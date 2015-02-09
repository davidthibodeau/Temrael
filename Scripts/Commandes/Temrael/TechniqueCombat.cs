using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using Server.TechniquesCombat;
using Server.Spells;
using Server.Spells.TechniquesCombat;

namespace Server.Custom.Commandes
{
    class TechniquesCombat
    {
        public static void Initialize()
        {
            //CommandSystem.Register("Technique1", AccessLevel.Player, new CommandEventHandler(Technique1_OnCommand));
            CommandSystem.Register("SnareTechnique", AccessLevel.Player, new CommandEventHandler(Technique_Snare_OnCommande));
        }


        [Usage("Technique1")]
        [Description("Confère un bonus sur la vitesse d'attaque.")]
        public static void Technique1_OnCommand(CommandEventArgs e)
        {
            e.Mobile.Say("Technique1");
            new AttackSpeed((PlayerMobile)e.Mobile);
        }

        [Usage("SnareTechnique")]
        [Description("Êmpêche le prochain joueur frappé de bouger pendant X temps.")]
        public static void Technique_Snare_OnCommande(CommandEventArgs e)
        {
            new SnareTechnique(e.Mobile);
        }
    }
}
