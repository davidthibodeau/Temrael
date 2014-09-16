using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using Server.Items;
using Server.Targeting;
using Server.Network;

namespace Server.Scripts.Commands
{
    public class UnequipAllArmor
    {
        public static void Initialize()
        {
            CommandSystem.Register("UnequipAllArmor", AccessLevel.Coordinateur, new CommandEventHandler(UnequipAllArmor_OnCommand));
        }

        [Usage("UnequipAllArmor")]
        [Description("Desequippe les armures et armes de tous les PJs")]
        public static void UnequipAllArmor_OnCommand(CommandEventArgs e)
        {
            foreach (Mobile m in World.Mobiles.Values)
            {
                if (m is TMobile)
                {
                    TMobile player = m as TMobile;

                    for (int i = 0; i < player.Items.Count; i++ )
                    {
                        Item item = player.Items[i];

                        if (item != null)
                            if (item is BaseArmor || item is BaseWeapon)
                                player.AddToBackpack(item);
                    }
                }
            }
        }
    }
}
