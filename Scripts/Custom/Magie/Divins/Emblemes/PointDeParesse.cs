using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Spells;
using Server.Items;

namespace Server.Spells
{
	public class PointDeParesseSpell : ReligiousSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
                "Point de paresse", "Gebo Toki Hiro",
				SpellCircle.Fourth,
				212,
				9041
            );

        public override int RequiredAptitudeValue { get { return 3; } }
        public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Protection }; } }

        public PointDeParesseSpell(Mobile caster, Item scroll)
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

                int ItemID = 3796;
                string name = "Point de paresse";
                int hue = 1942;

                TotemType type = TotemType.PointDeParesse;
                DateTime delete = DateTime.Now + GetDurationForSpell(0.5);
                int range = 1 + (int)(Caster.Skills[CastSkill].Value / 10);
                double bonus = 1 + (Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 100;

                int effectid = 14138;
                int effectspeed = 10;
                int effectduration = 20;
                EffectLayer layer = EffectLayer.Waist;
                int soundid = 501;

                Totem totem = new Totem(ItemID, name, hue, range, type, delete, Caster, bonus, effectid, effectspeed, effectduration, layer, soundid);

                if (totem != null)
                {
                    totem.MoveToWorld(new Point3D(p), Caster.Map);
                    totem.FixedParticles(effectid, effectspeed, effectduration, 5005, hue, 0, layer);
                    totem.PlaySound(soundid);
                }

                new PointDeParesseTimer(totem).Start();
            }

            FinishSequence();
        }

        public class PointDeParesseTimer : Timer
        {
            private Totem m_BaseTotem;

            public PointDeParesseTimer(Totem totem)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(5))
            {
                m_BaseTotem = totem;
            }

            protected override void OnTick()
            {
                if (m_BaseTotem == null || m_BaseTotem.Deleted || m_BaseTotem.Caster == null || m_BaseTotem.Caster.Deleted || !m_BaseTotem.Caster.Alive)
                {
                    Stop();
                    m_BaseTotem.Delete();
                    return;
                }

                foreach (Mobile m in m_BaseTotem.GetMobilesInRange(1 + (int)(m_BaseTotem.Caster.Skills[SkillName.Miracles].Base / 10)))
                {
                    /*if (m != null && m.Alive && m.CanSee(m_BaseTotem) && m is TMobile)
                        ((TMobile)m).AddFatigue(-1 * (int)m_BaseTotem.Bonus);*/
                }
            }
        }

		private class InternalTarget : Target
		{
            private PointDeParesseSpell m_Owner;

            public InternalTarget(PointDeParesseSpell owner)
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