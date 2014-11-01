using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using System.Reflection;
using Server.HuePickers;
using System.Collections;
using System.Collections.Generic;

namespace Server.Gumps
{
    public class FicheStatistiquesGump : GumpTemrael
    {
        private TMobile m_from;

        public FicheStatistiquesGump(TMobile from)
            : base("Statistiques", 560, 622)
        {
            m_from = from;
            Mobile m = (Mobile)from;
            
            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 20;

            y = 650;
            x = 90;
            int space = 80;

            AddMenuItem(x, y, 1178, 1, true);
            x += space;
            AddMenuItem(x, y, 1179, 2, true);
            x += space;
            AddMenuItem(x, y, 1180, 3, true);
            x += space;
            AddMenuItem(x, y, 1194, 4, true);
            x += space;
            AddMenuItem(x, y, 1196, 5, false);
            x += space;
            AddMenuItem(x, y, 1222, 6, true);
            x += space;
            AddMenuItem(x, y, 1191, 7, true);

            x = XBase;
            y = YBase;

            /*Statistiques*/
            line = 0;
            AddSection(x, y + line * scale, 540, 465, "Statistiques");

            Hashtable table = new Hashtable();

            String[] list= new String[28];
            int i = 0;

            list[i++] = "Régénération de vie:";
            list[i++] = ((1 / (Mobile.GetHitsRegenRate(m).TotalSeconds)).ToString("0.00") + " points/seconde");

            list[i++] = "Régénération de mana:";
            list[i++] = ((1 / (Mobile.GetManaRegenRate(m).TotalSeconds)).ToString("0.00") + " points/seconde");

            list[i++] = "Régénération de stamina:";
            list[i++] = ((1 / (Mobile.GetStamRegenRate(m).TotalSeconds)).ToString("0.00") + " points/seconde");

            list[i++] = "Armure:";
            list[i++] = m.PhysicalResistance.ToString();

            list[i++] = "Armure naturelle:";
            list[i++] = m.ArmureNaturelle.ToString();

            list[i++] = "Résistance physique:";
            list[i++] = (m.PhysicalResistance + m.ArmureNaturelle).ToString();

            list[i++] = "Résistance magique:";
            list[i++] = m.MagicResistance.ToString();

            list[i++] = "Vitesse d'attaque:";
            list[i++] =  ((m.Weapon as BaseWeapon).Strategy.Vitesse(m) / 10).ToString("0.00") + " secondes / attaque";

            list[i++] = "Chances de Critique:";
            list[i++] = ((int)((m.Weapon as BaseWeapon).Strategy.CritiqueChance(m) * 100)).ToString() + " %";

            list[i++] = "Langue courante:";
            list[i++] = from.Langues.CurrentLangue.ToString();

            list[i++] = "Position actuelle:";
            list[i++] = from.Location.ToString();

            list[i++] = "Prochain gain d'expérience:";
            list[i++] = from.Experience.NextExp.ToString();

            list[i++] = "Mode Expérience:";
            list[i++] = from.Experience.XPMode ? "Hebdomadaire" : "Quotidien";

            list[i++] = "Mode Suicide:";
            list[i++] = from.MortEngine.Suicide ? "Activé" : "Désactivé";

            if (from.MortEngine.MortVivant)
            {
                list[i++] = "Phase Mort-Vivant";
                list[i++] = from.MortEngine.MortEvo.ToString(); //17
            }

            x = 125;
            line++;

            for (i = 0; i < list.Length; i++)
            {
                line++;
                AddHtmlTexte(x, y + line * scale, 200, list[i++]);
                AddHtmlTexte(x + 250, y + line * scale, 200, list[i]);
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
                    from.SendGump(new FicheRaceGump(from));
                    break;
                case 2:
                    from.SendGump(new FicheClasseGump(from));
                    break;
                case 3:
                    from.SendGump(new FicheCaracteristiqueGump(from));
                    break;
                case 4:
                    from.SendGump(new FicheCompetencesGump(from));
                    break;
                case 5:
                    from.SendGump(new FicheStatistiquesGump(from));
                    break;
                case 6:
                    from.SendGump(new FicheStatutsGump(from));
                    break;
                case 7:
                    from.SendGump(new FicheCommandesGump(from));
                    break;
            }
        }
    }
}
