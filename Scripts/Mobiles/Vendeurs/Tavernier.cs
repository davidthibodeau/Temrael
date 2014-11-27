using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles.Vendeurs
{
    public class Tavernier : BaseVendor
    {
        [Constructable]
        public Tavernier()
            : base("Tavernier")
        {
            Name = "Alpaide";
        }


        public Tavernier(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x191; //female

            SetRace(new Capiceen(1023));
            HairItemID = 10229;
            HairHue = 1507;
            FacialHairItemID = 0;
            FacialHairHue = 0;
        }

        public override void InitOutfit()
        {
            AddItem(new ThighBoots(2164));
            AddItem(new JartellesBlanches(0));
            AddItem(new PantalonsMoulant(2007));
            AddItem(new Ceinture(2380));
            AddItem(new ChemiseAmple(2307));
            AddItem(new TricorneHat(2307));
            AddItem(new GoldEarrings(0));
            AddItem(new GoldRing(0));


        }

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBTaverne2());
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

    public class SBTaverne2 : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBTaverne2()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {

                Add(new BeverageBuyInfo(typeof(GlassMug), BeverageType.Water, 3, 20, 0x1F91, 0)); // 3
                Add(new BeverageBuyInfo(typeof(Pitcher), BeverageType.Water, 21, 20, 0x1F9D, 0)); // 21
                Add(new BeverageBuyInfo(typeof(Jug), BeverageType.Ale, 9, 20, 0x9C8, 0)); // 9
                Add(new BeverageBuyInfo(typeof(Pitcher), BeverageType.Ale, 21, 20, 0x1F95, 0)); // 21
                Add(new BeverageBuyInfo(typeof(GlassMug), BeverageType.Liquor, 3, 20, 0x1F85, 0)); // 3
                Add(new BeverageBuyInfo(typeof(BeverageBottle), BeverageType.Liquor, 15, 20, 0x99B, 0)); // 15
                Add(new BeverageBuyInfo(typeof(GlassMug), BeverageType.Milk, 3, 20, 0x1F89, 0)); // 3
                Add(new BeverageBuyInfo(typeof(GlassMug), BeverageType.Wine, 3, 20, 0x1F8D, 0)); // 3
                Add(new BeverageBuyInfo(typeof(BeverageBottle), BeverageType.Wine, 15, 20, 0x9C7, 0)); // 15  
                Add(new BeverageBuyInfo(typeof(Jug), BeverageType.Cider, 9, 20, 0x9C8, 0)); // 9
                Add(new BeverageBuyInfo(typeof(Pitcher), BeverageType.Cider, 21, 20, 0x1F97, 0)); // 21  
                Add(new GenericBuyInfo(typeof(Dices), 20, 0xFA7, 0)); // 6
                Add(new GenericBuyInfo(typeof(Chessboard), 20, 0xFA6, 0)); // 9
                Add(new GenericBuyInfo(typeof(CheckerBoard), 20, 0xFA6, 0)); // 9
                Add(new GenericBuyInfo(typeof(Backgammon), 20, 0xE1C, 0)); // 15
                Add(new GenericBuyInfo(typeof(Candle), 20, 0xA28, 0)); // 6
                Add(new GenericBuyInfo(typeof(BreadLoaf), 20, 0x103B, 0)); // 3
                Add(new GenericBuyInfo(typeof(CheeseWheel), 20, 0x97E, 0)); // 6
                Add(new GenericBuyInfo(typeof(CookedBird), 20, 0x9B7, 0)); // 3
                Add(new GenericBuyInfo(typeof(LambLeg), 20, 0x160A, 0)); // 3
                Add(new GenericBuyInfo(typeof(Ribs), 20, 0x9F2, 0)); // 6
                Add(new GenericBuyInfo(typeof(ApplePie), 20, 0x1041, 0)); // 3
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