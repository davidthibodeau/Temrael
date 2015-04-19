using System;
using Server;
using Server.Items;

using Server.Targeting;
using Server.Engines.Identities;

namespace Server.Engines.Craft
{
	public class DefJewelcrafting : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Couture; }
		}

		public override int GumpTitleNumber
		{
            get { return 1011172; } // Jewelry
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefJewelcrafting();

				return m_CraftSystem;
			}
		}

        private DefJewelcrafting()
            : base(1, 1, 1.25)// base( 1, 1, 3.0 )
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
            int index = -1;

            #region Tête
            index = AddCraft(typeof(Diaphene), "Tête", "Diaphène", 90.0, 100.0, typeof(FerIngot), "Lingot de Fer", 4, 1044037);
            AddRes(index, typeof(Sapphire), "Saphir", 2, 1044240);
            AddRes(index, typeof(StarSapphire), "Saphir Étoilé", 1, 1044240);
            AddRes(index, typeof(Diamond), "Diamant", 1, 1044240);

            index = AddCraft(typeof(Couronne), "Tête", "Couronne", 90.0, 100.0, typeof(FerIngot), "Lingot de Fer", 5, 1044037);
            AddRes(index, typeof(Diamond), "Diamant", 1, 1044240);
            AddRes(index, typeof(Ruby), "Rubis", 1, 1044240);
            AddRes(index, typeof(Sapphire), "Saphir", 8, 1044240);
            AddRes(index, typeof(StarSapphire), "Saphir Étoilé", 2, 1044240);

            #endregion

            #region Oreilles
            index = AddCraft(typeof(GoldEarrings), "Oreilles", "Boucles d'Oreilles", 40.0, 60.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
            AddRes(index, typeof(Diamond), "Diamant", 1, 1044240);

            #endregion

            #region Cou
            index = AddCraft(typeof(ColierCoquillages), "Cou", "Collier de Coquillages", 40.0, 90.0, typeof(FerIngot), "Lingot de Fer", 4, 1044037);

            index = AddCraft(typeof(ColierDents), "Cou", "Collier de Dents", 40.0, 90.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);

            index = AddCraft(typeof(ColierNordique), "Cou", "Collier Nordique", 20.0, 40.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);

            index = AddCraft(typeof(ColierFer), "Cou", "Collier de Fer", 20.0, 40.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
            AddRes(index, typeof(Citrine), "Citrine", 1, 1044240);

            index = AddCraft(typeof(ColierSerpantin), "Cou", "Collier Serpantin", 30.0, 50.0, typeof(FerIngot), "Lingot de Fer", 6, 1044037);
            AddRes(index, typeof(Tourmaline), "Tourmaline", 1, 1044240);

            index = AddCraft(typeof(GoldNecklace), "Cou", "Collier", 30.0, 50.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
            AddRes(index, typeof(Sapphire), "Saphir", 1, 1044240);

            index = AddCraft(typeof(GoldBeadNecklace), "Cou", "Collier de Perles d'Or", 40.0, 60.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
            AddRes(index, typeof(Amber), "Ambre", 1, 1044240);

            index = AddCraft(typeof(ColierSimple), "Cou", "Collier Simple", 40.0, 60.0, typeof(FerIngot), "Lingot de Fer", 3, 1044037);
            AddRes(index, typeof(Tourmaline), "Tourmaline", 1, 1044240);

            index = AddCraft(typeof(ColierSaphyre), "Cou", "Collier Saphire", 50.0, 70.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
            AddRes(index, typeof(Sapphire), "Saphir", 1, 1044240);

            index = AddCraft(typeof(ColierOrne), "Cou", "Collier Orné", 50.0, 70.0, typeof(FerIngot), "Lingot de Fer", 3, 1044037);
            AddRes(index, typeof(Amber), "Ambre", 1, 1044240);

            index = AddCraft(typeof(ColierLong), "Cou", "Long Collier", 50.0, 70.0, typeof(FerIngot), "Lingot de Fer", 4, 1044037);
            AddRes(index, typeof(Sapphire), "Saphir", 1, 1044240);

            index = AddCraft(typeof(ColierEmeraudes), "Cou", "Collier a Émeraudes", 50.0, 70.0, typeof(FerIngot), "Lingot de Fer", 4, 1044037);
            AddRes(index, typeof(Emerald), "Émeraude", 4, 1044240);

            index = AddCraft(typeof(ColierRubis), "Cou", "Collier a Rubis", 50.0, 70.0, typeof(FerIngot), "Lingot de Fer", 4, 1044037);
            AddRes(index, typeof(Ruby), "Rubis", 1, 1044240);

            index = AddCraft(typeof(ColierLargeRubis), "Cou", "Collier a Large Rubis", 60.0, 80.0, typeof(FerIngot), "Lingot de Fer", 4, 1044037);
            AddRes(index, typeof(Ruby), "Rubis", 1, 1044240);
            AddRes(index, typeof(Citrine), "Citrine", 4, 1044240);

            index = AddCraft(typeof(ColierSud), "Cou", "Collier Royal", 70.0, 90.0, typeof(FerIngot), "Lingot de Fer", 6, 1044037);
            AddRes(index, typeof(Tourmaline), "Tourmaline", 2, 1044240);

            index = AddCraft(typeof(ColierAraignee), "Cou", "Collier Araignée", 70.0, 90.0, typeof(FerIngot), "Lingot de Fer", 6, 1044037);
            AddRes(index, typeof(Amethyst), "Améthyste", 2, 1044240);

            index = AddCraft(typeof(ColierTriple), "Cou", "Collier Triple", 80.0, 100.0, typeof(FerIngot), "Lingot de Fer", 6, 1044037);
            AddRes(index, typeof(Ruby), "Rubis", 1, 1044240);
            AddRes(index, typeof(Emerald), "Émeraude", 1, 1044240);

            #endregion

            #region Poignets
            index = AddCraft(typeof(BracerMetal), "Poignets", "Bracelets", 40.0, 90.0, typeof(FerIngot), "Lingot de Fer", 4, 1044037);

            index = AddCraft(typeof(GoldBracelet), "Poignets", "Bracelet", 40.0, 60.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
            AddRes(index, typeof(Sapphire), "Saphir", 1, 1044240);

            #endregion

            #region Doigts
            index = AddCraft(typeof(GoldRing), "Doigts", "Bague, Tourmaline", 30.0, 50.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
            AddRes(index, typeof(Tourmaline), "Tourmaline", 1, 1044240);

            index = AddCraft(typeof(GoldRing), "Doigts", "Bague, Rubis", 40.0, 60.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
            AddRes(index, typeof(Ruby), "Rubis", 1, 1044240);

            index = AddCraft(typeof(GoldRing), "Doigts", "Bague, Améthyste", 50.0, 70.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
            AddRes(index, typeof(Amethyst), "Améthyste", 1, 1044240);

            index = AddCraft(typeof(GoldRing), "Doigts", "Bague, Émeraude", 55.0, 75.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
            AddRes(index, typeof(Emerald), "Émeraude", 1, 1044240);

            index = AddCraft(typeof(GoldRing), "Doigts", "Bague, Saphir", 60.0, 80.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
            AddRes(index, typeof(Sapphire), "Saphir", 1, 1044240);

            #endregion

            #region Corps
            index = AddCraft(typeof(Bijoux), "Corps", "Bijoux", 60.0, 80.0, typeof(FerIngot), "Lingot de Fer", 8, 1044037);
            AddRes(index, typeof(Citrine), "Citrine", 1, 1044240);

            #endregion

            // Set the overridable material
            SetSubRes(typeof(FerIngot), "Fer");

            // Add every material you want the player to be able to choose from
            // This will override the overridable material
            AddSubRes(typeof(FerIngot), "Fer", CraftResources.GetSkill(CraftResource.Fer), 1044267);
            AddSubRes(typeof(CuivreIngot), "Cuivre", CraftResources.GetSkill(CraftResource.Cuivre), 1044268);
            AddSubRes(typeof(BronzeIngot), "Bronze", CraftResources.GetSkill(CraftResource.Bronze), 1044268);
            AddSubRes(typeof(AcierIngot), "Acier", CraftResources.GetSkill(CraftResource.Acier), 1044268);
            AddSubRes(typeof(ArgentIngot), "Argent", CraftResources.GetSkill(CraftResource.Argent), 1044268);
            AddSubRes(typeof(OrIngot), "Or", CraftResources.GetSkill(CraftResource.Or), 1044268);
            AddSubRes(typeof(MytherilIngot), "Mytheril", CraftResources.GetSkill(CraftResource.Mytheril), 1044268);
            AddSubRes(typeof(LuminiumIngot), "Luminium", CraftResources.GetSkill(CraftResource.Luminium), 1044268);
            AddSubRes(typeof(ObscuriumIngot), "Obscurium", CraftResources.GetSkill(CraftResource.Obscurium), 1044268);
            AddSubRes(typeof(MystiriumIngot), "Mystirium", CraftResources.GetSkill(CraftResource.Mystirium), 1044268);
            AddSubRes(typeof(DominiumIngot), "Dominium", CraftResources.GetSkill(CraftResource.Dominium), 1044268);
            AddSubRes(typeof(VenariumIngot), "Venarium", CraftResources.GetSkill(CraftResource.Venarium), 1044268);
            AddSubRes(typeof(EclariumIngot), "Eclarium", CraftResources.GetSkill(CraftResource.Eclarium), 1044268);
            AddSubRes(typeof(AtheniumIngot), "Athenium", CraftResources.GetSkill(CraftResource.Athenium), 1044268);
            AddSubRes(typeof(UmbrariumIngot), "Umbrarium", CraftResources.GetSkill(CraftResource.Umbrarium), 1044268);

            Resmelt = true;
            MarkOption = true;
            Repair = true;
            CanEnhance = Core.AOS;
        }
	}
}