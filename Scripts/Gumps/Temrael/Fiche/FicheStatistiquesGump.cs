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

namespace Server.Gumps.Fiche
{
    public class FicheStatistiquesGump : BaseFicheGump
    {
        public FicheStatistiquesGump(PlayerMobile from)
            : base(from, "Statistiques", 560, 622, 5)
        {
            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 20;

            int space = 80;

            /*Statistiques*/
            line = 0;
            AddSection(x, y + line * scale, 540, 465, "Statistiques");

            Hashtable table = new Hashtable();

            String[] list= new String[28];
            int i = 0;

            list[i++] = "Régénération de vie:";
            list[i++] = ((1 / (Mobile.GetHitsRegenRate(from).TotalSeconds)).ToString("0.00") + " points/seconde");

            list[i++] = "Régénération de mana:";
            list[i++] = ((1 / (Mobile.GetManaRegenRate(from).TotalSeconds)).ToString("0.00") + " points/seconde");

            list[i++] = "Régénération de stamina:";
            list[i++] = ((1 / (Mobile.GetStamRegenRate(from).TotalSeconds)).ToString("0.00") + " points/seconde");

            list[i++] = "Armure:";
            list[i++] = from.PhysicalResistance.ToString();

            list[i++] = "Armure naturelle:";
            list[i++] = from.ArmureNaturelle.ToString();

            list[i++] = "Résistance physique:";
            list[i++] = (from.PhysicalResistance + from.ArmureNaturelle).ToString();

            list[i++] = "Résistance magique:";
            list[i++] = from.MagicResistance.ToString();

            list[i++] = "Vitesse d'attaque:";
            list[i++] =  ((from.Weapon as BaseWeapon).Strategy.CalculerVitesse(from) / 10).ToString("0.00") + " secondes / attaque";

            list[i++] = "Chances de Critique:";
            list[i++] = ((int)((from.Weapon as BaseWeapon).Strategy.CritiqueChance(from) * 100)).ToString() + " %";

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
            PlayerMobile from = (PlayerMobile)sender.Mobile;

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
