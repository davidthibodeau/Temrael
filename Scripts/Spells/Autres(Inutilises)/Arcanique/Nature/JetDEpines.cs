using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
	public class JetDEpinesSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		private static SpellInfo m_Info = new SpellInfo(
                "Jet D'épines", "In Vas Dras Ylem",
				SpellCircle.Seventh,
				212,
				9041,
				Reagent.SulfurousAsh,
				Reagent.MandrakeRoot,
				Reagent.Ginseng
			);

        public JetDEpinesSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( CheckHSequence( m ) )
			{
                Mobile source = Caster;

                SpellHelper.Turn(source, m);

                Disturb(m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                if (Caster.CheckSkill(SkillName.ArtMagique, 0, 120))
                {
                    Item item = m.FindItemOnLayer(Layer.OneHanded);
                    if (item != null)
                        item.MoveToWorld(m.Location, m.Map);

                    item = m.FindItemOnLayer(Layer.TwoHanded);
                    if (item != null)
                        item.MoveToWorld(m.Location, m.Map);

                    m.PlaySound(0x21C);
                    m.SendMessage("Des épines vous piquent le bout des doigts et vous désarment !");
                }
                else
                {
                    Caster.SendMessage("Vous ratez les mains de votre adversaire, mais vous le blessez quand même légèrement !");
                    AOS.Damage(Caster, m, Utility.Random(1, 10), 0, 0, 0, 0, 100);
                }
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private JetDEpinesSpell m_Owner;

            public InternalTarget(JetDEpinesSpell owner)
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