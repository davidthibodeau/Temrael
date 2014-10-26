using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;
using Server.Items;
using System.IO;
using Server.Accounting;

namespace Server.Commands
{
    public class CommandesCombat
    {

        private class SaveXPEntry
        {
            public string Account;

            public SaveXPEntry(string acc)
            {
                Account = acc;
            }
        }
        public static void Initialize()
        {
            CommandSystem.Register("savexp", AccessLevel.Coordinateur,
               new CommandEventHandler(savexp_OnCommand));
        }
        public static void savexp_OnCommand(CommandEventArgs e)
        {
            int count = 0;
			Console.WriteLine("Analyse...");
            Dictionary<string, SaveXPEntry> entrys = new Dictionary<string, SaveXPEntry>();
            foreach(Mobile m in World.Mobiles.Values)
            {
                if (m is TMobile)
                {					
                    TMobile player = m as TMobile;
                    int num = 0;

					if( player.Account != null )
					{
						count++;

                        Account act = player.Account as Account;

                        if ((!(player.Name.ToLower().Contains("[transfer]"))) && (!(player.Name.ToLower().Contains("[transféré]"))) && (!(player.Name.ToLower().Contains("(Transferer)"))) && (!(player.Name.ToLower().Contains("[Mort]"))))
                        {
                            if (player.MortCurrentState != MortState.Mourir && player.MortCurrentState != MortState.MortDefinitive && player.MortCurrentState != MortState.Delete)
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    //Console.WriteLine("Player : " + player.Name);
                                    if (act.GetTag("LegacyXP" + i.ToString()) == "")
                                    {
                                        act.RemoveTag("LegacyXP" + i.ToString());
                                        act.SetTag("LegacyXP" + i.ToString(), (player.XP * 4.4).ToString());
                                        //Console.WriteLine("LegacyXP" + i.ToString() + " : " + "LegacyXP" + i.ToString());
                                        break;
                                    }
                                    else if (!(Int32.TryParse(act.GetTag("LegacyXP" + i.ToString()), out num)))
                                    {
                                        act.RemoveTag("LegacyXP" + i.ToString());
                                        act.SetTag("LegacyXP" + i.ToString(), (player.XP * 2).ToString());
                                        //Console.WriteLine("LegacyXP" + i.ToString() + " : " + act.GetTag("LegacyXP" + i.ToString()));
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine(player.Name + " Deleted 2");
                            }
                        }
                        else
                        {
                            Console.WriteLine(player.Name + " Deleted 1");
                        }

						/*SaveXPEntry entry;
						if (!entrys.ContainsKey(player.Account.Username))
							entrys.Add(player.Account.Username, new SaveXPEntry(player.Account.Username));

						entry = entrys[player.Account.Username];
						SaveXPMobileEntry mobEntry = new SaveXPMobileEntry();
						mobEntry.Name = player.Name;
						mobEntry.XP = player.XP;
						mobEntry.TotalGold = player.TotalGold;
						if (player.BankBox != null)
                            mobEntry.TotalGold += player.BankBox.TotalGold;
						entry.Mobiles.Add(mobEntry);*/
					}
                }
            }
			/*Console.WriteLine("Exportation...");

            TextWriter text = new StreamWriter("exports.txt", false);

            FileStream file = File.Open("exports.bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);


            text.WriteLine("{0} accounts au total", entrys.Count);
            writer.Write(entrys.Count);

            foreach (SaveXPEntry entry in entrys.Values)
            {
                text.WriteLine("[{0}] ({1})", entry.Account, entry.Mobiles.Count);
                //serialization
                writer.Write((string)entry.Account); //string
                writer.Write((int)entry.Mobiles.Count);
                foreach (SaveXPMobileEntry mob in entry.Mobiles)
                {
                    text.WriteLine("--> ({0}): {1} xp | {2} po", mob.Name, mob.XP, mob.TotalGold);
                    writer.Write((string)mob.Name);
                    writer.Write((int)mob.XP);
                    writer.Write((int)mob.TotalGold);
                }
				text.WriteLine(" ");
            }
			Console.WriteLine("Done !");*/
        }
    }
}
