using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Engines.PartySystem;

namespace Server.Spells
{
	public class HallucinationsSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly SpellInfo m_Info = new SpellInfo(
                "Hallucinations", "Vas Kal In Ex",
				SpellCircle.Sixth,
				Core.AOS ? 239 : 215,
				9011,
				Reagent.Garlic,
				Reagent.MandrakeRoot,
				Reagent.BlackPearl
			);

        public HallucinationsSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
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
					IPooledEnumerable eable = map.GetMobilesInRange( new Point3D( p ), 3 );

					foreach ( Mobile m in eable )
					{
                        if (Caster.CanBeBeneficial(m, false))
    						targets.Add( m );
					}

					eable.Free();
				}

				Effects.PlaySound( p, Caster.Map, 0x299 );

                if (targets.Count > 0)
                {
                    for (int i = 0; i < targets.Count; ++i)
                    {
                        Mobile m = (Mobile)targets[i];

                        if (!Caster.CanSee(m))
                        {
                            continue;
                        }

                        Spells.OmbreSpell.CheckIncognito(this, Caster, m);
                    }
                }
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private HallucinationsSpell m_Owner;

            public InternalTarget(HallucinationsSpell owner)
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
