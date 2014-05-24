﻿using System;
using Server.Items;

namespace Server.Items
{
    public class PlaqueChevalierGreaves : BaseArmor
    {
        public override int NiveauAttirail { get { return PlaqueNoble_Niveau; } }

        public override int BasePhysicalResistance { get { return PlaqueNoble_Physique; } }
        public override int BaseContondantResistance { get { return PlaqueNoble_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueNoble_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueNoble_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueNoble_Magique; } }

        public override int InitMinHits { get { return PlaqueNoble_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueNoble_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueNoble_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public PlaqueChevalierGreaves()
            : base(0x2852)
        {
            Weight = 2.0;
            Name = "Brassards Royaux";
        }

        public PlaqueChevalierGreaves(Serial serial)
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
    public class PlaqueChevalierTunic : BaseArmor
    {
        public override int NiveauAttirail { get { return PlaqueNoble_Niveau; } }

        public override int BasePhysicalResistance { get { return PlaqueNoble_Physique; } }
        public override int BaseContondantResistance { get { return PlaqueNoble_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueNoble_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueNoble_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueNoble_Magique; } }

        public override int InitMinHits { get { return PlaqueNoble_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueNoble_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueNoble_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public PlaqueChevalierTunic()
            : base(0x2853)
        {
            Weight = 2.0;
            Name = "Tunique Royale";
        }

        public PlaqueChevalierTunic(Serial serial)
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
    public class PlaqueChevalierHelm : BaseArmor
    {
        public override int NiveauAttirail { get { return PlaqueNoble_Niveau; } }

        public override int BasePhysicalResistance { get { return PlaqueNoble_Physique; } }
        public override int BaseContondantResistance { get { return PlaqueNoble_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueNoble_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueNoble_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueNoble_Magique; } }

        public override int InitMinHits { get { return PlaqueNoble_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueNoble_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueNoble_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public PlaqueChevalierHelm()
            : base(0x2854)
        {
            Weight = 2.0;
            Name = "Casque Royal";
        }

        public PlaqueChevalierHelm(Serial serial)
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
    public class PlaqueChevalierGloves : BaseArmor
    {
        public override int NiveauAttirail { get { return PlaqueNoble_Niveau; } }

        public override int BasePhysicalResistance { get { return PlaqueNoble_Physique; } }
        public override int BaseContondantResistance { get { return PlaqueNoble_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueNoble_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueNoble_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueNoble_Magique; } }

        public override int InitMinHits { get { return PlaqueNoble_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueNoble_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueNoble_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public PlaqueChevalierGloves()
            : base(0x2855)
        {
            Weight = 2.0;
            Name = "Gants Royaux";
        }

        public PlaqueChevalierGloves(Serial serial)
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
    public class PlaqueChevalierGorget : BaseArmor
    {
        public override int NiveauAttirail { get { return PlaqueNoble_Niveau; } }

        public override int BasePhysicalResistance { get { return PlaqueNoble_Physique; } }
        public override int BaseContondantResistance { get { return PlaqueNoble_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueNoble_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueNoble_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueNoble_Magique; } }

        public override int InitMinHits { get { return PlaqueNoble_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueNoble_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueNoble_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public PlaqueChevalierGorget()
            : base(0x2856)
        {
            Weight = 2.0;
            Name = "Gorget Royal";
        }

        public PlaqueChevalierGorget(Serial serial)
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
    public class PlaqueChevalierLeggings : BaseArmor
    {
        public override int NiveauAttirail { get { return PlaqueNoble_Niveau; } }

        public override int BasePhysicalResistance { get { return PlaqueNoble_Physique; } }
        public override int BaseContondantResistance { get { return PlaqueNoble_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueNoble_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueNoble_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueNoble_Magique; } }

        public override int InitMinHits { get { return PlaqueNoble_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueNoble_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueNoble_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public PlaqueChevalierLeggings()
            : base(0x2857)
        {
            Weight = 2.0;
            Name = "Jambieres Royales";
        }

        public PlaqueChevalierLeggings(Serial serial)
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
