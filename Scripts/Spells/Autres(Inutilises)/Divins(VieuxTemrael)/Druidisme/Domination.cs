using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class DominationSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
                "Domination", "Impa Haga Perth",
				SpellCircle.Seventh,
				212,
				9041
            );

        public DominationSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return false; } }

        public void Target(BaseCreature m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (!m.Tamable || (m.Controlled && m.ControlMaster != null) || m is BaseVendor || (m.Summoned && m.SummonMaster != null) || m.Skills[SkillName.ArtMagique].Base < m.MinTameSkill)
            {
                Caster.SendMessage("Vous ne pouvez pas dominer : " + m.Name);
            }
            else if (CheckSequence())
            {
                SpellHelper.Turn(Caster, m);

                // Passively check animal lore for gain
                Caster.CheckTargetSkill(SkillName.Dressage, m, 0.0, 120.0);

                double minSkill, maxSkill;

                GetCastSkills(out minSkill, out maxSkill);

                if (Caster.CheckTargetSkill(SkillName.Dressage, m, minSkill, maxSkill))
                {
                    m.PrivateOverheadMessage(MessageType.Regular, 0x3B2, 502799, m.NetState); // It seems to accept you as master.

                    //m.EndDomination = DateTime.Now + GetDurationForSpell(2);
                    m.SetControlMaster(Caster);
                    m.IsBonded = false;

                    m.FixedParticles(14186, 10, 20, 5013, 1441, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m.PlaySound(497);
                }
            }

            FinishSequence();
        }

		private class InternalTarget : Target
		{
            private DominationSpell m_Owner;

            public InternalTarget(DominationSpell owner)
                : base(12, false, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
                if (o is BaseCreature)
                {
                    m_Owner.Target((BaseCreature)o);
                }
                else
                    from.SendMessage("Vous ne pouvez contrôler que les créatures!");
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}