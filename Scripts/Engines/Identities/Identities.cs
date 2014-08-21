using System;
using System.Collections.Generic;
using Server.Mobiles;

namespace Server.Engines.Identities
{
    public class Identities
    {
        private readonly Mobile m_Mobile;
    
        //14 Avec Tief + 0 based
        private string[] m_Identity = new string[]{
            "", //1,
            "", //2,
            "", //3,
            "", //4,
            "", //5,
            "", //6,
            "", //7,
            "", //8
            "", //9
            "", //10
            "", //11
            "", //12
            "", //13
            "" //14
        };

        private List<Identity> KnewIdentity = new List<Identity>();

        private int m_currentIdentity = 0;
        private bool m_Disguised = false;
        private bool m_DisguiseHidden = false;
        private bool m_RevealIdentity = true;

        [CommandProperty(AccessLevel.Batisseur)]
        public bool RevealIdentity
        {
            get { return m_RevealIdentity; }
            set { m_RevealIdentity = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int CurrentIdentity
        {
            get { return m_currentIdentity; }
            set { m_currentIdentity = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public bool Disguised
        {
            get { return m_Disguised; }
            set { m_Disguised = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public bool DisguiseHidden
        {
            get { return m_DisguiseHidden; }
            set { m_DisguiseHidden = value; }
        }

        public string this[int i]
        {
            get
            {
                if (i == 0 && (m_Identity[0] == "" || m_Identity[0] == null))
                    m_Identity[0] = m_Mobile.Name;
                return m_Identity[i];
            }
            set { m_Identity[i] = value; }
        }

        public Identities(Mobile mobile)
        {
            m_Mobile = mobile;
        }

        public Identities(GenericReader reader)
        {
            int version = reader.ReadInt();

            m_Mobile = reader.ReadMobile();

            int count = reader.ReadInt();
            m_Identity = new string[count];
            for (int i = 0; i < count; i++)
            {
                m_Identity[i] = reader.ReadString();
            }

            count = reader.ReadInt();
            for (int i = 0; i < count; i++)
            {
                KnewIdentity.Add(new Identity(reader));
            }

            m_currentIdentity = reader.ReadInt();
            m_Disguised = reader.ReadBool();
            m_DisguiseHidden = reader.ReadBool();
            m_RevealIdentity = reader.ReadBool();
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write(0); //version

            writer.Write(m_Mobile);

            writer.Write(m_Identity.Length);
            foreach(string s in m_Identity)
            {
                writer.Write(s);
            }

            writer.Write(KnewIdentity.Count);
            foreach(Identity i in KnewIdentity)
            {
                i.Serialize(writer);
            }

            writer.Write(m_currentIdentity);
            writer.Write(m_Disguised);
            writer.Write(m_DisguiseHidden);
            writer.Write(m_RevealIdentity);
        }

        public void ConvertPre9Ident(GenericReader reader)
        {
            int IdentityCount = reader.ReadInt();
            m_Identity = new string[IdentityCount];
            for (int i = 0; i < IdentityCount; i++)
            {
                m_Identity[i] = reader.ReadString();
            }
        }

        public void ConvertPre9Knew(GenericReader reader)
        {
            int count = reader.ReadInt();
            for (int i = 0; i < count; i++)
            {
                KnewIdentity.Add(new Identity(reader.ReadInt(), reader.ReadString(), reader.ReadInt()));
            }
        }

        public void NewName(string name, Mobile m)
        {
            PlayerMobile mob = m as PlayerMobile;
            if (mob == null)
                return;

            if (m_DisguiseHidden && !m_RevealIdentity)
            {
                m_Mobile.SendMessage("Vous n'etes pas apte a identifier ce personnage.");
                return;
            }

            Identity self = new Identity(m_Mobile.Serial, name, CurrentIdentity);

            Identity ident = mob.Identities.KnewIdentity.Find(x => x == self);
            if (ident == null)
                mob.Identities.KnewIdentity.Add(self);
            else
                ident.name = name;
        }

        public string GetNameUseBy(Mobile from)
        {           
            if (from == m_Mobile)
                return this[CurrentIdentity];

            if ((m_Mobile.Account != null && m_Mobile.Account.AccessLevel > AccessLevel.Player) || (from.Account != null && from.Account.AccessLevel > AccessLevel.Player))
                return (CurrentIdentity == 0 ? this[CurrentIdentity] : this[0] + " (" + this[CurrentIdentity] + ")");

            if (m_DisguiseHidden && !m_RevealIdentity)
                return "Identite Cachee";

            if (from is PlayerMobile)
            {
                Identities idfrom = ((PlayerMobile)from).Identities;

                Identity self = new Identity(m_Mobile.Serial, "", CurrentIdentity);

                Identity ident = idfrom.KnewIdentity.Find(x => x == self);
                if (ident != null)
                    return ident.name;
            }

            return DefaultName(from);
        }

        private string DefaultName(Mobile from)
        {
            return "Anonyme";
        }
    }
}

