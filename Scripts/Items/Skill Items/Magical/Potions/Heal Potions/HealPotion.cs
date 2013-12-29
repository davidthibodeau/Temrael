using System;
using Server;

namespace Server.Items
{
	public class HealPotion : BaseHealPotion
	{
		public override int MinHeal { get { return 40; } }
		public override int MaxHeal { get { return 75; } }
		public override double Delay{ get{ return 7.5; } }

		[Constructable]
		public HealPotion() : base( PotionEffect.Heal )
		{
            Name = "Potion de soins";
		}

		public HealPotion( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}