using System;
using System.Collections;
using Server.Multis;
using Server.Targeting;
using Server.Items;
using Server.Regions;
using Server.Mobiles;
using Server.Spells;

namespace Server.SkillHandlers
{
    public class DetectHidden
    {
        private const int NbCasesBonusPourUnJetManuel = 3; // Gotta love dem long names.
        private static int[] chancesReussite = {
        /* 0  case de distance*/    100,
        /* 1  case de distance*/    100,
        /* 2  case de distance*/    100,
        /* 3  case de distance*/    50,
        /* 4  case de distance*/    50,
        /* 5  case de distance*/    30,
        /* 6  case de distance*/    30,
        /* 7  case de distance*/    30,
        /* 8  case de distance*/    10,
        /* 9  case de distance*/    10,
        /* 10 case de distance*/    -1
                                        };

        public static void Initialize()
        {
            SkillInfo.Table[(int)SkillName.Detection].Callback = new SkillUseCallback( OnUse );
        }

        public static TimeSpan OnUse(Mobile src)
        {
            bool foundAnyone = false;

            foreach (Mobile m in src.GetMobilesInRange(10))
            {
                if (m != src)
                {
                    if (OnUseSingleTarget(src, m, src.GetStepsBetweenYouAnd(m) - NbCasesBonusPourUnJetManuel))
                        foundAnyone = true;
                }
            }
            if (!foundAnyone)
            {
                src.SendLocalizedMessage(500817); // You can see nothing hidden there.
            }

            return TimeSpan.FromSeconds(10.0);
        }

        public static bool OnUseSingleTarget(Mobile src, Mobile trg, int range)
        {
            bool foundAnyone = false;
            double srcSkill = src.Skills[SkillName.Detection].Value + src.Skills[SkillName.Detection].Value;
            double trgSkill = src.Skills[SkillName.Discretion].Value + src.Skills[SkillName.Infiltration].Value;

            src.SendMessage("Test");
            if (trg.Hidden && src != trg && (srcSkill >= trgSkill) && (src.AccessLevel >= trg.AccessLevel))
            {
                if ((range < 10) && (Utility.Random(100) <= chancesReussite[range]))
                {
                    AddToVisList(src, trg);
                    foundAnyone = true;
                }
                else
                {
                    RemoveFromVisList(src, trg);
                }
            }

            return foundAnyone;
        }

        private static void AddToVisList(Mobile source, Mobile target)
        {
            try
            {
                PlayerMobile pm = (PlayerMobile)target;
                if (!pm.VisibilityList.Contains(source))
                    pm.VisibilityList.Add(source);
                if (Utility.InUpdateRange(source, target))
                {
                    if (source.CanSee(target))
                    {
                        source.Send(new Network.MobileIncoming(source, target));
                    }
                    else
                    {
                        source.Send(target.RemovePacket);
                    }
                }
            }
            catch
            {
            }
        }

        private static void RemoveFromVisList(Mobile source, Mobile target)
        {
            try
            {
                PlayerMobile pm = (PlayerMobile)target;
                if (pm.VisibilityList.Contains(source))
                    pm.VisibilityList.Remove(source);

                if (Utility.InUpdateRange(source, target))
                {
                    if (source.CanSee(target))
                        source.Send(target.RemovePacket);
                }
            }
            catch
            {
            }
        }
    }
}
