using System;
using Server.Targeting;
using Server.Network;
using Server.Misc;
using Server.Items;

namespace Server.Spells
{
	public class MurDeHaieSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly SpellInfo m_Info = new SpellInfo(
				"Mur De Haie", "Kal Ylem An Por Grav",
				SpellCircle.First,
				221,
				9022,
				false,
				Reagent.BlackPearl,
				Reagent.Garlic,
				Reagent.SpidersSilk
			);

		public MurDeHaieSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( IPoint3D p )
		{
			if ( !Caster.CanSee( p ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( SpellHelper.CheckTown( p, Caster ) && CheckSequence() )
			{
				SpellHelper.Turn( Caster, p );

				SpellHelper.GetSurfaceTop( ref p );

				int dx = Caster.Location.X - p.X;
				int dy = Caster.Location.Y - p.Y;
				int rx = (dx - dy) * 44;
				int ry = (dx + dy) * 44;

				bool eastToWest;

				if ( rx >= 0 && ry >= 0 )
				{
					eastToWest = false;
				}
				else if ( rx >= 0 )
				{
					eastToWest = true;
				}
				else if ( ry >= 0 )
				{
					eastToWest = true;
				}
				else
				{
					eastToWest = false;
				}

				Effects.PlaySound( p, Caster.Map, 0x20B );

				TimeSpan duration = GetDurationForSpell(0.1);

				int itemID = 0xDB9;

				for ( int i = -1; i <= 1; ++i )
				{
					Point3D loc = new Point3D( eastToWest ? p.X + i : p.X, eastToWest ? p.Y : p.Y + i, p.Z );
					bool canFit = SpellHelper.AdjustField( ref loc, Caster.Map, 12, false );

					if ( !canFit )
						continue;

					Item item = new InternalItem( loc, Caster.Map, duration, itemID, Caster );
					item.ProcessDelta();

					Effects.SendLocationParticles( EffectItem.Create( loc, Caster.Map, EffectItem.DefaultDuration ), 0x376A, 9, 10, 5051 );
				}
			}

			FinishSequence();
		}

		[DispellableField]
		public class InternalItem : Item
		{
			private Timer m_Timer;

			public override bool BlocksFit{ get{ return true; } }

            public InternalItem(Point3D loc, Map map, TimeSpan duration, int itemID, Mobile caster)
                : base(itemID)
            {
                Visible = false;
                Movable = false;

                MoveToWorld(loc, map);

                if (caster.InLOS(this))
                    Visible = true;
                else
                    Delete();

                if (!this.Deleted && VerifyOtherFields(caster))
                    Delete();

                if (Deleted)
                    return;

                m_Timer = new InternalTimer(this, duration);
                m_Timer.Start();
            }

            public bool VerifyOtherFields(Mobile caster)
            {
                Map map = this.Map;
                
                bool test = false;
                
                IPooledEnumerable eable = map.GetItemsInRange(this.Location, 0);

                if (this.Deleted)
                    return false;

                foreach (Item item in eable)
                {
                    if (item != null && this == item)
                        continue;

                    if (item != null && (item is MurDeFeuSpell.InternalItem || item is GeyserSpell.InternalItem || item is MurDeHaieSpell.InternalItem || item is MurDeParalysieSpell.InternalItem || item is MurDePierreSpell.InternalItem || item is MurDEnergieSpell.InternalItem))
                    {
                        caster.SendMessage("Vous ne pouvez pas lancer un mur de haie au même endroit qu'un autre mur.");
                        test = true;
                    }
                }

                return test;
            }

			public InternalItem( Serial serial ) : base( serial )
			{
				m_Timer = new InternalTimer( this, TimeSpan.FromSeconds( 5.0 ) );
				m_Timer.Start();
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

			public override void OnAfterDelete()
			{
				base.OnAfterDelete();

				if ( m_Timer != null )
					m_Timer.Stop();
			}

			private class InternalTimer : Timer
			{
				private InternalItem m_Item;

				public InternalTimer( InternalItem item, TimeSpan duration ) : base( duration )
				{
					Priority = TimerPriority.OneSecond;
					m_Item = item;

                    Priority = TimerPriority.TwoFiftyMS;
				}

				protected override void OnTick()
				{
					m_Item.Delete();
				}
			}
		}

		private class InternalTarget : Target
		{
			private MurDeHaieSpell m_Owner;

            public InternalTarget(MurDeHaieSpell owner)
                : base(12, true, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is IPoint3D )
					m_Owner.Target( (IPoint3D)o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}