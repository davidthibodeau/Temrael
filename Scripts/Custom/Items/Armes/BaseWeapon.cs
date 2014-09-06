using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.Necromancy;
//using Server.Spells.Bushido;
//using Server.Spells.Ninjitsu;
using Server.Engines.Craft;
using System.Collections.Generic;
using Server.ContextMenus;
//using Server.Spells.Spellweaving;
using Server.Engines.Combat;
using System.Text.RegularExpressions;

namespace Server.Items
{
	public abstract class BaseWeapon : BaseWearable, IWeapon, ICraftable, IDurability
    {
        private static double[] m_DpsTab
        {
            get
            {
                return new double[]{
                    3, //Attirail 0
                    4, //Attirail 1
                    5, //Attirail 2
                    6, //Attirail 3
                    7, //Attirail 4                    
                    8, //Attirail 5
                    9, //Attirail 6
                };
            }
        }
        private static double getDam(int niv, double speed, bool twohands)
        {
            double damage = m_DpsTab[niv] * speed;

            damage += (speed - 2) * 4; //Pour compenser la perte du a la reduction de dégat

            if (twohands)
                damage *= 1.2;

            return damage;
        }
        private static int getMinDam(int niv, double speed, bool twohands)
        {
            return (int)(Math.Truncate(getDam(niv, speed, twohands) * .94));
        }
        private static int getMaxDam(int niv, double speed, bool twohands)
        {
            return (int)(Math.Round(getDam(niv, speed, twohands) * 1.06));
        }

        #region Balancement
            public static int Armes_MinDurabilite0 = 50;
            public static int Armes_MaxDurabilite0 = 75;
            public static int Armes_MinDurabilite1 = 75;
            public static int Armes_MaxDurabilite1 = 100;
            public static int Armes_MinDurabilite2 = 100;
            public static int Armes_MaxDurabilite2 = 125;
            public static int Armes_MinDurabilite3 = 125;
            public static int Armes_MaxDurabilite3 = 150;
            public static int Armes_MinDurabilite4 = 150;
            public static int Armes_MaxDurabilite4 = 175;
            public static int Armes_MinDurabilite5 = 175;
            public static int Armes_MaxDurabilite5 = 200;
            public static int Armes_MinDurabilite6 = 200;
            public static int Armes_MaxDurabilite6 = 225;

            public static double Claymore_Vitesse = 4.0;
            public static int Claymore_MinDam0 = getMinDam(0, Claymore_Vitesse, true);
            public static int Claymore_MinDam1 = getMinDam(1, Claymore_Vitesse, true);
            public static int Claymore_MinDam2 = getMinDam(2, Claymore_Vitesse, true);
            public static int Claymore_MinDam3 = getMinDam(3, Claymore_Vitesse, true);
            public static int Claymore_MinDam4 = getMinDam(4, Claymore_Vitesse, true);
            public static int Claymore_MinDam5 = getMinDam(5, Claymore_Vitesse, true);
            public static int Claymore_MinDam6 = getMinDam(6, Claymore_Vitesse, true);
            public static int Claymore_MaxDam0 = getMaxDam(0, Claymore_Vitesse, true);
            public static int Claymore_MaxDam1 = getMaxDam(1, Claymore_Vitesse, true);
            public static int Claymore_MaxDam2 = getMaxDam(2, Claymore_Vitesse, true);
            public static int Claymore_MaxDam3 = getMaxDam(3, Claymore_Vitesse, true);
            public static int Claymore_MaxDam4 = getMaxDam(4, Claymore_Vitesse, true);
            public static int Claymore_MaxDam5 = getMaxDam(5, Claymore_Vitesse, true);
            public static int Claymore_MaxDam6 = getMaxDam(6, Claymore_Vitesse, true);
            public static int Claymore_Force0 = 10;
            public static int Claymore_Force1 = 20;
            public static int Claymore_Force2 = 30;
            public static int Claymore_Force3 = 40;
            public static int Claymore_Force4 = 50;
            public static int Claymore_Force5 = 60;
            public static int Claymore_Force6 = 70;

            public static double LourdeLame_Vitesse = 3.5;
            public static int LourdeLame_MinDam0 = getMinDam(0, LourdeLame_Vitesse, true);
            public static int LourdeLame_MinDam1 = getMinDam(1, LourdeLame_Vitesse, true);
            public static int LourdeLame_MinDam2 = getMinDam(2, LourdeLame_Vitesse, true);
            public static int LourdeLame_MinDam3 = getMinDam(3, LourdeLame_Vitesse, true);
            public static int LourdeLame_MinDam4 = getMinDam(4, LourdeLame_Vitesse, true);
            public static int LourdeLame_MinDam5 = getMinDam(5, LourdeLame_Vitesse, true);
            public static int LourdeLame_MinDam6 = getMinDam(6, LourdeLame_Vitesse, true);
            public static int LourdeLame_MaxDam0 = getMaxDam(0, LourdeLame_Vitesse, true);
            public static int LourdeLame_MaxDam1 = getMaxDam(1, LourdeLame_Vitesse, true);
            public static int LourdeLame_MaxDam2 = getMaxDam(2, LourdeLame_Vitesse, true);
            public static int LourdeLame_MaxDam3 = getMaxDam(3, LourdeLame_Vitesse, true);
            public static int LourdeLame_MaxDam4 = getMaxDam(4, LourdeLame_Vitesse, true);
            public static int LourdeLame_MaxDam5 = getMaxDam(5, LourdeLame_Vitesse, true);
            public static int LourdeLame_MaxDam6 = getMaxDam(6, LourdeLame_Vitesse, true);
            public static int LourdeLame_Force0 = 5;
            public static int LourdeLame_Force1 = 15;
            public static int LourdeLame_Force2 = 25;
            public static int LourdeLame_Force3 = 35;
            public static int LourdeLame_Force4 = 45;
            public static int LourdeLame_Force5 = 55;
            public static int LourdeLame_Force6 = 65;

            public static double Lame_Vitesse = 3.0;
            public static int Lame_MinDam0 = getMinDam(0, Lame_Vitesse, false);
            public static int Lame_MinDam1 = getMinDam(1, Lame_Vitesse, false);
            public static int Lame_MinDam2 = getMinDam(2, Lame_Vitesse, false);
            public static int Lame_MinDam3 = getMinDam(3, Lame_Vitesse, false);
            public static int Lame_MinDam4 = getMinDam(4, Lame_Vitesse, false);
            public static int Lame_MinDam5 = getMinDam(5, Lame_Vitesse, false);
            public static int Lame_MinDam6 = getMinDam(6, Lame_Vitesse, false);
            public static int Lame_MaxDam0 = getMaxDam(0, Lame_Vitesse, false);
            public static int Lame_MaxDam1 = getMaxDam(1, Lame_Vitesse, false);
            public static int Lame_MaxDam2 = getMaxDam(2, Lame_Vitesse, false);
            public static int Lame_MaxDam3 = getMaxDam(3, Lame_Vitesse, false);
            public static int Lame_MaxDam4 = getMaxDam(4, Lame_Vitesse, false);
            public static int Lame_MaxDam5 = getMaxDam(5, Lame_Vitesse, false);
            public static int Lame_MaxDam6 = getMaxDam(6, Lame_Vitesse, false);
            public static int Lame_Force0 = 10;
            public static int Lame_Force1 = 15;
            public static int Lame_Force2 = 20;
            public static int Lame_Force3 = 25;
            public static int Lame_Force4 = 30;
            public static int Lame_Force5 = 35;
            public static int Lame_Force6 = 40;

            public static double CourteLame_Vitesse = 3.0;
            public static int CourteLame_MinDam0 = getMinDam(0, CourteLame_Vitesse, false);
            public static int CourteLame_MinDam1 = getMinDam(1, CourteLame_Vitesse, false);
            public static int CourteLame_MinDam2 = getMinDam(2, CourteLame_Vitesse, false);
            public static int CourteLame_MinDam3 = getMinDam(3, CourteLame_Vitesse, false);
            public static int CourteLame_MinDam4 = getMinDam(4, CourteLame_Vitesse, false);
            public static int CourteLame_MinDam5 = getMinDam(5, CourteLame_Vitesse, false);
            public static int CourteLame_MinDam6 = getMinDam(6, CourteLame_Vitesse, false);
            public static int CourteLame_MaxDam0 = getMaxDam(0, CourteLame_Vitesse, false);
            public static int CourteLame_MaxDam1 = getMaxDam(1, CourteLame_Vitesse, false);
            public static int CourteLame_MaxDam2 = getMaxDam(2, CourteLame_Vitesse, false);
            public static int CourteLame_MaxDam3 = getMaxDam(3, CourteLame_Vitesse, false);
            public static int CourteLame_MaxDam4 = getMaxDam(4, CourteLame_Vitesse, false);
            public static int CourteLame_MaxDam5 = getMaxDam(5, CourteLame_Vitesse, false);
            public static int CourteLame_MaxDam6 = getMaxDam(6, CourteLame_Vitesse, false);
            public static int CourteLame_Force0 = 5;
            public static int CourteLame_Force1 = 10;
            public static int CourteLame_Force2 = 15;
            public static int CourteLame_Force3 = 20;
            public static int CourteLame_Force4 = 25;
            public static int CourteLame_Force5 = 30;
            public static int CourteLame_Force6 = 35;

            public static double Sabre_Vitesse = 3.0;
            public static int Sabre_MinDam0 = getMinDam(0, Sabre_Vitesse, false);
            public static int Sabre_MinDam1 = getMinDam(1, Sabre_Vitesse, false);
            public static int Sabre_MinDam2 = getMinDam(2, Sabre_Vitesse, false);
            public static int Sabre_MinDam3 = getMinDam(3, Sabre_Vitesse, false);
            public static int Sabre_MinDam4 = getMinDam(4, Sabre_Vitesse, false);
            public static int Sabre_MinDam5 = getMinDam(5, Sabre_Vitesse, false);
            public static int Sabre_MinDam6 = getMinDam(6, Sabre_Vitesse, false);
            public static int Sabre_MaxDam0 = getMaxDam(0, Sabre_Vitesse, false);
            public static int Sabre_MaxDam1 = getMaxDam(1, Sabre_Vitesse, false);
            public static int Sabre_MaxDam2 = getMaxDam(2, Sabre_Vitesse, false);
            public static int Sabre_MaxDam3 = getMaxDam(3, Sabre_Vitesse, false);
            public static int Sabre_MaxDam4 = getMaxDam(4, Sabre_Vitesse, false);
            public static int Sabre_MaxDam5 = getMaxDam(5, Sabre_Vitesse, false);
            public static int Sabre_MaxDam6 = getMaxDam(6, Sabre_Vitesse, false);
            public static int Sabre_Force0 = 0;
            public static int Sabre_Force1 = 10;
            public static int Sabre_Force2 = 20;
            public static int Sabre_Force3 = 30;
            public static int Sabre_Force4 = 40;
            public static int Sabre_Force5 = 50;
            public static int Sabre_Force6 = 60;

            public static double Hallebarde_Vitesse = 4.0;
            public static int Hallebarde_MinDam0 = getMinDam(0, Hallebarde_Vitesse, true);
            public static int Hallebarde_MinDam1 = getMinDam(1, Hallebarde_Vitesse, true);
            public static int Hallebarde_MinDam2 = getMinDam(2, Hallebarde_Vitesse, true);
            public static int Hallebarde_MinDam3 = getMinDam(3, Hallebarde_Vitesse, true);
            public static int Hallebarde_MinDam4 = getMinDam(4, Hallebarde_Vitesse, true);
            public static int Hallebarde_MinDam5 = getMinDam(5, Hallebarde_Vitesse, true);
            public static int Hallebarde_MinDam6 = getMinDam(6, Hallebarde_Vitesse, true);
            public static int Hallebarde_MaxDam0 = getMaxDam(0, Hallebarde_Vitesse, true);
            public static int Hallebarde_MaxDam1 = getMaxDam(1, Hallebarde_Vitesse, true);
            public static int Hallebarde_MaxDam2 = getMaxDam(2, Hallebarde_Vitesse, true);
            public static int Hallebarde_MaxDam3 = getMaxDam(3, Hallebarde_Vitesse, true);
            public static int Hallebarde_MaxDam4 = getMaxDam(4, Hallebarde_Vitesse, true);
            public static int Hallebarde_MaxDam5 = getMaxDam(5, Hallebarde_Vitesse, true);
            public static int Hallebarde_MaxDam6 = getMaxDam(6, Hallebarde_Vitesse, true);
            public static int Hallebarde_Force0 = 40;
            public static int Hallebarde_Force1 = 45;
            public static int Hallebarde_Force2 = 50;
            public static int Hallebarde_Force3 = 55;
            public static int Hallebarde_Force4 = 60;
            public static int Hallebarde_Force5 = 65;
            public static int Hallebarde_Force6 = 70;

            public static double Bardiche_Vitesse = 4.0;
            public static int Bardiche_MinDam0 = getMinDam(0, Bardiche_Vitesse, true);
            public static int Bardiche_MinDam1 = getMinDam(1, Bardiche_Vitesse, true);
            public static int Bardiche_MinDam2 = getMinDam(2, Bardiche_Vitesse, true);
            public static int Bardiche_MinDam3 = getMinDam(3, Bardiche_Vitesse, true);
            public static int Bardiche_MinDam4 = getMinDam(4, Bardiche_Vitesse, true);
            public static int Bardiche_MinDam5 = getMinDam(5, Bardiche_Vitesse, true);
            public static int Bardiche_MinDam6 = getMinDam(6, Bardiche_Vitesse, true);
            public static int Bardiche_MaxDam0 = getMaxDam(0, Bardiche_Vitesse, true);
            public static int Bardiche_MaxDam1 = getMaxDam(1, Bardiche_Vitesse, true);
            public static int Bardiche_MaxDam2 = getMaxDam(2, Bardiche_Vitesse, true);
            public static int Bardiche_MaxDam3 = getMaxDam(3, Bardiche_Vitesse, true);
            public static int Bardiche_MaxDam4 = getMaxDam(4, Bardiche_Vitesse, true);
            public static int Bardiche_MaxDam5 = getMaxDam(5, Bardiche_Vitesse, true);
            public static int Bardiche_MaxDam6 = getMaxDam(6, Bardiche_Vitesse, true);
            public static int Bardiche_Force0 = 40;
            public static int Bardiche_Force1 = 45;
            public static int Bardiche_Force2 = 50;
            public static int Bardiche_Force3 = 55;
            public static int Bardiche_Force4 = 60;
            public static int Bardiche_Force5 = 65;
            public static int Bardiche_Force6 = 70;

            public static double Hache_Vitesse = 4.0;
            public static int Hache_MinDam0 = getMinDam(0, Hache_Vitesse, true);
            public static int Hache_MinDam1 = getMinDam(1, Hache_Vitesse, true);
            public static int Hache_MinDam2 = getMinDam(2, Hache_Vitesse, true);
            public static int Hache_MinDam3 = getMinDam(3, Hache_Vitesse, true);
            public static int Hache_MinDam4 = getMinDam(4, Hache_Vitesse, true);
            public static int Hache_MinDam5 = getMinDam(5, Hache_Vitesse, true);
            public static int Hache_MinDam6 = getMinDam(6, Hache_Vitesse, true);
            public static int Hache_MaxDam0 = getMaxDam(0, Hache_Vitesse, true);
            public static int Hache_MaxDam1 = getMaxDam(1, Hache_Vitesse, true);
            public static int Hache_MaxDam2 = getMaxDam(2, Hache_Vitesse, true);
            public static int Hache_MaxDam3 = getMaxDam(3, Hache_Vitesse, true);
            public static int Hache_MaxDam4 = getMaxDam(4, Hache_Vitesse, true);
            public static int Hache_MaxDam5 = getMaxDam(5, Hache_Vitesse, true);
            public static int Hache_MaxDam6 = getMaxDam(6, Hache_Vitesse, true);
            public static int Hache_Force0 = 40;
            public static int Hache_Force1 = 45;
            public static int Hache_Force2 = 50;
            public static int Hache_Force3 = 55;
            public static int Hache_Force4 = 60;
            public static int Hache_Force5 = 65;
            public static int Hache_Force6 = 70;

            public static double Hachette_Vitesse = 3.0;
            public static int Hachette_MinDam0 = getMinDam(0, Hachette_Vitesse, false);
            public static int Hachette_MinDam1 = getMinDam(1, Hachette_Vitesse, false);
            public static int Hachette_MinDam2 = getMinDam(2, Hachette_Vitesse, false);
            public static int Hachette_MinDam3 = getMinDam(3, Hachette_Vitesse, false);
            public static int Hachette_MinDam4 = getMinDam(4, Hachette_Vitesse, false);
            public static int Hachette_MinDam5 = getMinDam(5, Hachette_Vitesse, false);
            public static int Hachette_MinDam6 = getMinDam(6, Hachette_Vitesse, false);
            public static int Hachette_MaxDam0 = getMaxDam(0, Hachette_Vitesse, false);
            public static int Hachette_MaxDam1 = getMaxDam(1, Hachette_Vitesse, false);
            public static int Hachette_MaxDam2 = getMaxDam(2, Hachette_Vitesse, false);
            public static int Hachette_MaxDam3 = getMaxDam(3, Hachette_Vitesse, false);
            public static int Hachette_MaxDam4 = getMaxDam(4, Hachette_Vitesse, false);
            public static int Hachette_MaxDam5 = getMaxDam(5, Hachette_Vitesse, false);
            public static int Hachette_MaxDam6 = getMaxDam(6, Hachette_Vitesse, false);
            public static int Hachette_Force0 = 10;
            public static int Hachette_Force1 = 20;
            public static int Hachette_Force2 = 30;
            public static int Hachette_Force3 = 40;
            public static int Hachette_Force4 = 50;
            public static int Hachette_Force5 = 60;
            public static int Hachette_Force6 = 70;

            public static double Trident_Vitesse = 4.0;
            public static int Trident_MinDam0 = getMinDam(0, Trident_Vitesse, true);
            public static int Trident_MinDam1 = getMinDam(1, Trident_Vitesse, true);
            public static int Trident_MinDam2 = getMinDam(2, Trident_Vitesse, true);
            public static int Trident_MinDam3 = getMinDam(3, Trident_Vitesse, true);
            public static int Trident_MinDam4 = getMinDam(4, Trident_Vitesse, true);
            public static int Trident_MinDam5 = getMinDam(5, Trident_Vitesse, true);
            public static int Trident_MinDam6 = getMinDam(6, Trident_Vitesse, true);
            public static int Trident_MaxDam0 = getMaxDam(0, Trident_Vitesse, true);
            public static int Trident_MaxDam1 = getMaxDam(1, Trident_Vitesse, true);
            public static int Trident_MaxDam2 = getMaxDam(2, Trident_Vitesse, true);
            public static int Trident_MaxDam3 = getMaxDam(3, Trident_Vitesse, true);
            public static int Trident_MaxDam4 = getMaxDam(4, Trident_Vitesse, true);
            public static int Trident_MaxDam5 = getMaxDam(5, Trident_Vitesse, true);
            public static int Trident_MaxDam6 = getMaxDam(6, Trident_Vitesse, true);
            public static int Trident_Force0 = 40;
            public static int Trident_Force1 = 45;
            public static int Trident_Force2 = 50;
            public static int Trident_Force3 = 55;
            public static int Trident_Force4 = 60;
            public static int Trident_Force5 = 65;
            public static int Trident_Force6 = 70;

            public static double Lance_Vitesse = 3.5;
            public static int Lance_MinDam0 = getMinDam(0, Lance_Vitesse, true);
            public static int Lance_MinDam1 = getMinDam(1, Lance_Vitesse, true);
            public static int Lance_MinDam2 = getMinDam(2, Lance_Vitesse, true);
            public static int Lance_MinDam3 = getMinDam(3, Lance_Vitesse, true);
            public static int Lance_MinDam4 = getMinDam(4, Lance_Vitesse, true);
            public static int Lance_MinDam5 = getMinDam(5, Lance_Vitesse, true);
            public static int Lance_MinDam6 = getMinDam(6, Lance_Vitesse, true);
            public static int Lance_MaxDam0 = getMaxDam(0, Lance_Vitesse, true);
            public static int Lance_MaxDam1 = getMaxDam(1, Lance_Vitesse, true);
            public static int Lance_MaxDam2 = getMaxDam(2, Lance_Vitesse, true);
            public static int Lance_MaxDam3 = getMaxDam(3, Lance_Vitesse, true);
            public static int Lance_MaxDam4 = getMaxDam(4, Lance_Vitesse, true);
            public static int Lance_MaxDam5 = getMaxDam(5, Lance_Vitesse, true);
            public static int Lance_MaxDam6 = getMaxDam(6, Lance_Vitesse, true);
            public static int Lance_Force0 = 30;
            public static int Lance_Force1 = 35;
            public static int Lance_Force2 = 40;
            public static int Lance_Force3 = 45;
            public static int Lance_Force4 = 50;
            public static int Lance_Force5 = 55;
            public static int Lance_Force6 = 60;

            public static double Rapiere_Vitesse = 2.5;
            public static int Rapiere_MinDam0 = getMinDam(0, Rapiere_Vitesse, false);
            public static int Rapiere_MinDam1 = getMinDam(1, Rapiere_Vitesse, false);
            public static int Rapiere_MinDam2 = getMinDam(2, Rapiere_Vitesse, false);
            public static int Rapiere_MinDam3 = getMinDam(3, Rapiere_Vitesse, false);
            public static int Rapiere_MinDam4 = getMinDam(4, Rapiere_Vitesse, false);
            public static int Rapiere_MinDam5 = getMinDam(5, Rapiere_Vitesse, false);
            public static int Rapiere_MinDam6 = getMinDam(6, Rapiere_Vitesse, false);
            public static int Rapiere_MaxDam0 = getMaxDam(0, Rapiere_Vitesse, false);
            public static int Rapiere_MaxDam1 = getMaxDam(1, Rapiere_Vitesse, false);
            public static int Rapiere_MaxDam2 = getMaxDam(2, Rapiere_Vitesse, false);
            public static int Rapiere_MaxDam3 = getMaxDam(3, Rapiere_Vitesse, false);
            public static int Rapiere_MaxDam4 = getMaxDam(4, Rapiere_Vitesse, false);
            public static int Rapiere_MaxDam5 = getMaxDam(5, Rapiere_Vitesse, false);
            public static int Rapiere_MaxDam6 = getMaxDam(6, Rapiere_Vitesse, false);
            public static int Rapiere_Force0 = 5;
            public static int Rapiere_Force1 = 10;
            public static int Rapiere_Force2 = 15;
            public static int Rapiere_Force3 = 20;
            public static int Rapiere_Force4 = 25;
            public static int Rapiere_Force5 = 30;
            public static int Rapiere_Force6 = 35;

            public static double Dague_Vitesse = 2.0;
            public static int Dague_MinDam0 = getMinDam(0, Dague_Vitesse, true);
            public static int Dague_MinDam1 = getMinDam(1, Dague_Vitesse, true);
            public static int Dague_MinDam2 = getMinDam(2, Dague_Vitesse, true);
            public static int Dague_MinDam3 = getMinDam(3, Dague_Vitesse, true);
            public static int Dague_MinDam4 = getMinDam(4, Dague_Vitesse, true);
            public static int Dague_MinDam5 = getMinDam(5, Dague_Vitesse, true);
            public static int Dague_MinDam6 = getMinDam(6, Dague_Vitesse, true);
            public static int Dague_MaxDam0 = getMaxDam(0, Dague_Vitesse, true);
            public static int Dague_MaxDam1 = getMaxDam(1, Dague_Vitesse, true);
            public static int Dague_MaxDam2 = getMaxDam(2, Dague_Vitesse, true);
            public static int Dague_MaxDam3 = getMaxDam(3, Dague_Vitesse, true);
            public static int Dague_MaxDam4 = getMaxDam(4, Dague_Vitesse, true);
            public static int Dague_MaxDam5 = getMaxDam(5, Dague_Vitesse, true);
            public static int Dague_MaxDam6 = getMaxDam(6, Dague_Vitesse, true);
            public static int Dague_Force0 = 0;
            public static int Dague_Force1 = 5;
            public static int Dague_Force2 = 10;
            public static int Dague_Force3 = 15;
            public static int Dague_Force4 = 20;
            public static int Dague_Force5 = 25;
            public static int Dague_Force6 = 30;

            public static double Marteau_Vitesse = 4.0;
            public static int Marteau_MinDam0 = getMinDam(0, Marteau_Vitesse, true);
            public static int Marteau_MinDam1 = getMinDam(1, Marteau_Vitesse, true);
            public static int Marteau_MinDam2 = getMinDam(2, Marteau_Vitesse, true);
            public static int Marteau_MinDam3 = getMinDam(3, Marteau_Vitesse, true);
            public static int Marteau_MinDam4 = getMinDam(4, Marteau_Vitesse, true);
            public static int Marteau_MinDam5 = getMinDam(5, Marteau_Vitesse, true);
            public static int Marteau_MinDam6 = getMinDam(6, Marteau_Vitesse, true);
            public static int Marteau_MaxDam0 = getMaxDam(0, Marteau_Vitesse, true);
            public static int Marteau_MaxDam1 = getMaxDam(1, Marteau_Vitesse, true);
            public static int Marteau_MaxDam2 = getMaxDam(2, Marteau_Vitesse, true);
            public static int Marteau_MaxDam3 = getMaxDam(3, Marteau_Vitesse, true);
            public static int Marteau_MaxDam4 = getMaxDam(4, Marteau_Vitesse, true);
            public static int Marteau_MaxDam5 = getMaxDam(5, Marteau_Vitesse, true);
            public static int Marteau_MaxDam6 = getMaxDam(6, Marteau_Vitesse, true);
            public static int Marteau_Force0 = 40;
            public static int Marteau_Force1 = 45;
            public static int Marteau_Force2 = 50;
            public static int Marteau_Force3 = 55;
            public static int Marteau_Force4 = 60;
            public static int Marteau_Force5 = 65;
            public static int Marteau_Force6 = 70;

            public static double Masse_Vitesse = 3.0;
            public static int Masse_MinDam0 = getMinDam(0, Masse_Vitesse, false);
            public static int Masse_MinDam1 = getMinDam(1, Masse_Vitesse, false);
            public static int Masse_MinDam2 = getMinDam(2, Masse_Vitesse, false);
            public static int Masse_MinDam3 = getMinDam(3, Masse_Vitesse, false);
            public static int Masse_MinDam4 = getMinDam(4, Masse_Vitesse, false);
            public static int Masse_MinDam5 = getMinDam(5, Masse_Vitesse, false);
            public static int Masse_MinDam6 = getMinDam(6, Masse_Vitesse, false);
            public static int Masse_MaxDam0 = getMaxDam(0, Masse_Vitesse, false);
            public static int Masse_MaxDam1 = getMaxDam(1, Masse_Vitesse, false);
            public static int Masse_MaxDam2 = getMaxDam(2, Masse_Vitesse, false);
            public static int Masse_MaxDam3 = getMaxDam(3, Masse_Vitesse, false);
            public static int Masse_MaxDam4 = getMaxDam(4, Masse_Vitesse, false);
            public static int Masse_MaxDam5 = getMaxDam(5, Masse_Vitesse, false);
            public static int Masse_MaxDam6 = getMaxDam(6, Masse_Vitesse, false);
            public static int Masse_Force0 = 10;
            public static int Masse_Force1 = 20;
            public static int Masse_Force2 = 30;
            public static int Masse_Force3 = 40;
            public static int Masse_Force4 = 50;
            public static int Masse_Force5 = 60;
            public static int Masse_Force6 = 70;

            public static double Baton_Vitesse = 5.0;
            public static int Baton_MinDam0 = getMinDam(0, Baton_Vitesse, true);
            public static int Baton_MinDam1 = getMinDam(1, Baton_Vitesse, true);
            public static int Baton_MinDam2 = getMinDam(2, Baton_Vitesse, true);
            public static int Baton_MinDam3 = getMinDam(3, Baton_Vitesse, true);
            public static int Baton_MinDam4 = getMinDam(4, Baton_Vitesse, true);
            public static int Baton_MinDam5 = getMinDam(5, Baton_Vitesse, true);
            public static int Baton_MinDam6 = getMinDam(6, Baton_Vitesse, true);
            public static int Baton_MaxDam0 = getMaxDam(0, Baton_Vitesse, true);
            public static int Baton_MaxDam1 = getMaxDam(1, Baton_Vitesse, true);
            public static int Baton_MaxDam2 = getMaxDam(2, Baton_Vitesse, true);
            public static int Baton_MaxDam3 = getMaxDam(3, Baton_Vitesse, true);
            public static int Baton_MaxDam4 = getMaxDam(4, Baton_Vitesse, true);
            public static int Baton_MaxDam5 = getMaxDam(5, Baton_Vitesse, true);
            public static int Baton_MaxDam6 = getMaxDam(6, Baton_Vitesse, true);
            public static int Baton_Force0 = 40;
            public static int Baton_Force1 = 45;
            public static int Baton_Force2 = 50;
            public static int Baton_Force3 = 55;
            public static int Baton_Force4 = 60;
            public static int Baton_Force5 = 65;
            public static int Baton_Force6 = 70;

            public static double Arc_Vitesse = 3.0;
            public static int Arc_MinDam0 = getMinDam(0, Arc_Vitesse, false);
            public static int Arc_MinDam1 = getMinDam(1, Arc_Vitesse, false);
            public static int Arc_MinDam2 = getMinDam(2, Arc_Vitesse, false);
            public static int Arc_MinDam3 = getMinDam(3, Arc_Vitesse, false);
            public static int Arc_MinDam4 = getMinDam(4, Arc_Vitesse, false);
            public static int Arc_MinDam5 = getMinDam(5, Arc_Vitesse, false);
            public static int Arc_MinDam6 = getMinDam(6, Arc_Vitesse, false);
            public static int Arc_MaxDam0 = getMaxDam(0, Arc_Vitesse, false);
            public static int Arc_MaxDam1 = getMaxDam(1, Arc_Vitesse, false);
            public static int Arc_MaxDam2 = getMaxDam(2, Arc_Vitesse, false);
            public static int Arc_MaxDam3 = getMaxDam(3, Arc_Vitesse, false);
            public static int Arc_MaxDam4 = getMaxDam(4, Arc_Vitesse, false);
            public static int Arc_MaxDam5 = getMaxDam(5, Arc_Vitesse, false);
            public static int Arc_MaxDam6 = getMaxDam(6, Arc_Vitesse, false);
            public static int Arc_Force0 = 0;
            public static int Arc_Force1 = 10;
            public static int Arc_Force2 = 20;
            public static int Arc_Force3 = 30;
            public static int Arc_Force4 = 40;
            public static int Arc_Force5 = 50;
            public static int Arc_Force6 = 60;

            public static double Arbalete_Vitesse = 4.0;
            public static int Arbalete_MinDam0 = getMinDam(0, Arbalete_Vitesse, false);
            public static int Arbalete_MinDam1 = getMinDam(1, Arbalete_Vitesse, false);
            public static int Arbalete_MinDam2 = getMinDam(2, Arbalete_Vitesse, false);
            public static int Arbalete_MinDam3 = getMinDam(3, Arbalete_Vitesse, false);
            public static int Arbalete_MinDam4 = getMinDam(4, Arbalete_Vitesse, false);
            public static int Arbalete_MinDam5 = getMinDam(5, Arbalete_Vitesse, false);
            public static int Arbalete_MinDam6 = getMinDam(6, Arbalete_Vitesse, false);
            public static int Arbalete_MaxDam0 = getMaxDam(0, Arbalete_Vitesse, false);
            public static int Arbalete_MaxDam1 = getMaxDam(1, Arbalete_Vitesse, false);
            public static int Arbalete_MaxDam2 = getMaxDam(2, Arbalete_Vitesse, false);
            public static int Arbalete_MaxDam3 = getMaxDam(3, Arbalete_Vitesse, false);
            public static int Arbalete_MaxDam4 = getMaxDam(4, Arbalete_Vitesse, false);
            public static int Arbalete_MaxDam5 = getMaxDam(5, Arbalete_Vitesse, false);
            public static int Arbalete_MaxDam6 = getMaxDam(6, Arbalete_Vitesse, false);
            public static int Arbalete_Force0 = 10;
            public static int Arbalete_Force1 = 20;
            public static int Arbalete_Force2 = 30;
            public static int Arbalete_Force3 = 40;
            public static int Arbalete_Force4 = 50;
            public static int Arbalete_Force5 = 60;
            public static int Arbalete_Force6 = 70;
        #endregion

        private TemraelAttributes m_TemraelAttributes;
        private RareteItem m_rarete;

        [CommandProperty(AccessLevel.Batisseur)]
        public TemraelAttributes TemAttributes
        {
            get { return m_TemraelAttributes; }
            set { }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public RareteItem Rarete
        {
            get { return m_rarete; }
            set { m_rarete = value; InvalidateProperties(); }
        }

		/* Weapon internals work differently now (Mar 13 2003)
		 * 
		 * The attributes defined below default to -1.
		 * If the value is -1, the corresponding virtual 'Aos/Old' property is used.
		 * If not, the attribute value itself is used. Here's the list:
		 *  - MinDamage
		 *  - MaxDamage
		 *  - Speed
		 *  - HitSound
		 *  - MissSound
		 *  - StrRequirement, DexRequirement, IntRequirement
		 *  - WeaponType
		 *  - WeaponAnimation
		 *  - MaxRange
		 */

		#region Var declarations

		// Instance values. These values are unique to each weapon.
		private WeaponDamageLevel m_DamageLevel;
		private WeaponAccuracyLevel m_AccuracyLevel;
		private WeaponDurabilityLevel m_DurabilityLevel;
		private WeaponQuality m_Quality;
		private Mobile m_Crafter;
        private string m_CrafterName;
		private Poison m_Poison;
		private int m_PoisonCharges;
		private bool m_Identified;
		private int m_Hits;
		private int m_MaxHits;
		private SkillMod m_SkillMod, m_MageMod;
		private CraftResource m_Resource;
		private bool m_PlayerConstructed;

		private bool m_Cursed; // Is this weapon cursed via Curse Weapon necromancer spell? Temporary; not serialized.
		private bool m_Consecrated; // Is this weapon blessed via Consecrate Weapon paladin ability? Temporary; not serialized.

		private AosAttributes m_AosAttributes;
		private AosWeaponAttributes m_AosWeaponAttributes;
		private AosSkillBonuses m_AosSkillBonuses;
		private AosElementAttributes m_AosElementDamages;

		// Overridable values. These values are provided to override the defaults which get defined in the individual weapon scripts.
		private int m_StrReq, m_DexReq, m_IntReq;
		private int m_MinDamage, m_MaxDamage;
		private int m_HitSound, m_MissSound;
		private float m_Speed;
		private int m_MaxRange;
		private SkillName m_Skill;
		private WeaponType m_Type;
		private WeaponAnimation m_Animation;
		#endregion

		#region Virtual Properties
		public virtual WeaponAbility PrimaryAbility{ get{ return null; } }
		public virtual WeaponAbility SecondaryAbility{ get{ return null; } }

		public virtual int DefMaxRange{ get{ return 1; } }
		public virtual int DefHitSound{ get{ return 0; } }
		public virtual int DefMissSound{ get{ return 0; } }
		public virtual SkillName DefSkill{ get{ return SkillName.ArmeTranchante; } }
		public virtual WeaponType DefType{ get{ return WeaponType.Slashing; } }
		public virtual WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Slash1H; } }

		public virtual int AosStrengthReq{ get{ return 0; } }
		public virtual int AosDexterityReq{ get{ return 0; } }
		public virtual int AosIntelligenceReq{ get{ return 0; } }
		public virtual int AosMinDamage{ get{ return 0; } }
		public virtual int AosMaxDamage{ get{ return 0; } }
		public virtual double AosSpeed{ get{ return 0; } }
		public virtual float MlSpeed{ get{ return 0.0f; } }

		public virtual int InitMinHits{ get{ return 0; } }
		public virtual int InitMaxHits{ get{ return 0; } }

		public virtual bool CanFortify{ get{ return true; } }

		public override int PhysicalResistance{ get{ return m_AosWeaponAttributes.ResistPhysicalBonus; } }
		public override int ContondantResistance{ get{ return m_AosWeaponAttributes.ResistContondantBonus; } }
		public override int TranchantResistance{ get{ return m_AosWeaponAttributes.ResistTranchantBonus; } }
		public override int PerforantResistance{ get{ return m_AosWeaponAttributes.ResistPerforantBonus; } }
		public override int MagieResistance{ get{ return m_AosWeaponAttributes.ResistMagieBonus; } }

		public virtual SkillName AccuracySkill { get { return SkillName.Tactiques; } }
		#endregion

		#region Getters & Setters
		[CommandProperty( AccessLevel.Batisseur )]
		public AosAttributes Attributes
		{
			get{ return m_AosAttributes; }
			set{}
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public AosWeaponAttributes WeaponAttributes
		{
			get{ return m_AosWeaponAttributes; }
			set{}
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public AosSkillBonuses SkillBonuses
		{
			get{ return m_AosSkillBonuses; }
			set{}
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public AosElementAttributes AosElementDamages
		{
			get { return m_AosElementDamages; }
			set { }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public bool Cursed
		{
			get{ return m_Cursed; }
			set{ m_Cursed = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public bool Consecrated
		{
			get{ return m_Consecrated; }
			set{ m_Consecrated = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public bool Identified
		{
			get{ return m_Identified; }
			set{ m_Identified = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int HitPoints
		{
			get{ return m_Hits; }
			set
			{
				if ( m_Hits == value )
					return;

				if ( value > m_MaxHits )
					value = m_MaxHits;

				m_Hits = value;

				InvalidateProperties();
			}
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int MaxHitPoints
		{
			get{ return m_MaxHits; }
			set{ m_MaxHits = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int PoisonCharges
		{
			get{ return m_PoisonCharges; }
			set{ m_PoisonCharges = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public Poison Poison
		{
			get{ return m_Poison; }
			set{ m_Poison = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public WeaponQuality Quality
		{
			get{ return m_Quality; }
			set{ UnscaleDurability(); m_Quality = value; ScaleDurability(); InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public Mobile Crafter
		{
			get{ return m_Crafter; }
			set{ m_Crafter = value; InvalidateProperties(); }
		}

        [CommandProperty(AccessLevel.Batisseur)]
        public string CrafterName
        {
            get { return m_CrafterName; }
            set { m_CrafterName = value; InvalidateProperties(); }
        }

		[CommandProperty( AccessLevel.Batisseur )]
		public CraftResource Resource
		{
			get{ return m_Resource; }
			set{ UnscaleDurability(); m_Resource = value; Hue = CraftResources.GetHue( m_Resource ); InvalidateProperties(); ScaleDurability(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public WeaponDamageLevel DamageLevel
		{
			get{ return m_DamageLevel; }
			set{ m_DamageLevel = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public WeaponDurabilityLevel DurabilityLevel
		{
			get{ return m_DurabilityLevel; }
			set{ UnscaleDurability(); m_DurabilityLevel = value; InvalidateProperties(); ScaleDurability(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public bool PlayerConstructed
		{
			get{ return m_PlayerConstructed; }
			set{ m_PlayerConstructed = value; }
		}

        [CommandProperty(AccessLevel.Batisseur)]
        public int MaxRange
        {
            get { return (m_MaxRange == -1 ? CombatStrategy.Range : m_MaxRange); }
            set { m_MaxRange = value; InvalidateProperties(); }
        }

		[CommandProperty( AccessLevel.Batisseur )]
		public WeaponAnimation Animation
		{
			get{ return ( m_Animation == (WeaponAnimation)(-1) ? DefAnimation : m_Animation ); } 
			set{ m_Animation = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public WeaponType Type
		{
			get{ return ( m_Type == (WeaponType)(-1) ? DefType : m_Type ); }
			set{ m_Type = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public SkillName Skill
		{
			get{ return ( m_Skill == (SkillName)(-1) ? DefSkill : m_Skill ); }
			set{ m_Skill = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int HitSound
		{
			get{ return ( m_HitSound == -1 ? DefHitSound : m_HitSound ); }
			set{ m_HitSound = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int MissSound
		{
			get{ return ( m_MissSound == -1 ? DefMissSound : m_MissSound ); }
			set{ m_MissSound = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int MinDamage
		{
			get{ return ( m_MinDamage == -1 ? AosMinDamage : m_MinDamage ); }
			set{ m_MinDamage = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int MaxDamage
		{
			get{ return ( m_MaxDamage == -1 ? AosMaxDamage : m_MaxDamage ); }
			set{ m_MaxDamage = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public float Speed
		{
			get
			{
				if ( m_Speed != -1 )
					return m_Speed;

				if ( Core.ML )
					return MlSpeed;

                return (float)AosSpeed;


			}
			set{ m_Speed = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int StrRequirement
		{
			get{ return ( m_StrReq == -1 ? AosStrengthReq : m_StrReq ); }
			set{ m_StrReq = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int DexRequirement
		{
			get{ return ( m_DexReq == -1 ? AosDexterityReq : m_DexReq ); }
			set{ m_DexReq = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int IntRequirement
		{
			get{ return ( m_IntReq == -1 ? AosIntelligenceReq  : m_IntReq ); }
			set{ m_IntReq = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public WeaponAccuracyLevel AccuracyLevel
		{
			get
			{
				return m_AccuracyLevel;
			}
			set
			{
				if ( m_AccuracyLevel != value )
				{
					m_AccuracyLevel = value;

					if ( UseSkillMod )
					{
						if ( m_AccuracyLevel == WeaponAccuracyLevel.Regular )
						{
							if ( m_SkillMod != null )
								m_SkillMod.Remove();

							m_SkillMod = null;
						}
						else if ( m_SkillMod == null && Parent is Mobile )
						{
							m_SkillMod = new DefaultSkillMod( AccuracySkill, true, (int)m_AccuracyLevel * 5 );
							((Mobile)Parent).AddSkillMod( m_SkillMod );
						}
						else if ( m_SkillMod != null )
						{
							m_SkillMod.Value = (int)m_AccuracyLevel * 5;
						}
					}

					InvalidateProperties();
				}
			}
		}

        [CommandProperty(AccessLevel.Batisseur)]
        public CombatStrategy CombatStrategy
        {
            get;
            set;
        }
		#endregion

		public override void OnAfterDuped( Item newItem )
		{
			BaseWeapon weap = newItem as BaseWeapon;

			if ( weap == null )
				return;

			weap.m_AosAttributes = new AosAttributes( newItem, m_AosAttributes );
			weap.m_AosElementDamages = new AosElementAttributes( newItem, m_AosElementDamages );
			weap.m_AosSkillBonuses = new AosSkillBonuses( newItem, m_AosSkillBonuses );
			weap.m_AosWeaponAttributes = new AosWeaponAttributes( newItem, m_AosWeaponAttributes );
		}

		public virtual void UnscaleDurability()
		{
			int scale = 100 + GetDurabilityBonus();

			m_Hits = ((m_Hits * 100) + (scale - 1)) / scale;
			m_MaxHits = ((m_MaxHits * 100) + (scale - 1)) / scale;
			InvalidateProperties();
		}

		public virtual void ScaleDurability()
		{
			int scale = 100 + GetDurabilityBonus();

			m_Hits = ((m_Hits * scale) + 99) / 100;
			m_MaxHits = ((m_MaxHits * scale) + 99) / 100;
			InvalidateProperties();
		}

		public int GetDurabilityBonus()
		{
			int bonus = 0;

			if ( m_Quality == WeaponQuality.Exceptional )
				bonus += 20;

			switch ( m_DurabilityLevel )
			{
				case WeaponDurabilityLevel.Durable: bonus += 20; break;
				case WeaponDurabilityLevel.Substantial: bonus += 50; break;
				case WeaponDurabilityLevel.Massive: bonus += 70; break;
				case WeaponDurabilityLevel.Fortified: bonus += 100; break;
				case WeaponDurabilityLevel.Indestructible: bonus += 120; break;
			}

			if ( Core.AOS )
			{
				bonus += m_AosWeaponAttributes.DurabilityBonus;

				CraftResourceInfo resInfo = CraftResources.GetInfo( m_Resource );
				CraftAttributeInfo attrInfo = null;

				if ( resInfo != null )
					attrInfo = resInfo.AttributeInfo;

				if ( attrInfo != null )
					bonus += attrInfo.WeaponDurability;
			}

			return bonus;
		}

		public int GetLowerStatReq()
		{
			if ( !Core.AOS )
				return 0;

			int v = m_AosWeaponAttributes.LowerStatReq;

			CraftResourceInfo info = CraftResources.GetInfo( m_Resource );

			if ( info != null )
			{
				CraftAttributeInfo attrInfo = info.AttributeInfo;

				if ( attrInfo != null )
					v += attrInfo.WeaponLowerRequirements;
			}

			if ( v > 100 )
				v = 100;

			return v;
		}

		public static void BlockEquip( Mobile m, TimeSpan duration )
		{
			if ( m.BeginAction( typeof( BaseWeapon ) ) )
				new ResetEquipTimer( m, duration ).Start();
		}

		private class ResetEquipTimer : Timer
		{
			private Mobile m_Mobile;

			public ResetEquipTimer( Mobile m, TimeSpan duration ) : base( duration )
			{
				m_Mobile = m;
			}

			protected override void OnTick()
			{
				m_Mobile.EndAction( typeof( BaseWeapon ) );
			}
		}

		public override bool CheckConflictingLayer( Mobile m, Item item, Layer layer )
		{
			if ( base.CheckConflictingLayer( m, item, layer ) )
				return true;

			if ( this.Layer == Layer.TwoHanded && layer == Layer.OneHanded )
			{
				m.SendLocalizedMessage( 500214 ); // You already have something in both hands.
				return true;
			}
			else if ( this.Layer == Layer.OneHanded && layer == Layer.TwoHanded && !(item is BaseShield) && !(item is BaseEquipableLight) )
			{
				m.SendLocalizedMessage( 500215 ); // You can only wield one weapon at a time.
				return true;
			}

			return false;
		}

		public override bool AllowSecureTrade( Mobile from, Mobile to, Mobile newOwner, bool accepted )
		{
			if ( !Ethics.Ethic.CheckTrade( from, to, newOwner, this ) )
				return false;

			return base.AllowSecureTrade( from, to, newOwner, accepted );
		}

		public virtual Race RequiredRace { get { return null; } }	//On OSI, there are no weapons with race requirements, this is for custom stuff

		public override bool CanEquip( Mobile from )
		{
			if ( !Ethics.Ethic.CheckEquip( from, this ) )
				return false;

			if( RequiredRace != null && from.Race != RequiredRace )
			{
				if( RequiredRace == Race.Elf )
					from.SendLocalizedMessage( 1072203 ); // Only Elves may use this.
				else
					from.SendMessage( "Only {0} may use this.", RequiredRace.PluralName );

				return false;
			}
			else if ( from.RawDex < DexRequirement )
			{
				from.SendMessage( "You are not nimble enough to equip that." );
				return false;
			}
            else if (from.RawStr < AOS.Scale(StrRequirement, 100 - GetLowerStatReq()))
			{
				from.SendLocalizedMessage( 500213 ); // You are not strong enough to equip that.
				return false;
			}
            else if (from.RawInt < IntRequirement)
			{
				from.SendMessage( "You are not smart enough to equip that." );
				return false;
			}
			else if ( !from.CanBeginAction( typeof( BaseWeapon ) ) )
			{
				return false;
			}
			else
			{
				return base.CanEquip( from );
			}
		}

		public virtual bool UseSkillMod{ get{ return !Core.AOS; } }

		public override bool OnEquip( Mobile from )
		{
			int strBonus = m_AosAttributes.BonusStr;
			int dexBonus = m_AosAttributes.BonusDex;
			int intBonus = m_AosAttributes.BonusInt;
            int chaBonus = (m_TemraelAttributes.CharismaBonus > 5 ? 5 : m_TemraelAttributes.CharismaBonus);
            int conBonus = (m_TemraelAttributes.ConstitutionBonus > 5 ? 5 : m_TemraelAttributes.ConstitutionBonus);

			if ( (strBonus != 0 || dexBonus != 0 || intBonus != 0) )
			{
				Mobile m = from;

				string modName = this.Serial.ToString();

				if ( strBonus != 0 )
					m.AddStatMod( new StatMod( StatType.Str, modName + "Str", strBonus, TimeSpan.Zero ) );

				if ( dexBonus != 0 )
					m.AddStatMod( new StatMod( StatType.Dex, modName + "Dex", dexBonus, TimeSpan.Zero ) );

				if ( intBonus != 0 )
					m.AddStatMod( new StatMod( StatType.Int, modName + "Int", intBonus, TimeSpan.Zero ) );

                if (chaBonus != 0)
                    m.AddStatMod(new StatMod(StatType.Cha, modName + "Cha", chaBonus, TimeSpan.Zero));

                if (conBonus != 0)
                    m.AddStatMod(new StatMod(StatType.Con, modName + "Con", conBonus, TimeSpan.Zero));
			}

            from.NextCombatTime = Core.TickCount + Core.GetTicks(GetDelay(from));

			if ( UseSkillMod && m_AccuracyLevel != WeaponAccuracyLevel.Regular )
			{
				if ( m_SkillMod != null )
					m_SkillMod.Remove();

				m_SkillMod = new DefaultSkillMod( AccuracySkill, true, (int)m_AccuracyLevel * 5 );
				from.AddSkillMod( m_SkillMod );
			}

			if ( Core.AOS && m_AosWeaponAttributes.MageWeapon != 0 && m_AosWeaponAttributes.MageWeapon != 30 )
			{
				if ( m_MageMod != null )
					m_MageMod.Remove();

				m_MageMod = new DefaultSkillMod( SkillName.ArtMagique, true, -30 + m_AosWeaponAttributes.MageWeapon );
				from.AddSkillMod( m_MageMod );
			}

			return true;
		}

		public override void OnAdded(IEntity parent)
		{
			base.OnAdded( parent );

			if ( parent is Mobile )
			{
				Mobile from = (Mobile)parent;

				if ( Core.AOS )
					m_AosSkillBonuses.AddTo( from );

				from.CheckStatTimers();
				from.Delta( MobileDelta.WeaponDamage );
			}
		}

		public override void OnRemoved(IEntity parent)
		{
			if ( parent is Mobile )
			{
				Mobile m = (Mobile)parent;
				BaseWeapon weapon = m.Weapon as BaseWeapon;

				string modName = this.Serial.ToString();

				m.RemoveStatMod( modName + "Str" );
				m.RemoveStatMod( modName + "Dex" );
				m.RemoveStatMod( modName + "Int" );
                m.RemoveStatMod(modName + "Cha");
                m.RemoveStatMod(modName + "Con");

                if (parent is TMobile)
                {
                    TMobile from = (TMobile)parent;
                    from.BonusHits -= Attributes.BonusHits;
                    from.BonusStam -= Attributes.BonusStam;
                    from.BonusMana -= Attributes.BonusMana;
                }

                if (weapon != null)
                    m.NextCombatTime = Core.TickCount + Core.GetTicks(weapon.GetDelay(m));

				if ( UseSkillMod && m_SkillMod != null )
				{
					m_SkillMod.Remove();
					m_SkillMod = null;
				}

				if ( m_MageMod != null )
				{
					m_MageMod.Remove();
					m_MageMod = null;
				}

				if ( Core.AOS )
					m_AosSkillBonuses.Remove();

				m.CheckStatTimers();

				m.Delta( MobileDelta.WeaponDamage );
			}
		}

		public virtual SkillName GetUsedSkill( Mobile m, bool checkSkillAttrs )
		{
			SkillName sk;

			if ( checkSkillAttrs && m_AosWeaponAttributes.UseBestSkill != 0 )
			{
				double swrd = m.Skills[SkillName.ArmeTranchante].Value;
				double fenc = m.Skills[SkillName.ArmePerforante].Value;
				double mcng = m.Skills[SkillName.ArmeContondante].Value;
				double val;

				sk = SkillName.ArmeTranchante;
				val = swrd;

				if ( fenc > val ){ sk = SkillName.ArmePerforante; val = fenc; }
				if ( mcng > val ){ sk = SkillName.ArmeContondante; val = mcng; }
			}
			else if ( m_AosWeaponAttributes.MageWeapon != 0 )
			{
				if ( m.Skills[SkillName.ArtMagique].Value > m.Skills[Skill].Value )
					sk = SkillName.ArtMagique;
				else
					sk = Skill;
			}
			else
			{
				sk = Skill;

				if ( sk != SkillName.Anatomie && !m.Player && !m.Body.IsHuman && m.Skills[SkillName.Anatomie].Value > m.Skills[sk].Value )
					sk = SkillName.Anatomie;
			}

			return sk;
		}

		public virtual double GetAttackSkillValue( Mobile attacker, Mobile defender )
		{
			return attacker.Skills[GetUsedSkill( attacker, true )].Value;
		}

		public virtual double GetDefendSkillValue( Mobile attacker, Mobile defender )
		{
			return defender.Skills[GetUsedSkill( defender, true )].Value;
		}

		//private static bool CheckAnimal( Mobile m, Type type )
		//{
		//	return AnimalForm.UnderTransformation( m, type );
		//}

		public virtual TimeSpan GetDelay( Mobile m )
		{          
			double speed = this.Speed;

			if ( speed == 0 )
				return TimeSpan.FromSeconds( 1.0 );

			double delayInSeconds;

            if ( false /*Core.SE*/)
			{
				/*
				 * This is likely true for Core.AOS as well... both guides report the same
				 * formula, and both are wrong.
				 * The old formula left in for AOS for legacy & because we aren't quite 100%
				 * Sure that AOS has THIS formula
				 */
				int bonus = AosAttributes.GetValue( m, AosAttribute.WeaponSpeed );

				//if ( Spells.Chivalry.DivineFurySpell.UnderEffect( m ) )
				//	bonus += 10;

				// Bonus granted by successful use of Honorable Execution.
				//bonus += HonorableExecution.GetSwingBonus( m );

				if( DualWield.Registry.Contains( m ) )
					bonus += ((DualWield.DualWieldTimer)DualWield.Registry[m]).BonusSwingSpeed;

				if( Feint.Registry.Contains( m ) )
					bonus -= ((Feint.FeintTimer)Feint.Registry[m]).SwingSpeedReduction;

				//TransformContext context = TransformationSpellHelper.GetContext( m );

				//if( context != null && context.Spell is ReaperFormSpell )
				//	bonus += ((ReaperFormSpell)context.Spell).SwingSpeedBonus;

				//int discordanceEffect = 0;

				// Discordance gives a malus of -0/-28% to swing speed.
				//if ( SkillHandlers.Discordance.GetEffect( m, ref discordanceEffect ) )
				//	bonus -= discordanceEffect;

				//if( EssenceOfWindSpell.IsDebuffed( m ) )
				//	bonus -= EssenceOfWindSpell.GetSSIMalus( m );

				if ( bonus > 60 )
					bonus = 60;
				
				double ticks;

				if ( Core.ML )
				{
					int stamTicks = m.Stam / 30;

					ticks = speed * 4;
					ticks = Math.Floor( ( ticks - stamTicks ) * ( 100.0 / ( 100 + bonus ) ) );
				}
				else
				{
					speed = Math.Floor( speed * ( bonus + 100.0 ) / 100.0 );

					if ( speed <= 0 )
						speed = 1;

					ticks = Math.Floor( ( 80000.0 / ( ( m.Stam + 100 ) * speed ) ) - 2 );
				}
				
				// Swing speed currently capped at one swing every 1.25 seconds (5 ticks).
				if ( ticks < 5 )
					ticks = 5;

				delayInSeconds = ticks * 0.25;
			}
            //else if ( Core.AOS )
			{
                delayInSeconds = speed - ( ( (m.Dex-70) / 100) * 1.5 );

				int bonus = AosAttributes.GetValue( m, AosAttribute.WeaponSpeed );

                if (SymphonieSpell.m_SymphonieTable.Contains(m))
                {
                    int symphonie = (int)SymphonieSpell.m_SymphonieTable[m];
                    bonus -= symphonie;
                }

                if (FougueCelesteMiracle.m_FougueCelesteTable.Contains(m))
                {
                    bonus -= (int)FougueCelesteMiracle.m_FougueCelesteTable[m] * SpellHelper.GetTotalMobilesInRange(m, 5);

                    ReligiousSpell.MiracleEffet(m, m, 14154, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet);

                    //m.FixedParticles(14170, 10, 15, 5013, 1942, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                    //m.PlaySound(490);
                }

                delayInSeconds -= bonus / 100;

				//if ( Spells.Chivalry.DivineFurySpell.UnderEffect( m ) )
				//	bonus += 10;

				//int discordanceEffect = 0;

				// Discordance gives a malus of -0/-28% to swing speed.
				//if ( SkillHandlers.Discordance.GetEffect( m, ref discordanceEffect ) )
				//	bonus -= discordanceEffect;

				/*v += AOS.Scale( v, bonus );

				if ( v <= 0 )
					v = 1;

				delayInSeconds = Math.Floor( 40000.0 / v ) * 0.5;

				// Maximum swing rate capped at one swing per second 
				// OSI dev said that it has and is supposed to be 1.25
				if ( delayInSeconds < 1.25 )
					delayInSeconds = 1.25;*/
			}

            if (m is BaseCreature)
            {
                delayInSeconds = ((BaseCreature)m).AttackSpeed;
            }

            //bonus pour une arme a une main sans bouclier
            if (Layer == Layer.OneHanded)
            {
                Item b = m.FindItemOnLayer(Layer.TwoHanded);
                if (!(b is BaseShield))
                    delayInSeconds *= 0.85; // +15% de vitesse avec arme a une main sans bouclier
            }

            if (delayInSeconds < 1.0)
                delayInSeconds = 1.0;

            // Modificateur de la technique AttackSpeed.
            delayInSeconds = TechniquesCombat.AttackSpeed.Bonus(m, delayInSeconds);

			return TimeSpan.FromSeconds( delayInSeconds );
		}

		public virtual void OnBeforeSwing( Mobile attacker, Mobile defender )
		{
			WeaponAbility a = WeaponAbility.GetCurrentAbility( attacker );

			if( a != null && !a.OnBeforeSwing( attacker, defender ) )
				WeaponAbility.ClearCurrentAbility( attacker );

			//SpecialMove move = SpecialMove.GetCurrentMove( attacker );

			//if( move != null && !move.OnBeforeSwing( attacker, defender ) )
			//	SpecialMove.ClearCurrentMove( attacker );
		}

		public virtual TimeSpan OnSwing( Mobile attacker, Mobile defender )
		{
			bool canSwing = true;

			if ( Core.AOS )
			{
				canSwing = ( !attacker.Paralyzed && !attacker.Frozen );

				if ( canSwing )
				{
					Spell sp = attacker.Spell as Spell;

					canSwing = ( sp == null || !sp.IsCasting || !sp.BlocksMovement );
				}

				if ( canSwing )
				{
					PlayerMobile p = attacker as PlayerMobile;

					canSwing = ( p == null || p.PeacedUntil <= DateTime.Now );
			}
			}

			if ( canSwing && attacker.HarmfulCheck( defender ) )
			{
				attacker.DisruptiveAction();

				if ( attacker.NetState != null )
					attacker.Send( new Swing( 0, attacker, defender ) );

				if ( attacker is BaseCreature )
				{
					BaseCreature bc = (BaseCreature)attacker;
					WeaponAbility ab = bc.GetWeaponAbility();

					if ( ab != null )
					{
						if ( bc.WeaponAbilityChance > Utility.RandomDouble() )
							WeaponAbility.SetCurrentAbility( bc, ab );
						else
							WeaponAbility.ClearCurrentAbility( bc );
					}
				}
                Combat combat = new Combat(attacker, defender);
                if (combat.CheckHit())
                    OnHit(attacker, defender, 1.0);
                else
                    OnMiss(attacker, defender);
			}
            CombatStrategy.Sequence(attacker, defender);
			return GetDelay( attacker );
		}

		#region Sounds
		public virtual int GetHitAttackSound( Mobile attacker, Mobile defender )
		{
			int sound = attacker.GetAttackSound();

			if ( sound == -1 )
				sound = HitSound;

			return sound;
		}

		public virtual int GetHitDefendSound( Mobile attacker, Mobile defender )
		{
			return defender.GetHurtSound();
		}

		public virtual int GetMissAttackSound( Mobile attacker, Mobile defender )
		{
			if ( attacker.GetAttackSound() == -1 )
				return MissSound;
			else
				return -1;
		}

		public virtual int GetMissDefendSound( Mobile attacker, Mobile defender )
		{
			return -1;
		}
		#endregion


		public virtual int AbsorbDamageAOS( Mobile attacker, Mobile defender, int damage )
		{
			bool blocked = false;

			if ( defender.Player || defender.Body.IsHuman )
			{
                Combat combat = new Combat(attacker, defender);
				blocked = combat.CheckParer();

				if ( blocked )
				{
					defender.FixedEffect( 0x37B9, 10, 16 );
					damage = 0;

					// Successful block removes the Honorable Execution penalty.
					//HonorableExecution.RemovePenalty( defender );

					//if ( CounterAttack.IsCountering( defender ) )
					//{
					//	BaseWeapon weapon = defender.Weapon as BaseWeapon;
                    //
					//	if ( weapon != null )
					//	{
					//		defender.FixedParticles(0x3779, 1, 15, 0x158B, 0x0, 0x3, EffectLayer.Waist);
					//		weapon.OnSwing( defender, attacker );
					//	}
                    //
					//	CounterAttack.StopCountering( defender );
					//}

					//if ( Confidence.IsConfident( defender ) )
					//{
					//	defender.SendLocalizedMessage( 1063117 ); // Your confidence reassures you as you successfully block your opponent's blow.
                    //
					//	double bushido = defender.Skills.Bushido.Value;
                    //
					//	defender.Hits += Utility.RandomMinMax( 1, (int)(bushido / 12) );
					//	defender.Stam += Utility.RandomMinMax( 1, (int)(bushido / 5) );
					//}

					BaseShield shield = defender.FindItemOnLayer( Layer.TwoHanded ) as BaseShield;

					if ( shield != null )
					{
						shield.OnHit( this, damage );
					}
				}
			}

			if ( !blocked )
			{
				double positionChance = Utility.RandomDouble();

				Item armorItem;

				if( positionChance < 0.07 )
					armorItem = defender.NeckArmor;
				else if( positionChance < 0.14 )
					armorItem = defender.HandArmor;
				else if( positionChance < 0.28 )
					armorItem = defender.ArmsArmor;
				else if( positionChance < 0.43 )
					armorItem = defender.HeadArmor;
				else if( positionChance < 0.65 )
					armorItem = defender.LegsArmor;
				else
					armorItem = defender.ChestArmor;

				IWearableDurability armor = armorItem as IWearableDurability;

				if ( armor != null )
					armor.OnHit( this, damage ); // call OnHit to lose durability

                double chance = Utility.RandomDouble();

                //Calcul de l'armure
                int armorRating = (int)defender.PhysicalResistance;

                if (!(defender is TMobile))
                    armorRating += (int)defender.VirtualArmor;

                if (armorRating > 0)
                {
                    double scalar = 0;

                    if (defender is TMobile && attacker is BaseCreature) //Player vs Player & Npc vs Player
                    {
                        if (chance < 0.14)
                            scalar += 0.81;//.07 //0.41
                        else if (chance < 0.28)
                            scalar += 0.84;//.14  //0.44
                        else if (chance < 0.43)
                            scalar += 0.87;//.15 //.47
                        else if (chance < 0.65)
                            scalar += 0.80;//.22  //.50
                        else
                            scalar += 0.83;//.35 //.53
                    }
                    else if (defender is BaseCreature && attacker is TMobile) //Npc vs Player
                    {
                        if (chance < 0.14)
                            scalar += 0.81;//.07 //0.41
                        else if (chance < 0.28)
                            scalar += 0.84;//.14  //0.44
                        else if (chance < 0.43)
                            scalar += 0.87;//.15 //.47
                        else if (chance < 0.65)
                            scalar += 0.80;//.22  //.50
                        else
                            scalar += 0.83;//.35 //.53
                    }
                    else
                    {
                        if (attacker is TMobile) //Player vs Npc
                        {
                            if (chance < 0.14)
                                scalar += 0.30;//.07 //.20
                            else if (chance < 0.28)
                                scalar += 0.14;//.14 //.14
                            else if (chance < 0.43)
                                scalar += 0.15;//.15 //.24
                            else if (chance < 0.65)
                                scalar += 0.22;//.22 //.26
                            else
                                scalar += 0.28;//.35 //.28
                        }
                        else //Npc vs Npc
                        {
                            if (chance < 0.14)
                                scalar += 0.06;//.07
                            else if (chance < 0.28)
                                scalar += 0.08;//.14
                            else if (chance < 0.43)
                                scalar += 0.10;//.15
                            else if (chance < 0.65)
                                scalar += 0.12;//.22
                            else
                                scalar += 0.14;//.35
                        }
                    }

                    double bonus = 1;

                    //Directement dans le virtual armor désormais
                    /*if (defender is TMobile)
                        armorRating += ((TMobile)defender).GetAptitudeValue(NAptitude.Resistance) * 2;*/

                    //if (armorreduction != 1)
                    //    bonus -= (armorreduction - 1);

                    //if (AOS.Testing)
                    //    defender.SendMessage("Armor reduction : " + String.Format("{0:0.##}", armorreduction));

                    double percent = 1 - ( (armorRating * bonus) * 0.0030);

                    //Console.WriteLine("Percent Before : " + percent);
                    //Console.WriteLine("Dmg Before : " + damage);
                    
                    if (defender is TMobile)
                        percent -= (double)(((TMobile)defender).GetAptitudeValue(Aptitude.Robustesse) * 0.02);

                    if (defender is TMobile && attacker is TMobile)
                        percent -= (double)(((TMobile)defender).GetAptitudeValue(Aptitude.TueurDeMonstre) * 0.03);

                    if (attacker is TMobile)
                        percent += (double)((TMobile)attacker).GetAptitudeValue(Aptitude.Barbarisme) * 0.03;

                    if (percent < 0.10)
                        percent = 0.10;

                    if (percent > 1.00)
                        percent = 1.00;

                    damage = (int)(damage * percent);

                    //Console.WriteLine("Percent After : " + percent);
                    //Console.WriteLine("Dmg After : " + damage);
                }

                if (damage < 1)
                    damage = 1;
			}

			return damage;
		}

		public virtual int AbsorbDamage( Mobile attacker, Mobile defender, int damage )
		{
            return AbsorbDamageAOS(attacker, defender, damage);
		}

		public virtual int GetPackInstinctBonus( Mobile attacker, Mobile defender )
		{
			if ( attacker.Player || defender.Player )
				return 0;

			BaseCreature bc = attacker as BaseCreature;

			if ( bc == null || bc.PackInstinct == PackInstinct.None || (!bc.Controlled && !bc.Summoned) )
				return 0;

			Mobile master = bc.ControlMaster;

			if ( master == null )
				master = bc.SummonMaster;

			if ( master == null )
				return 0;

			int inPack = 1;

			foreach ( Mobile m in defender.GetMobilesInRange( 1 ) )
			{
				if ( m != attacker && m is BaseCreature )
				{
					BaseCreature tc = (BaseCreature)m;

					if ( (tc.PackInstinct & bc.PackInstinct) == 0 || (!tc.Controlled && !tc.Summoned) )
						continue;

					Mobile theirMaster = tc.ControlMaster;

					if ( theirMaster == null )
						theirMaster = tc.SummonMaster;

					if ( master == theirMaster && tc.Combatant == defender )
						++inPack;
				}
			}

			if ( inPack >= 5 )
				return 100;
			else if ( inPack >= 4 )
				return 75;
			else if ( inPack >= 3 )
				return 50;
			else if ( inPack >= 2 )
				return 25;

			return 0;
		}

		private static bool m_InDoubleStrike;

		public static bool InDoubleStrike
		{
			get{ return m_InDoubleStrike; }
			set{ m_InDoubleStrike = value; }
		}

		public void OnHit( Mobile attacker, Mobile defender )
		{
			OnHit( attacker, defender, 1.0 );
		}

        public void CantMount_Callback(object state)
        {
            TMobile mob = (TMobile)state;
            mob.EndAction(typeof(BaseMount));
        }

        //
        // FONCTION IMPORTANTE POUR LE COMBAT.
        //

		public virtual void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{

			PlaySwingAnimation( attacker );
			PlayHurtAnimation( defender );

			attacker.PlaySound( GetHitAttackSound( attacker, defender ) );
			defender.PlaySound( GetHitDefendSound( attacker, defender ) );

			int damage = ComputeDamage( attacker, defender );

            if (defender is TMobile)
            {
                TMobile def = (TMobile)defender;

                def.CheckEquitation(EquitationType.BeingAttacked);
            }

            TMobile player = null;

            if (attacker is TMobile)
                player = attacker as TMobile;

            if (player != null)
            {
                if (this is BaseRanged)
                    player.CheckEquitation(EquitationType.Ranged);
                else
                    player.CheckEquitation(EquitationType.Attacking);
            }

            double damagebonus = 0;

            if (attacker is TMobile)
            {
                double renversant = ((TMobile)attacker).GetAptitudeValue(Aptitude.CoupRenversant) * 0.01;
                if ((defender.Mounted) && (renversant > Utility.RandomDouble()))
                {
                    BaseMount.Dismount(defender);
                    Timer.DelayCall(TimeSpan.FromSeconds(0.3), new TimerStateCallback(CantMount_Callback), defender);
                }
            }

			#region Damage Multipliers
			/*
			 * The following damage bonuses multiply damage by a factor.
			 * Capped at x3 (300%).
			 */
			//double factor = 1.0;
			int percentageBonus = 0;

			WeaponAbility a = WeaponAbility.GetCurrentAbility( attacker );
			//SpecialMove move = SpecialMove.GetCurrentMove( attacker );

			if( a != null )
			{
				//factor *= a.DamageScalar;
				percentageBonus += (int)(a.DamageScalar * 100) - 100;
			}

			//if( move != null )
			//{
				//factor *= move.GetDamageScalar( attacker, defender );
			//	percentageBonus += (int)(move.GetDamageScalar( attacker, defender ) * 100) - 100;
			//}

			//factor *= damageBonus;
			percentageBonus += (int)(damageBonus * 100) - 100;
		

			if ( !attacker.Player )
			{
				if ( defender is PlayerMobile )
				{
					PlayerMobile pm = (PlayerMobile)defender;

					if( pm.EnemyOfOneType != null && pm.EnemyOfOneType != attacker.GetType() )
					{
						//factor *= 2.0;
						percentageBonus += 100;
					}
				}
			}
			else if ( !defender.Player )
			{
				if ( attacker is PlayerMobile )
				{
					PlayerMobile pm = (PlayerMobile)attacker;

					if ( pm.WaitingForEnemy )
					{
						pm.EnemyOfOneType = defender.GetType();
						pm.WaitingForEnemy = false;
					}

					if ( pm.EnemyOfOneType == defender.GetType() )
					{
						defender.FixedEffect( 0x37B9, 10, 5, 1160, 0 );
						//factor *= 1.5;
						percentageBonus += 50;
					}
				}
			}

			int packInstinctBonus = GetPackInstinctBonus( attacker, defender );

			if( packInstinctBonus != 0 )
			{
				//factor *= 1.0 + (double)packInstinctBonus / 100.0;
				percentageBonus += packInstinctBonus;
			}

			if( m_InDoubleStrike )
			{
				//factor *= 0.9; // 10% loss when attacking with double-strike
				percentageBonus -= 10;
			}

			//TransformContext context = TransformationSpellHelper.GetContext( defender );

			//if( (m_Slayer == SlayerName.Silver || m_Slayer2 == SlayerName.Silver) && context != null && context.Spell is NecromancerSpell && context.Type != typeof( HorrificBeastSpell ) )
			//{
				//factor *= 1.25; // Every necromancer transformation other than horrific beast takes an additional 25% damage
			//	percentageBonus += 25;
			//}

			if ( attacker is PlayerMobile && !(Core.ML && defender is PlayerMobile ))
			{
				PlayerMobile pmAttacker = (PlayerMobile) attacker;

				if( pmAttacker.HonorActive && pmAttacker.InRange( defender, 1 ) )
				{
					//factor *= 1.25;
					percentageBonus += 25;
				}

				if( pmAttacker.SentHonorContext != null && pmAttacker.SentHonorContext.Target == defender )
				{
					//pmAttacker.SentHonorContext.ApplyPerfectionDamageBonus( ref factor );
					percentageBonus += pmAttacker.SentHonorContext.PerfectionDamageBonus;
				}
			}

			//if ( factor > 3.0 )
			//	factor = 3.0;

			BaseTalisman talisman = attacker.Talisman as BaseTalisman;

			if ( talisman != null && talisman.Killer != null )
				percentageBonus += talisman.Killer.DamageBonus( defender );

			percentageBonus = Math.Min( percentageBonus, 300 );

			//damage = (int)(damage * factor);
			damage = AOS.Scale( damage, 100 + percentageBonus );

            if ((this is BaseRanged) && attacker is TMobile)
                damage += Convert.ToInt32(damage * (((TMobile)attacker).GetAptitudeValue(Aptitude.TirPrecis) * 0.03));

            if (attacker is TMobile && attacker.Mounted)
                damage += Convert.ToInt32(damage * (((TMobile)attacker).GetAptitudeValue(Aptitude.CombatMonte) * 0.03));

            if (attacker is TMobile && !(attacker.Mounted))
                damage += Convert.ToInt32(damage * (((TMobile)attacker).GetAptitudeValue(Aptitude.CombatAuSol) * 0.03));

            if (defender is BaseCreature && attacker is TMobile)
                damage += Convert.ToInt32(damage * (((TMobile)attacker).GetAptitudeValue(Aptitude.TueurDeMonstre) * 0.05));

            if (attacker is TMobile)
            {
                Combat combat = new Combat(attacker, defender);
                damage += combat.CheckCriticalStrike(damage);
            }

			#endregion

            #region Techniques de Combat

            damage = TechniquesCombat.Assassinat.Bonus(attacker, defender, damage);


            #endregion


            if ( attacker is BaseCreature )
				((BaseCreature)attacker).AlterMeleeDamageTo( defender, ref damage );

			if ( defender is BaseCreature )
				((BaseCreature)defender).AlterMeleeDamageFrom( attacker, ref damage );

			damage = AbsorbDamage( attacker, defender, damage );

			if ( !Core.AOS && damage < 1 )
				damage = 1;
			else if ( Core.AOS && damage == 0 ) // parried
			{
				if ( a != null && a.Validate( attacker ) /*&& a.CheckMana( attacker, true )*/ ) // Parried special moves have no mana cost 
				{
					a = null;
					WeaponAbility.ClearCurrentAbility( attacker );

					attacker.SendLocalizedMessage( 1061140 ); // Your attack was parried!
				}
			}

            if (FortificationDivineMiracle.m_FortificationDivineTable.Contains(defender))
            {
                Mobile caster = (Mobile)FortificationDivineMiracle.m_FortificationDivineTable[defender];

                if (caster != null)
                {
                    SpellHelper.Heal(caster, (int)(Utility.Random(2, 10) + (caster.Skills[SkillName.Miracles].Value / 15)), true);
                }

                ReligiousSpell.MiracleEffet(caster, caster, 14186, 10, 15, 5014, 0, 0, EffectLayer.Waist);

                //defender.FixedParticles(8902, 9, 18, 5005, EffectLayer.Waist);
            }

			AddBlood( attacker, defender, damage );

			int phys, contondant, tranchant, perforant, magie, chaos, direct;

			GetDamageTypes( attacker, out phys, out contondant, out tranchant, out perforant, out magie, out chaos, out direct );

			/*if ( Core.ML && this is BaseRanged )
			{
				BaseQuiver quiver = attacker.FindItemOnLayer( Layer.Cloak ) as BaseQuiver;

				if ( quiver != null )
					quiver.AlterBowDamage( ref phys, ref fire, ref cold, ref pois, ref nrgy, ref chaos, ref direct );
			}*/

			if ( m_Consecrated )
			{
				phys = defender.PhysicalResistance;
				contondant = defender.ContondantResistance;
				tranchant = defender.TranchantResistance;
				perforant = defender.PerforantResistance;
				magie = defender.MagieResistance;

				int low = phys, type = 0;

                if (contondant < low) { low = contondant; type = 1; }
                if (tranchant < low) { low = tranchant; type = 2; }
                if (perforant < low) { low = perforant; type = 3; }
                if (magie < low) { low = magie; type = 4; }

                phys = contondant = tranchant = perforant = magie = chaos = direct = 0;

				if ( type == 0 ) phys = 100;
                else if (type == 1) contondant = 100;
                else if (type == 2) tranchant = 100;
                else if (type == 3) perforant = 100;
                else if (type == 4) magie = 100;
			}

			int damageGiven = damage;

			if ( a != null && !a.OnBeforeDamage( attacker, defender ) )
			{
				WeaponAbility.ClearCurrentAbility( attacker );
				a = null;
			}

			//if ( move != null && !move.OnBeforeDamage( attacker, defender ) )
			//{
			//	SpecialMove.ClearCurrentMove( attacker );
			//	move = null;
			//}

			//bool ignoreArmor = ( a is ArmorIgnore || (move != null && move.IgnoreArmor( attacker )) );
            bool ignoreArmor = (a is ArmorIgnore);

			damageGiven = AOS.Damage( defender, attacker, damage, ignoreArmor, phys, contondant, tranchant, perforant, magie, chaos, direct, false, this is BaseRanged, false );

			//double propertyBonus = ( move == null ) ? 1.0 : move.GetPropertyBonus( attacker );
            double propertyBonus = 1.0;

			if ( Core.AOS )
			{
				int lifeLeech = 0;
				int stamLeech = 0;
				int manaLeech = 0;
				//int wraithLeech = 0;

				if ( (int)(m_AosWeaponAttributes.HitLeechHits * propertyBonus) > Utility.Random( 100 ) )
					lifeLeech += 30; // HitLeechHits% chance to leech 30% of damage as hit points

				if ( (int)(m_AosWeaponAttributes.HitLeechStam * propertyBonus) > Utility.Random( 100 ) )
					stamLeech += 50; // HitLeechStam% chance to leech 100% of damage as stamina

				if ( (int)(m_AosWeaponAttributes.HitLeechMana * propertyBonus) > Utility.Random( 100 ) )
					manaLeech += 40; // HitLeechMana% chance to leech 40% of damage as mana

				if ( m_Cursed )
					lifeLeech += 50; // Additional 50% life leech for cursed weapons (necro spell)

				Spells.TransformContext context = TransformationSpellHelper.GetContext( attacker );

				if ( context != null && context.Type == typeof( VampiricEmbraceSpell ) )
					lifeLeech += 20; // Vampiric embrace gives an additional 20% life leech

				if ( context != null && context.Type == typeof( WraithFormSpell ) )
				{
					int wraithLeech = (5 + (int)((15 * attacker.Skills.Goetie.Value) / 100)); // Wraith form gives an additional 5-20% mana leech

					// Mana leeched by the Wraith Form spell is actually stolen, not just leeched.
					defender.Mana -= AOS.Scale( damageGiven, wraithLeech );

					manaLeech += wraithLeech;
				}

				if ( lifeLeech != 0 )
					attacker.Hits += AOS.Scale( damageGiven, lifeLeech );

				if ( stamLeech != 0 )
					attacker.Stam += AOS.Scale( damageGiven, stamLeech );

				if ( manaLeech != 0 )
					attacker.Mana += AOS.Scale( damageGiven, manaLeech );

				if ( lifeLeech != 0 || stamLeech != 0 || manaLeech != 0 )
					attacker.PlaySound( 0x44D );
			}

			if ( m_MaxHits > 0 && ((MaxRange <= 1 && (defender is Slime || defender is ToxicElemental)) || Utility.Random( 25 ) == 0) ) // Stratics says 50% chance, seems more like 4%..
			{
				if ( MaxRange <= 1 && (defender is Slime || defender is ToxicElemental) )
					attacker.LocalOverheadMessage( MessageType.Regular, 0x3B2, 500263 ); // *Acid blood scars your weapon!*

				if ( Core.AOS && m_AosWeaponAttributes.SelfRepair > Utility.Random( 10 ) )
				{
					HitPoints += 2;
				}
				else
				{
					if ( m_Hits > 0 )
					{
						--HitPoints;
					}
					else if ( m_MaxHits > 1 )
					{
						--MaxHitPoints;

						if ( Parent is Mobile )
							((Mobile)Parent).LocalOverheadMessage( MessageType.Regular, 0x3B2, 1061121 ); // Your equipment is severely damaged.
					}
					else
					{
						Delete();
					}
				}
			}

			if ( attacker is VampireBatFamiliar )
			{
				BaseCreature bc = (BaseCreature)attacker;
				Mobile caster = bc.ControlMaster;

				if ( caster == null )
					caster = bc.SummonMaster;

				if ( caster != null && caster.Map == bc.Map && caster.InRange( bc, 2 ) )
					caster.Hits += damage;
				else
					bc.Hits += damage;
			}

			if ( Core.AOS )
			{
				int physChance = (int)(m_AosWeaponAttributes.HitPhysicalArea * propertyBonus);

                if (physChance > 5)
                    physChance = 5;

				int contondantChance = (int)(m_AosWeaponAttributes.HitContondantArea * propertyBonus);

                if (contondantChance > 5)
                    contondantChance = 5;

				int tranchantChance = (int)(m_AosWeaponAttributes.HitTranchantArea * propertyBonus);

                if (tranchantChance > 5)
                    tranchantChance = 5;

				int perforantChance = (int)(m_AosWeaponAttributes.HitPerforantArea * propertyBonus);

                if (perforantChance > 5)
                    perforantChance = 5;
                
				int magieChance = (int)(m_AosWeaponAttributes.HitMagieArea * propertyBonus);

                if (magieChance > 5)
                    magieChance = 5;

				if ( physChance != 0 && physChance > Utility.Random( 100 ) )
					DoAreaAttack( attacker, defender, 0x10E,   50, 100, 0, 0, 0, 0 );

				if ( contondantChance != 0 && contondantChance > Utility.Random( 100 ) )
					DoAreaAttack( attacker, defender, 0x11D, 1160, 0, 100, 0, 0, 0 );

				if ( tranchantChance != 0 && tranchantChance > Utility.Random( 100 ) )
					DoAreaAttack( attacker, defender, 0x0FC, 2100, 0, 0, 100, 0, 0 );

				if ( perforantChance != 0 && perforantChance > Utility.Random( 100 ) )
					DoAreaAttack( attacker, defender, 0x205, 1166, 0, 0, 0, 100, 0 );

				if ( magieChance != 0 && magieChance > Utility.Random( 100 ) )
					DoAreaAttack( attacker, defender, 0x1F1,  120, 0, 0, 0, 0, 100 );

				int maChance = (int)(m_AosWeaponAttributes.HitMagicArrow * propertyBonus);

                if (maChance > 5)
                    maChance = 5;

				int harmChance = (int)(m_AosWeaponAttributes.HitHarm * propertyBonus);

                if (harmChance > 5)
                    harmChance = 5;

				int fireballChance = (int)(m_AosWeaponAttributes.HitFireball * propertyBonus);

                if (fireballChance > 5)
                    fireballChance = 5;

				int lightningChance = (int)(m_AosWeaponAttributes.HitLightning * propertyBonus);

                if (lightningChance > 5)
                    lightningChance = 5;

				int dispelChance = (int)(m_AosWeaponAttributes.HitDispel * propertyBonus);

                if (dispelChance > 5)
                    dispelChance = 5;

				if ( maChance != 0 && maChance > Utility.Random( 100 ) )
					DoMagicArrow( attacker, defender );

				if ( harmChance != 0 && harmChance > Utility.Random( 100 ) )
					DoHarm( attacker, defender );

				if ( fireballChance != 0 && fireballChance > Utility.Random( 100 ) )
					DoFireball( attacker, defender );

				if ( lightningChance != 0 && lightningChance > Utility.Random( 100 ) )
					DoLightning( attacker, defender );

				if ( dispelChance != 0 && dispelChance > Utility.Random( 100 ) )
					DoDispel( attacker, defender );

				int laChance = (int)(m_AosWeaponAttributes.HitLowerAttack * propertyBonus);

                if (laChance > 10)
                    laChance = 10;

				int ldChance = (int)(m_AosWeaponAttributes.HitLowerDefend * propertyBonus);

                if (ldChance > 10)
                    ldChance = 10;

				if ( laChance != 0 && laChance > Utility.Random( 100 ) )
					DoLowerAttack( attacker, defender );

				if ( ldChance != 0 && ldChance > Utility.Random( 100 ) )
					DoLowerDefense( attacker, defender );
			}

			if ( attacker is BaseCreature )
				((BaseCreature)attacker).OnGaveMeleeAttack( defender );

			if ( defender is BaseCreature )
				((BaseCreature)defender).OnGotMeleeAttack( attacker );

            if (Poison != null && PoisonCharges > 0)
            {
                --PoisonCharges;

                if (Utility.RandomDouble() >= 0.5) // 50% chance to poison
                    defender.ApplyPoison(attacker, Poison);
            }

			if ( a != null )
				a.OnHit( attacker, defender, damage );

			//if ( move != null )
			//	move.OnHit( attacker, defender, damage );

			if ( defender is IHonorTarget && ((IHonorTarget)defender).ReceivedHonorContext != null )
				((IHonorTarget)defender).ReceivedHonorContext.OnTargetHit( attacker );

			/*if ( !(this is BaseRanged) )
			{
				if ( AnimalForm.UnderTransformation( attacker, typeof( GiantSerpent ) ) )
					defender.ApplyPoison( attacker, Poison.Lesser );

				if ( AnimalForm.UnderTransformation( defender, typeof( BullFrog ) ) )
					attacker.ApplyPoison( defender, Poison.Regular );
			}*/
		}

		public virtual double GetAosDamage( Mobile attacker, int bonus, int dice, int sides )
		{
			int damage = Utility.Dice( dice, sides, bonus ) * 100;
			int damageBonus = 0;

			// Inscription bonus
			int inscribeSkill = attacker.Skills[SkillName.Inscription].Fixed;

			damageBonus += inscribeSkill / 200;

			if ( inscribeSkill >= 1000 )
				damageBonus += 5;

			if ( attacker.Player )
			{
				// Int bonus
				damageBonus += (attacker.Int / 10);

                int aosBonus = AosAttributes.GetValue(attacker, AosAttribute.SpellDamage);

				// SDI bonus
                damageBonus += aosBonus;

				//TransformContext context = TransformationSpellHelper.GetContext( attacker );

				//if( context != null && context.Spell is ReaperFormSpell )
				//	damageBonus += ((ReaperFormSpell)context.Spell).SpellDamageBonus;
			}

			damage = AOS.Scale( damage, 100 + damageBonus );

			return damage / 100;
		}

		#region Do<AoSEffect>
		public virtual void DoMagicArrow( Mobile attacker, Mobile defender )
		{
			if ( !attacker.CanBeHarmful( defender, false ) )
				return;

			attacker.DoHarmful( defender );

			double damage = GetAosDamage( attacker, 10, 1, 4 );

			attacker.MovingParticles( defender, 0x36E4, 5, 0, false, true, 3006, 4006, 0 );
			attacker.PlaySound( 0x1E5 );

			SpellHelper.Damage( TimeSpan.FromSeconds( 1.0 ), defender, attacker, damage, 0, 0, 0, 0, 100 );
		}

		public virtual void DoHarm( Mobile attacker, Mobile defender )
		{
			if ( !attacker.CanBeHarmful( defender, false ) )
				return;

			attacker.DoHarmful( defender );

			double damage = GetAosDamage( attacker, 17, 1, 5 );

			if ( !defender.InRange( attacker, 2 ) )
				damage *= 0.25; // 1/4 damage at > 2 tile range
			else if ( !defender.InRange( attacker, 1 ) )
				damage *= 0.50; // 1/2 damage at 2 tile range

			defender.FixedParticles( 0x374A, 10, 30, 5013, 1153, 2, EffectLayer.Waist );
			defender.PlaySound( 0x0FC );

			SpellHelper.Damage( TimeSpan.Zero, defender, attacker, damage, 0, 0, 0, 0, 100 );
		}

		public virtual void DoFireball( Mobile attacker, Mobile defender )
		{
			if ( !attacker.CanBeHarmful( defender, false ) )
				return;

			attacker.DoHarmful( defender );

			double damage = GetAosDamage( attacker, 19, 1, 5 );

			attacker.MovingParticles( defender, 0x36D4, 7, 0, false, true, 9502, 4019, 0x160 );
			attacker.PlaySound( 0x15E );

			SpellHelper.Damage( TimeSpan.FromSeconds( 1.0 ), defender, attacker, damage, 0, 0, 0, 0, 100 );
		}

		public virtual void DoLightning( Mobile attacker, Mobile defender )
		{
			if ( !attacker.CanBeHarmful( defender, false ) )
				return;

			attacker.DoHarmful( defender );

			double damage = GetAosDamage( attacker, 23, 1, 4 );

			defender.BoltEffect( 0 );

			SpellHelper.Damage( TimeSpan.Zero, defender, attacker, damage, 0, 0, 0, 0, 100 );
		}

		public virtual void DoDispel( Mobile attacker, Mobile defender )
		{
			bool dispellable = false;

			if ( defender is BaseCreature )
				dispellable = ((BaseCreature)defender).Summoned && !((BaseCreature)defender).IsAnimatedDead;

			if ( !dispellable )
				return;

			if ( !attacker.CanBeHarmful( defender, false ) )
				return;

			attacker.DoHarmful( defender );

			Spells.DisparitionSpell sp = new Spells.DisparitionSpell( attacker, null );

			if ( sp.CheckResisted( defender ) )
			{
				defender.FixedEffect( 0x3779, 10, 20 );
			}
			else
			{
				Effects.SendLocationParticles( EffectItem.Create( defender.Location, defender.Map, EffectItem.DefaultDuration ), 0x3728, 8, 20, 5042 );
				Effects.PlaySound( defender, defender.Map, 0x201 );

				defender.Delete();
			}
		}

		public virtual void DoLowerAttack( Mobile from, Mobile defender )
		{
			if ( HitLower.ApplyAttack( defender ) )
			{
				defender.PlaySound( 0x28E );
				Effects.SendTargetEffect( defender, 0x37BE, 1, 4, 0xA, 3 );
			}
		}

		public virtual void DoLowerDefense( Mobile from, Mobile defender )
		{
			if ( HitLower.ApplyDefense( defender ) )
			{
				defender.PlaySound( 0x28E );
				Effects.SendTargetEffect( defender, 0x37BE, 1, 4, 0x23, 3 );
			}
		}

		public virtual void DoAreaAttack( Mobile from, Mobile defender, int sound, int hue, int phys, int contondant, int tranchant, int perforant, int magie )
		{
			Map map = from.Map;

			if ( map == null )
				return;

			List<Mobile> list = new List<Mobile>();

			foreach ( Mobile m in from.GetMobilesInRange( 10 ) )
			{
				if ( from != m && defender != m && SpellHelper.ValidIndirectTarget( from, m ) && from.CanBeHarmful( m, false ) && ( !Core.ML || from.InLOS( m ) ) && !(from.Party == m.Party))
					list.Add( m );
			}

			if ( list.Count == 0 )
				return;

			Effects.PlaySound( from.Location, map, sound );

			// TODO: What is the damage calculation?

			for ( int i = 0; i < list.Count; ++i )
			{
				Mobile m = list[i];

				double scalar = (11 - from.GetDistanceToSqrt( m )) / 10;

				if ( scalar > 1.0 )
					scalar = 1.0;
				else if ( scalar < 0.0 )
					continue;

				from.DoHarmful( m, true );
				//m.FixedEffect( 0x3779, 1, 15, hue, 0 );
				AOS.Damage( m, from, (int)(GetBaseDamage( from ) * scalar), phys, contondant, tranchant, perforant, magie );
			}
		}
		#endregion

		public virtual void AddBlood( Mobile attacker, Mobile defender, int damage )
		{
			if ( damage > 0 )
			{
				new Blood().MoveToWorld( defender.Location, defender.Map );

				int extraBlood = (Core.SE ? Utility.RandomMinMax( 3, 4 ) : Utility.RandomMinMax( 0, 1 ) );

				for( int i = 0; i < extraBlood; i++ )
				{
					new Blood().MoveToWorld( new Point3D(
						defender.X + Utility.RandomMinMax( -1, 1 ),
						defender.Y + Utility.RandomMinMax( -1, 1 ),
						defender.Z ), defender.Map );
				}
			}
		}

		public virtual void GetDamageTypes( Mobile wielder, out int phys, out int contondant, out int tranchant, out int perforant, out int magie, out int chaos, out int direct )
		{
			if( wielder is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)wielder;

				phys = bc.PhysicalDamage;
				contondant = bc.ContondantDamage;
				tranchant = bc.TranchantDamage;
				perforant = bc.PerforantDamage;
				magie = bc.MagieDamage;
				chaos = bc.ChaosDamage;
				direct = bc.DirectDamage;
			}
			else
			{
				contondant = m_AosElementDamages.Contondant;
				tranchant = m_AosElementDamages.Tranchant;
				perforant = m_AosElementDamages.Perforant;
				magie = m_AosElementDamages.Magie;
				chaos = m_AosElementDamages.Chaos;
				direct = m_AosElementDamages.Direct;

				phys = 100 - contondant - tranchant - perforant - magie - chaos - direct;

				CraftResourceInfo resInfo = CraftResources.GetInfo( m_Resource );

				if( resInfo != null )
				{
					CraftAttributeInfo attrInfo = resInfo.AttributeInfo;

					if( attrInfo != null )
					{
						int left = phys;

						left = ApplyCraftAttributeElementDamage( attrInfo.WeaponTranchantDamage,    ref tranchant, left );
						left = ApplyCraftAttributeElementDamage( attrInfo.WeaponMagieDamage,	    ref magie, left );
						left = ApplyCraftAttributeElementDamage( attrInfo.WeaponContondantDamage,	ref contondant, left );
						left = ApplyCraftAttributeElementDamage( attrInfo.WeaponPerforantDamage,    ref perforant, left );
						left = ApplyCraftAttributeElementDamage( attrInfo.WeaponChaosDamage,	    ref chaos, left );
						left = ApplyCraftAttributeElementDamage( attrInfo.WeaponDirectDamage,	    ref direct, left );

						phys = left;
					}
				}
			}
		}

		private int ApplyCraftAttributeElementDamage( int attrDamage, ref int element, int totalRemaining )
		{
			if( totalRemaining <= 0 )
				return 0;

			if ( attrDamage <= 0 )
				return totalRemaining;

			int appliedDamage = attrDamage;

			if ( (appliedDamage + element) > 100 )
				appliedDamage = 100 - element;

			if( appliedDamage > totalRemaining )
				appliedDamage = totalRemaining;

			element += appliedDamage;

			return totalRemaining - appliedDamage;
		}

		public virtual void OnMiss( Mobile attacker, Mobile defender )
		{
			PlaySwingAnimation( attacker );
			attacker.PlaySound( GetMissAttackSound( attacker, defender ) );
			defender.PlaySound( GetMissDefendSound( attacker, defender ) );

			WeaponAbility ability = WeaponAbility.GetCurrentAbility( attacker );

			if ( ability != null )
				ability.OnMiss( attacker, defender );

			//SpecialMove move = SpecialMove.GetCurrentMove( attacker );

			//if ( move != null )
			//	move.OnMiss( attacker, defender );

			if ( defender is IHonorTarget && ((IHonorTarget)defender).ReceivedHonorContext != null )
				((IHonorTarget)defender).ReceivedHonorContext.OnTargetMissed( attacker );
		}

		public virtual void GetBaseDamageRange( Mobile attacker, out int min, out int max )
		{
			if ( attacker is BaseCreature )
			{
				BaseCreature c = (BaseCreature)attacker;

				if ( c.DamageMin >= 0 )
				{
					min = c.DamageMin;
					max = c.DamageMax;
					return;
				}

				/*if ( this is Fists && !attacker.Body.IsHuman )
				{
					min = attacker.Str / 28;
					max = attacker.Str / 28;
					return;
				}*/
			}

			min = MinDamage;
			max = MaxDamage;
		}

		public virtual double GetBaseDamage( Mobile attacker )
		{
			int min, max;

			GetBaseDamageRange( attacker, out min, out max );

			return Utility.RandomMinMax( min, max );
		}

		public virtual int GetHitChanceBonus()
		{
			if ( !Core.AOS )
				return 0;

			int bonus = 0;

			switch ( m_AccuracyLevel )
			{
				case WeaponAccuracyLevel.Accurate:		bonus += 02; break;
				case WeaponAccuracyLevel.Surpassingly:	bonus += 04; break;
				case WeaponAccuracyLevel.Eminently:		bonus += 06; break;
				case WeaponAccuracyLevel.Exceedingly:	bonus += 08; break;
				case WeaponAccuracyLevel.Supremely:		bonus += 10; break;
			}

			return bonus;
		}

		public virtual int GetDamageBonus()
		{
			int bonus = VirtualDamageBonus;

			switch ( m_Quality )
			{
				case WeaponQuality.Low:			bonus -= 20; break;
				case WeaponQuality.Exceptional:	bonus += 20; break;
			}

			switch ( m_DamageLevel )
			{
				case WeaponDamageLevel.Ruin:	bonus += 15; break;
				case WeaponDamageLevel.Might:	bonus += 20; break;
				case WeaponDamageLevel.Force:	bonus += 25; break;
				case WeaponDamageLevel.Power:	bonus += 30; break;
				case WeaponDamageLevel.Vanq:	bonus += 35; break;
			}

			return bonus;
		}

		public virtual void GetStatusDamage( Mobile from, out int min, out int max )
		{
			int baseMin, baseMax;

			GetBaseDamageRange( from, out baseMin, out baseMax );

			if ( Core.AOS )
			{
				min = Math.Max( (int)ScaleDamageAOS( from, baseMin, false ), 1 );
				max = Math.Max( (int)ScaleDamageAOS( from, baseMax, false ), 1 );
			}
			else
			{
				min = Math.Max( (int)ScaleDamageOld( from, baseMin, false ), 1 );
				max = Math.Max( (int)ScaleDamageOld( from, baseMax, false ), 1 );
			}
		}

		public virtual double ScaleDamageAOS( Mobile attacker, double damage, bool checkSkills )
		{
            if (attacker is BaseCreature)
            {
                return damage;
            }
            else
            {
                if (checkSkills)
                {
                    //attacker.CheckSkill(SkillName.Tactiques, 0.0, attacker.Skills[SkillName.Tactiques].Cap); // Passively check tactics for gain
                    //attacker.CheckSkill( SkillName.Anatomy, 0.0, attacker.Skills[SkillName.Anatomy].Cap ); // Passively check Anatomy for gain

                    /*if (Type == WeaponType.Axe)
                        attacker.CheckSkill(SkillName.Foresterie, 0.0, 100.0); // Passively check Lumberjacking for gain*/
                }

                #region Physical bonuses
                /*
			     * These are the bonuses given by the physical characteristics of the mobile.
			     * No caps apply.
			     */

                //double strengthBonus = GetBonus(attacker.Str, 0.100, 30.0, 5.00);
                //double  anatomyBonus = GetBonus( attacker.Skills[SkillName.Anatomy].Value,			0.500, 100.0,  5.00 );
                //double tacticsBonus = GetBonus(attacker.Skills[SkillName.Tactiques].Value, 0.100, 50.0, 6.25);
                //double   lumberBonus = GetBonus( attacker.Skills[SkillName.Foresterie].Value,	0.200, 100.0, 10.00 );

                //Console.WriteLine("Strength Bonus : " + strengthBonus.ToString());
                //Console.WriteLine("Tactic Bonus : " + tacticsBonus.ToString());

                //if ( Type != WeaponType.Axe )
                //	lumberBonus = 0.0;
                #endregion

                #region Modifiers
                /*
			     * The following are damage modifiers whose effect shows on the status bar.
			     * Capped at 100% total.
			     */
                int damageBonus = AosAttributes.GetValue(attacker, AosAttribute.WeaponDamage);

                if (damageBonus > 10)
                    damageBonus = 10;

                // Horrific Beast transformation gives a +25% bonus to damage.
                if (TransformationSpellHelper.UnderTransformation(attacker, typeof(HorrificBeastSpell)))
                    damageBonus += 5;

                // Divine Fury gives a +10% bonus to damage.
                //if ( Spells.Chivalry.DivineFurySpell.UnderEffect( attacker ) )
                //	damageBonus += 10;

                int defenseMasteryMalus = 0;

                // Defense Mastery gives a -50%/-80% malus to damage.
                if (Server.Items.DefenseMastery.GetMalus(attacker, ref defenseMasteryMalus))
                    damageBonus -= defenseMasteryMalus;

                //int discordanceEffect = 0;

                // Discordance gives a -2%/-48% malus to damage.
                //if ( SkillHandlers.Discordance.GetEffect( attacker, ref discordanceEffect ) )
                //	damageBonus -= discordanceEffect * 2;

                if (damageBonus > 100)
                    damageBonus = 100;
                #endregion

                //double totalBonus = strengthBonus + anatomyBonus + tacticsBonus + lumberBonus + ((double)(GetDamageBonus() + damageBonus) / 100.0);
                double totalBonus = 0; //strengthBonus + tacticsBonus + ((double)(GetDamageBonus() + damageBonus) / 100.0);

                //Console.WriteLine("Total Bonus : " + totalBonus.ToString());
                //Console.WriteLine("Damage Avant : " + damage.ToString());
                //Console.WriteLine("Damage Après : " + (damage + (int)(damage * totalBonus)).ToString());


                return damage + (int)(damage * totalBonus);


            }
		}

		public virtual int VirtualDamageBonus{ get{ return 0; } }

		public virtual int ComputeDamageAOS( Mobile attacker, Mobile defender )
		{
			return (int)ScaleDamageAOS( attacker, GetBaseDamage( attacker ), true );
		}

		public virtual double ScaleDamageOld( Mobile attacker, double damage, bool checkSkills )
		{
			if ( checkSkills )
			{
				attacker.CheckSkill( SkillName.Tactiques, 0.0, attacker.Skills[SkillName.Tactiques].Cap ); // Passively check tactics for gain
				//attacker.CheckSkill( SkillName.Anatomy, 0.0, attacker.Skills[SkillName.Anatomy].Cap ); // Passively check Anatomy for gain

				if ( Type == WeaponType.Axe )
					attacker.CheckSkill( SkillName.Foresterie, 0.0, 100.0 ); // Passively check Lumberjacking for gain
			}

			/* Compute tactics modifier
			 * :   0.0 = 50% loss
			 * :  50.0 = unchanged
			 * : 100.0 = 50% bonus
			 */
			double tacticsBonus = (attacker.Skills[SkillName.Tactiques].Value - 50.0) / 100.0;

			/* Compute strength modifier
			 * : 1% bonus for every 5 strength
			 */
			double strBonus = (attacker.Str / 5.0) / 100.0;

			/* Compute anatomy modifier
			 * : 1% bonus for every 5 points of anatomy
			 * : +10% bonus at Grandmaster or higher
			 */
			//double anatomyValue = attacker.Skills[SkillName.Anatomy].Value;
			//double anatomyBonus = (anatomyValue / 5.0) / 100.0;

			//if ( anatomyValue >= 100.0 )
			//	anatomyBonus += 0.1;

			/* Compute lumberjacking bonus
			 * : 1% bonus for every 5 points of lumberjacking
			 * : +10% bonus at Grandmaster or higher
			 */
			//double lumberBonus;

			//if ( Type == WeaponType.Axe )
			//{
			//	double lumberValue = attacker.Skills[SkillName.Foresterie].Value;
            //
			//	lumberBonus = (lumberValue / 5.0) / 100.0;
            //
			//	if ( lumberValue >= 100.0 )
			//		lumberBonus += 0.1;
			//}
			//else
			//{
			//	lumberBonus = 0.0;
			//}

			// New quality bonus:
			double qualityBonus = ((int)m_Quality - 1) * 0.2;

			// Apply bonuses
			//damage += (damage * tacticsBonus) + (damage * strBonus) + (damage * anatomyBonus) + (damage * lumberBonus) + (damage * qualityBonus) + ((damage * VirtualDamageBonus) / 100);
            damage += (damage * tacticsBonus) + (damage * strBonus) + (damage * qualityBonus) + ((damage * VirtualDamageBonus) / 100);

			// Old quality bonus:
#if false
			/* Apply quality offset
			 * : Low         : -4
			 * : Regular     :  0
			 * : Exceptional : +4
			 */
			damage += ((int)m_Quality - 1) * 4.0;
#endif

			/* Apply damage level offset
			 * : Regular : 0
			 * : Ruin    : 1
			 * : Might   : 3
			 * : Force   : 5
			 * : Power   : 7
			 * : Vanq    : 9
			 */
			if ( m_DamageLevel != WeaponDamageLevel.Regular )
				damage += (2.0 * (int)m_DamageLevel) - 1.0;

			// Halve the computed damage and return
			damage /= 2.0;

			return ScaleDamageByDurability( (int)damage );
		}

		public virtual int ScaleDamageByDurability( int damage )
		{
			int scale = 100;

			if ( m_MaxHits > 0 && m_Hits < m_MaxHits )
				scale = 50 + ((50 * m_Hits) / m_MaxHits);

			return AOS.Scale( damage, scale );
		}

		public virtual int ComputeDamage( Mobile attacker, Mobile defender )
		{
			if ( Core.AOS )
				return ComputeDamageAOS( attacker, defender );

			return (int)ScaleDamageOld( attacker, GetBaseDamage( attacker ), true );
		}

		public virtual void PlayHurtAnimation( Mobile from )
		{
			int action;
			int frames;

			switch ( from.Body.Type )
			{
				case BodyType.Sea:
				case BodyType.Animal:
				{
					action = 7;
					frames = 5;
					break;
				}
				case BodyType.Monster:
				{
					action = 10;
					frames = 4;
					break;
				}
				case BodyType.Human:
				{
					action = 20;
					frames = 5;
					break;
				}
				default: return;
			}

			if ( from.Mounted )
				return;

			from.Animate( action, frames, 1, true, false, 0 );
		}

		public virtual void PlaySwingAnimation( Mobile from )
		{
			int action;

			switch ( from.Body.Type )
			{
				case BodyType.Sea:
				case BodyType.Animal:
				{
					action = Utility.Random( 5, 2 );
					break;
				}
				case BodyType.Monster:
				{
					switch ( Animation )
					{
						default:
						case WeaponAnimation.Wrestle:
						case WeaponAnimation.Bash1H:
						case WeaponAnimation.Pierce1H:
						case WeaponAnimation.Slash1H:
						case WeaponAnimation.Bash2H:
						case WeaponAnimation.Pierce2H:
						case WeaponAnimation.Slash2H: action = Utility.Random( 4, 3 ); break;
						case WeaponAnimation.ShootBow:  return; // 7
						case WeaponAnimation.ShootXBow: return; // 8
					}

					break;
				}
				case BodyType.Human:
				{
					if ( !from.Mounted )
					{
						action = (int)Animation;
					}
					else
					{
						switch ( Animation )
						{
							default:
							case WeaponAnimation.Wrestle:
							case WeaponAnimation.Bash1H:
							case WeaponAnimation.Pierce1H:
							case WeaponAnimation.Slash1H: action = 26; break;
							case WeaponAnimation.Bash2H:
							case WeaponAnimation.Pierce2H:
							case WeaponAnimation.Slash2H: action = 29; break;
							case WeaponAnimation.ShootBow: action = 27; break;
							case WeaponAnimation.ShootXBow: action = 28; break;
						}
					}

					break;
				}
				default: return;
			}

			from.Animate( action, 7, 1, true, false, 0 );
		}

		#region Serialization/Deserialization
		private static void SetSaveFlag( ref SaveFlag flags, SaveFlag toSet, bool setIf )
		{
			if ( setIf )
				flags |= toSet;
		}

		private static bool GetSaveFlag( SaveFlag flags, SaveFlag toGet )
		{
			return ( (flags & toGet) != 0 );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 10 ); // version

            writer.Write((int)m_rarete);
            m_TemraelAttributes.Serialize(writer);

			SaveFlag flags = SaveFlag.None;

			SetSaveFlag( ref flags, SaveFlag.DamageLevel,		m_DamageLevel != WeaponDamageLevel.Regular );
			SetSaveFlag( ref flags, SaveFlag.AccuracyLevel,		m_AccuracyLevel != WeaponAccuracyLevel.Regular );
			SetSaveFlag( ref flags, SaveFlag.DurabilityLevel,	m_DurabilityLevel != WeaponDurabilityLevel.Regular );
			SetSaveFlag( ref flags, SaveFlag.Quality,			m_Quality != WeaponQuality.Regular );
			SetSaveFlag( ref flags, SaveFlag.Hits,				m_Hits != 0 );
			SetSaveFlag( ref flags, SaveFlag.MaxHits,			m_MaxHits != 0 );
			SetSaveFlag( ref flags, SaveFlag.Poison,			m_Poison != null );
			SetSaveFlag( ref flags, SaveFlag.PoisonCharges,		m_PoisonCharges != 0 );
			SetSaveFlag( ref flags, SaveFlag.Crafter,			m_Crafter != null );
            SetSaveFlag( ref flags, SaveFlag.CrafterName,       m_CrafterName != null);
			SetSaveFlag( ref flags, SaveFlag.Identified,		m_Identified != false );
			SetSaveFlag( ref flags, SaveFlag.StrReq,			m_StrReq != -1 );
			SetSaveFlag( ref flags, SaveFlag.DexReq,			m_DexReq != -1 );
			SetSaveFlag( ref flags, SaveFlag.IntReq,			m_IntReq != -1 );
			SetSaveFlag( ref flags, SaveFlag.MinDamage,			m_MinDamage != -1 );
			SetSaveFlag( ref flags, SaveFlag.MaxDamage,			m_MaxDamage != -1 );
			SetSaveFlag( ref flags, SaveFlag.HitSound,			m_HitSound != -1 );
			SetSaveFlag( ref flags, SaveFlag.MissSound,			m_MissSound != -1 );
			SetSaveFlag( ref flags, SaveFlag.Speed,				m_Speed != -1 );
			SetSaveFlag( ref flags, SaveFlag.MaxRange,			m_MaxRange != -1 );
			SetSaveFlag( ref flags, SaveFlag.Skill,				m_Skill != (SkillName)(-1) );
			SetSaveFlag( ref flags, SaveFlag.Type,				m_Type != (WeaponType)(-1) );
			SetSaveFlag( ref flags, SaveFlag.Animation,			m_Animation != (WeaponAnimation)(-1) );
			SetSaveFlag( ref flags, SaveFlag.Resource,			m_Resource != CraftResource.Fer );
			SetSaveFlag( ref flags, SaveFlag.xAttributes,		!m_AosAttributes.IsEmpty );
			SetSaveFlag( ref flags, SaveFlag.xWeaponAttributes,	!m_AosWeaponAttributes.IsEmpty );
			SetSaveFlag( ref flags, SaveFlag.PlayerConstructed,	m_PlayerConstructed );
			SetSaveFlag( ref flags, SaveFlag.SkillBonuses,		!m_AosSkillBonuses.IsEmpty );
			SetSaveFlag( ref flags, SaveFlag.ElementalDamages,	!m_AosElementDamages.IsEmpty );

			writer.Write( (int) flags );

			if ( GetSaveFlag( flags, SaveFlag.DamageLevel ) )
				writer.Write( (int) m_DamageLevel );

			if ( GetSaveFlag( flags, SaveFlag.AccuracyLevel ) )
				writer.Write( (int) m_AccuracyLevel );

			if ( GetSaveFlag( flags, SaveFlag.DurabilityLevel ) )
				writer.Write( (int) m_DurabilityLevel );

			if ( GetSaveFlag( flags, SaveFlag.Quality ) )
				writer.Write( (int) m_Quality );

			if ( GetSaveFlag( flags, SaveFlag.Hits ) )
				writer.Write( (int) m_Hits );

			if ( GetSaveFlag( flags, SaveFlag.MaxHits ) )
				writer.Write( (int) m_MaxHits );

			if ( GetSaveFlag( flags, SaveFlag.Poison ) )
				Poison.Serialize( m_Poison, writer );

			if ( GetSaveFlag( flags, SaveFlag.PoisonCharges ) )
				writer.Write( (int) m_PoisonCharges );

			if ( GetSaveFlag( flags, SaveFlag.Crafter ) )
				writer.Write( (Mobile) m_Crafter );

            if (GetSaveFlag(flags, SaveFlag.CrafterName))
                writer.Write((string)m_CrafterName);

			if ( GetSaveFlag( flags, SaveFlag.StrReq ) )
				writer.Write( (int) m_StrReq );

			if ( GetSaveFlag( flags, SaveFlag.DexReq ) )
				writer.Write( (int) m_DexReq );

			if ( GetSaveFlag( flags, SaveFlag.IntReq ) )
				writer.Write( (int) m_IntReq );

			if ( GetSaveFlag( flags, SaveFlag.MinDamage ) )
				writer.Write( (int) m_MinDamage );

			if ( GetSaveFlag( flags, SaveFlag.MaxDamage ) )
				writer.Write( (int) m_MaxDamage );

			if ( GetSaveFlag( flags, SaveFlag.HitSound ) )
				writer.Write( (int) m_HitSound );

			if ( GetSaveFlag( flags, SaveFlag.MissSound ) )
				writer.Write( (int) m_MissSound );

			if ( GetSaveFlag( flags, SaveFlag.Speed ) )
				writer.Write( (float) m_Speed );

			if ( GetSaveFlag( flags, SaveFlag.MaxRange ) )
				writer.Write( (int) m_MaxRange );

			if ( GetSaveFlag( flags, SaveFlag.Skill ) )
				writer.Write( (int) m_Skill );

			if ( GetSaveFlag( flags, SaveFlag.Type ) )
				writer.Write( (int) m_Type );

			if ( GetSaveFlag( flags, SaveFlag.Animation ) )
				writer.Write( (int) m_Animation );

			if ( GetSaveFlag( flags, SaveFlag.Resource ) )
				writer.Write( (int) m_Resource );

			if ( GetSaveFlag( flags, SaveFlag.xAttributes ) )
				m_AosAttributes.Serialize( writer );

			if ( GetSaveFlag( flags, SaveFlag.xWeaponAttributes ) )
				m_AosWeaponAttributes.Serialize( writer );

			if ( GetSaveFlag( flags, SaveFlag.SkillBonuses ) )
				m_AosSkillBonuses.Serialize( writer );
			if( GetSaveFlag( flags, SaveFlag.ElementalDamages ) )
				m_AosElementDamages.Serialize( writer );

		}

		[Flags]
		private enum SaveFlag
		{
			None					= 0x00000000,
			DamageLevel				= 0x00000001,
			AccuracyLevel			= 0x00000002,
			DurabilityLevel			= 0x00000004,
			Quality					= 0x00000008,
			Hits					= 0x00000010,
			MaxHits					= 0x00000020,
			//Slayer					= 0x00000040,
			Poison					= 0x00000080,
			PoisonCharges			= 0x00000100,
			Crafter					= 0x00000200,
			Identified				= 0x00000400,
			StrReq					= 0x00000800,
			DexReq					= 0x00001000,
			IntReq					= 0x00002000,
			MinDamage				= 0x00004000,
			MaxDamage				= 0x00008000,
			HitSound				= 0x00010000,
			MissSound				= 0x00020000,
			Speed					= 0x00040000,
			MaxRange				= 0x00080000,
			Skill					= 0x00100000,
			Type					= 0x00200000,
			Animation				= 0x00400000,
			Resource				= 0x00800000,
			xAttributes				= 0x01000000,
			xWeaponAttributes		= 0x02000000,
			PlayerConstructed		= 0x04000000,
			SkillBonuses			= 0x08000000,
			//Slayer2					= 0x10000000,
			ElementalDamages		= 0x20000000,
			CrafterName 			= 0x40000000,
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
                case 10:
                    m_rarete = (RareteItem)reader.ReadInt();
                    m_rarete = RareteItem.Normal;
                    m_TemraelAttributes = new TemraelAttributes(this, reader);
                    goto case 9;
				case 9:
				case 8:
				case 7:
				case 6:
				case 5:
				{
					SaveFlag flags = (SaveFlag)reader.ReadInt();

					if ( GetSaveFlag( flags, SaveFlag.DamageLevel ) )
					{
						m_DamageLevel = (WeaponDamageLevel)reader.ReadInt();

						if ( m_DamageLevel > WeaponDamageLevel.Vanq )
							m_DamageLevel = WeaponDamageLevel.Ruin;
					}

					if ( GetSaveFlag( flags, SaveFlag.AccuracyLevel ) )
					{
						m_AccuracyLevel = (WeaponAccuracyLevel)reader.ReadInt();

						if ( m_AccuracyLevel > WeaponAccuracyLevel.Supremely )
							m_AccuracyLevel = WeaponAccuracyLevel.Accurate;
					}

					if ( GetSaveFlag( flags, SaveFlag.DurabilityLevel ) )
					{
						m_DurabilityLevel = (WeaponDurabilityLevel)reader.ReadInt();

						if ( m_DurabilityLevel > WeaponDurabilityLevel.Indestructible )
							m_DurabilityLevel = WeaponDurabilityLevel.Durable;
					}

					if ( GetSaveFlag( flags, SaveFlag.Quality ) )
						m_Quality = (WeaponQuality)reader.ReadInt();
					else
						m_Quality = WeaponQuality.Regular;

					if ( GetSaveFlag( flags, SaveFlag.Hits ) )
						m_Hits = reader.ReadInt();

					if ( GetSaveFlag( flags, SaveFlag.MaxHits ) )
						m_MaxHits = reader.ReadInt();

					if ( GetSaveFlag( flags, SaveFlag.Poison ) )
						m_Poison = Poison.Deserialize( reader );

					if ( GetSaveFlag( flags, SaveFlag.PoisonCharges ) )
						m_PoisonCharges = reader.ReadInt();

					if ( GetSaveFlag( flags, SaveFlag.Crafter ) )
						m_Crafter = reader.ReadMobile();

                    if (GetSaveFlag(flags, SaveFlag.CrafterName))
                        m_CrafterName = reader.ReadString();

					if ( GetSaveFlag( flags, SaveFlag.Identified ) )
						m_Identified = ( version >= 6 || reader.ReadBool() );

					if ( GetSaveFlag( flags, SaveFlag.StrReq ) )
						m_StrReq = reader.ReadInt();
					else
						m_StrReq = -1;

					if ( GetSaveFlag( flags, SaveFlag.DexReq ) )
						m_DexReq = reader.ReadInt();
					else
						m_DexReq = -1;

					if ( GetSaveFlag( flags, SaveFlag.IntReq ) )
						m_IntReq = reader.ReadInt();
					else
						m_IntReq = -1;

					if ( GetSaveFlag( flags, SaveFlag.MinDamage ) )
						m_MinDamage = reader.ReadInt();
					else
						m_MinDamage = -1;

					if ( GetSaveFlag( flags, SaveFlag.MaxDamage ) )
						m_MaxDamage = reader.ReadInt();
					else
						m_MaxDamage = -1;

					if ( GetSaveFlag( flags, SaveFlag.HitSound ) )
						m_HitSound = reader.ReadInt();
					else
						m_HitSound = -1;

					if ( GetSaveFlag( flags, SaveFlag.MissSound ) )
						m_MissSound = reader.ReadInt();
					else
						m_MissSound = -1;

					if ( GetSaveFlag( flags, SaveFlag.Speed ) )
					{
						if ( version < 9 )
							m_Speed = reader.ReadInt();
						else
							m_Speed = reader.ReadFloat();
					}
					else
						m_Speed = -1;

					if ( GetSaveFlag( flags, SaveFlag.MaxRange ) )
						m_MaxRange = reader.ReadInt();
					else
						m_MaxRange = -1;

					if ( GetSaveFlag( flags, SaveFlag.Skill ) )
						m_Skill = (SkillName)reader.ReadInt();
					else
						m_Skill = (SkillName)(-1);

					if ( GetSaveFlag( flags, SaveFlag.Type ) )
						m_Type = (WeaponType)reader.ReadInt();
					else
						m_Type = (WeaponType)(-1);

					if ( GetSaveFlag( flags, SaveFlag.Animation ) )
						m_Animation = (WeaponAnimation)reader.ReadInt();
					else
						m_Animation = (WeaponAnimation)(-1);

					if ( GetSaveFlag( flags, SaveFlag.Resource ) )
						m_Resource = (CraftResource)reader.ReadInt();
					else
						m_Resource = CraftResource.Fer;

                    if (GetSaveFlag(flags, SaveFlag.xAttributes))
                    {
                        m_AosAttributes = new AosAttributes(this, reader);
                        m_AosAttributes = new AosAttributes(this);
                    }
                    else
                        m_AosAttributes = new AosAttributes(this);

                    if (GetSaveFlag(flags, SaveFlag.xWeaponAttributes))
                    {
                        m_AosWeaponAttributes = new AosWeaponAttributes(this, reader);
                        m_AosWeaponAttributes = new AosWeaponAttributes(this);
                    }
                    else
                        m_AosWeaponAttributes = new AosWeaponAttributes(this);

					if ( UseSkillMod && m_AccuracyLevel != WeaponAccuracyLevel.Regular && Parent is Mobile )
					{
						m_SkillMod = new DefaultSkillMod( AccuracySkill, true, (int)m_AccuracyLevel * 5 );
						((Mobile)Parent).AddSkillMod( m_SkillMod );
					}

					if ( version < 7 && m_AosWeaponAttributes.MageWeapon != 0 )
						m_AosWeaponAttributes.MageWeapon = 30 - m_AosWeaponAttributes.MageWeapon;

					if ( Core.AOS && m_AosWeaponAttributes.MageWeapon != 0 && m_AosWeaponAttributes.MageWeapon != 30 && Parent is Mobile )
					{
						m_MageMod = new DefaultSkillMod( SkillName.ArtMagique, true, -30 + m_AosWeaponAttributes.MageWeapon );
						((Mobile)Parent).AddSkillMod( m_MageMod );
					}

					if ( GetSaveFlag( flags, SaveFlag.PlayerConstructed ) )
						m_PlayerConstructed = true;

                    if (GetSaveFlag(flags, SaveFlag.SkillBonuses))
                    {
                        m_AosSkillBonuses = new AosSkillBonuses(this, reader);
                        m_AosSkillBonuses = new AosSkillBonuses(this);
                    }
                    else
                        m_AosSkillBonuses = new AosSkillBonuses(this);

                    if (GetSaveFlag(flags, SaveFlag.ElementalDamages))
                    {
                        m_AosElementDamages = new AosElementAttributes(this, reader);
                        m_AosElementDamages = new AosElementAttributes(this);
                    }
                    else
                        m_AosElementDamages = new AosElementAttributes(this);

					break;
				}
				case 4:
				{
					goto case 3;
				}
				case 3:
				{
					m_StrReq = reader.ReadInt();
					m_DexReq = reader.ReadInt();
					m_IntReq = reader.ReadInt();

					goto case 2;
				}
				case 2:
				{
					m_Identified = reader.ReadBool();

					goto case 1;
				}
				case 1:
				{
					m_MaxRange = reader.ReadInt();

					goto case 0;
				}
				case 0:
				{
					if ( version == 0 )
						m_MaxRange = 1; // default

					if ( version < 5 )
					{
						m_Resource = CraftResource.Fer;
						m_AosAttributes = new AosAttributes( this );
						m_AosWeaponAttributes = new AosWeaponAttributes( this );
						m_AosElementDamages = new AosElementAttributes( this );
						m_AosSkillBonuses = new AosSkillBonuses( this );
					}

					m_MinDamage = reader.ReadInt();
					m_MaxDamage = reader.ReadInt();

					m_Speed = reader.ReadInt();

					m_HitSound = reader.ReadInt();
					m_MissSound = reader.ReadInt();

					m_Skill = (SkillName)reader.ReadInt();
					m_Type = (WeaponType)reader.ReadInt();
					m_Animation = (WeaponAnimation)reader.ReadInt();
					m_DamageLevel = (WeaponDamageLevel)reader.ReadInt();
					m_AccuracyLevel = (WeaponAccuracyLevel)reader.ReadInt();
					m_DurabilityLevel = (WeaponDurabilityLevel)reader.ReadInt();
					m_Quality = (WeaponQuality)reader.ReadInt();

					m_Crafter = reader.ReadMobile();
                    m_CrafterName = reader.ReadString();

					m_Poison = Poison.Deserialize( reader );
					m_PoisonCharges = reader.ReadInt();

					if ( UseSkillMod && m_AccuracyLevel != WeaponAccuracyLevel.Regular && Parent is Mobile )
					{
						m_SkillMod = new DefaultSkillMod( AccuracySkill, true, (int)m_AccuracyLevel * 5);
						((Mobile)Parent).AddSkillMod( m_SkillMod );
					}

					break;
				}
			}

			if ( Core.AOS && Parent is Mobile )
				m_AosSkillBonuses.AddTo( (Mobile)Parent );

			int strBonus = m_AosAttributes.BonusStr;
			int dexBonus = m_AosAttributes.BonusDex;
			int intBonus = m_AosAttributes.BonusInt;

			if ( this.Parent is Mobile && (strBonus != 0 || dexBonus != 0 || intBonus != 0) )
			{
				Mobile m = (Mobile)this.Parent;

				string modName = this.Serial.ToString();

				if ( strBonus != 0 )
					m.AddStatMod( new StatMod( StatType.Str, modName + "Str", strBonus, TimeSpan.Zero ) );

				if ( dexBonus != 0 )
					m.AddStatMod( new StatMod( StatType.Dex, modName + "Dex", dexBonus, TimeSpan.Zero ) );

				if ( intBonus != 0 )
					m.AddStatMod( new StatMod( StatType.Int, modName + "Int", intBonus, TimeSpan.Zero ) );
			}

			if ( Parent is Mobile )
				((Mobile)Parent).CheckStatTimers();

			if ( m_Hits <= 0 && m_MaxHits <= 0 )
			{
				m_Hits = m_MaxHits = Utility.RandomMinMax( InitMinHits, InitMaxHits );
			}

			if ( version < 6 )
				m_PlayerConstructed = true; // we don't know, so, assume it's crafted

            Hue = CraftResources.GetHue(m_Resource);
		}
		#endregion

		public BaseWeapon( int itemID ) : base( itemID )
		{
			Layer = (Layer)ItemData.Quality;

			m_Quality = WeaponQuality.Regular;
			m_StrReq = -1;
			m_DexReq = -1;
			m_IntReq = -1;
			m_MinDamage = -1;
			m_MaxDamage = -1;
			m_HitSound = -1;
			m_MissSound = -1;
			m_Speed = -1;
			m_MaxRange = -1;
			m_Skill = (SkillName)(-1);
			m_Type = (WeaponType)(-1);
			m_Animation = (WeaponAnimation)(-1);

			m_Hits = m_MaxHits = Utility.RandomMinMax( InitMinHits, InitMaxHits );

			m_Resource = CraftResource.Fer;

			m_AosAttributes = new AosAttributes( this );
			m_AosWeaponAttributes = new AosWeaponAttributes( this );
			m_AosSkillBonuses = new AosSkillBonuses( this );
			m_AosElementDamages = new AosElementAttributes( this );
            m_TemraelAttributes = new TemraelAttributes( this );

            m_rarete = RareteItem.Normal;
		}

		public BaseWeapon( Serial serial ) : base( serial )
		{
		}

		private string GetNameString()
		{
			string name = this.Name;

			if ( name == null )
				name = String.Format( "#{0}", LabelNumber );

			return name;
		}

		[Hue, CommandProperty( AccessLevel.Batisseur )]
		public override int Hue
		{
			get{ return base.Hue; }
			set{ base.Hue = value; InvalidateProperties(); }
		}

		public int GetElementalDamageHue()
		{
			int phys, contondant, tranchant, perforant, magie, chaos, direct;
			GetDamageTypes( null, out phys, out contondant, out tranchant, out perforant, out magie, out chaos, out direct );
			//Order is Cold, Energy, Fire, Poison, Physical left

			int currentMax = 50;
			int hue = 0;

			if( perforant >= currentMax )
			{
				hue = 1267 + (perforant - 50) / 10;
				currentMax = perforant;
			}

			if( contondant >= currentMax )
			{
                hue = 1255 + (contondant - 50) / 10;
                currentMax = contondant;
			}

			if( magie >= currentMax )
			{
                hue = 1273 + (magie - 50) / 10;
                currentMax = magie;
			}

			if( tranchant >= currentMax )
			{
                hue = 1261 + (tranchant - 50) / 10;
                currentMax = tranchant;
			}

			return hue;
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			int oreType;

			switch ( m_Resource )
			{
				case CraftResource.Cuivre:		    oreType = 1053108; break; // dull copper
				case CraftResource.Bronze:		    oreType = 1053107; break; // shadow iron
				case CraftResource.Acier:			oreType = 1053106; break; // copper
				case CraftResource.Argent:			oreType = 1053105; break; // bronze
				case CraftResource.Or:			    oreType = 1053104; break; // golden
				case CraftResource.Mytheril:		oreType = 1053103; break; // agapite
				case CraftResource.Luminium:		oreType = 1053102; break; // verite
				case CraftResource.Obscurium:		oreType = 1053101; break; // valorite
                case CraftResource.Mystirium:       oreType = 1053101; break; // valorite
                case CraftResource.Dominium:        oreType = 1053101; break; // valorite
                case CraftResource.Eclarium:        oreType = 1053101; break; // valorite
                case CraftResource.Venarium:        oreType = 1053101; break; // valorite
                case CraftResource.Athenium:        oreType = 1053101; break; // valorite
                case CraftResource.Umbrarium:       oreType = 1053101; break; // valorite
				/*case CraftResource.SpinedLeather:	oreType = 1061118; break; // spined
				case CraftResource.HornedLeather:	oreType = 1061117; break; // horned
				case CraftResource.BarbedLeather:	oreType = 1061116; break; // barbed
				case CraftResource.RedScales:		oreType = 1060814; break; // red
				case CraftResource.YellowScales:	oreType = 1060818; break; // yellow
				case CraftResource.BlackScales:		oreType = 1060820; break; // black
				case CraftResource.GreenScales:		oreType = 1060819; break; // green
				case CraftResource.WhiteScales:		oreType = 1060821; break; // white
				case CraftResource.BlueScales:		oreType = 1060815; break; // blue*/
				default: oreType = 0; break;
			}

			if ( oreType != 0 )
				list.Add( 1053099, "#{0}\t{1}", oreType, GetNameString() ); // ~1_oretype~ ~2_armortype~
			else if ( Name == null )
				list.Add( LabelNumber );
			else
				list.Add( Name );
				
		}

		public override bool AllowEquipedCast( Mobile from )
		{
			if ( base.AllowEquipedCast( from ) )
				return true;

			return ( m_AosAttributes.SpellChanneling != 0 );
		}

		public virtual int ArtifactRarity
		{
			get{ return 0; }
		}

		//public virtual int GetLuckBonus()
		//{
		//	CraftResourceInfo resInfo = CraftResources.GetInfo( m_Resource );
        //
		//	if ( resInfo == null )
		//		return 0;
        //
		//	CraftAttributeInfo attrInfo = resInfo.AttributeInfo;
        //
		//	if ( attrInfo == null )
		//		return 0;
        //
		//	return attrInfo.WeaponLuck;
		//}

		public override void GetProperties( ObjectPropertyList list )
		{
			//base.GetProperties( list );

            string couleur = "";
            RareteItem rarete = RareteItem.Normal;

            switch (Rarete)
            {
                case RareteItem.Mediocre:
                    rarete = RareteItem.Mediocre;
                    couleur = "333333";
                    break;
                case RareteItem.Normal:
                    rarete = RareteItem.Normal;
                    couleur = "999999";
                    break;
                case RareteItem.Magique:
                    rarete = RareteItem.Magique;
                    couleur = "003366";
                    break;
                case RareteItem.Rare:
                    rarete = RareteItem.Rare;
                    couleur = "993300";
                    break;
                case RareteItem.Legendaire:
                    rarete = RareteItem.Legendaire;
                    couleur = "5A4A31";
                    break;
                default: couleur = "999999"; break;
            }

            if (this.Identified)
            {
                string[] s = Regex.Split(GetType().ToString(),@"\.");
                string t = s[s.Length - 1];
                if (Name == null)
                    list.Add(1060393, "{0}\t{1}", couleur, t);
                else
                    list.Add(1060393, "{0}\t{1}", couleur, Name);
                //list.Add(1060394, "{0}\t{1}", couleur, rarete.ToString());
                list.Add(1060394, "{0}\t{1}", couleur, Quality.ToString());

                if (m_CrafterName != null)
                    list.Add(1060394, "{0}\t{1}", couleur, "Fabriquèßpar: " + m_CrafterName); // Fabriquèßpar: ~1_NAME~

                #region Factions
                if (FactionItemState != null)
                    list.Add(1041350); // faction item
                #endregion

                if (RequiredRace == Race.Elf)
                    list.Add(1075086); // Elves Only

                if (m_AosSkillBonuses != null)
                    m_AosSkillBonuses.GetProperties(list, couleur);

                int prop;

                /*if ((prop = ArtifactRarity) > 0)
                    list.Add(1061078, prop.ToString()); // artifact rarity ~1_val~*/

                if ((prop = (GetHitChanceBonus() + m_AosAttributes.AttackChance)) != 0)
                    list.Add(1060401, "{0}\t{1}", couleur, prop.ToString()); // hit chance increase ~1_val~%

                if ((prop = (GetDamageBonus() + m_AosAttributes.WeaponDamage)) != 0)
                    list.Add(1060402, "{0}\t{1}", couleur, prop.ToString()); // damage increase ~1_val~%

                if ((prop = m_AosAttributes.DefendChance) != 0)
                    list.Add(1060408, "{0}\t{1}", couleur, prop.ToString()); // defense chance increase ~1_val~%

                if ((prop = m_AosAttributes.WeaponSpeed) != 0)
                    list.Add(1060486, "{0}\t{1}", couleur, prop.ToString()); // swing speed increase ~1_val~%

                if ((prop = m_AosAttributes.ReflectPhysical) != 0)
                    list.Add(1060442, "{0}\t{1}", couleur, prop.ToString()); // reflect physical damage ~1_val~%

                if ((prop = m_AosAttributes.BonusStr) != 0)
                    list.Add(1060485, "{0}\t{1}", couleur, prop.ToString()); // strength bonus ~1_val~

                if ((prop = m_AosAttributes.BonusDex) != 0)
                    list.Add(1060409, "{0}\t{1}", couleur, prop.ToString()); // dexterity bonus ~1_val~

                if ((prop = m_TemraelAttributes.ConstitutionBonus) != 0)
                    list.Add("<h3><basefont color=#" + couleur + ">Bonus Constitution: " + prop.ToString() + "<basefont></h3>");

                if ((prop = m_AosAttributes.BonusInt) != 0)
                    list.Add(1060432, "{0}\t{1}", couleur, prop.ToString()); // intelligence bonus ~1_val~

                if ((prop = m_TemraelAttributes.CharismaBonus) != 0)
                    list.Add("<h3><basefont color=#" + couleur + ">Bonus Charisme: " + prop.ToString() + "<basefont></h3>");

                if ((prop = m_AosAttributes.BonusHits) != 0)
                    list.Add(1060431, "{0}\t{1}", couleur, prop.ToString()); // hit point increase ~1_val~

                if ((prop = m_AosAttributes.BonusStam) != 0)
                    list.Add(1060484, "{0}\t{1}", couleur, prop.ToString()); // stamina increase ~1_val~

                if ((prop = m_AosAttributes.BonusMana) != 0)
                    list.Add(1060439, "{0}\t{1}", couleur, prop.ToString()); // mana increase ~1_val~

                if ((prop = m_AosAttributes.RegenHits) != 0)
                    list.Add(1060444, "{0}\t{1}", couleur, prop.ToString()); // hit point regeneration ~1_val~

                if ((prop = m_AosAttributes.RegenStam) != 0)
                    list.Add(1060443, "{0}\t{1}", couleur, prop.ToString()); // stamina regeneration ~1_val~

                if ((prop = m_AosAttributes.RegenMana) != 0)
                    list.Add(1060440, "{0}\t{1}", couleur, prop.ToString()); // mana regeneration ~1_val~

                if ((prop = m_AosAttributes.EnhancePotions) != 0)
                    list.Add(1060411, "{0}\t{1}", couleur, prop.ToString()); // enhance potions ~1_val~%

                if ((prop = m_AosAttributes.CastRecovery) != 0)
                    list.Add(1060412, "{0}\t{1}", couleur, prop.ToString()); // faster cast recovery ~1_val~

                if ((prop = m_AosAttributes.CastSpeed) != 0)
                    list.Add(1060413, "{0}\t{1}", couleur, prop.ToString()); // faster casting ~1_val~

                if ((prop = m_AosAttributes.LowerManaCost) != 0)
                    list.Add(1060433, "{0}\t{1}", couleur, prop.ToString()); // lower mana cost ~1_val~%

                if ((prop = m_AosAttributes.LowerRegCost) != 0)
                    list.Add(1060434, "{0}\t{1}", couleur, prop.ToString()); // lower reagent cost ~1_val~%

                //if ((prop = m_AosAttributes.Luck) != 0)
                //    list.Add("<h3><basefont color=#" + couleur + ">Chance:" + prop.ToString() + "<basefont></h3>"); // luck ~1_val~

                if ((prop = m_AosAttributes.SpellChanneling) != 0)
                    list.Add(1060482); // spell channeling

                if ((prop = m_AosAttributes.SpellDamage) != 0)
                    list.Add(1060483, "{0}\t{1}", couleur, prop.ToString()); // spell damage increase ~1_val~%

                if ((prop = m_AosAttributes.NightSight) != 0)
                    list.Add(1060434, couleur); // night sight

                AddARProperties(list, couleur);

                if (this is IUsesRemaining && ((IUsesRemaining)this).ShowUsesRemaining)
                    list.Add(1060584, "{0}\t{1}", couleur, ((IUsesRemaining)this).UsesRemaining.ToString()); // uses remaining: ~1_val~

                if (m_Poison != null && m_PoisonCharges > 0)
                    list.Add(1060526, "{0}\t{1}", couleur, m_PoisonCharges.ToString());

                /*if (Core.ML && this is BaseRanged && ((BaseRanged)this).Balanced)
                    list.Add(1072792); // Balanced*/

                if ((prop = m_AosWeaponAttributes.HitPhysicalArea) != 0)
                    list.Add(1060428, "{0}\t{1}", couleur, prop.ToString()); // hit physical area ~1_val~%

                if ((prop = m_AosWeaponAttributes.HitTranchantArea) != 0)
                    list.Add(1060416, "{0}\t{1}", couleur, prop.ToString()); // hit cold area ~1_val~%

                if ((prop = m_AosWeaponAttributes.HitContondantArea) != 0)
                    list.Add(1060419, "{0}\t{1}", couleur, prop.ToString()); // hit fire area ~1_val~%

                if ((prop = m_AosWeaponAttributes.HitPerforantArea) != 0)
                    list.Add(1060429,"{0}\t{1}", couleur, prop.ToString()); // hit poison area ~1_val~%

                if ((prop = m_AosWeaponAttributes.HitMagieArea) != 0)
                    list.Add(1060418, "{0}\t{1}", couleur, prop.ToString()); // hit energy area ~1_val~%

                if ((prop = m_AosWeaponAttributes.HitDispel) != 0)
                    list.Add(1060417, "{0}\t{1}", couleur, prop.ToString()); // hit dispel ~1_val~%

                if ((prop = m_AosWeaponAttributes.HitFireball) != 0)
                    list.Add(1060420, "{0}\t{1}", couleur, prop.ToString()); // hit fireball ~1_val~%

                if ((prop = m_AosWeaponAttributes.HitLightning) != 0)
                    list.Add(1060423, "{0}\t{1}", couleur, prop.ToString()); // hit lightning ~1_val~%

                if ((prop = m_AosWeaponAttributes.HitHarm) != 0)
                    list.Add(1060421, "{0}\t{1}", couleur, prop.ToString()); // hit harm ~1_val~%

                if ((prop = m_AosWeaponAttributes.HitMagicArrow) != 0)
                    list.Add(1060426, "{0}\t{1}", couleur, prop.ToString()); // hit magic arrow ~1_val~%

                if ((prop = m_AosWeaponAttributes.HitLowerAttack) != 0)
                    list.Add(1060424, "{0}\t{1}", couleur, prop.ToString()); // hit lower attack ~1_val~%

                if ((prop = m_AosWeaponAttributes.HitLowerDefend) != 0)
                    list.Add(1060425, "{0}\t{1}", couleur, prop.ToString()); // hit lower defense ~1_val~%

                if ((prop = m_AosWeaponAttributes.HitLeechHits) != 0)
                    list.Add(1060422, "{0}\t{1}", couleur, prop.ToString()); // hit life leech ~1_val~%

                if ((prop = m_AosWeaponAttributes.HitLeechStam) != 0)
                    list.Add(1060430, "{0}\t{1}", couleur, prop.ToString()); // hit stamina leech ~1_val~%

                if ((prop = m_AosWeaponAttributes.HitLeechMana) != 0)
                    list.Add(1060427, "{0}\t{1}", couleur, prop.ToString()); // hit mana leech ~1_val~%

                /*if (Core.ML && this is BaseRanged && (prop = ((BaseRanged)this).Velocity) != 0)
                    list.Add(1072793, prop.ToString()); // Velocity ~1_val~%*/

                if ((prop = m_AosWeaponAttributes.MageWeapon) != 0)
                    list.Add(1060438, "{0}\t{1}", couleur, (30 - prop).ToString()); // mage weapon -~1_val~ skill

                int phys, contondant, tranchant, perforant, magie, chaos, direct;

                GetDamageTypes(null, out phys, out contondant, out tranchant, out perforant, out magie, out chaos, out direct);

                if (phys != 0)
                    list.Add(1060403, "{0}\t{1}", couleur, phys.ToString()); // physical damage ~1_val~%

                if (contondant != 0)
                    list.Add(1060405, "{0}\t{1}", couleur, contondant.ToString()); // fire damage ~1_val~%

                if (tranchant != 0)
                    list.Add(1060404, "{0}\t{1}", couleur, tranchant.ToString()); // cold damage ~1_val~%

                if (perforant != 0)
                    list.Add(1060406, "{0}\t{1}", couleur, perforant.ToString()); // poison damage ~1_val~%

                if (magie != 0)
                    list.Add(1060407, "{0}\t{1}", couleur, magie.ToString()); // energy damage ~1_val

                if (Core.ML && chaos != 0)
                    list.Add(1072846, chaos.ToString()); // chaos damage ~1_val~%

                if (Core.ML && direct != 0)
                    list.Add(1079978, direct.ToString()); // Direct Damage: ~1_PERCENT~%

                list.Add(1061168, "{0}\t{1}\t{2}", couleur, MinDamage.ToString(), MaxDamage.ToString()); // weapon damage ~1_val~ - ~2_val~

                if (Core.ML)
                    list.Add(1061167, String.Format("{0}s", Speed)); // weapon speed ~1_val~
                else
                    list.Add(1061167, "{0}\t{1}", couleur, Speed.ToString());

                if (MaxRange > 1)
                    list.Add(1061169, "{0}\t{1}", couleur, MaxRange.ToString()); // range ~1_val~

                if (Layer == Layer.TwoHanded)
                    list.Add(1061171, couleur); // two-handed weapon
                else
                    list.Add(1061824, couleur); // one-handed weapon

                if ((prop = m_AosWeaponAttributes.UseBestSkill) != 0)
                    list.Add(1060400, couleur); // use best weapon skill

                if (m_AosWeaponAttributes.UseBestSkill == 0)
                {
                    switch (Skill)
                    {
                        case SkillName.ArmeHaste: list.Add(1061165, couleur); break;
                        case SkillName.ArmeTranchante: list.Add(1061172, couleur); break; // skill required: swordsmanship
                        case SkillName.ArmeContondante: list.Add(1061173, couleur); break; // skill required: mace fighting
                        case SkillName.ArmePerforante: list.Add(1061174, couleur); break; // skill required: fencing
                        case SkillName.ArmeDistance: list.Add(1061175, couleur); break; // skill required: archery
                    }
                }

                int strReq = AOS.Scale(StrRequirement, 100 - GetLowerStatReq());

                if ((prop = GetLowerStatReq()) != 0)
                    list.Add(1060435, "{0}\t{1}", couleur, prop.ToString()); // lower requirements ~1_val~%

                if (strReq > 0)
                    list.Add(1061170, "{0}\t{1}", couleur, strReq.ToString()); // strength requirement ~1_val~

                if ((prop = m_AosWeaponAttributes.SelfRepair) != 0)
                    list.Add(1060450, "{0}\t{1}", couleur, prop.ToString()); // self repair ~1_val~

                if ((prop = GetDurabilityBonus()) > 0)
                    list.Add(1060410, "{0}\t{1}", couleur, prop.ToString()); // durability ~1_val~%

                if (m_Hits >= 0 && m_MaxHits > 0)
                    list.Add(1060639, "{0}\t{1}\t{2}", couleur, m_Hits, m_MaxHits); // durability ~1_val~ / ~2_val~
            }
            else
            {
                string[] s = Regex.Split(GetType().ToString(), @"\.");
                string t = s[s.Length - 1];
                if (Name == null)
                    list.Add(1060393, "{0}\t{1}", couleur, t);
                else
                    list.Add(1060393, "{0}\t{1}", couleur, Name);
                //list.Add(1060394, "{0}\t{1}", couleur, rarete.ToString());
                list.Add(1060395, couleur);
            }
		}

        public void AddARProperties(ObjectPropertyList list, string couleur)
        {
            int v = PhysicalResistance;

            if (v != 0)
                list.Add(1060448, "{0}\t{1}", couleur, v.ToString()); // physical resist ~1_val~%

            v = ContondantResistance;

            if (v != 0)
                list.Add(1060447, "{0}\t{1}", couleur, v.ToString()); // fire resist ~1_val~%

            v = TranchantResistance;

            if (v != 0)
                list.Add(1060445, "{0}\t{1}", couleur, v.ToString()); // cold resist ~1_val~%

            v = PerforantResistance;

            if (v != 0)
                list.Add(1060449, "{0}\t{1}", couleur, v.ToString()); // poison resist ~1_val~%

            v = MagieResistance;

            if (v != 0)
                list.Add(1060446, "{0}\t{1}", couleur, v.ToString()); // energy resist ~1_val~%
        }

		public override void OnSingleClick( Mobile from )
		{
			List<EquipInfoAttribute> attrs = new List<EquipInfoAttribute>();

			if ( DisplayLootType )
			{
				if ( LootType == LootType.Blessed )
					attrs.Add( new EquipInfoAttribute( 1038021 ) ); // blessed
				else if ( LootType == LootType.Cursed )
					attrs.Add( new EquipInfoAttribute( 1049643 ) ); // cursed
			}

			#region Factions
			if ( FactionItemState != null )
				attrs.Add( new EquipInfoAttribute( 1041350 ) ); // faction item
			#endregion

			if ( m_Quality == WeaponQuality.Exceptional )
				attrs.Add( new EquipInfoAttribute( 1018305 - (int)m_Quality ) );

			if ( m_Identified || from.AccessLevel >= AccessLevel.Batisseur )
			{

				if ( m_DurabilityLevel != WeaponDurabilityLevel.Regular )
					attrs.Add( new EquipInfoAttribute( 1038000 + (int)m_DurabilityLevel ) );

				if ( m_DamageLevel != WeaponDamageLevel.Regular )
					attrs.Add( new EquipInfoAttribute( 1038015 + (int)m_DamageLevel ) );

				if ( m_AccuracyLevel != WeaponAccuracyLevel.Regular )
					attrs.Add( new EquipInfoAttribute( 1038010 + (int)m_AccuracyLevel ) );
			}
			else if( m_DurabilityLevel != WeaponDurabilityLevel.Regular || m_DamageLevel != WeaponDamageLevel.Regular || m_AccuracyLevel != WeaponAccuracyLevel.Regular )
				attrs.Add( new EquipInfoAttribute( 1038000 ) ); // Unidentified

			if ( m_Poison != null && m_PoisonCharges > 0 )
				attrs.Add( new EquipInfoAttribute( 1017383, m_PoisonCharges ) );

			int number;

			if ( Name == null )
			{
				number = LabelNumber;
			}
			else
			{
				this.LabelTo( from, Name );
				number = 1041000;
			}

			if ( attrs.Count == 0 && Crafter == null && Name != null )
				return;

			EquipmentInfo eqInfo = new EquipmentInfo( number, m_Crafter, false, attrs.ToArray() );

			from.Send( new DisplayEquipmentInfo( this, eqInfo ) );
		}

		private static BaseWeapon m_Fists; // This value holds the default--fist--weapon

		public static BaseWeapon Fists
		{
			get{ return m_Fists; }
			set{ m_Fists = value; }
		}

        #region ICraftable Members

        public int OnCraft( int quality, bool makersMark, Mobile from, CraftSystem craftSystem, Type typeRes, BaseTool tool, CraftItem craftItem, int resHue )
		{
			Quality = (WeaponQuality)quality;

            if (makersMark)
            {
                Crafter = from;
                m_CrafterName = from.Name;
            }

			PlayerConstructed = true;

			Type resourceType = typeRes;

			if ( resourceType == null )
				resourceType = craftItem.Resources.GetAt( 0 ).ItemType;

			if ( Core.AOS )
			{
				Resource = CraftResources.GetFromType( resourceType );

				CraftContext context = craftSystem.GetContext( from );

				if ( context != null && context.DoNotColor )
					Hue = 0;

				if ( tool is BaseRunicTool )
					((BaseRunicTool)tool).ApplyAttributesTo( this );

                RareteInit.InitItem(this, quality, Crafter);

				if ( Quality == WeaponQuality.Exceptional )
				{
					if ( Attributes.WeaponDamage > 35 )
						Attributes.WeaponDamage -= 20;
					else
						Attributes.WeaponDamage = 15;

					if( Core.ML )
					{
						Attributes.WeaponDamage += (int)(from.Skills.Forge.Value / 20);

						if ( Attributes.WeaponDamage > 50 )
							Attributes.WeaponDamage = 50;

						from.CheckSkill( SkillName.Forge, 0, 100 );
					}
				}
			}
			else if ( tool is BaseRunicTool )
			{
				CraftResource thisResource = CraftResources.GetFromType( resourceType );

				if ( thisResource == ((BaseRunicTool)tool).Resource )
				{
					Resource = thisResource;

					CraftContext context = craftSystem.GetContext( from );

					if ( context != null && context.DoNotColor )
						Hue = 0;

					switch ( thisResource )
					{
						case CraftResource.Cuivre:
						{
							Identified = true;
							DurabilityLevel = WeaponDurabilityLevel.Regular;
                            DamageLevel = WeaponDamageLevel.Regular;
							AccuracyLevel = WeaponAccuracyLevel.Accurate;
							break;
						}
						case CraftResource.Bronze:
						{
							Identified = true;
							DurabilityLevel = WeaponDurabilityLevel.Regular;
							DamageLevel = WeaponDamageLevel.Ruin;
                            AccuracyLevel = WeaponAccuracyLevel.Accurate;
							break;
						}
						case CraftResource.Acier:
						{
							Identified = true;
							DurabilityLevel = WeaponDurabilityLevel.Durable;
							DamageLevel = WeaponDamageLevel.Ruin;
							AccuracyLevel = WeaponAccuracyLevel.Surpassingly;
							break;
						}
						case CraftResource.Argent:
						{
							Identified = true;
                            DurabilityLevel = WeaponDurabilityLevel.Regular;
							DamageLevel = WeaponDamageLevel.Regular;
							AccuracyLevel = WeaponAccuracyLevel.Surpassingly;
							break;
						}
						case CraftResource.Or:
						{
							Identified = true;
							DurabilityLevel = WeaponDurabilityLevel.Regular;
							DamageLevel = WeaponDamageLevel.Regular;
                            AccuracyLevel = WeaponAccuracyLevel.Surpassingly;
							break;
						}
						case CraftResource.Mytheril:
						{
							Identified = true;
							DurabilityLevel = WeaponDurabilityLevel.Indestructible;
							DamageLevel = WeaponDamageLevel.Ruin;
                            AccuracyLevel = WeaponAccuracyLevel.Eminently;
							break;
						}
						case CraftResource.Luminium:
						{
							Identified = true;
							DurabilityLevel = WeaponDurabilityLevel.Fortified;
							DamageLevel = WeaponDamageLevel.Power;
							AccuracyLevel = WeaponAccuracyLevel.Supremely;
							break;
						}
						case CraftResource.Obscurium:
						{
							Identified = true;
                            DurabilityLevel = WeaponDurabilityLevel.Fortified;
							DamageLevel = WeaponDamageLevel.Vanq;
                            AccuracyLevel = WeaponAccuracyLevel.Exceedingly;
							break;
						}
                        case CraftResource.Mystirium:
                        {
                            Identified = true;
                            DurabilityLevel = WeaponDurabilityLevel.Durable;
                            DamageLevel = WeaponDamageLevel.Vanq;
                            AccuracyLevel = WeaponAccuracyLevel.Supremely;
                            break;
                        }
                        case CraftResource.Dominium:
                        {
                            Identified = true;
                            DurabilityLevel = WeaponDurabilityLevel.Indestructible;
                            DamageLevel = WeaponDamageLevel.Force;
                            AccuracyLevel = WeaponAccuracyLevel.Exceedingly;
                            break;
                        }
                        case CraftResource.Eclarium:
                        {
                            Identified = true;
                            DurabilityLevel = WeaponDurabilityLevel.Regular;
                            DamageLevel = WeaponDamageLevel.Vanq;
                            AccuracyLevel = WeaponAccuracyLevel.Supremely;
                            break;
                        }
                        case CraftResource.Venarium:
                        {
                            Identified = true;
                            DurabilityLevel = WeaponDurabilityLevel.Massive;
                            DamageLevel = WeaponDamageLevel.Vanq;
                            AccuracyLevel = WeaponAccuracyLevel.Eminently;
                            break;
                        }
                        case CraftResource.Athenium:
                        {
                            Identified = true;
                            DurabilityLevel = WeaponDurabilityLevel.Substantial;
                            DamageLevel = WeaponDamageLevel.Might;
                            AccuracyLevel = WeaponAccuracyLevel.Supremely;
                            break;
                        }
                        case CraftResource.Umbrarium:
                        {
                            Identified = true;
                            DurabilityLevel = WeaponDurabilityLevel.Fortified;
                            DamageLevel = WeaponDamageLevel.Vanq;
                            AccuracyLevel = WeaponAccuracyLevel.Surpassingly;
                            break;
                        }
					}
				}
			}

			return quality;
		}

		#endregion
	}
}
