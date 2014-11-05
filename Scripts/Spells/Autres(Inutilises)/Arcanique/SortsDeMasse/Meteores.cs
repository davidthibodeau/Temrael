using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Spells
{
	public class MeteoresSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Météores", "Flam Kal Des Ylem",
				8,
				233,
				9042,
                Reagent.SulfurousAsh,
				Reagent.SulfurousAsh,
				Reagent.SulfurousAsh
            );

        public MeteoresSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return true; } }

		public void Target( IPoint3D p )
		{
			if ( !Caster.CanSee( p ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( CheckSequence() )
			{
				SpellHelper.Turn( Caster, p );

				if ( p is Item )
					p = ((Item)p).GetWorldLocation();

				ArrayList targets = new ArrayList();

				Map map = Caster.Map;

				if ( map != null )
				{
                    IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(p), (int)SpellHelper.AdjustValue(Caster, 1 + Caster.Skills[CastSkill].Value / 25, true));

					foreach ( Mobile m in eable )
					{
                        if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && !(Caster.Party == m.Party))
						{
							targets.Add( m );
						}
					}

					eable.Free();
				}

                //double damage = GetNewAosDamage(25, 1, 6, true);

				if ( targets.Count > 0 )
				{
					Effects.PlaySound( p, Caster.Map, 0x160 );

					for ( int i = 0; i < targets.Count; ++i )
					{
                        Mobile m = (Mobile)targets[i];

                        Disturb(m);

						if ( CheckResisted( m ) )
						{
							//damage *= 0.75;

							m.SendLocalizedMessage( 501783 ); // You feel yourself resisting magical energy.
                        }

						Caster.DoHarmful( m );
                        //SpellHelper.Damage(this, m, damage, 0, 100, 0, 0, 0);

						Caster.MovingParticles( m, 0x36D4, 7, 0, false, true, 9501, 1, 0, 0x100 );
					}
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private MeteoresSpell m_Owner;

            public InternalTarget(MeteoresSpell owner)
                : base(12, true, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				IPoint3D p = o as IPoint3D;

				if ( p != null )
					m_Owner.Target( p );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}