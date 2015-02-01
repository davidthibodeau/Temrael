using System;

namespace Server.Items
{
	[FlipableAttribute(0x0E05, 0x0E06)]
	public class WigStand : Item
	{
		[Constructable]
		public WigStand() : base(0x0E05)
		{
			Weight = 1;
		}

		public WigStand(Serial serial) : base(serial)
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

	public class MannequinMale : Item
	{
		[Constructable]
		public MannequinMale() : base(0x0EC6)
		{
			Weight = 5;
		}

		public MannequinMale(Serial serial) : base(serial)
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
	
	public class MannequinFemale : Item
	{
		[Constructable]
		public MannequinFemale() : base(0x0EC7)
		{
			Weight = 5;
		}

		public MannequinFemale(Serial serial) : base(serial)
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
	
	public class PoupeeMale : Item
	{
		[Constructable]
		public PoupeeMale() : base(0x20CD)
		{
			Weight = 1;
		}

		public PoupeeMale(Serial serial) : base(serial)
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
	
	public class PoupeeFemale : Item
	{
		[Constructable]
		public PoupeeFemale() : base(0x20CE)
		{
			Weight = 1;
		}

		public PoupeeFemale(Serial serial) : base(serial)
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
	
	
	public class TeddyBear : Item
	{
		[Constructable]
		public TeddyBear() : base(0x2118)
		{
			Weight = 1;
		}

		public TeddyBear(Serial serial) : base(serial)
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
	
	public class WoodenHorse : Item
	{
		[Constructable]
		public WoodenHorse() : base(0x2121)
		{
			Weight = 5;
		}

		public WoodenHorse(Serial serial) : base(serial)
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