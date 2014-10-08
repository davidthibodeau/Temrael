using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    // Une main
    public class Masse : BaseBashing
    {
        public override int DefMinDamage { get { return 0; } }
        public override int DefMaxDamage { get { return 0; } }
        public override int DefSpeed { get { return 0; } }

        [Constructable]
        public Masse()
            : base(0x0000)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Masse";
        }

        public Masse(Serial serial)
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



    // Deux mains
    public class Masse : BaseBashing
    {
        public override int DefMinDamage { get { return 0; } }
        public override int DefMaxDamage { get { return 0; } }
        public override int DefSpeed { get { return 0; } }

        [Constructable]
        public Masse()
            : base(0x0000)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
            Name = "Masse";
        }

        public Masse(Serial serial)
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