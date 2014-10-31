using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Engines.Craft;

namespace Server.Spells
{
	public class GriffesSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
                "Griffes", "Haga Fehu",
				6,
				212,
				9041
            );

        public GriffesSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
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
                Item onehanded = m.FindItemOnLayer(Layer.OneHanded) as Item;
                if (onehanded != null)
                    m.AddToBackpack(onehanded);

                Item twohanded = m.FindItemOnLayer(Layer.TwoHanded) as Item;
                if (twohanded != null)
                    m.AddToBackpack(twohanded);

                TimeSpan duration = GetDurationForSpell(0.7);

                m.FixedParticles(2339, 10, 30, 5013, 1942, 0, EffectLayer.Waist); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(481);

                //BaseWeapon griffe = BaseWeapon.SummonWeapon(93, 3, 1, 2041, SkillName.ArmePoing, CraftResource.Iron, (WeaponQuality)2, typeof(Griffes), DateTime.Now + duration);
                
                //if(griffe != null)
                //   m.EquipItem(griffe);
            }

            FinishSequence();
        }

		private class InternalTarget : Target
		{
            private GriffesSpell m_Owner;

            public InternalTarget(GriffesSpell owner)
                : base(12, false, TargetFlags.Beneficial)
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