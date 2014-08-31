using System;
using System.Collections.Generic;
using Server;
using Server.Multis;
using Server.Network;

namespace Server.Items
{
	[Furniture]
	[Flipable( 0x188E, 0x188F )]
	public class ArmoireA : BaseContainer
	{
		[Constructable]
		public ArmoireA() : base( 0x188E)
		{
			Weight = 5.0;
            Name = "Armoire à portes vitrées";
		}

		public ArmoireA( Serial serial ) : base( serial )
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
	
	[Furniture]
	[Flipable( 0x1892, 0x189C )]
	public class ArmoireB : BaseContainer
	{
		[Constructable]
		public ArmoireB() : base( 0x1892)
		{
			Weight = 5.0;
            Name = "Commode à pieds";
		}

		public ArmoireB( Serial serial ) : base( serial )
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

    [Furniture]
    [Flipable(0x2342, 0x2343)]
    public class SecretaireFonce : BaseContainer
    {
        [Constructable]
        public SecretaireFonce()
            : base(0x2342)
        {
            Weight = 5.0;
            Name = "Secrétaire foncé";
        }

        public SecretaireFonce(Serial serial)
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

    [Furniture]
    [Flipable(0x2344, 0x2345)]
    public class SecretairePale : BaseContainer
    {
        [Constructable]
        public SecretairePale()
            : base(0x2344)
        {
            Weight = 5.0;
            Name = "Secrétaire pâle";
        }

        public SecretairePale(Serial serial)
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

    [Furniture]
    [Flipable(0x2346, 0x2347)]
    public class SecretaireBourgogne : BaseContainer
    {
        [Constructable]
        public SecretaireBourgogne()
            : base(0x2346)
        {
            Weight = 5.0;
            Name = "Secrétaire bourgogne";
        }

        public SecretaireBourgogne(Serial serial)
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
}