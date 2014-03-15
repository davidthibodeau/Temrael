using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server
{
    public enum ZoneType
    {
        Mining,
        Fishing
    }
}

namespace Server.Engines.Harvest
{
    public class HarvestZone
    {
        private ZoneType m_ZoneType;
        private ArrayList m_Area;
        private HarvestVein[] m_Veins;
        private static ArrayList m_HarvestZones = new ArrayList();
        private Type m_RequiredTool;

        public ZoneType ZoneType
        {
            get { return m_ZoneType; }
            set { m_ZoneType = value; }
        }

        public ArrayList Area
        {
            get { return m_Area; }
            set { m_Area = value; }
        }

        public HarvestVein[] Veins
        {
            get { return m_Veins; }
            set { m_Veins = value; }
        }

        public Type RequiredTool
        {
            get { return m_RequiredTool; }
            set { m_RequiredTool = value; }
        }

        public static ArrayList HarvestZones
        {
            get { return m_HarvestZones; }
            set { m_HarvestZones = value; }
        }

        public static HarvestResource[] Resources
        {
            get { return m_Resources; }
            set { m_Resources = value; }
        }

        public HarvestZone(ZoneType zoneType)
        {
            m_ZoneType = zoneType;
            m_Area = new ArrayList();
        }

        public HarvestZone(ZoneType zoneType, Type tool)
        {
            m_ZoneType = zoneType;
            m_Area = new ArrayList();
            m_RequiredTool = tool;
        }

        private static HarvestResource[] m_Resources = new HarvestResource[]
			{
				new HarvestResource( 00.0, -50.0, 50.0, "Vous minez quelques minerais de Fer et les déposez dans votre sac.", typeof( FerOre ) ), // 0
				new HarvestResource( 40.0, -10.0, 80.0, "Vous minez quelques minerais de Cuivre et les déposez dans votre sac.", typeof( CuivreOre ) ), // 1
				new HarvestResource( 40.0, -10.0, 80.0, "Vous minez quelques minerais de Bronze et les déposez dans votre sac.", typeof( BronzeOre ) ), // 2
				new HarvestResource( 60.0, 10.0, 110.0, "Vous minez quelques minerais d'Acier et les déposez dans votre sac.", typeof( AcierOre ) ), // 3
				new HarvestResource( 60.0, 10.0, 110.0, "Vous minez quelques minerais d'Argent et les déposez dans votre sac.", typeof( ArgentOre ) ), // 4
				new HarvestResource( 60.0, 10.0, 110.0, "Vous minez quelques minerais d'Or et les déposez dans votre sac.", typeof( OrOre ) ), // 5
				new HarvestResource( 80.0, 30.0, 130.0, "Vous minez quelques minerais de Mytheril et les déposez dans votre sac.", typeof( MytherilOre ) ), // 6
				new HarvestResource( 80.0, 30.0, 130.0, "Vous minez quelques minerais de Luminium et les déposez dans votre sac.", typeof( LuminiumOre ) ), // 7
				new HarvestResource( 80.0, 30.0, 130.0, "Vous minez quelques minerais d'Obscurium et les déposez dans votre sac.", typeof( ObscuriumOre ) ), // 8
				new HarvestResource( 90.0, 40.0, 140.0, "Vous minez quelques minerais de Mystirium et les déposez dans votre sac.", typeof( MystiriumOre ) ), // 9
				new HarvestResource( 90.0, 40.0, 140.0, "Vous minez quelques minerais de Dominium et les déposez dans votre sac.", typeof( DominiumOre ) ), // 10
				new HarvestResource( 90.0, 40.0, 140.0, "Vous minez quelques minerais d'Eclarium et les déposez dans votre sac.", typeof( EclariumOre ) ), // 11
				new HarvestResource( 100.0, 50.0, 150.0, "Vous minez quelques minerais de Venarium et les déposez dans votre sac.", typeof( VenariumOre ) ), // 12
				new HarvestResource( 100.0, 50.0, 150.0, "Vous minez quelques minerais d'Athenium et les déposez dans votre sac.", typeof( AtheniumOre ) ), // 13
				new HarvestResource( 100.0, 50.0, 150.0, "Vous minez quelques minerais d'Umbrarium et les déposez dans votre sac.", typeof( UmbrariumOre ) ), // 14

                new HarvestResource( 00.0,  -100.0, 40.0, "Vous coupez quelques buches d'Érables et les déposez dans votre sac.", typeof( Log ) ), // 15
                new HarvestResource( 20.0,  -90.0, 50.0, "Vous coupez quelques buches de Pin et les déposez dans votre sac.", typeof( PinLog ) ), // 16
                new HarvestResource( 30.0,  -80.0, 60.0, "Vous coupez quelques buches de Cypprès et les déposez dans votre sac.", typeof( CypresLog ) ), // 17
                new HarvestResource( 40.0,  -70.0, 70.0, "Vous coupez quelques buches de Cèdre et les déposez dans votre sac.", typeof( CedreLog ) ), // 18
                new HarvestResource( 50.0,  -60.0, 80.0, "Vous coupez quelques buches de Saule et les déposez dans votre sac.", typeof( SauleLog ) ), // 19
                new HarvestResource( 60.0,  -50.0, 90.0, "Vous coupez quelques buches de Chêne et les déposez dans votre sac.", typeof( CheneLog ) ), // 20
                new HarvestResource( 70.0,  -40.0, 100.0, "Vous coupez quelques buches d'Ébène et les déposez dans votre sac.", typeof( EbeneLog ) ), // 21
                new HarvestResource( 80.0,  -30.0, 100.0, "Vous coupez quelques buches d'Acajou et les déposez dans votre sac.", typeof( AcajouLog ) ), // 22

                new HarvestResource( 0.0,  10.0, 60.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( SardineFish ) ), // 23
                new HarvestResource( 0.0,  10.0, 60.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( AnchoieFish ) ), // 24
                new HarvestResource( 0.0,  10.0, 60.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( HarengFish ) ), // 25
                new HarvestResource( 10.0,  20.0, 70.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( HuitreFish ) ), // 26
                new HarvestResource( 20.0,  30.0, 70.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( CalmarFish ) ), // 27
                new HarvestResource( 20.0,  30.0, 70.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( PieuvreFish ) ), // 28

                new HarvestResource( 30.0,  30.0, 80.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( TruiteSauvageFish ) ), // 29
                new HarvestResource( 30.0,  30.0, 80.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( CarpeFish ) ), // 30
                new HarvestResource( 40.0,  30.0, 80.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( EsturgeonFish ) ), // 31
                new HarvestResource( 40.0,  40.0, 90.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( BrochetFish ) ), // 32

                new HarvestResource( 40.0,  40.0, 90.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( TruiteMerFish ) ), // 33
                new HarvestResource( 50.0,  40.0, 100.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( MorueFish ) ), // 34
                new HarvestResource( 50.0,  50.0, 100.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( FletanFish ) ), // 35
                new HarvestResource( 50.0,  50.0, 110.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( MaquereauFish ) ), // 36
                new HarvestResource( 60.0,  50.0, 110.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( SoleFish ) ), // 37

                new HarvestResource( 60.0,  60.0, 110.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( GrandBrochetFish ) ), // 38
                new HarvestResource( 60.0,  60.0, 120.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( GrandDoreFish ) ), // 39
                new HarvestResource( 60.0,  60.0, 120.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( EsturgeonMerFish ) ), // 40
                new HarvestResource( 70.0,  60.0, 130.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( GrandSaumonFish ) ), // 41
                new HarvestResource( 70.0,  60.0, 130.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( ThonFish ) ), // 42
                new HarvestResource( 70.0,  70.0, 130.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( SaumonFish ) ), // 43

                new HarvestResource( 80.0,  70.0, 140.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( RequinGrisFish ) ), // 44
                new HarvestResource( 80.0,  70.0, 140.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( RequinBlancFish ) ), // 45
                new HarvestResource( 80.0,  70.0, 150.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( RaieFish ) ), // 46
                new HarvestResource( 80.0,  70.0, 150.0, "Vous pechez quelques poissons et les déposez dans votre sac.", typeof( EspadonFish ) ), // 47

				/*new HarvestResource( 00.0, -70.0, 100.0, "Vous coupez quelques bûches d'Érable et les déposez dans votre sac.", typeof( ErableLog ) ), // 16
				new HarvestResource( 10.0, -60.0, 100.0, "Vous coupez quelques bûches de Chêne et les déposez dans votre sac.", typeof( CheneLog ) ), // 17
				new HarvestResource( 20.0, -50.0, 100.0, "Vous coupez quelques bûches de Pin et les déposez dans votre sac.", typeof( PinLog ) ), // 18
				new HarvestResource( 30.0, -40.0, 100.0, "Vous coupez quelques bûches de Cèdre et les déposez dans votre sac.", typeof( CedreLog ) ), // 19
				new HarvestResource( 40.0, -10.0, 100.0, "Vous coupez quelques bûches de Cyprès et les déposez dans votre sac.", typeof( CypresLog ) ), // 20
				new HarvestResource( 50.0,   0.0, 100.0, "Vous coupez quelques bûches d'Ébène et les déposez dans votre sac.", typeof( EbeneLog ) ), // 21
				new HarvestResource( 70.0,  20.0, 110.0, "Vous coupez quelques bûches d'Acajou et les déposez dans votre sac.", typeof( AcajouLog ) ), // 22
				new HarvestResource( 60.0,  10.0, 105.0, "Vous coupez quelques bûches de Saule et les déposez dans votre sac.", typeof( SauleLog ) ), // 23

				new HarvestResource( 00.0, -70.0, 100.0, "Vous pêchez une truite et la déposez dans votre sac.", typeof( TruiteFish ) ), //24
				new HarvestResource( 00.0, -70.0, 100.0, "Vous pêchez un doré et le déposez dans votre sac.", typeof( DoreFish ) ), //25
				new HarvestResource( 35.0, -35.0, 100.0, "Vous pêchez une carpe et la déposez dans votre sac.", typeof( CarpeFish ) ), //26
				new HarvestResource( 00.0, -70.0, 100.0, "Vous pêchez une anguille et la déposez dans votre sac.", typeof( AnguilleFish ) ), //27
				new HarvestResource( 35.0, -35.0, 100.0, "Vous pêchez un esturgeon et le déposez dans votre sac.", typeof( EsturgeonFish ) ), //28
				new HarvestResource( 35.0, -35.0, 100.0, "Vous pêchez un brochet et le déposez dans votre sac.", typeof( BrochetFish ) ), //29
				new HarvestResource( 40.0, -30.0, 100.0, "Vous pêchez une sardine et la déposez dans votre sac.", typeof( SardineFish ) ), //30
				new HarvestResource( 40.0, -30.0, 100.0, "Vous pêchez un anchoie et le déposez dans votre sac.", typeof( AnchoieFish ) ), //31
				new HarvestResource( 60.0,  10.0, 100.0, "Vous pêchez une morue et la déposez dans votre sac.", typeof( MorueFish ) ), //32
				new HarvestResource( 40.0, -30.0, 100.0, "Vous pêchez un hareng et le déposez dans votre sac.", typeof( HarengFish ) ), //33
				new HarvestResource( 60.0,  10.0, 100.0, "Vous pêchez un flétan et le déposez dans votre sac.", typeof( FletanFish ) ), //34
				new HarvestResource( 60.0,  10.0, 100.0, "Vous pêchez un maquereau et le déposez dans votre sac.", typeof( MaquereauFish ) ), //35
				new HarvestResource( 60.0,  10.0, 100.0, "Vous pêchez une sole et la déposez dans votre sac.", typeof( SoleFish ) ), //36
				new HarvestResource( 60.0,  10.0, 100.0, "Vous pêchez un thon et le déposez dans votre sac.", typeof( ThonFish ) ), //37
				new HarvestResource( 60.0,  10.0, 100.0, "Vous pêchez un saumon et le déposez dans votre sac.", typeof( SaumonFish ) ), //38
				new HarvestResource( 75.0,  25.0, 110.0, "Vous pêchez un grand brochet et le déposez dans votre sac.", typeof( GrandBrochetFish ) ), //39
				new HarvestResource( 35.0, -35.0, 100.0, "Vous pêchez une truite sauvage et la déposez dans votre sac.", typeof( TruiteSauvageFish ) ), //40
				new HarvestResource( 75.0,  25.0, 110.0, "Vous pêchez un grand doré et le déposez dans votre sac.", typeof( GrandDoreFish ) ), //41
				new HarvestResource( 60.0,  10.0, 100.0, "Vous pêchez une truite de mer et la déposez dans votre sac.", typeof( TruiteMerFish ) ), //42
				new HarvestResource( 75.0,  25.0, 110.0, "Vous pêchez un esturgeon de mer et le déposez dans votre sac.", typeof( EsturgeonMerFish ) ), //43
				new HarvestResource( 75.0,  25.0, 110.0, "Vous pêchez un grand saumon et le déposez dans votre sac.", typeof( GrandSaumonFish ) ), //44
				new HarvestResource( 75.0,  25.0, 110.0, "Vous pêchez une raie et la déposez dans votre sac.", typeof( RaieFish ) ), //45
				new HarvestResource( 75.0,  25.0, 110.0, "Vous pêchez un espadon et le déposez dans votre sac.", typeof( EspadonFish ) ), //46
				new HarvestResource( 90.0,  85.0, 300.0, "Vous pêchez un requin gris.", typeof( RequinGrisFish ) ), //47
				new HarvestResource( 90.0,  85.0, 300.0, "Vous pêchez un requin blanc.", typeof( RequinBlancFish ) ), //48
				new HarvestResource( 40.0, -30.0, 100.0, "Vous pêchez une huître et la déposez dans votre sac.", typeof( HuitreFish ) ), //49
				new HarvestResource( 75.0,  25.0, 110.0, "Vous pêchez un calmar et le déposez dans votre sac.", typeof( CalmarFish ) ), //50
				new HarvestResource( 75.0,  25.0, 110.0, "Vous pêchez une pieuvre et la déposez dans votre sac.", typeof( PieuvreFish ) ), //51

				new HarvestResource( 60.0,  10.0, 100.0, "Vous minez quelques minerais de Justicium et les déposez dans votre sac.", typeof( JusticiumOre ) ), // 52
				new HarvestResource( 60.0,  10.0, 100.0, "Vous minez quelques minerais d'Or et les déposez dans votre sac.", typeof( GoldOre ) ), // 53
				new HarvestResource( 60.0,  10.0, 100.0, "Vous minez quelques minerais de Zirconium et les déposez dans votre sac.", typeof( ZirconiumOre ) ), // 54
				new HarvestResource( 80.0,  30.0, 110.0, "Vous minez quelques minerais d'Abyssium et les déposez dans votre sac.", typeof( AbyssiumOre ) ), // 55
				new HarvestResource( 80.0,  30.0, 110.0, "Vous minez quelques minerais de Bloodirium et les déposez dans votre sac.", typeof( BloodiriumOre ) ), // 56
				new HarvestResource( 80.0,  30.0, 110.0, "Vous minez quelques minerais d'Herbrosite et les déposez dans votre sac.", typeof( HerbrositeOre ) ), // 57
				new HarvestResource( 80.0,  30.0, 110.0, "Vous minez quelques minerais de Khandarium et les déposez dans votre sac.", typeof( KhandariumOre ) ), // 58
				new HarvestResource( 80.0,  30.0, 110.0, "Vous minez quelques minerais de Maritium et les déposez dans votre sac.", typeof( MaritiumOre ) ), // 59
				new HarvestResource( 80.0,  30.0, 110.0, "Vous minez quelques minerais de Muscovite et les déposez dans votre sac.", typeof( MuscoviteOre ) ), // 60
				new HarvestResource( 80.0,  30.0, 110.0, "Vous minez quelques minerais de Mytheril et les déposez dans votre sac.", typeof( MytherilOre ) ), // 61
				new HarvestResource( 80.0,  30.0, 110.0, "Vous minez quelques minerais de Phlogopite et les déposez dans votre sac.", typeof( PhlogopiteOre ) ), // 62
				new HarvestResource( 80.0,  30.0, 110.0, "Vous minez quelques minerais de Sombralir et les déposez dans votre sac.", typeof( SombralirOre ) ), // 63*/	
		};

        public static void AddZone(HarvestZone zone)
        {
            if (!m_HarvestZones.Contains(zone))
                m_HarvestZones.Add(zone);
        }

        public static void RemoveZone(HarvestZone zone)
        {
            if (m_HarvestZones.Contains(zone))
                m_HarvestZones.Remove(zone);
        }
    }
}