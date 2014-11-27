using System;
using Server;

namespace Server.Items
{
    public class Amethyst : BaseGem
	{
        public override int m_Couleur
        {
            get { return 2187; }
        }

        public override double m_SkillReq
        {
            get { return 50; }
        }

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Amethyst() : this( 1 )
		{
		}

		[Constructable]
		public Amethyst( int amount ) : base( 0xF16 )
		{
            Name = "Améthyste";
			Stackable = true;
			Amount = amount;
		}

		public Amethyst( Serial serial ) : base( serial )
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