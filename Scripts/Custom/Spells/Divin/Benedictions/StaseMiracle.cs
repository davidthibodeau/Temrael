using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.Fifth
{
    public class StaseMiracle : ReligiousSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
                "Stase", "",
                SpellCircle.Sixth,
                17,
                9012
            );

        public override int RequiredAptitudeValue { get { return 6; } }
        public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Benedictions }; } }

        public StaseMiracle(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckHSequence(m))
            {
                SpellHelper.Turn(Caster, m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                double duration = 5.0 + (Caster.Skills[SkillName.Miracles].Value * 0.2);

                duration = SpellHelper.AdjustValue(Caster, duration, Aptitude.FaveurDivine);

                if (CheckResisted(m))
                    duration *= 0.75;

                m.Paralyze(TimeSpan.FromSeconds(duration));

                m.PlaySound(0x204);
                m.FixedEffect(0x376A, 6, 1);
            }

            FinishSequence();
        }

        public class InternalTarget : Target
        {
            private StaseMiracle m_Owner;

            public InternalTarget(StaseMiracle owner)
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
    }
}