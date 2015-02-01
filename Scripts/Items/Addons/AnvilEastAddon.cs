using System;
using Server;
using Server.Regions;

namespace Server.Items
{
	public class AnvilEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new AnvilEastDeed(); } }

		[Constructable]
		public AnvilEastAddon()
		{
			AddComponent( new AnvilComponent( 0xFAF ), 0, 0, 0 );
            Movable = false;
            CanBeAltered = false;
		}

		public AnvilEastAddon( Serial serial ) : base( serial )
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
                    ((Container)Parent).AddItem(new AnvilEastDeed());

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

	public class AnvilEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new AnvilEastAddon(); } }
		public override int LabelNumber{ get{ return 1044333; } } // anvil (east)

		[Constructable]
		public AnvilEastDeed()
		{
		}

		public AnvilEastDeed( Serial serial ) : base( serial )
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