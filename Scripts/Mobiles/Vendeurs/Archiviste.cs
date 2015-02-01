using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles.Vendeurs
{
    public class Archiviste : BaseVendor
    {
        [Constructable]
        public Archiviste()
            : base("Archiviste")
        {
            Name = "Grégoire";
        }


        public Archiviste(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x190; //male

            SetRace(new Capiceen(1013));
            HairItemID = 10222;
            HairHue = 1103;
            FacialHairItemID = 10309;
            FacialHairHue = 1103;
        }

        public override void InitOutfit()
        {
            AddItem(new TogeAmple(2038));
            AddItem(new NewSpellbook());
            AddItem(new Shoes(1883));
        }

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBLivres());
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

    public class SBLivres : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBLivres()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(BlankScroll), 20, 0xEF3, 0)); // 3
                Add(new GenericBuyInfo(typeof(BrownBook), 20, 0xFEF, 0)); // 6
                Add(new GenericBuyInfo(typeof(TanBook), 20, 0xFF0, 0)); // 6
                Add(new GenericBuyInfo(typeof(BlueBook), 20, 0xFF2, 0)); // 6
                Add(new GenericBuyInfo(typeof(RedBook), 20, 0xFF1, 0)); // 6
                Add(new GenericBuyInfo(typeof(ScribesPen), 20, 0xFBF, 0)); // 6
                //Add(new GenericBuyInfo(typeof(LivreOuvert), 20, 0xFBE, 0)); // 6
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