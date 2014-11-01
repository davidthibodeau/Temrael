using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Engines.Combat;

namespace Server.Spells
{
	public class EnergyBoltSpell : Spell
	{
        public static int m_SpellID { get { return 104; } } // TOCHANGE

        private static short s_Cercle = 4;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Énergie", "Corp Por",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(1),
                SkillName.ArtMagique,
				Reagent.BlackPearl,
				Reagent.Nightshade
            );

		public EnergyBoltSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
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

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                m.FixedParticles(0x36BD, 20, 10, 5044, EffectLayer.Head);
                m.PlaySound(0x307);

                Damage.instance.AppliquerDegatsMagiques(m, Damage.instance.GetDegatsMagiques(Caster, Info.skillForCasting, Info.Circle, Info.castTime));

				m.MovingParticles( m, 0x379F, 7, 0, false, true, 3043, 4043, 0x211 );
				m.PlaySound( 0x20A );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private EnergyBoltSpell m_Owner;

			public InternalTarget( EnergyBoltSpell owner ) : base( 12, false, TargetFlags.Harmful )
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