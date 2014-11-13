using Server.Mobiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Combat
{
    public class StrategyMonstre : CombatStrategy
    {
        protected StrategyMonstre() { }

        public readonly static CombatStrategy Strategy = new StrategyMonstre();

        public override bool OnFired(Mobile atk, Mobile def)
        {
            return false;
        }

        protected override void CheckEquitationAttaque(Mobile atk)
        {            
        }

        public override SkillName ToucherSkill
        {
            get { return SkillName.Epee; }
        }

        protected override void AppliquerPoison(Mobile atk, Mobile def)
        {
        }

        protected override double ParerChance(Mobile def)
        {
            return 0;
        }

        public override int Range(Mobile atk)
        {
            BaseCreature monstre = atk as BaseCreature;
            return monstre.RangeFight;
        }
    }


}
