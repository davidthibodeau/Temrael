using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Spells;

namespace Server.Custom.CustomSpell
{
    public class InfoSpell : Server.Spells.SpellInfo
    {
        // Commun à tous les spells.
        private int m_castTime = -1;
        public int castTime { get { return m_castTime; } set { if (value <= 60 && value >= 0) m_castTime = value; } }

        public StyleSpell style = StyleSpell.Unsetted;


        // S'assure que tous ses membres ont été initialisés correctement.
        public void CheckValidity()
        {
            if (!(   castTime >= 0 &&
                     style != StyleSpell.Unsetted))
            {
                throw new Exception("BaseSpellInfo initialisé incorrectement :" + Name + ".");
            }
        }


        private InfoSpell(string Name, string Formule, SpellCircle Cercle, int Action, int HandEffect, int ManaCost, SkillName SkillUtilise, int NiveauSkillReq, int CastTime, StyleSpell Style, params Type[] regs)
            : base(Name, Formule, Cercle, Action, HandEffect, ManaCost, SkillUtilise, NiveauSkillReq, true, regs)
        {
            castTime = CastTime;
            style = Style;

            CheckValidity();
        }


        #region Spécialisations d'InfoBaseSpell pour chaque type de spell.
        public class Targetted : InfoSpell
        {
            // Membres aditionnels.

            public Targetted(string Name, string Formule, SpellCircle Cercle, int Action, int HandEffect, int ManaCost, SkillName SkillUtilise, int NiveauSkillReq, int CastTime, params Type[] regs)
                : base(Name, Formule, Cercle, Action, HandEffect, ManaCost, SkillUtilise, NiveauSkillReq, CastTime, StyleSpell.Targetted, regs)
            {
            }
        }

        public class TargettedTimer : InfoSpell
        {
            // Membres aditionnels.

            public TargettedTimer(string Name, string Formule, SpellCircle Cercle, int Action, int HandEffect, int ManaCost, SkillName SkillUtilise, int NiveauSkillReq, int CastTime, params Type[] regs)
                : base(Name, Formule, Cercle, Action, HandEffect, ManaCost, SkillUtilise, NiveauSkillReq, CastTime, StyleSpell.TargettedTimer, regs)
            {

            }
        }

        public class AoE : InfoSpell
        {
            // Membres aditionnels.

            public AoE(string Name, string Formule, SpellCircle Cercle, int Action, int HandEffect, int ManaCost, SkillName SkillUtilise, int NiveauSkillReq, int CastTime, params Type[] regs)
                : base(Name, Formule, Cercle, Action, HandEffect, ManaCost, SkillUtilise, NiveauSkillReq, CastTime, StyleSpell.AoE, regs)
            {

            }
        }

        public class AoETimer : InfoSpell
        {
            // Membres aditionnels.

            public AoETimer(string Name, string Formule, SpellCircle Cercle, int Action, int HandEffect, int ManaCost, SkillName SkillUtilise, int NiveauSkillReq, int CastTime, params Type[] regs)
                : base(Name, Formule, Cercle, Action, HandEffect, ManaCost, SkillUtilise, NiveauSkillReq, CastTime, StyleSpell.AoETimer, regs)
            {

            }
        }

        public class Self : InfoSpell
        {
            // Membres aditionnels.

            public Self(string Name, string Formule, SpellCircle Cercle, int Action, int HandEffect, int ManaCost, SkillName SkillUtilise, int NiveauSkillReq, int CastTime, params Type[] regs)
                : base(Name, Formule, Cercle, Action, HandEffect, ManaCost, SkillUtilise, NiveauSkillReq, CastTime, StyleSpell.AoETimer, regs)
            {

            }
        }

        public class SelfTimer : InfoSpell
        {
            // Membres aditionnels.

            public SelfTimer(string Name, string Formule, SpellCircle Cercle, int Action, int HandEffect, int ManaCost, SkillName SkillUtilise, int NiveauSkillReq, int CastTime, params Type[] regs)
                : base(Name, Formule, Cercle, Action, HandEffect, ManaCost, SkillUtilise, NiveauSkillReq, CastTime, StyleSpell.AoETimer, regs)
            {

            }
        }
        #endregion

    }
}
