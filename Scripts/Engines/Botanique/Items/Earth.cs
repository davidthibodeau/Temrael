using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
    public class Earth : Item
    {
        private EarthType m_EarthType;

        [CommandProperty(AccessLevel.Batisseur)]
        public EarthType EarthType
        {
            get { return m_EarthType; }
            set
            {
                if (value == EarthType.None)
                    Delete();
                else
                    m_EarthType = value;
            }
        }

        [Constructable]
        public Earth() : this(EarthType.Forest)
        {
        }

        [Constructable]
        public Earth(EarthType type) : base(0xF3B)
        {
            Name = "terre";
            Weight = 10.0;
            Movable = false;

            m_EarthType = type;
        }

        public Earth(Serial serial) : base(serial)
        {
        }

        public override void OnSingleClick(Mobile from)
        {
            base.OnSingleClick(from);

            if (from is TMobile)
            {
                TMobile m = (TMobile)from;

                LabelTo(from, String.Format("[{0}]", BotaniqueSystem.GetEarthName(m_EarthType)));
            }
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