using System;
using Server.Items;

namespace Server.Items
{
    public class ElfiqueChaineTunic : BaseArmor
    {
        public override int NiveauAttirail { get { return 4; } }

        public override int BasePhysicalResistance { get { return ChainElfique_Cuirasse; } }
        public override int BaseContondantResistance { get { return ChainElfique_Cuirasse_Contondant; } }
        public override int BaseTranchantResistance { get { return ChainElfique_Cuirasse_Tranchant; } }
        public override int BasePerforantResistance { get { return ChainElfique_Cuirasse_Perforant; } }
        public override int BaseMagieResistance { get { return ChainElfique_Cuirasse_Magique; } }

        public override int InitMinHits { get { return ChainElfique_MinDurabilite; } }
        public override int InitMaxHits { get { return ChainElfique_MaxDurabilite; } }

        public override int AosStrReq { get { return ChainElfique_Cuirasse_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Chainmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public ElfiqueChaineTunic()
            : base(0x2897)
        {
            Weight = 2.0;
            Name = "Tunique Elfique";
        }

        public ElfiqueChaineTunic(Serial serial)
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
    public class ElfiqueChaineLeggings : BaseArmor
    {
        public override int NiveauAttirail { get { return 4; } }

        public override int BasePhysicalResistance { get { return ChainElfique_Jambieres; } }
        public override int BaseContondantResistance { get { return ChainElfique_Jambieres_Contondant; } }
        public override int BaseTranchantResistance { get { return ChainElfique_Jambieres_Tranchant; } }
        public override int BasePerforantResistance { get { return ChainElfique_Jambieres_Perforant; } }
        public override int BaseMagieResistance { get { return ChainElfique_Jambieres_Magique; } }

        public override int InitMinHits { get { return ChainElfique_MinDurabilite; } }
        public override int InitMaxHits { get { return ChainElfique_MaxDurabilite; } }

        public override int AosStrReq { get { return ChainElfique_Jambieres_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Chainmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public ElfiqueChaineLeggings()
            : base(0x2898)
        {
            Weight = 2.0;
            Name = "Jambieres Elfiques";
        }

        public ElfiqueChaineLeggings(Serial serial)
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
