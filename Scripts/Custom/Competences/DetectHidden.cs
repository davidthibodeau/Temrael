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
        //Nombre de secondes nécessaire à abri pour fonctionner
        private const double abri_temps_max = 24;
        //Diminution de temps par niveau
        private const double abri_par_niveau = 3;

        public static void Initialize()
        {
            SkillInfo.Table[(int)SkillName.Detection].Callback = new SkillUseCallback(OnUse);
        }

        public static TimeSpan OnUse(Mobile src)
        {
            src.SendLocalizedMessage(500819);//Where will you search?
            src.Target = new InternalTarget();

            return TimeSpan.FromSeconds(6.0);
        }

        private class InternalTarget : Target
        {
            public InternalTarget()
                : base(12, true, TargetFlags.None)
            {
            }

            protected override void OnTarget(Mobile src, object targ)
            {
                if (src is TMobile)
                {
                    TMobile pm = (TMobile)src;

                    if (pm.CheckFatigue(1))
                    {
                        src.SendLocalizedMessage(500817); // You can see nothing hidden there.
                        return;
                    }
                }

                bool foundAnyone = false;

                Point3D p;
                if (targ is Mobile)
                    p = ((Mobile)targ).Location;
                else if (targ is Item)
                    p = ((Item)targ).Location;
                else if (targ is IPoint3D)
                    p = new Point3D((IPoint3D)targ);
                else
                    p = src.Location;

                double srcSkill = src.Skills[SkillName.Detection].Value + src.Skills[SkillName.Detection].Value;

                double range = 1 + src.Skills[SkillName.Detection].Value / 10.0;
                //src.CheckSkill(SkillName.Detection, 0, 120); //augmenter le skill

                if (range > 0)
                {
                    IPooledEnumerable inRange = src.Map.GetMobilesInRange(p, (int)range);

                    foreach (Mobile trg in inRange)
                    {
                        if (trg.Hidden && src != trg)
                        {
                            double sourceSkill = srcSkill;
                            double targetSkill = trg.Skills[SkillName.Discretion].Value + trg.Skills[SkillName.Infiltration].Value;

                            //Boost de l'habiletée liée à son
                            if (SonSpell.m_SonTable.Contains(trg))
                                targetSkill += (double)SonSpell.m_SonTable[trg];

                            //Variables relations à l'abri
                            double secondes = 0;
                            bool hasEvasion = false;
                            //Variables relatives à disparition
                            bool disparition = false;

                            if (trg is TMobile)
                            {
                                secondes = abri_temps_max - (double)((TMobile)trg).GetAptitudeValue(Aptitude.Evasion) * 4;
                                if (secondes != abri_temps_max)
                                {
                                    hasEvasion = true;
                                }
                            }

                            if (src is TMobile)
                            {
                                disparition = (((TMobile)src).GetAptitudeValue(Aptitude.Depistage) * 4) > trg.Skills.Discretion.Fixed;
                            }

                            //Peut trouver la personne SI :
                            // - La personne n'a pas la connaissance Abri OU si elle l'a mais que le délai depuis la dernière fois qu'elle a bougée n'est pas dépassé
                            // - Skills de DH >= skills de Hiding
                            // - Son niveau d'accès >= à la personne qu'elle cherche à dehider
                            // - Si l'habiletée disparition de la personne n'est plus en fonction OU si elle est en fonction mais que la personne cherchant à plus de point en détection que (disparition/2)
                            if (hasEvasion == false || (hasEvasion == true && Core.TickCount < (trg.LastMoveTime + (int)secondes * 1000)))
                            {
                                if ((sourceSkill >= targetSkill) && (src.AccessLevel >= trg.AccessLevel))
                                {
                                    AddToVisList(src, trg, sourceSkill, targetSkill);
                                    foundAnyone = true;
                                }
                            }
                        }
                    }
                    inRange.Free();
                }

                if (!foundAnyone)
                {
                    src.SendLocalizedMessage(500817); // You can see nothing hidden there.
                }
            }
        }

        public static void AddToVisList(Mobile source, Mobile target, double sourceSkill, double targetSkill)
        {
            int correct = 0;
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
                correct = 1;
            }
            catch
            {
            }

            if (correct == 0)
            {
                target.Hidden = false;
            }
        }
    }
}
