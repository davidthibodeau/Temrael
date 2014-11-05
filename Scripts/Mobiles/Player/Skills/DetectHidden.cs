using System;
using System.Collections;
using Server.Multis;
using Server.Targeting;
using Server.Items;
using Server.Regions;
using Server.Mobiles;
using Server.Spells;
using Server.Misc;

namespace Server.SkillHandlers
{
    public class DetectHidden
    {
        private const int NbCasesBonusPourUnJetManuel = 3; // Gotta love dem long names.
        private static int[] chancesReussite = {
        /* 0  case de distance*/    50,
        /* 1  case de distance*/    50,
        /* 2  case de distance*/    30,
        /* 3  case de distance*/    20,
        /* 4  case de distance*/    20,
        /* 5  case de distance*/    10,
        /* 6  case de distance*/    10,
        /* 7  case de distance*/    5,
        /* 8  case de distance*/    5,
        /* 9  case de distance*/    0,
        /* 10 case de distance*/    0 // Important de laisser à 0.
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
                if (m != src && m.Hidden)
                    if (OnUseSingleTarget(src, m, src.GetStepsBetweenYouAnd(m) - NbCasesBonusPourUnJetManuel))
                        foundAnyone = true;
            }

            if (!foundAnyone)
            {
                src.SendLocalizedMessage(500817); // You can see nothing hidden there.
            }

            return TimeSpan.FromSeconds(10.0);
        }

        public static bool OnUseSingleTarget(Mobile src, Mobile trg, int range)
        {
            if (src.AccessLevel >= trg.AccessLevel)
            {
                AddToVisList(src, trg);
                return true;
            }

            bool foundAnyone = false;
            double srcSkill = src.Skills[SkillName.Detection].Value * 2;
            double trgSkill = src.Skills[SkillName.Discretion].Value + src.Skills[SkillName.Infiltration].Value;

            if (range < 0)
                range = 0;


            if (trg.Hidden 
             && src != trg 
             && srcSkill >= trgSkill
             && range < 10)
            {
                if (Utility.Random(100) < chancesReussite[range])
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
            catch(Exception e)
            {
                ExceptionLogging.WriteLine(e, "Source: {0}, Target: {0}", source, target);
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
                    source.Send(target.RemovePacket);
                }
            }
            catch(Exception e)
            {
                ExceptionLogging.WriteLine(e, "Source: {0}, Target: {0}", source, target);
            }
        }
    }
}
