using System;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
    [CorpseName("Corps de Golem")]
    public class CrystalGolem : BaseCreature
    {
        private bool m_Stunning;

        public override bool IsScaredOfScaryThings { get { return false; } }
        public override bool IsScaryToPets { get { return true; } }

        public override bool IsBondable { get { return false; } }

        public override FoodType FavoriteFood { get { return FoodType.None; } }

        [Constructable]
        public CrystalGolem()
            : this(false, 1.0)
        {
        }

        [Constructable]
        public CrystalGolem(bool summoned, double scalar)
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8)
        {
            Name = "Golem de Crystal";
            Body = 181;

            //if ( summoned )
            //	Hue = 2101;

            SetStr((int)(251 * scalar), (int)(350 * scalar));
            SetDex((int)(76 * scalar), (int)(100 * scalar));
            SetInt((int)(101 * scalar), (int)(150 * scalar));

            SetHits((int)(151 * scalar), (int)(210 * scalar));

            SetDamage((int)(13 * scalar), (int)(24 * scalar));

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, (int)(35 * scalar), (int)(55 * scalar));

            if (summoned)
                SetResistance(ResistanceType.Contondant, (int)(50 * scalar), (int)(60 * scalar));
            else
                SetResistance(ResistanceType.Contondant, (int)(100 * scalar));

            SetResistance(ResistanceType.Tranchant, (int)(10 * scalar), (int)(30 * scalar));
            SetResistance(ResistanceType.Perforant, (int)(10 * scalar), (int)(25 * scalar));
            SetResistance(ResistanceType.Magie, (int)(30 * scalar), (int)(40 * scalar));

            SetSkill(SkillName.Concentration, (150.1 * scalar), (190.0 * scalar));
            SetSkill(SkillName.Tactiques, (60.1 * scalar), (100.0 * scalar));
            SetSkill(SkillName.ArmePoing, (60.1 * scalar), (100.0 * scalar));

            if (summoned)
            {
                Fame = 10;
                Karma = 10;
            }
            else
            {
                Fame = 3500;
                Karma = -3500;
            }

            ControlSlots = 3;
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 4.0; } }

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);
        }

        public override bool DeleteOnRelease { get { return true; } }

        public override int GetAngerSound()
        {
            return 541;
        }

        public override int GetIdleSound()
        {
            if (!Controlled)
                return 542;

            return base.GetIdleSound();
        }

        public override int GetDeathSound()
        {
            if (!Controlled)
                return 545;

            return base.GetDeathSound();
        }

        public override int GetAttackSound()
        {
            return 562;
        }

        public override int GetHurtSound()
        {
            if (Controlled)
                return 320;

            return base.GetHurtSound();
        }

        public override bool AutoDispel { get { return !Controlled; } }
        public override bool BleedImmune { get { return true; } }

        public override void OnGaveMeleeAttack(Mobile defender)
        {
            base.OnGaveMeleeAttack(defender);

            if (!m_Stunning && 0.3 > Utility.RandomDouble())
            {
                m_Stunning = true;

                defender.Animate(21, 6, 1, true, false, 0);
                this.PlaySound(0xEE);
                defender.LocalOverheadMessage(MessageType.Regular, 0x3B2, false, "You have been stunned by a colossal blow!");

                BaseWeapon weapon = this.Weapon as BaseWeapon;
                if (weapon != null)
                    weapon.OnHit(this, defender);

                if (defender.Alive)
                {
                    defender.Frozen = true;
                    Timer.DelayCall(TimeSpan.FromSeconds(5.0), new TimerStateCallback(Recover_Callback), defender);
                }
            }
        }

        private void Recover_Callback(object state)
        {
            Mobile defender = state as Mobile;

            if (defender != null)
            {
                defender.Frozen = false;
                defender.Combatant = null;
                defender.LocalOverheadMessage(MessageType.Regular, 0x3B2, false, "You recover your senses.");
            }

            m_Stunning = false;
        }

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            if (Controlled || Summoned)
            {
                Mobile master = (this.ControlMaster);

                if (master == null)
                    master = this.SummonMaster;

                if (master != null && master.Player && master.Map == this.Map && master.InRange(Location, 20))
                {
                    if (master.Mana >= amount)
                    {
                        master.Mana -= amount;
                    }
                    else
                    {
                        amount -= master.Mana;
                        master.Mana = 0;
                        master.Damage(amount);
                    }
                }
            }

            base.OnDamage(amount, from, willKill);
        }

        public override bool BardImmune { get { return !Core.AOS || Controlled; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }

        public CrystalGolem(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}