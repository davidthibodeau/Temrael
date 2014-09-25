using System;
using Server.Network;
using Server.Targeting;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0xF52, 0xF51 )]
	public class Dagger : BaseKnife
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.InfectiousStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ShadowStrike; } }

        public override int DefStrengthReq { get { return Dague_Force0; } }
        public override int DefMinDamage { get { return Dague_MinDam0; } }
        public override int DefMaxDamage { get { return Dague_MaxDam0; } }
        public override int DefSpeed { get { return Dague_Vitesse; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 40; } }

		public override SkillName DefSkill{ get{ return SkillName.ArmePerforante; } }
		public override WeaponType DefType{ get{ return WeaponType.Piercing; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Pierce1H; } }

		[Constructable]
		public Dagger() : base( 0xF52 )
		{
			Weight = 1.0;
            Name = "Dague";
		}

		public Dagger( Serial serial ) : base( serial )
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