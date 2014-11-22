using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Economy
{
    public class PrixNPC
    {
        private const double INFLATION = 1;
        private const double PRIXREVENTE = 0.5;

        // Prix lors de l'achat de l'item venant d'un NPC.
        public static int BuyPrice(Type type)
        {
            object item = Activator.CreateInstance(type);
            if (item is Item)
            {
                return (int)(((Item)item).GoldValue * INFLATION);
            }

            return int.MaxValue; // L'Objet n'a pas de prix setté.
        }

        // Prix lors de la vente d'un item à un NPC.
        public static int SellPrice(Type type)
        {
            object item = Activator.CreateInstance(type);
            if (item is Item)
            {
                if (((Item)item).GoldValue != int.MaxValue)
                {
                    return (int)(((Item)item).GoldValue * INFLATION * PRIXREVENTE);
                }
            }

            return 0; // L'Objet n'a pas de prix setté.
        }
    }
}
