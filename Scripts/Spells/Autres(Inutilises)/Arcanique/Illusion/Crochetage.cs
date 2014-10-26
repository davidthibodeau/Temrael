using System;
using Server.Targeting;
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Spells
{
	public class CrochetageSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Crochetage", "Ex Por",
				SpellCircle.Third,
				215,
				9001,
				Reagent.Bloodmoss,
				Reagent.SulfurousAsh,
                Reagent.Garlic
            );

        public CrochetageSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( LockableContainer targ )
		{
			if ( Multis.BaseHouse.CheckSecured( targ ) )
			{
				// You cannot cast this on a secure item.
				Caster.SendLocalizedMessage( 503098 );
			}
			else if ( CheckSequence() )
			{
				SpellHelper.Turn( Caster, targ );

				Point3D loc = targ.GetWorldLocation();

				Effects.SendLocationParticles(
					EffectItem.Create( loc, targ.Map, EffectItem.DefaultDuration ),
					0x376A, 9, 32, 5024 );

				Effects.PlaySound( loc, targ.Map, 0x1FF );

				if ( targ.Locked && targ.LockLevel == -255 )
				{
                    double level = Caster.Skills[CastSkill].Value;

                    level = SpellHelper.AdjustValue(Caster, level);

					if ( (int)level >= targ.RequiredSkill )
					{
						targ.Locked = false;
					}
					else
					{
                        Caster.SendMessage("Vous n'êtes pas assez compétent pour ouvrir ce coffre !");
					}
				}
				else
				{
                    // My spell does not seem to have an effect on that lock.
                    Caster.LocalOverheadMessage(MessageType.Regular, 0x3B2, 503099);
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private CrochetageSpell m_Owner;

            public InternalTarget(CrochetageSpell owner)
                : base(12, false, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is LockableContainer )
					m_Owner.Target( (LockableContainer)o );
				else
					from.SendLocalizedMessage( 501666 ); // You can't unlock that!

				// TODO: Really we can cast on anything, even mobiles, but it will effect and say 'That did not need to be unlocked'
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}