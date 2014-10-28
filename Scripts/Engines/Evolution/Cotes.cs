using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Evolution
{
    public class Cotes
    {
        private List<Cote> cotes = new List<Cote>();

        [CommandProperty(AccessLevel.Batisseur)]
        public DateTime LastCotation { get; set; }

        public void OctroyerCote(ValeurCote cote)
        {
            cotes.Add(new Cote(this, cote));
        }

    }
}
