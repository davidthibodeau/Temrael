using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefCooking : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Cuisine;	}
		}

		public override int GumpTitleNumber
		{
			get { return 1044003; } // <CENTER>COOKING MENU</CENTER>
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefCooking();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefCooking() : base( 1, 1, 1.25 )// base( 1, 1, 1.5 )
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
			int index = -1;

			/* Begin Ingredients */
			index = AddCraft( typeof( SackFlour ), "Ingrédients", "Sac de farine", 0.0, 30.0, typeof( WheatSheaf ), "Blé", 2, 1044490 );

            index = AddCraft(typeof(Dough), "Ingrédients", "Pâte", 0.0, 30.0, typeof(SackFlour), "Sac de farine", 1, 1044253);
			AddRes( index, typeof( BaseBeverage ), "Eau", 1, 1044253 );

            index = AddCraft(typeof(SweetDough), "Ingrédients", "Pâte sucrée", 0.0, 50.0, typeof(Dough), "Pâte", 1, 1044253);
			AddRes( index, typeof( JarHoney ), "Pot de miel", 1, 1044253 );

            index = AddCraft(typeof(CakeMix), "Ingrédients", "Mélange à gâteau", 20.0, 70.0, typeof(SackFlour), "Sac de farine", 1, 1044253);
			AddRes( index, typeof( SweetDough ), "Pâte sucrée", 1, 1044253 );

            index = AddCraft(typeof(CookieMix), "Ingrédients", "Mélange à biscuit", 30.0, 80.0, typeof(JarHoney), "Pot de miel", 1, 1044253);
			AddRes( index, typeof( SweetDough ), 1044475, 1, 1044253 );
			/* End Ingredients */

			/* Begin Preparations */
            index = AddCraft(typeof(UnbakedQuiche), "Préparations", "Quiche", 0.0, 100.0, typeof(Dough), "Pâte", 1, 1044253);
			AddRes( index, typeof( Eggs ), 1044477, 1, 1044253 );

            index = AddCraft(typeof(UnbakedMeatPie), "Préparations", "Pain de viande", 10.0, 70.0, typeof(Dough), "Pâte", 1, 1044253);
			AddRes( index, typeof( RawRibs ), 1044482, 1, 1044253 );

            index = AddCraft(typeof(UncookedSausagePizza), "Préparations", "Pizza à la saucisse", 20.0, 70.0, typeof(Dough), "Pâte", 1, 1044253);
			AddRes( index, typeof( Sausage ), 1044483, 1, 1044253 );

            index = AddCraft(typeof(UncookedCheesePizza), "Préparations", "Pizza au fromage", 25.0, 75.0, typeof(Dough), "Pâte", 1, 1044253);
			AddRes( index, typeof( CheeseWheel ), 1044486, 1, 1044253 );

            index = AddCraft(typeof(UnbakedFruitPie), "Préparations", "Tarte aux poires", 30.0, 80.0, typeof(Dough), "Pâte", 1, 1044253);
			AddRes( index, typeof( Pear ), 1044481, 1, 1044253 );

            index = AddCraft(typeof(UnbakedPeachCobbler), "Préparations", "Tarte tatin aux pêches", 35.0, 80.0, typeof(Dough), "Pâte", 1, 1044253);
			AddRes( index, typeof( Peach ), 1044480, 1, 1044253 );

            index = AddCraft(typeof(UnbakedApplePie), "Préparations", "Tarte aux pommes", 40.0, 80.0, typeof(Dough), "Pâte", 1, 1044253);
			AddRes( index, typeof( Apple ), 1044479, 1, 1044253 );

            index = AddCraft(typeof(UnbakedPumpkinPie), "Préparations", "Tarte à la citrouille", 40.0, 80.0, typeof(Dough), "Pâte", 1, 1044253);
			AddRes( index, typeof( Pumpkin ), 1044484, 1, 1044253 );

			/* Begin Baking */
            index = AddCraft(typeof(BreadLoaf), "Cuisson", "Miche de pain", 10.0, 60.0, typeof(Dough), "Pâte", 1, 1044253);
			SetNeedOven( index, true );

            index = AddCraft(typeof(Cookies), "Cuisson", "Biscuits", 10.0, 60.0, typeof(CookieMix), "Mélange à biscuit", 1, 1044253);
			SetNeedOven( index, true );

            index = AddCraft(typeof(Cake), "Cuisson", "Gâteau", 30.0, 80.0, typeof(CakeMix), "Mélange à gâteau", 1, 1044253);
			SetNeedOven( index, true );

            index = AddCraft(typeof(Muffins), "Cuisson", "Muffins", 30.0, 80.0, typeof(SweetDough), "Pâte sucrée", 1, 1044253);
			SetNeedOven( index, true );

            index = AddCraft(typeof(Quiche), "Cuisson", "Quiche", 35.0, 85.0, typeof(UnbakedQuiche), "Préparation de quiche", 1, 1044253);
			SetNeedOven( index, true );

            index = AddCraft(typeof(MeatPie), "Cuisson", "Pain de viande", 40.0, 90.0, typeof(UnbakedMeatPie), "Préparation de pain de viande", 1, 1044253);
			SetNeedOven( index, true );

            index = AddCraft(typeof(SausagePizza), "Cuisson", "Pizza aux saucisses", 40.0, 90.0, typeof(UncookedSausagePizza), "Préparation de pizza aux saucisses", 1, 1044253);
			SetNeedOven( index, true );

            index = AddCraft(typeof(CheesePizza), "Cuisson", "Pizza au fromage", 40.0, 90.0, typeof(UncookedCheesePizza), "Préparation de pizza au fromage", 1, 1044253);
			SetNeedOven( index, true );

            index = AddCraft(typeof(FruitPie), "Cuisson", "Tarte aux poires", 50.0, 100.0, typeof(UnbakedFruitPie), "Préparation de tarte aux poires", 1, 1044253);
			SetNeedOven( index, true );

            index = AddCraft(typeof(PeachCobbler), "Cuisson", "Tarte tatin aux pêches", 50.0, 100.0, typeof(UnbakedPeachCobbler), "Préparation de tarte tatin aux pêches", 1, 1044253);
			SetNeedOven( index, true );

            index = AddCraft(typeof(ApplePie), "Cuisson", "Tarte aux pommes", 60.0, 120.0, typeof(UnbakedApplePie), "Préparation de tarte aux pommes", 1, 1044253);
			SetNeedOven( index, true );

            index = AddCraft(typeof(PumpkinPie), "Cuisson", "Tarte à la citrouille", 60.0, 120.0, typeof(UnbakedPumpkinPie), "Préparation de tarte à la citrouille", 1, 1044253);
			SetNeedOven( index, true );
			/* End Baking */

			/* Begin Barbecue */
			index = AddCraft( typeof( CookedBird ), "Grillade de viandes", "Volaille", 0.0, 50.0, typeof( RawBird ), "Volaille cru", 1, 1044253 );
			SetNeedHeat( index, true );
			SetUseAllRes( index, true );

            index = AddCraft(typeof(ChickenLeg), "Grillade de viandes", "Pilon de poulet", 0.0, 50.0, typeof(RawChickenLeg), "Pilon de poulet cru", 1, 1044253);
			SetNeedHeat( index, true );
			SetUseAllRes( index, true );

            index = AddCraft(typeof(FriedEggs), "Grillade de viandes", "Oeufs", 20.0, 70.0, typeof(Eggs), "Oeufs", 1, 1044253);
			SetNeedHeat( index, true );
			SetUseAllRes( index, true );

            index = AddCraft(typeof(LambLeg), "Grillade de viandes", "Gigot d'agneau", 30.0, 80.0, typeof(RawLambLeg), "Gigot d'agneau cru", 1, 1044253);
			SetNeedHeat( index, true );
			SetUseAllRes( index, true );

            index = AddCraft(typeof(Ribs), "Grillade de viandes", "Entrecôte", 40.0, 90.0, typeof(RawRibs), "Entrecôte crue", 1, 1044253);
			SetNeedHeat( index, true );
			SetUseAllRes( index, true );
			/* End Barbecue */

            /* Begin Grillade de poissons */
            index = AddCraft(typeof(FishSteak), "Grillade de poissons", "Poisson (De base)", 10.0, 60.0, typeof(RawFishSteak), "Filet de poisson cru (De base)", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(TruiteFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawTruiteFishSteak), "Filet de truite cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(DoreFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawDoreFishSteak), "Filet de doré cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(CarpeFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawCarpeFishSteak), "Filet de carpe cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(AnguilleFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawAnguilleFishSteak), "Filet d'anguille cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(EsturgeonFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawEsturgeonFishSteak), "Filet d'esturgeon cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(BrochetFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawBrochetFishSteak), "Filet de brochet cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(SardineFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawSardineFishSteak), "Filet de sardine cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(AnchoieFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawAnchoieFishSteak), "Filet d'anchoie cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(MorueFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawMorueFishSteak), "Filet de morue cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(HarengFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawHarengFishSteak), "Filet d'hareng cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(FletanFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawFletanFishSteak), "Filet de flétan cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(MaquereauFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawMaquereauFishSteak), "Filet de maquereau cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(SoleFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawSoleFishSteak), "Filet de sole cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(ThonFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawThonFishSteak), "Filet de thon cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(SaumonFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawSaumonFishSteak), "Filet de saumon cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(GrandBrochetFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawGrandBrochetFishSteak), "Filet de grand brochet cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(TruiteSauvageFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawTruiteSauvageFishSteak), "Filet de truite sauvage cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(GrandDoreFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawGrandDoreFishSteak), "Filet de grand doré cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(TruiteMerFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawTruiteMerFishSteak), "Filet de truite des mers cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(EsturgeonMerFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawEsturgeonMerFishSteak), "Filet d'esturgeon de mers cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(GrandSaumonFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawGrandSaumonFishSteak), "Filet de grand saumon cru", 1, 1044253);
            SetNeedHeat(index, true);

            index = AddCraft(typeof(RaieFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawRaieFishSteak), "Filet de raie cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(EspadonFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawEspadonFishSteak), "Filet d'espadon cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(RequinGrisFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawRequinGrisFishSteak), "Filet de requin gris cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(RequinBlancFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawRequinBlancFishSteak), "Filet de requin blanc cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(HuitreFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawHuitreFishSteak), "Huitre crue", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(CalmarFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawCalmarFishSteak), "Calmar cru", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(PieuvreFishSteak), "Grillade de poissons", "Truite", 10.0, 60.0, typeof(RawPieuvreFishSteak), "Pieuvre crue", 1, 1044253);
            SetNeedHeat(index, true);
            SetUseAllRes(index, true);
            /* End Grillade de poissons */

            /* Begin Autres */
            index = AddCraft(typeof(BiscuitMessageVide), "Autres", "Biscuit Message", 00.0, 30.0, typeof(Dough), "Pâte", 1, 1044253);
            SetNeedOven(index, true);
            /* End Autres */
		}
	}
}