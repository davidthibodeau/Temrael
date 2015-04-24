using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class PeauDePierreSpell : Spell
	{
        public static int m_SpellID { get { return 402; } } // TOCHANGE

        private const int maxARbonus = 20;
        private const double dureeMax = 180;

        private static short s_Cercle = 2;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Peau de pierre", "Uus Sanct",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(4),
                SkillName.Providence,
				Reagent.Garlic,
				Reagent.Ginseng,
				Reagent.SulfurousAsh
            );

		public PeauDePierreSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
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

            m.AddBuff(new PeauDePierreBuff(value, (int)duree));

            Effects.SendTargetParticles(m,0x375A, 9, 20, 5016, EffectLayer.Waist);
            m.PlaySound(0x1ED);
        }

        private class PeauDePierreBuff : BaseBuff
        {
            private double value;

            public PeauDePierreBuff(double v, int duration)
                : base(new TimeSpan(0, 0, duration))
            {
                value = v;
            }

            protected override BuffEffect effect
            {
                get { return BuffEffect.ResistanceMagique; }
            }

            public override double Effect(BuffEffect stat)
            {
                if (stat == BuffEffect.ResistancePhysique)
                    return value;
                return 0;
            }

            public override BuffID Id
            {
                get { return BuffID.ResistanceBuffSpell; }
            }

            public override int CompareTo(object obj)
            {
                return 0;
            }
        }

        //private class InternalTimer : Timer
        //{
        //    private ResistanceMod m_resMod;
        //    private Mobile m_Owner;

        //    public InternalTimer(Mobile caster, int value, double duree) : base(TimeSpan.FromSeconds(duree))
        //    {
        //        Priority = TimerPriority.OneSecond;

        //        m_Owner = caster;

        //        m_resMod = new ResistanceMod(ResistanceType.Physical, (int)value);
        //        m_Owner.AddResistanceMod(m_resMod);
        //    }

        //    protected override void OnTick()
        //    {
        //        m_Owner.RemoveResistanceMod(m_resMod);

        //        m_Owner.SendMessage("Peau de pierre prend fin.");
        //    }
        //}

        private class InternalTarget : Target
        {
            private PeauDePierreSpell m_Owner;

            public InternalTarget(PeauDePierreSpell owner)
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
