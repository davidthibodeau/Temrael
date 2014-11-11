using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Mobiles;
using Server.Spells;
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
        SkillsAttributes
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
                            rarete = RareteItem.Rare;
                            chance = 0.30;
                            scale = rand.Next(1, 4);

                        }
                        if (m_ChanceTable[4] > Utility.RandomDouble())
                        {
                            effects.Add(ItemAttributes.Attributes);
                            effects.Add(ItemAttributes.SkillsAttributes);
                            effects.Add(ItemAttributes.ItemAttributes);
                            rarete = RareteItem.Legendaire;
                            chance = 0.30;
                            repeat = rand.Next(1, 3);
                            scale = rand.Next(1, 5);
                        }
                    }
                    break;
            }

            item.Rarete = rarete;
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
                            rarete = RareteItem.Rare;
                            chance = 0.30;
                            scale = rand.Next(15, 45);

                        }
                        if (m_ChanceTable[4] > Utility.RandomDouble())
                        {
                            effects.Add(ItemAttributes.Attributes);
                            effects.Add(ItemAttributes.SkillsAttributes);
                            effects.Add(ItemAttributes.ItemAttributes);
                            rarete = RareteItem.Legendaire;
                            chance = 0.15;
                            repeat = rand.Next(1, 3);
                            scale = rand.Next(30, 65);
                        }
                    }
                    break;
            }

            item.Rarete = rarete;
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
                            rarete = RareteItem.Rare;
                            chance = 0.30;
                            scale = rand.Next(15, 45);

                        }
                        if (m_ChanceTable[4] > Utility.RandomDouble())
                        {
                            effects.Add(ItemAttributes.Attributes);
                            effects.Add(ItemAttributes.SkillsAttributes);
                            effects.Add(ItemAttributes.ItemAttributes);
                            rarete = RareteItem.Legendaire;
                            chance = 0.15;
                            repeat = rand.Next(1, 3);
                            scale = rand.Next(30, 65);
                        }
                    }
                    break;
            }

            item.Rarete = rarete;
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
                            rarete = RareteItem.Rare;
                            chance = 0.30;
                            scale = rand.Next(15, 45);

                        }
                        if (m_ChanceTable[4] > Utility.RandomDouble())
                        {
                            effects.Add(ItemAttributes.Attributes);
                            effects.Add(ItemAttributes.SkillsAttributes);
                            effects.Add(ItemAttributes.ItemAttributes);
                            rarete = RareteItem.Legendaire;
                            chance = 0.15;
                            repeat = rand.Next(1, 3);
                            scale = rand.Next(30, 65);
                        }
                    }
                    break;
            }

            item.Rarete = rarete;
        }
    }
}