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
        private const double TempsJetReussit = 0.0; // Si le jet reussit, jet automatique de stealth.
        private const double TempsJetRate = 10.0;   // Si le jet a raté.
        private const double TempsJetImposs = 0.0;

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
                m.RevealingAction();

            if (m.Spell != null)
            {
                m.SendLocalizedMessage(501238); // You are busy doing something else and cannot hide.
                return TimeSpan.FromSeconds(TempsJetImposs);
            }

            //int range = 18 - (int)(m.Skills[SkillName.Discretion].Value / 10);
            int range = Math.Min((int)((100 - m.Skills[SkillName.Discretion].Value) / 2) + 8, 18);	//Cap of 18 not OSI-exact, intentional difference

            bool badCombat = (!m_CombatOverride && m.Combatant != null && m.InRange(m.Combatant.Location, range) && m.Combatant.InLOS(m));
            bool ok = !badCombat && (!m.Mounted);

            int dexDiff = (m.Dex - m.RawDex); // Malus de dex avec l'armure ?

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
            }
            else
            {
                if (ok)
                {
                    m.Hidden = true;
                    m.Warmode = false;
                    m.LocalOverheadMessage(MessageType.Regular, 0x1F4, 501240); // You have hidden yourself well.
                    Stealth.OnUse(m);
                    return TimeSpan.FromSeconds(TempsJetReussit);
                }
                else
                {
                    m.LocalOverheadMessage(MessageType.Regular, 0x22, 501241); // You can't seem to hide here.
                }
            }

            m.RevealingAction();
            return TimeSpan.FromSeconds(TempsJetRate);
        }
    }
}