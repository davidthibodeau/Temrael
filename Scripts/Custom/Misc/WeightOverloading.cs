using System;
using Server;
using Server.Mobiles;
using Server.Movement;

namespace Server.Misc
{
	public enum DFAlgorithm
	{
		Standard,
		PainSpike
	}

	public class WeightOverloading
	{
		public static void Initialize()
		{
			EventSink.Movement += new MovementEventHandler( EventSink_Movement );
		}

		private static DFAlgorithm m_DFA;

		public static DFAlgorithm DFA
		{
			get{ return m_DFA; }
			set{ m_DFA = value; }
		}

		public static void FatigueOnDamage( Mobile m, int damage )
		{
			double fatigue = 0.0;

			switch ( m_DFA )
			{
				case DFAlgorithm.Standard:
				{
					fatigue = (damage * (100.0 / m.Hits) * ((double)m.Stam / 100)) - 5.0;
					break;
				}
				case DFAlgorithm.PainSpike:
				{
					fatigue = (damage * ((100.0 / m.Hits) + ((50.0 + m.Stam) / 100) - 1.0)) - 5.0;
					break;
				}
			}

			if ( fatigue > 0 )
				m.Stam -= (int)fatigue;
		}

		public const int OverloadAllowance = 4; // We can be four stones overweight without getting fatigued

		public static int GetMaxWeight( Mobile m )
		{
			//return ((( Core.ML && m.Race == Race.Human) ? 100 : 40 ) + (int)(3.5 * m.Str));
			//Moved to core virtual method for use there

			return m.MaxWeight;
		}

		public static void EventSink_Movement( MovementEventArgs e )
		{
            Mobile from = e.Mobile;

            if (!from.Player || !from.Alive || from.AccessLevel >= AccessLevel.Batisseur)
                return;

            int maxWeight = GetMaxWeight(from) + OverloadAllowance;
            int overWeight = (Mobile.BodyWeight + from.TotalWeight) - maxWeight;

            if (from.StamMax == 0 || from.ManaMax == 0 || from.Dex <= 0)
            {
                from.SendMessage("Impossible de marcher sans mana, stam ou dex maximale.");
                e.Blocked = true;
                return;
            }

            if ((e.Direction & Direction.Running) != 0 && from.Dex < 20)
            {
                from.SendMessage("Vous ne pouvez pas courir a moins de 20 de dexterite.");
                e.Blocked = true;
                return;
            }

            if (overWeight > 0)
            {
                from.Stam -= GetStamLoss(from, overWeight, (e.Direction & Direction.Running) != 0);

                if (from.Stam == 0)
                {
                    from.SendLocalizedMessage(500109); // You are too fatigued to move, because you are carrying too much weight!
                    e.Blocked = true;
                    return;
                }
            }

            if (((from.Stam * 100) / Math.Max(from.StamMax, 1)) < 1)
            {
                if ((e.Direction & Direction.Running) != 0 || from.Stam <= 1)
                    from.Stam -= 2;
            }

            if (from is PlayerMobile && (e.Direction & Direction.Running) != 0)
            {
                PlayerMobile pm = (PlayerMobile)from;
                TileType type = Deplacement.GetTileType(from);
                int amt, perte;
                int value = 0;
                bool isActive = Deplacement.IsActive(from);

                if (from.AccessLevel == AccessLevel.Player)
                {
                    if (isActive)
                    {
                        switch (type)
                        {
                            // TOCHECK LIBREDEPLACEMENT
                            case TileType.Desert: value = (int)(pm.Skills.Survie.Value); break;
                            case TileType.Jungle: value = (int)(pm.Skills.Survie.Value); break;
                            case TileType.Forest: value = (int)(pm.Skills.Survie.Value); break;
                            case TileType.Snow: value = (int)(pm.Skills.Survie.Value); break;
                            case TileType.Swamp: value = (int)(pm.Skills.Survie.Value); break;
                        }
                    }
                }

                /*if (pm.Ville == Ville.Ilidelwis && pm.Region != null && pm.Region is TerritoryRegion && ((TerritoryRegion)pm.Region).Races == Race.Daelwena)
                    isActive = false;

                if (pm.Ville == Ville.Najarhim && type == TileType.Desert)
                    isActive = false;*/

                amt = (from.Mounted ? 4 : 3);

                if (isActive && type != TileType.Other)
                {
                    perte = ((value + 12) - (value * 2));

                    if (value < 8 && Utility.Random(8) > value)
                        from.Stam -= 1;

                    if (value < 6 && Utility.Random(6) > value)
                        from.Stam -= 1;

                    if (value < 4 && Utility.Random(4) > value)
                        from.Stam -= 1;

                    amt += (from.Mounted ? 4 - perte / 2 : 3 - perte / 2);
                }

                if (amt < 1)
                    amt = 1;

                //amt += (int)(from.GetAttributValue(Attribut.Constitution) / 40);

                if ((++pm.StepsTaken % amt) == 0)
                    from.Stam -= 1;
            }

			/*Mobile from = e.Mobile;

			if ( !from.Alive || from.AccessLevel > AccessLevel.Player  )
				return;

			if ( !from.Player )
			{
				// Else it won't work on monsters.
				//Spells.Ninjitsu.DeathStrike.AddStep( from );
				return;
			}

			int maxWeight = GetMaxWeight( from ) + OverloadAllowance;
			int overWeight = (Mobile.BodyWeight + from.TotalWeight) - maxWeight;

			if ( overWeight > 0 )
			{
				from.Stam -= GetStamLoss( from, overWeight, (e.Direction & Direction.Running) != 0 );

				if ( from.Stam == 0 )
				{
					from.SendLocalizedMessage( 500109 ); // You are too fatigued to move, because you are carrying too much weight!
					e.Blocked = true;
					return;
				}
			}

			if ( ((from.Stam * 100) / Math.Max( from.StamMax, 1 )) < 10 )
				--from.Stam;

			if ( from.Stam == 0 )
			{
				from.SendLocalizedMessage( 500110 ); // You are too fatigued to move.
				e.Blocked = true;
				return;
			}

			if ( from is PlayerMobile )
			{
				int amt = ( from.Mounted ? 48 : 16 );
				PlayerMobile pm = (PlayerMobile)from;

				if ( (++pm.StepsTaken % amt) == 0 )
					--from.Stam;
			}

			//Spells.Ninjitsu.DeathStrike.AddStep( from );*/
		}

		public static int GetStamLoss( Mobile from, int overWeight, bool running )
		{
			int loss = 5 + (overWeight / 25);

			if ( from.Mounted )
				loss /= 3;

			if ( running )
				loss *= 2;

			return loss;
		}

		public static bool IsOverloaded( Mobile m )
		{
			if ( !m.Player || !m.Alive || m.AccessLevel > AccessLevel.Player )
				return false;

			return ( (Mobile.BodyWeight + m.TotalWeight) > (GetMaxWeight( m ) + OverloadAllowance) );
		}
	}
}