using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Items;

namespace Server.Spells
{
	public class PluieAcideSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
                "Pluie Acide", "Kal Nox Corp Grav",
				SpellCircle.Seventh,
				236,
				9011,
				Reagent.Nightshade,
				Reagent.NoxCrystal,
				Reagent.Bloodmoss
			);

        public PluieAcideSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

        public override void OnCast()
        {
            if (CheckSequence())
            {
                Map map = Caster.Map;

                ArrayList targets = new ArrayList();

                //bool playerVsPlayer = false;

                if (map != null)
                {
                    IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(Caster.Location), (int)SpellHelper.AdjustValue(Caster, 1 + Caster.Skills[CastSkill].Value / 5, Aptitude.Sorcellerie, true));

                    foreach (Mobile m in eable)
                    {
                        if (SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && m != Caster && Caster.InLOS(m) && !(Caster.Party == m.Party))
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

                        ApplyPoisonTo(m);
                        m.PlaySound(0x474);

                        double damage = GetNewAosDamage(2, 1, 3, false);

                        //BaseArmor.AcidHit(m, (int)damage);
                    }
                }
            }

            FinishSequence();
        }

        public void ApplyPoisonTo(Mobile m)
        {
            if (Caster == null)
                return;

            Poison p = Poison.Regular;

            m.ApplyPoison(Caster, p);
        }
	}
}