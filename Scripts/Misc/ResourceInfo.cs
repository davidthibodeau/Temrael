using System;
using System.Collections;

namespace Server.Items
{
	public enum CraftResource
	{
		None = 0,
		Fer = 1,
		Cuivre,
		Bronze,
		Acier,
		Argent,
		Or,
        Mytheril,
		Luminium,
        Obscurium,
		Mystirium,
		Dominium,
        Eclarium,
        Venarium,
        Athenium,
        Umbrarium,

		RegularLeather = 101,
        ReptilienLeather,
		NordiqueLeather,
		DesertiqueLeather,
        MaritimeLeather,
        VolcaniqueLeather,
        GeantLeather,
        MinotaurLeather,
        OphidienLeather,
        ArachnideLeather,
        MagiqueLeather,
        AncienLeather,
        DemoniaqueLeather,
		DragoniqueLeather,
        LupusLeather,

		RegularScales = 201,
		NordiqueScales,
		DesertiqueScales,
		MaritimeScales,
		VolcaniqueScales,
		AncienScales,
        WyrmScales,

		RegularWood = 301, //Erable
		PinWood,
        CypresWood,
        CedreWood,
        SauleWood,
        CheneWood,
        EbeneWood,
        AcajouWood,

        RegularBones = 401,
        GobelinBones,
        ReptilienBones,
        NordiqueBones,
        DesertiqueBones,
        MaritimeBones,
        VolcaniqueBones,
        GeantBones,
        MinotaureBones,
        OphidienBones,
        ArachnideBones,
        MagiqueBones,
        AncienBones,
        DemonBones,
        DragonBones,

        TruiteSauvage = 501,
        TruiteMer,
        Truite,
        Thon,
        Sole,
        Saumon,
        Sardine,
        RequinGris,
        RequinBlanc,
        Raie,
        Pieuvre,
        Morue,
        Maquereau,
        Huitre,
        Hareng,
        GrandSaumon,
        GrandDore,
        GrandBrochet,
        Fletan,
        EsturgeonMer,
        Esturgeon,
        Espadon,
        Dore,
        Carpe,
        Calmar,
        Brochet,
        Anguille,
        Anchoie,

	}

	public enum CraftResourceType
	{
		None,
		Metal,
		Leather,
		Scales,
		Wood,
        Bones
	}

	public class CraftResourceInfo
	{
		private int m_Hue;
		private int m_Number;
		private string m_Name;
        private double m_SkillReq;
		private CraftResource m_Resource;
		private Type[] m_ResourceTypes;

		public int Hue{ get{ return m_Hue; } }
		public int Number{ get{ return m_Number; } }
		public string Name{ get{ return m_Name; } }
        public double SkillReq { get { return m_SkillReq; } }
		public CraftResource Resource{ get{ return m_Resource; } }
		public Type[] ResourceTypes{ get{ return m_ResourceTypes; } }

		public CraftResourceInfo( int hue, int number, string name, double skillReq, CraftResource resource, params Type[] resourceTypes )
		{
			m_Hue = hue;
			m_Number = number;
			m_Name = name;
            m_SkillReq = skillReq;
			m_Resource = resource;
			m_ResourceTypes = resourceTypes;

			for ( int i = 0; i < resourceTypes.Length; ++i )
				CraftResources.RegisterType( resourceTypes[i], resource );
		}
	}

	public class CraftResources
	{
		private static CraftResourceInfo[] m_MetalInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1053109, "Fer", 0,			CraftResource.Fer,				typeof( FerIngot ), 		typeof( FerOre ),			typeof( Granite ) ),
				new CraftResourceInfo( 1542, 1053108, "Cuivre",	40,         CraftResource.Cuivre,   		typeof( CuivreIngot ),	    typeof( CuivreOre ),       	typeof( CuivreGranite ) ),
				new CraftResourceInfo( 2469,  1053107, "Bronze", 40,   	    CraftResource.Bronze,   		typeof( BronzeIngot ),  	typeof( BronzeOre ),    	typeof( BronzeGranite ) ),
				new CraftResourceInfo( 2394, 1053106, "Acier", 60,		    CraftResource.Acier,			typeof( AcierIngot ),		typeof( AcierOre ), 		typeof( AcierGranite ) ),
				new CraftResourceInfo( 2357, 1053105, "Argent",	60,	        CraftResource.Argent,			typeof( ArgentIngot ),		typeof( ArgentOre ),		typeof( ArgentGranite ) ),
				new CraftResourceInfo( 2360,  1053104, "Or", 60,			CraftResource.Or,				typeof( OrIngot ),	    	typeof( OrOre ),			typeof( OrGranite ) ),
				new CraftResourceInfo( 2438,  1053103, "Mytheril", 80,		CraftResource.Mytheril,			typeof( MytherilIngot ),	typeof( MytherilOre ),		typeof( MytherilGranite ) ),
				new CraftResourceInfo( 1953,  1053102, "Luminium", 80,		CraftResource.Luminium,			typeof( LuminiumIngot ),	typeof( LuminiumOre ),		typeof( LuminiumGranite ) ),
				new CraftResourceInfo( 2041, 1053101, "Obscurium", 80,		CraftResource.Obscurium,		typeof( ObscuriumIngot ),	typeof( ObscuriumOre ),		typeof( ObscuriumGranite ) ),
                new CraftResourceInfo( 2331,  1053101, "Mystirium", 90,	    CraftResource.Mystirium,		typeof( MystiriumIngot ),	typeof( MystiriumOre ),		typeof( MystiriumGranite ) ),
                new CraftResourceInfo( 2358,  1053101, "Dominium", 90,		CraftResource.Dominium,		    typeof( DominiumIngot ),	typeof( DominiumOre ),		typeof( DominiumGranite ) ),
                new CraftResourceInfo( 2037,  1053101, "Eclarium", 100,	CraftResource.Eclarium,		    typeof( EclariumIngot ),	typeof( EclariumOre ),		typeof( EclariumGranite ) ),
                new CraftResourceInfo( 2391,  1053101, "Venarium", 90,		CraftResource.Venarium,		    typeof( VenariumIngot ),	typeof( VenariumOre ),		typeof( VenariumGranite ) ),
                new CraftResourceInfo( 2380,  1053101, "Athenium", 100,		CraftResource.Athenium,		    typeof( AtheniumIngot ),	typeof( AtheniumOre ),		typeof( AtheniumGranite ) ),
                new CraftResourceInfo( 2062,  1053101, "Umbrarium", 100,	CraftResource.Umbrarium,		typeof( UmbrariumIngot ),	typeof( UmbrariumOre ),		typeof( UmbrariumGranite ) ),
			};

		private static CraftResourceInfo[] m_ScaleInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0, 1053129, "Normal", 0,	        	CraftResource.RegularScales,		typeof( RegularScales ) ),
				new CraftResourceInfo( 2059, 1053130, "Nordique", 0,	    CraftResource.NordiqueScales,		typeof( NordiqueScales ) ),
				new CraftResourceInfo( 2164, 1053131, "Desertique", 0,	    CraftResource.DesertiqueScales,		typeof( DesertiqueScales ) ),
				new CraftResourceInfo( 2123, 1053132, "Maritime", 0,	    CraftResource.MaritimeScales,		typeof( MaritimeScales ) ),
				new CraftResourceInfo( 2375, 1053133, "Volcanique", 0,	    CraftResource.VolcaniqueScales,		typeof( VolcaniqueScales ) ),
				new CraftResourceInfo( 2174, 1053134, "Ancien", 0,	        CraftResource.AncienScales, 		typeof( AncienScales ) ),
                new CraftResourceInfo( 1953, 1053134, "Wyrmique", 0,	    CraftResource.WyrmScales, 		    typeof( WyrmScales ) )
			};

		private static CraftResourceInfo[] m_LeatherInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1049353, "Normal", 0,		    CraftResource.RegularLeather,	typeof( Leather ),			typeof( Hides ) ),
                new CraftResourceInfo( 2065, 1049356, "Lupus", 50,		    CraftResource.LupusLeather, 	typeof( LupusLeather ),	    typeof( LupusHides ) ),
                new CraftResourceInfo( 2180, 1049354, "Reptilien", 50,		CraftResource.ReptilienLeather,	typeof( ReptilienLeather ),	typeof( ReptilienHides ) ),
				new CraftResourceInfo( 2059, 1049354, "Nordique", 50,		CraftResource.NordiqueLeather,	typeof( NordiqueLeather ),	typeof( NordiqueHides ) ),
				new CraftResourceInfo( 2164, 1049355, "Desertique", 50, 	CraftResource.DesertiqueLeather,typeof( DesertiqueLeather ),typeof( DesertiqueHides ) ),
				new CraftResourceInfo( 2464, 1049356, "Maritime", 60,		CraftResource.MaritimeLeather,	typeof( MaritimeLeather ),	typeof( MaritimeHides ) ),
                new CraftResourceInfo( 2375, 1049356, "Volcanique", 60,     CraftResource.VolcaniqueLeather,typeof( VolcaniqueLeather ),typeof( VolcaniqueHides ) ),
				new CraftResourceInfo( 2167, 1049356, "Geant", 60,  		CraftResource.GeantLeather, 	typeof( GeantLeather ),	    typeof( GeantHides ) ),
                new CraftResourceInfo( 2373, 1049356, "Minotaure", 70,  	CraftResource.MinotaurLeather, 	typeof( MinotaureLeather ),	typeof( MinotaureHides ) ),
				new CraftResourceInfo( 2234, 1049356, "Ophidien", 70,		CraftResource.OphidienLeather,	typeof( OphidienLeather ),	typeof( OphidienHides ) ),
				new CraftResourceInfo( 2448, 1049356, "Arachnide", 70,		CraftResource.ArachnideLeather,	typeof( ArachnideLeather ),	typeof( ArachnideHides ) ),
                new CraftResourceInfo( 2459, 1049356, "Magique", 80, 		CraftResource.MagiqueLeather,	typeof( MagiqueLeather ),	typeof( MagiqueHides ) ),
				new CraftResourceInfo( 2398, 1049356, "Ancien", 80, 	    CraftResource.AncienLeather,	typeof( AncienLeather ),	typeof( AncienHides ) ),
				new CraftResourceInfo( 2076, 1049356, "Demoniaque", 80, 	CraftResource.DemoniaqueLeather,typeof( DemoniaqueLeather ),typeof( DemoniaqueHides ) ),
				new CraftResourceInfo( 2146, 1049356, "Dragonique", 90,	    CraftResource.DragoniqueLeather,typeof( DragoniqueLeather ),typeof( DragoniqueHides ) )
			};

        private static CraftResourceInfo[] m_BonesInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1049353, "Normal", 0,		    CraftResource.RegularBones,	    typeof( Bone ),			typeof( Bone ) ),
                new CraftResourceInfo( 2360, 1049353, "Gobelin", 50,		CraftResource.GobelinBones,	    typeof( GobelinBone ),	typeof( GobelinBone ) ),
                new CraftResourceInfo( 2246, 1049354, "Reptilien", 50,		CraftResource.ReptilienBones,	typeof( ReptilienBone ),	typeof( ReptilienBone ) ),
				new CraftResourceInfo( 2343, 1049354, "Nordique", 50,		CraftResource.NordiqueBones,	typeof( NordiqueBone ),	typeof( NordiqueBone ) ),
				new CraftResourceInfo( 2460, 1049355, "Desertique", 50, 	CraftResource.DesertiqueBones,	typeof( DesertiqueBone ),typeof( DesertiqueBone ) ),
				new CraftResourceInfo( 2235, 1049356, "Maritime", 60,		CraftResource.MaritimeBones,	typeof( MaritimeBone ),	typeof( MaritimeBone ) ),
                new CraftResourceInfo( 2454, 1049356, "Volcanique", 60,	    CraftResource.VolcaniqueBones,	typeof( VolcaniqueBone ),typeof( VolcaniqueBone ) ),
                new CraftResourceInfo( 2164, 1049356, "Geant", 60,		    CraftResource.GeantBones,   	typeof( GeantBone ),	typeof( GeantBone ) ),
                new CraftResourceInfo( 2168, 1049356, "Minotaure", 70,		CraftResource.MinotaureBones,   typeof( MinotaureBone ),typeof( MinotaureBone ) ),
				new CraftResourceInfo( 2076, 1049356, "Ophidien", 70,		CraftResource.OphidienBones,	typeof( OphidienBone ),	typeof( OphidienBone ) ),
                new CraftResourceInfo( 2390, 1049356, "Arachnide", 70,		CraftResource.ArachnideBones,	typeof( ArachnideBone ),typeof( ArachnideBone ) ),
                new CraftResourceInfo( 2238, 1049356, "Magique", 80,		CraftResource.MagiqueBones,  	typeof( MagiqueBone ),	typeof( MagiqueBone ) ),
                new CraftResourceInfo( 2396, 1049356, "Ancien", 80,	CraftResource.AncienBones,  	typeof( AncienBone ),	typeof( AncienBone ) ),
                new CraftResourceInfo( 2160, 1049356, "Demoniaque", 80,     CraftResource.DemonBones,   	typeof( DemonBone ),	typeof( DemonBone ) ),
				new CraftResourceInfo( 1940, 1049356, "Dragonique", 90,     CraftResource.DragonBones,  	typeof( DragonBone ),	typeof( DragonBone ) ),
			};

		private static CraftResourceInfo[] m_AOSLeatherInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1049353, "Normal",0,		CraftResource.RegularLeather,	typeof( Leather ),			typeof( Hides ) )
				//new CraftResourceInfo( 0x8AC, 1049354, "Spined",		CraftAttributeInfo.Spined,		CraftResource.SpinedLeather,	typeof( SpinedLeather ),	typeof( SpinedHides ) ),
				//new CraftResourceInfo( 0x845, 1049355, "Horned",		CraftAttributeInfo.Horned,		CraftResource.HornedLeather,	typeof( HornedLeather ),	typeof( HornedHides ) ),
				//new CraftResourceInfo( 0x851, 1049356, "Barbed",		CraftAttributeInfo.Barbed,		CraftResource.BarbedLeather,	typeof( BarbedLeather ),	typeof( BarbedHides ) ),
			};

		private static CraftResourceInfo[] m_WoodInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1011542, "Erable",0,      CraftResource.RegularWood,	typeof( Log ),			typeof( Board ) ),
				new CraftResourceInfo( 2263, 1072533, "Pin", 10,		CraftResource.PinWood,		typeof( PinLog ),		typeof( PinBoard ) ),
				new CraftResourceInfo( 2246, 1072534, "Cyprès", 20,	    CraftResource.CypresWood,	typeof( CypresLog ),	typeof( CypresBoard ) ),
				new CraftResourceInfo( 2450, 1072535, "Cèdre", 30,	    CraftResource.CedreWood,	typeof( CedreLog ),		typeof( CedreBoard ) ),
				new CraftResourceInfo( 2170, 1072536, "Saule", 40,		CraftResource.SauleWood,	typeof( SauleLog ),	    typeof( SauleBoard ) ),
				new CraftResourceInfo( 2144, 1072538, "Chêne", 50,		CraftResource.CheneWood,	typeof( CheneLog ),	    typeof( CheneBoard ) ),
				new CraftResourceInfo( 2055, 1072539, "Ébène", 60,		CraftResource.EbeneWood,	typeof( EbeneLog ),	    typeof( EbeneBoard ) ),
                new CraftResourceInfo( 2153, 1072539, "Acajou", 70,     CraftResource.AcajouWood,	typeof( AcajouLog ),	typeof( AcajouBoard ) )
			};

		/// <summary>
		/// Returns true if '<paramref name="resource"/>' is None, Iron, RegularLeather or RegularWood. False if otherwise.
		/// </summary>
		public static bool IsStandard( CraftResource resource )
		{
			return ( resource == CraftResource.None || resource == CraftResource.Fer || resource == CraftResource.RegularLeather || resource == CraftResource.RegularWood );
		}

		private static Hashtable m_TypeTable;

		/// <summary>
		/// Registers that '<paramref name="resourceType"/>' uses '<paramref name="resource"/>' so that it can later be queried by <see cref="CraftResources.GetFromType"/>
		/// </summary>
		public static void RegisterType( Type resourceType, CraftResource resource )
		{
			if ( m_TypeTable == null )
				m_TypeTable = new Hashtable();

			m_TypeTable[resourceType] = resource;
		}

		/// <summary>
		/// Returns the <see cref="CraftResource"/> value for which '<paramref name="resourceType"/>' uses -or- CraftResource.None if an unregistered type was specified.
		/// </summary>
		public static CraftResource GetFromType( Type resourceType )
		{
			if ( m_TypeTable == null )
				return CraftResource.None;

			object obj = m_TypeTable[resourceType];

			if ( !(obj is CraftResource) )
				return CraftResource.None;

			return (CraftResource)obj;
		}

		/// <summary>
		/// Returns a <see cref="CraftResourceInfo"/> instance describing '<paramref name="resource"/>' -or- null if an invalid resource was specified.
		/// </summary>
		public static CraftResourceInfo GetInfo( CraftResource resource )
		{
			CraftResourceInfo[] list = null;

			switch ( GetType( resource ) )
			{
				case CraftResourceType.Metal: list = m_MetalInfo; break;
				case CraftResourceType.Leather: list = m_LeatherInfo; break;
                case CraftResourceType.Bones: list = m_BonesInfo; break;
				case CraftResourceType.Scales: list = m_ScaleInfo; break;
				case CraftResourceType.Wood: list = m_WoodInfo; break;
			}

			if ( list != null )
			{
				int index = GetIndex( resource );

				if ( index >= 0 && index < list.Length )
					return list[index];
			}

			return null;
		}

		/// <summary>
		/// Returns a <see cref="CraftResourceType"/> value indiciating the type of '<paramref name="resource"/>'.
		/// </summary>
		public static CraftResourceType GetType( CraftResource resource )
		{
			if ( resource >= CraftResource.Fer && resource <= CraftResource.Umbrarium )
				return CraftResourceType.Metal;

			if ( resource >= CraftResource.RegularLeather && resource <= CraftResource.LupusLeather )
				return CraftResourceType.Leather;

			if ( resource >= CraftResource.RegularScales && resource <= CraftResource.WyrmScales )
				return CraftResourceType.Scales;

			if ( resource >= CraftResource.RegularWood && resource <= CraftResource.AcajouWood )
				return CraftResourceType.Wood;

            if (resource >= CraftResource.RegularBones && resource <= CraftResource.DragonBones )
                return CraftResourceType.Bones;

			return CraftResourceType.None;
		}

		/// <summary>
		/// Returns the first <see cref="CraftResource"/> in the series of resources for which '<paramref name="resource"/>' belongs.
		/// </summary>
		public static CraftResource GetStart( CraftResource resource )
		{
			switch ( GetType( resource ) )
			{
				case CraftResourceType.Metal: return CraftResource.Fer;
				case CraftResourceType.Leather: return CraftResource.RegularLeather;
                case CraftResourceType.Bones: return CraftResource.RegularBones;
				case CraftResourceType.Scales: return CraftResource.RegularScales;
				case CraftResourceType.Wood: return CraftResource.RegularWood;
			}

			return CraftResource.None;
		}

		/// <summary>
		/// Returns the index of '<paramref name="resource"/>' in the seriest of resources for which it belongs.
		/// </summary>
		public static int GetIndex( CraftResource resource )
		{
			CraftResource start = GetStart( resource );

			if ( start == CraftResource.None )
				return 0;

			return (int)(resource - start);
		}

		/// <summary>
		/// Returns the <see cref="CraftResourceInfo.Number"/> property of '<paramref name="resource"/>' -or- 0 if an invalid resource was specified.
		/// </summary>
		public static int GetLocalizationNumber( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? 0 : info.Number );
		}

		/// <summary>
		/// Returns the <see cref="CraftResourceInfo.Hue"/> property of '<paramref name="resource"/>' -or- 0 if an invalid resource was specified.
		/// </summary>
		public static int GetHue( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? 0 : info.Hue );
		}

		/// <summary>
		/// Returns the <see cref="CraftResourceInfo.Name"/> property of '<paramref name="resource"/>' -or- an empty string if the resource specified was invalid.
		/// </summary>
		public static string GetName( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? String.Empty : info.Name );
		}

        public static double GetSkill( CraftResource resource )
        {
            CraftResourceInfo info = GetInfo(resource);

            return (info == null ? 0 : info.SkillReq);
        }

		/// <summary>
		/// Returns the <see cref="CraftResource"/> value which represents '<paramref name="info"/>' -or- CraftResource.None if unable to convert.
		/// </summary>
		public static CraftResource GetFromOreInfo( OreInfo info )
		{
			/*if ( info.Name.IndexOf( "Spined" ) >= 0 )
				return CraftResource.SpinedLeather;
			else if ( info.Name.IndexOf( "Horned" ) >= 0 )
				return CraftResource.HornedLeather;
			else if ( info.Name.IndexOf( "Barbed" ) >= 0 )
				return CraftResource.BarbedLeather;
			else if ( info.Name.IndexOf( "Leather" ) >= 0 )
				return CraftResource.RegularLeather;*/

			if ( info.Level == 0 )
				return CraftResource.Fer;
			else if ( info.Level == 1 )
				return CraftResource.Cuivre;
			else if ( info.Level == 2 )
				return CraftResource.Bronze;
			else if ( info.Level == 3 )
				return CraftResource.Acier;
			else if ( info.Level == 4 )
				return CraftResource.Argent;
			else if ( info.Level == 5 )
				return CraftResource.Or;
			else if ( info.Level == 6 )
				return CraftResource.Mytheril;
			else if ( info.Level == 7 )
				return CraftResource.Luminium;
			else if ( info.Level == 8 )
				return CraftResource.Obscurium;
            else if ( info.Level == 9 )
                return CraftResource.Mystirium;
            else if ( info.Level == 10 )
                return CraftResource.Dominium;
            else if ( info.Level == 11 )
                return CraftResource.Eclarium;
            else if ( info.Level == 12 )
                return CraftResource.Venarium;
            else if ( info.Level == 13 )
                return CraftResource.Athenium;
            else if ( info.Level == 14 )
                return CraftResource.Umbrarium;

			return CraftResource.None;
		}

		/// <summary>
		/// Returns the <see cref="CraftResource"/> value which represents '<paramref name="info"/>', using '<paramref name="material"/>' to help resolve leather OreInfo instances.
		/// </summary>
		public static CraftResource GetFromOreInfo( OreInfo info, ArmorMaterialType material )
		{
			if ( material == ArmorMaterialType.Studded || material == ArmorMaterialType.Leather )
			{
				if ( info.Level == 0 )
					return CraftResource.RegularLeather;
				else if ( info.Level == 1 )
					return CraftResource.NordiqueLeather;
				else if ( info.Level == 2 )
					return CraftResource.DesertiqueLeather;
				else if ( info.Level == 3 )
					return CraftResource.MaritimeLeather;
                else if (info.Level == 4)
                    return CraftResource.VolcaniqueLeather;
                else if (info.Level == 5)
                    return CraftResource.GeantLeather;
                else if (info.Level == 6)
                    return CraftResource.OphidienLeather;
                else if (info.Level == 7)
                    return CraftResource.ArachnideLeather;
                else if (info.Level == 8)
                    return CraftResource.AncienLeather;
                else if (info.Level == 9)
                    return CraftResource.DemoniaqueLeather;
                else if (info.Level == 10)
                    return CraftResource.DragoniqueLeather;
                else if (info.Level == 11)
                    return CraftResource.LupusLeather;

				return CraftResource.None;
			}

            if (material == ArmorMaterialType.Bone)
            {
                if (info.Level == 0)
                    return CraftResource.RegularBones;
                else if (info.Level == 1)
                    return CraftResource.NordiqueBones;
                else if (info.Level == 2)
                    return CraftResource.DesertiqueBones;
                else if (info.Level == 3)
                    return CraftResource.MaritimeBones;
                else if (info.Level == 4)
                    return CraftResource.VolcaniqueBones;
                else if (info.Level == 5)
                    return CraftResource.GeantBones;
                else if (info.Level == 6)
                    return CraftResource.OphidienBones;
                else if (info.Level == 7)
                    return CraftResource.ArachnideBones;
                else if (info.Level == 8)
                    return CraftResource.AncienBones;
                else if (info.Level == 9)
                    return CraftResource.DemonBones;
                else if (info.Level == 10)
                    return CraftResource.DragonBones;
            }

			return GetFromOreInfo( info );
		}
	}

	// NOTE: This class is only for compatability with very old RunUO versions.
	// No changes to it should be required for custom resources.
	public class OreInfo
	{
		public static readonly OreInfo Fer			= new OreInfo( 0, 0x000, "Fer" );
		public static readonly OreInfo Cuivre   	= new OreInfo( 1, 0x860, "Cuivre" );
		public static readonly OreInfo Bronze   	= new OreInfo( 2, 0x87b, "Bronze" );
		public static readonly OreInfo Acier   		= new OreInfo( 3, 0x811, "Acier" );
		public static readonly OreInfo Argent		= new OreInfo( 4, 0x7a1, "Argent" );
		public static readonly OreInfo Or			= new OreInfo( 5, 0x798, "Or" );
		public static readonly OreInfo Mytheril		= new OreInfo( 6, 0x796, "Mytheril" );
		public static readonly OreInfo Luminium		= new OreInfo( 7, 0x80e, "Luminium" );
		public static readonly OreInfo Obscurium	= new OreInfo( 8, 0x7f9, "Obscurium" );
        public static readonly OreInfo Mystirium    = new OreInfo( 9, 0x877, "Mystirium" );
        public static readonly OreInfo Dominium     = new OreInfo( 10, 0x794, "Dominium" );
        public static readonly OreInfo Eclarium     = new OreInfo( 11, 0x815, "Eclarium" );
        public static readonly OreInfo Venarium     = new OreInfo( 12, 0x88a, "Venarium" );
        public static readonly OreInfo Athenium     = new OreInfo( 13, 0x807, "Athenium" );
        public static readonly OreInfo Umbrarium    = new OreInfo( 14, 0x81c, "Umbrarium" );


		private int m_Level;
		private int m_Hue;
		private string m_Name;

		public OreInfo( int level, int hue, string name )
		{
			m_Level = level;
			m_Hue = hue;
			m_Name = name;
		}

		public int Level
		{
			get
			{
				return m_Level;
			}
		}

		public int Hue
		{
			get
			{
				return m_Hue;
			}
		}

		public string Name
		{
			get
			{
				return m_Name;
			}
		}
	}
}