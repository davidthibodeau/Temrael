using System;
using System.IO;
using System.Reflection;
using Server;
using Server.Items;

namespace Server
{
	public class Loot
	{
		#region List definitions

		private static Type[] m_AosWeaponTypes = new Type[]
			{
				typeof( Scythe ),				//typeof( BoneHarvester ),		typeof( Scepter ),
				//typeof( BladedStaff ),			typeof( Pike ),					typeof( DoubleBladedStaff ),
				typeof( Lance )				//typeof( CrescentBlade )
			};

		public static Type[] AosWeaponTypes{ get{ return m_AosWeaponTypes; } }

		private static Type[] m_WeaponTypes = new Type[]
			{
				typeof( Axe ),					typeof( DoubleAxe ),
				typeof( ExecutionersAxe ),		typeof( LargeBattleAxe ),
				typeof( TwoHandedAxe ),			typeof( WarAxe ),				typeof( Club ),
				typeof( Mace ),					typeof( Maul ),					typeof( WarHammer ),
				typeof( WarMace ),				typeof( Bardiche ),				typeof( Halberd ),
				typeof( Spear ),				typeof( ShortSpear ),			typeof( Pitchfork ),
				typeof( WarFork ),				typeof( BlackStaff ),			typeof( GnarledStaff ),
                typeof( QuarterStaff ),			typeof( Cutlass ),              typeof( Longsword ),
				typeof( Scimitar ),				typeof( VikingSword ),			typeof( Pickaxe ),
				typeof( ButcherKnife ),			typeof( Cleaver ),
				typeof( Dagger ),				typeof( SkinningKnife ),		typeof( ShepherdsCrook )
			};

		public static Type[] WeaponTypes{ get{ return m_WeaponTypes; } }

        private static Type[] m_TemraelWeaponTypes = new Type[]
			{
                typeof( Astoria ),   typeof( Vorlame ),   typeof( Biliome ),   typeof( Rodere ),
                typeof( Dravene ),   typeof( Vifcoupe ),   typeof( Draglast ),   typeof( Auderre ),   typeof( Batarde ),
                typeof( Tranchevil ),   typeof( Ventmore ),   typeof( Excalior ),   typeof( Conquise ),   typeof( Runire ),
                typeof( Nerfille ),   typeof( Myliron ),   typeof( Nhilarte ),   typeof( Abysse ),   typeof( Atargne ),
                typeof( Querquoise ),   typeof( Merlarme ),   typeof( Dorleane ),   typeof( Couliere ),   typeof( Dawn ),
                typeof( Lerise ),   typeof( Luminera ),   typeof( Gerumir ),   typeof( Narvegne ),   typeof( Hectmore ),

                typeof( Sabre ),   typeof( Mersang ),   typeof( Raghash ),   typeof( Prisienne ),   typeof( Cutlass ),
                typeof( Scimitar ),

                typeof( Rougegorge ),   typeof( Monarque ),   typeof( Claymore ),   typeof( VikingSword ),   typeof( Courbelle ),
                typeof( Tranchor ),   typeof( Flamberge ),   typeof( Sombrimur ),   typeof( Marquaise ),   typeof( Mortimer ),
                typeof( Espadon ),   typeof( Zweihander ),   typeof( Morsame ),   typeof( Granlame ),
                
                typeof( Mirilione ),   typeof( Niropie ),   typeof( Zarel ),   typeof( Sefrio ),   typeof( Ferel ),

                typeof( Axe ),   typeof( Luminar ),   typeof( Loragne ),   typeof( Montorgne ),   typeof( WarAxe ),
                typeof( Orcarinia ),   typeof( Minarque ),   typeof( Grochette ),   typeof( Noctame ), 

                typeof( Morgrove ),   typeof( Venmar ),   typeof( TwoHandedAxe ),   typeof( LargeBattleAxe ),   typeof( Morgate ),
                typeof( Tranchecorps ),   typeof( Elvetrine ),   typeof( Viftranche ),

                typeof( Furagne ),   typeof( Duxtranche ),   typeof( Biliane ),

                typeof( Dagger ),   typeof( Safrine ),   typeof( Dentsombre ),   typeof( Lozure ),   typeof( Serpentine ),
                typeof( Brillaume ),   typeof( Dracourbe ),   typeof( Ecorchette ),

                typeof( Poignard ),   typeof( Eblame ),   typeof( Imperlame ),

                typeof( Fleuret ),   typeof( Percille ),   typeof( Rapiere ),   typeof( Cuivardise ),   typeof( Lyzardese ),
                typeof( Estoc ),   typeof( Musareche ),   typeof( Brette ),

                typeof( Bardiche ),   typeof( Scythe ),   typeof( Vougue ),   typeof( ExecutionersAxe ),   typeof( Guisarme ),
                
                typeof( Halberd ),   typeof( Bardine ),   typeof( Hastiche ),   typeof( Granbarde ),

                typeof( Lancel ),   typeof( Spear ),   typeof( Terricharde ),   typeof( Percetronc ),   typeof( ShortSpear ),
                typeof( WarFork ),   typeof( Lance ),   typeof( DoubleLance ),   typeof( Piculame ),   typeof( Percecoeur ),

                typeof( Pique ),   typeof( Trident ),   typeof( Racuris ),   typeof( Transpercille ),   typeof( Mascarate ),
                typeof( Turione ),

                typeof( Mace ),   typeof( WarMace ),   typeof( Maul ),   typeof( Brisecrane ),   typeof( WarHammer ),
                typeof( Granmace ),   typeof( Ecraseface ),   typeof( Fleau ),   typeof( Malert ),   typeof( Defonceur ),
                
                typeof( Griffes ),   typeof( Katar ),   typeof( Katara ),

                typeof( Club ),   typeof( Gourpic ),   typeof( Gourdin ),   typeof( Batonmace ),

                typeof( ShepherdsCrook ),   typeof( QuarterStaff ),   typeof( GnarledStaff ),   typeof( Canne ),   typeof( CanneOsseux ),
                typeof( BatonVoyage ),   typeof( BatonElfique ),   typeof( Eteurfer ),   typeof( Crochire ),   typeof( Seliphore ),
                typeof( BatonSoleil ),   typeof( BatonTenebrea ),   typeof( Boulnar ),   typeof( BatonSorcier ),   typeof( BatonElement ),
                typeof( BatonDruide ),   typeof( BatonOsseux )
			};

        public static Type[] TemraelWeaponTypes { get { return m_TemraelWeaponTypes; } }

		private static Type[] m_RangedWeaponTypes = new Type[]
			{
				typeof( GrandArc ),					typeof( Crossbow ),				typeof( HeavyCrossbow )
			};

		public static Type[] RangedWeaponTypes{ get{ return m_RangedWeaponTypes; } }

        private static Type[] m_TemraelRangedWeaponTypes = new Type[]
			{
				typeof( Tarkarc ),   typeof( Legarc ),   typeof( GrandArc ),   typeof( Souplecorde ),   typeof( Sombrevent ),
                typeof( Sifflecrin ),   typeof( Chantefleche ),

                typeof( Crossbow ),   typeof( HeavyCrossbow ),   typeof( Percemurs ),   typeof( Arbavive ),   typeof( Lumitrait )
			};

        public static Type[] TemraelRangedWeaponTypes { get { return m_TemraelRangedWeaponTypes; } }

		private static Type[] m_ArmorTypes = new Type[]
			{
				typeof( BoneArms ),				typeof( BoneChest ),			typeof( BoneGloves ),
				typeof( BoneLegs ),				typeof( BoneHelm ),				typeof( ChainChest ),
				typeof( ChainLegs ),			typeof( ChainCoif ),			typeof( Bascinet ),
				typeof( CloseHelm ),			typeof( Helmet ),				typeof( NorseHelm ),
                typeof( FemaleLeatherChest ),	typeof( LeatherArms ),
				typeof( LeatherBustierArms ),	typeof( LeatherChest ),			typeof( LeatherGloves ),
				typeof( LeatherGorget ),		typeof( LeatherLegs ),			typeof( LeatherShorts ),
				typeof( LeatherSkirt ),			typeof( LeatherCap ),			typeof( FemalePlateChest ),
				typeof( PlateArms ),			typeof( PlateChest ),			typeof( PlateGloves ),
				typeof( PlateGorget ),			typeof( PlateHelm ),			typeof( PlateLegs ),
				typeof( RingmailArms ),			typeof( RingmailChest ),		typeof( RingmailGloves ),
				typeof( RingmailLegs ),			typeof( FemaleStuddedChest ),	typeof( StuddedArms ),
				typeof( StuddedBustierArms ),	typeof( StuddedChest ),			typeof( StuddedGloves ),
				typeof( StuddedGorget ),		typeof( StuddedLegs )
			};

		public static Type[] ArmorTypes{ get{ return m_ArmorTypes; } }

        private static Type[] m_TemraelArmorTypes = new Type[]
			{
                typeof( BourgeonLeggings ),				typeof( BourgeonGreaves ),			typeof( BourgeonTunic ),
                typeof( MaillonsLeggings ),				typeof( MaillonsGreaves ),			typeof( MaillonsTunic ),
                typeof( MailluresLeggings ),			typeof( MailluresGreaves ),			typeof( MailluresTunic ),
                typeof( ElfiqueChaineLeggings ),		typeof( ElfiqueChaineTunic ),		
                typeof( MaillesHelm ),				    typeof( MaillesLeggings ),			typeof( MaillesTunic ),
                typeof( ElfiquePlaqueGorget ),			typeof( ElfiquePlaqueLeggings ),	typeof( ElfiquePlaqueTunic ),
                typeof( BrassardsGothique ),			typeof( CuirasseGothique ),		    typeof( CasqueGothique ),
                typeof( PlaqueBarbareGreaves ),			typeof( PlaqueBarbareGorget ),		typeof( PlaqueBarbareLeggings ),
                typeof( PlaqueBarbareTunic ),
                typeof( BrassardsOrne ),				typeof( CuirasseOrne ),
                typeof( BrassardsDecorer ),				typeof( GantsDecorer ),			    typeof( GorgetDecorer ),
                typeof( JambieresDecorer ),				typeof( CuirasseDecorer ),			typeof( CasqueDecorer ),
                typeof( CasqueClosDecorer ),
                typeof( PlaqueChevalierGreaves ),		typeof( PlaqueChevalierGloves ),	typeof( PlaqueChevalierGorget ),
                typeof( PlaqueChevalierLeggings ),		typeof( PlaqueChevalierTunic ),		typeof( PlaqueChevalierHelm ),
                typeof( ArmureDaedricGreaves ),			typeof( ArmureDaedricGloves ),		typeof( ArmureDaedricGorget ),
                typeof( ArmureDaedricLeggings ),		typeof( ArmureDaedricTunic ),		typeof( ArmureDaedricHelm ),
                typeof( LeggingsBarbare ),				typeof( TunicBarbare ),			    
                typeof( TuniqueChaine ),				typeof( CuirasseReligieuse ),		typeof( Cuirasse ),
                typeof( CuirasseBarbare ),				typeof( CuirasseNordique ),			typeof( CuirasseDraconique ),
                typeof( CasqueNordique ),				typeof( CasqueSudiste ),			typeof( CasqueCorne ),
                typeof( Brassards ),				    typeof( BrassardsChaotique ),		
                typeof( LeatherBarbareLeggings ),		typeof( LeatherBarbareTunic ),		
                typeof( RoublardLeggings ),				typeof( RoublardTunic ),			
                typeof( ElfiqueCuirTunic ),				typeof( ElfiqueCuirRobe ),			
                typeof( StuddedBarbareGreaves ),		typeof( StuddedBarbareGorget ),		typeof( StuddedBarbareLeggings ),
                typeof( StuddedBarbareTunic )			
			};

        public static Type[] TemraelArmorTypes { get { return m_TemraelArmorTypes; } }

		private static Type[] m_AosShieldTypes = new Type[]
			{
				typeof( ChaosShield ),			typeof( OrderShield )
			};

		public static Type[] AosShieldTypes{ get{ return m_AosShieldTypes; } }

		private static Type[] m_ShieldTypes = new Type[]
			{
				typeof( BronzeShield ),			typeof( Buckler ),				typeof( HeaterShield ),
				typeof( MetalShield ),			typeof( MetalKiteShield ),		typeof( WoodenKiteShield ),
				typeof( WoodenShield )
			};

		public static Type[] ShieldTypes{ get{ return m_ShieldTypes; } }

        private static Type[] m_TemraelShieldTypes = new Type[]
			{
                typeof(BouclierElfique), typeof(BouclierCuir), typeof(BouclierNordique), 
                typeof(BouclierChevaleresque), typeof(BouclierVieux), typeof(BouclierComte), 
                typeof(BouclierMarquis), typeof(BouclierDuc), typeof(BouclierPavoisNoir),
                typeof(BouclierGarde)
			};

        public static Type[] TemraelShieldTypes { get { return m_TemraelShieldTypes; } }

		private static Type[] m_GemTypes = new Type[]
			{
				typeof( Amber ),				typeof( Amethyst ),				typeof( Citrine ),
				typeof( Diamond ),				typeof( Emerald ),				typeof( Ruby ),
				typeof( Sapphire ),				typeof( StarSapphire ),			typeof( Tourmaline )
			};

		public static Type[] GemTypes{ get{ return m_GemTypes; } }

		private static Type[] m_JewelryTypes = new Type[]
			{
				typeof( GoldRing ),				typeof( GoldBracelet ),
				typeof( SilverRing ),			typeof( SilverBracelet )
			};

		public static Type[] JewelryTypes{ get{ return m_JewelryTypes; } }

        private static Type[] m_TemraelJewelryTypes = new Type[]
			{
				typeof( BracerMetal ),			typeof( ColierCoquillages ),	typeof( ColierDents ),
                typeof( ColierNordique ),		typeof( ColierFer ),			typeof( ColierSerpantin ),
                typeof( ColierSimple ),			typeof( ColierSaphyre ),		typeof( ColierOrne ),
                typeof( ColierLong ),			typeof( ColierEmeraudes ),		typeof( ColierRubis ),
                typeof( ColierLargeRubis ),		typeof( ColierSud ),			typeof( Bijoux ),
                typeof( ColierAraignee ),		typeof( ColierTriple ),			typeof( Diaphene ),
                typeof( Couronne )				
			};

        public static Type[] TemraelJewelryTypes { get { return m_TemraelJewelryTypes; } }

		private static Type[] m_RegTypes = new Type[]
			{
				typeof( BlackPearl ),			typeof( Bloodmoss ),			typeof( Garlic ),
				typeof( Ginseng ),				typeof( MandrakeRoot ),			typeof( Nightshade ),
				typeof( SulfurousAsh ),			typeof( SpidersSilk )
			};

		public static Type[] RegTypes{ get{ return m_RegTypes; } }

		private static Type[] m_NecroRegTypes = new Type[]
			{
				typeof( BatWing ),				typeof( GraveDust ),			typeof( DaemonBlood ),
				typeof( NoxCrystal ),			typeof( PigIron )
			};

		public static Type[] NecroRegTypes{ get{ return m_NecroRegTypes; } }

		private static Type[] m_PotionTypes = new Type[]
			{
				typeof( AgilityPotion ),		typeof( StrengthPotion ),		typeof( RefreshPotion ),
				typeof( LesserCurePotion ),		typeof( LesserHealPotion ),		typeof( LesserPoisonPotion )
			};

		public static Type[] PotionTypes{ get{ return m_PotionTypes; } }

		private static Type[] m_SEInstrumentTypes = new Type[]
			{
				typeof( BambooFlute )
			};

		public static Type[] SEInstrumentTypes{ get{ return m_SEInstrumentTypes; } }

		private static Type[] m_InstrumentTypes = new Type[]
			{
				typeof( Drums ),				typeof( Harp ),					typeof( LapHarp ),
				typeof( Lute ),					typeof( Tambourine ),			typeof( TambourineTassel )
			};

		public static Type[] InstrumentTypes{ get{ return m_InstrumentTypes; } }

		private static Type[] m_StatueTypes = new Type[]
		{
			typeof( StatueSouth ),			typeof( StatueSouth2 ),			typeof( StatueNorth ),
			typeof( StatueWest ),			typeof( StatueEast ),			typeof( StatueEast2 ),
			typeof( StatueSouthEast ),		typeof( BustSouth ),			typeof( BustEast )
		};

		public static Type[] StatueTypes{ get{ return m_StatueTypes; } }

		private static Type[] m_RegularScrollTypes = new Type[]
			{
				typeof( ReactiveArmorScroll ),	typeof( ClumsyScroll ),			typeof( CreateFoodScroll ),		typeof( FeeblemindScroll ),
				typeof( HealScroll ),			typeof( MagicArrowScroll ),		typeof( NightSightScroll ),		typeof( WeakenScroll ),
				typeof( AgilityScroll ),		typeof( CunningScroll ),		typeof( CureScroll ),			typeof( HarmScroll ),
				typeof( MagicTrapScroll ),		typeof( MagicUnTrapScroll ),	typeof( ProtectionScroll ),		typeof( StrengthScroll ),
				typeof( BlessScroll ),			typeof( FireballScroll ),		typeof( MagicLockScroll ),		typeof( PoisonScroll ),
				typeof( TelekinisisScroll ),	typeof( TeleportScroll ),		typeof( UnlockScroll ),			typeof( WallOfStoneScroll ),
				typeof( ArchCureScroll ),		typeof( ArchProtectionScroll ),	typeof( CurseScroll ),			typeof( FireFieldScroll ),
				typeof( GreaterHealScroll ),	typeof( LightningScroll ),		typeof( ManaDrainScroll ),		typeof( RecallScroll ),
				typeof( BladeSpiritsScroll ),	typeof( DispelFieldScroll ),	typeof( IncognitoScroll ),		typeof( MagicReflectScroll ),
				typeof( MindBlastScroll ),		typeof( ParalyzeScroll ),		typeof( PoisonFieldScroll ),	typeof( SummonCreatureScroll ),
				typeof( DispelScroll ),			typeof( EnergyBoltScroll ),		typeof( ExplosionScroll ),		typeof( InvisibilityScroll ),
				typeof( MarkScroll ),			typeof( MassCurseScroll ),		typeof( ParalyzeFieldScroll ),	typeof( RevealScroll ),
				typeof( ChainLightningScroll ), typeof( EnergyFieldScroll ),	typeof( FlamestrikeScroll ),	typeof( GateTravelScroll ),
				typeof( ManaVampireScroll ),	typeof( MassDispelScroll ),		typeof( MeteorSwarmScroll ),	typeof( PolymorphScroll ),
				typeof( EarthquakeScroll ),		typeof( EnergyVortexScroll ),	typeof( ResurrectionScroll ),	typeof( SummonAirElementalScroll ),
				typeof( SummonDaemonScroll ),	typeof( SummonEarthElementalScroll ),	typeof( SummonFireElementalScroll ),	typeof( SummonWaterElementalScroll )
			};

		private static Type[] m_NecromancyScrollTypes = new Type[]
			{
				typeof( AnimateDeadScroll ),		typeof( BloodOathScroll ),		typeof( CorpseSkinScroll ),	typeof( CurseWeaponScroll ),
				typeof( EvilOmenScroll ),			typeof( HorrificBeastScroll ),	typeof( LichFormScroll ),	typeof( MindRotScroll ),
				typeof( PainSpikeScroll ),			typeof( PoisonStrikeScroll ),	typeof( StrangleScroll ),	typeof( SummonFamiliarScroll ),
				typeof( VampiricEmbraceScroll ),	typeof( VengefulSpiritScroll ),	typeof( WitherScroll ),		typeof( WraithFormScroll )
			};
			
		private static Type[] m_SENecromancyScrollTypes = new Type[]
		{
			typeof( AnimateDeadScroll ),		typeof( BloodOathScroll ),		typeof( CorpseSkinScroll ),	typeof( CurseWeaponScroll ),
			typeof( EvilOmenScroll ),			typeof( HorrificBeastScroll ),	typeof( LichFormScroll ),	typeof( MindRotScroll ),
			typeof( PainSpikeScroll ),			typeof( PoisonStrikeScroll ),	typeof( StrangleScroll ),	typeof( SummonFamiliarScroll ),
			typeof( VampiricEmbraceScroll ),	typeof( VengefulSpiritScroll ),	typeof( WitherScroll ),		typeof( WraithFormScroll ),
			//typeof( ExorcismScroll )
		};

		private static Type[] m_PaladinScrollTypes = new Type[0];

		private static Type[] m_ArcaneScrollTypes = new Type[]
		{
			typeof( ArcaneCircleScroll ),	typeof ( GiftOfRenewalScroll ),	typeof( ImmolatingWeaponScroll ),	typeof( AttuneWeaponScroll ),
			typeof( ThunderstormScroll ),	typeof( NatureFuryScroll ),		typeof( ReaperFormScroll ),			typeof( WildfireScroll ),
			typeof( EssenceOfWindScroll ),	typeof( DryadAllureScroll ),	typeof( EtherealVoyageScroll ),		typeof( WordOfDeathScroll ),
			typeof( GiftOfLifeScroll ),		typeof( ArcaneEmpowermentScroll )
		};

		public static Type[] RegularScrollTypes{ get{ return m_RegularScrollTypes; } }
		public static Type[] NecromancyScrollTypes{ get{ return m_NecromancyScrollTypes; } }
		public static Type[] SENecromancyScrollTypes{ get{ return m_SENecromancyScrollTypes; } }
		public static Type[] PaladinScrollTypes{ get{ return m_PaladinScrollTypes; } }
		public static Type[] ArcaneScrollTypes{ get{ return m_ArcaneScrollTypes; } }

		private static Type[] m_SEClothingTypes = new Type[]
			{
				typeof( ClothNinjaJacket ),		typeof( FemaleKimono ),			typeof( Hakama ),
				typeof( HakamaShita ),			typeof( JinBaori ),				typeof( Kamishimo ),
				typeof( MaleKimono ),			typeof( NinjaTabi ),			typeof( Obi ),
				typeof( SamuraiTabi ),			typeof( TattsukeHakama ),		typeof( Waraji )
			};

		public static Type[] SEClothingTypes{ get{ return m_SEClothingTypes; } }

		private static Type[] m_AosClothingTypes = new Type[]
			{
				typeof( FurSarong ),			typeof( FurCape ),				typeof( FlowerGarland ),
				typeof( GildedDress ),			typeof( FurBoots ),				typeof( FormalShirt ),
		};

		public static Type[] AosClothingTypes{ get{ return m_AosClothingTypes; } }

		private static Type[] m_ClothingTypes = new Type[]
			{
				typeof( Cloak ),				
				typeof( Bonnet ),               typeof( Cap ),		            typeof( FeatheredHat ),
				typeof( FloppyHat ),            typeof( JesterHat ),			typeof( Surcoat ),
				typeof( SkullCap ),             typeof( StrawHat ),	            typeof( TallStrawHat ),
				typeof( TricorneHat ),			typeof( WideBrimHat ),          typeof( WizardsHat ),
				typeof( BodySash ),             typeof( Doublet ),              typeof( Boots ),
				typeof( FullApron ),            typeof( JesterSuit ),           typeof( Sandals ),
				typeof( Tunic ),				typeof( Shoes ),				typeof( Shirt ),
				typeof( Kilt ),                 typeof( Skirt ),				typeof( FancyShirt ),
				typeof( FancyDress ),			typeof( ThighBoots ),			typeof( LongPants ),
				typeof( PlainDress ),           typeof( Robe ),					typeof( ShortPants ),
				typeof( HalfApron )
			};

        public static Type[] ClothingTypes { get { return m_ClothingTypes; } }

        private static Type[] m_ClothingTemraelTypes = new Type[]
            {
                typeof( SkullCap ),                  typeof( Bandana ),		            typeof( Turban ),
                typeof( TurbanLong ),                typeof( TurbanFeminin ),		    typeof( TurbanAmple ),
                typeof( TurbanProtecteur ),          typeof( TurbanVoile ),		        typeof( TurbanNoble ),
                typeof( FloppyHat ),                 typeof( Cap ),		                typeof( WideBrimHat ),
                typeof( StrawHat ),                  typeof( TallStrawHat ),		    typeof( FeatheredHat ),
                typeof( Bonnet ),                    typeof( FeatheredHat ),		    typeof( TricorneHat ),
                typeof( JesterHat ),                 typeof( ChapeauCourt ),		    typeof( ChapeauPlume ),
                typeof( ChapeauMelon ),              typeof( ChapeauNoble ),		    typeof( ChapeauLoup ),

                typeof( Robe ),                     typeof( TogeSoutane ),		        typeof( TogePelerin ),
                typeof( TogeReligieuse ),           typeof( TogeNomade ),		        typeof( TogeOrient ),
                typeof( Toge ),                     typeof( TogeVoyage ),		        typeof( TogeDecore ),
                typeof( TogeDiciple ),              typeof( TogeElfique ),		        typeof( TogeGoetie ),
                typeof( TogeElfique ),              typeof( TogeDrow ),		            typeof( TogeHautElfe ),
                typeof( TogeAmple ),                typeof( TogeMystique ),		        typeof( TogeArchiMage ),
                typeof( TogeFeminine ),             typeof( TogeSorcier ),		        typeof( TogeOr ),

                typeof( ManteauPardessus ),         typeof( ManteauTabar ),		        typeof( ManteauCourt ),
                typeof( ManteauLong ),              typeof( ManteauRaye ),		        typeof( ManteauNoble ),

                typeof( CapeCourte ),               typeof( CapeVoyage ),		        typeof( CapeBarbare ),
                typeof( CapeNordique ),             typeof( Cloak ),		            typeof( CapeCapuche ),
                typeof( CapeCol ),                  typeof( CapeColLong ),		        typeof( CapeSolide ),
                typeof( CapeEpauliere ),            typeof( CapeDecore ),		        typeof( CapeLongue ),
                typeof( CapeTrainee ),              typeof( CapeCagoule ),		        typeof( CapeNoble ),
                typeof( Voile ),                    typeof( CapeFeminine ),		        typeof( CapeFourrure ),
                typeof( CapePoil ),                 typeof( CapeJarl ),		            typeof( CapePlume ),
                typeof( CapeSombre ),

                typeof( RobeDechire ),              typeof( RobeDrow ),		            typeof( RobePetite ),
                typeof( RobeSoubrette ),            typeof( PlainDress ),		        typeof( RobeSimple ),
                typeof( RobeOrdinaire ),            typeof( RobeGamine ),		        typeof( RobeEnfantine ),
                typeof( RobeDomestique ),           typeof( RobeBohemienne ),		    typeof( RobeOrcish ),
                typeof( RobeGitane ),               typeof( RobeACeinture ),		    typeof( RobeSansManches ),
                typeof( RobeDemoiselle ),           typeof( RobeFleurit ),		        typeof( RobeServeuse ),
                typeof( RobeServante ),             typeof( RobeAubergiste ),		    typeof( RobeSobre ),
                typeof( RobeOrne ),                 typeof( RobeAmusante ),		        typeof( RobeElegante ),
                typeof( RobeSeduisante ),           typeof( RobeOrient ),		        typeof( RobeOrientale ),
                typeof( RobeBourgeoise ),           typeof( RobeGrande ),		        typeof( RobeLarge ),
                typeof( RobeAmple ),                typeof( RobeAvecCorset ),		    typeof( RobeACorset ),
                typeof( RobeCorsetAmple ),          typeof( RobeCharmante ),		    typeof( RobeAttrayante ),
                typeof( RobeDore ),                 typeof( RobeNoble ),		        typeof( RobeCourt ),
                typeof( RobeAraneide ),             typeof( RobeNymph ),		        typeof( RobeAraignee ),
                typeof( RobeAntique ),              typeof( FancyDress ),		        typeof( RobeElfique ),
                typeof( RobeAmpleElfique ),         typeof( RobeElfe ),		            typeof( RobeElfeNoir ),
                typeof( RobeSombre ),               typeof( RobeOuverte ),		        typeof( Robetrainante ),
                typeof( RobeCourte ),               typeof( RobeBoheme ),		        typeof( RobeDentelle ),
                typeof( RobeTrainee ),              typeof( RobeMariage ),		        

                typeof( ChandailCourtDechire ),     typeof( ChandailDechire ),		    typeof( ChandailLongDechire ),
                typeof( TuniqueDechire ),           typeof( TuniqueLongueDechire ),     typeof( TabarDechire ),

                typeof( ChandailCourtBarbare ),     typeof( ChandailLongBarbare ),	    typeof( ChandailVieux ),
                typeof( SoutienGorge ),             typeof( ChandailSoutienGorge ),		typeof( Chandail ),
                typeof( Shirt ),                    typeof( ChandailSombre ),		    typeof( FancyShirt ),
                typeof( ChandailBordel ),           typeof( ChandailDecore ),		    typeof( ChandailCourt ),
                typeof( ChandailMarin ),            typeof( ChandailCombat ),		    typeof( ChandailFeminin ),
                typeof( ChandailNoble ),            

                typeof( ChemiseOrient ),            typeof( ChemiseCol ),		        typeof( ChemiseReligieuse ),
                typeof( Chemiselacee ),             typeof( ChemiseBourgeoise ),		typeof( ChemiseGaine ),
                typeof( ChemiseLongue ),            typeof( ChemiseElfique ),		    typeof( ChemiseAmple ),
                typeof( ChemiseNoble ),             

                typeof( CorsetPetit ),              typeof( CorsetOuvert ),		        typeof( Corset ),
                typeof( CorsetLong ),               typeof( CorsetAmple ),		        typeof( CorsetSombre ),

                typeof( Doublet ),                  typeof( DoubletBouton ),		    typeof( DoubletAmple ),
                typeof( DoubletFeminin ),           typeof( DoubletArmure ),		    

                typeof( TuniqueOuverte ),           typeof( TuniquePardessus ),		    typeof( Tunic ),
                typeof( TuniquePaysanne ),          typeof( TuniqueVoyage ),		    typeof( Tunique ),
                typeof( TuniqueAmple ),             typeof( TuniquePirate ),		    typeof( JesterSuit ),
                typeof( TuniqueOrientale ),         typeof( TuniqueNomade ),		    typeof( TuniqueBourgeoise ),
                typeof( TuniquePage ),              typeof( TuniqueAssassin ),		    typeof( TuniqueNoble ),

                typeof( Veston ),                   typeof( VesteCuir ),		        typeof( VestePoil ),
                typeof( Veste ),                    typeof( VesteLourde ),		        

                typeof( Surcoat ),                  typeof( TabarCourt ),		        typeof( TabarReligieux ),
                typeof( TabarLong ),                

                typeof( PantalonsDechires ),        typeof( PantalonsPauvre ),		    typeof( ShortPants ),
                typeof( LongPants ),                typeof( PantalonsOuvert ),		    typeof( PantalonsOrient ),
                typeof( PantalonsNordique ),        typeof( PantalonsNomade ),		    typeof( Pantalons ),
                typeof( PantalonsCourts ),          typeof( PantalonsLongs ),		    typeof( PantalonsCuir ),
                typeof( PantalonsMoulant ),         typeof( PantalonsArmure ),		    

                typeof( Kilt ),                     typeof( TuniqueKilt ),		        

                typeof( JupeOuvrier ),              typeof( Jupette ),		            typeof( JupeCourte ),
                typeof( Skirt ),                    typeof( Jupe ),		                typeof( JupeHakama ),
                typeof( JupeCourteBarbare ),        typeof( JupeLongueBarbare ),	    typeof( JupeCuir ),
                typeof( JupeOrcish ),               typeof( JupeNomade ),		        typeof( JupeOuverte ),
                typeof( JupeDecore ),               typeof( JupeLongue ),		        typeof( JupeAPans ),
                typeof( JupeOrient ),               typeof( JupeAmple ),		        typeof( JupeGrande ),
                typeof( JupeBordel ),               typeof( JupeNoble ),	
	        
                typeof( Sandals ),                  typeof( Geta ),		                typeof( Shoes ),
                typeof( SouliersBoucles ),          typeof( BottesPetites ),		    typeof( Boots ),
                typeof( ThighBoots ),               typeof( BottesBoucles ),		    typeof( Bottes ),
                typeof( BottesNoble ),              typeof( BottesFourrure ),		    typeof( BottesSombres ),

                typeof( BodySash ),                 typeof( Cocarde ),		            typeof( CeintureTorseGrande ),

                typeof( HalfApron ),                typeof( FullApron ),		        typeof( TablierBarbare ),

                typeof( SousVetement ),             typeof( JartellesBlanches ),		typeof( JartellesNoir ),
                typeof( Jartelles ),                

                typeof( CeinturePauvre ),           typeof( Bourse ),		            typeof( Ceinture ),
                typeof( CeintureBourse ),           typeof( CeintureBoucle ),		    typeof( CeintureCuir ),
                typeof( CeinturePendante ),         typeof( CeintureNordique ),		    typeof( CeintureLongue ),
                
                typeof( Carquois ),                 typeof( Fourreau ),		            typeof( FourreauDos ),
                typeof( FourreauDague ),            typeof( FourreauDecouvert ),		typeof( FourreauRapiere ),
                typeof( FourreauEpee ),             typeof( FourreauSabre ),

                typeof( SacocheCeinture ),          typeof( SacocheHerboriste ),		typeof( SacocheRoublard ),
                typeof( SacocheAventure ),               

                typeof( Pardessus ),                typeof( PardessusBarbare ),		    typeof( EpauliereBarbare ),
                typeof( Bracer ),                   typeof( BrassardsFeminins ),		typeof( BrassardsCommun ),
                typeof( BrassardsSimples ),         typeof( GantsSombres ),		        

                typeof( Foulard ),                  typeof( CagouleGorget ),		    typeof( FoulardProtecteur ),
                typeof( FoulardNoble ),             typeof( CagouleCuir ),		        typeof( Cagoule ),
                typeof( Capuche ),                  typeof( CapucheGrande ),		    typeof( CagouleGrande ),

                typeof( BandagesTorse ),            typeof( BandagesBras ),		        typeof( BandagesJambes ),
                typeof( BandeauDroit ),             typeof( BandeauAveugle ),		    typeof( BandeauGauche )
            };

		public static Type[] ClothingTemraelTypes{ get{ return m_ClothingTemraelTypes; } }

		private static Type[] m_SEHatTypes = new Type[]
			{
				typeof( ClothNinjaHood ),		typeof( Kasa )
			};

		public static Type[] SEHatTypes{ get{ return m_SEHatTypes; } }

		private static Type[] m_AosHatTypes = new Type[]
			{
				typeof( FlowerGarland ),	typeof( BearMask ),		typeof( DeerMask )	//Are Bear& Deer mask inside the Pre-AoS loottables too?
			};

		public static Type[] AosHatTypes{ get{ return m_AosHatTypes; } }

		private static Type[] m_HatTypes = new Type[]
			{
				typeof( SkullCap ),			typeof( Bandana ),		typeof( FloppyHat ),
				typeof( Cap ),				typeof( WideBrimHat ),	typeof( StrawHat ),
				typeof( TallStrawHat ),		typeof( WizardsHat ),	typeof( Bonnet ),
				typeof( FeatheredHat ),		typeof( TricorneHat ),	typeof( JesterHat )
			};

		public static Type[] HatTypes{ get{ return m_HatTypes; } }

        private static Type[] m_TemraelHatTypes = new Type[]
			{

			};

        public static Type[] TemraelHatTypes { get { return m_HatTypes; } }

		private static Type[] m_LibraryBookTypes = new Type[]
			{
				typeof( GrammarOfOrcish ),		typeof( CallToAnarchy ),				typeof( ArmsAndWeaponsPrimer ),
				typeof( SongOfSamlethe ),		typeof( TaleOfThreeTribes ),			typeof( GuideToGuilds ),
				typeof( BirdsOfBritannia ),		typeof( BritannianFlora ),				typeof( ChildrenTalesVol2 ),
				typeof( TalesOfVesperVol1 ),	typeof( DeceitDungeonOfHorror ),		typeof( DimensionalTravel ),
				typeof( EthicalHedonism ),		typeof( MyStory ),						typeof( DiversityOfOurLand ),
				typeof( QuestOfVirtues ),		typeof( RegardingLlamas ),				typeof( TalkingToWisps ),
				typeof( TamingDragons ),		typeof( BoldStranger ),					typeof( BurningOfTrinsic ),
				typeof( TheFight ),				typeof( LifeOfATravellingMinstrel ),	typeof( MajorTradeAssociation ),
				typeof( RankingsOfTrades ),		typeof( WildGirlOfTheForest ),			typeof( TreatiseOnAlchemy ),
				typeof( VirtueBook )
			};

		public static Type[] LibraryBookTypes{ get{ return m_LibraryBookTypes; } }

		#endregion

		#region Accessors

		public static BaseClothing RandomClothing()
		{
			return RandomClothing( false );
		}

		public static BaseClothing RandomClothing( bool inTokuno )
		{
			/*if ( Core.SE && inTokuno )
				return Construct( m_SEClothingTypes, m_AosClothingTypes, m_ClothingTypes ) as BaseClothing;

			if ( Core.AOS )
				return Construct( m_AosClothingTypes, m_ClothingTypes, m_ClothingTemraelTypes ) as BaseClothing;*/

			return Construct( m_ClothingTemraelTypes ) as BaseClothing;
		}

		public static BaseWeapon RandomRangedWeapon()
		{
			return RandomRangedWeapon( false );
		}

		public static BaseWeapon RandomRangedWeapon( bool inTokuno )
		{
			/*if ( Core.SE && inTokuno )
				return Construct( m_SERangedWeaponTypes, m_AosRangedWeaponTypes, m_RangedWeaponTypes ) as BaseWeapon;

			if ( Core.AOS )
				return Construct( m_AosRangedWeaponTypes, m_RangedWeaponTypes, m_TemraelRangedWeaponTypes ) as BaseWeapon;*/

            return Construct(m_TemraelRangedWeaponTypes) as BaseWeapon;
		}

		public static BaseWeapon RandomWeapon()
		{
			return RandomWeapon( false );
		}

		public static BaseWeapon RandomWeapon( bool inTokuno )
		{
			/*if ( Core.SE && inTokuno )
				return Construct( m_SEWeaponTypes, m_AosWeaponTypes, m_WeaponTypes ) as BaseWeapon;

			if ( Core.AOS )
				return Construct( m_AosWeaponTypes, m_WeaponTypes, m_TemraelWeaponTypes ) as BaseWeapon;*/

            return Construct(m_TemraelWeaponTypes) as BaseWeapon;
		}

		public static Item RandomWeaponOrJewelry()
		{
			return RandomWeaponOrJewelry( false );
		}

		public static Item RandomWeaponOrJewelry( bool inTokuno )
		{
			/*if ( Core.SE && inTokuno )
				return Construct( m_SEWeaponTypes, m_AosWeaponTypes, m_WeaponTypes, m_JewelryTypes );

			if ( Core.AOS )
				return Construct( m_AosWeaponTypes, m_WeaponTypes, m_JewelryTypes );*/

			return Construct( m_WeaponTypes, m_JewelryTypes );
		}

		public static BaseJewel RandomJewelry()
		{
			return Construct( m_JewelryTypes, m_TemraelJewelryTypes ) as BaseJewel;
		}

		public static BaseArmor RandomArmor()
		{
			return RandomArmor( false );
		}

		public static BaseArmor RandomArmor( bool inTokuno )
		{
			return Construct( m_ArmorTypes, m_TemraelArmorTypes ) as BaseArmor;
		}

		public static BaseHat RandomHat()
		{
			return RandomHat( false );
		}

		public static BaseHat RandomHat( bool inTokuno )
		{
			if ( Core.SE && inTokuno )
				return Construct( m_SEHatTypes, m_AosHatTypes, m_HatTypes ) as BaseHat;

			if ( Core.AOS )
				return Construct( m_AosHatTypes, m_HatTypes, m_TemraelHatTypes ) as BaseHat;

            return Construct(m_HatTypes, m_TemraelHatTypes) as BaseHat;
		}

		public static Item RandomArmorOrHat()
		{
			return RandomArmorOrHat( false );
		}

		public static Item RandomArmorOrHat( bool inTokuno )
		{
			if ( Core.AOS )
				return Construct( m_ArmorTypes, m_AosHatTypes, m_HatTypes );

			return Construct( m_ArmorTypes, m_HatTypes );
		}

		public static BaseShield RandomShield()
		{
			if ( Core.AOS )
				return Construct( m_AosShieldTypes, m_ShieldTypes, m_TemraelShieldTypes ) as BaseShield;

            return Construct(m_ShieldTypes, m_TemraelShieldTypes) as BaseShield;
		}

		public static BaseArmor RandomArmorOrShield()
		{
			return RandomArmorOrShield( false );
		}

		public static BaseArmor RandomArmorOrShield( bool inTokuno )
		{
			if ( Core.AOS )
				return Construct( m_ArmorTypes, m_AosShieldTypes, m_ShieldTypes ) as BaseArmor;

			return Construct( m_ArmorTypes, m_ShieldTypes ) as BaseArmor;
		}

		public static Item RandomArmorOrShieldOrJewelry()
		{
			return RandomArmorOrShieldOrJewelry( false );
		}

		public static Item RandomArmorOrShieldOrJewelry( bool inTokuno )
		{
			if ( Core.AOS )
				return Construct( m_ArmorTypes, m_AosHatTypes, m_HatTypes, m_AosShieldTypes, m_ShieldTypes, m_JewelryTypes );

			return Construct( m_ArmorTypes, m_HatTypes, m_ShieldTypes, m_JewelryTypes );
		}

		public static Item RandomArmorOrShieldOrWeapon()
		{
			return RandomArmorOrShieldOrWeapon( false );
		}

		public static Item RandomArmorOrShieldOrWeapon( bool inTokuno )
		{

			if ( Core.AOS )
				return Construct( m_AosWeaponTypes, m_WeaponTypes, m_RangedWeaponTypes, m_ArmorTypes, m_AosHatTypes, m_HatTypes, m_AosShieldTypes, m_ShieldTypes );

			return Construct( m_WeaponTypes, m_RangedWeaponTypes, m_ArmorTypes, m_HatTypes, m_ShieldTypes );
		}

		public static Item RandomArmorOrShieldOrWeaponOrJewelry()
		{
			return RandomArmorOrShieldOrWeaponOrJewelry( false );
		}

		public static Item RandomArmorOrShieldOrWeaponOrJewelry( bool inTokuno )
		{
			if ( Core.AOS )
				return Construct( m_AosWeaponTypes, m_WeaponTypes, m_RangedWeaponTypes, m_ArmorTypes, m_AosHatTypes, m_HatTypes, m_AosShieldTypes, m_ShieldTypes, m_JewelryTypes );

			return Construct( m_WeaponTypes, m_RangedWeaponTypes, m_ArmorTypes, m_HatTypes, m_ShieldTypes, m_JewelryTypes );
		}

		public static Item RandomGem()
		{
			return Construct( m_GemTypes );
		}

		public static Item RandomReagent()
		{
			return Construct( m_RegTypes );
		}

		public static Item RandomNecromancyReagent()
		{
			return Construct( m_NecroRegTypes );
		}

		public static Item RandomPossibleReagent()
		{
			if ( Core.AOS )
				return Construct( m_RegTypes, m_NecroRegTypes );

			return Construct( m_RegTypes );
		}

		public static Item RandomPotion()
		{
			return Construct( m_PotionTypes );
		}

		public static BaseInstrument RandomInstrument()
		{
			if ( Core.SE )
				return Construct( m_InstrumentTypes, m_SEInstrumentTypes ) as BaseInstrument;

			return Construct( m_InstrumentTypes ) as BaseInstrument;
		}

		public static Item RandomStatue()
		{
			return Construct( m_StatueTypes );
		}

		public static SpellScroll RandomScroll( int minIndex, int maxIndex, SpellbookType type )
		{
			Type[] types;

			switch ( type )
			{
				default:
				case SpellbookType.Regular: types = m_RegularScrollTypes; break;
				case SpellbookType.Necromancer: types = (Core.SE ? m_SENecromancyScrollTypes : m_NecromancyScrollTypes ); break;
				case SpellbookType.Paladin: types = m_PaladinScrollTypes; break;
				case SpellbookType.Arcanist: types = m_ArcaneScrollTypes; break;
			}

			return Construct( types, Utility.RandomMinMax( minIndex, maxIndex ) ) as SpellScroll;
		}

		public static BaseBook RandomLibraryBook()
		{
			return Construct( m_LibraryBookTypes ) as BaseBook;
		}

		public static BaseTalisman RandomTalisman()
		{
			BaseTalisman talisman = new BaseTalisman( BaseTalisman.GetRandomItemID() );

			talisman.Summoner = BaseTalisman.GetRandomSummoner();

			if ( talisman.Summoner.IsEmpty )
			{
				talisman.Removal = BaseTalisman.GetRandomRemoval();

				if ( talisman.Removal != TalismanRemoval.None )
				{
					talisman.MaxCharges = BaseTalisman.GetRandomCharges();
					talisman.MaxChargeTime = 1200;
				}
			}
			else
			{
				talisman.MaxCharges = Utility.RandomMinMax( 10, 50 );

				if ( talisman.Summoner.IsItem )
					talisman.MaxChargeTime = 60;
				else
					talisman.MaxChargeTime = 1800;
			}

			talisman.Blessed = BaseTalisman.GetRandomBlessed();
			talisman.Protection = BaseTalisman.GetRandomProtection();
			talisman.Killer = BaseTalisman.GetRandomKiller();
			talisman.Skill = BaseTalisman.GetRandomSkill();
			talisman.ExceptionalBonus = BaseTalisman.GetRandomExceptional();
			talisman.SuccessBonus = BaseTalisman.GetRandomSuccessful();
			talisman.Charges = talisman.MaxCharges;

			return talisman;
		}
		#endregion

		#region Construction methods
		public static Item Construct( Type type )
		{
			try
			{
				return Activator.CreateInstance( type ) as Item;
			}
			catch (Exception e)
			{
                Misc.ExceptionLogging.WriteLine(e);
				return null;
			}
		}

		public static Item Construct( Type[] types )
		{
			if ( types.Length > 0 )
				return Construct( types, Utility.Random( types.Length ) );

			return null;
		}

		public static Item Construct( Type[] types, int index )
		{
			if ( index >= 0 && index < types.Length )
				return Construct( types[index] );

			return null;
		}

		public static Item Construct( params Type[][] types )
		{
			int totalLength = 0;

			for ( int i = 0; i < types.Length; ++i )
				totalLength += types[i].Length;

			if ( totalLength > 0 )
			{
				int index = Utility.Random( totalLength );

				for ( int i = 0; i < types.Length; ++i )
				{
					if ( index >= 0 && index < types[i].Length )
						return Construct( types[i][index] );

					index -= types[i].Length;
				}
			}

			return null;
		}
		#endregion
	}
}