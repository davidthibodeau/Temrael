using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Items
{
    // Juste à recopier ceci, si la classe est en charge d'une CraftResource.
    // Sinon, juste à mettre ce qu'on veut dans les deux fonctions.

    /*
    #region IExtractable
    public string getName
    {
        get{ return CraftResources.GetName(m_Resource); }
    }
    public int getHue
    {
        get { return CraftResources.GetHue(m_Resource); }
    }
    #endregion
    */

    public interface IExtractable
    {
        int getHue{get;}
        string getName{get;}
    }
}
