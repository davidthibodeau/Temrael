using System;
using System.Collections;
using Server.Mobiles;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Spells
{
	public class SpiritualiteSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
                "Spiritualite", "Ehwa Tyr",
				SpellCircle.Seventh,
				203,
				9031
            );

		public SpiritualiteSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Mobile m )
		{
			if ( !(m is BaseCreature || m is TMobile) )
			{
				Caster.SendLocalizedMessage( 1060508 ); // You can't curse that.
			}
            else if (CheckHSequence(m))
            {
                SpellHelper.Turn(Caster, m);

                m.PlaySound(0xFC);
                m.FixedParticles(14186, 1, 13, 9912, 2062, 7, EffectLayer.Head);
                m.FixedParticles(14138, 1, 15, 9502, 1109, 7, EffectLayer.Head);

                TimeSpan duration = GetDurationForSpell(0.4);
                TimeSpan delay = TimeSpan.FromSeconds(11 - Caster.Skills[CastSkill].Value / 20);

                int amount = (int)(2 + Caster.Skills[CastSkill].Base / 20);
                amount = (int)SpellHelper.AdjustValue(m, amount);

                StopTimer(m);

                Timer t = new InternalTimer(m, delay, DateTime.Now + duration, amount);
                m_Timers[m] = t;
                t.Start();
            }

			FinishSequence();
		}

        private static Hashtable m_Timers = new Hashtable();

		public static void StopTimer( Mobile m )
		{
            Timer t = (Timer)m_Timers[m];

            if (t != null)
            {
                t.Stop();
                m_Timers.Remove(m);

                m.PlaySound(0xFC);
                m.FixedParticles(14186, 1, 13, 9912, 2062, 7, EffectLayer.Head);
                m.FixedParticles(14138, 1, 15, 9502, 1109, 7, EffectLayer.Head);
            }
		}

        private class InternalTimer : Timer
        {
            private Mobile target;
            private DateTime end;
            private int amount;

            public InternalTimer(Mobile targ, TimeSpan delay, DateTime endtime, int Amount)
                : base(TimeSpan.Zero, delay)
            {
                target = targ;
                end = endtime;
                amount = Amount;
            }

            protected override void OnTick()
            {
                if (DateTime.Now > end || target == null || target.Deleted || !target.Alive)
                {
                    Stop();
                    m_Timers.Remove(target);
                    return;
                }

                target.Mana += amount + Utility.Random(-3, 9);

                target.FixedParticles(14186, 1, 13, 9912, 2062, 7, EffectLayer.Head);
                target.FixedParticles(14138, 1, 15, 9502, 1109, 7, EffectLayer.Head);
            }
        }

		private class InternalTarget : Target
		{
            private SpiritualiteSpell m_Owner;

            public InternalTarget(SpiritualiteSpell owner)
                : base(12, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile) o );
				else
					from.SendLocalizedMessage( 1060508 ); // You can't curse that.
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}