using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class AffaiblissementSpell : Spell
	{
        public static int m_SpellID { get { return 808; } } // TOCHANGE

        private const int maxARbonus = 10;
        private const double dureeMax = 60;

        private static short s_Cercle = 5;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Affaiblissement", "An Sanct",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(4),
                SkillName.Providence,
				Reagent.Garlic,
				Reagent.Nightshade,
				Reagent.SulfurousAsh
            );

		public AffaiblissementSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

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
            double value = GetSpellScaling(Caster, Info.skillForCasting) * maxARbonus;
            double duree = GetSpellScaling(Caster, Info.skillForCasting) * dureeMax;

            new InternalTimer(m, (int)value, duree).Start();

            m.FixedParticles(0x375A, 9, 20, 5016, EffectLayer.Waist);
            m.PlaySound(0x1ED);
        }

        private class InternalTimer : Timer
        {
            private ResistanceMod m_resModPhys;
            private ResistanceMod m_resModMag;
            private Mobile m_Owner;

            public InternalTimer(Mobile caster, int value, double duree) : base(TimeSpan.FromSeconds(duree))
            {
                Priority = TimerPriority.OneSecond;

                m_Owner = caster;

                m_resModMag = new ResistanceMod(ResistanceType.Magie, -1 * (int)value);
                m_Owner.AddResistanceMod(m_resModMag);
                m_resModPhys = new ResistanceMod(ResistanceType.Physical, -1 * (int)value);
                m_Owner.AddResistanceMod(m_resModPhys);
            }

            protected override void OnTick()
            {
                m_Owner.RemoveResistanceMod(m_resModPhys);
                m_Owner.RemoveResistanceMod(m_resModMag);
            }
        }

        private class InternalTarget : Target
        {
            private AffaiblissementSpell m_Owner;

            public InternalTarget(AffaiblissementSpell owner)
                : base(12, false, TargetFlags.Harmful)
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
