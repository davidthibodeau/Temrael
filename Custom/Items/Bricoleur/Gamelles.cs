using System;

namespace Server.Items
{
	public class GamelleA: Item
	{
		[Constructable]
		public GamelleA() : base(0x097F)
		{
			Weight = 2;
		}

		public GamelleA(Serial serial) : base(serial)
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
	
	public class GamelleB: Item
	{
		[Constructable]
		public GamelleB() : base(0x09DD)
		{
			Weight = 2;
		}

		public GamelleB(Serial serial) : base(serial)
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
	
	public class GamelleC: Item
	{
		[Constructable]
		public GamelleC() : base(0x09DE)
		{
			Weight = 2;
		}

		public GamelleC(Serial serial) : base(serial)
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
	
	public class GamelleD: Item
	{
		[Constructable]
		public GamelleD() : base(0x09E1)
		{
			Weight = 2;
		}

		public GamelleD(Serial serial) : base(serial)
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
	
	public class GamelleE: Item
	{
		[Constructable]
		public GamelleE() : base(0x09E2)
		{
			Weight = 2;
		}

		public GamelleE(Serial serial) : base(serial)
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
	
	public class GamelleF: Item
	{
		[Constructable]
		public GamelleF() : base(0x09E4)
		{
			Weight = 2;
		}

		public GamelleF(Serial serial) : base(serial)
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
	
	public class GamelleG: Item
	{
		[Constructable]
		public GamelleG() : base(0x09E6)
		{
			Weight = 2;
		}

		public GamelleG(Serial serial) : base(serial)
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
	
	public class GamelleH: Item
	{
		[Constructable]
		public GamelleH() : base(0x09DC)
		{
			Weight = 2;
		}

		public GamelleH(Serial serial) : base(serial)
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
	
	public class GamelleI: Item
	{
		[Constructable]
		public GamelleI() : base(0x09E0)
		{
			Weight = 2;
		}

		public GamelleI(Serial serial) : base(serial)
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
	
	public class GamelleJ: Item
	{
		[Constructable]
		public GamelleJ() : base(0x09E5)
		{
			Weight = 2;
		}

		public GamelleJ(Serial serial) : base(serial)
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
	
	public class GamelleK: Item
	{
		[Constructable]
		public GamelleK() : base(0x09E7)
		{
			Weight = 2;
		}

		public GamelleK(Serial serial) : base(serial)
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
	
	public class GamelleL: Item
	{
		[Constructable]
		public GamelleL() : base(0x09E8)
		{
			Weight = 2;
		}

		public GamelleL(Serial serial) : base(serial)
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
	
	public class GamelleM: Item
	{
		[Constructable]
		public GamelleM() : base(0x09F3)
		{
			Weight = 2;
		}

		public GamelleM(Serial serial) : base(serial)
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

	public class GamelleN: Item
	{
		[Constructable]
		public GamelleN() : base(0x09DF)
		{
			Weight = 2;
		}

		public GamelleN(Serial serial) : base(serial)
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
	
	public class GamelleO: Item
	{
		[Constructable]
		public GamelleO() : base(0x09E3)
		{
			Weight = 2;
		}

		public GamelleO(Serial serial) : base(serial)
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
	
	public class GamelleP: Item
	{
		[Constructable]
		public GamelleP() : base(0x09ED)
		{
			Weight = 2;
		}

		public GamelleP(Serial serial) : base(serial)
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
	
		public class GamelleQ: Item
	{
		[Constructable]
		public GamelleQ() : base(0x09ED)
		{
			Weight = 2;
		}

		public GamelleQ(Serial serial) : base(serial)
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
		
		[FlipableAttribute(0x0974, 0x0975)]
		public class GamelleR: Item
	{
		[Constructable]
		public GamelleR() : base(0x0974)
		{
			Weight = 2;
		}

		public GamelleR(Serial serial) : base(serial)
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
	
	
	/*[FlipableAttribute(0x1EB1, 0x1EB2, 0x1EB3, 0x1EB4)]
	public class BarrelStaves : Item
	{
		[Constructable]
		public BarrelStaves() : base(0x1EB1)
		{
			Weight = 1;
		}

		public BarrelStaves(Serial serial) : base(serial)
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