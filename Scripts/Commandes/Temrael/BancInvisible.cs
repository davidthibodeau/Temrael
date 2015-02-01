using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Commands
{
    class BancInvisible
    {
        public static void Initialize()
        {
            CommandSystem.Register("BancInvis", AccessLevel.Batisseur, new CommandEventHandler(BancInvis_OnCommand));
            //CommandSystem.Register("BancInvisible", AccessLevel.GameMaster, new CommandEventHandler(BancInvis_OnCommand));
        }

        [Usage("BancInvis")]
        [Description("Donne la liste des serial des bancs invisibles sur la case du mj.")]
        public static void BancInvis_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;
            IPooledEnumerable eable = from.Map.GetItemsInRange(from.Location, 0);
            foreach (Item i in eable)
            {
                if (i.ItemID == 0xB2D || i.ItemID == 0xB2C || i.ItemID == 0xB2E
                    || i.ItemID == 0xB2F || i.ItemID == 0xB31 || i.ItemID == 0xB30)
                    from.SendMessage("Banc invisible trouvé. Son Serial est {0}", i.Serial);
            }
        }
    }
}
