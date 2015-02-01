using System;
using System.IO;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Spells;
using Server.Network;

namespace Server.Items
{
    public enum TotemType
    {
        Aucun = 0,
        Amulette = 1,
        Refecteur,
        Miracle,
        Talisman, 
        BarilDeBiere,
        PointDeParesse,
        DonDesRochers,
        TrousseDeSecours,
        Couverture,
        Soutien
    }

    public class Totem : Item
    {
        private int m_MaxRange;
        private DateTime m_ToDelete;
        private Timer m_DeleteTimer;
        private Mobile m_Caster;
        private double m_Bonus;

        private int m_EffectID;
        private int m_EffectSpeed;
        private int m_EffectDuration;
        private EffectLayer m_EffectLayer;
        private int m_SoundID;

        private TotemType m_TotemType;

        [CommandProperty(AccessLevel.Batisseur)]
        public int MaxRange
        {
            get { return m_MaxRange; }
            set { m_MaxRange = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public DateTime ToDelete
        {
            get { return m_ToDelete; }
            set { m_ToDelete = value; }
        }

        public Timer DeleteTimer
        {
            get { return m_DeleteTimer; }
            set { m_DeleteTimer = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public Mobile Caster
        {
            get { return m_Caster; }
            set { m_Caster = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public double Bonus
        {
            get { return m_Bonus; }
            set 
                { 
                    m_Bonus = value;

                    if (m_Bonus <= 0)
                        Delete();
                }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int EffectID
        {
            get { return m_EffectID; }
            set { m_EffectID = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int EffectSpeed
        {
            get { return m_EffectSpeed; }
            set { m_EffectSpeed = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int EffectDuration
        {
            get { return m_EffectDuration; }
            set { m_EffectDuration = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public EffectLayer EffectLayer
        {
            get { return m_EffectLayer; }
            set { m_EffectLayer = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int SoundID
        {
            get { return m_SoundID; }
            set { m_SoundID = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public TotemType TotemType
        {
            get { return m_TotemType; }
            set { m_TotemType = value; }
        }

        [Constructable]
        public Totem(int ItemID, string name, int hue, int maxrange, TotemType type, DateTime todelete, Mobile caster, double bonus, int effectid, int effectspeed, int effectduration, EffectLayer effectlayer, int soundid)
            : base(ItemID)
        {
            Name = name;
            Hue = hue;
            Movable = false;
            Visible = true;

            MaxRange = maxrange;
            ToDelete = todelete;
            Caster = caster;
            Bonus = bonus;
            EffectID = effectid;
            EffectSpeed = effectspeed;
            EffectDuration = effectduration;
            EffectLayer = effectlayer;
            SoundID = soundid;

            TotemType = type;

            if (m_DeleteTimer == null)
            {
                m_DeleteTimer = new DeleteTotemTimer(this);
                m_DeleteTimer.Start();
            }

            foreach (Mobile m in this.GetMobilesInRange(20))
            {
                m.InvalidateProperties();
                m.Delta(MobileDelta.Armor);
            }
        }

        public Totem(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);

            writer.Write(m_MaxRange);
            writer.Write(m_ToDelete);
            writer.Write(m_Caster);
            writer.Write(m_Bonus);

            writer.Write(m_EffectID);
            writer.Write(m_EffectSpeed);
            writer.Write(m_EffectDuration);
            writer.Write((int)m_EffectLayer);
            writer.Write(m_SoundID);

            writer.Write((int)m_TotemType);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_MaxRange = reader.ReadInt();
            m_ToDelete = reader.ReadDateTime();
            m_Caster = reader.ReadMobile();
            m_Bonus = reader.ReadDouble();

            m_EffectID = reader.ReadInt();
            m_EffectSpeed = reader.ReadInt();
            m_EffectDuration = reader.ReadInt();
            m_EffectLayer = (EffectLayer)reader.ReadInt();
            m_SoundID = reader.ReadInt();

            m_TotemType = (TotemType)reader.ReadInt();

            if (m_DeleteTimer == null)
            {
                m_DeleteTimer = new DeleteTotemTimer(this);
                m_DeleteTimer.Start();
            }

            if (m_TotemType == TotemType.Refecteur)
                new RefecteurSpell.RefecteurTimer(this).Start();

            if (m_TotemType == TotemType.Miracle)
                new MiracleSpell.MiracleTimer(this).Start();

            if (m_TotemType == TotemType.PointDeParesse)
                new PointDeParesseSpell.PointDeParesseTimer(this).Start();

            foreach (Mobile m in this.GetMobilesInRange(20))
            {
                m.InvalidateProperties();
                m.Delta(MobileDelta.Armor);
            }
        }

        public void FixedParticles(int itemID, int speed, int duration, int effect, int hue, int renderMode, EffectLayer layer)
        {
            Effects.SendLocationEffect(this, this.Map, itemID, duration, speed, hue, renderMode);
        }

        public void PlaySound(int soundid)
        {
            Effects.PlaySound(this.Location, this.Map, soundid);
        }

        public override void OnDelete()
        {
            foreach (Mobile m in this.GetMobilesInRange(20))
            {
                m.InvalidateProperties();
                m.Delta(MobileDelta.Armor);
            }
        }

        public class DeleteTotemTimer : Timer
        {
            private Totem m_Point;

            public DeleteTotemTimer(Totem point)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(10))
            {
                m_Point = point;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if (m_Point == null || m_Point.Deleted || m_Point.Caster == null)
                {
                    Stop();
                }
                else if (DateTime.Now >= m_Point.ToDelete)
                {
                    m_Point.Delete();
                    Stop();
                }
            }
        }
    }
}