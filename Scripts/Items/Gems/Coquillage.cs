using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Items.Gems
{
    public class Coquillage : BaseGem
    {
        public override int m_Couleur
        {
            get { return 2382; }
        }

        public override double m_SkillReq
        {
            get { return 30; }
        }

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Coquillage() : this( 1 )
		{
		}

		[Constructable]
		public Coquillage( int amount ) : base( 0xF15 )
		{
            Name = "Coquillage";
			Stackable = true;
			Amount = amount;
		}

        public Coquillage(Serial serial)
            : base(serial)
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
