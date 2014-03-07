using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Spells
{
	public class SeismeSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
                "Seisme", "In Vas Por Choma An Por",
				SpellCircle.Fifth,
				233,
				9012,
				false,
				Reagent.Bloodmoss,
                Reagent.Bloodmoss,
				Reagent.SulfurousAsh
			);

        public override int RequiredAptitudeValue { get { return 3; } }
        public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Evocation }; } }

        public SeismeSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}
      
		public override bool DelayedDamage{ get{ return !Core.AOS; } }

        public override void OnCast()
        {
               ArrayList m_target = new ArrayList();
            if (SpellHelper.CheckTown(Caster, Caster) && CheckSequence())
            {
                   double damage = GetNewAosDamage(15, 4, 6, true);

                   double s_damage = damage;

                   m_target.Clear();

                    Map map = Caster.Map;

                    if (map != null)
                    {
                        foreach (Mobile m in Caster.GetMobilesInRange((int)SpellHelper.AdjustValue(Caster, 1 + Caster.Skills[SkillName.Destruction].Value / 15, Aptitude.Sorcellerie, true)))
                        {
                            if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && (!Core.AOS || Caster.InLOS(m)) && !(Caster.Party == m.Party))
                                m_target.Add(m);
                        }
                    }

                    for (int i = 0; i < m_target.Count; ++i)
                    {
                        Mobile targ = (Mobile)m_target[i];

                        if (Caster.CanSee(targ))
                        {
                            Caster.DoHarmful(targ);

                            targ.Freeze(TimeSpan.FromSeconds(0.25));

                            AOS.Damage(targ, Caster, (int)s_damage, 100, 0, 0, 0, 0);
                        }
                    }
       

                    for (int i = 0; i < 12; i++)
                    {
                        Point3D orig = Caster.Location;

                        Point3D p = new Point3D(orig.X + Utility.Random(-5, 10), orig.Y + Utility.Random(-5, 10), orig.Z - 10);

                        Effects.SendLocationEffect(p, Caster.Map, 7020 + Utility.Random(0, 4), 50);
                        Effects.PlaySound(p, Caster.Map, 0x2F3);
                        Caster.Freeze(TimeSpan.FromSeconds(0.5));
                    }
                }

            FinishSequence();
    }
        }
            }