using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    // Deux mains.
    public class Griffes : BaseKatar
    {
        //public override double DefMinDamage { get { return 6; } }
        //public override double DefMaxDamage { get { return 10; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Griffes()
            : base(0x295c)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Griffes";
        }

        public Griffes(Serial serial)
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

    public class Katar : BaseKatar
    {
        //public override double DefMinDamage { get { return 7; } }
        //public override double DefMaxDamage { get { return 12; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Katar()
            : base(0x295d)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Katars";
        }

        public Katar(Serial serial)
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

    public class Katara : BaseKatar
    {
        //public override double DefMinDamage { get { return 9; } }
        //public override double DefMaxDamage { get { return 14; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public Katara()
            : base(0x295e)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Kataras";
        }

        public Katara(Serial serial)
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
