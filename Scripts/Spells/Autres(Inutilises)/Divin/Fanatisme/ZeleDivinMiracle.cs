using System;
using System.Collections;
using Server.Mobiles;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Spells
{
    public class ZeleDivinMiracle : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static readonly SpellInfo m_Info = new SpellInfo(
                "Zele Divin", "",
                SpellCircle.Eighth,
                17,
                9031
            );

        public ZeleDivinMiracle(Mobile caster, Item scroll)
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

                SkillMod[] mods = (SkillMod[])m_Table[m];

                if (mods == null)
                {
                    mods = new SkillMod[]
                    {
                        new DefaultSkillMod( SkillName.Tactiques, false, m.Skills[SkillName.Tactiques].Base + (Caster.Skills[CastSkill].Value / 2) ),
                        new DefaultSkillMod( SkillName.Parer, false, m.Skills[SkillName.Parer].Base + (Caster.Skills[CastSkill].Value / 2) ),
                        new DefaultSkillMod( SkillName.ArmeTranchante, false, m.Skills[SkillName.ArmeTranchante].Base + (Caster.Skills[CastSkill].Value / 2) ),
                        new DefaultSkillMod( SkillName.ArmeHaste, false, m.Skills[SkillName.ArmeHaste].Base + (Caster.Skills[CastSkill].Value / 2) ),
                        new DefaultSkillMod( SkillName.ArmeDistance, false, m.Skills[SkillName.ArmeDistance].Base + (Caster.Skills[CastSkill].Value / 2) ),
                        new DefaultSkillMod( SkillName.ArmePerforante, false, m.Skills[SkillName.ArmePerforante].Base + (Caster.Skills[CastSkill].Value / 2) ),
                        new DefaultSkillMod( SkillName.Anatomie, false, m.Skills[SkillName.Anatomie].Base + (Caster.Skills[CastSkill].Value / 2) ),
                        new DefaultSkillMod( SkillName.Equitation, false, m.Skills[SkillName.Equitation].Base + (Caster.Skills[CastSkill].Value / 2) ),
                        new DefaultSkillMod( SkillName.ArmeContondante, false, m.Skills[SkillName.ArmeContondante].Base + (Caster.Skills[CastSkill].Value / 2) )
                    };

                    for (int i = 0; i < mods.Length; ++i)
                        m.AddSkillMod(mods[i]);

                    m_Table[m] = mods;

                    TimeSpan duration = GetDurationForSpell(0.5);

                    new ZeleDivinMiracle.InternalTimer(m, duration).Start();
                }
            }

            FinishSequence();
        }

        private static Hashtable m_Table = new Hashtable();

        public static void StopTimer(Mobile m)
        {
            SkillMod[] mods = (SkillMod[])m_Table[m];

            if (mods != null)
            {
                for (int i = 0; i < mods.Length; ++i)
                    m.RemoveSkillMod(mods[i]);

                m.FixedParticles(14170, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.FixedParticles(14201, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(514);

                m_Table.Remove(m);
            }
        }

        private class InternalTimer : Timer
        {
            private Mobile target;

            public InternalTimer(Mobile targ, TimeSpan duration)
                : base(duration)
            {
                target = targ;
            }

            protected override void OnTick()
            {
                if (target == null || target.Deleted)
                    return;

                SkillMod[] mods = (SkillMod[])m_Table[target];

                target.FixedParticles(14170, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                target.FixedParticles(14201, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                target.PlaySound(514);

                m_Table.Remove(target);

                for (int i = 0; i < mods.Length; ++i)
                    target.RemoveSkillMod(mods[i]);
            }
        }

        private class InternalTarget : Target
        {
            private ZeleDivinMiracle m_Owner;

            public InternalTarget(ZeleDivinMiracle owner)
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