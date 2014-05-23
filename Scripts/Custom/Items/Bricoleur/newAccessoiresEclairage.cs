using System;

namespace Server.Items
{
    [Flipable(0x09FC, 0x0A01)]
	public class SocleChandelleMural : Item
	{
		[Constructable]
        public SocleChandelleMural()
            : base(0x09FC)
		{
			Weight = 2;
            Name = "Socle à chandelle mural";
		}

        public SocleChandelleMural(Serial serial)
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
	}

    [Flipable(0x09FB, 0x0A00)]
	public class SocleEtChandelleMural : Item
	{
		[Constructable]
        public SocleEtChandelleMural()
            : base(0x09FB)
		{
			Weight = 2;
            Name = "Socle mural avec chandelle";
		}

        public SocleEtChandelleMural(Serial serial)
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
	}

    [Flipable(0x0A06, 0x0A0B)]
	public class SocleTorche : Item
	{
		[Constructable]
        public SocleTorche()
            : base(0x0A06)
		{
			Weight = 2;
            Name = "Socle à torche mural";
		}

        public SocleTorche(Serial serial)
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
	}

    [Flipable(0x0A05, 0x0A0A)]
	public class SocleEtTorche : Item
	{
		[Constructable]
        public SocleEtTorche()
            : base(0x0A05)
		{
			Weight = 2;
            Name = "Socle mural avec torche";
		}

        public SocleEtTorche(Serial serial)
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
	}

    [Flipable(0x0A28, 0x0A0A)]
    public class chandelleCire : Item
    {
        [Constructable]
        public chandelleCire()
            : base(0x0A28)
        {
            Weight = 2;
            Name = "Chandelle de cire";
        }

        public chandelleCire(Serial serial)
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
    }

    public class chandelleSurPied : Item
    {
        [Constructable]
        public chandelleSurPied()
            : base(0x0A26)
        {
            Weight = 2;
            Name = "Chandelle sur pied";
        }

        public chandelleSurPied(Serial serial)
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
    }

    public class chandelierCourt : Item
    {
        [Constructable]
        public chandelierCourt()
            : base(0x0A27)
        {
            Weight = 2;
            Name = "Court chandelier";
        }

        public chandelierCourt(Serial serial)
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
    }

    public class chandelierLong : Item
    {
        [Constructable]
        public chandelierLong()
            : base(0x0A27)
        {
            Weight = 2;
            Name = "Long chandelier";
        }

        public chandelierLong(Serial serial)
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
    }

    public class lanterneSurPied : Item
    {
        [Constructable]
        public lanterneSurPied()
            : base(0x0B21)
        {
            Weight = 2;
            Name = "Lanterne Sur Pied";
        }

        public lanterneSurPied(Serial serial)
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
    }

    public class lanterneSurPiedOrne : Item
    {
        [Constructable]
        public lanterneSurPiedOrne()
            : base(0x0B25)
        {
            Weight = 2;
            Name = "Lanterne Sur Pied Orné";
        }

        public lanterneSurPiedOrne(Serial serial)
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
    }
}