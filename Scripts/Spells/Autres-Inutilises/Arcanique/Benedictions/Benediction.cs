using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
	public class BenedictionSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Benediction", "Rel Sanct",
				4,
				203,
				9061,
				Reagent.Garlic,
				Reagent.MandrakeRoot
            );

        public BenedictionSpell(Mobile caster, Item scroll)
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
			else if ( CheckBSequence( m ) )
			{
                ToogleBless(this, Caster, m);
			}

			FinishSequence();
		}

        public static void ToogleBless(Spell spell, Mobile Caster, Mobile m)
        {
            SpellHelper.Turn(Caster, m);

            SpellHelper.AddStatBonus(Caster, m, StatType.Str, TimeSpan.FromSeconds(0)); SpellHelper.DisableSkillCheck = true;
            SpellHelper.AddStatBonus(Caster, m, StatType.Dex, TimeSpan.FromSeconds(0));
            SpellHelper.AddStatBonus(Caster, m, StatType.Int, TimeSpan.FromSeconds(0)); SpellHelper.DisableSkillCheck = false;

            Effects.SendTargetParticles(m,0x373A, 10, 15, 5018, EffectLayer.Waist);
            m.PlaySound(0x1EA);
        }

		private class InternalTarget : Target
		{
            private BenedictionSpell m_Owner;

            public InternalTarget(BenedictionSpell owner)
                : base(12, false, TargetFlags.Beneficial)
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