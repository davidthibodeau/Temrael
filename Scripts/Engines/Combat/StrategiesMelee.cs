using Server.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Combat
{
    public abstract class StrategyMelee : CombatStrategy
    {
        protected override double ParerChance(Mobile def)
        {
            double parry = def.Skills[SkillName.Parer].Value;
            double chance = 0;

            if ((def.FindItemOnLayer(Layer.TwoHanded) as BaseShield) != null)
                chance = GetBonus(parry, 0.25, 5);
            else
                chance = GetBonus(parry, 0.10, 5);

            return chance;
        }
    }

    public class StrategyPerforante : StrategyMelee
    {
        public override SkillName ToucherSkill { get { return SkillName.ArmePerforante; } }

        // TODO: Implanter Coups Critiques
    }

    public class StrategyTranchante : StrategyMelee
    {
        public override SkillName ToucherSkill { get { return SkillName.ArmeTranchante; } }

        protected override double ToucherChance(Mobile atk, Mobile def)
        {
            double chance = base.ToucherChance(atk, def);
            double incChance = GetBonus(atk.Skills[SkillName.ArmeTranchante].Value, 0.05, 5);
            return chance * (1 + incChance);
        }
    }

    public class StrategyContondante : StrategyMelee
    {
        public override SkillName ToucherSkill { get { return SkillName.ArmeContondante; } }

        protected override double ReducedArmor(Mobile atk, double baseArmor)
        {
            double resist = base.ReducedArmor(atk, baseArmor);
            double contpen = GetBonus(atk.Skills[SkillName.ArmeContondante].Value, 0.05, 5);
            return ReduceValue(resist, contpen);
        }
    }

    public class StrategyHaste : StrategyMelee
    {
        public override SkillName ToucherSkill { get { return SkillName.ArmeHaste; } }

        // TODO: Faire en sorte que ce soit applique qu'a pied.
        public override int Range { get { return 2; } }
    }
}
