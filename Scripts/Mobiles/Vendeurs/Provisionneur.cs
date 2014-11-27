using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles.Vendeurs
{
    public class Provisionneur : BaseVendor
    {
        [Constructable]
        public Provisionneur()
            : base("Provisionneur")
        {
            Name = "Ahmed";
        }


        public Provisionneur(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x190; //male

            SetRace(new Nomade(1042));
            HairItemID = 10204;
            HairHue = 1136;
            FacialHairItemID = 0;
            FacialHairHue = 0;
        }

        public override void InitOutfit()
        {
            AddItem(new TuniquePaysanne(2044));
            AddItem(new Sandals(0));
            AddItem(new PantalonsNomade(2018));
            AddItem(new FloppyHat(2044));
            AddItem(new CeintureBourse(2018));
        }

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBProvisions());
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

    public class SBProvisions : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBProvisions()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {


                Add(new BeverageBuyInfo(typeof(BeverageBottle), BeverageType.Wine, 15, 20, 0x9C7, 0)); // 15  
                Add(new GenericBuyInfo(typeof(Dices), 20, 0xFA7, 0)); // 6
                Add(new GenericBuyInfo(typeof(Chessboard), 20, 0xFA6, 0)); // 9
                Add(new GenericBuyInfo(typeof(CheckerBoard), 20, 0xFA6, 0)); // 9
                Add(new GenericBuyInfo(typeof(Backgammon), 20, 0xE1C, 0)); // 15
                Add(new GenericBuyInfo(typeof(Candle), 20, 0xA28, 0)); // 6
                Add(new GenericBuyInfo(typeof(Arrow), 100, 0xF3F, 0)); // 3
                Add(new GenericBuyInfo(typeof(Bolt), 100, 0x1BFB, 0)); // 3
                Add(new GenericBuyInfo(typeof(Backpack), 20, 0xE75, 0)); // 15
                Add(new GenericBuyInfo(typeof(Pouch), 20, 0xE79, 0)); // 9
                Add(new GenericBuyInfo(typeof(Bag), 20, 0xE76, 0)); // 6
                Add(new GenericBuyInfo(typeof(Torch), 20, 0xF6B, 0)); // 6
                Add(new GenericBuyInfo(typeof(Lantern), 20, 0xA25, 0)); // 6
                Add(new GenericBuyInfo(typeof(WoodenBox), 20, 0x9AA, 0)); // 9
                Add(new GenericBuyInfo(typeof(Kindling), 20, 0xDE1, 0)); // 3
                Add(new GenericBuyInfo(typeof(RedBook), 20, 0xFF1, 0)); // 6
                Add(new GenericBuyInfo(typeof(Bandage), 50, 0xE21, 0)); // 3
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