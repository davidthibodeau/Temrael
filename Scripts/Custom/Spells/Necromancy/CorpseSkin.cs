using System;
using System.Collections;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Spells.Necromancy
{
	public class CorpseSkinSpell : NecromancerSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Corps Mortifié", "In Agle Corp Ylem",
				SpellCircle.Third,
				203,
				9051,
				Reagent.BatWing,
				Reagent.GraveDust
            );

		public CorpseSkinSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
        }

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

        public void Target(Mobile m)
        {
            if (CheckHSequence(m))
            {
                SpellHelper.Turn(Caster, m);

                ExpireTimer timer = (ExpireTimer)m_Table[m];

                if (timer != null)
                    timer.DoExpire();
                else
                    m.SendLocalizedMessage(1061689); // Your skin turns dry and corpselike.

                m.FixedParticles(0x373A, 1, 15, 9913, 67, 7, EffectLayer.Head);
                m.PlaySound(0x1BB);

                double ss = GetDamageSkill(Caster);
                double mr = (Caster == m ? 0.0 : GetResistSkill(m));

                double value = GetDamageSkill(Caster) / 2.5;

                value = SpellHelper.AdjustValue(Caster, value, Aptitude.Sorcellerie);

                if (value > 40)
                    value = 40;

                double duration = ((ss - mr) / 2.5) + 30.0;

                duration = SpellHelper.AdjustValue(Caster, duration, Aptitude.Spiritisme);

                if (duration > 90)
                    duration = 90;

                m.VirtualArmorMod -= (int)value;

                timer = new ExpireTimer(m, (int)value, TimeSpan.FromSeconds(duration));
                timer.Start();

                m_Table[m] = timer;
            }

            FinishSequence();
        }

		private static Hashtable m_Table = new Hashtable();

		public static bool RemoveCurse( Mobile m )
		{
			ExpireTimer t = (ExpireTimer)m_Table[m];

			if ( t == null )
				return false;

			m.SendLocalizedMessage( 1061688 ); // Your skin returns to normal.
			t.DoExpire();
			return true;
		}

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private int m_Value;

			public ExpireTimer( Mobile m, int value, TimeSpan delay ) : base( delay )
			{
				m_Mobile = m;
                m_Value = value;
			}

			public void DoExpire()
            {
                m_Mobile.VirtualArmorMod += m_Value;

                if (m_Mobile.VirtualArmorMod < 0)
                    m_Mobile.VirtualArmorMod = 0;

				Stop();
				m_Table.Remove( m_Mobile );
			}

			protected override void OnTick()
			{
				m_Mobile.SendLocalizedMessage( 1061688 ); // Your skin returns to normal.
				DoExpire();
			}
		}

		private class InternalTarget : Target
		{
			private CorpseSkinSpell m_Owner;

			public InternalTarget( CorpseSkinSpell owner ) : base( 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile) o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}