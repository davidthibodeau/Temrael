using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	[FlipableAttribute( 0xfbb, 0xfbc )]
	public class Tongs : BaseTool
	{
        public override int GoldValue { get { return 6; } }
		public override CraftSystem CraftSystem{ get{ return DefBlacksmithy.CraftSystem; } }

		[Constructable]
		public Tongs() : base( 0xFBB )
		{
			Weight = 2.0;
            Layer = Layer.TwoHanded;
		}

		[Constructable]
		public Tongs( int uses ) : base( uses, 0xFBB )
		{
			Weight = 2.0;
            Layer = Layer.TwoHanded;
		}

		public Tongs( Serial serial ) : base( serial )
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