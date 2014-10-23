using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;

namespace Server.Spells
{
	public class NResurrectionSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Resurrection", "An Corp",
				SpellCircle.Sixth,
				245,
				9062,
				Reagent.Bloodmoss,
				Reagent.Garlic,
				Reagent.Ginseng
            );

        public NResurrectionSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Corpse c )
		{
            Mobile m = c.Owner;

			if ( !Caster.CanSee( c ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( m == Caster )
			{
				Caster.SendLocalizedMessage( 501039 ); // Thou can not resurrect thyself.
			}
			else if ( !Caster.InRange( c, 5 ) )
			{
				Caster.SendLocalizedMessage( 501042 ); // Target is not close enough.
			}
			else if ( !m.Player )
			{
				Caster.SendLocalizedMessage( 501043 ); // Target is not a being.
			}
			else if ( CheckSequence() && m != null)
			{
                TMobile pm = m as TMobile;

                if (pm != null && Caster is TMobile && (pm.MortCurrentState == MortState.Assomage || pm.MortCurrentState == MortState.MortDefinitive))
                {
                    SpellHelper.Turn(Caster, pm);

                    /*((TMobile)Caster).AddFatigue(250);
                    pm.AddFatigue(-250);*/

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

                    pm.Direction = c.Direction;
                    pm.Animate(21, 5, 1, false, false, 0);

                    pm.Resurrect();

                    if (c != null)
                    {
                        ArrayList list = new ArrayList();

                        foreach (Item item in c.Items)
                        {
                            list.Add(item);
                        }

                        foreach (Item item in list)
                        {
                            if (item.Layer == Layer.Hair || item.Layer == Layer.FacialHair)
                                item.Delete();

                            if (item is RaceGump || c.EquipItems.Contains(item))
                            {
                                if (!m.EquipItem(item))
                                    m.AddToBackpack(item);
                            }
                            else
                            {
                                m.AddToBackpack(item);
                            }
                        }
                    }

                    pm.CheckRaceGump();
                    pm.CheckStatTimers();

                    pm.MortCurrentState = MortState.Resurrection;
                }
                else
                    Caster.SendMessage("Vous devez cibler le corps d'un joueur MORT !");
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private NResurrectionSpell m_Owner;

            public InternalTarget(NResurrectionSpell owner)
                : base(3, false, TargetFlags.Beneficial)
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