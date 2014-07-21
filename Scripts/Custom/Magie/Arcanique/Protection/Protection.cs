using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class ProtectSpell : Spell
	{
        public static Hashtable m_Timers = new Hashtable();
        public static Hashtable m_Values = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Protection", "Uus Sanct",
				SpellCircle.Second,
				236,
				9011,
				Reagent.Garlic,
				Reagent.Ginseng,
				Reagent.SulfurousAsh
            );

        public ProtectSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

        public static void ToogleProtection(Spell spell, Mobile Caster, Mobile m)
        {
            if (m != null && !m.Deleted)
            {
                StopTimer(m);

                TimeSpan duration = spell.GetDurationForSpell(1);

                double value = (int)(Caster.Skills[SkillName.ArtMagique].Value + Caster.Skills[SkillName.Restoration].Value);
                value /= 15;

                value = SpellHelper.AdjustValue(Caster, value);

                m.VirtualArmorMod += (int)value;
                m.UpdateResistances();

                Timer t = new InternalTimer(m, (int)value, duration);
                m_Timers[m] = t;
                t.Start();

                m_Values[m] = (int)value;

                m.FixedParticles(0x375A, 9, 20, 5016, EffectLayer.Waist);
                m.PlaySound(0x1ED);
            }
        }

        public static void StopTimer(Mobile m)
        {
            Timer t = (Timer)m_Timers[m];

            if (t != null)
            {
                t.Stop();
                m_Timers.Remove(m);

                if (m_Values.Contains(m))
                {
                    m.VirtualArmorMod -= (int)m_Values[m];

                    if (m.VirtualArmorMod < 0)
                        m.VirtualArmorMod = 0;

                    m.UpdateResistances();
                }
            }
        }

        private class InternalTimer : Timer
        {
            private Mobile m_Owner;
            private int m_Value;

            public InternalTimer(Mobile caster, int value, TimeSpan duree) : base(duree)
            {
                Priority = TimerPriority.TwoFiftyMS;

                m_Owner = caster;
                m_Value = value;
            }

            protected override void OnTick()
            {
                m_Owner.VirtualArmorMod -= m_Value;

                if (m_Owner.VirtualArmorMod < 0)
                    m_Owner.VirtualArmorMod = 0;

                m_Owner.UpdateResistances();

                m_Timers.Remove(m_Owner);
                m_Values.Remove(m_Owner);
            }
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckBSequence(m))
            {
                ToogleProtection(this, Caster, m);
            }

            FinishSequence();
        }

        private class InternalTarget : Target
        {
            private ProtectSpell m_Owner;

            public InternalTarget(ProtectSpell owner)
                : base(12, true, TargetFlags.Beneficial)
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
	}
}
