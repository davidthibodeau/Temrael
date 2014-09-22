using System;
using Server.Targeting;
using Server.Items;
using Server.Network;

namespace Server.SkillHandlers
{
	public class Poisoning
	{
		public static void Initialize()
		{
			SkillInfo.Table[(int)SkillName.Empoisonnement].Callback = new SkillUseCallback( OnUse );
		}

		public static TimeSpan OnUse( Mobile m )
		{
			m.Target = new InternalTargetPoison();

			m.SendMessage("Sélectionnez votre poison, ou la nourriture à identifier.");

			return TimeSpan.FromSeconds( 10.0 ); // 10 second delay before beign able to re-use a skill
		}

		private class InternalTargetPoison : Target
		{
			public InternalTargetPoison() :  base ( 2, false, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
                // Application de poison à un item.
				if ( targeted is BasePoisonPotion )
				{
					from.SendMessage("Quel objet voulez vous empoisonner?");
					from.Target = new InternalTarget( (BasePoisonPotion)targeted );
				}
                // Jet de tasteID.
                else if (targeted is Food)
                {
                    TasteID(from, (Food)targeted);
                }
                // Not a poison potion.
                else
				{
                    from.SendMessage("Ceci n'est pas une potion de poison.") ; // That is not a poison potion.
				}
			}

            void TasteID(Mobile from, Food food)
            {
                if (from.CheckTargetSkill(SkillName.Empoisonnement, food, 0, 100))
                {
                    if (food.Poison != null)
                    {
                        food.SendLocalizedMessageTo(from, 1038284); // It appears to have poison smeared on it.
                    }
                    else
                    {
                        // No poison on the food
                        food.SendLocalizedMessageTo(from, 1010600); // You detect nothing unusual about this substance.
                    }
                }
                else
                {
                    // Skill check failed
                    food.SendLocalizedMessageTo(from, 502823); // You cannot discern anything about this substance.
                }
            }

			private class InternalTarget : Target
			{
				private BasePoisonPotion m_Potion;

				public InternalTarget( BasePoisonPotion potion ) :  base ( 2, false, TargetFlags.None )
				{
					m_Potion = potion;
				}

				protected override void OnTarget( Mobile from, object targeted )
				{
					if ( m_Potion.Deleted )
						return;

					bool startTimer = false;

					if ( targeted is BaseWeapon )
					{
						BaseWeapon weapon = (BaseWeapon)targeted;

						if ( weapon.Layer == Layer.OneHanded )
						{
							// Only Bladed or Piercing weapon can be poisoned
							startTimer = ( /*weapon.Type == WeaponType.Slashing ||*/ weapon.Type == WeaponType.Piercing );
						}
					}
                    else if ( targeted is Food)
                    {
                        startTimer = true;
                    }


					if ( startTimer )
					{
						new InternalTimer( from, (Item)targeted, m_Potion ).Start();

						from.PlaySound( 0x4F );

						m_Potion.Consume();
						from.AddToBackpack( new Bottle() );
					}
					else // Target can't be poisoned
					{
                        from.SendMessage("Vous ne pouvez pas empoisonner celà ! Vous pouvez seulement empoisonner les dagues ou la nourriture.");
					}
				}

				private class InternalTimer : Timer
				{
					private Mobile m_From;
					private Item m_Target;
					private Poison m_Poison;
					private double m_MinSkill, m_MaxSkill;

					public InternalTimer( Mobile from, Item target, BasePoisonPotion potion ) : base( TimeSpan.FromSeconds( 2.0 ) )
					{
						m_From = from;
						m_Target = target;
						m_Poison = potion.Poison;
						m_MinSkill = potion.MinPoisoningSkill;
						m_MaxSkill = potion.MaxPoisoningSkill;
						Priority = TimerPriority.TwoFiftyMS;
					}

					protected override void OnTick()
					{
						if ( m_From.CheckTargetSkill( SkillName.Empoisonnement, m_Target, m_MinSkill, m_MaxSkill ) )
						{
							if ( m_Target is Food )
							{
								((Food)m_Target).Poison = m_Poison;
							}
							else if ( m_Target is BaseWeapon )
							{
								((BaseWeapon)m_Target).Poison = m_Poison;
								((BaseWeapon)m_Target).PoisonCharges = 18 - (m_Poison.Level * 2);
							}

							m_From.SendLocalizedMessage( 1010517 ); // You apply the poison
						}
						else // Failed
						{
							// 5% of chance of getting poisoned if failed
							if ( m_From.Skills[SkillName.Empoisonnement].Base < 80.0 && Utility.Random( 20 ) == 0 )
							{
								m_From.SendLocalizedMessage( 502148 ); // You make a grave mistake while applying the poison.
								m_From.ApplyPoison( m_From, m_Poison );
							}
							else
							{
								if ( m_Target is BaseWeapon )
								{
									BaseWeapon weapon = (BaseWeapon)m_Target;

									if ( weapon.Type == WeaponType.Slashing )
										m_From.SendLocalizedMessage( 1010516 ); // You fail to apply a sufficient dose of poison on the blade
									else
										m_From.SendLocalizedMessage( 1010518 ); // You fail to apply a sufficient dose of poison
								}
								else
								{
									m_From.SendLocalizedMessage( 1010518 ); // You fail to apply a sufficient dose of poison
								}
							}
						}
					}
				}
			}
		}
	}
}