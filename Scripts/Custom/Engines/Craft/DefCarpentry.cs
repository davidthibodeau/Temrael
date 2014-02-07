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

            #region Materials
            //index = AddCraft(typeof(Board), "Matériaux", "Planche", 10.0, 30.0, typeof(Log), "Bûche", 1, 1044465);
            //SetUseAllRes(index, true);

            index = AddCraft(typeof(Kindling), "Matériaux", "Branchette", 0.0, 5.0, typeof(Log), "Bûche", 1, 1044351);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(Board), "Matériaux", "Planche", 0.0, 5.0, typeof(Log), "Bûche", 1, 1044351);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(Shaft), "Matériaux", "Manche", 0.0, 5.0, typeof(Log), "Bûche", 1, 1044351);
            SetUseAllRes(index, true);

			
			index = AddCraft(typeof(PinBoard), "Matériaux", "Planche de pin", 20, 40, typeof(PinLog), "Bûche de Pin", 1, 1044351);
            SetUseAllRes(index, true);
			
			index = AddCraft(typeof(CypresBoard), "Matériaux", "Planche de Cypres", 30.0, 50.0, typeof(CypresLog), "Bûche de Cypres", 1, 1044351);
            SetUseAllRes(index, true);
			
			index = AddCraft(typeof(CedreBoard), "Matériaux", "Planche de cèdre", 40.0, 60.0, typeof(CedreLog), "Bûche de cèdre", 1, 1044351);
            SetUseAllRes(index, true);
			
			index = AddCraft(typeof(SauleBoard), "Matériaux", "Planche de Saule", 50.0, 70.0, typeof(SauleLog), "Bûche de Saule", 1, 1044351);
            SetUseAllRes(index, true);
			
			index = AddCraft(typeof(CheneBoard), "Matériaux", "Planche de chêne", 60.0, 80.0, typeof(CheneLog), "Bûche de chêne", 1, 1044351);
            SetUseAllRes(index, true);
			
			index = AddCraft(typeof(EbeneBoard), "Matériaux", "Planche d'ébène", 70.0, 90.0, typeof(EbeneLog), "Bûche d'ébène", 1, 1044351);
            SetUseAllRes(index, true);
			
			index = AddCraft(typeof(AcajouBoard), "Matériaux", "Planche d'Acajou", 80.0, 100.0, typeof(AcajouLog), "Bûche d'Acajou", 1, 1044351);
            SetUseAllRes(index, true);
			


            #endregion

            #region Others
            // Other Items

            /*if( Core.SE )
			{
				index = AddCraft( typeof( RedHangingLantern ), 1044294, 1029412, 65.0, 90.0, typeof( Log ), 1044041, 5, 1044351 );
				AddRes( index, typeof( BlankScroll ), 1044377, 10, 1044378 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( WhiteHangingLantern ), 1044294, 1029416, 65.0, 90.0, typeof( Log ), 1044041, 5, 1044351 );
				AddRes( index, typeof( BlankScroll ), 1044377, 10, 1044378 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( ShojiScreen ), 1044294, 1029423, 80.0, 105.0, typeof( Log ), 1044041, 75, 1044351 );
				AddSkill( index, SkillName.Couture, 50.0, 55.0 );
				AddRes( index, typeof( Cloth ), 1044286, 60, 1044287 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( BambooScreen ), 1044294, 1029428, 80.0, 105.0, typeof( Log ), 1044041, 75, 1044351 );
				AddSkill( index, SkillName.Couture, 50.0, 55.0 );
				AddRes( index, typeof( Cloth ), 1044286, 60, 1044287 );
				SetNeededExpansion( index, Expansion.SE );
			}

			if( Core.AOS )	//Duplicate Entries to preserve ordering depending on era
			{
				index = AddCraft( typeof( FishingPole ), 1044294, 1023519, 68.4, 93.4, typeof( Log ), 1044041, 5, 1044351 ); //This is in the categor of Other during AoS
				AddSkill( index, SkillName.Couture, 40.0, 45.0 );
				AddRes( index, typeof( Cloth ), 1044286, 5, 1044287 );
			}

			if ( Core.ML )
			{
				index = AddCraft( typeof( RunedSwitch ), 1044294, 1072896, 70.0, 120.0, typeof( Log ), 1044041, 2, 1044351 );
				AddRes( index, typeof( EnchantedSwitch ), 1072893, 1, 1053098 );
				AddRes( index, typeof( RunedPrism ), 1073465, 1, 1053098 );
				AddRes( index, typeof( JeweledFiligree ), 1072894, 1, 1053098 );
				SetNeededExpansion( index, Expansion.ML );
            }*/
            #endregion

            #region Misc
            // Misc
            index = AddCraft(typeof(BarrelStaves), "Divers", 1027857, 00.0, 25.0, typeof(Board), "Planches", 7, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(BarrelLid), "Divers", 1027608, 11.0, 36.0, typeof(Board), "Planches", 5, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(Easle), "Divers", 1044317, 86.8, 111.8, typeof(Board), "Planches", 25, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);
            #endregion

            #region Furniture
            // Furniture
            index = AddCraft(typeof(FootStool), "Chaise", 1022910, 11.0, 36.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(Stool), "Chaise", 1022602, 11.0, 36.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(BambooChair), "Chaise", 1044300, 21.0, 46.0, typeof(Board), "Planches", 15, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(WoodenChair), "Chaise", 1044301, 21.0, 46.0, typeof(Board), "Planches", 15, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(FancyWoodenChairCushion), "Chaise", 1044302, 42.1, 67.1, typeof(Board), "Planches", 18, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(WoodenChairCushion), "Chaise", 1044303, 42.1, 67.1, typeof(Board), "Planches", 15, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            //Gump invisible donc impossible à déplacer
            //index = AddCraft(typeof(WoodenBench), "Chaise", 1022860, 52.6, 77.6, typeof(Board), "Planches", 17, 1044351);
            //AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            //Gump invisible donc impossible à déplacer
            //index = AddCraft(typeof(WoodenThrone), "Chaise", 1044304, 52.6, 77.6, typeof(Board), "Planches", 17, 1044351);
            //AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(Throne), "Chaise", 1044305, 73.6, 98.6, typeof(Board), "Planches", 22, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(Nightstand), "Table", 1044306, 42.1, 67.1, typeof(Board), "Planches", 20, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(WritingTable), "Table", 1022890, 63.1, 88.1, typeof(Board), "Planches", 20, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(YewWoodTable), "Table", 1044307, 63.1, 88.1, typeof(Board), "Planches", 25, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(LargeTable), "Table", 1044308, 84.2, 109.2, typeof(Board), "Planches", 30, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(ShortMusicStand), "Table", 1044313, 78.9, 103.9, typeof(Board), "Planches", 15, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(TallMusicStand), "Table", 1044315, 81.5, 106.5, typeof(Board), "Planches", 20, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

			if( Core.SE )
			{
				index = AddCraft( typeof( ElegantLowTable ),	1044291, 1030265,	80.0, 105.0,	typeof( Log ), 1044041, 35, 1044351 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( PlainLowTable ),		1044291, 1030266,	80.0, 105.0,	typeof( Log ), 1044041, 35, 1044351 );
				SetNeededExpansion( index, Expansion.SE );
            }
            #endregion

			
			#region chaises
            index = AddCraft(typeof(ChairA), "Chaises & Bancs", "Trône rudimentaire", 30.0, 50.0, typeof(Board), "Planches", 6, 1044351);
            index = AddCraft(typeof(ChairB), "Chaises & Bancs", "Banc simple", 40.0, 60.0, typeof(Board), "Planches", 6, 1044351);
            index = AddCraft(typeof(ChairC), "Chaises & Bancs", "Trône avec coussins", 70.0, 90.0, typeof(Board), "Planches", 8, 1044351);
			AddRes(index, typeof(Cloth), "Tissu", 5, 1044563);	

			#endregion

						
			#region paravents
            index = AddCraft(typeof(ParaventA), "Paravents", "Paravent de bois sculpté", 80.0, 90.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(BlankScroll), "Papier (parchemin)", 4, 1044563);
            index = AddCraft(typeof(ParaventB), "Paravents", "Paravent de papier blanc", 70.0, 80.0, typeof(Board), "Planches", 5, 1044351);
            AddRes(index, typeof(BlankScroll), "Papier (parchemin)", 5, 1044563);
            index = AddCraft(typeof(ParaventC), "Paravents", "Paravent de bambou", 70.0, 80.0, typeof(Board), "Planches", 5, 1044351);
            AddRes(index, typeof(BlankScroll), "Papier (parchemin)", 5, 1044563);	
			#endregion
			
			
			#region Armoires
            index = AddCraft(typeof(ArmoireA), "Armoires", "Armoire à portes vitrées", 88.0, 100.0, typeof(Board), "Planches", 15, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);
            index = AddCraft(typeof(ArmoireA), "Armoires", "Commode à pieds", 88.0, 100.0, typeof(Board), "Planches", 15, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

			#endregion
			
			#region etageres
            index = AddCraft(typeof(EtagereA), "Etagères", "Support de bois clair", 50.0, 70.0, typeof(Board), "Planches", 6, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);
            index = AddCraft(typeof(EtagereB), "Etagères", "Support de bois brut", 50.0, 70.0, typeof(Board), "Planches", 6, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);
            index = AddCraft(typeof(EtagereC), "Etagères", "Support de bois bordeaux", 50.0, 70.0, typeof(Board), "Planches", 6, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);
            index = AddCraft(typeof(EtagereG), "Etagères", "Support de bois sombre", 50.0, 70.0, typeof(Board), "Planches", 6, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);
            index = AddCraft(typeof(EtagereD), "Etagères", "Etagère sur trois niveaux claire", 60.0, 75.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);
            index = AddCraft(typeof(EtagereE), "Etagères", "Etagère sur trois niveaux bordeaux", 60.0, 75.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);
            index = AddCraft(typeof(EtagereF), "Etagères", "Etagère sur trois niveaux sombre", 60.0, 75.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

			#endregion
			
			#region fruitcontainer
            index = AddCraft(typeof(FruitContainerA), "Contenant à fruits", "Tonneau de pommes", 69.0, 75.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(FerIngot), "Fer", 4, 1044563);
			AddRes(index, typeof(Apple), "Pommes", 50, 1044563);
            index = AddCraft(typeof(FruitContainerB), "Contenant à fruits", "Tonneau de bananes", 69.0, 75.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(FerIngot), "Fer", 4, 1044563);
			AddRes(index, typeof(Banana), "Bananes", 50, 1044563);
            index = AddCraft(typeof(FruitContainerC), "Contenant à fruits", "Tonneau de pain", 69.0, 75.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(FerIngot), "Fer", 4, 1044563);
			AddRes(index, typeof(Banana), "BreadLoaf", 25, 1044563);
            index = AddCraft(typeof(FruitContainerD), "Contenant à fruits", "Tonneau de dattes", 69.0, 75.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(FerIngot), "Fer", 4, 1044563);
			AddRes(index, typeof(Dates), "Dattes", 50, 1044563);
            index = AddCraft(typeof(FruitContainerE), "Contenant à fruits", "Tonneau de citrons", 69.0, 75.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(FerIngot), "Fer", 4, 1044563);
			AddRes(index, typeof(Lemon), "Citrons", 50, 1044563);
            index = AddCraft(typeof(FruitContainerF), "Contenant à fruits", "Tonneau de citrons verts", 69.0, 75.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(FerIngot), "Fer", 4, 1044563);
			AddRes(index, typeof(Lime), "Citrons verts", 50, 1044563);
            index = AddCraft(typeof(FruitContainerG), "Contenant à fruits", "Tonneau de pommes renversé", 80.0, 90.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(FerIngot), "Fer", 4, 1044563);
			AddRes(index, typeof(Apple), "Pommes", 50, 1044563);
            index = AddCraft(typeof(FruitContainerH), "Contenant à fruits", "Tonneau de bananes renversé", 80.0, 90.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(FerIngot), "Fer", 4, 1044563);
			AddRes(index, typeof(Banana), "Bananes", 50, 1044563);
            index = AddCraft(typeof(FruitContainerI), "Contenant à fruits", "Tonneau de patates renversé", 80.0, 90.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(FerIngot), "Fer", 4, 1044563);
            //Il y a un tonneau de Patates mais pas de Patates. Rien de vraiment semblable pour remplacer dans le craft.
            index = AddCraft(typeof(FruitContainerJ), "Contenant à fruits", "Tonneau de pêches renversé", 80.0, 90.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(FerIngot), "Fer", 4, 1044563);
			AddRes(index, typeof(Peach), "Pêches", 50, 1044563);


			#endregion
			
			
            #region Containers
            // Containers
            index = AddCraft(typeof(WoodenBox), "Conteneur", 1023709, 21.0, 46.0, typeof(Board), "Planches", 12, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(SmallCrate), "Conteneur", 1044309, 10.0, 35.0, typeof(Board), "Planches", 10, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(MediumCrate), "Conteneur", 1044310, 31.0, 56.0, typeof(Board), "Planches", 18, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(LargeCrate), "Conteneur", 1044311, 47.3, 72.3, typeof(Board), "Planches", 20, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(WoodenChest), "Conteneur", 1023650, 73.6, 98.6, typeof(Board), "Planches", 22, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(EmptyBookcase), "Conteneur", 1022718, 31.5, 56.5, typeof(Board), "Planches", 30, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(FancyArmoire), "Conteneur", 1044312, 84.2, 109.2, typeof(Board), "Planches", 40, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(Armoire), "Conteneur", 1022643, 84.2, 109.2, typeof(Board), "Planches", 40, 1044351);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

			if( Core.SE )
			{
				index = AddCraft( typeof( PlainWoodenChest ),	1044292, 1030251, 90.0, 115.0,	typeof( Log ), 1044041, 30, 1044351 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( OrnateWoodenChest ),	1044292, 1030253, 90.0, 115.0,	typeof( Log ), 1044041, 30, 1044351 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( GildedWoodenChest ),	1044292, 1030255, 90.0, 115.0,	typeof( Log ), 1044041, 30, 1044351 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( WoodenFootLocker ),	1044292, 1030257, 90.0, 115.0,	typeof( Log ), 1044041, 30, 1044351 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( FinishedWoodenChest ),1044292, 1030259, 90.0, 115.0,	typeof( Log ), 1044041, 30, 1044351 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( TallCabinet ),	1044292, 1030261, 90.0, 115.0,	typeof( Log ), 1044041, 35, 1044351 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( ShortCabinet ),	1044292, 1030263, 90.0, 115.0,	typeof( Log ), 1044041, 35, 1044351 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( RedArmoire ),	1044292, 1030328, 90.0, 115.0,	typeof( Log ), 1044041, 40, 1044351 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( ElegantArmoire ),	1044292, 1030330, 90.0, 115.0,	typeof( Log ), 1044041, 40, 1044351 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( MapleArmoire ),	1044292, 1030332, 90.0, 115.0,	typeof( Log ), 1044041, 40, 1044351 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( CherryArmoire ),	1044292, 1030334, 90.0, 115.0,	typeof( Log ), 1044041, 40, 1044351 );
				SetNeededExpansion( index, Expansion.SE );
			}

            index = AddCraft(typeof(Keg), "Conteneur", "Tonnelet", 57.8, 82.8, typeof(BarrelStaves), 1044288, 3, 1044253);
			AddRes( index, typeof( BarrelHoops ), 1044289, 1, 1044253 );
			AddRes( index, typeof( BarrelLid ), 1044251, 1, 1044253 );
            #endregion

            #region Add-On
            index = AddCraft(typeof(SmallBedSouthDeed), "Meubles", 1044321, 94.7, 119.8, typeof(Board), "Planches", 40, 1044351);
            AddSkill(index, SkillName.Couture, 75.0, 80.0);
            AddRes(index, typeof(Cloth), "Coton", 100, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(SmallBedEastDeed), "Meubles", 1044322, 94.7, 119.8, typeof(Board), "Planches", 40, 1044351);
            AddSkill(index, SkillName.Couture, 75.0, 80.0);
            AddRes(index, typeof(Cloth), "Coton", 100, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(LargeBedSouthDeed), "Meubles", 1044323, 94.7, 119.8, typeof(Board), "Planches", 45, 1044351);
            AddSkill(index, SkillName.Couture, 75.0, 80.0);
            AddRes(index, typeof(Cloth), "Coton", 150, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(LargeBedEastDeed), "Meubles", 1044324, 94.7, 119.8, typeof(Board), "Planches", 45, 1044351);
            AddSkill(index, SkillName.Couture, 75.0, 80.0);
            AddRes(index, typeof(Cloth), "Coton", 150, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(DartBoardSouthDeed), "Meubles", 1044325, 15.7, 40.7, typeof(Board), "Planches", 5, 1044351);
            AddRes(index, typeof(Nails), "Clou", 1, 1044563);

            index = AddCraft(typeof(DartBoardEastDeed), "Meubles", 1044326, 15.7, 40.7, typeof(Board), "Planches", 5, 1044351);
            AddRes(index, typeof(Nails), "Clou", 1, 1044563);

            index = AddCraft(typeof(BallotBoxDeed), "Meubles", 1044327, 47.3, 72.3, typeof(Board), "Planches", 5, 1044351);
            AddRes(index, typeof(Nails), "Clou", 1, 1044563);

            /*index = AddCraft(typeof(PentagramDeed), "Meubles", 1044328, 100.0, 125.0, typeof(Board), 1044041, 100, 1044351);
            AddSkill(index, SkillName.ArtMagique, 75.0, 80.0);
            AddRes(index, typeof(FerIngot), 1044036, 40, 1044037);
            index = AddCraft(typeof(AbbatoirDeed), "Meubles", 1044329, 100.0, 125.0, typeof(Board), 1044041, 100, 1044351);
            AddSkill(index, SkillName.ArtMagique, 50.0, 55.0);
            AddRes(index, typeof(FerIngot), "Lingot de Fer", 40, 1044037);*/
            index = AddCraft(typeof(TrainingDummyEastDeed), "Meubles", 1044335, 68.4, 93.4, typeof(Board), "Planches", 40, 1044351);
            AddSkill(index, SkillName.Couture, 50.0, 55.0);
            AddRes(index, typeof(Cloth), "Coton", 60, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(TrainingDummySouthDeed), "Meubles", 1044336, 68.4, 93.4, typeof(Board), "Planches", 40, 1044351);
            AddSkill(index, SkillName.Couture, 50.0, 55.0);
            AddRes(index, typeof(Cloth), "Coton", 60, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(PickpocketDipEastDeed), "Meubles", 1044337, 73.6, 98.6, typeof(Board), "Planches", 40, 1044351);
            AddSkill(index, SkillName.Couture, 50.0, 55.0);
            AddRes(index, typeof(Cloth), "Coton", 60, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(PickpocketDipSouthDeed), "Meubles", 1044338, 73.6, 98.6, typeof(Board), "Planches", 40, 1044351);
            AddSkill(index, SkillName.Couture, 50.0, 55.0);
            AddRes(index, typeof(Cloth), "Coton", 60, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(StoneOvenEastDeed), "Meubles", 1044345, 68.4, 93.4, typeof(Board), "Planches", 50, 1044351);
            AddSkill(index, SkillName.Bricolage, 50.0, 55.0);
            AddRes(index, typeof(FerIngot), "Lingot de Fer", 125, 1044037);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(StoneOvenSouthDeed), "Meubles", 1044346, 68.4, 93.4, typeof(Board), "Planches", 50, 1044351);
            AddSkill(index, SkillName.Bricolage, 50.0, 55.0);
            AddRes(index, typeof(FerIngot), "Lingot de Fer", 125, 1044037);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(FlourMillEastDeed), "Meubles", 1044347, 94.7, 119.7, typeof(Board), "Planches", 50, 1044351);
            AddSkill(index, SkillName.Bricolage, 50.0, 55.0);
            AddRes(index, typeof(FerIngot), "Lingot de Fer", 50, 1044037);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(FlourMillSouthDeed), "Meubles", 1044348, 94.7, 119.7, typeof(Board), "Planches", 50, 1044351);
            AddSkill(index, SkillName.Bricolage, 50.0, 55.0);
            AddRes(index, typeof(FerIngot), "Lingot de Fer", 50, 1044037);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            /*AddCraft(typeof(WaterTroughEastDeed), "Meubles", 1044349, 94.7, 119.7, typeof(Board), 1044041, 150, 1044351);
            AddCraft(typeof(WaterTroughSouthDeed), "Meubles", 1044350, 94.7, 119.7, typeof(Board), 1044041, 150, 1044351);*/

            index = AddCraft(typeof(Dressform), "Meubles", 1044339, 63.1, 88.1, typeof(Board), "Planches", 28, 1044351);
            AddSkill(index, SkillName.Couture, 65.0, 70.0);
            AddRes(index, typeof(Cloth), "Coton", 10, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(SpinningwheelEastDeed), "Meubles", 1044341, 73.6, 98.6, typeof(Board), "Planches", 32, 1044351);
            AddSkill(index, SkillName.Couture, 65.0, 70.0);
            AddRes(index, typeof(Cloth), "Coton", 25, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(SpinningwheelSouthDeed), "Meubles", 1044342, 73.6, 98.6, typeof(Board), "Planches", 32, 1044351);
            AddSkill(index, SkillName.Couture, 65.0, 70.0);
            AddRes(index, typeof(Cloth), "Coton", 25, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(LoomEastDeed), "Meubles", 1044343, 84.2, 109.2, typeof(Board), "Planches", 55, 1044351);
            AddSkill(index, SkillName.Couture, 65.0, 70.0);
            AddRes(index, typeof(Cloth), "Coton", 25, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(LoomSouthDeed), "Meubles", 1044344, 84.2, 109.2, typeof(Board), "Planches", 55, 1044351);
            AddSkill(index, SkillName.Couture, 65.0, 70.0);
            AddRes(index, typeof(Cloth), "Coton", 25, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(SmallForgeDeed), "Meubles", 1044330, 73.6, 98.6, typeof(Board), "Planches", 18, 1044351);
            AddSkill(index, SkillName.Forge, 75.0, 80.0);
            AddRes(index, typeof(FerIngot), "Lingot de Fer", 40, 1044037);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(LargeForgeEastDeed), "Meubles", 1044331, 78.9, 103.9, typeof(Board), "Planches", 30, 1044351);
            AddSkill(index, SkillName.Forge, 80.0, 85.0);
            AddRes(index, typeof(FerIngot), "Lingot de Fer", 100, 1044037);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(LargeForgeSouthDeed), "Meubles", 1044332, 78.9, 103.9, typeof(Board), "Planches", 30, 1044351);
            AddSkill(index, SkillName.Forge, 80.0, 85.0);
            AddRes(index, typeof(FerIngot), "Lingot de Fer", 100, 1044037);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(AnvilEastDeed), "Meubles", 1044333, 73.6, 98.6, typeof(Board), "Planches", 18, 1044351);
            AddSkill(index, SkillName.Forge, 75.0, 80.0);
            AddRes(index, typeof(FerIngot), "Lingot de Fer", 50, 1044037);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(AnvilSouthDeed), "Meubles", 1044334, 73.6, 98.6, typeof(Board), "Planches", 18, 1044351);
            AddSkill(index, SkillName.Forge, 75.0, 80.0);
            AddRes(index, typeof(FerIngot), "Lingot de Fer", 50, 1044037);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            if (Core.AOS)
            {
                index = AddCraft(typeof(PlayerBBEast), "Meubles", 1062420, 85.0, 110.0, typeof(Board), "Planches", 50, 1044351);
                index = AddCraft(typeof(PlayerBBSouth), "Meubles", 1062421, 85.0, 110.0, typeof(Board), "Planches", 50, 1044351);
            }
            #endregion

            #region Staves and Shields
            // Staves and Shields
            index = AddCraft(typeof(Pipe), "Équipement", "Pipe", 10.0, 30.0, typeof(Board), "Planche", 1, 1044351);
            index = AddCraft(typeof(PipeCrochu), "Équipement", "Pipe Crochu", 20.0, 50.0, typeof(Board), "Planche", 1, 1044351);
            index = AddCraft(typeof(PipeLongue), "Équipement", "Longue Pipe", 30.0, 60.0, typeof(Board), "Planches", 2, 1044351);

            index = AddCraft(typeof(ShepherdsCrook), "Équipement", "Baton de Berger", 20.0, 40.0, typeof(Board), "Planches", 7, 1044351);
            index = AddCraft(typeof(QuarterStaff), "Équipement", "Baton", 30.0, 50.0, typeof(Board), "Planches", 6, 1044351);
            index = AddCraft(typeof(GnarledStaff), "Équipement", "Bâton Noué", 30.0, 50.0, typeof(Board), "Planches", 7, 1044351);
            index = AddCraft(typeof(Canne), "Équipement", "Canne", 40.0, 60.0, typeof(Board), "Planches", 5, 1044351);
            index = AddCraft(typeof(CanneOsseux), "Équipement", "Canne Osseuse", 45.0, 65.0, typeof(Board), "Planches", 5, 1044351);
            AddRes(index, typeof(Bone), "Os", 3, 1044287);
            index = AddCraft(typeof(BatonVoyage), "Équipement", "Baton de Voyage", 45.0, 65.0, typeof(Board), "Planches", 6, 1044351);
            index = AddCraft(typeof(BatonElfique), "Équipement", "Baton Elfique", 45.0, 65.0, typeof(Board), "Planches", 6, 1044351);
            index = AddCraft(typeof(Eteurfer), "Équipement", "Eteurfer", 50.0, 70.0, typeof(Board), "Planches", 4, 1044351);
            AddRes(index, typeof(FerIngot), "Lingot de Fer", 6, 1044287);
            index = AddCraft(typeof(Crochire), "Équipement", "Crochire", 55.0, 75.0, typeof(Board), "Planches", 8, 1044351);
            index = AddCraft(typeof(Seliphore), "Équipement", "Seliphore", 60.0, 80.0, typeof(Board), "Planches", 8, 1044351);
            index = AddCraft(typeof(BatonSoleil), "Équipement", "Baton Religieux Nomade", 65.0, 85.0, typeof(Board), "Planches", 8, 1044351);
            index = AddCraft(typeof(BatonTenebrea), "Équipement", "Baton Tenebrea", 65.0, 85.0, typeof(Board), "Planches", 8, 1044351);
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

			/*if( !Core.AOS )	//Duplicate Entries to preserve ordering depending on era
			{
				index = AddCraft( typeof( FishingPole ), 1044295, 1023519, 68.4, 93.4, typeof( Log ), 1044041, 5, 1044351 ); //This is in the categor of Other during AoS
				AddSkill( index, SkillName.Couture, 40.0, 45.0 );
				AddRes( index, typeof( Cloth ), 1044286, 5, 1044287 );
			}*/

            /*if( Core.SE )
            {
                index = AddCraft( typeof( Bokuto ), 1044295, 1030227, 70.0, 95.0, typeof( Log ), 1044041, 6, 1044351 );
                SetNeededExpansion( index, Expansion.SE );

                index = AddCraft( typeof( Fukiya ), 1044295, 1030229, 60.0, 85.0, typeof( Log ), 1044041, 6, 1044351 );
                SetNeededExpansion( index, Expansion.SE );

                index = AddCraft( typeof( Tetsubo ), 1044295, 1030225, 80.0, 140.3, typeof( Log ), 1044041, 10, 1044351 );
                SetNeededExpansion( index, Expansion.SE );
            }*/
            #endregion

            #region Instruments
            // Instruments
            index = AddCraft(typeof(LapHarp), "Instrument", 1023762, 63.1, 88.1, typeof(Board), "Planches", 22, 1044351);
			AddRes( index, typeof( Cloth ), "Coton", 10, 1044287 );
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(Harp), "Instrument", 1023761, 78.9, 103.9, typeof(Board), "Planches", 38, 1044351);
			AddRes( index, typeof( Cloth ), "Coton", 15, 1044287 );
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(Drums), "Instrument", 1023740, 57.8, 82.8, typeof(Board), "Planches", 22, 1044351);
            AddRes(index, typeof(Cloth), "Coton", 10, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(Lute), "Instrument", 1023763, 68.4, 93.4, typeof(Board), "Planches", 28, 1044351);
            AddRes(index, typeof(Cloth), "Coton", 10, 1044287);
            AddRes(index, typeof(Nails), "Clous", 1, 1044563);

            index = AddCraft(typeof(Tambourine), "Instrument", 1023741, 57.8, 82.8, typeof(Board), "Planches", 15, 1044351);
            AddRes(index, typeof(Cloth), "Coton", 10, 1044287);
            AddRes(index, typeof(Nails), "Clou", 1, 1044563);

            index = AddCraft(typeof(TambourineTassel), "Instrument", 1044320, 57.8, 82.8, typeof(Board), "Planches", 15, 1044351);
            AddRes(index, typeof(Cloth), "Coton", 15, 1044287);
            AddRes(index, typeof(Nails), "Clou", 1, 1044563);

			if( Core.SE )
			{
                index = AddCraft(typeof(BambooFlute), 1044293, 1030247, 80.0, 105.0, typeof(Board), 1044041, 15, 1044351);
				AddSkill( index, SkillName.Musique, 45.0, 50.0 );
				SetNeededExpansion( index, Expansion.SE );
            }
            #endregion

            #region Blacksmithy
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
            #endregion

            #region Training
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
            #endregion

            #region Tailoring
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
            #endregion

            #region Cooking
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

            MarkOption = true;
			Repair = Core.AOS;

			SetSubRes( typeof( Board ), "Érable" );

			// Add every material you want the player to be able to choose from
			// This will override the overridable material	TODO: Verify the required skill amount
            AddSubRes(typeof(Board), "Érable", 00.0, 1072652);
            AddSubRes(typeof(PinBoard), "Pin", 20.0, 1072652);
            AddSubRes(typeof(CypresBoard), "Cyprès", 30.0, 1072652);
            AddSubRes(typeof(CedreBoard), "Cèdre", 40.0, 1072652);
            AddSubRes(typeof(SauleBoard), "Saule", 50.0, 1072652);
            AddSubRes(typeof(CheneBoard), "Chêne", 60.0, 1072652);
            AddSubRes(typeof(EbeneBoard), "Ébène", 70.0, 1072652);
            AddSubRes(typeof(AcajouBoard), "Acajou", 80.0, 1072652);
			/*AddSubRes( typeof( OakLog ), 1072644, 65.0, 1044041, 1072652 );
			AddSubRes( typeof( AshLog ), 1072645, 80.0, 1044041, 1072652 );
			AddSubRes( typeof( YewLog ), 1072646, 95.0, 1044041, 1072652 );
			AddSubRes( typeof( HeartwoodLog ), 1072647, 100.0, 1044041, 1072652 );
			AddSubRes( typeof( BloodwoodLog ), 1072648, 100.0, 1044041, 1072652 );
			AddSubRes( typeof( FrostwoodLog ), 1072649, 100.0, 1044041, 1072652 );*/

            SetSubRes2(typeof(Log), "Bûche");

            AddSubRes2(typeof(Log), "Bûche", 0.0, 1072652);
            AddSubRes2(typeof(PinLog), "Bûche de Pin", 20.0, 1072652);
            AddSubRes2(typeof(CypresLog), "Bûche de Cyprès", 30.0, 1072652);
            AddSubRes2(typeof(CedreLog), "Bûche de Cèdre", 40.0, 1072652);
            AddSubRes2(typeof(SauleLog), "Bûche de Saule", 50.0, 1072652);
            AddSubRes2(typeof(CheneLog), "Bûche de Chêne", 60.0, 1072652);
            AddSubRes2(typeof(EbeneLog), "Bûche d'Ébène", 70.0, 1072652);
            AddSubRes2(typeof(AcajouLog), "Bûche d'Acajou", 80.0, 1072652);
		}
	}
}