using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Evolution
{
    [PropertyObject]
    public class Cotes
    {
        private List<Cote> cotes = new List<Cote>();
        private List<RaisonCote> raisons = new List<RaisonCote>();

        [CommandProperty(AccessLevel.Batisseur, true)]
        public DateTime LastCotation { get; set; }
        [CommandProperty(AccessLevel.Batisseur, true)]
        public DateTime LastFiole { get; set; }
        [CommandProperty(AccessLevel.Batisseur, true)]
        public int AFKPenalite { get; set; }

        public RaisonCote this[int i] { get { return raisons[i]; } }
        public int Count { get { return raisons.Count; } }

        public void OctroyerCote(ValeurCote cote, Mobile from, int message)
        {
            cotes.Add(new Cote(this, cote));
            raisons.Add(new RaisonCote(from, message));
            LastCotation = DateTime.Now;
        }

        public void OctoyerFiole(Mobile from, byte message)
        {
            raisons.Add(new RaisonCote(from, message));
            LastFiole = DateTime.Now;
        }

        public void AFK(Mobile from)
        {
            OctroyerCote(ValeurCote.Interdit, from, 1);
            AFKPenalite += 3600;
        }

        public bool HasAFKPenalite()
        {
            if (AFKPenalite > 0)
            {
                AFKPenalite -= 20;
                return true;
            }
            return false;
        }

        public int OctroyerXP(int tick)
        {
            foreach (Cote cote in cotes)
            {
                if (tick <= 100)
                    break;

                tick -= cote.Consommer(tick);
            }

            return tick;
        }

        public Cotes()
        {
        }

        public Cotes(GenericReader reader)
        {
            int version = reader.ReadInt();

            LastCotation = reader.ReadDateTime();
            LastFiole = reader.ReadDateTime();

            int count = reader.ReadInt();

            for (int i = 0; i < count; i++)
            {
                cotes.Add(new Cote(this, reader));
            }

            count = reader.ReadInt();

            for (int i = 0; i < count; i++)
            {
                raisons.Add(new RaisonCote(reader));
            }
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write(0); //version

            writer.Write(LastCotation);
            writer.Write(LastFiole);

            for (int i = cotes.Count - 1; i > -1; i--)
            {
                if (!cotes[i].Active)
                    cotes.RemoveAt(i);
            }

            writer.Write(cotes.Count);

            foreach (Cote cote in cotes)
            {
                cote.Serialize(writer);
            }

            writer.Write(raisons.Count);

            foreach (RaisonCote raison in raisons)
            {
                raison.Serialize(writer);
            }
        }
    }
}
