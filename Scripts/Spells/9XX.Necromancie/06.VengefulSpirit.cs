using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Spells
{
	public class VengefulSpiritSpell : NecromancerSpell
	{
        public static int m_SpellID { get { return 906; } } // TOCHANGE

        private static short s_Cercle = 6;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Esprit Vengeur", "Kal Xen Bal Beh",
                s_Cercle,
				203,
				9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(1),
                SkillName.Animisme,
				Reagent.BatWing,
				Reagent.GraveDust,
				Reagent.PigIron
            );

		public VengefulSpiritSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( (Caster.Followers + 1) > Caster.FollowersMax )
			{
				Caster.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
				return false;
			}

			return true;
		}

		public void Target( Mobile m )
		{
			if ( Caster == m )
			{
				Caster.SendLocalizedMessage( 1061832 ); // You cannot exact vengeance on yourself.
			}
			else if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

                double duration = ((Caster.Skills[DamageSkill].Value * 80) / 130) + 10;

                TimeSpan t = TimeSpan.FromSeconds(duration);

                //Revenant rev = new Revenant( Caster, m, t );

                //if ( BaseCreature.Summon( rev, false, Caster, m.Location, 0x81, TimeSpan.FromSeconds( t.TotalSeconds + 2.0 ) ) )
                //    rev.FixedParticles( 0x373A, 1, 15, 9909, EffectLayer.Waist );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private VengefulSpiritSpell m_Owner;

			public InternalTarget( VengefulSpiritSpell owner ) : base( 12, false, TargetFlags.Harmful )
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