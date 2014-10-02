using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class PoisonNewSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Poison", "In Nox",
				SpellCircle.Third,
				203,
				9051,
				Reagent.Nightshade,
                Reagent.SulfurousAsh,
                Reagent.NoxCrystal
            );

		public PoisonNewSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
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
            else if (CheckHSequence(m))
            {
                SpellHelper.Turn(Caster, m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                Disturb(m);

                int level;

                double total = (Caster.Skills[SkillName.Necromancie].Value + Caster.Skills[SkillName.Empoisonnement].Value);

                if (total >= 200.0 && 3 > Utility.Random(10))
                    level = 3;
                else if (total > 140.0)
                    level = 2;
                else
                    level = 1;

                if (level > 1 && CheckResisted(m))
                {
                    level = 1;
                    m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                }

                m.ApplyPoison(Caster, Poison.GetPoison(level));

                m.FixedParticles(0x374A, 10, 15, 5021, EffectLayer.Waist);
                m.PlaySound(0x474);
            }

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private PoisonNewSpell m_Owner;

			public InternalTarget( PoisonNewSpell owner ) : base( 12, false, TargetFlags.Harmful )
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