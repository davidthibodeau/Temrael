using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class VoodooSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static readonly new SpellInfo Info = new SpellInfo(
                "Voodoo", "Ota Desi Maga",
                8,
                212,
                9041
            );

        public VoodooSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
        {
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public override bool DelayedDamage { get { return false; } }

        public void Target(PlayerMobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckSequence())
            {
                SpellHelper.Turn(Caster, m);

                TimeSpan duration = TimeSpan.FromSeconds(0);

                m.Freeze(duration);

                m.FixedParticles(2339, 10, 15, 5013, 1328, 0, EffectLayer.CenterFeet);
                m.PlaySound(527);
            }

            FinishSequence();
        }

        private class InternalTarget : Target
        {
            private VoodooSpell m_Owner;

            public InternalTarget(VoodooSpell owner)
                : base(12, false, TargetFlags.Beneficial)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is PlayerMobile)
                {
                    m_Owner.Target((PlayerMobile)o);
                }
                else
                    from.SendMessage("Vous ne pouvez que cibler les joueurs!");
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}