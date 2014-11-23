using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles.Vendeurs
{
    public class Couturier : BaseVendor
    {
        [Constructable]
        public Couturier()
            : base("Couturier")
        {
            Name = "Aland Regemorter";
        }


        public Couturier(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x190; //male

            SetRace(new Capiceen(1002));
            HairItemID = 10228;
            HairHue = 2218;
            FacialHairItemID = 0;
            FacialHairHue = 0;
        }

        public override void InitOutfit()
        {
            AddItem(new BottesBoucles(1908));
            AddItem(new PantalonsArmure(1338));
            AddItem(new CorsetLong(1908));
            AddItem(new Foulard(1338));
            AddItem(new FeatheredHat(1333));
            AddItem(new SewingKit(0));

        }

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBCouture());
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

    public class SBCouture : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBCouture()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(Scissors), 20, 0xF9F, 0)); // 3
                Add(new GenericBuyInfo(typeof(SewingKit), 20, 0xF9D, 0)); // 6
                Add(new GenericBuyInfo(typeof(BoltOfCloth), 20, 0xF95, 0)); // 51
                Add(new GenericBuyInfo(typeof(DarkYarn), 20, 0xE1D, 0)); // 3
                Add(new GenericBuyInfo(typeof(LightYarnUnraveled), 20, 0xE1F, 0)); // 3
                Add(new GenericBuyInfo(typeof(UncutCloth), 20, 0x1767, 0)); // 3
                Add(new GenericBuyInfo(typeof(Dyes), 20, 0xFA9, 0)); // 6
                Add(new GenericBuyInfo(typeof(LightYarn), 20, 0xE1E, 0)); // 3
                Add(new GenericBuyInfo(typeof(DyeTub), 20, 0xFAB, 0)); // 6
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