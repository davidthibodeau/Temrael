using System;
using Server;

namespace Server.Items
{
    public class PerfectEmerald : BaseGem
    {
        public override int m_Couleur
        {
            get { return 2386; }
        }

        [Constructable]
        public PerfectEmerald()
            : this(1)
        {
        }

        [Constructable]
        public PerfectEmerald(int amountFrom, int amountTo)
            : this(Utility.RandomMinMax(amountFrom, amountTo))
        {
        }

        [Constructable]
        public PerfectEmerald(int amount)
            : base(0x3194)
        {
            Stackable = true;
            Amount = amount;
        }

        public PerfectEmerald(Serial serial)
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