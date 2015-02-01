using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
    public class HireRanger : BaseHire
    {
        [Constructable]
        public HireRanger()
        {
            SpeechHue = Utility.RandomDyedHue();
            Hue = Utility.RandomSkinHue();

            if (this.Female = Utility.RandomBool())
            {
                Body = 0x191;
                Name = NameList.RandomName("female");
            }
            else
            {
                Body = 0x190;
                Name = NameList.RandomName("male");
                AddItem(new ShortPants(Utility.RandomNeutralHue()));
            }
            Title = "the ranger";
            Item hair = new Item(Utility.RandomList(0x203B, 0x2049, 0x2048, 0x204A));
            hair.Hue = Utility.RandomNeutralHue();
            hair.Layer = Layer.Hair;
            hair.Movable = false;
            AddItem(hair);

            if (Utility.RandomBool() && !this.Female)
            {
                Item beard = new Item(Utility.RandomList(0x203E, 0x203F, 0x2040, 0x2041, 0x204B, 0x204C, 0x204D));

                beard.Hue = hair.Hue;
                beard.Layer = Layer.FacialHair;
                beard.Movable = false;

                AddItem(beard);
            }

            SetStr(91, 91);
            SetDex(76, 76);
            SetInt(61, 61);

            SetDamage(13, 24);

            SetSkill(SkillName.Anatomie, 15, 37);
            SetSkill(SkillName.Parer, 45, 60);
            SetSkill(SkillName.ArmeDistance, 66, 97);
            SetSkill(SkillName.ArtMagique, 62, 62);
            SetSkill(SkillName.Epee, 35, 57);
            SetSkill(SkillName.ArmePerforante, 15, 37);
            SetSkill(SkillName.Tactiques, 65, 87);

            AddItem(new Shoes(Utility.RandomNeutralHue()));
            AddItem(new Shirt());

            // Pick a random sword
            switch (Utility.Random(2))
            {
                //case 0: AddItem(new Longsword()); break;
                case 1: AddItem(new VikingSword()); break;
            }

            PackItem(new Arrow(20));
            PackGold(10, 75);
        }
        public override bool ClickTitle { get { return false; } }
        public HireRanger(Serial serial)
            : base(serial)
        {
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
}
