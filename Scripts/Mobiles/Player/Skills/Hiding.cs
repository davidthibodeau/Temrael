using System;
using Server.Targeting;
using Server.Items;
using Server.Network;
using Server.Multis;
using Server.Spells;

namespace Server.SkillHandlers
{
    public class Hiding
    {
        private static TimeSpan TempsJetReussit = TimeSpan.FromSeconds(0);
        private static TimeSpan TempsJetRate = TimeSpan.FromSeconds(10);
        private static TimeSpan TempsJetImposs = TimeSpan.FromSeconds(0);  // Si le jet ne peut pas être fait pour une raison extérieure ( Joueur en combat, En train de caster )

        private static bool m_CombatOverride;

        public static bool CombatOverride
        {
            get { return m_CombatOverride; }
            set { m_CombatOverride = value; }
        }

        public static void Initialize()
        {
            SkillInfo.Table[(int)SkillName.Discretion].Callback = new SkillUseCallback( OnUse );
        }

        public static TimeSpan OnUse(Mobile m)
        {
            if (m.Hidden)
            {
                m.Hidden = false;
                return TempsJetRate;
            }

            if (m.Spell != null)
            {
                m.SendLocalizedMessage(501238); // You are busy doing something else and cannot hide.
                return TempsJetImposs;
            }

            int range = Math.Min((int)((100 - m.Skills[SkillName.Discretion].Value) / 2) + 8, 18);

            bool badCombat = (!m_CombatOverride && m.Combatant != null && m.InRange(m.Combatant.Location, range) && m.Combatant.InLOS(m));
            bool ok = !badCombat && (!m.Mounted);


            // Pour éviter le hide in the face en combat.
            if (ok)
            {
                if (!m_CombatOverride)
                {
                    foreach (Mobile check in m.GetMobilesInRange(range))
                    {
                        if (check.InLOS(m) && check.Combatant == m)
                        {
                            badCombat = true;
                            ok = false;
                            break;
                        }
                    }
                }

                ok = (!badCombat && m.CheckSkill(SkillName.Discretion, 0.0, 100.0));
            }

            if (badCombat)
            {
                m.LocalOverheadMessage(MessageType.Regular, 0x22, 501237); // You can't seem to hide right now.
                return TempsJetImposs;
            }
            else
            {
                if (ok)
                {
                    m.Hidden = true;
                    m.Warmode = false;
                    m.LocalOverheadMessage(MessageType.Regular, 0x1F4, 501240); // You have hidden yourself well.
                    return TempsJetReussit;
                }
                else
                {
                    m.LocalOverheadMessage(MessageType.Regular, 0x22, 501241); // You can't seem to hide here.
                    m.RevealingAction();
                    return TempsJetRate;
                }
            }
        }
    }
}