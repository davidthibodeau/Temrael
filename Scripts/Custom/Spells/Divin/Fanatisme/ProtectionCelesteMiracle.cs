using System;
using System.Collections;
using Server.Mobiles;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Spells
{
    public class ProtectionCelesteMiracle : ReligiousSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
                "Protection Celeste", "",
                SpellCircle.Eighth,
                17,
                9031
            );

        public override int RequiredAptitudeValue { get { return 8; } }
        public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Fanatisme }; } }

        public ProtectionCelesteMiracle(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public void Target(Mobile m)
        {
            if (!(m is BaseCreature || m is TMobile))
            {
                Caster.SendLocalizedMessage(1060508); // You can't curse that.
            }
            else if (CheckHSequence(m))
            {
                SpellHelper.Turn(Caster, m);

                m.FixedParticles(14170, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.FixedParticles(14201, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(514);

                StatMod[] mods = (StatMod[])m_Table[m];

                if (mods == null)
                {
                    mods = new StatMod[]
                    {
                        new StatMod( StatType.Str, "Protection Celeste", (int)(Caster.Skills[CastSkill].Value / 5), TimeSpan.FromSeconds((int)(Caster.Skills[CastSkill].Value / 2)) ),
                        new StatMod( StatType.Dex, "Protection Celeste", (int)(Caster.Skills[CastSkill].Value / 5), TimeSpan.FromSeconds((int)(Caster.Skills[CastSkill].Value / 2)) ),
                        new StatMod( StatType.Con, "Protection Celeste", (int)(Caster.Skills[CastSkill].Value / 5), TimeSpan.FromSeconds((int)(Caster.Skills[CastSkill].Value / 2)) )
                    };

                    for (int i = 0; i < mods.Length; ++i)
                        m.AddStatMod(mods[i]);

                    m_Table[m] = mods;
                }
            }

            FinishSequence();
        }

        private static Hashtable m_Table = new Hashtable();

        private class InternalTarget : Target
        {
            private ProtectionCelesteMiracle m_Owner;

            public InternalTarget(ProtectionCelesteMiracle owner)
                : base(12, false, TargetFlags.Beneficial)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile)
                    m_Owner.Target((Mobile)o);
                else
                    from.SendLocalizedMessage(1060508); // You can't curse that.
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}