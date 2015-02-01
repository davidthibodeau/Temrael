using System;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using Server.Commands;
using Server.Targeting;

namespace Server.Engines.Evolution
{
    public class CotesGump : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("cotes", AccessLevel.Chroniqueur, new CommandEventHandler(Cotes_OnCommand));
        }

        public static void Cotes_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            from.SendMessage("Veuillez choisir le joueur dont vous voulez voir les cotes.");
            from.Target = new CotesTarget();
        }

        private class CotesTarget : Target
        {
            public CotesTarget() : base (12, false, TargetFlags.None)
            {

            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                PlayerMobile mobile = targeted as PlayerMobile;
                if (mobile == null)
                {
                    from.SendMessage("Vous devez viser un joueur.");
                    return;
                }

                from.SendGump(new CotesGump(mobile, 0));
            }
        }

        private int page;
        private PlayerMobile mobile;

        public CotesGump(PlayerMobile pm, int page) : base(50, 50)
        {
            this.page = page;

            Closable=true;
            Disposable=true;
            Dragable=true;
            Resizable=false;

            AddPage(0);
            AddBackground(31, 48, 616, 462, 9250);
            AddBackground(39, 56, 600, 447, 3500);
            AddLabel(274, 78, 1301, @"Historique de cotes de " + pm.Name);
            //AddButton(545, 460, 4005, 4006, 1, GumpButtonType.Reply, 0);
            AddLabel(405, 461, 1301, @"Ajouter cote/fiole");

            Cotes cotes = pm.Experience.Cotes;

            AddLabel(65, 431, 1301, String.Format("Dernière cote: {0}", cotes.LastCotation));
            AddLabel(365, 431, 1301, String.Format("Dernière fiole: {0}", cotes.LastFiole));

            int basey = 110;
            for (int i = 0; i < cotes.Count; i++)
            {
                if (i >= (page + 1) * 10)
                    break;
                if (i < page * 10)
                    continue;
                RaisonCote cote = cotes[i];
                AddLabel(60, basey + (i % 10) * 30, 1301, cote.Auteur.Account.Username);
                AddLabel(150, basey + (i % 10) * 30, 1301, cote.Timestamp.ToString());
                AddLabel(350, basey + (i % 10) * 30, 1301, cote.Message);
                //AddButton(383, basey + (i % 10) * 30 - 1, 4005, 4006, i + 10, GumpButtonType.Reply, 0);

            }
            if (page + 1 < cotes.Count / 10)
                AddButton(602, 411, 5601, 5605, 2, GumpButtonType.Reply, 0);
            if (page > 0)
                AddButton(61, 410, 5603, 5607, 3, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile m = sender.Mobile;
            switch(info.ButtonID)
            {
                case 1:
                    m.SendGump(new AjouterCoteGump(mobile));
                    break;

                case 2:
                    m.SendGump(new CotesGump(mobile, page + 1));
                    break;

                case 3:
                    m.SendGump(new CotesGump(mobile, page - 1));
                    break;
            }
        }
    }
}

