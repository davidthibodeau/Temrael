using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles.Vendeurs
{
    public class Boulanger : BaseVendor
    {
        [Constructable]
        public Boulanger()
            : base("Boulanger")
        {
            Name = "Melba";
        }


        public Boulanger(Serial serial)
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

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBBoulangerie());
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

    public class SBBoulangerie : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBBoulangerie()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(SackFlour), 20, 0x1039, 0)); // 9
                Add(new GenericBuyInfo(typeof(BowlFlour), 20, 0xA1E, 0)); // 3
                Add(new GenericBuyInfo(typeof(ApplePie), 20, 0x1041, 0)); // 6
                Add(new GenericBuyInfo(typeof(Cake), 20, 0x9E9, 0)); // 6
                Add(new GenericBuyInfo(typeof(CheesePizza), 20, 0x1040, 0)); // 6
                Add(new GenericBuyInfo(typeof(FrenchBread), 20, 0x98C, 0)); // 3
                Add(new GenericBuyInfo(typeof(Cookies), 20, 0x160B, 0)); // 6
                Add(new GenericBuyInfo(typeof(BreadLoaf), 20, 0x103B, 0)); // 3
                Add(new GenericBuyInfo(typeof(Muffins), 20, 0x9EB, 0)); // 3
                Add(new GenericBuyInfo(typeof(RollingPin), 20, 0x1043, 0)); // 6
                Add(new GenericBuyInfo(typeof(Skillet), 20, 0x97F, 0)); // 6
                Add(new GenericBuyInfo(typeof(FlourSifter), 20, 0x103E, 0)); // 6
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