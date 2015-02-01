using System;
using Server.Items;
using Server.Network;
using Server.Spells;
using Server.Mobiles;
using Server.Engines.Combat;

namespace Server.Items
{
	public abstract class BaseRanged : BaseWeapon
	{
		public abstract int EffectID{ get; }
		public abstract Type AmmoType{ get; }
		public abstract Item Ammo{ get; }

		public override int DefHitSound{ get{ return 0x234; } }
		public override int DefMissSound{ get{ return 0x238; } }

		public override WeaponType DefType{ get{ return WeaponType.Ranged; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.ShootXBow; } }

		private Timer m_RecoveryTimer; // so we don't start too many timers
		private bool m_Balanced;
		private int m_Velocity;
		
		[CommandProperty( AccessLevel.Batisseur )]
		public bool Balanced
		{
			get{ return m_Balanced; }
			set{ m_Balanced = value; InvalidateProperties(); }
		}
		
		[CommandProperty( AccessLevel.Batisseur )]
		public int Velocity
		{
			get{ return m_Velocity; }
			set{ m_Velocity = value; InvalidateProperties(); }
		}

		public BaseRanged( int itemID ) : base( itemID )
		{
            Layer = Layer.TwoHanded;
		}

		public BaseRanged( Serial serial ) : base( serial )
		{
            Layer = Layer.TwoHanded;
		}

		public override int OnSwing( Mobile attacker, Mobile defender )
		{
			WeaponAbility a = WeaponAbility.GetCurrentAbility( attacker );

			// Make sure we've been standing still for .25/.5/1 second depending on Era
			if (Core.TickCount > (attacker.LastMoveTime + (Core.SE ? 250 : (Core.AOS ? 500 : 1000) )) || (Core.AOS && WeaponAbility.GetCurrentAbility( attacker ) is MovingShot) )
			{
				bool canSwing = true;
                int delay = 0;
				if ( Core.AOS )
				{
					canSwing = ( !attacker.Paralyzed && !attacker.Frozen );

					if ( canSwing )
					{
						Spell sp = attacker.Spell as Spell;

						canSwing = ( sp == null || !sp.IsCasting || !sp.BlocksMovement );
					}
				}

				if ( canSwing && attacker.HarmfulCheck( defender ) )
				{
					attacker.DisruptiveAction();
					attacker.Send( new Swing( 0, attacker, defender ) );

					if ( Strategy.OnFired( attacker, defender ) )
					{
                        delay = Strategy.Sequence(attacker, defender);
					}
				}

				attacker.RevealingAction();

                return delay;
			}
			else
			{
				attacker.RevealingAction();

                return 250;
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.Write( (bool) m_Balanced );
			writer.Write( (int) m_Velocity );
		}

		public override void Deserialize( GenericReader reader )
		{
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_Balanced = reader.ReadBool();
            m_Velocity = reader.ReadInt();

        }
	}

    public abstract class BaseArc : BaseRanged
    {
        public override int EffectID{ get{ return 0xF42; } }
		public override Type AmmoType{ get{ return typeof( Arrow ); } }
		public override Item Ammo{ get{ return new Arrow(); } }

        public BaseArc(int itemID)
            : base(itemID)
        {
        }

        public BaseArc(Serial serial)
            : base(serial)
        {
        }

        public override CombatStrategy Strategy { get { return StrategyArc.Strategy; } }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

    }

    public abstract class BaseArbalete : BaseRanged
    {        
        public override int EffectID { get { return 0x1BFE; } }
        public override Type AmmoType { get { return typeof(Bolt); } }
        public override Item Ammo { get { return new Bolt(); } }

        public BaseArbalete(int itemID)
            : base(itemID)
        {
        }

        public BaseArbalete(Serial serial)
            : base(serial)
        {
        }

        public override CombatStrategy Strategy { get { return StrategyArbalete.Strategy; } }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}