using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;

namespace Server.Spells.Eighth
{
	public class ResurrectionSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
                "Résurrection", "An Corp",
				SpellCircle.Eighth,
				245,
				9062,
				Reagent.Bloodmoss,
				Reagent.Garlic,
				Reagent.Ginseng
            );

        public override int RequiredAptitudeValue { get { return 12; } }
        public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Thaumaturgie }; } }

		public ResurrectionSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Corpse c )
		{
            Mobile m = c.Owner;

            if (m == null)
            {
            }
			else if ( !Caster.CanSee( c ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( m == Caster )
			{
				Caster.SendLocalizedMessage( 501039 ); // Thou can not resurrect thyself.
			}
			else if ( !Caster.Alive )
			{
				Caster.SendLocalizedMessage( 501040 ); // The resurrecter must be alive.
			}
			else if ( m.Alive )
			{
				Caster.SendLocalizedMessage( 501041 ); // Target is not dead.
			}
			else if ( !Caster.InRange( c, 1 ) )
			{
				Caster.SendLocalizedMessage( 501042 ); // Target is not close enough.
			}
			else if ( !m.Player )
			{
				Caster.SendLocalizedMessage( 501043 ); // Target is not a being.
			}
			else if ( CheckBSequence( m, true ) )
			{
                TMobile pm = m as TMobile;

                if (pm != null)
                {
                    SpellHelper.Turn(Caster, pm);

                    pm.PlaySound(0x214);
                    pm.FixedEffect(0x376A, 10, 16);

                    if (pm.TimerEvanouie != null)
                    {
                        pm.TimerEvanouie.Stop();
                        pm.TimerEvanouie = null;
                    }

                    if (pm.TimerMort != null)
                    {
                        pm.TimerMort.Stop();
                        pm.TimerMort = null;
                    }

                    pm.Location = c.Location;
                    pm.EndroitMort = c.Location;
                    pm.RisqueDeMort = false;
                    pm.Mort = false;
                    pm.Frozen = false;

                    ArrayList list = new ArrayList();

                    foreach (Item item in c.Items)
                    {
                        list.Add(item);
                    }

                    foreach (Item item in list)
                    {
                        if (item.Layer == Layer.Hair || item.Layer == Layer.FacialHair)
                            item.Delete();

                        if (item is BaseRaceGumps || c.EquipItems.Contains(item))
                        {
                            if (!pm.EquipItem(item))
                                pm.AddToBackpack(item);
                        }
                        else
                        {
                            pm.AddToBackpack(item);
                        }
                    }

                    pm.Direction = c.Direction;
                    pm.Animate(21, 5, 1, false, false, 0);

                    c.Delete();

                    pm.Resurrect();

                    pm.CheckRaceGump();
                }
			}
			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private ResurrectionSpell m_Owner;

			public InternalTarget( ResurrectionSpell owner ) : base( 1, false, TargetFlags.Beneficial )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
                Corpse c = o as Corpse;

                if (c != null && c.Owner is TMobile)
				{
					m_Owner.Target(c);
				}
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}