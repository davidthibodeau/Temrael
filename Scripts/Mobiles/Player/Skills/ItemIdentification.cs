using System;
using Server;
using Server.Targeting;
using Server.Mobiles;
using Server.Gumps;
using Server.Engines.Alchimie;

namespace Server.Items
{
	public class ItemIdentification
	{
		public static void Initialize()
		{
			SkillInfo.Table[(int)SkillName.Fignolage].Callback = new SkillUseCallback( OnUse );
		}

		public static TimeSpan OnUse( Mobile from )
		{
			from.SendLocalizedMessage( 500343 ); // What do you wish to appraise and identify?
			from.Target = new InternalTarget();

			return TimeSpan.FromSeconds( 1.0 );
		}

		[PlayerVendorTarget]
		private class InternalTarget : Target
		{
			public InternalTarget() :  base ( 8, false, TargetFlags.None )
			{
				AllowNonlocal = true;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Item )
				{
					if ( from.CheckTargetSkill( SkillName.Fignolage, o, 0, 100 ) )
					{
                        if (o is BaseWeapon)
                            ((BaseWeapon)o).Identified = true;
                        else if (o is BaseArmor)
                            ((BaseArmor)o).Identified = true;
                        else if (o is BaseJewel)
                            ((BaseJewel)o).Identified = true;
                        else if (o is BaseClothing)
                            ((BaseClothing)o).Identified = true;
                        else if (o is BasePlant)
                        {
                            BasePlant plant = o as BasePlant;

                            from.SendGump(new PlantIdentificationGump(from, plant));
                        }
                        else if (o is BasePlantReagent)
                        {
                            BasePlantReagent reg = o as BasePlantReagent;

                            from.SendGump(new RegIdentificationGump(from, reg));
                        }
                        else if (o is Potion)
                        {
                            ((Potion)o).Identified = true;
                        }
                        else
                            from.SendMessage("Vous pouvez seulement identifier une arme, armure, bijou, vetement ou bouclier.");
						/*if ( !Core.AOS )
							((Item)o).OnSingleClick( from );*/
					}
					else
					{
						from.SendLocalizedMessage( 500353 ); // You are not certain...
					}
				}
				/*else if ( o is Mobile )
				{
					((Mobile)o).OnSingleClick( from );
				}*/
				else
				{
					from.SendLocalizedMessage( 500353 ); // You are not certain...
				}
			}
		}
	}
}