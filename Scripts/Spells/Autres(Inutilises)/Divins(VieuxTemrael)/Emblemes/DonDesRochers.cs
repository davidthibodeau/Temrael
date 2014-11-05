using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Spells;
using Server.Items;

namespace Server.Spells
{
	public class DonDesRochersSpell : ReligiousSpell
	{
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
                "Don des rochers", "Gebo Tiwa Algi",
				7,
				212,
				9041
            );

        public DonDesRochersSpell(Mobile caster, Item scroll)
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

                int ItemID = 4963;
                string name = "Don des rochers";
                int hue = 0;

                TotemType type = TotemType.DonDesRochers;
                DateTime delete = DateTime.Now + TimeSpan.FromSeconds(0);
                int range = 1 + (int)(Caster.Skills[CastSkill].Value / 10);
                double bonus = 5 + (double)((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 8);//5 à 30%

                int effectid = 14201;
                int effectspeed = 10;
                int effectduration = 20;
                EffectLayer layer = EffectLayer.Waist;
                int soundid = 533;

                Totem totem = new Totem(ItemID, name, hue, range, type, delete, Caster, bonus, effectid, effectspeed, effectduration, layer, soundid);

                if (totem != null)
                {
                    totem.MoveToWorld(new Point3D(p), Caster.Map);
                    totem.FixedParticles(effectid, effectspeed, effectduration, 5005, hue, 0, layer);
                    totem.PlaySound(soundid);
                }
            }

            FinishSequence();
        }

		private class InternalTarget : Target
		{
            private DonDesRochersSpell m_Owner;

            public InternalTarget(DonDesRochersSpell owner)
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