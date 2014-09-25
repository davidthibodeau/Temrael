using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public class DagueEntrainement : BaseSword
    {
        public override int DefStrengthReq { get { return Dague_Force0; } }
        public override int DefMinDamage { get { return Dague_MinDam0; } }
        public override int DefMaxDamage { get { return Dague_MaxDam0; } }
        public override int DefSpeed { get { return Dague_Vitesse; } }

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
        public override int DefStrengthReq { get { return Lance_Force0; } }
        public override int DefMinDamage { get { return Lance_MinDam0; } }
        public override int DefMaxDamage { get { return Lance_MaxDam0; } }
        public override int DefSpeed { get { return Lance_Vitesse; } }

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
        public override int DefStrengthReq { get { return Masse_Force0; } }
        public override int DefMinDamage { get { return Masse_MinDam0; } }
        public override int DefMaxDamage { get { return Masse_MaxDam0; } }
        public override int DefSpeed { get { return Masse_Vitesse; } }

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
        public override int DefStrengthReq { get { return Baton_Force0; } }
        public override int DefMinDamage { get { return Baton_MinDam0; } }
        public override int DefMaxDamage { get { return Baton_MaxDam0; } }
        public override int DefSpeed { get { return Baton_Vitesse; } }

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
        public override int DefStrengthReq { get { return Lame_Force0; } }
        public override int DefMinDamage { get { return Lame_MinDam0; } }
        public override int DefMaxDamage { get { return Lame_MaxDam0; } }
        public override int DefSpeed { get { return Lame_Vitesse; } }

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
