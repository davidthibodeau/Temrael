using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;
 
namespace Server.Mobiles.Vendeurs
{
    public class Menuisier : BaseVendor
    {
        [Constructable]
        public Menuisier()
            : base("Menuisier")
        {
            Name = "Menuisier";
        }


        public Menuisier(Serial serial)
            : base(serial)
        {
        }
 
        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x190; //male
 
            SetRace(new Nain(1052));
            HairItemID = 8253;
            HairHue = 1123;
            FacialHairItemID = 10302;
            FacialHairHue = 1123;
        }
 
        public override void InitOutfit()
        {
            AddItem(new BottesLourdes(1877));
            AddItem(new PantalonsCourts(0));
            AddItem(new VestePoil(0));
            AddItem(new PipeCrochu(2045));
 
 
        }
 
        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }
 
        public override void InitSBInfo()
        {
                m_SBInfos.Add( new SBMenuiserie() );
        }
 
        public override void Serialize( GenericWriter writer )
        {
                base.Serialize( writer );
 
                writer.Write( (int) 0 ); // version
        }
 
        public override void Deserialize( GenericReader reader )
        {
                base.Deserialize( reader );
 
                int version = reader.ReadInt();
        }
 
    }
 
    public class SBMenuiserie : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();
 
        public SBMenuiserie()
        {
        }
 
        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
 
        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(Board), 50, 0x1BDA, 0)); // 3
                Add(new GenericBuyInfo(typeof(Froe), 20, 0x10E5, 0)); // 6
                Add(new GenericBuyInfo(typeof(DovetailSaw), 20, 0x1028, 0)); // 6
                Add(new GenericBuyInfo(typeof(Saw), 20, 0x10E7, 0)); // 9
                Add(new GenericBuyInfo(typeof(Nails), 20, 0x102E, 0)); // 3
                Add(new GenericBuyInfo(typeof(Hammer), 20, 0x102A, 0)); // 15
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