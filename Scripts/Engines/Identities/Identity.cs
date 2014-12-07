using System;
using System.Collections.Generic;

namespace Server.Engines.Identities
{
    [PropertyObject]
    public class Identity
    {
        private Dictionary<Mobile, string> names;

        public virtual string this[Mobile m]
        {
            get
            {
                try
                {
                    return names[m];
                }
                catch
                {
                    return "Anonyme";
                }
            }
            set { names[m] = value; }
        }

        public Identity()
        {
            names = new Dictionary<Mobile, string>();
        }

        public Identity(GenericReader reader)
        {
            int version = reader.ReadInt();

            names = new Dictionary<Mobile,string>();
            int count = reader.ReadInt();
            for (int i = 0; i < count; i++)
            {
                Mobile m = reader.ReadMobile();
                string s = reader.ReadString();

                if (m != null)
                    names.Add(m, s);
            }
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write(0); //version

            writer.Write(names.Count);
            foreach (Mobile m in names.Keys)
            {
                writer.Write(m);
                writer.Write(names[m]);
            }
        }
    }

    public class IdentiteCachee : Identity
    {
        public override string this[Mobile m]
        {
            get { return "Identite Cachee"; }
            set { }
        }
    }
}

