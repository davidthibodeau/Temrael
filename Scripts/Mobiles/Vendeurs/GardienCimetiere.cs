using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles.Vendeurs
{
    public class GardienCimetiere : BaseVendor
    {
        [Constructable]
        public GardienCimetiere()
            : base("GardienCimetiere")
        {
            Name = "Relonor";
        }


        public GardienCimetiere(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x190; //male

            SetRace(new Alfar(1908));
            HairItemID = 10212;
            HairHue = 0;
            FacialHairItemID = 10204;
            FacialHairHue = 0;
        }

        public override void InitOutfit()
        {
            AddItem(new Shoes(1107));
            AddItem(new JupeLongue(0));
            AddItem(new TogeDrow(2041));
            AddItem(new CapeDecore(1109));
            AddItem(new Cagoule(1109));
            AddItem(new BatonOsseux(0));
        }

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBNecromencie());
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

    public class SBNecromencie : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBNecromencie()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(BatWing), 20, 0xF78, 0)); // 3
                Add(new GenericBuyInfo(typeof(NoxCrystal), 20, 0xF8E, 0)); // 3
                Add(new GenericBuyInfo(typeof(GraveDust), 20, 0xF8F, 0)); // 3
                Add(new GenericBuyInfo(typeof(PigIron), 20, 0xF8A, 0)); // 3
                Add(new GenericBuyInfo(typeof(DaemonBlood), 20, 0xF7D, 0)); // 3
                Add(new GenericBuyInfo(typeof(NewSpellbook), 20, 0xEFA, 0)); // 15
                Add(new GenericBuyInfo(typeof(BlankScroll), 20, 0xEF3, 0)); // 3
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