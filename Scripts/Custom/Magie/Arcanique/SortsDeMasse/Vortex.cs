using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Spells
{
	public class VortexSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
                "Vortex", "Vas Hur Corp Por",
				SpellCircle.Eighth,
				233,
				9042,
				false,
				Reagent.Nightshade,
				Reagent.Garlic,
				Reagent.Bloodmoss
			);

		public VortexSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return true; } }

        private Timer m_Timer;

		public void Target( IPoint3D o )
		{
            IPoint3D p = o;

            if (o is Mobile)
                p = ((Mobile)o).Location;

			if ( !Caster.CanSee( p ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( SpellHelper.CheckTown( p, Caster ) && CheckSequence() )
			{
                TimeSpan duration = GetDurationForSpellvortex(0.02);

                double damage = GetNewAosDamage(6, 4, 6, true);

                DateTime endtime = DateTime.Now + duration;

                Effects.SendLocationEffect(new Point3D(p), Caster.Map, 0x37CC, (int)(Caster.Skills[SkillName.Destruction].Value* 1.5));

                m_Timer = new VortexTimer(Caster, damage, endtime, p, m_Timer, this);
                m_Timer.Start();
			}

			FinishSequence();
		}

        private class VortexTimer : Timer
        {
            private Mobile m_caster;
            private double s_damage;
            private DateTime ending;
            private IPoint3D loc;
            private Timer m_Timer;
            private Spell m_Spell;

            public VortexTimer(Mobile caster, double damage, DateTime endtime, IPoint3D p, Timer timer, Spell spell)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(1))
            {
                m_caster = caster;
                s_damage = damage;
                ending = endtime;
                loc = p;
                m_Timer = timer;
                m_Spell = spell;

                Priority = TimerPriority.TwoFiftyMS;
            }

            protected override void OnTick()
            {
                if (DateTime.Now >= ending)
                {
                    Stop();
                }
                else if (!m_caster.Alive)
                {
                    Stop();
                }
                else 
                {
                    if (loc is Item)
                        loc = ((Item)loc).GetWorldLocation();

                    ArrayList targets = new ArrayList();

                    Map map = m_caster.Map;

                    if (map != null)
                    {
                        IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(loc), (int)SpellHelper.AdjustValue(m_caster, 1 + m_caster.Skills[SkillName.Destruction].Base / 25, true));

                        foreach (Mobile m in eable)
                        {
                            if (m_caster != m && SpellHelper.ValidIndirectTarget(m_caster, m, true) && m_caster.CanBeHarmful(m, false) && m_caster.InLOS(m) && !(m_caster.Party == m.Party))
                            {
                                targets.Add(m);
                            }
                        }

                        eable.Free();
                    }

                    if (targets.Count > 0)
                    {
                        m_caster.PlaySound(0x29);

                        for (int i = 0; i < targets.Count; ++i)
                        {
                            Mobile m = (Mobile)targets[i];

                            double chance = 60;

                            if (chance > Utility.Random(0, 100))
                            {
                                Spell.Disturb(m);

                                m_caster.DoHarmful(m);
                                AOS.Damage(m, m_caster, (int)s_damage, 0, 0, 0, 0, 100);

                                m.BoltEffect(0);
                            }
                        }
                    }
                }
            }
        }

		private class InternalTarget : Target
		{
			private VortexSpell m_Owner;

			public InternalTarget( VortexSpell owner ) : base( 12, true, TargetFlags.Harmful )
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