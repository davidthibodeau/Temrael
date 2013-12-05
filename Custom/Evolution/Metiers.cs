using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Mobiles;
using System.Collections;

namespace Server
{
    public enum MetierType
    {
        None = -1,
        //Annonceur = 0,
        //Aubergiste,
        Boucher,
        Bricoleur,
        //Brigand,
        //Catin,
        Charpentier,
        Commercant,
        Couturier,
        Cuisinier,
        Dresseur,
        Forgeron,
        Herboriste,
        //Mercenaire,
        Noble,
        //Paysan,
        Scribe,
        //Soldat,
        //Voyageur,

        Maximum
    }

    public enum MetierBranche
    {
        Aucune = -1,
        Artisan = 0,
        Guerrier,
        Divers,

        Maximum
    }

    public class MetierInfo
    {
        private MetierType m_Metier;
        private ClasseAptitudes[] m_Aptitudes;
        private string m_Nom;
        private MetierBranche m_MetierBranche;
        private int m_Image;

        public MetierType Metier { get { return m_Metier; } }
        public ClasseAptitudes[] Aptitudes { get { return m_Aptitudes; } }
        public string Nom { get { return m_Nom; } }
        public MetierBranche MetierBranche { get { return m_MetierBranche; } }
        public int Image { get { return m_Image; } }

        public MetierInfo(MetierType metier, ClasseAptitudes[] aptitudes, string name, MetierBranche branche, int image)
        {
            m_Metier = metier;
            m_Aptitudes = aptitudes;
            m_Nom = name;
            m_MetierBranche = branche;
            m_Image = image;
        }
    }

    public sealed class Metiers
    {
        public static bool IsValidChange(MetierType oldMetier, MetierType newMetier)
        {
            /*MetierInfo oldinfo = GetInfos(oldMetier);
            MetierInfo info = GetInfos(newMetier);

            if (info == null)
                return false;

            return (info.MetierAvant == oldMetier || (info != null && oldinfo != null && info.MetierAvant == Metier.Aucun && oldinfo.MetierAvant == Metier.Aucun && info.MetierBranche == oldinfo.MetierBranche));*/

            return true;
        }

        public static int GetAptitudeValue(TMobile from, MetierType metier, NAptitude aptitude)
        {
            MetierInfo info = GetInfos(metier);

            if (info == null)
                return 0;

            if (info.Aptitudes != null)
            {
                for (int i = 0; i < info.Aptitudes.Length; ++i)
                {
                    ClasseAptitudes aptitudes = info.Aptitudes[i];

                    if (aptitudes.Niveau <= from.Niveau)
                    {
                      if (aptitudes.Aptitude == aptitude)
                        return aptitudes.Value;
                    }
                }
            }

            return 0;
        }

        public static Hashtable GetAptitudes(MetierType metier, int niveau)
        {
            Hashtable table = new Hashtable();
            MetierInfo info = GetInfos(metier);

            if (info == null)
                return table;

            if (info.Aptitudes != null)
            {
                for (int i = 0; i < info.Aptitudes.Length; ++i)
                {
                    ClasseAptitudes aptitudes = info.Aptitudes[i];

                    if (aptitudes.Niveau <= niveau)
                    {
                      if (!table.ContainsKey(aptitudes.Aptitude))
                        table.Add(aptitudes.Aptitude, aptitudes.Value);
                    }
                }
            }

            return table;
        }

        public static MetierBranche GetMetierBranche(MetierType metier)
        {
            MetierInfo info = GetInfos(metier);

            if (info == null)
                return MetierBranche.Aucune;

            return info.MetierBranche;
        }

        public static bool IsValid(TMobile m, MetierType metier)
        {
            MetierInfo info = GetInfos(metier);

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

        public static MetierInfo GetInfos(MetierType metier)
        {
            MetierInfo info = null;

            switch (metier)
            {
                case MetierType.Boucher: info = MetierBoucher.MetierInfo; break;
                case MetierType.Bricoleur: info = MetierBricoleur.MetierInfo; break;
                case MetierType.Charpentier: info = MetierCharpentier.MetierInfo; break;
                case MetierType.Commercant: info = MetierCommercant.MetierInfo; break;
                case MetierType.Couturier: info = MetierCouturier.MetierInfo; break;
                case MetierType.Cuisinier: info = MetierCuisinier.MetierInfo; break;
                case MetierType.Forgeron: info = MetierForgeron.MetierInfo; break;
                case MetierType.Herboriste: info = MetierHerboriste.MetierInfo; break;
                case MetierType.Scribe: info = MetierScribe.MetierInfo; break;

                case MetierType.Dresseur: info = MetierDresseur.MetierInfo; break;
                case MetierType.Noble: info = MetierNoble.MetierInfo; break;

                default: info = BaseMetier.MetierInfo; break;
            }

            return info;
        }
    }
}
