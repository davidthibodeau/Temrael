using System;
using Server;
using Server.Items;

namespace Server.Factions
{
	public class FactionBerserker : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Melee | GuardAI.Curse | GuardAI.Bless; } }

		[Constructable]
		public FactionBerserker() : base( "the berserker" )
		{
			GenerateBody( false, false );

			SetStr( 126, 150 );
			SetDex( 61, 85 );
			SetInt( 81, 95 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 50 );
			SetResistance( ResistanceType.Magie, 30, 50 );

			VirtualArmor = 24;

			SetSkill( SkillName.ArmeTranchante, 100.0, 110.0 );
			SetSkill( SkillName.Anatomie, 100.0, 110.0 );
			SetSkill( SkillName.Tactiques, 100.0, 110.0 );
			SetSkill( SkillName.Concentration, 100.0, 110.0 );
			SetSkill( SkillName.Soins, 100.0, 110.0 );
			//SetSkill( SkillName.Anatomy, 100.0, 110.0 );

			SetSkill( SkillName.ArtMagique, 100.0, 110.0 );
			//SetSkill( SkillName.EvalInt, 100.0, 110.0 );
			SetSkill( SkillName.Concentration, 100.0, 110.0 );

			AddItem( Immovable( Rehued( new BodySash(), 1645 ) ) );
			AddItem( Immovable( Rehued( new Kilt(), 1645 ) ) );
			AddItem( Immovable( Rehued( new Sandals(), 1645 ) ) );
			AddItem( Newbied( new DoubleAxe() ) );

			HairItemID = 0x2047; // Afro
			HairHue = 0x29;

			FacialHairItemID = 0x204B; // Medium Short Beard
			FacialHairHue = 0x29;

			PackItem( new Bandage( Utility.RandomMinMax( 30, 40 ) ) );
			PackStrongPotions( 6, 12 );
		}

		public FactionBerserker( Serial serial ) : base( serial )
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