using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Engines.PartySystem;
using Server.Mobiles;

namespace Server.Spells
{
	public class ChampDeStaseSpell : Spell
    {
        public static int m_SpellID { get { return 207; } } // TOCHANGE

        private static short s_Cercle = 7;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Champ De Stase", "An Tym",
				s_Cercle,
				239,
				9011,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(6),
                SkillName.Immuabilite,
				Reagent.Garlic,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh
			);

        public static Hashtable m_Timers = new Hashtable();

        private static int durationMax = 45;

        public ChampDeStaseSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
            else if (m.Blessed)
            {
                Caster.SendMessage("Vous ne pouvez pas cibler une créature invulnérable !");
            }
            else if (CheckSequence())
            {
                SpellHelper.Turn(Caster, m);

                if (m != Caster && m.BeginAction(typeof(ChampDeStaseSpell)) && m.AccessLevel <= Caster.AccessLevel)
                {
                    double dur = durationMax * Spell.GetSpellScaling(Caster, Info.skillForCasting);

                    TimeSpan duration = TimeSpan.FromSeconds(dur);

                    m.Freeze(duration);

                    m.Hidden = true;
                    m.Blessed = true;

                    Timer t = new InternalTimer(m, duration);

                    m_Timers[m] = t;

                    t.Start();
                }
                else
                    Caster.SendMessage("Vous ne pouvez pas vous cibler vous-même !");
            }

			FinishSequence();
		}

        public void StopTimer(Mobile m)
        {
            Timer t = (Timer)m_Timers[m];

            if (t != null)
            {
                t.Stop();
                m_Timers.Remove(m);

                m.RevealingAction();
                m.Blessed = false;
                m.Hidden = false;

                //if (m is PlayerMobile)
                //    ((PlayerMobile)m).Aphonie = false;

                m.EndAction(typeof(ChampDeStaseSpell));
            }
        }

        public class InternalTimer : Timer
        {
            private Mobile player;

            public InternalTimer(Mobile m, TimeSpan duration)
                : base(duration)
            {
                player = m;
                Priority = TimerPriority.TwoFiftyMS;
            }

            protected override void OnTick()
            {
                if (!player.CanBeginAction(typeof(ChampDeStaseSpell)))
                {
                    m_Timers.Remove(player);

                    player.RevealingAction();
                    player.Blessed = false;
                    player.Hidden = false;

                    //if (player is PlayerMobile)
                    //    ((PlayerMobile)player).Aphonie = false;

                    player.EndAction(typeof(ChampDeStaseSpell));
                }
            }
        }

		private class InternalTarget : Target
		{
            private ChampDeStaseSpell m_Owner;

            public InternalTarget(ChampDeStaseSpell owner)
                : base(12, true, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				Mobile m = o as Mobile;

				if ( m != null )
					m_Owner.Target( m );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}
