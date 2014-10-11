using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Engines.Harvest;
using Server.ContextMenus;
using Server.Engines.Combat;

namespace Server.Items
{
	public interface IAxe
	{
		bool Axe( Mobile from, BaseAxe axe );
	}

	public abstract class BaseAxe : BaseMeleeWeapon
	{
		public override int DefHitSound{ get{ return 0x232; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override WeaponType DefType{ get{ return WeaponType.Axe; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Slash2H; } }

        public override CombatStrategy Strategy { get { return StrategyHache.Strategy; } }

		public virtual HarvestSystem HarvestSystem{ get{ return Lumberjacking.System; } }

		private int m_UsesRemaining;
		private bool m_ShowUsesRemaining;

		[CommandProperty( AccessLevel.Batisseur )]
		public int UsesRemaining
		{
			get { return m_UsesRemaining; }
			set { m_UsesRemaining = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public bool ShowUsesRemaining
		{
			get { return m_ShowUsesRemaining; }
			set { m_ShowUsesRemaining = value; InvalidateProperties(); }
		}

		public virtual int GetUsesScalar()
		{
			if ( Quality == WeaponQuality.Exceptional )
				return 200;

			return 100;
		}

		public override void UnscaleDurability()
		{
			base.UnscaleDurability();

			int scale = GetUsesScalar();

			m_UsesRemaining = ((m_UsesRemaining * 100) + (scale - 1)) / scale;
			InvalidateProperties();
		}

		public override void ScaleDurability()
		{
			base.ScaleDurability();

			int scale = GetUsesScalar();

			m_UsesRemaining = ((m_UsesRemaining * scale) + 99) / 100;
			InvalidateProperties();
		}

		public BaseAxe( int itemID ) : base( itemID )
		{
			m_UsesRemaining = 150;
		}

		public BaseAxe( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( HarvestSystem == null || Deleted )
				return;

			Point3D loc = this.GetWorldLocation();			

			if ( !from.InLOS( loc ) || !from.InRange( loc, 2 ) )
			{
				from.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3E9, 1019045 ); // I can't reach that
				return;
			}
			else if ( !this.IsAccessibleTo( from ) )
			{
				this.PublicOverheadMessage( Server.Network.MessageType.Regular, 0x3E9, 1061637 ); // You are not allowed to access this.
				return;
			}
			
			if ( !(this.HarvestSystem is Mining) )
				from.SendLocalizedMessage( 1010018 ); // What do you want to use this item on?
			
			HarvestSystem.BeginHarvesting( from, this );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );

			if ( HarvestSystem != null )
				BaseHarvestTool.AddContextMenuEntries( from, this, list, HarvestSystem );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 2 ); // version

			writer.Write( (bool) m_ShowUsesRemaining );

			writer.Write( (int) m_UsesRemaining );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 2:
				{
					m_ShowUsesRemaining = reader.ReadBool();
					goto case 1;
				}
				case 1:
				{
					m_UsesRemaining = reader.ReadInt();
					goto case 0;
				}
				case 0:
				{
					if ( m_UsesRemaining < 1 )
						m_UsesRemaining = 150;

					break;
				}
			}
		}
	}
}