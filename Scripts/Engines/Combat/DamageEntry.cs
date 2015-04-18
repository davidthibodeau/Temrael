using Server;
using System;
using System.Collections.Generic;

namespace Server.Engines.Combat
{
    public enum VisibleDamageType
    {
        None,
        Related,
        Everyone,
        Selective
    }

    public class DamageEntry
    {
        private Mobile m_Damager;
        private int m_DamageGiven;
        private DateTime m_LastDamage;
        private List<DamageEntry> m_Responsible;

        public Mobile Damager { get { return m_Damager; } }

        public int DamageGiven { get { return m_DamageGiven; } set { m_DamageGiven = value; } }

        public DateTime LastDamage { get { return m_LastDamage; } set { m_LastDamage = value; } }

        public bool HasExpired { get { return (DateTime.Now > (m_LastDamage + m_ExpireDelay)); } }

        public List<DamageEntry> Responsible { get { return m_Responsible; } set { m_Responsible = value; } }

        private static TimeSpan m_ExpireDelay = TimeSpan.FromMinutes(2.0);

        public static TimeSpan ExpireDelay
        {
            get { return m_ExpireDelay; }
            set { m_ExpireDelay = value; }
        }

        public DamageEntry(Mobile damager)
        {
            m_Damager = damager;
        }
    }
}