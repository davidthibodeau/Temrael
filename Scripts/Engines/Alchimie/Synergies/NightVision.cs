using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Mobiles;

namespace Server.Engines.Alchimie
{
    public class NightVision : BaseSynergy
    {
        public override List<Type> Requirements
        {
            get 
            { 
                return new List<Type>()
                {
                    typeof(PotForce),
                    typeof(PotDex)
                };
            }
        }

        public override string Name
        {
            get { return "Vision nocturne"; }
        }

        public override void PutEffect(ScriptMobile target, double strength)
        {
            if (target.BeginAction(typeof(LightCycle)))
            {
                new LightCycle.NightSightTimer(target, TimeSpan.FromMinutes(1 * strength)).Start();
                target.LightLevel = 100;
            }
        }

        public override void RemoveEffect(ScriptMobile target)
        {
            target.EndAction(typeof(LightCycle));
            target.LightLevel = 0;
            BuffInfo.RemoveBuff(target, BuffIcon.NightSight);
        }
    }
}
