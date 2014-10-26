using System;

namespace Server.Items
{
	[Furniture]
	[Flipable( 0x18B6, 0x18B7 )]
	public class EtagereA : Item
	{
		[Constructable]
		public EtagereA() : base( 0x18B6 )
		{
			Weight = 2.0;
            Name = "Support de bois clair";
		}

		public EtagereA(Serial serial) : base(serial)
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
	[Flipable( 0x18B8, 0x18B9 )]
	public class EtagereB : Item
	{
		[Constructable]
		public EtagereB() : base( 0x18B8 )
		{
			Weight = 2.0;
            Name = "Support de bois brut";
		}

		public EtagereB(Serial serial) : base(serial)
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
	[Flipable( 0x18BA, 0x18BB )]
	public class EtagereC : Item
	{
		[Constructable]
		public EtagereC() : base( 0x18BA )
		{
			Weight = 2.0;
            Name = "Support de bois bourgogne";
		}

		public EtagereC(Serial serial) : base(serial)
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
	[Flipable( 0x2320, 0x2321 )]
	public class EtagereD : Item
	{
		[Constructable]
		public EtagereD() : base( 0x2320 )
		{
			Weight = 5.0;
            Name = "Etagère sur trois niveaux claire";
		}

		public EtagereD(Serial serial) : base(serial)
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
	[Flipable( 0x2322, 0x2323 )]
	public class EtagereE : Item
	{
		[Constructable]
		public EtagereE() : base( 0x2322 )
		{
			Weight = 5.0;
            Name = "Etagère sur trois niveaux bourgogne";
		}

		public EtagereE(Serial serial) : base(serial)
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
	[Flipable( 0x2340, 0x2341 )]
	public class EtagereF : Item
	{
		[Constructable]
		public EtagereF() : base( 0x2340 )
		{
			Weight = 5.0;
            Name = "Etagère sur trois niveaux sombre";
		}

		public EtagereF(Serial serial) : base(serial)
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
	[Flipable( 0x189D, 0x189E )]
	public class EtagereG : Item
	{
		[Constructable]
		public EtagereG() : base( 0x189D)
		{
			Weight = 2.0;
            Name = "Support de bois sombre";
		}

		public EtagereG(Serial serial) : base(serial)
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