using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class ChampEntropiqueScroll : SpellScroll
	{
		[Constructable]
		public ChampEntropiqueScroll() : this( 1 )
		{
		}

		[Constructable]
		public ChampEntropiqueScroll( int amount ) : base( ChampEntropiqueSpell.m_SpellID, 0x1F3B, amount )
		{
            Name = "Providence: Champ entropique";
		}

		public ChampEntropiqueScroll( Serial serial ) : base( serial )
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