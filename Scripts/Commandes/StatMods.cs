using Server.Targeting;
using System;

namespace Server.Commands
{
    public class StatMods
    {
        private enum Choix { Liste, Supprimer }

		public static void Initialize()
		{
            CommandSystem.Register("ListeStatMods", AccessLevel.Batisseur, new CommandEventHandler(ListStatMods_OnCommand));
            //CommandSystem.Register("SupprimerStatMods", AccessLevel.Coordinateur, new CommandEventHandler(DelStatMods_OnCommand));
		}

        public static void ListStatMods_OnCommand(CommandEventArgs e)
        {
            e.Mobile.Target = new StatModsTarget(Choix.Liste);
            e.Mobile.SendMessage("Veuillez cibler le joueur dont vous voulez voir la liste des modificateurs de stats.");
        }

        public static void DelStatMods_OnCommand(CommandEventArgs e)
        {
            e.Mobile.Target = new StatModsTarget(Choix.Supprimer);
            e.Mobile.SendMessage("Veuillez cibler le joueur dont vous voulez supprimer les modificateurs de stats.");
        }

        private class StatModsTarget : Target
        {
            private Choix choix;

            public StatModsTarget(Choix c)
                : base(15, false, TargetFlags.None)
            {
                choix = c;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                Mobile target = targeted as Mobile;

                if (target == null)
                {
                    from.SendMessage("Vous devez viser un mobile.");
                    return;
                }

                if (choix == Choix.Liste)
                {
                    foreach (StatMod sm in target.StatMods)
                    {
                        from.SendMessage("Mod {0} provenant de {1} a un valeur de {2}.", sm.Type, sm.Name, sm.Offset);
                    }
                }
                else if (choix == Choix.Supprimer)
                {
                    target.RemoveAllStatMods();
                    from.SendMessage("Pour éviter les problèmes, le joueur devrait être mis à nu.");
                }
            }
        }
    }
}
