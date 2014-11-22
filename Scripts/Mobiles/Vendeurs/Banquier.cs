using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;
using Server.Engines.Economy;

namespace Server.Mobiles.Vendeurs
{
    public class Banquier : BaseVendor
    {
        [Constructable]
        public Banquier()
            : base("Banquier")
        {
            Name = "Baudry";
        }


        public Banquier(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x190; //male

            SetRace(new Capiceen(1023));
            HairItemID = 8253;
            HairHue = 1144;
            FacialHairItemID = 0;
            FacialHairHue = 0;
        }

        public override void InitOutfit()
        {
            AddItem(new Shoes(2018));
            AddItem(new JartellesBlanches(0));
            AddItem(new PantalonsCourts(2018));
            AddItem(new CeintureBoucle(2055));
            AddItem(new DoubletBouton(2018));
            AddItem(new Chemiselacee(0));
            AddItem(new ChapeauPlume());
        }

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBBanque());
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

    public class SBBanque : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBBanque()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(Scales), 20, 0x1852, 0)); // 15
                Add(new GenericBuyInfo(typeof(ContractOfEmployment), 20, 0x14F0, 0)); // 3000

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