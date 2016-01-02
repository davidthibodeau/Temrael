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
using Server.Engines.Alchimie;

namespace Server.Scripts.Commands
{
    class Test
    {
        public static void Initialize()
        {
            CommandSystem.Register("Test", AccessLevel.Batisseur, new CommandEventHandler(Test_OnCommand));
            CommandSystem.Register("Test2", AccessLevel.Batisseur, new CommandEventHandler(Test2_OnCommand));
            CommandSystem.Register("Test3", AccessLevel.Batisseur, new CommandEventHandler(Test3_OnCommand));
        }

        [Usage("Test")]
        [Description("Test de scripts")]
        public static void Test_OnCommand(CommandEventArgs e)
        {
            Potion pot = new Potion(PotionImpl.Create((ScriptMobile)e.Mobile, new PotForce(TargetFlags.Beneficial, true)));

            if(pot != null)
                e.Mobile.AddToBackpack(pot);
        }

        [Usage("Test2")]
        [Description("Test de scripts")]
        public static void Test2_OnCommand(CommandEventArgs e)
        {
            Potion pot = new Potion(PotionImpl.Create((ScriptMobile)e.Mobile, new PotDex(TargetFlags.Harmful, true)));

            if (pot != null)
                e.Mobile.AddToBackpack(pot);
        }

        [Usage("Test3")]
        [Description("Test de scripts")]
        public static void Test3_OnCommand(CommandEventArgs e)
        {
            Potion pot1 = (Potion)e.Mobile.Backpack.FindItemByType(typeof(Potion));

            Potion pot2 = (Potion)e.Mobile.Backpack.FindItemByType(typeof(Potion));

            pot2.Mix(pot1);
            e.Mobile.SendMessage("Mixed.");
        }

    }
}