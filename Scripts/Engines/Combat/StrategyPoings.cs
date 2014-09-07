using System;

namespace Server.Engines.Combat
{
    public class StrategyPoings : CombatStrategy
    {
        private static CombatStrategy m_Strategy = new StrategyPoings();
        public static CombatStrategy Strategy { get { return m_Strategy; } }

        public override SkillName ToucherSkill { get { return SkillName.Anatomie; } }

        protected override double ParerChance(Mobile def)
        {
            return 0;
        }

    }
}

