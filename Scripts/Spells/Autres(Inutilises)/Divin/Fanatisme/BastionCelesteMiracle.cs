using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class BastionCelesteMiracle : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_Timers = new Hashtable();
        private static Hashtable m_Table = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Bastion Celeste", "",
                SpellCircle.Fifth,
                17,
                9041
            );

        public BastionCelesteMiracle(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public override bool DelayedDamage { get { return false; } }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckSequence())
            {
                SpellHelper.Turn(Caster, m);

                StopTimer(m);

                ResistanceMod[] mods = (ResistanceMod[])m_Table[m];

                if (mods == null)
                {
                    mods = new ResistanceMod[]
                    {
                        new ResistanceMod(ResistanceType.Magie, (int)(Caster.Skills[CastSkill].Value / 4) ),
                    };

                    for (int i = 0; i < mods.Length; ++i)
                        m.AddResistanceMod(mods[i]);

                    m_Table[m] = mods;

                    TimeSpan duration = GetDurationForSpell(0.5);

                    new BastionCelesteMiracle.InternalTimer(m, duration).Start();
                }

                FinishSequence();
            }
        }

        public static void StopTimer(Mobile m)
        {
            ResistanceMod[] mods = (ResistanceMod[])m_Table[m];

            if (mods != null)
            {
                for (int i = 0; i < mods.Length; ++i)
                    m.RemoveResistanceMod(mods[i]);

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

                ResistanceMod[] mods = (ResistanceMod[])m_Table[target];

                target.FixedParticles(14170, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                target.FixedParticles(14201, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                target.PlaySound(514);

                m_Table.Remove(target);

                for (int i = 0; i < mods.Length; ++i)
                    target.RemoveResistanceMod(mods[i]);
            }
        }

        private class InternalTarget : Target
        {
            private BastionCelesteMiracle m_Owner;

            public InternalTarget(BastionCelesteMiracle owner)
                : base(12, false, TargetFlags.Beneficial)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile && from != o)
                {
                    m_Owner.Target((Mobile)o);
                }
                else
                    from.SendMessage("Vous ne pouvez pas vous cibler.");
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}