using System;
using Server.Items;

namespace Server.Items
{
    public class ScalemailArms : BaseArmor
    {
        public override int NiveauAttirail { get { return 5; } }

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

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Ringmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularScales; } }

        [Constructable]
        public ScalemailArms()
            : base(0x2307)
        {
            Weight = 2.0;
            Name = "Brassards d'Anneaux d'Écailles";
        }

        public ScalemailArms(Serial serial)
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
    public class ScalemailLeggings : BaseArmor
    {
        public override int NiveauAttirail { get { return 5; } }

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

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Ringmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularScales; } }

        [Constructable]
        public ScalemailLeggings()
            : base(0x2309)
        {
            Weight = 2.0;
            Name = "Jambieres d'Anneaux d'Écailles";
        }

        public ScalemailLeggings(Serial serial)
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
    public class ScalemailTunic : BaseArmor
    {
        public override int NiveauAttirail { get { return 5; } }

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

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Ringmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularScales; } }

        [Constructable]
        public ScalemailTunic()
            : base(0x2308)
        {
            Weight = 2.0;
            Name = "Tunique d'Anneaux d'Écailles";
        }

        public ScalemailTunic(Serial serial)
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