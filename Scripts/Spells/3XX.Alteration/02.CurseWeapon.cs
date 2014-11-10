using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Spells
{
	public class CurseWeaponSpell : NecromancerSpell
	{
        public static int m_SpellID { get { return 302; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Maudire", "An Sanct Gra Char",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(2),
                SkillName.Alteration,
				Reagent.PigIron
            );


        private static short s_Cercle = 2;
        public static double LifestealPercentMax = 0.3;

		public CurseWeaponSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

		public override void OnCast()
		{
			BaseWeapon weapon = Caster.Weapon as BaseWeapon;

            if (weapon == null || weapon is Fists/* || weapon is CreatureFists*/)
			{
				Caster.SendLocalizedMessage( 501078 ); // You must be holding a weapon.
			}
			else if ( CheckSequence() )
			{

				Caster.PlaySound( 0x387 );
				Caster.FixedParticles( 0x3779, 1, 15, 9905, 32, 2, EffectLayer.Head );
				Caster.FixedParticles( 0x37B9, 1, 14, 9502, 32, 5, (EffectLayer)255 );
				new SoundEffectTimer( Caster ).Start();

                double duration = 100;

                duration *= Spell.GetSpellScaling(Caster, Info.skillForCasting);

				Timer t = (Timer)m_Table[weapon];

				if ( t != null )
					t.Stop();

				m_Table[weapon] = t = new ExpireTimer( weapon, TimeSpan.FromSeconds(duration) );

				t.Start();
			}

			FinishSequence();
		}

		public static Hashtable m_Table = new Hashtable();

        public static void GetOnHitEffect(Mobile atk, int damage)
        {
            if (CurseWeaponSpell.m_Table.Contains((BaseWeapon)atk.Weapon))
            {
                atk.Heal((int)(CurseWeaponSpell.LifestealPercentMax * Spell.GetSpellScaling(atk, Info.skillForCasting) * damage));
            }
        }

		private class ExpireTimer : Timer
		{
			private BaseWeapon m_Weapon;

			public ExpireTimer( BaseWeapon weapon, TimeSpan delay ) : base( delay )
			{
				m_Weapon = weapon;
				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				Effects.PlaySound( m_Weapon.GetWorldLocation(), m_Weapon.Map, 0xFA );
				m_Table.Remove( this );
			}
		}

		private class SoundEffectTimer : Timer
		{
			private Mobile m_Mobile;

			public SoundEffectTimer( Mobile m ) : base( TimeSpan.FromSeconds( 0.75 ) )
			{
				m_Mobile = m;
				Priority = TimerPriority.FiftyMS;
			}

			protected override void OnTick()
			{
				m_Mobile.PlaySound( 0xFA );
			}
		}
	}
}