using System;
using Server.Mobiles;
using System.Collections.Generic;
using Server.Items;
using Server.Engines.Races;
using System.IO;
using System.Xml;

namespace Server.Mobiles.Vendeurs
{
    public class Acheteur : BaseVendor
    {
        private static Dictionary<Mobile, int> ventesAlloues = new Dictionary<Mobile, int>();
        private static readonly string SavePath = Path.Combine(Directories.AppendPath(Directories.saves, "Misc"), "ventes.xml");
        public const int allocationHebdo = 500;

        public static void Configure()
        {
            EventSink.WorldLoad += new WorldLoadEventHandler( Load );
            EventSink.WorldSave += new WorldSaveEventHandler( Save );
        }

        public static void Reset()
        {
            ventesAlloues = new Dictionary<Mobile, int>();
        }

        public static void Save(WorldSaveEventArgs e)
        {
            using (StreamWriter op = new StreamWriter(SavePath))
            {
                XmlTextWriter xml = new XmlTextWriter(op);

                xml.Formatting = Formatting.Indented;
                xml.IndentChar = '\t';
                xml.Indentation = 1;

                xml.WriteStartDocument(true);

                xml.WriteStartElement("entries");

                foreach (Mobile m in ventesAlloues.Keys)
                {
                    xml.WriteStartElement("entry");
                    xml.WriteStartAttribute("mobile");
                    xml.WriteString(m.Serial.Value.ToString());
                    xml.WriteEndAttribute();
                    xml.WriteStartAttribute("depense");
                    xml.WriteString(ventesAlloues[m].ToString());
                    xml.WriteEndAttribute();
                    xml.WriteEndElement();
                }
                xml.Close();
            }
        }

        public static void Load()
        {
            if (!File.Exists(SavePath))
                return;

            XmlDocument doc = new XmlDocument();
            doc.Load(SavePath);

            XmlElement root = doc["entries"];

            foreach (XmlElement entry in root.GetElementsByTagName("entry"))
            {
                Mobile m = World.FindMobile(Utility.GetXMLInt32(entry.GetAttribute("mobile"), -1));
                if (m != null)
                    ventesAlloues.Add(m, Utility.GetXMLInt32(entry.GetAttribute("depense"), 0));
            }

        }

        public static bool TesterDepense(Mobile m, int x)
        {
            try
            {
                if(ventesAlloues[m] + x > allocationHebdo)
                    return false;
            }
            catch 
            {
                if (x > allocationHebdo)
                    return false;
            }
            return true;
        }

        public static int AjouterMontant(Mobile m, int x)
        {
            try
            {
                int y = ventesAlloues[m] + x;
                ventesAlloues[m] = y;
                return allocationHebdo - y;
            }
            catch 
            {
                ventesAlloues.Add(m, x);
                return allocationHebdo - x;
            }
        }

        public static int VerifierDepense(Mobile m)
        {
            try
            {
                return allocationHebdo - ventesAlloues[m];
            }
            catch
            {
                return allocationHebdo;
            }
        }

        [Constructable]
        public Acheteur()
            : base("Acheteur")
        {
            Name = "Melba";
        }


        public Acheteur(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x191; //female

            SetRace(new Nain(1054));
            HairItemID = 11123;
            HairHue = 1128;
            FacialHairItemID = 10308;
            FacialHairHue = 1128;
        }

        public override void InitOutfit()
        {
            AddItem(new RobeDomestique(1636));
            AddItem(new CapeCourte(1120));
            AddItem(new Shoes(1133));
            AddItem(new GoldEarrings(0));
        }

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override bool IsActiveBuyer { get { return true; } }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBAcheteur());
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

    public class SBAcheteur : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBAcheteur()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(FerIngot), PriceList(1));
                Add(typeof(CuivreIngot), PriceList(2));
                Add(typeof(BronzeIngot), PriceList(3));
                Add(typeof(AcierIngot), PriceList(4));
                Add(typeof(ArgentIngot), PriceList(5));
                Add(typeof(OrIngot), PriceList(6));
                Add(typeof(MytherilIngot), PriceList(7));
                Add(typeof(LuminiumIngot), PriceList(8));
                Add(typeof(ObscuriumIngot), PriceList(9));
                Add(typeof(MystiriumIngot), PriceList(10));
                Add(typeof(DominiumIngot), PriceList(11));
                Add(typeof(VenariumIngot), PriceList(12));
                Add(typeof(EclariumIngot), PriceList(13));
                Add(typeof(AtheniumIngot), PriceList(14));
                Add(typeof(UmbrariumIngot), PriceList(15));

                Add(typeof(Leather), PriceList(1));
                Add(typeof(LupusLeather), PriceList(2));
                Add(typeof(NordiqueLeather), PriceList(3));
                Add(typeof(ReptilienLeather), PriceList(4));
                Add(typeof(DesertiqueLeather), PriceList(5));
                Add(typeof(VolcaniqueLeather), PriceList(6));
                Add(typeof(MaritimeLeather), PriceList(7));
                Add(typeof(GeantLeather), PriceList(8));
                Add(typeof(MinotaureLeather), PriceList(9));
                Add(typeof(OphidienLeather), PriceList(10));
                Add(typeof(ArachnideLeather), PriceList(11));
                Add(typeof(MagiqueLeather), PriceList(12));
                Add(typeof(AncienLeather), PriceList(13));
                Add(typeof(DemoniaqueLeather), PriceList(14));
                Add(typeof(DragoniqueLeather), PriceList(15));

                Add(typeof(Bone), PriceList(1));
                Add(typeof(GobelinBone), PriceList(2));
                Add(typeof(NordiqueBone), PriceList(3));
                Add(typeof(ReptilienBone), PriceList(4));
                Add(typeof(DesertiqueBone), PriceList(5));
                Add(typeof(VolcaniqueBone), PriceList(6));
                Add(typeof(MaritimeBone), PriceList(7));
                Add(typeof(GeantBone), PriceList(8));
                Add(typeof(MinotaureBone), PriceList(9));
                Add(typeof(OphidienBone), PriceList(10));
                Add(typeof(ArachnideBone), PriceList(11));
                Add(typeof(MagiqueBone), PriceList(12));
                Add(typeof(AncienBone), PriceList(13));
                Add(typeof(DemonBone), PriceList(14));
                Add(typeof(DragonBone), PriceList(15));

                Add(typeof(Coquillage), PriceList(1));
                Add(typeof(Amber), PriceList(2));
                Add(typeof(Citrine), PriceList(3));
                Add(typeof(Tourmaline), PriceList(4));
                Add(typeof(Amethyst), PriceList(5));
                Add(typeof(Ruby), PriceList(6));
                Add(typeof(Sapphire), PriceList(7));
                Add(typeof(Emerald), PriceList(8));
                Add(typeof(Diamond), PriceList(9));
                Add(typeof(StarSapphire), PriceList(10));
                Add(typeof(FireRuby), PriceList(11));
                Add(typeof(PerfectEmerald), PriceList(12));
                Add(typeof(BlueDiamond), PriceList(13));

                Add(typeof(Log), PriceList(1));
                Add(typeof(PinLog), PriceList(2));
                Add(typeof(CypresLog), PriceList(4));
                Add(typeof(CedreLog), PriceList(6));
                Add(typeof(SauleLog), PriceList(8));
                Add(typeof(CheneLog), PriceList(10));
                Add(typeof(EbeneLog), PriceList(12));
                Add(typeof(AcajouLog), PriceList(15));

                Add(typeof(RawRibs));
                Add(typeof(RawBird));
                Add(typeof(RawLambLeg));
            }

            // Choisi de faire une liste pour l'acheteur seulement pour ces ressources, parce que
            // de toute manière ces ressources ne sont pas suposées être achetables chez un NPC. Ça veut dire qu'on
            // ne se servira pas du GoldValue pour décider du prix d'achat / de vente pour ces ressources
            // en particulier.
            public int PriceList(int level)
            {
                switch (level)
                {
                    case 1: return 1;
                    case 2: return 2;
                    case 3: return 3;
                    case 4: return 5;
                    case 5: return 7;
                    case 6: return 9;
                    case 7: return 11;
                    case 8: return 13;
                    case 9: return 15;
                    case 10: return 17;
                    case 11: return 20;
                    case 12: return 25;
                    case 13: return 30;
                    case 14: return 40;
                    case 15: return 50;
                }
                return 0;
            }
        }
    }
}

