using System;

namespace Server.Items
{
    public class DagueBois : BaseKnife
	{
        public override int DefSpeed { get { return 20; } }
        public override int DefMinDamage { get { return 1; } }
        public override int DefMaxDamage { get { return 2; } }
        
		[Constructable]
		public DagueBois() : base( 0x1494 )
		{
			Weight = 1.0;
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

    public class LanceBois : BaseSpear
    {
        public override int DefSpeed { get { return 20; } }
        public override int DefMinDamage { get { return 1; } }
        public override int DefMaxDamage { get { return 2; } }

        [Constructable]
        public LanceBois()
            : base(0x1495)
        {
            Weight = 2.0;
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

    public class MasseBois : BaseBashing
    {
        public override int DefSpeed { get { return 20; } }
        public override int DefMinDamage { get { return 1; } }
        public override int DefMaxDamage { get { return 2; } }

        [Constructable]
        public MasseBois()
            : base(0x1496)
        {
            Weight = 2.0;
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

    public class BatonBois : BaseStaff
    {
        public override int DefSpeed { get { return 20; } }
        public override int DefMinDamage { get { return 1; } }
        public override int DefMaxDamage { get { return 2; } }

        [Constructable]
        public BatonBois()
            : base(0x1497)
        {
            Weight = 2.0;
            Name = "Bâton d'entrainement";
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

    public class EpeeBois : BaseSword
    {
        public override int DefSpeed { get { return 20; } }
        public override int DefMinDamage { get { return 1; } }
        public override int DefMaxDamage { get { return 2; } }

        [Constructable]
        public EpeeBois()
            : base(0x1498)
        {
            Weight = 2.0;
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