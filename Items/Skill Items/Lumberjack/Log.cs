using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1bdd, 0x1be0 )]
	public abstract class BaseLog : Item, ICommodity, IAxe
	{
		private CraftResource m_Resource;

		[CommandProperty( AccessLevel.GameMaster )]
		public CraftResource Resource
		{
			get { return m_Resource; }
			set { m_Resource = value; InvalidateProperties(); }
		}

		int ICommodity.DescriptionNumber { get { return CraftResources.IsStandard( m_Resource ) ? LabelNumber : 1075062 + ( (int)m_Resource - (int)CraftResource.RegularWood ); } }
		bool ICommodity.IsDeedable { get { return true; } }
		//[Constructable]
		public BaseLog() : this( 1 )
		{
		}

		//[Constructable]
		public BaseLog( int amount ) : this( CraftResource.RegularWood, amount )
		{
		}

		//[Constructable]
		public BaseLog( CraftResource resource )
			: this( resource, 1 )
		{
		}
		//[Constructable]
		public BaseLog( CraftResource resource, int amount )
			: base( 0x1BDD )
		{
			Stackable = true;
			Weight = 2.0;
			Amount = amount;

			m_Resource = resource;
			Hue = CraftResources.GetHue( resource );
		}

        public static string[] m_Material = new string[]
            {
		        "Érable",
		        "Pin",
                "Cyprès",
                "Cèdre",
                "Saule",
                "Chêne",
                "Ébène",
                "Acajou",
            };

        public virtual string GetMaterial()
        {
            string value = "aucun";

            try
            {
                value = m_Material[((int)m_Resource) - 301];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return value;
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("<h3><basefont color=#FFFFFF>{3} {0}{1}{2}</h3></basefont>", "Bûche(s) [", GetMaterial(), "]", Amount);
        }

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			/*if ( !CraftResources.IsStandard( m_Resource ) )
			{
				int num = CraftResources.GetLocalizationNumber( m_Resource );

				if ( num > 0 )
					list.Add( num );
				else
					list.Add( CraftResources.GetName( m_Resource ) );
			}*/
		}
        public BaseLog(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			writer.Write( (int)m_Resource );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
					{
						m_Resource = (CraftResource)reader.ReadInt();
						break;
					}
			}

			if ( version == 0 )
				m_Resource = CraftResource.RegularWood;
		}

		public virtual bool TryCreateBoards( Mobile from, double skill, Item item )
		{
			if ( Deleted || !from.CanSee( this ) ) 
				return false;
			else if ( from.Skills.Menuiserie.Value < skill &&
				from.Skills.Foresterie.Value < skill )
			{
				item.Delete();
				from.SendLocalizedMessage( 1072652 ); // You cannot work this strange and unusual wood.
				return false;
			}
			base.ScissorHelper( from, item, 1, false );
			return true;
		}

		public virtual bool Axe( Mobile from, BaseAxe axe )
		{
			if ( !TryCreateBoards( from , 0, new Board() ) )
				return false;
			
			return true;
		}
	}

    public class Log : BaseLog
    {
        [Constructable]
        public Log()
            : this(1)
        {
        }
        [Constructable]
        public Log(int amount)
            : base(CraftResource.RegularWood, amount)
        {
        }
        public Log(Serial serial)
            : base(serial)
        {
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override bool Axe(Mobile from, BaseAxe axe)
        {
            if (!TryCreateBoards(from, 100, new Board()))
                return false;

            return true;
        }
    }

	public class PinLog : BaseLog
	{
		[Constructable]
		public PinLog() : this( 1 )
		{
		}
		[Constructable]
		public PinLog( int amount ) 
			: base( CraftResource.PinWood, amount )
		{
		}
        public PinLog(Serial serial)
            : base(serial)
		{
		}
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override bool Axe( Mobile from, BaseAxe axe )
		{
			if ( !TryCreateBoards( from , 100, new PinBoard() ) )
				return false;

			return true;
		}
	}

	public class CypresLog : BaseLog
	{
		[Constructable]
		public CypresLog()
			: this( 1 )
		{
		}
		[Constructable]
		public CypresLog( int amount )
			: base( CraftResource.CyprèsWood, amount )
		{
		}
        public CypresLog(Serial serial)
			: base( serial )
		{
		}
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override bool Axe( Mobile from, BaseAxe axe )
		{
			if ( !TryCreateBoards( from , 100, new CypresBoard() ) )
				return false;

			return true;
		}
	}

	public class CedreLog : BaseLog
	{
		[Constructable]
		public CedreLog()
			: this( 1 )
		{
		}

		[Constructable]
		public CedreLog( int amount )
			: base( CraftResource.CèdreWood, amount )
		{
		}

        public CedreLog(Serial serial)
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override bool Axe( Mobile from, BaseAxe axe )
		{
			if ( !TryCreateBoards( from , 100, new CedreBoard() ) )
				return false;

			return true;
		}
	}

	public class SauleLog : BaseLog
	{
		[Constructable]
		public SauleLog()
			: this( 1 )
		{
		}

		[Constructable]
		public SauleLog( int amount )
			: base( CraftResource.SauleWood, amount )
		{
		}

        public SauleLog(Serial serial)
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override bool Axe( Mobile from, BaseAxe axe )
		{
			if ( !TryCreateBoards( from , 65, new SauleBoard() ) )
				return false;

			return true;
		}
	}

	public class CheneLog : BaseLog
	{
		[Constructable]
		public CheneLog()
			: this( 1 )
		{
		}

		[Constructable]
		public CheneLog( int amount )
			: base( CraftResource.ChêneWood, amount )
		{
		}

        public CheneLog(Serial serial)
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override bool Axe( Mobile from, BaseAxe axe )
		{
			if ( !TryCreateBoards( from , 80, new CheneBoard() ) )
				return false;

			return true;
		}
	}

	public class EbeneLog : BaseLog
	{
		[Constructable]
		public EbeneLog()
			: this( 1 )
		{
		}

		[Constructable]
		public EbeneLog( int amount )
			: base( CraftResource.ÉbèneWood, amount )
		{
		}

        public EbeneLog(Serial serial)
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override bool Axe( Mobile from, BaseAxe axe )
		{
			if ( !TryCreateBoards( from , 95, new EbeneBoard() ) )
				return false;

			return true;
		}
	}

    public class AcajouLog : BaseLog
    {
        [Constructable]
        public AcajouLog()
            : this(1)
        {
        }

        [Constructable]
        public AcajouLog(int amount)
            : base(CraftResource.AcajouWood, amount)
        {
        }

        public AcajouLog(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override bool Axe(Mobile from, BaseAxe axe)
        {
            if (!TryCreateBoards(from, 95, new AcajouBoard()))
                return false;

            return true;
        }
    }
}