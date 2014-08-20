using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public abstract class BaseHides : Item, ICommodity
	{
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

		public BaseHides( CraftResource resource ) : this( resource, 1 )
		{
		}

		public BaseHides( CraftResource resource, int amount ) : base( 0x1079 )
		{
			Stackable = true;
			Weight = 5.0;
			Amount = amount;
			Hue = CraftResources.GetHue( resource );

			m_Resource = resource;
		}

		public BaseHides( Serial serial ) : base( serial )
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
            list.Add("<h3><basefont color=#FFFFFF>{3} {0}{1}{2}</h3></basefont>", "Peau(x) [", GetMaterial(), "]", Amount);
			/*if ( Amount > 1 )
				list.Add( 1050039, "{0}\t#{1}", Amount, 1024216 ); // ~1_NUMBER~ ~2_ITEMNAME~
			else
				list.Add( 1024216 ); // pile of hides*/
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
				//	return 1049687 + (int)(m_Resource - CraftResource.SpinedLeather);

				return 1047023;
			}
		}
	}

	[FlipableAttribute( 0x1079, 0x1078 )]
	public class Hides : BaseHides, IScissorable
	{
		[Constructable]
		public Hides() : this( 1 )
		{
		}

		[Constructable]
		public Hides( int amount ) : base( CraftResource.RegularLeather, amount )
		{
		}

		public Hides( Serial serial ) : base( serial )
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

		public bool Scissor( Mobile from, Scissors scissors )
		{
			if ( Deleted || !from.CanSee( this ) ) return false;

			if ( !IsChildOf ( from.Backpack ) )
			{
				from.SendLocalizedMessage ( 502437 ); // Items you wish to cut must be in your backpack
				return false;
			}
			base.ScissorHelper( from, new Leather(), 1 );

			return true;
		}
	}

    [FlipableAttribute(0x1079, 0x1078)]
    public class ReptilienHides : BaseHides, IScissorable
    {
        [Constructable]
        public ReptilienHides()
            : this(1)
        {
        }

        [Constructable]
        public ReptilienHides(int amount)
            : base(CraftResource.ReptilienLeather, amount)
        {
        }

        public ReptilienHides(Serial serial)
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

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (Deleted || !from.CanSee(this)) return false;

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
                return false;
            }

            base.ScissorHelper(from, new ReptilienLeather(), 1);

            return true;
        }
    }

	[FlipableAttribute( 0x1079, 0x1078 )]
	public class NordiqueHides : BaseHides, IScissorable
	{
		[Constructable]
		public NordiqueHides() : this( 1 )
		{
		}

		[Constructable]
        public NordiqueHides(int amount)
            : base(CraftResource.NordiqueLeather, amount)
		{
		}

        public NordiqueHides(Serial serial)
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

		public bool Scissor( Mobile from, Scissors scissors )
		{
			if ( Deleted || !from.CanSee( this ) ) return false;

			if ( !IsChildOf ( from.Backpack ) )
			{
				from.SendLocalizedMessage ( 502437 ); // Items you wish to cut must be in your backpack
				return false;
			}

            base.ScissorHelper(from, new NordiqueLeather(), 1);

			return true;
		}
	}

	[FlipableAttribute( 0x1079, 0x1078 )]
	public class DesertiqueHides : BaseHides, IScissorable
	{
		[Constructable]
		public DesertiqueHides() : this( 1 )
		{
		}

		[Constructable]
        public DesertiqueHides(int amount)
            : base(CraftResource.DesertiqueLeather, amount)
		{
		}

        public DesertiqueHides(Serial serial)
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

		public bool Scissor( Mobile from, Scissors scissors )
		{
			if ( Deleted || !from.CanSee( this ) ) return false;

			if ( !IsChildOf ( from.Backpack ) )
			{
				from.SendLocalizedMessage ( 502437 ); // Items you wish to cut must be in your backpack
				return false;
			}

            base.ScissorHelper(from, new DesertiqueLeather(), 1);

			return true;
		}
	}

	[FlipableAttribute( 0x1079, 0x1078 )]
	public class MaritimeHides : BaseHides, IScissorable
	{
		[Constructable]
		public MaritimeHides() : this( 1 )
		{
		}

		[Constructable]
        public MaritimeHides(int amount)
            : base(CraftResource.MaritimeLeather, amount)
		{
		}

        public MaritimeHides(Serial serial)
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

		public bool Scissor( Mobile from, Scissors scissors )
		{
			if ( Deleted || !from.CanSee( this ) ) return false;

			if ( !IsChildOf ( from.Backpack ) )
			{
				from.SendLocalizedMessage ( 502437 ); // Items you wish to cut must be in your backpack
				return false;
			}

            base.ScissorHelper(from, new MaritimeLeather(), 1);

			return true;
		}
	}

    [FlipableAttribute(0x1079, 0x1078)]
    public class VolcaniqueHides : BaseHides, IScissorable
    {
        [Constructable]
        public VolcaniqueHides()
            : this(1)
        {
        }

        [Constructable]
        public VolcaniqueHides(int amount)
            : base(CraftResource.VolcaniqueLeather, amount)
        {
        }

        public VolcaniqueHides(Serial serial)
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

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (Deleted || !from.CanSee(this)) return false;

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
                return false;
            }

            base.ScissorHelper(from, new VolcaniqueLeather(), 1);

            return true;
        }
    }

    [FlipableAttribute(0x1079, 0x1078)]
    public class GeantHides : BaseHides, IScissorable
    {
        [Constructable]
        public GeantHides()
            : this(1)
        {
        }

        [Constructable]
        public GeantHides(int amount)
            : base(CraftResource.GeantLeather, amount)
        {
        }

        public GeantHides(Serial serial)
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

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (Deleted || !from.CanSee(this)) return false;

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
                return false;
            }

            base.ScissorHelper(from, new GeantLeather(), 1);

            return true;
        }
    }

    [FlipableAttribute(0x1079, 0x1078)]
    public class MinotaureHides : BaseHides, IScissorable
    {
        [Constructable]
        public MinotaureHides()
            : this(1)
        {
        }

        [Constructable]
        public MinotaureHides(int amount)
            : base(CraftResource.MinotaurLeather, amount)
        {
        }

        public MinotaureHides(Serial serial)
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

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (Deleted || !from.CanSee(this)) return false;

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
                return false;
            }

            base.ScissorHelper(from, new MinotaureLeather(), 1);

            return true;
        }
    }

    [FlipableAttribute(0x1079, 0x1078)]
    public class OphidienHides : BaseHides, IScissorable
    {
        [Constructable]
        public OphidienHides()
            : this(1)
        {
        }

        [Constructable]
        public OphidienHides(int amount)
            : base(CraftResource.OphidienLeather, amount)
        {
        }

        public OphidienHides(Serial serial)
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

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (Deleted || !from.CanSee(this)) return false;

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
                return false;
            }

            base.ScissorHelper(from, new OphidienLeather(), 1);

            return true;
        }
    }

    [FlipableAttribute(0x1079, 0x1078)]
    public class ArachnideHides : BaseHides, IScissorable
    {
        [Constructable]
        public ArachnideHides()
            : this(1)
        {
        }

        [Constructable]
        public ArachnideHides(int amount)
            : base(CraftResource.ArachnideLeather, amount)
        {
        }

        public ArachnideHides(Serial serial)
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

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (Deleted || !from.CanSee(this)) return false;

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
                return false;
            }

            base.ScissorHelper(from, new ArachnideLeather(), 1);

            return true;
        }
    }

    [FlipableAttribute(0x1079, 0x1078)]
    public class MagiqueHides : BaseHides, IScissorable
    {
        [Constructable]
        public MagiqueHides()
            : this(1)
        {
        }

        [Constructable]
        public MagiqueHides(int amount)
            : base(CraftResource.MagiqueLeather, amount)
        {
        }

        public MagiqueHides(Serial serial)
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

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (Deleted || !from.CanSee(this)) return false;

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
                return false;
            }

            base.ScissorHelper(from, new MagiqueLeather(), 1);

            return true;
        }
    }

    [FlipableAttribute(0x1079, 0x1078)]
    public class AncienHides : BaseHides, IScissorable
    {
        [Constructable]
        public AncienHides()
            : this(1)
        {
        }

        [Constructable]
        public AncienHides(int amount)
            : base(CraftResource.AncienLeather, amount)
        {
        }

        public AncienHides(Serial serial)
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

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (Deleted || !from.CanSee(this)) return false;

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
                return false;
            }

            base.ScissorHelper(from, new AncienLeather(), 1);

            return true;
        }
    }

    [FlipableAttribute(0x1079, 0x1078)]
    public class DemoniaqueHides : BaseHides, IScissorable
    {
        [Constructable]
        public DemoniaqueHides()
            : this(1)
        {
        }

        [Constructable]
        public DemoniaqueHides(int amount)
            : base(CraftResource.DemoniaqueLeather, amount)
        {
        }

        public DemoniaqueHides(Serial serial)
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

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (Deleted || !from.CanSee(this)) return false;

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
                return false;
            }

            base.ScissorHelper(from, new DemoniaqueLeather(), 1);

            return true;
        }
    }

    [FlipableAttribute(0x1079, 0x1078)]
    public class DragoniqueHides : BaseHides, IScissorable
    {
        [Constructable]
        public DragoniqueHides()
            : this(1)
        {
        }

        [Constructable]
        public DragoniqueHides(int amount)
            : base(CraftResource.DragoniqueLeather, amount)
        {
        }

        public DragoniqueHides(Serial serial)
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

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (Deleted || !from.CanSee(this)) return false;

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
                return false;
            }

            base.ScissorHelper(from, new DragoniqueLeather(), 1);

            return true;
        }
    }

    [FlipableAttribute(0x1079, 0x1078)]
    public class LupusHides : BaseHides, IScissorable
    {
        [Constructable]
        public LupusHides()
            : this(1)
        {
        }

        [Constructable]
        public LupusHides(int amount)
            : base(CraftResource.LupusLeather, amount)
        {
        }

        public LupusHides(Serial serial)
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

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (Deleted || !from.CanSee(this)) return false;

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
                return false;
            }

            base.ScissorHelper(from, new LupusLeather(), 1);

            return true;
        }
    }
}