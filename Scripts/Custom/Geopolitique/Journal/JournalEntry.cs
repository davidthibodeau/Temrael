using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Systemes.Geopolitique.Journal
{
    public class JournalEntry
    {
        private Mobile m_Createur;

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
