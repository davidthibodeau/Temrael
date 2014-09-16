using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using Server.Targeting;
using Server.Items;

namespace Server.Scripts.Commands
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
                if (((TMobile)from).Achever)
                {
                    if (((TMobile)from).Niveau >= 10)
                    {
                        from.Target = new AcheverTarget();
                    }
                    else
                    {
                        from.SendMessage("Vous devez etre niveau 10 !");
                    }
                }
                else
                {
                    from.SendMessage("Vous devez avoir l'autorisation de l'équipe pour achever quelqu'un.");
                }
            }
        }

        private class AcheverTarget : Target
        {
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
                        if (from is TMobile)
                        {
                            TMobile tmob = from as TMobile;

                            if (DateTime.Now >= tmob.NextKillAllowed)
                            {
                                if (!(corps.Owner == from))
                                {
                                    if ((tmob.GetDistanceToSqrt(corps.Location) <= 3) && (tmob.InLOS(corps)))
                                    {
                                        if (((TMobile)corps.Owner).MortCurrentState == MortState.Assomage)
                                        {
                                            ((TMobile)corps.Owner).Mort = true;
                                            ((TMobile)corps.Owner).MortCurrentState = MortState.Mourir;

                                            //if (!((TMobile)corps.Owner).Suicide)
                                            //{
                                            //    tmob.XP = (int)(tmob.XP * 0.60);
                                            //}
                                            tmob.NextKillAllowed = DateTime.Now.AddHours(24);

                                            tmob.LastAchever = DateTime.Now;
                                            tmob.Frozen = true;
                                            tmob.SendMessage("Vous achevez le personnage et êtes pris sur place pour 5 secondes.");
                                            tmob.Achever = false;
                                            /*if (tmob.AccessLevel == AccessLevel.Player)
                                                tmob.Say("*Achève le personnage au sol.*");*/
                                            ((TMobile)corps.Owner).SendMessage("Vous avez ete acheve !");
                                            Timer.DelayCall(TimeSpan.FromSeconds(5), new TimerStateCallback(Achever_Callback), tmob);
                                            if (tmob.FindItemOnLayer(Layer.OneHanded) is BaseWeapon)
                                            {
                                                corps.Carve(tmob, tmob.FindItemOnLayer(Layer.OneHanded));
                                            }
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
                            else
                            {
                                tmob.SendMessage("Vous ne pouvez pas assassinez avant " + tmob.NextKillAllowed.ToString());
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
            }
        }
    }
}
