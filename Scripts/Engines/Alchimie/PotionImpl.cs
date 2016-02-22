using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Mobiles;
using Server.Network;
using Server.Items;

/*   Les classes déviant de PotionWrapper contiennent chacun un PotionImpl, qu'ils peuvent donner à d'autres PotionWrappers via les constructeurs.
 * 
 *          //////////////////
 *          // WeaponPotion //-------|
 *          //////////////////       |
 *                                   |
 *                                   |
 *          ////////////////         |       ///////////////
 *          // FoodPotion //---------|----->// PotionImpl //-------> List<BasePotionEffect> ....
 *          ////////////////         |       ///////////////
 *                                   |             ^
 *                                   |             |
 *          ////////////////////     |       ////////////
 *          // BeveragePotion //-----|       // Potion //
 *          ////////////////////             ////////////
 * 
 * 
 * 
 
 * TODO
 * 
    1. Faire en sorte que les composants alchimiques soient pris en mémoire dans la liste avec leur type.
    2. Faire en sorte que la vérification de l'existence des composants alchimiques des types pris en mémoire soient vérifiés juste avant la construction.
 
 */



namespace Server.Engines.Alchimie
{
    public class PotionImpl
    {
        #region Consts et Infos
        // Les gumps, et la construction de nouvelles potions est influencée par cette valeur.
        // Toutefois les potions désérializées ne sont pas affectées par la modification.
        public static readonly int MaxNbEffects = 3;
        public static readonly int NbEffectUnlockIncrement = 40; 
        // Il faut avoir   0,  40, 80 en alchimie pour pouvoir faire
        // des pots à      1,  2,  3 effets.
        public static int NbAvailableEffect(double skillval)
        {
            return (int)(skillval / NbEffectUnlockIncrement) + 1;
        }
        #endregion

        #region Membres

        private double m_PotionStrength;// Valeur allant de 0 à 1, représentant le scaling de la puissance provenant du skill du joueur qui a créé la potion.
        private List<BasePotionEffect> m_EffectsList;
        private List<BaseSynergy> m_SynergyList;

        #region Props
        public double PotionStrength
        {
            get { return m_PotionStrength; }
        }
        public List<BasePotionEffect> EffectsList
        {
            get { return m_EffectsList; }
        }
        public List<BaseSynergy> SynergyList
        {
            get { return m_SynergyList; }
        }
        public double MinSkill { get { return m_EffectsList.Max(r => r.MinSkill); } }
        public double MaxSkill { get { return m_EffectsList.Max(r => r.MaxSkill); } }
        #endregion
        #endregion

        // Generateur de potions pour les besoins joueurs. 
        // S'occupe de vérifier si le joueur peut la créer puis retourne la potion ou null.
        public static PotionImpl TryCreate(ScriptMobile maker, List<BasePotionEffect> list)
        {
            if (maker == null)
                return null;

            if (list.Count <= 0)
            {
                maker.SendMessage("Nombre insuffisant d'ingrédients utilisés.");
                return null;
            }

            foreach (BasePotionEffect effect in list)
            {
                if (effect.MinSkill > maker.Skills[SkillName.Alchimie].Value)
                {
                    maker.SendMessage("L'effet " + effect.Name + " demande " + effect.MinSkill + " en alchimie pour pouvoir être utilisé. ");
                    return null;
                }
            }

            bool found = false;
            foreach (Item item in maker.Backpack.Items)
            {
                if (item is Bottle)
                {
                    maker.Backpack.RemoveItem(item);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                maker.SendMessage("Vous devez avoir une bouteille vide dans votre sac pour pouvoir créer la potion.");
                return null;
            }

            return new PotionImpl(maker.Skills[SkillName.Alchimie].Value, list);
        }

        public void DoAllEffects(ScriptMobile target, double strength)
        {
            target.FixedParticles(0x376A, 9, 32, 5007, EffectLayer.Waist);
            foreach (BasePotionEffect effect in m_EffectsList)
            {
                effect.PutEffect(target, GetScaling(strength));
            }
            foreach (BaseSynergy synergy in m_SynergyList)
            {
                synergy.PutEffect(target, GetScaling(strength));
            }
        }
        private double GetScaling(double initialStrength)
        {
            return initialStrength * m_PotionStrength;
        }

        public void AddEffect(BasePotionEffect effect)
        {
            m_EffectsList.Add(effect);
            PostEffectmodif();
        }

        // This devient la potion modifiée. Le paramètre est "détruit".
        public void Mix(PotionImpl potion)
        {
            m_EffectsList.AddRange(potion.m_EffectsList);
            PostEffectmodif();
        }

        public void PostEffectmodif()
        {

            m_SynergyList = new List<BaseSynergy>();
            foreach (BaseSynergy synergy in BaseSynergy.synergyList)
            {
                if (synergy.MeetsRequirements(m_EffectsList))
                {
                    m_SynergyList.Add(synergy);
                }
            }

            // Important que le retrait des effets soit après la création des synergies.
            List<BasePotionEffect> list = new List<BasePotionEffect>();
            foreach (BasePotionEffect effect1 in m_EffectsList)
            {
                bool ok = true;
                foreach (BasePotionEffect effect2 in list)
                {
                    if (effect1.GetType() == effect2.GetType())
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                    list.Add(effect1);
            }
            m_EffectsList = list;
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write(PotionStrength);

            writer.Write(EffectsList.Count);
            foreach (BasePotionEffect effect in EffectsList)
            {
                effect.Serialize(writer);
            }
        }

        static public PotionImpl Deserialize(GenericReader reader)
        {
            PotionImpl pot = new PotionImpl();

            pot.m_PotionStrength = reader.ReadDouble();

            int count = reader.ReadInt();
            for (int i = 0; i < count; ++i)
            {
                pot.m_EffectsList.Add(BasePotionEffect.Deserialize(reader));
            }

            pot.PostEffectmodif();
            return pot;
        }

        #region Ctors
        private PotionImpl(double makers_skill, List<BasePotionEffect> list)
            : this()
        {
            m_PotionStrength = makers_skill / 100;
            m_EffectsList = list;
            PostEffectmodif();
        }

        public PotionImpl(PotionImpl pot)
        {
            m_PotionStrength = pot.m_PotionStrength;
            m_EffectsList = new List<BasePotionEffect>(pot.m_EffectsList);
        }

        private PotionImpl()
        {
            m_PotionStrength = 0;
            m_EffectsList = new List<BasePotionEffect>();
        }
        #endregion
    }
}
