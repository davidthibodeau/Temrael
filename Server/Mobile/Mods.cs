using System;

namespace Server
{
    #region [...]Mods
    public class TimedSkillMod : SkillMod
    {
        private DateTime m_Expire;

        public TimedSkillMod(SkillName skill, bool relative, double value, TimeSpan delay)
            : this(skill, relative, value, DateTime.Now + delay)
        {
        }

        public TimedSkillMod(SkillName skill, bool relative, double value, DateTime expire)
            : base(skill, relative, value)
        {
            m_Expire = expire;
        }

        public override bool CheckCondition()
        {
            return (DateTime.Now < m_Expire);
        }
    }

    public class EquipedSkillMod : SkillMod
    {
        private Item m_Item;
        private Mobile m_Mobile;

        public EquipedSkillMod(SkillName skill, bool relative, double value, Item item, Mobile mobile)
            : base(skill, relative, value)
        {
            m_Item = item;
            m_Mobile = mobile;
        }

        public override bool CheckCondition()
        {
            return (!m_Item.Deleted && !m_Mobile.Deleted && m_Item.Parent == m_Mobile);
        }
    }

    public class DefaultSkillMod : SkillMod
    {
        public DefaultSkillMod(SkillName skill, bool relative, double value)
            : base(skill, relative, value)
        {
        }

        public override bool CheckCondition()
        {
            return true;
        }
    }

    public abstract class SkillMod
    {
        private Mobile m_Owner;
        private SkillName m_Skill;
        private bool m_Relative;
        private double m_Value;
        private bool m_ObeyCap;

        protected SkillMod(SkillName skill, bool relative, double value)
        {
            m_Skill = skill;
            m_Relative = relative;
            m_Value = value;
        }

        public bool ObeyCap
        {
            get { return m_ObeyCap; }
            set
            {
                m_ObeyCap = value;

                if (m_Owner != null)
                {
                    Skill sk = m_Owner.Skills[m_Skill];

                    if (sk != null)
                        sk.Update();
                }
            }
        }

        public Mobile Owner
        {
            get
            {
                return m_Owner;
            }
            set
            {
                if (m_Owner != value)
                {
                    if (m_Owner != null)
                        m_Owner.RemoveSkillMod(this);

                    m_Owner = value;

                    if (m_Owner != value)
                        m_Owner.AddSkillMod(this);
                }
            }
        }

        public void Remove()
        {
            Owner = null;
        }

        public SkillName Skill
        {
            get
            {
                return m_Skill;
            }
            set
            {
                if (m_Skill != value)
                {
                    Skill oldUpdate = (m_Owner != null ? m_Owner.Skills[m_Skill] : null);

                    m_Skill = value;

                    if (m_Owner != null)
                    {
                        Skill sk = m_Owner.Skills[m_Skill];

                        if (sk != null)
                            sk.Update();
                    }

                    if (oldUpdate != null)
                        oldUpdate.Update();
                }
            }
        }

        public bool Relative
        {
            get
            {
                return m_Relative;
            }
            set
            {
                if (m_Relative != value)
                {
                    m_Relative = value;

                    if (m_Owner != null)
                    {
                        Skill sk = m_Owner.Skills[m_Skill];

                        if (sk != null)
                            sk.Update();
                    }
                }
            }
        }

        public bool Absolute
        {
            get
            {
                return !m_Relative;
            }
            set
            {
                if (m_Relative == value)
                {
                    m_Relative = !value;

                    if (m_Owner != null)
                    {
                        Skill sk = m_Owner.Skills[m_Skill];

                        if (sk != null)
                            sk.Update();
                    }
                }
            }
        }

        public double Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                if (m_Value != value)
                {
                    m_Value = value;

                    if (m_Owner != null)
                    {
                        Skill sk = m_Owner.Skills[m_Skill];

                        if (sk != null)
                            sk.Update();
                    }
                }
            }
        }

        public abstract bool CheckCondition();
    }

    public class ResistanceMod
    {
        private Mobile m_Owner;
        private ResistanceType m_Type;
        private int m_Offset;

        public Mobile Owner
        {
            get { return m_Owner; }
            set { m_Owner = value; }
        }

        public ResistanceType Type
        {
            get { return m_Type; }
            set
            {
                if (m_Type != value)
                {
                    m_Type = value;

                    if (m_Owner != null)
                        m_Owner.UpdateResistances();
                }
            }
        }

        public int Offset
        {
            get { return m_Offset; }
            set
            {
                if (m_Offset != value)
                {
                    m_Offset = value;

                    if (m_Owner != null)
                        m_Owner.UpdateResistances();
                }
            }
        }

        public ResistanceMod(ResistanceType type, int offset)
        {
            m_Type = type;
            m_Offset = offset;
        }
    }

    public class StatMod
    {
        private StatType m_Type;
        private string m_Name;
        private int m_Offset;
        private TimeSpan m_Duration;
        private DateTime m_Added;

        public StatType Type { get { return m_Type; } }
        public string Name { get { return m_Name; } }
        public int Offset { get { return m_Offset; } }

        public bool HasElapsed()
        {
            if (m_Duration == TimeSpan.Zero)
                return false;

            return (DateTime.Now - m_Added) >= m_Duration;
        }

        public StatMod(StatType type, string name, int offset, TimeSpan duration)
        {
            m_Type = type;
            m_Name = name;
            m_Offset = offset;
            m_Duration = duration;
            m_Added = DateTime.Now;
        }
    }

    #endregion
}