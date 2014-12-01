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
                if(ventesAlloues[m] + x > 500)
                    return false;
            }
            catch {}
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
                Add(typeof(FerIngot));
                Add(typeof(CuivreIngot));
                Add(typeof(BronzeIngot));
                Add(typeof(AcierIngot));
                Add(typeof(ArgentIngot));

                Add(typeof(Leather));
                Add(typeof(LupusLeather));
                Add(typeof(NordiqueLeather));
                Add(typeof(ReptilienLeather));
                Add(typeof(DesertiqueLeather));

                Add(typeof(Bone));
                Add(typeof(GobelinBone));
                Add(typeof(NordiqueBone));
                Add(typeof(ReptilienBone));
                Add(typeof(DesertiqueBone));

                Add(typeof(Coquillage));
                Add(typeof(Amber));
                Add(typeof(Citrine));
                Add(typeof(Tourmaline));
                Add(typeof(Amethyst));

                Add(typeof(Log));
                Add(typeof(PinLog));
                Add(typeof(CypresLog));

                Add(typeof(RawRibs));
                Add(typeof(RawBird));
                Add(typeof(RawLambLeg));
                Add(typeof(Feather));
            }
        }
    }
}

