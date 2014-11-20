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
            CommandSystem.Register("xSay", AccessLevel.Batisseur, new CommandEventHandler(xSay_OnCommand));
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

            public xSayTarget(string toSay) : base(12, true, TargetFlags.None)
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
                    new ItemInvisibleTimer(from, (IPoint3D)targeted, m_ToSay);
                }
            }
        }


        private class ItemInvisibleTimer : Timer
        {
            ItemInvisible item_;

            public ItemInvisibleTimer(Mobile from, IPoint3D location, string Message)
                : base(TimeSpan.FromSeconds(10))
            {
                item_ = new ItemInvisible();
                item_.DropToWorld(from, new Point3D(location.X, location.Y, location.Z));
                item_.Visible = true;
                item_.PublicOverheadMessage(MessageType.Regular, 0, false, Message);
                Start();
            }

            protected override void OnTick()
            {
                item_.Delete();
            }
        }

        private class ItemInvisible : Item
        {
            public ItemInvisible(Serial serial)
                : base(serial)
            { }

            public ItemInvisible()
                : base(0x0001)
            { }

            public override int GetDropSound()
            {
                return -2;
            }

            public override void Serialize(GenericWriter writer)
            {
                base.Serialize(writer);

                writer.Write((int)0); // version
            }

            public override void Deserialize(GenericReader reader)
            {
                base.Deserialize(reader);

                int version = reader.ReadInt();

            }
        }
    }
}