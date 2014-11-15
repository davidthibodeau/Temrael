using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Spells
{
	public class DefraicheurSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
                "Defraicheur", "Kal Vas An Flam",
                3,
                203,
                9031,
                Reagent.NoxCrystal,
                Reagent.GraveDust,
                Reagent.PigIron
            );

        public DefraicheurSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return false; } }

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
                    IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(p), (int)SpellHelper.AdjustValue(Caster, 2 + Caster.Skills[CastSkill].Value / 15, true));

					foreach ( Mobile m in eable )
					{
                        if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && !(Caster.Party == m.Party))
						{
							targets.Add( m );
						}
					}

					eable.Free();
				}

				if ( targets.Count > 0 )
				{
					Effects.PlaySound( p, Caster.Map, 0x160 );

					for ( int i = 0; i < targets.Count; ++i )
					{
                        Mobile m = (Mobile)targets[i];

                        if (!Caster.CanSee(m))
                        {
                            continue;
                        }


                        Disturb(m);

                        Effects.PlaySound(m.Location, map, 0x1FB);
                        Effects.PlaySound(m.Location, map, 0x10B);
                        Effects.SendLocationParticles(EffectItem.Create(m.Location, map, EffectItem.DefaultDuration), 0x37CC, 1, 40, 97, 3, 9917, 0);

                        Caster.DoHarmful(m);
                        m.FixedParticles(0x374A, 1, 15, 9502, 97, 3, (EffectLayer)255);

                        //double damage = GetNewAosDamage(10, 1, 4, true);

                        if (CheckResisted(m))
                        {
                            //damage *= 0.75;

                            m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                        }

                        //SpellHelper.Damage(this, m, damage, 0, 0, 100, 0, 0);
					}
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private DefraicheurSpell m_Owner;

            public InternalTarget(DefraicheurSpell owner)
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