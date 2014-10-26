using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Collections;

namespace Server.Engines.Identities
{
    [PropertyObject]
    public class Identities
    {
        [Flags]
        private enum StatutCachee
        {
            Revealed = 0x00,
            Foulard = 0x01,
            DesireCacher = 0x10,
            Cache = 0x11
        }

        private readonly Mobile m_Mobile;

        private Identity idCachee;
        private StatutCachee etatCachee;

        private Identity m_currentIdentity;
        private Identity couranteNonCachee;

        private Identity baseIdentity;
        private Identity transformationIdentity;
        private Identity[] deguisements;
        private Identity deguisementUnique;


        private bool m_Disguised = false;

        [CommandProperty(AccessLevel.Batisseur)]
        public bool RevealIdentity
        {
            get { return (((int)etatCachee) & 0x10) == 0x00; }
            set
            {
                if (!value)
                {
                    etatCachee = (StatutCachee)(0x10 | (int)etatCachee);
                    if (etatCachee == StatutCachee.Cache)
                        CacherIdentite();
                }
                else
                {
                    if (etatCachee == StatutCachee.Cache)
                        RevelerIdentite();
                    etatCachee = (StatutCachee)(0x01 & (int)etatCachee);
                }
            }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public Identity CurrentIdentity
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
            get { return (((int)etatCachee) & 0x01) == 0x00; }
            set
            {
                if (value)
                {
                    etatCachee = (StatutCachee)(0x01 | (int)etatCachee);
                    if (etatCachee == StatutCachee.Cache)
                        CacherIdentite();
                }
                else
                {
                    if (etatCachee == StatutCachee.Cache)
                        RevelerIdentite();
                    etatCachee = (StatutCachee)(0x10 & (int)etatCachee);
                }
            }
        }

        public Identity IdCachee
        {
            get { return idCachee; }
        }

        public Identities(Mobile mobile)
        {
            m_Mobile = mobile;
            baseIdentity = new Identity();
            baseIdentity[mobile] = mobile.Name;
            m_currentIdentity = baseIdentity;
            transformationIdentity = new Identity();
            idCachee = new IdentiteCachee();
        }

        public Identities(GenericReader reader)
        {
            int version = reader.ReadInt();

            m_Mobile = reader.ReadMobile();

            baseIdentity = new Identity(reader);
            m_currentIdentity = baseIdentity;
            transformationIdentity = new Identity(reader);
            idCachee = new IdentiteCachee(); //On ne sauvegarde pas idcache parce qu'il n'accumule pas d'informations.

        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write(0); //version

            writer.Write(m_Mobile);

            baseIdentity.Serialize(writer);
            transformationIdentity.Serialize(writer);
        }

        public void CacherIdentite()
        {
            if (m_currentIdentity == idCachee)
                return;

            couranteNonCachee = m_currentIdentity;
            m_currentIdentity = idCachee;
            m_Mobile.SendMessage("Votre identité est maintenant cachée.");
        }

        public void RevelerIdentite()
        {
            if (m_currentIdentity != idCachee)
                return;

            m_currentIdentity = couranteNonCachee;
            m_Mobile.SendMessage("Votre identité est maintenant révélée.");
        }

        public void Transformer()
        {
            if (m_currentIdentity == transformationIdentity)
                return;

            m_currentIdentity = transformationIdentity;
            m_Mobile.SendMessage("Vous êtes maintenant transformé.");
        }

        public void Detransformer()
        {
            if (m_currentIdentity != transformationIdentity)
                return;

            m_currentIdentity = baseIdentity;
            m_Mobile.SendMessage("Vous reprenez votre forme originelle.");
        }

        public void NewName(string name, Mobile m)
        {
            if (etatCachee == StatutCachee.Cache)
            {
                m_Mobile.SendMessage("Vous n'etes pas apte a identifier ce personnage.");
                return;
            }

            m_currentIdentity[m] = name;
        }

        public string GetNameUseBy(Mobile from)
        {          
            if ((m_Mobile.Account != null && m_Mobile.Account.AccessLevel > AccessLevel.Player))
                return m_Mobile.Name;

            if (from.Account != null && from.Account.AccessLevel > AccessLevel.Player)
                return (m_currentIdentity == baseIdentity ? m_Mobile.Name : m_Mobile.Name + " (" + m_currentIdentity[m_Mobile] + ")");

            return m_currentIdentity[from];
        }

        public override string ToString()
        {
            return "...";
        }
    }
}

