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
    public class CreationOverviewGump : GumpTemrael
    {
        private TMobile m_from;

        public CreationOverviewGump(TMobile from)
            : base("Résumé", 560, 622)
        {
            m_from = from;
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
            AddMenuItem(x, y, 1224, 6, true);
            x += space;
            AddMenuItem(x, y, 1182, 7, false);

            x = XBase;
            y = YBase;

            AddBackground(110, 125, 535, 140, 3500);
            AddHtml(125, 140, 510, 70, "Vérifiez les informations ci-dessous avant d'accepter. Une fois accepté, plusieurs de celles-ci ne peuvent être changés en jeu. Si vous souhaitez édité l'une des valeurs, retournez à la page correspondante.", true, true);
            AddHtml(520, 227, 200, 20, "<h3><basefont color=#025a>Confirmer<basefont></h3>", false, false);
            AddButton(470, 215, 52, 52, 8, GumpButtonType.Reply, 0);

            x = 110;
            y = 305;
            AddSection(x, y, 400, 160, "<h3><basefont color=#025a>Informations<basefont></h3>");
            x = 130;
            y = 310;
            AddHtmlTexte(x, y + line * scale, 400, "<h3><basefont color=#5A4A31>Race: " + from.Creation.race + "<basefont></h3>");
            line++;
            AddHtmlTexte(x, y + line * scale, 400, "<h3><basefont color=#5A4A31>Alignement: " + Alignements.getString(from.Creation.alignementA, from.Creation.alignementB));
            line++;
            AddHtmlTexte(x, y + line * scale, 400, "<h3><basefont color=#5A4A31>Classe: " + from.Creation.classe.ToString() + "<basefont></h3>");
            line++;
            AddHtmlTexte(x, y + line * scale, 400, "<h3><basefont color=#5A4A31>Métier: " + from.Creation.metier.ToString() + "<basefont></h3>");
            line++;
            AddHtmlTexte(x, y + line * scale, 400, "<h3><basefont color=#5A4A31>Destination: " + from.Creation.destination.ToString() + "<basefont></h3>");
            line++;
            if (m_from.Creation.race == Races.Aasimar || m_from.Creation.race == Races.Tieffelin)
            {
                AddHtmlTexte(x, y + line * scale, 400, "<h3><basefont color=#5A4A31>Race Secrète: " + from.Creation.secrete.ToString() + "<basefont></h3>");
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
                    bool complete = true;

                    if (m_from.Creation.race != Races.Aucun)
                        m_from.Races = m_from.Creation.race;
                    else
                        complete = false;

                    if (m_from.Creation.metier != MetierType.None)
                        if (m_from.MetierType.Count > 0)
                            m_from.MetierType[0] = m_from.Creation.metier;
                        else
                            m_from.MetierType.Add(m_from.Creation.metier);
                    else
                        complete = false;

                    if (m_from.Creation.classe != ClasseType.None)
                        m_from.ClasseType = m_from.Creation.classe;

                    if (m_from.Creation.destination == CreationCarteGump.DestinationsDepart.Aucune)
                        complete = false;

                    if ((m_from.Creation.race == Races.Tieffelin || m_from.Creation.race == Races.Aasimar) && m_from.Creation.secrete == Races.Aucun)
                        m_from.Creation.secrete = Races.Capiceen;

                    if (complete)
                    {
                        m_from.Identity[0] = m_from.Name;
                        switch (m_from.Creation.destination)
                        {
                            case Server.Gumps.CreationCarteGump.DestinationsDepart.Hasteindale:
                                InitializeCreation(m_from);
                                m_from.MoveToWorld(new Point3D(861, 594, 0), Map.Ilshenar);
                                break;
                            case Server.Gumps.CreationCarteGump.DestinationsDepart.Brandheim:
                                InitializeCreation(m_from);
                                m_from.MoveToWorld(new Point3D(2402, 1005, -80), Map.Felucca);
                                break;
                            case Server.Gumps.CreationCarteGump.DestinationsDepart.Elamsham:
                                InitializeCreation(m_from);
                                m_from.MoveToWorld(new Point3D(2549, 1333, -81), Map.Felucca);
                                break;
                            case Server.Gumps.CreationCarteGump.DestinationsDepart.Citarel:
                                InitializeCreation(m_from);
                                m_from.MoveToWorld(new Point3D(3388, 1996, -80), Map.Felucca);
                                break;
                            case Server.Gumps.CreationCarteGump.DestinationsDepart.Serenite:
                                InitializeCreation(m_from);
                                m_from.MoveToWorld(new Point3D(2628, 2099, -6), Map.Felucca);
                                break;
                            case Server.Gumps.CreationCarteGump.DestinationsDepart.Melandre:
                                InitializeCreation(m_from);
                                m_from.MoveToWorld(new Point3D(3088, 2809, -52), Map.Felucca);
                                break;
                            case Server.Gumps.CreationCarteGump.DestinationsDepart.Tartarus:
                                InitializeCreation(m_from);
                                m_from.MoveToWorld(new Point3D(1859, 3359, -79), Map.Felucca);
                                break;
                            case Server.Gumps.CreationCarteGump.DestinationsDepart.PosteDeGarde:
                                InitializeCreation(m_from);
                                m_from.MoveToWorld(new Point3D(3462, 2279, -75), Map.Felucca);
                                break;
                            case Server.Gumps.CreationCarteGump.DestinationsDepart.Prison:
                                InitializeCreation(m_from);
                                m_from.MoveToWorld(new Point3D(3565, 2270, -80), Map.Felucca);
                                break;
                            default: break;
                        }
                        m_from.SendMessage("Vous avez le droit d'apprendre une seconde langue.");
                        m_from.SendGump(new GumpLanguage(m_from, true));
                    }
                    else
                    {
                        from.SendGump(new CreationOverviewGump(from));
                        from.SendMessage("Vous devez complete tout les champs !");
                    }

                    break;
            }
        }

        private static void SetSkills(TMobile from)
        {
            from.SkillsCap = 800 * 10;

            for (int i = 0; i < from.Skills.Length; ++i)
            {
                from.Skills[i].Base = 0.0;
                from.Skills[i].Cap = 100.0;
            }

            from.CompetencesLibres = 800;
        }

        private static void SetAptitudes(TMobile from)
        {
            from.AptitudesLibres = 35;

            //Pour les humains
            if (from.GetAptitudeValue(Aptitude.PointSup) > 0)
              from.AptitudesLibres += from.GetAptitudeValue(Aptitude.PointSup);
        }

        private static void SetNiveau(TMobile from)
        {
            from.Niveau = 30;
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
                item.LootType = LootType.Newbied;

            Container pack = from.Backpack;

            if (pack != null)
                pack.DropItem(item);
            else
                item.Delete();
        }

        private static void InitializeCreation(TMobile from)
        {
            from.Niveau = 0;
            SetSkills(from);
            SetAptitudes(from);
            SetNiveau(from);
            SetCaract(from);
            //PackItem(from, new RedBook("a book", from.Name, 20, true));
            //PackItem(from, new Gold(2000)); //
            //PackItem(from, new Dagger());
            //PackItem(from, new Candle());
            /*if (from.Metier == Metier.Noble || from.MetierSecondaire == Metier.Noble)
                from.PointDestin = 1;
            else if (from.Races == Races.Tieffelin)
                from.PointDestin = 1;
            else
                from.PointDestin = 3;*/

            switch (from.Races)
            {
                case Races.Elfe:
                    //from.Hue = 2425;
                    from.Hue = from.Creation.hue;
                    EquipItem(from, new CorpsElfe(from.Hue));
                    break;
                case Races.ElfeNoir:
                    //from.Hue = 1900;
                    from.Hue = from.Creation.hue;
                    EquipItem(from, new CorpsElfe(from.Hue));
                    break;
                case Races.Capiceen:
                    //from.Hue = 1024;
                    from.Hue = from.Creation.hue;
                    break;
                case Races.Nain:
                    //from.Hue = 1867;
                    from.Hue = from.Creation.hue;
                    EquipItem(from, new CorpsNain(from.Hue));
                    break;
                case Races.Nomade:
                    //from.Hue = 1816;
                    from.Hue = from.Creation.hue;
                    break;
                case Races.Nordique:
                    //from.Hue = 1048;
                    from.Hue = from.Creation.hue;
                    EquipItem(from, new CorpsNordique(from.Hue));
                    break;
                case Races.Orcish:
                    //from.Hue = 1437;
                    from.Hue = from.Creation.hue;
                    EquipItem(from, new CorpsOrcish(from.Hue));
                    break;
                case Races.Tieffelin:
                    from.RaceSecrete = from.Creation.secrete;
                    switch (from.RaceSecrete)
                    {
                        case Races.Nordique:
                            from.Hue = 1023;
                            from.EquipItem(new CorpsNordique(from.Hue));
                            break;
                        case Races.Nomade:
                            from.Hue = 1044;
                            break;
                        case Races.Capiceen:
                            from.Hue = 1023;
                            break;
                    }
                    break;
                case Races.Aasimar:
                    from.RaceSecrete = from.Creation.secrete;
                    switch (from.RaceSecrete)
                    {
                        case Races.Nordique:
                            from.Hue = 1023;
                            from.EquipItem(new CorpsNordique(from.Hue));
                            break;
                        case Races.Nomade:
                            from.Hue = 1044;
                            break;
                        case Races.Capiceen:
                            from.Hue = 1023;
                            break;
                    }
                    break;
                default: break;
            }
        }
    }
}
