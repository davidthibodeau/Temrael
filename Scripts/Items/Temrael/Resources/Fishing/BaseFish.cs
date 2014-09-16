using System;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public abstract class BaseFish : Item
	{
		private CraftResource m_Resource;

		[CommandProperty( AccessLevel.Batisseur )]
		public CraftResource Resource
		{
			get{ return m_Resource; }
		}

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version

            writer.Write((int)m_Resource);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    {
                        m_Resource = (CraftResource)reader.ReadInt();
                        goto case 0;
                    }
                case 0:
                    {
                        break;
                    }
            }
        }

		[Constructable]
        public BaseFish(CraftResource resource) : this(resource, 1)
		{
		}

		[Constructable]
        public BaseFish(CraftResource resource, int amount) : base(0x09CC) //Utility.Random(0x09CC, 4)
		{
			Stackable = true;
			Weight = 1.0;
            Amount = amount;
            Hue = CraftResources.GetHue(resource);

            m_Resource = resource;

            //Name = "Poisson : " + resource.ToString();
		}

		public BaseFish( Serial serial ) : base( serial )
		{
        }

        public override int LabelNumber
        {
            get
            {
                return 1049568;
            }
        }

        public static string[] m_Material = new string[]
            {
                "truite",
                "doré",
                "carpe",
                "anguille",
                "esturgeon",
                "brochet",
                "sardine",
                "anchoie",
                "morue",
                "hareng",
                "flétan",
                "maquereau",
                "sole",
                "thon",
                "saumon",
                "grand brochet",
                "truite sauvage",
                "grand doré",
                "truite de mer",
                "esturgeon de mer",
                "grand saumon",
                "raie",
                "espadon",
                "requin gris",
                "requin blanc",
                "huître",
                "calmar",
                "pieuvre"
            };

        public virtual string GetMaterial()
        {
            string value = "aucun";

            try
            {
                value = m_Material[((int)m_Resource) - 501];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return value;
        }

        public override void OnSingleClick(Mobile from)
        {
            if (m_Resource == CraftResource.Huitre || m_Resource == CraftResource.Calmar || m_Resource == CraftResource.Pieuvre)
            {
                LabelTo(from, GetMaterial());
            }
            else
            {
                base.OnSingleClick(from);

                LabelTo(from, String.Format("[{0}]", GetMaterial()));
            }
        }

        /*public override void AddNameProperty(ObjectPropertyList list)
        {
            if (Amount > 1)
                list.Add(1060532, String.Format("{3} {0}{1}{2}", "Poissons [", GetMaterial(), "]", Amount)); // ~1_NUMBER~ ~2_ITEMNAME~
            else
                list.Add(String.Format("{0}{1}{2}", "Poisson [", GetMaterial(), "]")); // ingots
        }*/
    }

    public class TruiteFish : BaseFish, ICarvable
    {
        [Constructable]
        public TruiteFish() : this(1)
        {
        }

        [Constructable]
        public TruiteFish(int amount) : base(CraftResource.Truite, amount)
        {
            Name = "Truite";
        }

        public TruiteFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            int amount = Amount;
            
            /*Item newItem = new TruiteScales(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawTruiteFishSteak(), 2, false);
        }
    }

    public class DoreFish : BaseFish, ICarvable
    {
        [Constructable]
        public DoreFish() : this(1)
        {
        }

        [Constructable]
        public DoreFish(int amount) : base(CraftResource.Dore, amount)
        {
            Name = "Doré";
        }

        public DoreFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            int amount = Amount;
            /*Item newItem = new DoreScales(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawDoreFishSteak(), 2, false);
        }
    }

    public class CarpeFish : BaseFish, ICarvable
    {
        [Constructable]
        public CarpeFish() : this(1)
        {
        }

        [Constructable]
        public CarpeFish(int amount) : base(CraftResource.Carpe, amount)
        {
            Name = "Carpe";
        }

        public CarpeFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            int amount = Amount;
            /*Item newItem = new CarpeScales(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawCarpeFishSteak(), 2, false);
        }
    }

    public class AnguilleFish : BaseFish, ICarvable
    {
        [Constructable]
        public AnguilleFish() : this(1)
        {
        }

        [Constructable]
        public AnguilleFish(int amount) : base(CraftResource.Anguille, amount)
        {
            Name = "Anguille";
        }

        public AnguilleFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            int amount = Amount;
            /*Item newItem = new SangAnguille(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false)) 
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);

            newItem = new AnguilleScales(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawAnguilleFishSteak(), 2, false);
        }
    }

    public class EsturgeonFish : BaseFish, ICarvable
    {
        [Constructable]
        public EsturgeonFish() : this(1)
        {
        }

        [Constructable]
        public EsturgeonFish(int amount) : base(CraftResource.Esturgeon, amount)
        {
            Name = "Esturgeon";
        }

        public EsturgeonFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            int amount = Amount;
            /*Item newItem = new CaviarEsturgeon(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false)) 
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);

            newItem = new EsturgeonScales(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawEsturgeonFishSteak(), 3, false);
        }
    }

    public class BrochetFish : BaseFish, ICarvable
    {
        [Constructable]
        public BrochetFish() : this(1)
        {
        }

        [Constructable]
        public BrochetFish(int amount) : base(CraftResource.Brochet, amount)
        {
            Name = "Brochet";
        }

        public BrochetFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            int amount = Amount;
            /*Item newItem = new BrochetScales(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawBrochetFishSteak(), 4, false);
        }
    }

    public class SardineFish : BaseFish, ICarvable
    {
        [Constructable]
        public SardineFish() : this(1)
        {
        }

        [Constructable]
        public SardineFish(int amount) : base(CraftResource.Sardine, amount)
        {
            Name = "Sardine";
            ItemID = 0xDD6;
        }

        public SardineFish(Serial serial) : base(serial)
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
            ItemID = 0xDD6;
        }

        public void Carve(Mobile from, Item item)
        {
            base.ScissorHelper(from, new RawSardineFishSteak(), 1, false);
        }
    }

    public class AnchoieFish : BaseFish, ICarvable
    {
        [Constructable]
        public AnchoieFish() : this(1)
        {
        }

        [Constructable]
        public AnchoieFish(int amount) : base(CraftResource.Anchoie, amount)
        {
            Name = "Anchoie";
            ItemID = 0xDD6;
        }

        public AnchoieFish(Serial serial) : base(serial)
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
            ItemID = 0xDD6;
        }

        public void Carve(Mobile from, Item item)
        {
            base.ScissorHelper(from, new RawAnchoieFishSteak(), 1, false);
        }
    }

    public class MorueFish : BaseFish, ICarvable
    {
        [Constructable]
        public MorueFish() : this(1)
        {
        }

        [Constructable]
        public MorueFish(int amount) : base(CraftResource.Morue, amount)
        {
            Name = "Morue";
        }

        public MorueFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            int amount = Amount;
            /*Item newItem = new HuileMorue(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false)) 
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);

            newItem = new MorueScales(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawMorueFishSteak(), 2, false);
        }
    }

    public class HarengFish : BaseFish, ICarvable
    {
        [Constructable]
        public HarengFish() : this(1)
        {
        }

        [Constructable]
        public HarengFish(int amount) : base(CraftResource.Hareng, amount)
        {
            Name = "Hareng";
            ItemID = 0xDD6;
        }

        public HarengFish(Serial serial) : base(serial)
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
            ItemID = 0xDD6;
        }

        public void Carve(Mobile from, Item item)
        {
            base.ScissorHelper(from, new RawHarengFishSteak(), 1, false);
        }
    }

    public class FletanFish : BaseFish, ICarvable
    {
        [Constructable]
        public FletanFish() : this(1)
        {
        }

        [Constructable]
        public FletanFish(int amount) : base(CraftResource.Fletan, amount)
        {
            Name = "Fletan";
        }

        public FletanFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            int amount = Amount;
            /*Item newItem = new FletanScales(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawFletanFishSteak(), 2, false);
        }
    }

    public class MaquereauFish : BaseFish, ICarvable
    {
        [Constructable]
        public MaquereauFish() : this(1)
        {
        }

        [Constructable]
        public MaquereauFish(int amount) : base(CraftResource.Maquereau, amount)
        {
            Name = "Maquereau";
        }

        public MaquereauFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            int amount = Amount;
            /*Item newItem = new MaquereauScales(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawMaquereauFishSteak(), 2, false);
        }
    }

    public class SoleFish : BaseFish, ICarvable
    {
        [Constructable]
        public SoleFish() : this(1)
        {
        }

        [Constructable]
        public SoleFish(int amount) : base(CraftResource.Sole, amount)
        {
            Name = "Sole";
        }

        public SoleFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            int amount = Amount;
            /*Item newItem = new GraisseSole(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false)) 
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);

            newItem = new SoleScales(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawSoleFishSteak(), 2, false);
        }
    }

    public class ThonFish : BaseFish, ICarvable
    {
        [Constructable]
        public ThonFish() : this(1)
        {
        }

        [Constructable]
        public ThonFish(int amount) : base(CraftResource.Thon, amount)
        {
            Name = "Thon";
        }

        public ThonFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            int amount = Amount;
            /*Item newItem = new OeufThon(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false)) 
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);

            newItem = new ThonScales(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawThonFishSteak(), 2, false);
        }
    }

    public class SaumonFish : BaseFish, ICarvable
    {
        [Constructable]
        public SaumonFish() : this(1)
        {
        }

        [Constructable]
        public SaumonFish(int amount) : base(CraftResource.Saumon, amount)
        {
            Name = "Saumon";
        }

        public SaumonFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            int amount = Amount;
            /*Item newItem = new CaviarSaumon(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);

            newItem = new SaumonScales(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawSaumonFishSteak(), 3, false);
        }
    }

    public class GrandBrochetFish : BaseFish, ICarvable
    {
        [Constructable]
        public GrandBrochetFish() : this(1)
        {
        }

        [Constructable]
        public GrandBrochetFish(int amount) : base(CraftResource.GrandBrochet, amount)
        {
            Name = "Grand Brochet";
        }

        public GrandBrochetFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            int amount = Amount;
            /*Item newItem = new BrochetScales(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawGrandBrochetFishSteak(), 4, false);
        }
    }

    public class TruiteSauvageFish : BaseFish, ICarvable
    {
        [Constructable]
        public TruiteSauvageFish() : this(1)
        {
        }

        [Constructable]
        public TruiteSauvageFish(int amount) : base(CraftResource.TruiteSauvage, amount)
        {
            Name = "Truite Sauvage";
        }

        public TruiteSauvageFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            int amount = Amount;
            /*Item newItem = new TruiteScales(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawTruiteSauvageFishSteak(), 3, false);
        }
    }

    public class GrandDoreFish : BaseFish, ICarvable
    {
        [Constructable]
        public GrandDoreFish() : this(1)
        {
        }

        [Constructable]
        public GrandDoreFish(int amount) : base(CraftResource.GrandDore, amount)
        {
            Name = "Grand Doré";
        }

        public GrandDoreFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            int amount = Amount;
            /*Item newItem = new DoreScales(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawGrandDoreFishSteak(), 4, false);
        }
    }

    public class TruiteMerFish : BaseFish, ICarvable
    {
        [Constructable]
        public TruiteMerFish() : this(1)
        {
        }

        [Constructable]
        public TruiteMerFish(int amount) : base(CraftResource.TruiteMer, amount)
        {
            Name = "Truite des Mers";
        }

        public TruiteMerFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            int amount = Amount;
            /*Item newItem = new TruiteScales(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawTruiteMerFishSteak(), 4, false);
        }
    }

    public class EsturgeonMerFish : BaseFish, ICarvable
    {
        [Constructable]
        public EsturgeonMerFish() : this(1)
        {
        }

        [Constructable]
        public EsturgeonMerFish(int amount) : base(CraftResource.EsturgeonMer, amount)
        {
            Name = "Esturgeon";
        }

        public EsturgeonMerFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            int amount = Amount;
            /*Item newItem = new CaviarEsturgeon(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);

            newItem = new EsturgeonScales(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawEsturgeonMerFishSteak(), 4, false);
        }
    }

    public class GrandSaumonFish : BaseFish, ICarvable
    {
        [Constructable]
        public GrandSaumonFish() : this(1)
        {
        }

        [Constructable]
        public GrandSaumonFish(int amount) : base(CraftResource.GrandSaumon, amount)
        {
            Name = "Grand Saumon";
        }

        public GrandSaumonFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            int amount = Amount;
            /*Item newItem = new CaviarSaumon(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);

            newItem = new SaumonScales(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawGrandSaumonFishSteak(), 4, false);
        }
    }

    public class RaieFish : BaseFish, ICarvable
    {
        [Constructable]
        public RaieFish() : this(1)
        {
        }

        [Constructable]
        public RaieFish(int amount) : base(CraftResource.Raie, amount)
        {
            Name = "Raie";
        }

        public RaieFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            int amount = Amount;
            /*Item newItem = new OeilRaie(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);

            newItem = new RaieScales(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawRaieFishSteak(), 2, false);
        }
    }

    public class EspadonFish : BaseFish, ICarvable
    {
        [Constructable]
        public EspadonFish() : this(1)
        {
        }

        [Constructable]
        public EspadonFish(int amount) : base(CraftResource.Espadon, amount)
        {
            Name = "Espadon";
        }

        public EspadonFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            int amount = Amount;
            /*Item newItem = new EspadonScales(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawEspadonFishSteak(), 4, false);
        }
    }

    public class RequinGrisFish : BaseFish, ICarvable
    {
        [Constructable]
        public RequinGrisFish() : base(CraftResource.RequinGris, 151)
        {
            ItemID = 0x1C10;
            Movable = false;
            Name = "Requin Gris";
        }

        public RequinGrisFish(Serial serial) : base(serial)
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

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "requin gris");
        }

        public void Carve(Mobile from, Item item)
        {
            /*Item newItem = new DentRequin(5);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);

            newItem = new RawRequinGrisFishSteak(4);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);

            Delete();*/
        }
    }

    public class RequinBlancFish : BaseFish, ICarvable
    {
        [Constructable]
        public RequinBlancFish() : base(CraftResource.RequinBlanc, 151)
        {
            ItemID = 0x1C10;
            Movable = false;
            Name = "Requin Blanc";
        }

        public RequinBlancFish(Serial serial) : base(serial)
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

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "requin blanc");
        }

        public void Carve(Mobile from, Item item)
        {
            /*Item newItem = new DentRequin(5);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);

            newItem = new RawRequinBlancFishSteak(4);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);

            Delete();*/
        }
    }

    public class HuitreFish : BaseFish, ICarvable
    {
        [Constructable]
        public HuitreFish() : base(CraftResource.Huitre)
        {
            Stackable = false;
            ItemID = 4175;
            Name = "Huitre";
        }

        public HuitreFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            /*CoquillageArcEnCiel newItem = new CoquillageArcEnCiel();
            newItem.Movable = true;

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawHuitreFishSteak(), 1, false);
        }
    }

    public class CalmarFish : BaseFish, ICarvable
    {
        [Constructable]
        public CalmarFish() : this(1)
        {
        }

        [Constructable]
        public CalmarFish(int amount) : base(CraftResource.Calmar, amount)
        {
            ItemID = 3532;
            Name = "Calmar";
        }

        public CalmarFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            base.ScissorHelper(from, new RawCalmarFishSteak(), 2, false);
        }
    }

    public class PieuvreFish : BaseFish, ICarvable
    {
        [Constructable]
        public PieuvreFish() : this(1)
        {
        }

        [Constructable]
        public PieuvreFish(int amount) : base(CraftResource.Pieuvre, amount)
        {
            ItemID = 3521;
            Name = "Pieuvre";
        }

        public PieuvreFish(Serial serial) : base(serial)
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

        public void Carve(Mobile from, Item item)
        {
            /*Item newItem = new Encre(Amount);

            if (!(this.Parent is Container) || !((Container)this.Parent).TryDropItem(from, newItem, false))
                newItem.MoveToWorld(this.GetWorldLocation(), this.Map);*/

            base.ScissorHelper(from, new RawPieuvreFishSteak(), 1, false);
        }
    }
}
