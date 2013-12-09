using System;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Corps de Seigneur Morgalin" )]
	public class OrcishLord : BaseCreature
	{
        public override bool isBoss
        {
            get
            {
                return true;
            }
        }

		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Orc; } }

		[Constructable]
		public OrcishLord() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Seigneur Morgalin";
			Body = 160;
			BaseSoundID = 0x45A;

			SetStr( 147, 215 );
			SetDex( 91, 115 );
			SetInt( 61, 85 );

			SetHits( 1000, 2000 );

			SetDamage( 80, 160 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 60, 80);
            SetResistance(ResistanceType.Contondant, 60, 80);
            SetResistance(ResistanceType.Tranchant, 60, 80);
            SetResistance(ResistanceType.Perforant, 60, 80);
            SetResistance(ResistanceType.Magie, 60, 80);

			SetSkill( SkillName.Concentration, 70.1, 85.0 );
			SetSkill( SkillName.ArmeTranchante, 60.1, 85.0 );
			SetSkill( SkillName.Tactiques, 75.1, 90.0 );
			SetSkill( SkillName.ArmePoing, 60.1, 85.0 );

			Fame = 2500;
			Karma = -2500;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.SuperBoss );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 4.0; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		//public override int TreasureMapLevel{ get{ return 1; } }
		public override int Meat{ get{ return 1; } }
        public override int Bones { get { return 20; } }
        public override int Hides { get { return 12; } }
        public override HideType HideType { get { return HideType.Regular; } }
        public override BoneType BoneType { get { return BoneType.Gobelin; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.SavagesAndOrcs; }
		}

		public override bool IsEnemy( Mobile m )
		{
			if ( m.Player && m.FindItemOnLayer( Layer.Helm ) is OrcishKinMask )
				return false;

			return base.IsEnemy( m );
		}

		public override void AggressiveAction( Mobile aggressor, bool criminal )
		{
			base.AggressiveAction( aggressor, criminal );

			Item item = aggressor.FindItemOnLayer( Layer.Helm );

			if ( item is OrcishKinMask )
			{
				AOS.Damage( aggressor, 50, 0, 100, 0, 0, 0 );
				item.Delete();
				aggressor.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
				aggressor.PlaySound( 0x307 );
			}
		}

		public OrcishLord( Serial serial ) : base( serial )
		{
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