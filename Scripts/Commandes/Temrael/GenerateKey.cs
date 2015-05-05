using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using Server.Targeting;
using Server.Items;

namespace Server.Commandes.Temrael
{
    class GenerateKey
    {
        public static void Initialize()
        {
            CommandSystem.Register("GenerateNewKey", AccessLevel.Batisseur, new CommandEventHandler(GenerateNewKey_OnCommand));
            CommandSystem.Register("GenerateKeyFor", AccessLevel.Batisseur, new CommandEventHandler(GenerateKeyFor_OnCommand));
        }

        [Usage("GenerateNewKey [amount]")]
        [Description("Permet de créer entre 1 et 10 clefs qui utiliseront un nouveau keyvalue.")]
        public static void GenerateNewKey_OnCommand(CommandEventArgs e)
        {
            ActionLockable i = GenerateNewKey;
            int nbKeys = e.GetInt32(0);

            if (CheckNbKeys(nbKeys))
            {
                e.Mobile.Target = new TargetLockable(e.Mobile, i, nbKeys);
            }
            else
            {
                e.Mobile.SendMessage("Vous ne pouvez créer qu'entre 0 et 10 clefs à la fois.");
            }
        }
        public static bool GenerateNewKey(Mobile from, ILockable item, int nbKeys)
        {
            long newKeyValue = DateTime.Now.Ticks;
            Key key;
            
            item.KeyValue = newKeyValue;

            if (item is BaseDoor)
            {
                BaseDoor door = (BaseDoor)item;

                door.Link.KeyValue = newKeyValue;
            }

            for (int i = 0; i < nbKeys; i++)
            {
                key = new Key(KeyType.Iron);

                key.KeyValue = newKeyValue;

                from.AddToBackpack(key);
            }

            return true;
        }

        [Usage("GenerateKeyFor [amount]")]
        [Description("Permet de créer entre 1 et 10 clefs qui utiliseront l'ancien keyvalue.")]
        public static void GenerateKeyFor_OnCommand(CommandEventArgs e)
        {
            ActionLockable i = GenerateKeyFor;
            int nbKeys = e.GetInt32(0);
            if (CheckNbKeys(nbKeys))
            {
                e.Mobile.Target = new TargetLockable(e.Mobile, i, nbKeys);
            }
            else
            {
                e.Mobile.SendMessage("Vous ne pouvez créer qu'entre 0 et 10 clefs à la fois.");
            }
        }
        public static bool GenerateKeyFor(Mobile from, ILockable item, int nbKeys)
        {
            if (item.KeyValue != 0)
            {
                Key key;

                for (int i = 0; i < nbKeys; i++)
                {
                    key = new Key(KeyType.Iron);

                    key.KeyValue = item.KeyValue;

                    from.AddToBackpack(key);
                }
                return true;
            }
            else
            {
                return false;
            }
        }


        delegate bool ActionLockable(Mobile from, ILockable item, int nbKeys);

        private static bool CheckNbKeys(int nbKeys)
        {
            return (nbKeys > 0 && nbKeys <= 10);
        }

        private class TargetLockable : Target
        {
            Mobile m_from;
            ActionLockable m_d;
            int m_nbKeys = 0;

            public TargetLockable(Mobile from, ActionLockable d, int nbKeys)
                : base(15, false, TargetFlags.None)
            {
                m_from = from;
                m_d = d;
                m_nbKeys = nbKeys;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is ILockable)
                {
                    m_d( m_from, (ILockable)targeted, m_nbKeys );
                }
                else
                {
                    from.SendMessage("Ceci ne peut pas avoir de clef.");
                }
            }
        }
    }
}
