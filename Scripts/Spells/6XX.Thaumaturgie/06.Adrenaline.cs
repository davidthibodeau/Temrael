using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using System.Collections.Generic;

namespace Server.Spells
{
	public class AdrenalineSpell : Spell
	{
        public static int m_SpellID { get { return 606; } } // TOCHANGE

        private static short s_Cercle = 6;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Adrenaline", "In Mani Flam",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(2),
                SkillName.Providence,
				Reagent.Garlic,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh
            );

		public AdrenalineSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

        private const double dureeMax = 15;
        private const double dureeCooldown = 60;

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
            else if (m_SouffleTable.ContainsKey(m) || m_CooldownTable.Contains(m))
            {
                Caster.SendMessage("Vous ne pouvez pas lancer le sort de nouveau sur cette cible avant un certain temps");
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

            new ExpireTimer(m, TimeSpan.FromSeconds(duree));

            m_SouffleTable.Add(m, 0);

            m.FixedParticles(0x375A, 9, 20, 5016, EffectLayer.Waist);
            m.PlaySound(0x1ED);
        }

        public static void GetOnHitEffect(Mobile def, ref int damage)
        {
            if (def == null || m_SouffleTable.ContainsKey(def))
                return;

            m_SouffleTable[def] += damage;
            damage = 0;
        }

        private static Dictionary<Mobile, int> m_SouffleTable = new Dictionary<Mobile, int>();
        private static HashSet<Mobile> m_CooldownTable = new HashSet<Mobile>();

		private class ExpireTimer : Timer
		{
			private Mobile m_Target;
			private DateTime m_End;

            public ExpireTimer(Mobile target, TimeSpan delay)
                : base(TimeSpan.FromSeconds(1.0), TimeSpan.FromSeconds(1.0))
            {
                m_Target = target;
                m_End = DateTime.Now + delay;

                Priority = TimerPriority.TwoFiftyMS;
            }

			protected override void OnTick()
			{
				if (m_Target.Deleted || !m_Target.Alive || DateTime.Now >= m_End )
				{
                    m_Target.SendMessage("Votre adrénaline se dissipe.");

                    m_Target.Damage(m_SouffleTable[m_Target]);
                    m_CooldownTable.Add(m_Target);
                    m_SouffleTable.Remove(m_Target);
					Stop();

                    new CooldownTimer(m_Target, TimeSpan.FromSeconds(dureeCooldown)).Start();
				}
			}
		}

        private class CooldownTimer : Timer
        {
            private Mobile m_Target;
            private DateTime m_End;

            public CooldownTimer(Mobile target, TimeSpan delay)
                : base(TimeSpan.FromSeconds(1.0), TimeSpan.FromSeconds(1.0))
            {
                m_Target = target;
                m_End = DateTime.Now + delay;

                Priority = TimerPriority.TwoFiftyMS;
            }

            protected override void OnTick()
            {
                if (m_Target.Deleted || !m_Target.Alive || DateTime.Now >= m_End)
                {
                    m_CooldownTable.Remove(m_Target);
                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private AdrenalineSpell m_Owner;

            public InternalTarget(AdrenalineSpell owner)
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