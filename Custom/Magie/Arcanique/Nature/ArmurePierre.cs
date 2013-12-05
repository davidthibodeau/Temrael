using System;
using Server.Targeting;
using Server.Network;
using Server;
using Server.Mobiles;

namespace Server.Spells
{
	public class ArmurePierreSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
                "Armure de pierre", "Rel Sanct In Ylem",
				SpellCircle.Sixth,
				236,
				9031,
                Reagent.Bloodmoss,
                Reagent.Ginseng,
                Reagent.SpidersSilk
			);

        public override int RequiredAptitudeValue { get { return 5; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Adjuration }; } }

        public ArmurePierreSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new ArmurePierreTarget( this );
		}

		private class ArmurePierreTarget : Target
		{
			private Spell m_spell;

            public ArmurePierreTarget(Spell spell)
                : base(12, false, TargetFlags.Beneficial)
			{
				m_spell = spell;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
                if (targeted is TMobile && m_spell.CheckBSequence((Mobile)targeted))
				{
                    TMobile targ = (TMobile)targeted;

                    SpellHelper.Turn(m_spell.Caster, targ);

                    TimeSpan duration = m_spell.GetDurationForSpell(0.3);

                    new ArmurePierreSpell.InternalTimer(targ, duration).Start();
                    //targ.ArmurePierre = true;

                    targ.FixedParticles(6899, 9, 32, 5007, 2302, 0, EffectLayer.LeftFoot);
					targ.PlaySound( 508 );
				}

                m_spell.FinishSequence();
			}

			protected override void OnTargetFinish( Mobile from )
			{
                m_spell.FinishSequence();
			}
		}

        private class InternalTimer : Timer
        {
            private TMobile player;

            public InternalTimer(TMobile pm, TimeSpan duration)
                : base(duration)
            {
                player = pm;

                Priority = TimerPriority.TwoFiftyMS;
            }

            protected override void OnTick()
            {
                if (player == null || player.Deleted)
                    return;

                //player.ArmurePierre = false;
            }
        }
	}
}
