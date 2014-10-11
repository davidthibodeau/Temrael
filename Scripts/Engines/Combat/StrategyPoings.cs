using Server.Engines.Equitation;
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

        protected override void AppliquerPoison(Mobile atk, Mobile def)
        {
            // Le poison ne s'applique pas sur les poings.
        }

        protected override void CheckEquitationAttaque(Mobile atk)
        {
            CheckEquitation(atk, EquitationType.Attacking);
        }
    }
}

