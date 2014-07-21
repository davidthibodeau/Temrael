using System;
using Server;
using Server.Mobiles;
using System.Collections;
using Server.Gumps;

namespace Server
{
    public enum Aptitude
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
        private Aptitude m_Aptitude;
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

        public Aptitude Aptitude { get { return m_Aptitude; } }
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

        public AptitudesEntry(Aptitude aptitude, int max, SkillName skill, double firstSkillReq, double secondSkillReq, double thirdSkillReq, double fourthSkillReq, double fifthSkillReq, double sixthSkillReq, double seventhSkillReq, double eighthSkillReq, double ninthSkillReq, double tenthSkillReq, double eleventhSkillReq, double twelvethSkillReq, int firstAptReq, int secondAptReq, int thirdAptReq, ClasseBranche type)
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

    public sealed class Aptitudes : BaseAptitudes
    {

        #region AptitudesEntry
        public static AptitudesEntry[] m_AptitudeEntries = new AptitudesEntry[]
		{
                //9 -> Artisanat
                new AptitudesEntry( Aptitude.Boucherie,                   12, SkillName.Excavation, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, ClasseBranche.Artisan ), 
				new AptitudesEntry( Aptitude.Broderie,                    12, SkillName.Couture, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 2, ClasseBranche.Artisan ), 
                new AptitudesEntry( Aptitude.Botanique,                   12, SkillName.Agriculture, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 2, ClasseBranche.Aucun ), 
                new AptitudesEntry( Aptitude.Commerce,                     1, SkillName.Excavation, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0,  ClasseBranche.Artisan ), 
                new AptitudesEntry( Aptitude.Cuisson,                     12, SkillName.Cuisine, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  1, 1, 1,  ClasseBranche.Artisan ), 
                new AptitudesEntry( Aptitude.Ebenisterie,                 12, SkillName.Menuiserie, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 2, 2,  ClasseBranche.Artisan ), 
                new AptitudesEntry( Aptitude.Fignolage,                   -1, SkillName.Excavation, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  1, 1, 2,  ClasseBranche.Artisan ), 
                new AptitudesEntry( Aptitude.Forestier,                   12, SkillName.Foresterie, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  1, 2, 2,  ClasseBranche.Artisan ), 
                new AptitudesEntry( Aptitude.Hermetisme,                  12, SkillName.Alchimie, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 2, 2,  ClasseBranche.Artisan ), 
                new AptitudesEntry( Aptitude.Invention,                   12, SkillName.Bricolage, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 2, 2,  ClasseBranche.Artisan ), 
                new AptitudesEntry( Aptitude.Metallurgie,                 12, SkillName.Forge, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 2, 2,  ClasseBranche.Artisan ), 
                new AptitudesEntry( Aptitude.Mineur,                      12, SkillName.Excavation, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  1, 2, 3,  ClasseBranche.Artisan ), 
                new AptitudesEntry( Aptitude.Polissage,                   -1, SkillName.Excavation, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  1, 2, 2,  ClasseBranche.Artisan ), 
                new AptitudesEntry( Aptitude.Tanneur,                     12, SkillName.Excavation, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1,  ClasseBranche.Artisan ), 
                new AptitudesEntry( Aptitude.Transcription,               12, SkillName.Inscription, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 2,  ClasseBranche.Artisan ), 
                //17 -> Combat
                new AptitudesEntry( Aptitude.Barbarisme,                  -1, SkillName.Tactiques, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 3, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( Aptitude.CombatAuSol,                 12, SkillName.Tactiques, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 2, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( Aptitude.CombatMonte,                 -1, SkillName.Equitation, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 3, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( Aptitude.Commandement,                -1, SkillName.Tactiques, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  1, 2, 2, ClasseBranche.Aucun ), 
                new AptitudesEntry( Aptitude.CoupPrecis,                  -1, SkillName.Tactiques, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( Aptitude.CoupPuissant,                -1, SkillName.Tactiques, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 2, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( Aptitude.CoupRenversant,              12, SkillName.Tactiques, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 2, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( Aptitude.Endurance,                   -1, SkillName.Parer, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  1, 1, 2, ClasseBranche.Guerrier), 
                new AptitudesEntry( Aptitude.Esquive,                     -1, SkillName.Parer, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 2, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( Aptitude.Parade,                      -1, SkillName.Parer, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 2, 3, ClasseBranche.Aucun ), 
                new AptitudesEntry( Aptitude.PortArmure,                   6, SkillName.Parer, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  3, 4, 5, ClasseBranche.Guerrier ), 
                new AptitudesEntry( Aptitude.PortArme,                     6, SkillName.Tactiques, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 5, ClasseBranche.Guerrier ), 
                new AptitudesEntry( Aptitude.PortArmeDistance,             6, SkillName.ArmeDistance, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 5, ClasseBranche.Guerrier ), 
                new AptitudesEntry( Aptitude.PortBouclier,                 6, SkillName.Parer, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 5, ClasseBranche.Guerrier ), 
	            new AptitudesEntry( Aptitude.Precision,                   -1, SkillName.Tactiques, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100,  2, 2, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( Aptitude.Resistance,                  -1, SkillName.Parer, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( Aptitude.Robustesse,                  12, SkillName.Parer, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( Aptitude.Strategie,                   12, SkillName.Tactiques, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 1, 1, 2, ClasseBranche.Aucun ), 
                new AptitudesEntry( Aptitude.TirPrecis,                   -1, SkillName.ArmeDistance, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Guerrier ), 
                new AptitudesEntry( Aptitude.TueurDeMonstre,              -1, SkillName.Tactiques, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Guerrier ), 
                //12 -> Roublard
                new AptitudesEntry( Aptitude.Assassinat,                  -1, SkillName.ArmePerforante, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 3, 4, ClasseBranche.Roublard ), 
                new AptitudesEntry( Aptitude.Cambriolage,                 12, SkillName.Crochetage, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 3, 4, ClasseBranche.Roublard ), 
                new AptitudesEntry( Aptitude.Composition,                 12, SkillName.Musique, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 3, 4, ClasseBranche.Roublard ), 
                new AptitudesEntry( Aptitude.Deguisement,                 12, SkillName.Infiltration, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 1, 2, 3, ClasseBranche.Roublard ), 
                new AptitudesEntry( Aptitude.Depistage,                   12, SkillName.Detection, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Roublard ), 
                new AptitudesEntry( Aptitude.Derobage,                    -1, SkillName.Vol, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 3, 3, ClasseBranche.Roublard ), 
                new AptitudesEntry( Aptitude.Evasion,                     -1, SkillName.Discretion, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 1, 2, 2, ClasseBranche.Roublard ),
                new AptitudesEntry( Aptitude.Familier,                    -1, SkillName.Dressage, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 1, 1, 2, ClasseBranche.Roublard ), 
                new AptitudesEntry( Aptitude.LibreDeplacement,            12, SkillName.Survie, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 1, 1, 2, ClasseBranche.Roublard ), 
                new AptitudesEntry( Aptitude.MouvementCache,              -1, SkillName.Infiltration, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Roublard ), 
                new AptitudesEntry( Aptitude.Pillage,                     -1, SkillName.Vol, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Roublard ), 
                new AptitudesEntry( Aptitude.Resilience,                  -1, SkillName.Survie, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 1, 1, 2, ClasseBranche.Roublard ), 
                //10 -> Magie
                new AptitudesEntry( Aptitude.Adjuration,                  12, SkillName.Tenebrea, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 4, ClasseBranche.Magie ), 
                new AptitudesEntry( Aptitude.Alteration,                  12, SkillName.Mysticisme, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 4, ClasseBranche.Magie ), 
                new AptitudesEntry( Aptitude.DispenseComposante,           1, SkillName.ArtMagique, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 12, 0, 0, ClasseBranche.Magie ), 
                new AptitudesEntry( Aptitude.Evocation,                   12, SkillName.Destruction,30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 4, ClasseBranche.Magie ), 
                new AptitudesEntry( Aptitude.Illusion,                    12, SkillName.Reve, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 4, ClasseBranche.Magie ), 
                new AptitudesEntry( Aptitude.Incantation,                 10, SkillName.Concentration, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 1, 2, 2, ClasseBranche.Magie ), 
                new AptitudesEntry( Aptitude.Invocation,                  12, SkillName.Conjuration, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 4, ClasseBranche.Magie ), 
                new AptitudesEntry( Aptitude.Necromancie,                 12, SkillName.Goetie, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 4, ClasseBranche.Magie ), 
                new AptitudesEntry( Aptitude.PortArmeMagique,              3, SkillName.Concentration, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 4, 4, ClasseBranche.Magie ), 
                new AptitudesEntry( Aptitude.Receptacle,                  -1, SkillName.ArtMagique, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 1, 1, 2, ClasseBranche.Magie ), 
                new AptitudesEntry( Aptitude.Sorcellerie,                 -1, SkillName.ArtMagique, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Magie ),
                new AptitudesEntry( Aptitude.SortDeMasse,                 -1, SkillName.ArtMagique, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Magie ), 
                new AptitudesEntry( Aptitude.Spiritisme,                  -1, SkillName.Concentration, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Magie ), 
                new AptitudesEntry( Aptitude.Thaumaturgie,                12, SkillName.Restoration, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 4, ClasseBranche.Magie ), 
                //7 -> Cleric
                new AptitudesEntry( Aptitude.Benedictions,                12, SkillName.Miracles, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 4, ClasseBranche.Cleric ), 
                new AptitudesEntry( Aptitude.Fanatisme,                   12, SkillName.Miracles, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 4, ClasseBranche.Cleric ), 
                new AptitudesEntry( Aptitude.FaveurDivine,                12, SkillName.Priere, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Cleric ), 
                new AptitudesEntry( Aptitude.GraceDivine,                 12, SkillName.Priere, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 2, 2, 3, ClasseBranche.Cleric ), 
                new AptitudesEntry( Aptitude.Monial,                      12, SkillName.Miracles, 30, 40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 3, 4, 4, ClasseBranche.Cleric ),
   	    
                //Divers
                new AptitudesEntry( Aptitude.PointSup,                    -1, SkillName.Excavation, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ClasseBranche.Aucun ),
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

        public static int GetValue(TMobile m, Aptitude aptitude)
        {
            return 0;
        }

        public static int GetDisponiblePA(TMobile from)
        {
            return from.AptitudesLibres;
        }

        public static int GetRemainingPA(TMobile from)
        {
            int pa = from.Niveau + 5 + from.GetAptitudeValue(Aptitude.PointSup);
            int added = 0;

            try
            {
                for (int i = 0; i < m_AptitudeEntries.Length; i++)
                {
                    AptitudesEntry entry = (AptitudesEntry)m_AptitudeEntries[i];
                    Aptitude aptitude = entry.Aptitude;

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
                Misc.ExceptionLogging.WriteLine(ex);
            }

            return pa - added;
        }

        public static int GetCompReq(TMobile from, Aptitude aptitude)
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

        public static int GetCompNumReq(TMobile from, Aptitude aptitude)
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

        public static int GetRequiredPA(TMobile from, Aptitude aptitude)
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

        public static int GetBaseValue(TMobile from, Aptitude aptitude)
        {
            return from.GetBaseAptitudeValue(aptitude);
        }

        public static bool IsValid(TMobile from, Aptitude aptitude)
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

        public static bool CanRaise(TMobile from, Aptitude aptitude)
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

        public static bool CanLower(TMobile from, Aptitude aptitude)
        {
            int value = GetValue(from, aptitude);

            if (value > 0)
                return true;

            return false;
        }

        public int this[Aptitude aptitude]
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
            get { return this[Aptitude.Broderie]; }
            set { this[Aptitude.Broderie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Boucherie
        {
            get { return this[Aptitude.Boucherie]; }
            set { this[Aptitude.Boucherie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Botanique
        {
            get { return this[Aptitude.Botanique]; }
            set { this[Aptitude.Botanique] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Commerce
        {
            get { return this[Aptitude.Commerce]; }
            set { this[Aptitude.Commerce] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Cuisson
        {
            get { return this[Aptitude.Cuisson]; }
            set { this[Aptitude.Cuisson] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Ebenisterie
        {
            get { return this[Aptitude.Ebenisterie]; }
            set { this[Aptitude.Ebenisterie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Fignolage
        {
            get { return this[Aptitude.Fignolage]; }
            set { this[Aptitude.Fignolage] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Forestier
        {
            get { return this[Aptitude.Forestier]; }
            set { this[Aptitude.Forestier] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Hermetisme
        {
            get { return this[Aptitude.Hermetisme]; }
            set { this[Aptitude.Hermetisme] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Invention
        {
            get { return this[Aptitude.Invention]; }
            set { this[Aptitude.Invention] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Mettallurgie
        {
            get { return this[Aptitude.Metallurgie]; }
            set { this[Aptitude.Metallurgie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Mineur
        {
            get { return this[Aptitude.Mineur]; }
            set { this[Aptitude.Mineur] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Polissage
        {
            get { return this[Aptitude.Polissage]; }
            set { this[Aptitude.Polissage] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Tanneur
        {
            get { return this[Aptitude.Tanneur]; }
            set { this[Aptitude.Tanneur] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Transcription
        {
            get { return this[Aptitude.Transcription]; }
            set { this[Aptitude.Transcription] = value; }
        }
        #endregion

        #region Guerriers
        [CommandProperty(AccessLevel.GameMaster)]
        public int Barbarisme
        {
            get { return this[Aptitude.Barbarisme]; }
            set { this[Aptitude.Barbarisme] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int CombatAuSol
        {
            get { return this[Aptitude.CombatAuSol]; }
            set { this[Aptitude.CombatAuSol] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int CombatMonte
        {
            get { return this[Aptitude.CombatMonte]; }
            set { this[Aptitude.CombatMonte] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Commandement
        {
            get { return this[Aptitude.Commandement]; }
            set { this[Aptitude.Commandement] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int CoupPrecis
        {
            get { return this[Aptitude.CoupPrecis]; }
            set { this[Aptitude.CoupPrecis] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int CoupPuissant
        {
            get { return this[Aptitude.CoupPuissant]; }
            set { this[Aptitude.CoupPuissant] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int CoupRenversant
        {
            get { return this[Aptitude.CoupRenversant]; }
            set { this[Aptitude.CoupRenversant] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Endurance
        {
            get { return this[Aptitude.Endurance]; }
            set { this[Aptitude.Endurance] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Esquive
        {
            get { return this[Aptitude.Esquive]; }
            set { this[Aptitude.Esquive] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Parade
        {
            get { return this[Aptitude.Parade]; }
            set { this[Aptitude.Parade] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int PortArmure
        {
            get { return this[Aptitude.PortArmure]; }
            set { this[Aptitude.PortArmure] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int PortArme
        {
            get { return this[Aptitude.PortArme]; }
            set { this[Aptitude.PortArme] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int PortArmeDistance
        {
            get { return this[Aptitude.PortArmeDistance]; }
            set { this[Aptitude.PortArmeDistance] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int PortBouclier
        {
            get { return this[Aptitude.PortBouclier]; }
            set { this[Aptitude.PortBouclier] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Precision
        {
            get { return this[Aptitude.Precision]; }
            set { this[Aptitude.Precision] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Resistance
        {
            get { return this[Aptitude.Resistance]; }
            set { this[Aptitude.Resistance] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Robustesse
        {
            get { return this[Aptitude.Robustesse]; }
            set { this[Aptitude.Robustesse] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Strategie
        {
            get { return this[Aptitude.Strategie]; }
            set { this[Aptitude.Strategie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int TirPrecis
        {
            get { return this[Aptitude.TirPrecis]; }
            set { this[Aptitude.TirPrecis] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int TueurDeMonstre
        {
            get { return this[Aptitude.TueurDeMonstre]; }
            set { this[Aptitude.TueurDeMonstre] = value; }
        }
        #endregion

        #region Mages
        [CommandProperty(AccessLevel.GameMaster)]
        public int Adjuration
        {
            get { return this[Aptitude.Adjuration]; }
            set { this[Aptitude.Adjuration] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Alteration
        {
            get { return this[Aptitude.Alteration]; }
            set { this[Aptitude.Alteration] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int DispenseComposante
        {
            get { return this[Aptitude.DispenseComposante]; }
            set { this[Aptitude.DispenseComposante] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Evocation
        {
            get { return this[Aptitude.Evocation]; }
            set { this[Aptitude.Evocation] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Illusion
        {
            get { return this[Aptitude.Illusion]; }
            set { this[Aptitude.Illusion] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Invocation
        {
            get { return this[Aptitude.Invocation]; }
            set { this[Aptitude.Invocation] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Incantation
        {
            get { return this[Aptitude.Incantation]; }
            set { this[Aptitude.Incantation] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Necromancie
        {
            get { return this[Aptitude.Necromancie]; }
            set { this[Aptitude.Necromancie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int PortArmeMagique
        {
            get { return this[Aptitude.PortArmeMagique]; }
            set { this[Aptitude.PortArmeMagique] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Receptacle
        {
            get { return this[Aptitude.Receptacle]; }
            set { this[Aptitude.Receptacle] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Sorcellerie
        {
            get { return this[Aptitude.Sorcellerie]; }
            set { this[Aptitude.Sorcellerie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Spiritisme
        {
            get { return this[Aptitude.Spiritisme]; }
            set { this[Aptitude.Spiritisme] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SortDeMasse
        {
            get { return this[Aptitude.SortDeMasse]; }
            set { this[Aptitude.SortDeMasse] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Thaumaturgie
        {
            get { return this[Aptitude.Thaumaturgie]; }
            set { this[Aptitude.Thaumaturgie] = value; }
        }
        #endregion

        #region Roublards
        [CommandProperty(AccessLevel.GameMaster)]
        public int Assassinat
        {
            get { return this[Aptitude.Assassinat]; }
            set { this[Aptitude.Assassinat] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Cambriolage
        {
            get { return this[Aptitude.Cambriolage]; }
            set { this[Aptitude.Cambriolage] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Deguisement
        {
            get { return this[Aptitude.Deguisement]; }
            set { this[Aptitude.Deguisement] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Derobage
        {
            get { return this[Aptitude.Derobage]; }
            set { this[Aptitude.Derobage] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Evasion
        {
            get { return this[Aptitude.Evasion]; }
            set { this[Aptitude.Evasion] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Familier
        {
            get { return this[Aptitude.Familier]; }
            set { this[Aptitude.Familier] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Depistage
        {
            get { return this[Aptitude.Depistage]; }
            set { this[Aptitude.Depistage] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int LibreDeplacement
        {
            get { return this[Aptitude.LibreDeplacement]; }
            set { this[Aptitude.LibreDeplacement] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int MouvementCache
        {
            get { return this[Aptitude.MouvementCache]; }
            set { this[Aptitude.MouvementCache] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Pillage
        {
            get { return this[Aptitude.Pillage]; }
            set { this[Aptitude.Pillage] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Resilience
        {
            get { return this[Aptitude.Resilience]; }
            set { this[Aptitude.Resilience] = value; }
        }
        #endregion

        #region Cleric
        [CommandProperty(AccessLevel.GameMaster)]
        public int Benedictions
        {
            get { return this[Aptitude.Benedictions]; }
            set { this[Aptitude.Benedictions] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Fanatisme
        {
            get { return this[Aptitude.Fanatisme]; }
            set { this[Aptitude.Fanatisme] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int FaveurDivine
        {
            get { return this[Aptitude.FaveurDivine]; }
            set { this[Aptitude.FaveurDivine] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int GraceDivine
        {
            get { return this[Aptitude.GraceDivine]; }
            set { this[Aptitude.GraceDivine] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Protection
        {
            get { return this[Aptitude.Protection]; }
            set { this[Aptitude.Protection] = value; }
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

        public int GetValue(Aptitude aptitude)
        {
            int index = GetIndex(aptitude);

            if (index >= 0 && index < m_Values.Length)
            {
                int value = m_Values[index];

                return value;
            }

            return 0;
        }

        public void SetValue(Aptitude aptitude, int value)
        {
            int index = GetIndex(aptitude);

            if (index >= 0 && index < m_Values.Length)
            {
                int oldvalue = m_Values[index];

                m_Values[index] = value;

                m_Owner.OnAptitudesChange(aptitude, oldvalue, value);
            }
        }

        private int GetIndex(Aptitude aptitude)
        {
            int index = (int)aptitude;

            return index;
        }

        public virtual void Reset()
        {
            for (int i = 0; i < m_Values.Length; i++)
            {
                m_Values[i] = 0;
                m_Owner.OnAptitudesChange((Aptitude)i, Owner.GetAptitudeValue((Aptitude)i) + 1, Owner.GetAptitudeValue((Aptitude)i));
            }

            Owner.AptitudesLibres = 5 + Owner.Niveau + Owner.GetAptitudeValue(Aptitude.PointSup);
        }
    }
}
