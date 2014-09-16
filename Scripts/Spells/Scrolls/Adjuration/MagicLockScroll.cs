using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class MagicLockScroll : SpellScroll
	{
		[Constructable]
		public MagicLockScroll() : this( 1 )
		{
		}

		[Constructable]
		public MagicLockScroll( int amount ) : base( MagicLockSpell.spellID, 0x1F3F, amount )
		{
            Name = "Adjuration: Ouverture Magique";
		}

		public MagicLockScroll( Serial serial ) : base( serial )
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

            Name = "Adjuration: Ouverture Magique";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new MagicLockScroll( amount ), amount );
		}*/
	}
}