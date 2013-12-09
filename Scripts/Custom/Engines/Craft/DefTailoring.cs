using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefTailoring : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Couture; }
		}

		public override int GumpTitleNumber
		{
			get { return 1044005; } // <CENTER>TAILORING MENU</CENTER>
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefTailoring();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.5; // 50%
		}

		private DefTailoring() : base( 1, 1, 1.25 )// base( 1, 1, 4.5 )
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

		public static bool IsNonColorable(Type type)
		{
			for (int i = 0; i < m_TailorNonColorables.Length; ++i)
			{
				if (m_TailorNonColorables[i] == type)
				{
					return true;
				}
			}

			return false;
		}

		private static Type[] m_TailorNonColorables = new Type[]
			{
				typeof( OrcHelm )
			};

		private static Type[] m_TailorColorables = new Type[]
			{
				typeof( GozaMatEastDeed ), typeof( GozaMatSouthDeed ),
				typeof( SquareGozaMatEastDeed ), typeof( SquareGozaMatSouthDeed ),
				typeof( BrocadeGozaMatEastDeed ), typeof( BrocadeGozaMatSouthDeed ),
				typeof( BrocadeSquareGozaMatEastDeed ), typeof( BrocadeSquareGozaMatSouthDeed )
			};

		public override bool RetainsColorFrom( CraftItem item, Type type )
		{
			if ( type != typeof( Cloth ) && type != typeof( UncutCloth ) )
				return false;

			type = item.ItemType;

			bool contains = false;

			for ( int i = 0; !contains && i < m_TailorColorables.Length; ++i )
				contains = ( m_TailorColorables[i] == type );

			return contains;
		}

		public override void PlayCraftEffect( Mobile from )
		{
			from.PlaySound( 0x248 );
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

			

			#region Hats
            AddCraft(typeof(SkullCap), "Chapeaux", "Bandeau", 0.0, 20.0, typeof(Cloth), "Coton", 2, 1044287);
            AddCraft(typeof(Bandana), "Chapeaux", "Bandana", 0.0, 25.0, typeof(Cloth), "Coton", 2, 1044287);
            AddCraft(typeof(Turban), "Chapeaux", "Turban", 10.0, 20.0, typeof(Cloth), "Coton", 5, 1044287);
            AddCraft(typeof(TurbanLong), "Chapeaux", "Turban Long", 20.0, 30.0, typeof(Cloth), "Coton", 6, 1044287);
            AddCraft(typeof(TurbanFeminin), "Chapeaux", "Turban Feminin", 30.0, 40.0, typeof(Cloth), "Coton", 6, 1044287);
            AddCraft(typeof(TurbanProtecteur), "Chapeaux", "Turban Protecteur", 40.0, 50.0, typeof(Cloth), "Coton", 6, 1044287);
            AddCraft(typeof(TurbanVoile), "Chapeaux", "Turban Voilé", 50.0, 60.0, typeof(Cloth), "Coton", 6, 1044287);
            AddCraft(typeof(TurbanAmple), "Chapeaux", "Turban Ample", 50.0, 60.0, typeof(Cloth), "Coton", 7, 1044287);
            AddCraft(typeof(TurbanNoble), "Chapeaux", "Turban Noble", 60.0, 70.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(FloppyHat), "Chapeaux", "Large Chapeau", 6.2, 31.2, typeof(Cloth), "Coton", 11, 1044287);
            AddCraft(typeof(Cap), "Chapeaux", "Coiffe", 10.0, 30.0, typeof(Cloth), "Coton", 11, 1044287);
            AddCraft(typeof(WideBrimHat), "Chapeaux", "Chapeau à large bord", 10.0, 30.0, typeof(Cloth), "Coton", 12, 1044287);
            AddCraft(typeof(StrawHat), "Chapeaux", "Chapeau de Paille", 20.0, 40.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(TallStrawHat), "Chapeaux", "Grand Chapeau de Paille", 20.0, 40.0, typeof(Cloth), "Coton", 13, 1044287);
            //AddCraft( typeof( WizardsHat ), "Chapeaux", "Béret", 7.2, 32.2, typeof( Cloth ), "Coton", 15, 1044287 );
            AddCraft(typeof(Bonnet), "Chapeaux", "Bonnet", 30.0, 50.0, typeof(Cloth), "Coton", 11, 1044287);
            AddCraft(typeof(FeatheredHat), "Chapeaux", "Chapeau à plume", 40.0, 60.0, typeof(Cloth), "Coton", 12, 1044287);
            AddCraft(typeof(TricorneHat), "Chapeaux", "Tricone", 40.0, 60.0, typeof(Cloth), "Coton", 12, 1044287);
            AddCraft(typeof(JesterHat), "Chapeaux", "Chapeau des Fols", 50.0, 70.0, typeof(Cloth), "Coton", 15, 1044287);
            AddCraft(typeof(ChapeauCourt), "Chapeaux", "Chapeau de Court", 60.0, 80.0, typeof(Cloth), "Coton", 6, 1044287);
            AddCraft(typeof(ChapeauPlume), "Chapeaux", "Chapeau Mousquetaire", 70.0, 90.0, typeof(Cloth), "Coton", 6, 1044287);
            AddCraft(typeof(ChapeauMelon), "Chapeaux", "Chapeau Melon", 70.0, 90.0, typeof(Cloth), "Coton", 6, 1044287);
            AddCraft(typeof(ChapeauNoble), "Chapeaux", "Béret", 80.0, 90.0, typeof(Cloth), "Coton", 6, 1044287);
            AddCraft(typeof(ChapeauLoup), "Chapeaux", "Tête de Loup", 60.0, 80.0, typeof(Leather), "Cuir", 6, 1044287);

			/*if ( Core.AOS )
				AddCraft( typeof( FlowerGarland ), 1011375, 1028965, 10.0, 35.0, typeof( Cloth ), 1044286, 5, 1044287 );

			if( Core.SE )
			{
				index = AddCraft( typeof( ClothNinjaHood ), 1011375, 1030202, 80.0, 105.0, typeof( Cloth ), 1044286, 13, 1044287 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( Kasa ), 1011375, 1030211, 60.0, 85.0, typeof( Cloth ), 1044286, 12, 1044287 );	
				SetNeededExpansion( index, Expansion.SE );
			}*/
			#endregion

						
			#region Coussins //Fucking ADddRes de plumes qui fait crash en ouvrant le sewing kit
			AddCraft(typeof(CoussinB), "Coussins", "Petit coussin carré", 20.0, 40.0, typeof(Cloth), "Coton", 3, 1044287);
			//AddRes(index, typeof(Feather), "Plumes", 5, 1044287);
			AddCraft(typeof(CoussinA), "Coussins", "Gros oreiller", 40.0, 60.0, typeof(Cloth), "Coton", 4, 1044287);
			//AddRes(index, typeof(Feather), "Plumes", 5, 1044563);
			AddCraft(typeof(CoussinC), "Coussins", "Gros oreiller de velours", 50.0, 70.0, typeof(Cloth), "Coton", 4, 1044287);
			//AddRes(index, typeof(Feather), "Plumes", 5, 1044563);
			AddCraft(typeof(CoussinD), "Coussins", "Gros oreiller carré", 50.0, 70.0, typeof(Cloth), "Coton", 4, 1044287);
			//AddRes(index, typeof(Feather), "Plumes", 5, 1044563);
			AddCraft(typeof(CoussinE), "Coussins", "Petit coussin rond clair", 0.0, 30.0, typeof(Cloth), "Coton", 3, 1044287);
			//AddRes(index, typeof(Feather), "Plumes", 5, 1044563);
			AddCraft(typeof(CoussinF), "Coussins", "petit coussin rond sombre", 0.0, 30.0, typeof(Cloth), "Coton", 3, 1044287);
			//AddRes(index, typeof(Feather), "Plumes", 5, 1044563);
			AddCraft(typeof(CoussinG), "Coussins", "Petit coussin carré à pompon", 30.0, 50.0, typeof(Cloth), "Coton", 3, 1044287);
			//AddRes(index, typeof(Feather), "Plumes", 5, 1044563);
			AddCraft(typeof(CoussinH), "Coussins", "Autre petit coussin carré à pompon", 30.0, 50.0, typeof(Cloth), "Coton", 3, 1044287);
			//AddRes(index, typeof(Feather), "Plumes", 5, 1044563);
			AddCraft(typeof(CoussinI), "Coussins", "Gros coussin carré", 40.0, 60.0, typeof(Cloth), "Coton", 3, 1044287);
			//AddRes(index, typeof(Feather), "Plumes", 5, 1044563);
			AddCraft(typeof(CoussinJ), "Coussins", "Gros coussin carré droit", 0.0, 60.0, typeof(Cloth), "Coton", 3, 1044287);
			//AddRes(index, typeof(Feather), "Plumes", 5, 1044563);
            #endregion
			
			
			
            #region Toges
            AddCraft(typeof(Robe), "Toges & Manteaux", "Toge", 0.0, 30.0, typeof(Cloth), "Coton", 16, 1044287);
            AddCraft(typeof(TogeSoutane), "Toges & Manteaux", "Soutane", 20.0, 40.0, typeof(Cloth), "Coton", 17, 1044287);
            AddCraft(typeof(TogePelerin), "Toges & Manteaux", "Toge Pèlerine", 30.0, 50.0, typeof(Cloth), "Coton", 17, 1044287);
            AddCraft(typeof(TogeReligieuse), "Toges & Manteaux", "Toge Religieuse", 30.0, 50.0, typeof(Cloth), "Coton", 17, 1044287);
            AddCraft(typeof(TogeNomade), "Toges & Manteaux", "Toge de Nomade", 40.0, 60.0, typeof(Cloth), "Coton", 17, 1044287);
            AddCraft(typeof(TogeOrient), "Toges & Manteaux", "Toge d'Orient", 40.0, 60.0, typeof(Cloth), "Coton", 17, 1044287);
            AddCraft(typeof(Toge), "Toges & Manteaux", "Toge Arcanique", 40.0, 60.0, typeof(Cloth), "Coton", 17, 1044287);
            AddCraft(typeof(TogeVoyage), "Toges & Manteaux", "Toge Voyage", 40.0, 60.0, typeof(Cloth), "Coton", 17, 1044287);
            AddCraft(typeof(TogeDecore), "Toges & Manteaux", "Toge Décorée", 50.0, 70.0, typeof(Cloth), "Coton", 17, 1044287);
            AddCraft(typeof(TogeDiciple), "Toges & Manteaux", "Toge Moniale", 50.0, 70.0, typeof(Cloth), "Coton", 17, 1044287);
            AddCraft(typeof(TogeElfique), "Toges & Manteaux", "Toge d'Elfe", 50.0, 70.0, typeof(Cloth), "Coton", 15, 1044287);
            AddCraft(typeof(TogeGoetie), "Toges & Manteaux", "Toge Sinistre", 50.0, 80.0, typeof(Cloth), "Coton", 16, 1044287);
            //AddCraft(typeof(TogeElfique), "Toges & Manteaux", "Toge Elfique", 50.0, 80.0, typeof(Cloth), "Coton", 15, 1044287);
            AddCraft(typeof(TogeDrow), "Toges & Manteaux", "Toge d'Alfar", 50.0, 80.0, typeof(Cloth), "Coton", 15, 1044287);
            AddCraft(typeof(TogeHautElfe), "Toges & Manteaux", "Toge d'Haut Elfe", 60.0, 80.0, typeof(Cloth), "Coton", 18, 1044287); 
            AddCraft(typeof(TogeAmple), "Toges & Manteaux", "Toge Ample", 70.0, 90.0, typeof(Cloth), "Coton", 18, 1044287);
            AddCraft(typeof(TogeMystique), "Toges & Manteaux", "Toge Mystique", 70.0, 90.0, typeof(Cloth), "Coton", 16, 1044287);
            AddCraft(typeof(TogeArchiMage), "Toges & Manteaux", "Toge d'Archimage", 80.0, 100.0, typeof(Cloth), "Coton", 16, 1044287);
            AddCraft(typeof(TogeFeminine), "Toges & Manteaux", "Toge de Prêtrise", 90.0, 110.0, typeof(Cloth), "Coton", 17, 1044287);
            AddCraft(typeof(TogeSorcier), "Toges & Manteaux", "Toge de Sorcier", 90.0, 110.0, typeof(Cloth), "Coton", 18, 1044287);
            AddCraft(typeof(TogeOr), "Toges & Manteaux", "Toge d'Or", 90.0, 120.0, typeof(Cloth), "Coton", 18, 1044287);

            AddCraft(typeof(ManteauPardessus), "Toges & Manteaux", "Vieux Manteau", 30.0, 60.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(ManteauTabar), "Toges & Manteaux", "Manteau d'Arme", 40.0, 70.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(ManteauCourt), "Toges & Manteaux", "Manteau Court", 60.0, 80.0, typeof(Cloth), "Coton", 11, 1044287);
            AddCraft(typeof(ManteauLong), "Toges & Manteaux", "Manteau Long", 70.0, 90.0, typeof(Cloth), "Coton", 13, 1044287);
            AddCraft(typeof(ManteauRaye), "Toges & Manteaux", "Manteau Rayé", 80.0, 100.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(ManteauNoble), "Toges & Manteaux", "Manteau Noble", 90.0, 120.0, typeof(Cloth), "Coton", 18, 1044287);

            #endregion
			
			
			

            #region Capes
            AddCraft(typeof(CapeCourte), "Capes", "Cape Courte", 10.0, 40.0, typeof(Cloth), "Coton", 6, 1044287);
            AddCraft(typeof(CapeVoyage), "Capes", "Cape de Voyage", 20.0, 50.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(CapeBarbare), "Capes", "Cape Barbare", 30.0, 60.0, typeof(Leather), "Cuir", 14, 1044287);
            AddCraft(typeof(CapeNordique), "Capes", "Cape Nordique", 30.0, 60.0, typeof(Leather), "Cuir", 14, 1044287);
            AddCraft(typeof(Cloak), "Capes", "Cape", 40.0, 70.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(CapeEtendard), "Capes", "Cape Étendard", 40.0, 70.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(CapeCapuche), "Capes", "Cape à Capuche", 40.0, 70.0, typeof(Cloth), "Coton", 15, 1044287);
            AddCraft(typeof(CapeCol), "Capes", "Cape à Col", 40.0, 70.0, typeof(Cloth), "Coton", 15, 1044287);
            AddCraft(typeof(CapeColLong), "Capes", "Cape à Long Col", 50.0, 80.0, typeof(Cloth), "Coton", 16, 1044287);
            AddCraft(typeof(CapeSolide), "Capes", "Cape Solide", 50.0, 80.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(CapeEpauliere), "Capes", "Cape à Épaulières", 50.0, 80.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(CapeDecore), "Capes", "Cape Décorée", 50.0, 80.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(CapeLongue), "Capes", "Cape Longue", 60.0, 90.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(CapeTrainee), "Capes", "Cape à Trainée", 60.0, 90.0, typeof(Cloth), "Coton", 17, 1044287);
            AddCraft(typeof(CapeCagoule), "Capes", "Cape à Cagoule", 60.0, 90.0, typeof(Cloth), "Coton", 15, 1044287);
            AddCraft(typeof(CapeNoble), "Capes", "Cape Noble", 70.0, 100.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(Voile), "Capes", "Voile", 70.0, 100.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(CapeFeminine), "Capes", "Cape Féminine", 70.0, 100.0, typeof(Cloth), "Coton", 13, 1044287);
            AddCraft(typeof(CapeFourrure), "Capes", "Cape de Cuir", 80.0, 110.0, typeof(Leather), "Cuir", 14, 1044287);
            AddCraft(typeof(CapePoil), "Capes", "Cape de Poil", 80.0, 110.0, typeof(Leather), "Cuir", 14, 1044287);
            AddCraft(typeof(CapeJarl), "Capes", "Cape de Fourrure", 90.0, 120.0, typeof(Leather), "Cuir", 14, 1044287);
            AddCraft(typeof(CapePlume), "Capes", "Cape à Plumes", 90.0, 120.0, typeof(Feather), "Plumes", 60, 1044287);
            AddCraft(typeof(CapeSombre), "Capes", "Cape Sombre", 90.0, 120.0, typeof(Cloth), "Coton", 60, 1044287);

            #endregion

            #region Robes
            AddCraft(typeof(RobeDechire), "Robes", "Robe déchirée", 0.0, 5.0, typeof(Cloth), "Coton", 6, 1044287);
            AddCraft(typeof(RobeDrow), "Robes", "Robe Ancienne", 5.0, 10.0, typeof(Cloth), "Coton", 6, 1044287);
            AddCraft(typeof(RobePetite), "Robes", "Petite Robe", 10.0, 20.0, typeof(Cloth), "Coton", 6, 1044287);
            AddCraft(typeof(RobeSoubrette), "Robes", "Robe de Soubrette", 10.0, 20.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(PlainDress), "Robes", "Robe Simple", 15.0, 30.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(RobeSimple), "Robes", "Robe", 15.0, 30.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(RobeOrdinaire), "Robes", "Robe Ordinaire", 15.0, 30.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(RobeGamine), "Robes", "Robe de Gamine", 20.0, 50.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(RobeEnfantine), "Robes", "Robe Enfantine", 20.0, 50.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(RobeDomestique), "Robes", "Robe de Domestique", 25.0, 55.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(RobeBohemienne), "Robes", "Robe Bohémienne", 25.0, 55.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(RobeOrcish), "Robes", "Robe Orcish", 25.0, 55.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(RobeGitane), "Robes", "Robe de Gitane", 25.0, 55.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(RobeACeinture), "Robes", "Robe a Ceinture", 30.0, 60.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(RobeSansManches), "Robes", "Robe Sans Manches", 30.0, 60.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(RobeDemoiselle), "Robes", "Robe de Demoiselle", 30.0, 60.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(RobeFleurit), "Robes", "Robe Fleurit", 35.0, 65.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(RobeServeuse), "Robes", "Robe de Serveuse", 35.0, 65.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(RobeServante), "Robes", "Robe de Servante", 35.0, 65.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(RobeAubergiste), "Robes", "Robe d'Aubergiste", 40.0, 70.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(RobeSobre), "Robes", "Robe Sobre", 40.0, 70.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(RobeOrne), "Robes", "Robe Orné", 40.0, 70.0, typeof(Cloth), "Coton", 11, 1044287);
            AddCraft(typeof(RobeAmusante), "Robes", "Robe Amusante", 45.0, 75.0, typeof(Cloth), "Coton", 12, 1044287);
            AddCraft(typeof(RobeElegante), "Robes", "Robe Élégante", 45.0, 75.0, typeof(Cloth), "Coton", 12, 1044287);
            AddCraft(typeof(RobeSeduisante), "Robes", "Robe Séduisante", 45.0, 75.0, typeof(Cloth), "Coton", 12, 1044287);
            AddCraft(typeof(RobeOrient), "Robes", "Robe d'Orient", 50.0, 80.0, typeof(Cloth), "Coton", 12, 1044287);
            AddCraft(typeof(RobeOrientale), "Robes", "Robe de Nomades", 50.0, 80.0, typeof(Cloth), "Coton", 12, 1044287);
            AddCraft(typeof(RobeBourgeoise), "Robes", "Robe Bourgeoise", 50.0, 80.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(RobeGrande), "Robes", "Grande Robe", 55.0, 85.0, typeof(Cloth), "Coton", 16, 1044287);
            AddCraft(typeof(RobeLarge), "Robes", "Large Robe", 55.0, 85.0, typeof(Cloth), "Coton", 18, 1044287);
            AddCraft(typeof(RobeAmple), "Robes", "Robe Ample", 55.0, 85.0, typeof(Cloth), "Coton", 18, 1044287);
            AddCraft(typeof(RobeAvecCorset), "Robes", "Robe Avec Corset", 60.0, 90.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(RobeACorset), "Robes", "Robe À Corset", 60.0, 90.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(RobeCorsetAmple), "Robes", "Robe À Corset Ample", 60.0, 90.0, typeof(Cloth), "Coton", 16, 1044287);
            AddCraft(typeof(RobeCharmante), "Robes", "Robe Charmante", 65.0, 95.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(RobeAttrayante), "Robes", "Robe Attrayante", 65.0, 95.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(RobeDore), "Robes", "Robe Doré", 70.0, 100.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(RobeNoble), "Robes", "Robe Noble", 70.0, 100.0, typeof(Cloth), "Coton", 18, 1044287);
            AddCraft(typeof(RobeCourt), "Robes", "Robe de Court", 75.0, 105.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(RobeAraneide), "Robes", "Robe Aranéide", 75.0, 105.0, typeof(Cloth), "Coton", 12, 1044287);
            AddCraft(typeof(RobeCourteDrow), "Robes", "Robe Courte Elfe Noire", 75.0, 105.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(RobeNymph), "Robes", "Robe Nymph", 75.0, 105.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(RobeAraignee), "Robes", "Robe Araignée", 80.0, 110.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(RobeAntique), "Robes", "Robe Antique", 80.0, 110.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(FancyDress), "Robes", "Robe Décoré", 80.0, 110.0, typeof(Cloth), "Coton", 12, 1044287);
            AddCraft(typeof(RobeElfique), "Robes", "Robe Elfique", 85.0, 115.0, typeof(Cloth), "Coton", 13, 1044287);
            AddCraft(typeof(RobeAmpleElfique), "Robes", "Robe Ample Elfique", 85.0, 115.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(RobeElfe), "Robes", "Robe d'Elfe", 85.0, 115.0, typeof(Cloth), "Coton", 9, 1044287);
            AddCraft(typeof(RobeElfeNoir), "Robes", "Robe d'Alfar", 90.0, 120.0, typeof(Cloth), "Coton", 9, 1044287);
            AddCraft(typeof(RobeJuponElfique), "Robes", "Robe à Jupon Elfique", 90.0, 120.0, typeof(Cloth), "Coton", 12, 1044287);
            AddCraft(typeof(RobeSombre), "Robes", "Robe Sombre", 90.0, 120.0, typeof(Cloth), "Coton", 16, 1044287);
            AddCraft(typeof(RobeOuverte), "Robes", "Robe Ouverte", 90.0, 120.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(Robetrainante), "Robes", "Robe Trainante", 90.0, 120.0, typeof(Cloth), "Coton", 16, 1044287);
            AddCraft(typeof(RobeCourte), "Robes", "Robe Courte", 90.0, 120.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(RobeBoheme), "Robes", "Robe Bohème", 95.0, 125.0, typeof(Cloth), "Coton", 6, 1044287);
            AddCraft(typeof(RobeDentelle), "Robes", "Robe avec Dentelle", 95.0, 125.0, typeof(Cloth), "Coton", 16, 1044287);
            AddCraft(typeof(RobeTrainee), "Robes", "Robe avec Trainée", 95.0, 125.0, typeof(Cloth), "Coton", 16, 1044287);
            AddCraft(typeof(RobeMariage), "Robes", "Robe de Mariage", 95.0, 125.0, typeof(Cloth), "Coton", 16, 1044287);
            #endregion

            #region Shirts
            AddCraft(typeof(ChandailCourtDechire), "Tuniques & Chemises", "Chandail Déchiré", 0.0, 10.0, typeof(Cloth), "Coton", 9, 1044287);
            AddCraft(typeof(ChandailDechire), "Tuniques & Chemises", "Chemise Déchiré", 0.0, 10.0, typeof(Cloth), "Coton", 9, 1044287);
            AddCraft(typeof(ChandailLongDechire), "Tuniques & Chemises", "Chandail Long Déchiré", 0.0, 10.0, typeof(Cloth), "Coton", 9, 1044287);
            AddCraft(typeof(TuniqueDechire), "Tuniques & Chemises", "Tunique Déchirée", 0.0, 10.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(TuniqueLongueDechire), "Tuniques & Chemises", "Tunique Longue Déchirée", 0.0, 10.0, typeof(Cloth), "Coton", 12, 1044287);
            AddCraft(typeof(TabarDechire), "Tuniques & Chemises", "Tabar Déchiré", 0.0, 10.0, typeof(Cloth), "Coton", 10, 1044287);

            AddCraft(typeof(ChandailCourtBarbare), "Tuniques & Chemises", "Chandail Court Barbare", 5.0, 20.0, typeof(Cloth), "Coton", 6, 1044287);
            AddCraft(typeof(ChandailLongBarbare), "Tuniques & Chemises", "Chandail Long Barbare", 5.0, 20.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(ChandailVieux), "Tuniques & Chemises", "Vieux Chandail", 10.0, 30.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(SoutienGorge), "Tuniques & Chemises", "Petit Soutien Gorge", 20.0, 40.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(ChandailSoutienGorge), "Tuniques & Chemises", "Soutien Gorge", 20.0, 40.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(Chandail), "Tuniques & Chemises", "Chandail", 30.0, 50.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(Shirt), "Tuniques & Chemises", "Chandail Sans Manches", 30.0, 50.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(ChandailSombre), "Tuniques & Chemises", "Chandail Sombre", 40.0, 70.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(FancyShirt), "Tuniques & Chemises", "Chandail à manches longues", 40.0, 70.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(ChandailBordel), "Tuniques & Chemises", "Chandail de Bordel", 50.0, 80.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(ChandailDecore), "Tuniques & Chemises", "Chandail Decoré", 60.0, 90.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(ChandailCourt), "Tuniques & Chemises", "Chandail Court", 60.0, 90.0, typeof(Cloth), "Coton", 7, 1044287);
            AddCraft(typeof(ChandailMarin), "Tuniques & Chemises", "Chandail Marin", 70.0, 100.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(ChandailCombat), "Tuniques & Chemises", "Chandail de Combat", 80.0, 110.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(ChandailFeminin), "Tuniques & Chemises", "Chandail Féminin", 80.0, 110.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(ChandailNoble), "Tuniques & Chemises", "Chandail Noble", 90.0, 120.0, typeof(Cloth), "Coton", 8, 1044287);

            AddCraft(typeof(ChemiseOrient), "Tuniques & Chemises", "Chemise d'Orient", 10.0, 30.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(ChemiseCol), "Tuniques & Chemises", "Chemise à Col", 30.0, 50.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(ChemiseReligieuse), "Tuniques & Chemises", "Chemise Religieuse", 40.0, 70.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(Chemiselacee), "Tuniques & Chemises", "Chemise Lacée", 40.0, 70.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(ChemiseBourgeoise), "Tuniques & Chemises", "Chemise Bourgeoise", 50.0, 80.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(ChemiseGaine), "Tuniques & Chemises", "Chemise à Gaine", 60.0, 90.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(ChemiseLongue), "Tuniques & Chemises", "Chemise à manches longues", 70.0, 100.0, typeof(Cloth), "Coton", 11, 1044287);
            AddCraft(typeof(ChemiseElfique), "Tuniques & Chemises", "Chemise Elfique", 70.0, 100.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(ChemiseAmple), "Tuniques & Chemises", "Chemise Ample", 80.0, 110.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(ChemiseNoble), "Tuniques & Chemises", "Chemise Noble", 90.0, 120.0, typeof(Cloth), "Coton", 10, 1044287);

            AddCraft(typeof(CorsetPetit), "Tuniques & Chemises", "Petit Corset", 10.0, 30.0, typeof(Cloth), "Coton", 6, 1044287);
            AddCraft(typeof(CorsetOuvert), "Tuniques & Chemises", "Corset Ouvert", 30.0, 50.0, typeof(Cloth), "Coton", 7, 1044287);
            AddCraft(typeof(Corset), "Tuniques & Chemises", "Corset Simple", 50.0, 70.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(CorsetLong), "Tuniques & Chemises", "Corset Long", 60.0, 90.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(CorsetAmple), "Tuniques & Chemises", "Corset Ample", 70.0, 100.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(CorsetSombre), "Tuniques & Chemises", "Corset Sombre", 80.0, 110.0, typeof(Cloth), "Coton", 8, 1044287);

            AddCraft(typeof(Doublet), "Tuniques & Chemises", "Doublet", 30.0, 50.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(DoubletBouton), "Tuniques & Chemises", "Doublet à Boutons", 50.0, 70.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(DoubletAmple), "Tuniques & Chemises", "Doublet Ample", 60.0, 90.0, typeof(Cloth), "Coton", 9, 1044287);
            AddCraft(typeof(DoubletFeminin), "Tuniques & Chemises", "Doublet d'Alfar", 70.0, 100.0, typeof(Cloth), "Coton", 9, 1044287);
            AddCraft(typeof(DoubletArmure), "Tuniques & Chemises", "Doublet Armuré", 80.0, 110.0, typeof(Cloth), "Coton", 9, 1044287);

            AddCraft(typeof(TuniqueOuverte), "Tuniques & Chemises", "Tunique Ouverte", 0.0, 20.0, typeof(Cloth), "Coton", 9, 1044287);
            AddCraft(typeof(TuniquePardessus), "Tuniques & Chemises", "Tunique de Voyage", 10.0, 30.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(Tunic), "Tuniques & Chemises", "Tunique", 20.0, 50.0, typeof(Cloth), "Coton", 12, 1044287);
            AddCraft(typeof(TuniquePaysanne), "Tuniques & Chemises", "Tunique Simple", 30.0, 60.0, typeof(Cloth), "Coton", 12, 1044287);
            AddCraft(typeof(TuniqueVoyage), "Tuniques & Chemises", "Tunique de Voyage", 40.0, 70.0, typeof(Cloth), "Coton", 12, 1044287);
            AddCraft(typeof(Tunique), "Tuniques & Chemises", "Large Tunique", 40.0, 70.0, typeof(Cloth), "Coton", 12, 1044287);
            AddCraft(typeof(TuniqueAmple), "Tuniques & Chemises", "Tunique Ample", 50.0, 80.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(TuniquePirate), "Tuniques & Chemises", "Tunique de Pirate", 50.0, 80.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(JesterSuit), "Tuniques & Chemises", "Tunique des Fols", 60.0, 90.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(TuniqueOrientale), "Tuniques & Chemises", "Tunique Orientale", 60.0, 90.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(TuniqueNomade), "Tuniques & Chemises", "Tunique de Nomade", 70.0, 100.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(TuniqueBourgeoise), "Tuniques & Chemises", "Tunique Bourgeoise", 70.0, 100.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(TuniquePage), "Tuniques & Chemises", "Tunique de Page", 80.0, 110.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(TuniqueAssassin), "Tuniques & Chemises", "Tunique d'Assassin", 80.0, 110.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(TuniqueNoble), "Tuniques & Chemises", "Tunique Noble", 90.0, 120.0, typeof(Cloth), "Coton", 14, 1044287);

            AddCraft(typeof(Veston), "Toges & Manteaux", "Veston", 10.0, 30.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(VesteCuir), "Toges & Manteaux", "Veste de Cuir", 30.0, 50.0, typeof(Leather), "Cuir", 10, 1044287);
            AddCraft(typeof(VestePoil), "Toges & Manteaux", "Veste de Poil", 40.0, 60.0, typeof(Leather), "Cuir", 12, 1044287);
            AddCraft(typeof(Veste), "Toges & Manteaux", "Veste", 60.0, 80.0, typeof(Cloth), "Coton", 12, 1044287);
            AddCraft(typeof(VesteLourde), "Toges & Manteaux", "Veste Ample", 70.0, 90.0, typeof(Cloth), "Coton", 12, 1044287);

            AddCraft(typeof(Surcoat), "Tuniques & Chemises", "Surcot", 30.0, 60.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(TabarCourt), "Tuniques & Chemises", "Tabar Court", 50.0, 80.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(TabarReligieux), "Tuniques & Chemises", "Tabar Religieux", 70.0, 90.0, typeof(Cloth), "Coton", 14, 1044287);
            AddCraft(typeof(TabarLong), "Tuniques & Chemises", "Tabar Long", 80.0, 100.0, typeof(Cloth), "Coton", 18, 1044287);


			/*if ( Core.AOS )
			{
                AddCraft(typeof(FurCape), 1015269, 1028969, 35.0, 60.0, typeof(Cloth), "Coton", 13, 1044287);
                AddCraft(typeof(GildedDress), 1015269, 1028973, 37.5, 62.5, typeof(Cloth), "Coton", 16, 1044287);
                AddCraft(typeof(FormalShirt), 1015269, 1028975, 26.0, 51.0, typeof(Cloth), "Coton", 16, 1044287);
			}*

			if( Core.SE )
			{
				index = AddCraft( typeof( ClothNinjaJacket ), 1015269, 1030207, 75.0, 100.0, typeof( Cloth ), 1044286, 12, 1044287 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( Kamishimo ), 1015269, 1030212, 75.0, 100.0, typeof( Cloth ), 1044286, 15, 1044287 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( HakamaShita ), 1015269, 1030215, 40.0, 65.0, typeof( Cloth ), 1044286, 14, 1044287 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( MaleKimono ), 1015269, 1030189, 50.0, 75.0, typeof( Cloth ), 1044286, 16, 1044287 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( FemaleKimono ), 1015269, 1030190, 50.0, 75.0, typeof( Cloth ), 1044286, 16, 1044287 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( JinBaori ), 1015269, 1030220, 30.0, 55.0, typeof( Cloth ), 1044286, 12, 1044287 );
				SetNeededExpansion( index, Expansion.SE );
			}*/

			#endregion

			#region Pants
            AddCraft(typeof(PantalonsDechires), "Pantalons & Jupes", "Pantalons Déchirés", 0.0, 10.0, typeof(Cloth), "Coton", 5, 1044287);
            AddCraft(typeof(PantalonsPauvre), "Pantalons & Jupes", "Pantalons Pauvres", 0.0, 10.0, typeof(Cloth), "Coton", 6, 1044287);

            AddCraft(typeof(ShortPants), "Pantalons & Jupes", "Pantalons Courts", 5.0, 20.0, typeof(Cloth), "Coton", 6, 1044287);
            AddCraft(typeof(LongPants), "Pantalons & Jupes", "Pantalons Longs", 10.0, 30.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(PantalonsOuvert), "Pantalons & Jupes", "Pantalons Ouvert", 20.0, 50.0, typeof(Cloth), "Coton", 9, 1044287);
            AddCraft(typeof(PantalonsOrient), "Pantalons & Jupes", "Pantalons d'Orient", 30.0, 60.0, typeof(Cloth), "Coton", 9, 1044287);
            AddCraft(typeof(PantalonsNordique), "Pantalons & Jupes", "Pantalons Nordiques", 40.0, 70.0, typeof(Cloth), "Coton", 9, 1044287);
            AddCraft(typeof(PantalonsNomade), "Pantalons & Jupes", "Pantalons de Nomades", 40.0, 70.0, typeof(Cloth), "Coton", 9, 1044287);
            AddCraft(typeof(Pantalons), "Pantalons & Jupes", "Pantalons Simples", 50.0, 80.0, typeof(Cloth), "Coton", 9, 1044287);
            AddCraft(typeof(PantalonsCourts), "Pantalons & Jupes", "Pantalons Amples Courts", 50.0, 80.0, typeof(Cloth), "Coton", 7, 1044287);
            AddCraft(typeof(PantalonsLongs), "Pantalons & Jupes", "Pantalons Amples Longs", 60.0, 90.0, typeof(Cloth), "Coton", 9, 1044287);
            AddCraft(typeof(PantalonsCuir), "Pantalons & Jupes", "Pantalons de Cuir", 70.0, 100.0, typeof(Leather), "Cuir", 8, 1044287);
            AddCraft(typeof(PantalonsMoulant), "Pantalons & Jupes", "Pantalons Moulants", 80.0, 110.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(PantalonsArmure), "Pantalons & Jupes", "Pantalons Armuré", 90.0, 120.0, typeof(Leather), "Cuir", 9, 1044287);

            AddCraft(typeof(Kilt), "Pantalons & Jupes", "Kilt", 10.0, 30.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(TuniqueKilt), "Pantalons & Jupes", "Long Kilt", 30.0, 50.0, typeof(Cloth), "Coton", 12, 1044287);

            AddCraft(typeof(JupeOuvrier), "Pantalons & Jupes", "Jupe Dechiré", 0.0, 10.0, typeof(Cloth), "Coton", 3, 1044287);
            AddCraft(typeof(Jupette), "Pantalons & Jupes", "Jupette", 5.0, 20.0, typeof(Cloth), "Coton", 4, 1044287);
            AddCraft(typeof(JupeCourte), "Pantalons & Jupes", "Jupe Courte", 10.0, 30.0, typeof(Cloth), "Coton", 4, 1044287);
            AddCraft(typeof(Skirt), "Pantalons & Jupes", "Jupe Simple", 20.0, 40.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(Jupe), "Pantalons & Jupes", "Jupe", 20.0, 50.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(JupeHakama), "Pantalons & Jupes", "Hakama", 30.0, 60.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(JupeCourteBarbare), "Pantalons & Jupes", "Jupe Courte Barbare", 30.0, 60.0, typeof(Leather), "Cuir", 4, 1044287);
            AddCraft(typeof(JupeLongueBarbare), "Pantalons & Jupes", "Jupe Longue Barbare", 30.0, 60.0, typeof(Leather), "Cuir", 6, 1044287);
            AddCraft(typeof(JupeCuir), "Pantalons & Jupes", "Jupe de Cuir", 40.0, 70.0, typeof(Leather), "Cuir", 6, 1044287);
            AddCraft(typeof(JupeOrcish), "Pantalons & Jupes", "Jupe Orcish", 40.0, 70.0, typeof(Leather), "Cuir", 6, 1044287);
            AddCraft(typeof(JupeNomade), "Pantalons & Jupes", "Jupe Nomade", 40.0, 70.0, typeof(Leather), "Cuir", 6, 1044287);
            AddCraft(typeof(JupeOuverte), "Pantalons & Jupes", "Jupe Ouverte", 50.0, 80.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(JupeDecore), "Pantalons & Jupes", "Jupe Decoré", 50.0, 80.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(JupeLongue), "Pantalons & Jupes", "Jupe Longue", 60.0, 90.0, typeof(Cloth), "Coton", 12, 1044287);
            AddCraft(typeof(JupeAPans), "Pantalons & Jupes", "Jupe a Pans", 60.0, 90.0, typeof(Cloth), "Coton", 12, 1044287);
            AddCraft(typeof(JupeOrient), "Pantalons & Jupes", "Jupe d'Orient", 70.0, 100.0, typeof(Cloth), "Coton", 12, 1044287);
            AddCraft(typeof(JupeAmple), "Pantalons & Jupes", "Jupe Ample", 70.0, 100.0, typeof(Cloth), "Coton", 12, 1044287);
            AddCraft(typeof(JupeGrande), "Pantalons & Jupes", "Grande Jupe", 80.0, 110.0, typeof(Cloth), "Coton", 13, 1044287);
            AddCraft(typeof(JupeBordel), "Pantalons & Jupes", "Jupe de Bordel", 80.0, 110.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(JupeNoble), "Pantalons & Jupes", "Jupe Noble", 90.0, 120.0, typeof(Cloth), "Coton", 13, 1044287);


			//if ( Core.AOS )
			//	AddCraft( typeof( FurSarong ), 1015279, 1028971, 35.0, 60.0, typeof( Cloth ), 1044286, 12, 1044287 );

			if( Core.SE )
			{
				index = AddCraft( typeof( Hakama ), 1015279, 1030213, 50.0, 75.0, typeof( Cloth ), 1044286, 16, 1044287 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( TattsukeHakama ), 1015279, 1030214, 50.0, 75.0, typeof( Cloth ), 1044286, 16, 1044287 );
				SetNeededExpansion( index, Expansion.SE );
			}

			#endregion

			#region Misc
            AddCraft(typeof(BodySash), "Accessoires", "Ceinture de Torse", 0.0, 10.0, typeof(Cloth), "Coton", 4, 1044287);
            AddCraft(typeof(Cocarde), "Accessoires", "Cocarde", 20.0, 40.0, typeof(Cloth), "Coton", 5, 1044287);
            AddCraft(typeof(CeintureTorseGrande), "Accessoires", "Large Ceinture de Torse", 30.0, 50.0, typeof(Cloth), "Coton", 8, 1044287);

            AddCraft(typeof(HalfApron), "Accessoires", "Demi-Tablier", 10.0, 30.0, typeof(Cloth), "Coton", 6, 1044287);
            AddCraft(typeof(FullApron), "Accessoires", "Tablier", 25.0, 45.0, typeof(Cloth), "Coton", 10, 1044287);
            AddCraft(typeof(TablierBarbare), "Accessoires", "Tablier Barbare", 40.0, 50.0, typeof(Cloth), "Coton", 10, 1044287);

            AddCraft(typeof(SousVetement), "Accessoires", "Sous-Vetement", 10.0, 30.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(JartellesBlanches), "Accessoires", "Jartelles", 25.0, 45.0, typeof(Cloth), "Coton", 11, 1044287);
            AddCraft(typeof(JartellesNoir), "Accessoires", "Jartelles Sombres", 30.0, 50.0, typeof(Cloth), "Coton", 11, 1044287);
            AddCraft(typeof(Jartelles), "Accessoires", "Jartelles Complètes", 40.0, 60.0, typeof(Cloth), "Coton", 14, 1044287);

            AddCraft(typeof(CeinturePauvre), "Accessoires", "Ceinture Pauvre", 0.0, 20.0, typeof(Leather), "Cuir", 4, 1044287);
            AddCraft(typeof(Bourse), "Accessoires", "Bourse", 10.0, 30.0, typeof(Leather), "Cuir", 2, 1044287);
            AddCraft(typeof(Ceinture), "Accessoires", "Ceinture Simple", 20.0, 40.0, typeof(Leather), "Cuir", 3, 1044287);
            AddCraft(typeof(CeintureBourse), "Accessoires", "Ceinture Bourse", 20.0, 40.0, typeof(Leather), "Cuir", 4, 1044287);
            AddCraft(typeof(CeintureBoucle), "Accessoires", "Ceinture Bouclé", 30.0, 50.0, typeof(Leather), "Cuir", 4, 1044287);
            AddCraft(typeof(CeintureCuir), "Accessoires", "Ceinture de Cuir", 40.0, 70.0, typeof(Leather), "Cuir", 5, 1044287);
            AddCraft(typeof(CeinturePendante), "Accessoires", "Ceinture Pendante", 50.0, 80.0, typeof(Leather), "Cuir", 6, 1044287);
            AddCraft(typeof(CeintureNordique), "Accessoires", "Ceinture Nordique", 60.0, 90.0, typeof(Leather), "Cuir", 4, 1044287);
            AddCraft(typeof(CeintureLongue), "Accessoires", "Ceinture Longue", 70.0, 100.0, typeof(Leather), "Cuir", 8, 1044287);

            AddCraft(typeof(Carquois), "Accessoires", "Carquois", 30.0, 60.0, typeof(Leather), "Cuir", 8, 1044287);
            AddCraft(typeof(Fourreau), "Accessoires", "Fourreau", 30.0, 60.0, typeof(Leather), "Cuir", 8, 1044287);
            AddCraft(typeof(FourreauDos), "Accessoires", "Fourreau de Dos", 30.0, 60.0, typeof(Leather), "Cuir", 8, 1044287);
            AddCraft(typeof(FourreauDague), "Accessoires", "Fourreau à Dague", 40.0, 70.0, typeof(Leather), "Cuir", 5, 1044287);
            AddCraft(typeof(FourreauDecouvert), "Accessoires", "Fourreau à Découvert", 50.0, 80.0, typeof(Leather), "Cuir", 5, 1044287);
            AddCraft(typeof(FourreauRapiere), "Accessoires", "Fourreau d'Estoc", 60.0, 90.0, typeof(Leather), "Cuir", 5, 1044287);
            AddCraft(typeof(FourreauEpee), "Accessoires", "Fourreau à Épées", 60.0, 90.0, typeof(Leather), "Cuir", 5, 1044287);
            AddCraft(typeof(FourreauSabre), "Accessoires", "Fourreau à Sabres", 70.0, 100.0, typeof(Leather), "Cuir", 5, 1044287);

            AddCraft(typeof(SacocheCeinture), "Accessoires", "Ceinture Double", 30.0, 50.0, typeof(Leather), "Cuir", 6, 1044287);
            AddCraft(typeof(SacocheHerboriste), "Accessoires", "Sacoche d'Herboriste", 40.0, 60.0, typeof(Leather), "Cuir", 5, 1044287);
            AddCraft(typeof(SacocheRoublard), "Accessoires", "Sacoche de Roublard", 50.0, 70.0, typeof(Leather), "Cuir", 6, 1044287);
            AddCraft(typeof(SacocheAventure), "Accessoires", "Sacoche d'Aventurier", 60.0, 80.0, typeof(Leather), "Cuir", 6, 1044287);

            AddCraft(typeof(Pardessus), "Accessoires", "Pardessus", 20.0, 40.0, typeof(Leather), "Cuir", 6, 1044287);
            AddCraft(typeof(PardessusBarbare), "Accessoires", "Pardessus Barbare", 40.0, 60.0, typeof(Leather), "Cuir", 6, 1044287);
            AddCraft(typeof(EpauliereBarbare), "Accessoires", "Épaulière Barbare", 60.0, 80.0, typeof(Leather), "Cuir", 8, 1044287);
            
            AddCraft(typeof(Bracer), "Accessoires", "Bracer", 30.1, 50.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(BrassardsFeminins), "Accessoires", "Brassards Feminins", 40.0, 60.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(BrassardsCommun), "Accessoires", "Brassards", 50.0, 70.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(BrassardsSimples), "Accessoires", "Brassards Simples", 60.0, 80.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(GantsSombres), "Accessoires", "Gants Sombres", 70.0, 90.0, typeof(Cloth), "Coton", 6, 1044287);

            AddCraft(typeof(Foulard), "Accessoires", "Foulard", 20.0, 40.0, typeof(Cloth), "Coton", 4, 1044287);
            AddCraft(typeof(CagouleGorget), "Accessoires", "Petite Cagoule", 30.0, 50.0, typeof(Cloth), "Coton", 3, 1044287);
            AddCraft(typeof(FoulardProtecteur), "Accessoires", "Foulard Protecteur", 30.0, 50.0, typeof(Cloth), "Coton", 7, 1044287);
            AddCraft(typeof(FoulardNoble), "Accessoires", "Foulard Noble", 40.0, 60.0, typeof(Cloth), "Coton", 4, 1044287);
            AddCraft(typeof(CagouleCuir), "Accessoires", "Cagoule de Cuir", 50.0, 70.0, typeof(Leather), "Cuir", 3, 1044287);
            AddCraft(typeof(Cagoule), "Accessoires", "Cagoule", 50.0, 70.0, typeof(Cloth), "Coton", 7, 1044287);
            AddCraft(typeof(Capuche), "Accessoires", "Capuche", 60.0, 80.0, typeof(Cloth), "Coton", 8, 1044287);
            AddCraft(typeof(CapucheGrande), "Accessoires", "Grande Capuche", 60.0, 80.0, typeof(Cloth), "Coton", 9, 1044287);
            AddCraft(typeof(CagouleGrande), "Accessoires", "Grande Cagoule", 70.0, 90.0, typeof(Cloth), "Coton", 9, 1044287);

            AddCraft(typeof(Plume), "Accessoires", "Plume", 0.0, 0.0, typeof(Feather), "Plume", 1, 1044287);
            AddCraft(typeof(BandagesBras), "Accessoires", "Bandages de Bras", 10.0, 30.0, typeof(Cloth), "Coton", 2, 1044287);
            AddCraft(typeof(BandagesTorse), "Accessoires", "Bandages de Torse", 20.0, 40.0, typeof(Cloth), "Coton", 3, 1044287);
            AddCraft(typeof(BandagesJambes), "Accessoires", "Bandages de Jambes", 30.0, 50.0, typeof(Cloth), "Coton", 4, 1044287);

            AddCraft(typeof(BandeauDroit), "Accessoires", "Bandeau d'Oeil Droit", 10.0, 30.0, typeof(Cloth), "Coton", 4, 1044287);
            AddCraft(typeof(BandeauAveugle), "Accessoires", "Bandeau d'Aveugle", 10.0, 30.0, typeof(Cloth), "Coton", 4, 1044287);
            AddCraft(typeof(BandeauGauche), "Accessoires", "Bandeau d'Oeil Gauche", 10.0, 30.0, typeof(Cloth), "Coton", 4, 1044287);

			/*if( Core.SE )
			{
				index = AddCraft( typeof( Obi ), 1015283, 1030219, 20.0, 45.0, typeof( Cloth ), 1044286, 6, 1044287 );
				SetNeededExpansion( index, Expansion.SE );
			}

			if( Core.ML )
			{
				index = AddCraft( typeof( ElvenQuiver ), 1015283, 1032657, 65.0, 115.0, typeof( Leather ), 1044462, 28, 1044463 );
				AddRecipe( index, 501 );
				SetNeededExpansion( index, Expansion.ML );

				index = AddCraft( typeof( QuiverOfFire ), 1015283, 1073109, 65.0, 115.0, typeof( Leather ), 1044462, 28, 1044463 );
				AddRes( index, typeof( FireRuby ), 1032695, 15, 1042081 );
				AddRecipe( index, 502 );
				SetNeededExpansion( index, Expansion.ML );

				index = AddCraft( typeof( QuiverOfIce ), 1015283, 1073110, 65.0, 115.0, typeof( Leather ), 1044462, 28, 1044463 );
				AddRes( index, typeof( WhitePearl ), 1032694, 15, 1042081 );
				AddRecipe( index, 503 );
				SetNeededExpansion( index, Expansion.ML );

				index = AddCraft( typeof( QuiverOfBlight ), 1015283, 1073111, 65.0, 115.0, typeof( Leather ), 1044462, 28, 1044463 );
				AddRes( index, typeof( Blight ), 1032675, 10, 1042081 );
				AddRecipe( index, 504 );
				SetNeededExpansion( index, Expansion.ML );

				index = AddCraft( typeof( QuiverOfLightning ), 1015283, 1073112, 65.0, 115.0, typeof( Leather ), 1044462, 28, 1044463 );
				AddRes( index, typeof( Corruption ), 1032676, 10, 1042081 );
				AddRecipe( index, 505 );
				SetNeededExpansion( index, Expansion.ML );
			}

			AddCraft( typeof( OilCloth ), 1015283, 1041498, 74.6, 99.6, typeof( Cloth ), 1044286, 1, 1044287 );

			if( Core.SE )
			{
				index = AddCraft( typeof( GozaMatEastDeed ), 1015283, 1030404, 55.0, 80.0, typeof( Cloth ), 1044286, 25, 1044287 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( GozaMatSouthDeed ), 1015283, 1030405, 55.0, 80.0, typeof( Cloth ), 1044286, 25, 1044287 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( SquareGozaMatEastDeed ), 1015283, 1030407, 55.0, 80.0, typeof( Cloth ), 1044286, 25, 1044287 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( SquareGozaMatSouthDeed ), 1015283, 1030406, 55.0, 80.0, typeof( Cloth ), 1044286, 25, 1044287 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( BrocadeGozaMatEastDeed ), 1015283, 1030408, 55.0, 80.0, typeof( Cloth ), 1044286, 25, 1044287 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( BrocadeGozaMatSouthDeed ), 1015283, 1030409, 55.0, 80.0, typeof( Cloth ), 1044286, 25, 1044287 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( BrocadeSquareGozaMatEastDeed ), 1015283, 1030411, 55.0, 80.0, typeof( Cloth ), 1044286, 25, 1044287 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( BrocadeSquareGozaMatSouthDeed ), 1015283, 1030410, 55.0, 80.0, typeof( Cloth ), 1044286, 25, 1044287 );
				SetNeededExpansion( index, Expansion.SE );
			}*/

			#endregion

			#region Footwear
            /*if ( Core.AOS )
				AddCraft( typeof( FurBoots ), 1015288, 1028967, 50.0, 75.0, typeof( Cloth ), 1044286, 12, 1044287 );

			if( Core.SE )
			{
				index = AddCraft( typeof( NinjaTabi ), 1015288, 1030210, 70.0, 95.0, typeof( Cloth ), 1044286, 10, 1044287 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( SamuraiTabi ), 1015288, 1030209, 20.0, 45.0, typeof( Cloth ), 1044286, 6, 1044287 );
				SetNeededExpansion( index, Expansion.SE );
			}*/

            AddCraft(typeof(Sandals), "Chassures", "Sandales", 10.0, 20.0, typeof(Leather), "Cuir", 4, 1044463);
            AddCraft(typeof(Geta), "Chassures", "Geta", 20.0, 30.0, typeof(Leather), "Cuir", 5, 1044463);

            AddCraft(typeof(Shoes), "Chassures", "Souliers", 30.0, 50.0, typeof(Leather), "Cuir", 6, 1044463);
            //AddCraft(typeof(SouliersFourrure), "Chassures", "Souliers Fourrure", 16.5, 41.5, typeof(Leather), "Cuir", 8, 1044463);
            AddCraft(typeof(SouliersBoucles), "Chassures", "Souliers Bouclés", 50.0, 70.0, typeof(Leather), "Cuir", 7, 1044463);

            AddCraft(typeof(BottesPetites), "Chassures", "Petites Bottes", 30.0, 50.0, typeof(Leather), "Cuir", 6, 1044463);
            AddCraft(typeof(Boots), "Chassures", "Bottes", 40.0, 60.0, typeof(Leather), "Cuir", 8, 1044463);
            AddCraft(typeof(ThighBoots), "Chassures", "Bottes Longues", 50.0, 70.0, typeof(Leather), "Cuir", 14, 1044463);
            AddCraft(typeof(BottesBoucles), "Chassures", "Bottes Bouclés", 60.0, 80.0, typeof(Leather), "Cuir", 8, 1044463);
            AddCraft(typeof(Bottes), "Chassures", "Bottes Simples", 60.0, 80.0, typeof(Leather), "Cuir", 8, 1044463);
            AddCraft(typeof(BottesVoyage), "Chassures", "Bottes de Voyage", 60.0, 80.0, typeof(Leather), "Cuir", 8, 1044463);
            AddCraft(typeof(BottesLourdes), "Chassures", "Bottes Lourdes", 70.0, 90.0, typeof(Leather), "Cuir", 12, 1044463);
            AddCraft(typeof(BottesNoble), "Chassures", "Bottes Nobles", 70.0, 90.0, typeof(Leather), "Cuir", 12, 1044463);
            AddCraft(typeof(BottesFourrure), "Chassures", "Bottes Fourrure", 80.0, 100.0, typeof(Leather), "Cuir", 10, 1044463);
            AddCraft(typeof(BottesSombres), "Chassures", "Bottes Sombres", 90.0, 120.0, typeof(Leather), "Cuir", 16, 1044463);

			#endregion

			#region Leather Armor

            AddCraft(typeof(LeatherGorget), "Armure de Cuir", "Gants de Cuir", 30.0, 50.0, typeof(Leather), "Cuir", 4, 1044463);
            AddCraft(typeof(LeatherCap), "Armure de Cuir", "Casque de Cuir", 30.0, 50.0, typeof(Leather), "Cuir", 2, 1044463);
            AddCraft(typeof(LeatherGloves), "Armure de Cuir", "Gants de Cuir", 30.0, 50.0, typeof(Leather), "Cuir", 3, 1044463);
            AddCraft(typeof(LeatherArms), "Armure de Cuir", "Brassards de Cuir", 30.0, 50.0, typeof(Leather), "Cuir", 4, 1044463);
            AddCraft(typeof(LeatherLegs), "Armure de Cuir", "Jambières de Cuir", 30.0, 50.0, typeof(Leather), "Cuir", 10, 1044463);
            AddCraft(typeof(LeatherChest), "Armure de Cuir", "Plastron de Cuir", 30.0, 50.0, typeof(Leather), "Cuir", 12, 1044463);
            AddCraft(typeof(LeatherShorts), "Armure de Cuir", "Jupe de Cuir", 30.0, 50.0, typeof(Leather), "Cuir", 8, 1044463);
            AddCraft(typeof(LeatherSkirt), "Armure de Cuir", "Jupette de Cuir", 30.0, 50.0, typeof(Leather), "Cuir", 6, 1044463);
            AddCraft(typeof(LeatherBustierArms), "Armure de Cuir", "Brassards Féminins", 30.0, 50.0, typeof(Leather), "Cuir", 6, 1044463);
            AddCraft(typeof(FemaleLeatherChest), "Armure de Cuir", "Cuirasse Féminine", 30.0, 50.0, typeof(Leather), "Cuir", 8, 1044463);
            AddCraft(typeof(LeatherBarbareLeggings), "Armure de Cuir", "Jambière de Cuir Barbare", 50.0, 70.0, typeof(Leather), "Cuir", 10, 1044463);
            AddCraft(typeof(LeatherBarbareTunic), "Armure de Cuir", "Plastron de Cuir Barbare", 50.0, 70.0, typeof(Leather), "Cuir", 12, 1044463);
            AddCraft(typeof(RoublardLeggings), "Armure de Cuir", "Jambières Roublardes", 70.0, 90.0, typeof(Leather), "Cuir", 10, 1044463);
            AddCraft(typeof(RoublardTunic), "Armure de Cuir", "Plastron Roublard", 70.0, 90.0, typeof(Leather), "Cuir", 12, 1044463);
            AddCraft(typeof(ElfiqueCuirTunic), "Armure de Cuir", "Plastron de Cuir Elfique", 75.0, 95.0, typeof(Leather), "Cuir", 12, 1044463);
            AddCraft(typeof(ElfiqueCuirRobe), "Armure de Cuir", "Vetement de Cuir Elfique", 75.0, 95.0, typeof(Leather), "Cuir", 14, 1044463);


			if( Core.SE )
			{
				index = AddCraft( typeof( LeatherJingasa ), 1015293, 1030177, 45.0, 70.0, typeof( Leather ), 1044462, 4, 1044463 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( LeatherMempo ), 1015293, 1030181, 80.0, 105.0, typeof( Leather ), 1044462, 8, 1044463 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( LeatherDo ), 1015293, 1030182, 75.0, 100.0, typeof( Leather ), 1044462, 12, 1044463 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( LeatherHiroSode ), 1015293, 1030185, 55.0, 80.0, typeof( Leather ), 1044462, 5, 1044463 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( LeatherSuneate ), 1015293, 1030193, 68.0, 93.0, typeof( Leather ), 1044462, 12, 1044463 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( LeatherHaidate ), 1015293, 1030197, 68.0, 93.0, typeof( Leather ), 1044462, 12, 1044463 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( LeatherNinjaPants ), 1015293, 1030204, 80.0, 105.0, typeof( Leather ), 1044462, 13, 1044463 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( LeatherNinjaJacket ), 1015293, 1030206, 85.0, 110.0, typeof( Leather ), 1044462, 13, 1044463 );
				SetNeededExpansion( index, Expansion.SE );
				//index = AddCraft( typeof( LeatherNinjaBelt ), 1015293, 1030203, 50.0, 75.0, typeof( Leather ), 1044462, 5, 1044463 );
				//SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( LeatherNinjaMitts ), 1015293, 1030205, 65.0, 90.0, typeof( Leather ), 1044462, 12, 1044463 );
				SetNeededExpansion( index, Expansion.SE );
				index = AddCraft( typeof( LeatherNinjaHood ), 1015293, 1030201, 90.0, 115.0, typeof( Leather ), 1044462, 14, 1044463 );
				SetNeededExpansion( index, Expansion.SE );
			}

			#endregion

			#region Studded Armor
            AddCraft(typeof(StuddedGorget), "Armure de Cuir Clouté", "Gorget de Cuir Clouté", 50.0, 70.0, typeof(Leather), "Cuir", 6, 1044463);
            AddCraft(typeof(StuddedGloves), "Armure de Cuir Clouté", "Gants de Cuir Clouté", 50.0, 70.0, typeof(Leather), "Cuir", 8, 1044463);
            AddCraft(typeof(StuddedArms), "Armure de Cuir Clouté", "Brassards de Cuir Clouté", 50.0, 70.0, typeof(Leather), "Cuir", 10, 1044463);
            AddCraft(typeof(StuddedLegs), "Armure de Cuir Clouté", "Jambières de Cuir Clouté", 50.0, 70.0, typeof(Leather), "Cuir", 12, 1044463);
            AddCraft(typeof(StuddedChest), "Armure de Cuir Clouté", "Plastron de Cuir Clouté", 50.0, 70.0, typeof(Leather), "Cuir", 14, 1044463);
            AddCraft(typeof(StuddedBustierArms), "Armure de Cuir Clouté", "Brassards Féminins", 50.0, 70.0, typeof(Leather), "Cuir", 8, 1044463);
            AddCraft(typeof(FemaleStuddedChest), "Armure de Cuir Clouté", "Cuirasse Féminine", 50.0, 70.0, typeof(Leather), "Cuir", 10, 1044463);
            index = AddCraft(typeof(ElfeHelm), "Armure de Cuir Clouté", "Casque de Feuilles", 50.0, 80.0, typeof(Leather), "Cuir", 3, 1044463);
            AddRes(index, typeof(Log), "Bûche", 2, 1044563);
            index = AddCraft(typeof(ElfeGorget), "Armure de Cuir Clouté", "Gorget de Feuilles", 50.0, 80.0, typeof(Leather), "Cuir", 3, 1044463);
            AddRes(index, typeof(Log), "Bûche", 2, 1044563);
            index = AddCraft(typeof(ElfeArms), "Armure de Cuir Clouté", "Brassards de Feuilles", 50.0, 80.0, typeof(Leather), "Cuir", 3, 1044463);
            AddRes(index, typeof(Log), "Bûche", 2, 1044563);
            index = AddCraft(typeof(ElfeLeggings), "Armure de Cuir Clouté", "Jambières de Feuilles", 50.0, 80.0, typeof(Leather), "Cuir", 3, 1044463);
            AddRes(index, typeof(Log), "Bûche", 2, 1044563);
            index = AddCraft(typeof(ElfeTunic), "Armure de Cuir Clouté", "Tunique de Feuilles", 50.0, 80.0, typeof(Leather), "Cuir", 3, 1044463);
            AddRes(index, typeof(Log), "Bûche", 2, 1044563);
            AddCraft(typeof(StuddedBarbareGreaves), "Armure de Cuir Clouté", "Gorget de Cuir Clouté Barbare", 60.0, 80.0, typeof(Leather), "Cuir", 10, 1044463);
            AddCraft(typeof(StuddedBarbareGorget), "Armure de Cuir Clouté", "Gants de Cuir Clouté Barbare", 60.0, 80.0, typeof(Leather), "Cuir", 6, 1044463);
            AddCraft(typeof(StuddedBarbareLeggings), "Armure de Cuir Clouté", "Brassards de Cuir Clouté Barbare",60.0, 80.0, typeof(Leather), "Cuir", 12, 1044463);
            AddCraft(typeof(StuddedBarbareTunic), "Armure de Cuir Clouté", "Jambières de Cuir Clouté Barbare", 60.0, 80.0, typeof(Leather), "Cuir", 14, 1044463);

			#endregion

			#region Bone Armor
			/*index = AddCraft( typeof( BoneHelm ), 1049149, 1025206, 85.0, 110.0, typeof( Leather ), 1044462, 4, 1044463 );
			AddRes( index, typeof( Bone ), 1049064, 2, 1049063 );
			
			index = AddCraft( typeof( BoneGloves ), 1049149, 1025205, 89.0, 114.0, typeof( Leather ), 1044462, 6, 1044463 );
			AddRes( index, typeof( Bone ), 1049064, 2, 1049063 );

			index = AddCraft( typeof( BoneArms ), 1049149, 1025203, 92.0, 117.0, typeof( Leather ), 1044462, 8, 1044463 );
			AddRes( index, typeof( Bone ), 1049064, 4, 1049063 );

			index = AddCraft( typeof( BoneLegs ), 1049149, 1025202, 95.0, 120.0, typeof( Leather ), 1044462, 10, 1044463 );
			AddRes( index, typeof( Bone ), 1049064, 6, 1049063 );
		
			index = AddCraft( typeof( BoneChest ), 1049149, 1025199, 96.0, 121.0, typeof( Leather ), 1044462, 12, 1044463 );
			AddRes( index, typeof( Bone ), 1049064, 10, 1049063 );

			index = AddCraft(typeof(OrcHelm), 1049149, 1027947, 90.0, 115.0, typeof(Leather), 1044462, 6, 1044463);
			AddRes(index, typeof(Bone), 1049064, 4, 1049063);*/
			#endregion

			// Set the overridable material
			SetSubRes( typeof( Leather ), "Cuir" );

			// Add every material you want the player to be able to choose from
			// This will override the overridable material
			AddSubRes( typeof( Leather ),		"Cuir", 00.0, 1049311 );
            AddSubRes(typeof(ReptilienLeather), "Cuir Reptilien", 20.0, 1049311);
            AddSubRes(typeof(NordiqueLeather), "Cuir Nordique", 20.0, 1049311);
            AddSubRes(typeof(DesertiqueLeather), "Cuir Désertique", 30.0, 1049311);
            AddSubRes(typeof(MaritimeLeather), "Cuir Maritime", 40.0, 1049311);
            AddSubRes(typeof(VolcaniqueLeather), "Cuir Volcanique", 50.0, 1049311);
            AddSubRes(typeof(GeantLeather), "Cuir Géant", 50.0, 1049311);
            AddSubRes(typeof(MinotaureLeather), "Cuir Minotaure", 50.0, 1049311);
            AddSubRes(typeof(OphidienLeather), "Cuir Ophidien", 60.0, 1049311);
            AddSubRes(typeof(ArachnideLeather), "Cuir Arachnide", 60.0, 1049311);
            AddSubRes(typeof(MagiqueLeather), "Cuir Magique", 60.0, 1049311);
            AddSubRes(typeof(AncienLeather), "Cuir Ancien", 70.0, 1049311);
            AddSubRes(typeof(DemoniaqueLeather), "Cuir Demoniaque", 80.0, 1049311);
            AddSubRes(typeof(DragoniqueLeather), "Cuir Dragonique", 90.0, 1049311);
            AddSubRes(typeof(LupusLeather), "Cuir Lupus", 100.0, 1049311);
			/*AddSubRes( typeof( SpinedLeather ),	1049151, 65.0, 1044462, 1049311 );
			AddSubRes( typeof( HornedLeather ),	1049152, 80.0, 1044462, 1049311 );
			AddSubRes( typeof( BarbedLeather ),	1049153, 99.0, 1044462, 1049311 );*/

			MarkOption = true;
			Repair = Core.AOS;
			CanEnhance = Core.AOS;
		}
	}
}