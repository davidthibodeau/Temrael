using Server.Engines.Equitation;
using Server.Items;
using System;

namespace Server.Engines.Combat
{
    public class StrategyPoings : CombatStrategy
    {
        protected StrategyPoings() { }

        public readonly static CombatStrategy Strategy = new StrategyPoings();

        public override SkillName ToucherSkill { get { return SkillName.Anatomie; } }

        protected override void AppliquerPoison(Mobile atk, Mobile def)
        {
            // Le poison ne s'applique pas sur les poings.
        }

        protected override void CheckEquitationAttaque(Mobile atk)
        {
            CheckEquitation(atk, EquitationType.Attacking);
        }

        public override bool OnFired(Mobile atk, Mobile def)
        {
            return false;
        }
    }
}

