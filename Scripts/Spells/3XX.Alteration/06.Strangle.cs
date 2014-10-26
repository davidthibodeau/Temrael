using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Spells
{
	public class StrangleSpell : NecromancerSpell
	{
        public static int m_SpellID { get { return 306; } } // TOCHANGE

        private static int s_ManaCost = 50;
        private static SkillName s_SkillForCast = SkillName.ArtMagique;
        private static int s_MinSkillForCast = 50;
        private static TimeSpan s_DureeCast = TimeSpan.FromSeconds(1);

		public static readonly new SpellInfo Info = new SpellInfo(
				"Étranglement", "In Bal Nox",
				SpellCircle.Sixth,
				209,
				9031,
                s_ManaCost,
                s_DureeCast,
                s_SkillForCast,
                s_MinSkillForCast,
                false,
				Reagent.DaemonBlood,
				Reagent.NoxCrystal
            );

		public StrangleSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Mobile m )
		{
			if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

				SpellHelper.CheckReflect( (int)this.Circle, Caster, ref m );

				/* Temporarily chokes off the air suply of the target with poisonous fumes.
				 * The target is inflicted with poison damage over time.
				 * The amount of damage dealt each "hit" is based off of the caster's Spirit Speak skill and the Target's current Stamina.
				 * The less Stamina the target has, the more damage is done by Strangle.
				 * Duration of the effect is Spirit Speak skill level / 10 rounds, with a minimum number of 4 rounds.
				 * The first round of damage is dealt after 5 seconds, and every next round after that comes 1 second sooner than the one before, until there is only 1 second between rounds.
				 * The base damage of the effect lies between (Spirit Speak skill level / 10) - 2 and (Spirit Speak skill level / 10) + 1.
				 * Base damage is multiplied by the following formula: (3 - (target's current Stamina / target's maximum Stamina) * 2).
				 * Example:
				 * For a target at full Stamina the damage multiplier is 1,
				 * for a target at 50% Stamina the damage multiplier is 2 and
				 * for a target at 20% Stamina the damage multiplier is 2.6
				 */

				m.PlaySound( 0x22F );
				m.FixedParticles( 0x36CB, 1, 9, 9911, 67, 5, EffectLayer.Head );
				m.FixedParticles( 0x374A, 1, 17, 9502, 1108, 4, (EffectLayer)255 );

                if (m is TMobile)
                {
                    TMobile pm = Caster as TMobile;
                    double duration = 10.0;

                    duration = SpellHelper.AdjustValue(Caster, duration);

                    ((TMobile)m).Aphonier(TimeSpan.FromSeconds(duration));
                }

                m.Stam = (int)(m.Stam * 0.15);
			}

			FinishSequence();
        }

        private static Hashtable m_Table = new Hashtable();

        public static bool RemoveCurse(Mobile m)
        {
            Timer t = (Timer)m_Table[m];

            if (t == null)
                return false;

            t.Stop();
            m.SendLocalizedMessage(1061687); // You can breath normally again.

            m_Table.Remove(m);
            return true;
        }

		private class InternalTarget : Target
		{
			private StrangleSpell m_Owner;

			public InternalTarget( StrangleSpell owner ) : base( 12, false, TargetFlags.Harmful )
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