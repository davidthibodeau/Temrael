using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.Fifth;
using Server.Spells.Necromancy;

using Server.Scripts.Commands;

namespace Server.Spells.Seventh
{
	public class PolymorphSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Polymorph", "Vas Ylem Rel",
				SpellCircle.Seventh,
				221,
				9002,
				Reagent.Bloodmoss,
				Reagent.SpidersSilk,
				Reagent.MandrakeRoot
            );

		private int m_NewBody;

		public PolymorphSpell( Mobile caster, Item scroll, int body ) : base( caster, scroll, m_Info )
		{
			m_NewBody = body;
		}

		public PolymorphSpell( Mobile caster, Item scroll ) : this(caster,scroll,0)
		{
		}

        public override bool CheckCast()
        {
            if (Caster.Mounted)
            {
                Caster.SendLocalizedMessage(1042561); // Please dismount first.
                return false;
            }
            else if (!Caster.CanBeginAction(typeof(IncognitoSpell)))
            {
                Caster.SendMessage("Vous ne pouvez faire ce sort en étant sous l'effet de l'incognito.");
                return false;
            }
            else if (!Caster.CanBeginAction(typeof(PolymorphSpell)))
            {
                Caster.BodyMod = 0;
                Caster.EndAction(typeof(PolymorphSpell));

                if (Caster is TMobile)
                    ((TMobile)Caster).CheckRaceGump();
                /*Caster.SendLocalizedMessage(1005559); // This spell is already in effect.*/
                return false;
            }
            else if (TransformationSpell.UnderTransformation(Caster))
            {
                Caster.SendMessage("Vous ne pouvez faire ce sort en étant transformé.");
                return false;
            }
            /*else if (!Caster.CanBeginAction(typeof(ChauveSouris)))
            {
                Caster.SendMessage("Vous ne pouvez vous transformer en étant sous la forme d'une chauve-souris.");
                return false;
            }*/
            else if (m_NewBody == 0)
            {
                Caster.SendGump(new PolymorphGump(Caster, Scroll));
                return false;
            }

            return true;
        }

		public override void OnCast()
		{
			if ( Caster.Mounted )
			{
				Caster.SendLocalizedMessage( 1042561 ); //Please dismount first.
            }
            else if (!Caster.CanBeginAction(typeof(IncognitoSpell)))
            {
                Caster.SendMessage("Vous ne pouvez faire ce sort en étant sous l'effet de l'incognito.");
            }
            /*else if (Caster is TMobile && ((TMobile)Caster).Disguised)
            {
                Caster.SendMessage("Vous ne pouvez faire ce sort en étant déguisé.");
            }*/
            else if (TransformationSpell.UnderTransformation(Caster))
            {
                Caster.SendMessage("Vous ne pouvez faire ce sort en étant transformé.");
            }
            /*else if (!Caster.CanBeginAction(typeof(ChauveSouris)))
            {
                Caster.SendMessage("Vous ne pouvez vous transformer en étant sous la forme d'une chauve-souris.");
            }*/
			else if ( CheckSequence() )
			{
				if ( Caster.BeginAction( typeof( PolymorphSpell ) ) )
				{
					if ( m_NewBody != 0 )
					{
						/*if ( !((Body)m_NewBody).IsHuman )
						{
							Mobiles.IMount mt = Caster.Mount;

							if ( mt != null )
								mt.Rider = null;
						}*/

						Caster.BodyMod = m_NewBody;

						/*if ( m_NewBody == 400 || m_NewBody == 401 )
							Caster.HueMod = Utility.RandomSkinHue();
						else
							Caster.HueMod = 0;

						BaseArmor.ValidateMobile( Caster );*/

						StopTimer( Caster );

						Timer t = new InternalTimer( Caster );

						m_Timers[Caster] = t;

						t.Start();
					}
				}
				else
				{
					Caster.SendLocalizedMessage( 1005559 ); // This spell is already in effect.
				}
			}

			FinishSequence();
		}

		private static Hashtable m_Timers = new Hashtable();

		public static bool StopTimer( Mobile m )
		{
			Timer t = (Timer)m_Timers[m];

			if ( t != null )
			{
				t.Stop();
				m_Timers.Remove( m );
			}

			return ( t != null );
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Owner;

			public InternalTimer( Mobile owner ) : base( TimeSpan.FromSeconds( 0 ) )
			{
				m_Owner = owner;

                double duration = ((int)owner.Skills[SkillName.Reve].Value * 800) + 120;

                duration = SpellHelper.AdjustValue(owner, duration, Aptitude.Spiritisme);

                if (duration > 920)
                    duration = 920;

                Delay = TimeSpan.FromSeconds(duration);
				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if ( !m_Owner.CanBeginAction( typeof( PolymorphSpell ) ) )
				{
					m_Owner.BodyMod = 0;
					//m_Owner.HueMod = -1;
					m_Owner.EndAction( typeof( PolymorphSpell ) );

                    //BaseArmor.ValidateMobile(m_Owner);

                    if (m_Owner is TMobile)
                        ((TMobile)m_Owner).CheckRaceGump();
				}
			}
		}
	}
}
