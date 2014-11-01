using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
	public class CunningSpell : Spell
	{
        public static int m_SpellID { get { return 406; } } // TOCHANGE

        private static short s_Cercle = 6;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Ruse", "Uus Wis",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(1),
                SkillName.ArtMagique,
				Reagent.MandrakeRoot,
				Reagent.Nightshade);

		public CunningSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
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

				SpellHelper.AddStatBonus( Caster, m, StatType.Int );

				m.FixedParticles( 0x375A, 10, 15, 5011, EffectLayer.Head );
				m.PlaySound( 0x1EB );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private CunningSpell m_Owner;

			public InternalTarget( CunningSpell owner ) : base( 12, false, TargetFlags.Beneficial )
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