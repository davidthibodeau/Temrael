using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Engines.Mort;

namespace Server.Spells
{
	public class NResurrectionSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Resurrection", "An Corp",
				6,
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
                PlayerMobile pm = m as PlayerMobile;

                if (pm != null && Caster is PlayerMobile && (pm.MortEngine.MortCurrentState == MortState.Assomage || pm.MortEngine.MortCurrentState == MortState.MortDefinitive))
                {
                    SpellHelper.Turn(Caster, pm);

                    /*((PlayerMobile)Caster).AddFatigue(250);
                    pm.AddFatigue(-250);*/

                    pm.PlaySound(0x214);
                    Effects.SendTargetEffect(pm,0x376A, 10, 16);

                    if (pm.MortEngine.TimerEvanouie != null)
                    {
                        pm.MortEngine.TimerEvanouie.Stop();
                        pm.MortEngine.TimerEvanouie = null;
                    }

                    if (pm.MortEngine.TimerMort != null)
                    {
                        pm.MortEngine.TimerMort.Stop();
                        pm.MortEngine.TimerMort = null;
                    }

                    pm.Location = c.Location;
                    pm.MortEngine.EndroitMort = c.Location;
                    pm.MortEngine.RisqueDeMort = false;
                    pm.MortEngine.Mort = false;
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

                            if (item is RaceSkin || c.EquipItems.Contains(item))
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

                    pm.CheckRaceSkin();
                    pm.CheckStatTimers();

                    pm.MortEngine.MortCurrentState = MortState.Resurrection;
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

                if (c != null && c.Owner is PlayerMobile)
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