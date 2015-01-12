using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Items;
using Server.Engines.Combat;

namespace Server.Engines.Alchimie
{
    public class PotionEffectHandler
    {
        private Hashtable AffectedMobiles; // <Mobile,List<PotionInfo>>

        #region Singleton
        private static readonly PotionEffectHandler instance = new PotionEffectHandler();

        private PotionEffectHandler() 
        {
            AffectedMobiles = new Hashtable();
        }

        public static PotionEffectHandler Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Ajout / Retrait d'un effet.

        public void ApplyEffect(Mobile trg, PotionEffect effect, Source s)
        {
            if (!AffectedMobiles.ContainsKey(trg))
            {
                AffectedMobiles.Add(trg, new List<PotionInfo>());
            }

            List<PotionInfo> list = (List<PotionInfo>)AffectedMobiles[trg];
            double stacks = ApplyRate(effect.Stacks, s);

            PotionInfo p = null;
            foreach (PotionInfo potionInfo in list)
            {
                if (potionInfo.effect.GetType() == effect.GetType())
                {
                    p = potionInfo;
                    break;
                }
            }

            if (p == null)
            {
                p = new PotionInfo(trg, effect);
                list.Add(p);
            }

            if (p.stacks + stacks > effect.MaxStacks)
            {
                p.stacks = effect.MaxStacks;
            }
            else
            {
                p.stacks += stacks;
            }

            if (!p.timer.Running)
                p.timer.Start();
        }

        public void CureEffect(Mobile trg, double stacks)
        {
            if (!AffectedMobiles.ContainsKey(trg))
                return;

            List<PotionInfo> list = (List<PotionInfo>)AffectedMobiles[trg];

            foreach (PotionInfo potionInfo in list)
            {
                if(stacks <= 0)
                    break;

                stacks -= Retirer(ref potionInfo.stacks, stacks);
            }
        }

        // Taux dépendant de la méthode d'application
        double ApplyRate(double value, Source t)
        {
            switch (t)
            {
                case Source.Weapon: return value * 0.2;
                case Source.Food: return value * 0.8;
                case Source.Beverage: return value * 0.8;
                case Source.Potion: return value * 1;
            }
            return 0;
        }

        /// <summary>
        /// Soustrait le amount qu'il est possible d'enlever tout en restant > 0, et retourne combien a été enlevé au value.
        /// </summary>
        /// <param name="value">Le chiffre duquel on veut soustraire.</param>
        /// <param name="amount">Le nombre que l'on veut soustraire.</param>
        /// <returns>Le nombre qui a reussit a être soustrait.</returns>
        double Retirer(ref double value, double amount)
        {
            if (value - amount >= 0)
            {
                value -= amount;
                return amount;
            }
            else
            {
                amount = value;
                value = 0;
                return amount;
            }
        }
        #endregion

        #region Pour aider au balancement...

        public void GetEffectDuration( PotionEffect effect )
        {
            int i = effect.Stacks;
            double filter = effect.FilterPerTick;

            Console.WriteLine("DEBUG : L'effet de la potion dure " +  NextX(i, 0, filter) + " secondes/tick de timer.");
        }
        private int NextX(double value, int counter, double filter)
        {
            ++counter;
            value = value * filter;

            if (value < 1)
            {
                return counter;
            }
            else
            {
                return NextX(value, counter, filter);
            }
        }

        #endregion

        private class PotionInfo
        {
            public Mobile target;
            public double stacks;
            public PotionEffect effect;
            public PotionTimer timer;

            public PotionInfo(Mobile trg, PotionEffect eff)
            {
                target = trg;
                stacks = 0;
                effect = eff;
                timer = new PotionTimer(eff, this);
            }
        }

        private class PotionTimer : Timer
        {
            private PotionEffect m_effect;
            private PotionInfo m_info;

            public PotionTimer(PotionEffect effect, PotionInfo info)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(1))
            {
                m_effect = effect;
                m_info = info;
            }

            protected override void OnTick()
            {
                if (m_info.stacks > 1)
                {
                    m_effect.Effect(m_info.target, m_info.stacks);

                    m_info.stacks *= (1 - m_effect.FilterPerTick);
                }
                else
                {
                    m_effect.RemoveEffect(m_info.target);
                    Stop(); // S'arrête, et se réactive lorsque l'on rajoute des stacks, dans "ApplyEffect".
                }
            }
        }
    }

    public enum Source
    {
        Weapon,
        Food,
        Beverage,
        Potion
    }
}
