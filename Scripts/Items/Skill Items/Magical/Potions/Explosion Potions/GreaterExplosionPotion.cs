using System;
using Server;

namespace Server.Items
{
	public class GreaterExplosionPotion : BaseExplosionPotion
	{
		public override int MinDamage { get { return 35; } }
		public override int MaxDamage { get { return 45; } }

		[Constructable]
		public GreaterExplosionPotion() : base( PotionEffect.ExplosionGreater )
		{
            Name = "Grande potion explosive";
		}

		public GreaterExplosionPotion( Serial serial ) : base( serial )
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