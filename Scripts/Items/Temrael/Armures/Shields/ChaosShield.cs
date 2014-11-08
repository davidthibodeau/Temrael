using System;
using Server;
using Server.Guilds;

namespace Server.Items
{
	public class ChaosShield : BaseShield
	{
        //public override int NiveauAttirail { get { return 2; } }

        public override double BasePhysicalResistance { get { return ShldChaos.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ShldChaos.resistance_Magique; } }

        public override int InitMinHits { get { return ShldChaos. min_Durabilite; } }
        public override int InitMaxHits { get { return ShldChaos.max_Durabilite; } }

        public override int BaseStrReq { get { return ShldChaos.force_Requise; } }
        public override int BaseDexBonus { get { return ShldChaos.malus_Dex; } }

		[Constructable]
		public ChaosShield() : base( 0x1BC3 )
		{
			Weight = 5.0;
            Name = "Bouclier du Chaos";
		}

		public ChaosShield( Serial serial ) : base(serial)
		{
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );//version
		}

		public override bool OnEquip( Mobile from )
		{
			return Validate( from ) && base.OnEquip( from );
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( Validate( Parent as Mobile ) )
				base.OnSingleClick( from );
		}

		public virtual bool Validate( Mobile m )
		{
			if ( m == null || !m.Player || m.AccessLevel != AccessLevel.Player || Core.AOS )
				return true;

			Guild g = m.Guild as Guild;

			if ( g == null || g.Type != GuildType.Chaos )
			{
				m.FixedEffect( 0x3728, 10, 13 );
				Delete();

				return false;
			}

			return true;
		}
	}
}