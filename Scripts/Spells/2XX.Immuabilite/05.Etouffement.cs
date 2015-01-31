using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Spells
{
    class EtouffementSpell : Spell
    {
        public static int m_SpellID { get { return 205; } }

        public readonly static Hashtable m_Table = new Hashtable();

        private static short s_Cercle = 4;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Étouffement", "In Bal Vrii",
                s_Cercle,
				209,
				9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(3),
                SkillName.Immuabilite,
				Reagent.DaemonBlood,
				Reagent.NoxCrystal
            );

        public EtouffementSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public void Target(Mobile m)
        {
            if (CheckHSequence(m))
            {
                SpellHelper.Turn(Caster, m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                m.PlaySound(0x22F);
                Effects.SendTargetParticles(m,0x36CB, 1, 9, 9911, 67, 5, EffectLayer.Head);
                Effects.SendTargetParticles(m,0x374A, 1, 17, 9502, 1108, 4, (EffectLayer)255);

                int baseDuration = 40;

                TimeSpan duration = TimeSpan.FromSeconds(baseDuration * Spell.GetSpellScaling(Caster, Info.skillForCasting));
                int PourcentRate = 30;

                if (!m_Table.Contains(m))
                {
                    m_Table.Add(m, PourcentRate);
                    new EtouffementTimer(m, duration).Start();
                }
                else
                    Caster.SendMessage("Ce personnage est déjà affecté par ce sort.");
            }

            FinishSequence();
        }

        public static void RemoveBonus(Mobile m)
        {
            if (m_Table.Contains(m))
                m_Table.Remove(m);
        }

        private class InternalTarget : Target
        {
            private EtouffementSpell m_Owner;

            public InternalTarget(EtouffementSpell owner)
                : base(12, false, TargetFlags.Harmful)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile)
                    m_Owner.Target((Mobile)o);
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }

        private class EtouffementTimer : Timer
        {
            private Mobile m_Mobile;

            public EtouffementTimer(Mobile m, TimeSpan duration)
                : base(duration)
            {
                Priority = TimerPriority.TwentyFiveMS;
                m_Mobile = m;
            }

            protected override void OnTick()
            {
                EtouffementSpell.RemoveBonus(m_Mobile);
            }
        }
    }
}
