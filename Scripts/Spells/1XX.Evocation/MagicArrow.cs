using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server;

namespace Server.Spells
{
	public class MagicArrowSpell : Spell
	{
        public static int spellID { get { return 0; } } // TOCHANGE

        private static int s_ManaCost = 50;
        private static SkillName s_SkillForCast = SkillName.ArtMagique;
        private static int s_MinSkillForCast = 10;
        private static TimeSpan s_DureeCastCast = TimeSpan.FromSeconds(1);

		private static SpellInfo m_Info = new SpellInfo(
				"Flèche Magique", "In Por Ylem",
				SpellCircle.First,
				212,
				9041,
                s_ManaCost,
                s_DureeCastCast,
                s_SkillForCast,
                s_MinSkillForCast,
                false,
				Reagent.SulfurousAsh
            );

		public MagicArrowSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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
            else if (CheckHSequence(m))
            {
                Mobile source = Caster;

                SpellHelper.Turn(source, m);

                SpellHelper.CheckReflect((int)this.Circle, ref source, ref m);

              //  double damage = Utility.RandomMinMax(15, 20);
                double damage = Utility.RandomMinMax(7, 10);

                damage = SpellHelper.AdjustValue(Caster, damage);

                if (CheckResisted(m))
                {
                    damage *= 0.75;

                    m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                }

                damage *= GetDamageScalar(m);

                source.MovingParticles(m, 0x36E4, 5, 0, false, true, 3006, 4006, 0);
                source.PlaySound(0x1E5);

                SpellHelper.Damage(this, m, damage, 0, 0, 0, 0, 100);
            }

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private MagicArrowSpell m_Owner;

			public InternalTarget( MagicArrowSpell owner ) : base( 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
				{
					m_Owner.Target( (Mobile)o );
				}
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}