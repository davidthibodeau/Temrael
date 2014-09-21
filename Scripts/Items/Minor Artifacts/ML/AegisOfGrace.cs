using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class AegisOfGrace : DragonHelm
	{
		public override int LabelNumber{ get{ return 1075047; } } // Aegis of Grace

		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseContondantResistance{ get{ return 9; } }
		public override int BaseTranchantResistance{ get{ return 7; } }
		public override int BasePerforantResistance{ get{ return 7; } }
		public override int BaseMagieResistance{ get{ return 15; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Dragon; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.Fer; } }

		[Constructable]
		public AegisOfGrace()
		{
			SkillBonuses.SetValues( 0, SkillName.Concentration, 10.0 );

			Attributes.DefendChance = 20;

			ArmorAttributes.SelfRepair = 2;
		}

		public AegisOfGrace( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}