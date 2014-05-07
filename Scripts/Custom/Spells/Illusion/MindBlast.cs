using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.Fifth
{
	public class MindBlastSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Destruction Cérébrale", "Por Corp Wis",
				SpellCircle.Fifth,
				218,
				9032,
				Reagent.BlackPearl,
				Reagent.MandrakeRoot,
				Reagent.Nightshade,
				Reagent.SulfurousAsh
            );

        public override int RequiredAptitudeValue { get { return 6; } }
        public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Illusion }; } }

		public MindBlastSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return true; } }

		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( CheckHSequence( m ) )
			{
                SpellHelper.Turn(Caster, m);
                int intel = Caster.Int;

                if (intel > 150)
                    intel = 150;

                double damage = (intel - m.Int) / 2.5;

                damage = SpellHelper.AdjustValue(Caster, damage, Aptitude.Sorcellerie);

                if (CheckResisted(m))
				{
					damage *= 0.75;

                    m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
				}

                Caster.FixedParticles(0x374A, 10, 15, 2038, EffectLayer.Head);

                m.FixedParticles(0x374A, 10, 15, 5038, EffectLayer.Head);
                m.PlaySound(0x213);

                SpellHelper.Damage(this, m, damage, 0, 0, 0, 0, 100);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private MindBlastSpell m_Owner;

			public InternalTarget( MindBlastSpell owner ) : base( 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile)o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}