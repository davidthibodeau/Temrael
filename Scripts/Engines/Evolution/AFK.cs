using System;
using Server.Commands;
using Server.Targeting;
using Server.Mobiles;
using Server.Prompts;

namespace Server.Engines.Evolution
{
    public class AFK
    {
        public static void Initialize()
        {
            CommandSystem.Register("afk", AccessLevel.Chroniqueur, new CommandEventHandler(AFK_OnCommand));
        }

        public static void AFK_OnCommand(CommandEventArgs e)
        {
            Mobile m = e.Mobile;
            m.Target = new AFKTarget();
        }

        public static void AppliquerAFK(Mobile from, PlayerMobile pm)
        {
            if (pm.NetState != null)
            {
                CommandLogging.WriteLine(from, "a kické {0} pour AFK.", pm.ToString());
                pm.Experience.Cotes.AFK(from);
                pm.SendMessage("Vous avez été kické pour AFK.");
                pm.NetState.Dispose();
            }
            else
            {
                from.SendMessage("Ce joueur est déjà déconnecté.");
            }
        }

        private class AFKTarget : Target
        {
            public AFKTarget() : base(12, false, TargetFlags.None)
            {
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                PlayerMobile pm = targeted as PlayerMobile;

                if(pm == null)
                {
                    from.SendMessage("Vous devez viser un joueur.");
                    return;
                }

                from.SendMessage("Êtes-vous certain de vouloir marquer {0} comme AFK? (Répondez oui ou non)", pm.Name);
                from.Prompt = new AFKPrompt(pm);
            }
        }

        private class AFKPrompt : Prompt
        {
            PlayerMobile mobile;

            public AFKPrompt(PlayerMobile pm)
            {
                mobile = pm;
            }

            public override void OnResponse(Mobile from, string text)
            {
                if (text.ToLower() == "non")
                {
                    from.SendMessage("L'opération fut annulée.");
                }
                else if (text.ToLower() == "oui")
                {
                    AppliquerAFK(from, mobile);
                    from.SendMessage("Opération effectuée.");
                }
                else
                {
                    from.SendMessage("Veuillez répondre par oui ou par non.");
                    from.Prompt = this;
                }
            }
        }
    }
}

