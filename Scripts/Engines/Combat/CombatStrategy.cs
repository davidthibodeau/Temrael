using Server.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Combat
{
    /// <summary>
    /// Class servant de base au système de combat.
    /// Chaque type de combat (mêlée, distance, haches, créatures) va override cette class et 
    /// l'arme va utiliser ces methods pour engager le combat.
    /// </summary>
    [PropertyObject]
    public abstract class CombatStrategy
    {
        public virtual SkillName ToucherSkill { get { return SkillName.ArmeTranchante; } }
        public virtual int Range { get { return 1; } }

        /// <summary>
        /// Cette valeur détermine le pourcentage de pénétration avec 100 dans la compétence Penetration.
        /// Une valeur inférieure de pénétration scale de façon linéaire.
        /// </summary>
        public virtual double PenetrationRatio { get { return 0.3; } }

        #region Sequence de Combat
        /// <summary>
        /// Détermine la séquence de combat d'une tentative de coup de l'attaquant au défenseur.
        /// </summary>
        /// <param name="atk">L'attaquant</param>
        /// <param name="def">Le défenseur</param>
        /// <returns>Le délai nécessaire avant de pouvoir porter le prochain coup.</returns>
        public int Sequence(Mobile atk, Mobile def)
        {
            return 0;
        }
        #endregion

        #region Toucher
        public bool Toucher(Mobile atk, Mobile def)
        {
            double chance = ToucherChance(atk, def);

            if (chance < 0.02)
                chance = 0.02;

            return chance >= Utility.RandomDouble();
        }

        protected virtual double ToucherChance(Mobile atk, Mobile def)
        {
            double atkvalue = atk.Skills[ToucherSkill].Value;
            double defvalue = def.Skills[(def.Weapon as BaseWeapon).CombatStrategy.ToucherSkill].Value;

            double chance = (atkvalue + 20.0) * 100 / ((defvalue + 20.0) * 200);

            return chance;
        }
        #endregion

        #region Degats
        public int Degats(Mobile atk, Mobile def)
        {
            int basedmg = Utility.RandomMinMax((atk.Weapon as BaseWeapon).MinDamage, (atk.Weapon as BaseWeapon).MaxDamage);

            double dmg = ComputerDegats(atk, basedmg);
            double resist = ReducedArmor(atk, def.PhysicalResistance);

            // TODO: Insérer valeur de résistance naturelle dans le calcul

            dmg = dmg * (1 - resist);

            return (int)dmg;
        }

        public int MinDegats(Mobile atk)
        {
            return (int)ComputerDegats(atk, (atk.Weapon as BaseWeapon).MinDamage);
        }

        public int MaxDegats(Mobile atk)
        {
            return (int)ComputerDegats(atk, (atk.Weapon as BaseWeapon).MaxDamage);
        }

        protected virtual double ComputerDegats(Mobile atk, int basedmg)
        {
            double strBonus = GetBonus(atk.Str, 0.3, 5);
            double tactiqueBonus = GetBonus(atk.Skills[SkillName.Tactiques].Value, 0.625, 6.25);
            double anatomyBonus = GetBonus(atk.Skills[SkillName.Anatomie].Value, 0.5, 5);
            double exceptBonus = (atk.Weapon as BaseWeapon).Quality == WeaponQuality.Exceptional ?
                GetBonus(atk.Skills[SkillName.Polissage].Value, 0.5, 10) : 0;

            return basedmg * (1 + strBonus + tactiqueBonus + anatomyBonus);
        }

        protected virtual double ReducedArmor(Mobile atk, double baseArmor)
        {
            double pen = GetBonus(atk.Skills[SkillName.Penetration].Value, PenetrationRatio, 5);
            double resist = ReduceValue(baseArmor, pen);
            return resist;
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
        #endregion

        #region Parer
        /// <summary>
        /// Cette fonction sert à déterminer si le défenseur a paré le coup.
        /// Elle est appelée du module de stratégie du défendeur et utilise donc les informations de la class CombatStrategy courante.
        /// </summary>
        /// <param name="def">Le défendeur de l'attaque.</param>
        /// <returns>true si le défendeur a paré le coup.</returns>
        public bool Parer(Mobile def)
        {
            double chance = ParerChance(def);
            return chance >= Utility.RandomDouble();
        }

        protected abstract double ParerChance(Mobile def);
        #endregion
    }
}
