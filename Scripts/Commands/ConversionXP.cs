using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Mobiles;
using Server.Accounting;
using System.IO;

namespace Server.Commands
{
    public class ConversionXP
    {
        public static void Initialize()
        {
            CommandSystem.Register("savexp", AccessLevel.Owner,
               new CommandEventHandler(savexp_OnCommand));
        }

        public static void savexp_OnCommand(CommandEventArgs e)
        {
            int count = 0;
            Console.WriteLine("Sauvegarde des xps dans les comptes.");
            ICollection<IAccount> accounts = Accounts.GetAccounts();
            using (StreamWriter w = new StreamWriter("convertxp.log"))
            {
                foreach (Account act in accounts)
                {
                    if (act == null)
                        continue;
                    w.WriteLine("-------------------------");
                    w.WriteLine("Account: {0}", act.Username);

                    int firstxp = 0;
                    int secondxp = 0;
                    int thirdxp = 0;

                    for (int i = 0; i < 6; i++)
                    {
                        Mobile m = act[i];
                        if (m == null || !(m is TMobile))
                            continue;

                        TMobile player = m as TMobile;
                        w.Write(player.ToString() + "   ...    ");
                        int num = 0;

                        if ((!(player.Name.ToLower().Contains("[transfer]"))) && (!(player.Name.ToLower().Contains("[transféré]"))) && (!(player.Name.ToLower().Contains("(Transferer)"))) && (!(player.Name.ToLower().Contains("[Mort]"))))
                        {
                            if (player.MortCurrentState != MortState.Mourir && player.MortCurrentState != MortState.MortDefinitive && player.MortCurrentState != MortState.Delete)
                            {
                                if (player.XP > firstxp)
                                {
                                    thirdxp = secondxp;
                                    secondxp = firstxp;
                                    firstxp = player.XP;
                                }
                                else if (player.XP > secondxp)
                                {
                                    thirdxp = secondxp;
                                    secondxp = player.XP;
                                }
                                else if (player.XP > thirdxp)
                                {
                                    thirdxp = player.XP;
                                }
                                w.WriteLine("{0} XPs", player.XP);

                            }
                            else
                            {
                                w.WriteLine("Deleted 2");
                            }
                        }
                        else
                        {
                            w.WriteLine("Deleted 1");
                        }
                    }
                    act.SetTag("SavedXP1", firstxp.ToString());
                    act.SetTag("SavedXP2", secondxp.ToString());
                    act.SetTag("SavedXP3", thirdxp.ToString());

                    ////Console.WriteLine("Player : " + player.Name);
                    //if (act.GetTag("LegacyXP" + i.ToString()) == "")
                    //{
                    //    act.RemoveTag("LegacyXP" + i.ToString());
                    //    act.SetTag("LegacyXP" + i.ToString(), (player.XP * 4.4).ToString());
                    //    //Console.WriteLine("LegacyXP" + i.ToString() + " : " + "LegacyXP" + i.ToString());
                    //    break;
                    //}
                    //else if (!(Int32.TryParse(act.GetTag("LegacyXP"), out num)))
                    //{
                    //    act.RemoveTag("LegacyXP" + i.ToString());
                    //    act.SetTag("LegacyXP" + i.ToString(), (player.XP * 2).ToString());
                    //    //Console.WriteLine("LegacyXP" + i.ToString() + " : " + act.GetTag("LegacyXP" + i.ToString()));
                    //    break;
                    //}
                }
            }
            Console.WriteLine("Sauvegarde effectuée");
        }
    }
}
