using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Timers;

namespace Server.Systemes.Geopolitique
{
    public class Terre
    {
        private string m_Nom;
        private int m_Type = -1; //Index de Geopolitique.types
        private int m_Fonds;
        private List<Rente> m_Rentes;
        private List<Tresorier> m_Tresoriers;
        private Categorie m_Parent;
        private DateTime m_LastPaiement;
        private Timer m_PaiementTimer;

        public TypeTerre Type
        {
            get 
            {
                if(m_Type == -1) return TypeTerre.Empty;
                return Geopolitique.types[m_Type];
            }
            set
            {
                if (value == TypeTerre.Empty)
                    m_Type = -1;
                else
                    m_Type = Geopolitique.types.IndexOf(value);
            }
        }

        public int Rente 
        { 
            get 
            {
                int rente = Type.Rente;
                foreach (Rente r in m_Rentes)
                {
                    rente += r.Ajout;
                }
                return rente;
            } 
        }

        public string Nom { get { return m_Nom; } set { m_Nom = value; } }
        public int Fonds { get { return m_Fonds; } set { m_Fonds = value; } }
        public Categorie Parent { get { return m_Parent; } set { m_Parent = value; } }
        
        
        public int RentesCount { get { return m_Rentes.Count; } }
        public int TresorierCount { get { return m_Tresoriers.Count; } }

        public void AjouterRente(string raison, int ajout)
        {
            m_Rentes.Add(new Rente(raison, ajout));
        }

        public Rente RenteParIndex(int i)
        {
            return m_Rentes[i];
        }

        public IEnumerable<Rente> Rentes()
        {
            foreach (Rente a in m_Rentes)
                yield return a;
        }

        public void AjouterTresorier(Tresorier t)
        {
            m_Tresoriers.Add(t);
        }

        public Tresorier TresorierParIndex(int i)
        {
            return m_Tresoriers[i];
        }

        public IEnumerable<Tresorier> Tresoriers()
        {
            foreach (Tresorier t in m_Tresoriers)
                yield return t;
        }

        public void PayerRente()
        {
            Fonds += Rente;
            m_LastPaiement = DateTime.Now;
        }

        private void OnPaiementEvent(object source, ElapsedEventArgs e)
        {
            PayerRente();
        }

        private void TimerProchaineRente()
        {
            DateTime now = DateTime.Now;
            DateTime next = new DateTime(now.Year, now.Month, 1).AddMonths(1).AddHours(2);
            
            m_PaiementTimer = new PaiementTimer(this, next - now);
            m_PaiementTimer.Start();
        }
        
		private class PaiementTimer : Timer
		{
            Terre terre;

            public PaiementTimer(Terre t, TimeSpan delay)
                : base(delay)
            {
                terre = t;

                Priority = TimerPriority.OneMinute;
            }

			protected override void OnTick()
			{
                terre.PayerRente();
                terre.TimerProchaineRente();
			}
		}

        public void SupprimerTerre()
        {
            foreach (Tresorier t in m_Tresoriers)
            {
                t.Terre = null;
            }
            m_Tresoriers.Clear();
            Parent.RetirerTerre(this);
        }

        public void RetirerTresorier(Tresorier t)
        {
            m_Tresoriers.Remove(t);
        }

        public Terre(Categorie parent, string nom)
        {
            m_Parent = parent;
            m_Nom = nom;

            m_Fonds = 0;
            m_Rentes = new List<Rente>();
            m_Tresoriers = new List<Tresorier>();
            TimerProchaineRente();
            m_LastPaiement = DateTime.Now;
        }

        public Terre(Categorie parent, XmlElement node)
        {
            m_Parent = parent;
            m_Rentes = new List<Rente>();
            m_Tresoriers = new List<Tresorier>();

            m_Nom = Utility.GetText(node["nom"], null);
            m_Type = Utility.GetXMLInt32(Utility.GetText(node["type"],"-1"), -1);
            m_Fonds = Utility.GetXMLInt32(Utility.GetText(node["fonds"], "0"), 0);

            foreach (XmlElement ele in node.GetElementsByTagName("rente"))
            {
                m_Rentes.Add(new Rente(ele));
            }

            foreach (XmlElement ele in node.GetElementsByTagName("tresorier"))
            {
                int serial = Utility.GetXMLInt32(Utility.GetText(ele, "0"), 0);
                Tresorier t = (Tresorier)World.FindMobile(serial);
                if (t != null)
                {
                    m_Tresoriers.Add(t);
                    t.Terre = this;
                }
            }

            m_LastPaiement = Utility.GetXMLDateTime(Utility.GetText(node["lastpaiement"], ""), DateTime.Now);

            DateTime thismonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            if (m_LastPaiement < thismonth)
                PayerRente();

            TimerProchaineRente();
        }

        internal void Save(XmlTextWriter xml)
        {
            xml.WriteStartElement("nom");
            xml.WriteString(m_Nom);
            xml.WriteEndElement();

            xml.WriteStartElement("type");
            xml.WriteString(XmlConvert.ToString(m_Type));
            xml.WriteEndElement();

            xml.WriteStartElement("fonds");
            xml.WriteString(XmlConvert.ToString(m_Fonds));
            xml.WriteEndElement();
                     
            foreach (Rente ajout in m_Rentes)
            {
                xml.WriteStartElement("rente");
                ajout.Save(xml);
                xml.WriteEndElement();
            }

            foreach (Tresorier t in m_Tresoriers)
            {
                xml.WriteStartElement("tresorier");
                xml.WriteString(t.Serial.Value.ToString());
                xml.WriteEndElement();
            }

            xml.WriteStartElement("lastpaiement");
            xml.WriteString(m_LastPaiement.ToString());
            xml.WriteEndElement();
        }
    }
}
