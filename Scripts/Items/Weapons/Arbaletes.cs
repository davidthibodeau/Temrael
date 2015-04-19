using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class Arbalete : BaseArbalete
    {
        //public override double DefMinDamage { get { return 7; } }
        //public override double DefMaxDamage { get { return 12; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Arbalete()
            : base(0x3002)
        {
            Weight = 7.0;
            Layer = Layer.TwoHanded;
            Name = "Arbalete";
        }

        public Arbalete(Serial serial)
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

    public class ArbaleteLourde : BaseArbalete
    {
        //public override double DefMinDamage { get { return 11; } }
        //public override double DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 60; } }

        [Constructable]
        public ArbaleteLourde()
            : base(0x3003)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Arbalete Lourde";
        }

        public ArbaleteLourde(Serial serial)
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
    
    public class ArbaletePistolet : BaseArbalete
    {
        //public override double DefMinDamage { get { return 4; } }
        //public override double DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public ArbaletePistolet()
            : base(0x3040)
        {
            Weight = 8.0;
            Layer = Layer.OneHanded;
            Name = "Arbalete Pistolet";
        }

        public ArbaletePistolet(Serial serial)
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
        
    public class ArbaleteRepetition : BaseArbalete
    {
        //public override double DefMinDamage { get { return 4; } }
        //public override double DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 20; } }

        [Constructable]
        public ArbaleteRepetition()
            : base(0x303f)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Arbalete Repetition";
        }

        public ArbaleteRepetition(Serial serial)
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

    public class Arbavive : BaseArbalete
    {
        //public override double DefMinDamage { get { return 9; } }
        //public override double DefMaxDamage { get { return 14; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public Arbavive()
            : base(0x29c2)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Arbavive";
        }

        public Arbavive(Serial serial)
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

    public class Crossbow : BaseArbalete
    {
        public override int GoldValue { get { return 21; } }

        //public override double DefMinDamage { get { return 13; } }
        //public override double DefMaxDamage { get { return 18; } }
        public override int DefSpeed { get { return 70; } }

        [Constructable]
        public Crossbow()
            : base(0xf50)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Arbalete a manivelle";
        }

        public Crossbow(Serial serial)
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

    public class HeavyCrossbow : BaseArbalete
    {
        //public override double DefMinDamage { get { return 14; } }
        //public override double DefMaxDamage { get { return 19; } }
        public override int DefSpeed { get { return 80; } }

        [Constructable]
        public HeavyCrossbow()
            : base(0x13fd)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Heavy Crossbow";
        }

        public HeavyCrossbow(Serial serial)
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

    public class Lumitrait : BaseArbalete
    {
        //public override double DefMinDamage { get { return 6; } }
        //public override double DefMaxDamage { get { return 10; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Lumitrait()
            : base(0x29c0)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Lumitrait";
        }

        public Lumitrait(Serial serial)
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

    public class Percemurs : BaseArbalete
    {
        //public override double DefMinDamage { get { return 12; } }
        //public override double DefMaxDamage { get { return 20; } }
        public override int DefSpeed { get { return 80; } }

        [Constructable]
        public Percemurs()
            : base(0x29c1)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Percemurs";
        }

        public Percemurs(Serial serial)
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
