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
        //Guerrier
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
        //Ensorceleur,
        //Druide,
        //Shaman,

        //Roublard
        Espion,
        Rodeur,
        Assassin,
        Voleur,
        Barde,

        Artisan,

        //Divin
        //Moine,
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

    public class ClasseAptitudes
    {
        private int m_niveau;
        private NAptitude m_Aptitude;
        private int m_Value;

        public int Niveau { get { return m_niveau; } }
        public NAptitude Aptitude { get { return m_Aptitude; } }
        public int Value { get { return m_Value; } }

        public ClasseAptitudes(NAptitude aptitude, int value)
        {
            m_Aptitude = aptitude;
            m_Value = value;
        }

        public ClasseAptitudes(int niveau, NAptitude aptitude, int value)
        {
            m_niveau = niveau;
            m_Aptitude = aptitude;
            m_Value = value;
        }
    }

    public class ClasseComp
    {
        private SkillName m_SkillName;
        private double m_Value;

        public SkillName SkillName { get { return m_SkillName; } }
        public double Value { get { return m_Value; } }

        public ClasseComp(SkillName skillName, double value)
        {
            m_SkillName = skillName;
            m_Value = value;
        }
    }

    public class ClasseInfo
    {
        private ClasseType m_Classe;
        private ClasseAptitudes[] m_FirstApt;
        private ClasseAptitudes[] m_SecondApt;
        private ClasseAptitudes[] m_ThirdApt;
        private ClasseAptitudes[] m_FourthApt;
        private string[] m_Noms;
        private string m_Nom;
        private int m_Tooltip;
        private string m_Role;
        private ClasseBranche m_ClasseBranche;
        private int m_Image;
        private AlignementB m_Alignement;

        public ClasseType Classe { get { return m_Classe; } }
        public ClasseAptitudes[] FirstApt { get { return m_FirstApt; } }
        public ClasseAptitudes[] SecondApt { get { return m_SecondApt; } }
        public ClasseAptitudes[] ThirdApt { get { return m_ThirdApt; } }
        public ClasseAptitudes[] FourthApt { get { return m_FourthApt; } }
        public string[] Noms { get { return m_Noms; } }
        public string Nom { get { return m_Nom; } }
        public int Tooltip { get { return m_Tooltip; } }
        public string Role { get { return m_Role; } }
        public ClasseBranche ClasseBranche { get { return m_ClasseBranche; } }
        public int Image { get { return m_Image; } }
        public AlignementB Alignement { get { return m_Alignement; } }

        public ClasseInfo()
        {
        }

        public ClasseInfo(ClasseAptitudes[] firstApt, ClasseAptitudes[] secondApt, ClasseAptitudes[] thirdApt, ClasseAptitudes[] fourthApt, string name, string[] noms, string role, ClasseBranche branche, int image, int tooltip, AlignementB alignement)
        {
            m_FirstApt = firstApt;
            m_SecondApt = secondApt;
            m_ThirdApt = thirdApt;
            m_FourthApt = fourthApt;
            m_Nom = name;
            m_Noms = noms;
            m_Role = role;
            m_ClasseBranche = branche;
            m_Image = image;
            m_Tooltip = tooltip;
            m_Alignement = alignement;
        }

        public ClasseInfo(ClasseType classe, ClasseAptitudes[] firstApt, ClasseAptitudes[] secondApt, ClasseAptitudes[] thirdApt, ClasseAptitudes[] fourthApt, string name, string[] noms, string role, ClasseBranche branche, int image, int tooltip, AlignementB alignement)
        {
            m_Classe = classe;
            m_FirstApt = firstApt;
            m_SecondApt = secondApt;
            m_ThirdApt = thirdApt;
            m_FourthApt = fourthApt;
            m_Nom = name;
            m_Noms = noms;
            m_Role = role;
            m_ClasseBranche = branche;
            m_Image = image;
            m_Tooltip = tooltip;
            m_Alignement = alignement;
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

        public static int GetAptitudeValue(TMobile from, ClasseType classe, NAptitude aptitude)
        {
            ClasseInfo info = GetInfos(classe);
            ClasseAptitudes[] apt = null;

            if (info == null)
                return 0;

            if (from.Niveau >= 30)
                apt = info.FourthApt;
            else if (from.Niveau >= 20)
                apt = info.ThirdApt;
            else if (from.Niveau >= 10)
                apt = info.SecondApt;
            else
                apt = info.FirstApt;


            if (apt != null)
            {
                for (int i = 0; i < apt.Length; ++i)
                {
                    ClasseAptitudes aptitudes = apt[i];

                    if (aptitudes.Aptitude == aptitude)
                    return aptitudes.Value;
                }
            }

            return 0;
        }

        public static Hashtable GetAptitudes(ClasseType classe, int niveau)
        {
            Hashtable table = new Hashtable();
            ClasseInfo info = GetInfos(classe);
            ClasseAptitudes[] apt = null;

            if (info == null)
                return table;

            if (niveau >= 30)
                apt = info.FourthApt;
            else if (niveau >= 20)
                apt = info.ThirdApt;
            else if (niveau >= 10)
                apt = info.SecondApt;
            else
                apt = info.FirstApt;

            if (apt != null)
            {
                for (int i = 0; i < apt.Length; ++i)
                {
                    ClasseAptitudes aptitudes = apt[i];

                    if (!table.ContainsKey(aptitudes.Aptitude))
                        table.Add(aptitudes.Aptitude, aptitudes.Value);
                }
            }

            return table;
        }

        public static bool IsValid(TMobile m, ClasseType classe)
        {
            ClasseInfo info = GetInfos(classe);

            if (m == null || info == null)
                return false;

            /*if (info.Skills != null)
            {
                for (int i = 0; i < info.Skills.Length; ++i)
                {
                    ClasseComp skills = info.Skills[i];

                    if (m.Skills[skills.SkillName].Base < skills.Value)
                        return false;
                }
            }*/

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