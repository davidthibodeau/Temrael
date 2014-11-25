using Server.Engines.Races;
using Server.Items;
using System.Collections.Generic;
 
namespace Server.Mobiles.Vendeurs
{
    public class Voleur : BaseVendor
    {
        [Constructable]
        public Voleur()
            : base("Voleur")
        {
            Name = "Dalidah";
        }
 
 
        public Voleur(Serial serial)
            : base(serial)
        {
        }
 
        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x191; //female
 
            SetRace(new Nomade(1145));
            HairItemID = 10204;
            HairHue = 1136;
            FacialHairItemID = 0;
            FacialHairHue = 0;
        }
 
        public override void InitOutfit()
        {
            AddItem(new ChandailVieux(2044));
            AddItem(new Shoes(2044));
            AddItem(new Kilt(2044));
            AddItem(new TurbanAmple(2309));
            AddItem(new SacocheHerboriste(2309));
 
 
 
        }
 
                private List<SBInfo> m_SBInfos = new List<SBInfo>();
                protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }
 
                public override void InitSBInfo()
                {
                        m_SBInfos.Add( new SBVoleur() );
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

    public class SBVoleur : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();
 
        public SBVoleur()
        {
        }
 
        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
 
        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new BeverageBuyInfo(typeof(Jug), BeverageType.Cider, 9, 20, 0x9C8, 0 )); // 9  
                Add(new GenericBuyInfo(typeof(Lockpick), 20, 0x13FC, 0)); // 6
                Add(new GenericBuyInfo(typeof(DisguiseKit), 20, 0x1EBA, 0)); // 6
                Add(new GenericBuyInfo(typeof(SewingKit), 20, 0xF9D, 0)); // 3
                Add(new GenericBuyInfo(typeof(HairDye), 20, 0xEFF, 0)); // 6
                Add(new GenericBuyInfo(typeof(Bag), 20, 0xE76, 0)); // 6
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