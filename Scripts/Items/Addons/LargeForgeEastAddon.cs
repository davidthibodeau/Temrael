using System;
using Server;
using Server.Regions;

namespace Server.Items
{
	public class LargeForgeEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new LargeForgeEastDeed(); } }

		[Constructable]
		public LargeForgeEastAddon()
		{
			AddComponent( new ForgeComponent( 0x1986 ), 0, 0, 0 );
			AddComponent( new ForgeComponent( 0x198A ), 0, 1, 0 );
			AddComponent( new ForgeComponent( 0x1996 ), 0, 2, 0 );
			AddComponent( new ForgeComponent( 0x1992 ), 0, 3, 0 );
            Movable = false;
            CanBeAltered = false;
		}

		public LargeForgeEastAddon( Serial serial ) : base( serial )
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
                    ((Container)Parent).AddItem(new LargeForgeEastDeed());

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

	public class LargeForgeEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new LargeForgeEastAddon(); } }
		public override int LabelNumber{ get{ return 1044331; } } // large forge (east)

		[Constructable]
		public LargeForgeEastDeed()
		{
		}

		public LargeForgeEastDeed( Serial serial ) : base( serial )
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