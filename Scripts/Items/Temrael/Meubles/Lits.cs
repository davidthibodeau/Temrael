using System;

namespace Server.Items
{
	[Furniture]
    [Flipable(0x0908, 0x0909, 0x090A, 0x090B)]
	public class LitDeuxEtages : Item
	{
		[Constructable]
        public LitDeuxEtages()
            : base(0x0908)
		{
			Weight = 10.0;
            Name = "Lit à deux étages";
		}

        public LitDeuxEtages(Serial serial)
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
    [Flipable(0x0A5A, 0x0A5B, 0x0A5C, 0x0A5D, 0x0A5E, 0x0A5F, 0x0A60, 0x0A61, 0x0A62, 0x0A63, 0x0A64,
        0x0A65, 0x0A66, 0x0A67, 0x0A68, 0x0A69, 0x0A6A, 0x0A6B)]
	public class LitSimple : Item
	{
		[Constructable]
		public LitSimple() : base( 0x0A5A )
		{
			Weight = 10.0;
            Name = "Lit simple";
		}

        public LitSimple(Serial serial)
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
    [Flipable(0x0A70, 0x0A71, 0x0A72, 0x0A73, 0x0A74, 0x0A75, 0x0A76, 0x0A77, 0x0A78, 0x0A79, 0x0A7A, 0x0A7B,
        0x0A7C, 0x0A7D, 0x0A7E, 0x0A7F, 0x0A80, 0x0A81, 0x0A82, 0x0A83, 0x0A84, 0x0A85, 0x0A85, 0x0A86, 0x0A87,
        0x0A88, 0x0A89, 0x0A8A,0x0A8B,0x0A8C,0x0A8D,0x0A8E,0x0A8F,0x0A90, 0x0A91)]
	public class LitDouble : Item
	{
		[Constructable]
        public LitDouble()
            : base(0x0A70)
		{
			Weight = 10.0;
            Name = "Lit double";
		}

        public LitDouble(Serial serial)
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
}