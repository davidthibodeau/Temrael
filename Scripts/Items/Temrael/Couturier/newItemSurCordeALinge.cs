using System;

namespace Server.Items
{
    [Flipable(0x3C94, 0x3C95)]
	public class ChandailSurpendu : Item, IDyable
	{
		[Constructable]
        public ChandailSurpendu()
            : base(0x3C94)
		{
			Weight = 1.0;
            Name = "Chandail suspendu";
		}

        public ChandailSurpendu(Serial serial)
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
    public class PantalonSurpendu : Item, IDyable
    {
        [Constructable]
        public PantalonSurpendu()
            : base(0x3C98)
        {
            Weight = 1.0;
            Name = "Pantalon suspendu";
        }

        public PantalonSurpendu(Serial serial)
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
    public class DrapSurpendu : Item, IDyable
    {
        [Constructable]
        public DrapSurpendu()
            : base(0x3C9C)
        {
            Weight = 1.0;
            Name = "Drap suspendu";
        }

        public DrapSurpendu(Serial serial)
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
    public class JupeSurpendu : Item, IDyable
    {
        [Constructable]
        public JupeSurpendu()
            : base(0x3C9E)
        {
            Weight = 1.0;
            Name = "Jupe suspendue";
        }

        public JupeSurpendu(Serial serial)
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
    public class HaillonSurpendu : Item, IDyable
    {
        [Constructable]
        public HaillonSurpendu()
            : base(0x3CA0)
        {
            Weight = 1.0;
            Name = "Haillon suspendu";
        }

        public HaillonSurpendu(Serial serial)
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
    public class RideauSurpendu : Item, IDyable
    {
        [Constructable]
        public RideauSurpendu()
            : base(0x3CA0)
        {
            Weight = 1.0;
            Name = "Rideau suspendu";
        }

        public RideauSurpendu(Serial serial)
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