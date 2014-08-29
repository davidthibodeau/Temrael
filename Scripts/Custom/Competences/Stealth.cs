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

        //int Huehue = Server.Items.BaseArmor.DexMalusTotal; --- Test pour la future intégration des malus de Dex dans le calcul des chances de Stealth.

		public static int[,] ArmorTable{ get { return m_ArmorTable; } }
		private static int[,] m_ArmorTable = new int[,]
			{
							//	Gorget	Gloves	Helmet	Arms	Legs	Chest	Shield
				/* Cloth	*/	{ 0,	0,		0,		0,		0,		0,		0 },
				/* Leather	*/	{ 0,	0,		0,		0,		0,		0,		0 },
				/* Studded	*/	{ 2,	2,		0,		4,		6,		10,		0 },
				/* Bone		*/ 	{ 0,	5,		10,		10,		15,		25,		0 },
				/* Spined	*/	{ 0,	0,		0,		0,		0,		0,		0 },
				/* Horned	*/	{ 0,	0,		0,		0,		0,		0,		0 },
				/* Barbed	*/	{ 0,	0,		0,		0,		0,		0,		0 },
				/* Ring		*/	{ 0,	5,		0,		10,		15,		25,		0 },
				/* Chain	*/	{ 0,	0,		10,		0,		15,		25,		0 },
				/* Plate	*/	{ 5,	5,		10,		10,		15,		25,		0 },
				/* Dragon	*/	{ 0,	5,		10,		10,		15,		25,		0 }
			};

		public static int GetArmorRating( Mobile m )
		{
			if( !Core.AOS )
				return (int)m.ArmorRating;
            
			int ar = 0;

			for( int i = 0; i < m.Items.Count; i++ )
			{
				BaseArmor armor = m.Items[i] as BaseArmor;

				if( armor == null )
					continue;

				int materialType = (int)armor.MaterialType;
				int bodyPosition = (int)armor.BodyPosition;

				if( materialType >= m_ArmorTable.GetLength( 0 ) || bodyPosition >= m_ArmorTable.GetLength( 1 ) )
					continue;

				if( armor.ArmorAttributes.MageArmor == 0 )
					ar += m_ArmorTable[materialType, bodyPosition];
			}

			return ar;
		}

		public static TimeSpan OnUse( Mobile m )
		{
			if ( !m.Hidden )
			{
				m.SendLocalizedMessage( 502725 ); // You must hide first
			}
			/*else if ( m.Skills[SkillName.Discretion].Base < ((Core.ML) ? 30.0 : (Core.SE) ? 50.0 : 80.0) )
			{
				m.SendLocalizedMessage( 502726 ); // You are not hidden well enough.  Become better at hiding.
				m.RevealingAction();
			}*/
			else if( !m.CanBeginAction( typeof( Stealth ) ) )
			{
				m.SendLocalizedMessage( 1063086 ); // You cannot use this skill right now.
				m.RevealingAction();
			}
			else
			{
				int armorRating = GetArmorRating( m );
                // CALCUL DU BONUSMALUS ICI.

				if( armorRating >= (Core.AOS ? 42 : 26) )   // TEST POUR VOIR SI L'ARMURE EST TROP LOURDE.
				{
					m.SendLocalizedMessage( 502727 ); // You could not hope to move quietly wearing this much armor.
					m.RevealingAction();
				}

                else if (m.CheckSkill(SkillName.Infiltration, 0, 40)  /*   BONUS OU MALUS ICI    */)
				{
                    int steps = (int)(m.Skills[SkillName.Infiltration].Value / Diviseur); // A 100, 20 steps, ou 5 steps en courrant.

					if( steps < 1 )
						steps = 1;

                    if (m is TMobile)
                        steps += (int)((TMobile)m).GetAptitudeValue(Aptitude.MouvementCache) * 2;

					m.AllowedStealthSteps = steps;

					PlayerMobile pm = m as PlayerMobile; // IsStealthing should be moved to Server.Mobiles

					if( pm != null )
    						pm.IsStealthing = true;

					m.SendLocalizedMessage( 502730 ); // You begin to move quietly.
                    return TimeSpan.FromSeconds(TempsJetReussit); // Si le stealth a fonctionné.
				}
				else
				{
					m.SendLocalizedMessage( 502731 ); // You fail in your attempt to move unnoticed.
					m.RevealingAction();
                    return TimeSpan.FromSeconds(TempsJetRate); // Si le jet de stealth a raté.
				}
			}
            return TimeSpan.FromSeconds(TempsJetImposs);
		}
	}
}