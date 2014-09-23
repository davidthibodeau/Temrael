﻿using System;
using Server.Items;

namespace Server.Items
{
    public class ElfeHelm : BaseArmor
    {

        public override int BasePhysicalResistance { get { return ArmorFeuilles.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorFeuilles.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorFeuilles.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorFeuilles.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorFeuilles.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorFeuilles.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorFeuilles.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorFeuilles.force_Requise; } }
        public override int AosDexBonus { get { return ArmorFeuilles.malus_Dex; } }

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

        public override int BasePhysicalResistance { get { return ArmorFeuilles.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorFeuilles.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorFeuilles.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorFeuilles.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorFeuilles.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorFeuilles.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorFeuilles.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorFeuilles.force_Requise; } }
        public override int AosDexBonus { get { return ArmorFeuilles.malus_Dex; } }

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

        public override int BasePhysicalResistance { get { return ArmorFeuilles.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorFeuilles.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorFeuilles.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorFeuilles.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorFeuilles.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorFeuilles.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorFeuilles.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorFeuilles.force_Requise; } }
        public override int AosDexReq { get { return ArmorFeuilles.malus_Dex; } }

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

        public override int BasePhysicalResistance { get { return ArmorFeuilles.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorFeuilles.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorFeuilles.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorFeuilles.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorFeuilles.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorFeuilles.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorFeuilles.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorFeuilles.force_Requise; } }
        public override int AosDexBonus { get { return ArmorFeuilles.malus_Dex; } }

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

        public override int BasePhysicalResistance { get { return ArmorFeuilles.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorFeuilles.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorFeuilles.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorFeuilles.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorFeuilles.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorFeuilles.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorFeuilles.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorFeuilles.force_Requise; } }
        public override int AosDexBonus { get { return ArmorFeuilles.malus_Dex; } }

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