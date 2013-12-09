using System;
using Server;
using Server.Guilds;

namespace Server.Items
{
	public class OrderShield : BaseShield
	{
        public override int NiveauAttirail { get { return 3; } }

        public override int BasePhysicalResistance { get { return Bouclier_Def3; } }
        public override int BaseContondantResistance { get { return Resistances_Low0; } }
        public override int BaseTranchantResistance { get { return Resistances_Low0; } }
        public override int BasePerforantResistance { get { return Resistances_Inferior0; } }
        public override int BaseMagieResistance { get { return Resistances_Low0; } }

        public override int InitMinHits { get { return Bouclier_MinDurabilite3; } }
        public override int InitMaxHits { get { return Bouclier_MaxDurabilite3; } }

        public override int AosStrReq { get { return Bouclier_Force3; } }

		public override int ArmorBase{ get{ return 30; } }

		[Constructable]
		public OrderShield() : base( 0x1BC4 )
		{
			if ( !Core.AOS )
				LootType = LootType.Newbied;

			Weight = 7.0;
		}

		public OrderShield( Serial serial ) : base(serial)
		{
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( Weight == 6.0 )
				Weight = 7.0;
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
			if ( Core.AOS || m == null || !m.Player || m.AccessLevel != AccessLevel.Player )
				return true;

			Guild g = m.Guild as Guild;

			if ( g == null || g.Type != GuildType.Order )
			{
				m.FixedEffect( 0x3728, 10, 13 );
				Delete();

				return false;
			}

			return true;
		}
	}
}