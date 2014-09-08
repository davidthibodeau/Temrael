using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
using Server.Engines.PartySystem;

namespace Server.Spells.Fourth
{
	public class ArchProtectionSpell : Spell
	{
        private static int s_ManaCost = 50;
        private static SkillName s_SkillForCast = SkillName.ArtMagique;
        private static int s_MinSkillForCast = 50;

		private static SpellInfo m_Info = new SpellInfo(
				"Protection Magique", "Vas Uus Sanct",
				SpellCircle.Seventh,
				215,
				9011,
                s_ManaCost,
                s_SkillForCast,
                s_MinSkillForCast,
                false,
				Reagent.Garlic,
				Reagent.Ginseng,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh
            );

		public ArchProtectionSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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
            else if (CheckSequence())
            {
                SpellHelper.Turn(Caster, p);

                SpellHelper.GetSurfaceTop(ref p);

                ArrayList targets = new ArrayList();

                Map map = Caster.Map;

                if (map != null)
                {
                    IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(p), GetRadiusForSpell());

                    foreach (Mobile m in eable)
                    {
                        if (Caster.CanBeBeneficial(m, false))
                            targets.Add(m);
                    }

                    eable.Free();
                }

                Effects.PlaySound(p, Caster.Map, 0x299);

                double value = (int)(Caster.Skills[SkillName.Restoration].Value + Caster.Skills[SkillName.ArtMagique].Value + Caster.Skills[SkillName.Concentration].Value);
                value /= 30;

                value = SpellHelper.AdjustValue(Caster, value);

                if (value > 10)
                    value = 10;

                double duree = value * 9;

                duree = SpellHelper.AdjustValue(Caster, duree);

                if (duree > 120)
                    duree = 120;

                if (targets.Count > 0)
                {
                    for (int i = 0; i < targets.Count; ++i)
                    {
                        Mobile m = (Mobile)targets[i];

                        if (m.BeginAction(typeof(DefensiveSpell)))
                        {
                            if (m.VirtualArmorMod == 0)
                            {
                                Caster.DoBeneficial(m);
                                m.VirtualArmorMod += (int)value;
                                new InternalTimer(m, (int)value, duree).Start();

                                m.FixedParticles(0x375A, 9, 20, 5027, EffectLayer.Waist);
                                m.PlaySound(0x1F7);
                            }
                        }
                    }
                }
            }

			FinishSequence();
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Owner;
			private int m_Value;

            public InternalTimer(Mobile target, int value, double duree) : base(TimeSpan.FromSeconds(duree))
			{
				Priority = TimerPriority.OneSecond;

				m_Owner = target;
                m_Value = value;
			}

			protected override void OnTick()
			{
                m_Owner.EndAction(typeof(DefensiveSpell));
                m_Owner.VirtualArmorMod -= m_Value;

				if ( m_Owner.VirtualArmorMod < 0 )
					m_Owner.VirtualArmorMod = 0;
			}
		}

		private class InternalTarget : Target
		{
			private ArchProtectionSpell m_Owner;

			public InternalTarget( ArchProtectionSpell owner ) : base( 12, true, TargetFlags.None )
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
