using System;
using Server.Items;

namespace Server.Items
{
    public class CuirasseOrne : BaseArmor
    {
        public override int NiveauAttirail { get { return PlaqueOrne_Niveau; } }

        public override int BasePhysicalResistance { get { return PlaqueOrne_Physique; } }
        public override int BaseContondantResistance { get { return PlaqueOrne_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueOrne_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueOrne_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueOrne_Magique; } }

        public override int InitMinHits { get { return PlaqueOrne_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueOrne_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueOrne_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public CuirasseOrne()
            : base(0x288E)
        {
            Weight = 2.0;
            Name = "Cuirasse Orne";
        }

        public CuirasseOrne(Serial serial)
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
    public class BrassardsOrne : BaseArmor
    {
        public override int NiveauAttirail { get { return PlaqueOrne_Niveau; } }

        public override int BasePhysicalResistance { get { return PlaqueOrne_Physique; } }
        public override int BaseContondantResistance { get { return PlaqueOrne_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueOrne_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueOrne_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueOrne_Magique; } }

        public override int InitMinHits { get { return PlaqueOrne_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueOrne_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueOrne_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public BrassardsOrne()
            : base(0x288F)
        {
            Weight = 2.0;
            Name = "Brassards Ornes";
        }

        public BrassardsOrne(Serial serial)
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
