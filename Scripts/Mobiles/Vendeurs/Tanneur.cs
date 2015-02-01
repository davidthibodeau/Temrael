using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles.Vendeurs
{
    public class Tanneur : BaseVendor
    {
        [Constructable]
        public Tanneur()
            : base("Tanneur")
        {
            Name = "Eorane";
        }


        public Tanneur(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x190; //male

            SetRace(new Elfe(1023));
            HairItemID = 10212;
            HairHue = 1149;
            FacialHairItemID = 0;
            FacialHairHue = 0;
        }

        public override void InitOutfit()
        {
            AddItem(new ThighBoots(2164));
            AddItem(new LeatherChest(2164));
            AddItem(new LeatherLegs(2170));
            AddItem(new LeatherArms(2170));
            AddItem(new LeatherGloves(2165));
            AddItem(new LeatherGorget(2165));
            AddItem(new CapeVoyage(1445));
            AddItem(new FourreauEpee(0));

            Bandana b = new Bandana(1442);
            b.Layer = Layer.Bracelet;
            AddItem(b); // Il faudrait changer le layer pour Bracelet
        }

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBTannage());
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

    public class SBTannage : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBTannage()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {

                Add(new GenericBuyInfo(typeof(LeatherArms), 20, 0x13CD, 0)); // 9
                Add(new GenericBuyInfo(typeof(LeatherCap), 20, 0x1DB9, 0)); // 9
                Add(new GenericBuyInfo(typeof(LeatherGloves), 20, 0x13C6, 0)); // 9
                Add(new GenericBuyInfo(typeof(LeatherGorget), 20, 0x13C7, 0)); // 9
                Add(new GenericBuyInfo(typeof(Hides), 20, 0x1079, 0)); // 3
                Add(new GenericBuyInfo(typeof(LeatherLegs), 20, 0x13CB, 0)); // 15
                Add(new GenericBuyInfo(typeof(LeatherChest), 20, 0x13CC, 0)); // 21
                Add(new GenericBuyInfo(typeof(BoneLeatherSewingKit), 20, 0xE1F, 0)); // 6
                Add(new GenericBuyInfo(typeof(MediumStretchedHideSouthDeed), 20, 0x14F0, 0)); // 33
                Add(new GenericBuyInfo(typeof(MediumStretchedHideEastDeed), 20, 0x14F0, 0)); // 33
                Add(new GenericBuyInfo(typeof(SmallStretchedHideSouthDeed), 20, 0x14F0, 0)); // 27
                Add(new GenericBuyInfo(typeof(SmallStretchedHideEastDeed), 20, 0x14F0, 0)); // 27
                //Add(new GenericBuyInfo(typeof(FourrureClaire), 20, 0x11F6, 0)); // 21
                //Add(new GenericBuyInfo(typeof(FourrureSombre), 20, 0x11F5, 0)); // 21
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