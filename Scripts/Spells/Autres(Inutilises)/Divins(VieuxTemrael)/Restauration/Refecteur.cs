using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Spells;
using Server.Items;

namespace Server.Spells
{
	public class RefecteurSpell : ReligiousSpell
	{
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
                "Réfecteur", "Gebo Otil Algi",
				SpellCircle.Seventh,
				212,
				9041
            );

        public RefecteurSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
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

                int ItemID = 9328;
                string name = "Réfecteur";
                int hue = 1942;

                TotemType type = TotemType.Refecteur;
                DateTime delete = DateTime.Now + GetDurationForSpell(0.3);
                int range = 1 + (int)(Caster.Skills[CastSkill].Value / 20);
                double bonus = 1 + (double)((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 25);

                int effectid = 14170;
                int effectspeed = 9;
                int effectduration = 18;
                EffectLayer layer = EffectLayer.Head;
                int soundid = 533;

                Totem totem = new Totem(ItemID, name, hue, range, type, delete, Caster, bonus, effectid, effectspeed, effectduration, layer, soundid);

                if (totem != null)
                {
                    totem.MoveToWorld(new Point3D(p), Caster.Map);
                    totem.FixedParticles(effectid, effectspeed, effectduration, 5005, hue, 0, layer);
                    totem.PlaySound(soundid); 
                }

                new RefecteurTimer(totem).Start();
            }

            FinishSequence();
        }

        public class RefecteurTimer : Timer
        {
            private Totem m_BaseTotem;

            public RefecteurTimer(Totem totem)
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

                foreach (Mobile m in m_BaseTotem.GetMobilesInRange(m_BaseTotem.MaxRange))
                {
                    if (m != null && m.Alive && m.CanSee(m_BaseTotem) && m is TMobile)
                    {
                        SpellHelper.Heal(m, (int)m_BaseTotem.Bonus + Utility.Random(0, 5), true);
                    }
                }
            }
        }

		private class InternalTarget : Target
		{
            private RefecteurSpell m_Owner;

            public InternalTarget(RefecteurSpell owner)
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