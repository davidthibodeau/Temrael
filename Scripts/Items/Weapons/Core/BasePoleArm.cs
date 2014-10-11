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
	public abstract class BasePoleArm : BaseMeleeWeapon, IUsesRemaining
	{
		public override int DefHitSound{ get{ return 0x237; } }
		public override int DefMissSound{ get{ return 0x238; } }

		public override WeaponType DefType{ get{ return WeaponType.Polearm; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Slash2H; } }

        public override CombatStrategy Strategy { get { return StrategyHaste.Strategy; } }

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

		public BasePoleArm( int itemID ) : base( itemID )
		{
			m_UsesRemaining = 150;
            Layer = Layer.TwoHanded;
		}

		public BasePoleArm( Serial serial ) : base( serial )
		{
            Layer = Layer.TwoHanded;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( HarvestSystem == null )
				return;

			if ( IsChildOf( from.Backpack ) || Parent == from )
				HarvestSystem.BeginHarvesting( from, this );
			else
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
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

            writer.Write((int)0); // version

			writer.Write( (bool) m_ShowUsesRemaining );

			writer.Write( (int) m_UsesRemaining );
		}

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_ShowUsesRemaining = reader.ReadBool();

            m_UsesRemaining = reader.ReadInt();

            if (m_UsesRemaining < 1)
                m_UsesRemaining = 150;
        }
	}
}