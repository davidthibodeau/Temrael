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
using Server.Spells;
using Server.Spells.TechniquesCombat;

namespace Server.Scripts.Commands
{
    class Test
    {
        public static void Initialize()
        {
            CommandSystem.Register("Test", AccessLevel.Owner, new CommandEventHandler(Test_OnCommand));
            CommandSystem.Register("Test2", AccessLevel.Owner, new CommandEventHandler(Test2_OnCommand));
        }

        [Usage("Test")]
        [Description("Test de scripts")]
        public static void Test_OnCommand(CommandEventArgs e)
        {
            new SnareEffect(e.Mobile, new TimeSpan(0,0,10));
        }

        [Usage("Test2")]
        [Description("Test de scripts")]
        public static void Test2_OnCommand(CommandEventArgs e)
        {
            SnareEffect.UnSnare(e.Mobile);
        }
    }
}