using System;

namespace Server.Items
{
	[Furniture]
	[FlipableAttribute( 0x1BD7, 0x1BDA )]
    public abstract class BaseTBoard : Item, ICommodity, IExtractable
	{
        #region IExtractable
        public string getName
        {
            get { return CraftResources.GetName(m_Resource); }
        }
        public int getHue
        {
            get { return CraftResources.GetHue(m_Resource); }
        }
        public double getSkillReq
        {
            get { return CraftResources.GetSkill(m_Resource); }
        }
        #endregion

		private CraftResource m_Resource;

		[CommandProperty( AccessLevel.Batisseur )]
		public CraftResource Resource
		{
			get { return m_Resource; }
			set { m_Resource = value; InvalidateProperties(); }
		}

		int ICommodity.DescriptionNumber 
		{ 
			get
			{
				/*if ( m_Resource >= CraftResource.OakWood && m_Resource <= CraftResource.YewWood )
					return 1075052 + ( (int)m_Resource - (int)CraftResource.OakWood );

				switch ( m_Resource )
				{
					case CraftResource.Bloodwood: return 1075055;
					case CraftResource.Frostwood: return 1075056;
					case CraftResource.Heartwood: return 1075062;	//WHY Osi.  Why?
				}*/

				return LabelNumber;
			} 
		}

		bool ICommodity.IsDeedable { get { return true; } }

		//[Constructable]
		public BaseTBoard()
			: this( 1 )
		{
		}

		//[Constructable]
		public BaseTBoard( int amount )
			: this( CraftResource.RegularWood, amount )
		{
		}

		public BaseTBoard( Serial serial )
			: base( serial )
		{
		}

		//[Constructable]
        public BaseTBoard(CraftResource resource)
            : this(resource, 1)
		{
		}

		//[Constructable]
        public BaseTBoard(CraftResource resource, int amount)
			: base( 0x1BD7 )
		{
			Stackable = true;
			Amount = amount;

			m_Resource = resource;
			Hue = CraftResources.GetHue( resource );
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
            list.Add("<h3><basefont color=#FFFFFF>{3} {0}{1}{2}</h3></basefont>", "Planche(s) [", GetMaterial(), "]", Amount);
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 3 );

			writer.Write( (int)m_Resource );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 3:
				case 2:
					{
						m_Resource = (CraftResource)reader.ReadInt();
						break;
					}
			}

			if ( (version == 0 && Weight == 0.1) || ( version <= 2 && Weight == 2 ) )
				Weight = -1;

			if ( version <= 1 )
				m_Resource = CraftResource.RegularWood;
		}
	}

	[Furniture]
    public class Board : BaseTBoard
    {
        [Constructable]
        public Board()
            : this(1)
        {
        }

        [Constructable]
        public Board(int amount)
            : base(CraftResource.RegularWood, amount)
        {
            GoldValue = 3;
        }

        public Board(Serial serial)
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
    }

	[Furniture]
    public class SauleBoard : BaseTBoard
	{
		[Constructable]
		public SauleBoard()
			: this( 1 )
		{
		}

		[Constructable]
		public SauleBoard( int amount )
			: base( CraftResource.SauleWood, amount )
		{
		}

        public SauleBoard(Serial serial)
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
	}

	[Furniture]
    public class CheneBoard : BaseTBoard
	{
		[Constructable]
		public CheneBoard()
			: this( 1 )
		{
		}

		[Constructable]
		public CheneBoard( int amount )
			: base( CraftResource.CheneWood, amount )
		{
		}

        public CheneBoard(Serial serial)
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
	}
	[Furniture]
    public class EbeneBoard : BaseTBoard
	{
		[Constructable]
		public EbeneBoard()
			: this( 1 )
		{
		}

		[Constructable]
		public EbeneBoard( int amount )
			: base( CraftResource.EbeneWood, amount )
		{
		}

        public EbeneBoard(Serial serial)
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
	}
	[Furniture]
    public class PinBoard : BaseTBoard
	{
		[Constructable]
		public PinBoard()
			: this( 1 )
		{
		}

		[Constructable]
		public PinBoard( int amount )
			: base( CraftResource.PinWood, amount )
		{
		}

        public PinBoard(Serial serial)
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
	}
	[Furniture]
    public class CypresBoard : BaseTBoard
	{
		[Constructable]
		public CypresBoard()
			: this( 1 )
		{
		}

		[Constructable]
		public CypresBoard( int amount )
			: base( CraftResource.CypresWood, amount )
		{
		}

        public CypresBoard(Serial serial)
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
	}
	[Furniture]
    public class CedreBoard : BaseTBoard
	{
		[Constructable]
		public CedreBoard()
			: this( 1 )
		{
		}

		[Constructable]
		public CedreBoard( int amount )
			: base( CraftResource.CedreWood, amount )
		{
		}

        public CedreBoard(Serial serial)
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
	}
	[Furniture]
    public class AcajouBoard : BaseTBoard
    {
        [Constructable]
        public AcajouBoard()
            : this(1)
        {
        }

        [Constructable]
        public AcajouBoard(int amount)
            : base(CraftResource.AcajouWood, amount)
        {
        }

        public AcajouBoard(Serial serial)
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
    }
}