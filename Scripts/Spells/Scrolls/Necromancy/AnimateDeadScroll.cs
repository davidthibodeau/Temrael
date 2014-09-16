using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class AnimateDeadScroll : SpellScroll
	{
		[Constructable]
		public AnimateDeadScroll() : this( 1 )
		{
		}

		[Constructable]
		public AnimateDeadScroll( int amount ) : base( AnimateDeadSpell.spellID, 0x2260, amount )
		{
            Name = "Nécromancie: Animation";
		}

		public AnimateDeadScroll( Serial serial ) : base( serial )
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

            Name = "Nécromancie: Animation";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new AnimateDeadScroll( amount ), amount );
		}*/
	}
}