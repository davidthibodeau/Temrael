using System;

namespace Server.Items
{
	public class GrandVaseBec : Item
	{
		[Constructable]
		public GrandVaseBec() : base(0x0B45)
		{
			Weight = 2;
            Name = "Grand vase à bec";
		}

		public GrandVaseBec(Serial serial) : base(serial)
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
	
	public class PetitVaseBec : Item
	{
		[Constructable]
		public PetitVaseBec() : base(0x0B46)
		{
			Weight = 2;
            Name = "Petit vase à bec";
		}

		public PetitVaseBec(Serial serial) : base(serial)
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
	
	public class GrandVase : Item
	{
		[Constructable]
		public GrandVase() : base(0x0B47)
		{
			Weight = 2;
            Name = "Grand vase";
		}

		public GrandVase(Serial serial) : base(serial)
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
	
	public class PetitVase : Item
	{
		[Constructable]
		public PetitVase() : base(0x0B48)
		{
			Weight = 2;
            Name = "Petit vase";
		}

		public PetitVase(Serial serial) : base(serial)
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
	
	public class VaseRose : Item
	{
		[Constructable]
		public VaseRose() : base(0x0EB0)
		{
			Weight = 2;
            Name = "Vase rose";
		}

		public VaseRose(Serial serial) : base(serial)
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
	
	public class PetitPot : Item
	{
		[Constructable]
		public PetitPot() : base(0x11C6)
		{
			Weight = 2;
            Name = "Petit pot";
		}

		public PetitPot(Serial serial) : base(serial)
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
	
		public class GrandPot : Item
	{
		[Constructable]
		public GrandPot() : base(0x11C7)
		{
			Weight = 2;
            Name = "Grand pot";
		}

		public GrandPot(Serial serial) : base(serial)
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