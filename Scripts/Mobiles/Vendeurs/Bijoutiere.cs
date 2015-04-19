using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles.Vendeurs
{
    public class Bijoutiere : BaseVendor
    {
        [Constructable]
        public Bijoutiere()
            : base("Bijoutiere")
        {
            Name = "Jhalee";
        }


        public Bijoutiere(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x191; //female

            SetRace(new Alfar(2412));
            HairItemID = 10210;
            HairHue = 0;
            FacialHairItemID = 0;
            FacialHairHue = 0;
        }

        public override void InitOutfit()
        {
            AddItem(new Shoes(2018));
            AddItem(new PantalonsNomade(2328));
            AddItem(new RobeElfeNoir(2393));
            AddItem(new CapeColLong(2397));
            AddItem(new Bijoux(0));
            AddItem(new Diaphene(0));

        }

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBBijoux());
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

    public class SBBijoux : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBBijoux()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(BracerMetal), 20, 0x2686, 0)); // 9
                Add(new GenericBuyInfo(typeof(ColierCoquillages), 20, 0x3171, 0)); // 9
                Add(new GenericBuyInfo(typeof(Coquillage), 20, 0xFC7, 0)); // 3
                Add(new GenericBuyInfo(typeof(Amber), 20, 0xF25, 0)); // 6
                Add(new GenericBuyInfo(typeof(JewelcrafterTool), 20, 0x1EBC, 0)); // 6
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