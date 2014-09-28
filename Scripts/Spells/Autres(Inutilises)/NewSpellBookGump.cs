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
        private int m_SkillLevel;
        private SkillName m_Skill;
        private string m_Nom;
        private Type[] m_Reagents;
        private int m_ImageID;
        private int m_Cercle;
        private int m_SpellID;

        public int SkillLevel { get { return m_SkillLevel; } }
        public SkillName Skill { get { return m_Skill; } }
        public string Nom { get { return m_Nom; } }
        public Type[] Reagents { get { return m_Reagents; } }
        public int ImageID { get { return m_ImageID; } }
        public int Cercle { get { return m_Cercle; } }
        public int SpellID { get { return m_SpellID; } }

        public SpellBookEntry(int skillLevel, SkillName skill, string nom, Type[] regs, int imageid, int cercle, int spellid)
        {
            m_SkillLevel = skillLevel;
            m_Skill = skill;
            m_Nom = nom;
            m_Reagents = regs;
            m_ImageID = imageid;
            m_Cercle = cercle;
            m_SpellID = spellid;
        }
    }

    public class NewSpellbookGump : Gump
    {
        public static SpellBookEntry[] m_SpellBookEntry = new SpellBookEntry[]
        {

            //TOCHECK SPELLLIST

            //Evocation
            new SpellBookEntry( 1, SkillName.Evocation, "Fleche Mag.", MagicArrowSpell.m_Info.Reagents, 0x8D2, 3, MagicArrowSpell.m_SpellID),
            new SpellBookEntry( 2, SkillName.Evocation, "Boule de Feu", FireballSpell.m_Info.Reagents, 0x8D1, 3, FireballSpell.m_SpellID),
            new SpellBookEntry( 3, SkillName.Evocation, "Explosion", ExplosionSpell.m_Info.Reagents, 0x8EA, 6, ExplosionSpell.m_SpellID),
            new SpellBookEntry( 4, SkillName.Evocation, "Énergie", EnergyBoltSpell.m_Info.Reagents, 0x8E9, 6, EnergyBoltSpell.m_SpellID),
            new SpellBookEntry( 5, SkillName.Evocation,"Éclair", LightningSpell.m_Info.Reagents, 0x8DD, 4, LightningSpell.m_SpellID),
            //new SpellBookEntry( 6, SkillName.Evocation, "Vortex", new Type[] { typeof(Bloodmoss), typeof(BlackPearl), typeof(MandrakeRoot), typeof(Nightshade) }, 0x8F9, 8, 58),
            new SpellBookEntry( 7, SkillName.Evocation, "Tremblement", EarthquakeSpell.m_Info.Reagents, 0x8F8, 8, EarthquakeSpell.m_SpellID),
            new SpellBookEntry( 8, SkillName.Evocation, "Chaine d'Éclair", ChainLightningSpell.m_Info.Reagents, 0x8F0, 7, ChainLightningSpell.m_SpellID),
            new SpellBookEntry( 9, SkillName.Evocation, "Mur de Feu", FireFieldSpell.m_Info.Reagents, 0x8DB, 4, FireFieldSpell.m_SpellID),
            new SpellBookEntry( 10, SkillName.Evocation, "Jet de Flamme", FlameStrikeSpell.m_Info.Reagents, 0x8F2, 7, FlameStrikeSpell.m_SpellID),


            // Immuabilite
            new SpellBookEntry( 1, SkillName.Immuabilite, "Mur de Pierre", WallOfStoneSpell.m_Info.Reagents, 0x8D7, 3, WallOfStoneSpell.m_SpellID),
            new SpellBookEntry( 2, SkillName.Immuabilite, "Mur d'Energie", EnergyFieldSpell.m_Info.Reagents, 0x8D7, 3, EnergyFieldSpell.m_SpellID),
            new SpellBookEntry( 3, SkillName.Immuabilite, "Mur de Paralysie", ParalyzeFieldSpell.m_Info.Reagents, 0x8D7, 3, ParalyzeFieldSpell.m_SpellID),
            new SpellBookEntry( 4, SkillName.Immuabilite, "Paralysie", ParalyzeSpell.m_Info.Reagents, 0x8E5, 5, ParalyzeSpell.m_SpellID),
            //new SpellBookEntry( 5, SkillName.Immuabilite, "Etouffement", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8E5, 5, 38),
            //new SpellBookEntry( 6, SkillName.Immuabilite, "Lenteur", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8E5, 5, 38),
            //new SpellBookEntry( 7, SkillName.Immuabilite, "Champs de stase", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8E5, 5, 38),
            //new SpellBookEntry( 8, SkillName.Immuabilite, "Golem", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8E5, 5, 38),
            //new SpellBookEntry( 9, SkillName.Immuabilite, "Pétrification", new Type[] { typeof(BlackPearl), typeof(Ginseng), typeof(SpidersSilk) }, 0x8EE, 6, 47),

            // Alteration
            new SpellBookEntry( 1, SkillName.Alteration, "Pourriture d'esprit", MindRotSpell.m_Info.Reagents, 0x8D2, 3, MindRotSpell.m_SpellID),
            new SpellBookEntry( 2, SkillName.Alteration, "Arme maudite", CurseWeaponSpell.m_Info.Reagents, 0x8D2, 3, CurseWeaponSpell.m_SpellID),
            new SpellBookEntry( 3, SkillName.Alteration, "Pacte de sang", BloodOathSpell.m_Info.Reagents, 0x8D2, 3, BloodOathSpell.m_SpellID),
            new SpellBookEntry( 4, SkillName.Alteration, "Présage maléfique", EvilOmenSpell.m_Info.Reagents, 0x8D2, 3, EvilOmenSpell.m_SpellID),
            new SpellBookEntry( 5, SkillName.Alteration, "Douleur", PainSpikeSpell.m_Info.Reagents, 0x8D2, 3, PainSpikeSpell.m_SpellID),
            new SpellBookEntry( 6, SkillName.Alteration, "Étranglement", StrangleSpell.m_Info.Reagents, 0x8D2, 3, StrangleSpell.m_SpellID),
            new SpellBookEntry( 7, SkillName.Alteration, "Peau de cadavre", CorpseSkinSpell.m_Info.Reagents, 0x8D2, 3, CorpseSkinSpell.m_SpellID),
            new SpellBookEntry( 8, SkillName.Alteration, "Monstre", HorrificBeastSpell.m_Info.Reagents, 0x8D2, 3, HorrificBeastSpell.m_SpellID),




            //Providence
            new SpellBookEntry( 1, SkillName.Providence, "Armure du mage", ReactiveArmorSpell.m_Info.Reagents, 0x8D2, 3, ReactiveArmorSpell.m_SpellID),
            new SpellBookEntry( 2, SkillName.Providence, "Protection", ProtectionSpell.m_Info.Reagents, 0x8D2, 3, ProtectionSpell.m_SpellID),
            new SpellBookEntry( 3, SkillName.Providence, "Bénédiction", BlessSpell.m_Info.Reagents, 0x8D2, 3, BlessSpell.m_SpellID),
            new SpellBookEntry( 4, SkillName.Providence, "Force", StrengthSpell.m_Info.Reagents, 0x8D2, 3, StrengthSpell.m_SpellID),
            new SpellBookEntry( 5, SkillName.Providence, "Agilité", AgilitySpell.m_Info.Reagents, 0x8D2, 3, AgilitySpell.m_SpellID),
            new SpellBookEntry( 6, SkillName.Providence, "Astuce", CunningSpell.m_Info.Reagents, 0x8D2, 3, CunningSpell.m_SpellID),
            new SpellBookEntry( 7, SkillName.Providence, "Reflection magique", MagicReflectSpell.m_Info.Reagents, 0x8D2, 3, MagicReflectSpell.m_SpellID),
            //new SpellBookEntry( 1, SkillName.Providence, "Sacrifice", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),
            //new SpellBookEntry( 1, SkillName.Providence, "Peau de pierre", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),
            //new SpellBookEntry( 1, SkillName.Providence, "Champ entropique", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),
            //new SpellBookEntry( 1, SkillName.Providence, "Bénédiction de masse", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),

            //Transmutation
            //new SpellBookEntry( 1, SkillName.Transmutation, "Évasion", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),
            new SpellBookEntry( 2, SkillName.Transmutation, "Téléportation", TeleportSpell.m_Info.Reagents, 0x8D2, 3, TeleportSpell.m_SpellID),
            new SpellBookEntry( 3, SkillName.Transmutation, "Convocation", SummonCreatureSpell.m_Info.Reagents, 0x8D2, 3, SummonCreatureSpell.m_SpellID),
            //new SpellBookEntry( 4, SkillName.Transmutation, "Supression mag.", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),
            new SpellBookEntry( 5, SkillName.Transmutation, "Renvoi", DispelSpell.m_Info.Reagents, 0x8D2, 3, DispelSpell.m_SpellID),
            //new SpellBookEntry( 6, SkillName.Transmutation, "Endurance", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),
            //new SpellBookEntry( 7, SkillName.Transmutation, "Chance", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),
            new SpellBookEntry( 8, SkillName.Transmutation, "Transformation", PolymorphSpell.m_Info.Reagents, 0x8D2, 3, PolymorphSpell.m_SpellID),

            //Thaumaturgie
            new SpellBookEntry( 1, SkillName.Thaumaturgie, "Soins", HealSpell.m_Info.Reagents, 0x8D2, 3, HealSpell.m_SpellID),
            new SpellBookEntry( 1, SkillName.Thaumaturgie, "Antidote", CureSpell.m_Info.Reagents, 0x8D2, 3, CureSpell.m_SpellID),
            new SpellBookEntry( 1, SkillName.Thaumaturgie, "Soins majeurs", GreaterHealSpell.m_Info.Reagents, 0x8D2, 3, GreaterHealSpell.m_SpellID),
            //new SpellBookEntry( 1, SkillName.Thaumaturgie, "Totem de guérison", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),
            //new SpellBookEntry( 1, SkillName.Thaumaturgie, "Pacification", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),
            //new SpellBookEntry( 1, SkillName.Thaumaturgie, "Dernier souffle", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),
            //new SpellBookEntry( 1, SkillName.Thaumaturgie, "Adrénaline", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),

            //Hallucination
            new SpellBookEntry( 1, SkillName.Hallucination, "Invisibilité", InvisibilitySpell.m_Info.Reagents, 0x8D2, 3, InvisibilitySpell.m_SpellID),
            //new SpellBookEntry( 1, SkillName.Hallucination, "Confusion", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),
            //new SpellBookEntry( 1, SkillName.Hallucination, "Ventriloquie", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),
            //new SpellBookEntry( 1, SkillName.Hallucination, "Schizophrénie", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),
            //new SpellBookEntry( 1, SkillName.Hallucination, "Dissimulation", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),
            //new SpellBookEntry( 1, SkillName.Hallucination, "Copie", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),
            //new SpellBookEntry( 1, SkillName.Hallucination, "Clone", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),
            //new SpellBookEntry( 1, SkillName.Hallucination, "Provocation", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),
            //new SpellBookEntry( 1, SkillName.Hallucination, "Simulacre", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),

            //Ensorcellement
            new SpellBookEntry( 1, SkillName.Ensorcellement, "Faiblesse", WeakenSpell.m_Info.Reagents, 0x8D2, 3, WeakenSpell.m_SpellID),
            new SpellBookEntry( 1, SkillName.Ensorcellement, "Maladresse", ClumsySpell.m_Info.Reagents, 0x8D2, 3, ClumsySpell.m_SpellID),
            new SpellBookEntry( 1, SkillName.Ensorcellement, "Abrutissement", FeeblemindSpell.m_Info.Reagents, 0x8D2, 3, FeeblemindSpell.m_SpellID),
            new SpellBookEntry( 1, SkillName.Ensorcellement, "Malédiction", CurseSpell.m_Info.Reagents, 0x8D2, 3, CurseSpell.m_SpellID),
            new SpellBookEntry( 1, SkillName.Ensorcellement, "Douleur", HarmSpell.m_Info.Reagents, 0x8D2, 3, HarmSpell.m_SpellID),
            new SpellBookEntry( 1, SkillName.Ensorcellement, "Drain de mana", ManaDrainSpell.m_Info.Reagents, 0x8D2, 3, ManaDrainSpell.m_SpellID),
            new SpellBookEntry( 1, SkillName.Ensorcellement, "Drain vampirique", ManaVampireSpell.m_Info.Reagents, 0x8D2, 3, ManaVampireSpell.m_SpellID),
            //new SpellBookEntry( 1, SkillName.Ensorcellement, "Affaiblissement", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),
            //new SpellBookEntry( 1, SkillName.Ensorcellement, "Discordance", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),
            new SpellBookEntry( 1, SkillName.Ensorcellement, "Malediction suprême", MassCurseSpell.m_Info.Reagents, 0x8D2, 3, MassCurseSpell.m_SpellID),

            //Necromancie
            new SpellBookEntry( 1, SkillName.Necromancie, "Poison", PoisonSpell.m_Info.Reagents, 0x8D2, 3, PoisonSpell.m_SpellID),
            new SpellBookEntry( 1, SkillName.Necromancie, "Mur de poison", PoisonFieldSpell.m_Info.Reagents, 0x8D2, 3, PoisonFieldSpell.m_SpellID),
            new SpellBookEntry( 1, SkillName.Necromancie, "Wraith form", WraithFormSpell.m_Info.Reagents, 0x8D2, 3, WraithFormSpell.m_SpellID),
            new SpellBookEntry( 1, SkillName.Necromancie, "Lich form", LichFormSpell.m_Info.Reagents, 0x8D2, 3, LichFormSpell.m_SpellID),
            new SpellBookEntry( 1, SkillName.Necromancie, "Animate Dead", AnimateDeadSpell.m_Info.Reagents, 0x8D2, 3, AnimateDeadSpell.m_SpellID),
            new SpellBookEntry( 1, SkillName.Necromancie, "Vengeful spirit", VengefulSpiritSpell.m_Info.Reagents, 0x8D2, 3, VengefulSpiritSpell.m_SpellID),
            new SpellBookEntry( 1, SkillName.Necromancie, "Summon Familiar", SummonFamiliarSpell.m_Info.Reagents, 0x8D2, 3, SummonFamiliarSpell.m_SpellID),




            ////Adjuration
            //new SpellBookEntry( 1, "Fermeture Mag.", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D2, 3, 19),
            //new SpellBookEntry( 1, "Piège Magique", new Type[] { typeof(Nightshade), typeof(SpidersSilk) }, 0x8cC, 2, 13),
            //new SpellBookEntry( 2, "Ouverture Mag.", new Type[] { typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8D6, 3, 23),
            //new SpellBookEntry( 2, "Sup. De Piège", new Type[] { typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8cD, 2, 14),
            //new SpellBookEntry( 3, "Nuisance", new Type[] { typeof(Nightshade), typeof(SpidersSilk) }, 0x8cB, 2, 12),
            //new SpellBookEntry( 4, "Champ de Dissi.", new Type[] { typeof(BlackPearl), typeof(SpidersSilk), typeof(SulfurousAsh), typeof(Garlic) }, 0x8E1, 5, 34),
            //new SpellBookEntry( 5, "Dissipation", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8E8, 6, 41),
            //new SpellBookEntry( 6, "Drain de Mana", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8DE, 4, 31),
            //new SpellBookEntry( 7, "Poison", new Type[] { typeof(Nightshade) }, 0x8D3, 3, 20),
            //new SpellBookEntry( 8, "Dissip. Masse", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(BlackPearl), typeof(SulfurousAsh) }, 0x8F5, 7, 54),
            //new SpellBookEntry( 9, "Drain Vamp.", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8F4, 7, 53),
            //new SpellBookEntry( 10, "Mur de Poison", new Type[] { typeof(BlackPearl), typeof(Nightshade), typeof(SpidersSilk) }, 0x8E6, 5, 39),

            ////Alteration
            //new SpellBookEntry( 1, "Faiblesse", new Type[] { typeof(Garlic), typeof(Nightshade) }, 0x8c7, 1, 8),
            //new SpellBookEntry( 2, "Maladroit", new Type[] { typeof(Bloodmoss), typeof(Nightshade) }, 0x8c0, 1, 1),
            //new SpellBookEntry( 3, "Débilité", new Type[] { typeof(Ginseng), typeof(Nightshade) }, 0x8c2, 1, 3),
            //new SpellBookEntry( 4, "Telekinesis", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8D4, 3, 21),
            //new SpellBookEntry( 5, "Reflet", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8E3, 5, 36),
            //new SpellBookEntry( 8, "Malediction", new Type[] { typeof(Nightshade), typeof(Garlic), typeof(SulfurousAsh) }, 0x8DA, 4, 27),
            //new SpellBookEntry( 10, "Paralysie", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8E5, 5, 38),
            //new SpellBookEntry( 11, "Fléau", new Type[] { typeof(Garlic), typeof(Nightshade), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8ED, 6, 46),
            //new SpellBookEntry( 12, "Pétrification", new Type[] { typeof(BlackPearl), typeof(Ginseng), typeof(SpidersSilk) }, 0x8EE, 6, 47),

            ////Evocation
            //new SpellBookEntry( 1, "Bourrasque", new Type[] { typeof(MandrakeRoot) }, 0x5D7, 1, 201),
            //new SpellBookEntry( 1, "Flamèche", new Type[] { typeof(BlackPearl) }, 0x5BE, 1, 202),
            //new SpellBookEntry( 1, "Froid", new Type[] { typeof(Bloodmoss) }, 0x5CA, 1, 203),
            //new SpellBookEntry( 1, "Tempête", new Type[] { typeof(SulfurousAsh) }, 0x5C3, 1, 204),

            //new SpellBookEntry( 2, "Boule de Feu", new Type[] { typeof(BlackPearl) }, 0x8D1, 3, 18),
            //new SpellBookEntry( 3, "Mur de Feu", new Type[] { typeof(BlackPearl), typeof(SpidersSilk), typeof(SulfurousAsh) }, 0x8DB, 4, 28),
            //new SpellBookEntry( 4, "Énergie", new Type[] { typeof(BlackPearl), typeof(Nightshade) }, 0x8E9, 6, 42),
            //new SpellBookEntry( 5, "Éclair", new Type[] { typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8DD, 4, 30),
            //new SpellBookEntry( 6, "Explosion", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8EA, 6, 43),
            //new SpellBookEntry( 7, "Éner. de Masse", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(SpidersSilk), typeof(SulfurousAsh) }, 0x8F1, 7, 50),
            //new SpellBookEntry( 8, "Jet de Flamme", new Type[] { typeof(SpidersSilk), typeof(SulfurousAsh) }, 0x8F2, 7, 51),
            //new SpellBookEntry( 9, "Météores", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SulfurousAsh), typeof(SpidersSilk) }, 0x8F6, 7, 55),
            //new SpellBookEntry( 10, "Tremblement", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(Ginseng), typeof(SulfurousAsh) }, 0x8F8, 8, 57),
            //new SpellBookEntry( 11, "Vortex", new Type[] { typeof(Bloodmoss), typeof(BlackPearl), typeof(MandrakeRoot), typeof(Nightshade) }, 0x8F9, 8, 58),
            //new SpellBookEntry( 12, "Chaine d'Éclair", new Type[] { typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8F0, 7, 49),

            ////Illusion
            //new SpellBookEntry( 1, "Vision Noct.", new Type[] { typeof(SulfurousAsh), typeof(SpidersSilk) }, 0x8c5, 1, 6),
            //new SpellBookEntry( 1, "Voile", new Type[] { typeof(SulfurousAsh), typeof(SpidersSilk) }, 0x5BA, 1, 200),
            //new SpellBookEntry( 3, "Teleportation", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8D5, 3, 22),
            //new SpellBookEntry( 4, "Incognito", new Type[] { typeof(Bloodmoss), typeof(Garlic), typeof(Nightshade) }, 0x8E2, 5, 35),
            //new SpellBookEntry( 5, "Rappel", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8DF, 4, 32),
            //new SpellBookEntry( 6, "Lobotomie", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(Nightshade), typeof(SulfurousAsh) }, 0x8E4, 5, 37),
            //new SpellBookEntry( 7, "Marque", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8EC, 6, 45),
            //new SpellBookEntry( 8, "Polymorph", new Type[] { typeof(Bloodmoss), typeof(SpidersSilk), typeof(MandrakeRoot) }, 0x8F7, 7, 56),
            //new SpellBookEntry( 9, "Révélation", new Type[] { typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8EF, 6, 48),
            //new SpellBookEntry( 10, "Invisibilité", new Type[] { typeof(Bloodmoss), typeof(Nightshade) }, 0x8EB, 6, 44),
            //new SpellBookEntry( 12, "Voyagement", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8F3, 7, 52),

            ////Invocation
            //new SpellBookEntry( 1, "Nourriture", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8c1, 1, 2),
            //new SpellBookEntry( 2, "Flèche Mag.", new Type[] { typeof(SulfurousAsh) }, 0x8c4, 1, 5),
            //new SpellBookEntry( 3, "Mur de Pierre", new Type[] { typeof(Bloodmoss), typeof(Garlic) }, 0x8D7, 3, 24),
            //new SpellBookEntry( 4, "Convocation", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8E7, 5, 40),
            //new SpellBookEntry( 5, "Elem. de Terre", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8FD, 8, 62),
            //new SpellBookEntry( 6, "Esprit de Lame", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(Nightshade) }, 0x8E0, 5, 33),
            //new SpellBookEntry( 7, "Elem. d'Air", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8FB, 8, 60),
            //new SpellBookEntry( 9, "Elem. de Feu", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk), typeof(SulfurousAsh) }, 0x8FE, 8, 63),
            //new SpellBookEntry( 10, "Elem. d'Eau", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8FF, 8, 64),
            //new SpellBookEntry( 12, "Conjuration", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk), typeof(SulfurousAsh) }, 0x8FC, 8, 61),

            ////Necromancy            
            //new SpellBookEntry( 1, "Spectre", new Type[] { typeof(NoxCrystal), typeof(PigIron) }, 0x500F, 9, 115),
            //new SpellBookEntry( 2, "Corruption", new Type[] { typeof(GraveDust), typeof(PigIron) }, 0x5008, 9, 108),
            //new SpellBookEntry( 2, "Présage", new Type[] { typeof(BatWing), typeof(NoxCrystal) }, 0x5004, 9, 104),
            //new SpellBookEntry( 3, "Sermant", new Type[] { typeof(DaemonBlood) }, 0x5001, 9, 101),
            //new SpellBookEntry( 3, "Corps Mortifié", new Type[] { typeof(BatWing), typeof(GraveDust) }, 0x5002, 9, 102),
            //new SpellBookEntry( 4, "Minion", new Type[] { typeof(BatWing), typeof(GraveDust), typeof(DaemonBlood) }, 0x500B, 9, 111),
            //new SpellBookEntry( 5, "Pourriture", new Type[] { typeof(BatWing), typeof(PigIron), typeof(DaemonBlood) }, 0x5007, 9, 107),
            //new SpellBookEntry( 5, "Bête Horrifique", new Type[] { typeof(BatWing), typeof(DaemonBlood) }, 0x5005, 9, 105),
            //new SpellBookEntry( 6, "Venin", new Type[] { typeof(NoxCrystal) }, 0x5009, 9, 109),
            //new SpellBookEntry( 7, "Flétrir", new Type[] { typeof(NoxCrystal), typeof(GraveDust), typeof(PigIron) }, 0x500E, 9, 114),
            //new SpellBookEntry( 8, "Étranglement", new Type[] { typeof(DaemonBlood), typeof(NoxCrystal) }, 0x500A, 9, 110),
            //new SpellBookEntry( 9, "Liche", new Type[] { typeof(GraveDust), typeof(DaemonBlood), typeof(NoxCrystal) }, 0x5006, 9, 106),
            //new SpellBookEntry( 10, "Maudire", new Type[] { typeof(PigIron) }, 0x5003, 9, 103),
            //new SpellBookEntry( 11, "Esprit Vengeur", new Type[] { typeof(BatWing), typeof(GraveDust), typeof(PigIron) }, 0x500D, 9, 113),
            //new SpellBookEntry( 12, "Animation", new Type[] { typeof(GraveDust), typeof(DaemonBlood), typeof(NoxCrystal), typeof(PigIron) }, 0x5000, 9, 100),
            //new SpellBookEntry( 12, "Vampirisme", new Type[] { typeof(BatWing), typeof(NoxCrystal), typeof(PigIron) }, 0x500C, 9, 112),

            ////Thaumaturgie
            //new SpellBookEntry( 1, "Force", new Type[] { typeof(MandrakeRoot), typeof(Nightshade) }, 0x8cF, 2, 16),
            //new SpellBookEntry( 2, "Agilité", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8c8, 2, 9),
            //new SpellBookEntry( 3, "Ruse", new Type[] { typeof(MandrakeRoot), typeof(Nightshade) }, 0x8c9, 2, 10),
            //new SpellBookEntry( 4, "Armure Mag.", new Type[] { typeof(Garlic), typeof(SpidersSilk), typeof(SulfurousAsh) }, 0x8c6, 1, 7),
            //new SpellBookEntry( 5, "Protection", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(SulfurousAsh) }, 0x8cE, 2, 15),
            //new SpellBookEntry( 6, "Antidote", new Type[] { typeof(Garlic), typeof(Ginseng) }, 0x8cA, 2, 11),
            //new SpellBookEntry( 7, "Soins", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(SpidersSilk) }, 0x8c3, 1, 4),
            //new SpellBookEntry( 8, "Puissance", new Type[] { typeof(Garlic), typeof(MandrakeRoot) }, 0x8D0, 3, 17),
            //new SpellBookEntry( 9, "Remède", new Type[] { typeof(Bloodmoss), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8D8, 4, 25),
            //new SpellBookEntry( 10, "Protection Mag.", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8D9, 4, 26),
            //new SpellBookEntry( 11, "Soins Magiques", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8DC, 4, 29),
            //new SpellBookEntry( 12, "Résurrection", new Type[] { typeof(Bloodmoss), typeof(Garlic), typeof(Ginseng) }, 0x8FA, 8, 59),

        };

        public bool HasSpell(Mobile from, int spellID)
        {
            return (m_Book.HasSpell(spellID));
        }
        
        #region tableaux

        //Liste des magies du spellbook et leur couleur
        public SkillName[] m_SkillsList = new SkillName[] {
            SkillName.Evocation,
            SkillName.Immuabilite,
            SkillName.Alteration,
            SkillName.Providence,
            SkillName.Transmutation,
            SkillName.Thaumaturgie,
            SkillName.Hallucination,
            SkillName.Ensorcellement,
            SkillName.Necromancie
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

            m_Names[0] = "Evocation";
            m_Names[1] = "Immuabilite";
            m_Names[2] = "Alteration";
            m_Names[3] = "Providence";
            m_Names[4] = "Transmutation";
            m_Names[5] = "Thaumaturgie";
            m_Names[6] = "Hallucination";
            m_Names[7] = "Ensorcellement";
            m_Names[8] = "Necromancie";
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
                newconnaissance = (int)info.SkillLevel;

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
                    AddHtml(160 + hindex * 145, 32, 200, 20, "<h3><basefont color=#025a>" + (string)m_Names[info.Skill] + "<basefont></h3>", false, false);

                    // Séparateurs
                    AddImageTiled(130 + hindex * 165, 40, 130, 10, 0x3A);

                    //On remet à 0 pour la nouvelle page
                    vindex = 0;

                    //On ajoute les boutons de changement de page
                    AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, totpage + 1);
                    AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, totpage - 1);
                }

                //Si le livre possède le sort
                if (this.HasSpell(from, info.SpellID))
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

                oldconnaissance = (int)info.Skill;
             }

            value = 0;

            //Pour tous les sorts
            for (int i = 0; i < m_SpellBookEntry.Length; i++)
            {
                SpellBookEntry info = (SpellBookEntry)m_SpellBookEntry[i];

                //Si le livre possède le sort
                if (this.HasSpell(from, info.SpellID))
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

                    if (m_Names.Contains(info.Skill))
                        name = (string)m_Names[info.Skill];

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
                    AddHtml(130 + hindex * 165, 192, 200, 20, "<h3><basefont color=#5A4A31>" + name + " " + info.SkillLevel + "<basefont></h3>", false, false);


                    //On augmente le nombre de sort de 1 pour le prochain sort.
                    value++;
                }
            }

            totpage++;
            AddPage(totpage);
            AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, totpage - 1);
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