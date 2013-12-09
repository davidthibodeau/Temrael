using System;
using Server;
using Server.Items;

namespace Server.Factions
{
	public class FactionKnight : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Magic | GuardAI.Melee | GuardAI.Smart | GuardAI.Curse | GuardAI.Bless; } }

		[Constructable]
		public FactionKnight() : base( "the knight" )
		{
			GenerateBody( false, false );

			SetStr( 126, 150 );
			SetDex( 61, 85 );
			SetInt( 81, 95 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 50 );
			SetResistance( ResistanceType.Contondant, 30, 50 );
			SetResistance( ResistanceType.Tranchant, 30, 50 );
			SetResistance( ResistanceType.Magie, 30, 50 );
			SetResistance( ResistanceType.Perforant, 30, 50 );

			VirtualArmor = 24;

			SetSkill( SkillName.ArmeTranchante, 100.0, 110.0 );
			SetSkill( SkillName.ArmePoing, 100.0, 110.0 );
			SetSkill( SkillName.Tactiques, 100.0, 110.0 );
			SetSkill( SkillName.Concentration, 100.0, 110.0 );
			SetSkill( SkillName.Soins, 100.0, 110.0 );
			//SetSkill( SkillName.Anatomy, 100.0, 110.0 );

			SetSkill( SkillName.ArtMagique, 100.0, 110.0 );
			//SetSkill( SkillName.EvalInt, 100.0, 110.0 );
			SetSkill( SkillName.Concentration, 100.0, 110.0 );

			AddItem( Immovable( Rehued( new ChainChest(), 2125 ) ) );
			AddItem( Immovable( Rehued( new ChainLegs(), 2125 ) ) );
			AddItem( Immovable( Rehued( new ChainCoif(), 2125 ) ) );
			AddItem( Immovable( Rehued( new PlateArms(), 2125 ) ) );
			AddItem( Immovable( Rehued( new PlateGloves(), 2125 ) ) );

			AddItem( Immovable( Rehued( new BodySash(), 1254 ) ) );
			AddItem( Immovable( Rehued( new Kilt(), 1254 ) ) );
			AddItem( Immovable( Rehued( new Sandals(), 1254 ) ) );

			AddItem( Newbied( new Bardiche() ) );

			PackItem( new Bandage( Utility.RandomMinMax( 30, 40 ) ) );
			PackStrongPotions( 6, 12 );
		}

		public FactionKnight( Serial serial ) : base( serial )
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