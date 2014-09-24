using Server.Items;
using Server.Mobiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Engines.Equitation;

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
        #region Sequence de Combat
        /// <summary>
        /// Détermine la séquence de combat d'une tentative de coup de l'attaquant au défenseur.
        /// </summary>
        /// <param name="atk">L'attaquant</param>
        /// <param name="def">Le défenseur</param>
        /// <returns>Le délai nécessaire avant de pouvoir porter le prochain coup.</returns>
        public int Sequence(Mobile atk, Mobile def)
        {
            if (Toucher(atk, def))
                OnHit(atk, def);
            else
                OnMiss(atk, def);

            CheckEquitationAttaque(atk);
            
            return ProchaineAttaque(atk);
        }

        public virtual void OnHit(Mobile atk, Mobile def)
        {
            AttaqueAnimation(atk);
            DegatsAnimation(def);


            CheckEquitation(def, EquitationType.BeingAttacked);

            atk.PlaySound(Weapon(atk).GetHitAttackSound(atk, def));
            def.PlaySound(Weapon(def).GetHitDefendSound(atk, def));

            int degats = Degats(atk, def);
            if (DefStrategy(def).Parer(def))
            {
                def.FixedEffect(0x37B9, 10, 16);
                degats = 0;
            }

            def.Damage(degats,atk);
        }

        public virtual void OnMiss(Mobile atk, Mobile def)
        {
            AttaqueAnimation(atk);
            atk.PlaySound(Weapon(atk).GetMissAttackSound(atk, def));
        }

        public virtual void AttaqueAnimation(Mobile atk)
        {
            int action = Weapon(atk).SwingAnimation(atk);
            atk.Animate(action, 7, 1, true, false, 0);
        }
        
        public virtual void DegatsAnimation(Mobile def)
        {
            int action, frames;
            if (Weapon(def).PlayHurtAnimation(def, out action, out frames))
                def.Animate(action, frames, 1, true, false, 0);
        }

        //public delegate void EffetsAuxiliaires(Mobile atk, Mobile def);
        // Note: Should be in mobile.
        #endregion

        #region Equitation Check

        void CheckEquitationAttaque(Mobile m)
        {
            if (BaseRange != 1)
            {
                CheckEquitation(m, EquitationType.Ranged);
            }
            else if (BaseRange == 1)
            {
                CheckEquitation(m, EquitationType.Attacking);
            }
        }

        void CheckEquitation(Mobile m, EquitationType type)
        {
            Equitation.Equitation.CheckEquitation(m, type);
        }
        #endregion

        #region Range
        public virtual int BaseRange { get { return 1; } }

        public virtual int Range(Mobile atk)
        {
            return BaseRange;
        }
        #endregion

        #region Toucher
        public abstract SkillName ToucherSkill { get; }

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
            if (Critique(atk))
                dmg = CritiqueDegats(atk, dmg);
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
            double exceptBonus = 0;
            switch ((atk.Weapon as BaseWeapon).Quality)
            {
                case WeaponQuality.Low: exceptBonus = -0.20; break;
                case WeaponQuality.Regular: exceptBonus = 0; break;
                case WeaponQuality.Exceptional:
                    exceptBonus = 0.20;
                    exceptBonus += GetBonus(atk.Skills[SkillName.Polissage].Value, 0.2, 10);
                    break;
            }
            // TODO : Ajouter effet de la qualité et du dmg level basé sur le minerais ?

            return basedmg * (1 + strBonus + tactiqueBonus + anatomyBonus + exceptBonus);
        }

        protected virtual double ReducedArmor(Mobile atk, double baseArmor)
        {
            double pen = GetBonus(atk.Skills[SkillName.Penetration].Value, 0.3, 5);
            double resist = ReduceValue(baseArmor, pen);
            return resist / 100;
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
        #endregion

        #region Coup Critique
        public bool Critique(Mobile atk)
        {
            double chance = CritiqueChance(atk);
            return chance >= Utility.RandomDouble();
        }

        protected virtual double CritiqueChance(Mobile atk)
        {
            double chance = GetBonus(atk.Skills[SkillName.CoupCritique].Value, 0.2, 5);
            return chance;
        }

        protected virtual double CritiqueDegats(Mobile atk, double dmg)
        {
            double intvalue = GetBonus(atk.Int, 0.25, 10);
            return dmg * (1 + intvalue);
        }
        #endregion

        #region Vitesse
        /// <summary>
        /// Calcule le délai avant la prochaine attaque basé sur la vitesse du personnage.
        /// </summary>
        /// <param name="atk">Le personnage portant l'attaque.</param>
        /// <returns>Le délai en millisecondes.</returns>
        public int ProchaineAttaque(Mobile atk)
        {
            return (int)(Vitesse(atk) * 100);
        }

        /// <summary>
        /// Calcule la vitesse du personnage en fonction de la vitesse de son arme (celle-ci calculée en dixième de seconde)
        /// </summary>
        /// <param name="atk">Le personnage portant l'attaque.</param>
        /// <returns>Retourne le délai entre deux attaques en dixième de seconde.</returns>
        public double Vitesse(Mobile atk)
        {
            //Par tranche de 50 de stam, on retire 0.25 secondes (ou 0.1 secondes tous les 20 de stam)
            double s = Weapon(atk).Speed - atk.Stam/20;

            //Le délai minimal est de 1.25 secondes entre deux attaques.
            if (s < 10)
                s = 10;

            return s;
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

        protected CombatStrategy DefStrategy(Mobile def)
        {
            return (def.Weapon as BaseWeapon).CombatStrategy;
        }

        protected BaseWeapon Weapon(Mobile m)
        {
            return m.Weapon as BaseWeapon;
        }
    }
}
