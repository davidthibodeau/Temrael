using System;

namespace Server.Items
{

	
	[Flipable( 0x13A4, 0x13A5)]
	public class CoussinA : Item, IDyable
	{
		[Constructable]
		public CoussinA() : base( 0x13A4 )
		{
			Weight = 1.0;
            Name = "Coussin";
		}

		public CoussinA(Serial serial) : base(serial)
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
	
	
	public class CoussinB : Item, IDyable
	{
		[Constructable]
		public CoussinB() : base( 0x1397 )
		{
			Weight = 1.0;
            Name = "Coussin";
		}

		public CoussinB(Serial serial) : base(serial)
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
	
	
	[Flipable( 0x13A9, 0x13AA)]
	public class CoussinC : Item, IDyable
	{
		[Constructable]
		public CoussinC() : base( 0x13A9 )
		{
			Weight = 1.0;
            Name = "Coussin";
		}

		public CoussinC(Serial serial) : base(serial)
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
	
	
	[Flipable( 0x13AD, 0x13AE)]
	public class CoussinD : Item, IDyable
	{
		[Constructable]
		public CoussinD() : base( 0x13AD )
		{
			Weight = 1.0;
            Name = "Coussin";
		}

		public CoussinD(Serial serial) : base(serial)
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
	
	
	public class CoussinE : Item, IDyable
	{
		[Constructable]
		public CoussinE() : base( 0x13A7 )
		{
			Weight = 1.0;
            Name = "Coussin";
		}

		public CoussinE(Serial serial) : base(serial)
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
	
		
	public class CoussinF : Item, IDyable
	{
		[Constructable]
		public CoussinF() : base( 0x13A8 )
		{
			Weight = 1.0;
            Name = "Coussin";
		}

		public CoussinF(Serial serial) : base(serial)
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
	
			
	public class CoussinG : Item, IDyable
	{
		[Constructable]
		public CoussinG() : base( 0x13AB )
		{
			Weight = 1.0;
            Name = "Coussin";
		}

		public CoussinG(Serial serial) : base(serial)
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
	
	
	public class CoussinH : Item, IDyable
	{
		[Constructable]
		public CoussinH() : base( 0x13AC )
		{
			Weight = 1.0;
            Name = "Coussin";
		}

		public CoussinH(Serial serial) : base(serial)
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
	
	public class CoussinI : Item, IDyable
	{
		[Constructable]
		public CoussinI() : base( 0x163A )
		{
			Weight = 1.0;
            Name = "Coussin";
		}

		public CoussinI(Serial serial) : base(serial)
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
	
	public class CoussinJ : Item, IDyable
	{
		[Constructable]
		public CoussinJ() : base( 0x163B )
		{
			Weight = 1.0;
            Name = "Coussin";
		}

		public CoussinJ(Serial serial) : base(serial)
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
}