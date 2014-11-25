using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles.Vendeurs
{
    public class Soigneur : BaseVendor
    {
        [Constructable]
        public Soigneur()
            : base("Soigneur")
        {
            Name = "Joline";
        }


        public Soigneur(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x191; //female

            SetRace(new Elfe(0));
            HairItemID = 8253;
            HairHue = 1433;
            FacialHairItemID = 0;
            FacialHairHue = 0;
        }

        public override void InitOutfit()
        {
            AddItem(new TogeAmple(2074));
            AddItem(new ColierLong(1940));
            AddItem(new Sandals(1940));

        }

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBSoins());
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

    public class SBSoins : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBSoins()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(Bandage), 20, 0xE21, 0)); // 3
                Add(new GenericBuyInfo(typeof(Garlic), 100, 0xF84, 0)); // 3
                Add(new GenericBuyInfo(typeof(Ginseng), 100, 0xF85, 0)); // 3
                Add(new GenericBuyInfo(typeof(MandrakeRoot), 100, 0xF86, 0)); // 3
                Add(new GenericBuyInfo(typeof(SpidersSilk), 50, 0xF8D, 0)); // 3
                Add(new GenericBuyInfo(typeof(Bottle), 20, 0xF0E, 0)); // 3
                //Add(new GenericBuyInfo(typeof(BookOfChivalry), 20, 0x2252, 0)); // 27
                //Add(new GenericBuyInfo(typeof(WashBassin), WashBassin.GoldValue, 20, 0x1008, 0)); // 3
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
            }
        }
    }
}