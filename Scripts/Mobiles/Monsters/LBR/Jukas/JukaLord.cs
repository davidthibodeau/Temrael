using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a juka corpse" )] // Why is this 'juka' and warriors 'jukan' ? :-(
	public class JukaLord : BaseCreature
	{
		[Constructable]
		public JukaLord() : base( AIType.AI_Archer, FightMode.Closest, 10, 3, 0.2, 0.4 )
		{
			Name = "a juka lord";
            Body = 400;

			SetStr( 401, 500 );
			SetDex( 81, 100 );
			SetInt( 151, 200 );

			SetHits( 241, 300 );

			SetDamage( 10, 12 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Contondant, 45, 50 );
			SetResistance( ResistanceType.Tranchant, 40, 50 );
			SetResistance( ResistanceType.Perforant, 20, 25 );
			SetResistance( ResistanceType.Magie, 40, 50 );

			//SetSkill( SkillName.Anatomy, 90.1, 100.0 );
			SetSkill( SkillName.ArmeDistance, 95.1, 100.0 );
			SetSkill( SkillName.Soins, 80.1, 100.0 );
			SetSkill( SkillName.Concentration, 120.1, 130.0 );
			SetSkill( SkillName.ArmeTranchante, 90.1, 100.0 );
			SetSkill( SkillName.Tactiques, 95.1, 100.0 );
			SetSkill( SkillName.Anatomie, 90.1, 100.0 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 28;

			Container pack = new Backpack();

			pack.DropItem( new Arrow( Utility.RandomMinMax( 25, 35 ) ) );
			pack.DropItem( new Arrow( Utility.RandomMinMax( 25, 35 ) ) );
			pack.DropItem( new Bandage( Utility.RandomMinMax( 5, 15 ) ) );
			pack.DropItem( new Bandage( Utility.RandomMinMax( 5, 15 ) ) );
			pack.DropItem( Loot.RandomGem() );
			pack.DropItem( new ArcaneGem() );

			PackItem( pack );

			// TODO: Bandage self
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
		}

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			if ( from != null && !willKill && amount > 5 && from.Player && 5 > Utility.Random( 100 ) )
			{
				string[] toSay = new string[]
					{
						"{0}!!  You will have to do better than that!",
						"{0}!!  Prepare to meet your doom!",
						"{0}!!  My armies will crush you!",
						"{0}!!  You will pay for that!"
					};

				this.Say( true, String.Format( toSay[Utility.Random( toSay.Length )], from.Name ) );
			}

			base.OnDamage( amount, from, willKill );
		}

		public override int GetIdleSound()
		{
			return 0x262;
		}

		public override int GetAngerSound()
		{
			return 0x263;
		}

		public override int GetHurtSound()
		{
			return 0x1D0;
		}

		public override int GetDeathSound()
		{
			return 0x28D;
		}

		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }

		public JukaLord( Serial serial ) : base( serial )
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
