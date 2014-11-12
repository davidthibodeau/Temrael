using System;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Misc;
using Server.Items;
using Server.Gumps;
using Server.Prompts;
using Server.Spells;
using Server.Targeting;

using Server.Scripts.Commands;

namespace Server.Spells
{
	public class OmbreSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Incognito", "Kal In Ex",
				4,
				206,
				9002,
				Reagent.Bloodmoss,
				Reagent.Garlic,
				Reagent.Nightshade
            );

		public OmbreSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
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
                TimeSpan duration = TimeSpan.FromSeconds(0);

                StopTimer(m);


                

                if (m is PlayerMobile)
                {
                    PlayerMobile pm = (PlayerMobile)m;
                    pm.Transformation.OnTransformationChange(Utility.Random(33, 76), "Quelqu'un", 0, true);
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

                if (m is PlayerMobile)
                {
                    PlayerMobile pm = (PlayerMobile)m;
                    pm.Transformation.OnTransformationChange(0, null, -1, true);
                }
                else
                {
                    m.BodyMod = 0;
                    m.NameMod = null;
                }

                m.EndAction(typeof(OmbreSpell));

                if (m is PlayerMobile)
                    ((PlayerMobile)m).CheckRaceGump();

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
                    if (m_Owner is PlayerMobile)
                    {
                        PlayerMobile pm = (PlayerMobile)m_Owner;
                        pm.Transformation.OnTransformationChange(0, null, -1, true);
                    }
                    else
                    {
                        m_Owner.BodyMod = 0;
                        m_Owner.NameMod = null;
                    } 

					m_Owner.EndAction( typeof( OmbreSpell ) );

                    if (m_Owner is PlayerMobile)
                        ((PlayerMobile)m_Owner).CheckRaceGump();

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
