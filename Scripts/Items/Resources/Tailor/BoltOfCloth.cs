using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 0xF95, 0xF96 )]
	public class BoltOfCloth : Item, IScissorable, ICommodity
	{
		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }

		[Constructable]
		public BoltOfCloth() : this( 1 )
		{
		}

		[Constructable]
		public BoltOfCloth( int amount ) : base( 0xF95 )
		{
            GoldValue = 51;
			Stackable = true;
			Weight = 5.0;
			Amount = amount;
		}

		public BoltOfCloth( Serial serial ) : base( serial )
		{
		}

		/*public bool Dye( Mobile from, DyeTub sender )
		{
			if ( Deleted ) return false;

            if (this.Amount == 1)
            {
                Hue = sender.Hue;

                return true;
            }
            else
            {
                from.SendMessage("Vous ne pouvez pas teindre plus d'un rouleau à la fois.");
                return false;
            }
		}*/

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

		public bool Scissor( Mobile from, Scissors scissors )
		{
			if ( Deleted || !from.CanSee( this ) ) return false;

			base.ScissorHelper( from, new Cloth(), 50 );

			return true;
		}

		public override void OnSingleClick( Mobile from )
		{
			int number = (Amount == 1) ? 1049122 : 1049121;

			from.Send( new MessageLocalized( Serial, ItemID, MessageType.Label, 0x3B2, 3, number, "", (Amount * 50).ToString() ) );
		}
	}

    [FlipableAttribute(0xF97, 0xF98)]
    public class LinBoltOfCloth : Item, IScissorable, IDyable, ICommodity
    {
        int ICommodity.DescriptionNumber { get { return LabelNumber; } }
        bool ICommodity.IsDeedable { get { return true; } }

        [Constructable]
        public LinBoltOfCloth()
            : this(1)
        {
        }

        [Constructable]
        public LinBoltOfCloth(int amount)
            : base(0xF97)
        {
            Stackable = true;
            Weight = 5.0;
            Amount = amount;
        }

        public LinBoltOfCloth(Serial serial)
            : base(serial)
        {
        }

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted) return false;

            Hue = sender.Hue;

            return true;
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

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (Deleted || !from.CanSee(this)) return false;

            //base.ScissorHelper(from, new LinCloth(), 50);

            return true;
        }

        public override void OnSingleClick(Mobile from)
        {
            int number = (Amount == 1) ? 1049122 : 1049121;

            from.Send(new MessageLocalized(Serial, ItemID, MessageType.Label, 0x3B2, 3, number, "", (Amount * 50).ToString()));
        }
    }
}