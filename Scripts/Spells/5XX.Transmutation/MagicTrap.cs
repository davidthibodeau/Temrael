using System;
using Server.Targeting;
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Spells
{
	public class MagicTrapSpell : Spell
	{
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        private static short s_Cercle = 0;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Piège Magique", "In Jux",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(1),
                SkillName.ArtMagique,
				Reagent.Garlic,
				Reagent.SpidersSilk,
				Reagent.SulfurousAsh
            );

		public MagicTrapSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( TrapableContainer item )
		{
			if ( !Caster.CanSee( item ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( item.TrapType != TrapType.None && item.TrapType != TrapType.MagicTrap )
			{
				base.DoFizzle();
			}
			else if ( CheckSequence() )
			{
				SpellHelper.Turn( Caster, item );

                item.TrapType = TrapType.MagicTrap;

                double damage = Utility.Random(10, 50);

                damage = SpellHelper.AdjustValue(Caster, damage);

				item.TrapPower = (int)damage;

				Point3D loc = item.GetWorldLocation();

				Effects.SendLocationParticles( EffectItem.Create( new Point3D( loc.X + 1, loc.Y, loc.Z ), item.Map, EffectItem.DefaultDuration ), 0x376A, 9, 10, 9502 );
				Effects.SendLocationParticles( EffectItem.Create( new Point3D( loc.X, loc.Y - 1, loc.Z ), item.Map, EffectItem.DefaultDuration ), 0x376A, 9, 10, 9502 );
				Effects.SendLocationParticles( EffectItem.Create( new Point3D( loc.X - 1, loc.Y, loc.Z ), item.Map, EffectItem.DefaultDuration ), 0x376A, 9, 10, 9502 );
				Effects.SendLocationParticles( EffectItem.Create( new Point3D( loc.X, loc.Y + 1, loc.Z ), item.Map, EffectItem.DefaultDuration ), 0x376A, 9, 10, 9502 );
				Effects.SendLocationParticles( EffectItem.Create( new Point3D( loc.X, loc.Y,     loc.Z ), item.Map, EffectItem.DefaultDuration ), 0, 0, 0, 5014 );

				Effects.PlaySound( loc, item.Map, 0x1EF );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private MagicTrapSpell m_Owner;

			public InternalTarget( MagicTrapSpell owner ) : base( 12, false, TargetFlags.None )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is TrapableContainer )
				{
					m_Owner.Target( (TrapableContainer)o );
				}
				else
				{
					from.SendMessage( "You can't trap that" );
				}
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}