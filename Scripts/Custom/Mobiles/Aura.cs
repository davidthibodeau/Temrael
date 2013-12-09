using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
    #region IntensityEnum
    public enum AuraIntensity
    {
        Aucune = 0,
        Faible,
        Moderee,
        Forte,
        Surpuissante
    }
    #endregion

    public struct Aura
    {
        #region Variables
        public AlignementA AlignA;
        public AlignementB AlignB;
        public AuraIntensity Intensity;
        #endregion

        #region IsNull
        public bool isNull()
        {
            return Intensity == AuraIntensity.Aucune;
        }
        #endregion

        #region GetDescription
        public string getDescIntensity()
        {
            switch(Intensity)
            {
                case AuraIntensity.Faible: return "Faible";
                case AuraIntensity.Moderee: return "Modérée";
                case AuraIntensity.Forte: return "Forte";
                case AuraIntensity.Surpuissante: return "Surpuissante";
            }
            return "aucune";
        }
        #endregion
    }
}
