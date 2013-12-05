using System;
using Server.Items;

namespace Server.Items
{
    public class CasqueGothique : BaseArmor
    {
        public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return PlaqueGothique_Casque; } }
        public override int BaseContondantResistance { get { return PlaqueGothique_Casque_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueGothique_Casque_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueGothique_Casque_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueGothique_Casque_Magique; } }

        public override int InitMinHits { get { return PlaqueGothique_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueGothique_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueGothique_Casque_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public CasqueGothique()
            : base(0x288A)
        {
            Weight = 2.0;
            Name = "Casque Gothique";
        }

        public CasqueGothique(Serial serial)
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
    public class BrassardsGothique : BaseArmor
    {
        public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return PlaqueGothique_Brassards; } }
        public override int BaseContondantResistance { get { return PlaqueGothique_Brassards_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueGothique_Brassards_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueGothique_Brassards_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueGothique_Brassards_Magique; } }

        public override int InitMinHits { get { return PlaqueGothique_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueGothique_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueGothique_Brassards_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public BrassardsGothique()
            : base(0x288B)
        {
            Weight = 2.0;
            Name = "Brassards Gothiques";
        }

        public BrassardsGothique(Serial serial)
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
    public class CuirasseGothique : BaseArmor
    {
        public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return PlaqueGothique_Cuirasse; } }
        public override int BaseContondantResistance { get { return PlaqueGothique_Cuirasse_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueGothique_Cuirasse_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueGothique_Cuirasse_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueGothique_Cuirasse_Magique; } }

        public override int InitMinHits { get { return PlaqueGothique_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueGothique_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueGothique_Cuirasse_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public CuirasseGothique()
            : base(0x288C)
        {
            Weight = 2.0;
            Name = "Cuirasse Gothique";
        }

        public CuirasseGothique(Serial serial)
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
