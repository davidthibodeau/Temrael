using System;

namespace Server.Items
{
	[Furniture]
    [Flipable(0x0AFD, 0x0AFE, 0x0AFF, 0x0B03, 0x0B04, 0x0B05, 0x0B0B, 0x0B0C)]
	public class TableDeVitre : Item
	{
		[Constructable]
        public TableDeVitre()
            : base(0x0AFD)
		{
			Weight = 2.0;
            Name = "Table";
		}

        public TableDeVitre(Serial serial)
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

    [Furniture]
    [Flipable(0x0B34, 0x0B35, 0x0B36, 0x0B37, 0x0B38, 0x0B39, 0x0B3A, 0x0B3C)]
    public class TableDeNuit : Item
    {
        [Constructable]
        public TableDeNuit()
            : base(0x0B34)
        {
            Weight = 2.0;
            Name = "Table de nuit";
        }

        public TableDeNuit(Serial serial)
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

    [Furniture]
    [Flipable(0x0B3D, 0x0B3E, 0x0B3F, 0x0B40)]
    public class TableDeBoisRustique : Item
    {
        [Constructable]
        public TableDeBoisRustique()
            : base(0x0B3D)
        {
            Weight = 2.0;
            Name = "Table de bois rustique";
        }

        public TableDeBoisRustique(Serial serial)
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

    [Furniture]
    [Flipable(0x0B6B, 0x0B6C, 0x0B6D, 0x0B7E, 0x0B7F, 0x0B80)]
    public class TableElegante : Item
    {
        [Constructable]
        public TableElegante()
            : base(0x0AFD)
        {
            Weight = 2.0;
            Name = "Table élégante";
        }

        public TableElegante(Serial serial)
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

    [Furniture]
    [Flipable(0x0B6E, 0x0B6F, 0x0B70, 0x0B71, 0x0B72, 0x0B73, 0x0B74, 0x0B81, 0x0B82, 0x0B83, 0x0B84, 0x0B85, 0x0B86, 0x0B87)]
    public class TableDeBoisSombre : Item
    {
        [Constructable]
        public TableDeBoisSombre()
            : base(0x0AFD)
        {
            Weight = 2.0;
            Name = "Table de bois sombre";
        }

        public TableDeBoisSombre(Serial serial)
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

    [Furniture]
    [Flipable(0x0B75, 0x0B76, 0x0B77, 0x0B78, 0x0B79, 0x0B7A, 0x0B7B, 0x0B88, 0x0B89, 0x0B8A, 0x0B8B, 0x0B8C, 0x0B8D, 0x0B8E)]
    public class TableDeBoisClair : Item
    {
        [Constructable]
        public TableDeBoisClair()
            : base(0x0AFD)
        {
            Weight = 2.0;
            Name = "Table de bois clair";
        }

        public TableDeBoisClair(Serial serial)
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