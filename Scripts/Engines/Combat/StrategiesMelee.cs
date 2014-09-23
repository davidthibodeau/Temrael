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
                chance = GetBonus(parry, 0.125, 5);

            if (def.Int < 80)
                chance = chance * (20 + def.Int) / 100;

            return chance;
        }
    }

    public class StrategyPerforante : StrategyMelee
    {
        private static CombatStrategy m_Strategy = new StrategyPerforante();
        public static CombatStrategy Strategy { get { return m_Strategy; } }

        public override SkillName ToucherSkill { get { return SkillName.ArmePerforante; } }

        protected override double CritiqueChance(Mobile atk)
        {
            double chance = base.CritiqueChance(atk);
            double incChance = GetBonus(atk.Skills[SkillName.ArmePerforante].Value, 0.05, 5);
            return IncreasedValue(chance, incChance);
        }
    }

    public class StrategyTranchante : StrategyMelee
    {
        public readonly static CombatStrategy Strategy = new StrategyTranchante();
        
        public override SkillName ToucherSkill { get { return SkillName.ArmeTranchante; } }

        protected override double ToucherChance(Mobile atk, Mobile def)
        {
            double chance = base.ToucherChance(atk, def);
            double incChance = GetBonus(atk.Skills[SkillName.ArmeTranchante].Value, 0.05, 5);
            return IncreasedValue(chance, incChance);
        }
    }

    public class StrategyContondante : StrategyMelee
    {
        public readonly static CombatStrategy Strategy = new StrategyContondante();
        
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
        public readonly static CombatStrategy Strategy = new StrategyHaste();
        
        public override SkillName ToucherSkill { get { return SkillName.ArmeHaste; } }

        public override int BaseRange { get { return 2; } }

        public override int Range(Mobile atk)
        {
            if (atk.Mounted)
                return base.BaseRange;
            return BaseRange;
        }
    }

    public class StrategyHache : StrategyTranchante
    {
        public readonly new static CombatStrategy Strategy = new StrategyHache();
        
        protected override double ComputerDegats(Mobile atk, int basedmg)
        {
            double dmg = base.ComputerDegats(atk, basedmg);
            double foresterieBonus = GetBonus(atk.Skills[SkillName.Foresterie].Value, 0.2, 10);

            return dmg + basedmg * foresterieBonus;
        }
    }
}
