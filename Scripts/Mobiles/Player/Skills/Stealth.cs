using System;
using Server.Items;
using Server.Mobiles;

namespace Server.SkillHandlers
{
	public class Stealth
	{
        private const double Diviseur = 5.0; // Nombre de pas = (SkillStealthValue) / Diviseur.
        public const int CoutPasMarche = 1;  // Le coût d'un pas lorsque l'on marche en étant stealth.
        public const int CoutPasCourse = 5;  // Le coût d'un pas lorsque l'on courre en étant stealth.

        private const double TempsJetReussit = 0.0;
        private const double TempsJetRate = 10.0;
        private const double TempsJetImposs = 0.0; // Si le jet n'a pas pu être fait à cause d'une cause extérieure.

		public static void Initialize()
		{
			SkillInfo.Table[(int)SkillName.Infiltration].Callback = new SkillUseCallback( OnUse );
		}

		public static TimeSpan OnUse( Mobile m )
		{
			if ( !m.Hidden )
			{
				m.SendLocalizedMessage( 502725 ); // You must hide first
			}
			else if( !m.CanBeginAction( typeof( Stealth ) ) )
			{
				m.SendLocalizedMessage( 1063086 ); // You cannot use this skill right now.
				m.RevealingAction();
			}
            else
            {
                if (m.CheckSkill(SkillName.Infiltration, 0, 100)  /*   BONUS OU MALUS ICI    */)
				{
                    int steps = (int)(m.Skills[SkillName.Infiltration].Value / Diviseur); // A 100, 20 steps, ou 5 steps en courrant.

					if( steps < 1 )
						steps = 1;

                    if (m.Dex < 20)
                    {
                        m.SendMessage("Vous n'êtes pas assez agile pour vous déplacer efficacement.");
                        steps = steps / 3;
                    }

					m.AllowedStealthSteps = steps;

					m.SendLocalizedMessage( 502730 ); // You begin to move quietly.
                    return TimeSpan.FromSeconds(TempsJetReussit);
				}
				else
				{
					m.SendLocalizedMessage( 502731 ); // You fail in your attempt to move unnoticed.
					m.RevealingAction();
                    return TimeSpan.FromSeconds(TempsJetRate);
				}
			}

            return TimeSpan.FromSeconds(TempsJetImposs);
		}
	}
}