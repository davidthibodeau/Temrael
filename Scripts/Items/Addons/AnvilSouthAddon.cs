using System;
using Server;
using Server.Regions;

namespace Server.Items
{
	public class AnvilSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new AnvilSouthDeed(); } }

		[Constructable]
		public AnvilSouthAddon()
		{
			AddComponent( new AnvilComponent( 0xFB0 ), 0, 0, 0 );
            Movable = false;
            CanBeAltered = false;
		}

		public AnvilSouthAddon( Serial serial ) : base( serial )
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
                    ((Container)Parent).AddItem(new AnvilSouthDeed());

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

	public class AnvilSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new AnvilSouthAddon(); } }
		public override int LabelNumber{ get{ return 1044334; } } // anvil (south)

		[Constructable]
		public AnvilSouthDeed()
		{
		}

		public AnvilSouthDeed( Serial serial ) : base( serial )
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