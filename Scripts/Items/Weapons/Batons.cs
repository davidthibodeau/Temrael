using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class Batondruide : BaseStaff
    {
        public override int DefMinDamage { get { return 11; } }
        public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Batondruide()
            : base(0x29c9)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Baton de druide";
        }

        public Batondruide(Serial serial)
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