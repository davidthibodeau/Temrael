using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Combat
{
    public class SequenceCombat
    {
        private Mobile attaquant;
        private Mobile defenseur;


        public SequenceCombat(Mobile atk, Mobile def)
        {
            attaquant = atk;
            defenseur = def;
        }

        public bool CheckHit()
        {
            double chance = 0;

            BaseWeapon atkWeapon = attaquant.Weapon as BaseWeapon;
			BaseWeapon defWeapon = defenseur.Weapon as BaseWeapon;
            double atkvalue = attaquant.Skills[atkWeapon.Skill].Value;
            double defvalue = defenseur.Skills[defWeapon.Skill].Value;
            
            int materiaux = 0;

			switch (atkWeapon.AccuracyLevel )
			{
				case WeaponAccuracyLevel.Accurate:		materiaux += 02; break;
				case WeaponAccuracyLevel.Surpassingly:	materiaux += 04; break;
				case WeaponAccuracyLevel.Eminently:		materiaux += 06; break;
				case WeaponAccuracyLevel.Exceedingly:	materiaux += 08; break;
				case WeaponAccuracyLevel.Supremely:		materiaux += 10; break;
			}

            chance += (atkvalue + 20.0) * (100 + materiaux) / ((defvalue + 20.0) * 200);

            if (atkvalue > defvalue)
                chance += (atkvalue - defvalue) / 200;

            if (attaquant is TMobile)
            {
                TMobile tatk = attaquant as TMobile;
                if (tatk.CheckFatigue(6))
                    return false;

                chance += tatk.GetAptitudeValue(NAptitude.Precision) * 0.04;
            }

            if (defenseur is TMobile)
            {
                TMobile tdef = defenseur as TMobile;

                if (tdef.GetAptitudeValue(NAptitude.Esquive) * 0.02 >= Utility.RandomDouble())
                {
                    tdef.SendMessage("Vous esquivez le coup !");
                    return false;
                }
            }
            if (chance > 1)
                return true;

            if (chance < 0.02)
                chance = 0.02;

            return chance >= Utility.RandomDouble();
        }
    }
}
