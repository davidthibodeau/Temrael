using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Combat
{
    public class Vitesse
    {
        public double CalculerVitesse(Mobile atk, double baseTime)
        {
            int vit = atk.Vitesse;

            return baseTime / (1 + vit / 200.0);
        } 
    }
}
