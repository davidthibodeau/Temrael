using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class BloodOathScroll : SpellScroll
	{
		[Constructable]
		public BloodOathScroll() : this( 1 )
		{
		}

		[Constructable]
		public BloodOathScroll( int amount ) : base( BloodOathSpell.m_SpellID, 0x2261, amount )
		{
            Name = "Nécromancie: Sermant";
		}

		public BloodOathScroll( Serial serial ) : base( serial )
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

            Name = "Nécromancie: Sermant";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new BloodOathScroll( amount ), amount );
		}*/
	}
}