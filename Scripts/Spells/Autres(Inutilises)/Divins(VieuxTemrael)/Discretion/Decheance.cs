using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class DecheanceSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		private static SpellInfo m_Info = new SpellInfo(
                "Déchéance", "Mann Dowu",
				SpellCircle.Eighth,
				212,
				9041
            );

        public DecheanceSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
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
                    TMobile pm = (TMobile)m;

                    pm.DispelAllTransformations();

                    if (pm.Identities.Disguised)
                        pm.Identities.Disguised = false;

                    /*if (pm.m_DeguisementInfos != null)
                    {
                        Deguisements.RemoveDeguisement(pm);
                        pm.NextDisguiseTime = DateTime.Now + TimeSpan.FromMinutes(30.0);
                    }*/
                }
                else
                {
                    m.NameMod = null;
                    m.BodyMod = 0;
                    m.HueMod = -1;
                }

                m.FixedParticles(14170, 10, 15, 5013, 1109, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(501);
            }

            FinishSequence();
        }

		private class InternalTarget : Target
		{
            private DecheanceSpell m_Owner;

            public InternalTarget(DecheanceSpell owner)
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