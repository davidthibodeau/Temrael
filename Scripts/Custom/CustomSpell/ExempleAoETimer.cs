using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Spells;

namespace Server.Custom.CustomSpell
{
    class ExempleAoETimer : CustomSpell.CSpellAoETimer
    {
        Mobile m_caster;

        static private InfoSpell.AoETimer m_info = new InfoSpell.AoETimer(

        /*---------- SPELL INFO ----------*/
            /*  Nom du spell */ "Tremblement de terre",
            /*       Formule */ "Ooga Ooga Chakalaka",
            /*        Cercle */ Spells.SpellCircle.First,
            /*        Action */ 218,
            /*   Hand Effect */ 9002,
            /*     Mana cost */ 5,
            /* Skill utilisé */ SkillName.ArtMagique,
            /* Pts Skill req */ 0,
            /* Temps de cast */ TimeSpan.FromSeconds(5),

        /*-------- TARGETTED INFO --------*/
/*   Targets choisi au début */ false,
/*Continue cast during timer */ true,
            /*         Range */ 10,
            /*         Duree */ TimeSpan.FromSeconds(5),
            /*     Intervale */ TimerPriority.OneSecond,

        /*--------- INGRÉDIENTS ---------*/
        Reagent.Garlic);


        public ExempleAoETimer(Mobile caster, Item scroll)
            : base(caster, scroll, m_info)
        {
            m_caster = caster;
        }


        public override void UniqueEffect()
        {
            m_caster.PlaySound(0x2F3);
            m_caster.Say("Tremblement de terre!");
        }

        public override void OnStart(Mobile target)
        {
            target.Say("Pas pour de vrai ?!");
        }

        public override void OnTick(Mobile target)
        {
            target.Say("Oh non !");
        }

        public override void OnEnd(Mobile target)
        {
            target.Say("Ouf c'est fini.");
        }
    }
}
