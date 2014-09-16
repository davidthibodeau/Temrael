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
            if (!m.Hidden)
            {

                if (m.Spell != null)
                {
                    m.SendLocalizedMessage(501238); // You are busy doing something else and cannot hide.
                    return TimeSpan.FromSeconds(TempsJetImposs);
                }

                if (Core.ML && m.Target != null)
                {
                    Targeting.Target.Cancel(m);
                }

                double bonus = 0.0;

                #region Bonus de House (AOS). --- On le garde.. ?
                BaseHouse house = BaseHouse.FindHouseAt(m);

                if (house != null && house.IsFriend(m))
                {
                    bonus = 100.0;
                }
                else if (!Core.AOS)
                {
                    if (house == null)
                        house = BaseHouse.FindHouseAt(new Point3D(m.X - 1, m.Y, 127), m.Map, 16);

                    if (house == null)
                        house = BaseHouse.FindHouseAt(new Point3D(m.X + 1, m.Y, 127), m.Map, 16);

                    if (house == null)
                        house = BaseHouse.FindHouseAt(new Point3D(m.X, m.Y - 1, 127), m.Map, 16);

                    if (house == null)
                        house = BaseHouse.FindHouseAt(new Point3D(m.X, m.Y + 1, 127), m.Map, 16);

                    if (house != null)
                        bonus = 50.0;
                }
                #endregion


                if (MurmureSpell.m_MurmureTable.Contains(m))
                    bonus += (double)MurmureSpell.m_MurmureTable[m];

                //int range = 18 - (int)(m.Skills[SkillName.Discretion].Value / 10);
                int range = Math.Min((int)((100 - m.Skills[SkillName.Discretion].Value) / 2) + 8, 18);	//Cap of 18 not OSI-exact, intentional difference

                bool badCombat = (!m_CombatOverride && m.Combatant != null && m.InRange(m.Combatant.Location, range) && m.Combatant.InLOS(m));
                bool ok = (!badCombat && (!m.Mounted) /*&& m.CheckSkill( SkillName.Discretion, 0.0 - bonus, 100.0 - bonus )*/ );

                #region Malus de dex, dépendant des bonus/malus de dex comparé à la dex normale.

                int dexDiff = (m.Dex - m.RawDex);


                #endregion




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

                    ok = (!badCombat && m.CheckSkill(SkillName.Discretion, 0.0 - bonus, 100.0 - bonus));
                }

                if (badCombat)
                {
                    m.RevealingAction();
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
                        m.RevealingAction();

                        m.LocalOverheadMessage(MessageType.Regular, 0x22, 501241); // You can't seem to hide here.
                    }
                }
            }
            else
            {
                m.RevealingAction();
            }
            return TimeSpan.FromSeconds(TempsJetRate);
        }
    }
}