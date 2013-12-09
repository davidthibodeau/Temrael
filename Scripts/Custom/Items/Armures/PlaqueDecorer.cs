using System;
using Server.Items;

namespace Server.Items
{
    public class BouclierDecorer : BaseShield
    {
        public override int NiveauAttirail { get { return 6; } }

        public override int BasePhysicalResistance { get { return Bouclier_Def6; } }
        public override int BaseContondantResistance { get { return 0; } }
        public override int BaseTranchantResistance { get { return 0; } }
        public override int BasePerforantResistance { get { return 0; } }
        public override int BaseMagieResistance { get { return 0; } }

        public override int InitMinHits { get { return Bouclier_MinDurabilite6; } }
        public override int InitMaxHits { get { return Bouclier_MaxDurabilite6; } }

        public override int AosStrReq { get { return Bouclier_Force6; } }

        public override int ArmorBase { get { return 30; } }

        [Constructable]
        public BouclierDecorer()
            : base(0x2883)
        {
            Weight = 2.0;
            Name = "Bouclier Decore";
        }

        public BouclierDecorer(Serial serial)
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
    public class CasqueClosDecorer : BaseArmor
    {
        public override int NiveauAttirail { get { return 6; } }

        public override int BasePhysicalResistance { get { return PlaqueDecore_Casque; } }
        public override int BaseContondantResistance { get { return PlaqueDecore_Casque_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueDecore_Casque_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueDecore_Casque_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueDecore_Casque_Magique; } }

        public override int InitMinHits { get { return PlaqueDecore_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueDecore_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueDecore_Casque_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public CasqueClosDecorer()
            : base(0x2882)
        {
            Weight = 2.0;
            Name = "Casque Clos Decore";
        }

        public CasqueClosDecorer(Serial serial)
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
    public class CasqueDecorer : BaseArmor
    {
        public override int NiveauAttirail { get { return 6; } }

        public override int BasePhysicalResistance { get { return PlaqueDecore_Casque; } }
        public override int BaseContondantResistance { get { return PlaqueDecore_Casque_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueDecore_Casque_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueDecore_Casque_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueDecore_Casque_Magique; } }

        public override int InitMinHits { get { return PlaqueDecore_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueDecore_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueDecore_Casque_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public CasqueDecorer()
            : base(0x2884)
        {
            Weight = 2.0;
            Name = "Casque Decore";
        }

        public CasqueDecorer(Serial serial)
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
    public class GorgetDecorer : BaseArmor
    {
        public override int NiveauAttirail { get { return 6; } }

        public override int BasePhysicalResistance { get { return PlaqueDecore_Gorget; } }
        public override int BaseContondantResistance { get { return PlaqueDecore_Gorget_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueDecore_Gorget_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueDecore_Gorget_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueDecore_Gorget_Magique; } }

        public override int InitMinHits { get { return PlaqueDecore_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueDecore_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueDecore_Gorget_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public GorgetDecorer()
            : base(0x2885)
        {
            Weight = 2.0;
            Name = "Gorget Decore";
        }

        public GorgetDecorer(Serial serial)
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
    public class JambieresDecorer : BaseArmor
    {
        public override int NiveauAttirail { get { return 6; } }

        public override int BasePhysicalResistance { get { return PlaqueDecore_Jambieres; } }
        public override int BaseContondantResistance { get { return PlaqueDecore_Jambieres_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueDecore_Jambieres_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueDecore_Jambieres_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueDecore_Jambieres_Magique; } }

        public override int InitMinHits { get { return PlaqueDecore_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueDecore_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueDecore_Jambieres_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public JambieresDecorer()
            : base(0x2886)
        {
            Weight = 2.0;
            Name = "Jambieres Decores";
        }

        public JambieresDecorer(Serial serial)
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
    public class GantsDecorer : BaseArmor
    {
        public override int NiveauAttirail { get { return 6; } }

        public override int BasePhysicalResistance { get { return PlaqueDecore_Gants; } }
        public override int BaseContondantResistance { get { return PlaqueDecore_Gants_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueDecore_Gants_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueDecore_Gants_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueDecore_Gants_Magique; } }

        public override int InitMinHits { get { return PlaqueDecore_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueDecore_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueDecore_Gants_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public GantsDecorer()
            : base(0x2887)
        {
            Weight = 2.0;
            Name = "Gants Decores";
        }

        public GantsDecorer(Serial serial)
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
    public class CuirasseDecorer : BaseArmor
    {
        public override int NiveauAttirail { get { return 6; } }

        public override int BasePhysicalResistance { get { return PlaqueDecore_Cuirasse; } }
        public override int BaseContondantResistance { get { return PlaqueDecore_Cuirasse_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueDecore_Cuirasse_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueDecore_Cuirasse_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueDecore_Cuirasse_Magique; } }

        public override int InitMinHits { get { return PlaqueDecore_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueDecore_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueDecore_Cuirasse_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public CuirasseDecorer()
            : base(0x2888)
        {
            Weight = 2.0;
            Name = "Cuirasse Decore";
        }

        public CuirasseDecorer(Serial serial)
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
    public class BrassardsDecorer : BaseArmor
    {
        public override int NiveauAttirail { get { return 6; } }

        public override int BasePhysicalResistance { get { return PlaqueDecore_Brassards; } }
        public override int BaseContondantResistance { get { return PlaqueDecore_Brassards_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueDecore_Brassards_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueDecore_Brassards_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueDecore_Brassards_Magique; } }

        public override int InitMinHits { get { return PlaqueDecore_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueDecore_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueDecore_Brassards_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public BrassardsDecorer()
            : base(0x2889)
        {
            Weight = 2.0;
            Name = "Brassards Decores";
        }

        public BrassardsDecorer(Serial serial)
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
