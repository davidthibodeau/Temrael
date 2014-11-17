using Server.Mobiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Items;

namespace Server.Engines.Combat
{
    public class StrategyMonstreMelee : CombatStrategy
    {
        protected StrategyMonstreMelee() { }

        public readonly static CombatStrategy Strategy = new StrategyMonstreMelee();

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

    public class StrategyMonstreDist : StrategyDistance
    {
        public override int EffectID { get { return 0xF42; } }
        public override Type AmmoType { get { return typeof(Arrow); } }
        public override Item Ammo { get { return new Arrow(); } }

        protected StrategyMonstreDist() { }

        public readonly static CombatStrategy Strategy = new StrategyMonstreDist();

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

        public override bool OnFired(Mobile atk, Mobile def)
        {
            def.PublicOverheadMessage(Network.MessageType.Regular, 0, true, "Herp derp");

            atk.MovingEffect( def, EffectID, 18, 1, false, false );

			return true;
        }

        public override int Range(Mobile atk)
        {
            BaseCreature monstre = atk as BaseCreature;
            return monstre.RangeFight;
        }
    }


}
