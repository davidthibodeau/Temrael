using System;

namespace Server.Engines.Combat
{
    public class StrategyPoings : CombatStrategy
    {
        public readonly static CombatStrategy Strategy = new StrategyPoings();

        public override SkillName ToucherSkill { get { return SkillName.Anatomie; } }

        protected override double ParerChance(Mobile def)
        {
            return 0;
        }

    }
}

