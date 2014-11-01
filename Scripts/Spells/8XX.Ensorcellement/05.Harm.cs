using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class HarmSpell : Spell
	{
        public static int m_SpellID { get { return 805; } } // TOCHANGE

        private static short s_Cercle = 5;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Nuisance", "An Mani",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(1),
                SkillName.ArtMagique,
				Reagent.Nightshade,
				Reagent.SpidersSilk
            );

		public HarmSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return false; } }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckHSequence(m))
            {
                SpellHelper.Turn(Caster, m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

             //   double damage = Utility.RandomMinMax(20, 40);
                double damage = Utility.RandomMinMax(10, 20);

                damage = SpellHelper.AdjustValue(Caster, damage);

                if (CheckResisted(m))
                {
                    damage *= 0.75;

                    m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                }

                damage *= GetDamageScalar(m);

                m.FixedParticles(0x374A, 10, 15, 5013, EffectLayer.Waist);
                m.PlaySound(0x1F1);

                SpellHelper.Damage(this, m, damage, 0, 0, 0, 0, 100);
            }

            FinishSequence();
        }

		private class InternalTarget : Target
		{
			private HarmSpell m_Owner;

			public InternalTarget( HarmSpell owner ) : base( 12, false, TargetFlags.Harmful )
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