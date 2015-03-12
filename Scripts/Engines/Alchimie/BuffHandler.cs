using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Items;
using Server.Engines.Combat;

namespace Server.Engines.Buffs
{
    public class BuffHandler
    {
        private Hashtable AffectedMobiles; // <Mobile,List<BaseBuff>>

        #region Singleton
        private static readonly BuffHandler instance = new BuffHandler();

        private BuffHandler() 
        {
            AffectedMobiles = new Hashtable();
        }

        public static BuffHandler Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Ajout / Retrait d'un effet.

        public void ApplyEffect(Mobile trg, BaseBuff effect, Source s)
        {
            if (!AffectedMobiles.ContainsKey(trg))
            {
                AffectedMobiles.Add(trg, new List<BuffInfo>());
            }

            List<BuffInfo> list = (List<BuffInfo>)AffectedMobiles[trg];

            BuffInfo b = null;
            foreach (BuffInfo buffInfo in list)
            {
                if (buffInfo.effect.GetType() == effect.GetType())
                {
                    b = buffInfo;
                    break;
                }
            }

            if (b == null)
            {
                b = new BuffInfo(trg, effect);
                list.Add(b);
            }

            if (effect is Poison)
            {
                Poison pot = (Poison)effect;

                double stacks = ApplyRate(pot.Stacks, s);

                if (b.stacks + stacks > pot.MaxStacks)
                {
                    b.stacks = pot.MaxStacks;
                }
                else
                {
                    b.stacks += stacks;
                }
            }
            else if (effect is Buff)
            {
                Buff buff = (Buff)effect;

                ((BuffTimer)b.timer).Restart();
            }

            if (!b.timer.Running)
                b.timer.Start();
        }

        public void CureEffect(Mobile trg, double stacks)
        {
            if (!AffectedMobiles.ContainsKey(trg))
                return;

            List<BuffInfo> list = (List<BuffInfo>)AffectedMobiles[trg];

            foreach (BuffInfo buffInfo in list)
            {
                if(stacks <= 0)
                    break;

                stacks -= Retirer(ref buffInfo.stacks, stacks);
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
                case Source.None: return value * 1;
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

        public void GetEffectDuration(BaseBuff effect)
        {
            if (effect is Poison)
            {
                Poison pot = (Poison)effect;

                int i = pot.Stacks;
                double filter = pot.FilterPerTick;

                Console.WriteLine("DEBUG : L'effet de la potion dure " + NextX(i, 0, filter) + " secondes.");
            }
            else if (effect is Buff)
            {
                Buff buff = (Buff)effect;
                Console.WriteLine("DEBUG : L'effet de la potion dure " + buff.duree + " secondes.");
            }
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

        private class BuffInfo
        {
            public Mobile target;
            public double stacks;
            public BaseBuff effect;
            public Timer timer;

            public BuffInfo(Mobile trg, BaseBuff eff)
            {
                target = trg;
                stacks = 0;
                effect = eff;

                if (eff is Poison)
                {
                    timer = new PoisonTimer((Poison)eff, this);
                }
                else if (eff is Buff)
                {
                    timer = new BuffTimer((Buff)eff, this);
                }
            }
        }

        private class PoisonTimer : Timer
        {
            private Poison m_effect;
            private BuffInfo m_info;

            public PoisonTimer(Poison effect, BuffInfo info)
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

        private class BuffTimer : Timer
        {
            private Buff m_effect;
            private BuffInfo m_info;
            private DateTime m_End;

            public BuffTimer(Buff effect, BuffInfo info)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(1))
            {
                m_effect = effect;
                m_info = info;
                Start();
            }

            protected override void OnTick()
            {
                if (DateTime.Now < m_End)
                {
                    m_effect.Effect(m_info.target);
                }
                else
                {
                    m_effect.RemoveEffect(m_info.target);
                    Stop(); // S'arrête, et se réactive lorsque l'on rajoute des stacks, dans "ApplyEffect".
                }
            }

            public void Restart()
            {
                m_End = DateTime.Now + m_effect.duree;
                Start();
            }
        }
    }

    public enum Source
    {
        Weapon,
        Food,
        Beverage,
        Potion,
        None
    }
}
