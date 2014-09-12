using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Spells;

namespace Server.Custom.CustomSpell
{
    class ExempleTargettedTimer : CustomSpell.CSpellTargettedTimer
    {

        Mobile m_caster = null;
        Mobile m_target = null;

        const double scalingSkill = 0.1;

        static private InfoSpell.TargettedTimer m_info = new InfoSpell.TargettedTimer(

        /*---------- SPELL INFO ----------*/
        /*  Nom du spell */ "Boule de Glace", 
        /*       Formule */ "Kal Vas Ayss",
        /*        Cercle */ Spells.SpellCircle.First,
        /*        Action */ 218,
        /*   Hand Effect */ 9002,
        /*     Mana cost */ 5,
        /* Skill utilisé */ SkillName.ArtMagique,
        /* Pts Skill req */ 0,
        /* Temps de cast */ TimeSpan.FromSeconds(5),

        /*-------- TARGETTED INFO --------*/
        /* Nb de targets */ 1,
        /* Effect/Target */ false,
        /*         Range */ 10,
        /*         Duree */ TimeSpan.FromSeconds(5),
        /*     Intervale */ TimerPriority.OneSecond,

        /*--------- INGRÉDIENTS ---------*/
        Reagent.Garlic);


        public ExempleTargettedTimer(Mobile caster, Item scroll)
            : base(caster, scroll, m_info)
        {
            m_caster = caster;
        }



        public override void OnStart()
        {
            if (target1 is Mobile)
            {
                m_target = (Mobile)target1;
                m_target.Say("Début du timer!");
            }
            else
            {
                this.StopSpell(); // Arrêt du timer et de l'effet.
            }
        }


        public override void OnTick()
        {
            switch (NumeroTick)
            {
                case 1: m_target.Say("Oh non, je me fais ticker!");
                    break;
                case 2: m_target.Say("Aaaarrrgh!");
                    break;
                case 3: m_target.Say("Arrêtez je vous en priieee!");
                    break;
            }
        }


        public override void OnEnd()
        {
            m_target.Say("Ouf, c'est fini.");
        }
    }
}
