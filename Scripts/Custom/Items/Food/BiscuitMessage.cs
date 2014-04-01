using System;
using Server.Network;
using Server.Prompts;

namespace Server.Items
{
	public class BiscuitMessagePlein : Food
	{
        private string m_Message;

        [CommandProperty(AccessLevel.GameMaster)]
        public string Message
        {
            get { return m_Message; }
            set { m_Message = value; }
        }

		[Constructable]
        public BiscuitMessagePlein(string text) : base(0x1041)
		{
			Weight = 1.0;
			FillFactor = 1;
			Stackable = false;
            Name = "Biscuit avec Message";
            m_Message = text;
		}

        public BiscuitMessagePlein(Serial serial)
            : base(serial)
		{
		}

		public override bool Eat( Mobile from )
		{
            if (!base.Eat(from))
                this.Consume();

            from.SendMessage("Vous trouvez un message dans le biscuit.");
			from.AddToBackpack( new BiscuitMessage(m_Message) );
			return true;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
            writer.Write( (string) m_Message);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
            m_Message = reader.ReadString();
		}
	}

    public class BiscuitMessageVide : Item
    {

        [Constructable]
        public BiscuitMessageVide()
            : base(0x160b)
        {
            Weight = 1.0;
            Stackable = false;
            Name = "Biscuit Message Vide";
        }

        public BiscuitMessageVide(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (this.IsChildOf(from.Backpack))
                from.Prompt = new BiscuitMessagePrompt(from, this);
            else
                from.SendMessage("Ceci doit être dans votre sac pour l'utiliser");
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

    [FlipableAttribute(7971, 7971)]
    public class BiscuitMessage : Item
    {

        [Constructable]
        public BiscuitMessage(string Message)
            : base(7971)
        {
            Weight = 1.0;
            Stackable = false;
            Name = Message;

        }

        public BiscuitMessage(Serial serial)
            : base(serial)
        {
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

    public class BiscuitMessagePrompt : Prompt
    {
        private BiscuitMessageVide m_Item;
        private Mobile m_From;

        public BiscuitMessagePrompt(Mobile from, BiscuitMessageVide item)
        {
            from.SendMessage("Entrez le message à mettre dans le biscuit. ESC pour annuler.");
            m_Item = item;
            m_From = from;
        }

        public override void OnResponse(Mobile from, string text)
        {
            if (m_Item != null)
                if (!m_Item.Deleted)
                    if (from.Alive && !(from.Deleted))
                    {
                        from.AddToBackpack(new BiscuitMessagePlein(text));
                        m_Item.Delete();
                    }
        }
    }
}