using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Spells.TechniquesCombat
{
    // Petite classe qui permettra de faciliter l'ajout de scalings sur les techniques, si on le veut.
    public abstract class BaseTechnique
    {
        protected static bool CheckMana(Mobile caster, int ManaCost)
        {
            if (caster.Mana >= ManaCost)
            {
                caster.Mana -= ManaCost;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
