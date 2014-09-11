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
        private TimeSpan m_castTime = new TimeSpan(0, 0, -1);
        public TimeSpan castTime { get { return m_castTime; } set { if (value.Seconds <= 60 && value.Seconds >= 0) m_castTime = value; } }

        public StyleSpell style = StyleSpell.Unsetted;


        // S'assure que tous ses membres ont été initialisés correctement.
        public void CheckValidity()
        {
            if (!(   castTime.Seconds >= 0 &&
                     style != StyleSpell.Unsetted))
            {
                throw new Exception("BaseSpellInfo initialisé incorrectement :" + Name + ".");
            }
        }


        private InfoSpell(string Name, string Formule, SpellCircle Cercle, int Action, int HandEffect, int ManaCost, SkillName SkillUtilise, int NiveauSkillReq, TimeSpan CastTime, StyleSpell Style, params Type[] regs)
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
            private int m_NbTarget = 1;
            public int nbTarget { get { return m_NbTarget; } set { if (value <= 3 && value >= 1) m_NbTarget = value; } }

            private int m_Range = 10;
            public int range { get { return m_Range; } set { if (value <= 20 && value >= 1) m_Range = value; } }

            // Permet de passer à travers la fonction Effect() à chaque fois qu'on click un target.
            public bool unEffectParTarget = false;


            public Targetted(string Name, string Formule, SpellCircle Cercle, int Action, int HandEffect, int ManaCost, SkillName SkillUtilise, int NiveauSkillReq, TimeSpan CastTime, int NbTarget, bool unEffectParTarget, int Range, params Type[] regs)
                : base(Name, Formule, Cercle, Action, HandEffect, ManaCost, SkillUtilise, NiveauSkillReq, CastTime, StyleSpell.Targetted, regs)
            {
                nbTarget = NbTarget;
                range = Range;
            }
        }

        public class TargettedTimer : InfoSpell
        {
            // Membres aditionnels.

            public TargettedTimer(string Name, string Formule, SpellCircle Cercle, int Action, int HandEffect, int ManaCost, SkillName SkillUtilise, int NiveauSkillReq, TimeSpan CastTime, params Type[] regs)
                : base(Name, Formule, Cercle, Action, HandEffect, ManaCost, SkillUtilise, NiveauSkillReq, CastTime, StyleSpell.TargettedTimer, regs)
            {

            }
        }

        public class AoE : InfoSpell
        {
            // Membres aditionnels.

            public AoE(string Name, string Formule, SpellCircle Cercle, int Action, int HandEffect, int ManaCost, SkillName SkillUtilise, int NiveauSkillReq, TimeSpan CastTime, params Type[] regs)
                : base(Name, Formule, Cercle, Action, HandEffect, ManaCost, SkillUtilise, NiveauSkillReq, CastTime, StyleSpell.AoE, regs)
            {

            }
        }

        public class AoETimer : InfoSpell
        {
            // Membres aditionnels.

            public AoETimer(string Name, string Formule, SpellCircle Cercle, int Action, int HandEffect, int ManaCost, SkillName SkillUtilise, int NiveauSkillReq, TimeSpan CastTime, params Type[] regs)
                : base(Name, Formule, Cercle, Action, HandEffect, ManaCost, SkillUtilise, NiveauSkillReq, CastTime, StyleSpell.AoETimer, regs)
            {

            }
        }

        public class Self : InfoSpell
        {
            // Membres aditionnels.

            public Self(string Name, string Formule, SpellCircle Cercle, int Action, int HandEffect, int ManaCost, SkillName SkillUtilise, int NiveauSkillReq, TimeSpan CastTime, params Type[] regs)
                : base(Name, Formule, Cercle, Action, HandEffect, ManaCost, SkillUtilise, NiveauSkillReq, CastTime, StyleSpell.AoETimer, regs)
            {

            }
        }

        public class SelfTimer : InfoSpell
        {
            // Membres aditionnels.

            public SelfTimer(string Name, string Formule, SpellCircle Cercle, int Action, int HandEffect, int ManaCost, SkillName SkillUtilise, int NiveauSkillReq, TimeSpan CastTime, params Type[] regs)
                : base(Name, Formule, Cercle, Action, HandEffect, ManaCost, SkillUtilise, NiveauSkillReq, CastTime, StyleSpell.AoETimer, regs)
            {

            }
        }
        #endregion

    }
}
