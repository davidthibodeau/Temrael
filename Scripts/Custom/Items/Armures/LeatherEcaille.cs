using System;
using Server.Items;

namespace Server.Items
{
    public class LeatherEcailleGorget : BaseArmor
    {
        //public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return 3; } }
        public override int BaseContondantResistance { get { return 3; } }
        public override int BaseTranchantResistance { get { return 4; } }
        public override int BasePerforantResistance { get { return 2; } }
        public override int BaseMagieResistance { get { return 4; } }

        public override int InitMinHits { get { return 25; } }
        public override int InitMaxHits { get { return 30; } }

        public override int AosStrReq { get { return 55; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Studded; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularScales; } }

        [Constructable]
        public LeatherEcailleGorget()
            : base(0x2D33)
        {
            Weight = 2.0;
            Name = "Gorget d'Écailles";
        }

        public LeatherEcailleGorget(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
    public class LeatherEcailleArms : BaseArmor
    {
        //public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return 3; } }
        public override int BaseContondantResistance { get { return 3; } }
        public override int BaseTranchantResistance { get { return 4; } }
        public override int BasePerforantResistance { get { return 2; } }
        public override int BaseMagieResistance { get { return 4; } }

        public override int InitMinHits { get { return 25; } }
        public override int InitMaxHits { get { return 30; } }

        public override int AosStrReq { get { return 55; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Studded; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularScales; } }

        [Constructable]
        public LeatherEcailleArms()
            : base(0x2D32)
        {
            Weight = 2.0;
            Name = "Brassards d'Écailles";
        }

        public LeatherEcailleArms(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
    public class LeatherEcailleLeggings : BaseArmor
    {
        //public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return 3; } }
        public override int BaseContondantResistance { get { return 3; } }
        public override int BaseTranchantResistance { get { return 4; } }
        public override int BasePerforantResistance { get { return 2; } }
        public override int BaseMagieResistance { get { return 4; } }

        public override int InitMinHits { get { return 25; } }
        public override int InitMaxHits { get { return 30; } }

        public override int AosStrReq { get { return 55; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Studded; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularScales; } }

        [Constructable]
        public LeatherEcailleLeggings()
            : base(0x2D34)
        {
            Weight = 2.0;
            Name = "Jambieres d'Écailles";
        }

        public LeatherEcailleLeggings(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
    public class LeatherEcailleTunic : BaseArmor
    {
        //public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return 3; } }
        public override int BaseContondantResistance { get { return 3; } }
        public override int BaseTranchantResistance { get { return 4; } }
        public override int BasePerforantResistance { get { return 2; } }
        public override int BaseMagieResistance { get { return 4; } }

        public override int InitMinHits { get { return 25; } }
        public override int InitMaxHits { get { return 30; } }

        public override int AosStrReq { get { return 55; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Studded; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularScales; } }

        [Constructable]
        public LeatherEcailleTunic()
            : base(0x2D35)
        {
            Weight = 2.0;
            Name = "Tunique d'Écailles";
        }

        public LeatherEcailleTunic(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}