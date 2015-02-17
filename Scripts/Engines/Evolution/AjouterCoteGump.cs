using System;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;

namespace Server.Engines.Evolution
{
    public class AjouterCoteGump : Gump
    {
        PlayerMobile mobile;

        public AjouterCoteGump(PlayerMobile pm)
            : this(pm, 0)
        {

        }

        public AjouterCoteGump(PlayerMobile pm, int page) : base(50, 50)
        {
            mobile = pm;

            Closable=true;
            Disposable=true;
            Dragable=true;
            Resizable=false;

            AddPage(0);
            AddBackground(31, 48, 416, 432, 9250);
            AddBackground(39, 56, 400, 417, 3500);
            AddLabel(114, 78, 1301, @"Donner une cote ou fiole à " + pm.Name);

            int y = 110;
            AddLabel(60, y, 1301, RaisonCote.GetGMMessage(0));
            AddButton(383, y - 1, 4005, 4006, 100, GumpButtonType.Reply, 0);
            y += 30;
            
            for (int i = 100; i < RaisonCote.LimiteMaximale(ValeurCote.Passable) + 1; i++)
            {
                //if (i >= (page + 1) * 10)
                //    break;
                //if (i < page * 10)
                //    continue;
                AddLabel(60, y, 1301, RaisonCote.GetGMMessage(i));
                AddLabel(290, y, 1301, "(Passable)");
                AddButton(383, y, 4005, 4006, i, GumpButtonType.Reply, 0);

                y += 30;
            }

            for (int i = 200; i < RaisonCote.LimiteMaximale(ValeurCote.Questionnable) + 1; i++)
            {
                AddLabel(60, y, 1301, RaisonCote.GetGMMessage(i));
                AddLabel(290, y, 1301, "(Questionnable)");
                AddButton(383, y, 4005, 4006, i, GumpButtonType.Reply, 0);

                y += 30;
            }

            for (int i = 300; i < RaisonCote.LimiteMaximale(ValeurCote.Interdit) + 1; i++)
            {
                AddLabel(60, y, 1301, RaisonCote.GetGMMessage(i));
                AddLabel(290, y, 1301, "(Interdit)");
                AddButton(383, y, 4005, 4006, i, GumpButtonType.Reply, 0);

                y += 30;
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            int raison = info.ButtonID;

            switch ((ValeurCote)(raison / 100))
            {
                case ValeurCote.Normal:
                    if (raison == 1)
                        return;
                    mobile.Experience.Cotes.OctroyerCote(ValeurCote.Normal, from, raison);
                    break;
                case ValeurCote.Passable:
                    mobile.Experience.Cotes.OctroyerCote(ValeurCote.Passable, from, raison);
                    break;
                case ValeurCote.Questionnable:
                    mobile.Experience.Cotes.OctroyerCote(ValeurCote.Questionnable, from, raison);
                    break;
                case ValeurCote.Interdit:
                    mobile.Experience.Cotes.OctroyerCote(ValeurCote.Interdit, from, raison);
                    break;
            }

            from.SendMessage("Cote octroyée");
            from.SendGump(new CotesGump(mobile, 0));
        }
    }
}

