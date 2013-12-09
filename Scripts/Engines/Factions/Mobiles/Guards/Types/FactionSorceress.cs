using System;
using Server;
using Server.Items;

namespace Server.Factions
{
	public class FactionSorceress : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Magic | GuardAI.Bless | GuardAI.Curse; } }

		[Constructable]
		public FactionSorceress() : base( "the sorceress" )
		{
			GenerateBody( true, false );

			SetStr( 126, 150 );
			SetDex( 61, 85 );
			SetInt( 126, 150 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 50 );
			SetResistance( ResistanceType.Contondant, 30, 50 );
			SetResistance( ResistanceType.Tranchant, 30, 50 );
			SetResistance( ResistanceType.Magie, 30, 50 );
			SetResistance( ResistanceType.Perforant, 30, 50 );

			VirtualArmor = 24;

			SetSkill( SkillName.ArmeContondante, 100.0, 110.0 );
			SetSkill( SkillName.ArmePoing, 100.0, 110.0 );
			SetSkill( SkillName.Tactiques, 100.0, 110.0 );
			SetSkill( SkillName.Concentration, 100.0, 110.0 );
			SetSkill( SkillName.Soins, 100.0, 110.0 );
			//SetSkill( SkillName.Anatomy, 100.0, 110.0 );

			SetSkill( SkillName.ArtMagique, 100.0, 110.0 );
			//SetSkill( SkillName.EvalInt, 100.0, 110.0 );
			SetSkill( SkillName.Concentration, 100.0, 110.0 );

			AddItem( Immovable( Rehued( new WizardsHat(), 1325 ) ) );
			AddItem( Immovable( Rehued( new Sandals(), 1325 ) ) );
			AddItem( Immovable( Rehued( new LeatherGorget(), 1325 ) ) );
			AddItem( Immovable( Rehued( new LeatherGloves(), 1325 ) ) );
			AddItem( Immovable( Rehued( new LeatherLegs(), 1325 ) ) );
			AddItem( Immovable( Rehued( new Skirt(), 1325 ) ) );
			AddItem( Immovable( Rehued( new FemaleLeatherChest(), 1325 ) ) );
			AddItem( Newbied( Rehued( new QuarterStaff(), 1310 ) ) );

			PackItem( new Bandage( Utility.RandomMinMax( 30, 40 ) ) );
			PackStrongPotions( 6, 12 );
		}

		public FactionSorceress( Serial serial ) : base( serial )
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