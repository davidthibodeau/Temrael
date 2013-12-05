using System;

namespace Server.Items
{
	[Furniture]
	public class FruitContainerA : Item
	{
		[Constructable]
		public FruitContainerA() : base( 0x3C2D )
		{
			Weight = 5.0;
		}

		public FruitContainerA(Serial serial) : base(serial)
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
	public class FruitContainerB : Item
	{
		[Constructable]
		public FruitContainerB() : base( 0x3C2E )
		{
			Weight = 5.0;
		}

		public FruitContainerB(Serial serial) : base(serial)
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
	public class FruitContainerC : Item
	{
		[Constructable]
		public FruitContainerC() : base( 0x3C2F )
		{
			Weight = 5.0;
		}

		public FruitContainerC(Serial serial) : base(serial)
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
	public class FruitContainerD : Item
	{
		[Constructable]
		public FruitContainerD() : base( 0x3C30 )
		{
			Weight = 5.0;
		}

		public FruitContainerD(Serial serial) : base(serial)
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
	public class FruitContainerE : Item
	{
		[Constructable]
		public FruitContainerE() : base( 0x3C31 )
		{
			Weight = 5.0;
		}

		public FruitContainerE(Serial serial) : base(serial)
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
	public class FruitContainerF : Item
	{
		[Constructable]
		public FruitContainerF() : base( 0x3C32 )
		{
			Weight = 5.0;
		}

		public FruitContainerF(Serial serial) : base(serial)
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
	[Flipable( 0x3C33, 0x3C34 )]
	public class FruitContainerG : Item
	{
		[Constructable]
		public FruitContainerG() : base( 0x3C33 )
		{
			Weight = 5.0;
		}

		public FruitContainerG(Serial serial) : base(serial)
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
	[Flipable( 0x3C35, 0x3C36 )]
	public class FruitContainerH : Item
	{
		[Constructable]
		public FruitContainerH() : base( 0x3C35 )
		{
			Weight = 5.0;
		}

		public FruitContainerH(Serial serial) : base(serial)
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
	[Flipable( 0x3C37, 0x3C38 )]
	public class FruitContainerI : Item
	{
		[Constructable]
		public FruitContainerI() : base( 0x3C37 )
		{
			Weight = 5.0;
		}

		public FruitContainerI(Serial serial) : base(serial)
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
	[Flipable( 0x3C39, 0x3C3A )]
	public class FruitContainerJ : Item
	{
		[Constructable]
		public FruitContainerJ() : base( 0x3C39 )
		{
			Weight = 5.0;
		}

		public FruitContainerJ(Serial serial) : base(serial)
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