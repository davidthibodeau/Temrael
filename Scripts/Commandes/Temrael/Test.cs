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
using Server.Engines.BuffHandling;
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
            Buff b = new BuffForce(30, TimeSpan.FromSeconds(15));

            e.Mobile.SendMessage(b.GetType().Name);
            BuffHandler.Instance.ApplyBuff(e.Mobile, b);
        }

        [Usage("Test2")]
        [Description("Test de scripts")]
        public static void Test2_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendMessage(BuffHandler.Instance.GetBuffCumul(e.Mobile, typeof(BuffForce)).ToString());
        }
    }
}