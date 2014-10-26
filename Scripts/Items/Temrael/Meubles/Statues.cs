using System;

namespace Server.Items
{
	[Furniture]
    [Flipable(0x2D0E, 0x2D0F)]
	public class StatueBoisFemme : Item
	{
		[Constructable]
        public StatueBoisFemme()
            : base(0x2D0E)
		{
			Weight = 10.0;
            Name = "Statue de femme";
		}

        public StatueBoisFemme(Serial serial)
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

			if ( Weight == 6.0 )
				Weight = 10.0;
		}
	}
	
	[Furniture]
    [Flipable(0x2D12, 0x2D13)]
	public class StatueBoisHomme : Item
	{
		[Constructable]
		public StatueBoisHomme() : base( 0x24CB )
		{
			Weight = 10.0;
            Name = "Statue d'homme";
		}

        public StatueBoisHomme(Serial serial)
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

			if ( Weight == 6.0 )
				Weight = 10.0;
		}
	}
	
	[Furniture]
    [Flipable(0x2D10, 0x2D11)]
	public class StatueBoisEcureuil : Item
	{
		[Constructable]
		public StatueBoisEcureuil() : base( 0x24D0 )
		{
			Weight = 10.0;
            Name = "Statue d'écureuil";
		}

        public StatueBoisEcureuil(Serial serial)
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

			if ( Weight == 6.0 )
				Weight = 10.0;
		}
	}
}