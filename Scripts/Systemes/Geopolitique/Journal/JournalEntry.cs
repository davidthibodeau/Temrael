using System;
using System.Collections.Generic;
using System.Text;
using Server.Systemes.Geopolitique;

namespace Server.Systemes.Geopolitique.Journal
{

    public enum EntryType 
    { 
        CreerCategorie, 
    }

    public class JournalEntry
    {
        private Mobile m_Createur;

        public abstract EntryType Type;

        public Mobile Createur { get { return m_Createur; } }

        public JournalEntry(Mobile from)
        {
            m_Createur = from; 
        }
    }

    public class CreerCategorieEntry : JournalEntry
    {
        private Categorie categorie;

        public CreerCategorieEntry(Mobile from, Categorie cat)
            : base(from)
        {
            categorie = cat;
        }

    }

}
