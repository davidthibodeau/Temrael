using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Items;
using Server.Engines.Combat;
using Server.Mobiles;

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

        public void ApplyBuff(Mobile trg, Buff newbuff)
        {
            if (!AffectedMobiles.ContainsKey(trg))
            {
                AffectedMobiles.Add(trg, new List<BuffInfo>());
            }

            // Reflection, pour connaitre le typeof de la classe qui appelle cette fonction.
            // Cela fait en sorte que un "Buff" d'un type X est alloué par classe, par joueur.
            // Cela fait donc en sorte qu'un joueur ne peut pas stacker le spell "Buff de force" plusieurs fois, 
            // mais peut stacker un spell avec un potion, par exemple.
            StackFrame frame = new StackFrame(1);
            Type callertype = (frame.GetMethod()).DeclaringType;

            List<BuffInfo> list = (List<BuffInfo>)AffectedMobiles[trg];

            // On trouve voir si un buff de ce type et de la même provenance existe deja sur le mobile.
            BuffInfo b = null;
            foreach (BuffInfo buffInfo in list)
            {
                if (buffInfo.effect.GetType() == newbuff.GetType())
                {
                    if (buffInfo.callingclass == callertype)
                    {
                        b = buffInfo;
                        break;
                    }
                }
            }

            if (b == null)
            {
                b = new BuffInfo(trg, newbuff, callertype);
                list.Add(b);
            }
            else // if(b.effect is Buff) // non nécessaire, fait plus tôt.
            {
                Buff buff = (Buff)b.effect;

                if (buff.CompareNewEntry(newbuff))
                {
                    ((BuffTimer)b.timer).Restart();
                }
            }

            if (!b.timer.Running)
                b.timer.Start();
        }

        public void ApplyPoison(Mobile trg, Poison poison, Source s)
        {
            if (!AffectedMobiles.ContainsKey(trg))
            {
                AffectedMobiles.Add(trg, new List<BuffInfo>());
            }

            List<BuffInfo> list = (List<BuffInfo>)AffectedMobiles[trg];

            // On trouve voir si un buff de ce type et de la même provenance existe deja sur le mobile.
            BuffInfo b = null;
            foreach (BuffInfo buffInfo in list)
            {
                if (buffInfo.effect.GetType() == poison.GetType())
                {
                    b = buffInfo;
                    break;
                }
            }

            if (b == null)
            {
                b = new BuffInfo(trg, poison);
                list.Add(b);
            }
            else // if (b.effect is Poison)
            {
                double stacks = ApplyRate(poison.Stacks, s);

                if (b.stacks + stacks > poison.MaxStacks)
                {
                    b.stacks = poison.MaxStacks;
                }
                else
                {
                    b.stacks += stacks;
                }
            }

            if (!b.timer.Running)
                b.timer.Start();
        }

        public void CurePoison(Mobile trg, double stacks)
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

        public void RemoveBaseBuff(Mobile trg, BaseBuff buff)
        {
            if (!AffectedMobiles.ContainsKey(trg))
                return;

            List<BuffInfo> list = (List<BuffInfo>)AffectedMobiles[trg];

            // On trouve voir si un buff de ce type et de la même provenance existe deja sur le mobile.
            BuffInfo b = null;
            foreach (BuffInfo buffInfo in list)
            {
                if (buffInfo.effect.GetType() == buff.GetType())
                {
                    b = buffInfo;
                    break;
                }
            }

            list.Remove(b);
        }

        public double GetBuffCumul(Mobile trg, Type buff)
        {
            if (!AffectedMobiles.ContainsKey(trg))
                return 0;

            double cumul = 0;

            List<BuffInfo> list = (List<BuffInfo>)AffectedMobiles[trg];

            foreach( BuffInfo buffinfo in list )
            {
                if (buffinfo.timer.Running)
                {
                    if (buffinfo.effect is Buff)
                    {
                        Buff buffinfobuff = (Buff)buffinfo.effect;

                        if (buff == buffinfo.effect.GetType())
                        {
                            //cumul += buffinfobuff.GetOffset();
                        }
                    }
                }
            }

            return cumul;
        }

        // Taux dépendant de la méthode d'application
        private double ApplyRate(double value, Source t)
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
        private double Retirer(ref double value, double amount)
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
            public Type callingclass;

            public BuffInfo(Mobile trg, BaseBuff eff, Type typeOfCaller)
            {
                target = trg;
                stacks = 0;
                effect = eff;
                callingclass = typeOfCaller;

                if (eff is Poison)
                {
                    timer = new PoisonTimer((Poison)eff, this);
                }
                else if (eff is Buff)
                {
                    timer = new BuffTimer((Buff)eff, this);
                }
            }

            public BuffInfo(Mobile trg, BaseBuff eff)
                : this(trg, eff, null)
            {
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

            public void UpdateStatus()
            {
                if (m_info.target is PlayerMobile)
                {
                    PlayerMobile pm = (PlayerMobile)m_info.target;

                    pm.Delta(MobileDelta.HealthbarPoison);
                    pm.Delta(m_info.effect.mobileDelta);
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
                Restart();
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
                    UpdateStatus();
                    Stop(); // S'arrête, et se réactive lorsque l'on rajoute des stacks, dans "ApplyEffect".
                }
            }

            public void Restart()
            {
                m_End = DateTime.Now + m_effect.duree;
                Start();
                UpdateStatus();
            }

            public void UpdateStatus()
            {
                if (m_info.target is PlayerMobile)
                {
                    PlayerMobile pm = (PlayerMobile)m_info.target;

                    pm.Delta(m_info.effect.mobileDelta);
                }
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
