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

        private static double[] chancesReussite = {
        /* 0  case de distance*/    50,         // La case 0 de distance sert à quand on fait un jet manuel de détection, car marcher sur un joueur nous révèle automatiquement.

        /* 1  case de distance*/    10.5,       // 1.5 + 2.5 + 3.5 .... = 60. Donc 60% de chances de détecter quelqu'un qui vient de 10+ range. 
        /* 2  case de distance*/    9.5,        // À noter qu'un personnage hidé qui n'est pas dans le Line of Sight ne se fait pas calculer la détection, donc un joueur
        /* 3  case de distance*/    8.5,        // qui arrive en se servant des arbres comme cover aura plus de chances de reussir que quelqu'un qui marche
        /* 4  case de distance*/    7.5,        // en plein millieu d'une route.
        /* 5  case de distance*/    6.5,
        /* 6  case de distance*/    5.5,
        /* 7  case de distance*/    4.5,
        /* 8  case de distance*/    3.5,
        /* 9  case de distance*/    2.5,
        /* 10 case de distance*/    1.5
                                        };

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
                    if (OnUseSingleTarget(src, m, 0))
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
            bool foundAnyone = false;
            double srcSkill = src.Skills[SkillName.Detection].Value * 2;
            double trgSkill = src.Skills[SkillName.Discretion].Value + src.Skills[SkillName.Infiltration].Value;
            int Difficulte = 1;

            if ((trg.Direction & Direction.Running) != 0) // isRunning
                Difficulte = 3;

            if (range < 0)
                range = 0;

            if (trg.Hidden
             && trg.InLOS(src)
             && src != trg
             && range < 10)
            {
                for (int i = 0; i < Difficulte && !foundAnyone; i++)
                {
                    if ((Utility.Random(100) + trgSkill) * ImportanceSkills < (Utility.Random(100) + srcSkill) * ImportanceSkills)
                    {
                        if ((Utility.RandomDouble() * 100) < chancesReussite[range] * 2) // *2 parce que le if précédent a déjà une chance de reussir / failer.
                        {
                            AddToVisList(src, trg);
                            foundAnyone = true;
                        }
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
