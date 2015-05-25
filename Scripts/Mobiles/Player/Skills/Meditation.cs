using System;
using Server.Items;
using Server.Mobiles;
using Server.Engines.BuffHandling;

namespace Server.SkillHandlers
{
	class Meditation
	{
		public static void Initialize()
		{
			SkillInfo.Table[(int)SkillName.Meditation].Callback = new SkillUseCallback( OnUse );
		}

		public static TimeSpan OnUse( Mobile m )
		{
			m.RevealingAction();

			if ( m.Mana >= m.ManaMax )
			{
				m.SendLocalizedMessage( 501846 ); // You are at peace.
			}
			else
			{
                if (m.CheckSkill(SkillName.Meditation, 0.0, 100.0))
				{
					m.SendLocalizedMessage( 501851 ); // You enter a meditative trance.
					m.Meditating = true;
					BuffInfo.AddBuff( m, new BuffInfo( BuffIcon.ActiveMeditation, 1075657 ) );

					if ( m.Player || m.Body.IsHuman )
						m.PlaySound( 0xF9 );
				}
				else 
				{
					m.SendLocalizedMessage( 501850 ); // You cannot focus your concentration.
				}
			}

            return TimeSpan.FromSeconds(10.0);
		}
	}
}