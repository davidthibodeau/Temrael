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

	public class CraftAttributeInfo
	{
		private int m_WeaponContondantDamage;
		private int m_WeaponTranchantDamage;
		private int m_WeaponPerforantDamage;
		private int m_WeaponMagieDamage;
		private int m_WeaponChaosDamage;
		private int m_WeaponDirectDamage;
		private int m_WeaponDurability;
		//private int m_WeaponLuck;
		private int m_WeaponGoldIncrease;
		private int m_WeaponLowerRequirements;

		private int m_ArmorPhysicalResist;
		private int m_ArmorContondantResist;
		private int m_ArmorTranchantResist;
		private int m_ArmorPerforantResist;
		private int m_ArmorMagieResist;
		private int m_ArmorDurability;
		//private int m_ArmorLuck;
		private int m_ArmorGoldIncrease;
		private int m_ArmorLowerRequirements;

		private int m_RunicMinAttributes;
		private int m_RunicMaxAttributes;
		private int m_RunicMinIntensity;
		private int m_RunicMaxIntensity;

		public int WeaponContondantDamage{ get{ return m_WeaponContondantDamage; } set{ m_WeaponContondantDamage = value; } }
		public int WeaponTranchantDamage{ get{ return m_WeaponTranchantDamage; } set{ m_WeaponTranchantDamage = value; } }
		public int WeaponPerforantDamage{ get{ return m_WeaponPerforantDamage; } set{ m_WeaponPerforantDamage = value; } }
		public int WeaponMagieDamage{ get{ return m_WeaponMagieDamage; } set{ m_WeaponMagieDamage = value; } }
		public int WeaponChaosDamage{ get{ return m_WeaponChaosDamage; } set{ m_WeaponChaosDamage = value; } }
		public int WeaponDirectDamage{ get{ return m_WeaponDirectDamage; } set{ m_WeaponDirectDamage = value; } }
		public int WeaponDurability{ get{ return m_WeaponDurability; } set{ m_WeaponDurability = value; } }
		//public int WeaponLuck{ get{ return m_WeaponLuck; } set{ m_WeaponLuck = value; } }
		public int WeaponGoldIncrease{ get{ return m_WeaponGoldIncrease; } set{ m_WeaponGoldIncrease = value; } }
		public int WeaponLowerRequirements{ get{ return m_WeaponLowerRequirements; } set{ m_WeaponLowerRequirements = value; } }

		public int ArmorPhysicalResist{ get{ return m_ArmorPhysicalResist; } set{ m_ArmorPhysicalResist = value; } }
		public int ArmorContondantResist{ get{ return m_ArmorContondantResist; } set{ m_ArmorContondantResist = value; } }
		public int ArmorTranchantResist{ get{ return m_ArmorTranchantResist; } set{ m_ArmorTranchantResist = value; } }
		public int ArmorPerforantResist{ get{ return m_ArmorPerforantResist; } set{ m_ArmorPerforantResist = value; } }
		public int ArmorMagieResist{ get{ return m_ArmorMagieResist; } set{ m_ArmorMagieResist = value; } }
		public int ArmorDurability{ get{ return m_ArmorDurability; } set{ m_ArmorDurability = value; } }
		//public int ArmorLuck{ get{ return m_ArmorLuck; } set{ m_ArmorLuck = value; } }
		public int ArmorGoldIncrease{ get{ return m_ArmorGoldIncrease; } set{ m_ArmorGoldIncrease = value; } }
		public int ArmorLowerRequirements{ get{ return m_ArmorLowerRequirements; } set{ m_ArmorLowerRequirements = value; } }

		public int RunicMinAttributes{ get{ return m_RunicMinAttributes; } set{ m_RunicMinAttributes = value; } }
		public int RunicMaxAttributes{ get{ return m_RunicMaxAttributes; } set{ m_RunicMaxAttributes = value; } }
		public int RunicMinIntensity{ get{ return m_RunicMinIntensity; } set{ m_RunicMinIntensity = value; } }
		public int RunicMaxIntensity{ get{ return m_RunicMaxIntensity; } set{ m_RunicMaxIntensity = value; } }

		public CraftAttributeInfo()
		{
		}

		public static readonly CraftAttributeInfo Blank;
		public static readonly CraftAttributeInfo Cuivre, Bronze, Acier, Argent, Or, Mytheril, Luminium, Obscurium, Mystirium, Dominium, Eclarium, Venarium, Athenium, Umbrarium;
        public static readonly CraftAttributeInfo Gobelin, Reptilien, Nordique, Desertique, Maritime, Volcanique, Geant, Minotaure, Ophidien, Arachnide, Magique, Ancien, Demoniaque, Dragonique, Lupus, Balron, Wyrm;
        public static readonly CraftAttributeInfo ReptilienCuir, NordiqueCuir, DesertiqueCuir, MaritimeCuir, VolcaniqueCuir, GeantCuir, MinotaureCuir, OphidienCuir, ArachnideCuir, MagiqueCuir, AncienCuir, DemoniaqueCuir, DragoniqueCuir, LupusCuir;
		//public static readonly CraftAttributeInfo NordiqueScales, DesertiqueScales, MaritimeScales, VolcaniqueScales, AncienScales, WyrmScales;
		public static readonly CraftAttributeInfo PinWood, CypresWood, CedreWood, SauleWood, CheneWood, EbeneWood, AcajouWood;

		static CraftAttributeInfo()
		{
			Blank = new CraftAttributeInfo();

			CraftAttributeInfo cuivre = Cuivre = new CraftAttributeInfo();
            cuivre.WeaponDirectDamage = 1;
            cuivre.ArmorPhysicalResist = 1;
            cuivre.ArmorTranchantResist = 1;
            cuivre.ArmorContondantResist = 1;
            cuivre.ArmorPerforantResist = 1;
            cuivre.ArmorMagieResist = 1;
            cuivre.ArmorDurability = 100;
            cuivre.WeaponDurability = 50;
            cuivre.RunicMinAttributes = 2;
            cuivre.RunicMaxAttributes = 2;
            cuivre.RunicMinIntensity = 45;
            cuivre.RunicMaxIntensity = 100;
            cuivre.RunicMinIntensity = 10;
            cuivre.RunicMaxIntensity = 60;

			CraftAttributeInfo bronze = Bronze = new CraftAttributeInfo();
            bronze.WeaponDirectDamage = 1;
            bronze.ArmorPhysicalResist = 1;
            bronze.ArmorTranchantResist = 1;
            bronze.ArmorContondantResist = 1;
            bronze.ArmorPerforantResist = 1;
            bronze.ArmorMagieResist = 1;
            bronze.ArmorDurability = 100;
            bronze.WeaponDurability = 50;
            bronze.RunicMinAttributes = 2;
            bronze.RunicMaxAttributes = 2;
            bronze.RunicMinIntensity = 45;
            bronze.RunicMaxIntensity = 100;
            bronze.RunicMinIntensity = 10;
            bronze.RunicMaxIntensity = 60;


            CraftAttributeInfo acier = Acier = new CraftAttributeInfo();
            acier.WeaponDirectDamage = 2;
            acier.ArmorPhysicalResist = 2;
            acier.ArmorTranchantResist = 2;
            acier.ArmorContondantResist = 2;
            acier.ArmorPerforantResist = 2;
            acier.ArmorMagieResist = 2;
            acier.RunicMinAttributes = 3;
            acier.RunicMaxAttributes = 3;
            acier.RunicMinIntensity = 20;
            acier.RunicMaxIntensity = 70;

            CraftAttributeInfo argent = Argent = new CraftAttributeInfo();
            argent.WeaponDirectDamage = 2;
            argent.ArmorPhysicalResist = 2;
            argent.ArmorTranchantResist = 2;
            argent.ArmorContondantResist = 2;
            argent.ArmorPerforantResist = 2;
            argent.ArmorMagieResist = 2;
            argent.RunicMinAttributes = 3;
            argent.RunicMaxAttributes = 3;
            argent.RunicMinIntensity = 20;
            argent.RunicMaxIntensity = 70;

			CraftAttributeInfo or = Or = new CraftAttributeInfo();
            or.WeaponDirectDamage = 2;
            or.ArmorPhysicalResist = 2;
            or.ArmorTranchantResist = 2;
            or.ArmorContondantResist = 2;
            or.ArmorPerforantResist = 2;
            or.ArmorMagieResist = 2;
            or.RunicMinAttributes = 3;
            or.RunicMaxAttributes = 3;
            or.RunicMinIntensity = 20;
            or.RunicMaxIntensity = 70;

            or.ArmorLowerRequirements = 30;
            or.WeaponLowerRequirements = 50;

            CraftAttributeInfo mytheril = Mytheril = new CraftAttributeInfo();
            mytheril.WeaponDirectDamage = 3;
            mytheril.ArmorPhysicalResist = 3;
            mytheril.ArmorTranchantResist = 3;
            mytheril.ArmorContondantResist = 3;
            mytheril.ArmorPerforantResist = 3;
            mytheril.ArmorMagieResist = 3;
            mytheril.RunicMinAttributes = 4;
            mytheril.RunicMaxAttributes = 4;
            mytheril.RunicMinIntensity = 30;
            mytheril.RunicMaxIntensity = 80;

            CraftAttributeInfo luminium = Luminium = new CraftAttributeInfo();
            luminium.WeaponDirectDamage = 3;
            luminium.ArmorPhysicalResist = 3;
            luminium.ArmorTranchantResist = 3;
            luminium.ArmorContondantResist = 3;
            luminium.ArmorPerforantResist = 3;
            luminium.ArmorMagieResist = 3;
            luminium.RunicMinAttributes = 4;
            luminium.RunicMaxAttributes = 4;
            luminium.RunicMinIntensity = 30;
            luminium.RunicMaxIntensity = 80;

            CraftAttributeInfo obscurium = Obscurium = new CraftAttributeInfo();
            obscurium.WeaponDirectDamage = 3;
            obscurium.ArmorPhysicalResist = 3;
            obscurium.ArmorTranchantResist = 3;
            obscurium.ArmorContondantResist = 3;
            obscurium.ArmorPerforantResist = 3;
            obscurium.ArmorMagieResist = 3;
            obscurium.RunicMinAttributes = 4;
            obscurium.RunicMaxAttributes = 4;
            obscurium.RunicMinIntensity = 30;
            obscurium.RunicMaxIntensity = 80;

            CraftAttributeInfo mystirium = Mystirium = new CraftAttributeInfo();
            mystirium.WeaponDirectDamage = 4;
            mystirium.ArmorPhysicalResist = 4;
            mystirium.ArmorContondantResist = 4;
            mystirium.ArmorTranchantResist = 4;
            mystirium.ArmorPerforantResist = 4;
            mystirium.ArmorMagieResist = 4;
            mystirium.RunicMinAttributes = 5;
            mystirium.RunicMaxAttributes = 5;
            mystirium.RunicMinIntensity = 40;
            mystirium.RunicMaxIntensity = 90;

            mystirium.ArmorDurability = 50;

            CraftAttributeInfo dominium = Dominium = new CraftAttributeInfo();
            dominium.WeaponDirectDamage = 4;
            dominium.ArmorPhysicalResist = 4;
            dominium.ArmorContondantResist = 4;
            dominium.ArmorTranchantResist = 4;
            dominium.ArmorPerforantResist = 4;
            dominium.ArmorMagieResist = 4;
            dominium.RunicMinAttributes = 5;
            dominium.RunicMaxAttributes = 5;
            dominium.RunicMinIntensity = 40;
            dominium.RunicMaxIntensity = 90;

            dominium.ArmorDurability = 50;

            CraftAttributeInfo venarium = Venarium = new CraftAttributeInfo();
            venarium.WeaponDirectDamage = 4;
            venarium.ArmorPhysicalResist = 4;
            venarium.ArmorContondantResist = 4;
            venarium.ArmorTranchantResist = 4;
            venarium.ArmorPerforantResist = 4;
            venarium.ArmorMagieResist = 4;
            venarium.RunicMinAttributes = 5;
            venarium.RunicMaxAttributes = 5;
            venarium.RunicMinIntensity = 40;
            venarium.RunicMaxIntensity = 90;

            venarium.ArmorDurability = 50;

            CraftAttributeInfo eclarium = Eclarium = new CraftAttributeInfo();
            eclarium.WeaponDirectDamage = 5;
            eclarium.ArmorPhysicalResist = 5;
            eclarium.ArmorContondantResist = 5;
            eclarium.ArmorTranchantResist = 5;
            eclarium.ArmorPerforantResist = 5;
            eclarium.ArmorMagieResist = 5;
            eclarium.ArmorDurability = 50;
            eclarium.RunicMinAttributes = 6;
            eclarium.RunicMaxAttributes = 6;
            eclarium.RunicMinIntensity = 50;
            eclarium.RunicMaxIntensity = 100;

            CraftAttributeInfo athenium = Athenium = new CraftAttributeInfo();
            athenium.WeaponDirectDamage = 5;
            athenium.ArmorPhysicalResist = 5;
            athenium.ArmorContondantResist = 5;
            athenium.ArmorTranchantResist = 5;
            athenium.ArmorPerforantResist = 5;
            athenium.ArmorMagieResist = 5;
            athenium.ArmorDurability = 50;
            athenium.RunicMinAttributes = 6;
            athenium.RunicMaxAttributes = 6;
            athenium.RunicMinIntensity = 50;
            athenium.RunicMaxIntensity = 100;

            CraftAttributeInfo umbarium = Umbrarium = new CraftAttributeInfo();
            umbarium.WeaponDirectDamage = 5;
            umbarium.ArmorPhysicalResist = 5;
            umbarium.ArmorContondantResist = 5;
            umbarium.ArmorTranchantResist = 5;
            umbarium.ArmorPerforantResist = 5;
            umbarium.ArmorMagieResist = 5;
            umbarium.ArmorDurability = 50;
            umbarium.RunicMinAttributes = 6;
            umbarium.RunicMaxAttributes = 6;
            umbarium.RunicMinIntensity = 50;
            umbarium.RunicMaxIntensity = 100;

            CraftAttributeInfo gobelin = Gobelin = new CraftAttributeInfo();
            gobelin.ArmorPhysicalResist = 3;
            gobelin.ArmorContondantResist = 3;
            gobelin.ArmorTranchantResist = 3;
            gobelin.ArmorPerforantResist = 3;
            gobelin.ArmorMagieResist = 3;
            gobelin.RunicMinAttributes = 2;
            gobelin.RunicMaxAttributes = 2;
            gobelin.RunicMinIntensity = 10;
            gobelin.RunicMaxIntensity = 60;

            CraftAttributeInfo reptilien = Reptilien = new CraftAttributeInfo();
            reptilien.ArmorPhysicalResist = 3;
            reptilien.ArmorContondantResist = 3;
            reptilien.ArmorTranchantResist = 3;
            reptilien.ArmorPerforantResist = 3;
            reptilien.ArmorMagieResist = 3;
            reptilien.RunicMinAttributes = 2;
            reptilien.RunicMaxAttributes = 2;
            reptilien.RunicMinIntensity = 10;
            reptilien.RunicMaxIntensity = 60;

			CraftAttributeInfo nordique = Nordique = new CraftAttributeInfo();
            nordique.ArmorPhysicalResist = 3;
            nordique.ArmorContondantResist = 3;
            nordique.ArmorTranchantResist = 3;
            nordique.ArmorPerforantResist = 3;
            nordique.ArmorMagieResist = 3;
            nordique.RunicMinAttributes = 2;
            nordique.RunicMaxAttributes = 2;
            nordique.RunicMinIntensity = 10;
            nordique.RunicMaxIntensity = 60;

			CraftAttributeInfo desertique = Desertique = new CraftAttributeInfo();
            desertique.ArmorPhysicalResist = 3;
            desertique.ArmorContondantResist = 3;
            desertique.ArmorTranchantResist = 3;
            desertique.ArmorPerforantResist = 3;
            desertique.ArmorMagieResist = 3;
            desertique.RunicMinAttributes = 2;
            desertique.RunicMaxAttributes = 2;
            desertique.RunicMinIntensity = 10;
            desertique.RunicMaxIntensity = 60;

			CraftAttributeInfo maritime = Maritime = new CraftAttributeInfo();
            maritime.ArmorPhysicalResist = 6;
            maritime.ArmorContondantResist = 6;
            maritime.ArmorTranchantResist = 6;
            maritime.ArmorPerforantResist = 6;
            maritime.ArmorMagieResist = 6;
            maritime.RunicMinAttributes = 3;
            maritime.RunicMaxAttributes = 3;
            maritime.RunicMinIntensity = 20;
            maritime.RunicMaxIntensity = 70;

            CraftAttributeInfo volcanique = Volcanique = new CraftAttributeInfo();
            volcanique.ArmorPhysicalResist = 6;
            volcanique.ArmorContondantResist = 6;
            volcanique.ArmorTranchantResist = 6;
            volcanique.ArmorPerforantResist = 6;
            volcanique.ArmorMagieResist = 6;
            volcanique.RunicMinAttributes = 3;
            volcanique.RunicMaxAttributes = 3;
            volcanique.RunicMinIntensity = 20;
            volcanique.RunicMaxIntensity = 70;

            CraftAttributeInfo geant = Geant = new CraftAttributeInfo();
            geant.ArmorPhysicalResist = 6;
            geant.ArmorContondantResist = 6;
            geant.ArmorTranchantResist = 6;
            geant.ArmorPerforantResist = 6;
            geant.ArmorMagieResist = 6;
            geant.RunicMinAttributes = 3;
            geant.RunicMaxAttributes = 3;
            geant.RunicMinIntensity = 20;
            geant.RunicMaxIntensity = 70;

            CraftAttributeInfo minotaure = Minotaure = new CraftAttributeInfo();
            minotaure.ArmorPhysicalResist = 9;
            minotaure.ArmorContondantResist = 9;
            minotaure.ArmorTranchantResist = 9;
            minotaure.ArmorPerforantResist = 9;
            minotaure.ArmorMagieResist = 9;
            minotaure.RunicMinAttributes = 4;
            minotaure.RunicMaxAttributes = 4;
            minotaure.RunicMinIntensity = 30;
            minotaure.RunicMaxIntensity = 80;

            CraftAttributeInfo ophidien = Ophidien = new CraftAttributeInfo();
            ophidien.ArmorPhysicalResist = 9;
            ophidien.ArmorContondantResist = 9;
            ophidien.ArmorTranchantResist = 9;
            ophidien.ArmorPerforantResist = 9;
            ophidien.ArmorMagieResist = 9;
            ophidien.RunicMinAttributes = 4;
            ophidien.RunicMaxAttributes = 4;
            ophidien.RunicMinIntensity = 30;
            ophidien.RunicMaxIntensity = 80;

            CraftAttributeInfo arachnide = Arachnide = new CraftAttributeInfo();
            arachnide.ArmorPhysicalResist = 9;
            arachnide.ArmorContondantResist = 9;
            arachnide.ArmorTranchantResist = 9;
            arachnide.ArmorPerforantResist = 9;
            arachnide.ArmorMagieResist = 9;
            arachnide.RunicMinAttributes = 4;
            arachnide.RunicMaxAttributes = 4;
            arachnide.RunicMinIntensity = 30;
            arachnide.RunicMaxIntensity = 80;

            CraftAttributeInfo magique = Magique = new CraftAttributeInfo();
            magique.ArmorPhysicalResist = 12;
            magique.ArmorContondantResist = 12;
            magique.ArmorTranchantResist = 12;
            magique.ArmorPerforantResist = 12;
            magique.ArmorMagieResist = 14;
            magique.RunicMinAttributes = 5;
            magique.RunicMaxAttributes = 5;
            magique.RunicMinIntensity = 40;
            magique.RunicMaxIntensity = 90;

            CraftAttributeInfo ancien = Ancien = new CraftAttributeInfo();
            ancien.ArmorPhysicalResist = 12;
            ancien.ArmorContondantResist = 12;
            ancien.ArmorTranchantResist = 12;
            ancien.ArmorPerforantResist = 12;
            ancien.ArmorMagieResist = 12;
            ancien.RunicMinAttributes = 5;
            ancien.RunicMaxAttributes = 5;
            ancien.RunicMinIntensity = 40;
            ancien.RunicMaxIntensity = 90;

            CraftAttributeInfo demoniaque = Demoniaque = new CraftAttributeInfo();
            demoniaque.ArmorPhysicalResist = 12;
            demoniaque.ArmorContondantResist = 12;
            demoniaque.ArmorTranchantResist = 12;
            demoniaque.ArmorPerforantResist = 12;
            demoniaque.ArmorMagieResist = 12;
            demoniaque.RunicMinAttributes = 5;
            demoniaque.RunicMaxAttributes = 5;
            demoniaque.RunicMinIntensity = 40;
            demoniaque.RunicMaxIntensity = 90;

            CraftAttributeInfo dragonique = Dragonique = new CraftAttributeInfo();
            dragonique.ArmorPhysicalResist = 15;
            dragonique.ArmorContondantResist = 15;
            dragonique.ArmorTranchantResist = 15;
            dragonique.ArmorPerforantResist = 15;
            dragonique.ArmorMagieResist = 15;
            dragonique.RunicMinAttributes = 6;
            dragonique.RunicMaxAttributes = 6;
            dragonique.RunicMinIntensity = 50;
            dragonique.RunicMaxIntensity = 100;

            CraftAttributeInfo balron = Balron = new CraftAttributeInfo();
            balron.ArmorPhysicalResist = 15;
            balron.ArmorContondantResist = 15;
            balron.ArmorTranchantResist = 15;
            balron.ArmorPerforantResist = 15;
            balron.ArmorMagieResist = 15;
            balron.RunicMinAttributes = 6;
            balron.RunicMaxAttributes = 6;
            balron.RunicMinIntensity = 50;
            balron.RunicMaxIntensity = 100;

            CraftAttributeInfo wyrm = Wyrm = new CraftAttributeInfo();
            wyrm.ArmorPhysicalResist = 15;
            wyrm.ArmorContondantResist = 15;
            wyrm.ArmorTranchantResist = 15;
            wyrm.ArmorPerforantResist = 15;
            wyrm.ArmorMagieResist = 15;
            wyrm.RunicMinAttributes = 6;
            wyrm.RunicMaxAttributes = 6;
            wyrm.RunicMinIntensity = 50;
            wyrm.RunicMaxIntensity = 100;

            CraftAttributeInfo reptilienCuir = ReptilienCuir = new CraftAttributeInfo();
            reptilienCuir.ArmorPhysicalResist = 0;
            reptilienCuir.ArmorContondantResist = 0;
            reptilienCuir.ArmorTranchantResist = 0;
            reptilienCuir.ArmorPerforantResist = 0;
            reptilienCuir.ArmorMagieResist = 0;
            reptilienCuir.RunicMinAttributes = 2;
            reptilienCuir.RunicMaxAttributes = 2;
            reptilienCuir.RunicMinIntensity = 10;
            reptilienCuir.RunicMaxIntensity = 60;

            CraftAttributeInfo nordiqueCuir = NordiqueCuir = new CraftAttributeInfo();
            nordiqueCuir.ArmorPhysicalResist = 0;
            nordiqueCuir.ArmorContondantResist = 0;
            nordiqueCuir.ArmorTranchantResist = 0;
            nordiqueCuir.ArmorPerforantResist = 0;
            nordiqueCuir.ArmorMagieResist = 0;
            nordiqueCuir.RunicMinAttributes = 2;
            nordiqueCuir.RunicMaxAttributes = 2;
            nordiqueCuir.RunicMinIntensity = 10;
            nordiqueCuir.RunicMaxIntensity = 60;

            CraftAttributeInfo desertiqueCuir = DesertiqueCuir = new CraftAttributeInfo();
            desertiqueCuir.ArmorPhysicalResist = 0;
            desertiqueCuir.ArmorContondantResist = 0;
            desertiqueCuir.ArmorTranchantResist = 0;
            desertiqueCuir.ArmorPerforantResist = 0;
            desertiqueCuir.ArmorMagieResist = 0;
            desertiqueCuir.RunicMinAttributes = 2;
            desertiqueCuir.RunicMaxAttributes = 2;
            desertiqueCuir.RunicMinIntensity = 10;
            desertiqueCuir.RunicMaxIntensity = 60;

            CraftAttributeInfo maritimeCuir = MaritimeCuir = new CraftAttributeInfo();
            maritimeCuir.ArmorPhysicalResist = 3;
            maritimeCuir.ArmorContondantResist = 3;
            maritimeCuir.ArmorTranchantResist = 3;
            maritimeCuir.ArmorPerforantResist = 3;
            maritimeCuir.ArmorMagieResist = 3;
            maritimeCuir.RunicMinAttributes = 3;
            maritimeCuir.RunicMaxAttributes = 3;
            maritimeCuir.RunicMinIntensity = 20;
            maritimeCuir.RunicMaxIntensity = 70;

            CraftAttributeInfo volcaniqueCuir = VolcaniqueCuir = new CraftAttributeInfo();
            volcaniqueCuir.ArmorPhysicalResist = 3;
            volcaniqueCuir.ArmorContondantResist = 3;
            volcaniqueCuir.ArmorTranchantResist = 3;
            volcaniqueCuir.ArmorPerforantResist = 3;
            volcaniqueCuir.ArmorMagieResist = 3;
            volcaniqueCuir.RunicMinAttributes = 3;
            volcaniqueCuir.RunicMaxAttributes = 3;
            volcaniqueCuir.RunicMinIntensity = 20;
            volcaniqueCuir.RunicMaxIntensity = 70;

            CraftAttributeInfo geantCuir = GeantCuir = new CraftAttributeInfo();
            geantCuir.ArmorPhysicalResist = 3;
            geantCuir.ArmorContondantResist = 3;
            geantCuir.ArmorTranchantResist = 3;
            geantCuir.ArmorPerforantResist = 3;
            geantCuir.ArmorMagieResist = 3;
            geantCuir.RunicMinAttributes = 3;
            geantCuir.RunicMaxAttributes = 3;
            geantCuir.RunicMinIntensity = 20;
            geantCuir.RunicMaxIntensity = 70;

            CraftAttributeInfo minotaureCuir = MinotaureCuir = new CraftAttributeInfo();
            minotaureCuir.ArmorPhysicalResist = 6;
            minotaureCuir.ArmorContondantResist = 6;
            minotaureCuir.ArmorTranchantResist = 6;
            minotaureCuir.ArmorPerforantResist = 6;
            minotaureCuir.ArmorMagieResist = 6;
            minotaureCuir.RunicMinAttributes = 4;
            minotaureCuir.RunicMaxAttributes = 4;
            minotaureCuir.RunicMinIntensity = 30;
            minotaureCuir.RunicMaxIntensity = 80;

            CraftAttributeInfo ophidienCuir = OphidienCuir = new CraftAttributeInfo();
            ophidienCuir.ArmorPhysicalResist = 6;
            ophidienCuir.ArmorContondantResist = 6;
            ophidienCuir.ArmorTranchantResist = 6;
            ophidienCuir.ArmorPerforantResist = 6;
            ophidienCuir.ArmorMagieResist = 6;
            ophidienCuir.RunicMinAttributes = 4;
            ophidienCuir.RunicMaxAttributes = 4;
            ophidienCuir.RunicMinIntensity = 30;
            ophidienCuir.RunicMaxIntensity = 80;

            CraftAttributeInfo arachnideCuir = ArachnideCuir = new CraftAttributeInfo();
            arachnideCuir.ArmorPhysicalResist = 6;
            arachnideCuir.ArmorContondantResist = 6;
            arachnideCuir.ArmorTranchantResist = 6;
            arachnideCuir.ArmorPerforantResist = 6;
            arachnideCuir.ArmorMagieResist = 6;
            arachnideCuir.RunicMinAttributes = 4;
            arachnideCuir.RunicMaxAttributes = 4;
            arachnideCuir.RunicMinIntensity = 30;
            arachnideCuir.RunicMaxIntensity = 80;

            CraftAttributeInfo magiqueCuir = MagiqueCuir = new CraftAttributeInfo();
            magiqueCuir.ArmorPhysicalResist = 9;
            magiqueCuir.ArmorContondantResist = 9;
            magiqueCuir.ArmorTranchantResist = 9;
            magiqueCuir.ArmorPerforantResist = 9;
            magiqueCuir.ArmorMagieResist = 9;
            magiqueCuir.RunicMinAttributes = 5;
            magiqueCuir.RunicMaxAttributes = 5;
            magiqueCuir.RunicMinIntensity = 40;
            magiqueCuir.RunicMaxIntensity = 90;

            CraftAttributeInfo ancienCuir = AncienCuir = new CraftAttributeInfo();
            ancienCuir.ArmorPhysicalResist = 9;
            ancienCuir.ArmorContondantResist = 9;
            ancienCuir.ArmorTranchantResist = 9;
            ancienCuir.ArmorPerforantResist = 9;
            ancienCuir.ArmorMagieResist = 9;
            ancienCuir.RunicMinAttributes = 5;
            ancienCuir.RunicMaxAttributes = 5;
            ancienCuir.RunicMinIntensity = 40;
            ancienCuir.RunicMaxIntensity = 90;

            CraftAttributeInfo demoniaqueCuir = DemoniaqueCuir = new CraftAttributeInfo();
            demoniaqueCuir.ArmorPhysicalResist = 9;
            demoniaqueCuir.ArmorContondantResist = 9;
            demoniaqueCuir.ArmorTranchantResist = 9;
            demoniaqueCuir.ArmorPerforantResist = 9;
            demoniaqueCuir.ArmorMagieResist = 9;
            demoniaqueCuir.RunicMinAttributes = 5;
            demoniaqueCuir.RunicMaxAttributes = 5;
            demoniaqueCuir.RunicMinIntensity = 40;
            demoniaqueCuir.RunicMaxIntensity = 90;

            CraftAttributeInfo dragoniqueCuir = DragoniqueCuir = new CraftAttributeInfo();
            dragoniqueCuir.ArmorPhysicalResist = 12;
            dragoniqueCuir.ArmorContondantResist = 12;
            dragoniqueCuir.ArmorTranchantResist = 12;
            dragoniqueCuir.ArmorPerforantResist = 12;
            dragoniqueCuir.ArmorMagieResist = 12;
            dragoniqueCuir.RunicMinAttributes = 6;
            dragoniqueCuir.RunicMaxAttributes = 6;
            dragoniqueCuir.RunicMinIntensity = 50;
            dragoniqueCuir.RunicMaxIntensity = 100;

            CraftAttributeInfo lupusCuir = LupusCuir = new CraftAttributeInfo();
            lupusCuir.ArmorPhysicalResist = 12;
            lupusCuir.ArmorContondantResist = 12;
            lupusCuir.ArmorTranchantResist = 12;
            lupusCuir.ArmorPerforantResist = 12;
            lupusCuir.ArmorMagieResist = 12;
            lupusCuir.RunicMinAttributes = 6;
            lupusCuir.RunicMaxAttributes = 6;
            lupusCuir.RunicMinIntensity = 50;
            lupusCuir.RunicMaxIntensity = 100;

			//public static readonly CraftAttributeInfo OakWood, AshWood, YewWood, Heartwood, Bloodwood, Frostwood;

			CraftAttributeInfo pin = PinWood = new CraftAttributeInfo();
            pin.WeaponDirectDamage = 1;

			CraftAttributeInfo cypres = CypresWood = new CraftAttributeInfo();
            cypres.WeaponDirectDamage = 1;

			CraftAttributeInfo cedre = CedreWood = new CraftAttributeInfo();
            cedre.WeaponDirectDamage = 2;

			CraftAttributeInfo saule = SauleWood = new CraftAttributeInfo();
            saule.WeaponDirectDamage = 2;

			CraftAttributeInfo chene = CheneWood = new CraftAttributeInfo();
            chene.WeaponDirectDamage = 3;

            CraftAttributeInfo ebene = EbeneWood = new CraftAttributeInfo();
            ebene.WeaponDirectDamage = 3;

            CraftAttributeInfo acajou = AcajouWood = new CraftAttributeInfo();
            acajou.WeaponDirectDamage = 4;
		}
	}

	public class CraftResourceInfo
	{
		private int m_Hue;
		private int m_Number;
		private string m_Name;
        private double m_SkillReq;
		private CraftAttributeInfo m_AttributeInfo;
		private CraftResource m_Resource;
		private Type[] m_ResourceTypes;

		public int Hue{ get{ return m_Hue; } }
		public int Number{ get{ return m_Number; } }
		public string Name{ get{ return m_Name; } }
        public double SkillReq { get { return m_SkillReq; } }
		public CraftAttributeInfo AttributeInfo{ get{ return m_AttributeInfo; } }
		public CraftResource Resource{ get{ return m_Resource; } }
		public Type[] ResourceTypes{ get{ return m_ResourceTypes; } }

		public CraftResourceInfo( int hue, int number, string name, double skillReq, CraftAttributeInfo attributeInfo, CraftResource resource, params Type[] resourceTypes )
		{
			m_Hue = hue;
			m_Number = number;
			m_Name = name;
            m_SkillReq = skillReq;
			m_AttributeInfo = attributeInfo;
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
				new CraftResourceInfo( 0x000, 1053109, "Fer", 0,			CraftAttributeInfo.Blank,		CraftResource.Fer,				typeof( FerIngot ), 		typeof( FerOre ),			typeof( Granite ) ),
				new CraftResourceInfo( 1542, 1053108, "Cuivre",	40,    CraftAttributeInfo.Cuivre,	    CraftResource.Cuivre,   		typeof( CuivreIngot ),	    typeof( CuivreOre ),       	typeof( CuivreGranite ) ),
				new CraftResourceInfo( 2469,  1053107, "Bronze", 40,   	CraftAttributeInfo.Bronze,  	CraftResource.Bronze,   		typeof( BronzeIngot ),  	typeof( BronzeOre ),    	typeof( BronzeGranite ) ),
				new CraftResourceInfo( 2065, 1053106, "Acier", 60,		    CraftAttributeInfo.Acier,		CraftResource.Acier,			typeof( AcierIngot ),		typeof( AcierOre ), 		typeof( AcierGranite ) ),
				new CraftResourceInfo( 2357, 1053105, "Argent",	60,	CraftAttributeInfo.Argent,		CraftResource.Argent,			typeof( ArgentIngot ),		typeof( ArgentOre ),		typeof( ArgentGranite ) ),
				new CraftResourceInfo( 2360,  1053104, "Or", 60,			CraftAttributeInfo.Or,		    CraftResource.Or,				typeof( OrIngot ),	    	typeof( OrOre ),			typeof( OrGranite ) ),
				new CraftResourceInfo( 2378,  1053103, "Mytheril", 80,		CraftAttributeInfo.Mytheril,	CraftResource.Mytheril,			typeof( MytherilIngot ),	typeof( MytherilOre ),		typeof( MytherilGranite ) ),
				new CraftResourceInfo( 1953,  1053102, "Luminium", 80,		CraftAttributeInfo.Luminium,	CraftResource.Luminium,			typeof( LuminiumIngot ),	typeof( LuminiumOre ),		typeof( LuminiumGranite ) ),
				new CraftResourceInfo( 2041, 1053101, "Obscurium", 80,		CraftAttributeInfo.Obscurium,	CraftResource.Obscurium,		typeof( ObscuriumIngot ),	typeof( ObscuriumOre ),		typeof( ObscuriumGranite ) ),
                new CraftResourceInfo( 2331,  1053101, "Mystirium", 90,	CraftAttributeInfo.Mystirium,	CraftResource.Mystirium,		typeof( MystiriumIngot ),	typeof( MystiriumOre ),		typeof( MystiriumGranite ) ),
                new CraftResourceInfo( 2358,  1053101, "Dominium", 90,		CraftAttributeInfo.Dominium,	CraftResource.Dominium,		    typeof( DominiumIngot ),	typeof( DominiumOre ),		typeof( DominiumGranite ) ),
                /*TOCHANGE*/new CraftResourceInfo( 2176,  1053101, "Eclarium", 100,	CraftAttributeInfo.Eclarium,	CraftResource.Eclarium,		    typeof( EclariumIngot ),	typeof( EclariumOre ),		typeof( EclariumGranite ) ),
                new CraftResourceInfo( 2389,  1053101, "Venarium", 90,		CraftAttributeInfo.Venarium,	CraftResource.Venarium,		    typeof( VenariumIngot ),	typeof( VenariumOre ),		typeof( VenariumGranite ) ),
                new CraftResourceInfo( 2380,  1053101, "Athenium", 100,		CraftAttributeInfo.Athenium,	CraftResource.Athenium,		    typeof( AtheniumIngot ),	typeof( AtheniumOre ),		typeof( AtheniumGranite ) ),
                new CraftResourceInfo( 2062,  1053101, "Umbrarium", 100,	CraftAttributeInfo.Umbrarium,	CraftResource.Umbrarium,		typeof( UmbrariumIngot ),	typeof( UmbrariumOre ),		typeof( UmbrariumGranite ) ),
			};

		private static CraftResourceInfo[] m_ScaleInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0, 1053129, "Normal", 0,	        CraftAttributeInfo.Blank,		CraftResource.RegularScales,		typeof( RegularScales ) ),
				new CraftResourceInfo( 2059, 1053130, "Nordique", 0,	    CraftAttributeInfo.Nordique,	CraftResource.NordiqueScales,		typeof( NordiqueScales ) ),
				new CraftResourceInfo( 2164, 1053131, "Desertique", 0,	    CraftAttributeInfo.Desertique,	CraftResource.DesertiqueScales,		typeof( DesertiqueScales ) ),
				new CraftResourceInfo( 2123, 1053132, "Maritime", 0,	    CraftAttributeInfo.Maritime,	CraftResource.MaritimeScales,		typeof( MaritimeScales ) ),
				new CraftResourceInfo( 2375, 1053133, "Volcanique", 0,	CraftAttributeInfo.Volcanique,	CraftResource.VolcaniqueScales,		typeof( VolcaniqueScales ) ),
				new CraftResourceInfo( 2174, 1053134, "Ancien", 0,	        CraftAttributeInfo.Ancien,		CraftResource.AncienScales, 		typeof( AncienScales ) ),
                new CraftResourceInfo( 1953, 1053134, "Wyrmique", 0,	    CraftAttributeInfo.Wyrm,		CraftResource.WyrmScales, 		    typeof( WyrmScales ) )
			};

		private static CraftResourceInfo[] m_LeatherInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1049353, "Normal", 0,		CraftAttributeInfo.Blank,		        CraftResource.RegularLeather,	typeof( Leather ),			typeof( Hides ) ),
                new CraftResourceInfo( 2180, 1049354, "Reptilien", 50,		CraftAttributeInfo.ReptilienCuir,	CraftResource.ReptilienLeather,	typeof( ReptilienLeather ),	typeof( ReptilienHides ) ),
				new CraftResourceInfo( 2059, 1049354, "Nordique", 50,		CraftAttributeInfo.NordiqueCuir,	    CraftResource.NordiqueLeather,	typeof( NordiqueLeather ),	typeof( NordiqueHides ) ),
				new CraftResourceInfo( 2164, 1049355, "Desertique", 50, 	CraftAttributeInfo.DesertiqueCuir,	CraftResource.DesertiqueLeather,typeof( DesertiqueLeather ),typeof( DesertiqueHides ) ),
				new CraftResourceInfo( 2464, 1049356, "Maritime", 60,		CraftAttributeInfo.MaritimeCuir,	    CraftResource.MaritimeLeather,	typeof( MaritimeLeather ),	typeof( MaritimeHides ) ),
                new CraftResourceInfo( 2375, 1049356, "Volcanique", 60,	CraftAttributeInfo.VolcaniqueCuir,   CraftResource.VolcaniqueLeather,typeof( VolcaniqueLeather ),typeof( VolcaniqueHides ) ),
				new CraftResourceInfo( 2167, 1049356, "Geant", 60,  		CraftAttributeInfo.GeantCuir,        CraftResource.GeantLeather, 	typeof( GeantLeather ),	    typeof( GeantHides ) ),
                new CraftResourceInfo( 2373, 1049356, "Minotaure", 70,  	CraftAttributeInfo.MinotaureCuir,   	CraftResource.MinotaurLeather, 	typeof( MinotaureLeather ),	typeof( MinotaureHides ) ),
				new CraftResourceInfo( 2441, 1049356, "Ophidien", 70,		CraftAttributeInfo.OphidienCuir, 	CraftResource.OphidienLeather,	typeof( OphidienLeather ),	typeof( OphidienHides ) ),
				new CraftResourceInfo( 2448, 1049356, "Arachnide", 70,		CraftAttributeInfo.ArachnideCuir,	CraftResource.ArachnideLeather,	typeof( ArachnideLeather ),	typeof( ArachnideHides ) ),
                new CraftResourceInfo( 2459, 1049356, "Magique", 80, 		CraftAttributeInfo.MagiqueCuir,  	CraftResource.MagiqueLeather,	typeof( MagiqueLeather ),	typeof( MagiqueHides ) ),
				/*TOCHANGE*/new CraftResourceInfo( 2174, 1049356, "Ancien", 80, 		CraftAttributeInfo.AncienCuir,  	    CraftResource.AncienLeather,	typeof( AncienLeather ),	typeof( AncienHides ) ),
				new CraftResourceInfo( 2076, 1049356, "Demoniaque", 80, 	CraftAttributeInfo.DemoniaqueCuir,	CraftResource.DemoniaqueLeather,typeof( DemoniaqueLeather ),typeof( DemoniaqueHides ) ),
				new CraftResourceInfo( 2037, 1049356, "Dragonique", 90,	CraftAttributeInfo.DragoniqueCuir,	CraftResource.DragoniqueLeather,typeof( DragoniqueLeather ),typeof( DragoniqueHides ) ),
				new CraftResourceInfo( 2065, 1049356, "Lupus", 90,		CraftAttributeInfo.LupusCuir,       	CraftResource.LupusLeather, 	typeof( LupusLeather ),	    typeof( LupusHides ) )
			};

        private static CraftResourceInfo[] m_BonesInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1049353, "Normal", 0,		CraftAttributeInfo.Blank,		CraftResource.RegularBones,	    typeof( Bone ),			typeof( Bone ) ),
                new CraftResourceInfo( 2360, 1049353, "Gobelin", 50,		CraftAttributeInfo.Gobelin,		CraftResource.GobelinBones,	    typeof( GobelinBone ),	typeof( GobelinBone ) ),
                new CraftResourceInfo( 2246, 1049354, "Reptilien", 50,		CraftAttributeInfo.Reptilien,	CraftResource.ReptilienBones,	typeof( ReptilienBone ),	typeof( ReptilienBone ) ),
				new CraftResourceInfo( 2343, 1049354, "Nordique", 50,		CraftAttributeInfo.Nordique,	CraftResource.NordiqueBones,	typeof( NordiqueBone ),	typeof( NordiqueBone ) ),
				new CraftResourceInfo( 2460, 1049355, "Desertique", 50, 	CraftAttributeInfo.Desertique,	CraftResource.DesertiqueBones,	typeof( DesertiqueBone ),typeof( DesertiqueBone ) ),
				new CraftResourceInfo( 2235, 1049356, "Maritime", 60,		CraftAttributeInfo.Maritime,	CraftResource.MaritimeBones,	typeof( MaritimeBone ),	typeof( MaritimeBone ) ),
                new CraftResourceInfo( 2454, 1049356, "Volcanique", 60,	CraftAttributeInfo.Volcanique,	CraftResource.VolcaniqueBones,	typeof( VolcaniqueBone ),typeof( VolcaniqueBone ) ),
                new CraftResourceInfo( 2398, 1049356, "Geant", 60,		    CraftAttributeInfo.Geant,   	CraftResource.GeantBones,   	typeof( GeantBone ),	typeof( GeantBone ) ),
                new CraftResourceInfo( 2168, 1049356, "Minotaure", 70,		CraftAttributeInfo.Minotaure,   CraftResource.MinotaureBones,   typeof( MinotaureBone ),typeof( MinotaureBone ) ),
				new CraftResourceInfo( 2076, 1049356, "Ophidien", 70,		CraftAttributeInfo.Ophidien,	CraftResource.OphidienBones,	typeof( OphidienBone ),	typeof( OphidienBone ) ),
                new CraftResourceInfo( 2246, 1049356, "Arachnide", 70,		CraftAttributeInfo.Arachnide,	CraftResource.ArachnideBones,	typeof( ArachnideBone ),typeof( ArachnideBone ) ),
                new CraftResourceInfo( 2238, 1049356, "Magique", 80,		    CraftAttributeInfo.Magique,  	CraftResource.MagiqueBones,  	typeof( MagiqueBone ),	typeof( MagiqueBone ) ),
                /*TOCHANGE*/new CraftResourceInfo( 2174, 1049356, "Ancien", 80,		CraftAttributeInfo.Ancien,  	CraftResource.AncienBones,  	typeof( AncienBone ),	typeof( AncienBone ) ),
                new CraftResourceInfo( 2234, 1049356, "Demoniaque", 80, 	CraftAttributeInfo.Demoniaque,	CraftResource.DemonBones,   	typeof( DemonBone ),	typeof( DemonBone ) ),
				new CraftResourceInfo( 1940, 1049356, "Dragonique", 90,    CraftAttributeInfo.Dragonique,	CraftResource.DragonBones,  	typeof( DragonBone ),	typeof( DragonBone ) ),
			};

		private static CraftResourceInfo[] m_AOSLeatherInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1049353, "Normal",0,		CraftAttributeInfo.Blank,		CraftResource.RegularLeather,	typeof( Leather ),			typeof( Hides ) )
				//new CraftResourceInfo( 0x8AC, 1049354, "Spined",		CraftAttributeInfo.Spined,		CraftResource.SpinedLeather,	typeof( SpinedLeather ),	typeof( SpinedHides ) ),
				//new CraftResourceInfo( 0x845, 1049355, "Horned",		CraftAttributeInfo.Horned,		CraftResource.HornedLeather,	typeof( HornedLeather ),	typeof( HornedHides ) ),
				//new CraftResourceInfo( 0x851, 1049356, "Barbed",		CraftAttributeInfo.Barbed,		CraftResource.BarbedLeather,	typeof( BarbedLeather ),	typeof( BarbedHides ) ),
			};

		private static CraftResourceInfo[] m_WoodInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1011542, "Erable",0,    CraftAttributeInfo.Blank,		CraftResource.RegularWood,	typeof( Log ),			typeof( Board ) ),
				new CraftResourceInfo( 2263, 1072533, "Pin", 10,		CraftAttributeInfo.PinWood,		CraftResource.PinWood,		typeof( PinLog ),		typeof( PinBoard ) ),
				new CraftResourceInfo( 2390, 1072534, "Cyprès", 20,	    CraftAttributeInfo.CypresWood,  CraftResource.CypresWood,	typeof( CypresLog ),	typeof( CypresBoard ) ),
				new CraftResourceInfo( 2450, 1072535, "Cèdre", 30,	    CraftAttributeInfo.CedreWood,	CraftResource.CedreWood,	typeof( CedreLog ),		typeof( CedreBoard ) ),
				new CraftResourceInfo( 2170, 1072536, "Saule", 40,		CraftAttributeInfo.SauleWood,	CraftResource.SauleWood,	typeof( SauleLog ),	    typeof( SauleBoard ) ),
				new CraftResourceInfo( 2360, 1072538, "Chêne", 50,		CraftAttributeInfo.CheneWood,	CraftResource.CheneWood,	typeof( CheneLog ),	    typeof( CheneBoard ) ),
				new CraftResourceInfo( 2055, 1072539, "Ébène", 60,		CraftAttributeInfo.EbeneWood,	CraftResource.EbeneWood,	typeof( EbeneLog ),	    typeof( EbeneBoard ) ),
                new CraftResourceInfo( 2153, 1072539, "Acajou", 70,		CraftAttributeInfo.AcajouWood,	CraftResource.AcajouWood,	typeof( AcajouLog ),	typeof( AcajouBoard ) )
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