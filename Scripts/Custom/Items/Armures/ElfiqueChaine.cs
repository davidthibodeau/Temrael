using System;
using Server.Items;

namespace Server.Items
{
    public class ElfiqueChaineTunic : BaseArmor
    {
        //public override int NiveauAttirail { get { return ChainElfique_Niveau; } }

        public override int BasePhysicalResistance { get { return ArmorChainElf.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorChainElf.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorChainElf.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorChainElf.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorChainElf.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorChainElf.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorChainElf.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorChainElf.force_Requise; } }
        public override int AosDexBonus { get { return ArmorChainElf.malus_Dex; } }

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
        //public override int NiveauAttirail { get { return ChainElfique_Niveau; } }

        public override int BasePhysicalResistance { get { return ArmorChainElf.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorChainElf.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorChainElf.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorChainElf.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorChainElf.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorChainElf.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorChainElf.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorChainElf.force_Requise; } }
        public override int AosDexBonus { get { return ArmorChainElf.malus_Dex; } }

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
