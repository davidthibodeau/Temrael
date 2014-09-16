using System;
using Server.Targeting;
using Server.Items;
using Server.Network;
using Server.Mobiles;

namespace Server.Items
{
    public abstract class BaseFishSteak : Food
    {
		private CraftResource m_Resource;

		[CommandProperty( AccessLevel.Batisseur )]
		public CraftResource Resource
		{
			get{ return m_Resource; }
			set{ m_Resource = value; }
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

            Hue = 0;
        }

		[Constructable]
        public BaseFishSteak(CraftResource resource) : this(resource, 1)
		{
		}

		[Constructable]
        public BaseFishSteak(CraftResource resource, int amount) : base(0x97B) //Utility.Random(0x09CC, 4)
		{
			Stackable = true;
			Weight = 0.1;
            Amount = amount;
            FillFactor = 5;
            Hue = 0;

            m_Resource = resource;
		}

        public BaseFishSteak(Serial serial) : base(serial)
		{
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
                "calamari",
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
                list.Add(String.Format("{0}{1}{2}", "Poissons [", GetMaterial(), "]")); // ingots
        }*/
    }

    public class TruiteFishSteak : BaseFishSteak
    {
        [Constructable]
        public TruiteFishSteak() : this(1)
        {
        }

        [Constructable]
        public TruiteFishSteak(int amount) : base(CraftResource.Truite, amount)
        {
            Name = "Filet de Truite";
        }

        public TruiteFishSteak(Serial serial) : base(serial)
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

    public class DoreFishSteak : BaseFishSteak
    {
        [Constructable]
        public DoreFishSteak() : this(1)
        {
        }

        [Constructable]
        public DoreFishSteak(int amount) : base(CraftResource.Dore, amount)
        {
            Name = "Filet de Doré";
        }

        public DoreFishSteak(Serial serial) : base(serial)
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

    public class CarpeFishSteak : BaseFishSteak
    {
        [Constructable]
        public CarpeFishSteak() : this(1)
        {
        }

        [Constructable]
        public CarpeFishSteak(int amount) : base(CraftResource.Carpe, amount)
        {
            Name = "Filet de Carpe";
        }

        public CarpeFishSteak(Serial serial) : base(serial)
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

    public class AnguilleFishSteak : BaseFishSteak
    {
        [Constructable]
        public AnguilleFishSteak() : this(1)
        {
        }

        [Constructable]
        public AnguilleFishSteak(int amount) : base(CraftResource.Anguille, amount)
        {
            Name = "Filet d'Anguille";
        }

        public AnguilleFishSteak(Serial serial) : base(serial)
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

    public class EsturgeonFishSteak : BaseFishSteak
    {
        [Constructable]
        public EsturgeonFishSteak() : this(1)
        {
        }

        [Constructable]
        public EsturgeonFishSteak(int amount) : base(CraftResource.Esturgeon, amount)
        {
            Name = "Filet d'Esturgeon";
        }

        public EsturgeonFishSteak(Serial serial) : base(serial)
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

    public class BrochetFishSteak : BaseFishSteak
    {
        [Constructable]
        public BrochetFishSteak() : this(1)
        {
        }

        [Constructable]
        public BrochetFishSteak(int amount) : base(CraftResource.Brochet, amount)
        {
            Name = "Filet de Brochet";
        }

        public BrochetFishSteak(Serial serial) : base(serial)
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

    public class SardineFishSteak : BaseFishSteak
    {
        [Constructable]
        public SardineFishSteak() : this(1)
        {
        }

        [Constructable]
        public SardineFishSteak(int amount) : base(CraftResource.Sardine, amount)
        {
            Name = "Filet de Sardine";
        }

        public SardineFishSteak(Serial serial) : base(serial)
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

    public class AnchoieFishSteak : BaseFishSteak
    {
        [Constructable]
        public AnchoieFishSteak() : this(1)
        {
        }

        [Constructable]
        public AnchoieFishSteak(int amount) : base(CraftResource.Anchoie, amount)
        {
            Name = "Filet d'Anchoie";
        }

        public AnchoieFishSteak(Serial serial) : base(serial)
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

    public class MorueFishSteak : BaseFishSteak
    {
        [Constructable]
        public MorueFishSteak() : this(1)
        {
        }

        [Constructable]
        public MorueFishSteak(int amount) : base(CraftResource.Morue, amount)
        {
            Name = "Filet de Morue";
        }

        public MorueFishSteak(Serial serial) : base(serial)
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

    public class HarengFishSteak : BaseFishSteak
    {
        [Constructable]
        public HarengFishSteak() : this(1)
        {
        }

        [Constructable]
        public HarengFishSteak(int amount) : base(CraftResource.Hareng, amount)
        {
            Name = "Filet de Hareng";
        }

        public HarengFishSteak(Serial serial) : base(serial)
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

    public class FletanFishSteak : BaseFishSteak
    {
        [Constructable]
        public FletanFishSteak() : this(1)
        {
        }

        [Constructable]
        public FletanFishSteak(int amount) : base(CraftResource.Fletan, amount)
        {
            Name = "Filet de Flétan";
        }

        public FletanFishSteak(Serial serial) : base(serial)
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

    public class MaquereauFishSteak : BaseFishSteak
    {
        [Constructable]
        public MaquereauFishSteak() : this(1)
        {
        }

        [Constructable]
        public MaquereauFishSteak(int amount) : base(CraftResource.Maquereau, amount)
        {
            Name = "Filet de Maquereau";
        }

        public MaquereauFishSteak(Serial serial) : base(serial)
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

    public class SoleFishSteak : BaseFishSteak
    {
        [Constructable]
        public SoleFishSteak() : this(1)
        {
        }

        [Constructable]
        public SoleFishSteak(int amount) : base(CraftResource.Sole, amount)
        {
            Name = "Filet de Sole";
        }

        public SoleFishSteak(Serial serial) : base(serial)
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

    public class ThonFishSteak : BaseFishSteak
    {
        [Constructable]
        public ThonFishSteak() : this(1)
        {
        }

        [Constructable]
        public ThonFishSteak(int amount) : base(CraftResource.Thon, amount)
        {
            Name = "Filet de Thon";
        }

        public ThonFishSteak(Serial serial) : base(serial)
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

    public class SaumonFishSteak : BaseFishSteak
    {
        [Constructable]
        public SaumonFishSteak() : this(1)
        {
        }

        [Constructable]
        public SaumonFishSteak(int amount) : base(CraftResource.Saumon, amount)
        {
            Name = "Filet de Saumon";
        }

        public SaumonFishSteak(Serial serial) : base(serial)
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

    public class GrandBrochetFishSteak : BaseFishSteak
    {
        [Constructable]
        public GrandBrochetFishSteak() : this(1)
        {
        }

        [Constructable]
        public GrandBrochetFishSteak(int amount) : base(CraftResource.GrandBrochet, amount)
        {
            Name = "Filet de Grand Brochet";
        }

        public GrandBrochetFishSteak(Serial serial) : base(serial)
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

    public class TruiteSauvageFishSteak : BaseFishSteak
    {
        [Constructable]
        public TruiteSauvageFishSteak() : this(1)
        {
        }

        [Constructable]
        public TruiteSauvageFishSteak(int amount) : base(CraftResource.TruiteSauvage, amount)
        {
            Name = "Filet de Truite Sauvage";
        }

        public TruiteSauvageFishSteak(Serial serial) : base(serial)
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

    public class GrandDoreFishSteak : BaseFishSteak
    {
        [Constructable]
        public GrandDoreFishSteak() : this(1)
        {
        }

        [Constructable]
        public GrandDoreFishSteak(int amount) : base(CraftResource.GrandDore, amount)
        {
            Name = "Filet de Grand Doré";
        }

        public GrandDoreFishSteak(Serial serial) : base(serial)
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

    public class TruiteMerFishSteak : BaseFishSteak
    {
        [Constructable]
        public TruiteMerFishSteak() : this(1)
        {
        }

        [Constructable]
        public TruiteMerFishSteak(int amount) : base(CraftResource.TruiteMer, amount)
        {
            Name = "Filet de Truite des Mers";
        }

        public TruiteMerFishSteak(Serial serial) : base(serial)
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

    public class EsturgeonMerFishSteak : BaseFishSteak
    {
        [Constructable]
        public EsturgeonMerFishSteak() : this(1)
        {
        }

        [Constructable]
        public EsturgeonMerFishSteak(int amount) : base(CraftResource.EsturgeonMer, amount)
        {
            Name = "Filet d'Esturgeon des Mers";
        }

        public EsturgeonMerFishSteak(Serial serial) : base(serial)
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

    public class GrandSaumonFishSteak : BaseFishSteak
    {
        [Constructable]
        public GrandSaumonFishSteak() : this(1)
        {
        }

        [Constructable]
        public GrandSaumonFishSteak(int amount) : base(CraftResource.GrandSaumon, amount)
        {
            Name = "Filet de Grand Saumon";
        }

        public GrandSaumonFishSteak(Serial serial) : base(serial)
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

    public class RaieFishSteak : BaseFishSteak
    {
        [Constructable]
        public RaieFishSteak() : this(1)
        {
        }

        [Constructable]
        public RaieFishSteak(int amount) : base(CraftResource.Raie, amount)
        {
            Name = "Filet de Raie";
        }

        public RaieFishSteak(Serial serial) : base(serial)
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

    public class EspadonFishSteak : BaseFishSteak
    {
        [Constructable]
        public EspadonFishSteak() : this(1)
        {
        }

        [Constructable]
        public EspadonFishSteak(int amount) : base(CraftResource.Espadon, amount)
        {
            Name = "Filet d'Espadon";
        }

        public EspadonFishSteak(Serial serial) : base(serial)
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

    public class RequinGrisFishSteak : BaseFishSteak
    {
        [Constructable]
        public RequinGrisFishSteak() : this(1)
        {
        }

        [Constructable]
        public RequinGrisFishSteak(int amount) : base(CraftResource.RequinGris, amount)
        {
            Name = "Filet de Requin Gris";
        }

        public RequinGrisFishSteak(Serial serial) : base(serial)
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

    public class RequinBlancFishSteak : BaseFishSteak
    {
        [Constructable]
        public RequinBlancFishSteak() : this(1)
        {
        }

        [Constructable]
        public RequinBlancFishSteak(int amount) : base(CraftResource.RequinBlanc, amount)
        {
            Name = "Filet de Requin Blanc";
        }

        public RequinBlancFishSteak(Serial serial) : base(serial)
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

    public class HuitreFishSteak : BaseFishSteak
    {
        [Constructable]
        public HuitreFishSteak() : base(CraftResource.Huitre)
        {
            Stackable = false;
            ItemID = 2486;
            Hue = 2113;
            Name = "Huitre cuite";
        }

        public HuitreFishSteak(Serial serial) : base(serial)
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

            Hue = 2083;
        }
    }

    public class CalmarFishSteak : BaseFishSteak
    {
        [Constructable]
        public CalmarFishSteak() : this(1)
        {
        }

        [Constructable]
        public CalmarFishSteak(int amount) : base(CraftResource.Calmar, amount)
        {
            Name = "Calmar Cuit";
        }

        public CalmarFishSteak(Serial serial) : base(serial)
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

    public class PieuvreFishSteak : BaseFishSteak
    {
        [Constructable]
        public PieuvreFishSteak() : this(1)
        {
        }

        [Constructable]
        public PieuvreFishSteak(int amount) : base(CraftResource.Pieuvre, amount)
        {
            ItemID = 2427;
            Hue = 2222;
            Name = "Pieuvre Cuite";
        }

        public PieuvreFishSteak(Serial serial) : base(serial)
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

            Hue = CraftResources.GetHue(Resource);
        }
    }
}
