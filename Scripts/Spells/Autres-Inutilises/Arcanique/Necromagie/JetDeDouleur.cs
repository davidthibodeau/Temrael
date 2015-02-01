using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Spells
{
	public class JetDeDouleurSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Jet de douleur", "In Sar",
				8,
				203,
				9031,
				Reagent.GraveDust,
				Reagent.PigIron,
                Reagent.BatWing
            );

        public JetDeDouleurSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return false; } }

		public void Target( Mobile m )
		{
            if (CheckHSequence(m))
            {
                SpellHelper.Turn(Caster, m);

                Disturb(m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                Effects.SendTargetParticles(m,0x37C4, 1, 8, 9916, 39, 3, EffectLayer.Head);
                Effects.SendTargetParticles(m,0x37C4, 1, 8, 9502, 39, 4, EffectLayer.Head);
                m.PlaySound(0x210);

                //double damage = GetNewAosDamage(30, 1, 4, true);

                //AOS.Damage(m, Caster, (int)damage, 0, 0, 0, 0, 100);
            }

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private JetDeDouleurSpell m_Owner;

            public InternalTarget(JetDeDouleurSpell owner)
                : base(12, false, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile) o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}