using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class SouffleDEspritSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Souffle D'esprit", "Por Corp Wis",
				SpellCircle.Fifth,
				218,
				9032,
				Reagent.BlackPearl,
				Reagent.MandrakeRoot,
				Reagent.Garlic
            );

        public SouffleDEspritSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
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

                Disturb(m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                int intel = Caster.Int;

                double damage = GetNewAosDamage(30, 1, 3, true);

                Caster.FixedParticles(0x374A, 10, 15, 2038, EffectLayer.Head);

                m.FixedParticles(0x374A, 10, 15, 5038, EffectLayer.Head);
                m.PlaySound(0x213);

                SpellHelper.Damage(this, m, damage, 0, 0, 0, 0, 100);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private SouffleDEspritSpell m_Owner;

            public InternalTarget(SouffleDEspritSpell owner)
                : base(12, false, TargetFlags.Harmful)
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