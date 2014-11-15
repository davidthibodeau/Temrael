using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Spells
{
	public class JetDePoisonSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Jet De Poison", "In Vas Nox",
				4,
				203,
				9031,
				Reagent.NoxCrystal,
                Reagent.SulfurousAsh,
                Reagent.BlackPearl
            );

        public JetDePoisonSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return false; } }

		public void Target( Mobile m )
		{
			if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

                Disturb(m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

				Effects.SendLocationParticles( EffectItem.Create( m.Location, m.Map, EffectItem.DefaultDuration ), 0x36B0, 1, 14, 63, 7, 9915, 0 );
				Effects.PlaySound( m.Location, m.Map, 0x229 );

                //double damage = GetNewAosDamage(7, 1, 3, false);

                int level;

                double total = (Caster.Skills[SkillName.ArtMagique].Value + Caster.Skills[SkillName.Empoisonnement].Value);

                if (total >= 200.0 && 3 > Utility.Random(10))
                    level = 2;
                else if (total > 140.0)
                    level = 1;
                else
                    level = 0;

                m.ApplyPoison(Caster, Poison.GetPoison(level));

                //SpellHelper.Damage(this, m, damage, 0, 0, 0, 0, 100);

				Map map = m.Map;

				if ( map != null )
				{
					ArrayList targets = new ArrayList();

					foreach ( Mobile targ in m.GetMobilesInRange( 2 ) )
					{
                        if ((Caster != targ && m != targ && SpellHelper.ValidIndirectTarget(Caster, targ)) && Caster.CanBeHarmful(targ, false) && !(Caster.Party == targ.Party))
							targets.Add( targ );
					}

					for ( int i = 0; i < targets.Count; ++i )
					{
						Mobile targ = (Mobile)targets[i];

                        //SpellHelper.Damage(this, targ, damage * 0.33, 0, 0, 0, 0, 100);

                        m.FixedParticles(0x374A, 10, 15, 5021, EffectLayer.Waist);
                        m.PlaySound(0x474);
					}
				}
			}

			FinishSequence();
        }

		private class InternalTarget : Target
		{
            private JetDePoisonSpell m_Owner;

            public InternalTarget(JetDePoisonSpell owner)
                : base(12, false, TargetFlags.Harmful)
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