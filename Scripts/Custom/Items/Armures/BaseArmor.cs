using System;
using System.Collections;
using System.Collections.Generic;
using Server.Network;
using Server.Engines.Craft;
using Server.Factions;
using AMA = Server.Items.ArmorMeditationAllowance;
using AMT = Server.Items.ArmorMaterialType;
using ABT = Server.Items.ArmorBodyType;
using Server.ContextMenus;
using Server.Mobiles;
using System.Text.RegularExpressions;
/* Modification des armures et du AR qui vas avec :
 * la formule : Capacité*2*6(car 6 pieces d'armure hors bouclier)
 * passé la capacité 4 la formule change pour du cas par cas
 * Cette formule est calculé avec le matériel de base (Fer, Bones simple, Regular leather)
 * Set d'armure aura donc :
 * Capa 1 : 12 de Ar
 * Capa 2 : 24 de Ar
 * Capa 3 : 36 de Ar
 * Capa 4 : 48 de Ar
 * Capa 5 : 54 de Ar
 * Capa 6 : 60 de Ar 
 * 
 * Pour les lingots (Trop de fer pour équilibré proprement ) : on gagne de +0 à +4 Ar Par piece, soit Top Metal capa 6 =  84 de Ar sans shield
 * Pour les OS en capa 6 : (12+2)*6 = 84 de Ar sans shield
 * idem pour les peaux .(j'ignore si la qualité du cuire dépend de la capacité ou pas donc j'ai fais comme les os .
 * 
 * J'ai aussi mis les Resistance contendant etc = au AR des item, donc 60 de Resist Magic etc, j'ai pensé que si tu devais le modifié plus tard c'était plus facile d'avoir une base facile pour le calcule .
 */
namespace Server.Items
{
    public abstract class BaseArmor : Item, IScissorable, IFactionItem, ICraftable, IWearableDurability
    {
        #region Balancement

        //BOUCLIERS

        public const int Resistances_None0 = 0;
        public const int Resistances_Inferior0 = 12;
        public const int Resistances_Low0 = 25;
        public const int Resistances_Average0 = 40;
        public const int Resistances_Med0 = 50;
        public const int Resistances_High0 = 70;
        public const int Resistances_Advanced0 = 85;
        public const int Resistances_Max0 = 100;

        public const int Bouclier_Def0 = 2;
        public const int Bouclier_Def1 = 5;
        public const int Bouclier_Def2 = 8;
        public const int Bouclier_Def3 = 12;
        public const int Bouclier_Def4 = 15;
        public const int Bouclier_Def5 = 20;
        public const int Bouclier_Def6 = 25;
        public const int Bouclier_Force0 = 0;
        public const int Bouclier_Force1 = 10;
        public const int Bouclier_Force2 = 15;
        public const int Bouclier_Force3 = 20;
        public const int Bouclier_Force4 = 30;
        public const int Bouclier_Force5 = 40;
        public const int Bouclier_Force6 = 60;
        public const int Bouclier_MinDurabilite0 = 80;
        public const int Bouclier_MaxDurabilite0 = 100;
        public const int Bouclier_MinDurabilite1 = 85;
        public const int Bouclier_MaxDurabilite1 = 105;
        public const int Bouclier_MinDurabilite2 = 110;
        public const int Bouclier_MaxDurabilite2 = 125;
        public const int Bouclier_MinDurabilite3 = 130;
        public const int Bouclier_MaxDurabilite3 = 150;
        public const int Bouclier_MinDurabilite4 = 150;
        public const int Bouclier_MaxDurabilite4 = 175;
        public const int Bouclier_MinDurabilite5 = 180;
        public const int Bouclier_MaxDurabilite5 = 200;
        public const int Bouclier_MinDurabilite6 = 225;
        public const int Bouclier_MaxDurabilite6 = 250;

        //FEUILLES

        public const int Feuille_Casque = 2;
        public const int Feuille_Casque_Contondant = 2;
        public const int Feuille_Casque_Tranchant = 2;
        public const int Feuille_Casque_Perforant = 2;
        public const int Feuille_Casque_Magique = 2;
        public const int Feuille_Casque_Force = 0;

        public const int Feuille_Gorget = 2;
        public const int Feuille_Gorget_Contondant = 2;
        public const int Feuille_Gorget_Tranchant = 2;
        public const int Feuille_Gorget_Perforant = 2;
        public const int Feuille_Gorget_Magique = 2;
        public const int Feuille_Gorget_Force = 0;

        public const int Feuille_Brassards = 2;
        public const int Feuille_Brassards_Contondant = 2;
        public const int Feuille_Brassards_Tranchant = 2;
        public const int Feuille_Brassards_Perforant = 2;
        public const int Feuille_Brassards_Magique = 2;
        public const int Feuille_Brassards_Force = 12;

        public const int Feuille_Cuirasse = 2;
        public const int Feuille_Cuirasse_Contondant = 2;
        public const int Feuille_Cuirasse_Tranchant = 2;
        public const int Feuille_Cuirasse_Perforant = 2;
        public const int Feuille_Cuirasse_Magique = 2;
        public const int Feuille_Cuirasse_Force = 15;

        public const int Feuille_Jambieres = 2;
        public const int Feuille_Jambieres_Contondant = 2;
        public const int Feuille_Jambieres_Tranchant = 2;
        public const int Feuille_Jambieres_Perforant = 2;
        public const int Feuille_Jambieres_Magique = 2;
        public const int Feuille_Jambieres_Force = 10;

        public const int Feuille_MinDurabilite = 25;
        public const int Feuille_MaxDurabilite = 50;

        //LEATHER

        public const int Leather_Casque = 2;
        public const int Leather_Casque_Contondant = 2;
        public const int Leather_Casque_Tranchant = 2;
        public const int Leather_Casque_Perforant = 2;
        public const int Leather_Casque_Magique = 2;
        public const int Leather_Casque_Force = 2;

        public const int Leather_Gorget = 2;
        public const int Leather_Gorget_Contondant = 2;
        public const int Leather_Gorget_Tranchant = 2;
        public const int Leather_Gorget_Perforant = 2;
        public const int Leather_Gorget_Magique = 2;
        public const int Leather_Gorget_Force = 0;

        public const int Leather_Gants = 2;
        public const int Leather_Gants_Contondant = 2;
        public const int Leather_Gants_Tranchant = 2;
        public const int Leather_Gants_Perforant = 2;
        public const int Leather_Gants_Magique = 2;
        public const int Leather_Gants_Force = 0;

        public const int Leather_Brassards = 2;
        public const int Leather_Brassards_Contondant = 2;
        public const int Leather_Brassards_Tranchant = 2;
        public const int Leather_Brassards_Perforant = 2;
        public const int Leather_Brassards_Magique = 2;
        public const int Leather_Brassards_Force = 12;

        public const int Leather_Cuirasse = 2;
        public const int Leather_Cuirasse_Contondant = 2;
        public const int Leather_Cuirasse_Tranchant = 2;
        public const int Leather_Cuirasse_Perforant = 2;
        public const int Leather_Cuirasse_Magique = 2;
        public const int Leather_Cuirasse_Force = 15;

        public const int Leather_Jambieres = 2;
        public const int Leather_Jambieres_Contondant = 2;
        public const int Leather_Jambieres_Tranchant = 2;
        public const int Leather_Jambieres_Perforant = 2;
        public const int Leather_Jambieres_Magique = 2;
        public const int Leather_Jambieres_Force = 10;

        public const int Leather_MinDurabilite = 100;
        public const int Leather_MaxDurabilite = 125;

        //STUDDED

        public const int Studded_Gorget = 4;
        public const int Studded_Gorget_Contondant = 2;
        public const int Studded_Gorget_Tranchant = 2;
        public const int Studded_Gorget_Perforant = 2;
        public const int Studded_Gorget_Magique = 2;
        public const int Studded_Gorget_Force = 0;

        public const int Studded_Gants = 4;
        public const int Studded_Gants_Contondant = 2;
        public const int Studded_Gants_Tranchant = 2;
        public const int Studded_Gants_Perforant = 2;
        public const int Studded_Gants_Magique = 2;
        public const int Studded_Gants_Force = 0;

        public const int Studded_Brassards = 4;
        public const int Studded_Brassards_Contondant = 2;
        public const int Studded_Brassards_Tranchant = 2;
        public const int Studded_Brassards_Perforant = 2;
        public const int Studded_Brassards_Magique = 2;
        public const int Studded_Brassards_Force = 12;

        public const int Studded_Cuirasse = 4;
        public const int Studded_Cuirasse_Contondant = 2;
        public const int Studded_Cuirasse_Tranchant = 2;
        public const int Studded_Cuirasse_Perforant = 2;
        public const int Studded_Cuirasse_Magique = 2;
        public const int Studded_Cuirasse_Force = 15;

        public const int Studded_Jambieres = 4;
        public const int Studded_Jambieres_Contondant = 2;
        public const int Studded_Jambieres_Tranchant = 2;
        public const int Studded_Jambieres_Perforant = 2;
        public const int Studded_Jambieres_Magique = 2;
        public const int Studded_Jambieres_Force = 10;

        public const int Studded_MinDurabilite = 100;
        public const int Studded_MaxDurabilite = 125;

        //OS

        public const int Os_Casque = 2;
        public const int Os_Casque_Contondant = 2;
        public const int Os_Casque_Tranchant = 2;
        public const int Os_Casque_Perforant = 2;
        public const int Os_Casque_Magique = 2;
        public const int Os_Casque_Force = 5;

        public const int Os_Gants = 2;
        public const int Os_Gants_Contondant = 2;
        public const int Os_Gants_Tranchant = 2;
        public const int Os_Gants_Perforant = 2;
        public const int Os_Gants_Magique = 2;
        public const int Os_Gants_Force = 0;

        public const int Os_Brassards = 2;
        public const int Os_Brassards_Contondant = 2;
        public const int Os_Brassards_Tranchant = 2;
        public const int Os_Brassards_Perforant = 2;
        public const int Os_Brassards_Magique = 2;
        public const int Os_Brassards_Force = 10;

        public const int Os_Cuirasse = 2;
        public const int Os_Cuirasse_Contondant = 2;
        public const int Os_Cuirasse_Tranchant = 2;
        public const int Os_Cuirasse_Perforant = 2;
        public const int Os_Cuirasse_Magique = 2;
        public const int Os_Cuirasse_Force = 30;

        public const int Os_Jambieres = 2;
        public const int Os_Jambieres_Contondant = 2;
        public const int Os_Jambieres_Tranchant = 2;
        public const int Os_Jambieres_Perforant = 2;
        public const int Os_Jambieres_Magique = 2;
        public const int Os_Jambieres_Force = 10;

        public const int Os_MinDurabilite = 125;
        public const int Os_MaxDurabilite = 150;

        //RINGMAIL

        public const int Ring_Casque = 4;
        public const int Ring_Casque_Contondant = 4;
        public const int Ring_Casque_Tranchant = 4;
        public const int Ring_Casque_Perforant = 4;
        public const int Ring_Casque_Magique = 4;
        public const int Ring_Casque_Force = 2;
        public const int Ring_Casque_Dex = -1;

        public const int Ring_Gants = 2;
        public const int Ring_Gants_Contondant = 4;
        public const int Ring_Gants_Tranchant = 4;
        public const int Ring_Gants_Perforant = 4;
        public const int Ring_Gants_Magique = 4;
        public const int Ring_Gants_Force = 0;
        public const int Ring_Gants_Dex = -1;

        public const int Ring_Brassards = 4;
        public const int Ring_Brassards_Contondant = 4;
        public const int Ring_Brassards_Tranchant = 4;
        public const int Ring_Brassards_Perforant = 4;
        public const int Ring_Brassards_Magique = 4;
        public const int Ring_Brassards_Force = 12;
        public const int Ring_Brassards_Dex = -3;

        public const int Ring_Cuirasse = 4;
        public const int Ring_Cuirasse_Contondant = 4;
        public const int Ring_Cuirasse_Tranchant = 4;
        public const int Ring_Cuirasse_Perforant = 4;
        public const int Ring_Cuirasse_Magique = 4;
        public const int Ring_Cuirasse_Force = 15;
        public const int Ring_Cuirasse_Dex = -5;

        public const int Ring_Jambieres = 4;
        public const int Ring_Jambieres_Contondant = 4;
        public const int Ring_Jambieres_Tranchant = 4;
        public const int Ring_Jambieres_Perforant = 4;
        public const int Ring_Jambieres_Magique = 4;
        public const int Ring_Jambieres_Force = 10;
        public const int Ring_Jamvieres_Dex = -4;

        public const int Ring_MinDurabilite = 125;
        public const int Ring_MaxDurabilite = 150;

        //BOURGEON

        public const int Bourgeon_Brassards = 4;
        public const int Bourgeon_Brassards_Contondant = 4;
        public const int Bourgeon_Brassards_Tranchant = 4;
        public const int Bourgeon_Brassards_Perforant = 4;
        public const int Bourgeon_Brassards_Magique = 4;
        public const int Bourgeon_Brassards_Force = 12;

        public const int Bourgeon_Cuirasse = 4;
        public const int Bourgeon_Cuirasse_Contondant = 4;
        public const int Bourgeon_Cuirasse_Tranchant = 4;
        public const int Bourgeon_Cuirasse_Perforant = 4;
        public const int Bourgeon_Cuirasse_Magique = 4;
        public const int Bourgeon_Cuirasse_Force = 15;

        public const int Bourgeon_Jambieres = 4;
        public const int Bourgeon_Jambieres_Contondant = 4;
        public const int Bourgeon_Jambieres_Tranchant = 4;
        public const int Bourgeon_Jambieres_Perforant = 4;
        public const int Bourgeon_Jambieres_Magique = 4;
        public const int Bourgeon_Jambieres_Force = 10;

        public const int Bourgeon_MinDurabilite = 125;
        public const int Bourgeon_MaxDurabilite = 150;

        //Armure Barbare

        public const int ArmureBarbare_Cuirasse = 6; //= 10;
        public const int ArmureBarbare_Cuirasse_Contondant = 6; //= 10;
        public const int ArmureBarbare_Cuirasse_Tranchant = 6; //= 10;
        public const int ArmureBarbare_Cuirasse_Perforant = 6; //= 10;
        public const int ArmureBarbare_Cuirasse_Magique = 6; //= 10;
        public const int ArmureBarbare_Cuirasse_Force = 15;

        public const int ArmureBarbare_Jambieres = 6; //= 10;
        public const int ArmureBarbare_Jambieres_Contondant = 6; //= 10;
        public const int ArmureBarbare_Jambieres_Tranchant = 6; //= 10;
        public const int ArmureBarbare_Jambieres_Perforant = 6; //= 10;
        public const int ArmureBarbare_Jambieres_Magique = 6; //= 10;
        public const int ArmureBarbare_Jambieres_Force = 10;

        public const int ArmureBarbare_MinDurabilite = 125;
        public const int ArmureBarbare_MaxDurabilite = 150;

        //Maillons

        public const int Maillons_Brassards = 6;
        public const int Maillons_Brassards_Contondant = 6;
        public const int Maillons_Brassards_Tranchant = 6;
        public const int Maillons_Brassards_Perforant = 6;
        public const int Maillons_Brassards_Magique = 6;
        public const int Maillons_Brassards_Force = 13;

        public const int Maillons_Cuirasse = 6;
        public const int Maillons_Cuirasse_Contondant = 6;
        public const int Maillons_Cuirasse_Tranchant = 6;
        public const int Maillons_Cuirasse_Perforant = 6;
        public const int Maillons_Cuirasse_Magique = 6;
        public const int Maillons_Cuirasse_Force = 20;

        public const int Maillons_Jambieres = 6;
        public const int Maillons_Jambieres_Contondant = 6;
        public const int Maillons_Jambieres_Tranchant = 6;
        public const int Maillons_Jambieres_Perforant = 6;
        public const int Maillons_Jambieres_Magique = 6;
        public const int Maillons_Jambieres_Force = 15;

        public const int Maillons_MinDurabilite = 150;
        public const int Maillons_MaxDurabilite = 175;

        //Maillures

        public const int Maillures_Brassards = 6;
        public const int Maillures_Brassards_Contondant = 6;
        public const int Maillures_Brassards_Tranchant = 6;
        public const int Maillures_Brassards_Perforant = 6;
        public const int Maillures_Brassards_Magique = 6;
        public const int Maillures_Brassards_Force = 13;

        public const int Maillures_Cuirasse = 6;
        public const int Maillures_Cuirasse_Contondant = 6;
        public const int Maillures_Cuirasse_Tranchant = 6;
        public const int Maillures_Cuirasse_Perforant = 6;
        public const int Maillures_Cuirasse_Magique = 6;
        public const int Maillures_Cuirasse_Force = 20;

        public const int Maillures_Jambieres = 6;
        public const int Maillures_Jambieres_Contondant = 6;
        public const int Maillures_Jambieres_Tranchant = 6;
        public const int Maillures_Jambieres_Perforant = 6;
        public const int Maillures_Jambieres_Magique = 6;
        public const int Maillures_Jambieres_Force = 15;

        public const int Maillures_MinDurabilite = 150;
        public const int Maillures_MaxDurabilite = 175;

        //Chain

        public const int Chain_Casque = 8;
        public const int Chain_Casque_Contondant = 8;
        public const int Chain_Casque_Tranchant = 8;
        public const int Chain_Casque_Perforant = 8;
        public const int Chain_Casque_Magique = 8;
        public const int Chain_Casque_Force = 15;

        public const int Chain_Cuirasse = 8;
        public const int Chain_Cuirasse_Contondant = 8;
        public const int Chain_Cuirasse_Tranchant = 8;
        public const int Chain_Cuirasse_Perforant = 8;
        public const int Chain_Cuirasse_Magique = 8;
        public const int Chain_Cuirasse_Force = 30;

        public const int Chain_Jambieres = 8;
        public const int Chain_Jambieres_Contondant = 8;
        public const int Chain_Jambieres_Tranchant = 8;
        public const int Chain_Jambieres_Perforant = 8;
        public const int Chain_Jambieres_Magique = 8;
        public const int Chain_Jambieres_Force = 20;

        public const int Chain_MinDurabilite = 200;
        public const int Chain_MaxDurabilite = 225;

        //Chain Elfique

        public const int ChainElfique_Cuirasse = 8;
        public const int ChainElfique_Cuirasse_Contondant = 8;
        public const int ChainElfique_Cuirasse_Tranchant = 8;
        public const int ChainElfique_Cuirasse_Perforant = 8;
        public const int ChainElfique_Cuirasse_Magique = 8;
        public const int ChainElfique_Cuirasse_Force = 30;

        public const int ChainElfique_Jambieres = 8;
        public const int ChainElfique_Jambieres_Contondant = 8;
        public const int ChainElfique_Jambieres_Tranchant = 8;
        public const int ChainElfique_Jambieres_Perforant = 8;
        public const int ChainElfique_Jambieres_Magique = 8;
        public const int ChainElfique_Jambieres_Force = 20;

        public const int ChainElfique_MinDurabilite = 200;
        public const int ChainElfique_MaxDurabilite = 225;

        //Mailles

        public const int Mailles_Casque = 8;
        public const int Mailles_Casque_Contondant = 8;
        public const int Mailles_Casque_Tranchant = 8;
        public const int Mailles_Casque_Perforant = 8;
        public const int Mailles_Casque_Magique = 8;
        public const int Mailles_Casque_Force = 20;

        public const int Mailles_Cuirasse = 8;
        public const int Mailles_Cuirasse_Contondant = 8;
        public const int Mailles_Cuirasse_Tranchant = 8;
        public const int Mailles_Cuirasse_Perforant = 8;
        public const int Mailles_Cuirasse_Magique = 8;
        public const int Mailles_Cuirasse_Force = 35;

        public const int Mailles_Jambieres = 8;
        public const int Mailles_Jambieres_Contondant = 8;
        public const int Mailles_Jambieres_Tranchant = 8;
        public const int Mailles_Jambieres_Perforant = 8;
        public const int Mailles_Jambieres_Magique = 8;
        public const int Mailles_Jambieres_Force = 25;

        public const int Mailles_MinDurabilite = 200;
        public const int Mailles_MaxDurabilite = 225;

        //Plaque

        public const int Plaque_Casque = 9;
        public const int Plaque_Casque_Contondant = 9;
        public const int Plaque_Casque_Tranchant = 9;
        public const int Plaque_Casque_Perforant = 9;
        public const int Plaque_Casque_Magique = 9;
        public const int Plaque_Casque_Force = 30;

        public const int Plaque_Gorget = 9;
        public const int Plaque_Gorget_Contondant = 9;
        public const int Plaque_Gorget_Tranchant = 9;
        public const int Plaque_Gorget_Perforant = 9;
        public const int Plaque_Gorget_Magique = 9;
        public const int Plaque_Gorget_Force = 20;

        public const int Plaque_Gants = 9;
        public const int Plaque_Gants_Contondant = 9;
        public const int Plaque_Gants_Tranchant = 9;
        public const int Plaque_Gants_Perforant = 9;
        public const int Plaque_Gants_Magique = 9;
        public const int Plaque_Gants_Force = 30;

        public const int Plaque_Brassards = 9;
        public const int Plaque_Brassards_Contondant = 9;
        public const int Plaque_Brassards_Tranchant = 9;
        public const int Plaque_Brassards_Perforant = 9;
        public const int Plaque_Brassards_Magique = 9;
        public const int Plaque_Brassards_Force = 40;

        public const int Plaque_Cuirasse = 9;
        public const int Plaque_Cuirasse_Contondant = 9;
        public const int Plaque_Cuirasse_Tranchant = 9;
        public const int Plaque_Cuirasse_Perforant = 9;
        public const int Plaque_Cuirasse_Magique = 9;
        public const int Plaque_Cuirasse_Force = 50;

        public const int Plaque_Jambieres = 9;
        public const int Plaque_Jambieres_Contondant = 9;
        public const int Plaque_Jambieres_Tranchant = 9;
        public const int Plaque_Jambieres_Perforant = 9;
        public const int Plaque_Jambieres_Magique = 9;
        public const int Plaque_Jambieres_Force = 40;

        public const int Plaque_MinDurabilite = 225;
        public const int Plaque_MaxDurabilite = 250;

        //Plaque Elfique

        public const int PlaqueElfique_Gorget = 9;
        public const int PlaqueElfique_Gorget_Contondant = 9;
        public const int PlaqueElfique_Gorget_Tranchant = 9;
        public const int PlaqueElfique_Gorget_Perforant = 9;
        public const int PlaqueElfique_Gorget_Magique = 9;
        public const int PlaqueElfique_Gorget_Force = 20;

        public const int PlaqueElfique_Cuirasse = 9;
        public const int PlaqueElfique_Cuirasse_Contondant = 9;
        public const int PlaqueElfique_Cuirasse_Tranchant = 9;
        public const int PlaqueElfique_Cuirasse_Perforant = 9;
        public const int PlaqueElfique_Cuirasse_Magique = 9;
        public const int PlaqueElfique_Cuirasse_Force = 50;

        public const int PlaqueElfique_Jambieres = 9;
        public const int PlaqueElfique_Jambieres_Contondant = 9;
        public const int PlaqueElfique_Jambieres_Tranchant = 9;
        public const int PlaqueElfique_Jambieres_Perforant = 9;
        public const int PlaqueElfique_Jambieres_Magique = 9;
        public const int PlaqueElfique_Jambieres_Force = 40;

        public const int PlaqueElfique_MinDurabilite = 225;
        public const int PlaqueElfique_MaxDurabilite = 250;

        //Plaque Gothique

        public const int PlaqueGothique_Casque = 9;
        public const int PlaqueGothique_Casque_Contondant = 9;
        public const int PlaqueGothique_Casque_Tranchant = 9;
        public const int PlaqueGothique_Casque_Perforant = 9;
        public const int PlaqueGothique_Casque_Magique = 9;
        public const int PlaqueGothique_Casque_Force = 30;

        public const int PlaqueGothique_Brassards = 9;
        public const int PlaqueGothique_Brassards_Contondant = 9;
        public const int PlaqueGothique_Brassards_Tranchant = 9;
        public const int PlaqueGothique_Brassards_Perforant = 9;
        public const int PlaqueGothique_Brassards_Magique = 9;
        public const int PlaqueGothique_Brassards_Force = 50;

        public const int PlaqueGothique_Cuirasse = 9;
        public const int PlaqueGothique_Cuirasse_Contondant = 9;
        public const int PlaqueGothique_Cuirasse_Tranchant = 9;
        public const int PlaqueGothique_Cuirasse_Perforant = 9;
        public const int PlaqueGothique_Cuirasse_Magique = 9;
        public const int PlaqueGothique_Cuirasse_Force = 60;

        public const int PlaqueGothique_MinDurabilite = 225;
        public const int PlaqueGothique_MaxDurabilite = 250;

        //Plaque Barbare

        public const int PlaqueBarbare_Gorget = 9;
        public const int PlaqueBarbare_Gorget_Contondant = 9;
        public const int PlaqueBarbare_Gorget_Tranchant = 9;
        public const int PlaqueBarbare_Gorget_Perforant = 9;
        public const int PlaqueBarbare_Gorget_Magique = 9;
        public const int PlaqueBarbare_Gorget_Force = 20;

        public const int PlaqueBarbare_Brassards = 9;
        public const int PlaqueBarbare_Brassards_Contondant = 9;
        public const int PlaqueBarbare_Brassards_Tranchant = 9;
        public const int PlaqueBarbare_Brassards_Perforant = 9;
        public const int PlaqueBarbare_Brassards_Magique = 9;
        public const int PlaqueBarbare_Brassards_Force = 40;

        public const int PlaqueBarbare_Cuirasse = 9;
        public const int PlaqueBarbare_Cuirasse_Contondant = 9;
        public const int PlaqueBarbare_Cuirasse_Tranchant = 9;
        public const int PlaqueBarbare_Cuirasse_Perforant = 9;
        public const int PlaqueBarbare_Cuirasse_Magique = 9;
        public const int PlaqueBarbare_Cuirasse_Force = 50;

        public const int PlaqueBarbare_Jambieres = 9;
        public const int PlaqueBarbare_Jambieres_Contondant = 9;
        public const int PlaqueBarbare_Jambieres_Tranchant = 9;
        public const int PlaqueBarbare_Jambieres_Perforant = 9;
        public const int PlaqueBarbare_Jambieres_Magique = 9;
        public const int PlaqueBarbare_Jambieres_Force = 40;

        public const int PlaqueBarbare_MinDurabilite = 225;
        public const int PlaqueBarbare_MaxDurabilite = 250;

        //Plaque Orné

        public const int PlaqueOrne_Brassards = 10;
        public const int PlaqueOrne_Brassards_Contondant = 10;
        public const int PlaqueOrne_Brassards_Tranchant = 10;
        public const int PlaqueOrne_Brassards_Perforant = 10;
        public const int PlaqueOrne_Brassards_Magique = 10;
        public const int PlaqueOrne_Brassards_Force = 60;

        public const int PlaqueOrne_Cuirasse = 10;
        public const int PlaqueOrne_Cuirasse_Contondant = 10;
        public const int PlaqueOrne_Cuirasse_Tranchant = 10;
        public const int PlaqueOrne_Cuirasse_Perforant = 10;
        public const int PlaqueOrne_Cuirasse_Magique = 10;
        public const int PlaqueOrne_Cuirasse_Force = 70;

        public const int PlaqueOrne_MinDurabilite = 250;
        public const int PlaqueOrne_MaxDurabilite = 300;

        //Plaque Décoré

        public const int PlaqueDecore_Casque = 10;
        public const int PlaqueDecore_Casque_Contondant = 10;
        public const int PlaqueDecore_Casque_Tranchant = 10;
        public const int PlaqueDecore_Casque_Perforant = 10;
        public const int PlaqueDecore_Casque_Magique = 10;
        public const int PlaqueDecore_Casque_Force = 40;

        public const int PlaqueDecore_Gorget = 10;
        public const int PlaqueDecore_Gorget_Contondant = 10;
        public const int PlaqueDecore_Gorget_Tranchant = 10;
        public const int PlaqueDecore_Gorget_Perforant = 10;
        public const int PlaqueDecore_Gorget_Magique = 10;
        public const int PlaqueDecore_Gorget_Force = 25;

        public const int PlaqueDecore_Gants = 10;
        public const int PlaqueDecore_Gants_Contondant = 10;
        public const int PlaqueDecore_Gants_Tranchant = 10;
        public const int PlaqueDecore_Gants_Perforant = 10;
        public const int PlaqueDecore_Gants_Magique = 10;
        public const int PlaqueDecore_Gants_Force = 35;

        public const int PlaqueDecore_Brassards = 10;
        public const int PlaqueDecore_Brassards_Contondant = 10;
        public const int PlaqueDecore_Brassards_Tranchant = 10;
        public const int PlaqueDecore_Brassards_Perforant = 10;
        public const int PlaqueDecore_Brassards_Magique = 10;
        public const int PlaqueDecore_Brassards_Force = 60;

        public const int PlaqueDecore_Cuirasse = 10;
        public const int PlaqueDecore_Cuirasse_Contondant = 10;
        public const int PlaqueDecore_Cuirasse_Tranchant = 10;
        public const int PlaqueDecore_Cuirasse_Perforant = 10;
        public const int PlaqueDecore_Cuirasse_Magique = 10;
        public const int PlaqueDecore_Cuirasse_Force = 70;

        public const int PlaqueDecore_Jambieres = 10;
        public const int PlaqueDecore_Jambieres_Contondant = 10;
        public const int PlaqueDecore_Jambieres_Tranchant = 10;
        public const int PlaqueDecore_Jambieres_Perforant = 10;
        public const int PlaqueDecore_Jambieres_Magique = 10;
        public const int PlaqueDecore_Jambieres_Force = 60;

        public const int PlaqueDecore_MinDurabilite = 250;
        public const int PlaqueDecore_MaxDurabilite = 300;

        //Plaque Noble

        public const int PlaqueNoble_Casque = 10;
        public const int PlaqueNoble_Casque_Contondant = 10;
        public const int PlaqueNoble_Casque_Tranchant = 10;
        public const int PlaqueNoble_Casque_Perforant = 10;
        public const int PlaqueNoble_Casque_Magique = 10;
        public const int PlaqueNoble_Casque_Force = 40;

        public const int PlaqueNoble_Gorget = 10;
        public const int PlaqueNoble_Gorget_Contondant = 10;
        public const int PlaqueNoble_Gorget_Tranchant = 10;
        public const int PlaqueNoble_Gorget_Perforant = 10;
        public const int PlaqueNoble_Gorget_Magique = 10;
        public const int PlaqueNoble_Gorget_Force = 25;

        public const int PlaqueNoble_Gants = 10;
        public const int PlaqueNoble_Gants_Contondant = 10;
        public const int PlaqueNoble_Gants_Tranchant = 10;
        public const int PlaqueNoble_Gants_Perforant = 10;
        public const int PlaqueNoble_Gants_Magique = 10;
        public const int PlaqueNoble_Gants_Force = 35;

        public const int PlaqueNoble_Brassards = 10;
        public const int PlaqueNoble_Brassards_Contondant = 10;
        public const int PlaqueNoble_Brassards_Tranchant = 10;
        public const int PlaqueNoble_Brassards_Perforant = 10;
        public const int PlaqueNoble_Brassards_Magique = 10;
        public const int PlaqueNoble_Brassards_Force = 60;

        public const int PlaqueNoble_Cuirasse = 10;
        public const int PlaqueNoble_Cuirasse_Contondant = 10;
        public const int PlaqueNoble_Cuirasse_Tranchant = 10;
        public const int PlaqueNoble_Cuirasse_Perforant = 10;
        public const int PlaqueNoble_Cuirasse_Magique = 10;
        public const int PlaqueNoble_Cuirasse_Force = 70;

        public const int PlaqueNoble_Jambieres = 10;
        public const int PlaqueNoble_Jambieres_Contondant = 10;
        public const int PlaqueNoble_Jambieres_Tranchant = 10;
        public const int PlaqueNoble_Jambieres_Perforant = 10;
        public const int PlaqueNoble_Jambieres_Magique = 10;
        public const int PlaqueNoble_Jambieres_Force = 60;

        public const int PlaqueNoble_MinDurabilite = 250;
        public const int PlaqueNoble_MaxDurabilite = 300;

        //Plaque Daedric

        public const int PlaqueDaedric_Casque = 10;
        public const int PlaqueDaedric_Casque_Contondant = 10;
        public const int PlaqueDaedric_Casque_Tranchant = 10;
        public const int PlaqueDaedric_Casque_Perforant = 10;
        public const int PlaqueDaedric_Casque_Magique = 10;
        public const int PlaqueDaedric_Casque_Force = 40;

        public const int PlaqueDaedric_Gorget = 10;
        public const int PlaqueDaedric_Gorget_Contondant = 10;
        public const int PlaqueDaedric_Gorget_Tranchant = 10;
        public const int PlaqueDaedric_Gorget_Perforant = 10;
        public const int PlaqueDaedric_Gorget_Magique = 10;
        public const int PlaqueDaedric_Gorget_Force = 25;

        public const int PlaqueDaedric_Gants = 10;
        public const int PlaqueDaedric_Gants_Contondant = 10;
        public const int PlaqueDaedric_Gants_Tranchant = 10;
        public const int PlaqueDaedric_Gants_Perforant = 10;
        public const int PlaqueDaedric_Gants_Magique = 10;
        public const int PlaqueDaedric_Gants_Force = 35;

        public const int PlaqueDaedric_Brassards = 10;
        public const int PlaqueDaedric_Brassards_Contondant = 10;
        public const int PlaqueDaedric_Brassards_Tranchant = 10;
        public const int PlaqueDaedric_Brassards_Perforant = 10;
        public const int PlaqueDaedric_Brassards_Magique = 10;
        public const int PlaqueDaedric_Brassards_Force = 60;

        public const int PlaqueDaedric_Cuirasse = 10;
        public const int PlaqueDaedric_Cuirasse_Contondant = 10;
        public const int PlaqueDaedric_Cuirasse_Tranchant = 10;
        public const int PlaqueDaedric_Cuirasse_Perforant = 10;
        public const int PlaqueDaedric_Cuirasse_Magique = 10;
        public const int PlaqueDaedric_Cuirasse_Force = 70;

        public const int PlaqueDaedric_Jambieres = 10;
        public const int PlaqueDaedric_Jambieres_Contondant = 10;
        public const int PlaqueDaedric_Jambieres_Tranchant = 10;
        public const int PlaqueDaedric_Jambieres_Perforant = 10;
        public const int PlaqueDaedric_Jambieres_Magique = 10;
        public const int PlaqueDaedric_Jambieres_Force = 60;

        public const int PlaqueDaedric_MinDurabilite = 250;
        public const int PlaqueDaedric_MaxDurabilite = 300;

        //Divers
        public const int TuniqueChaine = 6; //= 8;
        public const int TuniqueChaine_Contondant = 6; //= 8;
        public const int TuniqueChaine_Tranchant = 6; //= 8;
        public const int TuniqueChaine_Perforant = 6; //= 8;
        public const int TuniqueChaine_Magique = 6; //= 8;
        public const int TuniqueChaine_Force = 20;
        public const int TuniqueChaine_MinDurabilite = 150;
        public const int TuniqueChaine_MaxDurabilite = 175;

        public const int CuirasseReligieuse = 8;
        public const int CuirasseReligieuse_Contondant = 8;
        public const int CuirasseReligieuse_Tranchant = 8;
        public const int CuirasseReligieuse_Perforant = 8;
        public const int CuirasseReligieuse_Magique = 8;
        public const int CuirasseReligieuse_Force = 30;
        public const int CuirasseReligieuse_MinDurabilite = 200;
        public const int CuirasseReligieuse_MaxDurabilite = 225;

        public const int Cuirasse = 10;
        public const int Cuirasse_Contondant = 10;
        public const int Cuirasse_Tranchant = 10;
        public const int Cuirasse_Perforant = 10;
        public const int Cuirasse_Magique = 10;
        public const int Cuirasse_Force = 50;
        public const int Cuirasse_MinDurabilite = 225;
        public const int Cuirasse_MaxDurabilite = 250;

        public const int CuirasseBarbare = 10;
        public const int CuirasseBarbare_Contondant = 10;
        public const int CuirasseBarbare_Tranchant = 10;
        public const int CuirasseBarbare_Perforant = 10;
        public const int CuirasseBarbare_Magique = 10;
        public const int CuirasseBarbare_Force = 30;
        public const int CuirasseBarbare_MinDurabilite = 200;
        public const int CuirasseBarbare_MaxDurabilite = 225;

        public const int CuirasseNordique = 10;
        public const int CuirasseNordique_Contondant = 10;
        public const int CuirasseNordique_Tranchant = 10;
        public const int CuirasseNordique_Perforant = 10;
        public const int CuirasseNordique_Magique = 10;
        public const int CuirasseNordique_Force = 50;
        public const int CuirasseNordique_MinDurabilite = 225;
        public const int CuirasseNordique_MaxDurabilite = 250;

        public const int CuirasseDraconique_Cuirasse = 10;
        public const int CuirasseDraconique_Cuirasse_Contondant = 10;
        public const int CuirasseDraconique_Cuirasse_Tranchant = 10;
        public const int CuirasseDraconique_Cuirasse_Perforant = 10;
        public const int CuirasseDraconique_Cuirasse_Magique = 10;
        public const int CuirasseDraconique_Cuirasse_Force = 70;
        public const int CuirasseDraconique_MinDurabilite = 250;
        public const int CuirasseDraconique_MaxDurabilite = 300;

        public const int CasqueNordique = 6;
        public const int CasqueNordique_Contondant = 6;
        public const int CasqueNordique_Tranchant = 6;
        public const int CasqueNordique_Perforant = 6;
        public const int CasqueNordique_Magique = 6;
        public const int CasqueNordique_Force = 15;
        public const int CasqueNordique_MinDurabilite = 200;
        public const int CasqueNordique_MaxDurabilite = 225;

        public const int CasqueNomade = 6;
        public const int CasqueNomade_Contondant = 6;
        public const int CasqueNomade_Tranchant = 6;
        public const int CasqueNomade_Perforant = 6;
        public const int CasqueNomade_Magique = 6;
        public const int CasqueNomade_Force = 15;
        public const int CasqueNomade_MinDurabilite = 200;
        public const int CasqueNomade_MaxDurabilite = 225;

        public const int CasqueCorne = 8;
        public const int CasqueCorne_Contondant = 8;
        public const int CasqueCorne_Tranchant = 8;
        public const int CasqueCorne_Perforant = 8;
        public const int CasqueCorne_Magique = 8;
        public const int CasqueCorne_Force = 30;
        public const int CasqueCorne_MinDurabilite = 225;
        public const int CasqueCorne_MaxDurabilite = 250;

        public const int Brassards = 10;
        public const int Brassards_Contondant = 10;
        public const int Brassards_Tranchant = 10;
        public const int Brassards_Perforant = 10;
        public const int Brassards_Magique = 10;
        public const int Brassards_Force = 40;
        public const int Brassards_MinDurabilite = 225;
        public const int Brassards_MaxDurabilite = 250;

        public const int BrassardsChaotique = 10;
        public const int BrassardsChaotique_Contondant = 10;
        public const int BrassardsChaotique_Tranchant = 10;
        public const int BrassardsChaotique_Perforant = 10;
        public const int BrassardsChaotique_Magique = 10;
        public const int BrassardsChaotique_Force = 60;
        public const int BrassardsChaotique_MinDurabilite = 250;
        public const int BrassardsChaotique_MaxDurabilite = 300;

        #endregion

        #region Factions
        private FactionItem m_FactionState;

        public FactionItem FactionItemState
        {
            get { return m_FactionState; }
            set
            {
                m_FactionState = value;

                if (m_FactionState == null)
                    Hue = CraftResources.GetHue(Resource);

                LootType = (m_FactionState == null ? LootType.Regular : LootType.Blessed);
            }
        }
        #endregion

        public virtual int NiveauAttirail { get { return 0; } }



        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);

            if (RootParent is Mobile)
            {
                if ((Mobile)RootParent == from)
                {
                    if (from.FindItemOnLayer(this.Layer) == this)
                        list.Add(new UnEquipEntry(from, this));
                    else
                        list.Add(new EquipEntry(from, this));
                }
            }
            else if (RootParent is Item || RootParent == null)
            {
                if (from.FindItemOnLayer(this.Layer) == this)
                    list.Add(new UnEquipEntry(from, this));
                else
                    list.Add(new EquipEntry(from, this));
            }
        }

        private class EquipEntry : ContextMenuEntry
        {
            private Mobile m_From;
            private BaseArmor m_Item;

            public EquipEntry(Mobile from, Item item)
                : base(6163, -1)
            {
                m_From = (Mobile)from;
                m_Item = (BaseArmor)item;
            }

            public override void OnClick()
            {
                Item[] candidates = m_From.Backpack.FindItemsByType(m_Item.GetType());
                Boolean found = false;
                foreach(Item i in candidates)
                {
                    if (m_Item == i) found = true;
                }
                if (!found)
                {
                    m_From.SendMessage("L'objet doit être dans votre sac pour que vous l'équipiez.");
                    return;
                }
                if (((BaseArmor)m_Item).CanEquip(m_From))
                {
                    if (!(m_From.EquipItem(m_Item)))
                        m_From.SendMessage("Vous ne parvenez pas a equiper cet objet.");
                }
                else
                {
                    m_From.SendMessage("Vous ne pouvez pas equiper cet objet !");
                }
            }
        }

        private class UnEquipEntry : ContextMenuEntry
        {
            private Mobile m_From;
            private BaseArmor m_Item;

            public UnEquipEntry(Mobile from, Item item)
                : base(6164, -1)
            {
                m_From = (Mobile)from;
                m_Item = (BaseArmor)item;
            }

            public override void OnClick()
            {
                m_From.PlaceInBackpack(m_Item);
                //m_From.EquipItem(m_Item);
            }
        }

        /* Armor internals work differently now (Jun 19 2003)
         * 
         * The attributes defined below default to -1.
         * If the value is -1, the corresponding virtual 'Aos/Old' property is used.
         * If not, the attribute value itself is used. Here's the list:
         *  - ArmorBase
         *  - StrBonus
         *  - DexBonus
         *  - IntBonus
         *  - StrReq
         *  - DexReq
         *  - IntReq
         *  - MeditationAllowance
         */

        // Instance values. These values must are unique to each armor piece.
        private int m_MaxHitPoints;
        private int m_HitPoints;
        private Mobile m_Crafter;
        private ArmorQuality m_Quality;
        private ArmorDurabilityLevel m_Durability;
        private ArmorProtectionLevel m_Protection;
        private CraftResource m_Resource;
        private bool m_Identified, m_PlayerConstructed;
        private int m_PhysicalBonus, m_ContondantBonus, m_TranchantBonus, m_PerforantBonus, m_MagieBonus;

        private AosAttributes m_AosAttributes;
        private AosArmorAttributes m_AosArmorAttributes;
        private AosSkillBonuses m_AosSkillBonuses;

        // Overridable values. These values are provided to override the defaults which get defined in the individual armor scripts.
        private int m_ArmorBase = -1;
        private int m_StrBonus = -1, m_DexBonus = -1, m_IntBonus = -1;
        private int m_StrReq = -1, m_DexReq = -1, m_IntReq = -1;
        private AMA m_Meditate = (AMA)(-1);


        public virtual bool AllowMaleWearer { get { return true; } }
        public virtual bool AllowFemaleWearer { get { return true; } }

        public abstract AMT MaterialType { get; }

        public virtual int RevertArmorBase { get { return ArmorBase; } }
        public virtual int ArmorBase { get { return 0; } }

        public virtual AMA DefMedAllowance { get { return AMA.None; } }
        public virtual AMA AosMedAllowance { get { return DefMedAllowance; } }
        public virtual AMA OldMedAllowance { get { return DefMedAllowance; } }


        public virtual int AosStrBonus { get { return 0; } }
        public virtual int AosDexBonus { get { return 0; } }
        public virtual int AosIntBonus { get { return 0; } }
        public virtual int AosStrReq { get { return 0; } }
        public virtual int AosDexReq { get { return 0; } }
        public virtual int AosIntReq { get { return 0; } }


        public virtual int OldStrBonus { get { return 0; } }
        public virtual int OldDexBonus { get { return 0; } }
        public virtual int OldIntBonus { get { return 0; } }
        public virtual int OldStrReq { get { return 0; } }
        public virtual int OldDexReq { get { return 0; } }
        public virtual int OldIntReq { get { return 0; } }

        public virtual bool CanFortify { get { return true; } }

        private RareteItem m_rarete;
        private TemraelAttributes m_TemraelAttributes;

        [CommandProperty(AccessLevel.GameMaster)]
        public TemraelAttributes TemAttributes
        {
            get { return m_TemraelAttributes; }
            set { }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public RareteItem Rarete
        {
            get { return m_rarete; }
            set { m_rarete = value; InvalidateProperties(); }
        }

        public override void OnAfterDuped(Item newItem)
        {
            BaseArmor armor = newItem as BaseArmor;

            if (armor == null)
                return;

            armor.m_AosAttributes = new AosAttributes(newItem, m_AosAttributes);
            armor.m_AosArmorAttributes = new AosArmorAttributes(newItem, m_AosArmorAttributes);
            armor.m_AosSkillBonuses = new AosSkillBonuses(newItem, m_AosSkillBonuses);
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public AMA MeditationAllowance
        {
            get { return (m_Meditate == (AMA)(-1) ? Core.AOS ? AosMedAllowance : OldMedAllowance : m_Meditate); }
            set { m_Meditate = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int BaseArmorRating
        {
            get
            {
                if (m_ArmorBase == -1)
                    return ArmorBase;
                else
                    return m_ArmorBase;
            }
            set
            {
                m_ArmorBase = value; Invalidate();
            }
        }

        public double BaseArmorRatingScaled
        {
            get
            {
                return (BaseArmorRating * ArmorScalar);
            }
        }

        public virtual double ArmorRating
        {
            get
            {
                int ar = BaseArmorRating;

                if (m_Protection != ArmorProtectionLevel.Regular)
                    ar += 10 + (5 * (int)m_Protection);

                switch (m_Resource)
                {
                    case CraftResource.Cuivre: ar += 1; break;
                    case CraftResource.Bronze: ar += 1; break;
                    case CraftResource.Acier: ar += 2; break;
                    case CraftResource.Argent: ar += 2; break;
                    case CraftResource.Or: ar += 2; break;
                    case CraftResource.Mytheril: ar += 3; break;
                    case CraftResource.Luminium: ar += 3; break;
                    case CraftResource.Obscurium: ar += 3; break;
                    case CraftResource.Mystirium: ar += 4; break;
                    case CraftResource.Dominium: ar += 4; break;
                    case CraftResource.Venarium: ar += 4; break;
                    case CraftResource.Eclarium: ar += 5; break;
                    case CraftResource.Athenium: ar += 5; break;
                    case CraftResource.Umbrarium: ar += 5; break;

                    case CraftResource.NordiqueLeather: ar += 2; break;
                    case CraftResource.DesertiqueLeather: ar += 2; break;
                    case CraftResource.MaritimeLeather: ar += 4; break;
                    case CraftResource.VolcaniqueLeather: ar += 4; break;
                    case CraftResource.GeantLeather: ar += 6; break;
                    case CraftResource.OphidienLeather: ar += 6; break;
                    case CraftResource.ArachnideLeather: ar += 6; break;
                    case CraftResource.AncienLeather: ar += 10; break;
                    case CraftResource.DemoniaqueLeather: ar += 10; break;
                    case CraftResource.DragoniqueLeather: ar += 12; break;
                    case CraftResource.LupusLeather: ar += 12; break;

                    case CraftResource.NordiqueBones: ar += 2; break;
                    case CraftResource.DesertiqueBones: ar += 2; break;
                    case CraftResource.MaritimeBones: ar += 4; break;
                    case CraftResource.VolcaniqueBones: ar += 4; break;
                    case CraftResource.GeantBones: ar += 6; break;
                    case CraftResource.OphidienBones: ar += 6; break;
                    case CraftResource.ArachnideBones: ar += 6; break;
                    case CraftResource.AncienBones: ar += 10; break;
                    case CraftResource.DemonBones: ar += 10; break;
                    case CraftResource.DragonBones: ar += 10; break;
                    case CraftResource.BalronBones: ar += 12; break;
                    case CraftResource.WyrmBones: ar += 12; break;
                }

                ar += -8 + (8 * (int)m_Quality);
                return ScaleArmorByDurability(ar);
            }
        }

        public double ArmorRatingScaled
        {
            get
            {
                return (ArmorRating * ArmorScalar);
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int StrBonus
        {
            get { return (m_StrBonus == -1 ? Core.AOS ? AosStrBonus : OldStrBonus : m_StrBonus); }
            set { m_StrBonus = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int DexBonus
        {
            get { return (m_DexBonus == -1 ? Core.AOS ? AosDexBonus : OldDexBonus : m_DexBonus); }
            set { m_DexBonus = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int IntBonus
        {
            get { return (m_IntBonus == -1 ? Core.AOS ? AosIntBonus : OldIntBonus : m_IntBonus); }
            set { m_IntBonus = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int StrRequirement
        {
            get { return (m_StrReq == -1 ? Core.AOS ? AosStrReq : OldStrReq : m_StrReq); }
            set { m_StrReq = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int DexRequirement
        {
            get { return (m_DexReq == -1 ? Core.AOS ? AosDexReq : OldDexReq : m_DexReq); }
            set { m_DexReq = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int IntRequirement
        {
            get { return (m_IntReq == -1 ? Core.AOS ? AosIntReq : OldIntReq : m_IntReq); }
            set { m_IntReq = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Identified
        {
            get { return m_Identified; }
            set { m_Identified = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool PlayerConstructed
        {
            get { return m_PlayerConstructed; }
            set { m_PlayerConstructed = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public CraftResource Resource
        {
            get
            {
                return m_Resource;
            }
            set
            {
                if (m_Resource != value)
                {
                    UnscaleDurability();

                    m_Resource = value;

                    if (!DefTailoring.IsNonColorable(this.GetType()))
                    {
                        Hue = CraftResources.GetHue(m_Resource);
                    }

                    Invalidate();
                    InvalidateProperties();

                    if (Parent is Mobile)
                        ((Mobile)Parent).UpdateResistances();

                    ScaleDurability();
                }
            }
        }

        public virtual double ArmorScalar
        {
            get
            {
                int pos = (int)BodyPosition;

                if (pos >= 0 && pos < m_ArmorScalars.Length)
                    return m_ArmorScalars[pos];

                return 1.0;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int MaxHitPoints
        {
            get { return m_MaxHitPoints; }
            set { m_MaxHitPoints = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int HitPoints
        {
            get
            {
                return m_HitPoints;
            }
            set
            {
                if (value != m_HitPoints && MaxHitPoints > 0)
                {
                    m_HitPoints = value;

                    if (m_HitPoints < 0)
                        Delete();
                    else if (m_HitPoints > MaxHitPoints)
                        m_HitPoints = MaxHitPoints;

                    InvalidateProperties();
                }
            }
        }


        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Crafter
        {
            get { return m_Crafter; }
            set { m_Crafter = value; InvalidateProperties(); }
        }


        [CommandProperty(AccessLevel.GameMaster)]
        public ArmorQuality Quality
        {
            get { return m_Quality; }
            set { UnscaleDurability(); m_Quality = value; Invalidate(); InvalidateProperties(); ScaleDurability(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public ArmorDurabilityLevel Durability
        {
            get { return m_Durability; }
            set { UnscaleDurability(); m_Durability = value; ScaleDurability(); InvalidateProperties(); }
        }

        public virtual int ArtifactRarity
        {
            get { return 0; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public ArmorProtectionLevel ProtectionLevel
        {
            get
            {
                return m_Protection;
            }
            set
            {
                if (m_Protection != value)
                {
                    m_Protection = value;

                    Invalidate();
                    InvalidateProperties();

                    if (Parent is Mobile)
                        ((Mobile)Parent).UpdateResistances();
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public AosAttributes Attributes
        {
            get { return m_AosAttributes; }
            set { }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public AosArmorAttributes ArmorAttributes
        {
            get { return m_AosArmorAttributes; }
            set { }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public AosSkillBonuses SkillBonuses
        {
            get { return m_AosSkillBonuses; }
            set { }
        }

        public int ComputeStatReq(StatType type)
        {
            int v;

            if (type == StatType.Str)
                v = StrRequirement;
            else if (type == StatType.Dex)
                v = DexRequirement;
            else
                v = IntRequirement;

            return AOS.Scale(v, 100 - GetLowerStatReq());
        }

        public int ComputeStatBonus(StatType type)
        {
            if (type == StatType.Str)
                return StrBonus + Attributes.BonusStr;
            else if (type == StatType.Dex)
                return DexBonus + Attributes.BonusDex;
            else
                return IntBonus + Attributes.BonusInt;
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int PhysicalBonus { get { return m_PhysicalBonus; } set { m_PhysicalBonus = value; InvalidateProperties(); } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int ContondantBonus { get { return m_ContondantBonus; } set { m_ContondantBonus = value; InvalidateProperties(); } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int TranchantBonus { get { return m_TranchantBonus; } set { m_TranchantBonus = value; InvalidateProperties(); } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int PerforantBonus { get { return m_PerforantBonus; } set { m_PerforantBonus = value; InvalidateProperties(); } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int MagieBonus { get { return m_MagieBonus; } set { m_MagieBonus = value; InvalidateProperties(); } }

        public virtual int BasePhysicalResistance { get { return 0; } }
        public virtual int BaseContondantResistance { get { return 0; } }
        public virtual int BaseTranchantResistance { get { return 0; } }
        public virtual int BasePerforantResistance { get { return 0; } }
        public virtual int BaseMagieResistance { get { return 0; } }

        public override int PhysicalResistance { get { return BasePhysicalResistance + GetProtOffset() + GetResourceAttrs().ArmorPhysicalResist + m_PhysicalBonus; } }
        public override int ContondantResistance { get { return BaseContondantResistance + GetProtOffset() + GetResourceAttrs().ArmorContondantResist + m_ContondantBonus; } }
        public override int TranchantResistance { get { return BaseTranchantResistance + GetProtOffset() + GetResourceAttrs().ArmorTranchantResist + m_TranchantBonus; } }
        public override int PerforantResistance { get { return BasePerforantResistance + GetProtOffset() + GetResourceAttrs().ArmorPerforantResist + m_PerforantBonus; } }
        public override int MagieResistance { get { return (int)(0.25*(BaseMagieResistance + GetProtOffset() + GetResourceAttrs().ArmorMagieResist)) + m_MagieBonus; } }

        public virtual int InitMinHits { get { return 0; } }
        public virtual int InitMaxHits { get { return 0; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public ArmorBodyType BodyPosition
        {
            get
            {
                switch (this.Layer)
                {
                    default:
                    case Layer.Neck: return ArmorBodyType.Gorget;
                    case Layer.TwoHanded: return ArmorBodyType.Shield;
                    case Layer.Gloves: return ArmorBodyType.Gloves;
                    case Layer.Helm: return ArmorBodyType.Helmet;
                    case Layer.Arms: return ArmorBodyType.Arms;

                    case Layer.InnerLegs:
                    case Layer.OuterLegs:
                    case Layer.Pants: return ArmorBodyType.Legs;

                    case Layer.InnerTorso:
                    case Layer.OuterTorso:
                    case Layer.Shirt: return ArmorBodyType.Chest;
                }
            }
        }

        public void DistributeBonuses(int amount)
        {
            for (int i = 0; i < amount; ++i)
            {
                switch (Utility.Random(5))
                {
                    case 0: ++m_PhysicalBonus; break;
                    case 1: ++m_ContondantBonus; break;
                    case 2: ++m_TranchantBonus; break;
                    case 3: ++m_PerforantBonus; break;
                    case 4: ++m_MagieBonus; break;
                }
            }

            InvalidateProperties();
        }

        public CraftAttributeInfo GetResourceAttrs()
        {
            CraftResourceInfo info = CraftResources.GetInfo(m_Resource);

            if (info == null)
                return CraftAttributeInfo.Blank;

            return info.AttributeInfo;
        }

        public int GetProtOffset()
        {
            switch (m_Protection)
            {
                case ArmorProtectionLevel.Guarding: return 1;
                case ArmorProtectionLevel.Hardening: return 2;
                case ArmorProtectionLevel.Fortification: return 3;
                case ArmorProtectionLevel.Invulnerability: return 4;
            }

            return 0;
        }

        public void UnscaleDurability()
        {
            int scale = 100 + GetDurabilityBonus();

            m_HitPoints = ((m_HitPoints * 100) + (scale - 1)) / scale;
            m_MaxHitPoints = ((m_MaxHitPoints * 100) + (scale - 1)) / scale;
            InvalidateProperties();
        }

        public void ScaleDurability()
        {
            int scale = 100 + GetDurabilityBonus();

            m_HitPoints = ((m_HitPoints * scale) + 99) / 100;
            m_MaxHitPoints = ((m_MaxHitPoints * scale) + 99) / 100;
            InvalidateProperties();
        }

        public int GetDurabilityBonus()
        {
            int bonus = 0;

            if (m_Quality == ArmorQuality.Exceptional)
                bonus += 20;

            switch (m_Durability)
            {
                case ArmorDurabilityLevel.Durable: bonus += 20; break;
                case ArmorDurabilityLevel.Substantial: bonus += 50; break;
                case ArmorDurabilityLevel.Massive: bonus += 70; break;
                case ArmorDurabilityLevel.Fortified: bonus += 100; break;
                case ArmorDurabilityLevel.Indestructible: bonus += 120; break;
            }

            if (Core.AOS)
            {
                bonus += m_AosArmorAttributes.DurabilityBonus;

                CraftResourceInfo resInfo = CraftResources.GetInfo(m_Resource);
                CraftAttributeInfo attrInfo = null;

                if (resInfo != null)
                    attrInfo = resInfo.AttributeInfo;

                if (attrInfo != null)
                    bonus += attrInfo.ArmorDurability;
            }

            return bonus;
        }

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack.
                return false;
            }

            if (Ethics.Ethic.IsImbued(this))
            {
                from.SendLocalizedMessage(502440); // Scissors can not be used on that to produce anything.
                return false;
            }

            CraftSystem system = DefTailoring.CraftSystem;

            CraftItem item = system.CraftItems.SearchFor(GetType());

            if (item != null && item.Resources.Count == 1 && item.Resources.GetAt(0).Amount >= 2)
            {
                try
                {
                    Item res = (Item)Activator.CreateInstance(CraftResources.GetInfo(m_Resource).ResourceTypes[0]);

                    ScissorHelper(from, res, m_PlayerConstructed ? (item.Resources.GetAt(0).Amount / 2) : 1);
                    return true;
                }
                catch
                {
                }
            }

            from.SendLocalizedMessage(502440); // Scissors can not be used on that to produce anything.
            return false;
        }

        private static double[] m_ArmorScalars = { 0.07, 0.07, 0.14, 0.15, 0.22, 0.35 };

        public static double[] ArmorScalars
        {
            get
            {
                return m_ArmorScalars;
            }
            set
            {
                m_ArmorScalars = value;
            }
        }

        public static void ValidateMobile(Mobile m)
        {
            for (int i = m.Items.Count - 1; i >= 0; --i)
            {
                if (i >= m.Items.Count)
                    continue;

                Item item = m.Items[i];

                if (item is BaseArmor)
                {
                    BaseArmor armor = (BaseArmor)item;

                    if (armor.RequiredRace != null && m.Race != armor.RequiredRace)
                    {
                        if (armor.RequiredRace == Race.Elf)
                            m.SendLocalizedMessage(1072203); // Only Elves may use this.
                        else
                            m.SendMessage("Only {0} may use this.", armor.RequiredRace.PluralName);

                        m.AddToBackpack(armor);
                    }
                    else if (!armor.AllowMaleWearer && !m.Female && m.AccessLevel < AccessLevel.GameMaster)
                    {
                        if (armor.AllowFemaleWearer)
                            m.SendLocalizedMessage(1010388); // Only females can wear this.
                        else
                            m.SendMessage("You may not wear this.");

                        m.AddToBackpack(armor);
                    }
                    else if (!armor.AllowFemaleWearer && m.Female && m.AccessLevel < AccessLevel.GameMaster)
                    {
                        if (armor.AllowMaleWearer)
                            m.SendLocalizedMessage(1063343); // Only males can wear this.
                        else
                            m.SendMessage("You may not wear this.");

                        m.AddToBackpack(armor);
                    }
                }
            }
        }

        public int GetLowerStatReq()
        {
            if (!Core.AOS)
                return 0;

            int v = m_AosArmorAttributes.LowerStatReq;

            CraftResourceInfo info = CraftResources.GetInfo(m_Resource);

            if (info != null)
            {
                CraftAttributeInfo attrInfo = info.AttributeInfo;

                if (attrInfo != null)
                    v += attrInfo.ArmorLowerRequirements;
            }

            if (v > 100)
                v = 100;

            return v;
        }

        public override void OnAdded(object parent)
        {
            if (parent is Mobile)
            {
                Mobile from = (Mobile)parent;

                if (Core.AOS)
                    m_AosSkillBonuses.AddTo(from);

                from.Delta(MobileDelta.Armor); // Tell them armor rating has changed
            }
        }

        public virtual double ScaleArmorByDurability(double armor)
        {
            int scale = 100;

            if (m_MaxHitPoints > 0 && m_HitPoints < m_MaxHitPoints)
                scale = 50 + ((50 * m_HitPoints) / m_MaxHitPoints);

            return (armor * scale) / 100;
        }

        protected void Invalidate()
        {
            if (Parent is Mobile)
                ((Mobile)Parent).Delta(MobileDelta.Armor); // Tell them armor rating has changed
        }

        public BaseArmor(Serial serial)
            : base(serial)
        {
        }

        private static void SetSaveFlag(ref SaveFlag flags, SaveFlag toSet, bool setIf)
        {
            if (setIf)
                flags |= toSet;
        }

        private static bool GetSaveFlag(SaveFlag flags, SaveFlag toGet)
        {
            return ((flags & toGet) != 0);
        }

        [Flags]
        private enum SaveFlag
        {
            None = 0x00000000,
            Attributes = 0x00000001,
            ArmorAttributes = 0x00000002,
            PhysicalBonus = 0x00000004,
            ContondantBonus = 0x00000008,
            TranchantBonus = 0x00000010,
            PerforantBonus = 0x00000020,
            MagieBonus = 0x00000040,
            Identified = 0x00000080,
            MaxHitPoints = 0x00000100,
            HitPoints = 0x00000200,
            Crafter = 0x00000400,
            Quality = 0x00000800,
            Durability = 0x00001000,
            Protection = 0x00002000,
            Resource = 0x00004000,
            BaseArmor = 0x00008000,
            StrBonus = 0x00010000,
            DexBonus = 0x00020000,
            IntBonus = 0x00040000,
            StrReq = 0x00080000,
            DexReq = 0x00100000,
            IntReq = 0x00200000,
            MedAllowance = 0x00400000,
            SkillBonuses = 0x00800000,
            PlayerConstructed = 0x01000000
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)8); // version

            writer.Write((int)m_rarete);
            m_TemraelAttributes.Serialize(writer);

            SaveFlag flags = SaveFlag.None;

            SetSaveFlag(ref flags, SaveFlag.Attributes, !m_AosAttributes.IsEmpty);
            SetSaveFlag(ref flags, SaveFlag.ArmorAttributes, !m_AosArmorAttributes.IsEmpty);
            SetSaveFlag(ref flags, SaveFlag.PhysicalBonus, m_PhysicalBonus != 0);
            SetSaveFlag(ref flags, SaveFlag.ContondantBonus, m_ContondantBonus != 0);
            SetSaveFlag(ref flags, SaveFlag.TranchantBonus, m_TranchantBonus != 0);
            SetSaveFlag(ref flags, SaveFlag.PerforantBonus, m_PerforantBonus != 0);
            SetSaveFlag(ref flags, SaveFlag.MagieBonus, m_MagieBonus != 0);
            SetSaveFlag(ref flags, SaveFlag.Identified, m_Identified != false);
            SetSaveFlag(ref flags, SaveFlag.MaxHitPoints, m_MaxHitPoints != 0);
            SetSaveFlag(ref flags, SaveFlag.HitPoints, m_HitPoints != 0);
            SetSaveFlag(ref flags, SaveFlag.Crafter, m_Crafter != null);
            SetSaveFlag(ref flags, SaveFlag.Quality, m_Quality != ArmorQuality.Regular);
            SetSaveFlag(ref flags, SaveFlag.Durability, m_Durability != ArmorDurabilityLevel.Regular);
            SetSaveFlag(ref flags, SaveFlag.Protection, m_Protection != ArmorProtectionLevel.Regular);
            SetSaveFlag(ref flags, SaveFlag.Resource, m_Resource != DefaultResource);
            SetSaveFlag(ref flags, SaveFlag.BaseArmor, m_ArmorBase != -1);
            SetSaveFlag(ref flags, SaveFlag.StrBonus, m_StrBonus != -1);
            SetSaveFlag(ref flags, SaveFlag.DexBonus, m_DexBonus != -1);
            SetSaveFlag(ref flags, SaveFlag.IntBonus, m_IntBonus != -1);
            SetSaveFlag(ref flags, SaveFlag.StrReq, m_StrReq != -1);
            SetSaveFlag(ref flags, SaveFlag.DexReq, m_DexReq != -1);
            SetSaveFlag(ref flags, SaveFlag.IntReq, m_IntReq != -1);
            SetSaveFlag(ref flags, SaveFlag.MedAllowance, m_Meditate != (AMA)(-1));
            SetSaveFlag(ref flags, SaveFlag.SkillBonuses, !m_AosSkillBonuses.IsEmpty);
            SetSaveFlag(ref flags, SaveFlag.PlayerConstructed, m_PlayerConstructed != false);

            writer.WriteEncodedInt((int)flags);

            if (GetSaveFlag(flags, SaveFlag.Attributes))
                m_AosAttributes.Serialize(writer);

            if (GetSaveFlag(flags, SaveFlag.ArmorAttributes))
                m_AosArmorAttributes.Serialize(writer);

            if (GetSaveFlag(flags, SaveFlag.PhysicalBonus))
                writer.WriteEncodedInt((int)m_PhysicalBonus);

            if (GetSaveFlag(flags, SaveFlag.ContondantBonus))
                writer.WriteEncodedInt((int)m_ContondantBonus);

            if (GetSaveFlag(flags, SaveFlag.TranchantBonus))
                writer.WriteEncodedInt((int)m_TranchantBonus);

            if (GetSaveFlag(flags, SaveFlag.PerforantBonus))
                writer.WriteEncodedInt((int)m_PerforantBonus);

            if (GetSaveFlag(flags, SaveFlag.MagieBonus))
                writer.WriteEncodedInt((int)m_MagieBonus);

            if (GetSaveFlag(flags, SaveFlag.MaxHitPoints))
                writer.WriteEncodedInt((int)m_MaxHitPoints);

            if (GetSaveFlag(flags, SaveFlag.HitPoints))
                writer.WriteEncodedInt((int)m_HitPoints);

            if (GetSaveFlag(flags, SaveFlag.Crafter))
                writer.Write((Mobile)m_Crafter);

            if (GetSaveFlag(flags, SaveFlag.Quality))
                writer.WriteEncodedInt((int)m_Quality);

            if (GetSaveFlag(flags, SaveFlag.Durability))
                writer.WriteEncodedInt((int)m_Durability);

            if (GetSaveFlag(flags, SaveFlag.Protection))
                writer.WriteEncodedInt((int)m_Protection);

            if (GetSaveFlag(flags, SaveFlag.Resource))
                writer.WriteEncodedInt((int)m_Resource);

            if (GetSaveFlag(flags, SaveFlag.BaseArmor))
                writer.WriteEncodedInt((int)m_ArmorBase);

            if (GetSaveFlag(flags, SaveFlag.StrBonus))
                writer.WriteEncodedInt((int)m_StrBonus);

            if (GetSaveFlag(flags, SaveFlag.DexBonus))
                writer.WriteEncodedInt((int)m_DexBonus);

            if (GetSaveFlag(flags, SaveFlag.IntBonus))
                writer.WriteEncodedInt((int)m_IntBonus);

            if (GetSaveFlag(flags, SaveFlag.StrReq))
                writer.WriteEncodedInt((int)m_StrReq);

            if (GetSaveFlag(flags, SaveFlag.DexReq))
                writer.WriteEncodedInt((int)m_DexReq);

            if (GetSaveFlag(flags, SaveFlag.IntReq))
                writer.WriteEncodedInt((int)m_IntReq);

            if (GetSaveFlag(flags, SaveFlag.MedAllowance))
                writer.WriteEncodedInt((int)m_Meditate);

            if (GetSaveFlag(flags, SaveFlag.SkillBonuses))
                m_AosSkillBonuses.Serialize(writer);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 8:
                    m_rarete = (RareteItem)reader.ReadInt();
                    m_TemraelAttributes = new TemraelAttributes(this, reader);
                    goto case 7;
                case 7:
                case 6:
                case 5:
                    {
                        SaveFlag flags = (SaveFlag)reader.ReadEncodedInt();

                        if (GetSaveFlag(flags, SaveFlag.Attributes))
                            m_AosAttributes = new AosAttributes(this, reader);
                        else
                            m_AosAttributes = new AosAttributes(this);

                        if (GetSaveFlag(flags, SaveFlag.ArmorAttributes))
                            m_AosArmorAttributes = new AosArmorAttributes(this, reader);
                        else
                            m_AosArmorAttributes = new AosArmorAttributes(this);

                        if (GetSaveFlag(flags, SaveFlag.PhysicalBonus))
                            m_PhysicalBonus = reader.ReadEncodedInt();

                        if (GetSaveFlag(flags, SaveFlag.ContondantBonus))
                            m_ContondantBonus = reader.ReadEncodedInt();

                        if (GetSaveFlag(flags, SaveFlag.TranchantBonus))
                            m_TranchantBonus = reader.ReadEncodedInt();

                        if (GetSaveFlag(flags, SaveFlag.PerforantBonus))
                            m_PerforantBonus = reader.ReadEncodedInt();

                        if (GetSaveFlag(flags, SaveFlag.MagieBonus))
                            m_MagieBonus = reader.ReadEncodedInt();

                        if (GetSaveFlag(flags, SaveFlag.Identified))
                            m_Identified = (version >= 7 || reader.ReadBool());

                        if (GetSaveFlag(flags, SaveFlag.MaxHitPoints))
                            m_MaxHitPoints = reader.ReadEncodedInt();

                        if (GetSaveFlag(flags, SaveFlag.HitPoints))
                            m_HitPoints = reader.ReadEncodedInt();

                        if (GetSaveFlag(flags, SaveFlag.Crafter))
                            m_Crafter = reader.ReadMobile();

                        if (GetSaveFlag(flags, SaveFlag.Quality))
                            m_Quality = (ArmorQuality)reader.ReadEncodedInt();
                        else
                            m_Quality = ArmorQuality.Regular;

                        if (version == 5 && m_Quality == ArmorQuality.Low)
                            m_Quality = ArmorQuality.Regular;

                        if (GetSaveFlag(flags, SaveFlag.Durability))
                        {
                            m_Durability = (ArmorDurabilityLevel)reader.ReadEncodedInt();

                            if (m_Durability > ArmorDurabilityLevel.Indestructible)
                                m_Durability = ArmorDurabilityLevel.Durable;
                        }

                        if (GetSaveFlag(flags, SaveFlag.Protection))
                        {
                            m_Protection = (ArmorProtectionLevel)reader.ReadEncodedInt();

                            if (m_Protection > ArmorProtectionLevel.Invulnerability)
                                m_Protection = ArmorProtectionLevel.Defense;
                        }

                        if (GetSaveFlag(flags, SaveFlag.Resource))
                            m_Resource = (CraftResource)reader.ReadEncodedInt();
                        else
                            m_Resource = DefaultResource;

                        if (m_Resource == CraftResource.None)
                            m_Resource = DefaultResource;

                        if (GetSaveFlag(flags, SaveFlag.BaseArmor))
                            m_ArmorBase = reader.ReadEncodedInt();
                        else
                            m_ArmorBase = -1;

                        if (GetSaveFlag(flags, SaveFlag.StrBonus))
                            m_StrBonus = reader.ReadEncodedInt();
                        else
                            m_StrBonus = -1;

                        if (GetSaveFlag(flags, SaveFlag.DexBonus))
                            m_DexBonus = reader.ReadEncodedInt();
                        else
                            m_DexBonus = -1;

                        if (GetSaveFlag(flags, SaveFlag.IntBonus))
                            m_IntBonus = reader.ReadEncodedInt();
                        else
                            m_IntBonus = -1;

                        if (GetSaveFlag(flags, SaveFlag.StrReq))
                            m_StrReq = reader.ReadEncodedInt();
                        else
                            m_StrReq = -1;

                        if (GetSaveFlag(flags, SaveFlag.DexReq))
                            m_DexReq = reader.ReadEncodedInt();
                        else
                            m_DexReq = -1;

                        if (GetSaveFlag(flags, SaveFlag.IntReq))
                            m_IntReq = reader.ReadEncodedInt();
                        else
                            m_IntReq = -1;

                        if (GetSaveFlag(flags, SaveFlag.MedAllowance))
                            m_Meditate = (AMA)reader.ReadEncodedInt();
                        else
                            m_Meditate = (AMA)(-1);

                        if (GetSaveFlag(flags, SaveFlag.SkillBonuses))
                            m_AosSkillBonuses = new AosSkillBonuses(this, reader);

                        if (GetSaveFlag(flags, SaveFlag.PlayerConstructed))
                            m_PlayerConstructed = true;

                        break;
                    }
                case 4:
                    {
                        m_AosAttributes = new AosAttributes(this, reader);
                        m_AosArmorAttributes = new AosArmorAttributes(this, reader);
                        goto case 3;
                    }
                case 3:
                    {
                        m_PhysicalBonus = reader.ReadInt();
                        m_ContondantBonus = reader.ReadInt();
                        m_TranchantBonus = reader.ReadInt();
                        m_PerforantBonus = reader.ReadInt();
                        m_MagieBonus = reader.ReadInt();
                        goto case 2;
                    }
                case 2:
                case 1:
                    {
                        m_Identified = reader.ReadBool();
                        goto case 0;
                    }
                case 0:
                    {
                        m_ArmorBase = reader.ReadInt();
                        m_MaxHitPoints = reader.ReadInt();
                        m_HitPoints = reader.ReadInt();
                        m_Crafter = reader.ReadMobile();
                        m_Quality = (ArmorQuality)reader.ReadInt();
                        m_Durability = (ArmorDurabilityLevel)reader.ReadInt();
                        m_Protection = (ArmorProtectionLevel)reader.ReadInt();

                        AMT mat = (AMT)reader.ReadInt();

                        if (m_ArmorBase == RevertArmorBase)
                            m_ArmorBase = -1;

                        /*m_BodyPos = (ArmorBodyType)*/
                        reader.ReadInt();

                        if (version < 4)
                        {
                            m_AosAttributes = new AosAttributes(this);
                            m_AosArmorAttributes = new AosArmorAttributes(this);
                        }

                        if (version < 3 && m_Quality == ArmorQuality.Exceptional)
                            DistributeBonuses(6);

                        if (version >= 2)
                        {
                            m_Resource = (CraftResource)reader.ReadInt();
                        }
                        else
                        {
                            OreInfo info;

                            switch (reader.ReadInt())
                            {
                                default:
                                case 0: info = OreInfo.Fer; break;
                                case 1: info = OreInfo.Cuivre; break;
                                case 2: info = OreInfo.Bronze; break;
                                case 3: info = OreInfo.Acier; break;
                                case 4: info = OreInfo.Argent; break;
                                case 5: info = OreInfo.Or; break;
                                case 6: info = OreInfo.Mytheril; break;
                                case 7: info = OreInfo.Luminium; break;
                                case 8: info = OreInfo.Obscurium; break;
                                case 9: info = OreInfo.Mystirium; break;
                                case 10: info = OreInfo.Dominium; break;
                                case 11: info = OreInfo.Eclarium; break;
                                case 12: info = OreInfo.Venarium; break;
                                case 13: info = OreInfo.Athenium; break;
                                case 14: info = OreInfo.Umbrarium; break;
                            }

                            m_Resource = CraftResources.GetFromOreInfo(info, mat);
                        }

                        m_StrBonus = reader.ReadInt();
                        m_DexBonus = reader.ReadInt();
                        m_IntBonus = reader.ReadInt();
                        m_StrReq = reader.ReadInt();
                        m_DexReq = reader.ReadInt();
                        m_IntReq = reader.ReadInt();

                        if (m_StrBonus == OldStrBonus)
                            m_StrBonus = -1;

                        if (m_DexBonus == OldDexBonus)
                            m_DexBonus = -1;

                        if (m_IntBonus == OldIntBonus)
                            m_IntBonus = -1;

                        if (m_StrReq == OldStrReq)
                            m_StrReq = -1;

                        if (m_DexReq == OldDexReq)
                            m_DexReq = -1;

                        if (m_IntReq == OldIntReq)
                            m_IntReq = -1;

                        m_Meditate = (AMA)reader.ReadInt();

                        if (m_Meditate == OldMedAllowance)
                            m_Meditate = (AMA)(-1);

                        if (m_Resource == CraftResource.None)
                        {
                            if (mat == ArmorMaterialType.Studded || mat == ArmorMaterialType.Leather)
                                m_Resource = CraftResource.RegularLeather;
                            /*else if ( mat == ArmorMaterialType.Spined )
                                m_Resource = CraftResource.SpinedLeather;
                            else if ( mat == ArmorMaterialType.Horned )
                                m_Resource = CraftResource.HornedLeather;
                            else if ( mat == ArmorMaterialType.Barbed )
                                m_Resource = CraftResource.BarbedLeather;*/
                            else
                                m_Resource = CraftResource.Fer;
                        }

                        if (m_MaxHitPoints == 0 && m_HitPoints == 0)
                            m_HitPoints = m_MaxHitPoints = Utility.RandomMinMax(InitMinHits, InitMaxHits);

                        break;
                    }
            }

            if (m_AosSkillBonuses == null)
                m_AosSkillBonuses = new AosSkillBonuses(this);

            if (Core.AOS && Parent is Mobile)
                m_AosSkillBonuses.AddTo((Mobile)Parent);

            int strBonus = ComputeStatBonus(StatType.Str);
            int dexBonus = ComputeStatBonus(StatType.Dex);
            int intBonus = ComputeStatBonus(StatType.Int);

            if (Parent is Mobile && (strBonus != 0 || dexBonus != 0 || intBonus != 0))
            {
                Mobile m = (Mobile)Parent;

                string modName = Serial.ToString();

                if (strBonus != 0)
                    m.AddStatMod(new StatMod(StatType.Str, modName + "Str", strBonus, TimeSpan.Zero));

                if (dexBonus != 0)
                    m.AddStatMod(new StatMod(StatType.Dex, modName + "Dex", dexBonus, TimeSpan.Zero));

                if (intBonus != 0)
                    m.AddStatMod(new StatMod(StatType.Int, modName + "Int", intBonus, TimeSpan.Zero));
            }

            if (Parent is Mobile)
                ((Mobile)Parent).CheckStatTimers();

            if (version < 7)
                m_PlayerConstructed = true; // we don't know, so, assume it's crafted

            //Devrait reset les couleurs des armures au reboot.
            if (!DefTailoring.IsNonColorable(this.GetType()))
                Hue = CraftResources.GetHue(m_Resource);
                    
        }

        public virtual CraftResource DefaultResource { get { return CraftResource.Fer; } }

        public BaseArmor(int itemID)
            : base(itemID)
        {
            m_Quality = ArmorQuality.Regular;
            m_Durability = ArmorDurabilityLevel.Regular;
            m_Crafter = null;

            m_Resource = DefaultResource;
            Hue = CraftResources.GetHue(m_Resource);

            m_HitPoints = m_MaxHitPoints = Utility.RandomMinMax(InitMinHits, InitMaxHits);

            this.Layer = (Layer)ItemData.Quality;

            m_rarete = RareteItem.Normal;

            m_AosAttributes = new AosAttributes(this);
            m_AosArmorAttributes = new AosArmorAttributes(this);
            m_AosSkillBonuses = new AosSkillBonuses(this);
            m_TemraelAttributes = new TemraelAttributes(this);
        }

        public override bool AllowSecureTrade(Mobile from, Mobile to, Mobile newOwner, bool accepted)
        {
            if (!Ethics.Ethic.CheckTrade(from, to, newOwner, this))
                return false;

            return base.AllowSecureTrade(from, to, newOwner, accepted);
        }

        public virtual Race RequiredRace { get { return null; } }

        public override bool CanEquip(Mobile from)
        {
            if (!Ethics.Ethic.CheckEquip(from, this))
                return false;

            if (from.AccessLevel < AccessLevel.GameMaster)
            {
                if (RequiredRace != null && from.Race != RequiredRace)
                {
                    if (RequiredRace == Race.Elf)
                        from.SendLocalizedMessage(1072203); // Only Elves may use this.
                    else
                        from.SendMessage("Only {0} may use this.", RequiredRace.PluralName);

                    return false;
                }
                else if (!AllowMaleWearer && !from.Female)
                {
                    if (AllowFemaleWearer)
                        from.SendLocalizedMessage(1010388); // Only females can wear this.
                    else
                        from.SendMessage("You may not wear this.");

                    return false;
                }
                else if (!AllowFemaleWearer && from.Female)
                {
                    if (AllowMaleWearer)
                        from.SendLocalizedMessage(1063343); // Only males can wear this.
                    else
                        from.SendMessage("You may not wear this.");

                    return false;
                }
                else
                {
                    int strBonus = ComputeStatBonus(StatType.Str), strReq = ComputeStatReq(StatType.Str);
                    int dexBonus = ComputeStatBonus(StatType.Dex), dexReq = ComputeStatReq(StatType.Dex);
                    int intBonus = ComputeStatBonus(StatType.Int), intReq = ComputeStatReq(StatType.Int);

                    if (from.RawDex < dexReq || (from.Dex + dexBonus) < 1)
                    {
                        from.SendLocalizedMessage(502077); // You do not have enough dexterity to equip this item.
                        return false;
                    }
                    else if (from.RawStr < strReq || (from.Str + strBonus) < 1)
                    {
                        from.SendLocalizedMessage(500213); // You are not strong enough to equip that.
                        return false;
                    }
                    else if (from.RawInt < intReq || (from.Int + intBonus) < 1)
                    {
                        from.SendMessage("You are not smart enough to equip that.");
                        return false;
                    }
                }
            }

            return base.CanEquip(from);
        }

        public override bool CheckPropertyConfliction(Mobile m)
        {
            if (base.CheckPropertyConfliction(m))
                return true;

            if (Layer == Layer.Pants)
                return (m.FindItemOnLayer(Layer.InnerLegs) != null);

            if (Layer == Layer.Shirt)
                return (m.FindItemOnLayer(Layer.InnerTorso) != null);

            return false;
        }

        public override bool OnEquip(Mobile from)
        {
            from.CheckStatTimers();

            int strBonus = (m_AosAttributes.BonusStr > 5 ? 5 : m_AosAttributes.BonusStr);
            int dexBonus = (m_AosAttributes.BonusDex > 5 ? 5 : m_AosAttributes.BonusDex);
            int intBonus = (m_AosAttributes.BonusInt > 5 ? 5 : m_AosAttributes.BonusInt);
            int chaBonus = (m_TemraelAttributes.CharismaBonus > 5 ? 5 : m_TemraelAttributes.CharismaBonus);
            int conBonus = (m_TemraelAttributes.ConstitutionBonus > 5 ? 5 : m_TemraelAttributes.ConstitutionBonus);

            if (strBonus != 0 || dexBonus != 0 || intBonus != 0)
            {
                string modName = this.Serial.ToString();

                if (strBonus != 0)
                    from.AddStatMod(new StatMod(StatType.Str, modName + "Str", strBonus, TimeSpan.Zero));

                if (dexBonus != 0)
                    from.AddStatMod(new StatMod(StatType.Dex, modName + "Dex", dexBonus, TimeSpan.Zero));

                if (intBonus != 0)
                    from.AddStatMod(new StatMod(StatType.Int, modName + "Int", intBonus, TimeSpan.Zero));
            }

            return base.OnEquip(from);
        }

        public override void OnRemoved(object parent)
        {
            if (parent is Mobile)
            {
                Mobile m = (Mobile)parent;
                string modName = this.Serial.ToString();

                m.RemoveStatMod(modName + "Str");
                m.RemoveStatMod(modName + "Dex");
                m.RemoveStatMod(modName + "Int");

                if (parent is TMobile)
                {
                    TMobile from = (TMobile)parent;
                    from.BonusHits -= Attributes.BonusHits;
                    from.BonusStam -= Attributes.BonusStam;
                    from.BonusMana -= Attributes.BonusMana;
                }

                if (Core.AOS)
                    m_AosSkillBonuses.Remove();

                ((Mobile)parent).Delta(MobileDelta.Armor); // Tell them armor rating has changed
                m.CheckStatTimers();
            }

            base.OnRemoved(parent);
        }

        public virtual int OnHit(BaseWeapon weapon, int damageTaken)
        {
            double HalfAr = ArmorRating / 2.0;
            int Absorbed = (int)(HalfAr + HalfAr * Utility.RandomDouble());

            damageTaken -= Absorbed;
            if (damageTaken < 0)
                damageTaken = 0;

            if (Absorbed < 2)
                Absorbed = 2;

            if (25 > Utility.Random(100)) // 25% chance to lower durability
            {
                if (Core.AOS && m_AosArmorAttributes.SelfRepair > Utility.Random(10))
                {
                    HitPoints += 2;
                }
                else
                {
                    int wear;

                    if (weapon.Type == WeaponType.Bashing)
                        wear = Absorbed / 2;
                    else
                        wear = Utility.Random(2);

                    if (wear > 0 && m_MaxHitPoints > 0)
                    {
                        if (m_HitPoints >= wear)
                        {
                            HitPoints -= wear;
                            wear = 0;
                        }
                        else
                        {
                            wear -= HitPoints;
                            HitPoints = 0;
                        }

                        if (wear > 0)
                        {
                            if (m_MaxHitPoints > wear)
                            {
                                MaxHitPoints -= wear;

                                if (Parent is Mobile)
                                    ((Mobile)Parent).LocalOverheadMessage(MessageType.Regular, 0x3B2, 1061121); // Your equipment is severely damaged.
                            }
                            else
                            {
                                Delete();
                            }
                        }
                    }
                }
            }

            return damageTaken;
        }

        private string GetNameString()
        {
            string name = this.Name;

            if (name == null)
                name = String.Format("#{0}", LabelNumber);

            return name;
        }

        [Hue, CommandProperty(AccessLevel.GameMaster)]
        public override int Hue
        {
            get { return base.Hue; }
            set { base.Hue = value; InvalidateProperties(); }
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            int oreType;

            switch (m_Resource)
            {
                case CraftResource.Cuivre: oreType = 1053108; break; // dull copper
                case CraftResource.Bronze: oreType = 1053107; break; // shadow iron
                case CraftResource.Acier: oreType = 1053106; break; // copper
                case CraftResource.Argent: oreType = 1053105; break; // bronze
                case CraftResource.Or: oreType = 1053104; break; // golden
                case CraftResource.Mytheril: oreType = 1053103; break; // agapite
                /*case CraftResource.Verite:		oreType = 1053102; break; // verite
                //case CraftResource.Valorite:		oreType = 1053101; break; // valorite
                //case CraftResource.SpinedLeather:	oreType = 1061118; break; // spined
                //case CraftResource.HornedLeather:	oreType = 1061117; break; // horned
                //case CraftResource.BarbedLeather:	oreType = 1061116; break; // barbed
                case CraftResource.RedScales:		oreType = 1060814; break; // red
                case CraftResource.YellowScales:	oreType = 1060818; break; // yellow
                case CraftResource.BlackScales:		oreType = 1060820; break; // black
                case CraftResource.GreenScales:		oreType = 1060819; break; // green
                case CraftResource.WhiteScales:		oreType = 1060821; break; // white
                case CraftResource.BlueScales:		oreType = 1060815; break; // blue*/
                default: oreType = 0; break;
            }

            if (m_Quality == ArmorQuality.Exceptional)
            {
                if (oreType != 0)
                    list.Add(1053100, "#{0}\t{1}", oreType, GetNameString()); // exceptional ~1_oretype~ ~2_armortype~
                else
                    list.Add(1050040, GetNameString()); // exceptional ~1_ITEMNAME~
            }
            else
            {
                if (oreType != 0)
                    list.Add(1053099, "#{0}\t{1}", oreType, GetNameString()); // ~1_oretype~ ~2_armortype~
                else if (Name == null)
                    list.Add(LabelNumber);
                else
                    list.Add(Name);
            }
        }

        public override bool AllowEquipedCast(Mobile from)
        {
            if (base.AllowEquipedCast(from))
                return true;

            return (m_AosAttributes.SpellChanneling != 0);
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
        //	return attrInfo.ArmorLuck;
        //}

        public override void GetProperties(ObjectPropertyList list)
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

            if (Identified)
            {
                string[] s = Regex.Split(GetType().ToString(), @"\.");
                string t = s[s.Length - 1];
                if (Name == null)
                    list.Add(1060393, "{0}\t{1}", couleur, t);
                else
                    list.Add(1060393, "{0}\t{1}", couleur, Name);
                list.Add(1060394, "{0}\t{1}", couleur, rarete.ToString());

                if (m_Crafter != null)
                    list.Add(1050043, couleur, m_Crafter.Name); // crafted by ~1_NAME~

                #region Factions
                if (m_FactionState != null)
                    list.Add(1041350); // faction item
                #endregion

                if (RequiredRace == Race.Elf)
                    list.Add(1075086); // Elves Only

                if (m_AosSkillBonuses != null)
                    m_AosSkillBonuses.GetProperties(list, couleur);

                int prop;

                /*if ((prop = ArtifactRarity) > 0)
                    list.Add(1061078, prop.ToString()); // artifact rarity ~1_val~*/

                if ((prop = m_AosAttributes.AttackChance) != 0)
                    list.Add(1060401, "{0}\t{1}", couleur, prop.ToString()); // hit chance increase ~1_val~%

                if ((prop = m_AosAttributes.WeaponDamage) != 0)
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

                //if ((prop = m_AosAttributes.SpellChanneling) != 0)
                //    list.Add(1060482); // spell channeling

                if ((prop = m_AosAttributes.SpellDamage) != 0)
                    list.Add(1060483, "{0}\t{1}", couleur, prop.ToString()); // spell damage increase ~1_val~%

                if ((prop = m_AosAttributes.NightSight) != 0)
                    list.Add(1060434, couleur); // night sight

                if ((prop = m_AosArmorAttributes.MageArmor) != 0)
                    list.Add(1060437, couleur); // mage armor

                AddARProperties(list, couleur);

                if ((prop = GetLowerStatReq()) != 0)
                    list.Add(1060435, "{0}\t{1}", couleur, prop.ToString()); // lower requirements ~1_val~%

                if ((prop = ComputeStatReq(StatType.Str)) > 0)
                    list.Add(1061170, "{0}\t{1}", couleur, prop.ToString()); // strength requirement ~1_val~

                if ((prop = m_AosArmorAttributes.SelfRepair) != 0)
                    list.Add(1060450, "{0}\t{1}", couleur, prop.ToString()); // self repair ~1_val~

                if ((prop = GetDurabilityBonus()) > 0)
                    list.Add(1060410, "{0}\t{1}", couleur, prop.ToString()); // durability ~1_val~%

                if (m_HitPoints >= 0 && m_MaxHitPoints > 0)
                    list.Add(1060639, "{0}\t{1}\t{2}", couleur, m_HitPoints, m_MaxHitPoints); // durability ~1_val~ / ~2_val~
            }
            else
            {
                string[] s = Regex.Split(GetType().ToString(), @"\.");
                string t = s[s.Length - 1];
                if (Name == null)
                    list.Add(1060393, "{0}\t{1}", couleur, t);
                else
                    list.Add(1060393, "{0}\t{1}", couleur, Name);
                list.Add(1060394, "{0}\t{1}", couleur, rarete.ToString());
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

        public override void OnSingleClick(Mobile from)
        {
            List<EquipInfoAttribute> attrs = new List<EquipInfoAttribute>();

            if (DisplayLootType)
            {
                if (LootType == LootType.Blessed)
                    attrs.Add(new EquipInfoAttribute(1038021)); // blessed
                else if (LootType == LootType.Cursed)
                    attrs.Add(new EquipInfoAttribute(1049643)); // cursed
            }

            #region Factions
            if (m_FactionState != null)
                attrs.Add(new EquipInfoAttribute(1041350)); // faction item
            #endregion

            if (m_Quality == ArmorQuality.Exceptional)
                attrs.Add(new EquipInfoAttribute(1018305 - (int)m_Quality));

            if (m_Identified || from.AccessLevel >= AccessLevel.GameMaster)
            {
                if (m_Durability != ArmorDurabilityLevel.Regular)
                    attrs.Add(new EquipInfoAttribute(1038000 + (int)m_Durability));

                if (m_Protection > ArmorProtectionLevel.Regular && m_Protection <= ArmorProtectionLevel.Invulnerability)
                    attrs.Add(new EquipInfoAttribute(1038005 + (int)m_Protection));
            }
            else if (m_Durability != ArmorDurabilityLevel.Regular || (m_Protection > ArmorProtectionLevel.Regular && m_Protection <= ArmorProtectionLevel.Invulnerability))
                attrs.Add(new EquipInfoAttribute(1038000)); // Unidentified

            int number;

            if (Name == null)
            {
                number = LabelNumber;
            }
            else
            {
                this.LabelTo(from, Name);
                number = 1041000;
            }

            if (attrs.Count == 0 && Crafter == null && Name != null)
                return;

            EquipmentInfo eqInfo = new EquipmentInfo(number, m_Crafter, false, attrs.ToArray());

            from.Send(new DisplayEquipmentInfo(this, eqInfo));
        }

        #region ICraftable Members

        public int OnCraft(int quality, bool makersMark, Mobile from, CraftSystem craftSystem, Type typeRes, BaseTool tool, CraftItem craftItem, int resHue)
        {
            Quality = (ArmorQuality)quality;

            if (makersMark)
                Crafter = from;

            Type resourceType = typeRes;

            if (resourceType == null)
                resourceType = craftItem.Resources.GetAt(0).ItemType;

            Resource = CraftResources.GetFromType(resourceType);
            PlayerConstructed = true;

            CraftContext context = craftSystem.GetContext(from);

            RareteInit.InitItem(this, quality, Crafter);

            if (context != null && context.DoNotColor)
                Hue = 0;

            if (Quality == ArmorQuality.Exceptional)
            {
                int bonus = (int)(from.Skills.Forge.Value / 20);

                for (int i = 0; i < bonus; i++)
                {
                    switch (Utility.Random(5))
                    {
                        case 0: m_PhysicalBonus++; break;
                        case 1: m_ContondantBonus++; break;
                        case 2: m_TranchantBonus++; break;
                        case 3: m_PerforantBonus++; break;
                        case 4: m_MagieBonus++; break;
                    }
                }
                //if ( !( Core.ML && this is BaseShield ))		// Guessed Core.ML removed exceptional resist bonuses from crafted shields
                //	DistributeBonuses( (tool is BaseRunicTool ? 6 : Core.SE ? 15 : 14) ); // Not sure since when, but right now 15 points are added, not 14.

                /*if( Core.ML && !(this is BaseShield) )
                {
                    int bonus = (int)(from.Skills.Forge.Value / 20);

                    for( int i = 0; i < bonus; i++ )
                    {
                        switch( Utility.Random( 5 ) )
                        {
                            case 0: m_PhysicalBonus++;	break;
                            case 1: m_FireBonus++;		break;
                            case 2: m_ColdBonus++;		break;
                            case 3: m_EnergyBonus++;	break;
                            case 4: m_PoisonBonus++;	break;
                        }
                    }

                    from.CheckSkill( SkillName.Forge, 0, 100 );
                }*/
            }
            else if (Quality == ArmorQuality.Low)
            {

            }

            if (Core.AOS && tool is BaseRunicTool)
                ((BaseRunicTool)tool).ApplyAttributesTo(this);

            return quality;
        }

        #endregion
    }
}
