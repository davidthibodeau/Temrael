using Server.Commands;
using Server.Gumps;
using Server.Mobiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Races
{
    public class RaceChoixGump : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("changerrace", AccessLevel.Batisseur, new CommandEventHandler(ChangerRace_OnCommand));
        }

        public static void ChangerRace_OnCommand(CommandEventArgs e)
        {
            PlayerMobile pm = e.Mobile as PlayerMobile;
            if(pm == null)
            {
                e.Mobile.SendMessage("Vous devez être un personnage joueur pour changer votre race");
                return;
            }
            pm.SendGump(new RaceChoixGump(pm));

        }

        PlayerMobile mobile;

        private enum Buttons
        {
            Aucune = 1,
            Alfar,
            Elfe,
            Nain,
            Orcish,
            Capiceen,
            CapiceenAasimar,
            CapiceenTieffelin,
            Nordique,
            NordiqueAasimar,
            NordiqueTieffelin,
            Nomade,
            NomadeAasimar,
            NomadeTieffelin
        }

        public RaceChoixGump(PlayerMobile m)
            : base(50, 50)
        {
            mobile = m;

            this.Closable = true;
            this.Disposable = true;
            this.Dragable = true;
            this.Resizable = false;

            AddPage(0);
            AddBackground(31, 48, 346, 612, 9250);
            AddBackground(39, 56, 330, 597, 3500);
            AddLabel(144, 78, 1301, @"Changez votre race");

            AddLabel(80, 120, 1301, "Alfar");
            AddButton(250, 119, 455, 455, ComputeButtonId(Buttons.Alfar, 1), GumpButtonType.Reply, 0);
            AddButton(250 + 29, 119, 456, 456, ComputeButtonId(Buttons.Alfar, 2), GumpButtonType.Reply, 0);
            AddButton(250 + 48, 119, 457, 457, ComputeButtonId(Buttons.Alfar, 3), GumpButtonType.Reply, 0);
            AddLabel(80, 160, 1301, "Elfe");
            AddButton(250, 159, 449, 449, ComputeButtonId(Buttons.Elfe, 1), GumpButtonType.Reply, 0);
            AddButton(250 + 29, 159, 450, 450, ComputeButtonId(Buttons.Elfe, 2), GumpButtonType.Reply, 0);
            AddButton(250 + 48, 159, 451, 451, ComputeButtonId(Buttons.Elfe, 3), GumpButtonType.Reply, 0);
            AddLabel(80, 200, 1301, "Nain");
            AddButton(250, 199, 461, 461, ComputeButtonId(Buttons.Nain, 1), GumpButtonType.Reply, 0);
            AddButton(250 + 29, 199, 462, 462, ComputeButtonId(Buttons.Nain, 2), GumpButtonType.Reply, 0);
            AddButton(250 + 48, 199, 463, 463, ComputeButtonId(Buttons.Nain, 3), GumpButtonType.Reply, 0);
            AddLabel(80, 240, 1301, "Orcish");
            AddButton(250, 239, 458, 458, ComputeButtonId(Buttons.Orcish, 1), GumpButtonType.Reply, 0);
            AddButton(250 + 29, 239, 459, 459, ComputeButtonId(Buttons.Orcish, 2), GumpButtonType.Reply, 0);
            AddButton(250 + 48, 239, 460, 460, ComputeButtonId(Buttons.Orcish, 3), GumpButtonType.Reply, 0);
            AddLabel(80, 280, 1301, "Capicéen");
            AddButton(250, 279, 449, 449, ComputeButtonId(Buttons.Capiceen, 1), GumpButtonType.Reply, 0);
            AddButton(250 + 29, 279, 450, 450, ComputeButtonId(Buttons.Capiceen, 2), GumpButtonType.Reply, 0);
            AddButton(250 + 48, 279, 451, 451, ComputeButtonId(Buttons.Capiceen, 3), GumpButtonType.Reply, 0);
            AddLabel(80, 320, 1301, "Capicéen Aasimar");
            AddButton(250, 319, 449, 449, ComputeButtonId(Buttons.CapiceenAasimar, 1), GumpButtonType.Reply, 0);
            AddButton(250 + 29, 319, 450, 450, ComputeButtonId(Buttons.CapiceenAasimar, 2), GumpButtonType.Reply, 0);
            AddButton(250 + 48, 319, 451, 451, ComputeButtonId(Buttons.CapiceenAasimar, 3), GumpButtonType.Reply, 0);
            AddLabel(80, 360, 1301, "Capicéen Tieffelin");
            AddButton(250, 359, 449, 449, ComputeButtonId(Buttons.CapiceenTieffelin, 1), GumpButtonType.Reply, 0);
            AddButton(250 + 29, 359, 450, 450, ComputeButtonId(Buttons.CapiceenTieffelin, 2), GumpButtonType.Reply, 0);
            AddButton(250 + 48, 359, 451, 451, ComputeButtonId(Buttons.CapiceenTieffelin, 3), GumpButtonType.Reply, 0);
            AddLabel(80, 400, 1301, "Nomade");
            AddButton(250, 399, 452, 452, ComputeButtonId(Buttons.Nomade, 1), GumpButtonType.Reply, 0);
            AddButton(250 + 29, 399, 453, 453, ComputeButtonId(Buttons.Nomade, 2), GumpButtonType.Reply, 0);
            AddButton(250 + 48, 399, 454, 454, ComputeButtonId(Buttons.Nomade, 3), GumpButtonType.Reply, 0);
            AddLabel(80, 440, 1301, "Nomade Aasimar");
            AddButton(250, 439, 452, 452, ComputeButtonId(Buttons.NomadeAasimar, 1), GumpButtonType.Reply, 0);
            AddButton(250 + 29, 439, 453, 453, ComputeButtonId(Buttons.NomadeAasimar, 2), GumpButtonType.Reply, 0);
            AddButton(250 + 48, 439, 454, 454, ComputeButtonId(Buttons.NomadeAasimar, 3), GumpButtonType.Reply, 0);
            AddLabel(80, 480, 1301, "Nomade Tieffelin");
            AddButton(250, 479, 452, 452, ComputeButtonId(Buttons.NomadeTieffelin, 1), GumpButtonType.Reply, 0);
            AddButton(250 + 29, 479, 453, 453, ComputeButtonId(Buttons.NomadeTieffelin, 2), GumpButtonType.Reply, 0);
            AddButton(250 + 48, 479, 454, 454, ComputeButtonId(Buttons.NomadeTieffelin, 3), GumpButtonType.Reply, 0);
            AddLabel(80, 520, 1301, "Nordique");
            AddButton(250, 519, 449, 449, ComputeButtonId(Buttons.Nordique, 1), GumpButtonType.Reply, 0);
            AddButton(250 + 29, 519, 450, 450, ComputeButtonId(Buttons.Nordique, 2), GumpButtonType.Reply, 0);
            AddButton(250 + 48, 519, 451, 451, ComputeButtonId(Buttons.Nordique, 3), GumpButtonType.Reply, 0);
            AddLabel(80, 560, 1301, "Nordique Aasimar");
            AddButton(250, 559, 449, 449, ComputeButtonId(Buttons.NordiqueAasimar, 1), GumpButtonType.Reply, 0);
            AddButton(250 + 29, 559, 450, 450, ComputeButtonId(Buttons.NordiqueAasimar, 2), GumpButtonType.Reply, 0);
            AddButton(250 + 48, 559, 451, 451, ComputeButtonId(Buttons.NordiqueAasimar, 3), GumpButtonType.Reply, 0);
            AddLabel(80, 600, 1301, "Nordique Tieffelin");
            AddButton(250, 599, 449, 449, ComputeButtonId(Buttons.NordiqueTieffelin, 1), GumpButtonType.Reply, 0);
            AddButton(250 + 29, 599, 450, 450, ComputeButtonId(Buttons.NordiqueTieffelin, 2), GumpButtonType.Reply, 0);
            AddButton(250 + 48, 599, 451, 451, ComputeButtonId(Buttons.NordiqueTieffelin, 3), GumpButtonType.Reply, 0);
        }

        private int ComputeButtonId(Buttons b, int colour)
        {
            return colour * 100 + (int)b;
        }

        public override void OnResponse(Network.NetState sender, RelayInfo info)
        {
            if (info.ButtonID == 0) return;

            Buttons b = (Buttons)(info.ButtonID % 100);
            int colour = info.ButtonID / 100 - 1;
            if (colour < 0 || colour > 2)
            {
                sender.Mobile.SendGump(this);
                return;
            }

            switch (b)
            {
                case Buttons.Alfar:
                    mobile.Race = new Alfar(Alfar.Hues[colour]);
                    break;
                case Buttons.Elfe:
                    mobile.Race = new Elfe(Elfe.Hues[colour]);
                    break;
                case Buttons.Nain:
                    mobile.Race = new Nain(Nain.Hues[colour]);
                    break;
                case Buttons.Orcish:
                    mobile.Race = new Orcish(Orcish.Hues[colour]);
                    break;
                case Buttons.Capiceen:
                    mobile.Race = new Capiceen(Capiceen.Hues[colour]);
                    break;
                case Buttons.CapiceenAasimar:
                    mobile.Race = new Capiceen(RaceSecrete.Aasimar, Capiceen.Hues[colour], 0);
                    break;
                case Buttons.CapiceenTieffelin:
                    mobile.Race = new Capiceen(RaceSecrete.Tieffelin, Capiceen.Hues[colour], 0);
                    break;
                case Buttons.Nomade:
                    mobile.Race = new Nomade(Nomade.Hues[colour]);
                    break;
                case Buttons.NomadeAasimar:
                    mobile.Race = new Nomade(RaceSecrete.Aasimar, Nomade.Hues[colour], 0);
                    break;
                case Buttons.NomadeTieffelin:
                    mobile.Race = new Nomade(RaceSecrete.Tieffelin, Nomade.Hues[colour], 0);
                    break;
                case Buttons.Nordique:
                    mobile.Race = new Nordique(Nordique.Hues[colour]);
                    break;
                case Buttons.NordiqueAasimar:
                    mobile.Race = new Nordique(RaceSecrete.Aasimar, Nordique.Hues[colour], 0);
                    break;
                case Buttons.NordiqueTieffelin:
                    mobile.Race = new Nordique(RaceSecrete.Tieffelin, Nordique.Hues[colour], 0);
                    break;
            }

            sender.Mobile.SendMessage(CurrentRace());
        }

        private string CurrentRace()
        {
            Race r = mobile.Race;
            if (r is AucuneRace)
                return "Vous n'avez aucune race.";

            return String.Format("Vous êtes un {0}.", r.Name + (r.isAasimaar ? " aasimar" : r.isTieffelin ? " tieffelin" : ""));
        }

    }
}
