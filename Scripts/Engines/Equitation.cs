using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Mobiles;
using Server.Movement;

namespace Server.Engines.Equitation
{

    public enum EquitationType
    {
        Attacking,
        Running,
        BeingAttacked,
        Ranged,
        Cast,
    }

    static class Equitation
    {
        #region Balancement

        private static double[] m_AttackingTable = new double[] { 0.501, 0.161, 0.051, 0.021,
            0.011, 0.001, 0.001, 0.001, 0.001, 0.001, 0.001 };

        private static double[] m_RunningTable = new double[] { 0.251, 0.161, 0.081, 0.051,
            0.021, 0.011, 0.011, 0.001, 0.000, 0.000, 0.000 };

        private static double[] m_BeingAttackedTable = new double[] { 0.501, 0.501, 0.501, 0.501,
            0.501, 0.501, 0.121, 0.051, 0.021, 0.011, 0.001 };

        private static double[] m_RangedAttackTable = new double[] { 0.501, 0.501, 0.501, 0.501,
            0.501, 0.501, 0.121, 0.051, 0.021, 0.011, 0.001 };

        private static double[] m_CastingTable = new double[] { 0.501, 0.501, 0.501, 0.501,
            0.501, 0.501, 0.121, 0.051, 0.021, 0.011, 0.001 };

        #endregion

        static public bool CheckEquitation(Mobile m, EquitationType type)
        {
            return CheckEquitation(m, type, 0);
        }

        static public bool CheckEquitation(Mobile m, EquitationType type, double malus)
        {
            if (m.AccessLevel >= AccessLevel.Batisseur)
                return true;

            if (!m.Mounted)
                return true;

            // Si on veut tester le running mais que le personnage ne courre pas.
            if (type == EquitationType.Running && (m.Direction & Direction.Running) == 0)
                return true;

            if (m.Map == null)
                return true;


            int equitation = ((int)m.Skills.Equitation.Value / 10);
            if (equitation < 0)
                equitation = 0;

            double chance = 0;
            switch (type)
            {
                case EquitationType.Attacking: chance = m_AttackingTable[equitation]; break;
                case EquitationType.Running: chance = m_RunningTable[equitation]; break;
                case EquitationType.BeingAttacked: chance = m_BeingAttackedTable[equitation]; break;
                case EquitationType.Cast: chance = m_CastingTable[equitation]; break;
                case EquitationType.Ranged: chance = m_RangedAttackTable[equitation]; break;
            }

            chance += malus;

            // Si le personnage rate son jet.
            if (chance >= Utility.RandomDouble())
            {
                TileType tile = Deplacement.GetTileType((Mobile)m);

                // Si on ne veut pas tester la course, plante.
                if (type != EquitationType.Running)
                {
                    Fall(m, (BaseMount)m.Mount);
                    return false;
                }
                // Si on veut tester la course, on vérifie la case, puis plante si ce n'est pas quelque chose de normal.
                else if (tile != TileType.Other && tile != TileType.Dirt)
                {
                    Fall(m, (BaseMount)m.Mount);
                    return false;
                }
            }
            return true;
        }

        static private void Fall(Mobile m, BaseMount mount)
        {
            mount.Rider = null;
            mount.Location = m.Location;

            mount.Animate(5, 5, 1, true, false, 0);
            m.Animate(22, 5, 1, true, false, 0);

            m.Damage(( m.HitsMax * 20 / 100 ));

            m.BeginAction(typeof(BaseMount));
            m.EndAction(typeof(BaseMount));

            mount.NextMountAbility = DateTime.Now.AddSeconds(12 - m.Skills.Equitation.Value / 10);
            mount.ControlOrder = OrderType.Stop;
        }
    }
}
