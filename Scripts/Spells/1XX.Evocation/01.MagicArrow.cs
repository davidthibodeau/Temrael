using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server;
using Server.Engines.Combat;

namespace Server.Spells
{
	public class MagicArrowSpell : Spell
	{
        public static int m_SpellID { get { return 101; } } // TOCHANGE

        private static short s_Cercle = 1;

        public static readonly new SpellInfo Info = new SpellInfo(
				"Flèche Magique", "In Por Ylem",
                s_Cercle,
				212,
				9041,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(1),
                SkillName.Evocation,
				Reagent.SulfurousAsh
            );

		public MagicArrowSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
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

                source.MovingParticles(m, 0x36E4, 5, 0, false, true, 3006, 4006, 0);
                source.PlaySound(0x1E5);

                Damage.instance.AppliquerDegatsMagiques(m, Damage.instance.GetDegatsMagiques(Caster, Info.skillForCasting, Info.Circle, Info.castTime));
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