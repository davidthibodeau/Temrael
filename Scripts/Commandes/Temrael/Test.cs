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
using Server.Engines.Buffs;

namespace Server.Scripts.Commands
{
    class Test
    {
        public static void Initialize()
        {
            CommandSystem.Register("Test", AccessLevel.Batisseur, new CommandEventHandler(Test_OnCommand));
            CommandSystem.Register("Test2", AccessLevel.Batisseur, new CommandEventHandler(Test2_OnCommand));
        }

        [Usage("Test")]
        [Description("Test de scripts")]
        public static void Test_OnCommand(CommandEventArgs e)
        {
            Server.Engines.Buffs.Buff b = new BuffForce(30, TimeSpan.FromSeconds(15));

            e.Mobile.SendMessage(b.GetType().Name);
            Server.Engines.Buffs.BuffHandler.Instance.ApplyBuff(e.Mobile, b);
        }

        [Usage("Test2")]
        [Description("Test de scripts")]
        public static void Test2_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendMessage(Server.Engines.Buffs.BuffHandler.Instance.GetBuffCumul(e.Mobile, typeof(Server.Engines.Buffs.BuffForce)).ToString());
        }
    }
}