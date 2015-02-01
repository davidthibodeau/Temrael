using System;
using Server.Network;
using Server.Mobiles;

namespace Server.Items
{
	public enum ECEffectType
	{
		None,
		Moving,
		Location,
		Target,
		Lightning
	}

	public enum EffectTriggerType
	{
		None,
		Sequenced,
		DoubleClick,
		InRange
	}

	public class EffectController : Item
    {
        #region IActivable
        public override void IActivableOnActivate(int mode, Mobile from, int overflow)
        {
            DoEffect(from, overflow);
        }
        #endregion

        #region Activate un IActivable.
        private int m_ActivateMode;
        private Item m_ActivateItem;

        [CommandProperty(AccessLevel.Batisseur)]
        public int ActivateMode { get { return m_ActivateMode; } set { m_ActivateMode = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public Item ActivateItem { get { return m_ActivateItem; } set { m_ActivateItem = value; } }
        #endregion

        #region Source / Target
        private IEntity m_Source;
		private IEntity m_Target;

        [CommandProperty(AccessLevel.Batisseur)]
        public Item SourceItem { get { return m_Source as Item; } set { m_Source = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public Mobile SourceMobile { get { return m_Source as Mobile; } set { m_Source = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public bool SourceNull { get { return (m_Source == null); } set { if (value) m_Source = null; } }


        [CommandProperty(AccessLevel.Batisseur)]
        public Item TargetItem { get { return m_Target as Item; } set { m_Target = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public Mobile TargetMobile { get { return m_Target as Mobile; } set { m_Target = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public bool TargetNull { get { return (m_Target == null); } set { if (value) m_Target = null; } }
        #endregion

        #region Cooldown
        private TimeSpan m_Cooldown;
        private DateTime m_LastEffect;

        [CommandProperty(AccessLevel.Batisseur)]
        public TimeSpan Cooldown { get { return m_Cooldown; } set { m_Cooldown = value; } }
        #endregion

        #region Message
        private TimeSpan m_MessageDelay;
        private bool m_MessageAtTrigger;
        private string m_Message;

        [CommandProperty(AccessLevel.Batisseur)]
        public TimeSpan MessageDelay { get { return m_MessageDelay; } set { m_MessageDelay = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public bool MessageAtTrigger { get { return m_MessageAtTrigger; } set { m_MessageAtTrigger = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public string Message { get { return m_Message; } set { m_Message = value; } }
        #endregion

        #region Missile
        private ECEffectType m_MissileEffectType;
        private int m_MissileItemID;
		private int m_MissileHue;
        private int m_MissileRenderMode;
		private int m_MissileSpeed;
		private int m_MissileDuration;
        private TimeSpan m_MissileDelay;
		private bool m_MissileFixedDirection;
		private bool m_MissileExplodes;
		private int m_MissileParticleEffect;
		private int m_MissileExplodeParticleEffect;
		private int m_MissileExplodesound;
		private EffectLayer m_MissileEffectLayer;
		private int m_MissileUnknown;

        [CommandProperty(AccessLevel.Batisseur)]
        public ECEffectType MissileEffectType { get { return m_MissileEffectType; } set { m_MissileEffectType = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public EffectLayer MissileEffectLayer { get { return m_MissileEffectLayer; } set { m_MissileEffectLayer = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        private bool MissileFixedDirection { get { return m_MissileFixedDirection; } set { m_MissileFixedDirection = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        private bool MissileExplodes { get { return m_MissileExplodes; } set { m_MissileExplodes = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int MissileItemID { get { return m_MissileItemID; } set { m_MissileItemID = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int MissileHue { get { return m_MissileHue; } set { m_MissileHue = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int MissileRenderMode { get { return m_MissileRenderMode; } set { m_MissileRenderMode = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int MissileSpeed { get { return m_MissileSpeed; } set { m_MissileSpeed = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int MissileDuration { get { return m_MissileDuration; } set { m_MissileDuration = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public TimeSpan MissileDelay { get { return m_MissileDelay; } set { m_MissileDelay = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int MissileParticleEffect { get { return m_MissileParticleEffect; } set { m_MissileParticleEffect = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int MissileExplodeParticleEffect { get { return m_MissileExplodeParticleEffect; } set { m_MissileExplodeParticleEffect = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int MissileExplodeSound { get { return m_MissileExplodesound; } set { m_MissileExplodesound = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int MissileUnknown { get { return m_MissileUnknown; } set { m_MissileUnknown = value; } }
        #endregion

        #region Sound
        private TimeSpan m_SoundDelay;
		private int m_SoundID;
		private bool m_SoundAtTrigger;

        [CommandProperty(AccessLevel.Batisseur)]
        public TimeSpan SoundDelay { get { return m_SoundDelay; } set { m_SoundDelay = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        private bool SoundAtTrigger { get { return m_SoundAtTrigger; } set { m_SoundAtTrigger = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int SoundID { get { return m_SoundID; } set { m_SoundID = value; } }
        #endregion

        #region Trigger
        private EffectTriggerType m_TriggerType;
        private int m_TriggerRange;
        private TimeSpan m_TriggerDelay;
        private EffectController m_Trigger;
        private bool m_TriggerPlayersOnly;

		[CommandProperty( AccessLevel.Batisseur )]
		public EffectTriggerType TriggerType{ get{ return m_TriggerType; } set{ m_TriggerType = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int TriggerRange { get { return m_TriggerRange; } set { m_TriggerRange = value; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public TimeSpan TriggerDelay{ get{ return m_TriggerDelay; } set{ m_TriggerDelay = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public EffectController TriggerSequence { get { return m_Trigger; } set { m_Trigger = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public bool TriggerPlayersOnly { get { return m_TriggerPlayersOnly; } set { m_TriggerPlayersOnly = value; } }
        #endregion


		public override string DefaultName
		{
			get { return "Effect Controller"; }
		}

		[Constructable]
		public EffectController() : base( 0x1B72 )
		{
			Movable = false;
			Visible = false;
			m_TriggerType = EffectTriggerType.Sequenced;
			m_MissileEffectLayer = (EffectLayer)255;

            m_LastEffect = DateTime.Now;

            m_Message = "";
		}

        public EffectController(Serial serial)
            : base(serial)
        {
        }

        // Triggers
		public override void OnDoubleClick( Mobile from )
		{
			if ( m_TriggerType == EffectTriggerType.DoubleClick )
				DoEffect( from );
		}

		public override bool HandlesOnMovement{ get{ return ( m_TriggerType == EffectTriggerType.InRange ); } }
		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
            if (m.Location != oldLocation
              && m_TriggerType == EffectTriggerType.InRange
              && Utility.InRange(GetWorldLocation(), m.Location, m_TriggerRange)
              && !Utility.InRange(GetWorldLocation(), oldLocation, m_TriggerRange))
            {
                DoEffect(m);
            }
		}

        public void DoEffect(object trigger)
        {
            DoEffect(trigger, 0);
        }

        // Effects
        public void DoEffect(object trigger, int overflow)
        {
            if (DateTime.Now < m_LastEffect.Add(m_Cooldown))
                return;

            m_LastEffect = DateTime.Now;

            if (Deleted || m_TriggerType == EffectTriggerType.None)
                return;

            if (((Mobile)trigger).AccessLevel > AccessLevel.Player)
                return;

            if (trigger is BaseCreature && m_TriggerPlayersOnly)
                return;

            if (ActivateItem != null && trigger is Mobile && ActivateItem is IActivable)
                ((IActivable)ActivateItem).OnActivate(m_ActivateMode, (Mobile)trigger, overflow);

            if (Trap_ActivateItem != null && trigger is Mobile && Trap_ActivateItem is IActivable)
                Trap_OnActivate((Mobile)trigger);

            if (m_SoundID > 0)
                Timer.DelayCall(m_SoundDelay, new TimerStateCallback(PlaySound), trigger);

            if (m_Message != "")
                Timer.DelayCall(m_MessageDelay, new TimerStateCallback(SendMessage), trigger);

            if (m_Trigger != null)
                Timer.DelayCall(m_TriggerDelay, new TimerStateCallback(m_Trigger.DoEffect), trigger);

            if (m_MissileEffectType != ECEffectType.None)
                Timer.DelayCall(m_MissileDelay, new TimerStateCallback(MissileEffect), trigger);
        }

		public void PlaySound( object trigger )
		{
			IEntity ent = null;

			if ( m_SoundAtTrigger )
				ent = trigger as IEntity;

			if ( ent == null )
				ent = this;

			Effects.PlaySound( (ent is Item) ? ((Item)ent).GetWorldLocation() : ent.Location, ent.Map, m_SoundID );
		}

        public void SendMessage( object trigger )
        {
            IEntity ent = null;

            if (m_MessageAtTrigger)
                ent = trigger as IEntity;

            if (ent == null)
                ent = this;

            if (ent is Mobile)
            {
                ((Mobile)ent).PublicOverheadMessage(Network.MessageType.Regular, 0, true, m_Message);
            }
            else if (ent is Item)
            {
                new ItemInvisibleTimer((Mobile)trigger, Location, m_Message);
            }
        }

		public void MissileEffect( object trigger )
		{
			IEntity from = m_Source, to = m_Target;
			
			if ( from == null )
				from = (IEntity)trigger;

			if ( to == null )
				to = (IEntity)trigger;

			switch ( m_MissileEffectType )
			{
				case ECEffectType.Lightning:
				{
					Effects.SendBoltEffect( from, false, m_MissileHue );
					break;
				}
				case ECEffectType.Location:
				{
					Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), m_MissileItemID, m_MissileSpeed, m_MissileDuration, m_MissileHue, m_MissileRenderMode, m_MissileParticleEffect, m_MissileUnknown );
					break;
				}
				case ECEffectType.Moving:
				{
					if ( from == this )
						from = EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration );

					if ( to == this )
						to = EffectItem.Create( to.Location, to.Map, EffectItem.DefaultDuration );

					Effects.SendMovingParticles( from, to, m_MissileItemID, m_MissileSpeed, m_MissileDuration, m_MissileFixedDirection, m_MissileExplodes, m_MissileHue, m_MissileRenderMode, m_MissileParticleEffect, m_MissileExplodeParticleEffect, m_MissileExplodesound, m_MissileEffectLayer, m_MissileUnknown );
					break;
				}
				case ECEffectType.Target:
				{
					Effects.SendTargetParticles( from, m_MissileItemID, m_MissileSpeed, m_MissileDuration, m_MissileHue, m_MissileRenderMode, m_MissileParticleEffect, m_MissileEffectLayer, m_MissileUnknown );
					break;
				}
			}
		}



        private class ItemInvisibleTimer : Timer
        {
            ItemInvisible item_;

            public ItemInvisibleTimer(Mobile from, IPoint3D location, string Message)
                : base(TimeSpan.FromSeconds(10))
            {
                item_ = new ItemInvisible();
                item_.DropToWorld(from, new Point3D(location.X, location.Y, location.Z));
                item_.Visible = true;
                item_.PublicOverheadMessage(MessageType.Regular, 0, false, Message);
                Start();
            }

            protected override void OnTick()
            {
                item_.Delete();
            }
        }

        private class ItemInvisible : Item
        {
            public ItemInvisible(Serial serial)
                : base(serial)
            { }

            public ItemInvisible()
                : base(0x0001)
            { }

            public override int GetDropSound()
            {
                return -2;
            }

            public override void Serialize(GenericWriter writer)
            {
                base.Serialize(writer);

                writer.Write((int)0); // version
            }

            public override void Deserialize(GenericReader reader)
            {
                base.Deserialize(reader);

                int version = reader.ReadInt();

            }
        }


        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write(m_TriggerPlayersOnly);

            writer.Write(m_Cooldown);
            writer.Write(m_LastEffect);

            writer.Write(m_ActivateMode);
            writer.Write(m_ActivateItem);

            writer.Write(m_TriggerDelay);
            writer.Write(m_SoundDelay);
            writer.Write(m_MissileDelay);

            if (m_Source is Item)
                writer.Write(m_Source as Item);
            else
                writer.Write(m_Source as Mobile);

            if (m_Target is Item)
                writer.Write(m_Target as Item);
            else
                writer.Write(m_Target as Mobile);

            writer.Write(m_Trigger as Item);

            writer.Write(m_MissileFixedDirection);
            writer.Write(m_MissileExplodes);
            writer.Write(m_SoundAtTrigger);

            writer.Write(m_MessageDelay);
            writer.Write(m_MessageAtTrigger);
            writer.Write(m_Message);

            writer.WriteEncodedInt((int)m_MissileEffectType);
            writer.WriteEncodedInt((int)m_MissileEffectLayer);
            writer.WriteEncodedInt((int)m_TriggerType);

            writer.WriteEncodedInt(m_MissileItemID);
            writer.WriteEncodedInt(m_MissileHue);
            writer.WriteEncodedInt(m_MissileRenderMode);
            writer.WriteEncodedInt(m_MissileSpeed);
            writer.WriteEncodedInt(m_MissileDuration);
            writer.WriteEncodedInt(m_MissileParticleEffect);
            writer.WriteEncodedInt(m_MissileExplodeParticleEffect);
            writer.WriteEncodedInt(m_MissileExplodesound);
            writer.WriteEncodedInt(m_MissileUnknown);
            writer.WriteEncodedInt(m_SoundID);
            writer.WriteEncodedInt(m_TriggerRange);
        }

        private IEntity ReadEntity(GenericReader reader)
        {
            return World.FindEntity(reader.ReadInt());
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (version == 0)
                m_TriggerPlayersOnly = reader.ReadBool();

            m_Cooldown = reader.ReadTimeSpan();
            m_LastEffect = reader.ReadDateTime();

            ActivateMode = reader.ReadInt();
            ActivateItem = reader.ReadItem();

            m_TriggerDelay = reader.ReadTimeSpan();
            m_SoundDelay = reader.ReadTimeSpan();
            m_MissileDelay = reader.ReadTimeSpan();

            m_Source = ReadEntity(reader);
            m_Target = ReadEntity(reader);
            m_Trigger = reader.ReadItem() as EffectController;

            m_MissileFixedDirection = reader.ReadBool();
            m_MissileExplodes = reader.ReadBool();
            m_SoundAtTrigger = reader.ReadBool();

            m_MessageDelay = reader.ReadTimeSpan();
            m_MessageAtTrigger = reader.ReadBool();
            m_Message = reader.ReadString();

            m_MissileEffectType = (ECEffectType)reader.ReadEncodedInt();
            m_MissileEffectLayer = (EffectLayer)reader.ReadEncodedInt();
            m_TriggerType = (EffectTriggerType)reader.ReadEncodedInt();

            m_MissileItemID = reader.ReadEncodedInt();
            m_MissileHue = reader.ReadEncodedInt();
            m_MissileRenderMode = reader.ReadEncodedInt();
            m_MissileSpeed = reader.ReadEncodedInt();
            m_MissileDuration = reader.ReadEncodedInt();
            m_MissileParticleEffect = reader.ReadEncodedInt();
            m_MissileExplodeParticleEffect = reader.ReadEncodedInt();
            m_MissileExplodesound = reader.ReadEncodedInt();
            m_MissileUnknown = reader.ReadEncodedInt();
            m_SoundID = reader.ReadEncodedInt();
            m_TriggerRange = reader.ReadEncodedInt();
        }

	}
}