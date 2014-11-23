using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public abstract class BaseIngot : Item, ICommodity, IExtractable
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
        #endregion

        private CraftResource m_Resource;

		[CommandProperty( AccessLevel.Batisseur )]
		public CraftResource Resource
		{
			get{ return m_Resource; }
			set{ m_Resource = value; InvalidateProperties(); }
		}

		public override double DefaultWeight
		{
			get { return 0.1; }
		}
		
		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			writer.Write( (int) m_Resource );
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
				case 0:
				{
					OreInfo info;

					switch ( reader.ReadInt() )
					{
						case 0: info = OreInfo.Fer; break;
						case 1: info = OreInfo.Cuivre; break;
						case 2: info = OreInfo.Bronze; break;
						case 3: info = OreInfo.Acier; break;
						case 4: info = OreInfo.Argent; break;
						case 5: info = OreInfo.Or; break;
						case 6: info = OreInfo.Mytheril; break;
						case 7: info = OreInfo.Luminium; break;
						case 8: info = OreInfo.Obscurium; break;
                        case 9: info = OreInfo.Mystirium; break;
                        case 10: info = OreInfo.Dominium; break;
                        case 11: info = OreInfo.Eclarium; break;
                        case 12: info = OreInfo.Venarium; break;
                        case 13: info = OreInfo.Athenium; break;
                        case 14: info = OreInfo.Umbrarium; break;
						default: info = null; break;
					}

					m_Resource = CraftResources.GetFromOreInfo( info );
					break;
				}
			}
		}

		public BaseIngot( CraftResource resource ) : this( resource, 1 )
		{
		}

		public BaseIngot( CraftResource resource, int amount ) : base( 0x1BF2 )
		{
			Stackable = true;
			Amount = amount;
			Hue = CraftResources.GetHue( resource );

			m_Resource = resource;
		}

		public BaseIngot( Serial serial ) : base( serial )
		{
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			if ( Amount > 1 )
				list.Add( 1050039, "{0}\t#{1}", Amount, 1027154 ); // ~1_NUMBER~ ~2_ITEMNAME~
			else
				list.Add( 1027154 ); // ingots
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if ( !CraftResources.IsStandard( m_Resource ) )
			{
				/*int num = CraftResources.GetLocalizationNumber( m_Resource );

				if ( num > 0 )
					list.Add( num );
				else*/
					list.Add( CraftResources.GetName( m_Resource ) );
			}
		}

		public override int LabelNumber
		{
			get
			{
				if ( m_Resource >= CraftResource.Cuivre && m_Resource <= CraftResource.Umbrarium )
					return 1042684 + (int)(m_Resource - CraftResource.Cuivre);

				return 1042692;
			}
		}
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class FerIngot : BaseIngot
	{
		[Constructable]
		public FerIngot() : this( 1 )
		{
		}

		[Constructable]
		public FerIngot( int amount ) : base( CraftResource.Fer, amount )
		{
            GoldValue = 3;
            Name = "Lingot de Fer";
		}

        public FerIngot(Serial serial)
            : base(serial)
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

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class CuivreIngot : BaseIngot
	{
		[Constructable]
		public CuivreIngot() : this( 1 )
		{
		}

		[Constructable]
		public CuivreIngot( int amount ) : base( CraftResource.Cuivre, amount )
		{
            Name = "Lingot de Cuivre";
		}

        public CuivreIngot(Serial serial)
            : base(serial)
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

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class BronzeIngot : BaseIngot
	{
		[Constructable]
		public BronzeIngot() : this( 1 )
		{
		}

		[Constructable]
		public BronzeIngot( int amount ) : base( CraftResource.Bronze, amount )
		{
            Name = "Lingot de Bronze";
		}

        public BronzeIngot(Serial serial)
            : base(serial)
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

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class AcierIngot : BaseIngot
	{
		[Constructable]
		public AcierIngot() : this( 1 )
		{
		}

		[Constructable]
		public AcierIngot( int amount ) : base( CraftResource.Acier, amount )
		{
            Name = "Lingot d'Acier";
		}

        public AcierIngot(Serial serial)
            : base(serial)
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

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class ArgentIngot : BaseIngot
	{
		[Constructable]
		public ArgentIngot() : this( 1 )
		{
		}

		[Constructable]
		public ArgentIngot( int amount ) : base( CraftResource.Argent, amount )
		{
            Name = "Lingot d'Argent";
		}

        public ArgentIngot(Serial serial)
            : base(serial)
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

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class OrIngot : BaseIngot
	{
		[Constructable]
		public OrIngot() : this( 1 )
		{
		}

		[Constructable]
		public OrIngot( int amount ) : base( CraftResource.Or, amount )
		{
            Name = "Lingot d'Or";
		}

        public OrIngot(Serial serial)
            : base(serial)
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

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class MytherilIngot : BaseIngot
	{
		[Constructable]
		public MytherilIngot() : this( 1 )
		{
		}

		[Constructable]
		public MytherilIngot( int amount ) : base( CraftResource.Mytheril, amount )
		{
            Name = "Lingot de Mytheril";
		}

        public MytherilIngot(Serial serial)
            : base(serial)
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

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class LuminiumIngot : BaseIngot
	{
		[Constructable]
		public LuminiumIngot() : this( 1 )
		{
		}

		[Constructable]
		public LuminiumIngot( int amount ) : base( CraftResource.Luminium, amount )
		{
            Name = "Lingot de Luminium";
		}

        public LuminiumIngot(Serial serial)
            : base(serial)
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

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class ObscuriumIngot : BaseIngot
	{
		[Constructable]
		public ObscuriumIngot() : this( 1 )
		{
		}

		[Constructable]
		public ObscuriumIngot( int amount ) : base( CraftResource.Obscurium, amount )
		{
            Name = "Lingot d'Obscurium";
		}

        public ObscuriumIngot(Serial serial)
            : base(serial)
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

    [FlipableAttribute(0x1BF2, 0x1BEF)]
    public class MystiriumIngot : BaseIngot
    {
        [Constructable]
        public MystiriumIngot()
            : this(1)
        {
        }

        [Constructable]
        public MystiriumIngot(int amount)
            : base(CraftResource.Mystirium, amount)
        {
            Name = "Lingot de Mystirium";
        }

        public MystiriumIngot(Serial serial)
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

    [FlipableAttribute(0x1BF2, 0x1BEF)]
    public class DominiumIngot : BaseIngot
    {
        [Constructable]
        public DominiumIngot()
            : this(1)
        {
        }

        [Constructable]
        public DominiumIngot(int amount)
            : base(CraftResource.Dominium, amount)
        {
            Name = "Lingot de Dominium";
        }

        public DominiumIngot(Serial serial)
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

    [FlipableAttribute(0x1BF2, 0x1BEF)]
    public class EclariumIngot : BaseIngot
    {
        [Constructable]
        public EclariumIngot()
            : this(1)
        {
        }

        [Constructable]
        public EclariumIngot(int amount)
            : base(CraftResource.Eclarium, amount)
        {
            Name = "Lingot d'Éclarium";
        }

        public EclariumIngot(Serial serial)
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

    [FlipableAttribute(0x1BF2, 0x1BEF)]
    public class VenariumIngot : BaseIngot
    {
        [Constructable]
        public VenariumIngot()
            : this(1)
        {
        }

        [Constructable]
        public VenariumIngot(int amount)
            : base(CraftResource.Venarium, amount)
        {
            Name = "Lingot de Venarium";
        }

        public VenariumIngot(Serial serial)
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

    [FlipableAttribute(0x1BF2, 0x1BEF)]
    public class AtheniumIngot : BaseIngot
    {
        [Constructable]
        public AtheniumIngot()
            : this(1)
        {
        }

        [Constructable]
        public AtheniumIngot(int amount)
            : base(CraftResource.Athenium, amount)
        {
            Name = "Lingot d'Athénium";
        }

        public AtheniumIngot(Serial serial)
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

    [FlipableAttribute(0x1BF2, 0x1BEF)]
    public class UmbrariumIngot : BaseIngot
    {
        [Constructable]
        public UmbrariumIngot()
            : this(1)
        {
        }

        [Constructable]
        public UmbrariumIngot(int amount)
            : base(CraftResource.Umbrarium, amount)
        {
            Name = "Lingot d'Umbrarium";
        }

        public UmbrariumIngot(Serial serial)
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