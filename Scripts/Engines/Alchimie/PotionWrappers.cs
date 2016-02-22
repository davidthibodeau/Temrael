using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Mobiles;
using Server.Engines.Alchimie;
using Server.Network;
using Server.Items;

namespace Server.Engines.Alchimie
{
    public abstract class PotionWrapper
    {
        private PotionImpl m_PotImpl;

        public PotionImpl PotImpl
        {
            get { return m_PotImpl; }
        }

        protected virtual bool MakeStackable { get { return false; } }
        protected abstract double PourcentEffect { get; }

        protected void DoAllEffects(ScriptMobile target, double strength)
        {
            if (m_PotImpl != null)
                m_PotImpl.DoAllEffects(target, PourcentEffect * strength);
        }

        public PotionWrapper(Potion potion) : this(potion.Pot)
        {
            potion.Consume();
            CheckStackable();
        }
        public PotionWrapper(PotionWrapper wrapper) : this(wrapper.m_PotImpl)
        {
            wrapper.m_PotImpl = null;
            CheckStackable();
        }
        protected PotionWrapper(PotionImpl potimpl)
        {
            m_PotImpl = potimpl;
            CheckStackable();
        }
        protected PotionWrapper()
        {
            m_PotImpl = null;
            CheckStackable();
        }
        private void CheckStackable()
        {
            if (m_PotImpl !=null)
            {
                foreach (BasePotionEffect effect in m_PotImpl.EffectsList)
                {
                    effect.m_Stackable = MakeStackable;
                }
            }
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write(m_PotImpl != null);
            if (m_PotImpl != null)
                m_PotImpl.Serialize(writer);
        }

    }

    public class WeaponPotion : PotionWrapper
    {
        protected override bool MakeStackable
        {
            get { return true; } 
        }

        protected override double PourcentEffect
        {
            get { return 0.2; }
        }

        public void OnWeaponHit(ScriptMobile target)
        {
            DoAllEffects(target, 1);
        }

        public WeaponPotion(Potion potion) : base(potion){}
        public WeaponPotion(PotionWrapper wrapper) : base(wrapper){}
        protected WeaponPotion(PotionImpl potimpl) : base(potimpl){}
        public WeaponPotion() : base(){}

        static public WeaponPotion Deserialize(GenericReader reader)
        {
            if (reader.ReadBool())
                return new WeaponPotion(PotionImpl.Deserialize(reader));
            else
                return new WeaponPotion();
        }
    }

    public class FoodPotion : PotionWrapper
    {
        protected override double PourcentEffect
        {
            get { return 0.7; }
        }

        public void OnEat(ScriptMobile eater)
        {
            DoAllEffects(eater, 1);
        }

        public FoodPotion(Potion potion) : base(potion){}
        public FoodPotion(PotionWrapper wrapper) : base(wrapper){}
        protected FoodPotion(PotionImpl potimpl) : base(potimpl){}
        public FoodPotion() : base() { }

        static public FoodPotion Deserialize(GenericReader reader)
        {
            if (reader.ReadBool())
                return new FoodPotion(PotionImpl.Deserialize(reader));
            else
                return new FoodPotion();
        }
    }

    public class BeveragePotion : PotionWrapper
    {
        protected override double PourcentEffect
        {
            get { return 0.7; }
        }

        public void OnDrink(ScriptMobile drinker, BaseBeverage parent)
        {
            DoAllEffects(drinker, 1.0 / (double)parent.MaxQuantity);
        }

        public BeveragePotion(Potion potion) : base(potion){}
        public BeveragePotion(PotionWrapper wrapper) : base(wrapper){}
        protected BeveragePotion(PotionImpl potimpl) : base(potimpl){}
        public BeveragePotion() : base(){}

        static public BeveragePotion Deserialize(GenericReader reader)
        {
            if (reader.ReadBool())
                return new BeveragePotion(PotionImpl.Deserialize(reader));
            else
                return new BeveragePotion();
        }
    }

    public class Potion : Item
    {
        private PotionImpl m_pot;
        private bool m_Identified;

        public PotionImpl Pot
        {
            get { return m_pot; }
        }
        public bool Identified
        {
            get { return m_Identified; }
            set { m_Identified = value; InvalidateProperties(); }
        }

        // This devient la potion modifiée. Le paramètre est "détruit".
        public void Mix(Potion potion)
        {
            m_pot.Mix(potion.m_pot);

            Effects.PlaySound(this, this.Map, 0x4E);
            potion.Consume();
            InvalidateProperties();
        }

        public void AddEffect(BasePotionEffect effect)
        {
            m_pot.AddEffect(effect);
            InvalidateProperties();
        }


        public override void OnDoubleClick(Mobile from)
        {
            if (from.Map != Map || !from.InRange(GetWorldLocation(), 2) || !from.InLOS(this))
            {
                from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1019045); // I can't reach that.
                return;
            }

            m_pot.DoAllEffects((ScriptMobile)from, 1);

            from.PlaySound(Utility.RandomList(0x30, 0x2D6));
            Consume();
            from.AddToBackpack(new Bottle());
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            if (Identified)
            {
                list.Add(Name);

                string str = "";

                str += "Puissance : " + (int)(m_pot.PotionStrength * 100);

                if (m_pot.EffectsList.Count > 0)
                {
                    foreach (BasePotionEffect effect in m_pot.EffectsList)
                    {
                        str += '\n' + effect.GetPotionInfo();
                    }
                }

                if (m_pot.SynergyList.Count > 0)
                {
                    foreach (BaseSynergy synergy in m_pot.SynergyList)
                    {
                        str += '\n' + synergy.GetPotionInfo();
                    }
                }

                list.Add(str);
            }
            else
            {
                list.Add("Potion");
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
            writer.Write(m_Identified);

            m_pot.Serialize(writer);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_Identified = reader.ReadBool();

            m_pot = PotionImpl.Deserialize(reader);
        }

        #region Ctors
        public Potion(Potion pot)
        {
            Name = pot.Name;
            m_Identified = pot.m_Identified;
            m_pot = new PotionImpl(pot.m_pot);
        }

        public Potion(PotionImpl pot)
            : this()
        {
            m_pot = pot;
        }

        private Potion()
            : base(0xF0A)
        {
            Name = "Potion";
            m_Identified = false;
        }

        public Potion(Serial serial)
            : base(serial)
        {
        }
        #endregion
    }
}