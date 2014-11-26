using Server.Commands;
using Server.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Accounting
{
    public class AccountMerging
    {
        public static void Initialize()
        {
            //CommandSystem.Register("mergeaccounts", AccessLevel.Owner, new CommandEventHandler(MergeAccounts_OnCommand));
        }

        public static void MergeAccounts_OnCommand(CommandEventArgs e)
        {
            NetState.FlushAll();
            NetState.Pause();

            DateTime start = DateTime.Now;

            MergeTagsFromMain();
            MergeAccountsFromPrison();
            RemoveUnusedTags();

            DateTime end = DateTime.Now;

            NetState.Resume();

            World.Broadcast(0x35, true, "Les accounts ont été fusionnés. The entire process took {0:F1} seconds.", (end - start).TotalSeconds);
            Console.WriteLine("Les accounts ont été fusionnés");
        }

        public static void MergeTagsFromMain()
        {
            Accounts main = new Accounts();

            main.Load("Accounts/main.xml");

            foreach (Account acc in main.GetAccounts())
            {
                Account account = Accounts.ServerAccounts.GetAccount(acc.Username) as Account;

                if (account != null) //Si existant, on lui donne les tags de l'ancien. Autrement, il fut supprimé.
                {
                    foreach (AccountTag tag in acc.Tags)
                    {
                        account.AddTag(tag.Name, tag.Value);
                    }
                }
            }
        }

        public static void MergeAccountsFromPrison()
        {
            Accounts prison = new Accounts();

            prison.Load("Accounts/prison.xml");

            foreach (Account acc in prison.GetAccounts())
            {
                Account account = Accounts.ServerAccounts.GetAccount(acc.Username) as Account;

                if (account == null) //Si non existant, on l'ajoute.
                {
                    for (int i = 0; i < 7; i++)
                    {
                        acc[i] = null; // Si l'account n'existait pas, on s'assure qu'il n'a pas de perso par accident.
                    }

                    List<AccountTag> tags = new List<AccountTag>(acc.Tags);

                    foreach (AccountTag tag in tags)
                    {
                        acc.RemoveTag(tag.Name); // On retire aussi tous les tags.
                    }
                    
                    Accounts.ServerAccounts.Add(acc);
                }
            }
        }

        public static void RemoveUnusedTags()
        {
            foreach (Account acc in Accounts.ServerAccounts.GetAccounts())
            {
                acc.RemoveTag("XPBeta");
                acc.RemoveTag("XP");

                acc.Transfert.ConvertTagsIntoActualTransferts();
            }
        }
    }
}
