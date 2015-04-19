using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Mobiles;
using Server.Targeting;
using Server.Commands;
using Server.Misc;
using Server.Engines.Help;

namespace Server.Commandes.Temrael
{
    class Report
    {
        private static readonly string USERNAME = "";
        private static readonly string PASSWORD = "";
        private static readonly string FORUMNUM = "137";

        public static void Initialize()
        {

            // Disablé pour le moment, parce que sur mon serveur de tests, un report semblait
            // causer un lagspike de 4-5 secondes. Il faudrait peut-être voir à threader le
            // module de forumpost, pour éviter qu'il "bloque" le reste ?

            // CommandSystem.Register("Report", AccessLevel.Player, new CommandEventHandler(Report_OnCommand));
        }

        [Usage("Report <Commentaire/Message>")]
        [Description("Permet de rapporter le comportement d'un joueur qui est jugé innacceptable.")]
        private static void Report_OnCommand(CommandEventArgs e)
        {
            if (e.Mobile is PlayerMobile)
            {
                PlayerMobile pm = (PlayerMobile)e.Mobile;
                e.Mobile.Target = new ReportTarget(e.ArgString);
            }
        }

        private class ReportTarget : Target
        {
            String s;
            public ReportTarget(String message)
                : base(20, false, TargetFlags.None)
            {
                s = message;
            }

            protected override void OnTarget(Mobile from, object targ)
            {
                if (from is PlayerMobile && targ is PlayerMobile)
                {
                    DoReport((PlayerMobile)from, (PlayerMobile)targ, s);
                }
                else
                {
                    from.SendMessage("La cible doit être un joueur.");
                }
            }
        }

        public static void DoReport(PlayerMobile from, PlayerMobile targ, string message)
        {

            // Prise des noms de tous les joueurs dans un range de X tiles du reporté.
            String noms = "";
            foreach (Mobile mob in from.GetMobilesInRange(20))
            {
                noms += mob.Name + "\n";
            }
            foreach (Mobile mob in targ.GetMobilesInRange(20))
            {
                if (!noms.Contains(mob.Name))
                {
                    noms += mob.Name + "\n";
                }
            }

            String speechlog = "";
            if (from.SpeechLog != null)
            {
                // Création d'un speechlog continu.
                Array array = from.SpeechLog.ToArray();
                foreach (SpeechLogEntry s in array)
                {
                    speechlog += s.From.Name + " : " + s.Speech + "\n\n";
                }
            }

            from.SendMessage("Envoi du rapport...");

            // Make forum ticket.
            PhpBB forumPost = new PhpBB(USERNAME, PASSWORD);

            forumPost.Login();

            forumPost.Post(FORUMNUM, 
            targ.Name,
            "\n" +
            "REPORTÉ : " + targ.Name + "\n" +
            "Sous le nom de : " + targ.GetNameUsedBy(from) + "\n" +
            "\n" +
            "REPORTEUR : " + from.Name + "\n" +
            "Sous le nom de : " + from.GetNameUsedBy(targ) + "\n" +
            "\n" +
            " DATE : " + DateTime.Now.ToString() + "\n" +
            "\n" +
            " COMMENTAIRE DE L'ACHEVÉ \n" +
            " ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ \n" +
            message + "\n" +
            "\n" +
            "\n" +
            " PERSONNAGES PRÉSENTS \n" +
            " ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ \n" +
            noms + "\n" +
            "\n" +
            "\n" +
            " SPEECHLOG DU REPORTEUR \n" +
            " ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ \n" +
            speechlog);

            from.SendMessage("Le rapport a été envoyée à l'équipe, et sera traité dans les plus brefs délais !");
        }
    }
}
