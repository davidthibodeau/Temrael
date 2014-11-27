using System;
using Server;

namespace Server.Items
{
    public class StarSapphire : BaseGem
	{
        public override int m_Couleur
        {
            get { return 2443; }
        }

        public override double m_SkillReq
        {
            get { return 75; }
        }

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public StarSapphire() : this( 1 )
		{
		}

		[Constructable]
		public StarSapphire( int amount ) : base( 0xF21 )
		{
            Name = "Saphir Etoile";
			Stackable = true;
			Amount = amount;
		}

		public StarSapphire( Serial serial ) : base( serial )
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