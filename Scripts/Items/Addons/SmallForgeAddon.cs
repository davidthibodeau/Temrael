using System;
using Server;
using Server.Regions;

namespace Server.Items
{
	public class SmallForgeAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new SmallForgeDeed(); } }

		[Constructable]
		public SmallForgeAddon()
		{
			AddComponent( new ForgeComponent( 0xFB1 ), 0, 0, 0 );
            Movable = false;
            CanBeAltered = false;
		}

		public SmallForgeAddon( Serial serial ) : base( serial )
		{
		}

        public override bool CanBePlacedInRegion(Point3D p, Map map)
        {
            return Region.Find(p, map) is VilleHurlevent;
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

            writer.Write((int)1); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            if (version == 0)
            {
                if (Parent != null && Parent is Container)
                {
                    ((Container)Parent).AddItem(new SmallForgeDeed());

                    Delete();
                }
                else
                {
                    Movable = false;
                    CanBeAltered = false;
                }
            }
		}
	}

	public class SmallForgeDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new SmallForgeAddon(); } }
		public override int LabelNumber{ get{ return 1044330; } } // small forge

		[Constructable]
		public SmallForgeDeed()
		{
		}

		public SmallForgeDeed( Serial serial ) : base( serial )
		{
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