using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Spells;

namespace Server.Custom.CustomSpell
{
    class CBouleDeGlace : CustomSpell.CSpellTargetted
    {

        Mobile m_Caster = null;
        Mobile m_Target = null;


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

        /*-------- TARGETTED INFO --------*/
        /* Temps de cast */ TimeSpan.FromSeconds(1),
        /* Nb de targets */ 1,
        /* Effect/Target */ false,
        /*         Range */ 10,

        /*--------- INGRÉDIENTS ---------*/
        Reagent.Garlic);



        public CBouleDeGlace(Mobile caster, Item scroll)
            : base(caster, scroll, m_info)
        {
            m_Caster = caster;

            //UnEffectParTarget = false;
        }

        public override void Effect()
        {
            if (target1 is Mobile )
            {
                m_Target = (Mobile)target1;

                if ( !m_Caster.CanSee( m_Target ) )
			    {
                    m_Caster.SendLocalizedMessage(500237); // Target can not be seen.
			    }
                else if (CheckSequence())
			    {
				    SpellHelper.Turn( m_Caster, m_Target );

                    SpellHelper.CheckReflect((int)this.Circle, ref m_Caster, ref m_Target);

                    double damage = Utility.RandomMinMax(10, 20);

                    damage = damage * ( 0.5 * m_Caster.Skills[SkillName.ArtMagique].Value );

                    m_Caster.MovingParticles(m_Target, 0x36D4, 7, 0, false, true, 9502, 4019, 0x160);
                    m_Caster.PlaySound(0x44B);
                }
            }
        }
    }
}
