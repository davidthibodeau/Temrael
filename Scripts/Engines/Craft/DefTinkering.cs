using System;
using Server;
using Server.Items;

using Server.Targeting;
using Server.Engines.Identities;

namespace Server.Engines.Craft
{
	public class DefTinkering : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Menuiserie; }
		}

		public override int GumpTitleNumber
		{
			get { return 1044007; } // <CENTER>TINKERING MENU</CENTER>
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefTinkering();

				return m_CraftSystem;
			}
		}

		private DefTinkering() : base( 1, 1, 1.25 )// base( 1, 1, 3.0 )
		{
		}

		public override double GetChanceAtMin( CraftItem item )
		{
			if ( item.NameNumber == 1044258 || item.NameNumber == 1046445 ) // potion keg and faction trap removal kit
				return 0.5; // 50%

			return 0.0; // 0%
		}

		public override int CanCraft( Mobile from, BaseTool tool, Type itemType )
		{
			if( tool == null || tool.Deleted || tool.UsesRemaining < 0 )
				return 1044038; // You have worn out your tool!
			else if ( !BaseTool.CheckAccessible( tool, from ) )
				return 1044263; // The tool must be on your person to use.

			return 0;
		}

		private static Type[] m_TinkerColorables = new Type[]
			{
				typeof( ForkLeft ), typeof( ForkRight ),
				typeof( SpoonLeft ), typeof( SpoonRight ),
				typeof( KnifeLeft ), typeof( KnifeRight ),
				typeof( Plate ),
				typeof( Goblet ), typeof( PewterMug ),
				typeof( KeyRing ),
				typeof( Candelabra ), typeof( Scales ),
				typeof( Key ), typeof( Globe ),
				typeof( Spyglass ), typeof( Lantern ),
				typeof( HeatingStand )
			};

		public override bool RetainsColorFrom( CraftItem item, Type type )
		{
			if ( !type.IsSubclassOf( typeof( BaseIngot ) ) )
				return false;

			type = item.ItemType;

			bool contains = false;

			for ( int i = 0; !contains && i < m_TinkerColorables.Length; ++i )
				contains = ( m_TinkerColorables[i] == type );

			return contains;
		}

		public override void PlayCraftEffect( Mobile from )
		{
			// no sound
			//from.PlaySound( 0x241 );
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
        //    int index = -1;

        //    #region Materials
        //    index = AddCraft(typeof(Nails), "Matériaux", "Clou", 2.0, 10.0, typeof(FerIngot), "Lingot de Fer", 1, 1044465);
        //    SetUseAllRes(index, true);

        //    index = AddCraft(typeof(Bottle), "Matériaux", "Bouteille", 5.0, 15.0, typeof(FerIngot), "Lingots de Fer", 2, 1044465);
        //    SetUseAllRes(index, true);

        //    index = AddCraft(typeof(IronWire), "Matériaux", "Fil de Fer", 5.0, 20.0, typeof(FerIngot), "Lingot de Fer", 1, 1044465);
        //    SetUseAllRes(index, true);

        //    index = AddCraft(typeof(CopperWire), "Matériaux", "Fil de Cuivre", 10.0, 30.0, typeof(CuivreIngot), "Lingot de Cuivre", 1, 1044465);
        //    SetUseAllRes(index, true);

        //    index = AddCraft(typeof(SilverWire), "Matériaux", "Fil d'Argent", 30.0, 50.0, typeof(ArgentIngot), "Lingot d'Argent", 1, 1044465);
        //    SetUseAllRes(index, true);

        //    index = AddCraft(typeof(GoldWire), "Matériaux", "Fil d'Or", 50.0, 90.0, typeof(OrIngot), "Lingot d'Or", 1, 1044465);
        //    SetUseAllRes(index, true);
        //    #endregion

        //    #region Wooden Items
        //    index = AddCraft(typeof(JointingPlane), "Objets de Bois", "Rabot de Joints", 0.0, 50.0, typeof(Log), 1044041, 4, 1044351);
        //    index = AddCraft(typeof(MouldingPlane), "Objets de Bois", "Rabot de Moulage", 0.0, 50.0, typeof(Log), 1044041, 4, 1044351);
        //    index = AddCraft(typeof(SmoothingPlane), "Objets de Bois", "Rabot de Lissage", 0.0, 50.0, typeof(Log), 1044041, 4, 1044351);
        //    index = AddCraft(typeof(ClockFrame), "Objets de Bois", "Cadre d'Horloge", 0.0, 50.0, typeof(Log), 1044041, 6, 1044351);
        //    index = AddCraft(typeof(Axle), "Objets de Bois", "Essieu", 0.0, 25.0, typeof(Log), 1044041, 2, 1044351);
        //    index = AddCraft(typeof(RollingPin), "Objets de Bois", "Rouleau à Pâtisserie", 0.0, 50.0, typeof(Log), 1044041, 5, 1044351);

        //    #endregion

        //    #region Tools
        //    index = AddCraft(typeof(Scissors), "Outils", "Ciseaux", 5.0, 55.0, typeof(FerIngot), 1044036, 2, 1044037);
        //    //index = AddCraft(typeof(MortarPestle), "Outils", "Mortier Pilon", 20.0, 70.0, typeof(FerIngot), 1044036, 3, 1044037);
        //    index = AddCraft(typeof(Scorp), "Outils", "Scorp", 30.0, 80.0, typeof(FerIngot), 1044036, 2, 1044037);
        //    index = AddCraft(typeof(TinkerTools), "Outils", "Outils de Bricolage", 10.0, 60.0, typeof(FerIngot), 1044036, 2, 1044037);
        //    index = AddCraft(typeof(SewingKit), "Outils", "Outils de Couture", 10.0, 70.0, typeof(FerIngot), 1044036, 2, 1044037);
        //    //index = AddCraft(typeof(Knitting), "Outils", "Outils d'Os", 10.0, 70.0, typeof(FerIngot), 1044036, 2, 1044037);
        //    index = AddCraft(typeof(BoneLeatherSewingKit), "Outils", "Kit de couture (Cuir/Os)", 10.0, 70.0, typeof(FerIngot), 1044036, 2, 1044037);
        //    index = AddCraft(typeof(Saw), "Outils", "Scie", 30.0, 80.0, typeof(FerIngot), 1044036, 4, 1044037);
        //    index = AddCraft(typeof(DovetailSaw), "Outils", "Scie à Queue d'Aronde", 30.0, 80.0, typeof(FerIngot), 1044036, 4, 1044037);
        //    index = AddCraft(typeof(Froe), "Outils", "Froe", 30.0, 80.0, typeof(FerIngot), 1044036, 2, 1044037);
        //    index = AddCraft(typeof(Shovel), "Outils", "Pelle", 40.0, 90.0, typeof(FerIngot), 1044036, 4, 1044037);
        //    index = AddCraft(typeof(Hammer), "Outils", "Marteau", 30.0, 80.0, typeof(FerIngot), 1044036, 1, 1044037);
        //    index = AddCraft(typeof(Tongs), "Outils", "Pinces", 35.0, 85.0, typeof(FerIngot), 1044036, 1, 1044037);
        //    index = AddCraft(typeof(SmithHammer), "Outils", "Marteau de Forge", 40.0, 90.0, typeof(FerIngot), 1044036, 4, 1044037);
        //    index = AddCraft(typeof(SledgeHammer), "Outils", "Maul de Forge", 40.0, 90.0, typeof(FerIngot), 1044036, 4, 1044037);
        //    index = AddCraft(typeof(Inshave), "Outils", "Inshave", 30.0, 80.0, typeof(FerIngot), 1044036, 2, 1044037);
        //    index = AddCraft(typeof(Pickaxe), "Outils", "Pioche", 40.0, 90.0, typeof(FerIngot), 1044036, 4, 1044037);
        //    index = AddCraft(typeof(Lockpick), "Outils", "Crochet", 45.0, 95.0, typeof(FerIngot), 1044036, 1, 1044037);
        //    index = AddCraft(typeof(Skillet), "Outils", "Poêlon", 30.0, 80.0, typeof(FerIngot), 1044036, 4, 1044037);
        //    index = AddCraft(typeof(FishingPole), "Outils", "Canne à Pêche", 68.4, 93.4, typeof(Log), "Bûche", 5, 1044351); //This is in the categor of Other during AoS
        //    AddSkill(index, SkillName.Couture, 40.0, 45.0);
        //    AddRes(index, typeof(Cloth), "Coton", 5, 1044287);
        //    index = AddCraft(typeof(FlourSifter), "Outils", "Farine", 50.0, 100.0, typeof(FerIngot), 1044036, 3, 1044037);
        //    index = AddCraft(typeof(FletcherTools), "Outils", "Outils d'Archer", 35.0, 85.0, typeof(Log), "Bûche", 3, 1044037);
        //    //index = AddCraft(typeof(MapmakersPen), "Outils", 1044167, 25.0, 75.0, typeof(FerIngot), 1044036, 1, 1044037);
        //    index = AddCraft(typeof(ScribesPen), "Outils", "Encrier", 25.0, 55.0, typeof(FerIngot), 1044036, 1, 1044037);
        //    index = AddCraft(typeof(NewSpellbook), "Outils", "Grimoire", 35.0, 65.0, typeof(Log), "Bûche", 2, 1044037);
        //    index = AddCraft(typeof(Runebook), "Outils", "Grimoire de Runes", 35.0, 65.0, typeof(Log), "Bûche", 2, 1044037);
        //    //index = AddCraft(typeof(NewDivineSpellbook), "Outils", "Grimoire Divin", 45.0, 75.0, typeof(Log), "Bûche", 2, 1044037);
        //    index = AddCraft(typeof(DeguisementKit), "Outils", "Kit de Déguisement", 50.0, 80.0, typeof(Log), "Bûche", 3, 1044037);
        //    index = AddCraft(typeof(OutilCoagulation), "Outils", "Outil de Coagulation", 60.0, 80.0, typeof(FerIngot), "Fer", 5, 1044037);
        //    //index = AddCraft(typeof(OutilFermentation), "Outils", "Outil de Fermentation", 60.0, 80.0, typeof(FerIngot), "Fer", 5, 1044037);
        //    index = AddCraft(typeof(ExtracteurCouleur), "Outils", "Extracteur de couleurs", 50.0, 70.0, typeof(FerIngot), "Lingots De Fer", 10, 1044367);
        //    #endregion

        //    #region Parts
        //    index = AddCraft(typeof(Gears), "Pièces", "Engrenage", 5.0, 55.0, typeof(FerIngot), 1044036, 2, 1044037);
        //    index = AddCraft(typeof(ClockParts), "Pièces", "Parties d'Horloges", 25.0, 75.0, typeof(FerIngot), 1044036, 1, 1044037);
        //    index = AddCraft(typeof(BarrelTap), "Pièces", "Embout de Baril", 35.0, 85.0, typeof(FerIngot), 1044036, 2, 1044037);
        //    index = AddCraft(typeof(Springs), "Pièces", "Ressorts", 5.0, 55.0, typeof(FerIngot), 1044036, 2, 1044037);
        //    index = AddCraft(typeof(SextantParts), "Pièces", "Pièces de Sextant", 30.0, 80.0, typeof(FerIngot), 1044036, 4, 1044037);
        //    index = AddCraft(typeof(BarrelHoops), "Pièces", "Cercles de Baril", -15.0, 35.0, typeof(FerIngot), 1044036, 5, 1044037);
        //    index = AddCraft(typeof(Hinge), "Pièces", "Charnière", 5.0, 55.0, typeof(FerIngot), 1044036, 2, 1044037);
			
        //    #endregion

        //    #region Utensils
        //    index = AddCraft(typeof(SpoonLeft), "Ustensiles", "Cuillere de Gauche", 0.0, 50.0, typeof(FerIngot), 1044036, 1, 1044037);
        //    index = AddCraft(typeof(SpoonRight), "Ustensiles", "Cuillere de Droite", 0.0, 50.0, typeof(FerIngot), 1044036, 1, 1044037);
        //    index = AddCraft(typeof(Plate), "Ustensiles", "Assiette", 0.0, 50.0, typeof(FerIngot), 1044036, 2, 1044037);
        //    index = AddCraft(typeof(ForkLeft), "Ustensiles", "Fourchette de Gauche", 0.0, 50.0, typeof(FerIngot), 1044036, 1, 1044037);
        //    index = AddCraft(typeof(ForkRight), "Ustensiles", "Fouchette de Droite", 0.0, 50.0, typeof(FerIngot), 1044036, 1, 1044037);
        //    index = AddCraft(typeof(KnifeLeft), "Ustensiles", "Couteau de Gauche", 0.0, 50.0, typeof(FerIngot), 1044036, 1, 1044037);
        //    index = AddCraft(typeof(KnifeRight), "Ustensiles", "Couteau de Droite", 0.0, 50.0, typeof(FerIngot), 1044036, 1, 1044037);
        //    index = AddCraft(typeof(Goblet), "Ustensiles", "Goblet", 10.0, 60.0, typeof(FerIngot), 1044036, 2, 1044037);
        //    index = AddCraft(typeof(PewterMug), "Ustensiles", "Coupe", 10.0, 60.0, typeof(FerIngot), 1044036, 2, 1044037);
        //    index = AddCraft(typeof(Cleaver), "Ustensiles", "Couperet", 20.0, 70.0, typeof(FerIngot), 1044036, 3, 1044037);
        //    index = AddCraft(typeof(ButcherKnife), "Ustensiles", "Couteau de Boucher", 25.0, 75.0, typeof(FerIngot), 1044036, 2, 1044037);

        //    #endregion

        //    #region Misc
        //    index = AddCraft(typeof(BlankScroll), "Divers", "Parchemin Vierge", 0.0, 30.0, typeof(Kindling), "Brindilles", 5, 1044037);
        //    index = AddCraft(typeof(KeyRing), "Divers", "Porte Clefs", 10.0, 60.0, typeof(FerIngot), 1044036, 2, 1044037);
        //    index = AddCraft(typeof(Key), "Divers", "Clef", 20.0, 70.0, typeof(FerIngot), 1044036, 3, 1044037);
        //    index = AddCraft(typeof(Lantern), "Divers", "Lanterne", 30.0, 80.0, typeof(FerIngot), 1044036, 2, 1044037);
        //    index = AddCraft(typeof(Candelabra), "Divers", "Candélabre", 55.0, 105.0, typeof(FerIngot), 1044036, 4, 1044037);
        //    index = AddCraft(typeof(Globe), "Divers", "Glove", 55.0, 105.0, typeof(FerIngot), 1044036, 4, 1044037);
        //    index = AddCraft(typeof(Scales), "Divers", "Balance", 60.0, 110.0, typeof(FerIngot), 1044036, 4, 1044037);
        //    index = AddCraft(typeof(Spyglass), "Divers", "Lunette de Marin", 60.0, 110.0, typeof(FerIngot), 1044036, 4, 1044037);
        //    index = AddCraft(typeof(HeatingStand), "Divers", "Pied de chauffage", 60.0, 110.0, typeof(FerIngot), 1044036, 4, 1044037);

        //    #endregion

        //    #region Jewelry
        //    index = AddCraft(typeof(BracerMetal), "Bijoux", "Bracelets", 40.0, 90.0, typeof(FerIngot), "Lingot de Fer", 4, 1044037);

        //    index = AddCraft(typeof(ColierCoquillages), "Bijoux", "Collier de Coquillages", 40.0, 90.0, typeof(FerIngot), "Lingot de Fer", 4, 1044037);

        //    index = AddCraft(typeof(ColierDents), "Bijoux", "Collier de Dents", 40.0, 90.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);

        //    index = AddCraft(typeof(ColierNordique), "Bijoux", "Collier Nordique", 20.0, 40.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);

        //    index = AddCraft(typeof(ColierFer), "Bijoux", "Collier de Fer", 20.0, 40.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
        //    AddRes(index, typeof(Citrine), "Citrine", 1, 1044240);

        //    index = AddCraft(typeof(ColierSerpantin), "Bijoux", "Collier Serpantin", 30.0, 50.0, typeof(FerIngot), "Lingot de Fer", 6, 1044037);
        //    AddRes(index, typeof(Tourmaline), "Tourmaline", 1, 1044240);

        //    index = AddCraft(typeof(GoldRing), "Bijoux", "Bague", 30.0, 50.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
        //    AddRes(index, typeof(Ruby), "Rubis", 1, 1044240);

        //    index = AddCraft(typeof(GoldNecklace), "Bijoux", "Collier", 30.0, 50.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
        //    AddRes(index, typeof(Sapphire), "Saphir", 1, 1044240);

        //    index = AddCraft(typeof(GoldEarrings), "Bijoux", "Boucles d'Oreilles", 40.0, 60.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
        //    AddRes(index, typeof(Diamond), "Diamant", 1, 1044240);

        //    index = AddCraft(typeof(GoldBeadNecklace), "Bijoux", "Collier de Perles d'Or", 40.0, 60.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
        //    AddRes(index, typeof(Amber), "Ambre", 1, 1044240);

        //    index = AddCraft(typeof(GoldBracelet), "Bijoux", "Bracelet", 40.0, 60.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
        //    AddRes(index, typeof(Sapphire), "Saphir", 1, 1044240);

        //    index = AddCraft(typeof(ColierSimple), "Bijoux", "Collier Simple", 40.0, 60.0, typeof(FerIngot), "Lingot de Fer", 3, 1044037);
        //    AddRes(index, typeof(Tourmaline), "Tourmaline", 1, 1044240);

        //    index = AddCraft(typeof(ColierSaphyre), "Bijoux", "Collier Saphire", 50.0, 70.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
        //    AddRes(index, typeof(Sapphire), "Saphir", 1, 1044240);

        //    index = AddCraft(typeof(ColierOrne), "Bijoux", "Collier Orné", 50.0, 70.0, typeof(FerIngot), "Lingot de Fer", 3, 1044037);
        //    AddRes(index, typeof(Amber), "Ambre", 1, 1044240);

        //    index = AddCraft(typeof(ColierLong), "Bijoux", "Long Collier", 50.0, 70.0, typeof(FerIngot), "Lingot de Fer", 4, 1044037);
        //    AddRes(index, typeof(Sapphire), "Saphir", 1, 1044240);

        //    index = AddCraft(typeof(ColierEmeraudes), "Bijoux", "Collier a Émeraudes", 50.0, 70.0, typeof(FerIngot), "Lingot de Fer", 4, 1044037);
        //    AddRes(index, typeof(Emerald), "Émeraude", 4, 1044240);

        //    index = AddCraft(typeof(ColierRubis), "Bijoux", "Collier a Rubis", 50.0, 70.0, typeof(FerIngot), "Lingot de Fer", 4, 1044037);
        //    AddRes(index, typeof(Ruby), "Rubis", 1, 1044240);

        //    index = AddCraft(typeof(ColierLargeRubis), "Bijoux", "Collier a Large Rubis", 60.0, 80.0, typeof(FerIngot), "Lingot de Fer", 4, 1044037);
        //    AddRes(index, typeof(Ruby), "Rubis", 1, 1044240);
        //    AddRes(index, typeof(Citrine), "Citrine", 4, 1044240);

        //    index = AddCraft(typeof(Bijoux), "Bijoux", "Bijoux", 60.0, 80.0, typeof(FerIngot), "Lingot de Fer", 8, 1044037);
        //    AddRes(index, typeof(Citrine), "Citrine", 1, 1044240);

        //    index = AddCraft(typeof(ColierSud), "Bijoux", "Collier Royal", 70.0, 90.0, typeof(FerIngot), "Lingot de Fer", 6, 1044037);
        //    AddRes(index, typeof(Tourmaline), "Tourmaline", 2, 1044240);

        //    index = AddCraft(typeof(ColierAraignee), "Bijoux", "Collier Araignée", 70.0, 90.0, typeof(FerIngot), "Lingot de Fer", 6, 1044037);
        //    AddRes(index, typeof(Amethyst), "Améthyste", 2, 1044240);

        //    index = AddCraft(typeof(ColierTriple), "Bijoux", "Collier Triple", 80.0, 100.0, typeof(FerIngot), "Lingot de Fer", 6, 1044037);
        //    AddRes(index, typeof(Ruby), "Rubis", 1, 1044240);
        //    AddRes(index, typeof(Emerald), "Émeraude", 1, 1044240);

        //    index = AddCraft(typeof(Diaphene), "Bijoux", "Diaphène", 90.0, 100.0, typeof(FerIngot), "Lingot de Fer", 4, 1044037);
        //    AddRes(index, typeof(Sapphire), "Saphir", 2, 1044240);
        //    AddRes(index, typeof(StarSapphire), "Saphir Étoilé", 1, 1044240);
        //    AddRes(index, typeof(Diamond), "Diamant", 1, 1044240);

        //    index = AddCraft(typeof(Couronne), "Bijoux", "Couronne", 90.0, 100.0, typeof(FerIngot), "Lingot de Fer", 5, 1044037);
        //    AddRes(index, typeof(Diamond), "Diamant", 1, 1044240);
        //    AddRes(index, typeof(Ruby), "Rubis", 1, 1044240);
        //    AddRes(index, typeof(Sapphire), "Saphir", 8, 1044240);
        //    AddRes(index, typeof(StarSapphire), "Saphir Étoilé", 2, 1044240);

        //    #endregion
			
        //    #region Vases
        //    index = AddCraft(typeof(GrandVaseBec), "Vases", "Grand vase à bec", 50.0, 60.0, typeof(FerIngot), "Lingot de Fer", 5, 1044037);
        //    index = AddCraft(typeof(PetitVaseBec), "Vases", "Petit vase à bec", 40.0, 50.0, typeof(FerIngot), "Lingot de Fer", 3, 1044037);
        //    index = AddCraft(typeof(GrandVase), "Vases", "Grand vase", 40.0, 50.0, typeof(FerIngot), "Lingot de Fer", 5, 1044037);
        //    index = AddCraft(typeof(PetitVase), "Vases", "Petit vase", 30.0, 40.0, typeof(FerIngot), "Lingot de Fer", 3, 1044037);
        //    index = AddCraft(typeof(VaseRose), "Vases", "Vase à Rose", 60.0, 70.0, typeof(FerIngot), "Lingot de Fer", 5, 1044037);
        //    index = AddCraft(typeof(GrandPot), "Vases", "Grand pot", 40.0, 50.0, typeof(FerIngot), "Lingot de Fer", 4, 1044037);
        //    index = AddCraft(typeof(PetitPot), "Vases", "Petit pot", 20.0, 30.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
        //    #endregion
			
        //    #region Mannequins
        //    index = AddCraft(typeof(WigStand), "Mannequins", "Stand à perruque", 30.0, 50.0, typeof(Cloth), "Tissu", 2, 1044037);
        //    AddRes(index, typeof(Feather), "Plumes", 20, 1044253);
        //    AddRes(index, typeof(Log), "Bois", 2, 1044253);
        //    index = AddCraft(typeof(TeddyBear), "Mannequins", "Ourson en peluche", 30.0, 50.0, typeof(Cloth), "Tissu", 5, 1044037);
        //    AddRes(index, typeof(Feather), "Plumes", 50, 1044253);
        //    index = AddCraft(typeof(MannequinMale), "Mannequins", "Mannequin de front", 60.0, 70.0, typeof(Cloth), "Tissu", 5, 1044037);
        //    AddRes(index, typeof(Feather), "Plumes", 50, 1044253);
        //    AddRes(index, typeof(Log), "Bois", 3, 1044253);
        //    index = AddCraft(typeof(MannequinFemale), "Mannequins", "Mannequin de côté", 60.0, 70.0, typeof(Cloth), "Tissu", 5, 1044037);
        //    AddRes(index, typeof(Feather), "Plumes", 50, 1044253);
        //    AddRes(index, typeof(Log), "Bois", 3, 1044253);
        //    index = AddCraft(typeof(PoupeeFemale), "Mannequins", "Poupée féminine", 60.0, 70.0, typeof(Cloth), "Tissu", 5, 1044037);
        //    AddRes(index, typeof(Feather), "Plumes", 50, 1044253);
        //    index = AddCraft(typeof(PoupeeMale), "Mannequins", "Poupée masculine", 60.0, 70.0, typeof(Cloth), "Tissu", 5, 1044037);
        //    AddRes(index, typeof(Feather), "Plumes", 50, 1044253);
        //    index = AddCraft(typeof(WoodenHorse), "Mannequins", "Cheval de bois", 70.0, 80.0, typeof(Log), "Bois", 15, 1044037);

        //    #endregion
			
        //    #region Gamelles
        //    index = AddCraft(typeof(GamelleA), "Gamelles", "Poêle à frire", 20.0, 40.0, typeof(FerIngot), "Fer", 2, 1044037);
        //    index = AddCraft(typeof(GamelleB), "Gamelles", "Casserole sale", 20.0, 40.0, typeof(FerIngot), "Fer", 2, 1044037);
        //    index = AddCraft(typeof(GamelleC), "Gamelles", "Poêle sale", 20.0, 40.0, typeof(FerIngot), "Fer", 2, 1044037);
        //    index = AddCraft(typeof(GamelleD), "Gamelles", "Plat sale", 20.0, 40.0, typeof(FerIngot), "Fer", 2, 1044037);
        //    index = AddCraft(typeof(GamelleO), "Gamelles", "Ecuelle sale", 20.0, 40.0, typeof(FerIngot), "Fer", 1, 1044037);
        //    index = AddCraft(typeof(GamelleP), "Gamelles", "Ecuelle propre", 20.0, 40.0, typeof(FerIngot), "Fer", 1, 1044037);
        //    index = AddCraft(typeof(GamelleE), "Gamelles", "Plat à poignées", 30.0, 50.0, typeof(FerIngot), "Fer", 2, 1044037);
        //    index = AddCraft(typeof(GamelleF), "Gamelles", "Casserole", 30.0, 50.0, typeof(FerIngot), "Fer", 2, 1044037);
        //    index = AddCraft(typeof(GamelleG), "Gamelles", "Grosse casserole sale", 50.0, 60.0, typeof(FerIngot), "Fer", 3, 1044037);
        //    index = AddCraft(typeof(GamelleH), "Gamelles", "Plat à poignées sale", 50.0, 60.0, typeof(FerIngot), "Fer", 2, 1044037);
        //    index = AddCraft(typeof(GamelleI), "Gamelles", "Grosse poêle sale", 50.0, 60.0, typeof(FerIngot), "Fer", 3, 1044037);
        //    index = AddCraft(typeof(GamelleJ), "Gamelles", "Grosse gamelle", 50.0, 60.0, typeof(FerIngot), "Fer", 3, 1044037);
        //    index = AddCraft(typeof(GamelleK), "Gamelles", "Plat à gratin", 50.0, 60.0, typeof(FerIngot), "Fer", 2, 1044037);
        //    index = AddCraft(typeof(GamelleK), "Gamelles", "Plat à gratin sale", 50.0, 60.0, typeof(FerIngot), "Fer", 2, 1044037);
        //    index = AddCraft(typeof(GamelleM), "Gamelles", "Gros plat sale", 50.0, 60.0, typeof(FerIngot), "Fer", 2, 1044037);
        //    index = AddCraft(typeof(GamelleN), "Gamelles", "Gamelle profonde", 60.0, 70.0, typeof(FerIngot), "Fer", 4, 1044037);
        //    index = AddCraft(typeof(GamelleR), "Gamelles", "Chaudron", 65.0, 75.0, typeof(FerIngot), "Fer", 15, 1044037);
        //    index = AddCraft(typeof(GamelleQ), "Gamelles", "Chaudron avec support", 70.0, 80.0, typeof(FerIngot), "Fer", 20, 1044037);
			
        //    #endregion	

        //    #region Multi-Component Items

        //    index = AddCraft(typeof(Clock), "Ensembles", "Horloge", 90.0, 100.0, typeof(ClockParts), 1044170, 2, 1044253);
        //    AddRes(index, typeof(Springs), "Ressorts", 1, 1044253);

        //    index = AddCraft(typeof(Sextant), "Ensembles", "Sextant", 75.0, 100.0, typeof(SextantParts), 1044170, 2, 1044253);
        //    AddRes(index, typeof(Hinge), "Charnière", 1, 1044253);

        //    index = AddCraft(typeof(PotionKeg), "Ensembles", "Tonnelet de Potions", 75.0, 100.0, typeof(Keg), 1044255, 1, 1044253);
        //    AddRes(index, typeof(BarrelTap), "Embout de baril", 1, 1044253);
			
			
        //    #endregion

        //    //Désactivé
        //    #region Traps
        //    /*// Dart Trap
        //    index = AddCraft( typeof( DartTrapCraft ), "Pièges", 1024396, 30.0, 80.0, typeof( FerIngot ), 1044036, 1, 1044037 );
        //    AddRes( index, typeof( Bolt ), 1044570, 1, 1044253 );

        //    // Poison Trap
        //    index = AddCraft(typeof(PoisonTrapCraft), "Pièges", 1044593, 30.0, 80.0, typeof(FerIngot), 1044036, 1, 1044037);
        //    AddRes( index, typeof( BasePoisonPotion ), 1044571, 1, 1044253 );

        //    // Explosion Trap
        //    index = AddCraft(typeof(ExplosionTrapCraft), "Pièges", 1044597, 55.0, 105.0, typeof(FerIngot), 1044036, 1, 1044037);
        //    AddRes( index, typeof( BaseExplosionPotion ), 1044569, 1, 1044253 );

        //    // Faction Gas Trap
        //    index = AddCraft(typeof(FactionGasTrapDeed), "Pièges", 1044598, 65.0, 115.0, typeof(Silver), 1044572, Core.AOS ? 250 : 1000, 1044253);
        //    AddRes( index, typeof( FerIngot ), 1044036, 10, 1044037 );
        //    AddRes( index, typeof( BasePoisonPotion ), 1044571, 1, 1044253 );

        //    // Faction explosion Trap
        //    index = AddCraft(typeof(FactionExplosionTrapDeed), "Pièges", 1044599, 65.0, 115.0, typeof(Silver), 1044572, Core.AOS ? 250 : 1000, 1044253);
        //    AddRes( index, typeof( FerIngot ), 1044036, 10, 1044037 );
        //    AddRes( index, typeof( BaseExplosionPotion ), 1044569, 1, 1044253 );

        //    // Faction Saw Trap
        //    index = AddCraft(typeof(FactionSawTrapDeed), "Pièges", 1044600, 65.0, 115.0, typeof(Silver), 1044572, Core.AOS ? 250 : 1000, 1044253);
        //    AddRes( index, typeof( FerIngot ), 1044036, 10, 1044037 );
        //    AddRes( index, typeof( Gears ), 1044254, 1, 1044253 );

        //    // Faction Spike Trap			
        //    index = AddCraft(typeof(FactionSpikeTrapDeed), "Pièges", 1044601, 65.0, 115.0, typeof(Silver), 1044572, Core.AOS ? 250 : 1000, 1044253);
        //    AddRes( index, typeof( FerIngot ), 1044036, 10, 1044037 );
        //    AddRes( index, typeof( Springs ), 1044171, 1, 1044253 );

        //    // Faction trap removal kit
        //    index = AddCraft(typeof(FactionTrapRemovalKit), "Pièges", 1046445, 90.0, 115.0, typeof(Silver), 1044572, 500, 1044253);
        //    AddRes( index, typeof( FerIngot ), 1044036, 10, 1044037 );*/
        //    #endregion

        //    // Set the overridable material
        //    SetSubRes( typeof( FerIngot ), "Fer" );

        //    // Add every material you want the player to be able to choose from
        //    // This will override the overridable material
        //    AddSubRes(typeof(FerIngot), "Fer", CraftResources.GetSkill( CraftResource.Fer), 1044267);
        //    AddSubRes(typeof(CuivreIngot), "Cuivre", CraftResources.GetSkill( CraftResource.Cuivre), 1044268);
        //    AddSubRes(typeof(BronzeIngot), "Bronze", CraftResources.GetSkill(CraftResource.Bronze), 1044268);
        //    AddSubRes(typeof(AcierIngot), "Acier", CraftResources.GetSkill(CraftResource.Acier), 1044268);
        //    AddSubRes(typeof(ArgentIngot), "Argent", CraftResources.GetSkill(CraftResource.Argent), 1044268);
        //    AddSubRes(typeof(OrIngot), "Or", CraftResources.GetSkill(CraftResource.Or), 1044268);
        //    //AddSubRes(typeof(MytherilIngot), "Mytheril", 70.0, 1044268);
        //    //AddSubRes(typeof(LuminiumIngot), "Luminium", 70.0, 1044268);
        //    //AddSubRes(typeof(ObscuriumIngot), "Obscurium", 70.0, 1044268);
        //    //AddSubRes(typeof(MystiriumIngot), "Mystirium", 80.0, 1044268);
        //    //AddSubRes(typeof(DominiumIngot), "Dominium", 80.0, 1044268);
        //    //AddSubRes(typeof(VenariumIngot), "Venarium", 80.0, 1044268);
        //    //AddSubRes(typeof(EclariumIngot), "Eclarium", 90.0, 1044268);
        //    //AddSubRes(typeof(AtheniumIngot), "Athenium", 90.0, 1044268);
        //    //AddSubRes(typeof(UmbrariumIngot), "Umbrarium", 90.0, 1044268);

        //    MarkOption = true;
        //    Repair = true;
        //    CanEnhance = Core.AOS;
        //
        }
	}

	public abstract class TrapCraft : CustomCraft
	{
		private LockableContainer m_Container;

		public LockableContainer Container{ get{ return m_Container; } }

		public abstract TrapType TrapType{ get; }

		public TrapCraft( Mobile from, CraftItem craftItem, CraftSystem craftSystem, Type typeRes, BaseTool tool, int quality ) : base( from, craftItem, craftSystem, typeRes, tool, quality )
		{
		}

		private int Verify( LockableContainer container )
		{
			if ( container == null || container.KeyValue == 0 )
				return 1005638; // You can only trap lockable chests.
			if ( From.Map != container.Map || !From.InRange( container.GetWorldLocation(), 2 ) )
				return 500446; // That is too far away.
			if ( !container.Movable )
				return 502944; // You cannot trap this item because it is locked down.
			if ( !container.IsAccessibleTo( From ) )
				return 502946; // That belongs to someone else.
			if ( container.Locked )
				return 502943; // You can only trap an unlocked object.
			if ( container.TrapType != TrapType.None )
				return 502945; // You can only place one trap on an object at a time.

			return 0;
		}

		private bool Acquire( object target, out int message )
		{
			LockableContainer container = target as LockableContainer;

			message = Verify( container );

			if ( message > 0 )
			{
				return false;
			}
			else
			{
				m_Container = container;
				return true;
			}
		}

		public override void EndCraftAction()
		{
			From.SendLocalizedMessage( 502921 ); // What would you like to set a trap on?
			From.Target = new ContainerTarget( this );
		}

		private class ContainerTarget : Target
		{
			private TrapCraft m_TrapCraft;

			public ContainerTarget( TrapCraft trapCraft ) : base( -1, false, TargetFlags.None )
			{
				m_TrapCraft = trapCraft;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				int message;

				if ( m_TrapCraft.Acquire( targeted, out message ) )
					m_TrapCraft.CraftItem.CompleteCraft( m_TrapCraft.Quality, false, m_TrapCraft.From, m_TrapCraft.CraftSystem, m_TrapCraft.TypeRes, m_TrapCraft.Tool, m_TrapCraft );
				else
					Failure( message );
			}

			protected override void OnTargetCancel( Mobile from, TargetCancelType cancelType )
			{
				if ( cancelType == TargetCancelType.Canceled )
					Failure( 0 );
			}

			private void Failure( int message )
			{
				Mobile from = m_TrapCraft.From;
				BaseTool tool = m_TrapCraft.Tool;

				if ( tool != null && !tool.Deleted && tool.UsesRemaining > 0 )
					from.SendGump( new CraftGump( from, m_TrapCraft.CraftSystem, tool, message ) );
				else if ( message > 0 )
					from.SendLocalizedMessage( message );
			}
		}

		public override Item CompleteCraft( out int message )
		{
			message = Verify( this.Container );

			if ( message == 0 )
			{
				int trapLevel = (int)(From.Skills.Menuiserie.Value / 10);

				Container.TrapType = this.TrapType;
				Container.TrapPower = trapLevel * 9;
				Container.TrapLevel = trapLevel;
				Container.TrapOnLockpick = true;

				message = 1005639; // Trap is disabled until you lock the chest.
			}

			return null;
		}
	}

	[CraftItemID( 0x1BFC )]
	public class DartTrapCraft : TrapCraft
	{
		public override TrapType TrapType{ get{ return TrapType.DartTrap; } }

		public DartTrapCraft( Mobile from, CraftItem craftItem, CraftSystem craftSystem, Type typeRes, BaseTool tool, int quality ) : base( from, craftItem, craftSystem, typeRes, tool, quality )
		{
		}
	}

	[CraftItemID( 0x113E )]
	public class PoisonTrapCraft : TrapCraft
	{
		public override TrapType TrapType{ get{ return TrapType.PoisonTrap; } }

		public PoisonTrapCraft( Mobile from, CraftItem craftItem, CraftSystem craftSystem, Type typeRes, BaseTool tool, int quality ) : base( from, craftItem, craftSystem, typeRes, tool, quality )
		{
		}
	}

	[CraftItemID( 0x370C )]
	public class ExplosionTrapCraft : TrapCraft
	{
		public override TrapType TrapType{ get{ return TrapType.ExplosionTrap; } }

		public ExplosionTrapCraft( Mobile from, CraftItem craftItem, CraftSystem craftSystem, Type typeRes, BaseTool tool, int quality ) : base( from, craftItem, craftSystem, typeRes, tool, quality )
		{
		}
	}
}