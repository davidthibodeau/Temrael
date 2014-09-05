using System;
using Server.Items;
using Server.Network;
using Server.Engines.Harvest;

namespace Server.Items
{
	[FlipableAttribute( 0x13B0, 0x13AF )]
	public class WarAxe : BaseAxe
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.BleedAttack; } }

        public override int AosStrengthReq { get { return Hachette_Force4; } }
        public override int AosMinDamage { get { return Hachette_MinDam4; } }
        public override int AosMaxDamage { get { return Hachette_MaxDam4; } }
        public override double AosSpeed { get { return Hachette_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

		public override int DefHitSound{ get{ return 0x233; } }
		public override int DefMissSound{ get{ return 0x239; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 80; } }

        public override SkillName DefSkill { get { return SkillName.ArmeTranchante; } }
        public override WeaponType DefType { get { return WeaponType.Axe; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Slash1H; } }

		public override HarvestSystem HarvestSystem{ get{ return null; } }

		[Constructable]
		public WarAxe() : base( 0x13B0 )
		{
			Weight = 8.0;
            Name = "Hache de Guerre";
		}

		public WarAxe( Serial serial ) : base( serial )
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