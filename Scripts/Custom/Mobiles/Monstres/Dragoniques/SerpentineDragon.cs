using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Dragon d'Orient" )]
	public class SerpentineDragon : BaseCreature
	{
        public override bool isBoss
        {
            get
            {
                return true;
            }
        }

		[Constructable]
		public SerpentineDragon() : base( AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4 )
		{
			Name = "Dragon d'Orient";
            Body = 140;
			BaseSoundID = 362;

			SetStr( 111, 140 );
			SetDex( 201, 220 );
			SetInt( 1001, 1040 );

			SetHits( 1600 );

			SetDamage( 40, 80 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Perforant, 25 );

            SetResistance(ResistanceType.Physical, 40, 60);
            SetResistance(ResistanceType.Contondant, 40, 60);
            SetResistance(ResistanceType.Tranchant, 40, 60);
            SetResistance(ResistanceType.Perforant, 40, 60);
            SetResistance(ResistanceType.Magie, 40, 60);

			//SetSkill( SkillName.EvalInt, 100.1, 110.0 );
			SetSkill( SkillName.ArtMagique, 110.1, 120.0 );
			SetSkill( SkillName.Concentration, 100.0 );
			SetSkill( SkillName.Concentration, 100.0 );
			SetSkill( SkillName.Tactiques, 50.1, 60.0 );
			SetSkill( SkillName.Anatomie, 30.1, 100.0 );

			Fame = 15000;
			Karma = 15000;
		}

        public override double AttackSpeed { get { return 3.0; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			AddLoot( LootPack.Gems, 2 );
		}

		public override int GetIdleSound()
		{
			return 0x2C4;
		}

		public override int GetAttackSound()
		{
			return 0x2C0;
		}

		public override int GetDeathSound()
		{
			return 0x2C1;
		}

		public override int GetAngerSound()
		{
			return 0x2C4;
		}

		public override int GetHurtSound()
		{
			return 0x2C3;
		}

        public override bool AlwaysMurderer { get { return true; } }
		public override bool ReacquireOnMovement{ get{ return true; } }
		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override double BonusPetDamageScalar{ get{ return (Core.SE) ? 3.0 : 1.0; } }

		public override bool AutoDispel{ get{ return true; } }
		public override int Meat{ get{ return 19; } }
		public override int Scales{ get{ return 10; } }
        public override ScaleType ScaleType { get { return ScaleType.Desertique; } }
		//public override int TreasureMapLevel{ get{ return 4; } }
        public override int Bones { get { return 14; } }
        public override int Hides { get { return 18; } }
        public override HideType HideType { get { return HideType.Dragonique; } }
        public override BoneType BoneType { get { return BoneType.Dragon; } }

		public SerpentineDragon( Serial serial ) : base( serial )
		{
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( !Core.SE && 0.2 > Utility.RandomDouble() && attacker is BaseCreature )
			{
				BaseCreature c = (BaseCreature)attacker;

				if ( c.Controlled && c.ControlMaster != null )
				{
					c.ControlTarget = c.ControlMaster;
					c.ControlOrder = OrderType.Attack;
					c.Combatant = c.ControlMaster;
				}
			}
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