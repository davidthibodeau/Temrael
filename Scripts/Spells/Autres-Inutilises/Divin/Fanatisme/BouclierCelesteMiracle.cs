using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class BouclierCelesteMiracle : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_Timers = new Hashtable();

        public static readonly new SpellInfo Info = new SpellInfo(
                "Bouclier Celeste", "",
                4,
                17,
                9041
            );

        public BouclierCelesteMiracle(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
        {
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public override bool DelayedDamage { get { return false; } }

        public void Target(Mobile m)
        {
            /*if (Caster.MeleeDamageAbsorb > 0)
            {
                Caster.SendLocalizedMessage(1005559); // This spell is already in effect.
            }
            else if (!Caster.CanBeginAction(typeof(DefensiveSpell)))
            {
                Caster.SendLocalizedMessage(1005385); // The spell will not adhere to you at this time.
            }
            else if (CheckSequence())
            {
                if (Caster.BeginAction(typeof(DefensiveSpell)))
                {
                    double value = Caster.Skills[SkillName.ArtMagique].Value + Caster.Skills[SkillName.ArtMagique].Value;
                    value /= 3;

                    if (value < 0)
                        value = 1;
                    else if (value > 33)
                        value = 33;

                    value = SpellHelper.AdjustValue(Caster, value);

                    Caster.MeleeDamageAbsorb = (int)value;

                    Effects.SendTargetParticles(Caster,0x376A, 9, 32, 5008, EffectLayer.Waist);
                    Caster.PlaySound(0x1F2);
                }
                else
                {
                    Caster.SendLocalizedMessage(1005385); // The spell will not adhere to you at this time.
                }
            }
            */
            FinishSequence();
        }

        private class InternalTarget : Target
        {
            private BouclierCelesteMiracle m_Owner;

            public InternalTarget(BouclierCelesteMiracle owner)
                : base(12, false, TargetFlags.Beneficial)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile && o == from)
                {
                    m_Owner.Target((Mobile)o);
                }
                else
                    from.SendMessage("Vous ne pouvez cibler que vous-même avec ce sort.");
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}