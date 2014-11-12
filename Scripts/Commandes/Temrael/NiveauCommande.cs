using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using Server.Targeting;
using Server.Engines.Evolution;

namespace Server.Scripts.Commands
{
    class NiveauCommande
    {
        public static void Initialize()
        {
            CommandSystem.Register("Niveau", AccessLevel.Batisseur, new CommandEventHandler(Niveau_OnCommande));
        }

        [Usage("Niveau")]
        [Description("Permet d'augmenter son niveau.")]
        public static void Niveau_OnCommande(CommandEventArgs e)
        {
            if (e.Mobile is PlayerMobile)
            {
                PlayerMobile from = (PlayerMobile)e.Mobile;

                if (XP.CanEvolve(from))
                    XP.Evolve(from);
            }

            /*if (from is PlayerMobile)
            {
                from.Target = new CotationTarget();
            }*/
        }
    }
}
