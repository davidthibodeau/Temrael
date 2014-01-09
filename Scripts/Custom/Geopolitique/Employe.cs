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
        private bool m_Removed; // Si l'employe fut retire de la liste mais possede toujours un montant a se faire payer.

        [CommandProperty(AccessLevel.GameMaster, true)]
        public Mobile Nom { get { return m_Nom; } set { m_Nom = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public string Titre { get { return m_Titre; } set { m_Titre = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Paie { get { return m_Paie; } set { m_Paie = value; } }
        [CommandProperty(AccessLevel.GameMaster, true)]
        public int Total { get { return m_Total; } set { m_Total = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public bool Removed { get { return m_Removed; } set { m_Removed = value; } }

        public Employe(Mobile nom, string titre, int paie)
        {
            m_Nom = nom;
            m_Titre = titre;
            m_Paie = paie;
            m_Total = 0;
            m_Removed = false;
        }

        public Employe(GenericReader reader)
        {
            int version = reader.ReadInt();

            m_Nom = reader.ReadMobile();
            m_Titre = reader.ReadString();
            m_Paie = reader.ReadInt();
            m_Total = reader.ReadInt();
            m_Removed = reader.ReadBool();
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write((Mobile)m_Nom);
            writer.Write((string)m_Titre);
            writer.Write((int)m_Paie);
            writer.Write((int)m_Total);
            writer.Write((bool)m_Removed);
        }
    }

}
