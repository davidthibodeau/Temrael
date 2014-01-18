using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using Server.Items;
using Server.Targeting;
using Server.Network;
using Server.Combat;

// Revue du délais entre chaque assassinat a 5 Minutes 
// Revue a la hausse des dégats de 1.5 à 1.7
namespace Server.Scripts.Commands
{
    class Assassinat
    {
        public static void Initialize()
        {
            CommandSystem.Register("Assassinat", AccessLevel.Player, new CommandEventHandler(Assassinat_OnCommand));
        }

        [Usage("Assassinat")]
        [Description("Permet d'assassiner un autre personnage.")]
        public static void Assassinat_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from is TMobile)
            {
                TMobile pm = (TMobile)e.Mobile;

                if (DateTime.Now < pm.LastAssassinat.AddMinutes(5)) 
                {
                    pm.SendMessage("Vous ne pouvez pas assassiner des maintenant !");
                }
                else if (pm.Weapon == null || !(pm.Weapon is BaseWeapon) || !(((BaseWeapon)pm.Weapon).Layer == Layer.OneHanded))
                {
                    pm.SendMessage("Vous devez avoir une arme a une main pour assassiner !");
                }
                else if (pm != null && pm.GetAptitudeValue(NAptitude.Assassinat) > 0)
                {
                    from.Target = new AssassinatTarget();
                }
                else
                {
                    pm.SendMessage("Vous devez avoir au moins un point en l'aptitude d'assassinat.");
                }
            }
        }

        private class AssassinatTarget : Target
        {

            public AssassinatTarget()
                : base(3, true, TargetFlags.None)
            {
                AllowNonlocal = true;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (from is TMobile)
                {
                    if (targeted is StaticTarget)
                    {
                        from.SendMessage("Vous devez pointer un personnage !");
                    }
                    else if (targeted is LandTarget)
                    {
                        from.SendMessage("Vous devez pointer un personnage !");
                    }
                    else if (targeted is TMobile)
                    {
                        if (targeted != from)
                        {
                            if (from.Hidden)
                            {
                                if (from.InRange(((TMobile)targeted).Location, 1))
                                {
                                    TMobile pm = (TMobile)from;
                                    TMobile defender = (TMobile)targeted;

                                    pm.SayTo(defender, "");

                                    //  double hitscale = (defender.ArmorRating * 2 / 150);

                                    double checkhitscale = 0;

                                    //if (pm.Hidden)
                                        checkhitscale = (pm.GetAptitudeValue(NAptitude.Assassinat) * 0.1);

                                    /*if (pm.GetAptitudeValue(NAptitude.Assassinat) > 0)
                                        checkhitscale = (pm.GetAptitudeValue(NAptitude.Assassinat) * 0.05);*/


                                    Item gorge = defender.FindItemOnLayer(Layer.Neck);
                                    if (gorge is BaseArmor)
                                    {
                                        BaseArmor gorgerin = gorge as BaseArmor;
                                        double malus = ((double)gorgerin.NiveauAttirail) * 0.0666;
                                        checkhitscale -= malus;
                                    }

                                    if (defender.Mounted)
                                    {
                                        checkhitscale -= 0.2;
                                    }

                                    //checkhitscale += pm.GetConnaissancesValue(NConnaissances.Traquenard) * 0.03;

                                    //if (defender is TMobile && ((TMobile)defender).GetAttributValue(Attribut.Pouvoir) > 0)
                                    //    checkhitscale = checkhitscale - (((TMobile)defender).GetAttributValue(Attribut.Pouvoir) * 0.00125);

                                    pm.DisruptiveAction();

                                    if (pm.NetState != null)
                                        pm.Send(new Swing(0, pm, defender));

                                    BaseWeapon weapon = ((BaseWeapon)pm.FindItemOnLayer(Layer.OneHanded));

                                    double hitscale = (weapon.MaxDamage * 1.7) * (1 + (pm.GetAptitudeValue(NAptitude.Assassinat) * 0.2));

                                    SequenceCombat combat = new SequenceCombat(pm, defender);
                                    if (combat.CheckHit())
                                        weapon.OnHit(pm, defender, hitscale);
                                    else
                                        weapon.OnMiss(pm, defender);

                                    pm.RevealingAction();

                                    pm.NextSkillTime = DateTime.Now + TimeSpan.FromSeconds(5);

                                    pm.LastAssassinat = DateTime.Now;
                                }
                                else
                                {
                                    from.SendMessage("La cible est trop loin !");
                                }
                            }
                            else
                            {
                                from.SendMessage("Vous devez etre cache !");
                            }
                        }
                        else
                        {
                            from.SendMessage("Vous ne pouvez pas vous assassinez vous meme !");
                        }
                    }
                    else if (targeted is Item)
                    {
                        from.SendMessage("Vous devez pointer un personnage !");
                    }
                }
            }
        }
    }
}
