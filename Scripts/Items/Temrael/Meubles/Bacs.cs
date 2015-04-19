using System;

namespace Server.Items
{
    [Flipable(0x0B41, 0x0B42, 0x0B43, 0x0B44)]
    [Furniture]
    public class BacDeau : BaseContainer
	{
		[Constructable]
        public BacDeau()
            : base(0x0B41)
		{
			Weight = 5.0;
            Name = "Bac d'eau";
		}

        public BacDeau(Serial serial)
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

    [Flipable(0x22BC, 0x22BD, 0x22BE, 0x22BF)]
    [Furniture]
    public class BacNourriture : BaseContainer
    {
        [Constructable]
        public BacNourriture()
            : base(0x22BC)
        {
            Weight = 5.0;
            Name = "Bac de nourriture";
        }

        public BacNourriture(Serial serial)
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

    [Flipable(0x22C0, 0x22C1, 0x22C2, 0x22C3)]
    [Furniture]
    public class BacVide : BaseContainer
    {
        [Constructable]
        public BacVide()
            : base(0x22C0)
        {
            Weight = 5.0;
            Name = "Bac vide";
        }

        public BacVide(Serial serial)
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