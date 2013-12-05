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
    public enum BardType
    {
        None = 0,
        Composition = 1,
        Compo = 2
    }
    
    public class BardSpellBookEntry
    {
        private string m_Nom;
        private int m_ImageID;
        private NAptitude m_Connaissances;
        private int m_SpellID;
        private BardType m_BardType;
        private int m_ManaReq;
        private int m_AptitudeLevel;

        public string Nom { get { return m_Nom; } }
        public int ImageID { get { return m_ImageID; } }
        public NAptitude Connaissance { get { return m_Connaissances; } }
        public int SpellID { get { return m_SpellID; } }
        public BardType BardType { get { return m_BardType; } }
        public int ManaReq { get { return m_ManaReq; } }
        public int AptitudeLevel { get { return m_AptitudeLevel; } }

        public BardSpellBookEntry(BardType bard, NAptitude connaissance, string nom, int imageid, int spellid, int manaReq, int aptitudeLevel)
        {
            m_BardType = bard;
            m_Nom = nom;
            m_ImageID = imageid;
            m_Connaissances = connaissance;
            m_SpellID = spellid;
            m_ManaReq = manaReq;
            m_AptitudeLevel = aptitudeLevel;
        }
    }

    public class NewBardSpellbookGump : Gump
    {
        public static BardSpellBookEntry[] m_BardSpellBookEntry = new BardSpellBookEntry[]
        {
            new BardSpellBookEntry( BardType.Composition, NAptitude.Composition, "Bruit", 0x5CE,  1600, 10, 1),
            new BardSpellBookEntry( BardType.Composition, NAptitude.Composition, "Son", 0x5CF, 1601, 10, 2),
            new BardSpellBookEntry( BardType.Composition, NAptitude.Composition, "Murmure", 0x5D0,  1602, 15, 3),
            new BardSpellBookEntry( BardType.Composition, NAptitude.Composition, "Sona", 0x5D6,  1603, 15, 4),
            new BardSpellBookEntry( BardType.Composition, NAptitude.Composition, "Hymne", 0x5D5, 1604, 20, 5),
            new BardSpellBookEntry( BardType.Composition, NAptitude.Composition, "Chant", 0x5B2,  1606, 20, 6),

            new BardSpellBookEntry( BardType.Compo, NAptitude.Composition, "Sonette", 0x5B0,  1607, 25, 7),
            new BardSpellBookEntry( BardType.Compo, NAptitude.Composition, "Fanfare", 0x5AE,  1608, 25, 8),
            new BardSpellBookEntry( BardType.Compo, NAptitude.Composition, "Poème", 0x5AF,  1610, 30, 9),
            new BardSpellBookEntry( BardType.Compo, NAptitude.Composition, "Symphonie", 0x5B1,  1611, 30, 10),
            new BardSpellBookEntry( BardType.Compo, NAptitude.Composition, "Harmonie", 0x5B3,  1612, 40, 11),
            new BardSpellBookEntry( BardType.Compo, NAptitude.Composition, "Sérénade", 0x5D8,  1613, 50, 12)
        };

        public bool HasSpell(Mobile from, int spellID)
        {
            if (m_Book != null)
                return (m_Book.HasSpell(spellID));
            else
                return true;
        }

        public Hashtable m_BardNameColors = new Hashtable();
        public Hashtable m_BardNames = new Hashtable();

        public void InitializeHashtable()
        {
            //m_BardNameColors[BardType.Barde] = 99;
            //m_BardNameColors[BardType.Danseur] = 79;

            m_BardNames[BardType.Composition] = "Composition";
            m_BardNames[BardType.Compo] = "Composition";
        }

        private NewBardSpellbook m_Book;
        private BaseInstrument m_Instrument;

        public NewBardSpellbookGump(Mobile from, BaseInstrument instrument)
            : base(150, 200)
        {
            InitializeHashtable();

            m_Instrument = instrument;
            int vindex = 0;
            int totpage = 0;
            int hindex = 0;

            if (from == null || !(from is TMobile))
                return;

            TMobile m = (TMobile)from;

            AddPage(0);
            AddImage(100, 10, 2201);

            int oldtype = -1;
            int newtype = -1;

            int value = 0;

            //Pour tous les sorts
            for (int i = 0; i < m_BardSpellBookEntry.Length; i++)
            {
                BardSpellBookEntry info = (BardSpellBookEntry)m_BardSpellBookEntry[i];
                //on assigne la nouvelle connaissance
                newtype = (int)info.BardType;

                //on change de page au 8eme sort.
                if (newtype != -1 && newtype != oldtype)
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

                    //On ajoute le nom du barde
                    //AddLabel(160 + hindex * 145, 25, (int)m_BardNameColors[info.BardType], (string)m_BardNames[info.BardType]);
                    AddHtml(160 + hindex * 145, 32, 200, 20, "<h3><basefont color=#025a>" + (string)m_BardNames[info.BardType] + "<basefont></h3>", false, false);

                    // Séparateurs
                    AddImageTiled(130 + hindex * 165, 40, 130, 10, 0x3A);

                    //On remet à 0 pour la nouvelle page
                    vindex = 0;

                    //On ajoute les boutons de changement de page
                    AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, totpage + 1);
                    AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, totpage - 1);
                }

                //Si le livre possède le sort
                if (this.HasSpell(from, info.SpellID))
                {
                    int buttonID = 2224;

                    if (m.QuickSpells.Contains(info.SpellID))
                        buttonID = 2223;

                    //On ajoute l'information et les boutons
                    //AddLabel(162 + hindex * 160, 54 + (vindex * 17), 0, info.Nom);
                    AddHtml(162 + hindex * 160, 54 + (vindex * 17), 200, 20, "<h3><basefont color=#5A4A31>" + info.Nom + "<basefont></h3>", false, false);

                    AddButton(127 + hindex * 160, 59 + (vindex * 17), 2103, 2104, info.SpellID, GumpButtonType.Reply, 0);
                    AddButton(140 + hindex * 160, 58 + (vindex * 17), buttonID, buttonID, info.SpellID + 200, GumpButtonType.Reply, 0);
                    vindex++;
                }

                oldtype = (int)info.BardType;
            }

            value = 0;

            try
            {
                //Pour tous les sorts
                for (int i = 0; i < m_BardSpellBookEntry.Length; i++)
                {
                    BardSpellBookEntry info = (BardSpellBookEntry)m_BardSpellBookEntry[i];
                    //Si le livre possède le sort
                    if (this.HasSpell(from, info.SpellID))
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

                        //if (m_BardNameColors.Contains(info.BardType))
                        //    namecolor = (int)m_BardNameColors[info.BardType];

                        if (m_BardNames.Contains(info.BardType))
                            name = (string)m_BardNames[info.BardType];

                        //On ajoute le nom
                        //AddLabel(130 + hindex * 165, 45, namecolor, info.Nom);
                        AddHtml(158 + hindex * 145, 32, 200, 20, "<h3><basefont color=#025a>" + info.Nom + "<basefont></h3>", false, false);

                        //On ajoute les séparateurs
                        //AddImageTiled(130 + hindex * 165, 60, 130, 10, 0x3A);
                        AddImageTiled(130 + hindex * 165, 40, 130, 10, 0x3A);

                        AddHtml(135 + hindex * 165, 105, 200, 20, "<h3><basefont color=#5A4A31>Mana Requise: " + info.ManaReq.ToString() + "<basefont></h3>", false, false);

                        //On ajoute l'icone en tant que bouton pour lancer le sort
                        //AddButton(160 + hindex * 165, 75, info.ImageID, info.ImageID, info.SpellID, GumpButtonType.Reply, 0);
                        AddButton(140 + hindex * 165, 60, info.ImageID, info.ImageID, info.SpellID, GumpButtonType.Reply, 0);

                        int buttonID = 2224;

                        if (m.QuickSpells.Contains(info.SpellID))
                            buttonID = 2223;

                        //On ajoute les boutons pour le lancement rapide
                        //AddLabel(170 + hindex * 165, 118, 0, "Rapide");
                        //AddButton(150 + hindex * 165, 121, buttonID, buttonID, info.SpellID + 200, GumpButtonType.Reply, 0);
                        AddHtml(210 + hindex * 165, 83, 200, 20, "<h3><basefont color=#5A4A31>Rapide<basefont></h3>", false, false);
                        AddButton(190 + hindex * 165, 84, buttonID, buttonID, info.SpellID + 200, GumpButtonType.Reply, 0);

                        AddHtml(130 + hindex * 165, 175, 200, 20, "<h3><basefont color=#025a>Aptitude<basefont></h3>", false, false);
                        AddHtml(130 + hindex * 165, 192, 200, 20, "<h3><basefont color=#5A4A31>" + name + " " + info.AptitudeLevel + "<basefont></h3>", false, false);

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

        public NewBardSpellbookGump(Mobile from, NewBardSpellbook book)
            : base(150, 200)
        {
            InitializeHashtable();

            m_Book = book;
            int vindex = 0;
            int totpage = 0;
            int hindex = 0;

            if (from == null || !(from is TMobile))
                return;

            TMobile m = (TMobile)from;

            AddPage(0);
            AddImage(100, 10, 2201);

            int oldtype = -1;
            int newtype = -1;

            int value = 0;

            //Pour tous les sorts
            for (int i = 0; i < m_BardSpellBookEntry.Length; i++)
            {
                BardSpellBookEntry info = (BardSpellBookEntry)m_BardSpellBookEntry[i];
                //on assigne la nouvelle connaissance
                newtype = (int)info.BardType;

                //on change de page au 8eme sort.
                if (newtype != -1 && newtype != oldtype)
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

                    //On ajoute le nom du barde
                    AddLabel(160 + hindex * 145, 25, (int)m_BardNameColors[info.BardType], (string)m_BardNames[info.BardType]);

                    // Séparateurs
                    AddImageTiled(130 + hindex * 165, 40, 130, 10, 0x3A);

                    //On remet à 0 pour la nouvelle page
                    vindex = 0;

                    //On ajoute les boutons de changement de page
                    AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, totpage + 1);
                    AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, totpage - 1);
                }

                //Si le livre possède le sort
                if (this.HasSpell(from, info.SpellID))
                {
                    int buttonID = 2224;

                    if (m.QuickSpells.Contains(info.SpellID))
                        buttonID = 2223;

                    //On ajoute l'information et les boutons
                    AddLabel(162 + hindex * 160, 54 + (vindex * 17), 0, info.Nom);
                    AddButton(127 + hindex * 160, 59 + (vindex * 17), 2103, 2104, info.SpellID, GumpButtonType.Reply, 0);
                    AddButton(140 + hindex * 160, 58 + (vindex * 17), buttonID, buttonID, info.SpellID + 200, GumpButtonType.Reply, 0);
                    vindex++;
                }

                oldtype = (int)info.BardType;
            }

            value = 0;
            
            try
            {
                //Pour tous les sorts
                for (int i = 0; i < m_BardSpellBookEntry.Length; i++)
                {
                    BardSpellBookEntry info = (BardSpellBookEntry)m_BardSpellBookEntry[i];
                    //Si le livre possède le sort
                    if (this.HasSpell(from, info.SpellID))
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

                        int namecolor = 0;
                        string name = "...";

                        if (m_BardNameColors.Contains(info.BardType))
                            namecolor = (int)m_BardNameColors[info.BardType];

                        if (m_BardNames.Contains(info.BardType))
                            name = (string)m_BardNames[info.BardType];

                        //On ajoute le nom
                        AddLabel(130 + hindex * 165, 45, namecolor, info.Nom);

                        //On ajoute les séparateurs
                        AddImageTiled(130 + hindex * 165, 60, 130, 10, 0x3A);

                        //On ajoute l'icone en tant que bouton pour lancer le sort
                        AddButton(160 + hindex * 165, 75, info.ImageID, info.ImageID, info.SpellID, GumpButtonType.Reply, 0);
                      
                        int buttonID = 2224;

                        if (m.QuickSpells.Contains(info.SpellID))
                            buttonID = 2223;

                        //On ajoute les boutons pour le lancement rapide
                        AddLabel(170 + hindex * 165, 118, 0, "Rapide");
                        AddButton(150 + hindex * 165, 121, buttonID, buttonID, info.SpellID + 200, GumpButtonType.Reply, 0);

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

        public static BardSpellBookEntry FindEntryBySpellID(int spellID)
        {
            for (int i = 0; i < m_BardSpellBookEntry.Length; i++)
            {
                BardSpellBookEntry info = (BardSpellBookEntry)m_BardSpellBookEntry[i];

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

                if (info.ButtonID >= 1600 && info.ButtonID < 1800)
                {
                    Spell spell = SpellRegistry.NewSpell(info.ButtonID, m, null);

                    if (spell != null)
                        spell.Cast();

                    if (m_Book != null)
                        m.SendGump(new NewBardSpellbookGump(m, m_Book));
                    else
                        m.SendGump(new NewBardSpellbookGump(m, m_Instrument));
                }
                else if (info.ButtonID >= 1800 && info.ButtonID < 2000)
                {
                    if (m.QuickSpells == null)
                        return;

                    if (m.QuickSpells.Contains((int)(info.ButtonID - 200)))
                    {
                        m.SendMessage("Le sort fut retiré de votre liste de sorts rapides.");
                        m.QuickSpells.Remove((int)(info.ButtonID - 200));
                    }
                    else
                    {
                        m.SendMessage("Le sort fut ajouté de votre liste de sorts rapides.");
                        m.QuickSpells.Add((int)(info.ButtonID - 200));
                    }

                    if (m_Book != null)
                        m.SendGump(new NewBardSpellbookGump(m, m_Book));
                    else
                        m.SendGump(new NewBardSpellbookGump(m, m_Instrument));
                }
            }
        }
    }
}