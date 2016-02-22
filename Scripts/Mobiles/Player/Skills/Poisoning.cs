using System;
using Server.Targeting;
using Server.Items;
using Server.Network;
using Server.Engines.Alchimie;
using Server.Mobiles;

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

			return TimeSpan.FromSeconds( 10.0 ); // 10 second delay before being able to re-use a skill
		}

		private class InternalTargetPoison : Target
		{
			public InternalTargetPoison() :  base ( 2, false, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
                // Application de poison à un item.
				if ( targeted is Potion )
				{
					from.SendMessage("Quel objet voulez vous empoisonner?");
                    from.Target = new InternalTarget((Potion)targeted);
				}
                // Jet de tasteID.
                else if (targeted is Food)
                {
                    TasteID(from, (Food)targeted);
                }
                // Not a poison potion.
                else if (targeted is BaseBeverage)
                {
                    TasteID(from, (BaseBeverage)targeted);
                }
                else
                {
                    from.SendMessage("Ceci n'est pas une potion de poison."); // That is not a poison potion.
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

            void TasteID(Mobile from, BaseBeverage drink)
            {
                if (from.CheckTargetSkill(SkillName.Empoisonnement, drink, 0, 100))
                {
                    if (drink.Poison != null)
                    {
                        drink.SendLocalizedMessageTo(from, 1038284); // It appears to have poison smeared on it.
                    }
                    else
                    {
                        // No poison on the food
                        drink.SendLocalizedMessageTo(from, 1010600); // You detect nothing unusual about this substance.
                    }
                }
                else
                {
                    // Skill check failed
                    drink.SendLocalizedMessageTo(from, 502823); // You cannot discern anything about this substance.
                }
            }

			private class InternalTarget : Target
			{
                private Potion m_Potion;

                public InternalTarget(Potion potion)
                    : base(2, false, TargetFlags.None)
				{
					m_Potion = potion;
				}

				protected override void OnTarget( Mobile from, object targeted )
				{
					if ( m_Potion.Deleted )
						return;

					bool startTimer = false;

                    if (targeted is BaseWeapon || targeted is Food || targeted is BaseBeverage)
                    {
						new InternalTimer( from, (Item)targeted, m_Potion ).Start();

                        from.PlaySound(Utility.RandomList(0x30, 0x2D6));
                        from.AddToBackpack(new Bottle());
					}
					else // Target can't be poisoned
					{
                        from.SendMessage("Vous ne pouvez pas empoisonner ceci.");
					}
				}

				private class InternalTimer : Timer
				{
					private Mobile m_From;
					private Item m_Target;
                    private Potion m_Potion;

                    public InternalTimer(Mobile from, Item target, Potion potion)
                        : base(TimeSpan.FromSeconds(2.0))
					{
						m_From = from;
						m_Target = target;
                        m_Potion = potion;
						Priority = TimerPriority.TwoFiftyMS;
					}

					protected override void OnTick()
					{
                        if (m_From.CheckTargetSkill(SkillName.Empoisonnement, m_Target, m_Potion.Pot.MinSkill, m_Potion.Pot.MinSkill))
						{
							if ( m_Target is Food )
							{
                                ((Food)m_Target).Poison = new FoodPotion(m_Potion);
							}
                            else if (m_Target is BaseBeverage)
                            {
                                ((BaseBeverage)m_Target).Poison = new BeveragePotion(m_Potion);
                            }
                            else if (m_Target is BaseWeapon)
                            {
                                ((BaseWeapon)m_Target).Poison = new WeaponPotion(m_Potion);
                                ((BaseWeapon)m_Target).PoisonCharges = 20;
                            }

							m_From.SendLocalizedMessage( 1010517 ); // You apply the poison
						}
						else // Failed
						{
							// 5% of chance of getting poisoned if failed
							if ( m_From.Skills[SkillName.Empoisonnement].Base < 80.0 && Utility.Random( 20 ) == 0 )
							{
								m_From.SendLocalizedMessage( 502148 ); // You make a grave mistake while applying the poison.
                                m_Potion.Pot.DoAllEffects((ScriptMobile)m_From, 1);
							}
							else
							{
								if ( m_Target is BaseWeapon )
								{
									BaseWeapon weapon = (BaseWeapon)m_Target;

                                    m_From.SendLocalizedMessage(1010518); // You fail to apply a sufficient dose of poison
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