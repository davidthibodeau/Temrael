using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Mobiles;
using Server.Spells;
using Server.Engines.Craft;
using System.Collections.Generic;
using Server.ContextMenus;
using Server.Engines.Combat;
using System.Text.RegularExpressions;

namespace Server.Items
{
	public abstract class BaseWeapon : BaseWearable, IWeapon, ICraftable, IDurability
    {

		/* Weapon internals work differently now (Mar 13 2003)
		 * 
		 * The attributes defined below default to -1.
		 * If the value is -1, the corresponding virtual 'Aos/Old' property is used.
		 * If not, the attribute value itself is used. Here's the list:
		 *  - MinDamage
		 *  - MaxDamage
		 *  - Speed
		 *  - HitSound
		 *  - MissSound
		 *  - StrRequirement, DexRequirement, IntRequirement
		 *  - WeaponType
		 *  - WeaponAnimation
		 *  - MaxRange
		 */

		#region Var declarations

		// Instance values. These values are unique to each weapon.
		private WeaponDamageLevel m_DamageLevel;
		private WeaponAccuracyLevel m_AccuracyLevel;
		private WeaponDurabilityLevel m_DurabilityLevel;
		private WeaponQuality m_Quality;
		private Mobile m_Crafter;
        private string m_CrafterName;
		private Poison m_Poison;
		private int m_PoisonCharges;
		private int m_Hits;
		private int m_MaxHits;
		private SkillMod m_SkillMod, m_MageMod;
		private CraftResource m_Resource;
		private bool m_PlayerConstructed;

		private bool m_Cursed; // Is this weapon cursed via Curse Weapon necromancer spell? Temporary; not serialized.
		private bool m_Consecrated; // Is this weapon blessed via Consecrate Weapon paladin ability? Temporary; not serialized.

		// Overridable values. These values are provided to override the defaults which get defined in the individual weapon scripts.
		private int m_StrReq, m_DexReq, m_IntReq;
		private int m_MinDamage, m_MaxDamage;
		private int m_HitSound, m_MissSound;
		private int m_Speed;
		private int m_MaxRange;
		private SkillName m_Skill;
		private WeaponType m_Type;
		private WeaponAnimation m_Animation;
		#endregion

		#region Virtual Properties
		public virtual WeaponAbility PrimaryAbility{ get{ return null; } }
		public virtual WeaponAbility SecondaryAbility{ get{ return null; } }

		public virtual int DefHitSound{ get{ return 0; } }
		public virtual int DefMissSound{ get{ return 0; } }
		public virtual WeaponType DefType{ get{ return WeaponType.Slashing; } }
		public virtual WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Slash1H; } }

        //public abstract int DefStrengthReq { get; }
        public virtual int DefMinDamage { get { return DPSMin(); } }
        public virtual int DefMaxDamage { get { return DPSMax(); } }
        public abstract int DefSpeed { get; }

        public const int MinWeaponSpeed = 30;
        public const int MaxWeaponSpeed = 60;

        public int DPSMin()
        {
            if (Layer == Layer.OneHanded)
            {
                switch (DefSpeed)
                {
                    case MinWeaponSpeed: return 3;
                    case 35: return 4;
                    case 40: return 6;
                    case 45: return 7;
                    case 50: return 9;
                    case 55: return 10;
                    case MaxWeaponSpeed: return 11;
                    default: return 0;
                }
            }
            if (Layer == Layer.TwoHanded)
            {
                switch (DefSpeed)
                {
                    case MinWeaponSpeed: return 4;
                    case 35: return 6;
                    case 40: return 8;
                    case 45: return 9;
                    case 50: return 11;
                    case 55: return 13;
                    case MaxWeaponSpeed: return 14;
                    default: return 0;
                }
            }
            return 0;
        }

        public int DPSMax()
        {
            if (Layer == Layer.OneHanded)
            {
                switch (DefSpeed)
                {
                    case MinWeaponSpeed: return 6;
                    case 35: return 8;
                    case 40: return 9;
                    case 45: return 11;
                    case 50: return 12;
                    case 55: return 14;
                    case MaxWeaponSpeed: return 15;
                    default: return 0;
                }
            }
            if (Layer == Layer.TwoHanded)
            {
                switch (DefSpeed)
                {
                    case MinWeaponSpeed: return 8;
                    case 35: return 10;
                    case 40: return 12;
                    case 45: return 14;
                    case 50: return 16;
                    case 55: return 18;
                    case MaxWeaponSpeed: return 20;
                    default: return 0;
                }
            }
            return 0;
        }

		public virtual int InitMinHits{ get{ return 150; } }
		public virtual int InitMaxHits{ get{ return 200; } }

		public virtual bool CanFortify{ get{ return true; } }
		#endregion

		#region Getters & Setters
		[CommandProperty( AccessLevel.Batisseur )]
		public bool Cursed
		{
			get{ return m_Cursed; }
			set{ m_Cursed = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public bool Consecrated
		{
			get{ return m_Consecrated; }
			set{ m_Consecrated = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int Durability
		{
			get{ return m_Hits; }
            set
            {
                if (value != m_Hits && MaxDurability > 0)
                {
                    m_Hits = value;

                    if (m_Hits < 0)
                        Delete();
                    else if (m_Hits > MaxDurability)
                        m_Hits = MaxDurability;

                    InvalidateProperties();
                }
            }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int MaxDurability
		{
			get{ return m_MaxHits; }
			set{ m_MaxHits = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int PoisonCharges
		{
			get{ return m_PoisonCharges; }
			set{ m_PoisonCharges = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public Poison Poison
		{
			get{ return m_Poison; }
			set{ m_Poison = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public WeaponQuality Quality
		{
			get{ return m_Quality; }
			set{ UnscaleDurability(); m_Quality = value; ScaleDurability(); InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public Mobile Crafter
		{
			get{ return m_Crafter; }
			set{ m_Crafter = value; InvalidateProperties(); }
		}

        [CommandProperty(AccessLevel.Batisseur)]
        public string CrafterName
        {
            get { return m_CrafterName; }
            set { m_CrafterName = value; InvalidateProperties(); }
        }

		[CommandProperty( AccessLevel.Batisseur )]
		public CraftResource Resource
		{
			get{ return m_Resource; }
			set{ UnscaleDurability(); m_Resource = value; Hue = CraftResources.GetHue( m_Resource ); InvalidateProperties(); ScaleDurability(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public WeaponDamageLevel DamageLevel
		{
			get{ return m_DamageLevel; }
			set{ m_DamageLevel = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public WeaponDurabilityLevel DurabilityLevel
		{
			get{ return m_DurabilityLevel; }
			set{ UnscaleDurability(); m_DurabilityLevel = value; InvalidateProperties(); ScaleDurability(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public bool PlayerConstructed
		{
			get{ return m_PlayerConstructed; }
			set{ m_PlayerConstructed = value; }
		}

        [CommandProperty(AccessLevel.Batisseur)]
        public int MaxRange
        {
            get { return (m_MaxRange == -1 ? RootParent is Mobile ? Strategy.Range(RootParent as Mobile) : Strategy.BaseRange : m_MaxRange); }
            set { m_MaxRange = value; InvalidateProperties(); }
        }

		[CommandProperty( AccessLevel.Batisseur )]
		public WeaponAnimation Animation
		{
			get{ return ( m_Animation == (WeaponAnimation)(-1) ? DefAnimation : m_Animation ); } 
			set{ m_Animation = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public WeaponType Type
		{
			get{ return ( m_Type == (WeaponType)(-1) ? DefType : m_Type ); }
			set{ m_Type = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public SkillName Skill
		{
			get{ return ( m_Skill == (SkillName)(-1) ? Strategy.ToucherSkill : m_Skill ); }
			set{ m_Skill = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int HitSound
		{
			get{ return ( m_HitSound == -1 ? DefHitSound : m_HitSound ); }
			set{ m_HitSound = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int MissSound
		{
			get{ return ( m_MissSound == -1 ? DefMissSound : m_MissSound ); }
			set{ m_MissSound = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
        public double MinDamage
		{
			get{ return ( m_MinDamage == -1 ? DurabilityMalus(ExceptBonus(RessourceBonus(DefMinDamage))) : DurabilityMalus(ExceptBonus(RessourceBonus(m_MinDamage)))); }
			set{ }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public double MaxDamage
		{
			get{ return ( m_MaxDamage == -1 ? DurabilityMalus(ExceptBonus(RessourceBonus(DefMaxDamage))) : DurabilityMalus(ExceptBonus(RessourceBonus(m_MaxDamage)))); }
			set{ }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int Speed
		{
			get
			{
			    if ( m_Speed != -1 )
				    return m_Speed;

				return DefSpeed;
			}
			set{ m_Speed = value; InvalidateProperties(); }
		}

        //[CommandProperty( AccessLevel.Batisseur )]
        //public int StrRequirement
        //{
        //    get{ return ( m_StrReq == -1 ? DefStrengthReq : m_StrReq ); }
        //    set{ m_StrReq = value; InvalidateProperties(); }
        //}

		[CommandProperty( AccessLevel.Batisseur )]
		public WeaponAccuracyLevel AccuracyLevel
		{
			get
			{
				return m_AccuracyLevel;
			}
			set
			{
				if ( m_AccuracyLevel != value )
				{
					m_AccuracyLevel = value;

					if ( UseSkillMod )
					{
						if ( m_AccuracyLevel == WeaponAccuracyLevel.Regular )
						{
							if ( m_SkillMod != null )
								m_SkillMod.Remove();

							m_SkillMod = null;
						}
						else if ( m_SkillMod != null )
						{
							m_SkillMod.Value = (int)m_AccuracyLevel * 5;
						}
					}

					InvalidateProperties();
				}
			}
		}

        [CommandProperty(AccessLevel.Batisseur)]
        public abstract CombatStrategy Strategy
        {
            get;
        }
		#endregion

        const double scalingRes = 0.3;
        private double GetResScaling(int niveau, int nbRessource)
        {
            return (1 + niveau * scalingRes / nbRessource);
        }

        public virtual double DurabilityMalus(double dmg)
        {
            if (m_Hits == 0)
                return 0;

            if (m_MaxHits == 0)
                return dmg;

            return ((m_Hits / m_MaxHits) * 0.3 * dmg) + (dmg * 0.7);
        }

        public virtual double ExceptBonus(double dmg)
        {
            switch (this.Quality)
            {
                case WeaponQuality.Low: dmg *= 0.80; break;
                case WeaponQuality.Regular: dmg *= 1; break;
                case WeaponQuality.Exceptional: dmg *= 1.20; break;
            }
            return dmg;
        }

        public double RessourceBonus(double dmg)
        {
            // Les bonus vont de 0% à 30% de bonus d'AR.
            switch (m_Resource)
            {
                case CraftResource.Cuivre: dmg *= GetResScaling(1, 14); break;
                case CraftResource.Bronze: dmg *= GetResScaling(2, 14); break;
                case CraftResource.Acier: dmg *= GetResScaling(3, 14); break;
                case CraftResource.Argent: dmg *= GetResScaling(4, 14); break;
                case CraftResource.Or: dmg *= GetResScaling(5, 14); break;
                case CraftResource.Mytheril: dmg *= GetResScaling(6, 14); break;
                case CraftResource.Luminium: dmg *= GetResScaling(7, 14); break;
                case CraftResource.Obscurium: dmg *= GetResScaling(8, 14); break;
                case CraftResource.Mystirium: dmg *= GetResScaling(9, 14); break;
                case CraftResource.Dominium: dmg *= GetResScaling(10, 14); break;
                case CraftResource.Venarium: dmg *= GetResScaling(11, 14); break;
                case CraftResource.Eclarium: dmg *= GetResScaling(12, 14); break;
                case CraftResource.Athenium: dmg *= GetResScaling(13, 14); break;
                case CraftResource.Umbrarium: dmg *= GetResScaling(14, 14); break;

                case CraftResource.PinWood: dmg *= GetResScaling(1, 7); break;
                case CraftResource.CypresWood: dmg *= GetResScaling(2, 7); break;
                case CraftResource.CedreWood: dmg *= GetResScaling(3, 7); break;
                case CraftResource.SauleWood: dmg *= GetResScaling(4, 7); break;
                case CraftResource.CheneWood: dmg *= GetResScaling(5, 7); break;
                case CraftResource.EbeneWood: dmg *= GetResScaling(6, 7); break;
                case CraftResource.AcajouWood: dmg *= GetResScaling(7, 7); break;
            }

            return dmg;
        }

		public virtual void UnscaleDurability()
		{
			int scale = 100 + GetDurabilityBonus();

			m_Hits = ((m_Hits * 100) + (scale - 1)) / scale;
			m_MaxHits = ((m_MaxHits * 100) + (scale - 1)) / scale;
			InvalidateProperties();
		}

		public virtual void ScaleDurability()
		{
			int scale = 100 + GetDurabilityBonus();

			m_Hits = ((m_Hits * scale) + 99) / 100;
			m_MaxHits = ((m_MaxHits * scale) + 99) / 100;
			InvalidateProperties();
		}

		public int GetDurabilityBonus()
		{
			int bonus = 0;

			if ( m_Quality == WeaponQuality.Exceptional )
				bonus += 20;

			switch ( m_DurabilityLevel )
			{
				case WeaponDurabilityLevel.Durable: bonus += 20; break;
				case WeaponDurabilityLevel.Substantial: bonus += 50; break;
				case WeaponDurabilityLevel.Massive: bonus += 70; break;
				case WeaponDurabilityLevel.Fortified: bonus += 100; break;
				case WeaponDurabilityLevel.Indestructible: bonus += 120; break;
			}

			return bonus;
		}

		public int GetLowerStatReq()
		{
            return 0;
		}

		public static void BlockEquip( Mobile m, TimeSpan duration )
		{
			if ( m.BeginAction( typeof( BaseWeapon ) ) )
				new ResetEquipTimer( m, duration ).Start();
		}

		private class ResetEquipTimer : Timer
		{
			private Mobile m_Mobile;

			public ResetEquipTimer( Mobile m, TimeSpan duration ) : base( duration )
			{
				m_Mobile = m;
			}

			protected override void OnTick()
			{
				m_Mobile.EndAction( typeof( BaseWeapon ) );
			}
		}

		public override bool CheckConflictingLayer( Mobile m, Item item, Layer layer )
		{
			if ( base.CheckConflictingLayer( m, item, layer ) )
				return true;

			if ( this.Layer == Layer.TwoHanded && layer == Layer.OneHanded )
			{
				m.SendLocalizedMessage( 500214 ); // You already have something in both hands.
				return true;
			}
			else if ( this.Layer == Layer.OneHanded && layer == Layer.TwoHanded && !(item is BaseShield) && !(item is BaseEquipableLight) )
			{
				m.SendLocalizedMessage( 500215 ); // You can only wield one weapon at a time.
				return true;
			}

			return false;
		}

		public override bool CanEquip( Mobile from )
		{
            //if (from.RawStr < AOS.Scale(StrRequirement, 100 - GetLowerStatReq()))
            //{
            //    from.SendLocalizedMessage( 500213 ); // You are not strong enough to equip that.
            //    return false;
            //}
            //else 
                if ( !from.CanBeginAction( typeof( BaseWeapon ) ) )
			{
				return false;
			}
			else
			{
				return base.CanEquip( from );
			}
		}

		public virtual bool UseSkillMod{ get{ return !Core.AOS; } }

		public override bool OnEquip( Mobile from )
		{
            from.NextCombatTime = Core.TickCount + Core.GetTicks(GetDelay(from));

			return true;
		}

		public override void OnAdded(IEntity parent)
		{
			base.OnAdded( parent );

			if ( parent is Mobile )
			{
				Mobile from = (Mobile)parent;

				from.CheckStatTimers();
				from.Delta( MobileDelta.WeaponDamage );
			}
		}

		public override void OnRemoved(IEntity parent)
		{
			if ( parent is Mobile )
			{
				Mobile m = (Mobile)parent;
				BaseWeapon weapon = m.Weapon as BaseWeapon;

				string modName = this.Serial.ToString();

				m.RemoveStatMod( modName + "Str" );
				m.RemoveStatMod( modName + "Dex" );
				m.RemoveStatMod( modName + "Int" );

                if (weapon != null)
                    m.NextCombatTime = Core.TickCount + Core.GetTicks(weapon.GetDelay(m));

				if ( UseSkillMod && m_SkillMod != null )
				{
					m_SkillMod.Remove();
					m_SkillMod = null;
				}

				if ( m_MageMod != null )
				{
					m_MageMod.Remove();
					m_MageMod = null;
				}

				m.CheckStatTimers();

				m.Delta( MobileDelta.WeaponDamage );
			}
		}

		public virtual TimeSpan GetDelay( Mobile m )
		{          
			return TimeSpan.FromMilliseconds(Strategy.ProchaineAttaque(m));
		}

		public virtual void OnBeforeSwing( Mobile attacker, Mobile defender )
		{
			WeaponAbility a = WeaponAbility.GetCurrentAbility( attacker );

			if( a != null && !a.OnBeforeSwing( attacker, defender ) )
				WeaponAbility.ClearCurrentAbility( attacker );
		}

		public virtual int OnSwing( Mobile attacker, Mobile defender )
		{
			bool canSwing = true;

			if ( Core.AOS )
			{
				canSwing = ( !attacker.Paralyzed && !attacker.Frozen );

				if ( canSwing )
				{
					Spell sp = attacker.Spell as Spell;

					canSwing = ( sp == null || !sp.IsCasting || !sp.BlocksMovement );
				}

				if ( canSwing )
				{
					PlayerMobile p = attacker as PlayerMobile;

					canSwing = ( p == null || p.PeacedUntil <= DateTime.Now );
			}
			}

			if ( canSwing && attacker.HarmfulCheck( defender ) )
			{
				attacker.DisruptiveAction();

				if ( attacker.NetState != null )
					attacker.Send( new Swing( 0, attacker, defender ) );

				if ( attacker is BaseCreature )
				{
					BaseCreature bc = (BaseCreature)attacker;
					WeaponAbility ab = bc.GetWeaponAbility();

					if ( ab != null )
					{
						if ( bc.WeaponAbilityChance > Utility.RandomDouble() )
							WeaponAbility.SetCurrentAbility( bc, ab );
						else
							WeaponAbility.ClearCurrentAbility( bc );
					}
				}
                int delay = Strategy.Sequence(attacker, defender);
                attacker.RevealingAction();
                return delay;
			}
            attacker.RevealingAction();
            return Strategy.ProchaineAttaque(attacker);
		}

		public virtual int GetPackInstinctBonus( Mobile attacker, Mobile defender )
		{
			if ( attacker.Player || defender.Player )
				return 0;

			BaseCreature bc = attacker as BaseCreature;

			if ( bc == null || bc.PackInstinct == PackInstinct.None || (!bc.Controlled && !bc.Summoned) )
				return 0;

			Mobile master = bc.ControlMaster;

			if ( master == null )
				master = bc.SummonMaster;

			if ( master == null )
				return 0;

			int inPack = 1;

			foreach ( Mobile m in defender.GetMobilesInRange( 1 ) )
			{
				if ( m != attacker && m is BaseCreature )
				{
					BaseCreature tc = (BaseCreature)m;

					if ( (tc.PackInstinct & bc.PackInstinct) == 0 || (!tc.Controlled && !tc.Summoned) )
						continue;

					Mobile theirMaster = tc.ControlMaster;

					if ( theirMaster == null )
						theirMaster = tc.SummonMaster;

					if ( master == theirMaster && tc.Combatant == defender )
						++inPack;
				}
			}

			if ( inPack >= 5 )
				return 100;
			else if ( inPack >= 4 )
				return 75;
			else if ( inPack >= 3 )
				return 50;
			else if ( inPack >= 2 )
				return 25;

			return 0;
		}

		private static bool m_InDoubleStrike;

		public static bool InDoubleStrike
		{
			get{ return m_InDoubleStrike; }
			set{ m_InDoubleStrike = value; }
		}

		public void OnHit( Mobile attacker, Mobile defender)
		{
            OnHit(attacker, defender, 1.0);
		}

		public virtual void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
		}

        public void CantMount_Callback(object state)
        {
            PlayerMobile mob = (PlayerMobile)state;
            mob.EndAction(typeof(BaseMount));
        }


		public virtual void DoLowerAttack( Mobile from, Mobile defender )
		{
			if ( HitLower.ApplyAttack( defender ) )
			{
				defender.PlaySound( 0x28E );
				Effects.SendTargetEffect( defender, 0x37BE, 1, 4, 0xA, 3 );
			}
		}

		public virtual void DoLowerDefense( Mobile from, Mobile defender )
		{
			if ( HitLower.ApplyDefense( defender ) )
			{
				defender.PlaySound( 0x28E );
				Effects.SendTargetEffect( defender, 0x37BE, 1, 4, 0x23, 3 );
			}
		}



		public virtual void AddBlood( Mobile attacker, Mobile defender, int damage )
		{
			if ( damage > 0 )
			{
				new Blood().MoveToWorld( defender.Location, defender.Map );

				int extraBlood = (Core.SE ? Utility.RandomMinMax( 3, 4 ) : Utility.RandomMinMax( 0, 1 ) );

				for( int i = 0; i < extraBlood; i++ )
				{
					new Blood().MoveToWorld( new Point3D(
						defender.X + Utility.RandomMinMax( -1, 1 ),
						defender.Y + Utility.RandomMinMax( -1, 1 ),
						defender.Z ), defender.Map );
				}
			}
		}

		public virtual void OnMiss( Mobile attacker, Mobile defender )
		{

			WeaponAbility ability = WeaponAbility.GetCurrentAbility( attacker );

			if ( ability != null )
				ability.OnMiss( attacker, defender );

			//SpecialMove move = SpecialMove.GetCurrentMove( attacker );

			//if ( move != null )
			//	move.OnMiss( attacker, defender );

		}

		public virtual int GetHitChanceBonus()
		{
			if ( !Core.AOS )
				return 0;

			int bonus = 0;

			switch ( m_AccuracyLevel )
			{
				case WeaponAccuracyLevel.Accurate:		bonus += 02; break;
				case WeaponAccuracyLevel.Surpassingly:	bonus += 04; break;
				case WeaponAccuracyLevel.Eminently:		bonus += 06; break;
				case WeaponAccuracyLevel.Exceedingly:	bonus += 08; break;
				case WeaponAccuracyLevel.Supremely:		bonus += 10; break;
			}

			return bonus;
		}

		public virtual int GetDamageBonus()
		{
            int bonus = 0;

			switch ( m_Quality )
			{
				case WeaponQuality.Low:			bonus -= 20; break;
				case WeaponQuality.Exceptional:	bonus += 20; break;
			}

			switch ( m_DamageLevel )
			{
				case WeaponDamageLevel.Ruin:	bonus += 15; break;
				case WeaponDamageLevel.Might:	bonus += 20; break;
				case WeaponDamageLevel.Force:	bonus += 25; break;
				case WeaponDamageLevel.Power:	bonus += 30; break;
				case WeaponDamageLevel.Vanq:	bonus += 35; break;
			}

			return bonus;
		}

		public virtual void GetStatusDamage( Mobile from, out int min, out int max )
		{
            min = Strategy.MinDegats(from);
            max = Strategy.MaxDegats(from);
		}


        #region Sons
        public virtual int GetHitAttackSound(Mobile atk, Mobile def)
        {
            int sound = atk.GetAttackSound();

            if (sound == -1)
                sound = HitSound;

            return sound;
        }

        public virtual int GetHitDefendSound(Mobile attacker, Mobile defender)
        {
            return defender.GetHurtSound();
        }

        public virtual int GetMissAttackSound(Mobile attacker, Mobile defender)
        {
            if (attacker.GetAttackSound() == -1)
                return MissSound;
            else
                return -1;
        }
		#endregion

		public virtual bool PlayHurtAnimation( Mobile from, out int action, out int frames )
		{

			switch ( from.Body.Type )
			{
				case BodyType.Sea:
				case BodyType.Animal:
				{
					action = 7;
					frames = 5;
					break;
				}
				case BodyType.Monster:
				{
					action = 10;
					frames = 4;
					break;
				}
				case BodyType.Human:
				{
					action = 20;
					frames = 5;
					break;
				}
                default: action = 0; frames = 0; return false;
			}

			if ( from.Mounted )
                return false;

            return true;
		}

		public virtual int SwingAnimation(Mobile from)
		{
			int action;

			switch ( from.Body.Type )
			{
				case BodyType.Sea:
				case BodyType.Animal:
				{
					action = Utility.Random( 5, 2 );
					break;
				}
				case BodyType.Monster:
				{
					switch ( Animation )
					{
						default:
						case WeaponAnimation.Wrestle:
						case WeaponAnimation.Bash1H:
						case WeaponAnimation.Pierce1H:
						case WeaponAnimation.Slash1H:
						case WeaponAnimation.Bash2H:
						case WeaponAnimation.Pierce2H:
						case WeaponAnimation.Slash2H: action = Utility.Random( 4, 3 ); break;
						case WeaponAnimation.ShootBow:  return 7; // 7
						case WeaponAnimation.ShootXBow: return 8; // 8
					}

					break;
				}
				case BodyType.Human:
				{
					if ( !from.Mounted )
					{
						action = (int)Animation;
					}
					else
					{
						switch ( Animation )
						{
							default:
							case WeaponAnimation.Wrestle:
							case WeaponAnimation.Bash1H:
							case WeaponAnimation.Pierce1H:
							case WeaponAnimation.Slash1H: action = 26; break;
							case WeaponAnimation.Bash2H:
							case WeaponAnimation.Pierce2H:
							case WeaponAnimation.Slash2H: action = 29; break;
							case WeaponAnimation.ShootBow: action = 27; break;
							case WeaponAnimation.ShootXBow: action = 28; break;
						}
					}

					break;
				}
				default: return 0;
			}
            return action;
;
		}

		#region Serialization/Deserialization
		private static void SetSaveFlag( ref SaveFlag flags, SaveFlag toSet, bool setIf )
		{
			if ( setIf )
				flags |= toSet;
		}

		private static bool GetSaveFlag( SaveFlag flags, SaveFlag toGet )
		{
			return ( (flags & toGet) != 0 );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

            writer.Write((int)1); // version

			SaveFlag flags = SaveFlag.None;

			SetSaveFlag( ref flags, SaveFlag.DamageLevel,		m_DamageLevel != WeaponDamageLevel.Regular );
			SetSaveFlag( ref flags, SaveFlag.AccuracyLevel,		m_AccuracyLevel != WeaponAccuracyLevel.Regular );
			SetSaveFlag( ref flags, SaveFlag.DurabilityLevel,	m_DurabilityLevel != WeaponDurabilityLevel.Regular );
			SetSaveFlag( ref flags, SaveFlag.Quality,			m_Quality != WeaponQuality.Regular );
			SetSaveFlag( ref flags, SaveFlag.Hits,				m_Hits != 0 );
			SetSaveFlag( ref flags, SaveFlag.MaxHits,			m_MaxHits != 0 );
			SetSaveFlag( ref flags, SaveFlag.Poison,			m_Poison != null );
			SetSaveFlag( ref flags, SaveFlag.PoisonCharges,		m_PoisonCharges != 0 );
			SetSaveFlag( ref flags, SaveFlag.Crafter,			m_Crafter != null );
            SetSaveFlag( ref flags, SaveFlag.CrafterName,       m_CrafterName != null);
			SetSaveFlag( ref flags, SaveFlag.StrReq,			m_StrReq != -1 );
			SetSaveFlag( ref flags, SaveFlag.DexReq,			m_DexReq != -1 );
			SetSaveFlag( ref flags, SaveFlag.IntReq,			m_IntReq != -1 );
			SetSaveFlag( ref flags, SaveFlag.MinDamage,			m_MinDamage != -1 );
			SetSaveFlag( ref flags, SaveFlag.MaxDamage,			m_MaxDamage != -1 );
			SetSaveFlag( ref flags, SaveFlag.HitSound,			m_HitSound != -1 );
			SetSaveFlag( ref flags, SaveFlag.MissSound,			m_MissSound != -1 );
			SetSaveFlag( ref flags, SaveFlag.Speed,				m_Speed != -1 );
			SetSaveFlag( ref flags, SaveFlag.MaxRange,			m_MaxRange != -1 );
			SetSaveFlag( ref flags, SaveFlag.Skill,				m_Skill != (SkillName)(-1) );
			SetSaveFlag( ref flags, SaveFlag.Type,				m_Type != (WeaponType)(-1) );
			SetSaveFlag( ref flags, SaveFlag.Animation,			m_Animation != (WeaponAnimation)(-1) );
			SetSaveFlag( ref flags, SaveFlag.Resource,			m_Resource != CraftResource.Fer );
			SetSaveFlag( ref flags, SaveFlag.PlayerConstructed,	m_PlayerConstructed );

			writer.Write( (int) flags );

			if ( GetSaveFlag( flags, SaveFlag.DamageLevel ) )
				writer.Write( (int) m_DamageLevel );

			if ( GetSaveFlag( flags, SaveFlag.AccuracyLevel ) )
				writer.Write( (int) m_AccuracyLevel );

			if ( GetSaveFlag( flags, SaveFlag.DurabilityLevel ) )
				writer.Write( (int) m_DurabilityLevel );

			if ( GetSaveFlag( flags, SaveFlag.Quality ) )
				writer.Write( (int) m_Quality );

			if ( GetSaveFlag( flags, SaveFlag.Hits ) )
				writer.Write( (int) m_Hits );

			if ( GetSaveFlag( flags, SaveFlag.MaxHits ) )
				writer.Write( (int) m_MaxHits );

			if ( GetSaveFlag( flags, SaveFlag.Poison ) )
				Poison.Serialize( m_Poison, writer );

			if ( GetSaveFlag( flags, SaveFlag.PoisonCharges ) )
				writer.Write( (int) m_PoisonCharges );

			if ( GetSaveFlag( flags, SaveFlag.Crafter ) )
				writer.Write( (Mobile) m_Crafter );

            if (GetSaveFlag(flags, SaveFlag.CrafterName))
                writer.Write((string)m_CrafterName);

			if ( GetSaveFlag( flags, SaveFlag.StrReq ) )
				writer.Write( (int) m_StrReq );

			if ( GetSaveFlag( flags, SaveFlag.DexReq ) )
				writer.Write( (int) m_DexReq );

			if ( GetSaveFlag( flags, SaveFlag.IntReq ) )
				writer.Write( (int) m_IntReq );

			if ( GetSaveFlag( flags, SaveFlag.MinDamage ) )
				writer.Write( (int) m_MinDamage );

			if ( GetSaveFlag( flags, SaveFlag.MaxDamage ) )
				writer.Write( (int) m_MaxDamage );

			if ( GetSaveFlag( flags, SaveFlag.HitSound ) )
				writer.Write( (int) m_HitSound );

			if ( GetSaveFlag( flags, SaveFlag.MissSound ) )
				writer.Write( (int) m_MissSound );

			if ( GetSaveFlag( flags, SaveFlag.Speed ) )
				writer.Write( (int) m_Speed );

			if ( GetSaveFlag( flags, SaveFlag.MaxRange ) )
				writer.Write( (int) m_MaxRange );

			if ( GetSaveFlag( flags, SaveFlag.Skill ) )
				writer.Write( (int) m_Skill );

			if ( GetSaveFlag( flags, SaveFlag.Type ) )
				writer.Write( (int) m_Type );

			if ( GetSaveFlag( flags, SaveFlag.Animation ) )
				writer.Write( (int) m_Animation );

			if ( GetSaveFlag( flags, SaveFlag.Resource ) )
				writer.Write( (int) m_Resource );
		}

		[Flags]
		private enum SaveFlag
		{
			None					= 0x00000000,
			DamageLevel				= 0x00000001,
			AccuracyLevel			= 0x00000002,
			DurabilityLevel			= 0x00000004,
			Quality					= 0x00000008,
			Hits					= 0x00000010,
			MaxHits					= 0x00000020,
			Poison					= 0x00000040,
			PoisonCharges			= 0x00000080,
			Crafter					= 0x00000100,
			Identified				= 0x00000200,
			StrReq					= 0x00000400,
			DexReq					= 0x00000800,
			IntReq					= 0x00001000,
			MinDamage				= 0x00002000,
			MaxDamage				= 0x00004000,
			HitSound				= 0x00008000,
			MissSound				= 0x00010000,
			Speed					= 0x00020000,
			MaxRange				= 0x00040000,
			Skill					= 0x00080000,
			Type					= 0x00100000,
			Animation				= 0x00200000,
			Resource				= 0x00400000,
			PlayerConstructed		= 0x00800000,
			ElementalDamages		= 0x01000000,
			CrafterName 			= 0x02000000,
		}

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            SaveFlag flags = (SaveFlag)reader.ReadInt();

            if (GetSaveFlag(flags, SaveFlag.DamageLevel))
            {
                m_DamageLevel = (WeaponDamageLevel)reader.ReadInt();

                if (m_DamageLevel > WeaponDamageLevel.Vanq)
                    m_DamageLevel = WeaponDamageLevel.Ruin;
            }

            if (GetSaveFlag(flags, SaveFlag.AccuracyLevel))
            {
                m_AccuracyLevel = (WeaponAccuracyLevel)reader.ReadInt();

                if (m_AccuracyLevel > WeaponAccuracyLevel.Supremely)
                    m_AccuracyLevel = WeaponAccuracyLevel.Accurate;
            }

            if (GetSaveFlag(flags, SaveFlag.DurabilityLevel))
            {
                m_DurabilityLevel = (WeaponDurabilityLevel)reader.ReadInt();

                if (m_DurabilityLevel > WeaponDurabilityLevel.Indestructible)
                    m_DurabilityLevel = WeaponDurabilityLevel.Durable;
            }

            if (GetSaveFlag(flags, SaveFlag.Quality))
                m_Quality = (WeaponQuality)reader.ReadInt();
            else
                m_Quality = WeaponQuality.Regular;

            if (GetSaveFlag(flags, SaveFlag.Hits))
                m_Hits = reader.ReadInt();

            if (GetSaveFlag(flags, SaveFlag.MaxHits))
                m_MaxHits = reader.ReadInt();

            if (GetSaveFlag(flags, SaveFlag.Poison))
                m_Poison = Poison.Deserialize(reader);

            if (GetSaveFlag(flags, SaveFlag.PoisonCharges))
                m_PoisonCharges = reader.ReadInt();

            if (GetSaveFlag(flags, SaveFlag.Crafter))
                m_Crafter = reader.ReadMobile();

            if (GetSaveFlag(flags, SaveFlag.CrafterName))
                m_CrafterName = reader.ReadString();

            if (GetSaveFlag(flags, SaveFlag.StrReq))
                m_StrReq = reader.ReadInt();
            else
                m_StrReq = -1;

            if (GetSaveFlag(flags, SaveFlag.DexReq))
                m_DexReq = reader.ReadInt();
            else
                m_DexReq = -1;

            if (GetSaveFlag(flags, SaveFlag.IntReq))
                m_IntReq = reader.ReadInt();
            else
                m_IntReq = -1;

            if (GetSaveFlag(flags, SaveFlag.MinDamage))
                m_MinDamage = reader.ReadInt();
            else
                m_MinDamage = -1;

            if (GetSaveFlag(flags, SaveFlag.MaxDamage))
                m_MaxDamage = reader.ReadInt();
            else
                m_MaxDamage = -1;

            if (GetSaveFlag(flags, SaveFlag.HitSound))
                m_HitSound = reader.ReadInt();
            else
                m_HitSound = -1;

            if (GetSaveFlag(flags, SaveFlag.MissSound))
                m_MissSound = reader.ReadInt();
            else
                m_MissSound = -1;

            if (version == 1)
            {
                if (GetSaveFlag(flags, SaveFlag.Speed))
                    m_Speed = reader.ReadInt();
                else
                    m_Speed = -1;
            }
            else
            {
                if (GetSaveFlag(flags, SaveFlag.Speed))
                    m_Speed = (int) reader.ReadFloat(); // CANCER ALERT, CANCER ALERT.
                else
                    m_Speed = -1;
            }

            if (GetSaveFlag(flags, SaveFlag.MaxRange))
                m_MaxRange = reader.ReadInt();
            else
                m_MaxRange = -1;

            if (GetSaveFlag(flags, SaveFlag.Skill))
                m_Skill = (SkillName)reader.ReadInt();
            else
                m_Skill = (SkillName)(-1);

            if (GetSaveFlag(flags, SaveFlag.Type))
                m_Type = (WeaponType)reader.ReadInt();
            else
                m_Type = (WeaponType)(-1);

            if (GetSaveFlag(flags, SaveFlag.Animation))
                m_Animation = (WeaponAnimation)reader.ReadInt();
            else
                m_Animation = (WeaponAnimation)(-1);

            if (GetSaveFlag(flags, SaveFlag.Resource))
                m_Resource = (CraftResource)reader.ReadInt();
            else
                m_Resource = CraftResource.Fer;

            if (GetSaveFlag(flags, SaveFlag.PlayerConstructed))
                m_PlayerConstructed = true;

            if (Parent is Mobile)
                ((Mobile)Parent).CheckStatTimers();

            if (m_Hits <= 0 && m_MaxHits <= 0)
            {
                m_Hits = m_MaxHits = Utility.RandomMinMax(InitMinHits, InitMaxHits);
            }

        }
		#endregion

		public BaseWeapon( int itemID ) : base( itemID )
		{
			Layer = (Layer)ItemData.Quality;

			m_Quality = WeaponQuality.Regular;
			m_StrReq = -1;
			m_DexReq = -1;
			m_IntReq = -1;
			m_MinDamage = -1;
			m_MaxDamage = -1;
			m_HitSound = -1;
			m_MissSound = -1;
			m_Speed = -1;
			m_MaxRange = -1;
			m_Skill = (SkillName)(-1);
			m_Type = (WeaponType)(-1);
			m_Animation = (WeaponAnimation)(-1);

			m_Hits = m_MaxHits = Utility.RandomMinMax( InitMinHits, InitMaxHits );

			m_Resource = CraftResource.Fer;
		}

		public BaseWeapon( Serial serial ) : base( serial )
		{
		}

		private string GetNameString()
		{
			string name = this.Name;

			if ( name == null )
				name = String.Format( "#{0}", LabelNumber );

			return name;
		}

		[Hue, CommandProperty( AccessLevel.Batisseur )]
		public override int Hue
		{
			get{ return base.Hue; }
			set{ base.Hue = value; InvalidateProperties(); }
		}


		public override void AddNameProperty( ObjectPropertyList list )
		{
			int oreType;

			switch ( m_Resource )
			{
				case CraftResource.Cuivre:		    oreType = 1053108; break; // dull copper
				case CraftResource.Bronze:		    oreType = 1053107; break; // shadow iron
				case CraftResource.Acier:			oreType = 1053106; break; // copper
				case CraftResource.Argent:			oreType = 1053105; break; // bronze
				case CraftResource.Or:			    oreType = 1053104; break; // golden
				case CraftResource.Mytheril:		oreType = 1053103; break; // agapite
				case CraftResource.Luminium:		oreType = 1053102; break; // verite
				case CraftResource.Obscurium:		oreType = 1053101; break; // valorite
                case CraftResource.Mystirium:       oreType = 1053101; break; // valorite
                case CraftResource.Dominium:        oreType = 1053101; break; // valorite
                case CraftResource.Eclarium:        oreType = 1053101; break; // valorite
                case CraftResource.Venarium:        oreType = 1053101; break; // valorite
                case CraftResource.Athenium:        oreType = 1053101; break; // valorite
                case CraftResource.Umbrarium:       oreType = 1053101; break; // valorite
				/*case CraftResource.SpinedLeather:	oreType = 1061118; break; // spined
				case CraftResource.HornedLeather:	oreType = 1061117; break; // horned
				case CraftResource.BarbedLeather:	oreType = 1061116; break; // barbed
				case CraftResource.RedScales:		oreType = 1060814; break; // red
				case CraftResource.YellowScales:	oreType = 1060818; break; // yellow
				case CraftResource.BlackScales:		oreType = 1060820; break; // black
				case CraftResource.GreenScales:		oreType = 1060819; break; // green
				case CraftResource.WhiteScales:		oreType = 1060821; break; // white
				case CraftResource.BlueScales:		oreType = 1060815; break; // blue*/
				default: oreType = 0; break;
			}

			if ( oreType != 0 )
				list.Add( 1053099, "#{0}\t{1}", oreType, GetNameString() ); // ~1_oretype~ ~2_armortype~
			else if ( Name == null )
				list.Add( LabelNumber );
			else
				list.Add( Name );
				
		}

		public override bool AllowEquipedCast( Mobile from )
		{
			if ( base.AllowEquipedCast( from ) )
				return true;

			//return ( m_AosAttributes.SpellChanneling != 0 );
            return false;
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			//base.GetProperties( list );

            string couleur = "";
            RareteItem rarete = RareteItem.Normal;

            switch (Rarete)
            {
                case RareteItem.Mediocre:
                    rarete = RareteItem.Mediocre;
                    couleur = "333333";
                    break;
                case RareteItem.Normal:
                    rarete = RareteItem.Normal;
                    couleur = "999999";
                    break;
                case RareteItem.Magique:
                    rarete = RareteItem.Magique;
                    couleur = "003366";
                    break;
                case RareteItem.Rare:
                    rarete = RareteItem.Rare;
                    couleur = "993300";
                    break;
                case RareteItem.Legendaire:
                    rarete = RareteItem.Legendaire;
                    couleur = "5A4A31";
                    break;
                default: couleur = "999999"; break;
            }

            if (this.Identified)
            {
                string[] s = Regex.Split(GetType().ToString(),@"\.");
                string t = s[s.Length - 1];
                if (Name == null)
                    list.Add(1060393, "{0}\t{1}", couleur, t);
                else
                    list.Add(1060393, "{0}\t{1}", couleur, Name);
                //list.Add(1060394, "{0}\t{1}", couleur, rarete.ToString());
                list.Add(1060394, "{0}\t{1}", couleur, Quality.ToString());

                if (m_CrafterName != null)
                    list.Add(1060394, "{0}\t{1}", couleur, "Fabriqué par: " + m_CrafterName); // Fabriquèßpar: ~1_NAME~

                int prop;

                AddARProperties(list, couleur);

                if (this is IUsesRemaining && ((IUsesRemaining)this).ShowUsesRemaining)
                    list.Add(1060584, "{0}\t{1}", couleur, ((IUsesRemaining)this).UsesRemaining.ToString()); // uses remaining: ~1_val~

                if (m_Poison != null && m_PoisonCharges > 0)
                    list.Add(1060526, "{0}\t{1}", couleur, m_PoisonCharges.ToString());

                /*if (Core.ML && this is BaseRanged && ((BaseRanged)this).Balanced)
                    list.Add(1072792); // Balanced*/

                list.Add(1061168, "{0}\t{1}\t{2}", couleur, String.Format("{0:0.00}", MinDamage), String.Format("{0:0.00}", MaxDamage)); // weapon damage ~1_val~ - ~2_val~

                if (Core.ML)
                    list.Add(1061167, String.Format("{0}s", Speed)); // weapon speed ~1_val~
                else
                    list.Add(1061167, "{0}\t{1}", couleur, Speed.ToString());

                if (MaxRange > 1)
                    list.Add(1061169, "{0}\t{1}", couleur, MaxRange.ToString()); // range ~1_val~

                if (Layer == Layer.TwoHanded)
                    list.Add(1061171, couleur); // two-handed weapon
                else
                    list.Add(1061824, couleur); // one-handed weapon

                if ((prop = GetLowerStatReq()) != 0)
                    list.Add(1060435, "{0}\t{1}", couleur, prop.ToString()); // lower requirements ~1_val~%

                if ((prop = GetDurabilityBonus()) > 0)
                    list.Add(1060410, "{0}\t{1}", couleur, prop.ToString()); // durability ~1_val~%

                if (m_Hits >= 0 && m_MaxHits > 0)
                    list.Add(1060639, "{0}\t{1}\t{2}", couleur, m_Hits, m_MaxHits); // durability ~1_val~ / ~2_val~
            }
            else
            {
                string[] s = Regex.Split(GetType().ToString(), @"\.");
                string t = s[s.Length - 1];
                if (Name == null)
                    list.Add(1060393, "{0}\t{1}", couleur, t);
                else
                    list.Add(1060393, "{0}\t{1}", couleur, Name);
                //list.Add(1060394, "{0}\t{1}", couleur, rarete.ToString());
                list.Add(1060395, couleur);
            }
		}

        public void AddARProperties(ObjectPropertyList list, string couleur)
        {
            double v = PhysicalResistance;

            if (v != 0)
                list.Add(1060448, "{0}\t{1}", couleur, v.ToString()); // physical resist ~1_val~%

            v = MagieResistance;

            if (v != 0)
                list.Add(1060446, "{0}\t{1}", couleur, v.ToString()); // energy resist ~1_val~%
        }

		public override void OnSingleClick( Mobile from )
		{
			List<EquipInfoAttribute> attrs = new List<EquipInfoAttribute>();

			if ( DisplayLootType )
			{
				if ( LootType == LootType.Blessed )
					attrs.Add( new EquipInfoAttribute( 1038021 ) ); // blessed
				else if ( LootType == LootType.Cursed )
					attrs.Add( new EquipInfoAttribute( 1049643 ) ); // cursed
			}

			if ( m_Quality == WeaponQuality.Exceptional )
				attrs.Add( new EquipInfoAttribute( 1018305 - (int)m_Quality ) );

			if ( Identified || from.AccessLevel >= AccessLevel.Batisseur )
			{

				if ( m_DurabilityLevel != WeaponDurabilityLevel.Regular )
					attrs.Add( new EquipInfoAttribute( 1038000 + (int)m_DurabilityLevel ) );

				if ( m_DamageLevel != WeaponDamageLevel.Regular )
					attrs.Add( new EquipInfoAttribute( 1038015 + (int)m_DamageLevel ) );

				if ( m_AccuracyLevel != WeaponAccuracyLevel.Regular )
					attrs.Add( new EquipInfoAttribute( 1038010 + (int)m_AccuracyLevel ) );
			}
			else if( m_DurabilityLevel != WeaponDurabilityLevel.Regular || m_DamageLevel != WeaponDamageLevel.Regular || m_AccuracyLevel != WeaponAccuracyLevel.Regular )
				attrs.Add( new EquipInfoAttribute( 1038000 ) ); // Unidentified

			if ( m_Poison != null && m_PoisonCharges > 0 )
				attrs.Add( new EquipInfoAttribute( 1017383, m_PoisonCharges ) );

			int number;

			if ( Name == null )
			{
				number = LabelNumber;
			}
			else
			{
				this.LabelTo( from, Name );
				number = 1041000;
			}

			if ( attrs.Count == 0 && Crafter == null && Name != null )
				return;

			EquipmentInfo eqInfo = new EquipmentInfo( number, m_Crafter, false, attrs.ToArray() );

			from.Send( new DisplayEquipmentInfo( this, eqInfo ) );
		}

		private static BaseWeapon m_Fists; // This value holds the default--fist--weapon

		public static BaseWeapon Fists
		{
			get{ return m_Fists; }
			set{ m_Fists = value; }
		}

        #region ICraftable Members

        public int OnCraft( int quality, bool makersMark, Mobile from, CraftSystem craftSystem, Type typeRes, BaseTool tool, CraftItem craftItem, int resHue )
		{
			Quality = (WeaponQuality)quality;

            Crafter = from;

            if (makersMark)
            {
                m_CrafterName = from.Name;
            }

			PlayerConstructed = true;

			Type resourceType = typeRes;

			if ( resourceType == null )
				resourceType = craftItem.Resources.GetAt( 0 ).ItemType;

			if ( Core.AOS )
			{
				Resource = CraftResources.GetFromType( resourceType );

				CraftContext context = craftSystem.GetContext( from );

				if ( context != null && context.DoNotColor )
					Hue = 0;

                RareteInit.InitItem(this, quality, Crafter);
			}
            //else if ( tool is BaseRunicTool )
            //{
            //    CraftResource thisResource = CraftResources.GetFromType( resourceType );

            //    if ( thisResource == ((BaseRunicTool)tool).Resource )
            //    {
            //        Resource = thisResource;

            //        CraftContext context = craftSystem.GetContext( from );

            //        if ( context != null && context.DoNotColor )
            //            Hue = 0;

            //        switch ( thisResource )
            //        {
            //            case CraftResource.Cuivre:
            //            {
            //                Identified = true;
            //                DurabilityLevel = WeaponDurabilityLevel.Regular;
            //                DamageLevel = WeaponDamageLevel.Regular;
            //                AccuracyLevel = WeaponAccuracyLevel.Accurate;
            //                break;
            //            }
            //            case CraftResource.Bronze:
            //            {
            //                Identified = true;
            //                DurabilityLevel = WeaponDurabilityLevel.Regular;
            //                DamageLevel = WeaponDamageLevel.Ruin;
            //                AccuracyLevel = WeaponAccuracyLevel.Accurate;
            //                break;
            //            }
            //            case CraftResource.Acier:
            //            {
            //                Identified = true;
            //                DurabilityLevel = WeaponDurabilityLevel.Durable;
            //                DamageLevel = WeaponDamageLevel.Ruin;
            //                AccuracyLevel = WeaponAccuracyLevel.Surpassingly;
            //                break;
            //            }
            //            case CraftResource.Argent:
            //            {
            //                Identified = true;
            //                DurabilityLevel = WeaponDurabilityLevel.Regular;
            //                DamageLevel = WeaponDamageLevel.Regular;
            //                AccuracyLevel = WeaponAccuracyLevel.Surpassingly;
            //                break;
            //            }
            //            case CraftResource.Or:
            //            {
            //                Identified = true;
            //                DurabilityLevel = WeaponDurabilityLevel.Regular;
            //                DamageLevel = WeaponDamageLevel.Regular;
            //                AccuracyLevel = WeaponAccuracyLevel.Surpassingly;
            //                break;
            //            }
            //            case CraftResource.Mytheril:
            //            {
            //                Identified = true;
            //                DurabilityLevel = WeaponDurabilityLevel.Indestructible;
            //                DamageLevel = WeaponDamageLevel.Ruin;
            //                AccuracyLevel = WeaponAccuracyLevel.Eminently;
            //                break;
            //            }
            //            case CraftResource.Luminium:
            //            {
            //                Identified = true;
            //                DurabilityLevel = WeaponDurabilityLevel.Fortified;
            //                DamageLevel = WeaponDamageLevel.Power;
            //                AccuracyLevel = WeaponAccuracyLevel.Supremely;
            //                break;
            //            }
            //            case CraftResource.Obscurium:
            //            {
            //                Identified = true;
            //                DurabilityLevel = WeaponDurabilityLevel.Fortified;
            //                DamageLevel = WeaponDamageLevel.Vanq;
            //                AccuracyLevel = WeaponAccuracyLevel.Exceedingly;
            //                break;
            //            }
            //            case CraftResource.Mystirium:
            //            {
            //                Identified = true;
            //                DurabilityLevel = WeaponDurabilityLevel.Durable;
            //                DamageLevel = WeaponDamageLevel.Vanq;
            //                AccuracyLevel = WeaponAccuracyLevel.Supremely;
            //                break;
            //            }
            //            case CraftResource.Dominium:
            //            {
            //                Identified = true;
            //                DurabilityLevel = WeaponDurabilityLevel.Indestructible;
            //                DamageLevel = WeaponDamageLevel.Force;
            //                AccuracyLevel = WeaponAccuracyLevel.Exceedingly;
            //                break;
            //            }
            //            case CraftResource.Eclarium:
            //            {
            //                Identified = true;
            //                DurabilityLevel = WeaponDurabilityLevel.Regular;
            //                DamageLevel = WeaponDamageLevel.Vanq;
            //                AccuracyLevel = WeaponAccuracyLevel.Supremely;
            //                break;
            //            }
            //            case CraftResource.Venarium:
            //            {
            //                Identified = true;
            //                DurabilityLevel = WeaponDurabilityLevel.Massive;
            //                DamageLevel = WeaponDamageLevel.Vanq;
            //                AccuracyLevel = WeaponAccuracyLevel.Eminently;
            //                break;
            //            }
            //            case CraftResource.Athenium:
            //            {
            //                Identified = true;
            //                DurabilityLevel = WeaponDurabilityLevel.Substantial;
            //                DamageLevel = WeaponDamageLevel.Might;
            //                AccuracyLevel = WeaponAccuracyLevel.Supremely;
            //                break;
            //            }
            //            case CraftResource.Umbrarium:
            //            {
            //                Identified = true;
            //                DurabilityLevel = WeaponDurabilityLevel.Fortified;
            //                DamageLevel = WeaponDamageLevel.Vanq;
            //                AccuracyLevel = WeaponAccuracyLevel.Surpassingly;
            //                break;
            //            }
            //        }
			//	  }
			//}

			return quality;
		}

		#endregion
	}
}
