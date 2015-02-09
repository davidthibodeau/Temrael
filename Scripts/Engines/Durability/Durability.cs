using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Mobiles;
using Server.Items;

namespace Server.Engines.Durability
{
    public static class DurabilityHandler
    {
        private const double ChancePerteDura = 0.3;

        public static void OnPhysAttack(Mobile atk)
        {
            if (atk.Weapon as BaseWeapon != null)
            {
                if (Utility.RandomDouble() < (1.0 / 6.0) * ((double)((BaseWeapon)atk.Weapon).Speed / (double)BaseWeapon.MaxWeaponSpeed * ChancePerteDura))
                {
                    ((BaseWeapon)atk.Weapon).Durability -= 1;
                }
            }
        }

        public static void OnPhysDamageReceive(Mobile atk, Mobile def)
        {
            if (atk != null)
            {
                if (atk.Weapon != null)
                {
                    if (Utility.RandomDouble() < ((double)((BaseWeapon)atk.Weapon).Speed / (double)BaseWeapon.MaxWeaponSpeed * ChancePerteDura))
                    {
                        ArmorDurabilityLoss(def);
                    }
                }
            }
        }

        public static void OnMagicDamageReceive(Mobile def)
        {
            if (Utility.RandomDouble() < ChancePerteDura)
            {
                ArmorDurabilityLoss(def);
            }
        }

        private static void ArmorDurabilityLoss(Mobile def)
        {
            switch (Utility.Random(6))
            {
                case 0: if (def.HeadArmor as BaseArmor != null) (def.HeadArmor as BaseArmor).Durability -= 1; break;
                case 1: if (def.NeckArmor as BaseArmor != null) (def.NeckArmor as BaseArmor).Durability -= 1; break;
                case 2: if (def.ChestArmor as BaseArmor != null) (def.ChestArmor as BaseArmor).Durability -= 1; break;
                case 3: if (def.ArmsArmor as BaseArmor != null) (def.ArmsArmor as BaseArmor).Durability -= 1; break;
                case 4: if (def.HandArmor as BaseArmor != null) (def.HandArmor as BaseArmor).Durability -= 1; break;
                case 5: if (def.LegsArmor as BaseArmor != null) (def.LegsArmor as BaseArmor).Durability -= 1; break;
                case 6: if (def.ShieldArmor as BaseArmor != null) (def.ShieldArmor as BaseArmor).Durability -= 1; break;
            }
        }
    }
}
