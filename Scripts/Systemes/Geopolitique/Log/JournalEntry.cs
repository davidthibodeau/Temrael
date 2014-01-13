using System;
using System.Collections.Generic;
using System.Text;
using Server.Systemes.Geopolitique;

namespace Server.Systemes.Geopolitique.Log
{

    public enum EntryType 
    { 
        CreerCategorie, 
    }

    public class JournalEntry
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
                    + categorie.Parent != null ? " en tant que sous catégorie de " + categorie.Parent : "." ;
            }
        }

        public CreerCategorieEntry(Mobile from, Categorie cat)
            : base(from)
        {
            categorie = cat;
        }

    }

}
