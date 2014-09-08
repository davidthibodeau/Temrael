using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.Third
{
	public class PoisonSpell : Spell
	{
        private static int s_ManaCost = 50;
        private static SkillName s_SkillForCast = SkillName.ArtMagique;
        private static int s_MinSkillForCast = 50;

		private static SpellInfo m_Info = new SpellInfo(
				"Poison", "In Nox",
				SpellCircle.Sixth,
				203,
				9051,
                s_ManaCost,
                s_SkillForCast,
                s_MinSkillForCast,
                false,
				Reagent.Nightshade
            );

		public PoisonSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

				SpellHelper.CheckReflect( (int)this.Circle, Caster, ref m );

				if ( m.Spell != null )
					m.Spell.OnCasterHurt();

				m.Paralyzed = false;

                /*if (CheckResisted(m))
                {
                    m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                }
                else
                {*/
                    int level;

                    double total = Caster.Skills[SkillName.Tenebrae].Value; // +Caster.Skills[SkillName.Empoisonner].Value;

                    //double dist = Caster.GetDistanceToSqrt(m);

                    //if (dist >= 3.0)
                    //    total -= (dist - 3.0) * 10.0;

                    if (total >= 90.0)
                        level = 3;
                    else if (total > 70.0)
                        level = 2;
                    else if (total > 45.0)
                        level = 1;
                    else
                        level = 0;

                    if (level > 0 && CheckResisted(m))
                    {
                        level = 0;
                        m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                    }

                    m.ApplyPoison(Caster, Poison.GetPoison(level));
                //}

				m.FixedParticles( 0x374A, 10, 15, 5021, EffectLayer.Waist );
				m.PlaySound( 0x474 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private PoisonSpell m_Owner;

			public InternalTarget( PoisonSpell owner ) : base( 12, false, TargetFlags.Harmful )
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