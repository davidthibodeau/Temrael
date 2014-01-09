using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Server.Systemes.Geopolitique
{
    //Wrapper pour la normalisation des types de terres et de leurs rentes
    public class TypeTerre
    {
        public static TypeTerre Empty { get { return new EmptyTerre(); } }
        
        private string m_Nom;
        private int m_Rente;

        public virtual string Nom { get { return m_Nom; } set { m_Nom = value; } }
        public virtual int Rente { get { return m_Rente; } set { m_Rente = value; } }

        public void delete()
        {
        }

        public TypeTerre(string nom, int rente)
        {
            m_Nom = nom;
            m_Rente = rente;
        }

        internal TypeTerre(XmlElement node)
        {
            m_Nom = Utility.GetText(node["nom"], null);
            m_Rente = Utility.GetXMLInt32(Utility.GetText(node["rentes"], "0"), 0);
        }

        internal void Save(XmlTextWriter xml)
        {
            xml.WriteStartElement("nom");
            xml.WriteString(m_Nom);
            xml.WriteEndElement();

            xml.WriteStartElement("rentes");
            xml.WriteString(XmlConvert.ToString(m_Rente));
            xml.WriteEndElement();
        }
    }

    // Utilisee pour declarer un type de terre constant.
    public class EmptyTerre : TypeTerre
    {

        public EmptyTerre() : base("", 0)
        {
        }

        public override string Nom { get { return ""; } set { } }
        public override int Rente { get { return 0; } set { } }
    }
}
