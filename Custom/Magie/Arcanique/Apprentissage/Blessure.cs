using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class BlessureSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Blessure", "An Mani",
				SpellCircle.Second,
				212,
				9041,
				Reagent.Nightshade,
				Reagent.SpidersSilk
            );

        public override int RequiredAptitudeValue { get { return 4; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] {NAptitude.Alteration }; } }

        public BlessureSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
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
            else if (CheckHSequence(m))
            {
                SpellHelper.Turn(Caster, m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                double damage = GetNewAosDamage(8, 1, 3, true); ;

                m.FixedParticles(0x374A, 10, 15, 5013, EffectLayer.Waist);
                m.PlaySound(0x1F1);

                SpellHelper.Damage(this, m, damage, 0, 0, 100, 0, 0);
            }

            FinishSequence();
        }

		private class InternalTarget : Target
		{
            private BlessureSpell m_Owner;

            public InternalTarget(BlessureSpell owner)
                : base(12, false, TargetFlags.Harmful)
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