using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using Server.Targeting;
using Server.Items;

namespace Server.Engines.Mort
{
    public class Achever
    {
        public static void Initialize()
        {
            CommandSystem.Register("Achever", AccessLevel.Player, new CommandEventHandler(Achever_OnCommand));
        }

        [Usage("Achever")]
        [Description("Permet d'achever un personnage joueur.")]
        public static void Achever_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from is TMobile)
            {
                from.Target = new AcheverTarget();
            }
        }

        private class AcheverTarget : Target
        {
            int startingHits = 0;
            TMobile m_corpseOwner;

            public AcheverTarget()
                : base(3, true, TargetFlags.None)
            {
                AllowNonlocal = true;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is Corpse)
                {
                    Corpse corps = targeted as Corpse;

                    if (corps.Owner is TMobile)
                    {
                        m_corpseOwner = (TMobile)corps.Owner;

                        if (from is TMobile)
                        {
                            TMobile tmob = from as TMobile;

                            if (m_corpseOwner != from)
                            {
                                if ((tmob.GetDistanceToSqrt(corps.Location) <= 3) && (tmob.InLOS(corps)))
                                {
                                    if (m_corpseOwner.MortEngine.MortCurrentState == MortState.Assomage)
                                    {
                                        tmob.MortEngine.LastAchever = DateTime.Now;
                                        tmob.Frozen = true;
                                        tmob.SendMessage("Vous achevez le personnage et êtes pris sur place pour 5 secondes.");
                                        tmob.MortEngine.Achever = false;

                                        startingHits = tmob.Hits;

                                        tmob.Emote( "Essaie d'achever le personnage au sol !");

                                        Timer.DelayCall(TimeSpan.FromSeconds(5), new TimerStateCallback(Achever_Callback), tmob);
                                    }
                                }
                                else
                                {
                                    tmob.SendMessage("Vous n'etes pas assez proche du cadavre.");
                                }
                            }
                            else
                            {
                                tmob.SendMessage("Vous ne pouvez pas vous achever vous meme !");
                            }
                        }
                    }
                    else
                    {
                        from.SendMessage("Le corps doit appartenir a un joueur.");
                    }
                }
                else
                {
                    from.SendMessage("Vous devez pointer un corps !");
                }
            }

            public void Achever_Callback(object state)
            {
                TMobile from = (TMobile)state;

                from.Frozen = false;

                if (startingHits <= from.Hits) // Si le joueur n'a pas perdu d'HP pendant l'achèvement..
                {
                    ContratAssassinat cs = null;
                    for (int i = 0; cs == null && i < from.MortEngine.ContratListe.Count; i++)
                    {
                        if (from.MortEngine.ContratListe[i].Cible == m_corpseOwner)
                        {
                            cs = from.MortEngine.ContratListe[i];
                        }
                    }

                    if (cs == null)
                    {
                        cs = new ContratAssassinat(from, from, m_corpseOwner, "Aucune explication");
                    }

                    // Fais comme si il était mort pour éviter qu'il respawn avant d'avoir répondu au gump de mort.
                    ((TMobile)m_corpseOwner).MortEngine.Mort = true;
                    ((TMobile)m_corpseOwner).MortEngine.MortCurrentState = MortState.Mourir;

                    m_corpseOwner.SendGump(new MortGump((Mobile)from, cs));

                }
                else
                {
                    from.SendMessage("Vous ne pouvez pas achever quelqu'un en étant en combat !");
                }
            }
        }
    }
}
