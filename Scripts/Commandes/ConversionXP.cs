using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Mobiles;
using Server.Accounting;
using System.IO;
using Server.Engines.Mort;

namespace Server.Commands
{
    public class ConversionXP
    {
        public static void Initialize()
        {
            //CommandSystem.Register("savexp", AccessLevel.Owner,
            //   new CommandEventHandler(savexp_OnCommand));
        }

        public static void savexp_OnCommand(CommandEventArgs e)
        {
            int count = 0;
            Console.WriteLine("Sauvegarde des xps dans les comptes.");
            ICollection<IAccount> accounts = Accounts.ServerAccounts.GetAccounts();
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
                        if (m == null || !(m is PlayerMobile))
                            continue;

                        PlayerMobile player = m as PlayerMobile;
                        w.Write(player.ToString() + "   ...    ");
                        int num = 0;

                        if ((!(player.Name.ToLower().Contains("[transfer]"))) && (!(player.Name.ToLower().Contains("[transféré]"))) && (!(player.Name.ToLower().Contains("(Transferer)"))) && (!(player.Name.ToLower().Contains("[Mort]"))))
                        {
                            if (player.MortEngine.MortCurrentState != MortState.Mourir && player.MortEngine.MortCurrentState != MortState.MortDefinitive && player.MortEngine.MortCurrentState != MortState.Delete)
                            {
                                if (player.Experience.XP > firstxp)
                                {
                                    thirdxp = secondxp;
                                    secondxp = firstxp;
                                    firstxp = player.Experience.XP;
                                }
                                else if (player.Experience.XP > secondxp)
                                {
                                    thirdxp = secondxp;
                                    secondxp = player.Experience.XP;
                                }
                                else if (player.Experience.XP > thirdxp)
                                {
                                    thirdxp = player.Experience.XP;
                                }
                                w.WriteLine("{0} XPs", player.Experience.XP);

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
                }
            }
            Console.WriteLine("Sauvegarde effectuée");
        }
    }
}
