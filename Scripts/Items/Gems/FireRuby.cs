using System;
using Server;

namespace Server.Items
{
    public class FireRuby : BaseGem
    {
        public override int m_Couleur
        {
            get { return 2367; }
        }

        [Constructable]
        public FireRuby()
            : this(1)
        {
        }

        [Constructable]
        public FireRuby(int amountFrom, int amountTo)
            : this(Utility.RandomMinMax(amountFrom, amountTo))
        {
        }

        [Constructable]
        public FireRuby(int amount)
            : base(0x3197)
        {
            Stackable = true;
            Amount = amount;
        }

        public FireRuby(Serial serial)
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