using System;
using Server;
using Server.Mobiles;
using Server.Targeting;
using Server.Items;

namespace Server.Engines.Craft
{
	public class Repair
	{
		public Repair()
		{
		}

		public static void Do( Mobile from, CraftSystem craftSystem, BaseTool tool )
		{
			from.Target = new InternalTarget( craftSystem, tool );
			from.SendLocalizedMessage( 1044276 ); // Target an item to repair.
		}

		public static void Do( Mobile from, CraftSystem craftSystem, RepairDeed deed )
		{
			from.Target = new InternalTarget( craftSystem, deed );
			from.SendLocalizedMessage( 1044276 ); // Target an item to repair.
		}

		private class InternalTarget : Target
		{
			private CraftSystem m_CraftSystem;
			private BaseTool m_Tool;
			private RepairDeed m_Deed;

			public InternalTarget( CraftSystem craftSystem, BaseTool tool ) :  base ( 2, false, TargetFlags.None )
			{
				m_CraftSystem = craftSystem;
				m_Tool = tool;
			}

			public InternalTarget( CraftSystem craftSystem, RepairDeed deed ) : base( 2, false, TargetFlags.None )
			{
				m_CraftSystem = craftSystem;
				m_Deed = deed;
			}

			protected override void OnTarget( Mobile mob, object targeted )
			{
                if (targeted is BaseWeapon)
                {
                    BaseWeapon weapon = (BaseWeapon)targeted;

                    Type t = CraftResources.GetTypeFromCraftResource(weapon.Resource);

                    if (t != null)
                    {
                        Item i = mob.Backpack.FindItemByType(t);
                        if (i != null)
                        {
                            int RequiredResAmount = (weapon.MaxDurability - weapon.Durability) / 25;
                            if (i.Amount > RequiredResAmount)
                            {
                                if (0.5 > Utility.RandomDouble())
                                {
                                    weapon.MaxDurability = (int)(weapon.MaxDurability * 0.95);
                                }

                                weapon.Durability = weapon.MaxDurability;

                                i.Consume(RequiredResAmount);
                            }
                            else
                            {
                                mob.SendMessage("Vous ne possédez pas assez de ressources pour réparer l'arme.");
                            }
                        }
                    }
                }
                else if (targeted is BaseArmor)
                {
                    BaseArmor armor = (BaseArmor)targeted;

                    Type t = CraftResources.GetTypeFromCraftResource(armor.Resource);

                    if(t != null)
                    {
                        Item i = mob.Backpack.FindItemByType(t);
                        if (i != null)
                        {
                            int RequiredResAmount = (armor.MaxDurability - armor.Durability) / 25;
                            if (i.Amount > RequiredResAmount)
                            {
                                if (0.5 > Utility.RandomDouble())
                                {
                                    armor.MaxDurability = (int)(armor.MaxDurability * 0.85);
                                }

                                armor.Durability = armor.MaxDurability;

                                i.Consume(RequiredResAmount);
                            }
                            else
                            {
                                mob.SendMessage("Vous ne possédez pas assez de ressources pour réparer l'armure.");
                            }
                        }
                    }
                }
			}
		}
	}
}