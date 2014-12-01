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
                m.CheckSkill(SkillName.Infiltration, m.Skills[SkillName.Infiltration].Value);

                // Malus de dex sur les chances de reussite.
                int malusDex = 0;
                int dex = m.RawDex - m.Dex; // Malus de dex de toutes les armures.
                if ((m.Skills[SkillName.Infiltration].Value / 2) - dex < 20 && dex != 0)
                {
                    malusDex = (int)((m.Skills[SkillName.Infiltration].Value / 2) - dex - 20) * 3; // -15% pour cap 4. -30% pour cap 5.
                }

                if (m.CheckSkill(SkillName.Infiltration, m.Skills[SkillName.Infiltration].Value - malusDex))
				{
                    int steps = (int)(m.Skills[SkillName.Infiltration].Value / Diviseur); // A 100, 20 steps, ou 4 steps en courrant.

                    // Malus de dex sur le nombre de pas possible.
                    if (malusDex != 0)
                    {
                        m.SendMessage("Vous n'êtes pas assez agile pour vous déplacer efficacement avec cette armure.");
                        steps = steps - steps * (-malusDex) * 4 / 100;
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