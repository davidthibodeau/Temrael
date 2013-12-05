using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using Server.Targeting;

namespace Server.Gumps
{
    class DeguisementGump : Gump
    {
        private TMobile m_From;

        public DeguisementGump(TMobile from)
            : base(0, 0)
        {
            m_From = from;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            //BG
            AddBackground(80, 72, 420, 397, 3600);
            AddBackground(90, 82, 400, 377, 9200);
            AddBackground(100, 92, 380, 350, 3500);

            //Dragons
            AddImage(39, 53, 10440);
            AddImage(459, 53, 10441);

            //Titre
            AddImage(125, 110, 95);
            AddImage(132, 119, 96);
            AddImage(268, 119, 96);
            AddImage(280, 119, 96);
            AddImage(455, 110, 97);

            AddHtml(230, 105, 200, 20, "<h1><basefont color=#025a>Déguisement<basefont></h1>", false, false);

            AddButton(126, 130, 1209, 1210, 1, GumpButtonType.Reply, 0);
            AddBackground(150, 130, 125, 20, 9270);
            AddLabel(155, 130, 0x080e, (m_From.Identity[0] == "" ? m_From.Name : m_From.Identity[0]));
            //AddHtml(150, 130, 200, 20, "<h3><basefont color=#5A4A31>Chausses<basefont></h3>", false, false);
            //AddItem(223, 119, 5905);

            AddButton(126, 160, 1209, 1210, 2, GumpButtonType.Reply, 0);
            AddBackground(150, 160, 125, 20, 9270);
            AddTextEntry(155, 160, 120, 20, 0x080e, 1, (m_From.Identity[1] == "" ? "Déguisement #1" : m_From.Identity[1]));
            //AddHtml(150, 160, 200, 20, "<h3><basefont color=#5A4A31>Pantalons<basefont></h3>", false, false);
            //AddItem(223, 149, 10047);

            AddButton(126, 190, 1209, 1210, 3, GumpButtonType.Reply, 0);
            AddBackground(150, 190, 125, 20, 9270);
            AddTextEntry(155, 190, 120, 20, 0x080e, 2, (m_From.Identity[2] == "" ? "Déguisement #2" : m_From.Identity[2]));
            //AddHtml(150, 190, 200, 20, "<h3><basefont color=#5A4A31>Torse<basefont></h3>", false, false);
            //AddItem(223, 182, 10232);

            AddButton(126, 220, 1209, 1210, 4, GumpButtonType.Reply, 0);
            AddBackground(150, 220, 125, 20, 9270);
            AddTextEntry(155, 220, 120, 20, 0x080e, 3, (m_From.Identity[3] == "" ? "Déguisement #3" : m_From.Identity[3]));
            //AddHtml(150, 220, 200, 20, "<h3><basefont color=#5A4A31>Tete<basefont></h3>", false, false);
            //AddItem(223, 209, 10366);

            AddButton(126, 250, 1209, 1210, 5, GumpButtonType.Reply, 0);
            AddBackground(150, 250, 125, 20, 9270);
            AddTextEntry(155, 250, 120, 20, 0x080e, 4, (m_From.Identity[4] == "" ? "Déguisement #4" : m_From.Identity[4]));
            //AddHtml(150, 250, 200, 20, "<h3><basefont color=#5A4A31>Mains<basefont></h3>", false, false);
            //AddItem(223, 242, 5062);

            AddButton(126, 280, 1209, 1210, 6, GumpButtonType.Reply, 0);
            AddBackground(150, 280, 125, 20, 9270);
            AddTextEntry(155, 280, 120, 20, 0x080e, 5, (m_From.Identity[5] == "" ? "Déguisement #5" : m_From.Identity[5]));
            //AddHtml(150, 280, 200, 20, "<h3><basefont color=#5A4A31>Bague<basefont></h3>", false, false);
            //AddItem(223, 275, 4234);

            AddButton(126, 310, 1209, 1210, 7, GumpButtonType.Reply, 0);
            AddBackground(150, 310, 125, 20, 9270);
            AddTextEntry(155, 310, 120, 20, 0x080e, 6, (m_From.Identity[6] == "" ? "Déguisement #6" : m_From.Identity[6]));
            //AddHtml(150, 310, 200, 20, "<h3><basefont color=#5A4A31>Talisman<basefont></h3>", false, false);
            //AddItem(223, 296, 5219);

            //Deuxieme Ranger

            AddButton(321, 130, 1209, 1210, 8, GumpButtonType.Reply, 0);
            AddBackground(345, 130, 125, 20, 9270);
            AddTextEntry(350, 130, 120, 20, 0x080e, 7, (m_From.Identity[7] == "" ? "Déguisement #7" : m_From.Identity[7]));
            //AddHtml(345, 130, 200, 20, "<h3><basefont color=#5A4A31>Bras<basefont></h3>", false, false);
            //AddItem(415, 119, 9862);

            AddButton(321, 160, 1209, 1210, 9, GumpButtonType.Reply, 0);
            AddBackground(345, 160, 125, 20, 9270);
            AddTextEntry(350, 160, 120, 20, 0x080e, 8, (m_From.Identity[8] == "" ? "Déguisement #8" : m_From.Identity[8]));
            //AddHtml(345, 160, 200, 20, "<h3><basefont color=#5A4A31>Tunique<basefont></h3>", false, false);
            //AddItem(415, 149, 10062);

            AddButton(321, 190, 1209, 1210, 10, GumpButtonType.Reply, 0);
            AddBackground(345, 190, 125, 20, 9270);
            AddTextEntry(350, 190, 120, 20, 0x080e, 9, (m_From.Identity[9] == "" ? "Déguisement #9" : m_From.Identity[9]));
            //AddHtml(345, 190, 200, 20, "<h3><basefont color=#5A4A31>Oreille<basefont></h3>", false, false);
            //AddItem(415, 190, 4231);

            AddButton(321, 220, 1209, 1210, 11, GumpButtonType.Reply, 0);
            AddBackground(345, 220, 125, 20, 9270);
            AddTextEntry(350, 220, 120, 20, 0x080e, 10, (m_From.Identity[10] == "" ? "Déguisement #10" : m_From.Identity[10]));
            //AddHtml(345, 220, 200, 20, "<h3><basefont color=#5A4A31>Brassards<basefont></h3>", false, false);
            //AddItem(415, 209, 10379);

            AddButton(321, 250, 1209, 1210, 12, GumpButtonType.Reply, 0);
            AddBackground(345, 250, 125, 20, 9270);
            AddTextEntry(350, 250, 120, 20, 0x080e, 11, (m_From.Identity[11] == "" ? "Déguisement #11" : m_From.Identity[11]));
            //AddHtml(345, 250, 200, 20, "<h3><basefont color=#5A4A31>Cape<basefont></h3>", false, false);
            //AddItem(415, 235, 10013);

            AddButton(321, 280, 1209, 1210, 13, GumpButtonType.Reply, 0);
            AddBackground(345, 280, 125, 20, 9270);
            AddTextEntry(350, 280, 120, 20, 0x080e, 12, (m_From.Identity[12] == "" ? "Déguisement #12" : m_From.Identity[12]));
            //AddHtml(345, 280, 200, 20, "<h3><basefont color=#5A4A31>Robe<basefont></h3>", false, false);
            //AddItem(415, 269, 10146);

            //AddButton(321, 310, 1209, 1210, 14, GumpButtonType.Reply, 0);
            //AddBackground(150, 310, 125, 20, 9270);
            //AddTextEntry(155, 310, 40, 20, 0x080e, 13, m_From.Identity[13]);
            //AddHtml(345, 310, 200, 20, "<h3><basefont color=#5A4A31>Jupe<basefont></h3>", false, false);
            //AddItem(415, 299, 10051);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            TMobile from = (TMobile)sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            if (from.LastDeguisement.AddMinutes(10) < DateTime.Now)
            {
                switch (info.ButtonID)
                {
                    case 1:
                        //from.Identity[0] = info.TextEntries[1].Text;
                        if (from.Identity[0] != "")
                            from.Name = from.Identity[0];

                        from.CurrentIdent = 0;
                        from.Disguised = false;
                        from.LastDeguisement = DateTime.Now;
                        break;
                    case 2:
                        if ((from.GetAptitudeValue(NAptitude.Deguisement) * 0.0834) > Utility.RandomDouble() && from.GetAptitudeValue(NAptitude.Deguisement) >= 1)
                        {
                            if (from.Identity[0] == "")
                                from.Identity[0] = from.Name;
                            string[] ident = from.Identity;
                            ident[1] = info.TextEntries[0].Text;
                            from.Identity = ident;
                            from.Name = from.Identity[1];
                            from.CurrentIdent = 1;
                            from.Disguised = true;
                            from.LastDeguisement = DateTime.Now;
                        }
                        else
                        {
                            from.SendMessage("Vous ratez votre déguisement !");
                            from.LastDeguisement = DateTime.Now;
                        }
                        break;
                    case 3:
                        if ((from.GetAptitudeValue(NAptitude.Deguisement) * 0.0834) > Utility.RandomDouble() && from.GetAptitudeValue(NAptitude.Deguisement) >= 2)
                        {
                            if (from.Identity[0] == "")
                                from.Identity[0] = from.Name;
                            string[] ident = from.Identity;
                            ident[2] = info.TextEntries[1].Text;
                            from.Identity = ident;
                            from.Name = from.Identity[2];
                            from.CurrentIdent = 2;
                            from.Disguised = true;
                            from.LastDeguisement = DateTime.Now;
                        }
                        else
                        {
                            from.SendMessage("Vous ratez votre déguisement !");
                            from.LastDeguisement = DateTime.Now;
                        }
                        break;
                    case 4:
                        if ((from.GetAptitudeValue(NAptitude.Deguisement) * 0.0834) > Utility.RandomDouble() && from.GetAptitudeValue(NAptitude.Deguisement) >= 3)
                        {
                            if (from.Identity[0] == "")
                                from.Identity[0] = from.Name;
                            string[] ident = from.Identity;
                            ident[3] = info.TextEntries[2].Text;
                            from.Identity = ident;
                            from.Name = from.Identity[3];
                            from.CurrentIdent = 3;
                            from.Disguised = true;
                            from.LastDeguisement = DateTime.Now;
                        }
                        else
                        {
                            from.SendMessage("Vous ratez votre déguisement !");
                            from.LastDeguisement = DateTime.Now;
                        }
                        break;
                    case 5:
                        if ((from.GetAptitudeValue(NAptitude.Deguisement) * 0.0834) > Utility.RandomDouble() && from.GetAptitudeValue(NAptitude.Deguisement) >= 4)
                        {
                            if (from.Identity[0] == "")
                                from.Identity[0] = from.Name;
                            string[] ident = from.Identity;
                            ident[4] = info.TextEntries[3].Text;
                            from.Identity = ident;
                            from.Name = from.Identity[4];
                            from.CurrentIdent = 4;
                            from.Disguised = true;
                            from.LastDeguisement = DateTime.Now;
                        }
                        else
                        {
                            from.SendMessage("Vous ratez votre déguisement !");
                            from.LastDeguisement = DateTime.Now;
                        }
                        break;
                    case 6:
                        if ((from.GetAptitudeValue(NAptitude.Deguisement) * 0.0834) > Utility.RandomDouble() && from.GetAptitudeValue(NAptitude.Deguisement) >= 5)
                        {
                            if (from.Identity[0] == "")
                                from.Identity[0] = from.Name;
                            string[] ident = from.Identity;
                            ident[5] = info.TextEntries[4].Text;
                            from.Identity = ident;
                            from.Name = from.Identity[5];
                            from.CurrentIdent = 5;
                            from.Disguised = true;
                            from.LastDeguisement = DateTime.Now;
                        }
                        else
                        {
                            from.SendMessage("Vous ratez votre déguisement !");
                            from.LastDeguisement = DateTime.Now;
                        }
                        break;
                    case 7:
                        if ((from.GetAptitudeValue(NAptitude.Deguisement) * 0.0834) > Utility.RandomDouble() && from.GetAptitudeValue(NAptitude.Deguisement) >= 6)
                        {
                            if (from.Identity[0] == "")
                                from.Identity[0] = from.Name;
                            string[] ident = from.Identity;
                            ident[6] = info.TextEntries[5].Text;
                            from.Identity = ident;
                            from.Name = from.Identity[6];
                            from.CurrentIdent = 6;
                            from.Disguised = true;
                            from.LastDeguisement = DateTime.Now;
                        }
                        else
                        {
                            from.SendMessage("Vous ratez votre déguisement !");
                            from.LastDeguisement = DateTime.Now;
                        }
                        break;
                    case 8:
                        if ((from.GetAptitudeValue(NAptitude.Deguisement) * 0.0834) > Utility.RandomDouble() && from.GetAptitudeValue(NAptitude.Deguisement) >= 7)
                        {
                            if (from.Identity[0] == "")
                                from.Identity[0] = from.Name;
                            string[] ident = from.Identity;
                            ident[7] = info.TextEntries[6].Text;
                            from.Identity = ident;
                            from.Name = from.Identity[7];
                            from.CurrentIdent = 7;
                            from.Disguised = true;
                            from.LastDeguisement = DateTime.Now;
                        }
                        else
                        {
                            from.SendMessage("Vous ratez votre déguisement !");
                            from.LastDeguisement = DateTime.Now;
                        }
                        break;
                    case 9:
                        if ((from.GetAptitudeValue(NAptitude.Deguisement) * 0.0834) > Utility.RandomDouble() && from.GetAptitudeValue(NAptitude.Deguisement) >= 8)
                        {
                            if (from.Identity[0] == "")
                                from.Identity[0] = from.Name;
                            string[] ident = from.Identity;
                            ident[8] = info.TextEntries[7].Text;
                            from.Identity = ident;
                            from.Name = from.Identity[8];
                            from.CurrentIdent = 8;
                            from.Disguised = true;
                            from.LastDeguisement = DateTime.Now;
                        }
                        break;
                    case 10:
                        if ((from.GetAptitudeValue(NAptitude.Deguisement) * 0.0834) > Utility.RandomDouble() && from.GetAptitudeValue(NAptitude.Deguisement) >= 9)
                        {
                            if (from.Identity[0] == "")
                                from.Identity[0] = from.Name;
                            string[] ident = from.Identity;
                            ident[9] = info.TextEntries[8].Text;
                            from.Identity = ident;
                            from.Name = from.Identity[9];
                            from.CurrentIdent = 9;
                            from.Disguised = true;
                            from.LastDeguisement = DateTime.Now;
                        }
                        else
                        {
                            from.SendMessage("Vous ratez votre déguisement !");
                            from.LastDeguisement = DateTime.Now;
                        }
                        break;
                    case 11:
                        if ((from.GetAptitudeValue(NAptitude.Deguisement) * 0.0834) > Utility.RandomDouble() && from.GetAptitudeValue(NAptitude.Deguisement) >= 10)
                        {
                            if (from.Identity[0] == "")
                                from.Identity[0] = from.Name;
                            string[] ident = from.Identity;
                            ident[10] = info.TextEntries[9].Text;
                            from.Identity = ident;
                            from.Name = from.Identity[10];
                            from.CurrentIdent = 10;
                            from.Disguised = true;
                            from.LastDeguisement = DateTime.Now;
                        }
                        else
                        {
                            from.SendMessage("Vous ratez votre déguisement !");
                            from.LastDeguisement = DateTime.Now;
                        }
                        break;
                    case 12:
                        if ((from.GetAptitudeValue(NAptitude.Deguisement) * 0.0834) > Utility.RandomDouble() && from.GetAptitudeValue(NAptitude.Deguisement) >= 11)
                        {
                            if (from.Identity[0] == "")
                                from.Identity[0] = from.Name;
                            string[] ident = from.Identity;
                            ident[11] = info.TextEntries[10].Text;
                            from.Identity = ident;
                            from.Name = from.Identity[11];
                            from.CurrentIdent = 11;
                            from.Disguised = true;
                            from.LastDeguisement = DateTime.Now;
                        }
                        else
                        {
                            from.SendMessage("Vous ratez votre déguisement !");
                            from.LastDeguisement = DateTime.Now;
                        }
                        break;
                    case 13:
                        if ((from.GetAptitudeValue(NAptitude.Deguisement) * 0.0834) > Utility.RandomDouble() && from.GetAptitudeValue(NAptitude.Deguisement) >= 12)
                        {
                            if (from.Identity[0] == "")
                                from.Identity[0] = from.Name;
                            string[] ident = from.Identity;
                            ident[12] = info.TextEntries[11].Text;
                            from.Identity = ident;
                            from.Name = from.Identity[12];
                            from.CurrentIdent = 12;
                            from.Disguised = true;
                            from.LastDeguisement = DateTime.Now;
                        }
                        else
                        {
                            from.SendMessage("Vous ratez votre déguisement !");
                            from.LastDeguisement = DateTime.Now;
                        }
                        break;
                    /*case 14:
                        if ((from.GetAptitudeValue(NAptitude.Deguisement) * 0.0834) > Utility.RandomDouble() && from.Races == Races.Tieffelin)
                        {
                            from.Identity[13] = info.TextEntries[13].Text;
                            from.Name = from.Identity[13];
                            from.CurrentIdent = 1;
                            from.Disguised = true;
                            from.LastDeguisement = DateTime.Now;
                        }
                        break;*/
                    default: break;
                }
            }
            else if (!(info.ButtonID == 0))
            {
                from.SendMessage("Il est encore trop tôt pour se déguiser de nouveau !");
            }
        }
    }
}
