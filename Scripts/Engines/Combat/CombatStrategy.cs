using Server.Engines.Equitation;
using Server.Items;
using Server.Mobiles;
using Server.Spells;
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

            bool crit;
            int degats = Degats(atk, def, out crit);
            if (DefStrategy(def).Parer(def))
            {
                def.FixedEffect(0x37B9, 10, 16);
                def.Mana -= 5;
                degats = 0;
            }
            else if(crit)
            {
                atk.Mana -= 10;
                atk.SendMessage("Vous effectuez un coup critique.");
                def.SendMessage("Vous recevez un coup critique.");
            }

            AppliquerPoison(atk, def);

            degats = Spell.OnHitEffects(atk, def, degats);

            def.Damage(degats,atk);
        }

        public virtual void OnMiss(Mobile atk, Mobile def)
        {
            AttaqueAnimation(atk);
            atk.PlaySound(Weapon(atk).GetMissAttackSound(atk, def));
        }

        // Utilise seulement pour les armes a distance.
        public abstract bool OnFired(Mobile atk, Mobile def);

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

        protected abstract void CheckEquitationAttaque(Mobile atk);

        public void CheckEquitation(Mobile m, EquitationType type)
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

            return atk.CheckSkill(ToucherSkill, chance);
        }

        protected virtual double ToucherChance(Mobile atk, Mobile def)
        {
            double atkvalue = atk.Skills[ToucherSkill].Value;
            double defvalue = def.Skills[(def.Weapon as BaseWeapon).Strategy.ToucherSkill].Value;

            double chance = (atkvalue + 20.0) * 100 / ((defvalue + 20.0) * 200);

            return chance;
        }
        #endregion

        #region Degats
        public int Degats(Mobile atk, Mobile def, out bool critique)
        {
            int basedmg = Utility.RandomMinMax((atk.Weapon as BaseWeapon).MinDamage, (atk.Weapon as BaseWeapon).MaxDamage);
            critique = false;
            double dmg = ComputerDegats(atk, basedmg, true);
            if (Critique(atk) && atk.Mana > 10)
            {
                critique = true;
                dmg = CritiqueDegats(atk, dmg);
            }

            return (int)DegatsReduits(atk, def, dmg);
        }

        public int MinDegats(Mobile atk)
        {
            return (int)ComputerDegats(atk, (atk.Weapon as BaseWeapon).MinDamage, false);
        }

        public int MaxDegats(Mobile atk)
        {
            return (int)ComputerDegats(atk, (atk.Weapon as BaseWeapon).MaxDamage, false);
        }

        protected virtual double ComputerDegats(Mobile atk, int basedmg, bool skillup)
        {
            if (skillup)
            {
                CheckSkillGain(atk, SkillName.Tactiques);
                CheckSkillGain(atk, SkillName.Anatomie);
            }

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
                    if (skillup)
                        CheckSkillGain(atk, SkillName.Polissage);
                    exceptBonus += GetBonus(atk.Skills[SkillName.Polissage].Value, 0.2, 10);
                    break;
            }
            // TODO : Ajouter effet de la qualité et du dmg level basé sur le minerais ?

            return basedmg * (1 + strBonus + tactiqueBonus + anatomyBonus + exceptBonus);
        }

        public virtual double DegatsReduits(Mobile atk, Mobile def, double dmg)
        {
            return Damage.instance.DegatsPhysiquesReduits(atk, def, dmg);
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
        #endregion

        protected abstract void AppliquerPoison(Mobile atk, Mobile def);

        #region Coup Critique
        public bool Critique(Mobile atk)
        {
            return atk.CheckSkill(SkillName.CoupCritique, CritiqueChance(atk));
        }

        public virtual double CritiqueChance(Mobile atk)
        {
            double chance = GetBonus(atk.Skills[SkillName.CoupCritique].Value, 0.2, 5);
            return chance;
        }

        public virtual double CritiqueDegats(Mobile atk, double dmg)
        {
            // Tentative de dégâts % constants.
            return IncreasedValue(dmg, 0.35);
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

            //Le délai minimal est de 1 secondes entre deux attaques.
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
            if (def.Mana <= 5)
                return false;

            double chance = ParerChance(def);
            
            // On donne la possibilite d'augmenter Parer seulement s'il y a chance de parer
            // Cela exclue donc a mains nues ou a distance
            if (chance > 0 || (def.FindItemOnLayer(Layer.TwoHanded) as BaseShield) != null)
                return def.CheckSkill(SkillName.Parer, ParerChance(def));
            return false;
        }

        protected abstract double ParerChance(Mobile def);
        #endregion

        protected CombatStrategy DefStrategy(Mobile def)
        {
            return (def.Weapon as BaseWeapon).Strategy;
        }

        protected BaseWeapon Weapon(Mobile m)
        {
            return m.Weapon as BaseWeapon;
        }

        // Test passif pour un gain de skill
        protected void CheckSkillGain(Mobile m, SkillName skill)
        {
            m.CheckSkill(skill, 0.0, m.Skills[skill].Cap);
        }
    }
}
