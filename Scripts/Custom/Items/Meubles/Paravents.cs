using System;

namespace Server.Items
{
	[Furniture]
	[Flipable( 0x1945, 0x1946 )]
	public class ParaventA : Item
	{
		[Constructable]
		public ParaventA() : base( 0x1945 )
		{
			Weight = 10.0;
            Name = "Paravent bourgogne";
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

			if ( Weight == 6.0 )
				Weight = 10.0;
		}
	}
	
	[Furniture]
	[Flipable( 0x24CB, 0x24CC, 0x24CD, 0x24CE, 0x24CF )]
	public class ParaventB : Item
	{
		[Constructable]
		public ParaventB() : base( 0x24CB )
		{
			Weight = 10.0;
            Name = "Paravent papier";
		}

		public ParaventB(Serial serial) : base(serial)
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

			if ( Weight == 6.0 )
				Weight = 10.0;
		}
	}
	
	[Furniture]
    [Flipable(0x24D0, 0x24D1, 0x24D2, 0x24D3, 0x24D4)]
	public class ParaventC : Item
	{
		[Constructable]
		public ParaventC() : base( 0x24D0 )
		{
			Weight = 10.0;
            Name = "Paravent bambou";
		}

		public ParaventC(Serial serial) : base(serial)
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

			if ( Weight == 6.0 )
				Weight = 10.0;
		}
	}
	

}