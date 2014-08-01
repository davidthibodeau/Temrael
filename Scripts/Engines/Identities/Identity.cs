using System;

namespace Server.Engines.Identities
{
    public class Identity : IEquatable<Identity>
    {
        private Serial m_serial;
        private string m_name;
        private int m_identity;

        public Serial serial { get { return m_serial; } set { m_serial = value; } }
        public string name { get { return m_name; } set { m_name = value; } }
        public int identity { get { return m_identity; } set { m_identity = value; } }

        public Identity()
        {
            m_serial = new Serial();
            m_name = "";
            m_identity = 0;
        }

        public Identity(Serial serial, string name, int identity)
        {
            m_serial = serial;
            m_name = name;
            m_identity = identity;
        }

        public Identity(GenericReader reader)
        {
            int version = reader.ReadInt();

            m_serial = reader.ReadInt();
            m_name = reader.ReadString();
            m_identity = reader.ReadInt();
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write(0); //version

            writer.Write(m_serial);
            writer.Write(m_name);
            writer.Write(m_identity);
        }

        public bool Equals(Identity other)
        {
            if (other == null)
                return false;

            if (m_serial == other.m_serial && m_identity == other.m_identity)
                return true;

            return false;
        }

        public override bool Equals(Object obj)
        {
            Identity idObj = obj as Identity;
            if (idObj == null)
                return false;
            else
                return Equals(idObj);
        }

        public override int GetHashCode()
        {
            return m_serial.GetHashCode() ^ m_identity.GetHashCode();
        }

        public static bool operator == (Identity id1, Identity id2)
        {
            if (id1 == null || id2 == null)
                return Object.Equals(id1, id2);

            return id1.Equals(id2);
        }

        public static bool operator != (Identity id1, Identity id2)
        {
            if (id1 == null || id2 == null)
                return !Object.Equals(id1, id2);

            return !id1.Equals(id2);
        }
    }
}

