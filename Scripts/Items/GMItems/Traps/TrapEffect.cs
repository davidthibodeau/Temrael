using System;
using Server;
using Server.Network;

namespace Server.Items
{
    public class TrapEffect : Item, IActivable
    {
        #region IActivable
        public override void IActivableOnActivate(int mode, Mobile from, int overflow)
        {
            DoEffect(from);

            if(Trap_ActivateItem != null && overflow < 5000) // overflow a une limite arbitraire mais avant qu'un stack overflow pop.
                Trap_ActivateItem.OnActivate(Trap_ActivateMode, from, overflow + 1);
        }
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
		private bool m_MissileFixedDirection;
		private bool m_MissileExplodes;
		private int m_MissileParticleEffect;
		private int m_MissileExplodeParticleEffect;
		private int m_MissileExplodesound;
		private EffectLayer m_MissileEffectLayer;
		private int m_MissileUnknown;
        private TimeSpan m_MissileEffectDelay;

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
        public int MissileParticleEffect { get { return m_MissileParticleEffect; } set { m_MissileParticleEffect = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int MissileExplodeParticleEffect { get { return m_MissileExplodeParticleEffect; } set { m_MissileExplodeParticleEffect = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int MissileExplodeSound { get { return m_MissileExplodesound; } set { m_MissileExplodesound = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int MissileUnknown { get { return m_MissileUnknown; } set { m_MissileUnknown = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public TimeSpan MissileEffectDelay { get { return m_MissileEffectDelay; } set { m_MissileEffectDelay = value; } }
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

		[CommandProperty( AccessLevel.Batisseur )]
		public EffectTriggerType TriggerType{ get{ return m_TriggerType; } set{ m_TriggerType = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int TriggerRange { get { return m_TriggerRange; } set { m_TriggerRange = value; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public TimeSpan TriggerDelay{ get{ return m_TriggerDelay; } set{ m_TriggerDelay = value; } }
        #endregion

        #region Damage
        private int m_Damage;

        [CommandProperty(AccessLevel.Batisseur)]
        public int Damage { get { return m_Damage; } set { m_Damage = value; } }
        #endregion

        public override string DefaultName
		{
			get { return "Trap Effect"; }
		}

		[Constructable]
        public TrapEffect()
            : base(0x1B7A)
		{
			Movable = false;
			Visible = false;
			m_TriggerType = EffectTriggerType.Sequenced;
			m_MissileEffectLayer = (EffectLayer)255;

            m_LastEffect = DateTime.Now;

            m_Message = "";
		}

        public TrapEffect(Serial serial)
            : base(serial)
        {
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

		public void DoEffect( object trigger )
		{
            if (DateTime.Now < m_LastEffect.Add(m_Cooldown))
                return;

			if ( Deleted || m_TriggerType == EffectTriggerType.None )
				return;

			if( trigger is Mobile && ((Mobile)trigger).Hidden && ((Mobile)trigger).AccessLevel > AccessLevel.Player )
				return;

			if ( m_SoundID > 0 )
				Timer.DelayCall( m_SoundDelay, new TimerStateCallback( PlaySound ), trigger );

            if (m_Message != "")
                Timer.DelayCall(m_MessageDelay, new TimerStateCallback(SendMessage), trigger);

			if ( m_Trigger != null )
				Timer.DelayCall( m_TriggerDelay, new TimerStateCallback( m_Trigger.DoEffect ), trigger );

			if ( m_MissileEffectType != ECEffectType.None )
                Timer.DelayCall(m_MissileEffectDelay, new TimerStateCallback(MissileEffect), trigger);

            if (m_Damage != 0 || trigger is Mobile)
                ((Mobile)trigger).Damage(m_Damage);
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

            writer.Write((int)2); // version

            writer.Write(m_MissileEffectDelay);
            writer.Write(m_TriggerDelay);
            writer.Write(m_SoundDelay);

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

            writer.Write(m_Damage);

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


            m_MissileEffectDelay = reader.ReadTimeSpan();
            m_TriggerDelay = reader.ReadTimeSpan();
            m_SoundDelay = reader.ReadTimeSpan();

            m_Source = ReadEntity(reader);
            m_Target = ReadEntity(reader);
            m_Trigger = reader.ReadItem() as EffectController;

            m_MissileFixedDirection = reader.ReadBool();
            m_MissileExplodes = reader.ReadBool();
            m_SoundAtTrigger = reader.ReadBool();

            if (version == 0 || version == 1)
            {
                reader.ReadBool();
            }
            m_MessageDelay = reader.ReadTimeSpan();
            m_MessageAtTrigger = reader.ReadBool();
            m_Message = reader.ReadString();

            m_Damage = reader.ReadInt();

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
