using System;

namespace Server.Items
{
    public class BaitRaie : BaseBait
	{
		[Constructable]
		public BaitRaie() : this( 20 )
		{
		}

		[Constructable]
		public BaitRaie( int charge ) : base( Bait.Raie, charge )
		{
		}

		public BaitRaie( Serial serial ) : base( serial )
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