using System;
using Server.Items;
using Server.Spells;

namespace Server.Engines.Craft
{
	public class DefInscription : CraftSystem
	{
		public override SkillName MainSkill
		{
			get { return SkillName.Inscription; }
		}

		public override int GumpTitleNumber
		{
			get { return 1044009; } // <CENTER>INSCRIPTION MENU</CENTER>
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if (m_CraftSystem == null)
					m_CraftSystem = new DefInscription();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin(CraftItem item)
		{
			return 0.0; // 0%
		}

		private DefInscription()
			: base(1, 1, 1.25)// base( 1, 1, 3.0 )
		{
		}

		public override int CanCraft(Mobile from, BaseTool tool, Type typeItem)
		{
			if (tool == null || tool.Deleted || tool.UsesRemaining < 0)
				return 1044038; // You have worn out your tool!
			else if (!BaseTool.CheckAccessible(tool, from))
				return 1044263; // The tool must be on your person to use.

			/*if (typeItem != null)
			{
				object o = Activator.CreateInstance(typeItem);

				if (o is SpellScroll)
				{
					SpellScroll scroll = (SpellScroll)o;
					Spellbook book = Spellbook.Find(from, scroll.SpellID);

					bool hasSpell = (book != null && book.HasSpell(scroll.SpellID));

					scroll.Delete();

					return (hasSpell ? 0 : 1042404); // null : You don't have that spell!
				}
				else if (o is Item)
				{
					((Item)o).Delete();
				}
			}*/

			return 0;
		}

		public override void PlayCraftEffect(Mobile from)
		{
			from.PlaySound(0x249);
		}

		private static Type typeofSpellScroll = typeof(SpellScroll);

		public override int PlayEndingEffect(Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item)
		{
			if (toolBroken)
				from.SendLocalizedMessage(1044038); // You have worn out your tool

			if (!typeofSpellScroll.IsAssignableFrom(item.ItemType)) //  not a scroll
			{
				if (failed)
				{
					if (lostMaterial)
						return 1044043; // You failed to create the item, and some of your materials are lost.
					else
						return 1044157; // You failed to create the item, but no materials were lost.
				}
				else
				{
					if (quality == 0)
						return 502785; // You were barely able to make this item.  It's quality is below average.
					else if (makersMark && quality == 2)
						return 1044156; // You create an exceptional quality item and affix your maker's mark.
					else if (quality == 2)
						return 1044155; // You create an exceptional quality item.
					else
						return 1044154; // You create the item.
				}
			}
			else
			{
				if (failed)
					return 501630; // You fail to inscribe the scroll, and the scroll is ruined.
				else
					return 501629; // You inscribe the spell and put the scroll in your backpack.
			}
		}

		private int m_Circle, m_Mana; // Celà veut dire que l'inscription n'a jamais réellement fonctionné..... ? À tester.

		private enum Reg { BlackPearl, Bloodmoss, Garlic, Ginseng, MandrakeRoot, Nightshade, SulfurousAsh, SpidersSilk }

		private Type[] m_RegTypes = new Type[]
			{
				typeof( BlackPearl ),
				typeof( Bloodmoss ),
				typeof( Garlic ),
				typeof( Ginseng ),
				typeof( MandrakeRoot ),
				typeof( Nightshade ),
				typeof( SulfurousAsh ),
				typeof( SpidersSilk )
			};

		private int m_Index;

		private void AddSpell(Type type, params Reg[] regs)
		{
			double minSkill, maxSkill;

			switch (m_Circle)
			{
				default:
				case 0: minSkill = -25.0; maxSkill = 25.0; break;
				case 1: minSkill = -10.8; maxSkill = 39.2; break;
				case 2: minSkill = 03.5; maxSkill = 53.5; break;
				case 3: minSkill = 17.8; maxSkill = 67.8; break;
				case 4: minSkill = 32.1; maxSkill = 82.1; break;
				case 5: minSkill = 46.4; maxSkill = 96.4; break;
				case 6: minSkill = 60.7; maxSkill = 110.7; break;
				case 7: minSkill = 75.0; maxSkill = 125.0; break;
			}

			int index = AddCraft(type, 1044369 + m_Circle, 1044381 + m_Index++, minSkill, maxSkill, m_RegTypes[(int)regs[0]], 1044353 + (int)regs[0], 1, 1044361 + (int)regs[0]);

			for (int i = 1; i < regs.Length; ++i)
				AddRes(index, m_RegTypes[(int)regs[i]], 1044353 + (int)regs[i], 1, 1044361 + (int)regs[i]);

			AddRes(index, typeof(BlankScroll), 1044377, 1, 1044378);

			SetManaReq(index, m_Mana);
		}

		private void AddNecroSpell(int spell, int mana, double minSkill, Type type, params Type[] regs)
		{
			int id = CraftItem.ItemIDOf(regs[0]);

			int index = AddCraft(type, 1061677, 1060509 + spell, minSkill, minSkill + 1.0, regs[0], id < 0x4000 ? 1020000 + id : 1078872 + id, 1, 501627);	//Yes, on OSI it's only 1.0 skill diff'.  Don't blame me, blame OSI.

			for (int i = 1; i < regs.Length; ++i)
			{
				id = CraftItem.ItemIDOf(regs[i]);
				AddRes(index, regs[i], id < 0x4000 ? 1020000 + id : 1078872 + id, 1, 501627);
			}

			AddRes(index, typeof(BlankScroll), 1044377, 1, 1044378);

			SetManaReq(index, mana);
		}

		public override void InitCraftList()
		{
            int index = -1;

            //index = AddCraft(typeof(BlankScroll), "Livres et Papier", "Parchemin Vierge", 0.0, 30.0, typeof(Kindling), "Brindilles", 5, 1044037);
            //SetUseAllRes(index, true);
            index = AddCraft(typeof(NewSpellbook), "Livres et Papier", "Grimoire", 10.0, 40.0, typeof(BlankScroll), "Parchemin Vierge", 10, 1044361);
            AddRes(index, typeof(Leather), "Cuir", 2, 1044463);
            //index = AddCraft(typeof(Runebook), "Livres et Papier", "Grimoire de Runes", 15.0, 45.0, typeof(BlankScroll), "Parchemin Vierge", 10, 1044361);
            //AddRes(index, typeof(Leather), "Cuir", 2, 1044463);
            index = AddCraft(typeof(BlueBook), "Livres et Papier", "Livre Bleu", 5.0, 35.0, typeof(BlankScroll), "Parchemin Vierge", 5, 1044361);
            AddRes(index, typeof(Leather), "Cuir", 2, 1044463);
            index = AddCraft(typeof(BrownBook), "Livres et Papier", "Livre Brun", 5.0, 35.0, typeof(BlankScroll), "Parchemin Vierge", 5, 1044361);
            AddRes(index, typeof(Leather), "Cuir", 2, 1044463);
            index = AddCraft(typeof(RedBook), "Livres et Papier", "Livre Rouge", 5.0, 35.0, typeof(BlankScroll), "Parchemin Vierge", 5, 1044361);
            AddRes(index, typeof(Leather), "Cuir", 2, 1044463);
            index = AddCraft(typeof(TanBook), "Livres et Papier", "Livre Beige", 5.0, 35.0, typeof(BlankScroll), "Parchemin Vierge", 5, 1044361);
            AddRes(index, typeof(Leather), "Cuir", 2, 1044463);

            index = AddCraft(typeof(MagicArrowScroll), "Évocation", "Flèche magique", 30.0, 60.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(ExplosionScroll), "Évocation", "Explosion", 42.0, 72.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(EnergyBoltScroll), "Évocation", "Énergie", 54.0, 84.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(FireFieldScroll), "Évocation", "Mur de feu", 66.0, 96.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(LightningScroll), "Évocation", "Éclair", 78.0, 108.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(ChainLightningScroll), "Évocation", "Chaine d'éclair", 90.0, 120.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);

            index = AddCraft(typeof(WallOfStoneScroll), "Immuabilité", "Mur de pierre", 30.0, 60.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(ParalyzeScroll), "Immuabilité", "Paralysie", 42, 72, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(EnergyFieldScroll), "Immuabilité", "Mur d'énergie", 54, 84, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(EtouffementScroll), "Immuabilité", "Étouffement", 66, 96, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(ParalyzeFieldScroll), "Immuabilité", "Mur de paralysie", 78, 108, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(LenteurScroll), "Immuabilité", "Lenteur", 90, 120, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);

            index = AddCraft(typeof(MindRotScroll), "Altération", "Pourriture", 30, 60, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(CurseWeaponScroll), "Altération", "Arme maudite", 42, 72, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(BloodOathScroll), "Altération", "Pacte de sang", 54, 84, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(EvilOmenScroll), "Altération", "Présage maléfique", 66, 96, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(PainSpikeScroll), "Altération", "Douleur", 78, 108, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(StrangleScroll), "Altération", "Étranglement", 90, 120, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);

            index = AddCraft(typeof(StrengthScroll), "Providence", "Force", 30, 60, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(AgilityScroll), "Providence", "Agilité", 30, 60, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(CunningScroll), "Providence", "Astuce", 30, 60, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(PeauDePierreScroll), "Providence", "Peau de pierre", 42, 72, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(ChampEntropiqueScroll), "Providence", "Champ entropique", 42, 72, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(SacrificeScroll), "Providence", "Sacrifice", 54, 84, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(BlessScroll), "Providence", "Bénédiction", 66, 96, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(ReactiveArmorScroll), "Providence", "Armure de mage", 78, 108, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(MagicReflectScroll), "Providence", "Reflet", 90, 120, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);

            index = AddCraft(typeof(HealScroll), "Thaumaturgie", "Soins", 30, 60, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(CureScroll), "Thaumaturgie", "Antidote", 42, 72, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(GreaterHealScroll), "Thaumaturgie", "Soins majeurs", 54, 84, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(TotemGuerisonScroll), "Thaumaturgie", "Totem de guérison", 66, 96, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(DernierSouffleScroll), "Thaumaturgie", "Dernier souffle", 78, 108, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(AdrenalineScroll), "Thaumaturgie", "Adrénaline", 90, 120, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);

            index = AddCraft(typeof(WeakenScroll), "Ensorcellement", "Faiblesse", 30,  60, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(ClumsyScroll), "Ensorcellement", "Maladresse", 30, 60, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(FeeblemindScroll), "Ensorcellement", "Abrutissement", 30, 60, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(HarmScroll), "Ensorcellement", "Blessure", 42, 72, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(ManaDrainScroll), "Ensorcellement", "Drain de mana", 54, 84, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(CurseScroll), "Ensorcellement", "Malédiction", 66, 96, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(AffaiblissementScroll), "Ensorcellement", "Affaiblissement", 78, 108, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            index = AddCraft(typeof(ManaVampireScroll), "Ensorcellement", "Drain vampirique", 90, 120, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);

            //index = AddCraft(typeof(MagicArrowScroll), "Évocation", "Flêche Magique", 30.0, 60.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);

            //index = AddCraft(typeof(MagicLockScroll), "Adjuration", "Fermeture Magique", 25.0, 55.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(MagicTrapScroll), "Adjuration", "Piège Magique", 25.0, 55.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(UnlockScroll), "Adjuration", "Ouverture Magique", 30.0, 60.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(MagicUnTrapScroll), "Adjuration", "Suppression Magique", 30.0, 60.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(HarmScroll), "Adjuration", "Nuisance", 35.0, 65.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(DispelFieldScroll), "Adjuration", "Champ de Dissipation", 40.0, 70.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(DispelScroll), "Adjuration", "Dissipation", 45.0, 75.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(ManaDrainScroll), "Adjuration", "Drain de Mana", 50.0, 80.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(PoisonScroll), "Adjuration", "Poison", 55.0, 85.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(MassDispelScroll), "Adjuration", "Dissipation de Masse", 60.0, 90.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(ManaVampireScroll), "Adjuration", "Drain Vampirique", 65.0, 95.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(PoisonFieldScroll), "Adjuration", "Mur de Poison", 70.0, 100.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);

            //index = AddCraft(typeof(WeakenScroll), "Altération", "Faiblesse", 25.0, 55.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(ClumsyScroll), "Altération", "Maladroit", 30.0, 60.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(FeeblemindScroll), "Altération", "Débilité", 35.0, 65.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(TelekinisisScroll), "Altération", "Télékinésis", 40.0, 70.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(MagicReflectScroll), "Altération", "Reflet", 45.0, 75.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(CurseScroll), "Altération", "Malédiction", 60.0, 90.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(ParalyzeScroll), "Altération", "Paralysie", 70.0, 100.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(MassCurseScroll), "Altération", "Fléau", 75.0, 105.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(ParalyzeFieldScroll), "Altération", "Pétrification", 80.0, 110.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);

            //index = AddCraft(typeof(BourrasqueScroll), "Évocation", "Bourrasque", 25.0, 55.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(FlamecheScroll), "Évocation", "Flamèche", 25.0, 55.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(FroidScroll), "Évocation", "Froid", 25.0, 55.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(TempeteScroll), "Évocation", "Tempête", 25.0, 55.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(FireballScroll), "Évocation", "Boule de Feu", 30.0, 60.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(FireFieldScroll), "Évocation", "Mur de Feu", 35.0, 65.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(EnergyBoltScroll), "Évocation", "Énergie", 40.0, 70.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(LightningScroll), "Évocation", "Éclair", 45.0, 75.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(ExplosionScroll), "Évocation", "Explosion", 50.0, 80.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(EnergyFieldScroll), "Évocation", "Énergie de Masse", 55.0, 85.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(FlamestrikeScroll), "Évocation", "Jet de Flamme", 60.0, 90.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(MeteorSwarmScroll), "Évocation", "Météores", 65.0, 95.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(EarthquakeScroll), "Évocation", "Tremblement", 70.0, 100.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(EnergyVortexScroll), "Évocation", "Vortex", 75.0, 105.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(ChainLightningScroll), "Évocation", "Chaine d'Éclairs", 80.0, 110.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);

            //index = AddCraft(typeof(VoileScroll), "Illusion", "Voile", 25.0, 55.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(NightSightScroll), "Illusion", "Vision Nocturne", 25.0, 55.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(TeleportScroll), "Illusion", "Téléportation", 35.0, 65.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(IncognitoScroll), "Illusion", "Incognito", 40.0, 70.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(RecallScroll), "Illusion", "Rappel", 45.0, 75.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(MindBlastScroll), "Illusion", "Lobotomie", 50.0, 80.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(MarkScroll), "Illusion", "Marque", 55.0, 85.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(PolymorphScroll), "Illusion", "Polymorph", 60.0, 90.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(RevealScroll), "Illusion", "Révélation", 65.0, 95.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(InvisibilityScroll), "Illusion", "Invisibilité", 70.0, 100.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(GateTravelScroll), "Illusion", "Voyagement", 80.0, 110.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);

            //index = AddCraft(typeof(CreateFoodScroll), "Invocation", "Nourriture", 25.0, 55.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(MagicArrowScroll), "Invocation", "Flèche Magique", 30.0, 60.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(WallOfStoneScroll), "Invocation", "Mur de Pierre", 35.0, 65.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(SummonCreatureScroll), "Invocation", "Convocation", 40.0, 70.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(SummonEarthElementalScroll), "Invocation", "Élémental de Terre", 45.0, 75.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(BladeSpiritsScroll), "Invocation", "Esprit de Lames", 50.0, 80.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(SummonAirElementalScroll), "Invocation", "Élémental d'Air", 55.0, 85.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(SummonFireElementalScroll), "Invocation", "Élémental de Feu", 65.0, 95.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(SummonWaterElementalScroll), "Invocation", "Élémental d'Eau", 70.0, 100.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(SummonDaemonScroll), "Invocation", "Conjuration", 80.0, 110.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);

            //index = AddCraft(typeof(StrengthScroll), "Thaumaturgie", "Force", 25.0, 55.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(AgilityScroll), "Thaumaturgie", "Agilité", 30.0, 60.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(CunningScroll), "Thaumaturgie", "Ruse", 35.0, 65.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(ReactiveArmorScroll), "Thaumaturgie", "Armure Magique", 40.0, 70.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(ProtectionScroll), "Thaumaturgie", "Protection", 45.0, 75.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(CureScroll), "Thaumaturgie", "Antidote", 50.0, 80.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(HealScroll), "Thaumaturgie", "Soins", 55.0, 85.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(BlessScroll), "Thaumaturgie", "Puissance", 60.0, 90.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(ArchCureScroll), "Thaumaturgie", "Remède", 65.0, 95.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(ArchProtectionScroll), "Thaumaturgie", "Protection Magique", 70.0, 100.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(GreaterHealScroll), "Thaumaturgie", "Soins Magiques", 75.0, 105.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(ResurrectionScroll), "Thaumaturgie", "Résurrection", 80.0, 110.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);

            //index = AddCraft(typeof(WraithFormScroll), "Nécromancie", "Spectre", 25.0, 55.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(PainSpikeScroll), "Nécromancie", "Corruption", 30.0, 60.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(EvilOmenScroll), "Nécromancie", "Sermant", 30.0, 60.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(CorpseSkinScroll), "Nécromancie", "Corps Mortifié", 35.0, 65.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(SummonFamiliarScroll), "Nécromancie", "Minion", 40.0, 70.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(MindRotScroll), "Nécromancie", "Pourriture", 45.0, 75.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(HorrificBeastScroll), "Nécromancie", "Bête Horrifique", 45.0, 75.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(PoisonStrikeScroll), "Nécromancie", "Venin", 50.0, 80.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(StrangleScroll), "Nécromancie", "Étranglement", 60.0, 90.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(LichFormScroll), "Nécromancie", "Liche", 65.0, 95.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(WitherScroll), "Nécromancie", "Flétrir", 65.0, 95.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(BloodOathScroll), "Nécromancie", "Présage", 70.0, 100.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(CurseWeaponScroll), "Nécromancie", "Maudire", 70.0, 100.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(VengefulSpiritScroll), "Nécromancie", "Esprit Vengeur", 75.0, 105.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(AnimateDeadScroll), "Nécromancie", "Animation des Morts", 80.0, 110.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
            //index = AddCraft(typeof(VampiricEmbraceScroll), "Nécromancie", "Vampirisime", 80.0, 110.0, typeof(BlankScroll), "Parchemin Vierge", 1, 1044361);
      
			MarkOption = true;
		}
	}
}