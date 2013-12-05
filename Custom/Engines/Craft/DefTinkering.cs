using System;
using Server;
using Server.Items;
using Server.Factions;
using Server.Targeting;

namespace Server.Engines.Craft
{
	public class DefTinkering : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Bricolage; }
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
			else if ( itemType != null && ( itemType.IsSubclassOf( typeof( BaseFactionTrapDeed ) ) || itemType == typeof( FactionTrapRemovalKit ) ) && Faction.Find( from ) == null )
				return 1044573; // You have to be in a faction to do that.

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

		public override bool ConsumeOnFailure( Mobile from, Type resourceType, CraftItem craftItem )
		{
			if ( resourceType == typeof( Silver ) )
				return false;

			return base.ConsumeOnFailure( from, resourceType, craftItem );
		}

		/*public void AddJewelrySet( GemType gemType, Type itemType )
		{
			int offset = (int)gemType - 1;

            index = AddCraft(typeof(SilverBeadNecklace), "Bijoux", "Colier de Coquillages", 40.0, 90.0, typeof(FerIngot), 1044036, 2, 1044037);
            AddRes(index, itemType, 1044231 + offset, 1, 1044240);

            index = AddCraft(typeof(GoldRing), "Bijoux", "Bague", 40.0, 90.0, typeof(OrIngot), 1044036, 2, 1044037);
			AddRes( index, itemType, 1044231 + offset, 1, 1044240 );

            index = AddCraft(typeof(SilverBeadNecklace), "Bijoux", "Colier de Perles", 40.0, 90.0, typeof(ArgentIngot), 1044036, 2, 1044037);
			AddRes( index, itemType, 1044231 + offset, 1, 1044240 );

            index = AddCraft(typeof(GoldNecklace), "Bijoux", "Colier", 40.0, 90.0, typeof(OrIngot), 1044036, 2, 1044037);
			AddRes( index, itemType, 1044231 + offset, 1, 1044240 );

            index = AddCraft(typeof(GoldEarrings), "Bijoux", "Boucles d'Oreilles", 40.0, 90.0, typeof(OrIngot), 1044036, 2, 1044037);
			AddRes( index, itemType, 1044231 + offset, 1, 1044240 );

            index = AddCraft(typeof(GoldBeadNecklace), "Bijoux", "Colier de Perles d'Or", 40.0, 90.0, typeof(OrIngot), 1044036, 2, 1044037);
			AddRes( index, itemType, 1044231 + offset, 1, 1044240 );

            index = AddCraft(typeof(GoldBracelet), "Bijoux", "Bracelet", 40.0, 90.0, typeof(OrIngot), 1044036, 2, 1044037);
			AddRes( index, itemType, 1044231 + offset, 1, 1044240 );
		}*/

		public override void InitCraftList()
		{
			int index = -1;

            #region Materials
                index = AddCraft(typeof(Nails), "Mat�riaux", "Clou", 2.0, 10.0, typeof(FerIngot), "Lingot de Fer", 1, 1044465);
                SetUseAllRes(index, true);

                index = AddCraft(typeof(Bottle), "Mat�riaux", "Bouteille", 5.0, 15.0, typeof(FerIngot), "Lingots de Fer", 2, 1044465);
                SetUseAllRes(index, true);

                index = AddCraft(typeof(IronWire), "Mat�riaux", "Fil de Fer", 5.0, 20.0, typeof(FerIngot), "Lingot de Fer", 1, 1044465);
                SetUseAllRes(index, true);

                index = AddCraft(typeof(CopperWire), "Mat�riaux", "Fil de Cuivre", 10.0, 30.0, typeof(CuivreIngot), "Lingot de Cuivre", 1, 1044465);
                SetUseAllRes(index, true);

                index = AddCraft(typeof(SilverWire), "Mat�riaux", "Fil d'Argent", 30.0, 50.0, typeof(ArgentIngot), "Lingot d'Argent", 1, 1044465);
                SetUseAllRes(index, true);

                index = AddCraft(typeof(GoldWire), "Mat�riaux", "Fil d'Or", 50.0, 90.0, typeof(OrIngot), "Lingot d'Or", 1, 1044465);
                SetUseAllRes(index, true);
            #endregion

            #region Wooden Items
            AddCraft(typeof(JointingPlane), "Objets de Bois", "Rabot de Joints", 0.0, 50.0, typeof(Log), 1044041, 4, 1044351);
            AddCraft(typeof(MouldingPlane), "Objets de Bois", "Rabot de Moulage", 0.0, 50.0, typeof(Log), 1044041, 4, 1044351);
            AddCraft(typeof(SmoothingPlane), "Objets de Bois", "Rabot de Lissage", 0.0, 50.0, typeof(Log), 1044041, 4, 1044351);
            AddCraft(typeof(ClockFrame), "Objets de Bois", "Cadre d'Horloge", 0.0, 50.0, typeof(Log), 1044041, 6, 1044351);
            AddCraft(typeof(Axle), "Objets de Bois", "Essieu", 0.0, 25.0, typeof(Log), 1044041, 2, 1044351);
            AddCraft(typeof(RollingPin), "Objets de Bois", "Rouleau � P�tisserie", 0.0, 50.0, typeof(Log), 1044041, 5, 1044351);

			if( Core.SE )
			{
				index = AddCraft( typeof( Nunchaku ), 1044042, 1030158, 70.0, 120.0, typeof( FerIngot ), 1044036, 3, 1044037 );
				AddRes( index, typeof( Log ), 1044041, 8, 1044351 );
				SetNeededExpansion( index, Expansion.SE );
			}
			#endregion

			#region Tools
            AddCraft(typeof(Scissors), "Outils", "Ciseaux", 5.0, 55.0, typeof(FerIngot), 1044036, 2, 1044037);
            AddCraft(typeof(MortarPestle), "Outils", "Mortier Pilon", 20.0, 70.0, typeof(FerIngot), 1044036, 3, 1044037);
            AddCraft(typeof(Scorp), "Outils", "Scorp", 30.0, 80.0, typeof(FerIngot), 1044036, 2, 1044037);
            AddCraft(typeof(TinkerTools), "Outils", "Outils de Bricolage", 10.0, 60.0, typeof(FerIngot), 1044036, 2, 1044037);
            //AddCraft(typeof(Hatchet), "Outils", "Hachette", 30.0, 80.0, typeof(FerIngot), 1044036, 4, 1044037);
            //AddCraft(typeof(DrawKnife), "Outils", 1024324, 30.0, 80.0, typeof(FerIngot), 1044036, 2, 1044037);
            AddCraft(typeof(SewingKit), "Outils", "Outils de Couture", 10.0, 70.0, typeof(FerIngot), 1044036, 2, 1044037);
            AddCraft(typeof(Knitting), "Outils", "Outils d'Os", 10.0, 70.0, typeof(FerIngot), 1044036, 2, 1044037);
            AddCraft(typeof(Saw), "Outils", "Scie", 30.0, 80.0, typeof(FerIngot), 1044036, 4, 1044037);
            AddCraft(typeof(DovetailSaw), "Outils", "Scie � Queue d'Aronde", 30.0, 80.0, typeof(FerIngot), 1044036, 4, 1044037);
            AddCraft(typeof(Froe), "Outils", "Froe", 30.0, 80.0, typeof(FerIngot), 1044036, 2, 1044037);
            AddCraft(typeof(Shovel), "Outils", "Pelle", 40.0, 90.0, typeof(FerIngot), 1044036, 4, 1044037);
            AddCraft(typeof(Hammer), "Outils", "Marteau", 30.0, 80.0, typeof(FerIngot), 1044036, 1, 1044037);
            AddCraft(typeof(Tongs), "Outils", "Pinces", 35.0, 85.0, typeof(FerIngot), 1044036, 1, 1044037);
            AddCraft(typeof(SmithHammer), "Outils", "Marteau de Forge", 40.0, 90.0, typeof(FerIngot), 1044036, 4, 1044037);
            AddCraft(typeof(SledgeHammer), "Outils", "Maul de Forge", 40.0, 90.0, typeof(FerIngot), 1044036, 4, 1044037);
            AddCraft(typeof(Inshave), "Outils", "Inshave", 30.0, 80.0, typeof(FerIngot), 1044036, 2, 1044037);
            AddCraft(typeof(Pickaxe), "Outils", "Pioche", 40.0, 90.0, typeof(FerIngot), 1044036, 4, 1044037);
            AddCraft(typeof(Lockpick), "Outils", "Crochet", 45.0, 95.0, typeof(FerIngot), 1044036, 1, 1044037);
            AddCraft(typeof(Skillet), "Outils", "Po�lon", 30.0, 80.0, typeof(FerIngot), 1044036, 4, 1044037);
            index = AddCraft(typeof(FishingPole), "Outils", "Cane a Peche", 68.4, 93.4, typeof(Log), "B�che", 5, 1044351); //This is in the categor of Other during AoS
            AddSkill(index, SkillName.Couture, 40.0, 45.0);
            AddRes(index, typeof(Cloth), "Coton", 5, 1044287);
            //AddCraft(typeof(FlourSifter), "Outils", "Farine", 50.0, 100.0, typeof(FerIngot), 1044036, 3, 1044037);
            AddCraft(typeof(FletcherTools), "Outils", "Outils d'Archer", 35.0, 85.0, typeof(Log), "B�che", 3, 1044037);
            //AddCraft(typeof(MapmakersPen), "Outils", 1044167, 25.0, 75.0, typeof(FerIngot), 1044036, 1, 1044037);
            AddCraft(typeof(ScribesPen), "Outils", "Encrier", 25.0, 55.0, typeof(FerIngot), 1044036, 1, 1044037);
            AddCraft(typeof(NewSpellbook), "Outils", "Grimoire", 35.0, 65.0, typeof(Log), "B�che", 2, 1044037);
            AddCraft(typeof(Runebook), "Outils", "Grimoire de Runes", 35.0, 65.0, typeof(Log), "B�che", 2, 1044037);
            //AddCraft(typeof(NewDivineSpellbook), "Outils", "Grimoire Divin", 45.0, 75.0, typeof(Log), "B�che", 2, 1044037);
            AddCraft(typeof(DeguisementKit), "Outils", "Kit de D�guisement", 50.0, 80.0, typeof(Log), "B�che", 3, 1044037);
            AddCraft(typeof(OutilCoagulation), "Outils", "Outil de Coagulation", 60.0, 80.0, typeof(FerIngot), "Fer", 5, 1044037);
            AddCraft(typeof(OutilFermentation), "Outils", "Outil de Coagulation", 60.0, 80.0, typeof(FerIngot), "Fer", 5, 1044037);
			#endregion

			#region Parts
            AddCraft(typeof(Gears), "Pi�ces", "Engrenage", 5.0, 55.0, typeof(FerIngot), 1044036, 2, 1044037);
            AddCraft(typeof(ClockParts), "Pi�ces", "Parties d'Horloges", 25.0, 75.0, typeof(FerIngot), 1044036, 1, 1044037);
            AddCraft(typeof(BarrelTap), "Pi�ces", "Couvercle de Baril", 35.0, 85.0, typeof(FerIngot), 1044036, 2, 1044037);
            AddCraft(typeof(Springs), "Pi�ces", "Ressorts", 5.0, 55.0, typeof(FerIngot), 1044036, 2, 1044037);
            AddCraft(typeof(SextantParts), "Pi�ces", "Pi�ces de Sextant", 30.0, 80.0, typeof(FerIngot), 1044036, 4, 1044037);
            AddCraft(typeof(BarrelHoops), "Pi�ces", "Cercles de Baril", -15.0, 35.0, typeof(FerIngot), 1044036, 5, 1044037);
            AddCraft(typeof(Hinge), "Pi�ces", "Charni�re", 5.0, 55.0, typeof(FerIngot), 1044036, 2, 1044037);
            //AddCraft(typeof(BolaBall), "Pi�ces", 1023699, 45.0, 95.0, typeof(FerIngot), 1044036, 10, 1044037);
			
			if ( Core.ML )
			{
				index = AddCraft( typeof( JeweledFiligree ), 1044047, 1072894, 70.0, 110.0, typeof( FerIngot ), 1044036, 2, 1044037 );
				AddRes( index, typeof( StarSapphire ), 1044231, 1, 1044253 );
				AddRes( index, typeof( Ruby ), 1044234, 1, 1044253 );
				SetNeededExpansion( index, Expansion.ML );
			}
			
			#endregion

			#region Utensils
            AddCraft(typeof(ButcherKnife), "Ustensiles", "Couteau de Boucher", 25.0, 75.0, typeof(FerIngot), 1044036, 2, 1044037);
            AddCraft(typeof(SpoonLeft), "Ustensiles", "Cuillere de Gauche", 0.0, 50.0, typeof(FerIngot), 1044036, 1, 1044037);
            AddCraft(typeof(SpoonRight), "Ustensiles", "Cuillere de Droite", 0.0, 50.0, typeof(FerIngot), 1044036, 1, 1044037);
            AddCraft(typeof(Plate), "Ustensiles", "Assiette", 0.0, 50.0, typeof(FerIngot), 1044036, 2, 1044037);
            AddCraft(typeof(ForkLeft), "Ustensiles", "Fourchette de Gauche", 0.0, 50.0, typeof(FerIngot), 1044036, 1, 1044037);
            AddCraft(typeof(ForkRight), "Ustensiles", "Fouchette de Droite", 0.0, 50.0, typeof(FerIngot), 1044036, 1, 1044037);
            AddCraft(typeof(Cleaver), "Ustensiles", "Couperet", 20.0, 70.0, typeof(FerIngot), 1044036, 3, 1044037);
            AddCraft(typeof(KnifeLeft), "Ustensiles", "Couteau de Gauche", 0.0, 50.0, typeof(FerIngot), 1044036, 1, 1044037);
            AddCraft(typeof(KnifeRight), "Ustensiles", "Couteau de Droite", 0.0, 50.0, typeof(FerIngot), 1044036, 1, 1044037);
            AddCraft(typeof(Goblet), "Ustensiles", "Goblet", 10.0, 60.0, typeof(FerIngot), 1044036, 2, 1044037);
            AddCraft(typeof(PewterMug), "Ustensiles", "Coupe", 10.0, 60.0, typeof(FerIngot), 1044036, 2, 1044037);
            //AddCraft(typeof(SkinningKnife), "Ustensiles", 1023781, 25.0, 75.0, typeof(FerIngot), 1044036, 2, 1044037);
			#endregion

			#region Misc
            AddCraft(typeof(BlankScroll), "Divers", "Parchemin Vierge", 0.0, 30.0, typeof(Kindling), "Brindilles", 5, 1044037);
            AddCraft(typeof(KeyRing), "Divers", "Porte Clefs", 10.0, 60.0, typeof(FerIngot), 1044036, 2, 1044037);
            AddCraft(typeof(Candelabra), "Divers", "Cand�labre", 55.0, 105.0, typeof(FerIngot), 1044036, 4, 1044037);
            AddCraft(typeof(Scales), "Divers", "Balance", 60.0, 110.0, typeof(FerIngot), 1044036, 4, 1044037);
            AddCraft(typeof(Key), "Divers", "Clef", 20.0, 70.0, typeof(FerIngot), 1044036, 3, 1044037);
            AddCraft(typeof(Globe), "Divers", "Glove", 55.0, 105.0, typeof(FerIngot), 1044036, 4, 1044037);
            AddCraft(typeof(Spyglass), "Divers", "Lunette de Marin", 60.0, 110.0, typeof(FerIngot), 1044036, 4, 1044037);
            AddCraft(typeof(Lantern), "Divers", "Lanterne", 30.0, 80.0, typeof(FerIngot), 1044036, 2, 1044037);
            //AddCraft(typeof(HeatingStand), "Divers", 1026217, 60.0, 110.0, typeof(FerIngot), 1044036, 4, 1044037);

			if ( Core.SE )
			{
				index = AddCraft( typeof( ShojiLantern ), 1044050, 1029404, 65.0, 115.0, typeof( FerIngot ), 1044036, 10, 1044037 );
				AddRes( index, typeof( Log ), 1044041, 5, 1044351 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( PaperLantern ), 1044050, 1029406, 65.0, 115.0, typeof( FerIngot ), 1044036, 10, 1044037 );
				AddRes( index, typeof( Log ), 1044041, 5, 1044351 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( RoundPaperLantern ), 1044050, 1029418, 65.0, 115.0, typeof( FerIngot ), 1044036, 10, 1044037 );
				AddRes( index, typeof( Log ), 1044041, 5, 1044351 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( WindChimes ), 1044050, 1030290, 80.0, 130.0, typeof( FerIngot ), 1044036, 15, 1044037 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( FancyWindChimes ), 1044050, 1030291, 80.0, 130.0, typeof( FerIngot ), 1044036, 15, 1044037 );
				SetNeededExpansion( index, Expansion.SE );

			}
			#endregion

			#region Jewelry
            index = AddCraft(typeof(BracerMetal), "Bijoux", "Bracelets", 40.0, 90.0, typeof(FerIngot), "Lingot de Fer", 4, 1044037);

            index = AddCraft(typeof(ColierCoquillages), "Bijoux", "Colier de Coquillages", 40.0, 90.0, typeof(FerIngot), "Lingot de Fer", 4, 1044037);

            index = AddCraft(typeof(ColierDents), "Bijoux", "Colier de Dents", 40.0, 90.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
            
            index = AddCraft(typeof(ColierNordique), "Bijoux", "Colier Nordique", 20.0, 40.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);

            index = AddCraft(typeof(ColierFer), "Bijoux", "Colier de Fer", 20.0, 40.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
            AddRes(index, typeof(Citrine), "Citrine", 1, 1044240);

            index = AddCraft(typeof(ColierSerpantin), "Bijoux", "Colier Serpantin", 30.0, 50.0, typeof(FerIngot), "Lingot de Fer", 6, 1044037);
            AddRes(index, typeof(Tourmaline), "Tourmaline", 1, 1044240);

            index = AddCraft(typeof(SilverBeadNecklace), "Bijoux", "Colier de Perles", 30.0, 50.0, typeof(ArgentIngot), "Lingot d'Argent", 2, 1044037);
            AddRes(index, typeof(Sapphire), "Saphir", 1, 1044240);

            index = AddCraft(typeof(GoldRing), "Bijoux", "Bague", 30.0, 50.0, typeof(OrIngot), "Lingot d'Or", 2, 1044037);
            AddRes(index, typeof(Ruby), "Rubis", 1, 1044240);

            index = AddCraft(typeof(GoldNecklace), "Bijoux", "Colier", 30.0, 50.0, typeof(OrIngot), "Lingot d'Or", 2, 1044037);
            AddRes(index, typeof(Sapphire), "Saphir", 1, 1044240);

            index = AddCraft(typeof(GoldEarrings), "Bijoux", "Boucles d'Oreilles", 40.0, 60.0, typeof(OrIngot), "Lingot d'Or", 2, 1044037);
            AddRes(index, typeof(Diamond), "Diamant", 1, 1044240);

            index = AddCraft(typeof(GoldBeadNecklace), "Bijoux", "Colier de Perles d'Or", 40.0, 60.0, typeof(OrIngot), "Lingot d'Or", 2, 1044037);
            AddRes(index, typeof(Amber), "Ambre", 1, 1044240);

            index = AddCraft(typeof(GoldBracelet), "Bijoux", "Bracelet", 40.0, 60.0, typeof(OrIngot), "Lingot d'Or", 2, 1044037);
            AddRes(index, typeof(Sapphire), "Saphir", 1, 1044240);

            index = AddCraft(typeof(ColierSimple), "Bijoux", "Colier Simple", 40.0, 60.0, typeof(OrIngot), "Lingot d'Or", 3, 1044037);
            AddRes(index, typeof(Tourmaline), "Tourmaline", 1, 1044240);

            index = AddCraft(typeof(ColierSaphyre), "Bijoux", "Colier Saphire", 50.0, 70.0, typeof(OrIngot), "Lingot d'Or", 2, 1044037);
            AddRes(index, typeof(Sapphire), "Saphir", 1, 1044240);

            index = AddCraft(typeof(ColierOrne), "Bijoux", "Colier Orn�", 50.0, 70.0, typeof(OrIngot), "Lingot d'Or", 3, 1044037);
            AddRes(index, typeof(Amber), "Ambre", 1, 1044240);

            index = AddCraft(typeof(ColierLong), "Bijoux", "Long Colier", 50.0, 70.0, typeof(OrIngot), "Lingot d'Or", 4, 1044037);
            AddRes(index, typeof(Sapphire), "Saphir", 1, 1044240);

            index = AddCraft(typeof(ColierEmeraudes), "Bijoux", "Colier a �meraudes", 50.0, 70.0, typeof(OrIngot), "Lingot d'Or", 4, 1044037);
            AddRes(index, typeof(Emerald), "�meraude", 4, 1044240);

            index = AddCraft(typeof(ColierRubis), "Bijoux", "Colier a Rubis", 50.0, 70.0, typeof(OrIngot), "Lingot d'Or", 4, 1044037);
            AddRes(index, typeof(Ruby), "Rubis", 1, 1044240);

            index = AddCraft(typeof(ColierLargeRubis), "Bijoux", "Colier a Large Rubis", 60.0, 80.0, typeof(OrIngot), "Lingot d'Or", 4, 1044037);
            AddRes(index, typeof(Ruby), "Rubis", 1, 1044240);
            AddRes(index, typeof(Citrine), "Citrine", 4, 1044240);

            index = AddCraft(typeof(Bijoux), "Bijoux", "Bijoux", 60.0, 80.0, typeof(OrIngot), "Lingot d'Or", 8, 1044037);
            AddRes(index, typeof(Citrine), "Citrine", 1, 1044240);

            index = AddCraft(typeof(ColierSud), "Bijoux", "Colier Royal", 70.0, 90.0, typeof(OrIngot), "Lingot d'Or", 6, 1044037);
            AddRes(index, typeof(Tourmaline), "Tourmaline", 2, 1044240);

            index = AddCraft(typeof(ColierAraignee), "Bijoux", "Colier Araign�e", 70.0, 90.0, typeof(FerIngot), "Lingot de Fer", 6, 1044037);
            AddRes(index, typeof(Amethyst), "Am�thyste", 2, 1044240);

            index = AddCraft(typeof(ColierTriple), "Bijoux", "Colier Triple", 80.0, 100.0, typeof(OrIngot), "Lingot d'Or", 6, 1044037);
            AddRes(index, typeof(Ruby), "Rubis", 1, 1044240);
            AddRes(index, typeof(Emerald), "�meraude", 1, 1044240);

            index = AddCraft(typeof(Diaphene), "Bijoux", "Diaph�ne", 90.0, 100.0, typeof(OrIngot), "Lingot d'Or", 4, 1044037);
            AddRes(index, typeof(Sapphire), "Saphir", 2, 1044240);
            AddRes(index, typeof(StarSapphire), "Saphir �toil�", 1, 1044240);
            AddRes(index, typeof(Diamond), "Diamant", 1, 1044240);

            index = AddCraft(typeof(Couronne), "Bijoux", "Couronne", 90.0, 100.0, typeof(OrIngot), "Lingot d'Or", 5, 1044037);
            AddRes(index, typeof(Diamond), "Diamant", 1, 1044240);
            AddRes(index, typeof(Ruby), "Rubis", 1, 1044240);
            AddRes(index, typeof(Sapphire), "Saphir", 8, 1044240);
            AddRes(index, typeof(StarSapphire), "Saphir �toil�", 2, 1044240);

			/*AddJewelrySet( GemType.StarSapphire, typeof( StarSapphire ) );
			AddJewelrySet( GemType.Emerald, typeof( Emerald ) );
			AddJewelrySet( GemType.Sapphire, typeof( Sapphire ) );
			AddJewelrySet( GemType.Ruby, typeof( Ruby ) );
			AddJewelrySet( GemType.Citrine, typeof( Citrine ) );
			AddJewelrySet( GemType.Amethyst, typeof( Amethyst ) );
			AddJewelrySet( GemType.Tourmaline, typeof( Tourmaline ) );
			AddJewelrySet( GemType.Amber, typeof( Amber ) );
			AddJewelrySet( GemType.Diamond, typeof( Diamond ) );*/
			#endregion
			
			
			#region Vases
            index = AddCraft(typeof(GrandVaseBec), "Vases", "Grand vase � bec", 50.0, 60.0, typeof(FerIngot), "Lingot de Fer", 5, 1044037);
			index = AddCraft(typeof(PetitVaseBec), "Vases", "Petit vase � bec", 40.0, 50.0, typeof(FerIngot), "Lingot de Fer", 3, 1044037);
			index = AddCraft(typeof(GrandVase), "Vases", "Grand vase", 40.0, 50.0, typeof(FerIngot), "Lingot de Fer", 5, 1044037);
			index = AddCraft(typeof(PetitVase), "Vases", "Petit vase", 30.0, 40.0, typeof(FerIngot), "Lingot de Fer", 3, 1044037);
			index = AddCraft(typeof(VaseRose), "Vases", "Vase � Rose", 60.0, 70.0, typeof(FerIngot), "Lingot de Fer", 5, 1044037);
			index = AddCraft(typeof(GrandPot), "Vases", "Grand pot", 40.0, 50.0, typeof(FerIngot), "Lingot de Fer", 4, 1044037);
			index = AddCraft(typeof(PetitPot), "Vases", "Petit pot", 20.0, 30.0, typeof(FerIngot), "Lingot de Fer", 2, 1044037);
			#endregion
			
			
			#region Mannequins
            index = AddCraft(typeof(WigStand), "Mannequins", "Stand � perruque", 30.0, 50.0, typeof(Cloth), "Tissu", 2, 1044037);
			AddRes(index, typeof(Feather), "Plumes", 20, 1044253);
			AddRes(index, typeof(Log), "Bois", 2, 1044253);
			index = AddCraft(typeof(MannequinMale), "Mannequins", "Mannequin de front", 60.0, 70.0, typeof(Cloth), "Tissu", 5, 1044037);
			AddRes(index, typeof(Feather), "Plumes", 50, 1044253);
			AddRes(index, typeof(Log), "Bois", 3, 1044253);
			index = AddCraft(typeof(MannequinFemale), "Mannequins", "Mannequin de c�t�", 60.0, 70.0, typeof(Cloth), "Tissu", 5, 1044037);
			AddRes(index, typeof(Feather), "Plumes", 50, 1044253);
			AddRes(index, typeof(Log), "Bois", 3, 1044253);
			index = AddCraft(typeof(PoupeeFemale), "Mannequins", "Poup�e f�minine", 60.0, 70.0, typeof(Cloth), "Tissu", 5, 1044037);
			AddRes(index, typeof(Feather), "Plumes", 50, 1044253);
			index = AddCraft(typeof(PoupeeMale), "Mannequins", "Poup�e masculine", 60.0, 70.0, typeof(Cloth), "Tissu", 5, 1044037);
			AddRes(index, typeof(Feather), "Plumes", 50, 1044253);
			index = AddCraft(typeof(TeddyBear), "Mannequins", "Ourson en peluche", 30.0, 50.0, typeof(Cloth), "Tissu", 5, 1044037);
			AddRes(index, typeof(Feather), "Plumes", 50, 1044253);
			index = AddCraft(typeof(WoodenHorse), "Mannequins", "Cheval de bois", 70.0, 80.0, typeof(Log), "Bois", 15, 1044037);

			#endregion
			
			#region Gamelles
            index = AddCraft(typeof(GamelleA), "Gamelles", "Po�le � frire", 20.0, 40.0, typeof(FerIngot), "Fer", 2, 1044037);
			index = AddCraft(typeof(GamelleB), "Gamelles", "Casserole sale", 20.0, 40.0, typeof(FerIngot), "Fer", 2, 1044037);
			index = AddCraft(typeof(GamelleC), "Gamelles", "Po�le sale", 20.0, 40.0, typeof(FerIngot), "Fer", 2, 1044037);
			index = AddCraft(typeof(GamelleD), "Gamelles", "Plat sale", 20.0, 40.0, typeof(FerIngot), "Fer", 2, 1044037);
			index = AddCraft(typeof(GamelleE), "Gamelles", "Plat � poign�es", 30.0, 50.0, typeof(FerIngot), "Fer", 2, 1044037);
			index = AddCraft(typeof(GamelleF), "Gamelles", "Casserole", 30.0, 50.0, typeof(FerIngot), "Fer", 2, 1044037);
			index = AddCraft(typeof(GamelleG), "Gamelles", "Grosse casserole sale", 50.0, 60.0, typeof(FerIngot), "Fer", 3, 1044037);
			index = AddCraft(typeof(GamelleH), "Gamelles", "Plat � poign�es sale", 50.0, 60.0, typeof(FerIngot), "Fer", 2, 1044037);
			index = AddCraft(typeof(GamelleI), "Gamelles", "Grosse po�le sale", 50.0, 60.0, typeof(FerIngot), "Fer", 3, 1044037);
			index = AddCraft(typeof(GamelleJ), "Gamelles", "Grosse gamelle", 50.0, 60.0, typeof(FerIngot), "Fer", 3, 1044037);
			index = AddCraft(typeof(GamelleK), "Gamelles", "Plat � gratin", 50.0, 60.0, typeof(FerIngot), "Fer", 2, 1044037);
			index = AddCraft(typeof(GamelleK), "Gamelles", "Plat � gratin sale", 50.0, 60.0, typeof(FerIngot), "Fer", 2, 1044037);
			index = AddCraft(typeof(GamelleM), "Gamelles", "Gros plat sale", 50.0, 60.0, typeof(FerIngot), "Fer", 2, 1044037);
			index = AddCraft(typeof(GamelleN), "Gamelles", "Gamelle profonde", 60.0, 70.0, typeof(FerIngot), "Fer", 4, 1044037);
			index = AddCraft(typeof(GamelleO), "Gamelles", "Ecuelle sale", 20.0, 40.0, typeof(FerIngot), "Fer", 1, 1044037);
			index = AddCraft(typeof(GamelleP), "Gamelles", "Ecuelle propre", 20.0, 40.0, typeof(FerIngot), "Fer", 1, 1044037);
			index = AddCraft(typeof(GamelleQ), "Gamelles", "Chaudron avec support", 70.0, 80.0, typeof(FerIngot), "Fer", 20, 1044037);
			index = AddCraft(typeof(GamelleR), "Gamelles", "Chaudron", 65.0, 75.0, typeof(FerIngot), "Fer", 15, 1044037);
			
			#endregion
			

			#region Multi-Component Items
			//index = AddCraft( typeof( AxleGears ), "Ensembles", "Essieu", 0.0, 0.0, typeof( Axle ), 1044169, 1, 1044253 );
            //AddRes(index, typeof(Gears), "Engrenage", 1, 1044253);

            index = AddCraft(typeof(ClockParts), "Ensembles", "Parties d'Horloges", 0.0, 0.0, typeof(AxleGears), 1044170, 1, 1044253);
            AddRes(index, typeof(Springs), "Ressorts", 1, 1044253);

            index = AddCraft(typeof(SextantParts), "Ensembles", "Parties de Sextant", 0.0, 0.0, typeof(AxleGears), 1044170, 1, 1044253);
            AddRes(index, typeof(Hinge), "Charni�re", 1, 1044253);

            /*index = AddCraft(typeof(ClockRight), "Ensembles", "Horloge de Droit", 0.0, 0.0, typeof(ClockFrame), 1044174, 1, 1044253);
            AddRes(index, typeof(ClockParts), "Partie d'Horloge", 1, 1044253);

            index = AddCraft(typeof(ClockLeft), "Ensembles", "Horloge de Gauche", 0.0, 0.0, typeof(ClockFrame), 1044174, 1, 1044253);
			AddRes( index, typeof( ClockParts ), "Partie d'Horloge", 1, 1044253 );*/

            //AddCraft(typeof(Sextant), "Ensembles", "Sextant", 0.0, 0.0, typeof(SextantParts), 1044175, 1, 1044253);

            //index = AddCraft(typeof(Bola), "Ensembles", 1046441, 60.0, 80.0, typeof(BolaBall), 1046440, 4, 1042613);
			//AddRes( index, typeof( Leather ), 1044462, 3, 1044463 );

            index = AddCraft(typeof(PotionKeg), "Ensembles", "Tonnelet de Potions", 75.0, 100.0, typeof(Keg), 1044255, 1, 1044253);
			AddRes( index, typeof( Bottle ), "Bouteilles", 10, 1044253 );
			AddRes( index, typeof( BarrelLid ), "Couvercle de Baril", 1, 1044253 );
            AddRes(index, typeof(BarrelHoops), "Cercles de Baril", 1, 1044253);
			
			
			#endregion

			#region Traps
			/*// Dart Trap
			index = AddCraft( typeof( DartTrapCraft ), "Pi�ges", 1024396, 30.0, 80.0, typeof( FerIngot ), 1044036, 1, 1044037 );
			AddRes( index, typeof( Bolt ), 1044570, 1, 1044253 );

			// Poison Trap
            index = AddCraft(typeof(PoisonTrapCraft), "Pi�ges", 1044593, 30.0, 80.0, typeof(FerIngot), 1044036, 1, 1044037);
			AddRes( index, typeof( BasePoisonPotion ), 1044571, 1, 1044253 );

			// Explosion Trap
            index = AddCraft(typeof(ExplosionTrapCraft), "Pi�ges", 1044597, 55.0, 105.0, typeof(FerIngot), 1044036, 1, 1044037);
			AddRes( index, typeof( BaseExplosionPotion ), 1044569, 1, 1044253 );

			// Faction Gas Trap
            index = AddCraft(typeof(FactionGasTrapDeed), "Pi�ges", 1044598, 65.0, 115.0, typeof(Silver), 1044572, Core.AOS ? 250 : 1000, 1044253);
			AddRes( index, typeof( FerIngot ), 1044036, 10, 1044037 );
			AddRes( index, typeof( BasePoisonPotion ), 1044571, 1, 1044253 );

			// Faction explosion Trap
            index = AddCraft(typeof(FactionExplosionTrapDeed), "Pi�ges", 1044599, 65.0, 115.0, typeof(Silver), 1044572, Core.AOS ? 250 : 1000, 1044253);
			AddRes( index, typeof( FerIngot ), 1044036, 10, 1044037 );
			AddRes( index, typeof( BaseExplosionPotion ), 1044569, 1, 1044253 );

			// Faction Saw Trap
            index = AddCraft(typeof(FactionSawTrapDeed), "Pi�ges", 1044600, 65.0, 115.0, typeof(Silver), 1044572, Core.AOS ? 250 : 1000, 1044253);
			AddRes( index, typeof( FerIngot ), 1044036, 10, 1044037 );
			AddRes( index, typeof( Gears ), 1044254, 1, 1044253 );

			// Faction Spike Trap			
            index = AddCraft(typeof(FactionSpikeTrapDeed), "Pi�ges", 1044601, 65.0, 115.0, typeof(Silver), 1044572, Core.AOS ? 250 : 1000, 1044253);
			AddRes( index, typeof( FerIngot ), 1044036, 10, 1044037 );
			AddRes( index, typeof( Springs ), 1044171, 1, 1044253 );

			// Faction trap removal kit
            index = AddCraft(typeof(FactionTrapRemovalKit), "Pi�ges", 1046445, 90.0, 115.0, typeof(Silver), 1044572, 500, 1044253);
			AddRes( index, typeof( FerIngot ), 1044036, 10, 1044037 );*/
			#endregion

			// Set the overridable material
			SetSubRes( typeof( FerIngot ), "Fer" );

			// Add every material you want the player to be able to choose from
			// This will override the overridable material
            AddSubRes(typeof(FerIngot), "Fer", 00.0, 1044267);
            AddSubRes(typeof(CuivreIngot), "Cuivre", 65.0, 1044268);
            AddSubRes(typeof(BronzeIngot), "Bronze", 70.0, 1044268);
            AddSubRes(typeof(AcierIngot), "Acier", 75.0, 1044268);
            AddSubRes(typeof(ArgentIngot), "Argent", 80.0, 1044268);
            AddSubRes(typeof(OrIngot), "Or", 85.0, 1044268);
            AddSubRes(typeof(MytherilIngot), "Mytheril", 90.0, 1044268);
            AddSubRes(typeof(LuminiumIngot), "Luminium", 95.0, 1044268);
            AddSubRes(typeof(ObscuriumIngot), "Obscurium", 99.0, 1044268);
            AddSubRes(typeof(MystiriumIngot), "Mystirium", 99.0, 1044268);
            AddSubRes(typeof(DominiumIngot), "Dominium", 99.0, 1044268);
            AddSubRes(typeof(EclariumIngot), "Eclarium", 99.0, 1044268);
            AddSubRes(typeof(VenariumIngot), "Venarium", 99.0, 1044268);
            AddSubRes(typeof(AtheniumIngot), "Athenium", 99.0, 1044268);
            AddSubRes(typeof(UmbrariumIngot), "Umbrarium", 99.0, 1044268);

			MarkOption = true;
			Repair = true;
			CanEnhance = Core.AOS;
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
				int trapLevel = (int)(From.Skills.Bricolage.Value / 10);

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