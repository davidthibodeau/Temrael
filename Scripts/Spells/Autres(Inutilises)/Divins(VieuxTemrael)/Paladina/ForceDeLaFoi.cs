using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Engines.PartySystem;

namespace Server.Spells
{
    public class ForceDeLaFoiSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
                "Force de la foi", "Haga Kena Otil",
				7,
				Core.AOS ? 239 : 215,
				9011
			);

        public ForceDeLaFoiSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
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
                    IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(p), (int)SpellHelper.AdjustValue(Caster, 1 + Caster.Skills[CastSkill].Value / 50, true));

					foreach ( Mobile m in eable )
					{
                        if (Caster.CanBeBeneficial(m, false))
    						targets.Add( m );
					}

					eable.Free();
				}

				Effects.PlaySound( p, Caster.Map, 0x299 );

				if ( targets.Count > 0 )
				{
					for ( int i = 0; i < targets.Count; ++i )
					{
						Mobile m = (Mobile)targets[i];

                        if (!Caster.CanSee(m))
                        {
                            continue;
                        }

                        Spells.ConfessionSpell.ToogleConfession(this, Caster, m, 0.30);
					}
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private ForceDeLaFoiSpell m_Owner;

            public InternalTarget(ForceDeLaFoiSpell owner)
                : base(12, true, TargetFlags.Beneficial)
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
