using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
    #region Alignements
    public enum AlignementA
    {
        Aucun = 0,
        Loyal, Neutre, Chaotique
    }
    public enum AlignementB
    {
       Aucun = 0, 
       Bon, Neutre, Mauvais
    }
    #endregion

    public class Alignements
    {
        #region GetString
        public static string getString(AlignementA a, AlignementB b)
        {
            if (a == AlignementA.Neutre && b == AlignementB.Neutre)
                return "Neutre";
            else return a.ToString() + " " + b.ToString();
        }
        #endregion
    }
}
