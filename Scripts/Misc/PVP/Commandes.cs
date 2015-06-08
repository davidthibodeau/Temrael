using Server.Mobiles;
using Server.Commands;
using Server.Targeting;
using Server.Items;
using Server.Misc.PVP;
using Server.Misc.PVP.Gumps;
using System.Collections.Generic;

namespace Server.Commandes.Temrael
{
    class Commandes
    {
        public static void Initialize()
        {
            CommandSystem.Register("PVP", AccessLevel.Batisseur, new CommandEventHandler(PVP_OnCommand)); // Pourrait être accessible aux joueurs si on améliore le despawn.
            CommandSystem.Register("PVPDelete", AccessLevel.Batisseur, new CommandEventHandler(PVPDelete_OnCommand));
            CommandSystem.Register("PVPClear", AccessLevel.Batisseur, new CommandEventHandler(PVPClear_OnCommand));
        }

        [Usage("PVP")]
        [Description("Donne accès au gump de PVP.")]
        public static void PVP_OnCommand(CommandEventArgs e)
        {
            foreach (KeyValuePair<Serial, Item> pair in World.Items)
            {
                if (pair.Value is PVPStone)
                {
                    e.Mobile.SendGump(new PVPGump(e.Mobile, (PVPStone)pair.Value));
                    break;
                }
            }
        }

        [Usage("PVPDelete [Nom de l'event]")]
        [Description("Permet de deleter un event précis.")]
        public static void PVPDelete_OnCommand(CommandEventArgs e)
        {
            PVPEvent pvpevent_todelete = null;
            if (PVPEvent.m_InstancesList != null)
            {
                foreach (PVPEvent pvpevent in PVPEvent.m_InstancesList)
                {
                    if (pvpevent.nom == e.Arguments[0])
                    {
                        pvpevent_todelete = pvpevent;
                        break;
                    }
                }
            }

            if (pvpevent_todelete != null)
            {
                pvpevent_todelete.StopEvent();
            }

        }

        [Usage("PVPClear")]
        [Description("Permet de deleter tous les events de la liste.")]
        public static void PVPClear_OnCommand(CommandEventArgs e)
        {
            PVPEvent.m_InstancesList = new System.Collections.ArrayList();
        }

    }
}
