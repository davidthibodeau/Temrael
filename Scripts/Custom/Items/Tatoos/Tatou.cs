using System;
using Server.Mobiles;

namespace Server.Items
{
    public abstract class Tatou : Item
    {
        /*public static Tatou CreateByID(int id, int hue)
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
                default: return new GenericTatou(id, hue);
            }
        }*/

        public override bool CanEquip(Mobile m)
        {
            if (m is TMobile)
            {
                TMobile pm = (TMobile)m;
            }

            return base.CanEquip(m);
        }

        public Tatou(int itemID)
            : this(itemID, 0)
        {
        }

        public Tatou(int itemID, int hue)
            : base(itemID)
        {
            LootType = LootType.Blessed;
            Layer = Layer.Unused_xF;
            Hue = hue;
        }

        public Tatou(Serial serial)
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

    public class GenericTatou : Tatou
    {
        [Constructable]
        public GenericTatou(int itemID)
            : this(itemID, 0)
        {
        }

        [Constructable]
        public GenericTatou(int itemID, int hue)
            : base(itemID, hue)
        {
            Name = "Tatoo";
            Movable = false;
            CanBeAltered = false;
        }

        public GenericTatou(Serial serial)
            : base(serial)
        {
        }

        /*public override Item Dupe(int amount)
        {
            return base.Dupe(new GenericTatou(ItemID, Hue), amount);
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