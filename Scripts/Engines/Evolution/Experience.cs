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
        public bool XPMode { get; set; }

        [CommandProperty(AccessLevel.Batisseur)]
        public DateTime NextFiole { get; set; }

        [CommandProperty(AccessLevel.Batisseur)]
        public DateTime NextExp { get; set; }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Niveau { get; set; }

        public bool[,] Ticks { get; private set; }

        [CommandProperty(AccessLevel.Batisseur)]
        public int XP { get; set; }


        public void Serialize(GenericWriter writer)
        {
            writer.Write(0); //version
            
            writer.Write(XP);
            writer.Write(Niveau);
            writer.Write(XPMode);
            writer.Write(NextFiole);
            writer.Write(NextExp);

            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 9; j++)
                    writer.Write(Ticks[i, j]);
        }

        public Experience(GenericReader reader)
        {
            int version = reader.ReadInt();

            XP = reader.ReadInt();
            Niveau = reader.ReadInt();
            XPMode = reader.ReadBool();
            NextFiole = reader.ReadDateTime();
            NextExp = reader.ReadDateTime();

            Ticks = new bool[7, 9];
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 9; j++)
                    Ticks[i, j] = reader.ReadBool();
        }

        public Experience()
        {
            XPMode = true;
            NextFiole = DateTime.Now;
            NextExp = DateTime.Now.AddMinutes(20);
            Ticks = new bool[7, 9];
        }
    }
}
