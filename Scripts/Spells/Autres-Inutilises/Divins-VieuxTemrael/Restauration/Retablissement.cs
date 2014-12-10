using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class RetablissementSpell : ReligiousSpell
	{
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_Timers = new Hashtable();

		public static readonly new SpellInfo Info = new SpellInfo(
                "Rétablissement", "Tyr Otil",
				1,
				212,
				9041
            );

        public RetablissementSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return false; } }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckSequence())
            {
                StopTimer(m);

                SpellHelper.Turn(Caster, m);

                int count = 1 + (int)(Caster.Skills[CastSkill].Value / 30 + Caster.Skills[DamageSkill].Value / 30);

                TimeSpan interval = TimeSpan.FromSeconds(16);

                Timer t = new RetablissementTimer(this, Caster, m, count, interval);
                m_Timers[m] = t;
                t.Start();

                m.FixedParticles(14170, 9, 32, 5005, EffectLayer.Waist);
                m.PlaySound(532);
            }

            FinishSequence();
        }

        public void StopTimer(Mobile m)
        {
            Timer t = (Timer)m_Timers[m];

            if (t != null)
            {
                t.Stop();
                m_Timers.Remove(m);

                m.FixedParticles(14170, 9, 32, 5005, EffectLayer.Waist);
                m.PlaySound(532);
            }
        }

        public void Heal(Mobile caster, Mobile m)
        {
            double toHeal;

            toHeal = Caster.Skills[SkillName.ArtMagique].Value / 5;
            //toHeal += Caster.Skills[SkillName.EvalInt].Value / 10;
            toHeal += Utility.Random(1, 3);

            toHeal = SpellHelper.AdjustValue(Caster, toHeal);

            SpellHelper.Heal(m, (int)toHeal, true);

            m.FixedParticles(0x376A, 9, 32, 5005, EffectLayer.Waist);
            m.PlaySound(0x1F2);
        }

        public class RetablissementTimer : Timer
        {
            private Mobile m_caster;
            private Mobile m_target;
            private int m_TotalCount;
            private int m_Count;
            private RetablissementSpell m_Spell;

            public RetablissementTimer(RetablissementSpell spell, Mobile caster, Mobile target, int count, TimeSpan interval)
                : base(TimeSpan.Zero, interval)
            {
                m_caster = caster;
                m_target = target;
                m_TotalCount = count;
                m_Count = 0;
                m_Spell = spell;
            }

            protected override void OnTick()
            {
                if (m_caster == null || m_target == null || m_Count > m_TotalCount || m_target.Deleted || !m_target.Alive)
                {
                    RetablissementSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14170, 9, 32, 5005, EffectLayer.Waist);
                    m_target.PlaySound(532);

                    Stop();
                    return;
                }
                else if (m_Spell != null)
                {
                    m_Spell.Heal(m_caster, m_target);
                    m_Count++;
                }
            }
        }

		private class InternalTarget : Target
		{
            private RetablissementSpell m_Owner;

            public InternalTarget(RetablissementSpell owner)
                : base(12, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
				{
					m_Owner.Target( (Mobile)o );
				}
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}