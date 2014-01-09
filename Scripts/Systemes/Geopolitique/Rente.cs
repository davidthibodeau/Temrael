using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Server.Systemes.Geopolitique
{
    public class Rente
    {
        private string m_Raison;
        private int m_Ajout;

        public string Raison { get { return m_Raison; } set { m_Raison = value; } }
        public int Ajout { get { return m_Ajout; } set { m_Ajout = value; } }

        public Rente(string raison, int ajout)
        {
            m_Raison = raison;
            m_Ajout = ajout;
        }

        public Rente(XmlElement ele)
        {
            m_Raison = Utility.GetText(ele["raison"], null);
            m_Ajout = Utility.GetXMLInt32(Utility.GetText(ele["ajout"], "0"), 0);
        }

        internal void Save(XmlTextWriter xml)
        {
            xml.WriteStartElement("raison");
            xml.WriteString(m_Raison);
            xml.WriteEndElement();

            xml.WriteStartElement("ajout");
            xml.WriteString(XmlConvert.ToString(m_Ajout));
            xml.WriteEndElement();
        }
    }
}
