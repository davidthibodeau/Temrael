using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Items
{
    public abstract class BaseGem : Item, IExtractable
    {
        public string getName
        {
            get { return Name; }
        }
        public int getHue
        {
            get { return m_Couleur; }
        }

        public abstract int m_Couleur
        {
            get;
        }

        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        public BaseGem(int itemID)
            : base(itemID)
        { }

        public BaseGem(Serial serial)
            : base(serial)
        { }
    }
}
