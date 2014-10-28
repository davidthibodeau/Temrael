using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Evolution
{
    // Abstraction des valeurs de cote. De la pire a la meilleure.
    public enum ValeurCote { Inacceptable, Interdit, Questionnable, Passable, Normal }

    public class Cote
    {
        // Valeur d'expérience qui reste à récupérer.
        private int xp; 
        private Cotes cotes;
        
        public Cote(Cotes cotes, ValeurCote cote)
        {
            xp = ReductionExperience(cote);
            this.cotes = cotes;
        }

        private int ReductionExperience(ValeurCote cote)
        {
            switch (cote)
            {
                case ValeurCote.Normal: return 0;
                    //TODO: Offrir d'autres valeurs
                default: return 0;
            }
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
