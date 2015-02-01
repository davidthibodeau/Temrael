using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles.Vendeurs
{
    public class Boucher : BaseVendor
    {
        [Constructable]
        public Boucher()
            : base("Boucher")
        {
            Name = "Kush";
        }


        public Boucher(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x190; //male

            SetRace(new Orcish(1437));
            HairItemID = 1112;
            HairHue = 10213;
            FacialHairItemID = 0;
            FacialHairHue = 0;
        }

        public override void InitOutfit()
        {
            AddItem(new Cleaver(0));
            AddItem(new HalfApron(2112));
            AddItem(new ChandailSombre(0));
            AddItem(new PantalonsDechires(1119));
            AddItem(new BottesLourdes(2165));

        }

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBBoucherie());
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

    public class SBBoucherie : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBBoucherie()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(Ham), 20, 0x9C9, 0)); // 3
                Add(new GenericBuyInfo(typeof(RawLambLeg), 20, 0x1609, 0)); // 3
                Add(new GenericBuyInfo(typeof(Bacon), 20, 0x979, 0)); // 6
                Add(new GenericBuyInfo(typeof(Cleaver), 20, 0xEC3, 0)); // 6
                Add(new GenericBuyInfo(typeof(Sausage), 20, 0x9C0, 0)); // 3
                Add(new GenericBuyInfo(typeof(RawBird), 20, 0x9B9, 0)); // 3
                Add(new GenericBuyInfo(typeof(RawChickenLeg), 20, 0x1607, 0)); // 3
                Add(new GenericBuyInfo(typeof(RawRibs), 20, 0x9F1, 0)); // 3
                Add(new GenericBuyInfo(typeof(ButcherKnife), 20, 0x13F6, 0)); // 6
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