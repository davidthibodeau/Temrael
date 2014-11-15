using System;
using System.Collections;
using Server.Misc;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Spells
{
	public class MassDispelSpell : Spell
	{
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        private static short s_Cercle = 0;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Dissipation de Masse", "Vas An Ort",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(1),
                SkillName.Transmutation,
				Reagent.Garlic,
				Reagent.MandrakeRoot,
				Reagent.BlackPearl,
				Reagent.SulfurousAsh
            );

		public MassDispelSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( IPoint3D p )
		{
			if ( !Caster.CanSee( p ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( CheckSequence() )
			{
				SpellHelper.Turn( Caster, p );

				SpellHelper.GetSurfaceTop( ref p );

				ArrayList targets = new ArrayList();

				Map map = Caster.Map;

				if ( map != null )
				{
					IPooledEnumerable eable = map.GetMobilesInRange( new Point3D( p ), 4 );

					foreach ( Mobile m in eable )
					{
						if ( m is BaseCreature && ((BaseCreature)m).Summoned && !((BaseCreature)m).IsAnimatedDead && Caster.CanBeHarmful( m, false ) )
							targets.Add( m );
					}

					eable.Free();
				}

				for ( int i = 0; i < targets.Count; ++i )
				{
					Mobile m = (Mobile)targets[i];

					BaseCreature bc = m as BaseCreature;

					if ( bc == null )
						continue;

					double dispelChance = (50.0 + ((100 * (Caster.Skills.Necromancie.Value - bc.DispelDifficulty)) / (bc.DispelFocus * 2))) / 120;

					if ( dispelChance > Utility.RandomDouble() )
                    {
                        Effects.SendLocationParticles(EffectItem.Create(m.Location, m.Map, EffectItem.DefaultDuration), 0x3728, 8, 20, 5042);
                        Effects.PlaySound(m, m.Map, 0x201);

                        m.Delete();
					}
					else
                    {
                        Caster.DoHarmful(m);

                        m.FixedEffect(0x3779, 10, 20);
                        Caster.SendLocalizedMessage(1010084); // The creature resisted the attempt to dispel it!
					}
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private MassDispelSpell m_Owner;

			public InternalTarget( MassDispelSpell owner ) : base( 12, true, TargetFlags.None )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				IPoint3D p = o as IPoint3D;

				if ( p != null )
					m_Owner.Target( p );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}