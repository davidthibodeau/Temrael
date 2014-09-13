using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Spells;

namespace Server.Custom.CustomSpell
{

    // Utilisation du spell.

    // Mobile caster = new Mobile();
    // (new Custom.CustomSpell.ExempleTargetted(caster, null)).Cast();

    class ExempleTargetted : CustomSpell.CSpellTargetted
    {

        Mobile m_caster = null;
        Mobile m_target = null;

        const double scalingSkill = 0.1;

        static private InfoSpell.Targetted m_info = new InfoSpell.Targetted(

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

        /*--------- INGRÉDIENTS ---------*/
        Reagent.Garlic);



        public ExempleTargetted(Mobile caster, Item scroll)
            : base(caster, scroll, m_info)
        {
            m_caster = caster;
        }

        public override void Effect()
        {
            if (target1 is Mobile )
            {
                m_target = (Mobile)target1;

                if ( !m_Caster.CanSee( m_target ) )
			    {
                    m_Caster.SendLocalizedMessage(500237); // Target can not be seen.
			    }
                else
			    {
				    SpellHelper.Turn( m_Caster, m_target );

                    SpellHelper.CheckReflect((int)this.Circle, ref m_caster, ref m_target);

                    double damage = Utility.RandomMinMax(10, 20);

                    damage = damage * ( scalingSkill * m_Caster.Skills[SkillName.ArtMagique].Value);

                    // Ici mettre la fonction qui s'occupe de faire du dégâts magique (Probablement une fonction CombatStrategy.)
                    // m_Target.SpellDamage((int)damage);

                    m_Caster.MovingParticles(m_target, 0x36D4, 7, 0, false, true, 9502, 4019, 0x160);
                    m_Caster.PlaySound(0x44B);
                }
            }
        }
    }
}
