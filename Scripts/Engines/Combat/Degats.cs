using System;

namespace Server.Engines.Combat
{
    public class Damage
    {
        private Damage() { }

        public static readonly Damage instance = new Damage();
        
        #region Degats Physiques
        public double DegatsPhysiquesReduits(Mobile atk, Mobile def, double dmg)
        {
            return DegatsPhysiquesReduits(atk, def, dmg, 0);
        }

        public double DegatsPhysiquesReduits(Mobile atk, Mobile def, double dmg, double incpen)
        {
            double basear = def.PhysicalResistance > 75 ? 75 : def.PhysicalResistance;
            double basepen = GetBonus(atk.Skills[SkillName.Penetration].Value, 0.3, 5);
            double reducedar = ReduceValue(basear, basepen);
            reducedar = ReduceValue(reducedar, incpen);

            return Reduction(dmg, reducedar + def.ArmureNaturelle);
        }
        #endregion

        #region Degats Magiques
        public void AppliquerDegatsMagiques(Mobile def, double dmg)
        {
            double reducedDmg = Reduction(dmg, def.MagicResistance);

            def.Damage((int)reducedDmg);
        }

        const double DPSBASE = 6.45;
        const double ScalingArtMag      = 0.5;// Bonus lié au skill ArtMagique.
        const double ScalingCategorie   = 0.5;// Bonus qui fait la différence entre un spell de cercle 1, et de cercle 10.
        const double ScalMainBranche    = 0;  // Scaling sur le skill de la branche passée en paramètre.
        const double ScalScndBranche    = 0;  // Scaling sur les skills des autres branches.
        const short NbTotalCercles      = 10; // Il y a présentement 10 cercles dans le système de magie.

        public double GetDegatsMagiques(Mobile atk, SkillName branche, short cercle, TimeSpan tempsCast)
        {
            double BaseDamage = BaseDegatsMagiques(cercle, tempsCast);
            double TotalDamage = BaseDamage;

            // Les ifs sont gérés à la compilation, donc pas de coût, juste un warning gossant.
            if (ScalingArtMag != 0)
            {
                TotalDamage += GetBonus(BaseDamage, ScalingArtMag, 0);
            }

            if (ScalMainBranche != 0)
            {
                // "ScalMainBranche - ScalScndBranche" parce qu'on reprend l'influence de la branche principale comme une branche secondaire, plus tard.
                TotalDamage += GetBonus(BaseDamage, ScalMainBranche - ScalScndBranche, 0) * atk.Skills[branche].Value;
            }

            if (ScalScndBranche != 0)
            {
                double value = atk.Skills[SkillName.Evocation].Value
                             + atk.Skills[SkillName.Immuabilite].Value
                             + atk.Skills[SkillName.Alteration].Value
                             + atk.Skills[SkillName.Providence].Value
                             + atk.Skills[SkillName.Transmutation].Value
                             + atk.Skills[SkillName.Thaumaturgie].Value
                             + atk.Skills[SkillName.Hallucination].Value
                             + atk.Skills[SkillName.Ensorcellement].Value
                             + atk.Skills[SkillName.Necromancie].Value;

                TotalDamage += GetBonus(BaseDamage, ScalScndBranche, 0) * value;
            }

            return TotalDamage;
        }

        private double BaseDegatsMagiques(short cercle, TimeSpan tempsCast)
        {
            // Calcul de la fiche Excel.
            return (((((ScalingCategorie / NbTotalCercles) * cercle) + 1) * DPSBASE) * tempsCast.TotalSeconds);
        }
        #endregion

        private double Reduction(double dmg, double resist)
        {
            resist = resist / 100;

            return dmg * (1 - resist);
        }

        protected double GetBonus(double value, double scalar, double offset)
        {
            double bonus = value * scalar;

            if (value >= 100)
                bonus += offset;

            return bonus / 100;
        }

        protected double ReduceValue(double value, double factor)
        {
            return value * (1 - factor);
        }

        protected double IncreasedValue(double value, double factor)
        {
            return value * (1 + factor);
        }

        protected double IncValueDimReturn(double value, double factor)
        {
            if (value >= 1) return 1;
            if (value < 0) value = 0;

            return (1 - value) * factor + value;
        }
    }
}