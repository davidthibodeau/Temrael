using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefBowFletching : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Menuiserie; }
		}

		public override int GumpTitleNumber
		{
			get { return 1044006; } // <CENTER>BOWCRAFT AND FLETCHING MENU</CENTER>
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefBowFletching();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.5; // 50%
		}

		private DefBowFletching() : base( 1, 1, 1.25 )// base( 1, 2, 1.7 )
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
			//	from.Animate( 33, 5, 1, true, false, 0 );

			from.PlaySound( 0x55 );
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

		public override CraftECA ECA{ get{ return CraftECA.FiftyPercentChanceMinusTenPercent; } }

		public override void InitCraftList()
		{
			int index = -1;

            #region Materials
            /*index = AddCraft(typeof(Board), "Matériaux", "Planche", 0.0, 0.0, typeof(Log), 1044466, 1, 1044465);
            SetUseAllRes(index, true);*/

            //AddCraft(typeof(Kindling), "Matériaux", "Branchette", 0.0, 00.0, typeof(Log), 1044041, 1, 1044351);

            index = AddCraft(typeof(Shaft), "Matériaux", "Manche", 0.0, 5.0, typeof(Kindling), "Brindille", 1, 1044351);
            SetUseAllRes(index, true);
            #endregion

            #region Ammunition
            // Ammunition
            index = AddCraft(typeof(Arrow), "Munitions", "Flèche", 0.0, 10.0, typeof(Shaft), "Manche", 1, 1044561);
			AddRes( index, typeof( Feather ), "Plume", 1, 1044563 );
			SetUseAllRes( index, true );

            index = AddCraft(typeof(Bolt), "Munitions", "Courte Flèche", 0.0, 10.0, typeof(Shaft), "Manche", 1, 1044561);
			AddRes( index, typeof( Feather ), "Plume", 1, 1044563 );
			SetUseAllRes( index, true );
            #endregion

            #region Bows
            index = AddCraft(typeof(Arc), "Arc", "Arc", 10.0, 40.0, typeof(Log), 1044041, 6, 1044351);
            index = AddCraft(typeof(Tarkarc), "Arc", "Tarkarc", 20.0, 50.0, typeof(Log), 1044041, 5, 1044351);
            index = AddCraft(typeof(Legarc), "Arc", "Legarc", 20.0, 50.0, typeof(Log), 1044041, 7, 1044351);
            index = AddCraft(typeof(GrandArc), "Arc", "Arc Long", 30.0, 60.0, typeof(Log), 1044041, 10, 1044351);
            index = AddCraft(typeof(Blancorde), "Arc", "Blancorde", 30.0, 60.0, typeof(Log), 1044041, 10, 1044351);
            index = AddCraft(typeof(Glaciale), "Arc", "Glaciale", 30.0, 60.0, typeof(Log), 1044041, 10, 1044351);
            index = AddCraft(typeof(Souplecorde), "Arc", "Souplecorde", 40.0, 70.0, typeof(Log), 1044041, 8, 1044351);
            index = AddCraft(typeof(Barbatrine), "Arc", "Barbatrine", 40.0, 70.0, typeof(Log), 1044041, 8, 1044351);
            index = AddCraft(typeof(Ebonie), "Arc", "Ebonie", 40.0, 70.0, typeof(Log), 1044041, 8, 1044351);
            index = AddCraft(typeof(Mirielle), "Arc", "Mirielle", 40.0, 70.0, typeof(Log), 1044041, 8, 1044351);
            index = AddCraft(typeof(Composite), "Arc", "Composite", 50.0, 80.0, typeof(Log), 1044041, 8, 1044351);
            index = AddCraft(typeof(Sombrevent), "Arc", "Sombrevent", 50.0, 80.0, typeof(Log), 1044041, 8, 1044351);
            index = AddCraft(typeof(Flamfleche), "Arc", "Flamflèche", 50.0, 80.0, typeof(Log), 1044041, 8, 1044351);
            index = AddCraft(typeof(Foudre), "Arc", "Foudre", 60.0, 90.0, typeof(Log), 1044041, 8, 1044351);
            index = AddCraft(typeof(Sifflecrin), "Arc", "Sifflecrin", 60.0, 90.0, typeof(Log), 1044041, 8, 1044351);
            index = AddCraft(typeof(Foliere), "Arc", "Foliere", 60.0, 90.0, typeof(Log), 1044041, 8, 1044351);
            index = AddCraft(typeof(Pieuse), "Arc", "Pieuse", 60.0, 90.0, typeof(Log), 1044041, 8, 1044351);
            index = AddCraft(typeof(Chantefleche), "Arc", "Chantefleche", 70.0, 100.0, typeof(Log), 1044041, 8, 1044351);
            index = AddCraft(typeof(Vigne), "Arc", "Vigne", 70.0, 100.0, typeof(Log), 1044041, 8, 1044351);
            index = AddCraft(typeof(Maegie), "Arc", "Maegie", 70.0, 100.0, typeof(Log), 1044041, 8, 1044351);
            #endregion

            #region Crossbow
            index = AddCraft(typeof(Arbalete), "Arbalète", "Arbalète", 10.0, 40.0, typeof(Log), 1044041, 6, 1044351);
            index = AddCraft(typeof(ArbaleteLourde), "Arbalète", "Arbalète Lourde", 20.0, 50.0, typeof(Log), 1044041, 8, 1044351);
            index = AddCraft(typeof(Crossbow), "Arbalète", "Arbalète à Méchanisme", 30.0, 60.0, typeof(Log), 1044041, 7, 1044351);
            index = AddCraft(typeof(HeavyCrossbow), "Arbalète", "Arbalète Décoré", 30.0, 60.0, typeof(Log), 1044041, 8, 1044351);
            index = AddCraft(typeof(ArbaleteRepetition), "Arbalète", "Arbalète à Répétition", 40.0, 70.0, typeof(Log), 1044041, 8, 1044351);
            index = AddCraft(typeof(Percemurs), "Arbalète", "Percemurs", 50.0, 80.0, typeof(Log), 1044041, 6, 1044351);
            index = AddCraft(typeof(ArbaletePistolet), "Arbalète", "Arbalète à Main", 60.0, 90.0, typeof(Log), 1044041, 7, 1044351);
            index = AddCraft(typeof(Arbavive), "Arbalète", "Arbavive", 60.0, 90.0, typeof(Log), 1044041, 8, 1044351);
            index = AddCraft(typeof(Lumitrait), "Arbalète", "Lumitrait", 70.0, 100.0, typeof(Log), 1044041, 7, 1044351);
            #endregion

            #region Weapons
            // Weapons

            /*if ( Core.AOS )
            {
                AddCraft( typeof( CompositeBow ), 1044566, 1029922, 70.0, 110.0, typeof( Log ), 1044041, 7, 1044351 );
                AddCraft( typeof( RepeatingCrossbow ), 1044566, 1029923, 90.0, 130.0, typeof( Log ), 1044041, 10, 1044351 );
            }

            if( Core.SE )
            {
                index = AddCraft( typeof( Yumi ), 1044566, 1030224, 90.0, 130.0, typeof( Log ), 1044041, 10, 1044351 );
                SetNeededExpansion( index, Expansion.SE );
            }*/
            #endregion

            SetSubRes(typeof(Log), "Érable");

            // Add every material you want the player to be able to choose from
            // This will override the overridable material	TODO: Verify the required skill amount
            AddSubRes(typeof(Log), "Érable", Log.SkillReq, 1072652);
            AddSubRes(typeof(PinLog), "Pin", PinLog.SkillReq, 1072652);
            AddSubRes(typeof(CypresLog), "Cyprès", CypresLog.SkillReq, 1072652);
            AddSubRes(typeof(CedreLog), "Cèdre", CedreLog.SkillReq, 1072652);
            AddSubRes(typeof(SauleLog), "Saule", SauleLog.SkillReq, 1072652);
            AddSubRes(typeof(CheneLog), "Chêne", CheneLog.SkillReq, 1072652);
            AddSubRes(typeof(EbeneLog), "Ébène", EbeneLog.SkillReq, 1072652);
            AddSubRes(typeof(AcajouLog), "Acajou", AcajouLog.SkillReq, 1072652);

            MarkOption = true;
			Repair = Core.AOS;
		}
	}
}