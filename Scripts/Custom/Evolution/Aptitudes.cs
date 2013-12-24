using System;
using Server;
using Server.Mobiles;
using System.Collections;
using Server.Gumps;

namespace Server
{
    public enum NAptitude
    {
        Boucherie = 0,
        Broderie,
        Botanique,
        Commerce,
        Cuisson,
        Ebenisterie,
        Fignolage,
        Forestier,
        Hermetisme,
        Invention,
        Metallurgie,
        Mineur,
        Polissage,
        Tanneur,
        Transcription,

        Barbarisme,
        CombatAuSol,
        CombatMonte,
        Commandement,
        CoupPrecis,
        CoupPuissant,
        CoupRenversant,
        Endurance,
        Esquive,
        Parade,
        PortArmure,
        PortArme,
        PortArmeDistance,
        PortBouclier,
        Precision,
        Resistance,
        Robustesse,
        Strategie,
        TirPrecis,
        TueurDeMonstre,

        Assassinat,
        Cambriolage,
        Composition,
        Deguisement,
        Depistage,
        Derobage,
        Evasion,
        Familier,
        LibreDeplacement,
        MouvementCache,
        Pillage,
        Resilience,

        Adjuration,
        Alteration,
        DispenseComposante,
        Evocation,
        Illusion,
        Incantation,
        Invocation,
        Necromancie,
        PortArmeMagique,
        Receptacle,
        Sorcellerie,
        SortDeMasse,
        Spiritisme,
        Thaumaturgie,

        Benedictions,
        Fanatisme,
        Monial,
        FaveurDivine,
        GraceDivine,
        Protection,

        PointSup,
        Saut
        //MortDef,
        //Rente,
        
        //Annonces,
    }

    public class AptitudesEntry
    {
        private NAptitude m_Aptitude;
        private int m_Max;
        private SkillName m_Skill;
        private double m_FirstSkill;
        private double m_SecondSkill;
        private double m_ThirdSkill;
        private double m_FourthSkill;
        private double m_FifthSkill;
        private double m_SixthSkill;
        private double m_SeventhSkill;
        private double m_EighthSkill;
        private double m_NinthSkill;
        private double m_TenthSkill;
        private double m_EleventhSkill;
        private double m_TwelvethSkill;
        private int m_FirstApt;
        private int m_SecondApt;
        private int m_ThirdApt;
        private ClasseBranche m_Type;

        public NAptitude Aptitude { get { return m_Aptitude; } }
        public int Max { get { return m_Max; } }
        public SkillName Skill { get { return m_Skill; } }
        public double FirstSkill { get { return m_FirstSkill; } }
        public double SecondSkill { get { return m_SecondSkill; } }
        public double ThirdSkill { get { return m_ThirdSkill; } }
        public double FourthSkill { get { return m_FourthSkill; } }
        public double FifthSkill { get { return m_FifthSkill; } }
        public double SixthSkill { get { return m_SixthSkill; } }
        public double SeventhSkill { get { return m_SeventhSkill; } }
        public double EighthSkill { get { return m_EighthSkill; } }
        public double NinthSkill { get { return m_NinthSkill; } }
        public double TenthSkill { get { return m_TenthSkill; } }
        public double EleventhSkill { get { return m_EleventhSkill; } }
        public double TwelvethSkill { get { return m_TwelvethSkill; } }
        public int FirstApt { get { return m_FirstApt; } }
        public int SecondApt { get { return m_SecondApt; } }
        public int ThirdApt { get { return m_ThirdApt; } }
        public ClasseBranche Type { get { return m_Type; } }

        public AptitudesEntry(NAptitude aptitude, int max, SkillName skill, double firstSkillReq, double secondSkillReq, double thirdSkillReq, double fourthSkillReq, double fifthSkillReq, double sixthSkillReq, double seventhSkillReq, double eighthSkillReq, double ninthSkillReq, double tenthSkillReq, double eleventhSkillReq, double twelvethSkillReq, int firstAptReq, int secondAptReq, int thirdAptReq, ClasseBranche type)
        {
            m_Aptitude = aptitude;
            m_Max = max;
            m_Skill = skill;
            m_FirstSkill = firstSkillReq;
            m_SecondSkill = secondSkillReq;
            m_ThirdSkill = thirdSkillReq;
            m_FourthSkill = fourthSkillReq;
            m_FifthSkill = fifthSkillReq;
            m_SixthSkill = sixthSkillReq;
            m_SeventhSkill = seventhSkillReq;
            m_EighthSkill = eighthSkillReq;
            m_NinthSkill = ninthSkillReq;
            m_TenthSkill = tenthSkillReq;
            m_EleventhSkill = eleventhSkillReq;
            m_TwelvethSkill = twelvethSkillReq;
            m_FirstApt = firstAptReq;
            m_SecondApt = secondAptReq;
            m_ThirdApt = thirdAptReq;
            m_Type = type;
        }
    }

    public class AptitudeInfo
    {
        private string m_name = string.Empty;
        private AptitudesEntry m_entry = null;
        private int m_tooltip = 0;
        private int m_Image = 0;
        private string m_Description;
        private string[] m_DescriptionNiveau;
        private string m_Note;

        public string Name { get { return m_name; } }
        public AptitudesEntry Entry { get { return m_entry; } }
        public int Tooltip { get { return m_tooltip; } }
        public string Description { get { return m_Description; } }
        public string[] DescriptionNiveau { get { return m_DescriptionNiveau; } }
        public string Note { get { return m_Note; } }
        public int Image { get { return m_Image; } }

        public AptitudeInfo(string name, AptitudesEntry entry, int tooltip, string description, string[] descriptionNiveau, string note, int image)
        {
            m_name = name;
            m_entry = entry;
            m_tooltip = tooltip;
            m_Description = description;
            m_DescriptionNiveau = descriptionNiveau;
            m_Note = note;
            m_Image = image;
        }
    }

    public sealed class Aptitudes : BaseAptitudes
    {
        #region AptitudeInfo
        public static AptitudeInfo GetInfos(NAptitude aptitude)
        {
            AptitudeInfo info = null;

            switch (aptitude)
            {
                case NAptitude.Boucherie: info = AptitudeBoucherie.AptitudeInfo; break;
                case NAptitude.Broderie: info = AptitudeBroderie.AptitudeInfo; break;
                case NAptitude.Commerce: info = AptitudeCommerce.AptitudeInfo; break;
                case NAptitude.Cuisson: info = AptitudeCuisson.AptitudeInfo; break;
                case NAptitude.Ebenisterie: info = AptitudeEbenisterie.AptitudeInfo; break;
                case NAptitude.Fignolage: info = AptitudeFignolage.AptitudeInfo; break;
                case NAptitude.Forestier: info = AptitudeForestier.AptitudeInfo; break;
                case NAptitude.Hermetisme: info = AptitudeHermetisme.AptitudeInfo; break;
                case NAptitude.Invention: info = AptitudeInvention.AptitudeInfo; break;
                case NAptitude.Metallurgie: info = AptitudeMetallurgie.AptitudeInfo; break;
                case NAptitude.Mineur: info = AptitudeMineur.AptitudeInfo; break;
                case NAptitude.Polissage: info = AptitudePolissage.AptitudeInfo; break;
                case NAptitude.Tanneur: info = AptitudeTanneur.AptitudeInfo; break;
                case NAptitude.Transcription: info = AptitudeTranscription.AptitudeInfo; break;

                case NAptitude.Barbarisme: info = AptitudeBarbarisme.AptitudeInfo; break;
                case NAptitude.CombatAuSol: info = AptitudeCombatAuSol.AptitudeInfo; break;
                case NAptitude.CombatMonte: info = AptitudeCombatMonte.AptitudeInfo; break;
                case NAptitude.Commandement: info = AptitudeCommandement.AptitudeInfo; break;
                case NAptitude.CoupPrecis: info = AptitudeCoupPrecis.AptitudeInfo; break;
                case NAptitude.CoupPuissant: info = AptitudeCoupPuissant.AptitudeInfo; break;
                case NAptitude.CoupRenversant: info = AptitudeCoupRenversant.AptitudeInfo; break;
                case NAptitude.Endurance: info = AptitudeEndurance.AptitudeInfo; break;
                case NAptitude.Esquive: info = AptitudeEsquive.AptitudeInfo; break;
                case NAptitude.Parade: info = AptitudeParade.AptitudeInfo; break;
                case NAptitude.PortArmure: info = AptitudePortArmure.AptitudeInfo; break;
                case NAptitude.PortArme: info = AptitudePortArme.AptitudeInfo; break;
                case NAptitude.PortArmeDistance: info = AptitudePortArmeDistance.AptitudeInfo; break;
                case NAptitude.PortBouclier: info = AptitudePortBouclier.AptitudeInfo; break;
                case NAptitude.Precision: info = AptitudePrecision.AptitudeInfo; break;
                case NAptitude.Resistance: info = AptitudeResistance.AptitudeInfo; break;
                case NAptitude.Robustesse: info = AptitudeRobustesse.AptitudeInfo; break;
                case NAptitude.Strategie: info = AptitudeStrategie.AptitudeInfo; break;
                case NAptitude.TirPrecis: info = AptitudeTirPrecis.AptitudeInfo; break;
                case NAptitude.TueurDeMonstre: info = AptitudeTueurDeMonstre.AptitudeInfo; break;

                case NAptitude.Assassinat: info = AptitudeAssassinat.AptitudeInfo; break;
                case NAptitude.Cambriolage: info = AptitudeCambriolage.AptitudeInfo; break;
                case NAptitude.Composition: info = AptitudeComposition.AptitudeInfo; break;
                case NAptitude.Deguisement: info = AptitudeDeguisement.AptitudeInfo; break;
                case NAptitude.Depistage: info = AptitudeDepistage.AptitudeInfo; break;
                case NAptitude.Derobage: info = AptitudeDerobage.AptitudeInfo; break;
                case NAptitude.Evasion: info = AptitudeEvasion.AptitudeInfo; break;
                case NAptitude.Familier: info = AptitudeFamilier.AptitudeInfo; break;
                case NAptitude.LibreDeplacement: info = AptitudeLibreDeplacement.AptitudeInfo; break;
                case NAptitude.MouvementCache: info = AptitudeMouvementCache.AptitudeInfo; break;
                case NAptitude.Pillage: info = AptitudePillage.AptitudeInfo; break;
                case NAptitude.Resilience: info = AptitudeResilience.AptitudeInfo; break;

                case NAptitude.Adjuration: info = AptitudeAdjuration.AptitudeInfo; break;
                case NAptitude.Alteration: info = AptitudeAlteration.AptitudeInfo; break;
                case NAptitude.DispenseComposante: info = AptitudeDispenseComposante.AptitudeInfo; break;
                case NAptitude.Evocation: info = AptitudeEvocation.AptitudeInfo; break;
                case NAptitude.Illusion: info = AptitudeIllusion.AptitudeInfo; break;
                case NAptitude.Incantation: info = AptitudeIncantation.AptitudeInfo; break;
                case NAptitude.Invocation: info = AptitudeInvocation.AptitudeInfo; break;
                case NAptitude.Necromancie: info = AptitudeNecromancie.AptitudeInfo; break;
                case NAptitude.PortArmeMagique: info = AptitudePortArmeMagique.AptitudeInfo; break;
                case NAptitude.Receptacle: info = AptitudeReceptacle.AptitudeInfo; break;
                case NAptitude.Sorcellerie: info = AptitudeSorcellerie.AptitudeInfo; break;
                case NAptitude.SortDeMasse: info = AptitudeSortDeMasse.AptitudeInfo; break;
                case NAptitude.Spiritisme: info = AptitudeSpiritisme.AptitudeInfo; break;
                case NAptitude.Thaumaturgie: info = AptitudeThaumaturgie.AptitudeInfo; break;

                case NAptitude.Benedictions: info = AptitudeBenedictions.AptitudeInfo; break;
                case NAptitude.Fanatisme: info = AptitudeFanatisme.AptitudeInfo; break;
                case NAptitude.FaveurDivine: info = AptitudeFanatisme.AptitudeInfo; break;
                case NAptitude.GraceDivine: info = AptitudeFanatisme.AptitudeInfo; break;

                default: info = BaseAptitude.AptitudeInfo; break;
            }

            return info;
        }
        #endregion

        #region AptitudesEntry
        public static AptitudesEntry[] m_AptitudeEntries = new AptitudesEntry[]
		{
                //9 -> Artisanat
                new AptitudesEntry( NAptitude.Boucherie,                   12, SkillName.Excavation, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, ClasseBranche.Artisan ), 
				new AptitudesEntry( NAptitude.Broderie,                    12, SkillName.Couture, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 2, ClasseBranche.Artisan ), 
                new AptitudesEntry( NAptitude.Botanique,                   12, SkillName.Agriculture, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 2, ClasseBranche.Aucun ), 
                new AptitudesEntry( NAptitude.Commerce,                     1, SkillName.Excavation, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0,  ClasseBranche.Artisan ), 
                new AptitudesEntry( NAptitude.Cuisson,                     12, SkillName.Cuisine, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  1, 1, 1,  ClasseBranche.Artisan ), 
                new AptitudesEntry( NAptitude.Ebenisterie,                 12, SkillName.Menuiserie, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 2, 2,  ClasseBranche.Artisan ), 
                new AptitudesEntry( NAptitude.Fignolage,                   -1, SkillName.Excavation, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  1, 1, 2,  ClasseBranche.Artisan ), 
                new AptitudesEntry( NAptitude.Forestier,                   12, SkillName.Foresterie, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  1, 2, 2,  ClasseBranche.Artisan ), 
                new AptitudesEntry( NAptitude.Hermetisme,                  12, SkillName.Alchimie, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 2, 2,  ClasseBranche.Artisan ), 
                new AptitudesEntry( NAptitude.Invention,                   12, SkillName.Bricolage, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 2, 2,  ClasseBranche.Artisan ), 
                new AptitudesEntry( NAptitude.Metallurgie,                 12, SkillName.Forge, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 2, 2,  ClasseBranche.Artisan ), 
                new AptitudesEntry( NAptitude.Mineur,                      12, SkillName.Excavation, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  1, 2, 3,  ClasseBranche.Artisan ), 
                new AptitudesEntry( NAptitude.Polissage,                   -1, SkillName.Excavation, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  1, 2, 2,  ClasseBranche.Artisan ), 
                new AptitudesEntry( NAptitude.Tanneur,                     12, SkillName.Excavation, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1,  ClasseBranche.Artisan ), 
                new AptitudesEntry( NAptitude.Transcription,               12, SkillName.Inscription, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 2,  ClasseBranche.Artisan ), 
                //17 -> Combat
                new AptitudesEntry( NAptitude.Barbarisme,                  -1, SkillName.Tactiques, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 3, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( NAptitude.CombatAuSol,                 12, SkillName.Tactiques, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 2, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( NAptitude.CombatMonte,                 -1, SkillName.Equitation, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 3, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( NAptitude.Commandement,                -1, SkillName.Tactiques, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  1, 2, 2, ClasseBranche.Aucun ), 
                new AptitudesEntry( NAptitude.CoupPrecis,                  -1, SkillName.Tactiques, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( NAptitude.CoupPuissant,                -1, SkillName.Tactiques, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 2, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( NAptitude.CoupRenversant,              12, SkillName.Tactiques, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 2, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( NAptitude.Endurance,                   -1, SkillName.Parer, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  1, 1, 2, ClasseBranche.Guerrier), 
                new AptitudesEntry( NAptitude.Esquive,                     -1, SkillName.Parer, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 2, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( NAptitude.Parade,                      -1, SkillName.Parer, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 2, 3, ClasseBranche.Aucun ), 
                new AptitudesEntry( NAptitude.PortArmure,                   6, SkillName.Parer, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  3, 4, 5, ClasseBranche.Guerrier ), 
                new AptitudesEntry( NAptitude.PortArme,                     6, SkillName.Tactiques, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 5, ClasseBranche.Guerrier ), 
                new AptitudesEntry( NAptitude.PortArmeDistance,             6, SkillName.ArmeDistance, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 5, ClasseBranche.Guerrier ), 
                new AptitudesEntry( NAptitude.PortBouclier,                 6, SkillName.Parer, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 5, ClasseBranche.Guerrier ), 
	            new AptitudesEntry( NAptitude.Precision,                   -1, SkillName.Tactiques, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 2, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( NAptitude.Resistance,                  -1, SkillName.Parer, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( NAptitude.Robustesse,                  12, SkillName.Parer, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( NAptitude.Strategie,                   12, SkillName.Tactiques, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 1, 1, 2, ClasseBranche.Aucun ), 
                new AptitudesEntry( NAptitude.TirPrecis,                   -1, SkillName.ArmeDistance, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( NAptitude.TueurDeMonstre,              -1, SkillName.Tactiques, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Guerrier ), 
                //12 -> Roublard
                new AptitudesEntry( NAptitude.Assassinat,                  -1, SkillName.ArmePerforante, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 3, 4, ClasseBranche.Roublard ), 
                new AptitudesEntry( NAptitude.Cambriolage,                 12, SkillName.Crochetage, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 3, 4, ClasseBranche.Roublard ), 
                new AptitudesEntry( NAptitude.Composition,                 12, SkillName.Musique, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 3, 4, ClasseBranche.Roublard ), 
                new AptitudesEntry( NAptitude.Deguisement,                 12, SkillName.Infiltration, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 1, 2, 3, ClasseBranche.Roublard ), 
                new AptitudesEntry( NAptitude.Depistage,                   12, SkillName.Detection, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Roublard ), 
                new AptitudesEntry( NAptitude.Derobage,                    -1, SkillName.Vol, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 3, 3, ClasseBranche.Roublard ), 
                new AptitudesEntry( NAptitude.Evasion,                     -1, SkillName.Discretion, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 1, 2, 2, ClasseBranche.Roublard ),
                new AptitudesEntry( NAptitude.Familier,                    -1, SkillName.Dressage, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 1, 1, 2, ClasseBranche.Roublard ), 
                new AptitudesEntry( NAptitude.LibreDeplacement,            12, SkillName.Survie, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 1, 1, 2, ClasseBranche.Roublard ), 
                new AptitudesEntry( NAptitude.MouvementCache,              -1, SkillName.Infiltration, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Roublard ), 
                new AptitudesEntry( NAptitude.Pillage,                     -1, SkillName.Vol, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Roublard ), 
                new AptitudesEntry( NAptitude.Resilience,                  -1, SkillName.Survie, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 1, 1, 2, ClasseBranche.Roublard ), 
                //10 -> Magie
                new AptitudesEntry( NAptitude.Adjuration,                  12, SkillName.Tenebrea, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 4, ClasseBranche.Magie ), 
                new AptitudesEntry( NAptitude.Alteration,                  12, SkillName.Mysticisme, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 4, ClasseBranche.Magie ), 
                new AptitudesEntry( NAptitude.DispenseComposante,           1, SkillName.ArtMagique, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 12, 0, 0, ClasseBranche.Magie ), 
                new AptitudesEntry( NAptitude.Evocation,                   12, SkillName.Destruction,30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 4, ClasseBranche.Magie ), 
                new AptitudesEntry( NAptitude.Illusion,                    12, SkillName.Reve, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 4, ClasseBranche.Magie ), 
                new AptitudesEntry( NAptitude.Incantation,                 10, SkillName.Concentration, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 1, 2, 2, ClasseBranche.Magie ), 
                new AptitudesEntry( NAptitude.Invocation,                  12, SkillName.Conjuration, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 4, ClasseBranche.Magie ), 
                new AptitudesEntry( NAptitude.Necromancie,                 12, SkillName.Goetie, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 4, ClasseBranche.Magie ), 
                new AptitudesEntry( NAptitude.PortArmeMagique,              3, SkillName.Concentration, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 4, 4, ClasseBranche.Magie ), 
                new AptitudesEntry( NAptitude.Receptacle,                  -1, SkillName.ArtMagique, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 1, 1, 2, ClasseBranche.Magie ), 
                new AptitudesEntry( NAptitude.Sorcellerie,                 -1, SkillName.ArtMagique, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Magie ),
                new AptitudesEntry( NAptitude.SortDeMasse,                 -1, SkillName.ArtMagique, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Magie ), 
                new AptitudesEntry( NAptitude.Spiritisme,                  -1, SkillName.Concentration, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Magie ), 
                new AptitudesEntry( NAptitude.Thaumaturgie,                12, SkillName.Restoration, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 4, ClasseBranche.Magie ), 
                //7 -> Cleric
                new AptitudesEntry( NAptitude.Benedictions,                12, SkillName.Miracles, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 4, ClasseBranche.Cleric ), 
                new AptitudesEntry( NAptitude.Fanatisme,                   12, SkillName.Miracles, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 4, ClasseBranche.Cleric ), 
                new AptitudesEntry( NAptitude.FaveurDivine,                12, SkillName.Priere, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Cleric ), 
                new AptitudesEntry( NAptitude.GraceDivine,                 12, SkillName.Priere, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Cleric ), 
                new AptitudesEntry( NAptitude.Monial,                      12, SkillName.Miracles, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 4, ClasseBranche.Cleric ),
   	    
                //Divers
                new AptitudesEntry( NAptitude.PointSup,                    -1, SkillName.Excavation, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ClasseBranche.Aucun ),
        };
        #endregion

        public Aptitudes(TMobile owner)
            : base(owner)
        {
        }

        public Aptitudes(TMobile owner, GenericReader reader)
            : base(owner, reader)
        {
        }

        public static int GetTooltip(NAptitude aptitude)
        {
            AptitudeInfo info = GetInfos(aptitude);

            return info.Tooltip;
        }

        public static int GetValue(TMobile m, NAptitude aptitude)
        {
            Aptitudes apti = m.Aptitudes;
            int value = 0;

            if (apti != null)
                value = apti[aptitude];

            return value;
        }

        public static int GetDisponiblePA(TMobile from)
        {
            return from.AptitudesLibres;
        }

        public static int GetRemainingPA(TMobile from)
        {
            int pa = from.Niveau + 5 + from.GetAptitudeValue(NAptitude.PointSup);
            int added = 0;

            try
            {
                for (int i = 0; i < m_AptitudeEntries.Length; i++)
                {
                    AptitudesEntry entry = (AptitudesEntry)m_AptitudeEntries[i];
                    NAptitude aptitude = entry.Aptitude;

                    int value = GetValue(from, aptitude);

                    if (value == 1)
                        added += entry.FirstApt;
                    else if (value == 2)
                        added += entry.SecondApt + entry.FirstApt;
                    else if (value == 3)
                        added += entry.ThirdApt + entry.SecondApt + entry.FirstApt;
                    else if (value == 4)
                        added += (entry.ThirdApt * 2) + entry.SecondApt + entry.FirstApt;
                    else if (value == 5)
                        added += (entry.ThirdApt * 3) + entry.SecondApt + entry.FirstApt;
                    else if (value == 6)
                        added += (entry.ThirdApt * 4) + entry.SecondApt + entry.FirstApt;
                    else if (value == 7)
                        added += (entry.ThirdApt * 5) + entry.SecondApt + entry.FirstApt;
                    else if (value == 8)
                        added += (entry.ThirdApt * 6) + entry.SecondApt + entry.FirstApt;
                    else if (value == 9)
                        added += (entry.ThirdApt * 7) + entry.SecondApt + entry.FirstApt;
                    else if (value == 10)
                        added += (entry.ThirdApt * 8) + entry.SecondApt + entry.FirstApt;
                    else if (value == 11)
                        added += (entry.ThirdApt * 9) + entry.SecondApt + entry.FirstApt;
                    else if (value >= 12)
                        added += (entry.ThirdApt * (value - 11)) + (entry.ThirdApt * 9) + entry.SecondApt + entry.FirstApt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return pa - added;
        }

        public static int GetCompReq(TMobile from, NAptitude aptitude)
        {
            int index = (int)aptitude;

            if (index >= 0 && index < m_AptitudeEntries.Length)
            {
                AptitudesEntry entry = m_AptitudeEntries[index];

                if (entry.ThirdSkill > 0)
                    return (int)entry.Skill;
                else
                    return -1;
            }

            return -1;
        }

        public static int GetCompNumReq(TMobile from, NAptitude aptitude)
        {
            int index = (int)aptitude;

            if (index >= 0 && index < m_AptitudeEntries.Length)
            {
                AptitudesEntry entry = m_AptitudeEntries[index];

                //if (!(entry.TwelveSkill > 0))
                //    return -1;

                switch (from.GetAptitudeValue(aptitude))
                {
                    case 0:
                        return Convert.ToInt32(entry.FirstSkill);
                    case 1:
                        return Convert.ToInt32(entry.SecondSkill);
                    case 2:
                        return Convert.ToInt32(entry.ThirdSkill);
                    default: break;
                }
                if (from.GetAptitudeValue(aptitude) > 2)
                    return Convert.ToInt32(entry.ThirdSkill);
            }

            return -1;
        }

        public static int GetRequiredPA(TMobile from, NAptitude aptitude)
        {
            int index = (int)aptitude;
            int req = 0;

            if (index >= 0 && index < m_AptitudeEntries.Length)
            {
                AptitudesEntry entry = m_AptitudeEntries[index];
                int value = GetValue(from, aptitude);

                if (value == 0)
                    req = entry.FirstApt;
                else if (value == 1)
                    req = entry.SecondApt;
                else if (value >= 2)
                    req = entry.ThirdApt;
            }

            return req;
        }

        public static int GetBaseValue(TMobile from, NAptitude aptitude)
        {
            return from.GetBaseAptitudeValue(aptitude);
        }

        public static bool IsValid(TMobile from, NAptitude aptitude)
        {
            int index = (int)aptitude;

            if (index >= 0 && index < m_AptitudeEntries.Length)
            {
                AptitudesEntry entry = m_AptitudeEntries[index];

                int max = entry.Max;
                int value = (int)from.GetAptitudeValue(aptitude);

                if (max != -1 && value > max)
                    return false;

                double skillRequirement = from.Skills[entry.Skill].Base;
                int addedvalue = GetValue(from, aptitude);

                if (addedvalue == 0)
                {
                    return true;
                }
                else if (addedvalue == 1 && skillRequirement >= entry.FirstSkill)
                {
                    return true;
                }
                else if (addedvalue == 2 && skillRequirement >= entry.SecondSkill)
                {
                    return true;
                }
                else if (addedvalue >= 3 && skillRequirement >= entry.ThirdSkill)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        public static bool CanRaise(TMobile from, NAptitude aptitude)
        {
            int requiredPA = GetRequiredPA(from, aptitude);
            int dispoPA = GetDisponiblePA(from);

            if (dispoPA >= requiredPA)
            {
                int index = (int)aptitude;

                if (index >= 0 && index < m_AptitudeEntries.Length)
                {
                    AptitudesEntry entry = m_AptitudeEntries[index];

                    int max = entry.Max;
                    int value = from.GetAptitudeValue(aptitude);

                    if (max != -1 && value >= max)
                        return false;

                    double skillRequirement = from.Skills[entry.Skill].Base;
                    int addedvalue = GetValue(from, aptitude);

                    if (addedvalue == 0 && dispoPA >= entry.FirstApt && skillRequirement >= entry.FirstSkill)
                    {
                        return true;
                    }
                    else if (addedvalue == 1 && dispoPA >= entry.SecondApt && skillRequirement >= entry.SecondSkill)
                    {
                        return true;
                    }
                    else if (addedvalue >= 2 && dispoPA >= entry.ThirdApt && skillRequirement >= entry.ThirdSkill)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool CanLower(TMobile from, NAptitude aptitude)
        {
            int value = GetValue(from, aptitude);

            if (value > 0)
                return true;

            return false;
        }

        public int this[NAptitude aptitude]
        {
            get { return GetValue(aptitude); }
            set { SetValue(aptitude, value); }
        }

        public override string ToString()
        {
            return "...";
        }

        #region Artisans
        [CommandProperty(AccessLevel.GameMaster)]
        public int Broderie
        {
            get { return this[NAptitude.Broderie]; }
            set { this[NAptitude.Broderie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Boucherie
        {
            get { return this[NAptitude.Boucherie]; }
            set { this[NAptitude.Boucherie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Botanique
        {
            get { return this[NAptitude.Botanique]; }
            set { this[NAptitude.Botanique] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Commerce
        {
            get { return this[NAptitude.Commerce]; }
            set { this[NAptitude.Commerce] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Cuisson
        {
            get { return this[NAptitude.Cuisson]; }
            set { this[NAptitude.Cuisson] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Ebenisterie
        {
            get { return this[NAptitude.Ebenisterie]; }
            set { this[NAptitude.Ebenisterie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Fignolage
        {
            get { return this[NAptitude.Fignolage]; }
            set { this[NAptitude.Fignolage] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Forestier
        {
            get { return this[NAptitude.Forestier]; }
            set { this[NAptitude.Forestier] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Hermetisme
        {
            get { return this[NAptitude.Hermetisme]; }
            set { this[NAptitude.Hermetisme] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Invention
        {
            get { return this[NAptitude.Invention]; }
            set { this[NAptitude.Invention] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Mettallurgie
        {
            get { return this[NAptitude.Metallurgie]; }
            set { this[NAptitude.Metallurgie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Mineur
        {
            get { return this[NAptitude.Mineur]; }
            set { this[NAptitude.Mineur] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Polissage
        {
            get { return this[NAptitude.Polissage]; }
            set { this[NAptitude.Polissage] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Tanneur
        {
            get { return this[NAptitude.Tanneur]; }
            set { this[NAptitude.Tanneur] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Transcription
        {
            get { return this[NAptitude.Transcription]; }
            set { this[NAptitude.Transcription] = value; }
        }
        #endregion

        #region Guerriers
        [CommandProperty(AccessLevel.GameMaster)]
        public int Barbarisme
        {
            get { return this[NAptitude.Barbarisme]; }
            set { this[NAptitude.Barbarisme] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int CombatAuSol
        {
            get { return this[NAptitude.CombatAuSol]; }
            set { this[NAptitude.CombatAuSol] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int CombatMonte
        {
            get { return this[NAptitude.CombatMonte]; }
            set { this[NAptitude.CombatMonte] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Commandement
        {
            get { return this[NAptitude.Commandement]; }
            set { this[NAptitude.Commandement] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int CoupPrecis
        {
            get { return this[NAptitude.CoupPrecis]; }
            set { this[NAptitude.CoupPrecis] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int CoupPuissant
        {
            get { return this[NAptitude.CoupPuissant]; }
            set { this[NAptitude.CoupPuissant] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int CoupRenversant
        {
            get { return this[NAptitude.CoupRenversant]; }
            set { this[NAptitude.CoupRenversant] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Endurance
        {
            get { return this[NAptitude.Endurance]; }
            set { this[NAptitude.Endurance] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Esquive
        {
            get { return this[NAptitude.Esquive]; }
            set { this[NAptitude.Esquive] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Parade
        {
            get { return this[NAptitude.Parade]; }
            set { this[NAptitude.Parade] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int PortArmure
        {
            get { return this[NAptitude.PortArmure]; }
            set { this[NAptitude.PortArmure] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int PortArme
        {
            get { return this[NAptitude.PortArme]; }
            set { this[NAptitude.PortArme] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int PortArmeDistance
        {
            get { return this[NAptitude.PortArmeDistance]; }
            set { this[NAptitude.PortArmeDistance] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int PortBouclier
        {
            get { return this[NAptitude.PortBouclier]; }
            set { this[NAptitude.PortBouclier] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Precision
        {
            get { return this[NAptitude.Precision]; }
            set { this[NAptitude.Precision] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Resistance
        {
            get { return this[NAptitude.Resistance]; }
            set { this[NAptitude.Resistance] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Robustesse
        {
            get { return this[NAptitude.Robustesse]; }
            set { this[NAptitude.Robustesse] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Strategie
        {
            get { return this[NAptitude.Strategie]; }
            set { this[NAptitude.Strategie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int TirPrecis
        {
            get { return this[NAptitude.TirPrecis]; }
            set { this[NAptitude.TirPrecis] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int TueurDeMonstre
        {
            get { return this[NAptitude.TueurDeMonstre]; }
            set { this[NAptitude.TueurDeMonstre] = value; }
        }
        #endregion

        #region Mages
        [CommandProperty(AccessLevel.GameMaster)]
        public int Adjuration
        {
            get { return this[NAptitude.Adjuration]; }
            set { this[NAptitude.Adjuration] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Alteration
        {
            get { return this[NAptitude.Alteration]; }
            set { this[NAptitude.Alteration] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int DispenseComposante
        {
            get { return this[NAptitude.DispenseComposante]; }
            set { this[NAptitude.DispenseComposante] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Evocation
        {
            get { return this[NAptitude.Evocation]; }
            set { this[NAptitude.Evocation] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Illusion
        {
            get { return this[NAptitude.Illusion]; }
            set { this[NAptitude.Illusion] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Invocation
        {
            get { return this[NAptitude.Invocation]; }
            set { this[NAptitude.Invocation] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Incantation
        {
            get { return this[NAptitude.Incantation]; }
            set { this[NAptitude.Incantation] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Necromancie
        {
            get { return this[NAptitude.Necromancie]; }
            set { this[NAptitude.Necromancie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int PortArmeMagique
        {
            get { return this[NAptitude.PortArmeMagique]; }
            set { this[NAptitude.PortArmeMagique] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Receptacle
        {
            get { return this[NAptitude.Receptacle]; }
            set { this[NAptitude.Receptacle] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Sorcellerie
        {
            get { return this[NAptitude.Sorcellerie]; }
            set { this[NAptitude.Sorcellerie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Spiritisme
        {
            get { return this[NAptitude.Spiritisme]; }
            set { this[NAptitude.Spiritisme] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SortDeMasse
        {
            get { return this[NAptitude.SortDeMasse]; }
            set { this[NAptitude.SortDeMasse] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Thaumaturgie
        {
            get { return this[NAptitude.Thaumaturgie]; }
            set { this[NAptitude.Thaumaturgie] = value; }
        }
        #endregion

        #region Roublards
        [CommandProperty(AccessLevel.GameMaster)]
        public int Assassinat
        {
            get { return this[NAptitude.Assassinat]; }
            set { this[NAptitude.Assassinat] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Cambriolage
        {
            get { return this[NAptitude.Cambriolage]; }
            set { this[NAptitude.Cambriolage] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Deguisement
        {
            get { return this[NAptitude.Deguisement]; }
            set { this[NAptitude.Deguisement] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Derobage
        {
            get { return this[NAptitude.Derobage]; }
            set { this[NAptitude.Derobage] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Evasion
        {
            get { return this[NAptitude.Evasion]; }
            set { this[NAptitude.Evasion] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Familier
        {
            get { return this[NAptitude.Familier]; }
            set { this[NAptitude.Familier] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Depistage
        {
            get { return this[NAptitude.Depistage]; }
            set { this[NAptitude.Depistage] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int LibreDeplacement
        {
            get { return this[NAptitude.LibreDeplacement]; }
            set { this[NAptitude.LibreDeplacement] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int MouvementCache
        {
            get { return this[NAptitude.MouvementCache]; }
            set { this[NAptitude.MouvementCache] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Pillage
        {
            get { return this[NAptitude.Pillage]; }
            set { this[NAptitude.Pillage] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Resilience
        {
            get { return this[NAptitude.Resilience]; }
            set { this[NAptitude.Resilience] = value; }
        }
        #endregion

        #region Cleric
        [CommandProperty(AccessLevel.GameMaster)]
        public int Benedictions
        {
            get { return this[NAptitude.Benedictions]; }
            set { this[NAptitude.Benedictions] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Fanatisme
        {
            get { return this[NAptitude.Fanatisme]; }
            set { this[NAptitude.Fanatisme] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int FaveurDivine
        {
            get { return this[NAptitude.FaveurDivine]; }
            set { this[NAptitude.FaveurDivine] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int GraceDivine
        {
            get { return this[NAptitude.GraceDivine]; }
            set { this[NAptitude.GraceDivine] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Protection
        {
            get { return this[NAptitude.Protection]; }
            set { this[NAptitude.Protection] = value; }
        }
        #endregion
    }

    [PropertyObject]
    public abstract class BaseAptitudes
    {
        private TMobile m_Owner;
        public int[] m_Values;
        private int[] m_Base = new int[100];

        public TMobile Owner { get { return m_Owner; } }

        public BaseAptitudes(TMobile owner)
        {
            m_Owner = owner;
            m_Values = m_Base;
        }

        public BaseAptitudes(TMobile owner, GenericReader reader)
        {
            m_Owner = owner;

            int version = reader.ReadInt();

            int oldLength = reader.ReadInt();

            m_Values = new int[oldLength];

            if (m_Values.Length != 99)
                m_Values = new int[100];

            for (int i = 0; i < oldLength; ++i)
                m_Values[i] = reader.ReadInt();
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write((int)0); // version;

            writer.Write((int)m_Values.Length);

            for (int i = 0; i < m_Values.Length; ++i)
                writer.Write((int)m_Values[i]);
        }

        public int GetValue(NAptitude aptitude)
        {
            int index = GetIndex(aptitude);

            if (index >= 0 && index < m_Values.Length)
            {
                int value = m_Values[index];

                return value;
            }

            return 0;
        }

        public void SetValue(NAptitude aptitude, int value)
        {
            int index = GetIndex(aptitude);

            if (index >= 0 && index < m_Values.Length)
            {
                int oldvalue = m_Values[index];

                m_Values[index] = value;

                m_Owner.OnAptitudesChange(aptitude, oldvalue, value);
            }
        }

        private int GetIndex(NAptitude aptitude)
        {
            int index = (int)aptitude;

            return index;
        }

        public virtual void Reset()
        {
            for (int i = 0; i < m_Values.Length; i++)
            {
                m_Values[i] = 0;
                m_Owner.OnAptitudesChange((NAptitude)i, Owner.GetAptitudeValue((NAptitude)i) + 1, Owner.GetAptitudeValue((NAptitude)i));
            }

            Owner.AptitudesLibres = 5 + Owner.Niveau + Owner.GetAptitudeValue(NAptitude.PointSup);
        }
    }
}
