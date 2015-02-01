using System;

namespace Server.Items
{
    [Flipable(0x3C94, 0x3C95)]
	public class ChandailSuspendu : Item, IDyable
	{
		[Constructable]
        public ChandailSuspendu()
            : base(0x3C94)
		{
			Weight = 1.0;
            Name = "Chandail suspendu";
		}

        public ChandailSuspendu(Serial serial)
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

    [Flipable(0x3C98, 0x3C99)]
    public class PantalonSuspendu : Item, IDyable
    {
        [Constructable]
        public PantalonSuspendu()
            : base(0x3C98)
        {
            Weight = 1.0;
            Name = "Pantalon suspendu";
        }

        public PantalonSuspendu(Serial serial)
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

    [Flipable(0x3C9C, 0x3C9D)]
    public class DrapSuspendu : Item, IDyable
    {
        [Constructable]
        public DrapSuspendu()
            : base(0x3C9C)
        {
            Weight = 1.0;
            Name = "Drap suspendu";
        }

        public DrapSuspendu(Serial serial)
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

    [Flipable(0x3C9E, 0x3C9F)]
    public class JupeSuspendu : Item, IDyable
    {
        [Constructable]
        public JupeSuspendu()
            : base(0x3C9E)
        {
            Weight = 1.0;
            Name = "Jupe suspendue";
        }

        public JupeSuspendu(Serial serial)
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

    [Flipable(0x3CA0, 0x3CA1)]
    public class HaillonSuspendu : Item, IDyable
    {
        [Constructable]
        public HaillonSuspendu()
            : base(0x3CA0)
        {
            Weight = 1.0;
            Name = "Haillon suspendu";
        }

        public HaillonSuspendu(Serial serial)
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

    [Flipable(0x3CA0, 0x3CA1)]
    public class RideauSuspendu : Item, IDyable
    {
        [Constructable]
        public RideauSuspendu()
            : base(0x3CA0)
        {
            Weight = 1.0;
            Name = "Rideau suspendu";
        }

        public RideauSuspendu(Serial serial)
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