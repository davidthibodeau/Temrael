using System;
using System.Collections.Generic;
using Server;

namespace Server.Systemes.Geopolitique
{
    //Wrapper class pour les listes d'employes dans les tresoriers.
    public class Employe
    {
        private Mobile m_Nom; // Employe 
        private string m_Titre; // Titre d'emploi
        private int m_Paie; // Montant par semaine
        private int m_Total; // Total du a l'employee
        private DateTime m_LastPaie; 
        private bool m_Removed; // Si l'employe fut retire de la liste mais possede toujours un montant a se faire payer.
        
        [CommandProperty(AccessLevel.GameMaster, true)]
        public Mobile Nom { get { return m_Nom; } set { m_Nom = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public string Titre { get { return m_Titre; } set { m_Titre = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Paie { get { return m_Paie; } set { m_Paie = value; } }
        [CommandProperty(AccessLevel.GameMaster, true)]
        public int Total { get { return m_Total; } set { m_Total = value; } }
        [CommandProperty(AccessLevel.GameMaster, true)]
        public DateTime LastPaie { get { return m_LastPaie; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public bool Removed { get { return m_Removed; } set { m_Removed = value; } }

        public void Payer()
        {
            if (m_LastPaie.CompareTo(DateTime.Now) >= 0)
                return;

            int annees = DateTime.Now.Year - m_LastPaie.Year;
            if(annees == 0)
            {
                int mois = DateTime.Now.Month - m_LastPaie.Month;
                if(mois == 0)
                {
                    int jours = DateTime.Now.Day - m_LastPaie.Day;
                    m_Total += jours * m_Paie / DaysInMonth(m_LastPaie.Month, DateTime.IsLeapYear(m_LastPaie.Year));
                    m_LastPaie = DateTime.Now;
                }
                else if (mois == 1)
                {
                    if (DateTime.Now.Day > m_LastPaie.Day)
                    {
                        m_Total += m_Paie;
                        m_LastPaie.AddMonths(1);
                        Payer();
                    }
                    else
                    {
                        int dayslastmonth = DaysInMonth(m_LastPaie.Month, DateTime.IsLeapYear(m_LastPaie.Year));
                        int jours = dayslastmonth - m_LastPaie.Day;
                        m_Total = jours * m_Paie / dayslastmonth;

                        int daysthismonth = DaysInMonth(DateTime.Now.Month, DateTime.IsLeapYear(DateTime.Now.Year));
                        jours = DateTime.Now.Day;
                        m_Total = jours * m_Paie / daysthismonth;
                        m_LastPaie = DateTime.Now;
                    }   
                }
                else
                {
                    m_Total += m_Paie;
                    m_LastPaie.AddMonths(1);
                    Payer();
                }
            }
            else if (annees == 1)
            {
                if (DateTime.Now.Month > m_LastPaie.Month)
                {
                    m_Total += m_Paie * 12;
                    m_LastPaie.AddYears(1);
                    Payer();
                }
                else
                {
                    if (m_LastPaie.Month < 12)
                    {
                        m_Total += m_Paie;
                        m_LastPaie.AddMonths(1);
                        Payer();
                    }
                    else if (DateTime.Now.Month > 1)
                    {
                        m_Total += m_Paie;
                        m_LastPaie.AddMonths(1);
                        Payer();
                    }
                    else // Il y a moins de 2 mois d'ecart.
                    {
                        if (DateTime.Now.Day > m_LastPaie.Day)
                        {
                            m_Total += m_Paie;
                            m_LastPaie.AddMonths(1);
                            Payer();
                        }
                        else
                        {
                            int dayslastmonth = DaysInMonth(m_LastPaie.Month, DateTime.IsLeapYear(m_LastPaie.Year));
                            int jours = dayslastmonth - m_LastPaie.Day;
                            m_Total = jours * m_Paie / dayslastmonth;

                            int daysthismonth = DaysInMonth(DateTime.Now.Month, DateTime.IsLeapYear(DateTime.Now.Year));
                            jours = DateTime.Now.Day;
                            m_Total = jours * m_Paie / daysthismonth;
                            m_LastPaie = DateTime.Now;
                        }
                    }
                }
            }
            else
            {
                m_Total += m_Paie * 12;
                m_LastPaie.AddYears(1);
                Payer();
            }
        }

        public int DaysInMonth(int month, bool leap)
        {
            switch (month)
            {
                case 1:
                    return 31;
                case 2:
                    return (leap ? 29 : 28);
                case 3:
                    return 31;
                case 4:
                    return 30;
                case 5:
                    return 31;
                case 6:
                    return 30;
                case 7:
                    return 31;
                case 8:
                    return 31;
                case 9:
                    return 30;
                case 10:
                    return 31;
                case 11:
                    return 30;
                case 12:
                    return 31;
                default:
                    return 0;
            }
        }


        public Employe(Mobile nom, string titre, int paie)
        {
            m_Nom = nom;
            m_Titre = titre;
            m_Paie = paie;
            m_Total = 0;
            m_LastPaie = DateTime.Now;
            m_Removed = false;
        }

        public Employe(GenericReader reader)
        {
            int version = reader.ReadInt();

            m_Nom = reader.ReadMobile();
            m_Titre = reader.ReadString();
            m_Paie = reader.ReadInt();
            m_Total = reader.ReadInt();
            m_LastPaie = reader.ReadDateTime();
            m_Removed = reader.ReadBool();
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write((int)0); // version

            writer.Write((Mobile)m_Nom);
            writer.Write((string)m_Titre);
            writer.Write((int)m_Paie);
            writer.Write((int)m_Total);
            writer.Write((DateTime)m_LastPaie);
            writer.Write((bool)m_Removed);
        }
    }

}
