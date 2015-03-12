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
        }

        [Usage("Test")]
        [Description("Test de scripts")]
        public static void Test_OnCommand(CommandEventArgs e)
        {
            Server.Engines.Buffs.Buff p = new BuffForce(30);

            e.Mobile.SendMessage(p.GetType().Name);
            Server.Engines.Buffs.BuffHandler.Instance.ApplyEffect(e.Mobile, p, Source.None);
        }
    }
}