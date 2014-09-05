using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Wisp" )]
	public class ShadowWisp : BaseCreature
	{
		[Constructable]
		public ShadowWisp() : base( AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.3, 0.6 )
		{
			Name = "Wisp";
			Body = 165;
			BaseSoundID = 466;

			SetStr( 16, 40 );
			SetDex( 16, 45 );
			SetInt( 11, 25 );

			SetHits( 150, 300 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15, 20 );
			SetResistance( ResistanceType.Contondant, 5, 10 );
			SetResistance( ResistanceType.Perforant, 5, 10 );
			SetResistance( ResistanceType.Magie, 15, 20 );

			//SetSkill( SkillName.EvalInt, 40.0 );
			SetSkill( SkillName.ArtMagique, 50.0 );
			SetSkill( SkillName.Concentration, 40.0 );
			SetSkill( SkillName.Concentration, 10.0 );
			SetSkill( SkillName.Tactiques, 0.1, 15.0 );
			SetSkill( SkillName.Anatomie, 25.1, 40.0 );

			Fame = 500;

			//AddItem( new LightSource() );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }

		public ShadowWisp( Serial serial ) : base( serial )
		{
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}