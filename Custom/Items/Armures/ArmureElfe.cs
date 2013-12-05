using System;
using Server.Items;

namespace Server.Items
{
    public class ElfeHelm : BaseArmor
    {
        public override int NiveauAttirail { get { return 1; } }

        public override int BasePhysicalResistance { get { return Feuille_Casque; } }
        public override int BaseContondantResistance { get { return Feuille_Casque_Contondant; } }
        public override int BaseTranchantResistance { get { return Feuille_Casque_Tranchant; } }
        public override int BasePerforantResistance { get { return Feuille_Casque_Perforant; } }
        public override int BaseMagieResistance { get { return Feuille_Casque_Magique; } }

        public override int InitMinHits { get { return Feuille_MinDurabilite; } }
        public override int InitMaxHits { get { return Feuille_MaxDurabilite; } }

        public override int AosStrReq { get { return Feuille_Casque_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Leather; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularWood; } }

        [Constructable]
        public ElfeHelm()
            : base(0x2FCC)
        {
            Weight = 2.0;
            Name = "Casque de Feuilles";
        }

        public ElfeHelm(Serial serial)
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
    public class ElfeGorget : BaseArmor
    {
        public override int NiveauAttirail { get { return 1; } }

        public override int BasePhysicalResistance { get { return Feuille_Gorget; } }
        public override int BaseContondantResistance { get { return Feuille_Gorget_Contondant; } }
        public override int BaseTranchantResistance { get { return Feuille_Gorget_Tranchant; } }
        public override int BasePerforantResistance { get { return Feuille_Gorget_Perforant; } }
        public override int BaseMagieResistance { get { return Feuille_Gorget_Magique; } }

        public override int InitMinHits { get { return Feuille_MinDurabilite; } }
        public override int InitMaxHits { get { return Feuille_MaxDurabilite; } }

        public override int AosStrReq { get { return Feuille_Gorget_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Leather; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularWood; } }

        [Constructable]
        public ElfeGorget()
            : base(0x2FCE)
        {
            Weight = 2.0;
            Name = "Gorget de Feuilles";
        }

        public ElfeGorget(Serial serial)
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
    public class ElfeArms : BaseArmor
    {
        public override int NiveauAttirail { get { return 1; } }

        public override int BasePhysicalResistance { get { return Feuille_Brassards; } }
        public override int BaseContondantResistance { get { return Feuille_Brassards_Contondant; } }
        public override int BaseTranchantResistance { get { return Feuille_Brassards_Tranchant; } }
        public override int BasePerforantResistance { get { return Feuille_Brassards_Perforant; } }
        public override int BaseMagieResistance { get { return Feuille_Brassards_Magique; } }

        public override int InitMinHits { get { return Feuille_MinDurabilite; } }
        public override int InitMaxHits { get { return Feuille_MaxDurabilite; } }

        public override int AosStrReq { get { return Feuille_Brassards_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Leather; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularWood; } }

        [Constructable]
        public ElfeArms()
            : base(0x2FCA)
        {
            Weight = 2.0;
            Name = "Brassards de Feuilles";
        }

        public ElfeArms(Serial serial)
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
    public class ElfeLeggings : BaseArmor
    {
        public override int NiveauAttirail { get { return 1; } }

        public override int BasePhysicalResistance { get { return Feuille_Jambieres; } }
        public override int BaseContondantResistance { get { return Feuille_Jambieres_Contondant; } }
        public override int BaseTranchantResistance { get { return Feuille_Jambieres_Tranchant; } }
        public override int BasePerforantResistance { get { return Feuille_Jambieres_Perforant; } }
        public override int BaseMagieResistance { get { return Feuille_Jambieres_Magique; } }

        public override int InitMinHits { get { return Feuille_MinDurabilite; } }
        public override int InitMaxHits { get { return Feuille_MaxDurabilite; } }

        public override int AosStrReq { get { return Feuille_Jambieres_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Leather; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularWood; } }

        [Constructable]
        public ElfeLeggings()
            : base(0x2FCD)
        {
            Weight = 2.0;
            Name = "Jambieres de Feuilles";
        }

        public ElfeLeggings(Serial serial)
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
    public class ElfeTunic : BaseArmor
    {
        public override int NiveauAttirail { get { return 1; } }

        public override int BasePhysicalResistance { get { return Feuille_Cuirasse; } }
        public override int BaseContondantResistance { get { return Feuille_Cuirasse_Contondant; } }
        public override int BaseTranchantResistance { get { return Feuille_Cuirasse_Tranchant; } }
        public override int BasePerforantResistance { get { return Feuille_Cuirasse_Perforant; } }
        public override int BaseMagieResistance { get { return Feuille_Cuirasse_Magique; } }

        public override int InitMinHits { get { return Feuille_MinDurabilite; } }
        public override int InitMaxHits { get { return Feuille_MaxDurabilite; } }

        public override int AosStrReq { get { return Feuille_Cuirasse_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Leather; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularWood; } }

        [Constructable]
        public ElfeTunic()
            : base(0x2FCB)
        {
            Weight = 2.0;
            Name = "Tunique de Feuilles";
        }

        public ElfeTunic(Serial serial)
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