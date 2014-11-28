using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public abstract class BaseLeather : Item, ICommodity, IExtractable
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
			get{ return m_Resource; }
			set{ m_Resource = value; InvalidateProperties(); }
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
					OreInfo info = new OreInfo( reader.ReadInt(), reader.ReadInt(), reader.ReadString() );

					m_Resource = CraftResources.GetFromOreInfo( info );
					break;
				}
			}
		}

		public BaseLeather( CraftResource resource ) : this( resource, 1 )
		{
		}

		public BaseLeather( CraftResource resource, int amount ) : base( 0x1081 )
		{
			Stackable = true;
			Weight = 1.0;
			Amount = amount;
			Hue = CraftResources.GetHue( resource );

			m_Resource = resource;
		}

		public BaseLeather( Serial serial ) : base( serial )
		{
		}

        public static string[] m_Material = new string[]
            {
                "Regulier",
                "Reptilien",
                "Nordique",
                "Desertique",
                "Maritime",
                "Volcanique",
                "Geant",
                "Minotaure",
                "Ophidien",
                "Arachnide",
                "Magique",
                "Ancien",
                "Demon",
                "Dragon",
                "Lupus"
            };

        public virtual string GetMaterial()
        {
            string value = "aucun";

            try
            {
                value = m_Material[((int)m_Resource) - 101];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return value;
        }

		public override void AddNameProperty( ObjectPropertyList list )
		{
            list.Add("<h3><basefont color=#FFFFFF>{3} {0}{1}{2}</h3></basefont>", "Cuir [", GetMaterial(), "]", Amount);
			/*if ( Amount > 1 )
				list.Add( 1050039, "{0}\t#{1}", Amount, 1024199 ); // ~1_NUMBER~ ~2_ITEMNAME~
			else
				list.Add( 1024199 ); // cut leather*/
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

		public override int LabelNumber
		{
			get
			{
				//if ( m_Resource >= CraftResource.SpinedLeather && m_Resource <= CraftResource.BarbedLeather )
				//	return 1049684 + (int)(m_Resource - CraftResource.SpinedLeather);

				return 1047022;
			}
		}
	}

	[FlipableAttribute( 0x1081, 0x1082 )]
	public class Leather : BaseLeather
	{
		[Constructable]
		public Leather() : this( 1 )
		{
		}

		[Constructable]
		public Leather( int amount ) : base( CraftResource.RegularLeather, amount )
		{
            GoldValue = 3;
            Name = "Cuir";
		}

		public Leather( Serial serial ) : base( serial )
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

    [FlipableAttribute(0x1081, 0x1082)]
    public class ReptilienLeather : BaseLeather
    {
        [Constructable]
        public ReptilienLeather()
            : this(1)
        {
        }

        [Constructable]
        public ReptilienLeather(int amount)
            : base(CraftResource.ReptilienLeather, amount)
        {
            Name = "Cuir Reptilien";
        }

        public ReptilienLeather(Serial serial)
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

	[FlipableAttribute( 0x1081, 0x1082 )]
	public class NordiqueLeather : BaseLeather
	{
		[Constructable]
		public NordiqueLeather() : this( 1 )
		{
		}

		[Constructable]
        public NordiqueLeather(int amount)
            : base(CraftResource.NordiqueLeather, amount)
		{
            Name = "Cuir Nordique";
		}

        public NordiqueLeather(Serial serial)
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

	[FlipableAttribute( 0x1081, 0x1082 )]
	public class DesertiqueLeather : BaseLeather
	{
		[Constructable]
		public DesertiqueLeather() : this( 1 )
		{
		}

		[Constructable]
        public DesertiqueLeather(int amount)
            : base(CraftResource.DesertiqueLeather, amount)
		{
            Name = "Cuir Désertique";
		}

        public DesertiqueLeather(Serial serial)
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

	[FlipableAttribute( 0x1081, 0x1082 )]
	public class MaritimeLeather : BaseLeather
	{
		[Constructable]
		public MaritimeLeather() : this( 1 )
		{
		}

		[Constructable]
        public MaritimeLeather(int amount)
            : base(CraftResource.MaritimeLeather, amount)
		{
            Name = "Cuir Maritime";
		}

        public MaritimeLeather(Serial serial)
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

    [FlipableAttribute(0x1081, 0x1082)]
    public class VolcaniqueLeather : BaseLeather
    {
        [Constructable]
        public VolcaniqueLeather()
            : this(1)
        {
        }

        [Constructable]
        public VolcaniqueLeather(int amount)
            : base(CraftResource.VolcaniqueLeather, amount)
        {
            Name = "Cuir Volcanique";
        }

        public VolcaniqueLeather(Serial serial)
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

    [FlipableAttribute(0x1081, 0x1082)]
    public class GeantLeather : BaseLeather
    {
        [Constructable]
        public GeantLeather()
            : this(1)
        {
        }

        [Constructable]
        public GeantLeather(int amount)
            : base(CraftResource.GeantLeather, amount)
        {
            Name = "Cuir Géant";
        }

        public GeantLeather(Serial serial)
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

    [FlipableAttribute(0x1081, 0x1082)]
    public class MinotaureLeather : BaseLeather
    {
        [Constructable]
        public MinotaureLeather()
            : this(1)
        {
        }

        [Constructable]
        public MinotaureLeather(int amount)
            : base(CraftResource.MinotaurLeather, amount)
        {
            Name = "Cuir de Minotaure";
        }

        public MinotaureLeather(Serial serial)
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

    [FlipableAttribute(0x1081, 0x1082)]
    public class OphidienLeather : BaseLeather
    {
        [Constructable]
        public OphidienLeather()
            : this(1)
        {
        }

        [Constructable]
        public OphidienLeather(int amount)
            : base(CraftResource.OphidienLeather, amount)
        {
            Name = "Cuir Ophidien";
        }

        public OphidienLeather(Serial serial)
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

    [FlipableAttribute(0x1081, 0x1082)]
    public class ArachnideLeather : BaseLeather
    {
        [Constructable]
        public ArachnideLeather()
            : this(1)
        {
        }

        [Constructable]
        public ArachnideLeather(int amount)
            : base(CraftResource.ArachnideLeather, amount)
        {
            Name = "Cuir d'Arachnide";
        }

        public ArachnideLeather(Serial serial)
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

    [FlipableAttribute(0x1081, 0x1082)]
    public class MagiqueLeather : BaseLeather
    {
        [Constructable]
        public MagiqueLeather()
            : this(1)
        {
        }

        [Constructable]
        public MagiqueLeather(int amount)
            : base(CraftResource.MagiqueLeather, amount)
        {
            Name = "Cuir Magique";
        }

        public MagiqueLeather(Serial serial)
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

    [FlipableAttribute(0x1081, 0x1082)]
    public class AncienLeather : BaseLeather
    {
        [Constructable]
        public AncienLeather()
            : this(1)
        {
        }

        [Constructable]
        public AncienLeather(int amount)
            : base(CraftResource.AncienLeather, amount)
        {
            Name = "Cuir Ancien";
        }

        public AncienLeather(Serial serial)
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

    [FlipableAttribute(0x1081, 0x1082)]
    public class DemoniaqueLeather : BaseLeather
    {
        [Constructable]
        public DemoniaqueLeather()
            : this(1)
        {
        }

        [Constructable]
        public DemoniaqueLeather(int amount)
            : base(CraftResource.DemoniaqueLeather, amount)
        {
            Name = "Cuir Démoniaque";
        }

        public DemoniaqueLeather(Serial serial)
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

    [FlipableAttribute(0x1081, 0x1082)]
    public class DragoniqueLeather : BaseLeather
    {
        [Constructable]
        public DragoniqueLeather()
            : this(1)
        {
        }

        [Constructable]
        public DragoniqueLeather(int amount)
            : base(CraftResource.DragoniqueLeather, amount)
        {
            Name = "Cuir Dragonique";
        }

        public DragoniqueLeather(Serial serial)
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

    [FlipableAttribute(0x1081, 0x1082)]
    public class LupusLeather : BaseLeather
    {
        [Constructable]
        public LupusLeather()
            : this(1)
        {
        }

        [Constructable]
        public LupusLeather(int amount)
            : base(CraftResource.LupusLeather, amount)
        {
            Name = "Cuir Lupus";
        }

        public LupusLeather(Serial serial)
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