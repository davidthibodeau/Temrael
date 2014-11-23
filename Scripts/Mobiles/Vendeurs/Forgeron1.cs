using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles.Vendeurs
{
    public class Forgeron1 : BaseVendor
    {
        [Constructable]
        public Forgeron1()
            : base("Forgeron")
        {
            Name = "Eadwin";
        }


        public Forgeron1(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x190; //male

            SetRace(new Nordique(1002));
            HairItemID = 10222;
            HairHue = 1112;
            FacialHairItemID = 10313;
            FacialHairHue = 1112;
        }

        public override void InitOutfit()
        {
            AddItem(new SmithHammer(0));
            AddItem(new BracerMetal(0));
            AddItem(new VesteCuir(0));
            AddItem(new CeintureNordique(0));
            AddItem(new LeatherBarbareLeggings(0));
            AddItem(new Bottes(2418));


        }

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBForge1());
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

    public class SBForge1 : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBForge1()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(SmithHammer), 20, 0x13E3, 0)); // 6
                Add(new GenericBuyInfo(typeof(FerIngot), 20, 0x1BF2, 0)); // 3
                Add(new GenericBuyInfo(typeof(Tongs), 20, 0xFBB, 0)); // 6
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