using System;
using Server.Spells;
using Server.Engines.Durability;
using Server.Spells.TechniquesCombat;

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
            double basepen = GetBonus(atk.Skills[SkillName.Penetration].Value, 0.35);
            double reducedar = ReduceValue(basear, basepen);
            reducedar = ReduceValue(reducedar, incpen);

            return Reduction(dmg, reducedar + def.ArmureNaturelle);
        }
        #endregion

        #region Degats Magiques
        public void AppliquerDegatsMagiques(Mobile def, double dmg)
        {
            def = ProtectionTechnique.GetOnHitEffect(def);

            double reducedDmg = Reduction(dmg, def.MagicalResistance);

            MagicReflectSpell.GetOnHitEffect(def, ref reducedDmg);

            DurabilityHandler.OnMagicDamageReceive(def);

            def.Damage((int)reducedDmg);
        }

        public short CercleMax { get { return 6; } } // Il y a présentement 6 cercles dans le système de magie.
        const double DPSBASE = 3;
        const double ScalingCategorie = 0.5;// Bonus qui fait la différence entre un spell de cercle 1, et de cercle 10, pour les dégâts.
        const double ScalingSpellMax = 3;   // Le SpellScaling peut augmenter les dégâts jusqu'à un maximum de *5.
        const double RandVariation = 0.1;   // Les valeurs de dégâts peuvent varier de +- 20%.

        public double RandDegatsMagiques(Mobile atk, SkillName branche, short cercle, TimeSpan tempsCast)
        {
            double degats = GetDegatsMagiques(atk, branche, cercle, tempsCast);

            if (Utility.RandomBool()) // +-
            {
                return (degats + (degats * Utility.RandomDouble() * RandVariation));
            }
            else
            {
                return (degats - (degats * Utility.RandomDouble() * RandVariation));
            }
        }

        private double GetDegatsMagiques(Mobile atk, SkillName branche, short cercle, TimeSpan tempsCast)
        {
            return (BaseDegatsMagique(tempsCast) *
                   (Spell.GetSpellScaling(atk, branche, ScalingSpellMax) + 1) *
                   (((ScalingCategorie / CercleMax) * cercle) + 1));
        }

        private double BaseDegatsMagique(TimeSpan tempsCast)
        {
            return DPSBASE * tempsCast.Seconds;
        }
        #endregion

        private double Reduction(double dmg, double resist)
        {
            resist = resist / 100;

            return dmg * (1 - resist);
        }

        public static double GetBonus(double value, double scalar)
        {
            double bonus = value * scalar;

            if (value >= 100)
                bonus += scalar * 5; // 5% de la valeur a 100 est donnee en bonus.

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