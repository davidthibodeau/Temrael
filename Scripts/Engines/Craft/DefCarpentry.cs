using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefCarpentry : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Menuiserie;	}
		}

		public override int GumpTitleNumber
		{
			get { return 1044004; } // <CENTER>CARPENTRY MENU</CENTER>
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefCarpentry();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.5; // 50%
		}
		
		public override bool RetainsColorFrom(CraftItem item, Type type)
		{
			if ((item.ItemType.IsDefined(typeof(FurnitureAttribute), false)) &&
				((TileData.ItemTable[CraftItem.ItemIDOf(item.ItemType)].Flags & TileFlag.PartialHue) == 0))
				return true;

			if ((type == typeof(BarrelStaves)) || (item.ItemType == typeof(BarrelStaves)))
				return true;

			return false;
		}

		private DefCarpentry() : base( 1, 1, 1.25 )// base( 1, 1, 3.0 )
		{
		}

		public override int CanCraft( Mobile from, BaseTool tool, Type itemType )
		{
			if( tool == null || tool.Deleted || tool.UsesRemaining < 0 )
				return 1044038; // You have worn out your tool!
			else if ( !BaseTool.CheckAccessible( tool, from ) )
				return 1044263; // The tool must be on your person to use.

			return 0;
		}

		public override void PlayCraftEffect( Mobile from )
		{
			// no animation
			//if ( from.Body.Type == BodyType.Human && !from.Mounted )
			//	from.Animate( 9, 5, 1, true, false, 0 );

			from.PlaySound( 0x23D );
		}

		public override int PlayEndingEffect( Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item )
		{
			if ( toolBroken )
				from.SendLocalizedMessage( 1044038 ); // You have worn out your tool

			if ( failed )
			{
				if ( lostMaterial )
					return 1044043; // You failed to create the item, and some of your materials are lost.
				else
					return 1044157; // You failed to create the item, but no materials were lost.
			}
			else
			{
				if ( quality == 0 )
					return 502785; // You were barely able to make this item.  It's quality is below average.
				else if ( makersMark && quality == 2 )
					return 1044156; // You create an exceptional quality item and affix your maker's mark.
				else if ( quality == 2 )
					return 1044155; // You create an exceptional quality item.
				else
					return 1044154; // You create the item.
			}
		}

		public override void InitCraftList()
		{
			int index = 0;

            #region Matériaux

            index = AddCraft(typeof(Kindling), "Matériaux", "Branchette (une)", 0.0, 5.0, typeof(Log), "Bûche", 1, 1044351);

            index = AddCraft(typeof(Kindling), "Matériaux", "Branchette (toutes)", 0.0, 5.0, typeof(Log), "Bûche", 1, 1044351);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(Board), "Matériaux", "Planche (une)", 0.0, 5.0, typeof(Log), "Bûche", 1, 1044351);

            index = AddCraft(typeof(Board), "Matériaux", "Planche (toutes)", 0.0, 5.0, typeof(Log), "Bûche", 1, 1044351);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(Shaft), "Matériaux", "Manche (une)", 0.0, 5.0, typeof(Log), "Bûche", 1, 1044351);

            index = AddCraft(typeof(Shaft), "Matériaux", "Manche (toutes)", 0.0, 5.0, typeof(Log), "Bûche", 1, 1044351);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(PinBoard), "Matériaux", "Planche de pin (une)", 20, 40, typeof(PinLog), "Bûche de Pin", 1, 1044351);

			index = AddCraft(typeof(PinBoard), "Matériaux", "Planche de pin (toutes)", 20, 40, typeof(PinLog), "Bûche de Pin", 1, 1044351);
            SetUseAllRes(index, true);
			
			index = AddCraft(typeof(CypresBoard), "Matériaux", "Planche de Cypres (une)", 30.0, 50.0, typeof(CypresLog), "Bûche de Cypres", 1, 1044351);

            index = AddCraft(typeof(CypresBoard), "Matériaux", "Planche de Cypres (toutes)", 30.0, 50.0, typeof(CypresLog), "Bûche de Cypres", 1, 1044351);
            SetUseAllRes(index, true);
			
			index = AddCraft(typeof(CedreBoard), "Matériaux", "Planche de cèdre (une)", 40.0, 60.0, typeof(CedreLog), "Bûche de cèdre", 1, 1044351);

            index = AddCraft(typeof(CedreBoard), "Matériaux", "Planche de cèdre (toutes)", 40.0, 60.0, typeof(CedreLog), "Bûche de cèdre", 1, 1044351);
            SetUseAllRes(index, true);
			
			index = AddCraft(typeof(SauleBoard), "Matériaux", "Planche de Saule (une)", 50.0, 70.0, typeof(SauleLog), "Bûche de Saule", 1, 1044351);

            index = AddCraft(typeof(SauleBoard), "Matériaux", "Planche de Saule (toutes)", 50.0, 70.0, typeof(SauleLog), "Bûche de Saule", 1, 1044351);
            SetUseAllRes(index, true);
			
            index = AddCraft(typeof(CheneBoard), "Matériaux", "Planche de chêne (une)", 60.0, 80.0, typeof(CheneLog), "Bûche de chêne", 1, 1044351);

			index = AddCraft(typeof(CheneBoard), "Matériaux", "Planche de chêne (toutes)", 60.0, 80.0, typeof(CheneLog), "Bûche de chêne", 1, 1044351);
            SetUseAllRes(index, true);
			
            index = AddCraft(typeof(EbeneBoard), "Matériaux", "Planche d'ébène (une)", 70.0, 90.0, typeof(EbeneLog), "Bûche d'ébène", 1, 1044351);

			index = AddCraft(typeof(EbeneBoard), "Matériaux", "Planche d'ébène (toutes)", 70.0, 90.0, typeof(EbeneLog), "Bûche d'ébène", 1, 1044351);
            SetUseAllRes(index, true);
			
			index = AddCraft(typeof(AcajouBoard), "Matériaux", "Planche d'Acajou (une)", 80.0, 100.0, typeof(AcajouLog), "Bûche d'Acajou", 1, 1044351);

            index = AddCraft(typeof(AcajouBoard), "Matériaux", "Planche d'Acajou (toutes)", 80.0, 100.0, typeof(AcajouLog), "Bûche d'Acajou", 1, 1044351);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(BarrelStaves), "Matériaux", "Douves de Tonneau", 00.0, 25.0, typeof(Board), "Planches", 7, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(BarrelLid), "Matériaux", "Couvercle de Tonneau", 11.0, 36.0, typeof(Board), "Planches", 5, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            #endregion

            #region Chaises

            index = AddCraft(typeof(Stool), "Chaises", "Tabouret", 11.0, 36.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(BambooChair), "Chaises", "Chaise rustique", 21.0, 46.0, typeof(Board), "Planches", 15, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(WoodenChair), "Chaises", "Chaise en bois", 21.0, 46.0, typeof(Board), "Planches", 15, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(FancyWoodenChairCushion), "Chaises", "Chaise avec coussin", 42.1, 67.1, typeof(Board), "Planches", 18, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(WoodenChairCushion), "Chaises", "Chaise avec coussin", 42.1, 67.1, typeof(Board), "Planches", 15, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(Throne), "Chaises", "Trône", 73.6, 98.6, typeof(Board), "Planches", 22, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            /*index = AddCraft(typeof(FootStool), "Chaises", "Tabouret de pied (Bug)", 11.0, 36.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(ChairA), "Chaises", "Trône rudimentaire (Bug)", 30.0, 50.0, typeof(Board), "Planches", 15, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(ChairB), "Chaises", "Banc simple (Bug)", 40.0, 60.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);*/

            index = AddCraft(typeof(TroneBois), "Chaises", "Trône", 45.0, 75.0, typeof(Board), "Planches", 14, 1044351);
            AddRes(index, typeof(Nails), "Clous", 5, 1044563);

            index = AddCraft(typeof(BancTemple), "Chaises", "Banc de temple", 55.0, 85.0, typeof(Board), "Planches", 13, 1044351);
            AddRes(index, typeof(Nails), "Clous", 3, 1044563);

            index = AddCraft(typeof(BancTemple), "Chaises", "Chaise coussinée", 25.0, 55.0, typeof(Board), "Planches", 9, 1044351);
            AddRes(index, typeof(Nails), "Clous", 2, 1044563);
            AddRes(index, typeof(Cloth), "Coton", 1, 1044287);

            #endregion

            #region Tables

            index = AddCraft(typeof(Nightstand), "Tables", "Table de chevet", 42.1, 67.1, typeof(Board), "Planches", 20, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(WritingTable), "Tables", "Table d'écriture", 63.1, 88.1, typeof(Board), "Planches", 20, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(YewWoodTable), "Tables", "Table", 63.1, 88.1, typeof(Board), "Planches", 25, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(LargeTable), "Tables", "Table", 84.2, 109.2, typeof(Board), "Planches", 30, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(ShortMusicStand), "Tables", "Petit support à musique", 78.9, 103.9, typeof(Board), "Planches", 15, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(TallMusicStand), "Tables", "Grand support à musique", 81.5, 106.5, typeof(Board), "Planches", 20, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(PlainLowTable), "Tables", "Table basse", 63.0, 88.0, typeof(Board), "Planches", 20, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(ElegantLowTable), "Tables", "Table basse élégante", 80.0, 105.0, typeof(Board), "Planches", 25, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(TableDeVitre), "Tables", "Table de vitre", 75.0, 105.0, typeof(Board), "Planches", 15, 1044351);
            AddRes(index, typeof(Nails), "Clous", 6, 1044563);

            index = AddCraft(typeof(TableDeNuit), "Tables", "Table de nuit", 20.0, 50.0, typeof(Board), "Planches", 18, 1044351);
            AddRes(index, typeof(Nails), "Clous", 6, 1044563);

            index = AddCraft(typeof(TableDeBoisRustique), "Tables", "Table de bois rustique", 22.0, 52.0, typeof(Board), "Planches", 18, 1044351);
            AddRes(index, typeof(Nails), "Clous", 6, 1044563);

            index = AddCraft(typeof(TableElegante), "Tables", "Table élégante", 61.0, 91.0, typeof(Board), "Planches", 18, 1044351);
            AddRes(index, typeof(Nails), "Clous", 6, 1044563);

            index = AddCraft(typeof(TableDeBoisSombre), "Tables", "Table de bois sombre", 41.0, 71.0, typeof(Board), "Planches", 18, 1044351);
            AddRes(index, typeof(Nails), "Clous", 6, 1044563);

            #endregion

            #region Lits

            index = AddCraft(typeof(LitSimple), "Lits", "Lit simple", 22.0, 52.0, typeof(Board), "Planches", 8, 1044351);
            AddRes(index, typeof(Nails), "Clous", 3, 1044563);
            AddRes(index, typeof(Cloth), "Coton", 1, 1044287);
            AddRes(index, typeof(Feather), "Plumes", 2, 1044563);

            index = AddCraft(typeof(LitDeuxEtages), "Lits", "Lit deux étages", 43.0, 73.0, typeof(Board), "Planches", 11, 1044351);
            AddRes(index, typeof(Nails), "Clous", 4, 1044563);
            AddRes(index, typeof(Cloth), "Coton", 2, 1044287);
            AddRes(index, typeof(Feather), "Plumes", 2, 1044563);

            index = AddCraft(typeof(LitDouble), "Lits", "Lit double", 43.0, 73.0, typeof(Board), "Planches", 9, 1044351);
            AddRes(index, typeof(Nails), "Clous", 4, 1044563);
            AddRes(index, typeof(Cloth), "Coton", 2, 1044287);
            AddRes(index, typeof(Feather), "Plumes", 4, 1044563);

            index = AddCraft(typeof(SmallBedSouthDeed), "Lits", "Petit lit (Sud)", 43.0, 73.0, typeof(Board), "Planches", 40, 1044351);
            AddRes(index, typeof(Cloth), "Coton", 15, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);
            AddRes(index, typeof(Feather), "Plumes", 2, 1044563);

            index = AddCraft(typeof(SmallBedEastDeed), "Lits", "Petit lit (Est)", 43.0, 73.0, typeof(Board), "Planches", 40, 1044351);
            AddRes(index, typeof(Cloth), "Coton", 15, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);
            AddRes(index, typeof(Feather), "Plumes", 2, 1044563);

            index = AddCraft(typeof(LargeBedSouthDeed), "Lits", "Grand lit (Sud)", 43.0, 73.0, typeof(Board), "Planches", 45, 1044351);
            AddRes(index, typeof(Cloth), "Coton", 20, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);
            AddRes(index, typeof(Feather), "Plumes", 2, 1044563);

            index = AddCraft(typeof(LargeBedEastDeed), "Lits", "Grand lit (Est)", 43.0, 73.0, typeof(Board), "Planches", 45, 1044351);
            AddRes(index, typeof(Cloth), "Coton", 20, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);
            AddRes(index, typeof(Feather), "Plumes", 2, 1044563);


            #endregion

            #region Armoires

            index = AddCraft(typeof(ArmoireA), "Armoires", "Armoire à portes vitrées", 59.0, 89.0, typeof(Board), "Planches", 19, 1044351);
            AddRes(index, typeof(Nails), "Clous", 5, 1044563);

            index = AddCraft(typeof(ArmoireB), "Armoires", "Commode à pieds", 39.0, 69.0, typeof(Board), "Planches", 17, 1044351);
            AddRes(index, typeof(Nails), "Clous", 6, 1044563);

            index = AddCraft(typeof(SecretaireFonce), "Armoires", "Secrétaire foncé", 50.0, 80.0, typeof(Board), "Planches", 13, 1044351);
            AddRes(index, typeof(Nails), "Clous", 3, 1044563);

            index = AddCraft(typeof(SecretairePale), "Armoires", "Secrétaire pâle", 50.0, 80.0, typeof(Board), "Planches", 13, 1044351);
            AddRes(index, typeof(Nails), "Clous", 3, 1044563);

            index = AddCraft(typeof(SecretaireBourgogne), "Armoires", "Secrétaire bourgogne", 50.0, 80.0, typeof(Board), "Planches", 13, 1044351);
            AddRes(index, typeof(Nails), "Clous", 3, 1044563);

            #endregion

            #region Etagères
            index = AddCraft(typeof(EtagereA), "Étagères", "Support de bois clair", 30.0, 60.0, typeof(Board), "Planches", 6, 1044351);
            AddRes(index, typeof(Nails), "Clous", 2, 1044563);

            index = AddCraft(typeof(EtagereB), "Étagères", "Support de bois brut", 22.0, 52.0, typeof(Board), "Planches", 6, 1044351);
            AddRes(index, typeof(Nails), "Clous", 2, 1044563);

            index = AddCraft(typeof(EtagereC), "Étagères", "Support de bois bourgogne", 30.0, 60.0, typeof(Board), "Planches", 4, 1044351);
            AddRes(index, typeof(Nails), "Clous", 2, 1044563);

            index = AddCraft(typeof(EtagereG), "Étagères", "Support de bois sombre", 30.0, 60.0, typeof(Board), "Planches", 6, 1044351);
            AddRes(index, typeof(Nails), "Clous", 2, 1044563);

            index = AddCraft(typeof(EtagereD), "Étagères", "Etagère sur trois niveaux claire", 35.0, 65.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(Nails), "Clous", 2, 1044563);

            index = AddCraft(typeof(EtagereE), "Étagères", "Etagère sur trois niveaux bourgogne", 35.0, 65.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(Nails), "Clous", 2, 1044563);

            index = AddCraft(typeof(EtagereF), "Étagères", "Etagère sur trois niveaux sombre", 35.0, 65.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(Nails), "Clous", 2, 1044563);

			#endregion

            #region Paravents
            index = AddCraft(typeof(ParaventA), "Paravents", "Paravent bourgogne", 63.0, 93.0, typeof(Board), "Planches", 6, 1044351);
            AddRes(index, typeof(Cloth), "Coton", 2, 1044287);

            index = AddCraft(typeof(ParaventB), "Paravents", "Paravent papier", 63.0, 93.0, typeof(Board), "Planches", 2, 1044351);
            AddRes(index, typeof(Cloth), "Coton", 6, 1044287);

            index = AddCraft(typeof(ParaventC), "Paravents", "Paravent bambou", 63.0, 93.0, typeof(Board), "Planches", 4, 1044351);
            AddRes(index, typeof(Cloth), "Coton", 4, 1044287);

            #endregion

            #region Conteneurs

            index = AddCraft(typeof(SmallCrate), "Conteneurs", "Petite Caisse", 10.0, 35.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(WoodenBox), "Conteneurs", "Petite Boite", 21.0, 46.0, typeof(Board), "Planches", 12, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(MediumCrate), "Conteneurs", "Caisse", 31.0, 56.0, typeof(Board), "Planches", 18, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(EmptyBookcase), "Conteneurs", "Bibliothèque Vide", 31.5, 56.5, typeof(Board), "Planches", 30, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(FullBookcaseA), "Conteneurs", "Bibliothèque", 47.5, 72.5, typeof(Board), "Planches", 30, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(FullBookcaseB), "Conteneurs", "Bibliothèque", 47.5, 72.5, typeof(Board), "Planches", 30, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(FullBookcaseC), "Conteneurs", "Bibliothèque", 47.5, 72.5, typeof(Board), "Planches", 30, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(Barrel), "Conteneurs", "Tonneau", 47.5, 72.5, typeof(BarrelStaves), "Douves de Tonneau", 4, 1044253);
            AddRes(index, typeof(BarrelHoops), "Cercles de tonneau", 1, 1044253);
            AddRes(index, typeof(BarrelLid), "Couvercle de tonneau", 1, 1044253);

            index = AddCraft(typeof(LargeCrate), "Conteneurs", "Grande Caisse", 47.3, 72.3, typeof(Board), "Planches", 20, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(Armoire), "Conteneurs", "Armoire", 47.2, 72.2, typeof(Board), "Planches", 30, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(Drawer), "Conteneurs", "Commode", 47.2, 72.2, typeof(Board), "Planches", 30, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(WoodenChest), "Conteneurs", "Coffre en bois", 73.6, 98.6, typeof(Board), "Planches", 22, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(FancyArmoire), "Conteneurs", "Armoire de Luxe", 84.2, 109.2, typeof(Board), "Planches", 40, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(FancyDrawer), "Conteneurs", "Commode de luxe", 84.2, 109.2, typeof(Board), "Planches", 40, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(Keg), "Conteneurs", "Tonnelet", 57.8, 82.8, typeof(BarrelStaves), "Douves de tonneau", 2, 1044253);
            AddRes(index, typeof(BarrelHoops), "Cercles de tonneau", 1, 1044253);
            AddRes(index, typeof(BarrelLid), "Couvercle de tonneau", 1, 1044253);

            index = AddCraft(typeof(BacDeau), "Conteneurs", "Bac d'eau", 22.0, 52.0, typeof(Board), "Planches", 7, 1044351);
            AddRes(index, typeof(Nails), "Clous", 3, 1044563);

            index = AddCraft(typeof(BacNourriture), "Conteneurs", "Bac de nourriture", 22.0, 52.0, typeof(Board), "Planches", 7, 1044351);
            AddRes(index, typeof(Nails), "Clous", 3, 1044563);

            index = AddCraft(typeof(BacVide), "Conteneurs", "Bac vide", 22.0, 52.0, typeof(Board), "Planches", 7, 1044351);
            AddRes(index, typeof(Nails), "Clous", 3, 1044563);

            #endregion

            #region Contenant à fruits
            index = AddCraft(typeof(FruitContainerA), "Conteneurs", "Tonneau de pommes", 69.0, 75.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(FerIngot), "Fer", 4, 1044563);
            AddRes(index, typeof(Apple), "Pommes", 25, 1044563);

            index = AddCraft(typeof(FruitContainerB), "Conteneurs", "Tonneau de bananes", 69.0, 75.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(FerIngot), "Fer", 4, 1044563);
            AddRes(index, typeof(Banana), "Bananes", 25, 1044563);

            index = AddCraft(typeof(FruitContainerC), "Conteneurs", "Tonneau de pain", 69.0, 75.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(FerIngot), "Fer", 4, 1044563);
            AddRes(index, typeof(Banana), "BreadLoaf", 25, 1044563);

            index = AddCraft(typeof(FruitContainerD), "Conteneurs", "Tonneau de dattes", 69.0, 75.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(FerIngot), "Fer", 4, 1044563);
            AddRes(index, typeof(Dates), "Dattes", 25, 1044563);

            index = AddCraft(typeof(FruitContainerE), "Conteneurs", "Tonneau de citrons", 69.0, 75.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(FerIngot), "Fer", 4, 1044563);
            AddRes(index, typeof(Lemon), "Citrons", 25, 1044563);

            index = AddCraft(typeof(FruitContainerF), "Conteneurs", "Tonneau de citrons verts", 69.0, 75.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(FerIngot), "Fer", 4, 1044563);
            AddRes(index, typeof(Lime), "Citrons verts", 25, 1044563);

            index = AddCraft(typeof(FruitContainerG), "Conteneurs", "Tonneau de pommes renversé", 80.0, 90.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(FerIngot), "Fer", 4, 1044563);
            AddRes(index, typeof(Apple), "Pommes", 25, 1044563);

            index = AddCraft(typeof(FruitContainerH), "Conteneurs", "Tonneau de bananes renversé", 80.0, 90.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(FerIngot), "Fer", 4, 1044563);
            AddRes(index, typeof(Banana), "Bananes", 25, 1044563);

            index = AddCraft(typeof(FruitContainerI), "Conteneurs", "Tonneau de patates renversé", 80.0, 90.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(FerIngot), "Fer", 4, 1044563);
            //Il y a un tonneau de Patates mais pas de Patates. Rien de vraiment semblable pour remplacer dans le craft.

            index = AddCraft(typeof(FruitContainerJ), "Conteneurs", "Tonneau de pêches renversé", 80.0, 90.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(FerIngot), "Fer", 4, 1044563);
            AddRes(index, typeof(Peach), "Pêches", 25, 1044563);

            #endregion

            #region Clotures

            index = AddCraft(typeof(ClotureTroisPlanchesHorizontales), "Clôtures", "Planches horizontales", 17.0, 47.0, typeof(Board), "Planches", 6, 1044351);
            AddRes(index, typeof(Nails), "Clou", 1, 1044563);

            index = AddCraft(typeof(ClotureTroisPlanchesVerticales), "Clôtures", "Planches verticales", 17.0, 47.0, typeof(Board), "Planches", 6, 1044351);
            AddRes(index, typeof(Nails), "Clou", 1, 1044563);

            #endregion

            #region Utilitaires

            index = AddCraft(typeof(DartBoardSouthDeed), "Utilitaires", "Darts (Sud)", 15.7, 40.7, typeof(Board), "Planches", 5, 1044351);
            AddRes(index, typeof(Nails), "Clou", 1, 1044563);

            index = AddCraft(typeof(DartBoardEastDeed), "Utilitaires", "Darts (Est)", 15.7, 40.7, typeof(Board), "Planches", 5, 1044351);
            AddRes(index, typeof(Nails), "Clou", 1, 1044563);


            index = AddCraft(typeof(BallotBoxDeed), "Utilitaires", "Urne de vote", 47.3, 72.3, typeof(Board), "Planches", 5, 1044351);
            AddRes(index, typeof(Nails), "Clou", 1, 1044563);

            index = AddCraft(typeof(StoneOvenEastDeed), "Utilitaires", "Four (Est)", 68.4, 93.4, typeof(Board), "Planches", 50, 1044351);
            AddSkill(index, SkillName.Menuiserie, 50.0, 55.0);
            AddRes(index, typeof(FerIngot), "Lingot de Fer", 125, 1044037);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(StoneOvenSouthDeed), "Utilitaires", "Four (Sud)", 68.4, 93.4, typeof(Board), "Planches", 50, 1044351);
            AddSkill(index, SkillName.Menuiserie, 50.0, 55.0);
            AddRes(index, typeof(FerIngot), "Lingot de Fer", 125, 1044037);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(FlourMillEastDeed), "Utilitaires", "Moulin (Est)", 94.7, 119.7, typeof(Board), "Planches", 50, 1044351);
            AddSkill(index, SkillName.Menuiserie, 50.0, 55.0);
            AddRes(index, typeof(FerIngot), "Lingot de Fer", 50, 1044037);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(FlourMillSouthDeed), "Utilitaires", "Moulin (Sud)", 94.7, 119.7, typeof(Board), "Planches", 50, 1044351);
            AddSkill(index, SkillName.Menuiserie, 50.0, 55.0);

            AddRes(index, typeof(FerIngot), "Lingot de Fer", 50, 1044037);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(Dressform), "Utilitaires", "Mannequin Vêtements", 63.1, 88.1, typeof(Board), "Planches", 28, 1044351);
            AddSkill(index, SkillName.Couture, 65.0, 70.0);
            AddRes(index, typeof(Cloth), "Coton", 10, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(SpinningwheelEastDeed), "Utilitaires", "Rouet (Est)", 73.6, 98.6, typeof(Board), "Planches", 32, 1044351);
            AddSkill(index, SkillName.Couture, 65.0, 70.0);
            AddRes(index, typeof(Cloth), "Coton", 25, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(SpinningwheelSouthDeed), "Utilitaires", "Rouet (Sud)", 73.6, 98.6, typeof(Board), "Planches", 32, 1044351);
            AddSkill(index, SkillName.Couture, 65.0, 70.0);
            AddRes(index, typeof(Cloth), "Coton", 25, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(LoomEastDeed), "Utilitaires", "Métier à tisser (Est)", 84.2, 109.2, typeof(Board), "Planches", 55, 1044351);
            AddSkill(index, SkillName.Couture, 65.0, 70.0);
            AddRes(index, typeof(Cloth), "Coton", 25, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(LoomSouthDeed), "Utilitaires", "Métier à tisser (Sud)", 84.2, 109.2, typeof(Board), "Planches", 55, 1044351);
            AddSkill(index, SkillName.Couture, 65.0, 70.0);
            AddRes(index, typeof(Cloth), "Coton", 25, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(SmallForgeDeed), "Utilitaires", "Petite Forge", 73.6, 98.6, typeof(Board), "Planches", 18, 1044351);
            AddSkill(index, SkillName.Forge, 75.0, 80.0);
            AddRes(index, typeof(FerIngot), "Lingot de Fer", 40, 1044037);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(LargeForgeEastDeed), "Utilitaires", "Forge (Est)", 78.9, 103.9, typeof(Board), "Planches", 30, 1044351);
            AddSkill(index, SkillName.Forge, 80.0, 85.0);
            AddRes(index, typeof(FerIngot), "Lingot de Fer", 100, 1044037);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(LargeForgeSouthDeed), "Utilitaires", "Forge (Sud)", 78.9, 103.9, typeof(Board), "Planches", 30, 1044351);
            AddSkill(index, SkillName.Forge, 80.0, 85.0);
            AddRes(index, typeof(FerIngot), "Lingot de Fer", 100, 1044037);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(AnvilEastDeed), "Utilitaires", "Enclume (Est)", 73.6, 98.6, typeof(Board), "Planches", 18, 1044351);
            AddSkill(index, SkillName.Forge, 75.0, 80.0);
            AddRes(index, typeof(FerIngot), "Lingot de Fer", 50, 1044037);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(AnvilSouthDeed), "Utilitaires", "Enclume (Sud)", 73.6, 98.6, typeof(Board), "Planches", 18, 1044351);
            AddSkill(index, SkillName.Forge, 75.0, 80.0);
            AddRes(index, typeof(FerIngot), "Lingot de Fer", 50, 1044037);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(PlayerBBEast), "Utilitaires", "Tableau d'affichage (Est)", 85.0, 110.0, typeof(Board), "Planches", 50, 1044351);

            index = AddCraft(typeof(PlayerBBSouth), "Utilitaires", "Tableau d'affichage (Sud)", 85.0, 110.0, typeof(Board), "Planches", 50, 1044351);

            index = AddCraft(typeof(Easle), "Utilitaires", "Chevalet", 86.8, 111.8, typeof(Board), "Planches", 25, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);
         
            #endregion

            #region Équipement

            index = AddCraft(typeof(Pipe), "Équipement", "Pipe", 10.0, 30.0, typeof(Board), "Planche", 1, 1044351);
            index = AddCraft(typeof(PipeCrochu), "Équipement", "Pipe Crochu", 20.0, 50.0, typeof(Board), "Planche", 1, 1044351);
            index = AddCraft(typeof(PipeLongue), "Équipement", "Longue Pipe", 30.0, 60.0, typeof(Board), "Planches", 2, 1044351);

            index = AddCraft(typeof(ShepherdsCrook), "Équipement", "Baton de Berger", 20.0, 40.0, typeof(Board), "Planches", 7, 1044351);
            index = AddCraft(typeof(QuarterStaff), "Équipement", "Baton", 30.0, 50.0, typeof(Board), "Planches", 6, 1044351);
            index = AddCraft(typeof(GnarledStaff), "Équipement", "Bâton Noué", 30.0, 50.0, typeof(Board), "Planches", 7, 1044351);
            index = AddCraft(typeof(Canne), "Équipement", "Canne", 40.0, 60.0, typeof(Board), "Planches", 5, 1044351);
            index = AddCraft(typeof(CanneOsseuse), "Équipement", "Canne Osseuse", 45.0, 65.0, typeof(Board), "Planches", 5, 1044351);
            AddRes(index, typeof(Bone), "Os", 3, 1044287);

            index = AddCraft(typeof(GnarledStaff), "Équipement", "Baton de Voyage", 45.0, 65.0, typeof(Board), "Planches", 6, 1044351);
            index = AddCraft(typeof(BatonElfique), "Équipement", "Baton Elfique", 45.0, 65.0, typeof(Board), "Planches", 6, 1044351);
            index = AddCraft(typeof(BatonLourd), "Équipement", "Eteurfer", 50.0, 70.0, typeof(Board), "Planches", 4, 1044351);
            AddRes(index, typeof(FerIngot), "Lingot de Fer", 6, 1044287);

            index = AddCraft(typeof(Crochire), "Équipement", "Crochire", 55.0, 75.0, typeof(Board), "Planches", 8, 1044351);
            index = AddCraft(typeof(Seliphore), "Équipement", "Seliphore", 60.0, 80.0, typeof(Board), "Planches", 8, 1044351);
            index = AddCraft(typeof(BatonSoleil), "Équipement", "Baton Religieux Nomade", 65.0, 85.0, typeof(Board), "Planches", 8, 1044351);
            index = AddCraft(typeof(BatonTenebreux), "Équipement", "Baton Tenebrea", 65.0, 85.0, typeof(Board), "Planches", 8, 1044351);
            index = AddCraft(typeof(Boulnar), "Équipement", "Boulnar", 65.0, 85.0, typeof(Board), "Planches", 7, 1044351);
            AddRes(index, typeof(FerIngot), "Lingot de Fer", 2, 1044287);

            index = AddCraft(typeof(BatonSorcier), "Équipement", "Baton Sorcier", 70.0, 90.0, typeof(Board), "Planches", 5, 1044351);
            index = AddCraft(typeof(BatonElement), "Équipement", "Baton d'Elementaliste", 70.0, 90.0, typeof(Board), "Planches", 5, 1044351);
            index = AddCraft(typeof(BatonDruide), "Équipement", "Baton de Druide", 75.0, 100.0, typeof(Board), "Planches", 8, 1044351);
            index = AddCraft(typeof(BatonOsseux), "Équipement", "Baton Osseux", 75.0, 100.0, typeof(Board), "Planches", 8, 1044351);
            AddRes(index, typeof(Bone), "Os", 10, 1044287);

            index = AddCraft(typeof(Club), "Équipement", "Club", 0.0, 20.0, typeof(Board), "Planches", 3, 1044351);
            index = AddCraft(typeof(Gourpic), "Équipement", "Gourpic", 10.0, 30.0, typeof(Board), "Planches", 3, 1044351);
            index = AddCraft(typeof(Gourdin), "Équipement", "Gourdin", 20.0, 50.0, typeof(Board), "Planches", 3, 1044351);
            index = AddCraft(typeof(Batonmace), "Équipement", "Bâton de Guerre", 60.0, 80.0, typeof(Board), "Planches", 8, 1044351);

            index = AddCraft(typeof(BouclierCuir), "Équipement", "Bouclier de Cuir", 20.0, 40.0, typeof(Leather), "Cuir", 9, 1044351);
            AddRes(index, typeof(Board), "Planches", 5, 1044287);

            index = AddCraft(typeof(WoodenShield), "Équipement", "Bouclier de Bois", 10.0, 30.0, typeof(Board), "Planches", 12, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(DagueBois), "Équipement", "Dague", 15.0, 45.0, typeof(Board), "Planches", 2, 1044351);

            index = AddCraft(typeof(LanceBois), "Équipement", "Lance", 30.0, 60.0, typeof(Board), "Planches", 2, 1044351);
            AddRes(index, typeof(Shaft), "Manche", 1, 1044351);

            index = AddCraft(typeof(MasseBois), "Équipement", "Masse", 15.0, 45.0, typeof(Board), "Planches", 4, 1044351);

            index = AddCraft(typeof(BatonBois), "Équipement", "Bâton", 15.0, 45.0, typeof(Shaft), "Manche", 1, 1044351);

            index = AddCraft(typeof(EpeeBois), "Équipement", "Épée", 15.0, 45.0, typeof(Board), "Planches", 5, 1044351);

            index = AddCraft(typeof(TrainingDummyEastDeed), "Équipement", "Mannequin Combat (Est)", 68.4, 93.4, typeof(Board), "Planches", 40, 1044351);
            //AddSkill(index, SkillName.Couture, 50.0, 55.0);
            AddRes(index, typeof(Cloth), "Coton", 60, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(TrainingDummySouthDeed), "Équipement", "Mannequin Combat (Sud)", 68.4, 93.4, typeof(Board), "Planches", 40, 1044351);
            //AddSkill(index, SkillName.Couture, 50.0, 55.0);
            AddRes(index, typeof(Cloth), "Coton", 60, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(PickpocketDipEastDeed), "Équipement", "Mannequin Vol (Est)", 73.6, 98.6, typeof(Board), "Planches", 40, 1044351);
            //AddSkill(index, SkillName.Couture, 50.0, 55.0);
            AddRes(index, typeof(Cloth), "Coton", 60, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(PickpocketDipSouthDeed), "Équipement", "Mannequin Vol (Sud)", 73.6, 98.6, typeof(Board), "Planches", 40, 1044351);
            //AddSkill(index, SkillName.Couture, 50.0, 55.0);
            AddRes(index, typeof(Cloth), "Coton", 60, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            #endregion

            #region Instruments

            index = AddCraft(typeof(LapHarp), "Instrument", "Petite Harpe", 63.1, 88.1, typeof(Board), "Planches", 22, 1044351);
			AddRes( index, typeof( Cloth ), "Coton", 10, 1044287 );
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(Harp), "Instrument", "Grande Harpe", 78.9, 103.9, typeof(Board), "Planches", 38, 1044351);
			AddRes( index, typeof( Cloth ), "Coton", 15, 1044287 );
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(Drums), "Instrument", "Tambour", 57.8, 82.8, typeof(Board), "Planches", 22, 1044351);
            AddRes(index, typeof(Cloth), "Coton", 10, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(Lute), "Instrument", "Luth", 68.4, 93.4, typeof(Board), "Planches", 28, 1044351);
            AddRes(index, typeof(Cloth), "Coton", 10, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(Tambourine), "Instrument", "Tambourine", 57.8, 82.8, typeof(Board), "Planches", 15, 1044351);
            AddRes(index, typeof(Cloth), "Coton", 10, 1044287);
            AddRes(index, typeof(Nails), "Clou", 1, 1044563);

            index = AddCraft(typeof(TambourineTassel), "Instrument", "Tambourine décorée", 57.8, 82.8, typeof(Board), "Planches", 15, 1044351);
            AddRes(index, typeof(Cloth), "Coton", 15, 1044287);
            AddRes(index, typeof(Nails), "Clou", 1, 1044563);

            #endregion

            #region Statues
            index = AddCraft(typeof(StatueBoisFemme), "Statues", "Statue de femme", 67.0, 97.0, typeof(Board), "Planches", 22, 1044351);
            AddRes(index, typeof(Nails), "Clous", 5, 1044563);
            AddRes(index, typeof(FerIngot), "Fer", 5, 1044563);

            index = AddCraft(typeof(StatueBoisHomme), "Statues", "Statue d'homme", 67.0, 97.0, typeof(Board), "Planches", 22, 1044351);
            AddRes(index, typeof(Nails), "Clous", 5, 1044563);
            AddRes(index, typeof(FerIngot), "Fer", 5, 1044563);

            index = AddCraft(typeof(StatueBoisEcureuil), "Statues", "Statue d'écureuil", 67.0, 97.0, typeof(Board), "Planches", 20, 1044351);
            AddRes(index, typeof(Nails), "Clous", 4, 1044563);
            AddRes(index, typeof(FerIngot), "Fer", 4, 1044563);

            #endregion

            //Désactivés
            #region Deeds

            // Blacksmithy
			/*index = AddCraft( typeof( SmallForgeDeed ), 1044296, 1044330, 73.6, 98.6, typeof( Log ), 1044041, 5, 1044351 );
			AddSkill( index, SkillName.Forge, 75.0, 80.0 );
			AddRes( index, typeof( FerIngot ), 1044036, 75, 1044037 );
			index = AddCraft( typeof( LargeForgeEastDeed ), 1044296, 1044331, 78.9, 103.9, typeof( Log ), 1044041, 5, 1044351 );
			AddSkill( index, SkillName.Forge, 80.0, 85.0 );
			AddRes( index, typeof( FerIngot ), 1044036, 100, 1044037 );
			index = AddCraft( typeof( LargeForgeSouthDeed ), 1044296, 1044332, 78.9, 103.9, typeof( Log ), 1044041, 5, 1044351 );
			AddSkill( index, SkillName.Forge, 80.0, 85.0 );
			AddRes( index, typeof( FerIngot ), 1044036, 100, 1044037 );
			index = AddCraft( typeof( AnvilEastDeed ), 1044296, 1044333, 73.6, 98.6, typeof( Log ), 1044041, 5, 1044351 );
			AddSkill( index, SkillName.Forge, 75.0, 80.0 );
			AddRes( index, typeof( FerIngot ), 1044036, 150, 1044037 );
			index = AddCraft( typeof( AnvilSouthDeed ), 1044296, 1044334, 73.6, 98.6, typeof( Log ), 1044041, 5, 1044351 );
			AddSkill( index, SkillName.Forge, 75.0, 80.0 );
			AddRes( index, typeof( FerIngot ), 1044036, 150, 1044037 );*/

            // Training
			/*index = AddCraft( typeof( TrainingDummyEastDeed ), 1044297, 1044335, 68.4, 93.4, typeof( Log ), 1044041, 55, 1044351 );
			AddSkill( index, SkillName.Couture, 50.0, 55.0 );
			AddRes( index, typeof( Cloth ), 1044286, 60, 1044287 );
			index = AddCraft( typeof( TrainingDummySouthDeed ), 1044297, 1044336, 68.4, 93.4, typeof( Log ), 1044041, 55, 1044351 );
			AddSkill( index, SkillName.Couture, 50.0, 55.0 );
			AddRes( index, typeof( Cloth ), 1044286, 60, 1044287 );
			index = AddCraft( typeof( PickpocketDipEastDeed ), 1044297, 1044337, 73.6, 98.6, typeof( Log ), 1044041, 65, 1044351 );
			AddSkill( index, SkillName.Couture, 50.0, 55.0 );
			AddRes( index, typeof( Cloth ), 1044286, 60, 1044287 );
			index = AddCraft( typeof( PickpocketDipSouthDeed ), 1044297, 1044338, 73.6, 98.6, typeof( Log ), 1044041, 65, 1044351 );
			AddSkill( index, SkillName.Couture, 50.0, 55.0 );
			AddRes( index, typeof( Cloth ), 1044286, 60, 1044287 );*/

            // Tailoring
			/*index = AddCraft( typeof( Dressform ), 1044298, 1044339, 63.1, 88.1, typeof( Log ), 1044041, 25, 1044351 );
			AddSkill( index, SkillName.Couture, 65.0, 70.0 );
			AddRes( index, typeof( Cloth ), 1044286, 10, 1044287 );
			index = AddCraft( typeof( SpinningwheelEastDeed ), 1044298, 1044341, 73.6, 98.6, typeof( Log ), 1044041, 75, 1044351 );
			AddSkill( index, SkillName.Couture, 65.0, 70.0 );
			AddRes( index, typeof( Cloth ), 1044286, 25, 1044287 );
			index = AddCraft( typeof( SpinningwheelSouthDeed ), 1044298, 1044342, 73.6, 98.6, typeof( Log ), 1044041, 75, 1044351 );
			AddSkill( index, SkillName.Couture, 65.0, 70.0 );
			AddRes( index, typeof( Cloth ), 1044286, 25, 1044287 );
			index = AddCraft( typeof( LoomEastDeed ), 1044298, 1044343, 84.2, 109.2, typeof( Log ), 1044041, 85, 1044351 );
			AddSkill( index, SkillName.Couture, 65.0, 70.0 );
			AddRes( index, typeof( Cloth ), 1044286, 25, 1044287 );
			index = AddCraft( typeof( LoomSouthDeed ), 1044298, 1044344, 84.2, 109.2, typeof( Log ), 1044041, 85, 1044351 );
			AddSkill( index, SkillName.Couture, 65.0, 70.0 );
			AddRes( index, typeof( Cloth ), 1044286, 25, 1044287 );*/

            // Cooking
			/*index = AddCraft( typeof( StoneOvenEastDeed ), 1044299, 1044345, 68.4, 93.4, typeof( Log ), 1044041, 85, 1044351 );
			AddSkill( index, SkillName.Bricolage, 50.0, 55.0 );
			AddRes( index, typeof( FerIngot ), 1044036, 125, 1044037 );
			index = AddCraft( typeof( StoneOvenSouthDeed ), 1044299, 1044346, 68.4, 93.4, typeof( Log ), 1044041, 85, 1044351 );
			AddSkill( index, SkillName.Bricolage, 50.0, 55.0 );
			AddRes( index, typeof( FerIngot ), 1044036, 125, 1044037 );
			index = AddCraft( typeof( FlourMillEastDeed ), 1044299, 1044347, 94.7, 119.7, typeof( Log ), 1044041, 100, 1044351 );
			AddSkill( index, SkillName.Bricolage, 50.0, 55.0 );
			AddRes( index, typeof( FerIngot ), 1044036, 50, 1044037 );
			index = AddCraft( typeof( FlourMillSouthDeed ), 1044299, 1044348, 94.7, 119.7, typeof( Log ), 1044041, 100, 1044351 );
			AddSkill( index, SkillName.Bricolage, 50.0, 55.0 );
			AddRes( index, typeof( FerIngot ), 1044036, 50, 1044037 );
			AddCraft( typeof( WaterTroughEastDeed ), 1044299, 1044349, 94.7, 119.7, typeof( Log ), 1044041, 150, 1044351 );
			AddCraft( typeof( WaterTroughSouthDeed ), 1044299, 1044350, 94.7, 119.7, typeof( Log ), 1044041, 150, 1044351 );*/
            #endregion

            SetSubRes(typeof(Board), "Planche d'Érable");

			// Add every material you want the player to be able to choose from
			// This will override the overridable material	TODO: Verify the required skill amount
            AddSubRes(typeof(Board), "Planche d'Érable", CraftResources.GetSkill(CraftResource.RegularWood ), 1072652);
            AddSubRes(typeof(PinBoard), "Planche de Pin", CraftResources.GetSkill(CraftResource.PinWood ), 1072652);
            AddSubRes(typeof(CypresBoard), "Planche de Cyprès", CraftResources.GetSkill(CraftResource.CypresWood ), 1072652);
            AddSubRes(typeof(CedreBoard), "Planche de Cèdre", CraftResources.GetSkill(CraftResource.CedreWood ), 1072652);
            AddSubRes(typeof(SauleBoard), "Planche de Saule", CraftResources.GetSkill(CraftResource.SauleWood ), 1072652);
            AddSubRes(typeof(CheneBoard), "Planche de Chêne", CraftResources.GetSkill(CraftResource.CheneWood ), 1072652);
            AddSubRes(typeof(EbeneBoard), "Planche d'Ébène", CraftResources.GetSkill(CraftResource.EbeneWood ), 1072652);
            AddSubRes(typeof(AcajouBoard), "Planche d'Acajou", CraftResources.GetSkill(CraftResource.AcajouWood ), 1072652);

            SetSubRes2(typeof(Log), "Bûche d'Érable");

            AddSubRes2(typeof(Log), "Érable", CraftResources.GetSkill(CraftResource.RegularWood ), 1072652);
            AddSubRes2(typeof(PinLog), "Pin", CraftResources.GetSkill(CraftResource.PinWood ), 1072652);
            AddSubRes2(typeof(CypresLog), "Cyprès", CraftResources.GetSkill(CraftResource.CypresWood ), 1072652);
            AddSubRes2(typeof(CedreLog), "Cèdre", CraftResources.GetSkill(CraftResource.CedreWood ), 1072652);
            AddSubRes2(typeof(SauleLog), "Saule", CraftResources.GetSkill(CraftResource.SauleWood ), 1072652);
            AddSubRes2(typeof(CheneLog), "Chêne", CraftResources.GetSkill(CraftResource.CheneWood ), 1072652);
            AddSubRes2(typeof(EbeneLog), "Ébène", CraftResources.GetSkill(CraftResource.EbeneWood ), 1072652);
            AddSubRes2(typeof(AcajouLog), "Acajou", CraftResources.GetSkill(CraftResource.AcajouWood ), 1072652);

            MarkOption = true;
            Repair = Core.AOS;
		}
	}
}