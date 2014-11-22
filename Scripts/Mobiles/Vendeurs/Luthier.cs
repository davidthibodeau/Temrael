using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles.Vendeurs
{
    public class Luthier : BaseVendor
    {
        [Constructable]
        public Luthier()
            : base("Luthier")
        {
            Name = "Rosaline d'Arane";
        }


        public Luthier(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x191; //female

            SetRace(new Capiceen(1002));
            HairItemID = 10399;
            HairHue = 1506;
            FacialHairItemID = 0;
            FacialHairHue = 0;
        }

        public override void InitOutfit()
        {
            AddItem(new JupeAmple(2044));
            AddItem(new CorsetAmple(2325));
            AddItem(new CeintureLongue(2326));
            AddItem(new ColierLargeRubis(0));
            AddItem(new ChapeauNoble(2325));
            AddItem(new GoldRing(1940));
            AddItem(new GoldEarrings(2325));
        }

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBInstrumentsMusique());
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

    public class SBInstrumentsMusique : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBInstrumentsMusique()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(Harp), 20, 0xEB1, 0)); // 21
                Add(new GenericBuyInfo(typeof(LapHarp), 20, 0xEB2, 0)); // 15
                Add(new GenericBuyInfo(typeof(TambourineTassel), 20, 0xE9E, 0)); // 9
                Add(new GenericBuyInfo(typeof(Drums), 20, 0xE9C, 0)); // 9
                Add(new GenericBuyInfo(typeof(BambooFlute), 20, 0x2805, 0)); // 15
                Add(new GenericBuyInfo(typeof(Lute), 20, 0xEB3, 0)); // 15
                //Add(new GenericBuyInfo(typeof(Partitions), 20, 0xEBD, 0)); // 6
                //Add(new GenericBuyInfo(typeof(Lutrin), 20, 0xEAB, 0)); // 21
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