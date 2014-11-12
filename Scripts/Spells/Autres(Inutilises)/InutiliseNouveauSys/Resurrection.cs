using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;

namespace Server.Spells
{
	public class ResurrectionSpell : Spell
	{
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        private static short s_Cercle = 0;

		public static readonly new SpellInfo Info = new SpellInfo(
                "Résurrection", "An Corp",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(1),
                SkillName.ArtMagique,
				Reagent.Bloodmoss,
				Reagent.Garlic,
				Reagent.Ginseng
            );

		public ResurrectionSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
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
                PlayerMobile pm = m as PlayerMobile;

                if (pm != null)
                {
                    SpellHelper.Turn(Caster, pm);

                    pm.PlaySound(0x214);
                    pm.FixedEffect(0x376A, 10, 16);

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