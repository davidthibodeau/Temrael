using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles.Vendeurs
{
    public class VendeurArcs : BaseVendor
    {
        [Constructable]
        public VendeurArcs()
            : base("Vendeur d'arcs")
        {
            Name = "Irmine";
        }


        public VendeurArcs(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x190; //male

            SetRace(new Nordique(1023));
            HairItemID = 11126;
            HairHue = 1515;
            FacialHairItemID = 0;
            FacialHairHue = 0;
        }

        public override void InitOutfit()
        {
            AddItem(new RoublardTunic(0));
            AddItem(new Carquois(0));
            AddItem(new PardessusBarbare(2164));
            AddItem(new CapePoil(2164));
            AddItem(new RoublardLeggings(0));
            AddItem(new Vigne(2168));



        }

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBArcs());
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

    public class SBArcs : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBArcs()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(FletcherTools), 20, 0x1022, 0)); // 6
                Add(new GenericBuyInfo(typeof(Arrow), 20, 0xF3F, 0)); // 3
                Add(new GenericBuyInfo(typeof(Crossbow), 20, 0xF50, 0)); // 21
                Add(new GenericBuyInfo(typeof(Bolt), 20, 0x1BFB, 0)); // 3
                Add(new GenericBuyInfo(typeof(Arc), 20, 0x2D24, 0)); // 21
                Add(new GenericBuyInfo(typeof(ArcheryButte), 20, 0x100A, 0)); // 21
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