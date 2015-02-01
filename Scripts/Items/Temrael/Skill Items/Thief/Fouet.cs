using System;
using Server.Network;
using Server.Targeting;
using Server.Items;
using Server.Mobiles;
using System.Collections;
using Server.Engines.Craft;
using System.Collections.Generic;
using Server.Engines.Combat;

namespace Server.Items
{
    public abstract class BaseFouet : BaseWearable
    {
        protected const int Range = 7;
        protected const double WaitTime = 10.0;                               //Wait time on individual target (seconds)
        protected const double CooldownTime = 5.0;                            //Cooldown time between each use (seconds)
        protected static HashSet<Mobile> MobilesList = new HashSet<Mobile>(); //Immuned mobiles
        protected DateTime NextUse;                                           //Next time the whipe is usable

        protected const double StealingScaling = 0.30;                        //Scaling off stealing 
        protected const double StealingBonus = 30.0;                          //Bonus if stealing is at 100
        protected const double SnoopingScaling = 0.20;                        //Scaling off snooping
        protected const double SnoopingBonus = 20.0;                          //Bonus if snooping is at 100

        public enum Sounds
        {
            Miss = 0x234 + 1,           //User misses the target
            SuccessDrop = 0x146 + 2,    //User successfully drop the target's weapon
            SuccessSteal = 0x534 + 3,   //User successfully steals the target's weapon
            Whip = 0x146 + 4            //User whips an unarmed target
        }

        public BaseFouet(int id)
            : base(id)
        {
            NextUse = DateTime.MinValue;
        }

        public BaseFouet(Serial serial) 
            : base(serial)
        { 
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
        
        public override void OnDoubleClick(Mobile from)
        {
            if (DateTime.Now < NextUse)
                from.SendMessage("Vous ne pouvez pas utiliser le fouet maintenant.");
            else if (from.Dex < 65)
                from.SendMessage("Vous n'êtes pas assez à l'aise pour utiliser le fouet.");
            else
                from.Target = new InternalTarget(this, Range);
        }

        public void Target(Mobile atk, Mobile target)
        {
            if (!atk.CanSee(target))
            {
                atk.SendLocalizedMessage(500237); //Target can not be seen.
            }
            else if (MobilesList.Contains(target))
            {
                DoAnimation(atk, target, Sounds.Miss);
            }
            else
                DoEffect(atk, target);
        }

        public void DoEffect(Mobile atk, Mobile def)
        {
            double chances = GetChances(atk, def);
            NextUse = DateTime.Now.AddSeconds(CooldownTime);
            Item weapon = Weapon(def);

            if (weapon.Layer == Layer.TwoHanded) //Target has a two-handed weapon
            {
                chances = chances / 1.5;

                if (chances >= Utility.RandomDouble())
                {
                    if (chances / 1.5 >= Utility.RandomDouble() && !atk.Mounted) //Weapon is stolen
                    {
                        atk.AddToBackpack(weapon);
                        DoAnimation(atk, def, Sounds.SuccessSteal);
                    }
                    else                                         //Weapon drops on ground
                    {
                        weapon.MoveToWorld(weapon.GetWorldLocation(), weapon.Map);
                        DoAnimation(atk, def, Sounds.SuccessDrop);
                    }
                }
                else
                {
                    DoAnimation(atk, def, Sounds.Miss);
                }

                new WaitTimer(def, TimeSpan.FromSeconds(WaitTime)).Start();
            }
            else if (weapon.Layer == Layer.OneHanded) //Target has a one-handed weapon
            {
                if (def.FindItemOnLayer(Layer.TwoHanded) as BaseShield != null)
                    chances = chances - def.Skills[SkillName.Parer].Value * 0.001;

                if (chances >= Utility.RandomDouble())
                {
                    if (chances / 1.5 >= Utility.RandomDouble() && !atk.Mounted) //Weapon is stolen 
                    {
                        atk.AddToBackpack(weapon);
                        DoAnimation(atk, def, Sounds.SuccessSteal);
                    }
                    else                                         //Weapon drops on ground
                    {
                        weapon.MoveToWorld(weapon.GetWorldLocation(), weapon.Map);
                        DoAnimation(atk, def, Sounds.SuccessDrop);
                    }
                }
                else
                {
                    DoAnimation(atk, def, Sounds.Miss);
                }
                new WaitTimer(def, TimeSpan.FromSeconds(WaitTime)).Start();
            }
            else
            {
                DoAnimation(atk, def, Sounds.Whip);
            }
            atk.RevealingAction();
            def.RevealingAction();
            atk.DisruptiveAction();
            def.DisruptiveAction();
            CombatStrategy.GetStrategy(atk).ResetAttackAfterCast(atk);
            CombatStrategy.GetStrategy(def).ResetAttackAfterCast(def);
        }

        public double GetChances(Mobile atk, Mobile def)
        {
            double chances = 0;

            chances += atk.Skills[SkillName.Vol].Value * StealingScaling;
            if (atk.Skills[SkillName.Vol].Value == 100)
                chances += StealingBonus;
            chances += atk.Skills[SkillName.Fouille].Value * SnoopingScaling;
            if (atk.Skills[SkillName.Fouille].Value == 100)
                chances += SnoopingBonus;

            return (chances / 100) - 0.003 * def.Skills[(CombatStrategy.GetStrategy(def).ToucherSkill)].Value;
        }

        public void DoAnimation(Mobile from, Mobile target, Sounds sound)
        {
            switch (sound)
            {
                case Sounds.Miss:
                    {
                        from.Animate(9, 7, 1, true, false, 0);
                        from.PlaySound(((int)Sounds.Miss - 1));
                        target.SendMessage("Un coup de fouet vous frôle de près!");
                        target.PlaySound(((int)Sounds.Miss - 1));
                        break;
                    }
                case Sounds.SuccessDrop: 
                    {
                        from.Animate(9, 7, 1, true, false, 0);
                        from.PlaySound(((int)Sounds.Miss - 1));
                        target.SendMessage("Vous recevez un coup de fouet et échappez votre arme!");
                        target.Animate(20, 5, 1, true, false, 0);
                        target.PlaySound(((int)Sounds.SuccessDrop - 2));
                        break;
                    }
                case Sounds.SuccessSteal:
                    {
                        from.Animate(9, 7, 1, true, false, 0);
                        from.PlaySound(((int)Sounds.Miss - 1));
                        target.SendMessage("Vous recevez un coup de fouet et votre arme vous glisse des mains!");
                        target.Animate(20, 5, 1, true, false, 0);
                        target.PlaySound(((int)Sounds.SuccessSteal - 3));
                        break;
                    }
                case Sounds.Whip:
                    {
                        from.Animate(9, 7, 1, true, false, 0);
                        from.PlaySound(((int)Sounds.Miss - 1));
                        target.SendMessage("Vous recevez un coup de fouet!");
                        target.Animate(20, 5, 1, true, false, 0);
                        target.PlaySound(((int)Sounds.Whip - 4));
                        break;
                    }
            }
        }

        public static BaseWeapon Weapon(Mobile m)
        {
            return m.Weapon as BaseWeapon;
        }

        private class InternalTarget : Target
        {
            private BaseFouet m_Owner;

            public InternalTarget(BaseFouet owner, int range)
                : base(range, false, TargetFlags.Harmful)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile)
                {
                    m_Owner.Target(from, (Mobile)o);
                }
            }

            protected override void OnTargetFinish(Mobile from)
            {
            }
        }

        private class WaitTimer : Timer
        {
            private Mobile m_Target;
            private DateTime m_End;

            public WaitTimer(Mobile target, TimeSpan delay)
                : base(TimeSpan.FromSeconds(1.0), TimeSpan.FromSeconds(1.0))
            {
                m_Target = target;
                m_End = DateTime.Now + delay;
                MobilesList.Add(target);
                Priority = TimerPriority.TwoFiftyMS;
            }

            protected override void OnTick()
            {
                if (m_Target.Deleted || !m_Target.Alive || DateTime.Now >= m_End)
                {
                    MobilesList.Remove(m_Target);
                    Stop();
                }
            }
        }
    }

    public class FouetCuir : BaseFouet
    {
        [Constructable]
        public FouetCuir()
            : base(0x166E)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Fouet en cuir";
        }

        public FouetCuir(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
