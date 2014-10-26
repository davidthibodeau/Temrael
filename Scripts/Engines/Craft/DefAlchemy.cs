using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefAlchemy : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Alchimie;	}
		}

		public override int GumpTitleNumber
		{
			get { return 1044001; } // <CENTER>ALCHEMY MENU</CENTER>
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefAlchemy();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefAlchemy() : base( 1, 1, 1.25 )// base( 1, 1, 3.1 )
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
			from.PlaySound( 0x242 );
		}

		private static Type typeofPotion = typeof( BasePotion );

		public static bool IsPotion( Type type )
		{
			return typeofPotion.IsAssignableFrom( type );
		}

		public override int PlayEndingEffect( Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item )
		{
			if ( toolBroken )
				from.SendLocalizedMessage( 1044038 ); // You have worn out your tool

			if ( failed )
			{
				if ( IsPotion( item.ItemType ) )
				{
					from.AddToBackpack( new Bottle() );
					return 500287; // You fail to create a useful potion.
				}
				else
				{
					return 1044043; // You failed to create the item, and some of your materials are lost.
				}
			}
			else
			{
				from.PlaySound( 0x240 ); // Sound of a filling bottle

				if ( IsPotion( item.ItemType ) )
				{
					if ( quality == -1 )
						return 1048136; // You create the potion and pour it into a keg.
					else
						return 500279; // You pour the potion into a bottle...
				}
				else
				{
					return 1044154; // You create the item.
				}
			}
		}

		public override void InitCraftList()
		{
			int index = -1;

			// Refresh Potion
			index = AddCraft( typeof( RefreshPotion ), "Potions", "Potion de rafraichissement", 0.0, 25.0, typeof( BlackPearl ), "Perle Noire", 1, 1044361 );
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(TotalRefreshPotion), "Potions", "Potion de rafrai. majeure", 25.0, 75.0, typeof( BlackPearl ), "Perles Noires", 5, 1044361);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);

            // Mana Potion
            index = AddCraft(typeof(ManaPotion), "Potions", "Potion de mana", 0.0, 25.0, typeof(SulfurousAsh), "Cendres", 1, 1044361);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(TotalManaPotion), "Potions", "Potion de mana majeure", 25.0, 75.0, typeof(SulfurousAsh), "Cendres", 5, 1044361);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);

			// Agility Potion
            index = AddCraft(typeof(AgilityPotion), "Potions", "Potion d'agilité", 15.0, 65.0, typeof(Bloodmoss), "Mousse Sanglante", 1, 1044362);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(GreaterAgilityPotion), "Potions", "Potion d'agilité majeure", 35.0, 85.0, typeof(Bloodmoss), "Mousse Sanglante", 3, 1044362);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);

			// Nightsight Potion
            index = AddCraft(typeof(NightSightPotion), "Potions", "Potion de vision nocturne", 0.0, 25.0, typeof(SpidersSilk), "Toiles", 1, 1044368);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);

			// Heal Potion
            index = AddCraft(typeof(LesserHealPotion), "Potions", "Potion de soins mineurs", 0.0, 25.0, typeof(Ginseng), "Ginseng", 1, 1044364);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(HealPotion), "Potions", "Potion de soins", 30.0, 60.0, typeof(Ginseng), "Ginseng", 3, 1044364);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(GreaterHealPotion), "Potions", "Potion de soins majeurs", 75.0, 100.0, typeof(Ginseng), "Ginseng", 7, 1044364);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);

			// Strength Potion
            index = AddCraft(typeof(StrengthPotion), "Potions", "Potion de force", 0.0, 25.0, typeof(MandrakeRoot), "Racine de Mandragore", 2, 1044365);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(GreaterStrengthPotion), "Potions", "Potion de force majeure", 45.0, 95.0, typeof(MandrakeRoot), "Racine de Mandragore", 5, 1044365);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);

			// Poison Potion
            index = AddCraft(typeof(LesserPoisonPotion), "Potions", "Potion de poison mineur", 0.0, 45.0, typeof(Nightshade), "Solanacée", 1, 1044366);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(PoisonPotion), "Potions", "Potion de poison", 15.0, 65.0, typeof(Nightshade), "Solanacée", 2, 1044366);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(GreaterPoisonPotion), "Potions", "Potion de poison majeur", 55.0, 105.0, typeof(Nightshade), "Solanacée", 4, 1044366);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(DeadlyPoisonPotion), "Potions", "Potion de poison mortel", 90.0, 140.0, typeof(Nightshade), "Solanacée", 8, 1044366);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);

			// Cure Potion
            index = AddCraft(typeof(LesserCurePotion), "Potions", "Antidote mineur", 0.0, 25.0, typeof(Garlic), "Ail", 1, 1044363);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(CurePotion), "Potions", "Antidote", 25.0, 75.0, typeof(Garlic), "Ail", 3, 1044363);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(GreaterCurePotion), "Potions", "Antidote majeur", 65.0, 115.0, typeof(Garlic), "Ail", 6, 1044363);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);

			// Explosion Potion
            index = AddCraft(typeof(LesserExplosionPotion), "Potions", "Potion explosive mineure", 0.0, 45.0, typeof(SulfurousAsh), "Cendres Sulfureuses", 3, 1044367);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(ExplosionPotion), "Potions", "Potion explosive", 35.0, 85.0, typeof(SulfurousAsh), "Cendres Sulfureuses", 5, 1044367);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(GreaterExplosionPotion), "Potions", "Potion explosive majeure", 65.0, 115.0, typeof(SulfurousAsh), "Cendres Sulfureuses", 10, 1044367);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);

            //Teintures
            //Débutant
            index = AddCraft(typeof(EssenceSouci), "Teintures Debutant", "Essence de soucis", 25.0, 50.0, typeof(SouciPlante), "Fleur de souci", 2, "Vous n'avez pas assez de fleur de souci.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(EssenceImmortelle), "Teintures Debutant", "Essence de l'immortelle", 25.0, 50.0, typeof(ImmortellePlante), "Fleur d'immortelle à Bractées", 2, "Vous n'avez pas assez de fleurs d'immortelles à bractées.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(EssenceKalmia), "Teintures Debutant", "Essence de Kalmia", 25.0, 50.0, typeof(KalmiaPlante), "Fleur de Kalmia", 2, "Vous n'avez pas assez de fleur de Kalmia.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(EssenceAgastache), "Teintures Debutant", "Essence d'Agastache", 25.0, 50.0, typeof(AgastachePlante), "Fleur d'Agastache", 2, "Vous n'avez pas assez de fleur d'Agastache.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(EssenceMelaleuca), "Teintures Debutant", "Essence de Melaleuca ", 25.0, 50.0, typeof(MelaleucaPlante), "Fleur de Melaleuca", 2, "Vous n'avez pas assez de fleur de Melaleuca.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(EssenceAirelleRouge), "Teintures Debutant", "Essence d'Airelle Rouge", 25.0, 50.0, typeof(AirellePlante), "Fleur d'Airelle Rouge", 2, "Vous n'avez pas assez de fleur d'airelle rouge.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(EssenceAchillee), "Teintures Debutant", "Essence d'Achillée", 25.0, 50.0, typeof(AchilleePlante), "Fleur d'Achillée", 2, "Vous n'avez pas assez de fleur d'Achillée.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(EssencedeCiste), "Teintures Debutant", "Essence de Ciste", 25.0, 50.0, typeof(CistePlante), "Fleur de Ciste", 2, "Vous n'avez pas assez de fleur de Ciste.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            //INTERMÉDIAIRE 
            index = AddCraft(typeof(TeintureMiel), "Teintures Intermédiaire", "Teinture de miel", 50.0, 75.0, typeof(JarHoney), "Pot de miel", 5, "Vous n'avez pas assez de pots de miel.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(TeintureFumier), "Teintures Intermédiaire", "Teinture de fumier", 50.0, 75.0, typeof(Fumier), "Fumier", 5, "Vous n'avez pas assez de fumier.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(TeinturePerleNoire), "Teintures Intermédiaire", "Teinture de perles noires", 50.0, 75.0, typeof(BlackPearl), "Perle noire", 15, "Vous n'avez pas assez de perles noires.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(TeintureExtraitDatte), "Teintures Intermédiaire", "Teinture d'extraits de dattes", 50.0, 75.0, typeof(Dattes), "Dattes", 15, "Vous n'avez pas assez de dattes.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(TeinturePlumeBlanche), "Teintures Intermédiaire", "Teinture de plumes blanches", 50.0, 75.0, typeof(Feather), "Plumes", 50, "Vous n'avez pas assez de plumes.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(TeinturePierreVolcanique), "Teintures Intermédiaire", "Teinture de pierres volcaniques", 50.0, 75.0, typeof(PierreVolcanique), "Pierres Volcaniques", 5, "Vous n'avez pas assez de pierres volcaniques.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(TeinturePeauSerpent), "Teintures Intermédiaire", "Teinture de peau de serpent", 50.0, 75.0, typeof(ReptilienLeather), "Cuir Reptilien", 20, "Vous n'avez pas assez de cuir reptilien.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(TeintureGueuleLoup), "Teintures Intermédiaire", "Teinture de gueule-de-loup", 50.0, 75.0, typeof(GueuledeLoupRegeant), "Gueule-de-loup", 5, "Vous n'avez pas assez de gueule-de-loup.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(TeintureEau), "Teintures Intermédiaire", "Teinture d'Eau", 50.0, 75.0, typeof(Pitcher), "Pichet d'Eau", 5, 1044367);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            //Avance
            index = AddCraft(typeof(HuileSulfureDilue), "Teintures Avancés", "Huile de sulfure dilué", 60.0, 90.0, typeof(SulfurousAsh), "Sulfure", 50, "Vous n'avez pas assez de sulfure.");
            AddRes(index, typeof(Pitcher), "Pichet d'Eau", 1, "Il vous manque un pichet d'eau.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(HuileTerreBouillie), "Teintures Avancés", "Huile de terre bouillie", 60.0, 90.0, typeof(Fumier), "Fumier", 25, "Vous n'avez pas assez de fumier.");
            AddRes(index, typeof(Kindling), "Brindilles", 50, "Vous n'avez pas assez de brindilles !");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(HuileCendreLiquefie), "Teintures Avancés", "Huile de cendres liquifiés", 60.0, 90.0, typeof(Cendres), "Cendres", 25, "Vous n'avez pas assez de cendres.");
            AddRes(index, typeof(Pitcher), "Pichet d'Eau", 1, "Il vous manque un pichet d'eau.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(HuileRaisinFermente), "Teintures Avancés", "Huile de raisins fermentés", 60.0, 90.0, typeof(Grapes), "Raisins", 50, "Vous n'avez pas assez de raisins.");
            //AddRes(index, typeof(Pitcher), "Pichet d'Eau", 1, 500315);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(HuileOeufMortifie), "Teintures Avancés", "Huile d'oeufs mortifiés", 60.0, 90.0, typeof(Eggs), "Oeufs", 15, "Vous n'avez pas assez d'oeufs.");
            AddRes(index, typeof(MortarPestle), "Mortier", 1, "Il vous manque un mortier !");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(HuileSangCoagule), "Teintures Avancés", "Huile de sang coagulé", 60.0, 90.0, typeof(FioleDeSang), "Sang Coagulé", 15, "Vous n'avez pas assez de sang coagulé.");
            //AddRes(index, typeof(Pitcher), "Pichet d'Eau", 1, 500315);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            /*index = AddCraft(typeof(HuileVeninNeutralise), "Teintures Avancés", "Huile de venin neutralisé", 60.0, 90.0, typeof(BaiserDeLloth), "Baisé de Lloth", 1, 1044367);
            AddRes(index, typeof(RemedeBaiserDeLloth), "Remede naoser de Lloth", 1, 500315);
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);*/
            index = AddCraft(typeof(HuileCoquillageMacere), "Teintures Avancés", "Huile de coquillages maceres", 60.0, 90.0, typeof(Coquillage), "Coquillages", 25, "Vous n'avez pas assez de coquillages.");
            AddRes(index, typeof(MortarPestle), "Mortier", 1, "Il vous manque un mortier !");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(HuileResineAmbreBleue), "Teintures Avancés", "Huile de resine d'ambre bleue", 60.0, 90.0, typeof(ResineAmbreBleue), "Resine d'ambre bleue", 15, "Vous n'avez pas assez de résine d'ambre bleue.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            //Expert
            index = AddCraft(typeof(PigmentCitrine), "Teintures d'Experts", "Pigment de Citrine fondu", 80.0, 100.0, typeof(Citrine), "Citrine", 25, "Vous n'avez pas assez de citrines.");
            AddRes(index, typeof(EclatDeVolcan), "Eclat de Volcan", 1, "Vous n'avez pas assez d'éclat de volcan.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(PigmentObsidienne), "Teintures d'Experts", "Pigment d'Obsidienne fondu", 80.0, 100.0, typeof(ObsidienRegeant), "Obsidienne", 25, "Vous n'avez pas assez d'obsidienne.");
            AddRes(index, typeof(EclatDeVolcan), "Eclat de Volcan", 1, "Vous n'avez pas assez d'éclat de volcan.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(PigmentAmethyste), "Teintures d'Experts", "Pigment d'Amethyste fondu", 80.0, 100.0, typeof(Amethyst), "Amethyste", 25, "Vous n'avez pas assez d'Amethyst.");
            AddRes(index, typeof(EclatDeVolcan), "Eclat de Volcan", 1, "Vous n'avez pas assez d'éclat de volcan.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(PigmentDiamant), "Teintures d'Experts", "Pigment de Diamant fondu", 80.0, 100.0, typeof(Diamond), "Diamant", 25, "Vous n'avez pas assez de diamants.");
            AddRes(index, typeof(EclatDeVolcan), "Eclat de Volcan", 1, "Vous n'avez pas assez d'éclat de volcan.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(PigmentRubis), "Teintures d'Experts", "Pigment de Rubis fondu", 80.0, 100.0, typeof(Ruby), "Rubis", 25, "Vous n'avez pas assez de rubis.");
            AddRes(index, typeof(EclatDeVolcan), "Eclat de Volcan", 1, "Vous n'avez pas assez d'éclat de volcan.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(PigmentEmeraude), "Teintures d'Experts", "Pigment d'Emeraude fondu", 80.0, 100.0, typeof(Emerald), "Emeraude", 25, "Vous n'avez pas assez d'émeraude.");
            AddRes(index, typeof(EclatDeVolcan), "Eclat de Volcan", 1, "Vous n'avez pas assez d'éclat de volcan.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);
            index = AddCraft(typeof(PigmentSaphir), "Teintures d'Experts", "Pigment de Saphir fondu", 80.0, 100.0, typeof(Sapphire), "Saphir", 25, "Vous n'avez pas assez de saphir.");
            AddRes(index, typeof(EclatDeVolcan), "Eclat de Volcan", 1, "Vous n'avez pas assez d'éclat de volcan.");
            AddRes(index, typeof(Bottle), "Bouteille", 1, 500315);

		}
	}
}