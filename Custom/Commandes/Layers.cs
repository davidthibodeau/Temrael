using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;

namespace Server.Scripts.Commands
{
    class Layers
    {
        public static void Initialize()
        {
            CommandSystem.Register("ChangerLayers", AccessLevel.Player, new CommandEventHandler(Layers_OnCommand));
        }

        [Usage("ChangerLayers")]
        [Description("Ouvre le menu permettant de changer le layer d'un vetement.")]
        public static void Layers_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from is TMobile)
            {
                from.SendGump(new LayersGump((Mobile)from));
            }
        }
    }
}
