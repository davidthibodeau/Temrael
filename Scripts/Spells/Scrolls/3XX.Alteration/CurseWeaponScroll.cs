using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class CurseWeaponScroll : SpellScroll
	{
		[Constructable]
		public CurseWeaponScroll() : this( 1 )
		{
		}

		[Constructable]
		public CurseWeaponScroll( int amount ) : base( CurseWeaponSpell.m_SpellID, 0x2263, amount )
		{
            Name = "Alteration: Arme maudite";
		}

		public CurseWeaponScroll( Serial serial ) : base( serial )
		{
		}
	}
}