using System;
using System.Collections;
using Server.Mobiles;
using Server.Items;
using Server;
using Server.Engines.Combat;

namespace Server.TechniquesCombat
{
    public sealed class Assassinat
    {
        #region Singleton
        private static readonly Assassinat instance = new Assassinat();

        private Assassinat() { }

        public static Assassinat Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        private Hashtable MobilesList = new Hashtable(); // Attacker -- Defender
        private Hashtable MobilesBonus = new Hashtable(); // Attacker -- % de scaling.

        private const double TrackingOffs = 0.3; // Le total doit être de 1.
        private const double HiddenOffs = 0.7;   //

        private const double DetectedDiv = 2;

        private const double MalusStam = 0.75;  // Le defenseur peut perdre jusqu'à 75% de sa stamina au premier hit.
        private const double BonusDegats = 0.4; // 0 à 40% de degats bonus contre la cible.

        private const double MeleeScal = 1;
        private const double RangedScal = 0.4;
        private const double MonsterScal = 0.3;

        private readonly TimeSpan Cooldown = new TimeSpan(0, 2, 0);


        public void OnHit(Mobile atk, Mobile def, ref double dmg)
        {
            if (!MobilesBonus.Contains(atk))
            {
                if (!MobilesList.Contains(atk))  // First hit.
                {
                    double scaling = ScalingBonus(atk, def) * TypeMultiplier(atk,def);

                    if (scaling != 0)
                    {
                        atk.SendMessage("Vous prenez " + def.GetNameUsedBy(atk) + " en chasse !");
                        def.SendMessage("On vous prend en chasse !");

                        def.Stam -= (int)(def.Stam * (scaling * MalusStam));

                        new CooldownTimer(atk, def, scaling, Cooldown);
                    }
                }
            }
            
            if(MobilesBonus.Contains(atk))
            {
                if (MobilesList[atk] == def) // Following hits.
                {
                    dmg *= 1 + ((double)MobilesBonus[atk] * BonusDegats);
                }
            }
        }

        private double ScalingBonus(Mobile atk, Mobile def)
        {
            double scaling = 0;

            if (SkillHandlers.Tracking.IsTracking(atk, def) || atk is BaseCreature)
            {
                scaling += (TrackingOffs * atk.Skills[SkillName.Poursuite].Value / 100);
            }

            if (atk.Hidden)
            {
                scaling += HiddenOffs;

                if (def.CanSee(atk))
                {
                    scaling /= DetectedDiv;
                }
            }

            return scaling;
        }

        private double TypeMultiplier(Mobile atk, Mobile def)
        {
            CombatStrategy strategy = ((BaseWeapon)atk.Weapon).Strategy;
            if (strategy is StrategyMonstre)
            {
                return MonsterScal;
            }
            else if (strategy is StrategyDistance)
            {
                if (atk.InRange(def, 5))
                {
                    return RangedScal;
                }
                else
                {
                    return 0; // Rend l'attaque non-surnoise.
                }
            }
            else
            {
                return MeleeScal;
            }
        }

        private class CooldownTimer : Timer
        {
            Mobile m_atk, m_def;

            public CooldownTimer(Mobile atk, Mobile def, double scaling, TimeSpan duration)
                : base(duration)
            {
                m_atk = atk;
                m_def = def;
                Assassinat.instance.MobilesList.Add(atk, def);
                Assassinat.instance.MobilesBonus.Add(atk, scaling);
                Start();
            }

            protected override void OnTick()
            {
                Assassinat.instance.MobilesList.Remove(m_atk);
                Assassinat.instance.MobilesBonus.Remove(m_atk);
            }
        }
    }
}