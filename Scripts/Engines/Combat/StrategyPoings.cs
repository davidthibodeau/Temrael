using Server.Engines.Equitation;
using Server.Items;
using System;

namespace Server.Engines.Combat
{
    public class StrategyPoings : CombatStrategy
    {
        public readonly static CombatStrategy Strategy = new StrategyPoings();

        public override SkillName ToucherSkill { get { return SkillName.Anatomie; } }

        protected override double ParerChance(Mobile def)
        {
            double parry = def.Skills[SkillName.Parer].Value;
            double chance = 0;

            if ((def.FindItemOnLayer(Layer.TwoHanded) as BaseShield) != null)
                chance = GetBonus(parry, 0.125, 5);

            if (def.Int < 80)
                chance = chance * (20 + def.Int) / 100;

            return chance;
        }

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

