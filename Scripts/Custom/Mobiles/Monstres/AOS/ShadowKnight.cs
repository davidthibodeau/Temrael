using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a shadow knight corpse" )]
	public class ShadowKnight : BaseCreature
	{
		/*public override WeaponAbility GetWeaponAbility()
		{
			return Utility.RandomBool() ? WeaponAbility.ConcussionBlow : WeaponAbility.CrushingBlow;
		}*/

		public override bool IgnoreYoungProtection { get { return Core.ML; } }

		[Constructable]
		public ShadowKnight() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "shadow knight" );
			Title = "the Shadow Knight";
			Body = 118;

			SetStr( 250 );
			SetDex( 100 );
			SetInt( 100 );

			SetHits( 2000 );

			SetDamage( 20, 30 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Tranchant, 40 );

			SetResistance( ResistanceType.Physical, 90 );
			SetResistance( ResistanceType.Contondant, 65 );
			SetResistance( ResistanceType.Tranchant, 75 );
			SetResistance( ResistanceType.Perforant, 75 );
			SetResistance( ResistanceType.Magie, 55 );

			SetSkill( SkillName.Miracles, 120.0 );
			SetSkill( SkillName.Detection, 80.0 );
			//SetSkill( SkillName.EvalInt, 100.0 );
			SetSkill( SkillName.ArtMagique, 100.0 );
			SetSkill( SkillName.Concentration, 100.0 );
			SetSkill( SkillName.Concentration, 120.0 );
			SetSkill( SkillName.Tactiques, 100.0 );
			SetSkill( SkillName.ArmePoing, 100.0 );

			Fame = 25000;
			Karma = -25000;
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 2 );
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		/*public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			if ( !Summoned && !NoKillAwards && DemonKnight.CheckArtifactChance( this ) )
				DemonKnight.DistributeArtifact( this );
		}*/

		public override int GetIdleSound()
		{
			return 0x2CE;
		}

		public override int GetDeathSound()
		{
			return 0x2C1;
		}

		public override int GetHurtSound()
		{
			return 0x2D1;
		}

		public override int GetAttackSound()
		{
			return 0x2C8;
		}

		private Timer m_SoundTimer;
		private bool m_HasTeleportedAway;

		public override void OnCombatantChange()
		{
			base.OnCombatantChange();

			if ( Hidden && Combatant != null )
				Combatant = null;
		}

		public virtual void SendTrackingSound()
		{
			if ( Hidden )
			{
				Effects.PlaySound( this.Location, this.Map, 0x2C8 );
				Combatant = null;
			}
			else
			{
				Frozen = false;

				if ( m_SoundTimer != null )
					m_SoundTimer.Stop();

				m_SoundTimer = null;
			}
		}

		public override void OnThink()
		{
			if ( !m_HasTeleportedAway && Hits < (HitsMax / 2) )
			{
				Map map = this.Map;

				if ( map != null )
				{
					// try 10 times to find a teleport spot
					for ( int i = 0; i < 10; ++i )
					{
						int x = X + (Utility.RandomMinMax( 5, 10 ) * (Utility.RandomBool() ? 1 : -1));
						int y = Y + (Utility.RandomMinMax( 5, 10 ) * (Utility.RandomBool() ? 1 : -1));
						int z = Z;

						if ( !map.CanFit( x, y, z, 16, false, false ) )
							continue;

						Point3D from = this.Location;
						Point3D to = new Point3D( x, y, z );

						if ( !InLOS( to ) )
							continue;

						this.Location = to;
						this.ProcessDelta();
						this.Hidden = true;
						this.Combatant = null;

						Effects.SendLocationParticles( EffectItem.Create( from, map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 2023 );
						Effects.SendLocationParticles( EffectItem.Create(   to, map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 5023 );

						Effects.PlaySound( to, map, 0x1FE );

						m_HasTeleportedAway = true;
						m_SoundTimer = Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), TimeSpan.FromSeconds( 2.5 ), new TimerCallback( SendTrackingSound ) );

						Frozen = true;

						break;
					}
				}
			}

			base.OnThink();
		}

		public override bool BardImmune{ get{ return !Core.SE; } }
		public override bool Unprovokable{ get{ return Core.SE; } }
		public override bool AreaPeaceImmune{ get{ return Core.SE; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		//public override int TreasureMapLevel{ get{ return 1; } }

		public ShadowKnight( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 357 )
				BaseSoundID = -1;
		}
	}
}