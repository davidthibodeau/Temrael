using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Spells;
using Server.Items;

namespace Server.Spells
{
	public class AppelDeLaNatureSpell : ReligiousSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
                "Appel De La Nature", "Impa Desi Marc",
				SpellCircle.Second,
				212,
				9041
            );

        public override int RequiredAptitudeValue { get { return 2; } }
        public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Monial }; } }

        public AppelDeLaNatureSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return false; } }

        public void Target(IPoint3D p)
        {
            if (!Caster.CanSee(p))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckSequence())
            {
                SpellHelper.Turn(Caster, p);

				SpellHelper.GetSurfaceTop( ref p );

                Effects.SendLocationEffect(p, Caster.Map, 14120, 20, 10, 1441, 0); //p, map, item, duration, speed, hue, render
                Effects.PlaySound(p, Caster.Map, 494);//p map sound

                foreach(Mobile m in Caster.Map.GetMobilesInRange(new Point3D(p), (int)SpellHelper.AdjustValue(Caster, 10 + Caster.Skills[CastSkill].Base / 4, Aptitude.Sorcellerie, true)))
                {
                    if (m != null && !(m is BaseVendor) && m is BaseCreature && ((BaseCreature)m).DefaultAI == AIType.AI_Animal)
                    {
                        ((BaseCreature)m).TargetLocation = new Point2D((IPoint2D)p);
                        m.FixedParticles(14120, 10, 20, 5013, 1441, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                        m.PlaySound(494);
                    }
                }
            }

            FinishSequence();
        }

		private class InternalTarget : Target
		{
            private AppelDeLaNatureSpell m_Owner;

            public InternalTarget(AppelDeLaNatureSpell owner)
                : base(12, true, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is IPoint3D )
				{
                    m_Owner.Target((IPoint3D)o);
				}
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}