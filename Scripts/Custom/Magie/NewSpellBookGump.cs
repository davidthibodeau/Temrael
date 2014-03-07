using System; 
using System.Collections; 
using Server; 
using Server.Items; 
using Server.Mobiles; 
using Server.Network; 
using Server.Spells; 
using Server.Prompts;

namespace Server.Gumps
{
    public enum SpellCirconstances
    {
        Tempete,
        Neige,
        Pluie,
        Vent,
        Froid,
        Chaud,
        Nuit,
        Jour,
        Feu,
        Corps,
        Vegetation,
        Sang
    }

    public class SpellBookEntry
    {
        private int m_ConnaissanceLevel;
        private string m_Nom;
        private Type[] m_Reagents;
        private int m_ImageID;
        private int m_Cercle;
        private Aptitude m_Connaissances;
        private int m_SpellID;

        public int ConnaissanceLevel { get { return m_ConnaissanceLevel; } }
        public string Nom { get { return m_Nom; } }
        public Type[] Reagents { get { return m_Reagents; } }
        public int ImageID { get { return m_ImageID; } }
        public int Cercle { get { return m_Cercle; } }
        public Aptitude Connaissance { get { return m_Connaissances; } }
        public int SpellID { get { return m_SpellID; } }

        public SpellBookEntry(int conn, Aptitude connaissance, string nom, Type[] regs, int imageid, int cercle, int spellid)
        {
            m_ConnaissanceLevel = conn;
            m_Nom = nom;
            m_Reagents = regs;
            m_ImageID = imageid;
            m_Cercle = cercle;
            m_Connaissances = connaissance;
            m_SpellID = spellid;
        }
    }

    public class NewSpellbookGump : Gump
    {
        public static SpellBookEntry[] m_SpellBookEntry = new SpellBookEntry[]
        {
            //Adjuration
            new SpellBookEntry( 1, Aptitude.Adjuration, "Fermeture Mag.", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),
            new SpellBookEntry( 1, Aptitude.Adjuration, "Piège Magique", new Type[] { typeof(Nightshade), typeof(SpidersSilk) }, 0x8cC, 2, 13),
            new SpellBookEntry( 2, Aptitude.Adjuration, "Ouverture Mag.", new Type[] { typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D6, 3, 23),
            new SpellBookEntry( 2, Aptitude.Adjuration, "Sup. De Piège", new Type[] { typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8cD, 2, 14),
            new SpellBookEntry( 3, Aptitude.Adjuration, "Nuisance", new Type[] { typeof(Nightshade), typeof(SpidersSilk) }, 0x8cB, 2, 12),
            new SpellBookEntry( 4, Aptitude.Adjuration, "Champ de Dissi.", new Type[] { typeof(BlackPearl), typeof(SpidersSilk), typeof(SulfurousAsh), typeof(Garlic) }, 0x8E1, 5, 34),
            new SpellBookEntry( 5, Aptitude.Adjuration, "Dissipation", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8E8, 6, 41),
            new SpellBookEntry( 6, Aptitude.Adjuration, "Drain de Mana", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8DE, 4, 31),
            new SpellBookEntry( 7, Aptitude.Adjuration, "Poison", new Type[] { typeof(Nightshade) }, 0x8D3, 3, 20),
            new SpellBookEntry( 8, Aptitude.Adjuration, "Dissip. Masse", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(BlackPearl), typeof(SulfurousAsh) }, 0x8F5, 7, 54),
            new SpellBookEntry( 9, Aptitude.Adjuration, "Drain Vamp.", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8F4, 7, 53),
            new SpellBookEntry( 10, Aptitude.Adjuration, "Mur de Poison", new Type[] { typeof(BlackPearl), typeof(Nightshade), typeof(SpidersSilk) }, 0x8E6, 5, 39),

            //Alteration
            new SpellBookEntry( 1, Aptitude.Alteration, "Faiblesse", new Type[] { typeof(Garlic), typeof(Nightshade) }, 0x8c7, 1, 8),
            new SpellBookEntry( 2, Aptitude.Alteration, "Maladroit", new Type[] { typeof(Bloodmoss), typeof(Nightshade) }, 0x8c0, 1, 1),
            new SpellBookEntry( 3, Aptitude.Alteration, "Débilité", new Type[] { typeof(Ginseng), typeof(Nightshade) }, 0x8c2, 1, 3),
            new SpellBookEntry( 4, Aptitude.Alteration, "Telekinesis", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8D4, 3, 21),
            new SpellBookEntry( 5, Aptitude.Alteration, "Reflet", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8E3, 5, 36),
            new SpellBookEntry( 8, Aptitude.Alteration, "Malediction", new Type[] { typeof(Nightshade), typeof(Garlic), typeof(SulfurousAsh) }, 0x8DA, 4, 27),
            new SpellBookEntry( 10, Aptitude.Alteration, "Paralysie", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8E5, 5, 38),
            new SpellBookEntry( 11, Aptitude.Alteration, "Fléau", new Type[] { typeof(Garlic), typeof(Nightshade), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8ED, 6, 46),
            new SpellBookEntry( 12, Aptitude.Alteration, "Pétrification", new Type[] { typeof(BlackPearl), typeof(Ginseng), typeof(SpidersSilk) }, 0x8EE, 6, 47),

            //Evocation
            new SpellBookEntry( 1, Aptitude.Evocation, "Bourrasque", new Type[] { typeof(MandrakeRoot) }, 0x5D7, 1, 201),
            new SpellBookEntry( 1, Aptitude.Evocation, "Flamèche", new Type[] { typeof(BlackPearl) }, 0x5BE, 1, 202),
            new SpellBookEntry( 1, Aptitude.Evocation, "Froid", new Type[] { typeof(Bloodmoss) }, 0x5CA, 1, 203),
            new SpellBookEntry( 1, Aptitude.Evocation, "Tempête", new Type[] { typeof(SulfurousAsh) }, 0x5C3, 1, 204),

            new SpellBookEntry( 2, Aptitude.Evocation, "Boule de Feu", new Type[] { typeof(BlackPearl) }, 0x8D1, 3, 18),
            new SpellBookEntry( 3, Aptitude.Evocation, "Mur de Feu", new Type[] { typeof(BlackPearl), typeof(SpidersSilk), typeof(SulfurousAsh) }, 0x8DB, 4, 28),
            new SpellBookEntry( 4, Aptitude.Evocation, "Énergie", new Type[] { typeof(BlackPearl), typeof(Nightshade) }, 0x8E9, 6, 42),
            new SpellBookEntry( 5, Aptitude.Evocation, "Éclair", new Type[] { typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8DD, 4, 30),
            new SpellBookEntry( 6, Aptitude.Evocation, "Explosion", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8EA, 6, 43),
            new SpellBookEntry( 7, Aptitude.Evocation, "Éner. de Masse", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(SpidersSilk), typeof(SulfurousAsh) }, 0x8F1, 7, 50),
            new SpellBookEntry( 8, Aptitude.Evocation, "Jet de Flamme", new Type[] { typeof(SpidersSilk), typeof(SulfurousAsh) }, 0x8F2, 7, 51),
            new SpellBookEntry( 9, Aptitude.Evocation, "Météores", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SulfurousAsh), typeof(SpidersSilk) }, 0x8F6, 7, 55),
            new SpellBookEntry( 10, Aptitude.Evocation, "Tremblement", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(Ginseng), typeof(SulfurousAsh) }, 0x8F8, 8, 57),
            new SpellBookEntry( 11, Aptitude.Evocation, "Vortex", new Type[] { typeof(Bloodmoss), typeof(BlackPearl), typeof(MandrakeRoot), typeof(Nightshade) }, 0x8F9, 8, 58),
            new SpellBookEntry( 12, Aptitude.Evocation, "Chaine d'Éclair", new Type[] { typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8F0, 7, 49),

            //Illusion
            new SpellBookEntry( 1, Aptitude.Illusion, "Vision Noct.", new Type[] { typeof(SulfurousAsh), typeof(SpidersSilk) }, 0x8c5, 1, 6),
            new SpellBookEntry( 1, Aptitude.Illusion, "Voile", new Type[] { typeof(SulfurousAsh), typeof(SpidersSilk) }, 0x5BA, 1, 200),
            new SpellBookEntry( 3, Aptitude.Illusion, "Teleportation", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8D5, 3, 22),
            new SpellBookEntry( 4, Aptitude.Illusion, "Incognito", new Type[] { typeof(Bloodmoss), typeof(Garlic), typeof(Nightshade) }, 0x8E2, 5, 35),
            new SpellBookEntry( 5, Aptitude.Illusion, "Marque", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8EC, 6, 45),
            new SpellBookEntry( 6, Aptitude.Illusion, "Lobotomie", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(Nightshade), typeof(SulfurousAsh) }, 0x8E4, 5, 37),
            new SpellBookEntry( 7, Aptitude.Illusion, "Rappel", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8DF, 4, 32),
            new SpellBookEntry( 8, Aptitude.Illusion, "Polymorph", new Type[] { typeof(Bloodmoss), typeof(SpidersSilk), typeof(MandrakeRoot) }, 0x8F7, 7, 56),
            new SpellBookEntry( 9, Aptitude.Illusion, "Révélation", new Type[] { typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8EF, 6, 48),
            new SpellBookEntry( 10, Aptitude.Illusion, "Invisibilité", new Type[] { typeof(Bloodmoss), typeof(Nightshade) }, 0x8EB, 6, 44),
            new SpellBookEntry( 12, Aptitude.Illusion, "Voyagement", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8F3, 7, 52),

            //Invocation
            new SpellBookEntry( 1, Aptitude.Invocation, "Nourriture", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8c1, 1, 2),
            new SpellBookEntry( 2, Aptitude.Invocation, "Flèche Mag.", new Type[] { typeof(SulfurousAsh) }, 0x8c4, 1, 5),
            new SpellBookEntry( 3, Aptitude.Invocation, "Mur de Pierre", new Type[] { typeof(Bloodmoss), typeof(Garlic) }, 0x8D7, 3, 24),
            new SpellBookEntry( 4, Aptitude.Invocation, "Convocation", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8E7, 5, 40),
            new SpellBookEntry( 5, Aptitude.Invocation, "Elem. de Terre", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8FD, 8, 62),
            new SpellBookEntry( 6, Aptitude.Invocation, "Esprit de Lame", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(Nightshade) }, 0x8E0, 5, 33),
            new SpellBookEntry( 7, Aptitude.Invocation, "Elem. d'Air", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8FB, 8, 60),
            new SpellBookEntry( 9, Aptitude.Invocation, "Elem. de Feu", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk), typeof(SulfurousAsh) }, 0x8FE, 8, 63),
            new SpellBookEntry( 10, Aptitude.Invocation, "Elem. d'Eau", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8FF, 8, 64),
            new SpellBookEntry( 12, Aptitude.Invocation, "Conjuration", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk), typeof(SulfurousAsh) }, 0x8FC, 8, 61),

            //Necromancy            
              new SpellBookEntry( 1, Aptitude.Necromancie, "Corruption", new Type[] { typeof(GraveDust), typeof(PigIron) }, 0x5008, 9, 108),
              new SpellBookEntry( 1, Aptitude.Necromancie, "Spectre", new Type[] { typeof(NoxCrystal), typeof(PigIron) }, 0x500F, 9, 115),
            new SpellBookEntry( 2, Aptitude.Necromancie, "Présage", new Type[] { typeof(BatWing), typeof(NoxCrystal) }, 0x5004, 9, 104),
            new SpellBookEntry( 2, Aptitude.Necromancie, "Sermant", new Type[] { typeof(DaemonBlood) }, 0x5001, 9, 101),
            new SpellBookEntry( 3, Aptitude.Necromancie, "Corps Mortifié", new Type[] { typeof(BatWing), typeof(GraveDust) }, 0x5002, 9, 102),
             new SpellBookEntry( 3, Aptitude.Necromancie, "Maudire", new Type[] { typeof(PigIron) }, 0x5003, 9, 103),
             new SpellBookEntry( 4, Aptitude.Necromancie, "Minion", new Type[] { typeof(BatWing), typeof(GraveDust), typeof(DaemonBlood) }, 0x500B, 9, 111),
            new SpellBookEntry( 5, Aptitude.Necromancie, "Pourriture", new Type[] { typeof(BatWing), typeof(PigIron), typeof(DaemonBlood) }, 0x5007, 9, 107),
            new SpellBookEntry( 6, Aptitude.Necromancie, "Bête Horrifique", new Type[] { typeof(BatWing), typeof(DaemonBlood) }, 0x5005, 9, 105),
            new SpellBookEntry( 6, Aptitude.Necromancie, "Animation", new Type[] { typeof(GraveDust), typeof(DaemonBlood), typeof(NoxCrystal), typeof(PigIron) }, 0x5000, 9, 100),
            new SpellBookEntry( 7, Aptitude.Necromancie, "Venin", new Type[] { typeof(NoxCrystal) }, 0x5009, 9, 109),
            new SpellBookEntry( 8, Aptitude.Necromancie, "Flétrir", new Type[] { typeof(NoxCrystal), typeof(GraveDust), typeof(PigIron) }, 0x500E, 9, 114),
            new SpellBookEntry( 9, Aptitude.Necromancie, "Étranglement", new Type[] { typeof(DaemonBlood), typeof(NoxCrystal) }, 0x500A, 9, 110),
            new SpellBookEntry( 10, Aptitude.Necromancie, "Liche", new Type[] { typeof(GraveDust), typeof(DaemonBlood), typeof(NoxCrystal) }, 0x5006, 9, 106),
            new SpellBookEntry( 11, Aptitude.Necromancie, "Esprit Vengeur", new Type[] { typeof(BatWing), typeof(GraveDust), typeof(PigIron) }, 0x500D, 9, 113),
            new SpellBookEntry( 12, Aptitude.Necromancie, "Animation", new Type[] { typeof(GraveDust), typeof(DaemonBlood), typeof(NoxCrystal), typeof(PigIron) }, 0x5000, 9, 100),
            new SpellBookEntry( 12, Aptitude.Necromancie, "Vampirisme", new Type[] { typeof(BatWing), typeof(NoxCrystal), typeof(PigIron) }, 0x500C, 9, 112),

            //Thaumaturgie
            new SpellBookEntry( 1, Aptitude.Thaumaturgie, "Force", new Type[] { typeof(MandrakeRoot), typeof(Nightshade) }, 0x8cF, 2, 16),
            new SpellBookEntry( 2, Aptitude.Thaumaturgie, "Agilité", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8c8, 2, 9),
            new SpellBookEntry( 3, Aptitude.Thaumaturgie, "Ruse", new Type[] { typeof(MandrakeRoot), typeof(Nightshade) }, 0x8c9, 2, 10),
            new SpellBookEntry( 4, Aptitude.Thaumaturgie, "Armure Mag.", new Type[] { typeof(Garlic), typeof(SpidersSilk), typeof(SulfurousAsh) }, 0x8c6, 1, 7),
            new SpellBookEntry( 5, Aptitude.Thaumaturgie, "Protection", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(SulfurousAsh) }, 0x8cE, 2, 15),
            new SpellBookEntry( 6, Aptitude.Thaumaturgie, "Antidote", new Type[] { typeof(Garlic), typeof(Ginseng) }, 0x8cA, 2, 11),
            new SpellBookEntry( 7, Aptitude.Thaumaturgie, "Soins", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(SpidersSilk) }, 0x8c3, 1, 4),
            new SpellBookEntry( 8, Aptitude.Thaumaturgie, "Puissance", new Type[] { typeof(Garlic), typeof(MandrakeRoot) }, 0x8D0, 3, 17),
            new SpellBookEntry( 9, Aptitude.Thaumaturgie, "Remède", new Type[] { typeof(Bloodmoss), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8D8, 4, 25),
            new SpellBookEntry( 10, Aptitude.Thaumaturgie, "Protection Mag.", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8D9, 4, 26),
            new SpellBookEntry( 11, Aptitude.Thaumaturgie, "Soins Magiques", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8DC, 4, 29),
            new SpellBookEntry( 12, Aptitude.Thaumaturgie, "Résurrection", new Type[] { typeof(Bloodmoss), typeof(Garlic), typeof(Ginseng) }, 0x8FA, 8, 59),

            /*new SpellBookEntry( 1, NAptitude.Alteration, "Nourriture", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8c1, 1, 600),
            new SpellBookEntry( 2, NAptitude.Alteration, "Vision de nuit", new Type[] { typeof(SulfurousAsh), typeof(SpidersSilk) }, 0x8c5, 1, 601),
            new SpellBookEntry( 3, NAptitude.Alteration, "Flèche magique", new Type[] { typeof(SulfurousAsh) }, 0x8c4, 1, 602),
            new SpellBookEntry( 4, NAptitude.Alteration, "Blessure", new Type[] { typeof(Nightshade), typeof(SpidersSilk) }, 0x5101, 2, 603),
            new SpellBookEntry( 5, NAptitude.Alteration, "Pieux de terre", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(Garlic) }, 0x132, 2, 604),
            new SpellBookEntry( 6, NAptitude.Alteration, "Télékinésie", new Type[] { typeof(MandrakeRoot), typeof(Bloodmoss) }, 0x8d4, 2, 606),

            new SpellBookEntry( 1, NAptitude.Thaumaturgie, "Force", new Type[] { typeof(MandrakeRoot), typeof(Nightshade)  }, 0x8cf, 1, 607),
            new SpellBookEntry( 1, NAptitude.Thaumaturgie, "Agilite", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8c8, 1, 608),
            new SpellBookEntry( 2, NAptitude.Thaumaturgie, "Faiblesse", new Type[] { typeof(Garlic), typeof(Nightshade) }, 0x8c7, 1, 609),
            new SpellBookEntry( 2, NAptitude.Thaumaturgie, "Maladresse", new Type[] { typeof(Bloodmoss), typeof(Nightshade) }, 0x8c0, 1, 610),
            new SpellBookEntry( 3, NAptitude.Thaumaturgie, "Intelligence", new Type[] { typeof(MandrakeRoot), typeof(Nightshade) }, 0x8c9, 2, 611),
            new SpellBookEntry( 3, NAptitude.Thaumaturgie, "Stupidité", new Type[] { typeof(Ginseng), typeof(Nightshade) }, 0x8c2, 2, 612),
            new SpellBookEntry( 4, NAptitude.Thaumaturgie, "Bénédiction", new Type[] { typeof(Garlic), typeof(MandrakeRoot) }, 0x8d0, 4, 613),
            new SpellBookEntry( 5, NAptitude.Thaumaturgie, "Malédiction", new Type[] { typeof(Nightshade), typeof(Garlic), typeof(SulfurousAsh) }, 0x8da, 5, 614),
            new SpellBookEntry( 6, NAptitude.Thaumaturgie, "Revers", new Type[] { typeof(Nightshade), typeof(Garlic), typeof(SulfurousAsh) }, 0x8ed, 7, 615),

            new SpellBookEntry( 1, NAptitude.Adjuration, "Mur de haies", new Type[] { typeof(BlackPearl), typeof(Garlic), typeof(SpidersSilk) }, 0x130, 1, 616),
            new SpellBookEntry( 2, NAptitude.Adjuration, "Mur de pierre", new Type[] { typeof(Bloodmoss), typeof(Garlic) }, 0x8d7, 2, 617),
            new SpellBookEntry( 3, NAptitude.Adjuration, "Geyser", new Type[] { typeof(BlackPearl), typeof(SpidersSilk), typeof(Ginseng) }, 0x5BE, 3, 618),
            new SpellBookEntry( 4, NAptitude.Adjuration, "Mur de feu", new Type[] { typeof(SpidersSilk), typeof(BlackPearl), typeof(SulfurousAsh) }, 0x8db, 5, 619),
            new SpellBookEntry( 5, NAptitude.Adjuration, "Mur d'énergie", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8f1, 6, 620),
            new SpellBookEntry( 6, NAptitude.Adjuration, "Mur de paralysie", new Type[] { typeof(MandrakeRoot), typeof(Ginseng), typeof(SpidersSilk) }, 0x8ee, 7, 621),

            new SpellBookEntry( 1, NAptitude.Thaumaturgie, "Révélation", new Type[] { typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8ef, 1, 622),
            new SpellBookEntry( 2, NAptitude.Thaumaturgie, "Dissipation", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8e8, 3, 623),
            new SpellBookEntry( 3, NAptitude.Thaumaturgie, "Dissipation de mur", new Type[] { typeof(BlackPearl), typeof(SpidersSilk), typeof(Garlic) }, 0x8e1, 4, 625),
            new SpellBookEntry( 4, NAptitude.Thaumaturgie, "Dissipation massive", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(BlackPearl) }, 0x8f5, 6, 626),
            new SpellBookEntry( 5, NAptitude.Thaumaturgie, "Armure magique", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x11a, 7, 624),
            new SpellBookEntry( 6, NAptitude.Thaumaturgie, "Dérobade", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x12b, 8, 627),

            new SpellBookEntry( 1, NAptitude.Thaumaturgie, "Antidote", new Type[] { typeof(Garlic), typeof(Ginseng) }, 0x8ca, 1, 628),
            new SpellBookEntry( 2, NAptitude.Thaumaturgie, "Guérison", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(SpidersSilk) }, 0x8c3, 2, 629),
            new SpellBookEntry( 3, NAptitude.Thaumaturgie, "Antidote massif", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8d8, 4, 630),
            new SpellBookEntry( 4, NAptitude.Thaumaturgie, "Résurrection", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(Bloodmoss) }, 0x8fa, 6, 633),
            new SpellBookEntry( 5, NAptitude.Thaumaturgie, "Guérison majeure", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(SpidersSilk) }, 0x8dc, 7, 631),
            new SpellBookEntry( 6, NAptitude.Thaumaturgie, "Zone de guérison", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x14a, 7, 632),

            new SpellBookEntry( 1, NAptitude.Thaumaturgie, "Protection", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(SulfurousAsh) }, 0x8ce, 2, 636),
            new SpellBookEntry( 2, NAptitude.Thaumaturgie, "Réflection", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8e3, 4, 635),
            new SpellBookEntry( 3, NAptitude.Thaumaturgie, "Secours", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x12f, 5, 637),
            new SpellBookEntry( 4, NAptitude.Thaumaturgie, "Copie", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8d9, 6, 638),
            new SpellBookEntry( 5, NAptitude.Thaumaturgie, "Champ De Stase", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(BlackPearl) }, 0x12e, 7, 639),
            new SpellBookEntry( 6, NAptitude.Thaumaturgie, "Armure", new Type[] { typeof(Garlic), typeof(SpidersSilk), typeof(SulfurousAsh) }, 0x8c6, 8, 634),

            new SpellBookEntry( 1, NAptitude.Necromancie, "Poison mineur", new Type[] { typeof(Nightshade) }, 0x134, 1, 640),
            new SpellBookEntry( 2, NAptitude.Necromancie, "Poison", new Type[] { typeof(NoxCrystal), typeof(Nightshade), typeof(SulfurousAsh) }, 0x8d3, 3, 641),
            new SpellBookEntry( 3, NAptitude.Necromancie, "Jet de poison", new Type[] { typeof(NoxCrystal), typeof(Nightshade), typeof(BlackPearl) }, 0x137, 4, 642),
            new SpellBookEntry( 4, NAptitude.Necromancie, "Mur de poison", new Type[] { typeof(Garlic), typeof(Nightshade), typeof(NoxCrystal) }, 0x8e6, 6, 643),
            new SpellBookEntry( 5, NAptitude.Necromancie, "Pluie acide", new Type[] { typeof(Nightshade), typeof(Bloodmoss), typeof(NoxCrystal) }, 0x59e5, 7, 644),
            new SpellBookEntry( 6, NAptitude.Necromancie, "Pincée acide", new Type[] { typeof(Nightshade), typeof(NoxCrystal), typeof(BlackPearl) }, 0x133, 8, 645),

            new SpellBookEntry( 1, NAptitude.Adjuration, "Cri d'ours", new Type[] { typeof(Bloodmoss), typeof(Ginseng), typeof(Garlic) }, 0x59e4, 1, 649),
            new SpellBookEntry( 2, NAptitude.Adjuration, "Abeilles", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(Garlic) }, 0x135, 2, 647),
            new SpellBookEntry( 3, NAptitude.Adjuration, "Épines", new Type[] { typeof(BlackPearl), typeof(SulfurousAsh), typeof(MandrakeRoot) }, 0x138, 3, 648),
            new SpellBookEntry( 4, NAptitude.Adjuration, "Racines", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x122, 5, 646),
            new SpellBookEntry( 5, NAptitude.Adjuration, "Armure de pierre", new Type[] { typeof(Bloodmoss), typeof(Ginseng), typeof(SpidersSilk) }, 0x59e0, 6, 650),
            new SpellBookEntry( 6, NAptitude.Adjuration, "Jet d'épines", new Type[] { typeof(SulfurousAsh), typeof(MandrakeRoot), typeof(Ginseng) }, 0x129, 7, 651),

            new SpellBookEntry( 1, NAptitude.Evocation, "Boule de feu", new Type[] { typeof(BlackPearl), typeof(Garlic), typeof(SulfurousAsh) }, 0x8d1, 2, 652),
            new SpellBookEntry( 2, NAptitude.Evocation, "Éclair", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8dd, 4, 653),
            new SpellBookEntry( 3, NAptitude.Evocation, "Boule de glace", new Type[] { typeof(BlackPearl), typeof(Ginseng), typeof(Garlic) }, 0x127, 5, 654),
            new SpellBookEntry( 4, NAptitude.Evocation, "Boule d'énergie", new Type[] { typeof(Nightshade), typeof(BlackPearl), typeof(Garlic) }, 0x8e9, 6, 655),
            new SpellBookEntry( 5, NAptitude.Evocation, "Jet de feu", new Type[] { typeof(SpidersSilk), typeof(SulfurousAsh), typeof(BlackPearl) }, 0x8f2, 7, 656),
            new SpellBookEntry( 6, NAptitude.Evocation, "Fulguration", new Type[] { typeof(MandrakeRoot), typeof(SulfurousAsh), typeof(Ginseng) }, 0x126, 8, 657),

            new SpellBookEntry( 1, NAptitude.Evocation, "Tremblements", new Type[] { typeof(Bloodmoss), typeof(Ginseng), typeof(SulfurousAsh) }, 0x8f8, 3, 658),
            new SpellBookEntry( 2, NAptitude.Evocation, "Explosion", new Type[] { typeof(SulfurousAsh), typeof(SulfurousAsh), typeof(Bloodmoss) }, 0x8ea, 4, 659),
            new SpellBookEntry( 3, NAptitude.Evocation, "Séisme", new Type[] { typeof(SulfurousAsh), typeof(Bloodmoss), typeof(Bloodmoss) }, 0x13d, 5, 660),
            new SpellBookEntry( 4, NAptitude.Evocation, "Éclair en chaîne", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8f0, 7, 661),
            new SpellBookEntry( 5, NAptitude.Evocation, "Météores", new Type[] { typeof(SulfurousAsh), typeof(SulfurousAsh), typeof(SulfurousAsh) }, 0x8f6, 8, 662),
            new SpellBookEntry( 6, NAptitude.Evocation, "Vortex", new Type[] { typeof(Nightshade), typeof(Garlic), typeof(Bloodmoss) }, 0x148, 8, 663),

            new SpellBookEntry( 1, NAptitude.Invocation, "Créatures", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8e7, 1, 664),
            new SpellBookEntry( 2, NAptitude.Invocation, "Élém. : Terre", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(BlackPearl) }, 0x8fd, 3, 665),
            new SpellBookEntry( 3, NAptitude.Invocation, "Élém. : Air", new Type[] { typeof(Ginseng), typeof(MandrakeRoot), typeof(Nightshade) }, 0x8fb, 4, 666),
            new SpellBookEntry( 4, NAptitude.Invocation, "Élém. : Feu", new Type[] { typeof(SulfurousAsh), typeof(SulfurousAsh), typeof(SpidersSilk) }, 0x8fe, 6, 667),
            new SpellBookEntry( 5, NAptitude.Invocation, "Élém. : Eau", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8ff, 7, 668),
            new SpellBookEntry( 6, NAptitude.Invocation, "Élém. : Cristal", new Type[] { typeof(BlackPearl), typeof(BlackPearl), typeof(SpidersSilk) }, 0x11f, 8, 669),

            new SpellBookEntry( 1, NAptitude.Invocation, "Esprit animal", new Type[] { typeof(Bloodmoss), typeof(BlackPearl) }, 0x123, 3, 670),
            new SpellBookEntry( 2, NAptitude.Invocation, "Esprit de lames", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(Nightshade) }, 0x8e0, 5, 671),
            new SpellBookEntry( 3, NAptitude.Invocation, "Esprit d'énergie", new Type[] { typeof(BlackPearl), typeof(Nightshade), typeof(Bloodmoss) }, 0x8f9, 6, 672),
            new SpellBookEntry( 4, NAptitude.Invocation, "Esprit du dragon", new Type[] { typeof(Bloodmoss), typeof(Bloodmoss), typeof(Bloodmoss) }, 0x5322, 7, 673),
            new SpellBookEntry( 5, NAptitude.Invocation, "Démon", new Type[] { typeof(Bloodmoss), typeof(Garlic), typeof(SpidersSilk) }, 0x8fc, 8, 674),
            new SpellBookEntry( 6, NAptitude.Invocation, "Esprit vengeur", new Type[] { typeof(BlackPearl), typeof(BlackPearl), typeof(SulfurousAsh) }, 0x13f, 8, 675),

            new SpellBookEntry( 1, NAptitude.Necromancie, "Pourriture d'esprit", new Type[] { typeof(BlackPearl), typeof(SulfurousAsh), typeof(Ginseng) }, 0x156, 1, 676),
            new SpellBookEntry( 2, NAptitude.Necromancie, "Drain de mana", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8de, 2, 677),
            new SpellBookEntry( 3, NAptitude.Necromancie, "Malaise", new Type[] { typeof(Garlic), typeof(SulfurousAsh), typeof(Ginseng) }, 0x08e5, 4, 678),
            new SpellBookEntry( 4, NAptitude.Necromancie, "Souffle d'esprit", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(Garlic) }, 0x8e4, 5, 679),
            new SpellBookEntry( 5, NAptitude.Necromancie, "Drain vampirique", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8f4, 6, 680),
            new SpellBookEntry( 6, NAptitude.Necromancie, "Étouffements", new Type[] { typeof(SulfurousAsh), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8e5, 7, 681),

            new SpellBookEntry( 1, NAptitude.Illusion, "Endurance", new Type[] { typeof(Bloodmoss), typeof(Ginseng), typeof(Garlic) }, 0x5323, 2, 682),
            new SpellBookEntry( 2, NAptitude.Illusion, "Téléportation", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8d5, 3, 683),
            new SpellBookEntry( 3, NAptitude.Illusion, "Rappel", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8df, 5, 684),
            new SpellBookEntry( 4, NAptitude.Illusion, "Évasion", new Type[] { typeof(BlackPearl) }, 0x5326, 1, 685),
            new SpellBookEntry( 5, NAptitude.Illusion, "Trou de ver", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8f3, 7, 686),
            new SpellBookEntry( 6, NAptitude.Illusion, "Marquage", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8ec, 8, 687),

            new SpellBookEntry( 1, NAptitude.Illusion, "Piège", new Type[] { typeof(Garlic), typeof(SpidersSilk), typeof(SulfurousAsh) }, 0x8cc, 2, 688),
            new SpellBookEntry( 1, NAptitude.Illusion, "Désamorçage", new Type[] { typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8cd, 2, 689),
            new SpellBookEntry( 2, NAptitude.Illusion, "Serrure", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(Ginseng) }, 0x8d2, 3, 690),
            new SpellBookEntry( 2, NAptitude.Illusion, "Crochetage", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8d6, 3, 691),
            new SpellBookEntry( 3, NAptitude.Illusion, "Incognito", new Type[] { typeof(Bloodmoss), typeof(Garlic), typeof(Nightshade) }, 0x8e2, 4, 692),
            new SpellBookEntry( 4, NAptitude.Illusion, "Invisibilité", new Type[] { typeof(Nightshade), typeof(Bloodmoss), typeof(BlackPearl) }, 0x8eb, 5, 693),
            new SpellBookEntry( 5, NAptitude.Illusion, "Hallucinations", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(BlackPearl) }, 0x12c, 6, 694),
            new SpellBookEntry( 6, NAptitude.Illusion, "Disparition", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(Nightshade) }, 0x12d, 7, 695),

            new SpellBookEntry( 1, NAptitude.Alteration, "Alteration", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(SulfurousAsh) }, 0x174, 1, 696),
            new SpellBookEntry( 2, NAptitude.Alteration, "Subterfuge", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(Nightshade) }, 0x17a, 2, 697),
            new SpellBookEntry( 3, NAptitude.Alteration, "Chimere", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(BlackPearl) }, 0x177, 4, 698),
            new SpellBookEntry( 4, NAptitude.Alteration, "Transmutation", new Type[] { typeof(BlackPearl), typeof(Ginseng), typeof(SulfurousAsh) }, 0x175, 5, 699),
            new SpellBookEntry( 5, NAptitude.Alteration, "Métamorphose", new Type[] { typeof(Bloodmoss), typeof(SpidersSilk), typeof(MandrakeRoot) }, 0x8f7, 7, 700),
            new SpellBookEntry( 6, NAptitude.Alteration, "Mutation", new Type[] { typeof(SulfurousAsh), typeof(SulfurousAsh), typeof(SulfurousAsh) }, 0x59df, 8, 701),

            new SpellBookEntry( 1, NAptitude.Necromancie, "Calamité", new Type[] { typeof(PigIron) }, 0x5003, 2, 702),
            new SpellBookEntry( 2, NAptitude.Necromancie, "Peau des morts", new Type[] { typeof(BatWing), typeof(GraveDust) }, 0x167, 4, 703),
            new SpellBookEntry( 3, NAptitude.Necromancie, "Mauvais présage", new Type[] { typeof(BatWing), typeof(NoxCrystal) }, 0x161, 5, 704),
            new SpellBookEntry( 4, NAptitude.Necromancie, "Lance d'os", new Type[] { typeof(MandrakeRoot), typeof(Garlic), typeof(PigIron) }, 0x12a, 6, 705),
            new SpellBookEntry( 5, NAptitude.Necromancie, "Serment de sang", new Type[] { typeof(DaemonBlood), typeof(Garlic) }, 0x5001, 7, 706),
            new SpellBookEntry( 6, NAptitude.Necromancie, "Jet de douleur", new Type[] { typeof(GraveDust), typeof(PigIron), typeof(BatWing) }, 0x164, 8, 707),

            new SpellBookEntry( 1, NAptitude.Necromancie, "Familier", new Type[] { typeof(BatWing), typeof(GraveDust), typeof(DaemonBlood) }, 0x151, 2, 708),
            new SpellBookEntry( 2, NAptitude.Necromancie, "Défraîcheur", new Type[] { typeof(NoxCrystal), typeof(GraveDust), typeof(PigIron) }, 0x500E, 3, 709),
            new SpellBookEntry( 3, NAptitude.Necromancie, "Strangulaire", new Type[] { typeof(Bloodmoss), typeof(NoxCrystal), typeof(GraveDust) }, 0x59e3, 5, 710),
            new SpellBookEntry( 4, NAptitude.Necromancie, "Réanimation", new Type[] { typeof(GraveDust), typeof(DaemonBlood), typeof(DaemonBlood) }, 0x147, 6, 711),
            new SpellBookEntry( 5, NAptitude.Necromancie, "Appel de la liche", new Type[] { typeof(GraveDust), typeof(DaemonBlood), typeof(PigIron) }, 0x168, 8, 712),
            new SpellBookEntry( 6, NAptitude.Necromancie, "Insurrection", new Type[] { typeof(GraveDust), typeof(GraveDust), typeof(DaemonBlood) }, 0x11c, 8, 713)*/
        };

        public bool HasSpell(Mobile from, int spellID)
        {
            return (m_Book.HasSpell(spellID));
        }
        
        #region tableaux
        //Liste des magies du spellbook et leur couleur
        public Aptitude[] m_ConnaissanceList = new Aptitude[] {
            Aptitude.Adjuration,
            Aptitude.Alteration,
            Aptitude.Evocation,
            Aptitude.Illusion,
            Aptitude.Invocation,
            Aptitude.Necromancie,
            Aptitude.Thaumaturgie,
        };

        //public Hashtable m_NameColors = new Hashtable();
        public Hashtable m_Names = new Hashtable();

        public void InitializeHashtable()
        {
            /*m_NameColors[NAptitude.Adjuration] = 498;
            m_NameColors[NAptitude.Alteration] = 260;
            m_NameColors[NAptitude.Evocation] = 140;
            m_NameColors[NAptitude.Illusion] = 2052;
            m_NameColors[NAptitude.Invocation] = 1249;
            m_NameColors[NAptitude.Thaumaturgie] = 554;
            m_NameColors[NAptitude.Necromancie] = 12;*/

            m_Names[Aptitude.Adjuration] = "Adjuration";
            m_Names[Aptitude.Alteration] = "Alteration";
            m_Names[Aptitude.Evocation] = "Evocation";
            m_Names[Aptitude.Illusion] = "Illusion";
            m_Names[Aptitude.Invocation] = "Invocation";
            m_Names[Aptitude.Necromancie] = "Necromancie";
            m_Names[Aptitude.Thaumaturgie] = "Thaumaturgie";
        }
        #endregion

        private NewSpellbook m_Book;

        public NewSpellbookGump(Mobile from, NewSpellbook book)
            : base(150, 200)
        {
            InitializeHashtable();

            m_Book = book;
            int vindex = 0;
            int totpage = 0;
            int hindex = 0;

            if (!(from is TMobile))
                return;

            TMobile m = (TMobile)from;

            AddPage(0);
            AddImage(100, 10, 2201);

            int oldconnaissance = -1;
            int newconnaissance = -1;

            int value = 0;
            int addition = 0;

            //Pour tous les sorts
            for (int i = 0; i < m_SpellBookEntry.Length; i++)
            {
                SpellBookEntry info = (SpellBookEntry)m_SpellBookEntry[i];

                //on assigne la nouvelle connaissance
                newconnaissance = (int)info.Connaissance;

                if (newconnaissance == oldconnaissance)
                    addition += 1;
                else
                    addition = 0;

                //on fait la comparaison des connaissances pour savoir si on a changé de connaissance
                if ((newconnaissance != -1 && newconnaissance != oldconnaissance) || (addition == 9) || (addition == 18))
                {
                    value++;

                    if (value % 2 == 1)
                    {
                        totpage++;
                        AddPage(totpage);
                        hindex = 0;
                    }
                    else
                        hindex = 1;

                    //On ajoute le nom de la connaissance
                    //AddLabel(160 + hindex * 145, 25, (int)m_NameColors[info.Connaissance], (string)m_Names[info.Connaissance]);
                    AddHtml(160 + hindex * 145, 32, 200, 20, "<h3><basefont color=#025a>" + (string)m_Names[info.Connaissance] + "<basefont></h3>", false, false);

                    // Séparateurs
                    AddImageTiled(130 + hindex * 165, 40, 130, 10, 0x3A);

                    //On remet à 0 pour la nouvelle page
                    vindex = 0;

                    //On ajoute les boutons de changement de page
                    AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, totpage + 1);
                    AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, totpage - 1);
                }

                //Si le livre possède le sort
                if (this.HasSpell(from, info.SpellID) && ArrayContains(m_ConnaissanceList, info.Connaissance))
                {
                    int buttonID = 2224;

                    if (m.QuickSpells.Contains(info.SpellID))
                        buttonID = 2223;

                    //On ajoute l'information et les boutons
                    //AddLabel(162 + hindex * 160, 54 + (vindex * 17), 0, info.Nom);
                    AddHtml(162 + hindex * 160, 54 + (vindex * 17), 200, 20, "<h3><basefont color=#5A4A31>" + info.Nom + "<basefont></h3>", false, false);

                    AddButton(127 + hindex * 160, 59 + (vindex * 17), 2103, 2104, info.SpellID, GumpButtonType.Reply, 0);
                    AddButton(140 + hindex * 160, 58 + (vindex * 17), buttonID, buttonID, info.SpellID + 1000, GumpButtonType.Reply, 0);
                    vindex++;
                }

                oldconnaissance = (int)info.Connaissance;
             }

            value = 0;

            //Pour tous les sorts
            for (int i = 0; i < m_SpellBookEntry.Length; i++)
            {
                SpellBookEntry info = (SpellBookEntry)m_SpellBookEntry[i];

                //Si le livre possède le sort
                if (this.HasSpell(from, info.SpellID) && ArrayContains(m_ConnaissanceList, info.Connaissance))
                {
                    //Si le # du sort est pair...
                    if (value % 2 == 0)
                    {
                        //On fait une page
                        totpage++;
                        AddPage(totpage);
                        hindex = 0;

                        //On ajoute les boutons de pages
                        AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, totpage - 1);
                        AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, totpage + 1);
                    }
                    else
                        hindex = 1;

                    //int namecolor = 0;
                    string name = "...";

                    /*if (m_NameColors.Contains(info.Connaissance))
                        namecolor = (int)m_NameColors[info.Connaissance];*/

                    if (m_Names.Contains(info.Connaissance))
                        name = (string)m_Names[info.Connaissance];

                    //On ajoute le nom
                    //AddLabel(130 + hindex * 165, 45, namecolor, info.Nom);
                    AddHtml(158 + hindex * 145, 32, 200, 20, "<h3><basefont color=#025a>" + info.Nom + "<basefont></h3>", false, false);

                    //On ajoute les séparateurs
                    //AddImageTiled(130 + hindex * 165, 60, 130, 10, 0x3A);
                    AddImageTiled(130 + hindex * 165, 40, 130, 10, 0x3A);

                    //On ajoute l'icone en tant que bouton pour lancer le sort
                    AddButton(140 + hindex * 165, 60, info.ImageID, info.ImageID, info.SpellID, GumpButtonType.Reply, 0);
                    //AddLabel(190 + hindex * 165, 63, namecolor, "Cercle : " + info.Cercle.ToString());
                    AddHtml(190 + hindex * 165, 63, 200, 20, "<h3><basefont color=#5A4A31>Cercle:" + info.Cercle.ToString() + "<basefont></h3>", false, false);

                    int buttonID = 2224;

                    if (m.QuickSpells.Contains(info.SpellID))
                        buttonID = 2223;

                    //On ajoute les boutons pour le lancement rapide
                    //AddLabel(210 + hindex * 165, 83, 0, "Rapide");
                    AddHtml(210 + hindex * 165, 83, 200, 20, "<h3><basefont color=#5A4A31>Rapide<basefont></h3>", false, false);
                    AddButton(190 + hindex * 165, 84, buttonID, buttonID, info.SpellID + 1000, GumpButtonType.Reply, 0);

                    //On ajoute les infos diverses
                    //AddLabel(130 + hindex * 165, 105, 567, "Ingrédiants:");
                    AddHtml(130 + hindex * 165, 105, 200, 20, "<h3><basefont color=#025a>Ingrédiants<basefont></h3>", false, false);
                    for (int j = 0; j < info.Reagents.Length; j++)
                    {
                        Type type = (Type)info.Reagents[j];
                        //AddLabel(130 + hindex * 165, 123 + j * 18, 0, type.Name);
                        AddHtml(130 + hindex * 165, 123 + j * 18, 200, 20, "<h3><basefont color=#5A4A31>" + type.Name + "<basefont></h3>", false, false);

                    }

                    //AddLabel(130 + hindex * 165, 172, 567, "Aptitude:");
                    //AddLabel(130 + hindex * 165, 192, namecolor, name + " " + info.ConnaissanceLevel);

                    AddHtml(130 + hindex * 165, 175, 200, 20, "<h3><basefont color=#025a>Aptitude<basefont></h3>", false, false);
                    AddHtml(130 + hindex * 165, 192, 200, 20, "<h3><basefont color=#5A4A31>" + name + " " + info.ConnaissanceLevel + "<basefont></h3>", false, false);


                    //On augmente le nombre de sort de 1 pour le prochain sort.
                    value++;
                }
            }

            totpage++;
            AddPage(totpage);
            AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, totpage - 1);
        }

        public bool ArrayContains(Aptitude[] conn, Aptitude wanted)
        {
            for (int i = 0; i < conn.Length; i++)
            {
                if (wanted == (Aptitude)conn[i])
                    return true;
            }

            return false;
        }

        public static SpellBookEntry FindEntryBySpellID(int spellID)
        {
            for (int i = 0; i < m_SpellBookEntry.Length; i++)
            {
                SpellBookEntry info = (SpellBookEntry)m_SpellBookEntry[i];

                if (info.SpellID == spellID)
                    return info;
            }

            return null;
        }

        public class CompareSpellID : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                SpellBookEntry a = (SpellBookEntry)obj1;
                SpellBookEntry b = (SpellBookEntry)obj2;

                return ((int)a.SpellID).CompareTo(((int)b.SpellID));
            }
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            if (from is TMobile)
            {
                TMobile m = (TMobile)from;

                if (info.ButtonID >= 1 && info.ButtonID < 300)
                {
                    Spell spell = SpellRegistry.NewSpell(info.ButtonID, m, null);

                    if (spell != null)
                        spell.Cast();

                    m.SendGump(new NewSpellbookGump(m, m_Book));
                }
                else if (info.ButtonID >= 1000 && info.ButtonID < 1300)
                {
                    if (m.QuickSpells == null)
                        return;

                    if (m.QuickSpells.Contains((int)(info.ButtonID - 1000)))
                    {
                        m.SendMessage("Le sort a été retiré de votre liste de lancement rapide.");
                        m.QuickSpells.Remove((int)(info.ButtonID - 1000));
                    }
                    else
                    {
                        m.SendMessage("Le sort a été ajouté à votre liste de lancement rapide.");
                        m.QuickSpells.Add((int)(info.ButtonID - 1000));
                    }

                    m.SendGump(new NewSpellbookGump(m, m_Book));
                }
            }
        }
    }
}