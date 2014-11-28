using System;
using Server.Items;

namespace Server.Engines.Craft
{
    /*
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
		}
	}
    */
}