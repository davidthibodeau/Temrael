using System;
using Server;

namespace Server.Items
{
    public class BlueDiamond : BaseGem
    {
        public override int m_Couleur
        {
            get { return 2174; }
        }

        public override double m_SkillReq
        {
            get { return 90; }
        }

        [Constructable]
        public BlueDiamond()
            : this(1)
        {
        }

        [Constructable]
        public BlueDiamond(int amountFrom, int amountTo)
            : this(Utility.RandomMinMax(amountFrom, amountTo))
        {
        }

        [Constructable]
        public BlueDiamond(int amount)
            : base(0x3198)
        {
            Stackable = true;
            Amount = amount;
        }

        public BlueDiamond(Serial serial)
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
