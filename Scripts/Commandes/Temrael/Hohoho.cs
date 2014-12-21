using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using Server.Targeting;

namespace Server.Commandes
{
    class Hohoho
    {
        public static void Initialize()
        {
            CommandSystem.Register("Hohoho", AccessLevel.Player, new CommandEventHandler(Hohoho_OnCommand));
        }

        [Usage("Hohoho")]
        [Description("Permet d'ajouter l'item clické au sac de tous des joueurs.")]
        public static void Hohoho_OnCommand(CommandEventArgs e)
        {
            e.Mobile.Target = new ItemToAdd();
        }

        private class ItemToAdd : Target
        {
            public ItemToAdd()
                : base(15, false, TargetFlags.None)
            {
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is Item)
                {
                    Type t = targeted.GetType();
                    foreach (Mobile m in World.Mobiles.Values)
                    {
                        m.AddToBackpack( (Item)Activator.CreateInstance(t) );
                    }
                }
                else
                {
                    from.SendMessage("Ceci n'est pas un item.");
                }
            }
        }
    }
}
