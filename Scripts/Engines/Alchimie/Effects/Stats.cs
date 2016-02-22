using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Engines.Alchimie
{
    public class PotForce : BasePotionEffect
    {
        public override ulong ID { get { return 1; } } // Berk.
        public override string Name { get { return "Force"; } }
        public override double MinSkill { get { return 0; } }
        public override double MaxSkill { get { return 30; } }

        public override void PutEffect(ScriptMobile target, double strength)
        {
            int val = (int)(30 * strength);
            if (m_EffectType == TargetFlags.Harmful)
            {
                val = -val;
            }

            target.AddStatMod(new StatMod(StatType.Str, Use_ID().ToString(), val, TimeSpan.FromSeconds(10)));
        }

        public override void RemoveEffect(ScriptMobile target)
        {
            target.RemoveStatMod(ID.ToString());
        }

        public PotForce(TargetFlags flag, bool stackable)
            : base(flag, stackable)
        {
        }

        public PotForce()
            : base(TargetFlags.Beneficial, false)
        {
        }
    }

    public class PotDex : BasePotionEffect
    {
        public override ulong ID { get { return 2; } }
        public override string Name { get { return "Dexterite"; } }
        public override double MinSkill { get { return 0; } }
        public override double MaxSkill { get { return 30; } }

        public override void PutEffect(ScriptMobile target, double strength)
        {
            int val = (int)(30 * strength);
            if (m_EffectType == TargetFlags.Harmful)
            {
                val = -val;
            }

            target.AddStatMod(new StatMod(StatType.Dex, Use_ID().ToString(), val, TimeSpan.FromSeconds(10)));
        }

        public override void RemoveEffect(ScriptMobile target)
        {
            target.RemoveStatMod(ID.ToString());
        }

        public PotDex(TargetFlags flag, bool stackable)
            : base(flag, stackable)
        {
        }

        public PotDex()
            : base(TargetFlags.Beneficial, false)
        {
        }
    }

    public class PotInt : BasePotionEffect
    {
        public override ulong ID { get { return 3; } }
        public override string Name { get { return "Intelligence"; } }
        public override double MinSkill { get { return 0; } }
        public override double MaxSkill { get { return 30; } }

        public override void PutEffect(ScriptMobile target, double strength)
        {
            int val = (int)(30 * strength);
            if (m_EffectType == TargetFlags.Harmful)
            {
                val = -val;
            }

            target.AddStatMod(new StatMod(StatType.Int, Use_ID().ToString(), val, TimeSpan.FromSeconds(10)));
        }

        public override void RemoveEffect(ScriptMobile target)
        {
            target.RemoveStatMod(ID.ToString());
        }

        public PotInt(TargetFlags flag, bool stackable)
            : base(flag, stackable)
        {
        }

        public PotInt()
            : base(TargetFlags.Beneficial, false)
        {
        }
    }
}
