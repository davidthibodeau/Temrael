using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class ChampEntropiqueSpell : Spell
	{
        public static int m_SpellID { get { return 408; } } // TOCHANGE

        private const int maxARbonus = 20;
        private const double dureeMax = 180;

        private static short s_Cercle = 2;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Champ Entropique", "Jux Sanct",
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

		public ChampEntropiqueSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
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

            m.AddBuff(new ChampEntropiqueBuff(value, (int)duree));

            Effects.SendTargetParticles(m,0x375A, 9, 20, 5016, EffectLayer.Waist);
            m.PlaySound(0x1ED);
        }

        private class ChampEntropiqueBuff : BaseBuff
        {
            private double value;

            public ChampEntropiqueBuff(double v, int duration)
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
                if (stat == BuffEffect.ResistanceMagique)
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

            public override void EndBuff(Mobile mobile)
            {                
            }
        }

        private class InternalTarget : Target
        {
            private ChampEntropiqueSpell m_Owner;

            public InternalTarget(ChampEntropiqueSpell owner)
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
