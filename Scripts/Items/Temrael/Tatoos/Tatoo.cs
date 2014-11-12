using System;
using Server.Mobiles;

namespace Server.Items
{
    public abstract class Tatoo : Item
    {
        /*public static Tatoo CreateByID(int id, int hue)
        {
            switch (id)
            {
                case 12416: return new Tatoo01(hue);
                case 12417: return new Tatoo02(hue);
                case 12452: return new Tatoo03(hue);
                case 12415: return new Tatoo04(hue);
                case 12414: return new Tatoo05(hue);
                case 12451: return new Tatoo06(hue);
                case 12418: return new Tatoo07(hue);
                case 12412: return new Tatoo08(hue);
                case 12448: return new Tatoo09(hue);
                case 12450: return new Tatoo10(hue);
                case 12410: return new Tatoo11(hue);
                case 12454: return new Tatoo12(hue);
                case 12449: return new Tatoo13(hue);
                case 12411: return new Tatoo14(hue);
                case 12456: return new Tatoo15(hue);
                case 12455: return new Tatoo16(hue);
                case 12413: return new Tatoo17(hue);
                case 12453: return new Tatoo18(hue);
                case 12457: return new Tatoo19(hue);
                default: return new GenericTatoo(id, hue);
            }
        }*/

        public override bool CanEquip(Mobile m)
        {
            if (m is PlayerMobile)
            {
                PlayerMobile pm = (PlayerMobile)m;
            }

            return base.CanEquip(m);
        }

        public Tatoo(int itemID)
            : this(itemID, 0)
        {
        }

        public Tatoo(int itemID, int hue)
            : base(itemID)
        {
            LootType = LootType.Blessed;
            Layer = Layer.Tatoo;
            Hue = hue;
        }

        public Tatoo(Serial serial)
            : base(serial)
        {
        }

        public override bool DisplayLootType { get { return false; } }

        public override bool VerifyMove(Mobile from)
        {
            return (from.AccessLevel >= AccessLevel.Batisseur);
        }

        public override DeathMoveResult OnParentDeath(Mobile parent)
        {
            //Dupe(Amount);

            return DeathMoveResult.MoveToCorpse;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            LootType = LootType.Blessed;

            int version = reader.ReadInt();
        }
    }

    public class GenericTatoo : Tatoo
    {
        [Constructable]
        public GenericTatoo(int itemID)
            : this(itemID, 0)
        {
        }

        [Constructable]
        public GenericTatoo(int itemID, int hue)
            : base(itemID, hue)
        {
            Name = "Tatoo";
            Movable = false;
            CanBeAltered = false;
        }

        public GenericTatoo(Serial serial)
            : base(serial)
        {
        }

        /*public override Item Dupe(int amount)
        {
            return base.Dupe(new GenericTatoo(ItemID, Hue), amount);
        }*/

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}