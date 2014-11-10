using System;
using System.Collections;
using Server;
using Server.Targeting;
using Server.Movement;

namespace Server.Items
{
	public class Shovel : Item
	{
		[Constructable]
		public Shovel() : base( 0xF39 )
		{
            Name = "pelle";
			Weight = 5.0;
            Layer = Layer.TwoHanded;
		}

		public Shovel( Serial serial ) : base( serial )
		{
        }

        private static ArrayList m_List = new ArrayList();

        public static bool ContainsPoint(Point3D p)
        {
            return m_List.Contains(p);
        }

        public static bool AddPoint(Point3D p)
        {
            if (!ContainsPoint(p))
            {
                m_List.Add(p);
                return true;
            }

            return false;
        }

        public static void RemovePoint(Point3D p)
        {
            if (ContainsPoint(p))
                m_List.Remove(p);
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (BotaniqueSystem.Enabled)
            {
                from.SendMessage("Où voulez-vous pelleter?");
                from.BeginTarget(1, true, TargetFlags.None, new TargetCallback(ChooseLand_OnTarget));
            }
        }

        private void ChooseLand_OnTarget(Mobile from, object targeted)
        {
            if (Deleted || !Movable || !from.CheckAlive())
                return;

            if (targeted is LandTarget)
            {
                Point3D p = ((LandTarget)targeted).Location;

                /*if (p == Point3D.Zero || Map != Map.Felucca)
                {
                    from.SendMessage("Vous ne pouvez pelleter ici.");
                }*/
                if (from.Mounted)
                {
                    from.SendMessage("Vous ne pouvez pelleter en étant sur une monture.");
                }
                else if (ContainsPoint(p))
                {
                    from.SendMessage("Il n'y a pas assez de terre ici. Essayez ailleurs.");
                }
                else
                {
                    TileType tile = Deplacement.GetTileType(p, Map);

                    if (tile == TileType.Desert || tile == TileType.Forest || tile == TileType.Jungle || tile == TileType.Swamp || tile == TileType.Dirt)
                    {
                        from.Animate(32, 5, 1, true, false, 0);

                        Timer.DelayCall(TimeSpan.FromSeconds(2.0), new TimerStateCallback(Pelletage_Callback), new object[] { from, p, tile });
                    }
                    else
                    {
                        from.SendMessage("Ce type de terre ne peut être pelleté.");
                    }
                }
            }
            else
            {
                from.SendMessage("Vous devez choisir le sol.");
            }
        }

        private void Pelletage_Callback(object state)
        {
            object[] states = (object[])state;
            Mobile from = (Mobile)states[0];
            Point3D p = (Point3D)states[1];
            TileType tile = (TileType)states[2];

            if (Deleted || !Movable || !from.CheckAlive())
                return;
            
            if (from.Mounted)
            {
                from.SendMessage("Vous ne pouvez pelleter en étant sur une monture.");
            }
            else
            {
                if (ContainsPoint(p))
                {
                    from.SendMessage("Il n'y a pas assez de terre ici. Essayez ailleurs.");
                }
                else
                {
                    from.SendMessage("Verser la terre dans quel pot ou poche?");
                    from.BeginTarget(1, true, TargetFlags.None, new TargetStateCallback(ChooseBowl_OnTarget), new object[] { p, tile });
                }
            }
        }

        private void ChooseBowl_OnTarget(Mobile from, object targeted, object state)
        {
            if (targeted is BaseBowl)
            {
                if (Deleted || !Movable || !from.CheckAlive())
                    return;

                BaseBowl bowl = (BaseBowl)targeted;
                object[] states = (object[])state;
                Point3D p = (Point3D)states[0];
                
                if (from.Mounted)
                {
                    from.SendMessage("Vous ne pouvez verser la terre en étant sur une monture.");
                }
                else if (!bowl.IsChildOf(from.Backpack))
                {
                    from.SendMessage("{0} doit être dans votre sac.", bowl is EarthBag ? "La poche" : "Le pot");
                }
                else if (bowl.HasEarth)
                {
                    from.SendMessage("{0} doit être vide.", bowl is EarthBag ? "La poche" : "Le pot");
                }
                else
                {
                    if (ContainsPoint(p))
                    {
                        from.SendMessage("Il n'y a pas assez de terre ici. Essayez ailleurs.");
                    }
                    else
                    {
                        TileType tile = (TileType)states[1];
                        EarthType earthType;

                        switch (tile)
                        {
                            case TileType.Desert: earthType = EarthType.Desert; break;
                            case TileType.Forest: earthType = EarthType.Forest; break;
                            case TileType.Jungle: earthType = EarthType.Jungle; break;
                            case TileType.Swamp: earthType = EarthType.Swamp; break;
                            default: earthType = EarthType.Dirt; break;
                        }

                        bowl.AddEarth(earthType);
                        from.SendMessage("Vous remplissez {0} de terre.", bowl is EarthBag ? "la poche" : "le pot");

                        AddPoint(p);
                        new InternalTimer(p).Start();
                    }
                }
            }
            else
            {
                from.SendMessage("Vous devez choisir un pot ou une poche.");
            }
        }

        private class InternalTimer : Timer
        {
            private Point3D m_Location;

            public InternalTimer(Point3D p) : base(TimeSpan.FromMinutes(10))
            {
                m_Location = p;
            }

            protected override void OnTick()
            {
                Shovel.RemovePoint(m_Location);
            }
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
        {
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}