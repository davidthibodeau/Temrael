using System;
using Server;
using Server.Mobiles;
using Server.Items;
using System.Collections;

namespace Server.Engines.Mort
{
        public enum MortState
    {
        Aucun,
        Mourir,
        Assomage,
        Ebranle,
        MortDefinitive,
        MortVivant,
        Resurrection,
        Delete
    }

    public enum MortEvo
    {
        Aucune,
        Decomposition,
        Zombie,
        Squelette,
        Ombre,
        Spectre,
        Esprit
    }


    public class EvanouieTimer : Timer
    {
        private Mobile m;
        private Container m_Corpse;
        private int m_Direction;
        private bool m_Mort;

        public EvanouieTimer(Mobile from, Container c, int direction, bool mort)
            : base(TimeSpan.FromSeconds(60))
        {
            m = from;
            m_Corpse = c;
            m_Direction = direction;
            m_Mort = mort;
            m.Frozen = true;
        }

        protected override void OnTick()
        {
            PlayerMobile pm = m as PlayerMobile;

            Stop();
            m.Frozen = false;

            if (!pm.MortEngine.Mort)
            {
                //pm.MortEngine.RisqueDeMort = true;
                m.Resurrect();

                if (m_Corpse != null)
                {
                    ArrayList list = new ArrayList();

                    foreach (Item item in m_Corpse.Items)
                    {
                        list.Add(item);
                    }

                    foreach (Item item in list)
                    {
                        if (item.Layer == Layer.Hair || item.Layer == Layer.FacialHair)
                            item.Delete();

                        if (item is RaceGump || (m_Corpse is Corpse && ((Corpse)m_Corpse).EquipItems.Contains(item)))
                        {
                            if (!m.EquipItem(item))
                                m.AddToBackpack(item);
                        }
                        else
                        {
                            m.AddToBackpack(item);
                        }
                    }

                    m_Corpse.Delete();
                }

                m.Direction = (Direction)m_Direction;
                m.Animate(21, 5, 1, false, false, 0);

                //RisqueDeMortTimer Timer = new RisqueDeMortTimer(m);
                pm.MortEngine.TimerMort = this;
                //Timer.Start();

                pm.MortEngine.MortCurrentState = MortState.Ebranle;
            }
            else
            {
                pm.MortEngine.MortCurrentState = MortState.MortDefinitive;
                pm.MoveToWorld(new Point3D(new Point2D(5277, 2159), 5), Map.Felucca);
                pm.Resurrect();
            }
            /*else
            {
                pm.MortEngine.RisqueDeMort = false;
                m.Resurrect();
            }*/

            pm.CheckRaceGump();
        }
    }

    public class RisqueDeMortTimer : Timer
    {
        private Mobile m;

        public RisqueDeMortTimer(Mobile from)
            : base(TimeSpan.FromSeconds(10))
        {
            m = from;
        }

        protected override void OnTick()
        {
            PlayerMobile pm = m as PlayerMobile;

            Stop();
            pm.MortEngine.RisqueDeMort = false;
            pm.MortEngine.MortCurrentState = MortState.Aucun;
        }
    }

    public class MortVivantEvoTimer : Timer
    {
        private Mobile m;

        public MortVivantEvoTimer(Mobile from)
            : base(TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(10))
        {
            m = from;
        }

        protected override void OnTick()
        {
            PlayerMobile pm = m as PlayerMobile;
            Item item = pm.FindItemOnLayer(Layer.Shirt);
            Item hair = pm.FindItemOnLayer(Layer.Hair);
            Item facialhair = pm.FindItemOnLayer(Layer.FacialHair);

            if (pm.MortEngine.MortVivant)
            {
                switch (pm.MortEngine.MortEvo)
                {
                    case MortEvo.Aucune:
                        if (pm.MortEngine.AmeLastFed.AddDays(7) < DateTime.Now)
                        {
                            pm.MortEngine.AmeLastFed = DateTime.Now;
                            if (item is RaceGump)
                                item.Hue = 0;
                            pm.HueMod = 0;
                            pm.SendMessage("Puisque vous ne vous êtes pas nourri de l'âme d'un vivant depuis 7 jours, votre corps se déteriore.");
                            //pm.MortEngine.MortRace = pm.Races;
                            //pm.Races = Race.MortVivant;
                            pm.MortEngine.MortEvo = MortEvo.Decomposition;
                            //Competences.Reset(pm);
                            Statistiques.Reset(pm);
                        }
                        break;
                    case MortEvo.Decomposition:
                        if (pm.MortEngine.AmeLastFed.AddDays(14) < DateTime.Now)
                        {
                            pm.MortEngine.AmeLastFed = DateTime.Now;
                            if (item is RaceGump)
                                item.Delete();
                            pm.SendMessage("Puisque vous ne vous êtes pas nourri de l'âme d'un vivant depuis 14 jours, votre corps se déteriore à nouveau.");
                            pm.MortEngine.MortEvo = MortEvo.Zombie;
                            ZombieGump zombieGump = new ZombieGump();
                            EquipItem(pm, zombieGump, pm.Hue);
                        }
                        break;
                    case MortEvo.Zombie:
                        if (pm.MortEngine.AmeLastFed.AddDays(28) < DateTime.Now)
                        {
                            pm.MortEngine.AmeLastFed = DateTime.Now;
                            if (item is MortRaceGump)
                                item.Delete();
                            if (hair != null)
                                hair.Delete();
                            if (facialhair != null)
                                facialhair.Delete();
                            pm.SendMessage("Puisque vous ne vous êtes pas nourri de l'âme d'un vivant depuis 28 jours, votre corps se déteriore à nouveau.");
                            pm.SendMessage("Avertissement: La prochaine transformation qui aura lieu dans 28 jours sera définitive. Nourrissez-vous de l'âme d'un vivant d'ici là.");
                            pm.MortEngine.MortEvo = MortEvo.Squelette;
                            SqueletteGump squeletteGump = new SqueletteGump();
                            EquipItem(pm, squeletteGump, 0);
                        }
                        break;
                    case MortEvo.Squelette:
                        if (pm.MortEngine.AmeLastFed.AddDays(56) < DateTime.Now)
                        {
                            pm.MortEngine.AmeLastFed = DateTime.Now;
                            if (item is MortRaceGump)
                                item.Delete();
                            if (hair != null)
                                hair.Delete();
                            if (facialhair != null)
                                facialhair.Delete();
                            pm.SendMessage("Puisque vous ne vous êtes pas nourri de l'âme d'un vivant depuis 56 jours, votre corps se transforme en cette chose définitivement.");
                            pm.MortEngine.MortEvo = MortEvo.Ombre;
                            OmbreGump ombreGump = new OmbreGump();
                            EquipItem(pm, ombreGump, 0);
                        }
                        break;
                    case MortEvo.Ombre:
                        Stop();
                        break;
                }
            }
        }

        private static void EquipItem(PlayerMobile from, Item item)
        {
            if (item != null)
                from.EquipItem(item);
        }

        private static void EquipItem(PlayerMobile from, Item item, int hue)
        {
            if (item != null)
            {
                item.Hue = hue;

                from.EquipItem(item);
            }
        }
    }
}