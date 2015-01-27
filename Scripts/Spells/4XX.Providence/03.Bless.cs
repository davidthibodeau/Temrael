using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
	public class BlessSpell : Spell
	{
        public static int m_SpellID { get { return 403; } } // TOCHANGE

        private static short s_Cercle = 4;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Bénédiction", "Rel Sanct",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(5),
                SkillName.Providence,
				Reagent.Garlic,
				Reagent.MandrakeRoot
            );

        private static short durationMax = 600;
        private static short bonusMax = 20;

		public BlessSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
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
				SpellHelper.Turn( Caster, m );

                int bonus = (int)(bonusMax * GetSpellScaling(Caster, Info.skillForCasting));
                TimeSpan duration = TimeSpan.FromSeconds(durationMax * GetSpellScaling(Caster, Info.skillForCasting));

                SpellHelper.AddStatBonus(Caster, m, StatType.All, bonus, duration); SpellHelper.DisableSkillCheck = true;

				m.FixedParticles( 0x373A, 10, 15, 5018, EffectLayer.Waist );
				m.PlaySound( 0x1EA );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private BlessSpell m_Owner;

			public InternalTarget( BlessSpell owner ) : base( 12, false, TargetFlags.Beneficial )
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