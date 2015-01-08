using Server.Commands;
using Server.Mobiles;
using Server.Prompts;
using Server.Targeting;
using System;

namespace Server.Engines.Identities
{
    public static class ResetIdentity
    {
        public static void Initialize()
        {
            CommandSystem.Register("resetidentity", AccessLevel.Owner, new CommandEventHandler(ResetIdentity_OnCommand));
        }

        public static void ResetIdentity_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendMessage("Veuillez choisir le joueur que vous dont vous désirez remettre à neuf l'identité.");
        }

        private class ResetTarget : Target
        {
            public ResetTarget() : base(15, false, TargetFlags.None)
            {
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                PlayerMobile pm = targeted as PlayerMobile;

                if (pm == null)
                {
                    from.SendMessage("Vous devez choisir un joueur.");
                    return;
                }

                from.SendMessage("Êtes-vous certain de vouloir remettre à neuf l'identité courante ({0}) de ce joueur?", 
                    pm.Identities.CurrentIdentity.IdType.ToString());
                from.SendMessage("Plus personne ne reconnaîtra cette identité et cette opération est irréversible. (Répondez oui ou non)");
                from.Prompt = new ResetPrompt(pm);
            }
        }

        private class ResetPrompt : Prompt
        {
            private PlayerMobile joueur;

            public ResetPrompt(PlayerMobile pm)
            {
                joueur = pm;
            }

            public override void OnResponse(Mobile from, string text)
            {
                if (text.ToLower() == "non")
                    from.SendMessage("L'opération fut annulée.");
                else if (text.ToLower() == "oui")
                {
                    joueur.Identities.CurrentIdentity.Reset();
                    from.SendMessage("L'opération fut complétée.");
                    joueur.SendMessage("Votre identité courante fut remise à neuf. Plus personne ne la reconnaîtra");
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
