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
        CyprèsWood,
        CèdreWood,
        SauleWood,
        ChêneWood,
        ÉbèneWood,
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
        BalronBones,
        WyrmBones,

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
            cuivre.ArmorDurability = 50;
            cuivre.ArmorLowerRequirements = 20;
            cuivre.WeaponDurability = 100;
            cuivre.WeaponLowerRequirements = 50;
            cuivre.RunicMinAttributes = 1;
            cuivre.RunicMaxAttributes = 2;
			if ( Core.ML )
			{
                cuivre.RunicMinIntensity = 40;
                cuivre.RunicMaxIntensity = 100;
			}
			else
			{
                cuivre.RunicMinIntensity = 10;
                cuivre.RunicMaxIntensity = 35;
			}

			CraftAttributeInfo bronze = Bronze = new CraftAttributeInfo();
             bronze.WeaponDirectDamage = 2;
            bronze.ArmorPhysicalResist = 2;
            bronze.ArmorTranchantResist = 2;
            bronze.ArmorContondantResist = 2;
            bronze.ArmorPerforantResist = 2;
            bronze.ArmorMagieResist = 2;
            bronze.ArmorDurability = 100;
            bronze.WeaponDurability = 50;
            bronze.RunicMinAttributes = 2;
            bronze.RunicMaxAttributes = 2;
			if ( Core.ML )
			{
                bronze.RunicMinIntensity = 45;
                bronze.RunicMaxIntensity = 100;
			}
			else
			{
                bronze.RunicMinIntensity = 20;
                bronze.RunicMaxIntensity = 45;
			}

            CraftAttributeInfo acier = Acier = new CraftAttributeInfo();
            acier.WeaponDirectDamage = 4;
            acier.ArmorPhysicalResist = 4;
            acier.ArmorTranchantResist = 4;
            acier.ArmorContondantResist = 4;
            acier.ArmorPerforantResist = 4;
            acier.ArmorMagieResist = 4;
            acier.RunicMinAttributes = 2;
            acier.RunicMaxAttributes = 3;
			if ( Core.ML )
			{
                acier.RunicMinIntensity = 50;
                acier.RunicMaxIntensity = 100;
			}
			else
			{
                acier.RunicMinIntensity = 25;
                acier.RunicMaxIntensity = 50;
			}

            CraftAttributeInfo argent = Argent = new CraftAttributeInfo();
            argent.WeaponDirectDamage = 4;
            argent.ArmorPhysicalResist = 4;
            argent.ArmorTranchantResist = 4;
            argent.ArmorContondantResist = 4;
            argent.ArmorPerforantResist = 4;
            argent.ArmorMagieResist = 4;
            argent.RunicMinAttributes = 3;
            argent.RunicMaxAttributes = 3;
			if ( Core.ML )
			{
                argent.RunicMinIntensity = 55;
                argent.RunicMaxIntensity = 100;
			}
			else
			{
                argent.RunicMinIntensity = 30;
                argent.RunicMaxIntensity = 65;
			}


			CraftAttributeInfo or = Or = new CraftAttributeInfo();
             or.WeaponDirectDamage = 4;
            or.ArmorPhysicalResist = 4;
            or.ArmorTranchantResist = 4;
            or.ArmorContondantResist = 4;
            or.ArmorPerforantResist = 4;
            or.ArmorMagieResist = 4;
			//golden.ArmorLuck = 40;
            or.ArmorLowerRequirements = 30;
			//golden.WeaponLuck = 40;
            or.WeaponLowerRequirements = 50;
            or.RunicMinAttributes = 3;
            or.RunicMaxAttributes = 4;
			if ( Core.ML )
			{
                or.RunicMinIntensity = 60;
                or.RunicMaxIntensity = 100;
			}
			else
			{
                or.RunicMinIntensity = 35;
                or.RunicMaxIntensity = 75;
			}

            CraftAttributeInfo mytheril = Mytheril = new CraftAttributeInfo();
             mytheril.WeaponDirectDamage = 6;
            mytheril.ArmorPhysicalResist = 6;
            mytheril.ArmorTranchantResist = 6;
            mytheril.ArmorContondantResist = 6;
            mytheril.ArmorPerforantResist = 6;
            mytheril.ArmorMagieResist = 6;
            mytheril.RunicMinAttributes = 4;
            mytheril.RunicMaxAttributes = 4;
			if ( Core.ML )
			{
                mytheril.RunicMinIntensity = 65;
                mytheril.RunicMaxIntensity = 100;
			}
			else
			{
                mytheril.RunicMinIntensity = 40;
                mytheril.RunicMaxIntensity = 80;
			}

            CraftAttributeInfo luminium = Luminium = new CraftAttributeInfo();
             luminium.WeaponDirectDamage = 6;
            luminium.ArmorPhysicalResist = 6;
            luminium.ArmorContondantResist = 6;
            luminium.ArmorTranchantResist = 6;
            luminium.ArmorPerforantResist = 6;
            luminium.ArmorMagieResist = 6;
            luminium.RunicMinAttributes = 4;
            luminium.RunicMaxAttributes = 5;
			if ( Core.ML )
			{
                luminium.RunicMinIntensity = 70;
                luminium.RunicMaxIntensity = 100;
			}
			else
			{
                luminium.RunicMinIntensity = 45;
                luminium.RunicMaxIntensity = 90;
			}

            CraftAttributeInfo obscurium = Obscurium = new CraftAttributeInfo();
             obscurium.WeaponDirectDamage = 8;
            obscurium.ArmorPhysicalResist = 8;
            obscurium.ArmorContondantResist = 8;
            obscurium.ArmorTranchantResist = 8;
            obscurium.ArmorPerforantResist = 8;
            obscurium.ArmorMagieResist = 8;
            obscurium.ArmorDurability = 50;
            obscurium.RunicMinAttributes = 5;
            obscurium.RunicMaxAttributes = 5;
			if ( Core.ML )
			{
                obscurium.RunicMinIntensity = 85;
                obscurium.RunicMaxIntensity = 100;
			}
			else
			{
                obscurium.RunicMinIntensity = 50;
                obscurium.RunicMaxIntensity = 100;
			}

            CraftAttributeInfo mystirium = Mystirium = new CraftAttributeInfo();
             mystirium.WeaponDirectDamage = 8;
            mystirium.ArmorPhysicalResist = 8;
            mystirium.ArmorContondantResist = 8;
            mystirium.ArmorTranchantResist = 8;
            mystirium.ArmorPerforantResist = 8;
            mystirium.ArmorMagieResist = 8;
            mystirium.ArmorDurability = 50;
            mystirium.RunicMinAttributes = 5;
            mystirium.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                mystirium.RunicMinIntensity = 85;
                mystirium.RunicMaxIntensity = 100;
            }
            else
            {
                mystirium.RunicMinIntensity = 50;
                mystirium.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo dominium = Dominium = new CraftAttributeInfo();
            dominium.WeaponDirectDamage = 8;
            dominium.ArmorPhysicalResist = 8;
            dominium.ArmorContondantResist = 8;
            dominium.ArmorTranchantResist = 8;
            dominium.ArmorPerforantResist = 8;
            dominium.ArmorMagieResist = 8;
            dominium.ArmorDurability = 50;
            dominium.RunicMinAttributes = 5;
            dominium.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                dominium.RunicMinIntensity = 85;
                dominium.RunicMaxIntensity = 100;
            }
            else
            {
                dominium.RunicMinIntensity = 50;
                dominium.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo eclarium = Eclarium = new CraftAttributeInfo();
            eclarium.WeaponDirectDamage = 10;
            eclarium.ArmorPhysicalResist = 10;
            eclarium.ArmorContondantResist = 10;
            eclarium.ArmorTranchantResist = 10;
            eclarium.ArmorPerforantResist = 10;
            eclarium.ArmorMagieResist = 10;
            eclarium.ArmorDurability = 50;
            eclarium.RunicMinAttributes = 5;
            eclarium.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                eclarium.RunicMinIntensity = 85;
                eclarium.RunicMaxIntensity = 100;
            }
            else
            {
                eclarium.RunicMinIntensity = 50;
                eclarium.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo venarium = Venarium = new CraftAttributeInfo();
            venarium.WeaponDirectDamage = 10;
            venarium.ArmorPhysicalResist = 10;
            venarium.ArmorContondantResist = 10;
            venarium.ArmorTranchantResist = 10;
            venarium.ArmorPerforantResist = 10;
            venarium.ArmorMagieResist = 10;
            venarium.ArmorDurability = 50;
            venarium.RunicMinAttributes = 5;
            venarium.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                venarium.RunicMinIntensity = 85;
                venarium.RunicMaxIntensity = 100;
            }
            else
            {
                venarium.RunicMinIntensity = 50;
                venarium.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo athenium = Athenium = new CraftAttributeInfo();
            athenium.WeaponDirectDamage = 12;
            athenium.ArmorPhysicalResist = 12;
            athenium.ArmorContondantResist = 12;
            athenium.ArmorTranchantResist = 12;
            athenium.ArmorPerforantResist = 12;
            athenium.ArmorMagieResist = 12;
            athenium.ArmorDurability = 50;
            athenium.RunicMinAttributes = 5;
            athenium.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                athenium.RunicMinIntensity = 85;
                athenium.RunicMaxIntensity = 100;
            }
            else
            {
                athenium.RunicMinIntensity = 50;
                athenium.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo umbarium = Umbrarium = new CraftAttributeInfo();
            umbarium.WeaponDirectDamage = 12;
            umbarium.ArmorPhysicalResist = 12;
            umbarium.ArmorContondantResist = 12;
            umbarium.ArmorTranchantResist = 12;
            umbarium.ArmorPerforantResist = 12;
            umbarium.ArmorMagieResist = 12;
            umbarium.ArmorDurability = 50;
            /*umbarium.WeaponContondantDamage = 10;
            umbarium.WeaponTranchantDamage = 20;
            umbarium.WeaponPerforantDamage = 20;
            umbarium.WeaponMagieDamage = 10;*/
            umbarium.RunicMinAttributes = 5;
            umbarium.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                umbarium.RunicMinIntensity = 85;
                umbarium.RunicMaxIntensity = 100;
            }
            else
            {
                umbarium.RunicMinIntensity = 50;
                umbarium.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo gobelin = Gobelin = new CraftAttributeInfo();

            gobelin.ArmorPhysicalResist = 2;
            gobelin.ArmorContondantResist = 2;
            gobelin.ArmorTranchantResist = 2;
            gobelin.ArmorPerforantResist = 2;
            gobelin.ArmorMagieResist = 2;
            gobelin.RunicMinAttributes = 3;
            gobelin.RunicMaxAttributes = 4;
            if (Core.ML)
            {
                gobelin.RunicMinIntensity = 40;
                gobelin.RunicMaxIntensity = 100;
            }
            else
            {
                gobelin.RunicMinIntensity = 20;
                gobelin.RunicMaxIntensity = 40;
            }

            CraftAttributeInfo reptilien = Reptilien = new CraftAttributeInfo();

            reptilien.ArmorPhysicalResist = 2;
            reptilien.ArmorContondantResist = 2;
            reptilien.ArmorTranchantResist = 2;
            reptilien.ArmorPerforantResist = 2;
            reptilien.ArmorMagieResist = 2;
            reptilien.RunicMinAttributes = 3;
            reptilien.RunicMaxAttributes = 4;
            if (Core.ML)
            {
                reptilien.RunicMinIntensity = 40;
                reptilien.RunicMaxIntensity = 100;
            }
            else
            {
                reptilien.RunicMinIntensity = 20;
                reptilien.RunicMaxIntensity = 40;
            }

			CraftAttributeInfo nordique = Nordique = new CraftAttributeInfo();

            nordique.ArmorPhysicalResist = 2;
            nordique.ArmorContondantResist = 2;
            nordique.ArmorTranchantResist = 2;
            nordique.ArmorPerforantResist = 2;
            nordique.ArmorMagieResist = 2;
            nordique.RunicMinAttributes = 3;
            nordique.RunicMaxAttributes = 4;
			if ( Core.ML )
			{
				nordique.RunicMinIntensity = 40;
				nordique.RunicMaxIntensity = 100;
			}
			else
			{
				nordique.RunicMinIntensity = 20;
				nordique.RunicMaxIntensity = 40;
			}

			CraftAttributeInfo desertique = Desertique = new CraftAttributeInfo();

            desertique.ArmorPhysicalResist = 2;
            desertique.ArmorContondantResist = 2;
            desertique.ArmorTranchantResist = 2;
            desertique.ArmorPerforantResist = 2;
            desertique.ArmorMagieResist = 2;
            desertique.RunicMinAttributes = 3;
            desertique.RunicMaxAttributes = 4;
			if ( Core.ML )
			{
                desertique.RunicMinIntensity = 45;
                desertique.RunicMaxIntensity = 100;
			}
			else
			{
                desertique.RunicMinIntensity = 30;
                desertique.RunicMaxIntensity = 70;
			}

			CraftAttributeInfo maritime = Maritime = new CraftAttributeInfo();

            maritime.ArmorPhysicalResist = 4;
            maritime.ArmorContondantResist = 4;
            maritime.ArmorTranchantResist = 4;
            maritime.ArmorPerforantResist =4;
            maritime.ArmorMagieResist = 4;
            maritime.RunicMinAttributes = 4;
            maritime.RunicMaxAttributes = 5;
			if ( Core.ML )
			{
                maritime.RunicMinIntensity = 50;
                maritime.RunicMaxIntensity = 100;
			}
			else
			{
                maritime.RunicMinIntensity = 40;
                maritime.RunicMaxIntensity = 100;
			}

            CraftAttributeInfo volcanique = Volcanique = new CraftAttributeInfo();

            volcanique.ArmorPhysicalResist = 4;
            volcanique.ArmorContondantResist = 4;
            volcanique.ArmorTranchantResist = 4;
            volcanique.ArmorPerforantResist = 4;
            volcanique.ArmorMagieResist = 4;
            volcanique.RunicMinAttributes = 4;
            volcanique.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                volcanique.RunicMinIntensity = 50;
                volcanique.RunicMaxIntensity = 100;
            }
            else
            {
                volcanique.RunicMinIntensity = 40;
                volcanique.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo geant = Geant = new CraftAttributeInfo();

            geant.ArmorPhysicalResist = 6;
            geant.ArmorContondantResist = 6;
            geant.ArmorTranchantResist = 6;
            geant.ArmorPerforantResist = 6;
            geant.ArmorMagieResist = 6;
            geant.RunicMinAttributes = 4;
            geant.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                geant.RunicMinIntensity = 50;
                geant.RunicMaxIntensity = 100;
            }
            else
            {
                geant.RunicMinIntensity = 40;
                geant.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo minotaure = Minotaure = new CraftAttributeInfo();

            minotaure.ArmorPhysicalResist = 6;
            minotaure.ArmorContondantResist = 6;
            minotaure.ArmorTranchantResist = 6;
            minotaure.ArmorPerforantResist = 6;
            minotaure.ArmorMagieResist = 6;
            minotaure.RunicMinAttributes = 4;
            minotaure.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                minotaure.RunicMinIntensity = 50;
                minotaure.RunicMaxIntensity = 100;
            }
            else
            {
                minotaure.RunicMinIntensity = 40;
                minotaure.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo ophidien = Ophidien = new CraftAttributeInfo();

            ophidien.ArmorPhysicalResist = 6;
            ophidien.ArmorContondantResist = 6;
            ophidien.ArmorTranchantResist = 6;
            ophidien.ArmorPerforantResist = 6;
            ophidien.ArmorMagieResist = 6;
            ophidien.RunicMinAttributes = 4;
            ophidien.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                ophidien.RunicMinIntensity = 50;
                ophidien.RunicMaxIntensity = 100;
            }
            else
            {
                ophidien.RunicMinIntensity = 40;
                ophidien.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo arachnide = Arachnide = new CraftAttributeInfo();

            arachnide.ArmorPhysicalResist = 6;
            arachnide.ArmorContondantResist = 6;
            arachnide.ArmorTranchantResist = 6;
            arachnide.ArmorPerforantResist = 6;
            arachnide.ArmorMagieResist = 6;
            arachnide.RunicMinAttributes = 4;
            arachnide.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                arachnide.RunicMinIntensity = 50;
                arachnide.RunicMaxIntensity = 100;
            }
            else
            {
                arachnide.RunicMinIntensity = 40;
                arachnide.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo magique = Magique = new CraftAttributeInfo();

            magique.ArmorPhysicalResist = 6;
            magique.ArmorContondantResist = 6;
            magique.ArmorTranchantResist = 6;
            magique.ArmorPerforantResist = 6;
            magique.ArmorMagieResist = 6;
            magique.RunicMinAttributes = 4;
            magique.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                magique.RunicMinIntensity = 50;
                magique.RunicMaxIntensity = 100;
            }
            else
            {
                magique.RunicMinIntensity = 40;
                magique.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo ancien = Ancien = new CraftAttributeInfo();

            ancien.ArmorPhysicalResist = 10;
            ancien.ArmorContondantResist = 10;
            ancien.ArmorTranchantResist = 10;
            ancien.ArmorPerforantResist = 10;
            ancien.ArmorMagieResist = 10;
            ancien.RunicMinAttributes = 4;
            ancien.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                ancien.RunicMinIntensity = 50;
                ancien.RunicMaxIntensity = 100;
            }
            else
            {
                ancien.RunicMinIntensity = 40;
                ancien.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo demoniaque = Demoniaque = new CraftAttributeInfo();

            demoniaque.ArmorPhysicalResist = 10;
            demoniaque.ArmorContondantResist = 10;
            demoniaque.ArmorTranchantResist = 10;
            demoniaque.ArmorPerforantResist = 10;
            demoniaque.ArmorMagieResist = 10;
            demoniaque.RunicMinAttributes = 4;
            demoniaque.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                demoniaque.RunicMinIntensity = 50;
                demoniaque.RunicMaxIntensity = 100;
            }
            else
            {
                demoniaque.RunicMinIntensity = 40;
                demoniaque.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo dragonique = Dragonique = new CraftAttributeInfo();

            dragonique.ArmorPhysicalResist = 10;
            dragonique.ArmorContondantResist = 10;
            dragonique.ArmorTranchantResist = 10;
            dragonique.ArmorPerforantResist = 10;
            dragonique.ArmorMagieResist = 10;
            dragonique.RunicMinAttributes = 4;
            dragonique.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                dragonique.RunicMinIntensity = 50;
                dragonique.RunicMaxIntensity = 100;
            }
            else
            {
                dragonique.RunicMinIntensity = 40;
                dragonique.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo balron = Balron = new CraftAttributeInfo();

            balron.ArmorPhysicalResist = 12;
            balron.ArmorContondantResist = 12;
            balron.ArmorTranchantResist = 12;
            balron.ArmorPerforantResist = 12;
            balron.ArmorMagieResist = 12;
            balron.RunicMinAttributes = 4;
            balron.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                balron.RunicMinIntensity = 50;
                balron.RunicMaxIntensity = 100;
            }
            else
            {
                balron.RunicMinIntensity = 40;
                balron.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo wyrm = Wyrm = new CraftAttributeInfo();

            wyrm.ArmorPhysicalResist = 12;
            wyrm.ArmorContondantResist = 12;
            wyrm.ArmorTranchantResist = 12;
            wyrm.ArmorPerforantResist = 12;
            wyrm.ArmorMagieResist = 12;
            wyrm.RunicMinAttributes = 4;
            wyrm.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                wyrm.RunicMinIntensity = 50;
                wyrm.RunicMaxIntensity = 100;
            }
            else
            {
                wyrm.RunicMinIntensity = 40;
                wyrm.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo reptilienCuir = ReptilienCuir = new CraftAttributeInfo();

            reptilienCuir.ArmorPhysicalResist = 1;
            reptilienCuir.ArmorContondantResist = 1;
            reptilienCuir.ArmorTranchantResist = 1;
            reptilienCuir.ArmorPerforantResist = 1;
            reptilienCuir.ArmorMagieResist = 1;
            reptilienCuir.RunicMinAttributes = 3;
            reptilienCuir.RunicMaxAttributes = 4;
            if (Core.ML)
            {
                reptilienCuir.RunicMinIntensity = 40;
                reptilienCuir.RunicMaxIntensity = 100;
            }
            else
            {
                reptilienCuir.RunicMinIntensity = 20;
                reptilienCuir.RunicMaxIntensity = 40;
            }

            CraftAttributeInfo nordiqueCuir = NordiqueCuir = new CraftAttributeInfo();

            nordiqueCuir.ArmorPhysicalResist = 1;
            nordiqueCuir.ArmorContondantResist = 1;
            nordiqueCuir.ArmorTranchantResist = 1;
            nordiqueCuir.ArmorPerforantResist = 1;
            nordiqueCuir.ArmorMagieResist = 1;
            nordiqueCuir.RunicMinAttributes = 3;
            nordiqueCuir.RunicMaxAttributes = 4;
            if (Core.ML)
            {
                nordiqueCuir.RunicMinIntensity = 40;
                nordiqueCuir.RunicMaxIntensity = 100;
            }
            else
            {
                nordiqueCuir.RunicMinIntensity = 20;
                nordiqueCuir.RunicMaxIntensity = 40;
            }

            CraftAttributeInfo desertiqueCuir = DesertiqueCuir = new CraftAttributeInfo();

            desertiqueCuir.ArmorPhysicalResist = 1;
            desertiqueCuir.ArmorContondantResist = 1;
            desertiqueCuir.ArmorTranchantResist = 1;
            desertiqueCuir.ArmorPerforantResist = 1;
            desertiqueCuir.ArmorMagieResist = 1;
            desertiqueCuir.RunicMinAttributes = 3;
            desertiqueCuir.RunicMaxAttributes = 4;
            if (Core.ML)
            {
                desertiqueCuir.RunicMinIntensity = 45;
                desertiqueCuir.RunicMaxIntensity = 100;
            }
            else
            {
                desertiqueCuir.RunicMinIntensity = 30;
                desertiqueCuir.RunicMaxIntensity = 70;
            }

            CraftAttributeInfo maritimeCuir = MaritimeCuir = new CraftAttributeInfo();

            maritimeCuir.ArmorPhysicalResist = 2;
            maritimeCuir.ArmorContondantResist = 2;
            maritimeCuir.ArmorTranchantResist = 2;
            maritimeCuir.ArmorPerforantResist = 2;
            maritimeCuir.ArmorMagieResist = 2;
            maritimeCuir.RunicMinAttributes = 4;
            maritimeCuir.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                maritimeCuir.RunicMinIntensity = 50;
                maritimeCuir.RunicMaxIntensity = 100;
            }
            else
            {
                maritimeCuir.RunicMinIntensity = 40;
                maritimeCuir.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo volcaniqueCuir = VolcaniqueCuir = new CraftAttributeInfo();

            volcaniqueCuir.ArmorPhysicalResist = 2;
            volcaniqueCuir.ArmorContondantResist = 2;
            volcaniqueCuir.ArmorTranchantResist = 2;
            volcaniqueCuir.ArmorPerforantResist = 2;
            volcaniqueCuir.ArmorMagieResist = 2;
            volcaniqueCuir.RunicMinAttributes = 4;
            volcaniqueCuir.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                volcaniqueCuir.RunicMinIntensity = 50;
                volcaniqueCuir.RunicMaxIntensity = 100;
            }
            else
            {
                volcaniqueCuir.RunicMinIntensity = 40;
                volcaniqueCuir.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo geantCuir = GeantCuir = new CraftAttributeInfo();

            geantCuir.ArmorPhysicalResist = 3;
            geantCuir.ArmorContondantResist = 3;
            geantCuir.ArmorTranchantResist = 3;
            geantCuir.ArmorPerforantResist = 3;
            geantCuir.ArmorMagieResist = 3;
            geantCuir.RunicMinAttributes = 4;
            geantCuir.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                geantCuir.RunicMinIntensity = 50;
                geantCuir.RunicMaxIntensity = 100;
            }
            else
            {
                geantCuir.RunicMinIntensity = 40;
                geantCuir.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo minotaureCuir = MinotaureCuir = new CraftAttributeInfo();

            minotaureCuir.ArmorPhysicalResist = 3;
            minotaureCuir.ArmorContondantResist = 3;
            minotaureCuir.ArmorTranchantResist = 3;
            minotaureCuir.ArmorPerforantResist = 3;
            minotaureCuir.ArmorMagieResist = 3;
            minotaureCuir.RunicMinAttributes = 4;
            minotaureCuir.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                minotaureCuir.RunicMinIntensity = 50;
                minotaureCuir.RunicMaxIntensity = 100;
            }
            else
            {
                minotaureCuir.RunicMinIntensity = 40;
                minotaureCuir.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo ophidienCuir = OphidienCuir = new CraftAttributeInfo();

            ophidienCuir.ArmorPhysicalResist = 3;
            ophidienCuir.ArmorContondantResist = 3;
            ophidienCuir.ArmorTranchantResist = 3;
            ophidienCuir.ArmorPerforantResist = 3;
            ophidienCuir.ArmorMagieResist = 3;
            ophidienCuir.RunicMinAttributes = 4;
            ophidienCuir.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                ophidienCuir.RunicMinIntensity = 50;
                ophidienCuir.RunicMaxIntensity = 100;
            }
            else
            {
                ophidienCuir.RunicMinIntensity = 40;
                ophidienCuir.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo arachnideCuir = ArachnideCuir = new CraftAttributeInfo();

            arachnideCuir.ArmorPhysicalResist = 3;
            arachnideCuir.ArmorContondantResist = 3;
            arachnideCuir.ArmorTranchantResist = 3;
            arachnideCuir.ArmorPerforantResist = 3;
            arachnideCuir.ArmorMagieResist = 3;
            arachnideCuir.RunicMinAttributes = 4;
            arachnideCuir.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                arachnideCuir.RunicMinIntensity = 50;
                arachnideCuir.RunicMaxIntensity = 100;
            }
            else
            {
                arachnideCuir.RunicMinIntensity = 40;
                arachnideCuir.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo magiqueCuir = MagiqueCuir = new CraftAttributeInfo();

            magiqueCuir.ArmorPhysicalResist = 3;
            magiqueCuir.ArmorContondantResist = 3;
            magiqueCuir.ArmorTranchantResist = 3;
            magiqueCuir.ArmorPerforantResist = 3;
            magiqueCuir.ArmorMagieResist = 3;
            magiqueCuir.RunicMinAttributes = 4;
            magiqueCuir.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                magiqueCuir.RunicMinIntensity = 50;
                magiqueCuir.RunicMaxIntensity = 100;
            }
            else
            {
                magiqueCuir.RunicMinIntensity = 40;
                magiqueCuir.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo ancienCuir = AncienCuir = new CraftAttributeInfo();

            ancienCuir.ArmorPhysicalResist = 4;
            ancienCuir.ArmorContondantResist = 4;
            ancienCuir.ArmorTranchantResist = 4;
            ancienCuir.ArmorPerforantResist = 4;
            ancienCuir.ArmorMagieResist = 4;
            ancienCuir.RunicMinAttributes = 4;
            ancienCuir.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                ancienCuir.RunicMinIntensity = 50;
                ancienCuir.RunicMaxIntensity = 100;
            }
            else
            {
                ancienCuir.RunicMinIntensity = 40;
                ancienCuir.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo demoniaqueCuir = DemoniaqueCuir = new CraftAttributeInfo();

            demoniaqueCuir.ArmorPhysicalResist = 4;
            demoniaqueCuir.ArmorContondantResist = 4;
            demoniaqueCuir.ArmorTranchantResist = 4;
            demoniaqueCuir.ArmorPerforantResist = 4;
            demoniaqueCuir.ArmorMagieResist = 4;
            demoniaqueCuir.RunicMinAttributes = 4;
            demoniaqueCuir.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                demoniaqueCuir.RunicMinIntensity = 50;
                demoniaqueCuir.RunicMaxIntensity = 100;
            }
            else
            {
                demoniaqueCuir.RunicMinIntensity = 40;
                demoniaqueCuir.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo dragoniqueCuir = DragoniqueCuir = new CraftAttributeInfo();

            dragoniqueCuir.ArmorPhysicalResist = 4;
            dragoniqueCuir.ArmorContondantResist = 4;
            dragoniqueCuir.ArmorTranchantResist = 4;
            dragoniqueCuir.ArmorPerforantResist = 4;
            dragoniqueCuir.ArmorMagieResist = 4;
            dragoniqueCuir.RunicMinAttributes = 4;
            dragoniqueCuir.RunicMaxAttributes = 5;

            if (Core.ML)
            {
                dragoniqueCuir.RunicMinIntensity = 50;
                dragoniqueCuir.RunicMaxIntensity = 100;
            }
            else
            {
                dragoniqueCuir.RunicMinIntensity = 40;
                dragoniqueCuir.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo lupusCuir = LupusCuir = new CraftAttributeInfo();

            lupusCuir.ArmorPhysicalResist = 5;
            lupusCuir.ArmorContondantResist = 5;
            lupusCuir.ArmorTranchantResist = 5;
            lupusCuir.ArmorPerforantResist = 5;
            lupusCuir.ArmorMagieResist = 5;
            lupusCuir.RunicMinAttributes = 4;
            lupusCuir.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                lupusCuir.RunicMinIntensity = 50;
                lupusCuir.RunicMaxIntensity = 100;
            }
            else
            {
                lupusCuir.RunicMinIntensity = 40;
                lupusCuir.RunicMaxIntensity = 100;
            }

			//public static readonly CraftAttributeInfo OakWood, AshWood, YewWood, Heartwood, Bloodwood, Frostwood;

			CraftAttributeInfo pin = PinWood = new CraftAttributeInfo();
            pin.WeaponDirectDamage = 1;

			CraftAttributeInfo cypres = CypresWood = new CraftAttributeInfo();
            pin.WeaponDirectDamage = 1;

			CraftAttributeInfo cedre = CedreWood = new CraftAttributeInfo();
            pin.WeaponDirectDamage = 2;

			CraftAttributeInfo saule = SauleWood = new CraftAttributeInfo();
            pin.WeaponDirectDamage = 2;

			CraftAttributeInfo chene = CheneWood = new CraftAttributeInfo();
            pin.WeaponDirectDamage = 3;

            CraftAttributeInfo ebene = EbeneWood = new CraftAttributeInfo();
            pin.WeaponDirectDamage = 3;

            CraftAttributeInfo acajou = AcajouWood = new CraftAttributeInfo();
            pin.WeaponDirectDamage = 4;
		}
	}

	public class CraftResourceInfo
	{
		private int m_Hue;
		private int m_Number;
		private string m_Name;
		private CraftAttributeInfo m_AttributeInfo;
		private CraftResource m_Resource;
		private Type[] m_ResourceTypes;

		public int Hue{ get{ return m_Hue; } }
		public int Number{ get{ return m_Number; } }
		public string Name{ get{ return m_Name; } }
		public CraftAttributeInfo AttributeInfo{ get{ return m_AttributeInfo; } }
		public CraftResource Resource{ get{ return m_Resource; } }
		public Type[] ResourceTypes{ get{ return m_ResourceTypes; } }

		public CraftResourceInfo( int hue, int number, string name, CraftAttributeInfo attributeInfo, CraftResource resource, params Type[] resourceTypes )
		{
			m_Hue = hue;
			m_Number = number;
			m_Name = name;
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
				new CraftResourceInfo( 0x000, 1053109, "Fer",			CraftAttributeInfo.Blank,		CraftResource.Fer,				typeof( FerIngot ), 		typeof( FerOre ),			typeof( Granite ) ),
				new CraftResourceInfo( 0x860, 1053108, "Cuivre",	    CraftAttributeInfo.Cuivre,	    CraftResource.Cuivre,   		typeof( CuivreIngot ),	    typeof( CuivreOre ),       	typeof( CuivreGranite ) ),
				new CraftResourceInfo( 2107,  1053107, "Bronze",    	CraftAttributeInfo.Bronze,  	CraftResource.Bronze,   		typeof( BronzeIngot ),  	typeof( BronzeOre ),    	typeof( BronzeGranite ) ),
				new CraftResourceInfo( 0x811, 1053106, "Acier",		    CraftAttributeInfo.Acier,		CraftResource.Acier,			typeof( AcierIngot ),		typeof( AcierOre ), 		typeof( AcierGranite ) ),
				new CraftResourceInfo( 0x7a1, 1053105, "Argent",		CraftAttributeInfo.Argent,		CraftResource.Argent,			typeof( ArgentIngot ),		typeof( ArgentOre ),		typeof( ArgentGranite ) ),
				new CraftResourceInfo( 2360,  1053104, "Or",			CraftAttributeInfo.Or,		    CraftResource.Or,				typeof( OrIngot ),	    	typeof( OrOre ),			typeof( OrGranite ) ),
				new CraftResourceInfo( 2119,  1053103, "Mytheril",		CraftAttributeInfo.Mytheril,	CraftResource.Mytheril,			typeof( MytherilIngot ),	typeof( MytherilOre ),		typeof( MytherilGranite ) ),
				new CraftResourceInfo( 2062,  1053102, "Luminium",		CraftAttributeInfo.Luminium,	CraftResource.Luminium,			typeof( LuminiumIngot ),	typeof( LuminiumOre ),		typeof( LuminiumGranite ) ),
				new CraftResourceInfo( 0x7f9, 1053101, "Obscurium",		CraftAttributeInfo.Obscurium,	CraftResource.Obscurium,		typeof( ObscuriumIngot ),	typeof( ObscuriumOre ),		typeof( ObscuriumGranite ) ),
                new CraftResourceInfo( 2158,  1053101, "Mystirium",		CraftAttributeInfo.Mystirium,	CraftResource.Mystirium,		typeof( MystiriumIngot ),	typeof( MystiriumOre ),		typeof( MystiriumGranite ) ),
                new CraftResourceInfo( 1940,  1053101, "Dominium",		CraftAttributeInfo.Dominium,	CraftResource.Dominium,		    typeof( DominiumIngot ),	typeof( DominiumOre ),		typeof( DominiumGranite ) ),
                new CraftResourceInfo( 2176,  1053101, "Eclarium",		CraftAttributeInfo.Eclarium,	CraftResource.Eclarium,		    typeof( EclariumIngot ),	typeof( EclariumOre ),		typeof( EclariumGranite ) ),
                new CraftResourceInfo( 2180,  1053101, "Venarium",		CraftAttributeInfo.Venarium,	CraftResource.Venarium,		    typeof( VenariumIngot ),	typeof( VenariumOre ),		typeof( VenariumGranite ) ),
                new CraftResourceInfo( 2174,  1053101, "Athenium",		CraftAttributeInfo.Athenium,	CraftResource.Athenium,		    typeof( AtheniumIngot ),	typeof( AtheniumOre ),		typeof( AtheniumGranite ) ),
                new CraftResourceInfo( 2171,  1053101, "Umbrarium",		CraftAttributeInfo.Umbrarium,	CraftResource.Umbrarium,		typeof( UmbrariumIngot ),	typeof( UmbrariumOre ),		typeof( UmbrariumGranite ) ),
			};

		private static CraftResourceInfo[] m_ScaleInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0, 1053129, "Normal",	        CraftAttributeInfo.Blank,		CraftResource.RegularScales,		typeof( RegularScales ) ),
				new CraftResourceInfo( 2059, 1053130, "Nordique",	    CraftAttributeInfo.Nordique,	CraftResource.NordiqueScales,		typeof( NordiqueScales ) ),
				new CraftResourceInfo( 2164, 1053131, "Desertique",	    CraftAttributeInfo.Desertique,	CraftResource.DesertiqueScales,		typeof( DesertiqueScales ) ),
				new CraftResourceInfo( 2123, 1053132, "Maritime",	    CraftAttributeInfo.Maritime,	CraftResource.MaritimeScales,		typeof( MaritimeScales ) ),
				new CraftResourceInfo( 2375, 1053133, "Volcanique",	CraftAttributeInfo.Volcanique,	CraftResource.VolcaniqueScales,		typeof( VolcaniqueScales ) ),
				new CraftResourceInfo( 2174, 1053134, "Ancien",	        CraftAttributeInfo.Ancien,		CraftResource.AncienScales, 		typeof( AncienScales ) ),
                new CraftResourceInfo( 1953, 1053134, "Wyrmique",	    CraftAttributeInfo.Wyrm,		CraftResource.WyrmScales, 		    typeof( WyrmScales ) )
			};

		private static CraftResourceInfo[] m_LeatherInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1049353, "Normal",		CraftAttributeInfo.Blank,		        CraftResource.RegularLeather,	typeof( Leather ),			typeof( Hides ) ),
                new CraftResourceInfo( 2129, 1049354, "Reptilien",		CraftAttributeInfo.ReptilienCuir,	CraftResource.ReptilienLeather,	typeof( ReptilienLeather ),	typeof( ReptilienHides ) ),
				new CraftResourceInfo( 2059, 1049354, "Nordique",		CraftAttributeInfo.NordiqueCuir,	    CraftResource.NordiqueLeather,	typeof( NordiqueLeather ),	typeof( NordiqueHides ) ),
				new CraftResourceInfo( 2164, 1049355, "Desertique", 	CraftAttributeInfo.DesertiqueCuir,	CraftResource.DesertiqueLeather,typeof( DesertiqueLeather ),typeof( DesertiqueHides ) ),
				new CraftResourceInfo( 2123, 1049356, "Maritime",		CraftAttributeInfo.MaritimeCuir,	    CraftResource.MaritimeLeather,	typeof( MaritimeLeather ),	typeof( MaritimeHides ) ),
                new CraftResourceInfo( 2375, 1049356, "Volcanique",	CraftAttributeInfo.VolcaniqueCuir,   CraftResource.VolcaniqueLeather,typeof( VolcaniqueLeather ),typeof( VolcaniqueHides ) ),
				new CraftResourceInfo( 2424, 1049356, "Geant",   		CraftAttributeInfo.GeantCuir,        CraftResource.GeantLeather, 	typeof( GeantLeather ),	    typeof( GeantHides ) ),
                new CraftResourceInfo( 2170, 1049356, "Minotaure",   	CraftAttributeInfo.MinotaureCuir,   	CraftResource.MinotaurLeather, 	typeof( MinotaureLeather ),	typeof( MinotaureHides ) ),
				new CraftResourceInfo( 2373, 1049356, "Ophidien",		CraftAttributeInfo.OphidienCuir, 	CraftResource.OphidienLeather,	typeof( OphidienLeather ),	typeof( OphidienHides ) ),
				new CraftResourceInfo( 2180, 1049356, "Arachnide",		CraftAttributeInfo.ArachnideCuir,	CraftResource.ArachnideLeather,	typeof( ArachnideLeather ),	typeof( ArachnideHides ) ),
                new CraftResourceInfo( 2326, 1049356, "Magique", 		CraftAttributeInfo.MagiqueCuir,  	CraftResource.MagiqueLeather,	typeof( MagiqueLeather ),	typeof( MagiqueHides ) ),
				new CraftResourceInfo( 2174, 1049356, "Ancien", 		CraftAttributeInfo.AncienCuir,  	    CraftResource.AncienLeather,	typeof( AncienLeather ),	typeof( AncienHides ) ),
				new CraftResourceInfo( 1945, 1049356, "Demoniaque", 	CraftAttributeInfo.DemoniaqueCuir,	CraftResource.DemoniaqueLeather,typeof( DemoniaqueLeather ),typeof( DemoniaqueHides ) ),
				new CraftResourceInfo( 0x794, 1049356, "Dragonique",	CraftAttributeInfo.DragoniqueCuir,	CraftResource.DragoniqueLeather,typeof( DragoniqueLeather ),typeof( DragoniqueHides ) ),
				new CraftResourceInfo( 2054, 1049356, "Lupus", 		CraftAttributeInfo.LupusCuir,       	CraftResource.LupusLeather, 	typeof( LupusLeather ),	    typeof( LupusHides ) )
			};

        private static CraftResourceInfo[] m_BonesInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1049353, "Normal",		CraftAttributeInfo.Blank,		CraftResource.RegularBones,	    typeof( Bone ),			typeof( Bone ) ),
                new CraftResourceInfo( 2360, 1049353, "Gobelin",		CraftAttributeInfo.Gobelin,		CraftResource.GobelinBones,	    typeof( GobelinBone ),	typeof( GobelinBone ) ),
                new CraftResourceInfo( 2129, 1049354, "Reptilien",		CraftAttributeInfo.Reptilien,	CraftResource.ReptilienBones,	typeof( ReptilienBone ),	typeof( ReptilienBone ) ),
				new CraftResourceInfo( 2059, 1049354, "Nordique",		CraftAttributeInfo.Nordique,	CraftResource.NordiqueBones,	typeof( NordiqueBone ),	typeof( NordiqueBone ) ),
				new CraftResourceInfo( 2164, 1049355, "Desertique", 	CraftAttributeInfo.Desertique,	CraftResource.DesertiqueBones,	typeof( DesertiqueBone ),typeof( DesertiqueBone ) ),
				new CraftResourceInfo( 2123, 1049356, "Maritime",		CraftAttributeInfo.Maritime,	CraftResource.MaritimeBones,	typeof( MaritimeBone ),	typeof( MaritimeBone ) ),
                new CraftResourceInfo( 2375, 1049356, "Volcanique",	CraftAttributeInfo.Volcanique,	CraftResource.VolcaniqueBones,	typeof( VolcaniqueBone ),typeof( VolcaniqueBone ) ),
                new CraftResourceInfo( 2424, 1049356, "Geant",		    CraftAttributeInfo.Geant,   	CraftResource.GeantBones,   	typeof( GeantBone ),	typeof( GeantBone ) ),
                new CraftResourceInfo( 2170, 1049356, "Minotaure",		CraftAttributeInfo.Minotaure,   CraftResource.MinotaureBones,   typeof( MinotaureBone ),typeof( MinotaureBone ) ),
				new CraftResourceInfo( 2373, 1049356, "Ophidien",		CraftAttributeInfo.Ophidien,	CraftResource.OphidienBones,	typeof( OphidienBone ),	typeof( OphidienBone ) ),
                new CraftResourceInfo( 2180, 1049356, "Arachnide",		CraftAttributeInfo.Arachnide,	CraftResource.ArachnideBones,	typeof( ArachnideBone ),typeof( ArachnideBone ) ),
                new CraftResourceInfo( /*2185*/ 2326, 1049356, "Magique", 		    CraftAttributeInfo.Magique,  	CraftResource.MagiqueBones,  	typeof( MagiqueBone ),	typeof( MagiqueBone ) ),
                new CraftResourceInfo( 2174, 1049356, "Ancien", 		CraftAttributeInfo.Ancien,  	CraftResource.AncienBones,  	typeof( AncienBone ),	typeof( AncienBone ) ),
                new CraftResourceInfo( 1945, 1049356, "Demoniaque", 	CraftAttributeInfo.Demoniaque,	CraftResource.DemonBones,   	typeof( DemonBone ),	typeof( DemonBone ) ),
				new CraftResourceInfo( 0x794, 1049356, "Dragonique",    CraftAttributeInfo.Dragonique,	CraftResource.DragonBones,  	typeof( DragonBone ),	typeof( DragonBone ) ),
				new CraftResourceInfo( 2055, 1049356, "Balron",		CraftAttributeInfo.Balron,  	CraftResource.BalronBones,  	typeof( BalronBone ),	typeof( BalronBone ) ),
				new CraftResourceInfo( 1953, 1049356, "Wyrmique",		CraftAttributeInfo.Wyrm,    	CraftResource.WyrmBones,    	typeof( WyrmBone ),	    typeof( WyrmBone ) )

			};

		private static CraftResourceInfo[] m_AOSLeatherInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1049353, "Normal",		CraftAttributeInfo.Blank,		CraftResource.RegularLeather,	typeof( Leather ),			typeof( Hides ) )
				//new CraftResourceInfo( 0x8AC, 1049354, "Spined",		CraftAttributeInfo.Spined,		CraftResource.SpinedLeather,	typeof( SpinedLeather ),	typeof( SpinedHides ) ),
				//new CraftResourceInfo( 0x845, 1049355, "Horned",		CraftAttributeInfo.Horned,		CraftResource.HornedLeather,	typeof( HornedLeather ),	typeof( HornedHides ) ),
				//new CraftResourceInfo( 0x851, 1049356, "Barbed",		CraftAttributeInfo.Barbed,		CraftResource.BarbedLeather,	typeof( BarbedLeather ),	typeof( BarbedHides ) ),
			};

		private static CraftResourceInfo[] m_WoodInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1011542, "Erable",    CraftAttributeInfo.Blank,		CraftResource.RegularWood,	typeof( Log ),			typeof( Board ) ),
				new CraftResourceInfo( 2059, 1072533, "Pin",		CraftAttributeInfo.PinWood,		CraftResource.PinWood,		typeof( PinLog ),		typeof( PinBoard ) ),
				new CraftResourceInfo( 2129, 1072534, "Cyprès",	    CraftAttributeInfo.CypresWood,  CraftResource.CyprèsWood,	typeof( CypresLog ),	typeof( CypresBoard ) ),
				new CraftResourceInfo( 2164, 1072535, "Cèdre",	    CraftAttributeInfo.CedreWood,	CraftResource.CèdreWood,	typeof( CedreLog ),		typeof( CedreBoard ) ),
				new CraftResourceInfo( 2170, 1072536, "Saule",		CraftAttributeInfo.SauleWood,	CraftResource.SauleWood,	typeof( SauleLog ),	    typeof( SauleBoard ) ),
				new CraftResourceInfo( 2360, 1072538, "Chêne",		CraftAttributeInfo.CheneWood,	CraftResource.ChêneWood,	typeof( CheneLog ),	    typeof( CheneBoard ) ),
				new CraftResourceInfo( 2055, 1072539, "Ébène",		CraftAttributeInfo.EbeneWood,	CraftResource.ÉbèneWood,	typeof( EbeneLog ),	    typeof( EbeneBoard ) ),
                new CraftResourceInfo( 2373, 1072539, "Acajou",		CraftAttributeInfo.AcajouWood,	CraftResource.AcajouWood,	typeof( AcajouLog ),	typeof( AcajouBoard ) )
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

            if (resource >= CraftResource.RegularBones && resource <= CraftResource.WyrmBones)
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
                else if (info.Level == 11)
                    return CraftResource.BalronBones;
                else if (info.Level == 12)
                    return CraftResource.WyrmBones;
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