using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
	public class RacinesSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Racines", "An Por Choma",
				SpellCircle.Fifth,
				218,
				9012,
				Reagent.Garlic,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
			);

        public RacinesSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                TimeSpan duration = TimeSpan.FromSeconds(0.5) + GetDurationForSpell(0.1);

                m.Paralyze(duration);

				Point3D loc = new Point3D( m.X + 1, m.Y, m.Z );
                new InternalItem(0x1A9E, loc, Caster, m.Map, duration);
				loc = new Point3D( m.X + 1, m.Y + 1, m.Z );
                new InternalItem(0x1A9F, loc, Caster, m.Map, duration);
				loc = new Point3D( m.X, m.Y + 1, m.Z );
                new InternalItem(0x1AA0, loc, Caster, m.Map, duration);

				m.PlaySound( 0x204 );
				m.FixedEffect( 0x376A, 6, 1 );
			}

			FinishSequence();
		}
		
		private class InternalItem : Item
		{
			private Timer m_Timer;
			private Mobile m_Caster;
			private TimeSpan m_Dura;

			public override bool BlocksFit{ get{ return true; } }

			public InternalItem( int itemID, Point3D loc, Mobile caster, Map map, TimeSpan duration ) : base( itemID )
			{
				bool canFit = SpellHelper.AdjustField( ref loc, map, 12, false );

				Visible = true;
				Movable = false;

				MoveToWorld( loc, map );

				m_Caster = caster;
				m_Dura = duration;
				m_Timer = new InternalTimer( this, duration );
				m_Timer.Start();
			}

			public override void OnAfterDelete()
			{
				base.OnAfterDelete();

				if ( m_Timer != null )
					m_Timer.Stop();
			}

			public InternalItem( Serial serial ) : base( serial )
			{
			}

			public override void Serialize( GenericWriter writer )
			{
				base.Serialize( writer );

				writer.Write( (int) 1 ); // version

				writer.Write( m_Caster );
			}

			public override void Deserialize( GenericReader reader )
			{
				base.Deserialize( reader );

				int version = reader.ReadInt();

				switch ( version )
				{
					case 1:
					{
						m_Caster = reader.ReadMobile();

						goto case 0;
					}
					case 0:
					{
						m_Timer = new InternalTimer( this, m_Dura );
						m_Timer.Start();

						break;
					}
				}
			}

			private class InternalTimer : Timer
			{
				private InternalItem m_Item;

				public InternalTimer( InternalItem item, TimeSpan duration ) : base( duration )
				{
					m_Item = item;
					Priority = TimerPriority.FiftyMS;
				}

				protected override void OnTick()
				{
					if ( m_Item.Deleted )
						return;

					m_Item.Delete();
				}
			}
		}

		public class InternalTarget : Target
		{
            private RacinesSpell m_Owner;

            public InternalTarget(RacinesSpell owner)
                : base(12, false, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile)o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}