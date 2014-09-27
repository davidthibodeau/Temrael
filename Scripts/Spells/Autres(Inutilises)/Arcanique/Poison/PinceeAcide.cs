using System;
using Server.Targeting;
using Server.Network;
using Server.Items;

namespace Server.Spells
{
	public class PinceeAcideSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        //NB Fast cast
		private static SpellInfo m_Info = new SpellInfo(
				"Pincee Acide", "Bet Nox",
				SpellCircle.Eighth,
				203,
				9051,
				Reagent.Nightshade,
                Reagent.NoxCrystal,
                Reagent.BlackPearl
			);

        public PinceeAcideSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
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

                Disturb(m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                int level;

                double total = (Caster.Skills[SkillName.ArtMagique].Value + Caster.Skills[SkillName.Empoisonnement].Value);

                if (total >= 200.0 && 3 > Utility.Random(10))
                    level = 2;
                else if (total > 140.0)
                    level = 1;
                else
                    level = 0;

                m.ApplyPoison(Caster, Poison.GetPoison(level));

				m.FixedParticles( 0x374A, 10, 15, 5021, EffectLayer.Waist );
				m.PlaySound( 0x474 );

                double damage = GetNewAosDamage(2, 1, 2, false);

                //BaseArmor.AcidHit(m, (int)damage);

                damage = GetNewAosDamage(12, 1, 4, false);

                SpellHelper.Damage(this, m, damage, 0, 0, 0, 0, 100);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private PinceeAcideSpell m_Owner;

            public InternalTarget(PinceeAcideSpell owner)
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