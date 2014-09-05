using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "Dragon des Marais" )]
	public class DragonMarais : BaseMount
	{
		private bool m_BardingExceptional;
		private Mobile m_BardingCrafter;
		private int m_BardingHP;
		private bool m_HasBarding;
		private CraftResource m_BardingResource;

		[CommandProperty( AccessLevel.Batisseur )]
		public Mobile BardingCrafter
		{
			get{ return m_BardingCrafter; }
			set{ m_BardingCrafter = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public bool BardingExceptional
		{
			get{ return m_BardingExceptional; }
			set{ m_BardingExceptional = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int BardingHP
		{
			get{ return m_BardingHP; }
			set{ m_BardingHP = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public bool HasBarding
		{
			get{ return m_HasBarding; }
			set
			{
				m_HasBarding = value;

				if ( m_HasBarding )
				{
					Hue = CraftResources.GetHue( m_BardingResource );
					BodyValue = 0x31F;
					ItemID = 0x3EBE;
				}
				else
				{
					Hue = 0x851;
					BodyValue = 0x31A;
					ItemID = 0x3EBD;
				}

				InvalidateProperties();
			}
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public CraftResource BardingResource
		{
			get{ return m_BardingResource; }
			set
			{
				m_BardingResource = value;

				if ( m_HasBarding )
					Hue = CraftResources.GetHue( value );

				InvalidateProperties();
			}
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int BardingMaxHP
		{
			get{ return m_BardingExceptional ? 2500 : 1000; }
		}

		[Constructable]
		public DragonMarais() : this( "Dragon des Marais" )
		{
		}

		[Constructable]
		public DragonMarais( string name ) : base( name, 242, 0x3EAC, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0x16A;

			SetStr( 201, 300 );
			SetDex( 66, 85 );
			SetInt( 61, 100 );

			SetHits( 121, 180 );

			SetDamage( 3, 4 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Perforant, 25 );

			SetResistance( ResistanceType.Physical, 35, 40 );
			SetResistance( ResistanceType.Contondant, 20, 30 );
			SetResistance( ResistanceType.Tranchant, 20, 40 );
			SetResistance( ResistanceType.Perforant, 20, 30 );
			SetResistance( ResistanceType.Magie, 30, 40 );

			//SetSkill( SkillName.Anatomy, 45.1, 55.0 );
			SetSkill( SkillName.Concentration, 45.1, 55.0 );
			SetSkill( SkillName.Tactiques, 45.1, 55.0 );
			SetSkill( SkillName.Anatomie, 45.1, 55.0 );

			Fame = 2000;
			Karma = -2000;

			Hue = 0x851;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 97.0;
		}

		public override bool OverrideBondingReqs()
		{
			return true;
		}

		public override int GetIdleSound()
		{
			return 0x2CE;
		}

		public override int GetDeathSound()
		{
			return 0x2CC;
		}

		public override int GetHurtSound()
		{
			return 0x2D1;
		}

		public override int GetAttackSound()
		{
			return 0x2C8;
		}

		public override double GetControlChance( Mobile m, bool useBaseSkill )
		{
			return 1.0;
		}

		public override bool ReacquireOnMovement{ get{ return true; } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override int Scales{ get{ return 5; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Normal; } }
		public override bool CanAngerOnTame { get { return true; } }

        public DragonMarais(Serial serial)
            : base(serial)
		{
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if ( m_HasBarding && m_BardingExceptional && m_BardingCrafter != null )
				list.Add( 1060853, m_BardingCrafter.Name ); // armor exceptionally crafted by ~1_val~
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			writer.Write( (bool) m_BardingExceptional );
			writer.Write( (Mobile) m_BardingCrafter );
			writer.Write( (bool) m_HasBarding );
			writer.Write( (int) m_BardingHP );
			writer.Write( (int) m_BardingResource );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
				{
					m_BardingExceptional = reader.ReadBool();
					m_BardingCrafter = reader.ReadMobile();
					m_HasBarding = reader.ReadBool();
					m_BardingHP = reader.ReadInt();
					m_BardingResource = (CraftResource) reader.ReadInt();
					break;
				}
			}

			if ( Hue == 0 && !m_HasBarding )
				Hue = 0x851;

			if ( BaseSoundID == -1 )
				BaseSoundID = 0x16A;
		}
	}
}