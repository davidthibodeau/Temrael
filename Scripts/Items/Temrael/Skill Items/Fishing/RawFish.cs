using System;
using Server.Targeting;
using Server.Items;
using Server.Network;
using Server.Mobiles;

namespace Server.Items
{
    public abstract class BaseRawFishSteak : CookableFood
    {
		private CraftResource m_Resource;

		[CommandProperty( AccessLevel.Batisseur )]
		public CraftResource Resource
		{
			get{ return m_Resource; }
			set{ m_Resource = value; }
		}

        public override double DefaultWeight
        {
            get { return 0.1; }
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
        public BaseRawFishSteak(CraftResource resource) : this(resource, 1)
		{
		}

		[Constructable]
        public BaseRawFishSteak(CraftResource resource, int amount) : base(0x097A, 10) //Utility.Random(0x09CC, 4)
		{
			Stackable = true;
            Amount = amount;
            Hue = 0;

            m_Resource = resource;
		}

        public BaseRawFishSteak(Serial serial) : base(serial)
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
                "huître crue",
                "calamari cru",
                "pieuvre crue"
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
                list.Add(1060532, String.Format("{3} {0}{1}{2}", "Poissons crus [", GetMaterial(), "]", Amount)); // ~1_NUMBER~ ~2_ITEMNAME~
            else
                list.Add(String.Format("{0}{1}{2}", "Poisson cru [", GetMaterial(), "]")); // ingots
        }*/
    }

    public class RawTruiteFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawTruiteFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawTruiteFishSteak(int amount) : base(CraftResource.Truite, amount)
        {
            Name = "filet de Truite Cru";
        }

        public RawTruiteFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new TruiteFishSteak();
        }
    }

    public class RawDoreFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawDoreFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawDoreFishSteak(int amount) : base(CraftResource.Dore, amount)
        {
            Name = "filet de Doré Cru";
        }

        public RawDoreFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new DoreFishSteak();
        }
    }

    public class RawCarpeFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawCarpeFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawCarpeFishSteak(int amount) : base(CraftResource.Carpe, amount)
        {
            Name = "filet de Carpe Cru";
        }

        public RawCarpeFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new CarpeFishSteak();
        }
    }

    public class RawAnguilleFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawAnguilleFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawAnguilleFishSteak(int amount) : base(CraftResource.Anguille, amount)
        {
            Name = "filet d'Anguille Cru";
        }

        public RawAnguilleFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new AnguilleFishSteak();
        }
    }

    public class RawEsturgeonFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawEsturgeonFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawEsturgeonFishSteak(int amount) : base(CraftResource.Esturgeon, amount)
        {
            Name = "filet d'Esturgeon Cru";
        }

        public RawEsturgeonFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new EsturgeonFishSteak();
        }
    }

    public class RawBrochetFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawBrochetFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawBrochetFishSteak(int amount) : base(CraftResource.Brochet, amount)
        {
            Name = "filet de Brochet Cru";
        }

        public RawBrochetFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new BrochetFishSteak();
        }
    }

    public class RawSardineFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawSardineFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawSardineFishSteak(int amount) : base(CraftResource.Sardine, amount)
        {
            Name = "filet de Sardine Cru";
        }

        public RawSardineFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new SardineFishSteak();
        }
    }

    public class RawAnchoieFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawAnchoieFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawAnchoieFishSteak(int amount) : base(CraftResource.Anchoie, amount)
        {
            Name = "filet d'Anchoie Cru";
        }

        public RawAnchoieFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new AnchoieFishSteak();
        }
    }

    public class RawMorueFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawMorueFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawMorueFishSteak(int amount) : base(CraftResource.Morue, amount)
        {
            Name = "filet de Morue Cru";
        }

        public RawMorueFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new MorueFishSteak();
        }
    }

    public class RawHarengFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawHarengFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawHarengFishSteak(int amount) : base(CraftResource.Hareng, amount)
        {
            Name = "filet d'Hareng Cru";
        }

        public RawHarengFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new HarengFishSteak();
        }
    }

    public class RawFletanFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawFletanFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawFletanFishSteak(int amount) : base(CraftResource.Fletan, amount)
        {
            Name = "filet de Flétan Cru";
        }

        public RawFletanFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new FletanFishSteak();
        }
    }

    public class RawMaquereauFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawMaquereauFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawMaquereauFishSteak(int amount) : base(CraftResource.Maquereau, amount)
        {
            Name = "filet de Maquereau Cru";
        }

        public RawMaquereauFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new MaquereauFishSteak();
        }
    }

    public class RawSoleFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawSoleFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawSoleFishSteak(int amount) : base(CraftResource.Sole, amount)
        {
            Name = "filet de Sole Cru";
        }

        public RawSoleFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new SoleFishSteak();
        }
    }

    public class RawThonFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawThonFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawThonFishSteak(int amount) : base(CraftResource.Thon, amount)
        {
            Name = "filet de Thon Cru";
        }

        public RawThonFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new ThonFishSteak();
        }
    }

    public class RawSaumonFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawSaumonFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawSaumonFishSteak(int amount) : base(CraftResource.Saumon, amount)
        {
            Name = "filet de Saumon Cru";
        }

        public RawSaumonFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new SaumonFishSteak();
        }
    }

    public class RawGrandBrochetFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawGrandBrochetFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawGrandBrochetFishSteak(int amount) : base(CraftResource.GrandBrochet, amount)
        {
            Name = "filet de Grand Brochet Cru";
        }

        public RawGrandBrochetFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new GrandBrochetFishSteak();
        }
    }

    public class RawTruiteSauvageFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawTruiteSauvageFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawTruiteSauvageFishSteak(int amount) : base(CraftResource.TruiteSauvage, amount)
        {
            Name = "filet de Truite Sauvage Cru";
        }

        public RawTruiteSauvageFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new TruiteSauvageFishSteak();
        }
    }

    public class RawGrandDoreFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawGrandDoreFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawGrandDoreFishSteak(int amount) : base(CraftResource.GrandDore, amount)
        {
            Name = "filet de Grand Doré Cru";
        }

        public RawGrandDoreFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new GrandDoreFishSteak();
        }
    }

    public class RawTruiteMerFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawTruiteMerFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawTruiteMerFishSteak(int amount) : base(CraftResource.TruiteMer, amount)
        {
            Name = "filet de Truite des Mers Cru";
        }

        public RawTruiteMerFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new TruiteMerFishSteak();
        }
    }

    public class RawEsturgeonMerFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawEsturgeonMerFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawEsturgeonMerFishSteak(int amount) : base(CraftResource.EsturgeonMer, amount)
        {
            Name = "filet d'Esturgeon des Mers Cru";
        }

        public RawEsturgeonMerFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new EsturgeonMerFishSteak();
        }
    }

    public class RawGrandSaumonFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawGrandSaumonFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawGrandSaumonFishSteak(int amount) : base(CraftResource.GrandSaumon, amount)
        {
            Name = "filet de Grand Saumon Cru";
        }

        public RawGrandSaumonFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new GrandSaumonFishSteak();
        }
    }

    public class RawRaieFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawRaieFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawRaieFishSteak(int amount) : base(CraftResource.Raie, amount)
        {
            Name = "filet de Raie Cru";
        }

        public RawRaieFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new RaieFishSteak();
        }
    }

    public class RawEspadonFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawEspadonFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawEspadonFishSteak(int amount) : base(CraftResource.Espadon, amount)
        {
            Name = "filet d'Espadon Cru";
        }

        public RawEspadonFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new EspadonFishSteak();
        }
    }

    public class RawRequinGrisFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawRequinGrisFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawRequinGrisFishSteak(int amount) : base(CraftResource.RequinGris, amount)
        {
            Name = "filet de Requin Gris Cru";
        }

        public RawRequinGrisFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new RequinGrisFishSteak();
        }
    }

    public class RawRequinBlancFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawRequinBlancFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawRequinBlancFishSteak(int amount) : base(CraftResource.RequinBlanc, amount)
        {
            Name = "filet de Requin Blanc Cru";
        }

        public RawRequinBlancFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new RequinBlancFishSteak();
        }
    }

    public class RawHuitreFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawHuitreFishSteak() : base(CraftResource.Huitre)
        {
            Stackable = false;
            ItemID = 2426;
            Hue = 2083;
            Name = "Huitre Cru";
        }

        public RawHuitreFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new HuitreFishSteak();
        }
    }

    public class RawCalmarFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawCalmarFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawCalmarFishSteak(int amount) : base(CraftResource.Calmar, amount)
        {
            Name = "Calmar Cru";
        }

        public RawCalmarFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new CalmarFishSteak();
        }
    }

    public class RawPieuvreFishSteak : BaseRawFishSteak
    {
        [Constructable]
        public RawPieuvreFishSteak() : this(1)
        {
        }

        [Constructable]
        public RawPieuvreFishSteak(int amount) : base(CraftResource.Pieuvre, amount)
        {
            ItemID = 2426;
            Hue = CraftResources.GetHue(Resource);
            Name = "Pieuvre Cru";
        }

        public RawPieuvreFishSteak(Serial serial) : base(serial)
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

        public override Food Cook()
        {
            return new PieuvreFishSteak();
        }
    }
}
