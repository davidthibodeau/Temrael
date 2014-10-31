using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Spells;
using Server.Items;

namespace Server.Spells
{
    public class GuerisonMiraculeuseMiracle : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static readonly new SpellInfo Info = new SpellInfo(
                "Guerison Miraculeuse", "",
                8,
                17,
                9041
            );

        public GuerisonMiraculeuseMiracle(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
        {
        }

        public override void OnCast()
        {
            if (Caster == null || Caster.Deleted || !Caster.Alive)
            {
                return;
            }

            foreach (Item itema in Caster.GetItemsInRange(1 + (int)(Caster.Skills[SkillName.ArtMagique].Base / 10)))
            {
                if (itema != null && itema is Corpse)
                {
                    Corpse c = (Corpse)itema;

                    if (c != null && c.Owner != null && c.Owner is TMobile)
                    {
                        TMobile pm = (TMobile)(c.Owner);

                        if (pm.MortCurrentState == MortState.Assomage)
                        {
                            //pm.AddFatigue(-100);

                            SpellHelper.Turn(Caster, pm);

                            pm.PlaySound(0x214);
                            pm.FixedEffect(0x376A, 10, 16);

                            if (pm.TimerEvanouie != null)
                            {
                                pm.TimerEvanouie.Stop();
                                pm.TimerEvanouie = null;
                            }

                            if (pm.TimerMort != null)
                            {
                                pm.TimerMort.Stop();
                                pm.TimerMort = null;
                            }

                            pm.Location = c.Location;
                            pm.EndroitMort = c.Location;
                            pm.RisqueDeMort = false;
                            pm.Mort = false;
                            pm.Frozen = false;

                            pm.Direction = c.Direction;
                            pm.MoveToWorld(c.Location, c.Map);
                            pm.Animate(21, 5, 1, false, false, 0);

                            pm.Resurrect();

                            if (c != null)
                            {
                                ArrayList list = new ArrayList();

                                foreach (Item item in c.Items)
                                {
                                    list.Add(item);
                                }

                                foreach (Item item in list)
                                {
                                    if (item.Layer == Layer.Hair || item.Layer == Layer.FacialHair)
                                        item.Delete();

                                    if (item is RaceGump || c.EquipItems.Contains(item))
                                    {
                                        if (!pm.EquipItem(item))
                                            pm.AddToBackpack(item);
                                    }
                                    else
                                    {
                                        pm.AddToBackpack(item);
                                    }
                                }
                            }

                            pm.CheckRaceGump();
                            pm.CheckStatTimers();

                            pm.MortCurrentState = MortState.Ebranle;
                        }
                    }
                }
            }
        }

        public override bool DelayedDamage { get { return false; } }
    }
}