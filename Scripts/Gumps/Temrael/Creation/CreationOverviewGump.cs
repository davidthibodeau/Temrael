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

namespace Server.Gumps.Creation
{

    public class CreationOverviewGump : BaseCreationGump
    {
        public CreationOverviewGump(PlayerMobile from)
            : base(from, "Résumé", 560, 622, 7)
        {
            int x = XBase;
            int y = YBase;
            int line = 2;
            int scale = 25;

            AddBackground(110, 125, 535, 210, 3500);
            AddHtml(125, 140, 510, 180, "<h3><basefont color=#5A4A31>Veuillez vérifier votre choix de race et vous assurer " 
                + "que vos vêtements de départ sont tels que désirés. Vous ne pourrez conserver que ce que votre personnage " 
                + "porte en ce moment, mais pas le contenu de votre sac. Si vous désirez modifier une de ses informations, " 
                + "retournez à la page correspondante.<br /><br />Si vous avez de l'expérience en banque de transfert, veuillez " 
                + "vous assurez de l'avoir transféré via la commande .transfert. Il ne vous sera plus possible de faire le transfert " 
                + "par après.<basefont></h3>", true, false);
            AddButton(470, 645, 52, 52, 8, GumpButtonType.Reply, 0);
            AddHtml(520, 645 + 12, 200, 20, "<h3><basefont color=#025a>Confirmer<basefont></h3>", false, false);

            //x = 110;
            //y = 305;
            //AddSection(x, y, 400, 160, "<h3><basefont color=#025a>Informations<basefont></h3>");
            //x = 130;
            //y = 310;
            //AddHtmlTexte(x, y + line * scale, 400, "<h3><basefont color=#5A4A31>Race: " + from.Race.Name + "<basefont></h3>");
            //line++;
            ////AddHtmlTexte(x, y + line * scale, 400, "<h3><basefont color=#5A4A31>Classe: " + from.Creation.classe.ToString() + "<basefont></h3>");
            ////line++;
            ////AddHtmlTexte(x, y + line * scale, 400, "<h3><basefont color=#5A4A31>Destination: " + from.Creation.destination.ToString() + "<basefont></h3>");
            ////line++;
            //if (m_from.Race.isAasimaar)
            //{
            //    AddHtmlTexte(x, y + line * scale, 400, "<h3><basefont color=#5A4A31>Race Secrète: Aasimar<basefont></h3>");
            //    line++;
            //}
            //else if (m_from.Race.isTieffelin)
            //{
            //    AddHtmlTexte(x, y + line * scale, 400, "<h3><basefont color=#5A4A31>Race Secrète: Tieffelin<basefont></h3>");
            //    line++;
            //}
        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            PlayerMobile from = (PlayerMobile)sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            if (info.ButtonID < 8)
            {
                base.OnResponse(sender, info);
                return;
            }

            switch (info.ButtonID)
            {
                case 8:
                    if (from.Race is AucuneRace)
                    {
                        from.SendGump(new CreationOverviewGump(from));
                        from.SendMessage("Vous devez choisir une race");
                    }
                    else
                    {
                        InitializeCreation(m_from);

                        m_from.MoveToWorld(new Point3D(1806, 1338, -80), Map.Felucca);

                        m_from.SendMessage("Vous avez le droit d'apprendre une seconde langue.");
                        m_from.SendGump(new GumpLanguage(m_from, true));
                    }
                    break;
            }
        }

        private static void SetSkills(PlayerMobile from)
        {
            from.SkillsCap = 100 * 10;

            for (int i = 0; i < from.Skills.Length; ++i)
            {
                from.Skills[i].Base = 0.0;
                from.Skills[i].Cap = 100.0;
            }

            //from.CompetencesLibres = 200;
        }

        private static void SetCaract(PlayerMobile from)
        {
            Statistiques.Reset(from);
        }

        public static void EquipItem(PlayerMobile from, Item item)
        {
            if (item != null)
                from.EquipItem(item);
        }

        private static void PackItem(PlayerMobile from, Item item)
        {
            if (!Core.AOS)
                item.LootType = LootType.Blessed;

            Container pack = from.Backpack;

            if (pack != null)
                pack.DropItem(item);
            else
                item.Delete();
        }

        private static void InitializeCreation(PlayerMobile from)
        {
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
            //from.Hue = hue;

            //if (race is Elfe)
            //{
            //    EquipItem(from, new CorpsElfe(from.Hue));
            //}
            //else if (race is Alfar)
            //{
            //    EquipItem(from, new CorpsElfe(from.Hue));
            //}
            //else if (race is Nain)
            //{
            //    EquipItem(from, new CorpsNain(from.Hue));
            //}
            //else if (race is Nordique)
            //{
            //    EquipItem(from, new CorpsNordique(from.Hue));
            //}
            //else if (race is Orcish)
            //{
            //    EquipItem(from, new CorpsOrcish(from.Hue));
            //}
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
