using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Spells
{
	public class CriDOursSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
                "Cri d'Ours", "In Vas Ex Beh Bal",
				SpellCircle.First,
				233,
				9012,
				false,
				Reagent.Bloodmoss,
				Reagent.Ginseng,
				Reagent.Garlic
			);

        public CriDOursSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
		{
		}

        public override void OnCast()
        {
            if (CheckSequence())
            {
                TimeSpan duration = GetDurationForSpell(0.8);

                DateTime endtime = DateTime.Now + duration;

                Map map = Caster.Map;

                ArrayList targets = new ArrayList();

                if (map != null)
                {
                    IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(Caster.Location), (int)SpellHelper.AdjustValue(Caster, 1 + Caster.Skills[SkillName.ArtMagique].Value / 20));

                    foreach (Mobile m in eable)
                    {
                        if (Caster.CanBeBeneficial(m, false) && (Caster.Party == m.Party))
                        {
                            targets.Add(m);
                        }
                    }

                    eable.Free();
                }

                if (targets.Count > 0)
                {
                    for (int i = 0; i < targets.Count; ++i)
                    {
                        Mobile m = (Mobile)targets[i];

                        if (m is TMobile)
                        {
                            new CriDOursTimer((TMobile)m, endtime).Start();
                        }

                        if (m is BaseCreature)
                        {
                            new CriDOursTimer((BaseCreature)m, endtime).Start();
                        }
                    }

                    Caster.PlaySound(163);
                }
            }

            FinishSequence();
        }

        private class CriDOursTimer : Timer
        {
            private TMobile m_target;
            private DateTime m_end;
            private BaseCreature m_creature;

            public CriDOursTimer(TMobile target, DateTime endtime)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(3))
            {
                m_target = target;
                m_end = endtime;
                //m_target.CriDOurs = true;
                target.PlaySound(99);

                Priority = TimerPriority.TwoFiftyMS;
            }

            public CriDOursTimer(BaseCreature target, DateTime endtime)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(3))
            {
                m_creature = target;
                m_end = endtime;
                //m_creature.CriDOurs = true;
                target.PlaySound(99);

                Priority = TimerPriority.TwoFiftyMS;
            }

            protected override void OnTick()
            {
                if (m_target == null && m_creature == null)
                {
                    Stop();
                    return;
                }
                else if (m_creature != null && (!m_creature.Alive || DateTime.Now >= m_end))
                {
                    //m_creature.CriDOurs = false;
                    Stop();
                }
                else if (m_target != null && (!m_target.Alive || DateTime.Now >= m_end))
                {
                    //m_target.CriDOurs = false;
                    Stop();
                }

                if(m_target != null)
                    m_target.FixedParticles(0x3779, 5, 10, 5052, EffectLayer.LeftFoot);
                else if(m_creature != null)
                    m_creature.FixedParticles(0x3779, 5, 10, 5052, EffectLayer.LeftFoot);
            }
        }

	}
}