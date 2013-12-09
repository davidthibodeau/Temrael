using System;
using Server.Items;

namespace Server.Items
{
    public class ElfiquePlaqueGorget : BaseArmor
    {
        public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return PlaqueElfique_Gorget; } }
        public override int BaseContondantResistance { get { return PlaqueElfique_Gorget_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueElfique_Gorget_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueElfique_Gorget_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueElfique_Gorget_Magique; } }

        public override int InitMinHits { get { return PlaqueElfique_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueElfique_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueElfique_Gorget_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public ElfiquePlaqueGorget()
            : base(0x2899)
        {
            Weight = 2.0;
            Name = "Gorget Elfique";
        }

        public ElfiquePlaqueGorget(Serial serial)
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
    public class ElfiquePlaqueLeggings : BaseArmor
    {
        public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return PlaqueElfique_Jambieres; } }
        public override int BaseContondantResistance { get { return PlaqueElfique_Jambieres_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueElfique_Jambieres_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueElfique_Jambieres_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueElfique_Jambieres_Magique; } }

        public override int InitMinHits { get { return PlaqueElfique_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueElfique_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueElfique_Jambieres_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public ElfiquePlaqueLeggings()
            : base(0x289A)
        {
            Weight = 2.0;
            Name = "Jambieres Elfiques";
        }

        public ElfiquePlaqueLeggings(Serial serial)
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
    public class ElfiquePlaqueTunic : BaseArmor
    {
        public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return PlaqueElfique_Cuirasse; } }
        public override int BaseContondantResistance { get { return PlaqueElfique_Cuirasse_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueElfique_Cuirasse_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueElfique_Cuirasse_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueElfique_Cuirasse_Magique; } }

        public override int InitMinHits { get { return PlaqueElfique_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueElfique_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueElfique_Cuirasse_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public ElfiquePlaqueTunic()
            : base(0x289B)
        {
            Weight = 2.0;
            Name = "Tunique Elfique";
        }

        public ElfiquePlaqueTunic(Serial serial)
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