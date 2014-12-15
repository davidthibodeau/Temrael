using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public class DagueEntrainement : BaseKnife
    {
        //public override int DefMinDamage { get { return 1; } }
        //public override int DefMaxDamage { get { return 4; } }
        public override int DefSpeed { get { return 45; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public DagueEntrainement()
            : base(0x1494)
        {
            Weight = 2.0;
            Name = "Dague d'entraînement";
        }

        public DagueEntrainement(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
    public class LanceEntrainement : BaseSpear
    {
        //public override int DefMinDamage { get { return 1; } }
        //public override int DefMaxDamage { get { return 4; } }
        public override int DefSpeed { get { return 45; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public LanceEntrainement()
            : base(0x1495)
        {
            Weight = 2.0;
            Name = "Lance d'entraînement";
        }

        public LanceEntrainement(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
    public class MasseEntrainement : BaseBashing
    {
        //public override int DefMinDamage { get { return 1; } }
        //public override int DefMaxDamage { get { return 4; } }
        public override int DefSpeed { get { return 45; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public MasseEntrainement()
            : base(0x1496)
        {
            Weight = 2.0;
            Name = "Masse d'entraînement";
        }

        public MasseEntrainement(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
    public class BatonEntrainement : BaseStaff
    {
        //public override int DefMinDamage { get { return 1; } }
        //public override int DefMaxDamage { get { return 4; } }
        public override int DefSpeed { get { return 45; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public BatonEntrainement()
            : base(0x1497)
        {
            Weight = 6.0;
            Name = "Bâton d'entraînement";
        }

        public BatonEntrainement(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
    public class EpeeEntrainement : BaseSword
    {
        //public override int DefMinDamage { get { return 1; } }
        //public override int DefMaxDamage { get { return 4; } }
        public override int DefSpeed { get { return 45; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public EpeeEntrainement()
            : base(0x1498)
        {
            Weight = 6.0;
            Name = "Épée d'entrainement";
        }

        public EpeeEntrainement(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
