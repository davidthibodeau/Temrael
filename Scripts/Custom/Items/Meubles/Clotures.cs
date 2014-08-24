using System;

namespace Server.Items
{
    [Flipable(0x0646, 0x0647, 0x085C, 0x085D, 0x085E, 0x085F, 0x0861, 0x0877, 0x0878)]
	[Furniture]
	public class ClotureTroisPlanchesHorizontales : Item
	{
		[Constructable]
        public ClotureTroisPlanchesHorizontales()
            : base(0x0646)
		{
			Weight = 5.0;
            Name = "Clôture";
		}

        public ClotureTroisPlanchesHorizontales(Serial serial)
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

    [Flipable(0x0646, 0x0647, 0x085C, 0x085D, 0x085E, 0x085F, 0x0861, 0x0877, 0x0878)]
    public class ClotureTroisPlanchesVerticales : Item
	{
		[Constructable]
        public ClotureTroisPlanchesVerticales()
            : base(0x0646)
		{
			Weight = 5.0;
            Name = "Clôture";
		}

        public ClotureTroisPlanchesVerticales(Serial serial)
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

    public class CloturePlanchesCroisees : Item
    {
        [Constructable]
        public CloturePlanchesCroisees()
            : base(0x0720)
        {
            Weight = 5.0;
            Name = "Clôture";
        }

        public CloturePlanchesCroisees(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

        }
    }
}