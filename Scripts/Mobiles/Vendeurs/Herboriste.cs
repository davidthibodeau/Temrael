using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles.Vendeurs
{
    public class Herboriste : BaseVendor
    {
        [Constructable]
        public Herboriste()
            : base("Herboriste")
        {
            Name = "Feuille";
        }


        public Herboriste(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x191; //female

            SetRace(new Elfe(1011));
            HairItemID = 8253;
            HairHue = 1433;
            FacialHairItemID = 0;
            FacialHairHue = 0;
        }

        public override void InitOutfit()
        {
            AddItem(new Robe(2008));
            AddItem(new BatonDruide(0));
            AddItem(new Shoes(2164));

        }

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBHerbes());
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

    public class SBHerbes : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBHerbes()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                //Add(new GenericBuyInfo(typeof(PotFleursRouges), 15, 20, 0x3D71, 0));
                //Add(new GenericBuyInfo(typeof(PotFleurBlanche), 9, 20, 0x8FE, 0));
                //Add(new GenericBuyInfo(typeof(ArbreFleursRouges), 21, 20, 0x3D79, 0));
                //Add(new GenericBuyInfo(typeof(FleurSechee), 3, 20, 0xC3B, 0));
                //Add(new GenericBuyInfo(typeof(HerbeSechee), 3, 20, 0xC41, 0));
                //Add(new GenericBuyInfo(typeof(PanierHerbes), 6, 20, 0x194F, 0));
                Add(new GenericBuyInfo(typeof(Garlic), 20, 0xF84, 0)); // 3
                Add(new GenericBuyInfo(typeof(Ginseng), 20, 0xF85, 0)); // 3
                Add(new GenericBuyInfo(typeof(MandrakeRoot), 20, 0xF86, 0)); // 3
                Add(new GenericBuyInfo(typeof(SpidersSilk), 20, 0xF8D, 0)); // 3
                Add(new GenericBuyInfo(typeof(BlackPearl), 20, 0xF7A, 0)); // 3
                Add(new GenericBuyInfo(typeof(Bloodmoss), 20, 0xF7B, 0)); // 3
                Add(new GenericBuyInfo(typeof(SulfurousAsh), 20, 0xF8C, 0)); // 3
                Add(new GenericBuyInfo(typeof(Nightshade), 20, 0xF88, 0)); // 3
                Add(new GenericBuyInfo(typeof(Bottle), 20, 0xF0E, 0)); // 3

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