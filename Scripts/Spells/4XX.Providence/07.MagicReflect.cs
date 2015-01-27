using System;
using System.Collections;
using Server;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using System.Collections.Generic;

namespace Server.Spells
{
	public class MagicReflectSpell : Spell
	{
        public static int m_SpellID { get { return 407; } } // TOCHANGE

        private static short s_Cercle = 6;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Reflet", "In Jux Sanct",
                s_Cercle,
                203,
                9031,
                20,
                TimeSpan.FromSeconds(3),
                SkillName.Providence,
				Reagent.Garlic,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
            );

		public MagicReflectSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

        private const int maxDmgBlock = 100;
        private const int duration = 30;

        private static Dictionary<Mobile, double> m_Table = new Dictionary<Mobile, double>();

        public static bool InTable(Mobile m)
        {
            return m_Table.ContainsKey(m);
        }

        public static void GetOnHitEffect(Mobile def, ref double damage)
        {
            if (InTable(def) && damage > 1)
            {
                double block = m_Table[def];

                if (block > 0)
                {
                    def.FixedParticles(0x375A, 10, 15, 5037, EffectLayer.Waist);
                    def.PlaySound(0x1E9);
                }

                double dmg = damage - 1;
                
                if (block > dmg)
                {
                    block -= dmg;
                    dmg = 0;
                }
                else
                {
                    dmg -= block;
                    block = 0;
                }
                damage = dmg + 1;
                m_Table[def] = block;
            }
        }

        public override void OnCast()
        {
            if (Caster is PlayerMobile)
            {
                Caster.Target = new InternalTarget(this);
            }
            else if (m_Table.ContainsKey(Caster) || ReactiveArmorSpell.InTable(Caster))
            {
                Caster.SendLocalizedMessage(1005559); // This spell is already in effect.
            }
            else if (!Caster.CanBeginAction(typeof(DefensiveSpell)))
            {
                Caster.SendLocalizedMessage(1005385); // The spell will not adhere to you at this time.
            }
            else if (CheckSequence())
            {
                if (Caster.BeginAction(typeof(DefensiveSpell)))
                {
                    DoEffect(Caster);
                }
                else
                {
                    Caster.SendLocalizedMessage(1005385); // The spell will not adhere to you at this time.
                }

                FinishSequence();
            }
        }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (m_Table.ContainsKey(m) || ReactiveArmorSpell.InTable(Caster))
            {
                Caster.SendLocalizedMessage(1005559); // This spell is already in effect.
            }
            else if (CheckSequence())
            {
                DoEffect(m);
            }

            FinishSequence();
        }

        private void DoEffect(Mobile m)
        {
            double value = GetSpellScaling(Caster, Info.skillForCasting) * maxDmgBlock;

            m_Table.Add(m, value);

            new ExpireTimer(m, TimeSpan.FromSeconds(duration)).Start();

            m.FixedParticles(0x375A, 10, 15, 5037, EffectLayer.Waist);
            m.PlaySound(0x1E9);
        }

        private class InternalTarget : Target
        {
            private MagicReflectSpell m_Owner;

            public InternalTarget(MagicReflectSpell owner)
                : base(12, false, TargetFlags.Beneficial)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile)
                {
                    m_Owner.Target((Mobile)o);
                }
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }

        private class ExpireTimer : Timer
        {
            private Mobile m_Target;
            private DateTime m_End;

            public ExpireTimer(Mobile target, TimeSpan delay)
                : base(TimeSpan.FromSeconds(1.0), TimeSpan.FromSeconds(1.0))
            {
                m_Target = target;
                m_End = DateTime.Now + delay;

                Priority = TimerPriority.TwoFiftyMS;
            }

            protected override void OnTick()
            {
                if (m_Target.Deleted || !m_Target.Alive || DateTime.Now >= m_End)
                {
                    m_Target.SendMessage("Votre reflet a été rompu.");

                    m_Table.Remove(m_Target);
                    Stop();
                }
            }
        }
	}
}
