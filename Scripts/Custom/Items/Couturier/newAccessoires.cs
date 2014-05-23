using System;

namespace Server.Items
{
    [Flipable(0x11EA, 0x13A5)]
	public class OreillerDePaille : Item, IDyable
	{
		[Constructable]
        public OreillerDePaille()
            : base(0x11EA)
		{
			Weight = 1.0;
            Name = "Oreiller de paille";
		}

        public OreillerDePaille(Serial serial)
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

    [Flipable(0x11F0, 0x11F1, 0x11F2, 0x11F3)]
    public class Hamac : Item, IDyable
    {
        [Constructable]
        public Hamac()
            : base(0x11F0)
        {
            Weight = 1.0;
            Name = "Hamac";
        }

        public Hamac(Serial serial)
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

    [Flipable(0x11FD, 0x11FE, 0x11FF, 0x1200)]
    public class LitDeCamp : Item, IDyable
    {
        [Constructable]
        public LitDeCamp()
            : base(0x11FD)
        {
            Weight = 1.0;
            Name = "Lit de camp";
        }

        public LitDeCamp(Serial serial)
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