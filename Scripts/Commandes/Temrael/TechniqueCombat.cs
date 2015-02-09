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
            CommandSystem.Register("SnareTechnique", AccessLevel.Player, new CommandEventHandler(Technique_Snare_OnCommand));
            CommandSystem.Register("ProtectionTechnique", AccessLevel.Player, new CommandEventHandler(Technique_Protection_OnCommand));
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
        public static void Technique_Snare_OnCommand(CommandEventArgs e)
        {
            new SnareTechnique(e.Mobile);
        }

        [Usage("ProtectionTechnique")]
        [Description("Permet au protecteur d'avoir une chance de prendre les coups à la place de la cible pendant 15 secondes.")]
        public static void Technique_Protection_OnCommand(CommandEventArgs e)
        {
            new ProtectionTechnique(e.Mobile);
        }
    }
}
