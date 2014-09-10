using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Spells;


namespace Server.Custom.CustomSpell
{
    public enum StyleSpell
    {
        Unsetted, // Par défaut, si non défini.

        Targetted,
        TargettedTimer,

        AoE,
        AoETimer,

        Self,
        SelfTimer
    }

    // Classe de base pour les autres sortes de spell. Non-instanciable.
    public class CustomSpell : Server.Spells.Spell
    {
        private StyleSpell m_Style;

        private CustomSpell(Mobile caster, Item scroll, InfoSpell info)
            : base(caster, scroll, (Server.Spells.SpellInfo)info)
        {
            m_Style = info.style;
        }

        // Appelle la bonne fonction, dépendant du type de spell. La fonction appellée est virtual ici, et overridée dans les classes spécialisées.
        public override void OnCast()
        {
            switch (m_Style)
            {
                    // Targetted
                case (StyleSpell.Targetted): UseSpellTargetted();
                    break;

                    // TargettedTimer
                case    (StyleSpell.TargettedTimer) : UseSpellTargettedTimer();
                    break;

                    // AoE
                case (StyleSpell.AoE): UseSpellAoE();
                    break;

                    // AoETimer
                case (StyleSpell.AoETimer): UseSpellAoETimer();
                    break;

                    // Self
                case (StyleSpell.Self): UseSpellSelf();
                    break;

                    // SelfTimer
                case (StyleSpell.SelfTimer): UseSpellSelfTimer();
                    break;
            }
        }


        #region Fonctions virtual, utilisées par les classes spécialisées.
        public virtual void UseSpellTargetted()
        {
        }

        public virtual void UseSpellTargettedTimer()
        {
        }

        public virtual void UseSpellAoE()
        {
        }

        public virtual void UseSpellAoETimer()
        {
        }

        public virtual void UseSpellSelf()
        {
        }

        public virtual void UseSpellSelfTimer()
        {
        }
        #endregion


        // NON FONCTIONNEL.
        public abstract class CSpellTargetted : CustomSpell
        {
            private InfoSpell.Targetted m_info;

            public CSpellTargetted(Mobile caster, Item scroll, InfoSpell.Targetted info)
                : base(caster, scroll, (InfoSpell)info)
            {
                m_info = info;
            }

            public override void UseSpellTargetted()
            {
                // Partie gérée par la classe... - range, cast time, mana cost, etc.. etc..

                // Effect();
            }

            public abstract void Effect(Mobile caster, Mobile target);

        }


        // NON FONCTIONNEL.
        public abstract class CSpellTargettedTimer : CustomSpell
        {
            private InfoSpell.TargettedTimer m_info;

            public CSpellTargettedTimer(Mobile caster, Item scroll, InfoSpell.TargettedTimer info)
                : base(caster, scroll, (InfoSpell)info)
            {
                m_info = info;
            }

            public override void UseSpellTargettedTimer()
            {
                // Partie gérée par la classe... - range, cast time, mana cost, etc.. etc..

                // TIMER !

                Effect();

                //
            }

            public abstract void Effect();
        }


        // NON FONCTIONNEL.
        public abstract class CSpellAoE : CustomSpell
        {
            private InfoSpell.AoE m_info;

            public CSpellAoE(Mobile caster, Item scroll, InfoSpell.AoE info)
                : base(caster, scroll, (InfoSpell)info)
            {
                m_info = info;
            }

            public override void UseSpellAoE()
            {
                // Partie gérée par la classe... - range, cast time, mana cost, etc.. etc..

                Effect();

                //
            }

            public abstract void Effect();
        }


        // NON FONCTIONNEL.
        public abstract class CSpellAoETimer : CustomSpell
        {
            private InfoSpell.AoETimer m_info;

            public CSpellAoETimer(Mobile caster, Item scroll, InfoSpell.AoETimer info)
                : base(caster, scroll, (InfoSpell)info)
            {
                m_info = info;
            }

            public override void UseSpellAoETimer()
            {
                // Partie gérée par la classe... - range, cast time, mana cost, etc.. etc..

                // TIMER !

                Effect();

                //
            }

            public abstract void Effect();
        }


        // NON FONCTIONNEL.
        public abstract class CSpellSelf : CustomSpell
        {
            private InfoSpell.Self m_info;

            public CSpellSelf(Mobile caster, Item scroll, InfoSpell.Self info)
                : base(caster, scroll, (InfoSpell)info)
            {
                m_info = info;
            }

            public override void UseSpellSelf()
            {
                // Partie gérée par la classe... - range, cast time, mana cost, etc.. etc..

                // TIMER !

                Effect();

                //
            }

            public abstract void Effect();
        }


        // NON FONCTIONNEL.
        public abstract class CSpellSelfTimer : CustomSpell
        {
            private InfoSpell.SelfTimer m_info;

            public CSpellSelfTimer(Mobile caster, Item scroll, InfoSpell.SelfTimer info)
                : base(caster, scroll, (InfoSpell)info)
            {
                m_info = info;
            }

            public override void UseSpellSelfTimer()
            {
                // Partie gérée par la classe... - range, cast time, mana cost, etc.. etc..

                // TIMER !

                Effect();

                //
            }

            public abstract void Effect();
        }
    }
}
