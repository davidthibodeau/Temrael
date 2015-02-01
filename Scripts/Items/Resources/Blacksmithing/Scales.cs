using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public abstract class BaseScales : Item, ICommodity, IExtractable
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
            get { return CraftResources.GetSkill(m_Resource); ; }
        }
        #endregion

		public override int LabelNumber{ get{ return 1053139; } } // dragon scales

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

			writer.Write( (int) 0 ); // version

			writer.Write( (int) m_Resource );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Resource = (CraftResource)reader.ReadInt();
					break;
				}
			}
		}

		public BaseScales( CraftResource resource ) : this( resource, 1 )
		{
		}

		public BaseScales( CraftResource resource, int amount ) : base( 0x26B4 )
		{
			Stackable = true;
			Amount = amount;
			Hue = CraftResources.GetHue( resource );

			m_Resource = resource;
		}

        public static string[] m_Material = new string[]
            {
                "Regulier",
                "Nordique",
                "Desertique",
                "Maritime",
                "Volcanique",
                "Ancien",
                "Wyrm"
            };

        public virtual string GetMaterial()
        {
            string value = "aucun";

            try
            {
                value = m_Material[((int)m_Resource) - 201];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return value;
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("<h3><basefont color=#FFFFFF>{3} {0}{1}{2}</h3></basefont>", "Écaille(s) [", GetMaterial(), "]", Amount);
            /*if (Amount > 1)
                list.Add(1060532, String.Format("{3} {0}{1}{2}", "Os [", GetMaterial(), "]", Amount)); // ~1_NUMBER~ ~2_ITEMNAME~
            else
                list.Add(String.Format("{0}{1}{2}", "Os [", GetMaterial(), "]")); // ingots*/
        }

		public BaseScales( Serial serial ) : base( serial )
		{
		}
	}

	public class RegularScales : BaseScales
	{
		[Constructable]
		public RegularScales() : this( 1 )
		{
		}

		[Constructable]
		public RegularScales( int amount ) : base( CraftResource.RegularScales, amount )
		{
		}

        public RegularScales(Serial serial)
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

	public class NordiqueScales : BaseScales
	{
		[Constructable]
		public NordiqueScales() : this( 1 )
		{
		}

		[Constructable]
		public NordiqueScales( int amount ) : base( CraftResource.NordiqueScales, amount )
		{
		}

        public NordiqueScales(Serial serial)
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

	public class DesertiqueScales : BaseScales
	{
		[Constructable]
		public DesertiqueScales() : this( 1 )
		{
		}

		[Constructable]
        public DesertiqueScales(int amount)
            : base(CraftResource.DesertiqueScales, amount)
		{
		}

        public DesertiqueScales(Serial serial)
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

	public class MaritimeScales : BaseScales
	{
		[Constructable]
		public MaritimeScales() : this( 1 )
		{
		}

		[Constructable]
        public MaritimeScales(int amount)
            : base(CraftResource.MaritimeScales, amount)
		{
		}

        public MaritimeScales(Serial serial)
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

	public class VolcaniqueScales : BaseScales
	{
		[Constructable]
		public VolcaniqueScales() : this( 1 )
		{
		}

		[Constructable]
        public VolcaniqueScales(int amount)
            : base(CraftResource.VolcaniqueScales, amount)
		{
		}

        public VolcaniqueScales(Serial serial)
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

	public class AncienScales : BaseScales
	{
		public override int LabelNumber{ get{ return 1053140; } } // sea serpent scales

		[Constructable]
		public AncienScales() : this( 1 )
		{
		}

		[Constructable]
        public AncienScales(int amount)
            : base(CraftResource.AncienScales, amount)
		{
		}

        public AncienScales(Serial serial)
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

    public class WyrmScales : BaseScales
    {
        public override int LabelNumber { get { return 1053140; } } // sea serpent scales

        [Constructable]
        public WyrmScales()
            : this(1)
        {
        }

        [Constructable]
        public WyrmScales(int amount)
            : base(CraftResource.WyrmScales, amount)
        {
        }

        public WyrmScales(Serial serial)
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