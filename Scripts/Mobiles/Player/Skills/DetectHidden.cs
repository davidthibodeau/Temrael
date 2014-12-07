using System;
using System.Collections;
using Server.Multis;
using Server.Targeting;
using Server.Items;
using Server.Regions;
using Server.Mobiles;
using Server.Spells;
using Server.Misc;
using Server.Network;

namespace Server.SkillHandlers
{
    public class DetectHidden
    {
        private const int ImportanceSkills = 2; // Si 100 hide/stealth et 90 detect :
                                                // Différence de jet = (100 - 90) * "2".
                                                // 20.

        public static void Initialize()
        {
            SkillInfo.Table[(int)SkillName.Detection].Callback = new SkillUseCallback( OnUse );
        }

        public static TimeSpan OnUse(Mobile src)
        {
            bool foundAnyone = false;

            src.PublicOverheadMessage(MessageType.Regular, 0, true, "Jette un oeil aux allentours."); // Empêche quelqu'un de se mettre la détection manuelle en loop sans avoir l'air retardé.

            foreach (Mobile m in src.GetMobilesInRange(10))
            {
                if (m != src && m.Hidden)
                    if (OnUseSingleTarget(src, m))
                        foundAnyone = true;
            }

            if (!foundAnyone)
            {
                src.SendLocalizedMessage(500817); // You can see nothing hidden there.
            }

            return TimeSpan.FromSeconds(10.0);
        }

        public static bool OnUseSingleTarget(Mobile src, Mobile trg)
        {
            if (trg.AccessLevel >= src.AccessLevel)
                return false;

            bool foundAnyone = false;
            double srcSkill = src.Skills[SkillName.Detection].Value * 2;
            double trgSkill = src.Skills[SkillName.Discretion].Value + src.Skills[SkillName.Infiltration].Value;
            int Difficulte = 1;

            if ((trg.Direction & Direction.Running) != 0) // isRunning
                Difficulte = 3;

            if (trg.Hidden
             && trg.InLOS(src)
             && src != trg)
            {
                for (int i = 0; i < Difficulte && !foundAnyone; i++)
                {
                    if ((Utility.Random(100) + trgSkill) * ImportanceSkills < (Utility.Random(100) + srcSkill) * ImportanceSkills)
                    {
                        AddToVisList(src, trg);
                        foundAnyone = true;
                    }
                }
            }
            else
            {
                RemoveFromVisList(src, trg);
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
                    NetState ns = source.NetState;
                    if (ns != null)
                    {

                        if (source.CanSee(target))
                        {
                            if (ns.StygianAbyss)
                                source.Send(new MobileIncoming(source, target));
                            else
                                source.Send(new MobileIncomingOld(source, target));
                            if (ObjectPropertyList.Enabled)
                            {
                                ns.Send(target.OPLPacket);

                                foreach (Item item in target.Items)
                                    ns.Send(item.OPLPacket);
                            }
                        }
                        else
                        {
                            source.Send(target.RemovePacket);
                        }
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
