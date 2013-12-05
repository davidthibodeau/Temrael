using System;
using Server.Network;
using System.Collections.Generic;

namespace Server.Items
{
    public abstract class BasePorticullis : BaseDoor
    {
        private bool m_Raised;

        public BasePorticullis(int closedID, int openedID, int openedSound, int closedSound, Point3D offset)
            : base(closedID, openedID, openedSound, closedSound, offset)
		{
		}

        public BasePorticullis( Serial serial ) : base( serial )
		{
		}

        public void RaisedUse(Mobile m)
        {
            m_Raised = true;
        }

        public override void Use(Mobile from)
        {
            if (Locked && !Open && UseLocks())
            {
                if (from.AccessLevel >= AccessLevel.GameMaster)
                {
                    from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 502502); // That is locked, but you open it with your godly powers.
                    //from.Send( new MessageLocalized( Serial, ItemID, MessageType.Regular, 0x3B2, 3, 502502, "", "" ) ); // That is locked, but you open it with your godly powers.
                }
                else if (Key.ContainsKey(from.Backpack, this.KeyValue))
                {
                    from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 501282); // You quickly unlock, open, and relock the door
                }
                else if (IsInside(from))
                {
                    from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 501280); // That is locked, but is usable from the inside.
                }
                else if (m_Raised)
                {
                    from.LocalOverheadMessage(MessageType.Regular, 0x3B2, true, "Vous utilisez le mechanisme pour ouvrir la porte.");
                    m_Raised = false;
                }
                else
                {
                    if (Hue == 0x44E && Map == Map.Malas) // doom door into healer room in doom
                        this.SendLocalizedMessageTo(from, 1060014); // Only the dead may pass.
                    else
                        from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 502503); // That is locked.

                    return;
                }
            }

            if (Open && !IsFreeToClose())
                return;

            if (Open)
                OnClosed(from);
            else
                OnOpened(from);

            if (UseChainedFunctionality)
            {
                bool open = !Open;

                List<BaseDoor> list = GetChain();

                for (int i = 0; i < list.Count; ++i)
                    list[i].Open = open;
            }
            else
            {
                Open = !Open;

                BaseDoor link = this.Link;

                if (Open && link != null && !link.Open)
                    link.Open = true;
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write(m_Raised);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_Raised = reader.ReadBool();
        }
    }
	public class PortcullisNS : BasePorticullis
	{
		public override bool UseChainedFunctionality{ get{ return true; } }

		[Constructable]
		public PortcullisNS() : base( 0x6F5, 0x6F5, 0xF0, 0xEF, new Point3D( 0, 0, 20 ) )
		{
		}

		public PortcullisNS( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

    public class PortcullisEW : BasePorticullis
	{
		public override bool UseChainedFunctionality{ get{ return true; } }

		[Constructable]
		public PortcullisEW() : base( 0x6F6, 0x6F6, 0xF0, 0xEF, new Point3D( 0, 0, 20 ) )
		{
		}

		public PortcullisEW( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}