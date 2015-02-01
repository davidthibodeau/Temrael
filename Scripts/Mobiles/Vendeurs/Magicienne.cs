using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles.Vendeurs
{
    public class Magicienne : BaseVendor
    {
        [Constructable]
        public Magicienne()
            : base("Magicienne")
        {
            Name = "Zalla";
        }


        public Magicienne(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x191; //female

            SetRace(new Nain(1052));
            HairItemID = 10197;
            HairHue = 1133;
            FacialHairItemID = 0;
            FacialHairHue = 0;
        }

        public override void InitOutfit()
        {
            AddItem(new TogeSorcier(2346));
            AddItem(new BatonSorcier(0));
            AddItem(new Shoes(2164));
            AddItem(new GoldEarrings(1890));

        }

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBMagie());
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

    public class SBMagie : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBMagie()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(Garlic), 20, 0xF84, 0)); // 3
                Add(new GenericBuyInfo(typeof(Ginseng), 20, 0xF85, 0)); // 3
                Add(new GenericBuyInfo(typeof(MandrakeRoot), 20, 0xF86, 0)); // 3
                Add(new GenericBuyInfo(typeof(SpidersSilk), 20, 0xF8D, 0)); // 3
                Add(new GenericBuyInfo(typeof(BlackPearl), 20, 0xF7A, 0)); // 3
                Add(new GenericBuyInfo(typeof(Bloodmoss), 20, 0xF7B, 0)); // 3
                Add(new GenericBuyInfo(typeof(SulfurousAsh), 20, 0xF8C, 0)); // 3
                Add(new GenericBuyInfo(typeof(Nightshade), 20, 0xF88, 0)); // 3
                Add(new GenericBuyInfo(typeof(NewSpellbook), 20, 0xEFA, 0)); // 60
                Add(new GenericBuyInfo(typeof(BlankScroll), 20, 0xEF3, 0)); // 5
                Add(new GenericBuyInfo(typeof(RecallRune), 20, 0x1F14, 0)); // 6
                Add(new GenericBuyInfo(typeof(ScribesPen), 20, 0xFBF, 0)); // 6
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