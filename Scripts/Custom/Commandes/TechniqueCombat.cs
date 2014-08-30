using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using Server.TechniquesCombat;

namespace Server.Custom.Commandes
{
    class TechniquesCombat
    {
        public static void Initialize()
        {

            CommandSystem.Register("Technique1", AccessLevel.Batisseur, new CommandEventHandler(Technique1_OnCommand));

            // ...
        }

        [Usage("Technique1")]
        [Description("Confère un bonus sur la vitesse d'attaque.")]
        public static void Technique1_OnCommand(CommandEventArgs e)
        {
            e.Mobile.Say("Technique1");
            new AttackSpeed((PlayerMobile)e.Mobile);
        }

        // ...
    }
}
