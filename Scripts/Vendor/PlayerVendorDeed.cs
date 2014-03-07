using System;
using Server;
using Server.Mobiles;
using Server.Multis;
using Server.Targeting;
using Server.Regions;

namespace Server.Items
{
	public class ContractOfEmployment : Item
	{
		public override int LabelNumber{ get{ return 1041243; } } // a contract of employment

		[Constructable]
		public ContractOfEmployment() : base( 0x14F0 )
		{
			Weight = 1.0;
			//LootType = LootType.Blessed;
		}

		public ContractOfEmployment( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); //version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void OnDoubleClick( Mobile from )
		{
			PlayerMobile pm = (PlayerMobile)from;
			
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
			else
			{
				//from.SendLocalizedMessage( 503248 ); // Your godly powers allow you to place this vendor whereever you wish.

                if (from is TMobile)
                {
                    TMobile tmob = from as TMobile;

                    if (tmob.GetAptitudeValue(Aptitude.Commerce) > 0)
                        from.Target = new PlaceTarget(this);
                    else
                        from.SendMessage("Vous n'avez pas d'aptitude de commerce.");
                }

				//Mobile v = new PlayerVendor( from, BaseHouse.FindHouseAt( from ) );

				//v.Direction = from.Direction & Direction.Mask;
				//v.MoveToWorld( from.Location, from.Map );

				//v.SayTo( from, 503246 ); // Ah! it feels good to be working again.

                //this.Delete();

			}
		}

        private class PlaceTarget : Target
        {
            private ContractOfEmployment m_Item;

            public PlaceTarget(ContractOfEmployment item)
                : base(3, true, TargetFlags.None)
            {
                m_Item = item;
                AllowNonlocal = true;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                //from.SendMessage(targeted.ToString());

                IPoint3D p = (IPoint3D)targeted;
                Point3D point = new Point3D(p.X, p.Y, p.Z);

                if (Region.Find(point, Map.Felucca).GetType().ToString().Contains("Commerce"))
                {
                    Mobile v = new PlayerVendor(from, BaseHouse.FindHouseAt(from));

                    v.Direction = from.Direction & Direction.Mask;
                    v.MoveToWorld(point, from.Map);

                    v.SayTo(from, "Je suis a votre service.");

                    m_Item.Delete();

                    //v.SayTo(from, 503246);
                }
                else
                {
                    from.SendMessage("Vous pouvez seulement placer un marchand dans une zone commercial.");
                }

            }
        }
    }
}
