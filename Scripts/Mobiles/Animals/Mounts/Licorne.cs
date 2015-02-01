using System;
using Server.Mobiles;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "Licorne" )]
	public class Licorne : BaseMount
	{
		public override bool AllowMaleRider{ get{ return true; } }
		public override bool AllowMaleTamer{ get{ return true; } }

		public override bool InitialInnocent{ get{ return true; } }

		public override TimeSpan MountAbilityDelay { get { return TimeSpan.FromHours( 1.0 ); } }

		public override void OnDisallowedRider( Mobile m )
		{
			m.SendLocalizedMessage( 1042318 ); // The Licorne refuses to allow you to ride it.
		}

		public override bool DoMountAbility( int damage, Mobile attacker )
		{
			if( Rider == null || attacker == null )	//sanity
				return false;

			if( Rider.Poisoned && ((Rider.Hits - damage) < 40) )
			{
				Poison p = Rider.Poison;

				if( p != null )
				{
					int chanceToCure = 10000 + (int)(this.Skills[SkillName.ArtMagique].Value * 75) - ((p.Level + 1) * (Core.AOS ? (p.Level < 4 ? 3300 : 3100) : 1750));
					chanceToCure /= 100;

					if( chanceToCure > Utility.Random( 100 ) )
					{
						if( Rider.CurePoison( this ) )	//TODO: Confirm if mount is the one flagged for curing it or the rider is
						{
							Rider.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, true, "Your mount senses you are in danger and aids you with magic." );
							Effects.SendTargetParticles(Rider, 0x373A, 10, 15, 5012, EffectLayer.Waist );
							Rider.PlaySound( 0x1E0 );	// Cure spell effect.
							Rider.PlaySound( 0xA9 );		// Licorne's whinny.

							return true;
						}
					}
				}
			}

			return false;
		}

		[Constructable]
		public Licorne() : this( "Licorne" )
		{
		}

		[Constructable]
		public Licorne( string name ) : base( name, 0x7A, 0x3EB4, AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0x4BC;

			SetStr( 296, 325 );
			SetDex( 96, 115 );
			SetInt( 186, 225 );

			SetHits( 191, 210 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Magical, 25 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Magical, 25, 40 );

			SetSkill( SkillName.Hallucination, 80.1, 90.0 );
			SetSkill( SkillName.Thaumaturgie, 60.2, 80.0 );
			SetSkill( SkillName.ArtMagique, 50.1, 60.0 );
			SetSkill( SkillName.Concentration, 75.3, 90.0 );
			SetSkill( SkillName.Tactiques, 20.1, 22.5 );
			SetSkill( SkillName.Anatomie, 80.5, 92.5 );

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 97.0;
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override int Meat{ get{ return 3; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Regular; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

        public Licorne(Serial serial)
            : base(serial)
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