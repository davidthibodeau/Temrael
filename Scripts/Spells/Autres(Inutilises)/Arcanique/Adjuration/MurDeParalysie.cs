using System;
using Server.Targeting;
using Server.Items;
using Server.Network;
using Server.Misc;
using Server.Mobiles;

namespace Server.Spells
{
	public class MurDeParalysieSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Mur De Paralysie", "In Ex Grav",
				SpellCircle.Seventh,
				230,
				9012,
				false,
				Reagent.MandrakeRoot,
				Reagent.Ginseng,
				Reagent.SpidersSilk
            );

        public MurDeParalysieSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
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
			else if ( /*SpellHelper.CheckTown( p, Caster ) && */CheckSequence() )
			{
				SpellHelper.Turn( Caster, p );

				SpellHelper.GetSurfaceTop( ref p );

				int dx = Caster.Location.X - p.X;
				int dy = Caster.Location.Y - p.Y;
				int rx = (dx - dy) * 44;
				int ry = (dx + dy) * 44;

				bool eastToWest;

				if ( rx >= 0 && ry >= 0 )
					eastToWest = false;
				else if ( rx >= 0 )
					eastToWest = true;
				else if ( ry >= 0 )
					eastToWest = true;
				else
					eastToWest = false;

				Effects.PlaySound( p, Caster.Map, 0x20B );

                int itemID = eastToWest ? 0x3967 : 0x3979;

                TimeSpan duration = GetDurationForSpell(0.7);

				for ( int i = -3; i <= 3; ++i )
				{
					Point3D loc = new Point3D( eastToWest ? p.X + i : p.X, eastToWest ? p.Y : p.Y + i, p.Z );
					bool canFit = SpellHelper.AdjustField( ref loc, Caster.Map, 12, false );

					if ( !canFit )
						continue;

					Item item = new InternalItem( Caster, itemID, loc, Caster.Map, duration );
					item.ProcessDelta();

					Effects.SendLocationParticles( EffectItem.Create( loc, Caster.Map, EffectItem.DefaultDuration ), 0x376A, 9, 10, 5048 );
				}
			}

			FinishSequence();
		}

		[DispellableField]
		public class InternalItem : Item
		{
			private Timer m_Timer;
			private Mobile m_Caster;
			private DateTime m_End;

			public override bool BlocksFit{ get{ return true; } }

			public InternalItem( Mobile caster, int itemID, Point3D loc, Map map, TimeSpan duration ) : base( itemID )
			{
				Visible = false;
				Movable = false;
				Light = LightType.Circle300;

				MoveToWorld( loc, map );

                if (caster.InLOS(this))
                    Visible = true;
                else
                    Delete();

                if (!this.Deleted && VerifyOtherFields(caster))
                    Delete();

                if (Deleted)
                    return;

				m_Caster = caster;

				m_Timer = new InternalTimer( this, duration );
				m_Timer.Start();

				m_End = DateTime.Now + duration;
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
                        caster.SendMessage("Vous ne pouvez pas lancer un mur de paralysie au même endroit qu'un autre mur.");
                        test = true;
                    }
                }

                return test;
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

				writer.Write( (int) 0 ); // version

				writer.Write( m_Caster );
				writer.WriteDeltaTime( m_End );
			}

			public override void Deserialize( GenericReader reader )
			{
				base.Deserialize( reader );

				int version = reader.ReadInt();

				switch ( version )
				{
					case 0:
					{
						m_Caster = reader.ReadMobile();
						m_End = reader.ReadDeltaTime();

						m_Timer = new InternalTimer( this, m_End - DateTime.Now );
						m_Timer.Start();

						break;
					}
				}
			}

			public override bool OnMoveOver( Mobile m )
			{
				if ( Visible && m_Caster != null && SpellHelper.ValidIndirectTarget( m_Caster, m ) && m_Caster.CanBeHarmful( m, false ) )
				{
					m_Caster.DoHarmful( m );

                    double duration = 5.0 + (m_Caster.Skills[SkillName.ArtMagique].Value * 0.2);

                    duration = SpellHelper.AdjustValue(m_Caster, duration);

					m.Paralyze( TimeSpan.FromSeconds( duration ) );

					m.PlaySound( 0x204 );
					m.FixedEffect( 0x376A, 10, 16 );
				}

				return true;
			}

			private class InternalTimer : Timer
			{
				private Item m_Item;

				public InternalTimer( Item item, TimeSpan duration ) : base( duration )
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
            private MurDeParalysieSpell m_Owner;

            public InternalTarget(MurDeParalysieSpell owner)
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