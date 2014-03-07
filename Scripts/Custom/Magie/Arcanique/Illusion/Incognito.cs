using System;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Misc;
using Server.Items;
using Server.Gumps;
using Server.Prompts;
using Server.Spells;
using Server.Spells.Seventh;
using Server.Spells.Necromancy;
using Server.Targeting;

using Server.Scripts.Commands;

namespace Server.Spells
{
	public class OmbreSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Incognito", "Kal In Ex",
				SpellCircle.Fourth,
				206,
				9002,
				Reagent.Bloodmoss,
				Reagent.Garlic,
				Reagent.Nightshade
            );

        public override int RequiredAptitudeValue { get { return 3; } }
        public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Illusion }; } }

		public OmbreSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckBSequence(m))
            {
                SpellHelper.Turn(Caster, m);

                CheckIncognito(this, Caster, m);
            }

            FinishSequence();
        }

        public static void CheckIncognito(Spell spell, Mobile Caster, Mobile m)
        {
            if (CheckTransformation(Caster, m))
            {
                ToogleIncognito(spell, Caster, m);
            }
            else
                StopTimer(m);
        }

        public static void ToogleIncognito(Spell spell, Mobile Caster, Mobile m)
        {
            if (m.BeginAction(typeof(Spell)))
            {
                TimeSpan duration = spell.GetDurationForSpell(30, 0.5);

                StopTimer(m);


                

                if (m is TMobile)
                {
                    TMobile pm = (TMobile)m;
                    pm.OnTransformationChange(Utility.Random(33, 76), "Quelqu'un", 0, true);
                }
                else
                {
                    Caster.BodyMod = Utility.Random(33, 76);
                    Caster.NameMod = "Quelqu'un";
                }

                m.FixedParticles(0x373A, 10, 15, 5036, EffectLayer.Head);
                m.PlaySound(0x3BD);

                BaseArmor.ValidateMobile(m);

                Timer t = new InternalTimer(m, duration);

                m_Timers[m] = t;

                t.Start();
            }
        }

		private static Hashtable m_Timers = new Hashtable();

		public static bool StopTimer( Mobile m )
		{
			Timer t = (Timer)m_Timers[m];

			if ( t != null )
			{
				t.Stop();
				m_Timers.Remove( m );

                if (m is TMobile)
                {
                    TMobile pm = (TMobile)m;
                    pm.OnTransformationChange(0, null, -1, true);
                }
                else
                {
                    m.BodyMod = 0;
                    m.NameMod = null;
                }

                m.EndAction(typeof(OmbreSpell));

                if (m is TMobile)
                    ((TMobile)m).CheckRaceGump();

                BaseArmor.ValidateMobile(m);
			}

			return ( t != null );
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Owner;

			public InternalTimer( Mobile owner, TimeSpan duration ) : base( duration )
			{
				m_Owner = owner;

                Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
                if (m_Owner == null || m_Owner.Deleted)
                    return;

				if ( !m_Owner.CanBeginAction( typeof( OmbreSpell ) ) )
				{
                    if (m_Owner is TMobile)
                    {
                        TMobile pm = (TMobile)m_Owner;
                        pm.OnTransformationChange(0, null, -1, true);
                    }
                    else
                    {
                        m_Owner.BodyMod = 0;
                        m_Owner.NameMod = null;
                    } 

					m_Owner.EndAction( typeof( OmbreSpell ) );

                    if (m_Owner is TMobile)
                        ((TMobile)m_Owner).CheckRaceGump();

                    BaseArmor.ValidateMobile(m_Owner);
				}
			}
		}

        public class InternalTarget : Target
        {
            private OmbreSpell m_Owner;

            public InternalTarget(OmbreSpell owner)
                : base(12, false, TargetFlags.Beneficial)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile)
                {
                    m_Owner.Target((Mobile)o);
                }
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
	}
}
