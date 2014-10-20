using System;
using Server;
using Server.Items;

namespace Server.Factions
{
	public class FactionDeathKnight : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Melee | GuardAI.Curse | GuardAI.Bless; } }

		[Constructable]
		public FactionDeathKnight() : base( "the death knight" )
		{
			GenerateBody( false, false );
			Hue = 1;

			SetStr( 126, 150 );
			SetDex( 61, 85 );
			SetInt( 81, 95 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 50 );
			SetResistance( ResistanceType.Magie, 30, 50 );

			VirtualArmor = 24;

			SetSkill( SkillName.Epee, 100.0, 110.0 );
			SetSkill( SkillName.Anatomie, 100.0, 110.0 );
			SetSkill( SkillName.Tactiques, 100.0, 110.0 );
			SetSkill( SkillName.Concentration, 100.0, 110.0 );
			SetSkill( SkillName.Soins, 100.0, 110.0 );
			//SetSkill( SkillName.Anatomy, 100.0, 110.0 );

			SetSkill( SkillName.ArtMagique, 100.0, 110.0 );
			//SetSkill( SkillName.EvalInt, 100.0, 110.0 );
			SetSkill( SkillName.Concentration, 100.0, 110.0 );

			Item shroud = new Item( 0x204E );
			shroud.Layer = Layer.OuterTorso;

			AddItem( Immovable( Rehued( shroud, 1109 ) ) );
			AddItem( Newbied( Rehued( new ExecutionersAxe(), 2211 ) ) );

			PackItem( new Bandage( Utility.RandomMinMax( 30, 40 ) ) );
			PackStrongPotions( 6, 12 );
		}

		public FactionDeathKnight( Serial serial ) : base( serial )
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