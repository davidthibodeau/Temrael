using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Mobiles;

namespace Server.Gumps
{
    public abstract class GumpTemrael : Gump
    {
        public static int ColorTitre = 2123;
        public static int ColorText  = 2100;
        public static int ColorTextGreen = 2210;
        public static int ColorTextLight = 2122;
        public static int ColorTextGray = 2403;
        public static int ColorTextYellow = 2212;
        public static int ColorTextRed = 2117;

        public static string ColorHtmlTitre = "#025a";
        public static string ColorHtmlText = "#241b0d";
        public static string ColorHtmlRed = "#990000";
        public static string ColorHtmlGreen = "#009900";
        public static string ColorHtmlBlue = "#336699";
        public static string ColorHtmlYellow = "#FFCC66";
        public static string ColorHtmlGray = "#999999";

        public static int DefaultHtmlLength = 200;

        public static int RealXBase = 50;
        public static int RealYBase = 50;

        private int m_Largeur;
        private int m_Hauteur;
        private int m_Colonne;

        public int Colone { get { return m_Colonne - 10; } }
        public bool AsColonne { get { return m_Colonne > 50; } }
        public int Largeur { get { return m_Largeur - 10; } }
        public int Hauteur { get { return m_Hauteur - 17; } }
        public static int XBase {get{return RealXBase+50;}}
        public static int YBase { get { return RealYBase+60; } }
        public int XCol { get { return XBase + m_Colonne + 5; } }

        public int LargeurColonne1 { get { return m_Colonne-15; } }
        public int LargeurColonne2 { get { return (Largeur - m_Colonne) - 15; } }

        
        public GumpTemrael(string titre, int largeur, int hauteur)
            : this(titre, largeur, hauteur, 0, false)
        {

        }
        public GumpTemrael(string titre, int largeur, int hauteur, int colonne)
            : this(titre, largeur, hauteur, colonne, false)
        {

        }
        public GumpTemrael(string titre, int largeur, int hauteur, bool craft)
            : this(titre, largeur, hauteur, 0, craft)
        {

        }
        public GumpTemrael(string titre, int largeur, int hauteur, int colonne, bool craft)
            : base(RealXBase, RealYBase)
        {
            m_Largeur = largeur;
            m_Hauteur = hauteur;
            m_Colonne = colonne;

            int _x = RealXBase;
            int _y = RealYBase;

            int col = _x+m_Colonne;

            if (craft)
            {
                AddBackground(_x + 30, _y + 43, m_Largeur, m_Hauteur + 12, 3500);
            }
            else
            {
                AddBackground(_x, _y, m_Largeur + 80, m_Hauteur + 80, 3600);
                AddBackground(_x + 10, _y + 10, m_Largeur + 60, m_Hauteur + 60, 9200);
                AddBackground(_x + 20, _y + 20, m_Largeur + 40, m_Hauteur + 40, 3500);
                AddBackground(_x + 40, _y + 40, m_Largeur, m_Hauteur, 9300);

                //Dragons
                if (hauteur > 250)
                {
                    AddImage(_x - 40, _y - 20, 10440);
                    AddImage(m_Largeur + 88, _y - 20, 10441);
                }

                //Titre
                if (largeur > 180)
                {
                    AddTitre(_x + 40, _y +45, largeur, titre);
                }
            }

            /* Nubia Gump
             * 
             * AddBackground(_x, _y, m_Largeur, 48, 0x2454); //Parchemin

            AddBackground(_x, _y + 50,  m_Largeur, m_Hauteur, 0x1400); //Fond Pierre

            AddImageTiled(_x, _y, m_Largeur, 18, 0x280A); //Bande 2
            AddImageTiled(_x, _y + 35, m_Largeur, 18, 0x280A); //Bande 1



            if (AsColonne)
            {
                AddAlphaRegion(_x + 5, _y + 56,
                    m_Colonne - 5,  m_Hauteur -10);
                AddAlphaRegion(m_Colonne + _x +5 , _y + 56,
                    (m_Largeur - m_Colonne)-10 , m_Hauteur-10);
            }
            else
                AddAlphaRegion(_x+5, _y + 56,
                   m_Largeur - 10, m_Hauteur - 10);

            AddImage(0, _y-10, 0x28a0); //Dragon
            if( Hauteur >= 250 )
                AddImage(0, _y +150, 0x28a1); //Dragon
            if (Hauteur >= 350)
                AddImage(0, _y +320, 0x28a2); //Dragon
            AddImage(m_Largeur + 18, 46, 0x1582); //Sigle UO

            AddLabel(_x + 30, _y+17, ColorTitre, titre);*/

        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile f = sender.Mobile;
            TMobile from = f as TMobile;
           
        }

        public void AddValidButton(int x, int y, int id, bool green, string text)
        {
            if (green)
                AddButton(x, y, 0x2343, 0x2343, id, GumpButtonType.Reply, 0);
            else
                AddButton(x, y, 0x2342, 0x2342, id, GumpButtonType.Reply, 0);
            AddHtmlTexteColored(x + 20, y - 3, DefaultHtmlLength, text, green ? ColorHtmlText : ColorHtmlGray);
            //AddLabel(x + 20, y-3, (green ? ColorTextLight : ColorTextGray), text);
        }
        public static int[] ButtonID = new int[] { 0x4b9, 0x4ba };
        public void AddButtonTrueFalse(int x, int y, int id, bool select, string text)
        {
            if (select)
                AddImage(x, y, ButtonID[1], 2118);
            else
                AddButton(x, y, ButtonID[0], ButtonID[1], id, GumpButtonType.Reply, 0);
            AddHtmlTexteColored(x + 20, y - 3, DefaultHtmlLength, text, select ? ColorHtmlText : ColorHtmlGray);
            //AddLabel(x + 20, y - 3, (select ? ColorTextLight : ColorTextGray), text);
        }
        public void AddSimpleButton(int x, int y, int id, string text)
        {
            AddSimpleButton(x, y, id, text, ColorHtmlText);
        }
        public void AddSimpleButton(int x, int y, int id, string text, string color)
        {
            AddButton(x, y, ButtonID[0], ButtonID[1], id, GumpButtonType.Reply, 0);
            AddHtmlTexteColored(x + 20, y - 3, 350, text, color);
            //AddLabel(x + 20, y - 3, color, text);
        }
        public void AddButtonPageSuivante(int x, int y, int id)
        {
            AddButton(x, y, 0x2622, 0x2623, id, GumpButtonType.Reply, 0);
        }
        public void AddButtonPagePrecedante(int x, int y, int id)
        {
            AddButton(x, y, 0x2626, 0x2627, id, GumpButtonType.Reply, 0);
        }
        public void AddButton(int x, int y, int id, int gumpId)
        {
            AddButton(x, y, gumpId, gumpId, id, GumpButtonType.Reply, 0);
        }
        public void AddButton(int x, int y, int id, int gumpId, int gumpIdPressed)
        {
            AddButton(x, y, gumpId, gumpIdPressed, id, GumpButtonType.Reply, 0);
        }
        public void AddLigne(int x, int y, int largeur)
        {
            AddImage(x, y, 95);
            AddImageTiled(x + 5, y + 9, largeur - 10, 3, 96);
            /*for (int i = 0; i < largeur / 179; i++)
                AddImage((x + 5) + (i * 179), y + 9, 96);
            AddImage((x) + (largeur - 10), y + 9, 96); //Assurer qu'on a la fin*/
            AddImage((x) + (largeur - 10), y, 97);
        }
        public void AddHtmlTitre(int x, int y, int largeur, string texte)
        {
            AddHtml(x, y, largeur, 20, String.Concat("<h3><basefont color=#025a>", texte, "<basefont></h3>"), false, false);
        }
        public void AddHtmlTexte(int x, int y, int largeur, string texte)
        {
            AddHtml(x, y, largeur, 20, String.Concat("<h3><basefont color=#241b0d>", texte, "<basefont></h3>"), false, false);
        }
        public void AddHtmlTexteColored(int x, int y, int largeur, string texte, string color)
        {
            AddHtml(x, y, largeur, 20, String.Concat("<h3><basefont color=", color, ">", texte, "<basefont></h3>"), false, false);
        }
        public void AddTitre(int x, int y, int largeur, string texte)
        {
            AddLigne(x, y, largeur);
            AddHtmlTitre(x + 10, y - 5, largeur, texte);
        }
        public void AddSection(int x, int y, int largeur, int hauteur, string titre)
        {
            AddBackground(x, y, largeur, hauteur + 58, 3500);
            AddLigne(x + 20, y + 20, largeur - 37);
            AddHtmlTitre(x + 30, y + 13, largeur - 35, titre);
        }
        public void AddSection(int x, int y, int largeur, int hauteur, string titre, string description)
        {
            AddBackground(x, y, largeur, hauteur + 58, 3500);
            AddLigne(x + 20, y + 20, largeur - 37);
            AddHtmlTitre(x + 30, y + 13, largeur - 35, titre);
            AddHtml(x + 15, y + 43, largeur - 30, hauteur, String.Concat("<h3><basefont color=#241b0d>", description, "<basefont></h3>"), true, true);
        }
        public void AddSection(int x, int y, int largeur, int hauteur, string titre, string description, string[] texte)
        {
            AddBackground(x, y, largeur, hauteur + 58 + (texte.Length * 20), 3500);
            AddLigne(x + 20, y + 20, largeur - 37);
            AddHtmlTitre(x + 30, y + 13, largeur - 35, titre);
            AddHtml(x + 20, y + 43, largeur - 30, hauteur, String.Concat("<h3><basefont color=#241b0d>", description, "<basefont></h3>"), true, true);

            for (int i = 0; i < texte.Length; i++)
            {
                AddHtmlTexte(x + 15, (y + 43) + hauteur + (i * 20), largeur - 35, texte[i]);
            }
        }
        public void AddSection(int x, int y, int largeur, int hauteur, string titre, string[] texte)
        {
            AddBackground(x, y, largeur, hauteur + (texte.Length * 20), 3500);
            AddLigne(x + 20, y + 20, largeur - 37);
            AddHtmlTitre(x + 30, y + 13, largeur - 35, titre);

            for (int i = 0; i < texte.Length; i++)
            {
                AddHtmlTexte(x + 20, (y + 43) + (i * 20), largeur - 35, texte[i]);
            }
        }
        public void AddInvisibleSection(int x, int y, int largeur, int hauteur)
        {
            AddBackground(x, y, largeur, hauteur, 3500);
            AddAlphaRegion(x + 10, y + 10, largeur - 20, hauteur - 20);
        }
        public void AddMenuItem(int x, int y, int gumpID, int buttonID, bool isActive)
        {
            if (isActive)
                AddBackground(x, y, 80, 62, 9300);

            AddButton(x + 20, y + 10, gumpID, gumpID, buttonID, GumpButtonType.Reply, 0);
            AddButton(x + 58, y + 12, 2087, 2087, buttonID, GumpButtonType.Reply, 0);
            AddButton(x + 10, y + 12, 2097, 2097, buttonID, GumpButtonType.Reply, 0);
        }
        public void AddBackgroundImage(int x, int y, int width, int height, int id, int gumpID)
        {
            AddBackground(x, y, width, height, 2620);
            AddButton(x + 5, y + 5, gumpID, gumpID, id, GumpButtonType.Reply, 0);
        }
    }
}
