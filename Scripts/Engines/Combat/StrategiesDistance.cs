using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Combat
{
    public abstract class StrategyDistance : CombatStrategy
    {
        public override SkillName ToucherSkill { get { return SkillName.ArmeDistance; } }

        protected override double ComputerDegats(Mobile atk, int basedmg)
        {
            double dmg = base.ComputerDegats(atk, basedmg);
            double menuiserieBonus = GetBonus(atk.Skills[SkillName.Menuiserie].Value, 0.2, 10);

            return dmg + basedmg * menuiserieBonus;
        }

        protected override double ParerChance(Mobile def)
        {
            return 0.0;
        }
    }

    public class StrategyArc : StrategyDistance
    {
        public readonly static CombatStrategy Strategy = new StrategyArc();
        
        public override int BaseRange { get { return 10; } }
    }

    public class StrategyArbalete : StrategyDistance
    {
        public readonly static CombatStrategy Strategy = new StrategyArbalete();
        
        public override int BaseRange { get { return 8; } }
    }
}
