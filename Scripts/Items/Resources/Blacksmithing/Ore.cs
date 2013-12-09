using System;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Engines.Craft;
using Server.Mobiles;

namespace Server.Items
{
	public abstract class BaseOre : Item, ICommodity
	{
		private CraftResource m_Resource;

		[CommandProperty( AccessLevel.GameMaster )]
		public CraftResource Resource
		{
			get{ return m_Resource; }
			set{ m_Resource = value; InvalidateProperties(); }
		}

		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }

		public abstract BaseIngot GetIngot();

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

		public BaseOre( CraftResource resource ) : this( resource, 1 )
		{
		}

		public BaseOre( CraftResource resource, int amount ) : base( Utility.Random( 4 ) )
		{
			{
				double random = Utility.RandomDouble();
				if ( 0.12 >= random )
					ItemID = 0x19B7;
				else if ( 0.18 >= random )
					ItemID = 0x19B8;
				else if ( 0.25 >= random )
					ItemID = 0x19BA;
				else
					ItemID = 0x19B9;
			}
			
			Stackable = true;
			Amount = amount;
			Hue = CraftResources.GetHue( resource );

			m_Resource = resource;
		}

		public BaseOre( Serial serial ) : base( serial )
		{
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			if ( Amount > 1 )
				list.Add( 1050039, "{0}\t#{1}", Amount, 1026583 ); // ~1_NUMBER~ ~2_ITEMNAME~
			else
				list.Add( 1026583 ); // ore
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
					return 1042845 + (int)(m_Resource - CraftResource.Cuivre);

				return 1042853; // iron ore;
			}
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !Movable )
				return;
			
			if ( RootParent is BaseCreature )
			{
				from.SendLocalizedMessage( 500447 ); // That is not accessible
				return;
			}
			else if ( from.InRange( this.GetWorldLocation(), 2 ) )
			{
				from.SendLocalizedMessage( 501971 ); // Select the forge on which to smelt the ore, or another pile of ore with which to combine it.
				from.Target = new InternalTarget( this );
			}
			else
			{
				from.SendLocalizedMessage( 501976 ); // The ore is too far away.
			}
		}

		private class InternalTarget : Target
		{
			private BaseOre m_Ore;

			public InternalTarget( BaseOre ore ) :  base ( 2, false, TargetFlags.None )
			{
				m_Ore = ore;
			}

			private bool IsForge( object obj )
			{
				if ( Core.ML && obj is Mobile && ((Mobile)obj).IsDeadBondedPet )
					return false;

				if ( obj.GetType().IsDefined( typeof( ForgeAttribute ), false ) )
					return true;

				int itemID = 0;

				if ( obj is Item )
					itemID = ((Item)obj).ItemID;
				else if ( obj is StaticTarget )
					itemID = ((StaticTarget)obj).ItemID;

				return ( itemID == 4017 || (itemID >= 6522 && itemID <= 6569) );
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( m_Ore.Deleted )
					return;

				if ( !from.InRange( m_Ore.GetWorldLocation(), 2 ) )
				{
					from.SendLocalizedMessage( 501976 ); // The ore is too far away.
					return;
				}
				
				#region Combine Ore
				if ( targeted is BaseOre )
				{
					BaseOre ore = (BaseOre)targeted;
					if ( !ore.Movable )
						return;
					else if ( m_Ore == ore )
					{
						from.SendLocalizedMessage( 501972 ); // Select another pile or ore with which to combine this.
						from.Target = new InternalTarget( ore );
						return;
					}
					else if ( ore.Resource != m_Ore.Resource )
					{
						from.SendLocalizedMessage( 501979 ); // You cannot combine ores of different metals.
						return;
					}

					int worth = ore.Amount;
					if ( ore.ItemID == 0x19B9 )
						worth *= 8;
					else if ( ore.ItemID == 0x19B7 )
						worth *= 2;
					else 
						worth *= 4;
					int sourceWorth = m_Ore.Amount;
					if ( m_Ore.ItemID == 0x19B9 )
						sourceWorth *= 8;
					else if ( m_Ore.ItemID == 0x19B7 )
						sourceWorth *= 2;
					else
						sourceWorth *= 4;
					worth += sourceWorth;

					int plusWeight = 0;
					int newID = ore.ItemID;
					if ( ore.DefaultWeight != m_Ore.DefaultWeight )
					{
						if ( ore.ItemID == 0x19B7 || m_Ore.ItemID == 0x19B7 )
						{
							newID = 0x19B7;
						}
						else if ( ore.ItemID == 0x19B9 )
						{
							newID = m_Ore.ItemID;
							plusWeight = ore.Amount * 2;
						}
						else
						{
							plusWeight = m_Ore.Amount * 2;
						}
					}

					if ( (ore.ItemID == 0x19B9 && worth > 120000) || (( ore.ItemID == 0x19B8 || ore.ItemID == 0x19BA ) && worth > 60000) || (ore.ItemID == 0x19B7 && worth > 30000))
					{
						from.SendLocalizedMessage( 1062844 ); // There is too much ore to combine.
						return;
					}
					else if ( ore.RootParent is Mobile && (plusWeight + ((Mobile)ore.RootParent).Backpack.TotalWeight) > ((Mobile)ore.RootParent).Backpack.MaxWeight )
					{ 
						from.SendLocalizedMessage( 501978 ); // The weight is too great to combine in a container.
						return;
					}

					ore.ItemID = newID;
					if ( ore.ItemID == 0x19B9 )
					{
						ore.Amount = worth / 8;
						m_Ore.Delete();
					}
					else if ( ore.ItemID == 0x19B7 )
					{
						ore.Amount = worth / 2;
						m_Ore.Delete();
					}
					else
					{
						ore.Amount = worth / 4;
						m_Ore.Delete();
					}	
					return;
				}
				#endregion

				if ( IsForge( targeted ) )
				{
					double difficulty;

					switch ( m_Ore.Resource )
					{
						default: difficulty = 0.0; break;
						case CraftResource.Cuivre: difficulty = 15.0; break;
						case CraftResource.Bronze: difficulty = 20.0; break;
						case CraftResource.Acier: difficulty = 25.0; break;
						case CraftResource.Argent: difficulty = 30.0; break;
						case CraftResource.Or: difficulty = 45.0; break;
						case CraftResource.Mytheril: difficulty = 50.0; break;
						case CraftResource.Luminium: difficulty = 55.0; break;
						case CraftResource.Obscurium: difficulty = 65.0; break;
                        case CraftResource.Mystirium: difficulty = 70.0; break;
                        case CraftResource.Dominium: difficulty = 70.0; break;
                        case CraftResource.Eclarium: difficulty = 85.0; break;
                        case CraftResource.Venarium: difficulty = 85.0; break;
                        case CraftResource.Athenium: difficulty = 99.0; break;
                        case CraftResource.Umbrarium: difficulty = 99.0; break;
					}

					double minSkill = difficulty - 25.0;
					double maxSkill = difficulty + 25.0;
					
					if ( difficulty > 50.0 && difficulty > from.Skills[SkillName.Excavation].Value )
					{
						from.SendLocalizedMessage( 501986 ); // You have no idea how to smelt this strange ore!
						return;
					}
					
					if ( m_Ore.Amount <= 1 && m_Ore.ItemID == 0x19B7 )
					{
						from.SendLocalizedMessage( 501987 ); // There is not enough metal-bearing ore in this pile to make an ingot.
						return;
					}

					if ( from.CheckTargetSkill( SkillName.Excavation, targeted, minSkill, maxSkill ) )
					{
						if ( m_Ore.Amount <= 0 )
						{
							from.SendLocalizedMessage( 501987 ); // There is not enough metal-bearing ore in this pile to make an ingot.
						}
						else
						{
							int amount = m_Ore.Amount;
							if ( m_Ore.Amount > 30000 )
								amount = 30000;

							BaseIngot ingot = m_Ore.GetIngot();
							
							if ( m_Ore.ItemID == 0x19B7 )
							{
								if ( m_Ore.Amount % 2 == 0 )
								{
									amount /= 2;
									m_Ore.Delete();
								}
								else
								{
									amount /= 2;
									m_Ore.Amount = 1;
								}
							}
								
							else if ( m_Ore.ItemID == 0x19B9 )
							{
								amount *= 2;
								m_Ore.Delete();
							}
							
							else
							{
								amount /= 1;
								m_Ore.Delete();
							}

							ingot.Amount = amount;
							from.AddToBackpack( ingot );
							//from.PlaySound( 0x57 );


							from.SendLocalizedMessage( 501988 ); // You smelt the ore removing the impurities and put the metal in your backpack.
						}
					}
					else if ( m_Ore.Amount < 2 && m_Ore.ItemID == 0x19B9 )
					{
						from.SendLocalizedMessage( 501990 ); // You burn away the impurities but are left with less useable metal.
						m_Ore.ItemID = 0x19B8;
					}
					else if ( m_Ore.Amount < 2 && m_Ore.ItemID == 0x19B8 || m_Ore.ItemID == 0x19BA )
					{
						from.SendLocalizedMessage( 501990 ); // You burn away the impurities but are left with less useable metal.
						m_Ore.ItemID = 0x19B7;
					}
					else
					{
						from.SendLocalizedMessage( 501990 ); // You burn away the impurities but are left with less useable metal.
						m_Ore.Amount /= 2;
					}
				}
			}
		}
	}

	public class FerOre : BaseOre
	{
		[Constructable]
		public FerOre() : this( 1 )
		{
		}

		[Constructable]
		public FerOre( int amount ) : base( CraftResource.Fer, amount )
		{
            Name = "Minerais de Fer";
		}

        public FerOre(Serial serial)
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

		

		public override BaseIngot GetIngot()
		{
			return new FerIngot();
		}
	}

	public class CuivreOre : BaseOre
	{
		[Constructable]
		public CuivreOre() : this( 1 )
		{
		}

		[Constructable]
		public CuivreOre( int amount ) : base( CraftResource.Cuivre, amount )
		{
            Name = "Minerais de Cuivre";
		}

        public CuivreOre(Serial serial)
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

		

		public override BaseIngot GetIngot()
		{
            return new CuivreIngot();
		}
	}

	public class BronzeOre : BaseOre
	{
		[Constructable]
		public BronzeOre() : this( 1 )
		{
		}

		[Constructable]
		public BronzeOre( int amount ) : base( CraftResource.Bronze, amount )
		{
            Name = "Minerais de Bronze";
		}

        public BronzeOre(Serial serial)
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

		

		public override BaseIngot GetIngot()
		{
            return new BronzeIngot();
		}
	}

	public class AcierOre : BaseOre
	{
		[Constructable]
		public AcierOre() : this( 1 )
		{
		}

		[Constructable]
		public AcierOre( int amount ) : base( CraftResource.Acier, amount )
		{
            Name = "Minerais d'Acier";
		}

        public AcierOre(Serial serial)
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

		

		public override BaseIngot GetIngot()
		{
			return new AcierIngot();
		}
	}

	public class ArgentOre : BaseOre
	{
		[Constructable]
		public ArgentOre() : this( 1 )
		{
		}

		[Constructable]
		public ArgentOre( int amount ) : base( CraftResource.Argent, amount )
		{
            Name = "Minerais d'Argent";
		}

        public ArgentOre(Serial serial)
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

		

		public override BaseIngot GetIngot()
		{
			return new ArgentIngot();
		}
	}

	public class OrOre : BaseOre
	{
		[Constructable]
		public OrOre() : this( 1 )
		{
		}

		[Constructable]
		public OrOre( int amount ) : base( CraftResource.Or, amount )
		{
            Name = "Minerais d'Or";
		}

        public OrOre(Serial serial)
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

		

		public override BaseIngot GetIngot()
		{
			return new OrIngot();
		}
	}

	public class MytherilOre : BaseOre
	{
		[Constructable]
		public MytherilOre() : this( 1 )
		{
		}

		[Constructable]
		public MytherilOre( int amount ) : base( CraftResource.Mytheril, amount )
		{
            Name = "Minerais de Mytheril";
		}

        public MytherilOre(Serial serial)
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

		

		public override BaseIngot GetIngot()
		{
            return new MytherilIngot();
		}
	}

	public class LuminiumOre : BaseOre
	{
		[Constructable]
		public LuminiumOre() : this( 1 )
		{
		}

		[Constructable]
		public LuminiumOre( int amount ) : base( CraftResource.Luminium, amount )
		{
            Name = "Minerais de Luminium";
		}

        public LuminiumOre(Serial serial)
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

		

		public override BaseIngot GetIngot()
		{
			return new LuminiumIngot();
		}
	}

	public class ObscuriumOre : BaseOre
	{
		[Constructable]
		public ObscuriumOre() : this( 1 )
		{
		}

		[Constructable]
		public ObscuriumOre( int amount ) : base( CraftResource.Obscurium, amount )
		{
            Name = "Minerais d'Obscurium";
		}

        public ObscuriumOre(Serial serial)
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

		

		public override BaseIngot GetIngot()
		{
			return new ObscuriumIngot();
		}
	}

    public class MystiriumOre : BaseOre
    {
        [Constructable]
        public MystiriumOre()
            : this(1)
        {
        }

        [Constructable]
        public MystiriumOre(int amount)
            : base(CraftResource.Mystirium, amount)
        {
            Name = "Minerais de Mystirium";
        }

        public MystiriumOre(Serial serial)
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



        public override BaseIngot GetIngot()
        {
            return new MystiriumIngot();
        }
    }

    public class DominiumOre : BaseOre
    {
        [Constructable]
        public DominiumOre()
            : this(1)
        {
        }

        [Constructable]
        public DominiumOre(int amount)
            : base(CraftResource.Dominium, amount)
        {
            Name = "Minerais de Dominium";
        }

        public DominiumOre(Serial serial)
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



        public override BaseIngot GetIngot()
        {
            return new DominiumIngot();
        }
    }

    public class EclariumOre : BaseOre
    {
        [Constructable]
        public EclariumOre()
            : this(1)
        {
        }

        [Constructable]
        public EclariumOre(int amount)
            : base(CraftResource.Eclarium, amount)
        {
            Name = "Minerais d'Eclarium";
        }

        public EclariumOre(Serial serial)
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



        public override BaseIngot GetIngot()
        {
            return new EclariumIngot();
        }
    }

    public class VenariumOre : BaseOre
    {
        [Constructable]
        public VenariumOre()
            : this(1)
        {
        }

        [Constructable]
        public VenariumOre(int amount)
            : base(CraftResource.Venarium, amount)
        {
            Name = "Minerais de Venarium";
        }

        public VenariumOre(Serial serial)
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



        public override BaseIngot GetIngot()
        {
            return new VenariumIngot();
        }
    }

    public class AtheniumOre : BaseOre
    {
        [Constructable]
        public AtheniumOre()
            : this(1)
        {
        }

        [Constructable]
        public AtheniumOre(int amount)
            : base(CraftResource.Athenium, amount)
        {
            Name = "Minerais d'Athenium";
        }

        public AtheniumOre(Serial serial)
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



        public override BaseIngot GetIngot()
        {
            return new AtheniumIngot();
        }
    }

    public class UmbrariumOre : BaseOre
    {
        [Constructable]
        public UmbrariumOre()
            : this(1)
        {
        }

        [Constructable]
        public UmbrariumOre(int amount)
            : base(CraftResource.Umbrarium, amount)
        {
            Name = "Minerais d'Umbrarium";
        }

        public UmbrariumOre(Serial serial)
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



        public override BaseIngot GetIngot()
        {
            return new UmbrariumIngot();
        }
    }
}