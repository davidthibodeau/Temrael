using System;
using Server;
using Server.Network;
using Server.Targeting;
using Server.Mobiles;
using Server.Items;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class xEmote
    {
        public static void Initialize()
        {
            CommandSystem.Register("xEmote", AccessLevel.Batisseur, new CommandEventHandler(xEmote_OnCommand));
        }

        public static void xEmote_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;
            string toEmote = e.ArgString.Trim();

            if (toEmote.Length > 0)
                from.Target = new xEmoteTarget(toEmote);
            else
                from.SendMessage("Format: xEmote \"<texte>\"");
        }

        private class xEmoteTarget : Target
        {
            private string m_ToEmote;

            public xEmoteTarget(string toEmote) : base(12, false, TargetFlags.None)
            {
                m_ToEmote = toEmote;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is Mobile)
                {
                    Mobile targ = targeted as Mobile;

                    if (from == targ)
                    {
                        from.SendMessage("Vous ne pouvez faire le .xEmote sur vous.");
                    }
                    else if (targ.AccessLevel > AccessLevel.Player)
                    {
                        from.SendMessage("Vous ne pouvez faire le .xEmote sur un maitre de jeu.");
                    }
                    else
                    {
                        targ.PublicOverheadMessage(MessageType.Emote, targ.EmoteHue, false, String.Format("*{0}*", m_ToEmote), false);
                    }
                }
                else if (targeted is Item)
                {
                    Item targ = targeted as Item;
                    targ.PublicOverheadMessage(MessageType.Emote, 0, false, String.Format("*{0}*", m_ToEmote));
                }
                else
                {
                    from.SendMessage("Vous devez choisir un mobile ou un item.");
                }
            }
        }
    }
}