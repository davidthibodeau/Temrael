using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Server.Systemes.Geopolitique;

namespace Server.Systemes.Geopolitique.Log
{

    public enum EntryType
    {
        Invalide,
        CreerCategorie,
        CreerTerre,
        CreerTresorier,
    }

    public abstract class JournalEntry
    {
        private Mobile m_Createur;
        private DateTime m_Timestamp;

        public abstract EntryType Type { get; }
        public abstract string Message { get; }

        public Mobile Createur { get { return m_Createur; } }
        public DateTime Timestamp { get { return m_Timestamp; } }


        public JournalEntry(Mobile from)
        {
            m_Createur = from;
            m_Timestamp = DateTime.Now;
        }

        public JournalEntry(XmlElement root)
        {
            int serial = Utility.GetXMLInt32(Utility.GetText(root["createur"], "0"), 0);
            m_Createur = World.FindMobile(serial);

            m_Timestamp = Utility.GetXMLDateTime(Utility.GetText(root["timestamp"], null), DateTime.MinValue);
        }

        public void Save(XmlTextWriter xml)
        {
            xml.WriteStartElement("createur");
            xml.WriteString(m_Createur.Serial.Value.ToString());
            xml.WriteEndElement();

            xml.WriteStartElement("timestamp");
            xml.WriteString(XmlConvert.ToString(m_Timestamp, XmlDateTimeSerializationMode.Local));
            xml.WriteEndElement();
        }

    }

    public class CreerCategorieEntry : JournalEntry
    {
        private Categorie categorie;

        public override EntryType Type { get { return EntryType.CreerCategorie; } }
        public override string Message
        {
            get
            {
                return Createur + " a créé la catégorie " + categorie.Nom
                    + categorie.Parent != null ? " en tant que sous catégorie de " + categorie.Parent : ".";
            }
        }

        public CreerCategorieEntry(Mobile from, Categorie cat)
            : base(from)
        {
            categorie = cat;
        }

        public CreerCategorieEntry(XmlElement root)
            : base(root)
        {
            //Need a function to get the categorie from a uid.
            // Probably same thing needed for terre.
        }

    }

    public class CreerTerreEntry : JournalEntry
    {
        private Terre terre;

        public override EntryType Type { get { return EntryType.CreerTerre; } }
        public override string Message
        {
            get
            {
                return Createur + " a créé la terre " + terre.Nom
                    + terre.Parent != null ? " en tant que sous catégorie de " + terre.Parent.Nom : ".";
            }
        }

        public CreerTerreEntry(Mobile from, Terre t)
            : base(from)
        {
            terre = t;
        }

        public CreerTerreEntry(XmlElement root)
            : base(root)
        {
            //Need a function to get the categorie from a uid.
            // Probably same thing needed for terre.
        }

    }

    public class CreerTresorierEntry : JournalEntry
    {
        private Tresorier tresorier;

        public override EntryType Type { get { return EntryType.CreerTresorier; } }
        public override string Message
        {
            get
            {
                return Createur + " a créé le trésorier " + tresorier.Description
                    + tresorier.Terre != null ? " pour la terre " + tresorier.Terre.Nom : ".";
            }
        }

        public CreerTresorierEntry(Mobile from, Tresorier t)
            : base(from)
        {
            tresorier = t;
        }

        public CreerTresorierEntry(XmlElement root)
            : base(root)
        {
            //Need a function to get the categorie from a uid.
            // Probably same thing needed for terre.
        }

    }
}
