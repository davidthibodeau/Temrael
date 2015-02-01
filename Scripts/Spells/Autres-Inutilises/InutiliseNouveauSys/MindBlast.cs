using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class MindBlastSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        private static short s_Cercle = 0;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Destruction Cérébrale", "Por Corp Wis",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(1),
                SkillName.ArtMagique,
				Reagent.BlackPearl,
				Reagent.MandrakeRoot,
				Reagent.Nightshade,
				Reagent.SulfurousAsh
            );

		public MindBlastSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return true; } }

		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( CheckHSequence( m ) )
			{
                SpellHelper.Turn(Caster, m);
                int intel = Caster.Int;

                if (intel > 150)
                    intel = 150;

                double damage = (intel - m.Int) / 2.5;

                damage = SpellHelper.AdjustValue(Caster, damage);

                if (CheckResisted(m))
				{
					damage *= 0.75;

                    m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
				}

                Effects.SendTargetParticles(Caster,0x374A, 10, 15, 2038, EffectLayer.Head);

                Effects.SendTargetParticles(m,0x374A, 10, 15, 5038, EffectLayer.Head);
                m.PlaySound(0x213);

                SpellHelper.Damage(this, m, damage, 0, 0, 0, 0, 100);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private MindBlastSpell m_Owner;

			public InternalTarget( MindBlastSpell owner ) : base( 12, false, TargetFlags.Harmful )
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