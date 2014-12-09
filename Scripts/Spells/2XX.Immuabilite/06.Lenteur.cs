using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Spells
{
    class LenteurSpell : Spell
    {
        public static int m_SpellID { get { return 206; } }

        public readonly static Hashtable m_Table = new Hashtable();

        private static short s_Cercle = 5;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Lenteur", "Mas Nuuh",
                s_Cercle,
				209,
				9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(4),
                SkillName.Immuabilite,
				Reagent.BlackPearl,
				Reagent.SpidersSilk
            );

        public LenteurSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
		{
		}

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public void Target(Mobile m)
        {
            if (CheckHSequence(m))
            {
                SpellHelper.Turn(Caster, m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                m.PlaySound(0x1F1);
                m.FixedParticles(0x3789, 1, 20, 9911, 0, 5, EffectLayer.Head);

                int baseDuration = 20;

                TimeSpan duration = TimeSpan.FromSeconds(baseDuration * Spell.GetSpellScaling(Caster, Info.skillForCasting));
                int PourcentRate = 30;

                if (!m_Table.Contains(m))
                {
                    m_Table.Add(m, PourcentRate);
                    new LenteurTimer(m, duration).Start();
                }
                else
                    Caster.SendMessage("Ce personnage est déjà affecté par ce sort.");
            }

            FinishSequence();
        }

        public static void RemoveBonus(Mobile m)
        {
            if (m_Table.Contains(m))
                m_Table.Remove(m);
        }

        public static void GetOnHitEffect(Mobile atk, ref int attackSpeed)
        {
            if (m_Table.Contains(atk))
            {
                attackSpeed = (attackSpeed * 140) / 100;
            }
        }

        private class InternalTarget : Target
        {
            private LenteurSpell m_Owner;

            public InternalTarget(LenteurSpell owner)
                : base(12, false, TargetFlags.Harmful)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile)
                    m_Owner.Target((Mobile)o);
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }

        private class LenteurTimer : Timer
        {
            private Mobile m_Mobile;

            public LenteurTimer(Mobile m, TimeSpan duration)
                : base(duration)
            {
                Priority = TimerPriority.TwentyFiveMS;
                m_Mobile = m;
            }

            protected override void OnTick()
            {
                LenteurSpell.RemoveBonus(m_Mobile);
            }
        }
    }
}
