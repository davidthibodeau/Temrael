using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Evolution
{
    [PropertyObject]
    public class Experience
    {
        [CommandProperty(AccessLevel.Batisseur)]
        //false = daily. true = hebdo
        public bool XPMode { get; set; } // TODO: Default should be true

        [CommandProperty(AccessLevel.Batisseur)]
        public DateTime NextFiole { get; set; }

        [CommandProperty(AccessLevel.Batisseur)]
        public DateTime NextExp { get; set; }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Niveau { get; set; }

        public bool[,] Ticks { get; private set; }

        [CommandProperty(AccessLevel.Batisseur)]
        public int XP { get; set; }

    }
}
