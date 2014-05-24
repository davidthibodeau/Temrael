using System;
using Server.Items;

namespace Server.Items
{
    public class ElfiqueCuirTunic : BaseArmor
    {

        public override int BasePhysicalResistance { get { return Leather_Physique; } }
        public override int BaseContondantResistance { get { return Leather_Contondant; } }
        public override int BaseTranchantResistance { get { return Leather_Tranchant; } }
        public override int BasePerforantResistance { get { return Leather_Perforant; } }
        public override int BaseMagieResistance { get { return Leather_Magique; } }

        public override int InitMinHits { get { return Leather_MinDurabilite; } }
        public override int InitMaxHits { get { return Leather_MaxDurabilite; } }

        public override int AosStrReq { get { return Leather_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Studded; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public ElfiqueCuirTunic()
            : base(0x289C)
        {
            Weight = 2.0;
            Name = "Tunique Elfique";
        }

        public ElfiqueCuirTunic(Serial serial)
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
    public class ElfiqueCuirRobe : BaseArmor
    {

        public override int BasePhysicalResistance { get { return Leather_Physique; } }
        public override int BaseContondantResistance { get { return Leather_Contondant; } }
        public override int BaseTranchantResistance { get { return Leather_Tranchant; } }
        public override int BasePerforantResistance { get { return Leather_Perforant; } }
        public override int BaseMagieResistance { get { return Leather_Magique; } }

        public override int InitMinHits { get { return Leather_MinDurabilite; } }
        public override int InitMaxHits { get { return Leather_MaxDurabilite; } }

        public override int AosStrReq { get { return Leather_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Studded; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public ElfiqueCuirRobe()
            : base(0x289D)
        {
            Weight = 2.0;
            Name = "Robe Elfique";
        }

        public ElfiqueCuirRobe(Serial serial)
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
