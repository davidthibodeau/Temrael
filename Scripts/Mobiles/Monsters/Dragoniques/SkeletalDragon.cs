using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Dragon Squelette" )]
	public class SkeletalDragon : BaseCreature
	{
        public override bool isBoss
        {
            get
            {
                return true;
            }
        }

		[Constructable]
		public SkeletalDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Dragon Squelette";
			Body = 43;
			BaseSoundID = 0x488;

			SetStr( 898, 1030 );
			SetDex( 68, 200 );
			SetInt( 488, 620 );

			SetHits( 1400, 2800 );

			SetDamage( 40, 80 );

			SetDamageType( ResistanceType.Physical, 75 );

            SetResistance(ResistanceType.Physical, 40, 60);
            SetResistance(ResistanceType.Magie, 40, 60);

			//SetSkill( SkillName.EvalInt, 80.1, 100.0 );
			SetSkill( SkillName.ArtMagique, 80.1, 100.0 );
			SetSkill( SkillName.Concentration, 100.3, 130.0 );
			SetSkill( SkillName.Tactiques, 97.6, 100.0 );
			SetSkill( SkillName.Anatomie, 97.6, 100.0 );

            Tamable = true;
            ControlSlots = 11;
            MinTameSkill = 97.0;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			AddLoot( LootPack.Gems, 5 );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.5; } }
		public override bool ReacquireOnMovement{ get{ return true; } }
		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }
		public override int BreathEffectHue{ get{ return 0x480; } }
		public override double BonusPetDamageScalar{ get{ return (Core.SE)? 3.0 : 1.0; } }
		// TODO: Undead summoning?

		public override bool AutoDispel{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override bool BleedImmune{ get{ return true; } }
		public override int Meat{ get{ return 19; } } // where's it hiding these? :)
		//public override int Hides{ get{ return 20; } }
		//public override HideType HideType{ get{ return HideType.Ancien; } }
        public override int Bones { get { return 24; } }
        public override BoneType BoneType { get { return BoneType.Ancien; } }

		public SkeletalDragon( Serial serial ) : base( serial )
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