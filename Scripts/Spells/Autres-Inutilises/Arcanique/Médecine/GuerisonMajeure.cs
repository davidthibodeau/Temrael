using System;
using Server;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class GuerisonMajeureSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Guerison Majeure", "In Vas Mani",
				6,
				204,
				9061,
				Reagent.Garlic,
				Reagent.Ginseng,
				Reagent.SpidersSilk
            );

        public GuerisonMajeureSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
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
			else if ( m is BaseCreature && ((BaseCreature)m).IsAnimatedDead )
			{
				Caster.SendLocalizedMessage( 1061654 ); // You cannot heal that which is not alive.
			}
			else if ( m.IsDeadBondedPet )
			{
				Caster.SendLocalizedMessage( 1060177 ); // You cannot heal a creature that is already dead!
			}
			else if ( m.Poisoned )
			{
				Caster.LocalOverheadMessage( MessageType.Regular, 0x22, (Caster == m) ? 1005000 : 1010398 );
			}
			else if ( CheckBSequence( m ) )
			{
                ToogleGreaterHeal(this, Caster, m, 1.0);
			}

			FinishSequence();
		}

        public static void ToogleGreaterHeal(Spell spell, Mobile Caster, Mobile m, double scale)
        {
            SpellHelper.Turn(Caster, m);

            double toHeal;

            toHeal = Caster.Skills[SkillName.ArtMagique].Value * scale;
            toHeal += Utility.Random(1, 5);

            toHeal += Caster.Skills[SkillName.Soins].Value * scale / 3;

            toHeal = SpellHelper.AdjustValue(Caster, toHeal);

            if (RegenerescenceSpell.m_RegenerescenceTable.Contains(m))
                toHeal *= (double)RegenerescenceSpell.m_RegenerescenceTable[m];

            SpellHelper.Heal(m, (int)toHeal, true);

            m.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);
            m.PlaySound(0x202);
        }

		public class InternalTarget : Target
		{
            private GuerisonMajeureSpell m_Owner;

            public InternalTarget(GuerisonMajeureSpell owner)
                : base(12, false, TargetFlags.Beneficial)
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