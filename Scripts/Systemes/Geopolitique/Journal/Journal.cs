using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Systemes.Geopolitique.Journal
{
    public class Journal
    {
        private Dictionary<Mobile, List<JournalEntry>> entreesParCreateur;
        private Dictionary<EntryType, List<JournalEntry>> entreesParType;
    }
}
