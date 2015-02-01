using System;

namespace Server.Items
{
    [Flipable(0x0A6C, 0x0A6D, 0x0A6E, 0x0A6F)]
	public class DrapGris : Item, IDyable
	{
		[Constructable]
		public DrapGris() : base( 0x0A6C )
		{
			Weight = 1.0;
            Name = "Drap gris";
		}

        public DrapGris(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
		
			public bool Dye( Mobile from, DyeTub sender )
		{
			if ( Deleted )
			return false;

			Hue = sender.Hue;

			return true;
		}
	}

    [Flipable(0x0A92, 0x0A93, 0x0A94, 0x0A95)]
	public class DrapBlanc : Item, IDyable
	{
		[Constructable]
        public DrapBlanc()
            : base(0x0A92)
		{
			Weight = 1.0;
            Name = "Drap blanc";
		}

        public DrapBlanc(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
		
			public bool Dye( Mobile from, DyeTub sender )
		{
			if ( Deleted )
			return false;

			Hue = sender.Hue;

			return true;
		}
	}
}