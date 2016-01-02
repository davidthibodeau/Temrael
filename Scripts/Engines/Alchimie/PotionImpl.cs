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
 * */



namespace Server.Engines.Alchimie
{
    public class PotionImpl
    {
        #region Membres
        // Valeur allant de 0 à 1, représentant le scaling de la puissance provenant du skill du joueur qui a créé la potion.
        private double m_PotionStrength;
        public double PotionStrength
        {
            get { return m_PotionStrength; }
        }
        private List<BasePotionEffect> m_EffectsList;
        public List<BasePotionEffect> EffectsList
        {
            get { return m_EffectsList; }
        }
        #endregion

        public double MinSkill { get { return m_EffectsList.Max(r => r.MinSkill); } }
        public double MaxSkill { get { return m_EffectsList.Max(r => r.MaxSkill); } }


        #region Generateur de potions.
        public static PotionImpl Create(ScriptMobile maker, params BasePotionEffect[] list)
        {
            if (maker == null)
                return null;

            foreach (BasePotionEffect effect in list)
            {
                if (effect.MinSkill > maker.Skills[SkillName.Alchimie].Value)
                {
                    return null;
                }
            }

            return new PotionImpl(maker.Skills[SkillName.Alchimie].Value, list);
        }
        #endregion

        public void DoAllEffects(ScriptMobile target, double strength)
        {
            foreach (BasePotionEffect effect in m_EffectsList)
            {
                effect.PutEffect(target, GetScaling(strength));
            }
        }
        private double GetScaling(double initialStrength)
        {
            return initialStrength * m_PotionStrength;
        }

        #region Ctors
        private PotionImpl(double makers_skill, params BasePotionEffect[] list)
            : this()
        {
            m_PotionStrength = makers_skill / 100;

            m_EffectsList = new List<BasePotionEffect>(list);
        }

        public PotionImpl(PotionImpl pot)
        {
            m_PotionStrength = pot.m_PotionStrength;
            m_EffectsList = pot.m_EffectsList;
        }

        private PotionImpl()
        {
            m_PotionStrength = 0;
            m_EffectsList = new List<BasePotionEffect>();
        }
        #endregion

        public void Mix(PotionImpl potion)
        {
            m_EffectsList.AddRange(potion.m_EffectsList);
        }

        public void AddEffect(BasePotionEffect effect)
        {
            m_EffectsList.Add(effect);
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

            return pot;
        }
    }
}
