using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Spells.TechniquesCombat
{
    // Permet au lanceur de la technique de prendre les coups à la place du
    // mobile visé pendant 10 secondes, tant qu'il reste à une case de distance.
    // 70% de chances de reussir à prendre le coup.

    class ProtectionTechnique : BaseTechnique
    {
        #region Membres / consts.

        private const int DureeSecs = 15;

        private static int ManaCost { get { return 30; } }

        private static Hashtable MobilesList; // Protecteur -- Protégé.

        #endregion

        #region Ctor
        public ProtectionTechnique(Mobile def)
        {
            if (MobilesList == null)
                MobilesList = new Hashtable();

            def.Target = new InternalTarget(this, 10);
            def.SendMessage("Choisissez la personne que vous voulez protéger !");
        }
        #endregion

        #region Methodes, ss-classe InternalTarget

        public void Target(Mobile def, Mobile target)
        {
            if (!MobilesList.ContainsKey(def))
            {
                if (CheckMana(def, ManaCost))
                {
                    MobilesList.Add(def, target);
                    def.SendMessage("Vous protégez " + target.GetNameUsedBy(def));
                    target.SendMessage("Vous êtes protégé par " + target.GetNameUsedBy(def));
                    new InternalTimer(def, TimeSpan.FromSeconds(DureeSecs));
                }
            }
        }

        public static Mobile GetOnHitEffect(Mobile protege)
        {
            bool blocked = false;
            Mobile retour = protege;

            if (MobilesList != null)
            {
                foreach (DictionaryEntry pair in MobilesList)
                {
                    if (pair.Value == protege)
                    {
                        if (CheckProtection((Mobile)pair.Key, protege))
                        {
                            retour = (Mobile)pair.Key;
                            break;
                        }
                    }
                }
            }

            return retour;
        }

        private static bool CheckProtection(Mobile protecteur, Mobile protege)
        {
            if(Utility.RandomDouble() <= protecteur.Skills[SkillName.Parer].Base / 100 * 0.7 && protecteur.InRange(protege.Location, 1))
            {
                return true;
            }
            return false;
        }

        private class InternalTarget : Target
        {
            private ProtectionTechnique m_Owner;

            public InternalTarget(ProtectionTechnique owner, int range)
                : base(range, false, TargetFlags.Beneficial)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile)
                {
                    m_Owner.Target(from, (Mobile)o);
                }
            }

            protected override void OnTargetFinish(Mobile from)
            {
            }
        }

        private class InternalTimer : Timer
        {
            Mobile m_mob;

            public InternalTimer(Mobile mob, TimeSpan duration)
                : base(duration)
            {
                m_mob = mob;
                Start();
            }

            protected override void OnTick()
            {
                MobilesList.Remove(m_mob);
                Stop();
            }
        }

        #endregion
    }
}
