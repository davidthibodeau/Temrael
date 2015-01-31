using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using System.Collections;

namespace Server.Spells
{
    public class PoingDeValeurSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static readonly new SpellInfo Info = new SpellInfo(
                "Poing de valeur", "Otil Grav",
                2,
                212,
                9041
            );

        public PoingDeValeurSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
        {
        }

        public override void OnCast()
        {
            if (CheckSequence())
            {
                ArrayList targets = new ArrayList();

                Map map = Caster.Map;

                if (map != null)
                {
                    double tile = 4;

                    SpellHelper.AdjustValue(Caster, tile); 

                    if (tile > 12)
                        tile = 12;

                    foreach (Mobile m in Caster.GetMobilesInRange((int)tile))
                    {
                        if (Caster.CanBeBeneficial(m, false))
                            targets.Add(m);
                    }
                }

                double toHeal;

                toHeal = Caster.Skills[CastSkill].Value * 0.15;
                toHeal += Caster.Skills[DamageSkill].Value * 0.07;

                toHeal = SpellHelper.AdjustValue(Caster, toHeal);

                for (int i = 0; i < targets.Count; ++i)
                {
                    Mobile m = (Mobile)targets[i];

                    SpellHelper.Heal(m, (int)toHeal + Utility.Random(1, 3), true);

                    Effects.SendTargetParticles(m,0x376A, 9, 32, 5005, EffectLayer.Waist);
                    m.PlaySound(483);
                }
            }

            FinishSequence();
        }
    }
}