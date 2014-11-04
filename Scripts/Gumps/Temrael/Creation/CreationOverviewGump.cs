using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using System.Reflection;
using Server.HuePickers;
using System.Collections.Generic;
using Server.Engines.Langues;
using Server.Engines.Races;

namespace Server.Gumps
{
    public class CreationInfos
    {
        public int Hue { get; set; }
        public Race Race { get; set; }

        public CreationInfos()
        {
        }
    }

    public class CreationOverviewGump : GumpTemrael
    {
        private TMobile m_from;
        private CreationInfos m_infos;

        public CreationOverviewGump(TMobile from, CreationInfos infos)
            : base("Résumé", 560, 622)
        {
            m_from = from;
            m_infos = infos;
            int x = XBase;
            int y = YBase;
            int line = 2;
            int scale = 25;

            y = 650;
            x = 90;
            int space = 70;

            AddCreationMenuItem(x, y, 1193, 2, true);
            x += space;
            AddCreationMenuItem(x, y, 1190, 3, true);
            x += space;
            AddCreationMenuItem(x, y, 1188, 4, true);
            x += space;
            AddCreationMenuItem(x, y, 1224, 6, true);
            x += space;
            AddCreationMenuItem(x, y, 1182, 7, false);

            x = XBase;
            y = YBase;

            AddBackground(110, 125, 535, 90, 3500);
            AddHtml(125, 140, 510, 60, "<h3><basefont color=#5A4A31>Vérifiez les informations ci-dessous avant d'accepter. Une fois accepté, plusieurs de celles-ci ne peuvent être changés en jeu. Si vous souhaitez éditer l'une des valeurs, retournez à la page correspondante.<basefont></h3>", true, false);
            AddButton(470, 645, 52, 52, 8, GumpButtonType.Reply, 0);
            AddHtml(520, 645 + 12, 200, 20, "<h3><basefont color=#025a>Confirmer<basefont></h3>", false, false);

            x = 110;
            y = 305;
            AddSection(x, y, 400, 160, "<h3><basefont color=#025a>Informations<basefont></h3>");
            x = 130;
            y = 310;
            AddHtmlTexte(x, y + line * scale, 400, "<h3><basefont color=#5A4A31>Race: " + from.Race.Name + "<basefont></h3>");
            line++;
            //AddHtmlTexte(x, y + line * scale, 400, "<h3><basefont color=#5A4A31>Classe: " + from.Creation.classe.ToString() + "<basefont></h3>");
            //line++;
            //AddHtmlTexte(x, y + line * scale, 400, "<h3><basefont color=#5A4A31>Destination: " + from.Creation.destination.ToString() + "<basefont></h3>");
            //line++;
            if (m_from.Race.isAasimaar)
            {
                AddHtmlTexte(x, y + line * scale, 400, "<h3><basefont color=#5A4A31>Race Secrète: Aasimar<basefont></h3>");
                line++;
            }
            else if (m_from.Race.isTieffelin)
            {
                AddHtmlTexte(x, y + line * scale, 400, "<h3><basefont color=#5A4A31>Race Secrète: Tieffelin<basefont></h3>");
                line++;
            }
        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            TMobile from = (TMobile)sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            switch (info.ButtonID)
            {
                case 2:
                    from.SendGump(new CreationRaceGump(from, m_infos));
                    break;
                case 3:
                    if (from.Race != null)
                    {
                        from.SendGump(new CreationEquipementGump(from, m_infos));
                    }
                    else
                    {
                        goto case 3;
                    }
                    break;
                case 7:
                    from.SendGump(new CreationOverviewGump(from, m_infos));
                    break;
                case 8:
                    bool complete = true;

                    //if (m_from.Creation.race != Race.Aucun)
                    //    m_from.Races = m_from.Creation.race;
                    //else
                    //    complete = false;

                    //if (m_from.Creation.classe != ClasseType.None)
                    //    m_from.ClasseType = m_from.Creation.classe;

                    //if (m_from.Creation.destination == CreationCarteGump.DestinationsDepart.Aucune)
                    //    complete = false;

                    if (complete)
                    {

                        InitializeCreation(m_from, m_infos.Hue);
                        //switch (m_from.Creation.destination)
                        //{
                        //    case Server.Gumps.CreationCarteGump.DestinationsDepart.Hasteindale:
                        //        InitializeCreation(m_from);
                        //        m_from.MoveToWorld(new Point3D(861, 594, 0), Map.Ilshenar);
                        //        break;
                        //    case Server.Gumps.CreationCarteGump.DestinationsDepart.Brandheim:
                        //        InitializeCreation(m_from);
                        //        m_from.MoveToWorld(new Point3D(2402, 1005, -80), Map.Felucca);
                        //        break;
                        //    case Server.Gumps.CreationCarteGump.DestinationsDepart.Elamsham:
                        //        InitializeCreation(m_from);
                        //        m_from.MoveToWorld(new Point3D(2549, 1333, -81), Map.Felucca);
                        //        break;
                        //    case Server.Gumps.CreationCarteGump.DestinationsDepart.Citarel:
                        //        InitializeCreation(m_from);
                        //        m_from.MoveToWorld(new Point3D(3388, 1996, -80), Map.Felucca);
                        //        break;
                        //    case Server.Gumps.CreationCarteGump.DestinationsDepart.Serenite:
                        //        InitializeCreation(m_from);
                        //        m_from.MoveToWorld(new Point3D(2628, 2099, -6), Map.Felucca);
                        //        break;
                        //    case Server.Gumps.CreationCarteGump.DestinationsDepart.Melandre:
                        //        InitializeCreation(m_from);
                        //        m_from.MoveToWorld(new Point3D(3088, 2809, -52), Map.Felucca);
                        //        break;
                        //    case Server.Gumps.CreationCarteGump.DestinationsDepart.Tartarus:
                        //        InitializeCreation(m_from);
                        //        m_from.MoveToWorld(new Point3D(1859, 3359, -79), Map.Felucca);
                        //        break;
                        //    default: break;
                        //}
                        m_from.MoveToWorld(new Point3D(1806, 1338, -80), Map.Felucca);
                        m_from.SendMessage("Vous avez le droit d'apprendre une seconde langue.");
                        m_from.SendGump(new GumpLanguage(m_from, true));
                    }
                    else
                    {
                        from.SendGump(new CreationOverviewGump(from, m_infos));
                        from.SendMessage("Vous devez complete tout les champs !");
                    }

                    break;
            }
        }

        private static void SetSkills(TMobile from)
        {
            from.SkillsCap = 100 * 10;

            for (int i = 0; i < from.Skills.Length; ++i)
            {
                from.Skills[i].Base = 0.0;
                from.Skills[i].Cap = 100.0;
            }

            //from.CompetencesLibres = 200;
        }

        private static void SetCaract(TMobile from)
        {
            Statistiques.Reset(from);
        }

        public static void EquipItem(TMobile from, Item item)
        {
            if (item != null)
                from.EquipItem(item);
        }

        private static void PackItem(TMobile from, Item item)
        {
            if (!Core.AOS)
                item.LootType = LootType.Blessed;

            Container pack = from.Backpack;

            if (pack != null)
                pack.DropItem(item);
            else
                item.Delete();
        }

        private static void InitializeCreation(TMobile from, int hue)
        {
            from.Experience.Niveau = 0;
            SetSkills(from);
            SetCaract(from);

            if (from.Backpack != null)
            {
                while (from.Backpack.Items.Count > 0)
                    ((Item)from.Backpack.Items[0]).Delete();
            }

            PackItem(from, new RedBook("a book", from.Name, 20, true));
            PackItem(from, new Gold(200)); //
            PackItem(from, new Dagger());
            PackItem(from, new Candle());

            Race race = from.Race;
            from.Hue = hue;

            if (race is Elfe)
            {
                EquipItem(from, new CorpsElfe(from.Hue));
            }
            else if (race is Alfar)
            {
                EquipItem(from, new CorpsElfe(from.Hue));
            }
            else if (race is Nain)
            {
                EquipItem(from, new CorpsNain(from.Hue));
            }
            else if (race is Nordique)
            {
                EquipItem(from, new CorpsNordique(from.Hue));
            }
            else if (race is Orcish)
            {
                EquipItem(from, new CorpsOrcish(from.Hue));
            }
            //case Race.Tieffelin:
            //    from.RaceSecrete = from.Creation.secrete;
            //    switch (from.RaceSecrete)
            //    {
            //        case Race.Nordique:
            //            from.Hue = 1023;
            //            from.EquipItem(new CorpsNordique(from.Hue));
            //            break;
            //        case Race.Nomade:
            //            from.Hue = 1044;
            //            break;
            //        case Race.Capiceen:
            //            from.Hue = 1023;
            //            break;
            //    }
            //    break;
            //case Race.Aasimar:
            //    from.RaceSecrete = from.Creation.secrete;
            //    switch (from.RaceSecrete)
            //    {
            //        case Race.Nordique:
            //            from.Hue = 1023;
            //            from.EquipItem(new CorpsNordique(from.Hue));
            //            break;
            //        case Race.Nomade:
            //            from.Hue = 1044;
            //            break;
            //        case Race.Capiceen:
            //            from.Hue = 1023;
            //            break;
            //    }
            //    break;

        }
    }
}
