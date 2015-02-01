using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Server.Engines.Geopolitique.Log
{
    public class Journal
    {
        private Dictionary<Mobile, List<JournalEntry>> entriesParCreateur;
        private Dictionary<EntryType, List<JournalEntry>> entriesParType;
        private Dictionary<DateTime, List<JournalEntry>> entriesParTimestamp;

        private List<JournalEntry> entries;

        public Journal()
        {
            entries = new List<JournalEntry>();
            entriesParCreateur = new Dictionary<Mobile, List<JournalEntry>>();
            entriesParType = new Dictionary<EntryType, List<JournalEntry>>();
            entriesParTimestamp = new Dictionary<DateTime, List<JournalEntry>>();
        }

        public Journal(XmlElement node) : this()
        {
            foreach (XmlElement ele in node.GetElementsByTagName("journalentry"))
            {
                EntryType type = EntryType.Invalide;
                try
                {
                    type = (EntryType) Enum.Parse(typeof(EntryType), Utility.GetText(node["type"], ""));
                }
                catch
                {
                    Console.WriteLine("ERREUR: Entrée invalide dans le journal de géopolitique.");
                    continue;
                }

                JournalEntry entry = null;
                switch(type)
                {
                    case EntryType.CreerCategorie:
                        entry = new CreerCategorieEntry(ele);
                        break;
                }

                AjouterEntryStrict(entry);
            }
        }

        /* On maintient 2 journaux, un local et un global. Chaque terre, categorie, 
         * tresorier, etc. maintient son journal local. Cette fonction va ajouter 
         * aux deux a la fois. La version stricte va seulement ajouter au journal local.
         * C'est pour eviter de dedoubler au deserialize.
         */ 
        public void AjouterEntry(JournalEntry entry)
        {
            if (this != Geopolitique.journal)
                Geopolitique.journal.AjouterEntryStrict(entry);
            AjouterEntryStrict(entry);
        }
    
        
        public void AjouterEntryStrict(JournalEntry entry)
        {
            if(entry == null)
                Console.WriteLine("Erreur: AjouterEntryStrict a été appelé avec un journalentry null");
            List<JournalEntry> j;
            if (entriesParCreateur.TryGetValue(entry.Createur, out j))
            {
                j.Add(entry);
            }
            else
            {
                j = new List<JournalEntry>();
                j.Add(entry);
                entriesParCreateur.Add(entry.Createur, j);
            }

            if (entriesParType.TryGetValue(entry.Type, out j))
            {
                j.Add(entry);
            }
            else
            {
                j = new List<JournalEntry>();
                j.Add(entry);
                entriesParType.Add(entry.Type, j);
            }

            if (entriesParTimestamp.TryGetValue(entry.Timestamp, out j))
            {
                j.Add(entry);
            }
            else
            {
                j = new List<JournalEntry>();
                j.Add(entry);
                entriesParTimestamp.Add(entry.Timestamp, j);
            }

            entries.Add(entry);
        }

        //public void
    }
}
