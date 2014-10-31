using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class DrainDeManaSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
                "Drain De Mana", "Ort Rel",
				2,
				215,
				9031,
				Reagent.BlackPearl,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
            );

        public DrainDeManaSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
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

                Disturb(m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                double manaLost = 0;

                if (CheckResisted(m))
                    m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                else
                    manaLost = Utility.Random(1, m.Mana);

                manaLost = SpellHelper.AdjustValue(Caster, manaLost);

                if (manaLost > 100)
                    manaLost = 100;

                m.Mana -= (int)manaLost;

                m.FixedParticles(0x374A, 10, 15, 5032, EffectLayer.Head);
                m.PlaySound(0x1F8);
            }

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private DrainDeManaSpell m_Owner;

            public InternalTarget(DrainDeManaSpell owner)
                : base(12, false, TargetFlags.Harmful)
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