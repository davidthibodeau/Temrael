using System;
using System.Collections.Generic;

namespace Server.Engines.Identities
{
    public enum IdentityType { Base, Transformation, Cachee }

    [PropertyObject]
    public class Identity
    {
        private Dictionary<Mobile, string> names;

        [CommandProperty(AccessLevel.Chroniqueur)]
        public IdentityType IdType { get; private set; }

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

        public Identity(IdentityType type)
        {
            IdType = type;
            names = new Dictionary<Mobile, string>();
        }

        public Identity(IdentityType type, GenericReader reader)
            : this(type)
        {
            int version = reader.ReadInt();
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

        public void Reset()
        {
            names = new Dictionary<Mobile, string>();
        }

        public override string ToString()
        {
            return IdType.ToString();
        }
    }

    public class IdentiteCachee : Identity
    {
        public override string this[Mobile m]
        {
            get { return "Identite Cachee"; }
            set { }
        }

        public IdentiteCachee()
            : base(IdentityType.Cachee)
        {
        }
    }
}

