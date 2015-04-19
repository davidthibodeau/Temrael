using Server.Spells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Combat
{
    public class Vitesse
    {
        private Vitesse() { }

        public static readonly Vitesse instance = new Vitesse();

        public double CalculerVitesse(Mobile atk, double baseTime)
        {
             double s = baseTime / (1 + atk.Vitesse / 50.0);

            // Lenteur devrait modifier la props Vitesse directement.
            // Todo: introduire VitesseMod
            if (LenteurSpell.Contains(atk))
                LenteurSpell.GetOnHitEffect(atk, ref s);

            return s;
        } 
    }
}
