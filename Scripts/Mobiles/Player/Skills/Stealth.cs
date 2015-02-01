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

        private static TimeSpan TempsJetReussit = TimeSpan.FromSeconds(0.0);
        private static TimeSpan TempsJetRate = TimeSpan.FromSeconds(10.0);
        private static TimeSpan TempsJetImposs = TimeSpan.FromSeconds(0.0); // Si le jet n'a pas pu être fait à cause d'une cause extérieure.

		public static void Initialize()
		{
			SkillInfo.Table[(int)SkillName.Infiltration].Callback = new SkillUseCallback( OnUse );
		}

        /*
        Coord 0 : x = 0 + skill        x = 100
        Coord 1 : x = -3 * 6 + skill   x = 82          y = -50
        Coord 2 : x = -4 * 6 + skill   x = 76          y = -20
        Coord 3 : x = -5 * 6 + skill   x = 70          y = 10
        Coord 4 : x = -6 * 6 + skill   x = 64          y = 40 
        Coord 5 : x = -7 * 6 + skill   x = 58          y = 70
        
        f(x) = -5x + 360
        */
        public static double ScalMalusArmure( Mobile m )
        {
            double dex = m.RawDex - m.Dex;
            double malus = 0;
            double val = 0;

            val = ((-5 * (m.Skills[SkillName.Infiltration].Value - dex)) + 360) / 100;

            if (val > 0)
            {
                malus = val;
            }

            return malus;
        }



		public static TimeSpan OnUse( Mobile m )
		{
			if ( !m.Hidden )
			{
                Hiding.OnUse(m);

                if (!m.Hidden) // Si le jet est raté.
                    return TempsJetRate;
                else
                    return OnUse(m);
			}
			else if( !m.CanBeginAction( typeof( Stealth ) ) )
			{
				m.SendLocalizedMessage( 1063086 ); // You cannot use this skill right now.
			}
            else
            {

                if (m.CheckSkill(SkillName.Infiltration, (m.Skills[SkillName.Infiltration].Value * (1 - ScalMalusArmure(m)) / 100)))
				{
                    int steps = (int)(m.Skills[SkillName.Infiltration].Value / Diviseur); // A 100, 20 steps, ou 4 steps en courrant.

                    // Malus de dex sur le nombre de pas possible.
                    int val = (int)(steps * (1 - ScalMalusArmure(m)));
                    if (val != steps)
                    {
                        steps = val;
                        m.SendMessage("Vous n'êtes pas assez agile pour vous déplacer efficacement avec cette armure.");
                    }

                    if (steps < 1)
                        steps = 1;

					m.AllowedStealthSteps = steps;

					m.SendLocalizedMessage( 502730 ); // You begin to move quietly.
                    return TempsJetReussit;
				}
				else
				{
					m.SendLocalizedMessage( 502731 ); // You fail in your attempt to move unnoticed.
					m.RevealingAction();
                    return TempsJetRate;
				}
			}

            return TempsJetImposs;
		}
	}
}