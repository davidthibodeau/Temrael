using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;
using Server.Items;
using Server.Spells;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class QuickSpellLaunchCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("qsl", AccessLevel.Player, new CommandEventHandler(QSL_OnCommand));
        }

        [Usage("QSL")]
        [Description("Lance le menu de sorts rapides.")]
        public static void QSL_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from is TMobile)
            {
                TMobile m = (TMobile)from;

                if (m != null)
                {
                    m.SendMessage("Choisissez le livre ou instrument a utiliser.");
                    m.BeginTarget(12, false, TargetFlags.None, new TargetCallback(QSL_OnTarget));
                }
            }
        }

        public static void QSL_OnTarget(Mobile from, object targ)
        {
            if (targ is NewSpellbook && from.Backpack != null && ((Item)targ).Parent == from.Backpack)
                from.SendGump(new QuickSpellLaunchGump((TMobile)from, (NewSpellbook)targ, null));
            else if (targ is BaseInstrument && from.Backpack != null && ((Item)targ).Parent == from.Backpack)
                from.SendGump(new QuickSpellLaunchGump((TMobile)from, (BaseInstrument)targ, null));
        }
    }
}