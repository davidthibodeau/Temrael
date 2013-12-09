using System;
using Server;
using Server.Network;
using Server.Targeting;
using Server.Mobiles;
using Server.Items;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class xSay
    {
        public static void Initialize()
        {
            CommandSystem.Register("xSay", AccessLevel.GameMaster, new CommandEventHandler(xSay_OnCommand));
        }

        public static void xSay_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;
            string toSay = e.ArgString.Trim();

            if (toSay.Length > 0)
                from.Target = new xSayTarget(toSay);
            else
                from.SendMessage("Format: xSay \"<texte>\"");
        }

        private class xSayTarget : Target
        {
            private string m_ToSay;

            public xSayTarget(string toSay) : base(12, false, TargetFlags.None)
            {
                m_ToSay = toSay;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is Mobile)
                {
                    Mobile targ = targeted as Mobile;

                    if (from == targ)
                    {
                        from.SendMessage("Vous ne pouvez faire le .xSay sur vous.");
                    }
                    else if (targ.AccessLevel > AccessLevel.Player)
                    {
                        from.SendMessage("Vous ne pouvez faire le .xSay sur un maitre de jeu.");
                    }
                    else
                    {
                        targ.PublicOverheadMessage(MessageType.Regular, targ.SpeechHue, false, m_ToSay, false);
                    }
                }
                else if (targeted is Item)
                {
                    Item targ = targeted as Item;
                    targ.PublicOverheadMessage(MessageType.Regular, 0, false, m_ToSay);
                }
                else
                {
                    from.SendMessage("Vous devez choisir un mobile ou un item.");
                }
            }
        }
    }
}