using System;
using System.Collections;
using Server;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class SacrificeSpell : Spell
	{
        public static int m_SpellID { get { return 409; } } // TOCHANGE

        private static short s_Cercle = 3;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Sacrifice", "In Jux Flam",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(1),
                SkillName.Providence,
				Reagent.Garlic,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
            );

		public SacrificeSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

        private const double dureeMax = 180;

        public override void OnCast()
        {
            if (Caster is PlayerMobile)
            {
                Caster.Target = new InternalTarget(this);
            }
            else
            {
                if (CheckSequence())
                {
                    DoEffect(Caster);
                }
                FinishSequence();
            }
        }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckSequence())
            {
                DoEffect(m);
            }

            FinishSequence();
        }

        private void DoEffect(Mobile m)
        {
            double duree = GetSpellScaling(Caster, Info.skillForCasting) * dureeMax;

            new ExpireTimer(Caster, m, TimeSpan.FromSeconds(duree)).Start();

            m_SacrificeTable[m] = Caster;

            Effects.SendTargetParticles(m,0x375A, 9, 20, 5016, EffectLayer.Waist);
            m.PlaySound(0x1ED);
        }

        public static void GetOnHitEffect(Mobile def, ref double damage)
        {
            Mobile caster = GetSacrifice(def);
            if (caster != null)
            {
                caster.Damage((int)(damage * 0.25));
                damage = damage * 0.75;
            }
        }

		public static Mobile GetSacrifice( Mobile m )
		{
			if ( m == null )
				return null;

			Mobile oath = (Mobile)m_SacrificeTable[m];

			if ( oath == m )
				oath = null;

			return oath;
		}

        private static Hashtable m_SacrificeTable = new Hashtable();

		private class ExpireTimer : Timer
		{
			private Mobile m_Caster;
			private Mobile m_Target;
			private DateTime m_End;

			public ExpireTimer( Mobile caster, Mobile target, TimeSpan delay ) : base( TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 ) )
			{
				m_Caster = caster;
				m_Target = target;
				m_End = DateTime.Now + delay;

				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				if ( m_Caster.Deleted || m_Target.Deleted || !m_Caster.Alive || !m_Target.Alive || DateTime.Now >= m_End )
				{
                    m_Caster.SendMessage("Le lien de sacrifice a été rompu.");
                    m_Target.SendMessage("Le lien de sacrifice a été rompu.");

					m_SacrificeTable.Remove( m_Caster );
					m_SacrificeTable.Remove( m_Target );

					Stop();
				}
			}
		}

        private class InternalTarget : Target
        {
            private SacrificeSpell m_Owner;

            public InternalTarget(SacrificeSpell owner)
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
