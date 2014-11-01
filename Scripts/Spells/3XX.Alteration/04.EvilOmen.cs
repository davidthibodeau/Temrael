using System;
using System.Collections;
using Server.Mobiles;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Spells
{
	public class EvilOmenSpell : NecromancerSpell
	{
        public static int m_SpellID { get { return 304; } } // TOCHANGE

        private static short s_Cercle = 4;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Présage Malsain", "Pas Tym An Sanct",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(1),
                SkillName.ArtMagique,
				Reagent.BatWing,
				Reagent.NoxCrystal
            );

		public EvilOmenSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Mobile m )
		{
			if ( !(m is BaseCreature || m is TMobile) )
			{
				Caster.SendLocalizedMessage( 1060508 ); // You can't curse that.
			}
			else if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

				/* Curses the target so that the next harmful event that affects them is magnified.
				 * Damage to the target's hit points is increased 25%,
				 * the poison level of the attack will be 1 higher
				 * and the Resist Magic skill of the target will be fixed on 50.
				 * 
				 * The effect lasts for one harmful event only.
				 */

				m.PlaySound( 0xFC );
				m.FixedParticles( 0x3728, 1, 13, 9912, 1150, 7, EffectLayer.Head );
				m.FixedParticles( 0x3779, 1, 15, 9502, 67, 7, EffectLayer.Head );

				if ( !m_Table.Contains( m ) )
				{
					SkillMod mod = new DefaultSkillMod( SkillName.Meditation, false, 50.0 );

					if ( m.Skills[SkillName.Meditation].Base > 50.0 )
						m.AddSkillMod( mod );

					m_Table[m] = mod;
				}

                double duration = 7.0;

                duration = SpellHelper.AdjustValue(Caster, duration);

				Timer.DelayCall( TimeSpan.FromSeconds(duration), new TimerStateCallback( EffectExpire_Callback ), m );
			}

			FinishSequence();
		}

		private static Hashtable m_Table = new Hashtable();

		private static void EffectExpire_Callback( object state )
		{
			CheckEffect( (Mobile)state );
		}

		public static bool CheckEffect( Mobile m )
		{
			SkillMod mod = (SkillMod)m_Table[m];

			if ( mod == null )
				return false;

			m_Table.Remove( m );
			mod.Remove();

			return true;
		}

		private class InternalTarget : Target
		{
			private EvilOmenSpell m_Owner;

			public InternalTarget( EvilOmenSpell owner ) : base( 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile) o );
				else
					from.SendLocalizedMessage( 1060508 ); // You can't curse that.
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}