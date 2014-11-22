using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles.Vendeurs
{
    public class Fossoyeur : BaseVendor
    {
        [Constructable]
        public Fossoyeur()
            : base("Fossoyeur")
        {
            Name = "Wilfried";
        }


        public Fossoyeur(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x190; //male

            SetRace(new Capiceen(1013));
            HairItemID = 8251;
            HairHue = 1145;
            FacialHairItemID = 8254;
            FacialHairHue = 1145;
        }

        public override void InitOutfit()
        {
            AddItem(new Shoes(0));
            AddItem(new PantalonsCuir(2044));
            AddItem(new VesteLourde(1109));
            AddItem(new ChemiseReligieuse(2168));
            AddItem(new ChapeauMelon(1109));

        }

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBServiceFuneraire());
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

    public class SBServiceFuneraire : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBServiceFuneraire()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(GraveDust), 20, 0x9C9, 0)); // 3
                //Add(new GenericBuyInfo(typeof(UrneBleue), 20, 0x1609, 0)); // 27
                //Add(new GenericBuyInfo(typeof(UrneBlanche), 20, 0x979, 0)); // 45
                //Add(new GenericBuyInfo(typeof(UrneGrise), 20, 0xEC3, 0)); // 15
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