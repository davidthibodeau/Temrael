using System; 
using System.Collections; 
using Server; 
using Server.Items; 
using Server.Mobiles; 
using Server.Network; 
using Server.Spells; 
using Server.Prompts;

namespace Server.Gumps
{
    public class DivineSpellBookEntry
    {
        private int m_ConnaissanceLevel;
        private string m_Nom;
        private int m_ImageID;
        private int m_Cercle;
        private NAptitude m_Connaissances;
        private int m_SpellID;

        public int ConnaissanceLevel { get { return m_ConnaissanceLevel; } }
        public string Nom { get { return m_Nom; } }
        public int ImageID { get { return m_ImageID; } }
        public int Cercle { get { return m_Cercle; } }
        public NAptitude Connaissance { get { return m_Connaissances; } }
        public int SpellID { get { return m_SpellID; } }
        public int Piete { get { return Spell.m_PieteTable[(int)Cercle - 1]; } }

        public DivineSpellBookEntry(int conn, NAptitude connaissance, string nom, int imageid, int cercle, int spellid)
        {
            m_ConnaissanceLevel = conn;
            m_Nom = nom;
            m_ImageID = imageid;
            m_Cercle = cercle;
            m_Connaissances = connaissance;
            m_SpellID = spellid;
        }
    }

    public class NewDivineSpellbookGump : Gump
    {
        public static DivineSpellBookEntry[] m_DivineSpellBookEntry = new DivineSpellBookEntry[]
        {
            new DivineSpellBookEntry( 1, NAptitude.Benedictions, "Repas Céleste", 0x8C1, 1, 2007),
            new DivineSpellBookEntry( 2, NAptitude.Benedictions, "Repos Céleste", 0x8C5, 2, 2008),
            new DivineSpellBookEntry( 3, NAptitude.Benedictions, "Panacée", 0x5CC, 3, 2005),
            new DivineSpellBookEntry( 4, NAptitude.Benedictions, "Guérison Céleste", 0x5101, 4, 2003),
            new DivineSpellBookEntry( 5, NAptitude.Benedictions, "Exaltation", 0x5105, 5, 2001),
            new DivineSpellBookEntry( 6, NAptitude.Benedictions, "Stase", 0x5AC, 6, 2010),
            new DivineSpellBookEntry( 7, NAptitude.Benedictions, "Véhémence", 0x5AB, 7, 2011),
            new DivineSpellBookEntry( 8, NAptitude.Benedictions, "Rétablissement", 0x5D1, 8, 2009),
            new DivineSpellBookEntry( 9, NAptitude.Benedictions, "Extase", 0x5102, 9, 2002),
            new DivineSpellBookEntry( 10, NAptitude.Benedictions, "Bénir", 0x5AA, 10, 2000),
            new DivineSpellBookEntry( 11, NAptitude.Benedictions, "Remède Divin", 0x5CB, 11, 2006),
            new DivineSpellBookEntry( 12, NAptitude.Benedictions, "Guérison Mirac.", 0x5D8, 12, 2004),

            new DivineSpellBookEntry( 1, NAptitude.Fanatisme, "Sacrifice", 0x5201, 1, 2021),
            new DivineSpellBookEntry( 2, NAptitude.Fanatisme, "Sauvegarde", 0x5205, 2, 2022),
            new DivineSpellBookEntry( 3, NAptitude.Fanatisme, "Ferveur Divine", 0x5208, 3, 2016),
            new DivineSpellBookEntry( 4, NAptitude.Fanatisme, "Bouclier Céleste", 0x5200, 4, 2014),
            new DivineSpellBookEntry( 5, NAptitude.Fanatisme, "Fortif. Divine", 0x5107, 5, 2017),
            new DivineSpellBookEntry( 6, NAptitude.Fanatisme, "Monture Céleste", 0x5D3, 6, 2019),
            new DivineSpellBookEntry( 7, NAptitude.Fanatisme, "Fougue Céleste", 0x5202, 7, 2018),
            new DivineSpellBookEntry( 8, NAptitude.Fanatisme, "Protection Cél.", 0x520B, 8, 2020),
            new DivineSpellBookEntry( 9, NAptitude.Fanatisme, "Bastion Céleste", 0x5203, 9, 2013),
            new DivineSpellBookEntry( 10, NAptitude.Fanatisme, "Zèle Divin", 0x5206, 10, 2023),
            new DivineSpellBookEntry( 11, NAptitude.Fanatisme, "Ardeur Céleste", 0x520C, 11, 2012),
            new DivineSpellBookEntry( 12, NAptitude.Fanatisme, "Défense Divine", 0x5204, 12, 2015),

            /*new DivineSpellBookEntry( 1, NAptitude.Monial, "Diligence", 0x5207, 1, 1000),
            new DivineSpellBookEntry( 2, NAptitude.Monial, "Spiritualité", 0x5D2, 2, 1000),
            new DivineSpellBookEntry( 3, NAptitude.Monial, "Croyance", 0x5BD, 3, 1000),
            new DivineSpellBookEntry( 4, NAptitude.Monial, "Foi", 0x5C0, 4, 1000),
            new DivineSpellBookEntry( 5, NAptitude.Monial, "Conviction", 0x5CD, 5, 1000),
            new DivineSpellBookEntry( 6, NAptitude.Monial, "Célérité", 0x5C7, 6, 1000),
            new DivineSpellBookEntry( 7, NAptitude.Monial, "Serment", 0x5C1, 7, 1000),
            new DivineSpellBookEntry( 8, NAptitude.Monial, "Consécration", 0x5C5, 8, 1000),
            new DivineSpellBookEntry( 9, NAptitude.Monial, "Obsécration", 0x5C8, 9, 1000),
            new DivineSpellBookEntry( 10, NAptitude.Monial, "Adoration", 0x5BB, 10, 1000),
            new DivineSpellBookEntry( 11, NAptitude.Monial, "Supplication", 0x5100, 11, 1000),
            new DivineSpellBookEntry( 12, NAptitude.Monial, "Transcendance", 0x5209, 12, 1000),

            new DivineSpellBookEntry( 1, NAptitude.Monial, "Guide", 0x5C9, 1, 1000),
            new DivineSpellBookEntry( 2, NAptitude.Monial, "Messe", 0x5B6, 2, 1000),
            new DivineSpellBookEntry( 3, NAptitude.Monial, "Confession", 0x5106, 3, 1000),
            new DivineSpellBookEntry( 4, NAptitude.Monial, "Feu Divin", 0x5DB, 4, 1000),
            new DivineSpellBookEntry( 5, NAptitude.Monial, "Aphonie", 0x5B7, 5, 1000),
            new DivineSpellBookEntry( 6, NAptitude.Monial, "Stagnation", 0x5AE, 6, 1000),
            new DivineSpellBookEntry( 7, NAptitude.Monial, "Bûché", 0x5BF, 7, 1000),
            new DivineSpellBookEntry( 8, NAptitude.Monial, "Gardien Céleste", 0x5B4, 8, 1000),
            new DivineSpellBookEntry( 9, NAptitude.Monial, "Persuasion", 0x5104, 9, 1000),
            new DivineSpellBookEntry( 10, NAptitude.Monial, "Interruption", 0x5103, 10, 1000),
            new DivineSpellBookEntry( 11, NAptitude.Monial, "Rite", 0x5108, 11, 1000),
            new DivineSpellBookEntry( 12, NAptitude.Monial, "Résurrection", 0x5100, 12, 1000),

            new DivineSpellBookEntry( 1, NAptitude.Monial, "Aveuglement", 0x5B5, 1, 1000),
            new DivineSpellBookEntry( 2, NAptitude.Monial, "Jalousie", 0x520A, 2, 1000),
            new DivineSpellBookEntry( 3, NAptitude.Monial, "Sang de Fer", 0x5B2, 3, 1000),
            new DivineSpellBookEntry( 4, NAptitude.Monial, "Jugement", 0x5AF, 4, 1000),
            new DivineSpellBookEntry( 5, NAptitude.Monial, "Voile", 0x5B3, 5, 1000),
            new DivineSpellBookEntry( 6, NAptitude.Monial, "Culte", 0x5100, 6, 1000),
            new DivineSpellBookEntry( 7, NAptitude.Monial, "Condamnation", 0x5B1, 7, 1000),
            new DivineSpellBookEntry( 8, NAptitude.Monial, "Arrogance", 0x5B0, 8, 1000),
            new DivineSpellBookEntry( 9, NAptitude.Monial, "Mépris", 0x5C4, 9, 1000),
            new DivineSpellBookEntry( 10, NAptitude.Monial, "Règne", 0x5109, 10, 1000),
            new DivineSpellBookEntry( 11, NAptitude.Monial, "Divination", 0x5C6, 11, 1000),
            new DivineSpellBookEntry( 12, NAptitude.Monial, "Shamanisme", 0x5AD, 12, 1000),

            new DivineSpellBookEntry( 2, NAptitude.Protection, "Poing de valeur", 0x15c, 2, 1001),
            new DivineSpellBookEntry( 3, NAptitude.Protection, "Essouflement", 0x520E, 3, 1002),
            new DivineSpellBookEntry( 4, NAptitude.Protection, "Lumière divine", 0x59E6, 4, 1003),
            new DivineSpellBookEntry( 5, NAptitude.Protection, "Imbroglio", 0x59E1, 5, 1005),
            new DivineSpellBookEntry( 6, NAptitude.Protection, "Griffes", 0x5212, 6, 1004),

            new DivineSpellBookEntry( 1, NAptitude.Benedictions, "Rétablissement", 0x5320, 1, 1006),
            new DivineSpellBookEntry( 2, NAptitude.Benedictions, "Régénération", 0x15f, 2, 1007),
            new DivineSpellBookEntry( 3, NAptitude.Benedictions, "Bouclier", 0x11b, 4, 1008),
            new DivineSpellBookEntry( 4, NAptitude.Benedictions, "Amulette", 0x14b, 5, 1009),
            new DivineSpellBookEntry( 5, NAptitude.Benedictions, "Réfecteur", 0x145, 7, 1010),
            new DivineSpellBookEntry( 6, NAptitude.Benedictions, "Miracle", 0x13b, 8, 1011),

            new DivineSpellBookEntry( 1, NAptitude.Benedictions, "Répartition", 0x520F, 1, 1012),
            new DivineSpellBookEntry( 2, NAptitude.Benedictions, "Renouvellement", 0x139, 3, 1013),
            new DivineSpellBookEntry( 3, NAptitude.Benedictions, "Purification", 0x15f, 4, 1014),
            new DivineSpellBookEntry( 4, NAptitude.Benedictions, "Promptitude", 0x5321, 6, 1015),
            new DivineSpellBookEntry( 5, NAptitude.Benedictions, "Passion", 0x15b, 7, 1016),
            new DivineSpellBookEntry( 6, NAptitude.Benedictions, "Régénérescence", 0x160, 8, 1017),

            new DivineSpellBookEntry( 1, NAptitude.Fanatisme, "Haute précision", 0x5216, 1, 1018),
            new DivineSpellBookEntry( 2, NAptitude.Fanatisme, "Agglomération", 0x119, 2, 1019),
            new DivineSpellBookEntry( 3, NAptitude.Fanatisme, "Rudesse", 0x59D9, 4, 1020),
            new DivineSpellBookEntry( 4, NAptitude.Fanatisme, "Consécration", 0x5107, 5, 1021),
            new DivineSpellBookEntry( 5, NAptitude.Fanatisme, "Confession", 0x5208, 6, 1022),
            new DivineSpellBookEntry( 6, NAptitude.Fanatisme, "Force de la foi", 0x59DB, 7, 1023),

            new DivineSpellBookEntry( 1, NAptitude.Monial, "Famine", 0x125, 2, 1024),
            new DivineSpellBookEntry( 2, NAptitude.Monial, "Errance", 0x124, 3, 1025),
            new DivineSpellBookEntry( 3, NAptitude.Monial, "Bêtes", 0x11e, 4, 1026),
            new DivineSpellBookEntry( 4, NAptitude.Monial, "Hypnose", 0x158, 5, 1027),
            new DivineSpellBookEntry( 5, NAptitude.Monial, "Fétichisme", 0x5325, 7, 1028),
            new DivineSpellBookEntry( 6, NAptitude.Monial, "Voodoo", 0x80B, 8, 1029),

            new DivineSpellBookEntry( 1, NAptitude.Monial, "Pied ancré", 0x5324, 1, 1030),
            new DivineSpellBookEntry( 2, NAptitude.Monial, "Robustesse", 0x142, 2, 1031),
            new DivineSpellBookEntry( 3, NAptitude.Monial, "Souplesse", 0x5420, 4, 1032),
            new DivineSpellBookEntry( 4, NAptitude.Monial, "Corps pur", 0x11d, 5, 1033),
            new DivineSpellBookEntry( 5, NAptitude.Monial, "Éternelle jeunesse", 0x5426, 7, 1034),
            new DivineSpellBookEntry( 6, NAptitude.Monial, "Prouesse", 0x15d, 8, 1035),

            new DivineSpellBookEntry( 1, NAptitude.Monial, "Conscience", 0x131, 1, 1036),
            new DivineSpellBookEntry( 2, NAptitude.Monial, "Appel de la nature", 0x144, 2, 1037),
            new DivineSpellBookEntry( 3, NAptitude.Monial, "Animaux", 0x14c, 4, 1038),
            new DivineSpellBookEntry( 4, NAptitude.Monial, "Instinct charnel", 0x59DE, 5, 1039),
            new DivineSpellBookEntry( 5, NAptitude.Monial, "Domination", 0x59D8, 7, 1041),
            new DivineSpellBookEntry( 6, NAptitude.Monial, "Transfert", 0x14d, 8, 1040),

            new DivineSpellBookEntry( 1, NAptitude.Monial, "Plume", 0x5203, 2, 1042),
            new DivineSpellBookEntry( 2, NAptitude.Monial, "Intrinsèque", 0x159, 3, 1043),
            new DivineSpellBookEntry( 3, NAptitude.Monial, "Voile", 0x13c, 4, 1044),
            new DivineSpellBookEntry( 4, NAptitude.Monial, "Écho", 0x5425, 5, 1045),
            new DivineSpellBookEntry( 5, NAptitude.Monial, "Stupéfaction", 0x162, 7, 1046),
            new DivineSpellBookEntry( 6, NAptitude.Monial, "Déchéance", 0x152, 8, 1047),

            new DivineSpellBookEntry( 1, NAptitude.Monial, "Aura de fatigue", 0x5108, 2, 1048),
            new DivineSpellBookEntry( 2, NAptitude.Monial, "Mortification", 0x5200, 3, 1049),
            new DivineSpellBookEntry( 3, NAptitude.Monial, "Exécration", 0x5103, 4, 1050),
            new DivineSpellBookEntry( 4, NAptitude.Monial, "Halène putride", 0x157, 5, 1051),
            new DivineSpellBookEntry( 5, NAptitude.Monial, "Horreur", 0x59DD, 7, 1052),
            new DivineSpellBookEntry( 6, NAptitude.Monial, "Pourrissement", 0x5100, 8, 1053),

            new DivineSpellBookEntry( 1, NAptitude.Fanatisme, "Courage", 0x5211, 2, 1054),
            new DivineSpellBookEntry( 2, NAptitude.Fanatisme, "Sagesse", 0x59E2, 3, 1055),
            new DivineSpellBookEntry( 3, NAptitude.Fanatisme, "Berseck", 0x5109, 4, 1056),
            new DivineSpellBookEntry( 4, NAptitude.Fanatisme, "Transcendance", 0x5105, 5, 1057),
            new DivineSpellBookEntry( 5, NAptitude.Fanatisme, "Spiritualité", 0x5104, 7, 1058),
            new DivineSpellBookEntry( 6, NAptitude.Fanatisme, "Soif du combat", 0x5201, 8, 1059),

            new DivineSpellBookEntry( 1, NAptitude.Monial, "Sauvegarde", 0x5207, 2, 1060),
            new DivineSpellBookEntry( 2, NAptitude.Monial, "Exaltation", 0x155, 3, 1061),
            new DivineSpellBookEntry( 3, NAptitude.Monial, "Labyrinthe", 0x149, 4, 1062),
            new DivineSpellBookEntry( 4, NAptitude.Monial, "Vision réelle", 0x166, 5, 1063),
            new DivineSpellBookEntry( 5, NAptitude.Monial, "Appui", 0x14f, 7, 1064),
            new DivineSpellBookEntry( 6, NAptitude.Monial, "Patronage", 0x121, 8, 1065),

            new DivineSpellBookEntry( 1, NAptitude.Protection, "Talisman", 0x163, 2, 1066),
            new DivineSpellBookEntry( 2, NAptitude.Protection, "Baril de bière", 0x13a, 3, 1067),
            new DivineSpellBookEntry( 3, NAptitude.Protection, "Point de paresse", 0x136, 4, 1068),
            new DivineSpellBookEntry( 4, NAptitude.Protection, "Soutien", 0x140, 5, 1069),
            new DivineSpellBookEntry( 5, NAptitude.Protection, "Don des rochers", 0x120, 7, 1070),
            new DivineSpellBookEntry( 6, NAptitude.Protection, "Couverture", 0x5106, 8, 1071),*/
        };

        public bool HasSpell(Mobile from, int spellID)
        {
            return (m_Book.HasSpell(spellID));
        }
        
        #region tableaux
        //Liste des magies du spellbook et leur couleur
        public NAptitude[] m_DivineConnaissanceList = new NAptitude[] {
            NAptitude.Protection,  
            NAptitude.Benedictions,    
            NAptitude.Benedictions,   
            NAptitude.Fanatisme,    
            NAptitude.Monial,   
            NAptitude.Monial,     
            NAptitude.Monial,   
            NAptitude.Monial,    
            NAptitude.Monial,    
            NAptitude.Fanatisme,    
            NAptitude.Monial,      
            NAptitude.Protection     
        };
        
        public Hashtable m_DivineNameColors = new Hashtable();
        public Hashtable m_DivineNames = new Hashtable();

        public void InitializeHashtable()
        {
            m_DivineNameColors[NAptitude.Protection] = 498;
            m_DivineNameColors[NAptitude.Benedictions] = 320;
            m_DivineNameColors[NAptitude.Benedictions] = 260;
            m_DivineNameColors[NAptitude.Fanatisme] = 140;
            m_DivineNameColors[NAptitude.Monial] = 340;
            m_DivineNameColors[NAptitude.Monial] = 995;
            m_DivineNameColors[NAptitude.Monial] = 44;
            m_DivineNameColors[NAptitude.Monial] = 1050;
            m_DivineNameColors[NAptitude.Monial] = 1450;
            m_DivineNameColors[NAptitude.Fanatisme] = 1521;
            m_DivineNameColors[NAptitude.Monial] = 2052;
            m_DivineNameColors[NAptitude.Protection] = 1249;

            //m_DivineNames[NAptitude.Protection] = "Protection";
            m_DivineNames[NAptitude.Benedictions] = "Bénédictions";
            m_DivineNames[NAptitude.Fanatisme] = "Fanatisme";
            m_DivineNames[NAptitude.Monial] = "Vénération";
            m_DivineNames[NAptitude.Monial] = "Monial";
        }
        #endregion

        private NewDivineSpellbook m_Book;

        public NewDivineSpellbookGump(Mobile from, NewDivineSpellbook book)
            : base(150, 200)
        {
            InitializeHashtable();

            m_Book = book;
            int vindex = 0;
            int totpage = 0;
            int hindex = 0;

            if (!(from is TMobile))
                return;

            TMobile m = (TMobile)from;

            AddPage(0);
            AddImage(100, 10, 2201);

            int oldconnaissance = -1;
            int newconnaissance = -1;

            int value = 0;
            int addition = 0;

            //Pour tous les sorts
            for (int i = 0; i < m_DivineSpellBookEntry.Length; i++)
            {
                DivineSpellBookEntry info = (DivineSpellBookEntry)m_DivineSpellBookEntry[i];
                //on assigne la nouvelle connaissance
                newconnaissance = (int)info.Connaissance;

                if (newconnaissance == oldconnaissance)
                    addition += 1;
                else
                    addition = 0;

                //on fait la comparaison des connaissances pour savoir si on a changé de connaissance
                if ((newconnaissance != -1 && newconnaissance != oldconnaissance) || (addition == 6) || (addition == 12) || (addition == 18) || (addition == 24))
                {
                    value++;

                    if (value % 2 == 1)
                    {
                        totpage++;
                        AddPage(totpage);
                        hindex = 0;
                    }
                    else
                        hindex = 1;

                    //On ajoute le nom de la connaissance
                    //AddLabel(160 + hindex * 145, 25, (int)m_DivineNameColors[info.Connaissance], (string)m_DivineNames[info.Connaissance]);
                    AddHtml(160 + hindex * 145, 32, 200, 20, "<h3><basefont color=#025a>" + (string)m_DivineNames[info.Connaissance] + "<basefont></h3>", false, false);

                    // Séparateurs
                    AddImageTiled(130 + hindex * 165, 40, 130, 10, 0x3A);

                    //On remet à 0 pour la nouvelle page
                    vindex = 0;

                    //On ajoute les boutons de changement de page
                    AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, totpage + 1);
                    AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, totpage - 1);
                }

                //Si le livre possède le sort
                if (this.HasSpell(from, info.SpellID) && ArrayContains(m_DivineConnaissanceList, info.Connaissance))
                {
                    int buttonID = 2224;

                    if (m.QuickSpells.Contains(info.SpellID))
                        buttonID = 2223;

                    //On ajoute l'information et les boutons
                    //AddLabel(162 + hindex * 160, 54 + (vindex * 17), 0, info.Nom);
                    AddHtml(162 + hindex * 160, 54 + (vindex * 17), 200, 20, "<h3><basefont color=#5A4A31>" + info.Nom + "<basefont></h3>", false, false);

                    AddButton(127 + hindex * 160, 59 + (vindex * 17), 2103, 2104, info.SpellID, GumpButtonType.Reply, 0);
                    AddButton(140 + hindex * 160, 58 + (vindex * 17), buttonID, buttonID, info.SpellID - 1000, GumpButtonType.Reply, 0);
                    vindex++;
                }

                oldconnaissance = (int)info.Connaissance;
             }

            value = 0;

            try
            {
                //Pour tous les sorts
                for (int i = 0; i < m_DivineSpellBookEntry.Length; i++)
                {
                    DivineSpellBookEntry info = (DivineSpellBookEntry)m_DivineSpellBookEntry[i];
                    //Si le livre possède le sort
                    if (this.HasSpell(from, info.SpellID) && ArrayContains(m_DivineConnaissanceList, info.Connaissance))
                    {
                        //Si le # du sort est pair...
                        if (value % 2 == 0)
                        {
                            //On fait une page
                            totpage++;
                            AddPage(totpage);
                            hindex = 0;

                            //On ajoute les boutons de pages
                            AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, totpage - 1);
                            AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, totpage + 1);
                        }
                        else
                            hindex = 1;

                        //int namecolor = 0;
                        string name = "...";

                        //if (m_DivineNameColors.Contains(info.Connaissance))
                        //    namecolor = (int)m_DivineNameColors[info.Connaissance];

                        if (m_DivineNames.Contains(info.Connaissance))
                            name = (string)m_DivineNames[info.Connaissance];

                        //On ajoute le nom
                        //AddLabel(130 + hindex * 165, 45, namecolor, info.Nom);
                        AddHtml(158 + hindex * 145, 32, 200, 20, "<h3><basefont color=#025a>" + info.Nom + "<basefont></h3>", false, false);

                        //On ajoute les séparateurs
                        AddImageTiled(130 + hindex * 165, 40, 130, 10, 0x3A);

                        //On ajoute l'icone en tant que bouton pour lancer le sort
                        AddButton(140 + hindex * 165, 75, info.ImageID, info.ImageID, info.SpellID, GumpButtonType.Reply, 0);
                        //AddLabel(190 + hindex * 165, 78, namecolor, "Cercle : " + info.Cercle.ToString());
                        AddHtml(190 + hindex * 165, 63, 200, 20, "<h3><basefont color=#5A4A31>Cercle: " + info.Cercle.ToString() + "<basefont></h3>", false, false);

                        int buttonID = 2224;

                        if (m.QuickSpells.Contains(info.SpellID))
                            buttonID = 2223;

                        //On ajoute les boutons pour le lancement rapide
                        //AddLabel(210 + hindex * 165, 98, 0, "Rapide");
                        AddHtml(210 + hindex * 165, 83, 200, 20, "<h3><basefont color=#5A4A31>Rapide<basefont></h3>", false, false);
                        AddButton(190 + hindex * 165, 84, buttonID, buttonID, info.SpellID - 1000, GumpButtonType.Reply, 0);

                        //On ajoute les infos diverses
                        //AddLabel(130 + hindex * 165, 120, 0, "Pdp : " + info.Pdp);
                        AddHtml(130 + hindex * 165, 120, 200, 20, "<h3><basefont color=#5A4A31>Piété : " + info.Piete + "<basefont></h3>", false, false);

                        //AddLabel(130 + hindex * 165, 138, namecolor, name + " " + info.ConnaissanceLevel);

                        AddHtml(130 + hindex * 165, 175, 200, 20, "<h3><basefont color=#025a>Aptitude<basefont></h3>", false, false);
                        AddHtml(130 + hindex * 165, 192, 200, 20, "<h3><basefont color=#5A4A31>" + name + " " + info.ConnaissanceLevel + "<basefont></h3>", false, false);

                        //On augmente le nombre de sort de 1 pour le prochain sort.
                        value++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

            totpage++;
            AddPage(totpage);
            AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, totpage - 1);
        }

        public bool ArrayContains(NAptitude[] conn, NAptitude wanted)
        {
            for (int i = 0; i < conn.Length; i++)
            {
                if (wanted == (NAptitude)conn[i])
                    return true;
            }

            return false;
        }

        public static DivineSpellBookEntry FindEntryBySpellID(int spellID)
        {

            for (int i = 0; i < m_DivineSpellBookEntry.Length; i++)
            {
                DivineSpellBookEntry info = (DivineSpellBookEntry)m_DivineSpellBookEntry[i];

                if (info.SpellID == spellID)
                    return info;
            }

            return null;
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            if (from is TMobile)
            {
                TMobile m = (TMobile)from;

                if (info.ButtonID >= 2000 && info.ButtonID < 2100)
                {
                    Console.WriteLine("Spell ID : " + info.ButtonID);
                    Spell spell = SpellRegistry.NewSpell(info.ButtonID, m, null);

                    if (spell != null)
                        spell.Cast();

                    m.SendGump(new NewDivineSpellbookGump(m, m_Book));
                }
                else if (info.ButtonID >= 1000 && info.ButtonID < 1100)
                {
                    if (m.QuickSpells == null)
                        return;

                    if (m.QuickSpells.Contains((int)(info.ButtonID + 1000)))
                    {
                        m.SendMessage("Le sort a été retiré de votre liste de lancement rapide.");
                        m.QuickSpells.Remove((int)(info.ButtonID + 1000));
                    }
                    else
                    {
                        m.SendMessage("Le sort a été ajouté à votre liste de lancement rapide.");
                        m.QuickSpells.Add((int)(info.ButtonID + 1000));
                    }

                    m.SendGump(new NewDivineSpellbookGump(m, m_Book));
                }
            }
        }
    }
}