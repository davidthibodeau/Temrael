using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles.Vendeurs
{
    public class Cordonnier : BaseVendor
    {
        [Constructable]
        public Cordonnier()
            : base("Cordonnier")
        {
            Name = "Flavien";
        }


        public Cordonnier(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x190; //male

            SetRace(new Capiceen(1002));
            HairItemID = 10209;
            HairHue = 1148;
            FacialHairItemID = 8246;
            FacialHairHue = 1148;
        }

        public override void InitOutfit()
        {
            AddItem(new BottesSombres(2306));
            AddItem(new PantalonsMoulant(1609));
            AddItem(new CeintureBourse(2144));
            AddItem(new ChandailDecore(2307));
            AddItem(new ChemiseAmple(0));
            AddItem(new LeatherGloves(2306));
            AddItem(new CapeCourte(1609));
            AddItem(new PipeCrochu(2306));
        }

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBCordonnerie());
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

    public class SBCordonnerie : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBCordonnerie()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(Shoes), 20, 0x170F, 0)); // 6
                Add(new GenericBuyInfo(typeof(Leather), 20, 0x1081, 0)); // 3
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