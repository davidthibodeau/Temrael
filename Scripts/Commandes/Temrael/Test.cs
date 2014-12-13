using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using Server.Items;
using Server.Network;
using Server.Targeting;
using System.Collections.Generic;
using Server.Engines.Equitation;

namespace Server.Scripts.Commands
{
    class Test
    {
        public static void Initialize()
        {
            CommandSystem.Register("Test", AccessLevel.Batisseur, new CommandEventHandler(Test_OnCommand));
        }

        [Usage("Test")]
        [Description("Test de scripts")]
        public static void Test_OnCommand(CommandEventArgs e)
        {
            BoiteAuLettreComponent.WeeklyPay();
        }
    }
}