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

using Server.Scripts.Commands;

namespace Server.Spells.Fifth
{
	public class IncognitoSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Incognito", "Kal In Ex",
				SpellCircle.Fifth,
				206,
				9002,
				Reagent.Bloodmoss,
				Reagent.Garlic,
				Reagent.Nightshade
            );

        public override int RequiredAptitudeValue { get { return 4; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Illusion }; } }

		public IncognitoSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

        private string m_Name;

        public IncognitoSpell(Mobile caster, Item scroll, string name) : base(caster, scroll, m_Info)
		{
            m_Name = name;
		}

        public override bool CheckCast()
        {
            if (!Caster.CanBeginAction(typeof(IncognitoSpell)))
            {
                Caster.SendLocalizedMessage(1005559); // This spell is already in effect.
                return false;
            }
            else if (!Caster.CanBeginAction(typeof(PolymorphSpell)))
            {
                Caster.SendMessage("Vous ne pouvez faire ce sort en étant transformé.");
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
            else if (m_Name == null || m_Name == "")
            {
                if (Caster is TMobile)
                {
                    ((TMobile)Caster).Incognito = true;
                }
                else
                {
                    Caster.SendMessage("Entrez le nouveau nom que vous désirez avoir (Minimum 3 lettres, ESC pour annuler).");
                    Caster.Prompt = new NamePrompt(Scroll);
                }
                return false;
            }

            return true;
        }

        private class NamePrompt : Prompt
        {
            private Item m_Scroll;

            public NamePrompt(Item scroll)
            {
                m_Scroll = scroll;
            }

            public override void OnResponse(Mobile m, string text)
            {
                if (text != null && text.Length >= 3)
                {
                    Spell spell = new IncognitoSpell(m, m_Scroll, text);
                    spell.Cast();
                }
                else
                {
                    m.SendMessage("La marque doit avoir au moins 3 caractères.");
                }
            }
        }

		public override void OnCast()
        {
            if (!Caster.CanBeginAction(typeof(IncognitoSpell)))
            {
                Caster.SendLocalizedMessage(1005559); // This spell is already in effect.
            }
            else if (!Caster.CanBeginAction(typeof(PolymorphSpell)))
            {
                Caster.SendMessage("Vous ne pouvez faire ce sort en étant transformé.");
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
				if ( Caster.BeginAction( typeof( IncognitoSpell ) ) )
				{
					Caster.NameMod = m_Name;
                    
					/*TMobile pm = Caster as TMobile;

					if ( pm != null )
					{
						if ( pm.Body.IsFemale )
							pm.SetHairMods( Utility.RandomList( m_HairIDs ), 0 );
						else
							pm.SetHairMods( Utility.RandomList( m_HairIDs ), Utility.RandomList( m_BeardIDs ) );

						Item hair = pm.FindItemOnLayer( Layer.Hair );

						if ( hair != null )
							hair.Hue = Utility.RandomHairHue();

						hair = pm.FindItemOnLayer( Layer.FacialHair );

						if ( hair != null )
							hair.Hue = Utility.RandomHairHue();
					}*/

					Caster.FixedParticles( 0x373A, 10, 15, 5036, EffectLayer.Head );
					Caster.PlaySound( 0x3BD );

					StopTimer( Caster );

					Timer t = new InternalTimer( Caster );

					m_Timers[Caster] = t;

					t.Start();
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

		/*private static int[] m_HairIDs = new int[]
			{
				0x2044, 0x2045, 0x2046,
				0x203C, 0x203B, 0x203D,
				0x2047, 0x2048, 0x2049,
				0x204A, 0x0000
			};

		private static int[] m_BeardIDs = new int[]
			{
				0x203E, 0x203F, 0x2040,
				0x2041, 0x204B, 0x204C,
				0x204D, 0x0000
			};*/

		private class InternalTimer : Timer
		{
			private Mobile m_Owner;

			public InternalTimer( Mobile owner ) : base( TimeSpan.FromSeconds( 0 ) )
			{
				m_Owner = owner;

				double val = (owner.Skills[SkillName.ArtMagique].Value * 8) + 120;

				if ( val > 920 )
					val = 920;

				Delay = TimeSpan.FromSeconds( val );
				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if ( !m_Owner.CanBeginAction( typeof( IncognitoSpell ) ) )
				{
					//m_Owner.BodyMod = 0;
					//m_Owner.HueMod = -1;
					m_Owner.NameMod = null;
					m_Owner.EndAction( typeof( IncognitoSpell ) );

                    /*BaseArmor.ValidateMobile(m_Owner);

                    if (m_Owner is TMobile)
                    {
                        ((TMobile)m_Owner).SetHairMods(-1, -1);

                        ((TMobile)m_Owner).CheckRaceGump();
                    }*/
				}
			}
		}
	}
}
