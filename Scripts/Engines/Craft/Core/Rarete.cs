using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.Necromancy;
//using Server.Spells.Bushido;
//using Server.Spells.Ninjitsu;
using Server.Factions;
using Server.Engines.Craft;
using System.Collections.Generic;
using Server.ContextMenus;
//using Server.Spells.Spellweaving;

namespace Server.Items
{
    public enum ItemAttributes
    {
        None,
        Attributes,
        ItemAttributes,
        SkillsAttributes,
        TemAttributes
    }

    public class RareteInit
    {
        private static double[] m_ChanceTable = new double[] { 0.501, 0.251, 0.161, 0.021, 0.011 };

        public static void InitItem(Item item, int Quality, Mobile Crafter)
        {
            /*if (item is BaseWeapon)
            {
                InitWeapon((BaseWeapon)item, Quality, Crafter);
            }
            else if (item is BaseArmor)
            {
                InitArmor((BaseArmor)item, Quality, Crafter);
            }
            else if (item is BaseClothing)
            {
                InitClothing((BaseClothing)item, Quality, Crafter);
            }
            else if (item is BaseJewel)
            {
                InitJewel((BaseJewel)item, Quality, Crafter);
            }*/
        }

        private static void InitWeapon(BaseWeapon item, int Quality, Mobile Crafter)
        {
            Random rand = new Random();
            double chance = 0;
            int scale = 0;
            int repeat = 0;
            List<ItemAttributes> effects = new List<ItemAttributes>();
            RareteItem rarete = RareteItem.Normal;

            switch (Quality)
            {
                case (int)WeaponQuality.Low:
                    {
                        switch (m_ChanceTable[0] > Utility.RandomDouble())
                        {
                            case true:
                                effects.Add(ItemAttributes.Attributes);
                                rarete = RareteItem.Mediocre;
                                chance = 0.70;
                                scale = rand.Next(1, 10);
                                break;
                            case false:
                                rarete = RareteItem.Normal;
                                chance = 0;
                                break;
                        }
                        break;
                    }
                case (int)WeaponQuality.Regular:
                    {
                        switch (m_ChanceTable[1] < Utility.RandomDouble())
                        {
                            case true:
                                rarete = RareteItem.Normal;
                                chance = 0;
                                break;
                            case false:
                                effects.Add(ItemAttributes.Attributes);
                                effects.Add(ItemAttributes.SkillsAttributes);
                                rarete = RareteItem.Magique;
                                chance = 0.50;
                                scale = rand.Next(1, 3);
                                break;
                        }
                        break;
                    }
                case (int)WeaponQuality.Exceptional:
                    {
                        if (m_ChanceTable[2] > Utility.RandomDouble())
                        {
                            effects.Add(ItemAttributes.Attributes);
                            effects.Add(ItemAttributes.SkillsAttributes);
                            rarete = RareteItem.Magique;
                            chance = 0.50;
                            scale = rand.Next(1, 3);
                        }
                        if (m_ChanceTable[3] > Utility.RandomDouble())
                        {
                            effects.Add(ItemAttributes.Attributes);
                            effects.Add(ItemAttributes.SkillsAttributes);
                            effects.Add(ItemAttributes.ItemAttributes);
                            effects.Add(ItemAttributes.TemAttributes);
                            rarete = RareteItem.Rare;
                            chance = 0.30;
                            scale = rand.Next(1, 4);

                        }
                        if (m_ChanceTable[4] > Utility.RandomDouble())
                        {
                            effects.Add(ItemAttributes.Attributes);
                            effects.Add(ItemAttributes.SkillsAttributes);
                            effects.Add(ItemAttributes.ItemAttributes);
                            effects.Add(ItemAttributes.TemAttributes);
                            rarete = RareteItem.Legendaire;
                            chance = 0.30;
                            repeat = rand.Next(1, 3);
                            scale = rand.Next(1, 5);
                        }
                    }
                    break;
            }

            item.Rarete = rarete;

            for (int i = 0; i < effects.Count; i++)
            {
                while (repeat >= 0)
                {
                    if (chance > Utility.RandomDouble())
                    {
                        switch (effects[i])
                        {
                            case ItemAttributes.Attributes:
                                switch (rand.Next(0, 21))
                                {
                                    case 0:
                                        item.Attributes.SetValue(0x00000001, scale);
                                        break;
                                    case 1:
                                        item.Attributes.SetValue(0x00000002, scale);
                                        break;
                                    case 2:
                                        item.Attributes.SetValue(0x00000004, scale);
                                        break;
                                    case 3:
                                        item.Attributes.SetValue(0x00000008, scale);
                                        break;
                                    case 4:
                                        item.Attributes.SetValue(0x00000010, scale);
                                        break;
                                    case 5:
                                        item.Attributes.SetValue(0x00000020, scale);
                                        break;
                                    case 6:
                                        item.Attributes.SetValue(0x00000040, scale);
                                        break;
                                    case 7:
                                        item.Attributes.SetValue(0x00000080, scale);
                                        break;
                                    case 8:
                                        item.Attributes.SetValue(0x00000100, scale);
                                        break;
                                    case 9:
                                        item.Attributes.SetValue(0x00000200, scale);
                                        break;
                                    case 10:
                                        item.Attributes.SetValue(0x00000400, scale);
                                        break;
                                    case 11:
                                        item.Attributes.SetValue(0x00000800, scale);
                                        break;
                                    case 12:
                                        item.Attributes.SetValue(0x00001000, scale);
                                        break;
                                    case 13:
                                        item.Attributes.SetValue(0x00002000, scale);
                                        break;
                                    case 14:
                                        item.Attributes.SetValue(0x00004000, scale);
                                        break;
                                    case 15:
                                        item.Attributes.SetValue(0x00008000, scale);
                                        break;
                                    case 16:
                                        item.Attributes.SetValue(0x00010000, scale);
                                        break;
                                    case 17:
                                        item.Attributes.SetValue(0x00020000, scale);
                                        break;
                                    case 18:
                                        item.Attributes.SetValue(0x00040000, scale);
                                        break;
                                    case 19:
                                        item.Attributes.SetValue(0x00080000, scale);
                                        break;
                                    case 20:
                                        item.Attributes.SetValue(0x00200000, scale);
                                        break;
                                    case 21:
                                        item.Attributes.SetValue(0x00400000, scale);
                                        break;
                                }
                                break;
                            case ItemAttributes.SkillsAttributes:
                                item.SkillBonuses.SetValues(0, (SkillName)rand.Next(0, 52), (double)scale);
                                break;
                            case ItemAttributes.ItemAttributes:
                                switch (rand.Next(0, 24))
                                {
                                    case 0:
                                        item.WeaponAttributes.SetValue(0x00000001, scale);
                                        break;
                                    case 1:
                                        item.WeaponAttributes.SetValue(0x00000002, scale);
                                        break;
                                    case 2:
                                        item.WeaponAttributes.SetValue(0x00000004, scale);
                                        break;
                                    case 3:
                                        item.WeaponAttributes.SetValue(0x00000008, scale);
                                        break;
                                    case 4:
                                        item.WeaponAttributes.SetValue(0x00000010, scale);
                                        break;
                                    case 5:
                                        item.WeaponAttributes.SetValue(0x00000020, scale);
                                        break;
                                    case 6:
                                        item.WeaponAttributes.SetValue(0x00000040, scale);
                                        break;
                                    case 7:
                                        item.WeaponAttributes.SetValue(0x00000080, scale);
                                        break;
                                    case 8:
                                        item.WeaponAttributes.SetValue(0x00000100, scale);
                                        break;
                                    case 9:
                                        item.WeaponAttributes.SetValue(0x00000200, scale);
                                        break;
                                    case 10:
                                        item.WeaponAttributes.SetValue(0x00000400, scale);
                                        break;
                                    case 11:
                                        item.WeaponAttributes.SetValue(0x00000800, scale);
                                        break;
                                    case 12:
                                        item.WeaponAttributes.SetValue(0x00001000, scale);
                                        break;
                                    case 13:
                                        item.WeaponAttributes.SetValue(0x00002000, scale);
                                        break;
                                    case 14:
                                        item.WeaponAttributes.SetValue(0x00004000, scale);
                                        break;
                                    case 15:
                                        item.WeaponAttributes.SetValue(0x00008000, scale);
                                        break;
                                    case 16:
                                        item.WeaponAttributes.SetValue(0x00010000, scale);
                                        break;
                                    case 17:
                                        item.WeaponAttributes.SetValue(0x00020000, scale);
                                        break;
                                    case 18:
                                        item.WeaponAttributes.SetValue(0x00040000, scale);
                                        break;
                                    case 19:
                                        item.WeaponAttributes.SetValue(0x00080000, scale);
                                        break;
                                    case 20:
                                        item.WeaponAttributes.SetValue(0x00100000, scale);
                                        break;
                                    case 21:
                                        item.WeaponAttributes.SetValue(0x00200000, scale);
                                        break;
                                    case 22:
                                        item.WeaponAttributes.SetValue(0x00400000, scale);
                                        break;
                                    case 23:
                                        item.WeaponAttributes.SetValue(0x00800000, scale);
                                        break;
                                    case 24:
                                        item.WeaponAttributes.SetValue(0x01000000, scale);
                                        break;
                                }
                                break;
                            case ItemAttributes.TemAttributes:
                                switch (rand.Next(0, 2))
                                {
                                    case 0:
                                        item.TemAttributes.SetValue(0x00000001, scale);
                                        break;
                                    case 1:
                                        item.TemAttributes.SetValue(0x00000002, scale);
                                        break;
                                }
                                break;
                        }
                    }
                    repeat--;
                }
            }
        }

        private static void InitArmor(BaseArmor item, int Quality, Mobile Crafter)
        {
            Random rand = new Random();
            double chance = 0;
            int scale = 0;
            int repeat = 0;
            List<ItemAttributes> effects = new List<ItemAttributes>();
            RareteItem rarete = RareteItem.Normal;

            switch (Quality)
            {
                case (int)WeaponQuality.Low:
                    {
                        switch (m_ChanceTable[0] > Utility.RandomDouble())
                        {
                            case true:
                                effects.Add(ItemAttributes.Attributes);
                                rarete = RareteItem.Mediocre;
                                chance = 0.70;
                                scale = rand.Next(1, 10);
                                break;
                            case false:
                                rarete = RareteItem.Normal;
                                chance = 0;
                                break;
                        }
                        break;
                    }
                case (int)WeaponQuality.Regular:
                    {
                        switch (m_ChanceTable[1] < Utility.RandomDouble())
                        {
                            case true:
                                rarete = RareteItem.Normal;
                                chance = 0;
                                break;
                            case false:
                                effects.Add(ItemAttributes.Attributes);
                                effects.Add(ItemAttributes.SkillsAttributes);
                                rarete = RareteItem.Magique;
                                chance = 0.50;
                                scale = rand.Next(5, 20);
                                break;
                        }
                        break;
                    }
                case (int)WeaponQuality.Exceptional:
                    {
                        if (m_ChanceTable[2] > Utility.RandomDouble())
                        {
                            effects.Add(ItemAttributes.Attributes);
                            effects.Add(ItemAttributes.SkillsAttributes);
                            rarete = RareteItem.Magique;
                            chance = 0.50;
                            scale = rand.Next(5, 20);
                        }
                        if (m_ChanceTable[3] > Utility.RandomDouble())
                        {
                            effects.Add(ItemAttributes.Attributes);
                            effects.Add(ItemAttributes.SkillsAttributes);
                            effects.Add(ItemAttributes.ItemAttributes);
                            effects.Add(ItemAttributes.TemAttributes);
                            rarete = RareteItem.Rare;
                            chance = 0.30;
                            scale = rand.Next(15, 45);

                        }
                        if (m_ChanceTable[4] > Utility.RandomDouble())
                        {
                            effects.Add(ItemAttributes.Attributes);
                            effects.Add(ItemAttributes.SkillsAttributes);
                            effects.Add(ItemAttributes.ItemAttributes);
                            effects.Add(ItemAttributes.TemAttributes);
                            rarete = RareteItem.Legendaire;
                            chance = 0.15;
                            repeat = rand.Next(1, 3);
                            scale = rand.Next(30, 65);
                        }
                    }
                    break;
            }

            item.Rarete = rarete;

            for (int i = 0; i < effects.Count; i++)
            {
                while (repeat >= 0)
                {
                    if (chance > Utility.RandomDouble())
                    {
                        switch (effects[i])
                        {
                            case ItemAttributes.Attributes:
                                switch (rand.Next(0, 21))
                                {
                                    case 0:
                                        item.Attributes.SetValue(0x00000001, scale);
                                        break;
                                    case 1:
                                        item.Attributes.SetValue(0x00000002, scale);
                                        break;
                                    case 2:
                                        item.Attributes.SetValue(0x00000004, scale);
                                        break;
                                    case 3:
                                        item.Attributes.SetValue(0x00000008, scale);
                                        break;
                                    case 4:
                                        item.Attributes.SetValue(0x00000010, scale);
                                        break;
                                    case 5:
                                        item.Attributes.SetValue(0x00000020, scale);
                                        break;
                                    case 6:
                                        item.Attributes.SetValue(0x00000040, scale);
                                        break;
                                    case 7:
                                        item.Attributes.SetValue(0x00000080, scale);
                                        break;
                                    case 8:
                                        item.Attributes.SetValue(0x00000100, scale);
                                        break;
                                    case 9:
                                        item.Attributes.SetValue(0x00000200, scale);
                                        break;
                                    case 10:
                                        item.Attributes.SetValue(0x00000400, scale);
                                        break;
                                    case 11:
                                        item.Attributes.SetValue(0x00000800, scale);
                                        break;
                                    case 12:
                                        item.Attributes.SetValue(0x00001000, scale);
                                        break;
                                    case 13:
                                        item.Attributes.SetValue(0x00002000, scale);
                                        break;
                                    case 14:
                                        item.Attributes.SetValue(0x00004000, scale);
                                        break;
                                    case 15:
                                        item.Attributes.SetValue(0x00008000, scale);
                                        break;
                                    case 16:
                                        item.Attributes.SetValue(0x00010000, scale);
                                        break;
                                    case 17:
                                        item.Attributes.SetValue(0x00020000, scale);
                                        break;
                                    case 18:
                                        item.Attributes.SetValue(0x00040000, scale);
                                        break;
                                    case 19:
                                        item.Attributes.SetValue(0x00080000, scale);
                                        break;
                                    case 20:
                                        item.Attributes.SetValue(0x00200000, scale);
                                        break;
                                    case 21:
                                        item.Attributes.SetValue(0x00400000, scale);
                                        break;
                                }
                                break;
                            case ItemAttributes.SkillsAttributes:
                                item.SkillBonuses.SetValues(0, (SkillName)rand.Next(0, 52), (double)scale);
                                break;
                            case ItemAttributes.ItemAttributes:
                                switch (rand.Next(0, 2))
                                {
                                    case 0:
                                        item.ArmorAttributes.SetValue(0x00000001, (int)(Crafter.Skills.Fignolage.Fixed / 10));
                                        break;
                                    case 1:
                                        item.ArmorAttributes.SetValue(0x00000002, (int)(Crafter.Skills.Fignolage.Fixed / 10));
                                        break;
                                    case 2:
                                        item.ArmorAttributes.SetValue(0x00000008, (int)(Crafter.Skills.Fignolage.Fixed / 10));
                                        break;
                                }
                                break;
                            case ItemAttributes.TemAttributes:
                                switch (rand.Next(0, 2))
                                {
                                    case 0:
                                        item.TemAttributes.SetValue(0x00000001, scale);
                                        break;
                                    case 1:
                                        item.TemAttributes.SetValue(0x00000002, scale);
                                        break;
                                }
                                break;
                        }
                    }
                    repeat--;
                }
            }
        }

        private static void InitClothing(BaseClothing item, int Quality, Mobile Crafter)
        {
            Random rand = new Random();
            double chance = 0;
            int scale = 0;
            int repeat = 0;
            List<ItemAttributes> effects = new List<ItemAttributes>();
            RareteItem rarete = RareteItem.Normal;

            switch (Quality)
            {
                case (int)WeaponQuality.Low:
                    {
                        switch (m_ChanceTable[0] > Utility.RandomDouble())
                        {
                            case true:
                                effects.Add(ItemAttributes.Attributes);
                                rarete = RareteItem.Mediocre;
                                chance = 0.70;
                                scale = rand.Next(1, 10);
                                break;
                            case false:
                                rarete = RareteItem.Normal;
                                chance = 0;
                                break;
                        }
                        break;
                    }
                case (int)WeaponQuality.Regular:
                    {
                        switch (m_ChanceTable[1] < Utility.RandomDouble())
                        {
                            case true:
                                rarete = RareteItem.Normal;
                                chance = 0;
                                break;
                            case false:
                                effects.Add(ItemAttributes.Attributes);
                                effects.Add(ItemAttributes.SkillsAttributes);
                                rarete = RareteItem.Magique;
                                chance = 0.50;
                                scale = rand.Next(5, 20);
                                break;
                        }
                        break;
                    }
                case (int)WeaponQuality.Exceptional:
                    {
                        if (m_ChanceTable[2] > Utility.RandomDouble())
                        {
                            effects.Add(ItemAttributes.Attributes);
                            effects.Add(ItemAttributes.SkillsAttributes);
                            rarete = RareteItem.Magique;
                            chance = 0.50;
                            scale = rand.Next(5, 20);
                        }
                        if (m_ChanceTable[3] > Utility.RandomDouble())
                        {
                            effects.Add(ItemAttributes.Attributes);
                            effects.Add(ItemAttributes.SkillsAttributes);
                            effects.Add(ItemAttributes.ItemAttributes);
                            effects.Add(ItemAttributes.TemAttributes);
                            rarete = RareteItem.Rare;
                            chance = 0.30;
                            scale = rand.Next(15, 45);

                        }
                        if (m_ChanceTable[4] > Utility.RandomDouble())
                        {
                            effects.Add(ItemAttributes.Attributes);
                            effects.Add(ItemAttributes.SkillsAttributes);
                            effects.Add(ItemAttributes.ItemAttributes);
                            effects.Add(ItemAttributes.TemAttributes);
                            rarete = RareteItem.Legendaire;
                            chance = 0.15;
                            repeat = rand.Next(1, 3);
                            scale = rand.Next(30, 65);
                        }
                    }
                    break;
            }

            item.Rarete = rarete;

            for (int i = 0; i < effects.Count; i++)
            {
                while (repeat >= 0)
                {
                    if (chance > Utility.RandomDouble())
                    {
                        switch (effects[i])
                        {
                            case ItemAttributes.Attributes:
                                switch (rand.Next(0, 21))
                                {
                                    case 0:
                                        item.Attributes.SetValue(0x00000001, scale);
                                        break;
                                    case 1:
                                        item.Attributes.SetValue(0x00000002, scale);
                                        break;
                                    case 2:
                                        item.Attributes.SetValue(0x00000004, scale);
                                        break;
                                    case 3:
                                        item.Attributes.SetValue(0x00000008, scale);
                                        break;
                                    case 4:
                                        item.Attributes.SetValue(0x00000010, scale);
                                        break;
                                    case 5:
                                        item.Attributes.SetValue(0x00000020, scale);
                                        break;
                                    case 6:
                                        item.Attributes.SetValue(0x00000040, scale);
                                        break;
                                    case 7:
                                        item.Attributes.SetValue(0x00000080, scale);
                                        break;
                                    case 8:
                                        item.Attributes.SetValue(0x00000100, scale);
                                        break;
                                    case 9:
                                        item.Attributes.SetValue(0x00000200, scale);
                                        break;
                                    case 10:
                                        item.Attributes.SetValue(0x00000400, scale);
                                        break;
                                    case 11:
                                        item.Attributes.SetValue(0x00000800, scale);
                                        break;
                                    case 12:
                                        item.Attributes.SetValue(0x00001000, scale);
                                        break;
                                    case 13:
                                        item.Attributes.SetValue(0x00002000, scale);
                                        break;
                                    case 14:
                                        item.Attributes.SetValue(0x00004000, scale);
                                        break;
                                    case 15:
                                        item.Attributes.SetValue(0x00008000, scale);
                                        break;
                                    case 16:
                                        item.Attributes.SetValue(0x00010000, scale);
                                        break;
                                    case 17:
                                        item.Attributes.SetValue(0x00020000, scale);
                                        break;
                                    case 18:
                                        item.Attributes.SetValue(0x00040000, scale);
                                        break;
                                    case 19:
                                        item.Attributes.SetValue(0x00080000, scale);
                                        break;
                                    case 20:
                                        item.Attributes.SetValue(0x00200000, scale);
                                        break;
                                    case 21:
                                        item.Attributes.SetValue(0x00400000, scale);
                                        break;
                                }
                                break;
                            case ItemAttributes.SkillsAttributes:
                                item.SkillBonuses.SetValues(0, (SkillName)rand.Next(0, 52), (double)scale);
                                break;
                            case ItemAttributes.ItemAttributes:
                                switch (rand.Next(0, 2))
                                {
                                    case 0:
                                        item.ClothingAttributes.SetValue(0x00000001, (int)(Crafter.Skills.Fignolage.Fixed / 10));
                                        break;
                                    case 1:
                                        item.ClothingAttributes.SetValue(0x00000002, (int)(Crafter.Skills.Fignolage.Fixed / 10));
                                        break;
                                    case 2:
                                        item.ClothingAttributes.SetValue(0x00000008, (int)(Crafter.Skills.Fignolage.Fixed / 10));
                                        break;
                                }
                                break;
                            case ItemAttributes.TemAttributes:
                                switch (rand.Next(0, 2))
                                {
                                    case 0:
                                        item.TemAttributes.SetValue(0x00000001, scale);
                                        break;
                                    case 1:
                                        item.TemAttributes.SetValue(0x00000002, scale);
                                        break;
                                }
                                break;
                        }
                    }
                    repeat--;
                }
            }
        }

        private static void InitJewel(BaseJewel item, int Quality, Mobile Crafter)
        {
            Random rand = new Random();
            double chance = 0;
            int scale = 0;
            int repeat = 0;
            List<ItemAttributes> effects = new List<ItemAttributes>();
            RareteItem rarete = RareteItem.Normal;

            switch (Quality)
            {
                case (int)WeaponQuality.Low:
                    {
                        switch (m_ChanceTable[0] > Utility.RandomDouble())
                        {
                            case true:
                                effects.Add(ItemAttributes.Attributes);
                                rarete = RareteItem.Mediocre;
                                chance = 0.70;
                                scale = rand.Next(1, 10);
                                break;
                            case false:
                                rarete = RareteItem.Normal;
                                chance = 0;
                                break;
                        }
                        break;
                    }
                case (int)WeaponQuality.Regular:
                    {
                        switch (m_ChanceTable[1] < Utility.RandomDouble())
                        {
                            case true:
                                rarete = RareteItem.Normal;
                                chance = 0;
                                break;
                            case false:
                                effects.Add(ItemAttributes.Attributes);
                                effects.Add(ItemAttributes.SkillsAttributes);
                                rarete = RareteItem.Magique;
                                chance = 0.50;
                                scale = rand.Next(5, 20);
                                break;
                        }
                        break;
                    }
                case (int)WeaponQuality.Exceptional:
                    {
                        if (m_ChanceTable[2] > Utility.RandomDouble())
                        {
                            effects.Add(ItemAttributes.Attributes);
                            effects.Add(ItemAttributes.SkillsAttributes);
                            rarete = RareteItem.Magique;
                            chance = 0.50;
                            scale = rand.Next(5, 20);
                        }
                        if (m_ChanceTable[3] > Utility.RandomDouble())
                        {
                            effects.Add(ItemAttributes.Attributes);
                            effects.Add(ItemAttributes.SkillsAttributes);
                            effects.Add(ItemAttributes.ItemAttributes);
                            effects.Add(ItemAttributes.TemAttributes);
                            rarete = RareteItem.Rare;
                            chance = 0.30;
                            scale = rand.Next(15, 45);

                        }
                        if (m_ChanceTable[4] > Utility.RandomDouble())
                        {
                            effects.Add(ItemAttributes.Attributes);
                            effects.Add(ItemAttributes.SkillsAttributes);
                            effects.Add(ItemAttributes.ItemAttributes);
                            effects.Add(ItemAttributes.TemAttributes);
                            rarete = RareteItem.Legendaire;
                            chance = 0.15;
                            repeat = rand.Next(1, 3);
                            scale = rand.Next(30, 65);
                        }
                    }
                    break;
            }

            item.Rarete = rarete;

            for (int i = 0; i < effects.Count; i++)
            {
                while (repeat >= 0)
                {
                    if (chance > Utility.RandomDouble())
                    {
                        switch (effects[i])
                        {
                            case ItemAttributes.Attributes:
                                switch (rand.Next(0, 21))
                                {
                                    case 0:
                                        item.Attributes.SetValue(0x00000001, scale);
                                        break;
                                    case 1:
                                        item.Attributes.SetValue(0x00000002, scale);
                                        break;
                                    case 2:
                                        item.Attributes.SetValue(0x00000004, scale);
                                        break;
                                    case 3:
                                        item.Attributes.SetValue(0x00000008, scale);
                                        break;
                                    case 4:
                                        item.Attributes.SetValue(0x00000010, scale);
                                        break;
                                    case 5:
                                        item.Attributes.SetValue(0x00000020, scale);
                                        break;
                                    case 6:
                                        item.Attributes.SetValue(0x00000040, scale);
                                        break;
                                    case 7:
                                        item.Attributes.SetValue(0x00000080, scale);
                                        break;
                                    case 8:
                                        item.Attributes.SetValue(0x00000100, scale);
                                        break;
                                    case 9:
                                        item.Attributes.SetValue(0x00000200, scale);
                                        break;
                                    case 10:
                                        item.Attributes.SetValue(0x00000400, scale);
                                        break;
                                    case 11:
                                        item.Attributes.SetValue(0x00000800, scale);
                                        break;
                                    case 12:
                                        item.Attributes.SetValue(0x00001000, scale);
                                        break;
                                    case 13:
                                        item.Attributes.SetValue(0x00002000, scale);
                                        break;
                                    case 14:
                                        item.Attributes.SetValue(0x00004000, scale);
                                        break;
                                    case 15:
                                        item.Attributes.SetValue(0x00008000, scale);
                                        break;
                                    case 16:
                                        item.Attributes.SetValue(0x00010000, scale);
                                        break;
                                    case 17:
                                        item.Attributes.SetValue(0x00020000, scale);
                                        break;
                                    case 18:
                                        item.Attributes.SetValue(0x00040000, scale);
                                        break;
                                    case 19:
                                        item.Attributes.SetValue(0x00080000, scale);
                                        break;
                                    case 20:
                                        item.Attributes.SetValue(0x00200000, scale);
                                        break;
                                    case 21:
                                        item.Attributes.SetValue(0x00400000, scale);
                                        break;
                                }
                                break;
                            case ItemAttributes.SkillsAttributes:
                                item.SkillBonuses.SetValues(0, (SkillName)rand.Next(0, 52), (double)scale);
                                break;
                            /*case ItemAttributes.ItemAttributes:
                                switch (rand.Next(0, 2))
                                {
                                    case 0:
                                        item.ClothingAttributes.SetValue(0x00000001, (int)(Crafter.Skills.Identification.Fixed / 10));
                                        break;
                                    case 1:
                                        item.ClothingAttributes.SetValue(0x00000002, (int)(Crafter.Skills.Identification.Fixed / 10));
                                        break;
                                    case 2:
                                        item.ClothingAttributes.SetValue(0x00000008, (int)(Crafter.Skills.Identification.Fixed / 10));
                                        break;
                                }
                                break;*/
                            case ItemAttributes.TemAttributes:
                                switch (rand.Next(0, 2))
                                {
                                    case 0:
                                        item.TemAttributes.SetValue(0x00000001, scale);
                                        break;
                                    case 1:
                                        item.TemAttributes.SetValue(0x00000002, scale);
                                        break;
                                }
                                break;
                        }
                    }
                    repeat--;
                }
            }
        }
    }
}