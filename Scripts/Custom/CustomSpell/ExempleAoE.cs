using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Spells;

namespace Server.Custom.CustomSpell
{
    class ExempleAoE : CustomSpell.CSpellAoE
    {
        Mobile m_caster;

        static private InfoSpell.AoE m_info = new InfoSpell.AoE(

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
            /*         Range */ 10,

        /*--------- INGRÉDIENTS ---------*/
        Reagent.Garlic);

        public ExempleAoE(Mobile caster, Item scroll)
            : base(caster, scroll, m_info)
        {
            m_caster = caster;
        }

        public override void UniqueEffect()
        {
        }

        public override void TargetEffect(Mobile target)
        {
            if (target != Caster)
            {
                target.Say("Je me fais tremblement de terrer!");
            }
        }



    }
}
