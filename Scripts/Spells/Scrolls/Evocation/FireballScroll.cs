using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class FireballScroll : SpellScroll
	{
		[Constructable]
		public FireballScroll() : this( 1 )
		{
		}

		[Constructable]
		public FireballScroll( int amount ) : base( FireballSpell.spellID, 0x1F3E, amount )
		{
            Name = "Évocation: Boule de Feu";
		}

		public FireballScroll( Serial serial ) : base( serial )
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

            Name = "Évocation: Boule de Feu";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new FireballScroll( amount ), amount );
		}*/
	}
}