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
        }

        [Usage("Test")]
        [Description("Test de scripts")]
        public static void Test_OnCommand(CommandEventArgs e)
        {
            Server.Engines.Alchimie.PotionEffect p = new PotionStrBuffScal();

            ((BaseWeapon)e.Mobile.Weapon).Poison = p;
            e.Mobile.SendMessage(p.GetType().Name);
            //Server.Engines.Alchimie.PotionEffectHandler.Instance.ApplyEffect(e.Mobile, p, Source.Potion);
        }
    }
}