using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class ResurrectionScroll : SpellScroll
	{
		[Constructable]
		public ResurrectionScroll() : this( 1 )
		{
		}

		[Constructable]
		public ResurrectionScroll( int amount ) : base( ResurrectionSpell.m_SpellID, 0x1F67, amount )
		{
            Name = "Thaumaturgie: Résurrection";
		}

		public ResurrectionScroll( Serial serial ) : base( serial )
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

            Name = "Thaumaturgie: Résurrection";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new ResurrectionScroll( amount ), amount );
		}*/
	}
}