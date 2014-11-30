using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class AffaiblissementScroll : SpellScroll
	{
		[Constructable]
		public AffaiblissementScroll() : this( 1 )
		{
		}

		[Constructable]
		public AffaiblissementScroll( int amount ) : base( CurseSpell.m_SpellID, 0x1F47, amount )
		{
            Name = "Ensorcellement: Affaiblissement";
		}

		public AffaiblissementScroll( Serial serial ) : base( serial )
		{
		}

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
	}
}