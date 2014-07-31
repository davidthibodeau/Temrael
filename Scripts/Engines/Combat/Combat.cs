using System;
using Server.Mobiles;
using Server.Items;
using System.Collections;
using Server.Engines.PartySystem;

namespace Server.Engines.Combat
{
    public class Combat
    {
        private Mobile attaquant;
        private BaseWeapon atkWeapon;
        private double atkvalue;

        private Mobile defenseur;
        private BaseWeapon defWeapon;     
        private double defvalue;

        public Combat(Mobile atk, Mobile def)
        {
            attaquant = atk;
            defenseur = def;

            atkWeapon = attaquant.Weapon as BaseWeapon;
			defWeapon = defenseur.Weapon as BaseWeapon;

            atkvalue = attaquant.Skills[atkWeapon.Skill].Value;
            defvalue = defenseur.Skills[defWeapon.Skill].Value;
        }

        public bool CheckHit()
        {
            double chance = 0;

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

                chance += tatk.GetAptitudeValue(Aptitude.Precision) * 0.04;
            }

            if (defenseur is TMobile)
            {
                TMobile tdef = defenseur as TMobile;

                if (tdef.GetAptitudeValue(Aptitude.Esquive) * 0.02 >= Utility.RandomDouble())
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

        //Precondition: attaquant is TMobile
        public int CheckCriticalStrike(int dmg)
        {
            double chancetoCriticalStrike = 0.02;
            TMobile atk = attaquant as TMobile;

            if (attaquant.Mana < 4)
                return 0;

                chancetoCriticalStrike += atk.GetAptitudeValue(Aptitude.CoupPrecis) * 0.02;

                if(defenseur is BaseCreature)
                    chancetoCriticalStrike += atk.GetAptitudeValue(Aptitude.TueurDeMonstre) * 0.03;
            

            if (chancetoCriticalStrike > Utility.RandomDouble())
            {
                DoCriticalStrike();
                return (int) (dmg * atk.GetAptitudeValue(Aptitude.CoupPuissant) * 0.05);
            }
            return 0;
        }

        //Precondition: attaquant is TMobile
        private void DoCriticalStrike()
        {
            SkillName skill = atkWeapon.Skill;
            TMobile atk = attaquant as TMobile;
            StatType stat = StatType.All;

            if (skill == SkillName.ArmeDistance || skill == SkillName.ArmePerforante /*Ajout->*/ || skill == SkillName.ArmeContondante)
            {
                if (defenseur.Frozen)
                    defenseur.Frozen = false;
                double val = 1 + atk.GetAptitudeValue(Aptitude.CoupPuissant) * 0.5;
                defenseur.Freeze(TimeSpan.FromSeconds(val));

                stat = StatType.Con;
            }
            /*else if (skill == SkillName.ArmeContondante)
            {
                int dmg = (int) atkWeapon.GetAosDamage(attaquant, 0, 0, 0);

                defenseur.Damage(dmg, attaquant);

                stat = StatType.Con;
            }*/
            else if (skill == SkillName.ArmeTranchante || skill == SkillName.ArmeHaste)
            {
                // Attaque rotative. Est-ce qu'elles arrivent a quelque part d'autre?
                Map map = attaquant.Map;
                ArrayList targets = new ArrayList();
                Party party = Engines.PartySystem.Party.Get(attaquant);
                bool inParty = false;

                if (map != null)
                {
                    int tile = atkWeapon.MaxRange;

                    if (0.10 > Utility.RandomDouble())
                        tile++;

                    if (0.60 > Utility.RandomDouble())
                        tile++;

                    /*foreach (Mobile m in attaquant.GetMobilesInRange((int)tile))
                    {
                        if (attaquant != m && attaquant.Party != defenseur.Party)
                            targets.Add(m);
                    }*/

                    foreach (Mobile m in attaquant.GetMobilesInRange((int)tile))
                    {
                        if (attaquant != m)
                        {
                            if (party != null && party.Count > 0)
                            {
                                for (int k = 0; k < party.Members.Count; ++k)
                                {
                                    PartyMemberInfo pmi = (PartyMemberInfo)party.Members[k];
                                    Mobile member = pmi.Mobile;
                                    if (member.Serial == m.Serial)
                                        inParty = true;
                                }
                                if (!inParty)
                                    targets.Add(m);
                            }
                            else
                            {
                                targets.Add(m);
                            }
                        }
                        inParty = false;
                    }


                    for (int i = 0; i < targets.Count; ++i)
                    {
                        Mobile m = (Mobile)targets[i];
                        if (attaquant.HarmfulCheck(m) && CheckHit())
                            atkWeapon.OnHit(attaquant, m);
                        else
                            atkWeapon.OnMiss(attaquant, m);
                    }
                }

                stat = StatType.Str;
            }
            else if (skill == SkillName.ArmePoing)
            {
                 if (attaquant.HarmfulCheck(defenseur) && CheckHit())
                    atkWeapon.OnHit(attaquant, defenseur);
                else
                    atkWeapon.OnMiss(attaquant, defenseur);

                //stat = StatType.Int;
                stat = StatType.Str;
            }


            double scale = 1 + atk.GetAptitudeValue(Aptitude.CoupPuissant) * 0.05;

            attaquant.SendMessage("Vous portez un coup critique!");
            defenseur.AddStatMod(new StatMod(stat, atkWeapon.Serial + "Critical Strike", (int)(-1 * (atkvalue / 5) * scale), TimeSpan.FromSeconds(atkvalue * scale / 2)));
            defenseur.SendMessage("Vous subissez un coup critique!");

            attaquant.PlaySound(284);
        }

        public bool CheckParer() 
        {
            BaseShield shield = defenseur.FindItemOnLayer( Layer.TwoHanded ) as BaseShield;

            double parry = defenseur.Skills[SkillName.Parer].Value;
            double chance = 0;

            if (shield != null)
            {
                chance = parry / 300;
                if (chance < 0)
                    chance = 0;
            }
            else if (!(defenseur.Weapon is Fists) && !(defenseur.Weapon is BaseRanged))
            {
                chance = parry / (defWeapon.Layer == Layer.OneHanded ? 800 : 600);
            }

            if (defenseur.Dex < 70)
                chance = chance * (20 + defenseur.Dex) / 100;

            return defenseur.CheckSkill(SkillName.Parer, chance);
        }
    }
}
