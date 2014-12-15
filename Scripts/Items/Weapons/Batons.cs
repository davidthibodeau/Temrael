using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class BatonDruide : BaseStaff
    {
        //public override int DefMinDamage { get { return 11; } }
        //public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public BatonDruide()
            : base(0x29c9)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Baton de druide";
        }

        public BatonDruide(Serial serial)
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

    public class BatonElement : BaseStaff
    {
        //public override int DefMinDamage { get { return 11; } }
        //public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public BatonElement()
            : base(0x317d)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Baton des éléments";
        }

        public BatonElement(Serial serial)
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

    public class BatonElfique : BaseStaff
    {
        //public override int DefMinDamage { get { return 11; } }
        //public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public BatonElfique()
            : base(0x2894)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Baton elfique";
        }

        public BatonElfique(Serial serial)
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

    public class Batonentrainement : BaseStaff
    {
        //public override int DefMinDamage { get { return 6; } }
        //public override int DefMaxDamage { get { return 10; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Batonentrainement()
            : base(0x1497)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Baton d'entraînement";
        }

        public Batonentrainement(Serial serial)
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

    public class BatonOsseux : BaseStaff
    {
        //public override int DefMinDamage { get { return 11; } }
        //public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public BatonOsseux()
            : base(0x29c8)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Baton osseux";
        }

        public BatonOsseux(Serial serial)
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

    public class BatonSoleil : BaseStaff
    {
        //public override int DefMinDamage { get { return 11; } }
        //public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public BatonSoleil()
            : base(0x29c6)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Baton du soleil";
        }

        public BatonSoleil(Serial serial)
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

    public class BatonSorcier : BaseStaff
    {
        //public override int DefMinDamage { get { return 11; } }
        //public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public BatonSorcier()
            : base(0x317e)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Baton du sorcier";
        }

        public BatonSorcier(Serial serial)
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

    public class BatonTenebreux : BaseStaff
    {
        //public override int DefMinDamage { get { return 11; } }
        //public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public BatonTenebreux()
            : base(0x29c5)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Baton ténébreux";
        }

        public BatonTenebreux(Serial serial)
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

    public class Batonlumineux : BaseStaff
    {
        //public override int DefMinDamage { get { return 11; } }
        //public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public Batonlumineux()
            : base(0x29c7)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Baton lumineux";
        }

        public Batonlumineux(Serial serial)
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

    public class GnarledStaff: BaseStaff
    {
        //public override int DefMinDamage { get { return 11; } }
        //public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public GnarledStaff()
            : base(0x29cb)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Baton de voyage";
        }

        public GnarledStaff(Serial serial)
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

    public class Boulnar : BaseStaff
    {
        //public override int DefMinDamage { get { return 11; } }
        //public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public Boulnar()
            : base(0x29cd)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Boulnar";
        }

        public Boulnar(Serial serial)
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

    public class Crochire : BaseStaff
    {
        //public override int DefMinDamage { get { return 11; } }
        //public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public Crochire()
            : base(0x29cf)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Crochire";
        }

        public Crochire(Serial serial)
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

    public class BatonLourd : BaseStaff
    {
        //public override int DefMinDamage { get { return 13; } }
        //public override int DefMaxDamage { get { return 18; } }
        public override int DefSpeed { get { return 55; } }

        [Constructable]
        public BatonLourd()
            : base(0x29cc)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Baton lourd";
        }

        public BatonLourd(Serial serial)
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

    public class Seliphore : BaseStaff
    {
        //public override int DefMinDamage { get { return 11; } }
        //public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public Seliphore()
            : base(0x29ce)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Seliphore";
        }

        public Seliphore(Serial serial)
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

    public class Canne : BaseStaff
    {
        //public override int DefMinDamage { get { return 5; } }
        //public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Canne()
            : base(0x29c4)
        {
            Weight = 8.0;
            Layer = Layer.OneHanded;
            Name = "Canne";
        }

        public Canne(Serial serial)
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

    public class CanneOsseuse : BaseStaff
    {
        //public override int DefMinDamage { get { return 7; } }
        //public override int DefMaxDamage { get { return 12; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public CanneOsseuse()
            : base(0x13f8)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Canne osseuse";
        }

        public CanneOsseuse(Serial serial)
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

    public class BlackStaff : BaseStaff
    {
        //public override int DefMinDamage { get { return 11; } }
        //public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public BlackStaff()
            : base(0xdf0)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Baton noir";
        }

        public BlackStaff(Serial serial)
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

    public class ShepherdsCrook : BaseStaff
    {
        //public override int DefMinDamage { get { return 11; } }
        //public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public ShepherdsCrook()
            : base(0xe81)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Houlette du berger";
        }

        public ShepherdsCrook(Serial serial)
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

    public class QuarterStaff : BaseStaff
    {
        //public override int DefMinDamage { get { return 5; } }
        //public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public QuarterStaff()
            : base(0xe89)
        {
            Weight = 8.0;
            Layer = Layer.OneHanded;
            Name = "Baton de combat";
        }

        public QuarterStaff(Serial serial)
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

    public class Batonsauvage : BaseStaff
    {
        //public override int DefMinDamage { get { return 9; } }
        //public override int DefMaxDamage { get { return 13; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public Batonsauvage()
            : base(0x2a70)
        {
            Weight = 8.0;
            Layer = Layer.OneHanded;
            Name = "Baton du sauvage";
        }

        public Batonsauvage(Serial serial)
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

    public class Canalisateur : BaseStaff
    {
        //public override int DefMinDamage { get { return 9; } }
        //public override int DefMaxDamage { get { return 13; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public Canalisateur()
            : base(0x2a74)
        {
            Weight = 8.0;
            Layer = Layer.OneHanded;
            Name = "Canalisateur";
        }

        public Canalisateur(Serial serial)
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