using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Items
{
    class TeintureModif : BaseTeinture
    {
        private int m_Couleur = 0;
        public override int Couleur { get { return m_Couleur; } }

        [Constructable]
        public TeintureModif()
            : base(0xE28)
        {
            Weight = 0.1;
            Name = "Essence";
            Hue = Couleur;
        }

        public TeintureModif(IExtractable e)
            : base(0xE28)
        {
            Weight = 0.1;
            Name = "Essence " + e.getName;
            m_Couleur = e.getHue;
            Hue = Couleur;
        }

        public TeintureModif(Serial s)
            : base(s)
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
