using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Server.Systemes.Geopolitique
{
    public class Categorie
    {
        private string m_Nom;
        private List<Categorie> m_Categories;
        private List<Terre> m_Terres;
        private Categorie m_Parent;

        public string Nom { get { return m_Nom; } set { m_Nom = value; } }
        public Categorie Parent { get { return m_Parent; } set { m_Parent = value; } }

        public int CategoriesCount { get { return m_Categories.Count; } }
        public int TerresCount { get { return m_Terres.Count; } }

        public void AjouterCategorie(Categorie cat)
        {
            m_Categories.Add(cat);
        }

        public Categorie CategorieParIndex(int i)
        {
            return m_Categories[i];
        }

        public IEnumerable<Categorie> Categories()
        {
            foreach (Categorie c in m_Categories)
                yield return c;
        }

        public void AjouterTerre(Terre t)
        {
            m_Terres.Add(t);
        }

        public Terre TerreParIndex(int i)
        {
            return m_Terres[i];
        }

        public IEnumerable<Terre> Terres()
        {
            foreach (Terre t in m_Terres)
                yield return t;
        }

        public Categorie(Categorie parent, string nom)
        {
            m_Categories = new List<Categorie>();
            m_Terres = new List<Terre>();
            m_Parent = parent;
            m_Nom = nom;
            
        }

        public Categorie(Categorie parent, XmlElement node)
        {
            m_Categories = new List<Categorie>();
            m_Terres = new List<Terre>();
            m_Parent = parent;
            m_Nom = Utility.GetText(node["nom"], null);

            if (node != null)
            {
                foreach (XmlElement ele in node.GetElementsByTagName("categorie"))
                {
                    m_Categories.Add(new Categorie(this, ele));
                }

                foreach (XmlElement ele in node.GetElementsByTagName("terre"))
                {
                    m_Terres.Add(new Terre(this, ele));
                }
            }
        }
 
        public void Save(XmlTextWriter xml)
        {
            xml.WriteStartElement("nom");
            xml.WriteString(m_Nom);
            xml.WriteEndElement();

            foreach (Categorie cat in m_Categories)
            {
                xml.WriteStartElement("categorie");
                cat.Save(xml);
                xml.WriteEndElement();
            }
            foreach (Terre terre in m_Terres)
            {
                xml.WriteStartElement("terre");
                terre.Save(xml);
                xml.WriteEndElement();
            }
        }
    }
}
