using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefBlacksmithy : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Forge;	}
		}

		/*public override int GumpTitleNumber
		{
			get { return 1044002; } // <CENTER>BLACKSMITHY MENU</CENTER>
		}*/

        public override string GumpTitleString
        {
            get { return "Menu de Forge"; }
        }

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefBlacksmithy();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefBlacksmithy() : base( 1, 1, 1.25 )// base( 1, 2, 1.7 )
		{
			/*
			
			base( MinCraftEffect, MaxCraftEffect, Delay )
			
			MinCraftEffect	: The minimum number of time the mobile will play the craft effect
			MaxCraftEffect	: The maximum number of time the mobile will play the craft effect
			Delay			: The delay between each craft effect
			
			Example: (3, 6, 1.7) would make the mobile do the PlayCraftEffect override
			function between 3 and 6 time, with a 1.7 second delay each time.
			
			*/ 
		}

		private static Type typeofAnvil = typeof( AnvilAttribute );
		private static Type typeofForge = typeof( ForgeAttribute );

		public static void CheckAnvilAndForge( Mobile from, int range, out bool anvil, out bool forge )
		{
			anvil = false;
			forge = false;

			Map map = from.Map;

			if ( map == null )
				return;

			IPooledEnumerable eable = map.GetItemsInRange( from.Location, range );

			foreach ( Item item in eable )
			{
				Type type = item.GetType();

				bool isAnvil = ( type.IsDefined( typeofAnvil, false ) || item.ItemID == 4015 || item.ItemID == 4016 || item.ItemID == 0x2DD5 || item.ItemID == 0x2DD6 );
				bool isForge = ( type.IsDefined( typeofForge, false ) || item.ItemID == 4017 || (item.ItemID >= 6522 && item.ItemID <= 6569) || item.ItemID == 0x2DD8 );

				if ( isAnvil || isForge )
				{
					if ( (from.Z + 16) < item.Z || (item.Z + 16) < from.Z || !from.InLOS( item ) )
						continue;

					anvil = anvil || isAnvil;
					forge = forge || isForge;

					if ( anvil && forge )
						break;
				}
			}

			eable.Free();

			for ( int x = -range; (!anvil || !forge) && x <= range; ++x )
			{
				for ( int y = -range; (!anvil || !forge) && y <= range; ++y )
				{
					StaticTile[] tiles = map.Tiles.GetStaticTiles( from.X+x, from.Y+y, true );

					for ( int i = 0; (!anvil || !forge) && i < tiles.Length; ++i )
					{
						int id = tiles[i].ID;

						bool isAnvil = ( id == 4015 || id == 4016 || id == 0x2DD5 || id == 0x2DD6 );
						bool isForge = ( id == 4017 || (id >= 6522 && id <= 6569) || id == 0x2DD8 );

						if ( isAnvil || isForge )
						{
							if ( (from.Z + 16) < tiles[i].Z || (tiles[i].Z + 16) < from.Z || !from.InLOS( new Point3D( from.X+x, from.Y+y, tiles[i].Z + (tiles[i].Height/2) + 1 ) ) )
								continue;

							anvil = anvil || isAnvil;
							forge = forge || isForge;
						}
					}
				}
			}
		}

		public override int CanCraft( Mobile from, BaseTool tool, Type itemType )
		{
			if ( tool == null || tool.Deleted || tool.UsesRemaining < 0 )
				return 1044038; // You have worn out your tool!
			else if ( !BaseTool.CheckTool( tool, from ) )
				return 1048146; // If you have a tool equipped, you must use that tool.
			else if ( !BaseTool.CheckAccessible( tool, from ) )
				return 1044263; // The tool must be on your person to use.

			bool anvil, forge;
			CheckAnvilAndForge( from, 2, out anvil, out forge );

			if ( anvil && forge )
				return 0;

			return 1044267; // You must be near an anvil and a forge to smith items.
		}

		public override void PlayCraftEffect( Mobile from )
		{
			// no animation, instant sound
			if ( from.Body.Type == BodyType.Human && !from.Mounted )
				from.Animate( 9, 5, 1, true, false, 0 );
			new InternalTimer( from ).Start();

			//from.PlaySound( 0x2A );
		}

		// Delay to synchronize the sound with the hit on the anvil
		private class InternalTimer : Timer
		{
			private Mobile m_From;

			public InternalTimer( Mobile from ) : base( TimeSpan.FromSeconds( 0.7 ) )
			{
				m_From = from;
			}

			protected override void OnTick()
			{
				m_From.PlaySound( 0x2A );
			}
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
			/*
			Synthax for a SIMPLE craft item
			AddCraft( ObjectType, Group, MinSkill, MaxSkill, ResourceType, Amount, Message )
			
			ObjectType		: The type of the object you want to add to the build list.
			Group			: The group in wich the object will be showed in the craft menu.
			MinSkill		: The minimum of skill value
			MaxSkill		: The maximum of skill value
			ResourceType	: The type of the resource the mobile need to create the item
			Amount			: The amount of the ResourceType it need to create the item
			Message			: String or Int for Localized.  The message that will be sent to the mobile, if the specified resource is missing.
			
			Synthax for a COMPLEXE craft item.  A complexe item is an item that need either more than
			only one skill, or more than only one resource.
			
			Coming soon....
			*/

            int index = 0;

			#region Ringmail
            index = AddCraft(typeof(RingmailGloves), "Anneaux", "Gants d'Anneaux", 15.0, 45.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(RingmailLegs), "Anneaux", "Jambieres d'Anneaux", 15.0, 45.0, typeof(FerIngot), "Lingots", 16, 1044037);
            index = AddCraft(typeof(RingmailArms), "Anneaux", "Brassards d'Anneaux", 15.0, 45.0, typeof(FerIngot), "Lingots", 14, 1044037);
            index = AddCraft(typeof(RingmailChest), "Anneaux", "Cuirasse d'Anneaux", 15.0, 45.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(Bascinet), "Anneaux", "Bascinet", 15.0, 45.0, typeof(FerIngot), "Lingots", 15, 1044037);
            index = AddCraft(typeof(Helmet), "Anneaux", "Casque", 15.0, 45.0, typeof(FerIngot), "Lingots", 15, 1044037);
            #endregion

            #region Drow
            index = AddCraft(typeof(DrowHelm), "Anneaux", "Courrone d'Alfar", 20.0, 50.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(DrowGorget), "Anneaux", "Gorget d'Aflar", 20.0, 50.0, typeof(FerIngot), "Lingots", 16, 1044037);
            index = AddCraft(typeof(DrowArms), "Anneaux", "Brassards d'Alfar", 20.0, 50.0, typeof(FerIngot), "Lingots", 14, 1044037);
            index = AddCraft(typeof(DrowLeggings), "Anneaux", "Jambières d'Alfar", 20.0, 50.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(DrowTunic), "Anneaux", "Tunique d'Alfar", 20.0, 50.0, typeof(FerIngot), "Lingots", 15, 1044037);
            #endregion
            /*
            #region Scalemail
            index = AddCraft(typeof(ScalemailArms), "Anneaux", "Brassards d'Anneaux d'Écailles", 20.0, 50.0, typeof(FerIngot), "Lingots", 15, 1044037);
            index = AddCraft(typeof(ScalemailLeggings), "Anneaux", "Jambieres d'Anneaux d'Écailles", 20.0, 50.0, typeof(FerIngot), "Lingots", 15, 1044037);
            index = AddCraft(typeof(ScalemailTunic), "Anneaux", "Tunique d'Anneaux d'Écailles", 20.0, 50.0, typeof(FerIngot), "Lingots", 15, 1044037);

            #endregion*/

            #region Bourgeon
            index = AddCraft(typeof(BourgeonLeggings), "Anneaux", "Jambieres", 20.0, 50.0, typeof(FerIngot), "Lingots", 16, 1044037);
            index = AddCraft(typeof(BourgeonGreaves), "Anneaux", "Brassards", 20.0, 50.0, typeof(FerIngot), "Lingots", 14, 1044037);
            index = AddCraft(typeof(BourgeonTunic), "Anneaux", "Cuirasse", 20.0, 50.0, typeof(FerIngot), "Lingots", 18, 1044037);
            #endregion

            #region Maillons
            index = AddCraft(typeof(MaillonsLeggings), "Anneaux", "Jambieres de Maillons", 25.0, 55.0, typeof(FerIngot), "Lingots", 16, 1044037);
            index = AddCraft(typeof(MaillonsGreaves), "Anneaux", "Brassards de Maillons", 25.0, 55.0, typeof(FerIngot), "Lingots", 14, 1044037);
            index = AddCraft(typeof(MaillonsTunic), "Anneaux", "Cuirasse de Maillons", 25.0, 55.0, typeof(FerIngot), "Lingots", 18, 1044037);
            #endregion

            #region Maillures
            index = AddCraft(typeof(MailluresLeggings), "Chaines", "Jambieres de Maillures", 25.0, 55.0, typeof(FerIngot), "Lingots", 16, 1044037);
            index = AddCraft(typeof(MailluresGreaves), "Chaines", "Brassards de Maillures", 25.0, 55.0, typeof(FerIngot), "Lingots", 14, 1044037);
            index = AddCraft(typeof(MailluresTunic), "Chaines", "Cuirasse de Maillures", 25.0, 55.0, typeof(FerIngot), "Lingots", 18, 1044037);
            #endregion

            #region Chainmail
            index = AddCraft( typeof( ChainCoif ), "Chaines", "Casque de Chaines", 30.0, 60.0, typeof( FerIngot ), "Lingots", 10, 1044037 );
            index = AddCraft(typeof(ChainLegs), "Chaines", "Jambieres de Chaines", 30.0, 60.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(ChainChest), "Chaines", "Cuirasse de Chaines", 30.0, 60.0, typeof(FerIngot), "Lingots", 20, 1044037);
			#endregion

            #region Chaine Elfique
            index = AddCraft(typeof(ElfiqueChaineLeggings), "Chaines", "Jambieres Elfiques", 35.0, 65.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(ElfiqueChaineTunic), "Chaines", "Cuirasse Elfiques", 35.0, 65.0, typeof(FerIngot), "Lingots", 20, 1044037);
            #endregion

            #region Mailles
            index = AddCraft(typeof(MaillesHelm), "Chaines", "Casque de Mailles", 35.0, 65.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(MaillesLeggings), "Chaines", "Jambieres de Mailles", 35.0, 65.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(MaillesTunic), "Chaines", "Cuirasse de Mailles", 35.0, 65.0, typeof(FerIngot), "Lingots", 20, 1044037);
            #endregion

            #region Platemail
            index = AddCraft(typeof(PlateArms), "Plaques", "Brassards de Plaque", 40.0, 70.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(PlateGloves), "Plaques", "Gants de Plaque", 40.0, 70.0, typeof(FerIngot), "Lingots", 12, 1044037);
            index = AddCraft(typeof(PlateGorget), "Plaques", "Gorget de Plaque", 40.0, 70.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(PlateLegs), "Plaques", "Jambieres de Plaque", 40.0, 70.0, typeof(FerIngot), "Lingots", 20, 1044037);
            index = AddCraft(typeof(PlateChest), "Plaques", "Cuirasse de Plaque", 40.0, 70.0, typeof(FerIngot), "Lingots", 25, 1044037);
            index = AddCraft(typeof(FemalePlateChest), "Plaques", "Cuirasse Féminine", 40.0, 70.0, typeof(FerIngot), "Lingots", 20, 1044037);
            index = AddCraft(typeof(PlateHelm), "Plaques", "Casque de Plaque", 40.0, 70.0, typeof(FerIngot), "Lingots", 15, 1044037);
            index = AddCraft(typeof(CloseHelm), "Plaques", "Casque Clos", 40.0, 70.0, typeof(FerIngot), "Lingots", 15, 1044037);

			#endregion

            #region Plaque Elfique
            index = AddCraft(typeof(ElfiquePlaqueGorget), "Plaques", "Gorget de Plaque Elfique", 45.0, 75.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(ElfiquePlaqueLeggings), "Plaques", "Jambieres de Plaque Elfique", 45.0, 75.0, typeof(FerIngot), "Lingots", 20, 1044037);
            index = AddCraft(typeof(ElfiquePlaqueTunic), "Plaques", "Cuirasse de Plaque Elfique", 45.0, 75.0, typeof(FerIngot), "Lingots", 25, 1044037);
            #endregion

            #region Plaque Gothique
            index = AddCraft(typeof(BrassardsGothique), "Plaques", "Brassards de Plaque Gothique", 50.0, 80.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(CuirasseGothique), "Plaques", "Cuirasse de Plaque Gothique", 50.0, 80.0, typeof(FerIngot), "Lingots", 25, 1044037);
            index = AddCraft(typeof(CasqueGothique), "Plaques", "Casque à Cornes Gothique", 50.0, 80.0, typeof(FerIngot), "Lingots", 15, 1044037);
            #endregion

            #region Plaque Barbare
            index = AddCraft(typeof(PlaqueBarbareGreaves), "Plaques", "Brassards de Plaque Barbare", 50.0, 80.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(PlaqueBarbareGorget), "Plaques", "Gorget de Plaque Barbare", 50.0, 80.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(PlaqueBarbareLeggings), "Plaques", "Jambieres de Plaque Barbare", 50.0, 80.0, typeof(FerIngot), "Lingots", 20, 1044037);
            index = AddCraft(typeof(PlaqueBarbareTunic), "Plaques", "Cuirasse de Plaque Barbare", 50.0, 80.0, typeof(FerIngot), "Lingots", 25, 1044037);
            #endregion

            #region Plaque Orne
            index = AddCraft(typeof(BrassardsOrne), "Plaques Lourdes", "Brassards de Plaque Orné", 60.0, 90.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(CuirasseOrne), "Plaques Lourdes", "Cuirasse de Plaque Orné", 60.0, 90.0, typeof(FerIngot), "Lingots", 25, 1044037);
            #endregion

            #region Plaque Decorer
            index = AddCraft(typeof(BrassardsDecorer), "Plaques Lourdes", "Brassards de Plaque Décoré", 65.0, 95.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(GantsDecorer), "Plaques Lourdes", "Gants de Plaque Décoré", 65.0, 95.0, typeof(FerIngot), "Lingots", 12, 1044037);
            index = AddCraft(typeof(GorgetDecorer), "Plaques Lourdes", "Gorget de Plaque Décoré", 65.0, 95.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(JambieresDecorer), "Plaques Lourdes", "Jambieres de Plaque Décoré", 65.0, 95.0, typeof(FerIngot), "Lingots", 20, 1044037);
            index = AddCraft(typeof(CuirasseDecorer), "Plaques Lourdes", "Cuirasse de Plaque Décoré", 65.0, 95.0, typeof(FerIngot), "Lingots", 25, 1044037);
            index = AddCraft(typeof(CasqueDecorer), "Plaques Lourdes", "Casque de Plaque Décoré", 65.0, 95.0, typeof(FerIngot), "Lingots", 15, 1044037);
            index = AddCraft(typeof(CasqueClosDecorer), "Plaques Lourdes", "Casque Clos Décoré", 65.0, 95.0, typeof(FerIngot), "Lingots", 15, 1044037);
            #endregion

            #region Plaque Noble
            index = AddCraft(typeof(PlaqueChevalierGreaves), "Plaques Lourdes", "Brassards de Plaque Royal", 70.0, 100.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(PlaqueChevalierGloves), "Plaques Lourdes", "Gants de Plaque Royal", 70.0, 100.0, typeof(FerIngot), "Lingots", 12, 1044037);
            index = AddCraft(typeof(PlaqueChevalierGorget), "Plaques Lourdes", "Gorget de Plaque Royal", 70.0, 100.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(PlaqueChevalierLeggings), "Plaques Lourdes", "Jambieres de Plaque Royal", 70.0, 100.0, typeof(FerIngot), "Lingots", 20, 1044037);
            index = AddCraft(typeof(PlaqueChevalierTunic), "Plaques Lourdes", "Cuirasse de Plaque Royal", 70.0, 100.0, typeof(FerIngot), "Lingots", 25, 1044037);
            index = AddCraft(typeof(PlaqueChevalierHelm), "Plaques Lourdes", "Casque de Plaque Royal", 70.0, 100.0, typeof(FerIngot), "Lingots", 15, 1044037);
            #endregion

            #region Plaque Daedric
            index = AddCraft(typeof(ArmureDaedricGreaves), "Plaques Lourdes", "Brassards de Plaque Daedric", 70.0, 100.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(ArmureDaedricGloves), "Plaques Lourdes", "Gants de Plaque Daedric", 70.0, 100.0, typeof(FerIngot), "Lingots", 12, 1044037);
            index = AddCraft(typeof(ArmureDaedricGorget), "Plaques Lourdes", "Gorget de Plaque Daedric", 70.0, 100.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(ArmureDaedricLeggings), "Plaques Lourdes", "Jambieres de Plaque Daedric", 70.0, 100.0, typeof(FerIngot), "Lingots", 20, 1044037);
            index = AddCraft(typeof(ArmureDaedricTunic), "Plaques Lourdes", "Cuirasse de Plaque Daedric", 70.0, 100.0, typeof(FerIngot), "Lingots", 25, 1044037);
            index = AddCraft(typeof(ArmureDaedricHelm), "Plaques Lourdes", "Casque de Plaque Daedric", 70.0, 100.0, typeof(FerIngot), "Lingots", 15, 1044037);
            #endregion

            #region Armure Barbare
            index = AddCraft(typeof(LeggingsBarbare), "Armure Diverses", "Jambieres de Plaque Barbare", 30.0, 50.0, typeof(FerIngot), "Lingots", 20, 1044037);
            index = AddCraft(typeof(TunicBarbare), "Armure Diverses", "Cuirasse de Plaque Barbare", 30.0, 50.0, typeof(FerIngot), "Lingots", 25, 1044037);
            #endregion

            #region Armures Diverses
            index = AddCraft(typeof(TuniqueChaine), "Armure Diverses", "Bourgeon de Chaines", 20.0, 40.0, typeof(FerIngot), "Lingots", 25, 1044037);
            index = AddCraft(typeof(CuirasseReligieuse), "Armure Diverses", "Cuirasse de Templier", 50.0, 80.0, typeof(FerIngot), "Lingots", 25, 1044037);
            index = AddCraft(typeof(Cuirasse), "Armure Diverses", "Cuirasse", 60.0, 90.0, typeof(FerIngot), "Lingots", 25, 1044037);
            index = AddCraft(typeof(CuirasseBarbare), "Armure Diverses", "Cuirasse Ancienne", 50.0, 80.0, typeof(FerIngot), "Lingots", 25, 1044037);
            index = AddCraft(typeof(CuirasseNordique), "Armure Diverses", "Cuirasse Nordique", 60.0, 90.0, typeof(FerIngot), "Lingots", 25, 1044037);
            index = AddCraft(typeof(CuirasseDraconique), "Armure Diverses", "Cuirasse Draconique", 70.0, 100.0, typeof(FerIngot), "Lingots", 25, 1044037);
            index = AddCraft(typeof(CasqueNordique), "Armure Diverses", "Casque Nordique", 60.0, 90.0, typeof(FerIngot), "Lingots", 15, 1044037);
            index = AddCraft(typeof(CasqueSudiste), "Armure Diverses", "Casque Nomade", 60.0, 90.0, typeof(FerIngot), "Lingots", 15, 1044037);
            index = AddCraft(typeof(CasqueCorne), "Armure Diverses", "Casque à Cornes", 70.0, 100.0, typeof(FerIngot), "Lingots", 15, 1044037);
            index = AddCraft(typeof(Brassards), "Armure Diverses", "Brassards", 60.0, 90.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(BrassardsChaotique), "Armure Diverses", "Brassards Chaotique", 70.0, 100.0, typeof(FerIngot), "Lingots", 18, 1044037);
            #endregion

			#region Shields
            index = AddCraft(typeof(Buckler), "Boucliers", "Bouclet", 10.0, 30.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(BronzeShield), "Boucliers", "Bouclier Orné", 20.0, 40.0, typeof(FerIngot), "Lingots", 12, 1044037);
            index = AddCraft(typeof(MetalShield), "Boucliers", "Bouclier", 30.0, 60.0, typeof(FerIngot), "Lingots", 14, 1044037);
            index = AddCraft(typeof(ChaosShield), "Boucliers", "Bouclier du Chaos", 40.0, 70.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(OrderShield), "Boucliers", "Bouclier d'Ordre", 50.0, 80.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(WoodenKiteShield), "Boucliers", "Bouclier de Bois", 40.0, 70.0, typeof(FerIngot), "Lingots", 8, 1044037);
            index = AddCraft(typeof(BouclierGarde), "Boucliers", "Bouclier Métallique", 50.0, 80.0, typeof(FerIngot), "Lingots", 16, 1044037);
            index = AddCraft(typeof(MetalKiteShield), "Boucliers", "Bouclier Croisé", 50.0, 80.0, typeof(FerIngot), "Lingots", 16, 1044037);
            index = AddCraft(typeof(BouclierComte), "Boucliers", "Bouclier de Karmilide", 50.0, 80.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(BouclierMarquis), "Boucliers", "Bouclier de Faréligue", 50.0, 80.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(BouclierDuc), "Boucliers", "Bouclier d'Horlé", 50.0, 80.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(BouclierNordique), "Boucliers", "Bouclier Nordique", 60.0, 90.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(BouclierElfique), "Boucliers", "Bouclier Elfique", 60.0, 90.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(BouclierChevaleresque), "Boucliers", "Bouclier Chevaleresque", 60.0, 90.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(BouclierVieux), "Boucliers", "Vieux Pavois", 70.0, 100.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(HeaterShield), "Boucliers", "Pavois", 70.0, 100.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(BouclierDecorer), "Boucliers", "Pavois Decoré", 70.0, 100.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(BouclierPavoisNoir), "Boucliers", "Pavois Royal", 70.0, 100.0, typeof(FerIngot), "Lingots", 18, 1044037);
			#endregion

			#region Épées

            //Épées Courtes

            index = AddCraft(typeof(Astoria), "Épées", "Astoria", 10.0, 40.0, typeof(FerIngot), "Lingots", 8, 1044037);
            index = AddCraft(typeof(Biliome), "Épées", "Biliome", 20.0, 50.0, typeof(FerIngot), "Lingots", 10, 1044037);
            //index = AddCraft(typeof(Runire), "Épées", "Runire", 30.0, 60.0, typeof(FerIngot), "Lingots", 8, 1044037);
            index = AddCraft(typeof(Myliron), "Épées", "Myliron", 40.0, 70.0, typeof(FerIngot), "Lingots", 8, 1044037);
            index = AddCraft(typeof(Vorlame), "Épées", "Vorlame", 50.0, 80.0, typeof(FerIngot), "Lingots", 10, 1044037);
            //index = AddCraft(typeof(Dawn), "Épées", "Dawn", 60.0, 90.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(Lerise), "Épées", "Lerise", 70.0, 100.0, typeof(FerIngot), "Lingots", 8, 1044037);
            index = AddCraft(typeof(Gerumir), "Épées", "Gerumir", 70.0, 100.0, typeof(FerIngot), "Lingots", 10, 1044037);

            //Épées Longues

            index = AddCraft(typeof(Rodere), "Épées", "Rodère", 30.0, 60.0, typeof(FerIngot), "Lingots", 10, 1044037);
            //index = AddCraft(typeof(Dravene), "Épées", "Dravène", 40.0, 70.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(Draglast), "Épées", "Draglast", 50.0, 80.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(Merlame), "Épées", "Merlarme", 50.0, 80.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(Narvegne), "Épées", "Narvègne", 60.0, 90.0, typeof(FerIngot), "Lingots", 12, 1044037);
            index = AddCraft(typeof(Hectmore), "Épées", "Hectmore", 70.0, 100.0, typeof(FerIngot), "Lingots", 10, 1044037);

            //Sabres

            index = AddCraft(typeof(Sabre), "Épées", "Sabre", 20.0, 50.0, typeof(FerIngot), "Lingots", 8, 1044037);
            index = AddCraft(typeof(Mersang), "Épées", "Mersang", 30.0, 60.0, typeof(FerIngot), "Lingots", 8, 1044037);
            index = AddCraft(typeof(Raghash), "Épées", "Raghash", 40.0, 70.0, typeof(FerIngot), "Lingots", 8, 1044037);
            index = AddCraft(typeof(Prisienne), "Épées", "Prisienne", 50.0, 80.0, typeof(FerIngot), "Lingots", 8, 1044037);
            //index = AddCraft(typeof(Coutelas), "Épées", "Coutelas", 60.0, 90.0, typeof(FerIngot), "Lingots", 8, 1044037);
            index = AddCraft(typeof(Scimitar), "Épées", "Scimitar", 70.0, 100.0, typeof(FerIngot), "Lingots", 10, 1044037);

            //Épées Lourdes

            index = AddCraft(typeof(Vifcoupe), "Épées", "Vifcoupe", 10.0, 40.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(Auderre), "Épées", "Audèrre", 10.0, 40.0, typeof(FerIngot), "Lingots", 10, 1044037);
            //index = AddCraft(typeof(Batarde), "Épées", "Batarde", 30.0, 60.0, typeof(FerIngot), "Lingots", 10, 1044037);
            //index = AddCraft(typeof(Tranchevil), "Épées", "Tranchevil", 30.0, 60.0, typeof(FerIngot), "Lingots", 10, 1044037);
            //index = AddCraft(typeof(Ventmore), "Épées", "Ventmore", 30.0, 60.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(Excalior), "Épées", "Excalior", 40.0, 70.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(Conquise), "Épées", "Conquise", 40.0, 70.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(Atargne), "Épées", "Atargne", 50.0, 80.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(Nerfille), "Épées", "Nerfille", 50.0, 80.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(Querquoise), "Épées", "Querquoise", 50.0, 80.0, typeof(FerIngot), "Lingots", 10, 1044037);
            //index = AddCraft(typeof(Nhilarte), "Épées", "Nhilarte", 50.0, 80.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(Abysse), "Épées", "Abysse", 60.0, 90.0, typeof(FerIngot), "Lingots", 12, 1044037);
            //index = AddCraft(typeof(Dorleane), "Épées", "Dorleane", 60.0, 90.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(Couliere), "Épées", "Coulière", 70.0, 100.0, typeof(FerIngot), "Lingots", 12, 1044037);

            //Claymore

            index = AddCraft(typeof(Rougegorge), "Épées", "Rougegorge", 20.0, 50.0, typeof(FerIngot), "Lingots", 14, 1044037);
            //index = AddCraft(typeof(Monarque), "Épées", "Monarque", 30.0, 60.0, typeof(FerIngot), "Lingots", 12, 1044037);
            //index = AddCraft(typeof(Claymore), "Épées", "Claymore", 30.0, 60.0, typeof(FerIngot), "Lingots", 14, 1044037);
            index = AddCraft(typeof(VikingSword), "Épées", "Épée Lourde", 40.0, 70.0, typeof(FerIngot), "Lingots", 15, 1044037);
            index = AddCraft(typeof(Courbelle), "Épées", "Courbelle", 40.0, 70.0, typeof(FerIngot), "Lingots", 16, 1044037);
            index = AddCraft(typeof(Tranchor), "Épées", "Tranchor", 50.0, 80.0, typeof(FerIngot), "Lingots", 16, 1044037);
            index = AddCraft(typeof(Flamberge), "Épées", "Flamberge", 50.0, 80.0, typeof(FerIngot), "Lingots", 16, 1044037);
            index = AddCraft(typeof(Sombrimur), "Épées", "Sombrimur", 50.0, 80.0, typeof(FerIngot), "Lingots", 16, 1044037);
            //index = AddCraft(typeof(Marquaise), "Épées", "Marquaise", 60.0, 90.0, typeof(FerIngot), "Lingots", 16, 1044037);
            //index = AddCraft(typeof(Mortimer), "Épées", "Mortimer", 60.0, 90.0, typeof(FerIngot), "Lingots", 16, 1044037);
            //index = AddCraft(typeof(Espadon), "Épées", "Espadon", 60.0, 90.0, typeof(FerIngot), "Lingots", 16, 1044037);
            index = AddCraft(typeof(Zweihander), "Épées", "Zweihander", 70.0, 100.0, typeof(FerIngot), "Lingots", 16, 1044037);
            index = AddCraft(typeof(Morsame), "Épées", "Morsame", 70.0, 100.0, typeof(FerIngot), "Lingots", 16, 1044037);
            index = AddCraft(typeof(Granlame), "Épées", "Granlame", 70.0, 100.0, typeof(FerIngot), "Lingots", 18, 1044037);

            //Doubles

            //index = AddCraft(typeof(Mirilione), "Épées", "Mirilione", 30.0, 60.0, typeof(FerIngot), "Lingots", 8, 1044037);
            //index = AddCraft(typeof(Niropie), "Épées", "Niropie", 70.0, 100.0, typeof(FerIngot), "Lingots", 6, 1044037);

            //Doubles Elfiques

            //index = AddCraft(typeof(Zarel), "Épées", "Zarel", 30.0, 60.0, typeof(FerIngot), "Lingots", 6, 1044037);
            //index = AddCraft(typeof(Sefrio), "Épées", "Sefrio", 50.0, 80.0, typeof(FerIngot), "Lingots", 8, 1044037);
            //index = AddCraft(typeof(Ferel), "Épées", "Ferel", 70.0, 100.0, typeof(FerIngot), "Lingots", 10, 1044037);

            #endregion

            #region Axes
            //index = AddCraft(typeof(Hachette), "Haches", "Hachette", 0.0, 30.0, typeof(FerIngot), "Lingots", 10, 1044037);
            //AddRes(index, typeof(Log), "Bûches d'érable", 2, 1044351);
            index = AddCraft(typeof(Axe), "Haches", "Hache", 10.0, 40.0, typeof(FerIngot), "Lingots", 10, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 2, 1044351);
            //index = AddCraft(typeof(HachetteDouble), "Haches", "Hachette Double", 20.0, 50.0, typeof(FerIngot), "Lingots", 8, 1044037);
            //AddRes(index, typeof(Log), "Bûches d'érable", 2, 1044351);
            index = AddCraft(typeof(Luminar), "Haches", "Luminar", 30.0, 60.0, typeof(FerIngot), "Lingots", 10, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 2, 1044351);
            index = AddCraft(typeof(Loragne), "Haches", "Loragne", 30.0, 60.0, typeof(FerIngot), "Lingots", 12, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 2, 1044351);
            index = AddCraft(typeof(Montorgne), "Haches", "Montorgne", 40.0, 70.0, typeof(FerIngot), "Lingots", 12, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 2, 1044351);
            index = AddCraft(typeof(WarAxe), "Haches", "Hache de Guerre", 50.0, 80.0, typeof(FerIngot), "Lingots", 14, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 2, 1044351);
            index = AddCraft(typeof(Orcarinia), "Haches", "Orcarinia", 50.0, 80.0, typeof(FerIngot), "Lingots", 12, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 2, 1044351);
            index = AddCraft(typeof(Minarque), "Haches", "Minarque", 60.0, 90.0, typeof(FerIngot), "Lingots", 12, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 2, 1044351);
            index = AddCraft(typeof(Grochette), "Haches", "Grochette", 70.0, 100.0, typeof(FerIngot), "Lingots", 16, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 2, 1044351);
            index = AddCraft(typeof(Noctame), "Haches", "Noctame", 70.0, 100.0, typeof(FerIngot), "Lingots", 10, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 2, 1044351);

            index = AddCraft(typeof(HacheDouble), "Haches", "Hache Métalique", 20.0, 50.0, typeof(FerIngot), "Lingots", 18, 1044037);
            index = AddCraft(typeof(Morgrove), "Haches", "Morgrove", 20.0, 50.0, typeof(FerIngot), "Lingots", 16, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Venmar), "Haches", "Venmar", 30.0, 60.0, typeof(FerIngot), "Lingots", 16, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(TwoHandedAxe), "Haches", "Hache Double", 40.0, 70.0, typeof(FerIngot), "Lingots", 16, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(LargeBattleAxe), "Haches", "Hache Barbare", 50.0, 80.0, typeof(FerIngot), "Lingots", 14, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Morgate), "Haches", "Morgate", 60.0, 90.0, typeof(FerIngot), "Lingots", 16, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Coupecrane), "Haches", "Coupecrane", 60.0, 90.0, typeof(FerIngot), "Lingots", 14, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Tranchecorps), "Haches", "Tranchecorps", 60.0, 90.0, typeof(FerIngot), "Lingots", 16, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Elvetrine), "Haches", "Elvetrine", 70.0, 100.0, typeof(FerIngot), "Lingots", 16, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Viftranche), "Haches", "Viftranche", 70.0, 100.0, typeof(FerIngot), "Lingots", 16, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);

            /*index = AddCraft(typeof(Furagne), "Haches", "Furagne", 30.0, 60.0, typeof(FerIngot), "Lingots", 4, 1044037);
            AddRes(index, typeof(Log), "Bûche", 1, 1044351);
            index = AddCraft(typeof(Duxtranche), "Haches", "Duxtranche", 50.0, 80.0, typeof(FerIngot), "Lingots", 6, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 2, 1044351);
            index = AddCraft(typeof(Biliane), "Haches", "Biliane", 70.0, 100.0, typeof(FerIngot), "Lingots", 6, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 2, 1044351);*/

			#endregion

            #region Fencing

            index = AddCraft(typeof(Dagger), "Armes Perforantes", "Dague", 5.0, 25.0, typeof(FerIngot), "Lingots", 3, 1044037);
            index = AddCraft(typeof(ButcherKnife), "Armes Perforantes", "Couteau de Boucher", 10.0, 20.0, typeof(FerIngot), "Lingots", 2, 1044037);
            index = AddCraft(typeof(Cleaver), "Armes Perforantes", "Cleaver", 10.0, 20.0, typeof(FerIngot), "Lingots", 2, 1044037);
            index = AddCraft(typeof(Safrine), "Armes Perforantes", "Safrine", 20.0, 50.0, typeof(FerIngot), "Lingots", 2, 1044037);
            index = AddCraft(typeof(Dentsombre), "Armes Perforantes", "Dentsombre", 30.0, 60.0, typeof(FerIngot), "Lingots", 2, 1044037);
            index = AddCraft(typeof(Lozure), "Armes Perforantes", "Lozure", 40.0, 70.0, typeof(FerIngot), "Lingots", 3, 1044037);
            index = AddCraft(typeof(Basilarda), "Armes Perforantes", "Basilarda", 40.0, 70.0, typeof(FerIngot), "Lingots", 3, 1044037);
            index = AddCraft(typeof(Osseuse), "Armes Perforantes", "Osseuse", 50.0, 80.0, typeof(FerIngot), "Lingots", 3, 1044037);
            index = AddCraft(typeof(Serpentine), "Armes Perforantes", "Serpentine", 50.0, 80.0, typeof(FerIngot), "Lingots", 3, 1044037);
            index = AddCraft(typeof(Elvine), "Armes Perforantes", "Elvine", 60.0, 90.0, typeof(FerIngot), "Lingots", 4, 1044037);
            index = AddCraft(typeof(Brillaume), "Armes Perforantes", "Brillaume", 60.0, 90.0, typeof(FerIngot), "Lingots", 4, 1044037);
            index = AddCraft(typeof(Dracourbe), "Armes Perforantes", "Dracourbe", 70.0, 100.0, typeof(FerIngot), "Lingots", 3, 1044037);
            index = AddCraft(typeof(Spadasine), "Armes Perforantes", "Spadasine", 70.0, 100.0, typeof(FerIngot), "Lingots", 3, 1044037);
            index = AddCraft(typeof(Ecorchette), "Armes Perforantes", "Écorchette", 70.0, 100.0, typeof(FerIngot), "Lingots", 3, 1044037);
            //index = AddCraft(typeof(Poignard), "Armes Perforantes", "Poignard", 30.0, 50.0, typeof(FerIngot), "Lingots", 3, 1044037);
            //index = AddCraft(typeof(Eblame), "Armes Perforantes", "Eblame", 50.0, 80.0, typeof(FerIngot), "Lingots", 4, 1044037);
            //index = AddCraft(typeof(Imperlame), "Armes Perforantes", "Imperlame", 70.0, 100.0, typeof(FerIngot), "Lingots", 3, 1044037);
            index = AddCraft(typeof(Fleuret), "Armes Perforantes", "Fleuret", 10.0, 40.0, typeof(FerIngot), "Lingots", 8, 1044037);
            index = AddCraft(typeof(Percille), "Armes Perforantes", "Percille", 20.0, 50.0, typeof(FerIngot), "Lingots", 8, 1044037);
            index = AddCraft(typeof(Rapiere), "Armes Perforantes", "Rapiere", 30.0, 60.0, typeof(FerIngot), "Lingots", 8, 1044037);
            index = AddCraft(typeof(Cuivardise), "Armes Perforantes", "Cuivardise", 40.0, 70.0, typeof(FerIngot), "Lingots", 8, 1044037);
            index = AddCraft(typeof(Lyzardese), "Armes Perforantes", "Lyzardèse", 50.0, 80.0, typeof(FerIngot), "Lingots", 8, 1044037);
            index = AddCraft(typeof(Estoc), "Armes Perforantes", "Estoc", 60.0, 90.0, typeof(FerIngot), "Lingots", 10, 1044037);
            index = AddCraft(typeof(Musareche), "Armes Perforantes", "Musarèche", 70.0, 100.0, typeof(FerIngot), "Lingots", 12, 1044037);
            index = AddCraft(typeof(Brette), "Armes Perforantes", "Brette", 70.0, 100.0, typeof(FerIngot), "Lingots", 12, 1044037);

            #endregion

            #region Pole Arms

            index = AddCraft(typeof(Bardiche), "Armes d'Hastes", "Bardiche", 20.0, 50.0, typeof(FerIngot), "Lingots", 18, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Scythe), "Armes d'Hastes", "Faux", 30.0, 60.0, typeof(FerIngot), "Lingots", 14, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Vougue), "Armes d'Hastes", "Vougue", 40.0, 70.0, typeof(FerIngot), "Lingots", 18, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(ExecutionersAxe), "Armes d'Hastes", "Gardiche", 60.0, 90.0, typeof(FerIngot), "Lingots", 14, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Cythe), "Armes d'Hastes", "Cythe", 60.0, 90.0, typeof(FerIngot), "Lingots", 16, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Guisarme), "Armes d'Hastes", "Guisarme", 70.0, 100.0, typeof(FerIngot), "Lingots", 18, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);

            index = AddCraft(typeof(Halberd), "Armes d'Hastes", "Hallebarde", 30.0, 60.0, typeof(FerIngot), "Lingots", 20, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Bardine), "Armes d'Hastes", "Bardine", 40.0, 70.0, typeof(FerIngot), "Lingots", 20, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Hastiche), "Armes d'Hastes", "Hastiche", 50.0, 80.0, typeof(FerIngot), "Lingots", 20, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Helbarde), "Armes d'Hastes", "Helbarde", 60.0, 90.0, typeof(FerIngot), "Lingots", 20, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Granbarde), "Armes d'Hastes", "Granbarde", 70.0, 100.0, typeof(FerIngot), "Lingots", 20, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);

            #endregion

            #region Spears

            index = AddCraft(typeof(Lancel), "Lances", "Lancel", 10.0, 40.0, typeof(FerIngot), "Lingots", 12, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Spear), "Lances", "Lance", 20.0, 50.0, typeof(FerIngot), "Lingots", 12, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Terricharde), "Lances", "Terricharde", 30.0, 60.0, typeof(FerIngot), "Lingots", 12, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(PerceTronc), "Lances", "PerceTronc", 40.0, 70.0, typeof(FerIngot), "Lingots", 12, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(ShortSpear), "Lances", "Hastone", 50.0, 80.0, typeof(FerIngot), "Lingots", 12, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(WarFork), "Lances", "Hastal", 50.0, 80.0, typeof(FerIngot), "Lingots", 12, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Lance), "Lances", "Lance de Joute", 60.0, 90.0, typeof(FerIngot), "Lingots", 20, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(DoubleLance), "Lances", "Double Lance", 60.0, 90.0, typeof(FerIngot), "Lingots", 12, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Piculame), "Lances", "Piculame", 70.0, 100.0, typeof(FerIngot), "Lingots", 12, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(PerceCoeur), "Lances", "PerceCoeur", 70.0, 100.0, typeof(FerIngot), "Lingots", 12, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Pitchfork), "Lances", "Fourche", 20.0, 50.0, typeof(FerIngot), "Lingots", 12, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Pique), "Lances", "Pique", 20.0, 50.0, typeof(FerIngot), "Lingots", 12, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Trident), "Lances", "Trident", 30.0, 60.0, typeof(FerIngot), "Lingots", 12, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Racuris), "Lances", "Racuris", 40.0, 70.0, typeof(FerIngot), "Lingots", 12, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Transpercille), "Lances", "Transpercille", 50.0, 80.0, typeof(FerIngot), "Lingots", 12, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Mascarate), "Lances", "Mascarate", 60.0, 90.0, typeof(FerIngot), "Lingots", 12, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Turione), "Lances", "Turione", 70.0, 100.0, typeof(FerIngot), "Lingots", 14, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);

			#endregion

			#region Bashing
            index = AddCraft(typeof(Mace), "Armes Contondantes", "Mace", 20.0, 50.0, typeof(FerIngot), "Lingots", 6, 1044037);
            index = AddCraft(typeof(WarMace), "Armes Contondantes", "Masse de Guerre", 30.0, 60.0, typeof(FerIngot), "Lingots", 14, 1044037);
            index = AddCraft(typeof(Maul), "Armes Contondantes", "Maul", 40.0, 70.0, typeof(FerIngot), "Lingots", 10, 1044037);
            //index = AddCraft(typeof(Brisecrane), "Armes Contondantes", "Brisecrane", 40.0, 70.0, typeof(FerIngot), "Lingots", 16, 1044037);
            index = AddCraft(typeof(WarHammer), "Armes Contondantes", "Marteau", 40.0, 70.0, typeof(FerIngot), "Lingots", 16, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 3, 1044351);
            index = AddCraft(typeof(Massue), "Armes Contondantes", "Massue", 40.0, 70.0, typeof(FerIngot), "Lingots", 10, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Granmace), "Armes Contondantes", "Granmace", 50.0, 80.0, typeof(FerIngot), "Lingots", 14, 1044037);
            index = AddCraft(typeof(Ecracheur), "Armes Contondantes", "Ecracheur", 50.0, 80.0, typeof(FerIngot), "Lingots", 12, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Ecraseface), "Armes Contondantes", "Écraseface", 60.0, 90.0, typeof(FerIngot), "Lingots", 4, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(MarteauGuerre), "Armes Contondantes", "Marteau de Guerre", 60.0, 90.0, typeof(FerIngot), "Lingots", 12, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Fleau), "Armes Contondantes", "Fléau", 60.0, 90.0, typeof(FerIngot), "Lingots", 16, 1044037);
            index = AddCraft(typeof(Malert), "Armes Contondantes", "Malette", 70.0, 100.0, typeof(FerIngot), "Lingots", 16, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);
            index = AddCraft(typeof(Defonceur), "Armes Contondantes", "Défonceur", 70.0, 100.0, typeof(FerIngot), "Lingots", 8, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 2, 1044351);
            index = AddCraft(typeof(Broyeur), "Armes Contondantes", "Broyeur", 70.0, 100.0, typeof(FerIngot), "Lingots", 16, 1044037);
            AddRes(index, typeof(Log), "Bûches d'érable", 4, 1044351);

			#endregion

            #region Poings

            index = AddCraft(typeof(Griffes), "Armes de Poings", "Griffes", 30.0, 60.0, typeof(FerIngot), "Lingots", 12, 1044037);
            index = AddCraft(typeof(Katar), "Armes de Poings", "Katar", 50.0, 80.0, typeof(FerIngot), "Lingots", 13, 1044037);
            index = AddCraft(typeof(Katara), "Armes de Poings", "Katara", 70.0, 100.0, typeof(FerIngot), "Lingots", 14, 1044037);

            #endregion

			// Set the overridable material
			SetSubRes( typeof( FerIngot ), "Fer" );

			// Add every material you want the player to be able to choose from
			// This will override the overridable material
			AddSubRes( typeof( FerIngot ),	"Fer", CraftResources.GetSkill( CraftResource.Fer ), 1044267 );
            AddSubRes(typeof(CuivreIngot), "Cuivre", CraftResources.GetSkill( CraftResource.Cuivre), 1044268);
            AddSubRes(typeof(BronzeIngot), "Bronze", CraftResources.GetSkill( CraftResource.Bronze), 1044268);
            AddSubRes(typeof(AcierIngot), "Acier", CraftResources.GetSkill( CraftResource.Acier), 1044268);
            AddSubRes(typeof(ArgentIngot), "Argent", CraftResources.GetSkill( CraftResource.Argent), 1044268);
            AddSubRes(typeof(OrIngot), "Or", CraftResources.GetSkill( CraftResource.Or), 1044268);
            AddSubRes(typeof(MytherilIngot), "Mytheril", CraftResources.GetSkill( CraftResource.Mytheril), 1044268);
            AddSubRes(typeof(LuminiumIngot), "Luminium", CraftResources.GetSkill( CraftResource.Luminium), 1044268);
            AddSubRes(typeof(ObscuriumIngot), "Obscurium", CraftResources.GetSkill( CraftResource.Obscurium), 1044268);
            AddSubRes(typeof(MystiriumIngot), "Mystirium", CraftResources.GetSkill( CraftResource.Mystirium), 1044268);
            AddSubRes(typeof(DominiumIngot), "Dominium", CraftResources.GetSkill( CraftResource.Dominium), 1044268);
            AddSubRes(typeof(VenariumIngot), "Venarium", CraftResources.GetSkill( CraftResource.Venarium), 1044268);
            AddSubRes(typeof(EclariumIngot), "Eclarium", CraftResources.GetSkill( CraftResource.Eclarium), 1044268);
            AddSubRes(typeof(AtheniumIngot), "Athenium", CraftResources.GetSkill( CraftResource.Athenium), 1044268);
            AddSubRes(typeof(UmbrariumIngot), "Umbrarium", CraftResources.GetSkill( CraftResource.Umbrarium), 1044268);

			/*SetSubRes2( typeof( RegularScales ),    "Écailles" );

			AddSubRes2( typeof( RegularScales ),	"Écailles", 0.0, 1044268 );
			AddSubRes2( typeof( NordiqueScales ),	"Écailles Nordiques", 0.0, 1044268 );
			AddSubRes2( typeof( DesertiqueScales ),	"Écailles Désertiques", 0.0, 1044268 );
			AddSubRes2( typeof( MaritimeScales ),	"Écailles Maritimes", 0.0, 1044268 );
			AddSubRes2( typeof( VolcaniqueScales ),	"Écailles Volcaniques", 0.0, 1044268 );
			AddSubRes2( typeof( AncienScales ),		"Écailles Anciennes", 0.0, 1044268 );
            AddSubRes2( typeof( WyrmScales ),       "Écailles Wyrmiques", 0.0, 1044268);*/

			Resmelt = true;
			Repair = true;
			MarkOption = true;
			CanEnhance = Core.AOS;
		}
	}

	public class ForgeAttribute : Attribute
	{
		public ForgeAttribute()
		{
		}
	}

	public class AnvilAttribute : Attribute
	{
		public AnvilAttribute()
		{
		}
	}
}