using System;
using Server;

namespace Server.Items
{
    public class Citrine : BaseGem
	{
        public override int m_Couleur
        {
            get { return 2382; }
        }

        public override double m_SkillReq
        {
            get { return 40; }
        }

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Citrine() : this( 1 )
		{
		}

		[Constructable]
		public Citrine( int amount ) : base( 0xF15 )
		{
            Name = "Citrine";
			Stackable = true;
			Amount = amount;
		}

		public Citrine( Serial serial ) : base( serial )
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