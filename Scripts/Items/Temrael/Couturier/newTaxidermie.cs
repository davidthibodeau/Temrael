using System;

namespace Server.Items
{
    [Flipable(0x1E60, 0x1E67)]
	public class TeteOurs : Item, IDyable
	{
		[Constructable]
        public TeteOurs()
            : base(0x1E60)
		{
			Weight = 1.0;
            Name = "Tête d'ours";
		}

        public TeteOurs(Serial serial)
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


    [Flipable(0x1E61, 0x1E68)]
    public class TeteCerf : Item, IDyable
    {
        [Constructable]
        public TeteCerf()
            : base(0x1E61)
        {
            Weight = 1.0;
            Name = "Tête de cerf";
        }

        public TeteCerf(Serial serial)
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
    [Flipable(0x1E62, 0x1E69)]
    public class PoissonPlanche : Item, IDyable
    {
        [Constructable]
        public PoissonPlanche()
            : base(0x1E62)
        {
            Weight = 1.0;
            Name = "Poisson sur planche";
        }

        public PoissonPlanche(Serial serial)
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

    [Flipable(0x1E63, 0x1E6A)]
    public class TeteOgre : Item, IDyable
    {
        [Constructable]
        public TeteOgre()
            : base(0x1E63)
        {
            Weight = 1.0;
            Name = "Tête d'ogre";
        }

        public TeteOgre(Serial serial)
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

    [Flipable(0x1E64, 0x1E6B)]
    public class TeteOrc : Item, IDyable
    {
        [Constructable]
        public TeteOrc()
            : base(0x1E64)
        {
            Weight = 1.0;
            Name = "Tête d'orc";
        }

        public TeteOrc(Serial serial)
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

    [Flipable(0x1E65, 0x1E6C)]
    public class TeteOursPolaire : Item, IDyable
    {
        [Constructable]
        public TeteOursPolaire()
            : base(0x1E65)
        {
            Weight = 1.0;
            Name = "Tête d'ours polaire";
        }

        public TeteOursPolaire(Serial serial)
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

    [Flipable(0x1E66, 0x1E6D)]
    public class TeteTroll : Item, IDyable
    {
        [Constructable]
        public TeteTroll()
            : base(0x1E66)
        {
            Weight = 1.0;
            Name = "Tête de troll";
        }

        public TeteTroll(Serial serial)
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