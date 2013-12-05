using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using System.Reflection;
using Server.HuePickers;
using System.Collections.Generic;

namespace Server.Gumps
{
    public class CreationCarteGump : GumpTemrael
    {
        public enum DestinationsDepart
        {
            Aucune,

            /*beta*/
            Hasteindale,

            /*principale*/
            Brandheim,
            Elamsham,
            Serenite,
            Citarel,
            Melandre,
            Tartarus
        }

        private TMobile m_from;
        private DestinationsDepart m_destination;

        public CreationCarteGump(TMobile from)
            : base("Ville de Départ", 560, 622)
        {
            m_from = from;
            m_destination = m_from.Creation.destination;

            int x = XBase;
            int y = YBase;
            int line = 2;
            int scale = 25;

            y = 650;
            x = 90;
            int space = 80;

            AddMenuItem(x, y, 1189, 1, true);
            x += space;
            AddMenuItem(x, y, 1193, 2, true);
            x += space;
            AddMenuItem(x, y, 1190, 3, true);
            x += space;
            AddMenuItem(x, y, 1192, 4, true);
            x += space;
            AddMenuItem(x, y, 1188, 5, true);
            x += space;
            AddMenuItem(x, y, 1224, 6, false);
            x += space;
            AddMenuItem(x, y, 1182, 7, true);

            x = XBase;
            y = YBase;

            if (Temrael.beta)
            {
                AddImage(175, 150, 448);
            }
            else
            {
                AddBackground(170, 145, 445, 478, 2620);
                AddImage(175, 150, 1766);
            }

            //Hasteindale
            if (Temrael.beta)
            {
                if (m_destination == DestinationsDepart.Hasteindale)
                {
                    AddButton(446, 354, 9009, 9009, 8, GumpButtonType.Reply, 0);
                    AddTooltip(3006430);
                }
                else
                {
                    AddButton(446, 354, 9008, 9008, 8, GumpButtonType.Reply, 0);
                    AddTooltip(3006430);
                }
            }
            else
            {
                //184, 148
                if (m_destination == DestinationsDepart.Brandheim)
                {
                    AddButton(442, 250, 9009, 9009, 9, GumpButtonType.Reply, 0);
                    AddTooltip(3006432);
                }
                else
                {
                    AddButton(442, 250, 9008, 9008, 9, GumpButtonType.Reply, 0);
                    AddTooltip(3006432);
                }

                if (m_destination == DestinationsDepart.Elamsham)
                {
                    AddButton(448, 290, 9009, 9009, 10, GumpButtonType.Reply, 0);
                    AddTooltip(3006433);
                }
                else
                {
                    AddButton(448, 290, 9008, 9008, 10, GumpButtonType.Reply, 0);
                    AddTooltip(3006433);
                }

                if (m_destination == DestinationsDepart.Citarel)
                {
                    AddButton(559, 347, 9009, 9009, 11, GumpButtonType.Reply, 0);
                    AddTooltip(3006434);
                }
                else
                {
                    AddButton(559, 347, 9008, 9008, 11, GumpButtonType.Reply, 0);
                    AddTooltip(3006434);
                }

                if (m_destination == DestinationsDepart.Serenite)
                {
                    AddButton(468, 376, 9009, 9009, 12, GumpButtonType.Reply, 0);
                    AddTooltip(3006435);
                }
                else
                {
                    AddButton(468, 376, 9008, 9008, 12, GumpButtonType.Reply, 0);
                    AddTooltip(3006435);
                }

                if (m_destination == DestinationsDepart.Melandre)
                {
                    AddButton(512, 462, 9009, 9009, 13, GumpButtonType.Reply, 0);
                    AddTooltip(3006436);
                }
                else
                {
                    AddButton(512, 462, 9008, 9008, 13, GumpButtonType.Reply, 0);
                    AddTooltip(3006436);
                }

                /*if (m_destination == DestinationsDepart.Tartarus)
                {
                    AddButton(381, 519, 9009, 9009, 14, GumpButtonType.Reply, 0);
                    AddTooltip(3006437);
                }
                else
                {
                    AddButton(381, 519, 9008, 9008, 14, GumpButtonType.Reply, 0);
                    AddTooltip(3006437);
                }*/
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            TMobile from = (TMobile)sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            switch (info.ButtonID)
            {
                case 1:
                    from.SendGump(new CreationAlignementGump(from));
                    break;
                case 2:
                    if (from.Creation.alignementA != AlignementA.Aucun && from.Creation.alignementB != AlignementB.Aucun)
                    {
                        from.SendGump(new CreationRaceGump(from));
                    }
                    else
                    {
                        goto case 1;
                    }
                    break;
                case 3:
                    if (from.Creation.race != Races.Aucun)
                    {
                        from.SendGump(new CreationClasseGump(from));
                    }
                    else
                    {
                        goto case 2;
                    }
                    break;
                case 4:
                    if (from.Creation.classe != ClasseType.None)
                    {
                        from.SendGump(new CreationMetierGump(from));
                    }
                    else
                    {
                        goto case 3;
                    }
                    break;
                case 5:
                    if (from.Creation.metier != MetierType.None)
                    {
                        from.SendGump(new CreationEquipementGump(from));
                    }
                    else
                    {
                        goto case 4;
                    }
                    break;
                case 6:
                    from.SendGump(new CreationCarteGump(from));
                    break;
                case 7:
                    from.SendGump(new CreationOverviewGump(from));
                    break;
                case 8:
                    from.Creation.destination = DestinationsDepart.Hasteindale;
                    from.SendGump(new CreationCarteGump(from));
                    break;
                case 9:
                    from.Creation.destination = DestinationsDepart.Brandheim;
                    from.SendGump(new CreationCarteGump(from));
                    break;
                case 10:
                    from.Creation.destination = DestinationsDepart.Elamsham;
                    from.SendGump(new CreationCarteGump(from));
                    break;
                case 11:
                    from.Creation.destination = DestinationsDepart.Citarel;
                    from.SendGump(new CreationCarteGump(from));
                    break;
                case 12:
                    from.Creation.destination = DestinationsDepart.Serenite;
                    from.SendGump(new CreationCarteGump(from));
                    break;
                case 13:
                    from.Creation.destination = DestinationsDepart.Melandre;
                    from.SendGump(new CreationCarteGump(from));
                    break;
                case 14:
                    from.Creation.destination = DestinationsDepart.Tartarus;
                    from.SendGump(new CreationCarteGump(from));
                    break;
            }
        }
    }
}
