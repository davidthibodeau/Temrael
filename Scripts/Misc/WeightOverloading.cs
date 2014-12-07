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

        const int PERTE_STAM_RUNNING = 2;
        const int MULTI_TILE_ACCIDENTE = 3; // Il coûte 3 fois plus cher de courrir sur du terrain accidenté que non.

		public static void EventSink_Movement( MovementEventArgs e )
		{
            Mobile from = e.Mobile;

            if (!from.Player || !from.Alive || from.AccessLevel >= AccessLevel.Batisseur)
                return;

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

            int overWeight = (Mobile.BodyWeight + from.TotalWeight) - (GetMaxWeight(from) + OverloadAllowance);
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


            if (from is PlayerMobile && (e.Direction & Direction.Running) != 0)
            {
                PlayerMobile pm = (PlayerMobile)from;

                int PerteStam = PERTE_STAM_RUNNING;
                int amt = (from.Mounted ?  4 : 3); // Nombre de pas de course avant de perdre de la stam.


                if (Deplacement.IsActive(from) && Deplacement.GetTileType(from) != TileType.Other) // Si terrain accidenté.
                {
                    PerteStam *= (1 + MULTI_TILE_ACCIDENTE - (MULTI_TILE_ACCIDENTE * (int)(pm.Skills.Survie.Value) / 100));
                }


                if ((++pm.StepsTaken % amt) == 0) // À chaque "amt" cases, le joueur perd de la stam.
                    from.Stam -= PerteStam;
            }
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

            // Fix pour les GMs en player avec .gm .
            if (int.MaxValue == GetMaxWeight(m))
            {
                return false;
            }

			return ( (Mobile.BodyWeight + m.TotalWeight) > (GetMaxWeight( m ) + OverloadAllowance) );
		}
	}
}