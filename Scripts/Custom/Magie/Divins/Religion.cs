using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells
{
    public enum Dieux
    {
        Aucune,
        Croise,
        Vierge,
        Chasseresse,
        Batisseur,
        Mere,
        Guerrier,
        General,
        Sorciere,
        Assassin
    }

    public class Religion
    {
        private static string[] m_GodName = new string[]
        {
            "Aucun", "Le Croisé", "La Vierge", "La Chaseresse", "Le Bâtisseur", "La Mère", "Le Guerrier", "Le Général", "La Sorcière", "L'Assassin"
        };

        private static string[] m_GodNameNoAccent = new string[]
        {
            "Aucun", "Le Croise", "La Vierge", "La Chaseresse", "Le Batisseur", "La Mere", "Le Guerrier", "Le General", "La Sorciere", "L'Assassin"
        };

        public static string GetDieuxName(Dieux Dieux)
        {
            return m_GodName[(int)Dieux];
        }

        public static string GetGodName(TMobile from)
        {
            return m_GodName[(int)from.Dieux];
        }

        public static string GetGodNameNoAccent(TMobile from)
        {
            return m_GodNameNoAccent[(int)from.Dieux];
        }

        public static void DoPrayer(TMobile from, Dieux Dieux, int seconds, int minPDP, int maxPDP, int mana)
        {
            if (mana > from.Mana)
            {
                from.SendMessage("Vous n'avez pas assez de mana.");
            }
            else if (from.Dieux == Spells.Dieux.Aucune)
            {
                from.Dieux = Dieux;
                from.SendMessage("Vous prenez pour dieu " + m_GodName[(int)Dieux]);
                from.SendGump(new ReligionGump(from, Dieux));
            }
            else if (from.Dieux != Dieux && DateTime.Now < from.NextDieuxChange)
            {
                //ResetValues(from, Dieux);
                from.SendMessage("Vous ne pouvez pas changer de Dieux dès maintenant !");
                from.SendGump(new ReligionGump(from, Dieux));
            }
            else if (from.Dieux != Dieux && DateTime.Now >= from.NextDieuxChange)
            {
                //from.SendGump(new DieuxChangeGump(from, Dieux, seconds, minPDP, maxPDP, mana));
                ResetValues(from, Dieux);
                DoPrayer(from, Dieux, seconds, minPDP, maxPDP, mana);
            }
            else
            {
                from.SendMessage("Vous débutez votre prière.");
                from.PublicOverheadMessage(MessageType.Emote, 0x59, false, "*débute une prière*", false);

                //from.LastPrayerLocation = from.Location;
                from.Mana -= mana;

                TimeSpan duration = TimeSpan.FromSeconds(seconds);
                int pdp = Utility.RandomMinMax(minPDP, maxPDP);

                /*pdp *= 1 + (GetPiete(from) / 2100);
                pdp *= 1 + (GetInfluence(from) / 5000);

                if (pdp > maxPDP)
                    pdp = maxPDP;*/

                if (from.TimerPraying != null)
                {
                    from.TimerPraying.Stop();
                    from.TimerPraying = null;
                }

                //from.CheckEtude();

                from.NextPrayingTime = DateTime.Now + duration;

                from.TimerPraying = new TMobile.PrayingTimer(from, duration, pdp);
                from.TimerPraying.Start();
            }
        }

        /*public static int GetPdp(TMobile from)
        {
            return from.PouvoirDivinProcure;
        }

        public static int GetMaxPdp(TMobile from)
        {
            return from.PdpMax;
        }*/

        public static int GetPiete(TMobile from)
        {
            return from.Piete;
        }

        public static int GetInfluence(TMobile from)
        {
            int croyant = 0;
            int total = 0;

            ArrayList mobs = new ArrayList(World.Mobiles.Values);

            foreach (Mobile mob in mobs)
            {
                if (mob is TMobile)
                {
                    TMobile m = (TMobile)mob;

                    if (m.Dieux != Dieux.Aucune)
                    {
                        if (m.Dieux == from.Dieux)
                            croyant++;

                        total++;
                    }
                }
            }

            if (total <= 0)
                return 0;

            return (croyant * 1000) / total;
        }

        public static void ResetValues(TMobile from, Dieux Dieux)
        {
            from.Piete = 0;
            //from.PouvoirDivinProcure = 0;
            from.Dieux = Dieux;
            from.NextDieuxChange = DateTime.Now.AddDays(7);
        }

        public class ReligionGump : Gump
        {
            private TMobile m_From;
            private Dieux m_Dieux;

            public ReligionGump(TMobile from, Dieux Dieux)
                : base(0, 0)
            {
                m_From = from;
                m_Dieux = Dieux;

                Closable = true;
                Disposable = true;
                Dragable = true;
                Resizable = false;

                AddPage(0);

                //BG
                AddBackground(80, 72, 640, 730, 3600);
                AddBackground(90, 82, 620, 710, 9200);
                AddBackground(100, 92, 600, 690, 3500);
                AddBackground(120, 112, 560, 650, 9300);

                //Dragons
                AddImage(39, 53, 10440);
                AddImage(679, 53, 10441);

                AddImage(125, 130, 95);
                AddImage(132, 139, 96);
                AddImage(268, 139, 96);
                AddImage(335, 139, 96);
                AddImage(435, 139, 96);
                AddImage(490, 139, 96);
                AddImage(665, 130, 97);

                AddBackground(119, 625, 557, 130, 3500);
                //AddAlphaRegion(74, 305, 557, 162);

                AddHtml(370, 125, 200, 20, "<h3><basefont color=#025a>Religion<basefont></h3>", false, false);

                AddBackground(185, 190, 130, 132, 2620);
                AddButton(190, 195, 1701, 1701, 1, GumpButtonType.Reply, 0);

                AddBackground(325, 190, 130, 132, 2620);
                AddButton(330, 195, 1700, 1700, 2, GumpButtonType.Reply, 0);

                AddBackground(465, 190, 130, 132, 2620);
                AddButton(470, 195, 1707, 1707, 3, GumpButtonType.Reply, 0);



                AddBackground(185, 340, 130, 132, 2620);
                AddButton(190, 345, 1699, 1699, 4, GumpButtonType.Reply, 0);

                AddBackground(325, 340, 130, 132, 2620);
                AddButton(330, 345, 1702, 1702, 5, GumpButtonType.Reply, 0);

                AddBackground(465, 340, 130, 132, 2620);
                AddButton(470, 345, 1710, 1710, 6, GumpButtonType.Reply, 0);


                AddBackground(185, 490, 130, 132, 2620);
                AddButton(190, 495, 1709, 1709, 7, GumpButtonType.Reply, 0);

                AddBackground(325, 490, 130, 132, 2620);
                AddButton(330, 495, 1705, 1705, 8, GumpButtonType.Reply, 0);

                AddBackground(465, 490, 130, 132, 2620);
                AddButton(470, 495, 1708, 1708, 9, GumpButtonType.Reply, 0);

                //for (int i = 0; i < 5; i++)
                //{
                //    AddImage(78 + (i * 115), 103, 1571 + i);
                //    AddButton(107 + (i * 115), 264, 2151, 2152, 1 + i, GumpButtonType.Reply, 0);
                //}

                AddHtml(220, 175, 200, 20, "<h3><basefont color=#025a>Le Croisé<basefont></h3>", false, false);
                AddHtml(370, 175, 200, 20, "<h3><basefont color=#025a>La Vierge<basefont></h3>", false, false);
                AddHtml(500, 175, 200, 20, "<h3><basefont color=#025a>La Chaseresse<basefont></h3>", false, false);


                AddHtml(220, 325, 200, 20, "<h3><basefont color=#025a>Le Bâtisseur<basefont></h3>", false, false);
                AddHtml(370, 325, 200, 20, "<h3><basefont color=#025a>La Mère<basefont></h3>", false, false);
                AddHtml(500, 325, 200, 20, "<h3><basefont color=#025a>Le Guerrier<basefont></h3>", false, false);

                AddHtml(220, 475, 200, 20, "<h3><basefont color=#025a>Le Général<basefont></h3>", false, false);
                AddHtml(370, 475, 200, 20, "<h3><basefont color=#025a>La Sorcière<basefont></h3>", false, false);
                AddHtml(500, 475, 200, 20, "<h3><basefont color=#025a>L'Assassin<basefont></h3>", false, false);

                //AddHtml(355, 512, 200, 20, "<h3><basefont color=#025a>Religion<basefont></h3>", false, false);

                AddHtml(258, 636, 200, 20, "<h3><basefont color=#025a>Pieté<basefont></h3>", false, false);
                AddHtml(447, 635, 200, 20, "<h3><basefont color=#5A4A31>" + GetPiete(m_From) + " / 12<basefont></h3>", false, false);
                AddHtml(258, 666, 200, 20, "<h3><basefont color=#025a>Relation actuelle<basefont></h3>", false, false);
                AddHtml(447, 666, 200, 20, "<h3><basefont color=#5A4A31>" + GetGodName(m_From) + "<basefont></h3>", false, false);
                /*AddHtml(258, 696, 200, 20, "<h3><basefont color=#025a>Influence divine<basefont></h3>", false, false);
                AddHtml(447, 696, 200, 20, "<h3><basefont color=#5A4A31>" + GetInfluence(m_From) + " / 1000<basefont></h3>", false, false);*/
                //AddLabel(223, 426, 1152, "Pouvoir divin procuré");
                //AddLabel(412, 426, 1152, GetPdp(m_From) + " / " + GetMaxPdp(m_From));

                for (int i = 0; i < 3; ++i)
                    AddHtml(414, 441 + (i * 30), 200, 20, "<h3><basefont color=#5A4A31>:<basefont></h3>", false, false);

                AddHtml(148, 645, 200, 20, "<h3><basefont color=#025a>Convertir<basefont></h3>", false, false);
                AddButton(146, 661, 111, 111, 0, GumpButtonType.Reply, 0);
                //AddButton(570, 561, 111, 111, 9, GumpButtonType.Reply, 0);
            }

            private class PriereEntry
            {
                private int m_Duree, m_MinPDP, m_MaxPDP, m_Mana;

                public int Duree { get { return m_Duree; } }
                public int MinPDP { get { return m_MinPDP; } }
                public int MaxPDP { get { return m_MaxPDP; } }
                public int Mana { get { return m_Mana; } }

                public PriereEntry(int duree, int minPDP, int maxPDP, int mana)
                {
                    m_Duree = duree;
                    m_MinPDP = minPDP;
                    m_MaxPDP = maxPDP;
                    m_Mana = mana;
                }
            }

            private static PriereEntry[] m_Entries = new PriereEntry[]
			{
				new PriereEntry( 20, 20, 30, 10 ),
				new PriereEntry( 40, 40, 60, 10 ),
				new PriereEntry( 60, 60, 80, 10 ),
				new PriereEntry( 80, 80, 100, 10 ),
				new PriereEntry( 100, 100, 120, 10 ),
				new PriereEntry( 120, 120, 140, 10 ),
			};

            public override void OnResponse(NetState sender, RelayInfo info)
            {
                switch (info.ButtonID)
                {
                    case 1:
                        m_Dieux = Dieux.Croise;
                        break;
                    case 2:
                        m_Dieux = Dieux.Vierge;
                        break;
                    case 3:
                        m_Dieux = Dieux.Chasseresse;
                        break;
                    case 4:
                        m_Dieux = Dieux.Batisseur;
                        break;
                    case 5:
                        m_Dieux = Dieux.Mere;
                        break;
                    case 6:
                        m_Dieux = Dieux.Guerrier;
                        break;
                    case 7:
                        m_Dieux = Dieux.General;
                        break;
                    case 8:
                        m_Dieux = Dieux.Sorciere;
                        break;
                    case 9:
                        m_Dieux = Dieux.Assassin;
                        break;
                }

                /*else if (info.ButtonID == 8)
                {
                    m_From.Target = new InternalTarget(m_From);
                }
                else if (m_Croix is Croix && (!m_From.CanSee(m_Croix) || !m_From.InRange(m_Croix.Location, 4)))
                {
                    m_From.SendLocalizedMessage(500446); // That is too far away.
                }*/
                if (info.ButtonID == 0)
                {
                    m_From.CloseGump(typeof(ReligionGump));
                }
                else if (m_From.IsPraying)
                {
                    m_From.SendMessage("Vous êtes déjà en train de prier.");
                }
                else
                {
                    //int i = 5;
                    int seconds = 15;
                    int minPDP = m_From.Skills.Priere.Fixed / 200;
                    int maxPDP = m_From.Skills.Priere.Fixed / 100;
                    int mana = 10;

                    /*int pouvoirdivin = m_From.GetAptitudeValue(NAptitude.GraceDivine);

                    minPDP = (int)(minPDP * (1 + pouvoirdivin * 0.03));
                    maxPDP = (int)(maxPDP * (1 + pouvoirdivin * 0.03));*/

                    //m_From.SendMessage("Grâce à votre niveau de pouvoir divin, votre prière vous procurera entre " + minPDP + " et " + maxPDP + " pouvoir divin.");

                    DoPrayer(m_From, m_Dieux, seconds, minPDP, maxPDP, mana);
                    //m_From.SendGump(new PriereGump(m_From, (Dieux)info.ButtonID));
                }
            }

            public class InternalTarget : Target
            {
                TMobile m_from;

                public InternalTarget(TMobile from)
                    : base(-1, false, TargetFlags.None)
                {
                    m_from = from;
                }

                protected override void OnTarget(Mobile from, object target)
                {
                    if (target != null)
                    {
                        if (target is TMobile)
                        {
                            TMobile targ = target as TMobile;
                            if ((!m_from.CanSee(targ) || !m_from.InRange(targ.Location, 4)))
                            {
                                m_from.SendLocalizedMessage(500446); // That is too far away.
                            }
                            else
                            {
                                if (DateTime.Now < targ.NextDieuxChange)
                                {
                                    m_from.SendMessage("Il est trop tot pour changer la religion du personnage !");
                                }
                                else if (targ.Dieux == m_from.Dieux)
                                {
                                    m_from.SendMessage("Il prit deja le meme dieux que vous !");
                                }
                                else
                                {
                                    //Religion.ResetValues(targ, m_from.Dieux);
                                    //m_from.SendMessage("Il est desormais convertie.");
                                    targ.SendGump(new DieuxChangeGump(targ, m_from.Dieux));
                                }
                            }
                            m_from.SendGump(new ReligionGump(m_from, m_from.Dieux));
                        }
                    }
                }
            }
        }

        public class PriereGump : Gump
        {
            private class PriereEntry
            {
                private int m_Duree, m_MinPDP, m_MaxPDP, m_Mana;

                public int Duree { get { return m_Duree; } }
                public int MinPDP { get { return m_MinPDP; } }
                public int MaxPDP { get { return m_MaxPDP; } }
                public int Mana { get { return m_Mana; } }

                public PriereEntry(int duree, int minPDP, int maxPDP, int mana)
                {
                    m_Duree = duree;
                    m_MinPDP = minPDP;
                    m_MaxPDP = maxPDP;
                    m_Mana = mana;
                }
            }

            private static PriereEntry[] m_Entries = new PriereEntry[]
			{
				new PriereEntry( 20, 20, 30, 10 ),
				new PriereEntry( 40, 40, 60, 20 ),
				new PriereEntry( 60, 60, 80, 30 ),
				new PriereEntry( 80, 80, 100, 40 ),
				new PriereEntry( 100, 100, 120, 50 ),
				new PriereEntry( 120, 120, 140, 60 ),
			};

            private TMobile m_From;
            private Dieux m_Dieux;
            private Item m_Croix;

            public PriereGump(TMobile from, Dieux Dieux)
                : base(0, 0)
            {
                m_From = from;
                m_Dieux = Dieux;

                Closable = true;
                Disposable = true;
                Dragable = true;
                Resizable = false;

                AddPage(0);

                AddBackground(58, 10, 234, 255, 9200);
                AddBackground(66, 18, 218, 25, 9300);
                AddBackground(67, 57, 214, 196, 2620);

                AddAlphaRegion(72, 64, 204, 182);

                AddItem(187, 118, 2);
                AddItem(209, 118, 3);
                AddImage(8, 12, 10400);
                AddImage(7, 184, 10402);
                AddImage(259, 12, 10410);
                AddImage(259, 184, 10412);

                AddLabel(111, 20, 0, "Choisissez une prière");

                AddLabel(103, 70, 1152, "20 secondes");
                AddButton(80, 73, 2103, 2104, 1, GumpButtonType.Reply, 0);
                AddLabel(103, 100, 1152, "40 secondes");
                AddButton(80, 103, 2103, 2104, 2, GumpButtonType.Reply, 0);
                AddLabel(103, 130, 1152, "60 secondes");
                AddButton(80, 133, 2103, 2104, 3, GumpButtonType.Reply, 0);
                AddLabel(103, 160, 1152, "80 secondes");
                AddButton(80, 163, 2103, 2104, 4, GumpButtonType.Reply, 0);
                AddLabel(103, 190, 1152, "100 secondes");
                AddButton(80, 193, 2103, 2104, 5, GumpButtonType.Reply, 0);
                AddLabel(103, 220, 1152, "120 secondes");
                AddButton(80, 224, 2103, 2104, 6, GumpButtonType.Reply, 0);
            }

            public override void OnResponse(NetState sender, RelayInfo info)
            {
                if (info.ButtonID == 0)
                {
                    m_From.CloseGump(typeof(ReligionGump));
                    m_From.CloseGump(typeof(PriereGump));
                }
                else
                {
                    /*if (m_Croix is Croix && (!m_From.CanSee(m_Croix) || !m_From.InRange(m_Croix.Location, 4)))
                    {
                        m_From.SendLocalizedMessage(500446); // That is too far away.
                    }*/
                    if (m_From.NextActionTime > DateTime.Now)
                    {
                        m_From.SendMessage("Vous devant attendre avant de prier.");
                    }
                    else if (m_From.IsPraying)
                    {
                        m_From.SendMessage("Vous êtes déjà en train de prier.");
                    }
                    else
                    {
                        int i = info.ButtonID - 1;
                        int seconds = m_Entries[i].Duree;
                        int minPDP = m_Entries[i].MinPDP;
                        int maxPDP = m_Entries[i].MaxPDP;
                        int mana = m_Entries[i].Mana;

                        int pouvoirdivin = m_From.GetAptitudeValue(Aptitude.GraceDivine);

                        minPDP = (int)(minPDP * (1 + pouvoirdivin * 0.03));
                        maxPDP = (int)(maxPDP * (1 + pouvoirdivin * 0.03));

                        //m_From.SendMessage("Grâce à votre niveau de pouvoir divin, votre prière vous procurera entre " + minPDP + " et " + maxPDP + " pouvoir divin.");

                        DoPrayer(m_From, m_Dieux, seconds, minPDP, maxPDP, mana);
                    }
                }
            }
        }

        public class DieuxChangeGump : Gump
        {
            private TMobile m_From;
            private Dieux m_Dieux;
            private int m_Seconds;
            private int m_minPDP;
            private int m_maxPDP;
            private int m_mana;
            private Item m_Croix;

            public DieuxChangeGump(TMobile from, Dieux Dieux, int seconds, int minPDP, int maxPDP, int mana)
                : base(0, 0)
            {
                m_From = from;
                m_Dieux = Dieux;
                m_Seconds = seconds;
                m_minPDP = minPDP;
                m_maxPDP = maxPDP;
                m_mana = mana;

                Closable = true;
                Disposable = true;
                Dragable = true;
                Resizable = false;

                AddPage(0);

                AddBackground(0, 0, 334, 130, 9200);
                AddBackground(8, 8, 318, 25, 9300);
                AddBackground(9, 47, 314, 71, 2620);

                AddLabel(30, 10, 0, "Désirez vous changer de Dieux pour " + GetDieuxName(Dieux) + " ?");

                AddLabel(45, 60, 1152, "Oui");
                AddButton(22, 63, 2103, 2104, 1, GumpButtonType.Reply, 0);
                AddLabel(45, 90, 1152, "Non");
                AddButton(22, 93, 2103, 2104, 2, GumpButtonType.Reply, 0);
            }

            public DieuxChangeGump(TMobile from, Dieux Dieux)
                : base(0, 0)
            {
                m_From = from;
                m_Dieux = Dieux;
                //m_Seconds = seconds;
                //m_minPDP = minPDP;
                //m_maxPDP = maxPDP;
                //m_mana = mana;

                Closable = true;
                Disposable = true;
                Dragable = true;
                Resizable = false;

                AddPage(0);

                AddBackground(0, 0, 334, 130, 9200);
                AddBackground(8, 8, 318, 25, 9300);
                AddBackground(9, 47, 314, 71, 2620);

                AddLabel(30, 10, 0, "Désirez vous changer de Dieux pour " + GetDieuxName(Dieux) + " ?");

                AddLabel(45, 60, 1152, "Oui");
                AddButton(22, 63, 2103, 2104, 1, GumpButtonType.Reply, 0);
                AddLabel(45, 90, 1152, "Non");
                AddButton(22, 93, 2103, 2104, 2, GumpButtonType.Reply, 0);
            }

            public override void OnResponse(NetState sender, RelayInfo info)
            {
                if (info.ButtonID == 0 || info.ButtonID == 2)
                {
                    m_From.CloseGump(typeof(DieuxChangeGump));
                    m_From.CloseGump(typeof(ReligionGump));
                    m_From.CloseGump(typeof(PriereGump));

                    m_From.SendGump(new ReligionGump(m_From, m_Dieux));
                }
                else if (info.ButtonID == 1)
                {
                    ResetValues(m_From, m_Dieux);
                    //DoPrayer(m_From, m_Dieux, m_Seconds, m_minPDP, m_maxPDP, m_mana);
                }
            }
        }
    }
}