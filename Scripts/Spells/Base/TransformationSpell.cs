using System;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Spells;

using Server.Scripts.Commands;

namespace Server.Spells
{
	public abstract class TransformationSpell : NecromancerSpell
	{
		public abstract int Body{ get; }
		public virtual int Hue{ get{ return 0; } }

		public virtual int StrOffset{ get{ return 0; } }
		public virtual int DexOffset{ get{ return 0; } }
		public virtual int IntOffset{ get{ return 0; } }

		public TransformationSpell( Mobile caster, Item scroll, SpellInfo info ) : base( caster, scroll, info )
		{
		}

		public override bool BlockedByHorrificBeast{ get{ return false; } }

		public override bool CheckCast()
		{
			if ( Caster.Mounted )
			{
				Caster.SendLocalizedMessage( 1042561 ); // Please dismount first.
				return false;
            }
            else if (!Caster.CanBeginAction(typeof(IncognitoSpell)))
            {
                Caster.SendMessage("Vous ne pouvez faire ce sort en étant sous l'effet de l'incognito.");
                return false;
            }
            else if (!Caster.CanBeginAction(typeof(PolymorphSpell)))
            {
                Caster.SendMessage("Vous ne pouvez faire ce sort en étant transformé.");
                return false;
            }
            /*else if (!Caster.CanBeginAction(typeof(ChauveSouris)))
            {
                Caster.SendMessage("Vous ne pouvez vous transformer en étant sous la forme d'une chauve-souris.");
            }*/
            /*else if (TransformationSpell.UnderTransformation(Caster))
            {
                Caster.SendLocalizedMessage(1005559); // This spell is already in effect.
                return false;
            }*/

			return base.CheckCast();
		}

		public override void OnCast()
		{
			Mobile caster = this.Caster;

			if ( caster.Mounted )
			{
				caster.SendLocalizedMessage( 1042561 ); // Please dismount first.
            }
            else if (!caster.CanBeginAction(typeof(IncognitoSpell)))
            {
                caster.SendMessage("Vous ne pouvez faire ce sort en étant sous l'effet de l'incognito.");
            }
            else if (!caster.CanBeginAction(typeof(PolymorphSpell)))
            {
                caster.SendMessage("Vous ne pouvez faire ce sort en étant transformé.");
            }
            /*else if (!caster.CanBeginAction(typeof(ChauveSouris)))
            {
                caster.SendMessage("Vous ne pouvez vous transformer en étant sous la forme d'une chauve-souris.");
            }
            else if (caster is PlayerMobile && ((PlayerMobile)caster).Disguised)
            {
                caster.SendMessage("Vous ne pouvez faire ce sort en étant déguisé.");
            }*/
			else if ( CheckSequence() )
			{
				TransformContext context = GetContext( caster );
				Type ourType = this.GetType();

				bool wasTransformed = ( context != null );
				bool ourTransform = ( wasTransformed && context.Type == ourType );

				if ( wasTransformed )
				{
					RemoveContext( caster, context, ourTransform );

					if ( ourTransform )
					{
						caster.PlaySound( 0xFA );
						Effects.SendTargetParticles(Caster, 0x3728, 1, 13, 5042, EffectLayer.Waist );
					}
				}

				if ( !ourTransform )
				{
					ArrayList mods = new ArrayList();

					if ( StrOffset != 0 )
						mods.Add( new StatMod(StatType.Str, "TransformationSpell", StrOffset, TimeSpan.FromDays(90.0)));

                    if (DexOffset != 0)
                        mods.Add(new StatMod(StatType.Dex, "TransformationSpell", DexOffset, TimeSpan.FromDays(90.0)));

                    if (IntOffset != 0)
                        mods.Add(new StatMod(StatType.Int, "TransformationSpell", IntOffset, TimeSpan.FromDays(90.0)));

					if ( !((Body)this.Body).IsHuman )
					{
						Mobiles.IMount mt = Caster.Mount;

						if ( mt != null )
							mt.Rider = null;
					}

					caster.BodyMod = this.Body;
					caster.HueMod = this.Hue;

					for ( int i = 0; i < mods.Count; ++i )
                        caster.AddStatMod((StatMod)mods[i]);

					PlayEffect( caster );

					Timer timer = new TransformTimer(caster, this);
					timer.Start();

					AddContext( caster, new TransformContext( timer, mods, ourType ) );
				}
			}

			FinishSequence();
		}

		public virtual double TickRate{ get{ return 1.0; } }

		public virtual void OnTick( Mobile m )
		{
		}

		public virtual void PlayEffect( Mobile m )
		{
		}

		private static Hashtable m_Table = new Hashtable();

		public static void AddContext( Mobile m, TransformContext context )
		{
			m_Table[m] = context;

			//if ( context.Type == typeof( HorrificBeastSpell ) )
			// 	m.Delta( MobileDelta.WeaponDamage );
		}

		public static void RemoveContext( Mobile m, bool resetGraphics )
		{
			TransformContext context = GetContext( m );

			if ( context != null )
				RemoveContext( m, context, resetGraphics );
		}

		public static void RemoveContext( Mobile m, TransformContext context, bool resetGraphics )
		{
			m_Table.Remove( m );

			ArrayList mods = context.Mods;

			for ( int i = 0; i < mods.Count; ++i )
                m.RemoveStatMod(((StatMod)mods[i]).Name);

			if ( resetGraphics )
			{
				m.HueMod = -1;
				m.BodyMod = 0;
			}

			context.Timer.Stop();

            if (m is PlayerMobile)
                ((PlayerMobile)m).CheckRaceSkin();

			//if ( context.Type == typeof( HorrificBeastSpell ) )
			//	m.Delta( MobileDelta.WeaponDamage );
		}

		public static TransformContext GetContext( Mobile m )
		{
			return ( m_Table[m] as TransformContext );
		}

		public static bool UnderTransformation( Mobile m )
		{
			return ( GetContext( m ) != null );
		}

		public static bool UnderTransformation( Mobile m, Type type )
		{
			TransformContext context = GetContext( m );

			return ( context != null && context.Type == type );
		}
	}
}