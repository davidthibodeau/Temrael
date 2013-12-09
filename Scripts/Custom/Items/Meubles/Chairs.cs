using System;

namespace Server.Items
{
	[Furniture]
	[Flipable( 0x03A1, 0x03A2, 0x03A3, 0x03A4 )]
	public class ChairA : Item
	{
		[Constructable]
		public ChairA() : base( 0x3A1 )
		{
			Weight = 2.0;
		}

		public ChairA(Serial serial) : base(serial)
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
	[Flipable( 0x03B1, 0x03B2)]
	public class ChairB : Item
	{
		[Constructable]
		public ChairB() : base( 0x3B1 )
		{
			Weight = 2.0;
		}

		public ChairB(Serial serial) : base(serial)
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
	[Flipable( 0x0B32, 0x0B33)]
	public class ChairC : Item
	{
		[Constructable]
		public ChairC() : base( 0xB32 )
		{
			Weight = 2.0;
		}

		public ChairC(Serial serial) : base(serial)
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


	

	/*[Furniture]
	[Flipable( 0x1945, 0x1946 )]
	public class ParaventA : Item
	{
		[Constructable]
		public ParaventA() : base( 0x1945 )
		{
			Weight = 5.0;
		}

		public ParaventA(Serial serial) : base(serial)
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
	*/
	

}