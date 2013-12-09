using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 0xF49, 0xF4a )]
	public class Axe : BaseAxe
	{
        public override int NiveauAttirail { get { return 1; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hachette_Force1; } }
        public override int AosMinDamage { get { return Hachette_MinDam1; } }
        public override int AosMaxDamage { get { return Hachette_MaxDam1; } }
        public override double AosSpeed { get { return Hachette_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

		public override int OldStrengthReq{ get{ return 35; } }
		public override int OldMinDamage{ get{ return 6; } }
		public override int OldMaxDamage{ get{ return 33; } }
		public override int OldSpeed{ get{ return 37; } }

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