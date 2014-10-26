using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class FamineSpell : ReligiousSpell
	{
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
                "Famine", "Desi Thur",
				SpellCircle.Second,
				212,
				9041
            );

        public FamineSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
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
            else if (CheckSequence())
            {
                SpellHelper.Turn(Caster, m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                if (m is TMobile)
                {
                    /*if (DateTime.Now < ((TMobile)m).NextFamine)
                    {
                        Caster.SendMessage("Vous ne pouvez pas exécuter une autre famine sur ce personnage dès maintenant.");
                        return;
                    }
                    else
                        ((TMobile)m).NextFamine = DateTime.Now + TimeSpan.FromMinutes(5);*/
                }

                m.FixedParticles(14154, 10, 15, 5013, 0, 0, EffectLayer.Waist);
                m.PlaySound(496);
            }

            FinishSequence();
        }

		private class InternalTarget : Target
		{
            private FamineSpell m_Owner;

            public InternalTarget(FamineSpell owner)
                : base(12, false, TargetFlags.Harmful)
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