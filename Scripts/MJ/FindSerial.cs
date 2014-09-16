using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class FindSerial
    {
        public static void Initialize()
        {
            CommandSystem.Register("FindSerial", AccessLevel.Chroniqueur, new CommandEventHandler(FindSerial_OnCommand));
        }

        public static void FindSerial_OnCommand(CommandEventArgs e)
        {
            try
            {
                int serial = e.GetInt32(0);
                bool found = false;
                ArrayList list = new ArrayList(World.Items.Values);

                for (int i = 0; i < list.Count; ++i)
                {
                    Item item = list[i] as Item;

                    if (item.Serial == serial)
                    {
                        e.Mobile.SendMessage(String.Format("Location : {0}", item.Location));

                        if (item.Parent != null)
                        {
                            e.Mobile.SendMessage(String.Format("Parent : {0}", item.Parent.ToString()));

                            if (item.Parent is Item && ((Item)item.Parent).Parent != null)
                            {
                                e.Mobile.SendMessage(String.Format("2e Parent : {0}", ((Item)item.Parent).Parent.ToString()));

                                if (((Item)item.Parent).Parent is Item && ((Item)((Item)item.Parent)).Parent != null)
                                {
                                    e.Mobile.SendMessage(String.Format("3e Parent : {0}", ((Item)((Item)item.Parent)).Parent.ToString()));

                                    if (((Item)item.Parent).Parent is Item && ((Item)((Item)item.Parent)).Parent != null)
                                    {
                                        e.Mobile.SendMessage(String.Format("4e Parent : {0}", ((Item)((Item)((Item)item.Parent))).Parent.ToString()));
                                        if (((Item)item.Parent).Parent is Item && ((Item)((Item)((Item)item.Parent))).Parent != null)
                                        {
                                            e.Mobile.SendMessage(String.Format("5e Parent : {0}", ((Item)((Item)((Item)((Item)item.Parent)))).Parent.ToString()));
                                            if (((Item)item.Parent).Parent is Item && ((Item)((Item)((Item)((Item)item.Parent)))).Parent != null)
                                            {
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        found = true;
                        break;
                    }
                }

                if (!found)
                    e.Mobile.SendMessage("Aucun item n'a été trouvé avec ce serial.");
            }
            catch
            {
                e.Mobile.SendMessage("Erreur dans l'exécution de la commande. Voir console.");
            }
        }
    }
}