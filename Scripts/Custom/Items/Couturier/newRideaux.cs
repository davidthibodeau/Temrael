using System;

namespace Server.Items
{
    [Flipable(0x154E, 0x154F, 0x1557)]
	public class RideauSurSocle : Item, IDyable
	{
		[Constructable]
        public RideauSurSocle()
            : base(0x154E)
		{
			Weight = 1.0;
            Name = "Rideau sur socle";
		}

        public RideauSurSocle(Serial serial)
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

    [Flipable(0x160D, 0x160E)]
    public class RideauDroit : Item, IDyable
    {
        [Constructable]
        public RideauDroit()
            : base(0x160D)
        {
            Weight = 1.0;
            Name = "Rideau droit";
        }

        public RideauDroit(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

        }

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.Hue;

            return true;
        }
    }

    [Flipable(0x3D9D, 0x3D9E, 0x3DA0, 0x3DA1)]
    public class RideauBlanc : Item, IDyable
    {
        [Constructable]
        public RideauBlanc()
            : base(0x3D9D)
        {
            Weight = 1.0;
            Name = "Rideau blanc";
        }

        public RideauBlanc(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

        }

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.Hue;

            return true;
        }
    }

    [Flipable(0x3DA3, 0x3DA6)]
    public class RideauBlancSimple : Item, IDyable
    {
        [Constructable]
        public RideauBlancSimple()
            : base(0x3DA3)
        {
            Weight = 1.0;
            Name = "Rideau blanc simple";
        }

        public RideauBlancSimple(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

        }

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.Hue;

            return true;
        }
    }

    [Flipable(0x3D9C, 0x3D9F, 0x3DAB, 0x3DAC)]
    public class RideauDessus : Item, IDyable
    {
        [Constructable]
        public RideauDessus()
            : base(0x3D9C)
        {
            Weight = 1.0;
            Name = "Dessus de rideau";
        }

        public RideauDessus(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

        }

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.Hue;

            return true;
        }
    }
}