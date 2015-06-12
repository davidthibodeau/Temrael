using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using System.Collections.Generic;

namespace Server.Spells
{
	public class DernierSouffleSpell : Spell
	{
        public static int m_SpellID { get { return 605; } } // TOCHANGE

        private static short s_Cercle = 5;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Dernier souffle", "In Sanct Mani",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(2),
                SkillName.Thaumaturgie,
				Reagent.Garlic,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh
            );

		public DernierSouffleSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

        private const double dureeMax = 30;
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
            else if (m_SouffleTable.Contains(m) || m_CooldownTable.Contains(m))
            {
                Caster.SendMessage("Vous ne pouvez pas lancer le sort de nouveau sur cette cible avant un certain temps");
            }
            else if (CheckBSequence(m))
            {
                DoEffect(m);
            }

            FinishSequence();
        }

        private void DoEffect(Mobile m)
        {
            double duree = GetSpellScaling(Caster, Info.skillForCasting) * dureeMax;

            new ExpireTimer(m, TimeSpan.FromSeconds(duree)).Start();

            m_SouffleTable.Add(m);

            Effects.SendTargetParticles(m,0x3779, 9, 20, 5016, EffectLayer.Waist);
            m.PlaySound(0x1ED);
        }

        public static void GetOnHitEffect(Mobile def, ref double damage)
        {
            if (GetSouffle(def))
            {
                if (def.Hits <= 1)
                {
                    damage = 0;
                    Effects.SendTargetParticles(def,0x3779, 9, 20, 5016, EffectLayer.Waist);
                    def.PlaySound(0x1ED);
                }
                else if (def.Hits - damage < 1)
                {
                    damage = def.Hits - 1;
                    Effects.SendTargetParticles(def,0x3779, 9, 20, 5016, EffectLayer.Waist);
                    def.PlaySound(0x1ED);
                }
            }
        }

        public static bool GetSouffle(Mobile m)
        {
            if (m == null)
                return false;

            return m_SouffleTable.Contains(m);
        }

        private static HashSet<Mobile> m_SouffleTable = new HashSet<Mobile>();
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
                    m_Target.SendMessage("Votre dernier souffle a été rompu.");

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
            private DernierSouffleSpell m_Owner;

            public InternalTarget(DernierSouffleSpell owner)
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