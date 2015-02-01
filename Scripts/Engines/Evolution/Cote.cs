using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Evolution
{
    // Abstraction des valeurs de cote. De la pire a la meilleure.
    public enum ValeurCote { Interdit, Questionnable, Passable, Normal }

    public class Cote
    {
        // Valeur d'expérience qui reste à récupérer.
        private int xp; 
        private Cotes cotes;
        private ValeurCote cote;

        public bool Active { get { return xp != 0; } }
        
        public Cote(Cotes cotes, ValeurCote cote)
        {
            this.cotes = cotes;
            this.cote = cote;
            xp = ReductionExperience();
        }

        private int ReductionExperience()
        {
            switch (cote)
            {
                case ValeurCote.Normal: return 0;
                case ValeurCote.Passable: return 1000;
                case ValeurCote.Questionnable: return 2000;
                case ValeurCote.Interdit: return 5000;
                default: return 0;
            }
        }

        public int Consommer(int tick)
        {
            if (tick < 100)
                return 0;

            int valeur = 0;

            switch (cote)
            {
                case ValeurCote.Normal: valeur = 0; break;
                case ValeurCote.Passable: valeur = 25; break;
                case ValeurCote.Questionnable: valeur = 50; break;
                case ValeurCote.Interdit: valeur = 100; break;
            }

            if (xp < valeur)
                valeur = xp;

            if (tick - valeur < 100)
                valeur = tick - 100;

            xp -= valeur;
            return valeur;
        }

        public Cote(Cotes cotes, GenericReader reader)
        {
            this.cotes = cotes;

            int version = reader.ReadInt();

            xp = reader.ReadInt();
            cote = (ValeurCote)reader.ReadInt();
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write(0); //version

            writer.Write(xp);
            writer.Write((int)cote);
        }

        //private void AttribuerCote(Mobile from, int cote)
        //{
        //    if (!(m_SelectedPlayer == null))
        //    {
        //        m_SelectedPlayer.ListCote.Add(cote);
        //        if (m_SelectedPlayer.ListCote.Count > 5)
        //            m_SelectedPlayer.ListCote.RemoveAt(0);
        //        m_SelectedPlayer.LastCotation = DateTime.Now;
        //        CommandLogging.WriteLine(from, "{0} a attribué une cote de {1} à {2}.", 
        //            CommandLogging.Format(from), cote, CommandLogging.Format(m_SelectedPlayer));
        //        from.SendGump(new AdminGump(from, AdminGumpPage.Clients, 0, null, "", null));
        //    }
        //}

        //private void DonnerFiole(Mobile from, BaseFiole fiole)
        //{
        //    if (!(m_SelectedPlayer == null))
        //    {
        //        if (m_SelectedPlayer.NextFiole < DateTime.Now)
        //        {
        //            m_SelectedPlayer.Backpack.AddItem(fiole);
        //            m_SelectedPlayer.NextFiole = DateTime.Now.AddDays(1);
        //            CommandLogging.WriteLine(from, "{0} a donné une fiole de {1} exp à {2}.", 
        //                CommandLogging.Format(from), fiole.Exp,CommandLogging.Format(m_SelectedPlayer));
        //            from.SendGump(new AdminGump(from, AdminGumpPage.Clients, 0, null, "", null));
        //        }
        //        else
        //        {
        //            m_SelectedPlayer.SendMessage("Le joueur a recus une fiole dans les dernieres 24 heures.");
        //        }
        //    }
        //}

    }
}
