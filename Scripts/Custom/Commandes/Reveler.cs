using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using Server.Items;
using Server.Targeting;
using Server.Network;
using Server.Engines.Combat;

namespace Server.Scripts.Commands
{
    public class Reveler
    {
        public static void Initialize()
        {
            CommandSystem.Register("Reveler", AccessLevel.Player, new CommandEventHandler(Reveler_OnCommand));
        }

        [Usage("Reveler")]
        [Description("Révéler la cible cachée.")]
        public static void Reveler_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from is TMobile)
            {
                TMobile pm = (TMobile)e.Mobile;

                from.Target = new RevelerTarget();
            }
        }

        private class RevelerTarget : Target
        {

            public RevelerTarget()
                : base(15, true, TargetFlags.None)
            {
                AllowNonlocal = true;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (from is TMobile)
                {
                    if (targeted is TMobile && targeted != from)
                    {
                        TMobile PersoVise = (TMobile)targeted;
                        if (PersoVise.Hidden) // Si le target est caché.
                        {
                            PersoVise.NextSkillTime = 5; // Empêche le joueur visé d'utiliser un skill pour les 5 prochaines secondes.
                            PersoVise.RevealingAction();
                        }
                        else
                        {
                            from.SendMessage("Le personnage ciblé doit être caché !");
                        }
                    }
                    else
                    {
                        from.SendMessage("Vous devez viser un personnage !");
                    }
                }
            }
        }
    }
}
