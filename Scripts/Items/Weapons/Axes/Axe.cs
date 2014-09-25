using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 0xF49, 0xF4a )]
	public class Axe : BaseAxe
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Dismount; } }

        public override int DefStrengthReq { get { return Hachette_Force1; } }
        public override int DefMinDamage { get { return Hachette_MinDam1; } }
        public override int DefMaxDamage { get { return Hachette_MaxDam1; } }
        public override int DefSpeed { get { return Hachette_Vitesse; } }

        public override int InitMinHits { get { return Armes_MinDurabilite0; } }
        public override int InitMaxHits { get { return Armes_MaxDurabilite0; } }

		[Constructable]
		public Axe() : base( 0xF49 )
		{
			Weight = 4.0;
            Name = "Hache";
		}

		public Axe( Serial serial ) : base( serial )
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