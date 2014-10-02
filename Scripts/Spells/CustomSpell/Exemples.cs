using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Spells;

namespace Server.Custom.CustomSpell
{
    // Utilisation du spell.

    // Mobile caster = new Mobile();
    // (new Custom.CustomSpell.ExempleTargeted(caster, null)).Cast();

    class ExempleTargeted : CustomSpell.CSpellTargeted
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        Mobile m_caster = null;
        Mobile m_target = null;

        const double scalingSkill = 0.1;

        static private InfoSpell.Targeted info = new InfoSpell.Targeted(

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

        /*-------- Targeted INFO --------*/
            /* Nb de targets */ 1,
            /* Effect/Target */ false,
            /*         Range */ 10,

        /*--------- INGRÉDIENTS ---------*/
        Reagent.Garlic);



        public ExempleTargeted(Mobile caster, Item scroll)
            : base(caster, scroll, info)
        {
            m_caster = caster;
        }

        public override void Effect()
        {
            if (target1 is Mobile)
            {
                m_target = (Mobile)target1;

                if (!m_Caster.CanSee(m_target))
                {
                    m_Caster.SendLocalizedMessage(500237); // Target can not be seen.
                }
                else
                {
                    SpellHelper.Turn(m_Caster, m_target);

                    SpellHelper.CheckReflect((int)this.Circle, ref m_caster, ref m_target);

                    double damage = Utility.RandomMinMax(10, 20);

                    damage = damage * (scalingSkill * m_Caster.Skills[SkillName.ArtMagique].Value);

                    // Ici mettre la fonction qui s'occupe de faire du dégâts magique (Probablement une fonction CombatStrategy.)
                    // m_Target.SpellDamage((int)damage);

                    m_Caster.MovingParticles(m_target, 0x36D4, 7, 0, false, true, 9502, 4019, 0x160);
                    m_Caster.PlaySound(0x44B);
                }
            }
        }
    }

    class ExempleTargetedTimer : CustomSpell.CSpellTargetedTimer
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        Mobile m_caster = null;
        Mobile m_target = null;

        const double scalingSkill = 0.1;

        static private InfoSpell.TargetedTimer info = new InfoSpell.TargetedTimer(

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

        /*-------- TARGETED INFO --------*/
            /* Nb de targets */ 1,
            /* Effect/Target */ false,
            /*         Range */ 10,
            /*         Duree */ TimeSpan.FromSeconds(5),
            /*     Intervale */ TimerPriority.OneSecond,

        /*--------- INGRÉDIENTS ---------*/
        Reagent.Garlic);


        public ExempleTargetedTimer(Mobile caster, Item scroll)
            : base(caster, scroll, info)
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

    class ExempleAoE : CustomSpell.CSpellAoE
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        Mobile m_caster;

        static private InfoSpell.AoE info = new InfoSpell.AoE(

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

        /*---------- AOE INFO ----------*/
            /*         Range */ 10,

        /*--------- INGRÉDIENTS ---------*/
        Reagent.Garlic);

        public ExempleAoE(Mobile caster, Item scroll)
            : base(caster, scroll, info)
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

    class ExempleAoETimer : CustomSpell.CSpellAoETimer
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        Mobile m_caster;

        static private InfoSpell.AoETimer info = new InfoSpell.AoETimer(

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

        /*---------- AOE INFO ----------*/
            /*   Targets choisi au début */ false,
            /*Continue cast during timer */ true,
            /*         Range */ 10,
            /*         Duree */ TimeSpan.FromSeconds(5),
            /*     Intervale */ TimerPriority.OneSecond,

        /*--------- INGRÉDIENTS ---------*/
        Reagent.Garlic);


        public ExempleAoETimer(Mobile caster, Item scroll)
            : base(caster, scroll, info)
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

    class ExempleSelf : CustomSpell.CSpellSelf
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        static private InfoSpell.Self info = new InfoSpell.Self(

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

        /*--------- INGRÉDIENTS ---------*/
        Reagent.Garlic);

        public ExempleSelf(Mobile caster, Item scroll)
            : base(caster, scroll, info)
        {
        }

        public override void Effect(Mobile caster)
        {
            caster.Say("Je me fais affecter!");
        }
    }

    class ExempleSelfTimer : CustomSpell.CSpellSelfTimer
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE


        static private InfoSpell.SelfTimer info = new InfoSpell.SelfTimer(

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
        /*---------- SELF INFO ----------*/
            /*         Duree */ TimeSpan.FromSeconds(5),
            /*     Intervale */ TimerPriority.OneSecond,

        /*--------- INGRÉDIENTS ---------*/
        Reagent.Garlic);

        public ExempleSelfTimer(Mobile caster, Item scroll)
            : base(caster, scroll, info)
        {
        }

        public override void UniqueEffect()
        {
            Caster.Say("UniqueEffect");
        }

        public override void OnStart(Mobile caster)
        {
            Caster.Say("OnStart");
        }

        public override void OnTick(Mobile caster)
        {
            Caster.Say("OnTick");
        }

        public override void OnEnd(Mobile caster)
        {
            Caster.Say("OnEnd");
        }
    }




}
