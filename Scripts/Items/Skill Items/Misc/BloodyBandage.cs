using System;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Gumps;

namespace Server.Items
{
    public class BloodyBandage : Item, IDyable
    {
        public virtual bool RequireFreeHand { get { return true; } }

        public static bool HasFreeHand(Mobile m)
        {
            Item handOne = m.FindItemOnLayer(Layer.OneHanded);
            Item handTwo = m.FindItemOnLayer(Layer.TwoHanded);

            if (handTwo is BaseWeapon)
                handOne = handTwo;

            return (handOne == null && handTwo == null);
        }

        [Constructable]
        public BloodyBandage()
            : this(1)
        {
        }

        [Constructable]
        public BloodyBandage(int amount)
            : base(0xE20)
        {
            Stackable = true;
            Weight = 0.1;
            Amount = amount;
            Name = "bandage ensanglanté";
        }

        public BloodyBandage(Serial serial)
            : base(serial)
        {
        }

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            //Hue = sender.DyedHue;

            return true;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            Weight = 0.1;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!HasFreeHand(from))
            {
                from.SendMessage("Vous devez avoir les mains libre pour pouvoir soigner.");
                return;
            }

            else if (from.InRange(GetWorldLocation(), 2))
            {
                from.RevealingAction();

                from.SendLocalizedMessage(500948); // Who will you use the bandages on?

                from.Target = new InternalTarget(this);
            }
            else
            {
                from.SendLocalizedMessage(500295); // You are too far away to do that.
            }
        }

        /*public override Item Dupe(int amount)
        {
            return base.Dupe(new BloodyBandage(), amount);
        }*/

        private class InternalTarget : Target
        {
            private BloodyBandage m_Bandage;

            public InternalTarget(BloodyBandage bandage)
                : base(1, true, TargetFlags.None)
            {
                m_Bandage = bandage;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (m_Bandage.Deleted)
                    return;

                else if (targeted is LandTarget)
                {
                    int tileID = ((LandTarget)targeted).TileID;
                    PlayerMobile player = from as PlayerMobile;

                    bool contains = false;

                    for (int i = 0; !contains && i < m_WaterTiles.Length; i += 2)
                        contains = (tileID >= m_WaterTiles[i] && tileID <= m_WaterTiles[i + 1]);

                    if (contains)
                    {
                        m_Bandage.Consume();
                        from.AddToBackpack(new Bandage());

                        player.PlaySound(1444);
                    }
                }

                else if (targeted is StaticTarget)
                {
                    int itemID = ((StaticTarget)targeted).ItemID;
                    PlayerMobile player = from as PlayerMobile;

                    bool contains = false;

                    for (int i = 0; !contains && i < m_WaterStaticTiles.Length; i += 2)
                        contains = (itemID >= m_WaterStaticTiles[i] && itemID <= m_WaterStaticTiles[i + 1]);

                    if (contains)
                    {
                        m_Bandage.Consume();
                        from.AddToBackpack(new Bandage());

                        player.PlaySound(1444);
                    }
                }
            }
        }

        private static int[] m_WaterTiles = new int[]
			{
				0xA8, 0xAB,
				0x136, 0x137,
			};

        private static int[] m_WaterStaticTiles = new int[]
			{
				0x1796, 0x17B2,         
				0x346E, 0x3485,
				0x3490, 0x34AB,
				0x34B5, 0x34D5,
				0x34ED, 0x3530,
				0x3B63, 0x3B7F,
				0x1559, 0x1559,
				0x1796, 0x17B2,
				0x1FA3, 0x1FCA,
                0x1FC7, 0x2694, 
                0x25E3,  
			};
    }
}