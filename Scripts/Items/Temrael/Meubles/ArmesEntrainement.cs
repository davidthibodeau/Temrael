using System;

namespace Server.Items
{
	[Furniture]
	public class DagueBois : Item
	{
		[Constructable]
		public DagueBois() : base( 0x1494 )
		{
			Weight = 5.0;
            Name = "Dague d'entrainement";
		}

        public DagueBois(Serial serial)
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

    [Furniture]
    public class LanceBois : Item
    {
        [Constructable]
        public LanceBois()
            : base(0x1495)
        {
            Weight = 5.0;
            Name = "Lance d'entrainement";
        }

        public LanceBois(Serial serial)
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

    [Furniture]
    public class MasseBois : Item
    {
        [Constructable]
        public MasseBois()
            : base(0x1496)
        {
            Weight = 5.0;
            Name = "Masse d'entrainement";
        }

        public MasseBois(Serial serial)
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

    [Furniture]
    public class BatonBois : Item
    {
        [Constructable]
        public BatonBois()
            : base(0x1497)
        {
            Weight = 5.0;
            Name = "Baton d'entrainement";
        }

        public BatonBois(Serial serial)
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

    [Furniture]
    public class EpeeBois : Item
    {
        [Constructable]
        public EpeeBois()
            : base(0x1495)
        {
            Weight = 5.0;
            Name = "Epée d'entrainement";
        }

        public EpeeBois(Serial serial)
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