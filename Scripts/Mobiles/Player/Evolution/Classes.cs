using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server
{
    public enum ClasseType
    {
        None = -1,
        Archer = 0,
        Barbare,
        Guerrier,
        Cavalier,
        Duelliste,
        Protecteur,
        Champion,

        //Mages
        Magicien,
        Sorcier,
        Necromancien,
        Illusioniste,
        Conjurateur,

        //Roublard
        Espion,
        Rodeur,
        Assassin,
        Voleur,
        Barde,

        Artisan,

        Pretre,
        Paladin,
        PaladinDechu,

        Maximum //pour comptage
    }

    public enum ClasseBranche
    {
        Aucun,
        Guerrier,
        Roublard,
        Magie,
        Cleric,
        Artisan
    }

    public class ClasseCompetences
    {
        private SkillName m_SkillName;
        private double m_Value;

        public SkillName SkillName { get { return m_SkillName; } }
        public double Value { get { return m_Value; } }

        public ClasseCompetences(SkillName skillName, double value)
        {
            m_SkillName = skillName;
            m_Value = value;
        }
    }

    public class ClasseInfo
    {
        private ClasseType m_Classe;
        private ClasseCompetences[] m_ClasseCompetences;
        private string[] m_Noms;
        private string m_Nom;
        private int m_Tooltip;
        private string m_Role;
        private ClasseBranche m_ClasseBranche;
        private int m_Image;
        
        public ClasseType Classe { get { return m_Classe; } }
        public ClasseCompetences[] ClasseCompetences { get { return m_ClasseCompetences; } }
        public string[] Noms { get { return m_Noms; } }
        public string Nom { get { return m_Nom; } }
        public int Tooltip { get { return m_Tooltip; } }
        public string Role { get { return m_Role; } }
        public ClasseBranche ClasseBranche { get { return m_ClasseBranche; } }
        public int Image { get { return m_Image; } }
        
        public ClasseInfo()
        {
        }

        public ClasseInfo(ClasseCompetences[] classeCompetences, string name, string[] noms, string role, ClasseBranche branche, int image, int tooltip)
        {
            m_ClasseCompetences = classeCompetences;
            m_Nom = name;
            m_Noms = noms;
            m_Role = role;
            m_ClasseBranche = branche;
            m_Image = image;
            m_Tooltip = tooltip;
        }

        public ClasseInfo(ClasseType classe, ClasseCompetences[] classeCompetences, string name, string[] noms, string role, ClasseBranche branche, int image, int tooltip)
        {
            m_Classe = classe;
            m_ClasseCompetences = classeCompetences;
            m_Nom = name;
            m_Noms = noms;
            m_Role = role;
            m_ClasseBranche = branche;
            m_Image = image;
            m_Tooltip = tooltip;
        }
    }

    public class Classes
    {
        public static bool IsValidChange(ClasseType oldClass, ClasseType newClass)
        {
            /*ClasseInfo oldinfo = GetInfos(oldClass);
            ClasseInfo info = GetInfos(newClass);

            if (info == null)
                return false;

            return (info.ClasseAvant == oldClass || (info != null && oldinfo != null && info.ClasseAvant == Classe.Aucune && oldinfo.ClasseAvant == Classe.Aucune && info.ClasseArbre == oldinfo.ClasseArbre));*/

            return true;
        }

        public static Hashtable GetCompetences(ClasseType classe)
        {
            Hashtable table = new Hashtable();
            ClasseInfo info = GetInfos(classe);
            ClasseCompetences[] cpt = null;

            if (info == null)
                return table;

            cpt = info.ClasseCompetences;

            if (cpt != null)
            {
                for (int i = 0; i < cpt.Length; ++i)
                {
                    ClasseCompetences competences = cpt[i];

                    if (!table.ContainsKey(competences.SkillName))
                        table.Add(competences.SkillName, competences.Value);
                }
            }

            return table;
        }

        public static bool IsValid(TMobile m, ClasseType classe)
        {
            ClasseInfo info = GetInfos(classe);

            if (m == null || info == null)
                return false;

            return true;
        }

        public static ClasseInfo GetInfos(ClasseType classe)
        {
            ClasseInfo info = null;

            switch (classe)
            {
                case ClasseType.Archer: info = ClasseArcher.ClasseInfo; break;
                case ClasseType.Barbare: info = ClasseBarbare.ClasseInfo; break;
                case ClasseType.Guerrier: info = ClasseGuerrier.ClasseInfo; break;
                case ClasseType.Cavalier: info = ClasseCavalier.ClasseInfo; break;
                case ClasseType.Duelliste: info = ClasseDuelliste.ClasseInfo; break;
                case ClasseType.Protecteur: info = ClasseProtecteur.ClasseInfo; break;
                case ClasseType.Champion: info = ClasseChampion.ClasseInfo; break;
                
                case ClasseType.Magicien: info = ClasseMagicien.ClasseInfo; break;
                case ClasseType.Sorcier: info = ClasseSorcier.ClasseInfo; break;
                case ClasseType.Necromancien: info = ClasseNecromancien.ClasseInfo; break;
                case ClasseType.Illusioniste: info = ClasseIllusioniste.ClasseInfo; break;
                case ClasseType.Conjurateur: info = ClasseConjurateur.ClasseInfo; break;

                case ClasseType.Paladin: info = ClassePaladin.ClasseInfo; break;
                case ClasseType.PaladinDechu: info = ClassePaladinDechu.ClasseInfo; break;
                case ClasseType.Pretre: info = ClassePretre.ClasseInfo; break;

                case ClasseType.Espion: info = ClasseEspion.ClasseInfo; break;
                case ClasseType.Rodeur: info = ClasseRodeur.ClasseInfo; break;
                case ClasseType.Assassin: info = ClasseAssassin.ClasseInfo; break;
                case ClasseType.Voleur: info = ClasseVoleur.ClasseInfo; break;
                case ClasseType.Barde: info = ClasseBarde.ClasseInfo; break;

                case ClasseType.Artisan: info = ClasseArtisan.ClasseInfo; break;

                default: info = BaseClasse.ClasseInfo; break;
            }

            return info;
        }
    }
}