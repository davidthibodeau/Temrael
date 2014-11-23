using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles.Vendeurs
{
    public class Artiste : BaseVendor
    {
        [Constructable]
        public Artiste()
            : base("Artiste maudit")
        {
            Name = "Charles";
        }


        public Artiste(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x190; //male

            SetRace(new Capiceen(1002));
            HairItemID = 10227;
            HairHue = 1111;
            FacialHairItemID = 10308;
            FacialHairHue = 1111;
        }

        public override void InitOutfit()
        {
            AddItem(new GoldRing(0));
            AddItem(new ThighBoots(0));
            AddItem(new LeatherLegs(1104));
            AddItem(new Chemiselacee(0));
            AddItem(new FoulardNoble(1636));
            AddItem(new ChapeauNoble(1636));

            PaintsAndBrush p = new PaintsAndBrush();
            p.Layer = Layer.Shirt;
            AddItem(p); // layer shirt
        }

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBArt());
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

    public class SBArt : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBArt()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(PaintsAndBrush), 20, 0xFC1, 0)); // 6
                Add(new GenericBuyInfo(typeof(RuinedPainting), 20, 0xC2C, 0)); // 27
                Add(new BeverageBuyInfo(typeof(BeverageBottle), BeverageType.Wine, 6, 20, 0x9C7, 0 )); // 6 Du vin
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