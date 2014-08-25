using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13B9, 0x13Ba )]
	public class VikingSword : BaseSword
	{
        //public override int NiveauAttirail { get { return 3; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Claymore_Force3; } }
        public override int AosMinDamage { get { return Claymore_MinDam3; } }
        public override int AosMaxDamage { get { return Claymore_MaxDam3; } }
        public override double AosSpeed { get { return Claymore_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

		public override int OldStrengthReq{ get{ return 40; } }
		public override int OldMinDamage{ get{ return 6; } }
		public override int OldMaxDamage{ get{ return 34; } }
		public override int OldSpeed{ get{ return 30; } }

		public override int DefHitSound{ get{ return 0x237; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 100; } }

		[Constructable]
		public VikingSword() : base( 0x13B9 )
		{
			Weight = 6.0;
            		Name = "Épée Lourde";
            		Layer = Layer.TwoHanded;
		}

		public VikingSword( Serial serial ) : base( serial )
		{
			Layer = Layer.TwoHanded;
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
			Layer = Layer.TwoHanded;
		}
	}
}