using Server.Items;
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
                int i = SellResource(type);
                if (i != -1)
                {
                    return (int)(i * INFLATION);
                }
                if (((Item)item).GoldValue != int.MaxValue)
                {
                    return (int)(((Item)item).GoldValue * INFLATION * PRIXREVENTE);
                }
            }

            return 0; // L'Objet n'a pas de prix setté.
        }

        public static int SellResource(Type type)
        {
            object item = Activator.CreateInstance(type);

            if (item is BaseIngot)
            {
                BaseIngot ing = item as BaseIngot;

                switch (ing.Resource)
                {
                    case CraftResource.Fer: return 1;
                    case CraftResource.Cuivre: return 2;
                    case CraftResource.Bronze: return 3;
                    case CraftResource.Acier: return 5;
                    case CraftResource.Argent: return 7;
                }
            }

            if (item is BaseLeather)
            {
                BaseLeather leath = item as BaseLeather;

                switch (leath.Resource)
                {
                    case CraftResource.RegularLeather: return 1;
                    case CraftResource.LupusLeather: return 2;
                    case CraftResource.NordiqueLeather: return 3;
                    case CraftResource.ReptilienLeather: return 5;
                    case CraftResource.DesertiqueLeather: return 7;
                }
            }

            if (item is BaseLog)
            {
                BaseLog board = item as BaseLog;

                switch (board.Resource)
                {
                    case CraftResource.RegularWood: return 1;
                    case CraftResource.PinWood: return 2;
                    case CraftResource.CypresWood: return 5;
                }
            }

            if (item is BaseGem)
            {
                if (item is Coquillage)
                    return 1;
                if (item is Amber)
                    return 2;
                if (item is Citrine)
                    return 3;
                if (item is Tourmaline)
                    return 5;
                if (item is Amethyst)
                    return 7;
            }

            return -1;
        }
    }
}
