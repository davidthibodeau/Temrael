using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
    public class HireSailor : BaseHire
    {
        [Constructable]
        public HireSailor()
        {
            SpeechHue = Utility.RandomDyedHue();
            Hue = Utility.RandomSkinHue();

            if (this.Female = Utility.RandomBool())
            {
                Body = 0x191;
                Name = NameList.RandomName("female");
                AddItem(new ShortPants(Utility.RandomNeutralHue()));
            }
            else
            {
                Body = 0x190;
                Name = NameList.RandomName("male");
                AddItem(new ShortPants(Utility.RandomNeutralHue()));
            }
            Title = "the sailot";
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

            SetStr(86);
            SetDex(66);
            SetInt(41);

            SetDamage(10, 23);

            SetSkill(SkillName.Vol, 66.0, 97.5);
            //SetSkill(SkillName.Peacemaking, 65.0, 87.5);
            SetSkill(SkillName.Concentration, 25.0, 47.5);
            SetSkill(SkillName.Soins, 65.0, 87.5);
            SetSkill(SkillName.Tactiques, 65.0, 87.5);
            SetSkill(SkillName.ArmePerforante, 65.0, 87.5);
            SetSkill(SkillName.Parer, 45.0, 60.5);
            SetSkill(SkillName.Crochetage, 65, 87);
            SetSkill(SkillName.Discretion, 65, 87);
            SetSkill(SkillName.Fouille, 65, 87);

            AddItem(new Shoes(Utility.RandomNeutralHue()));
            AddItem(new Scimitar());

            AddItem(new Shirt(Utility.RandomNeutralHue()));


            PackGold(0, 25);
        }
        public override bool ClickTitle { get { return false; } }
        public HireSailor(Serial serial)
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
