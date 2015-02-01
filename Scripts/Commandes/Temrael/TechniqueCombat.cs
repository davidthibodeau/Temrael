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
            //CommandSystem.Register("TechniqueAssassin", AccessLevel.Player, new CommandEventHandler(TechniqueAssassin_OnCommand));
            //CommandSystem.Register("Technique1", AccessLevel.Player, new CommandEventHandler(Technique1_OnCommand));
            //// ...
            //CommandSystem.Register("Targeted", AccessLevel.Player, new CommandEventHandler(Targeted_OnCommand));
            //CommandSystem.Register("TargetedTimer", AccessLevel.Player, new CommandEventHandler(TargetedTimer_OnCommand));
            //CommandSystem.Register("AoE", AccessLevel.Player, new CommandEventHandler(AoE_OnCommand));
            //CommandSystem.Register("AoETimer", AccessLevel.Player, new CommandEventHandler(AoETimer_OnCommand));
            //CommandSystem.Register("SpellSelf", AccessLevel.Player, new CommandEventHandler(Self_OnCommand));
            //CommandSystem.Register("SelfTimer", AccessLevel.Player, new CommandEventHandler(SelfTimer_OnCommand));
        }

        [Usage("TechniqueAssassin")]
        [Description("Confère un bonus de dégâts dépendant du niveau de poursuite.")]
        public static void TechniqueAssassin_OnCommand(CommandEventArgs e)
        {
            e.Mobile.Say("TechniqueAssassin");
            //new Assassinat((PlayerMobile)e.Mobile);
        }

        [Usage("Technique1")]
        [Description("Confère un bonus sur la vitesse d'attaque.")]
        public static void Technique1_OnCommand(CommandEventArgs e)
        {
            e.Mobile.Say("Technique1");
            new AttackSpeed((PlayerMobile)e.Mobile);
        }

        // ...

        [Usage("Targeted")]
        [Description("Exemple du TargetedTimer")]
        public static void Targeted_OnCommand(CommandEventArgs e)
        {
            (new Custom.CustomSpell.ExempleTargeted(e.Mobile, null)).Cast();
        }

        [Usage("TargetedTimer")]
        [Description("Exemple du TargetedTimer")]
        public static void TargetedTimer_OnCommand(CommandEventArgs e)
        {
            (new Custom.CustomSpell.ExempleTargetedTimer(e.Mobile, null)).Cast();
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

        [Usage("SpellSelf")]
        [Description("Exemple du Self")]
        public static void Self_OnCommand(CommandEventArgs e)
        {
            (new Custom.CustomSpell.ExempleSelf(e.Mobile, null)).Cast();
        }

        [Usage("SelfTimer")]
        [Description("Exemple du SelfTimer")]
        public static void SelfTimer_OnCommand(CommandEventArgs e)
        {
            (new Custom.CustomSpell.ExempleSelfTimer(e.Mobile, null)).Cast();
        }
    }
}
