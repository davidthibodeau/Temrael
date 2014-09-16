using System;
using Server.Targeting;
using Server.Network;
using Server.Items;
using Server.Misc;

namespace Server.Spells
{
	public class DispelFieldSpell : Spell
	{
        public static int spellID { get { return 0; } } // TOCHANGE

        private static int s_ManaCost = 50;
        private static SkillName s_SkillForCast = SkillName.ArtMagique;
        private static int s_MinSkillForCast = 50;
        private static TimeSpan s_Duree = TimeSpan.FromSeconds(1);

		private static SpellInfo m_Info = new SpellInfo(
				"Champ de Dissipation", "An Grav",
				SpellCircle.Fifth,
				206,
				9002,
                s_ManaCost,
                s_Duree,
                s_SkillForCast,
                s_MinSkillForCast,
                false,
				Reagent.BlackPearl,
				Reagent.SpidersSilk,
				Reagent.SulfurousAsh,
				Reagent.Garlic
            );

		public DispelFieldSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Item item )
		{
			Type t = item.GetType();

			if ( !Caster.CanSee( item ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( !t.IsDefined( typeof( DispellableFieldAttribute ), false ) )
			{
				Caster.SendLocalizedMessage( 1005049 ); // That cannot be dispelled.
			}
			else if ( item is Moongate && !((Moongate)item).Dispellable )
			{
				Caster.SendLocalizedMessage( 1005047 ); // That magic is too chaotic
			}
			else if ( CheckSequence() )
			{
				SpellHelper.Turn( Caster, item );

				Effects.SendLocationParticles( EffectItem.Create( item.Location, item.Map, EffectItem.DefaultDuration ), 0x376A, 9, 20, 5042 );
				Effects.PlaySound( item.GetWorldLocation(), item.Map, 0x201 );

				item.Delete();
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private DispelFieldSpell m_Owner;

			public InternalTarget( DispelFieldSpell owner ) : base( 12, false, TargetFlags.None )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Item )
				{
					m_Owner.Target( (Item)o );
				}
				else
				{
					m_Owner.Caster.SendLocalizedMessage( 1005049 ); // That cannot be dispelled.
				}
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}