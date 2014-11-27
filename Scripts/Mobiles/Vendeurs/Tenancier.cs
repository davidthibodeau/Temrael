using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;
 
namespace Server.Mobiles.Vendeurs
{
    public class Tenancier : BaseVendor
    {
        [Constructable]
        public Tenancier()
            : base("Tenancier")
        {
            Name = "Quildiira Hlaret";
        }


        public Tenancier(Serial serial)
            : base(serial)
        {
        }
 
        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x191; //female
 
            SetRace(new Alfar(2410));
            HairItemID = 10212;
            HairHue = 0;
            FacialHairItemID = 0;
            FacialHairHue = 0;
        }
 
        public override void InitOutfit()
        {
            AddItem(new JupeAmple(2058));
            AddItem(new RobeCourteDrow(2041));
            AddItem(new FoulardNoble(2325));
            AddItem(new ChapeauCourt(2325));
            AddItem(new Bijoux(0));
 
        }
 
        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }
 
        public override void InitSBInfo()
        {
                m_SBInfos.Add( new SBTaverne1() );
        }
 
        public override void Serialize( GenericWriter writer )
        {
                base.Serialize( writer );
 
                writer.Write( (int) 0 ); // version
        }
 
        public override void Deserialize( GenericReader reader )
        {
                base.Deserialize( reader );
 
                int version = reader.ReadInt();
        }
 
    }
 
    public class SBTaverne1 : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();
 
        public SBTaverne1()
        {
        }
 
        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
 
        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new BeverageBuyInfo(typeof(GlassMug), BeverageType.Water, 3, 20, 0x1F91, 0 )); // 3
                Add(new BeverageBuyInfo(typeof(Pitcher), BeverageType.Water, 21, 20, 0x1F9D, 0 )); // 21
                Add(new BeverageBuyInfo(typeof(Jug), BeverageType.Ale, 9, 20, 0x9C8, 0)); // 9
                Add(new BeverageBuyInfo(typeof(Pitcher), BeverageType.Ale, 21, 20, 0x1F95, 0)); // 21
                Add(new BeverageBuyInfo(typeof(GlassMug), BeverageType.Liquor, 3, 20, 0x1F85, 0)); // 3
                Add(new BeverageBuyInfo(typeof(BeverageBottle), BeverageType.Liquor, 15, 20, 0x99B, 0 )); // 15
                Add(new BeverageBuyInfo(typeof(GlassMug), BeverageType.Milk, 3, 20, 0x1F89, 0)); // 3
                Add(new BeverageBuyInfo(typeof(GlassMug), BeverageType.Wine, 3, 20, 0x1F8D, 0)); // 3
                Add(new BeverageBuyInfo(typeof(BeverageBottle), BeverageType.Wine, 15, 20, 0x9C7, 0 )); // 15  
                Add(new BeverageBuyInfo(typeof(Jug), BeverageType.Cider, 9, 20, 0x9C8, 0)); // 9
                Add(new BeverageBuyInfo(typeof(Pitcher), BeverageType.Cider, 21, 20, 0x1F97, 0)); // 21
                Add(new GenericBuyInfo(typeof(Candle), 20, 0xA28, 0)); // 6
                Add(new GenericBuyInfo(typeof(Cake), 20, 0x9E9, 0)); // 3
                Add(new GenericBuyInfo(typeof(CookedBird), 20, 0x9B7, 0)); // 3
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