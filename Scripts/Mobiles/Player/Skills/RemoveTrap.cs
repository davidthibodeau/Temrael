using System;
using Server.Targeting;
using Server.Items;
using Server.Network;


namespace Server.SkillHandlers
{
	public class RemoveTrap
	{
		public static void Initialize()
		{
			SkillInfo.Table[(int)SkillName.Pieges].Callback = new SkillUseCallback( OnUse );
		}

		public static TimeSpan OnUse( Mobile m )
		{
			m.Target = new InternalTarget();

			m.SendLocalizedMessage( 502368 ); // Which trap will you attempt to disarm?

			return TimeSpan.FromSeconds( 10.0 ); // 10 second delay before being able to re-use a skill
		}

		private class InternalTarget : Target
		{
			public InternalTarget() :  base ( 2, false, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is Mobile )
				{
					from.SendLocalizedMessage( 502816 ); // You feel that such an action would be inappropriate
				}
				else if ( targeted is IEntity )
				{
                    from.Direction = from.GetDirectionTo(((IEntity)targeted).Location);

                    if ( targeted is ITrapable )
                    {
                        ITrapable targ = (ITrapable)targeted;

                        if (! targ.Trap_IsTrapped)
					    {
						    from.SendLocalizedMessage( 502373 ); // That doesn't appear to be trapped
						    return;
					    }

					    from.PlaySound( 0x241 );

                        if (from.CheckTargetSkill(SkillName.Pieges, targ, targ.Trap_DisarmDifficulty, targ.Trap_DisarmDifficulty + 20))
					    {
                            targ.Trap_Disarm();
						    from.SendLocalizedMessage( 502377 ); // You successfully render the trap harmless
					    }
					    else
					    {
						    from.SendLocalizedMessage( 502372 ); // You fail to disarm the trap... but you don't set it off
					    }
                    }
				}
				else
				{
					from.SendLocalizedMessage( 502373 ); // That does'nt appear to be trapped
				}
			}
		}
	}
}