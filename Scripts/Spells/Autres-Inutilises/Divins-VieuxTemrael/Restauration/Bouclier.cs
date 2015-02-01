using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class BouclierSpell : ReligiousSpell
	{
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_BouclierTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

		public static readonly new SpellInfo Info = new SpellInfo(
                "Bouclier", "Otil Algi",
				4,
				212,
				9041
            );

        public BouclierSpell(Mobile caster, Item scroll)
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
                SpellHelper.Turn(Caster, m);

                StopTimer(m);

                TimeSpan duration = TimeSpan.FromSeconds(0);

                m_BouclierTable[m] = Caster;

                Timer t = new BouclierTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                Effects.SendTargetParticles(m,8902, 9, 18, 5005, EffectLayer.Waist);
                m.PlaySound(490);
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
                m_BouclierTable.Remove(m);

                Effects.SendTargetParticles(m,8902, 9, 18, 5005, EffectLayer.Waist);
                m.PlaySound(490);
            }
        }

        public class BouclierTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public BouclierTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && BouclierSpell.m_BouclierTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    BouclierSpell.m_BouclierTable.Remove(m_target);
                    BouclierSpell.m_Timers.Remove(m_target);

                    Effects.SendTargetParticles(m_target,8902, 9, 18, 5005, EffectLayer.Waist);
                    m_target.PlaySound(490);

                    Stop();
                }
            }
        }

		private class InternalTarget : Target
		{
            private BouclierSpell m_Owner;

            public InternalTarget(BouclierSpell owner)
                : base(12, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
                if (o is Mobile && o == from)
                {
                    m_Owner.Target((Mobile)o);
                }
                else
                    from.SendMessage("Vous ne pouvez cibler que vous-même avec ce sort.");
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}