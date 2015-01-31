using System;
using System.Collections;
using Server;
using Server.Network;

namespace Server.Items
{
	public class BaseShield : BaseArmor
	{
		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		public BaseShield( int itemID ) : base( itemID )
		{
		}

		public BaseShield( Serial serial ) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

            writer.Write((int)0); //version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override int OnHit( BaseWeapon weapon, int damage )
		{
			if( Core.AOS )
			{
                double halfArmor = ResistanceBonus(BasePhysicalResistance) / 2.0;
				int absorbed = (int)(halfArmor + (halfArmor*Utility.RandomDouble()));

				if( absorbed < 2 )
					absorbed = 2;

				int wear;

				if( weapon.Type == WeaponType.Bashing )
					wear = (absorbed / 2);
				else
					wear = Utility.Random( 2 );

				if( wear > 0 && MaxDurability > 0 )
				{
					if( Durability >= wear )
					{
						Durability -= wear;
						wear = 0;
					}
					else
					{
						wear -= Durability;
						Durability = 0;
					}

					if( wear > 0 )
					{
						if( MaxDurability > wear )
						{
							MaxDurability -= wear;

							if( Parent is Mobile )
								((Mobile)Parent).LocalOverheadMessage( MessageType.Regular, 0x3B2, 1061121 ); // Your equipment is severely damaged.
						}
						else
						{
							Delete();
						}
					}
				}

				return 0;
			}
			else
			{
				Mobile owner = this.Parent as Mobile;
				if( owner == null )
					return damage;

                double ar = this.ResistanceBonus(BasePhysicalResistance);
				double chance = (owner.Skills[SkillName.Parer].Value - (ar * 2.0)) / 100.0;

				if( chance < 0.01 )
					chance = 0.01;
				/*
				FORMULA: Displayed AR = ((Parrying Skill * Base AR of Shield) ÷ 200) + 1 

				FORMULA: % Chance of Blocking = parry skill - (shieldAR * 2)

				FORMULA: Melee Damage Absorbed = (AR of Shield) / 2 | Archery Damage Absorbed = AR of Shield 
				*/
				if( owner.CheckSkill( SkillName.Parer, chance ) )
				{
					if( weapon.Skill == SkillName.ArmeDistance )
						damage -= (int)ar;
					else
						damage -= (int)(ar / 2.0);

					if( damage < 0 )
						damage = 0;

					Effects.SendTargetEffect(owner, 0x37B9, 10, 16 );

					if( 25 > Utility.Random( 100 ) ) // 25% chance to lower durability
					{
						int wear = Utility.Random( 2 );

						if( wear > 0 && MaxDurability > 0 )
						{
							if( Durability >= wear )
							{
								Durability -= wear;
								wear = 0;
							}
							else
							{
								wear -= Durability;
								Durability = 0;
							}

							if( wear > 0 )
							{
								if( MaxDurability > wear )
								{
									MaxDurability -= wear;

									if( Parent is Mobile )
										((Mobile)Parent).LocalOverheadMessage( MessageType.Regular, 0x3B2, 1061121 ); // Your equipment is severely damaged.
								}
								else
								{
									Delete();
								}
							}
						}
					}
				}

				return damage;
			}
		}
	}
}
