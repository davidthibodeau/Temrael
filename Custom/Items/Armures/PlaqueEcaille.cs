using System;
using Server.Items;

namespace Server.Items
{
    public class PlaqueEcailleHelm : BaseArmor
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

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularScales; } }

        [Constructable]
        public PlaqueEcailleHelm()
            : base(0x2D2F)
        {
            Weight = 2.0;
            Name = "Casque de Plaque d'Écailles";
        }

        public PlaqueEcailleHelm(Serial serial)
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
    public class PlaqueEcailleArms : BaseArmor
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

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularScales; } }

        [Constructable]
        public PlaqueEcailleArms()
            : base(0x2D2E)
        {
            Weight = 2.0;
            Name = "Brassards de Plaque d'Écailles";
        }

        public PlaqueEcailleArms(Serial serial)
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
    public class PlaqueEcailleLeggings : BaseArmor
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

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularScales; } }

        [Constructable]
        public PlaqueEcailleLeggings()
            : base(0x2D31)
        {
            Weight = 2.0;
            Name = "Jambieres de Plaque d'Écailles";
        }

        public PlaqueEcailleLeggings(Serial serial)
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
    public class PlaqueEcailleTunic : BaseArmor
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

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularScales; } }

        [Constructable]
        public PlaqueEcailleTunic()
            : base(0x2D30)
        {
            Weight = 2.0;
            Name = "Tunique de Plaque d'Écailles";
        }

        public PlaqueEcailleTunic(Serial serial)
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