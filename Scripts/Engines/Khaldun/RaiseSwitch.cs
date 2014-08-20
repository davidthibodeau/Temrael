using System;
using Server;
using Server.Network;
using Server.ContextMenus;
using System.Collections.Generic;

namespace Server.Items
{
	public class RaiseSwitch : Item
	{
		private RaisableItem m_RaisableItem;

		[CommandProperty( AccessLevel.Batisseur )]
		public RaisableItem RaisableItem
		{
			get{ return m_RaisableItem; }
			set{ m_RaisableItem = value; }
		}

        private BasePorticullis m_RaisableDoor;

        [CommandProperty(AccessLevel.Batisseur)]
        public BasePorticullis RaisableDoor
        {
            get { return m_RaisableDoor; }
            set { m_RaisableDoor = value; }
        }

        private Mobile m_Owner;

        [CommandProperty(AccessLevel.Batisseur)]
        public Mobile Owner
        {
            get { return m_Owner; }
            set { m_Owner = value; }
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);

            if (m_RaisableDoor != null)
            {
                if (this.isLocked())
                    list.Add(new UnLockEntry(from, this));
                else
                    list.Add(new LockEntry(from, this));
            }
        }

        private class LockEntry : ContextMenuEntry
        {
            private Mobile m_From;
            private RaiseSwitch m_Item;

            public LockEntry(Mobile from, Item item)
                : base(6165, -1)
            {
                m_From = (Mobile)from;
                m_Item = (RaiseSwitch)item;
            }

            public override void OnClick()
            {
                if (m_From == m_Item.Owner)
                    m_Item.Lock();
            }
        }

        private class UnLockEntry : ContextMenuEntry
        {
            private Mobile m_From;
            private RaiseSwitch m_Item;

            public UnLockEntry(Mobile from, Item item)
                : base(6166, -1)
            {
                m_From = (Mobile)from;
                m_Item = (RaiseSwitch)item;
            }

            public override void OnClick()
            {
                if (m_From == m_Item.Owner)
                    m_Item.UnLock();
            }
        }

        public bool isLocked()
        {
            if (m_RaisableDoor != null)
            {
                if (m_RaisableDoor.Locked)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public void Lock()
        {
            m_RaisableDoor.Locked = true;
        }

        public void UnLock()
        {
            m_RaisableDoor.Locked = false;
        }

		[Constructable]
		public RaiseSwitch() : this( 0x1093 )
		{
		}

		protected RaiseSwitch( int itemID ) : base( itemID )
		{
			Movable = false;
		}

		public override void OnDoubleClick( Mobile m )
		{
			if ( !m.InRange( this, 2 ) )
			{
				m.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
				return;
			}

            if (!(m.Z == this.Z))
            {
                m.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1019045); // I can't reach that.
                return;
            }

			if ( RaisableItem != null && RaisableItem.Deleted )
				RaisableItem = null;

			Flip();

			if ( RaisableItem != null )
			{
				if ( RaisableItem.IsRaisable )
				{
					RaisableItem.Raise();
					m.LocalOverheadMessage( MessageType.Regular, 0x5A, true, "You hear a grinding noise echoing in the distance." );
				}
				else
				{
					m.LocalOverheadMessage( MessageType.Regular, 0x5A, true, "You flip the switch again, but nothing happens." );
				}
			}

            if (RaisableDoor != null && RaisableDoor.Deleted)
                RaisableDoor = null;

            //Flip();

            if (RaisableDoor != null)
            {
                RaisableDoor.RaisedUse(m);
                RaisableDoor.Use(m);
            }
		}

		protected virtual void Flip()
		{
			if ( ItemID != 0x1093 )
			{
				ItemID = 0x1093;

				StopResetTimer();
			}
			else
			{
				ItemID = 0x1095;

				if ( RaisableItem != null && RaisableItem.CloseDelay >= TimeSpan.Zero )
					StartResetTimer( RaisableItem.CloseDelay );
				else
					StartResetTimer( TimeSpan.FromMinutes( 2.0 ) );
			}

			Effects.PlaySound( Location, Map, 0x3E8 );
		}

		private ResetTimer m_ResetTimer;

		protected void StartResetTimer( TimeSpan delay )
		{
			StopResetTimer();

			m_ResetTimer = new ResetTimer( this, delay );
			m_ResetTimer.Start();
		}

		protected void StopResetTimer()
		{
			if ( m_ResetTimer != null )
			{
				m_ResetTimer.Stop();
				m_ResetTimer = null;
			}
		}

		protected virtual void Reset()
		{
			if ( ItemID != 0x1093 )
				Flip();
		}

		private class ResetTimer : Timer
		{
			private RaiseSwitch m_RaiseSwitch;

			public ResetTimer( RaiseSwitch raiseSwitch, TimeSpan delay ) : base( delay )
			{
				m_RaiseSwitch = raiseSwitch;

				Priority = ComputePriority( delay );
			}

			protected override void OnTick()
			{
				if ( m_RaiseSwitch.Deleted )
					return;

				m_RaiseSwitch.m_ResetTimer = null;

				m_RaiseSwitch.Reset();
			}
		}

		public RaiseSwitch( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 1 ); // version

            writer.Write( (Mobile) m_Owner );
            writer.Write( (Item) m_RaisableDoor );
			writer.Write( (Item) m_RaisableItem );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();

            switch (version)
            {
                case 1:
                    m_Owner = (Mobile)reader.ReadMobile();
                    m_RaisableDoor = (BasePorticullis)reader.ReadItem();
                    break;
                case 0:
			        m_RaisableItem = (RaisableItem) reader.ReadItem();
                    break;
                default: break;
            }

			Reset();
		}
	}

    public class WinchNS : RaiseSwitch
    {
        [Constructable]
		public WinchNS() : this( 0x1EA8 )
		{
		}

		protected WinchNS( int itemID ) : base( itemID )
		{
			Movable = false;
		}

        protected override void Flip()
        {
            if (ItemID != 0x1EA9)
            {
                ItemID = 0x1EA9;

                StartResetTimer(TimeSpan.FromSeconds(10.0));
            }
            else
            {
                ItemID = 0x1EA8;

                if (RaisableItem != null && RaisableItem.CloseDelay >= TimeSpan.Zero)
                    StartResetTimer(RaisableItem.CloseDelay);
                else
                    StartResetTimer(TimeSpan.FromMinutes(2.0));
            }
        }

        private class ResetTimer : Timer
        {
            private WinchNS m_Winch;

            public ResetTimer(WinchNS winch, TimeSpan delay) : base(delay)
            {
                m_Winch = winch;
                Priority = ComputePriority(delay);
            }

            protected override void OnTick()
            {
                if (m_Winch.Deleted)
                    return;

                m_Winch.StopResetTimer();

                m_Winch.Reset();
            }
        }

        protected override void Reset()
        {
            if (ItemID != 0x1EA8)
                ItemID = 0x1EA8;
            //base.Reset();
        }

        public WinchNS( Serial serial ) : base( serial )
		{
		}

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt((int)0); // version

        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();

            Reset();
        }
    }

    public class WinchEW : RaiseSwitch
    {
        [Constructable]
        public WinchEW()
            : this(0x1EAC)
        {
        }

        protected WinchEW(int itemID)
            : base(itemID)
        {
            Movable = false;
        }

        protected override void Flip()
        {
            if (ItemID != 0x1EAD)
            {
                ItemID = 0x1EAD;

                StartResetTimer(TimeSpan.FromSeconds(10.0));
            }
            else
            {
                ItemID = 0x1EAC;

                if (RaisableItem != null && RaisableItem.CloseDelay >= TimeSpan.Zero)
                    StartResetTimer(RaisableItem.CloseDelay);
                else
                    StartResetTimer(TimeSpan.FromMinutes(2.0));
            }
        }

        private class ResetTimer : Timer
        {
            private WinchEW m_Winch;

            public ResetTimer(WinchEW winch, TimeSpan delay)
                : base(delay)
            {
                m_Winch = winch;
                Priority = ComputePriority(delay);
            }

            protected override void OnTick()
            {
                if (m_Winch.Deleted)
                    return;

                m_Winch.StopResetTimer();

                m_Winch.Reset();
            }
        }

        protected override void Reset()
        {
            if (ItemID != 0x1EAC)
                ItemID = 0x1EAC;
            //base.Reset();
        }

        public WinchEW(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt((int)0); // version

        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();

            Reset();
        }
    }

	public class DisappearingRaiseSwitch : RaiseSwitch
	{
		public int CurrentRange{ get{ return Visible ? 3 : 2; } }

		[Constructable]
		public DisappearingRaiseSwitch() : base( 0x108F )
		{
		}

		protected override void Flip()
		{
		}

		protected override void Reset()
		{
		}

		public override bool HandlesOnMovement{ get{ return true; } }

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( Utility.InRange( m.Location, Location, CurrentRange ) || Utility.InRange( oldLocation, Location, CurrentRange ) )
				Refresh();
		}

		public override void OnMapChange()
		{
			if ( !Deleted )
				Refresh();
		}

		public override void OnLocationChange( Point3D oldLoc )
		{
			if ( !Deleted )
				Refresh();
		}

		public void Refresh()
		{
			bool found = false;
			foreach ( Mobile mob in GetMobilesInRange( CurrentRange ) )
			{
				if ( mob.Hidden && mob.AccessLevel > AccessLevel.Player )
					continue;

				found = true;
				break;
			}

			Visible = found;
		}

		public DisappearingRaiseSwitch( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			if ( RaisableItem != null && RaisableItem.Deleted )
				RaisableItem = null;

			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();

			Timer.DelayCall( TimeSpan.Zero, new TimerCallback( Refresh ) );
		}
	}
}