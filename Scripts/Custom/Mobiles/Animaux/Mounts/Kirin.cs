using System;
using Server.Mobiles;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "Kirin" )]
	public class Kirin : BaseMount
	{
		public override bool AllowFemaleRider{ get{ return true; } }
		public override bool AllowFemaleTamer{ get{ return true; } }

		public override bool InitialInnocent{ get{ return true; } }

		public override TimeSpan MountAbilityDelay { get { return TimeSpan.FromHours( 1.0 ); } }

		public override void OnDisallowedRider( Mobile m )
		{
			m.SendLocalizedMessage( 1042319 ); // The Ki-Rin refuses your attempts to mount it.
		}

		public override bool DoMountAbility( int damage, Mobile attacker )
		{
			if( Rider == null || attacker == null )	//sanity
				return false;

			if( (Rider.Hits - damage) < 30 && Rider.Map == attacker.Map && Rider.InRange( attacker, 18 ) )	//Range and map checked here instead of other base fuction because of abiliites that don't need to check this
			{
				attacker.BoltEffect( 0 );
				// 35~100 damage, unresistable, by the Ki-rin.
				attacker.Damage( Utility.RandomMinMax( 35, 100 ), this, false );	//Don't inform mount about this damage, Still unsure wether or not it's flagged as the mount doing damage or the player.  If changed to player, without the extra bool it'd be an infinite loop

				Rider.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1042534 );	// Your mount calls down the forces of nature on your opponent.
				Rider.FixedParticles( 0, 0, 0, 0x13A7, EffectLayer.Waist );
				Rider.PlaySound( 0xA9 );	// Ki-rin's whinny.
				return true;
			}

			return false;
		}

		[Constructable]
		public Kirin() : this( "Kirin" )
		{
		}

		[Constructable]
		public Kirin( string name ) : base( name, 132, 0x3EAD, AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0x3C5;

			SetStr( 296, 325 );
			SetDex( 86, 105 );
			SetInt( 186, 225 );

			SetHits( 191, 210 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Contondant, 10 );
			SetDamageType( ResistanceType.Tranchant, 10 );
			SetDamageType( ResistanceType.Magie, 10 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Contondant, 35, 45 );
			SetResistance( ResistanceType.Tranchant, 25, 35 );
			SetResistance( ResistanceType.Perforant, 25, 35 );
			SetResistance( ResistanceType.Magie, 25, 35 );

			//SetSkill( SkillName.EvalInt, 80.1, 90.0 );
			SetSkill( SkillName.ArtMagique, 60.4, 100.0 );
			SetSkill( SkillName.Concentration, 90.1, 100.0 );
			SetSkill( SkillName.Concentration, 85.3, 100.0 );
			SetSkill( SkillName.Tactiques, 20.1, 22.5 );
			SetSkill( SkillName.Anatomie, 80.5, 92.5 );

			Fame = 9000;
			Karma = 9000;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 90.0;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			//AddLoot( LootPack.LowScrolls );
			AddLoot( LootPack.Potions );
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override int Meat{ get{ return 3; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Regular; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public Kirin( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( version == 0 )
				AI = AIType.AI_Mage;
		}
	}
}