using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Leviathan" )]
	public class Leviathan : BaseCreature
	{
		private Mobile m_Fisher;

		public Mobile Fisher
		{
			get{ return m_Fisher; }
			set{ m_Fisher = value; }
		}

		[Constructable]
		public Leviathan() : this( null )
		{
		}

		[Constructable]
		public Leviathan( Mobile fisher ) : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			m_Fisher = fisher;

			// May not be OSI accurate; mostly copied from krakens
			Name = "Leviathan";
			Body = 74;
			BaseSoundID = 353;

			Hue = 0x481;

			SetStr( 1000 );
			SetDex( 501, 520 );
			SetInt( 501, 515 );

			SetHits( 1500 );

			SetDamage( 30, 60 );

			SetDamageType( ResistanceType.Physical, 70 );
			

            SetResistance(ResistanceType.Physical, 40, 60);
            
            
            
            SetResistance(ResistanceType.Magie, 40, 60);

			//SetSkill( SkillName.EvalInt, 97.6, 107.5 );
			SetSkill( SkillName.ArtMagique, 97.6, 107.5 );
			SetSkill( SkillName.Concentration, 97.6, 107.5 );
			SetSkill( SkillName.Concentration, 97.6, 107.5 );
			SetSkill( SkillName.Tactiques, 97.6, 107.5 );
			SetSkill( SkillName.Anatomie, 97.6, 107.5 );

			CanSwim = true;
			CantWalk = true;
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override bool HasBreath{ get{ return true; } }
		public override int BreathPhysicalDamage{ get{ return 70; } } // TODO: Verify damage type
		public override int BreathColdDamage{ get{ return 30; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x1ED; } }
		public override double BreathDamageScalar{ get{ return 0.05; } }
		public override double BreathMinDelay{ get{ return 5.0; } }
		public override double BreathMaxDelay{ get{ return 7.5; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
		}

		//public override double TreasureMapChance{ get{ return 0.25; } }
		//public override int TreasureMapLevel{ get{ return 5; } }

        public override int Bones { get { return 12; } }
        public override int Hides { get { return 15; } }
        public override HideType HideType { get { return HideType.Maritime; } }
        public override BoneType BoneType { get { return BoneType.Maritime; } }

		public Leviathan( Serial serial ) : base( serial )
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

		public static Type[] Artifacts { get { return m_Artifacts; } }

		private static Type[] m_Artifacts = new Type[]
		{
			// Decorations
			typeof( CandelabraOfSouls ),
			typeof( GhostShipAnchor ),
			typeof( GoldBricks ),
			typeof( PhillipsWoodenSteed ),
			typeof( SeahorseStatuette ),
			typeof( ShipModelOfTheHMSCape ),
			typeof( AdmiralsHeartyRum ),

			// Equipment
			typeof( AlchemistsBauble ),
			typeof( BurglarsBandana ),
			typeof( DreadPirateHat ),
			typeof( GwennosHarp ),
			typeof( IolosLute ),
			typeof( NightsKiss ),
			typeof( PolarBearMask ),
			typeof( VioletCourage )
		};

		public static void GiveArtifactTo( Mobile m )
		{
			Item item = Loot.Construct( m_Artifacts );

			if ( item == null )
				return;

			// TODO: Confirm messages
			if ( m.AddToBackpack( item ) )
				m.SendMessage( "As a reward for slaying the mighty leviathan, an artifact has been placed in your backpack." );
			else
				m.SendMessage( "As your backpack is full, your reward for destroying the legendary leviathan has been placed at your feet." );
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			if ( m_Fisher != null && 25 > Utility.Random( 100 ) )
				GiveArtifactTo( m_Fisher );

			m_Fisher = null;
		}
	}
}