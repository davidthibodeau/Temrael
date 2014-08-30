using System;
using System.Collections;
using Server.Mobiles;
using Server.Items;

namespace Server.TechniquesCombat
{
    public class AttackSpeed
    {

        // Ressources
        private PlayerMobile m_Caster;
        public AttackSpeed(PlayerMobile caster)
        {
            m_Caster = caster;
            Use();
        }


        // Modifiables.
        private int m_ManaCost = 10;
        private const float m_MultiplicateurSpeed = 5f;


        TimeSpan CalculDuree()
        {
            int Hours = 0;
            int Minutes = 0;
            int Seconds = 0;

            // Insert formula here...
            Seconds = 20;

            return new TimeSpan(Hours, Minutes, Seconds);
        }


        private void Use()
        {
            if ((!m_Caster.Deleted && m_Caster.Alive))
            {
                if (m_Caster.Mana >= m_ManaCost)
                {
                    m_Caster.Mana -= m_ManaCost;
                    BonusTimer m_TimerDuration = new BonusTimer(CalculDuree(), m_Caster);
                }
                else
                {
                    m_Caster.SendMessage("Vous n'avez pas assez de mana pour utiliser cette technique !");
                }
            }
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Timer qui ajoute un bonus, puis le retire quand le temps est écoulé.
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private class BonusTimer : Timer
        {
            private PlayerMobile m_Caster;
            private BaseWeapon m_Weapon;




            private void AjoutBonus()
            {
                m_Weapon.Speed = m_Weapon.Speed / m_MultiplicateurSpeed;
            }


            private void RetraitBonus()
            {
                m_Weapon.Speed = m_Weapon.Speed * m_MultiplicateurSpeed;
            }


            public BonusTimer(TimeSpan duration, PlayerMobile caster)
                : base(duration)
            {
                m_Caster = caster;
                m_Weapon = (BaseWeapon)caster.Weapon;

                Priority = TimerPriority.TwoFiftyMS;

                CommencerTechnique();
            }

            // Pas touche ---v

            private bool DetruitCorrectement;

            public void CommencerTechnique()
            {
                AjoutBonus();
                DetruitCorrectement = false;
                Start();
            }

            protected override void OnTick()
            {
                RetraitBonus();
                DetruitCorrectement = true;
                Stop();
            }

            ~BonusTimer()
            {
                if (DetruitCorrectement == false)
                {
                    RetraitBonus();
                }
            }
        }
    }
}
