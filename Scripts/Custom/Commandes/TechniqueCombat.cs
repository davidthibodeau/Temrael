using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using Server.TechniquesCombat;
using Server.Spells;

namespace Server.Custom.Commandes
{
    class TechniquesCombat
    {
        public static void Initialize()
        {
            CommandSystem.Register("TechniqueAssassin", AccessLevel.Player, new CommandEventHandler(TechniqueAssassin_OnCommand));
            CommandSystem.Register("Technique1", AccessLevel.Player, new CommandEventHandler(Technique1_OnCommand));
            // ...
            CommandSystem.Register("Targetted", AccessLevel.Player, new CommandEventHandler(Targetted_OnCommand));
            CommandSystem.Register("TargettedTimer", AccessLevel.Player, new CommandEventHandler(TargettedTimer_OnCommand));
            CommandSystem.Register("AoE", AccessLevel.Player, new CommandEventHandler(AoE_OnCommand));
            CommandSystem.Register("AoETimer", AccessLevel.Player, new CommandEventHandler(AoETimer_OnCommand));
        }

        [Usage("TechniqueAssassin")]
        [Description("Confère un bonus de dégâts dépendant du niveau de poursuite.")]
        public static void TechniqueAssassin_OnCommand(CommandEventArgs e)
        {
            e.Mobile.Say("TechniqueAssassin");
            new Assassinat((PlayerMobile)e.Mobile);
        }

        [Usage("Technique1")]
        [Description("Confère un bonus sur la vitesse d'attaque.")]
        public static void Technique1_OnCommand(CommandEventArgs e)
        {
            e.Mobile.Say("Technique1");
            new AttackSpeed((PlayerMobile)e.Mobile);
        }

        // ...

        [Usage("Targetted")]
        [Description("Exemple du targettedTimer")]
        public static void Targetted_OnCommand(CommandEventArgs e)
        {
            (new Custom.CustomSpell.ExempleTargetted(e.Mobile, null)).Cast();
        }

        [Usage("TargettedTimer")]
        [Description("Exemple du targettedTimer")]
        public static void TargettedTimer_OnCommand(CommandEventArgs e)
        {
            (new Custom.CustomSpell.ExempleTargettedTimer(e.Mobile, null)).Cast();
        }

        [Usage("AoE")]
        [Description("Exemple du AoE")]
        public static void AoE_OnCommand(CommandEventArgs e)
        {
            (new Custom.CustomSpell.ExempleAoE(e.Mobile, null)).Cast();
        }

        [Usage("AoETimer")]
        [Description("Exemple du AoETimer")]
        public static void AoETimer_OnCommand(CommandEventArgs e)
        {
            (new Custom.CustomSpell.ExempleAoETimer(e.Mobile, null)).Cast();
        }
    }
}
