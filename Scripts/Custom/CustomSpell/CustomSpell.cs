using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
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

                case (StyleSpell.Unsetted): throw new Exception("StyleSpell non setté.");
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

            public object   target1 = null,
                            target2 = null, 
                            target3 = null;

            private bool target1rdy = false,
                         target2rdy = false,
                         target3rdy = false;

            // Permet de passer à travers la fonction Effect() à chaque fois qu'on click un target.
            public bool UnEffectParTarget = false;


            public CSpellTargetted(Mobile caster, Item scroll, InfoSpell.Targetted info)
                : base(caster, scroll, (InfoSpell)info)
            {
                m_info = info;
            }

            // Point d'entrée, lorsque l'on appelle un Spell.Cast();
            public override void UseSpellTargetted()
            {
                // Pré spell.

                Caster.Target = new InternalTarget(this, 1);
            }

            public override void OnCast()
            {base.OnCast();}

            // Appellé à chaque fois que l'utilisateur clique sur un target.
            private void OnNewTarget()
            {
                if (UnEffectParTarget)
                {
                    // Un effet à chaque target.
                    Effect();
                }
                else
                {
                    if (target1rdy && (target2rdy || m_info.nbTarget <= 1) && (target3rdy || m_info.nbTarget <= 2))
                    {
                        // Appelle l'effet seulement lorsque tous les targets demandés sont faits.
                        Effect();
                    }
                }

                // Si on veut plus de targets, on en créée un nouveau.
                if (target2 == null && m_info.nbTarget <= 2)
                {
                    Caster.Target = new InternalTarget(this, 2);
                }
                else if (target3 == null && m_info.nbTarget <= 3)
                {
                    Caster.Target = new InternalTarget(this, 3);
                }
                else
                {
                    m_Caster.SendMessage("Sequence Finie");
                    FinishSequence();
                }
            }


            // Doit être redéfinie par l'utilisateur de la classe.
            public abstract void Effect();


            // Créer un target et retourner l'objet dans le "target" spécifié par le int.
            private class InternalTarget : Target
            {
                private CSpellTargetted m_Owner;

                private int m_numeroTarget = 1;
                private int numeroTarget { get { return m_numeroTarget; } set { if (value <= 3 && value >= 1) m_numeroTarget = numeroTarget; } }

                public InternalTarget(CSpellTargetted owner, int NumeroTarget)
                    : base(owner.m_info.range, true, TargetFlags.None)
                {
                    numeroTarget = NumeroTarget;
                    m_Owner = owner;

                    switch (numeroTarget)
                    {
                        case 1: m_Owner.target1rdy = false;
                            break;
                        case 2: m_Owner.target2rdy = false;
                            break;
                        case 3: m_Owner.target3rdy = false;
                            break;
                    }
                }

                protected override void OnTarget(Mobile from, object o)
                {
                    switch (numeroTarget)
                    {
                        case 1: m_Owner.target1 = o;
                                m_Owner.target1rdy = true;
                            break;
                        case 2: m_Owner.target2 = o;
                                m_Owner.target2rdy = true;
                            break;
                        case 3: m_Owner.target3 = o;
                                m_Owner.target3rdy = true;
                            break;
                    }

                    m_Owner.OnNewTarget();
                }
            }

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
