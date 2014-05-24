using System;
using Server.Items;

namespace Server.Items
{
    public class TunicBarbare : BaseArmor
    {
        public override int NiveauAttirail { get { return ArmureBarbare_Niveau; } }

        public override int BasePhysicalResistance { get { return ArmureBarbare_Physique; } }
        public override int BaseContondantResistance { get { return ArmureBarbare_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmureBarbare_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmureBarbare_Perforant; } }
        public override int BaseMagieResistance { get { return ArmureBarbare_Magique; } }

        public override int InitMinHits { get { return ArmureBarbare_MinDurabilite; } }
        public override int InitMaxHits { get { return ArmureBarbare_MaxDurabilite; } }

        public override int AosStrReq { get { return ArmureBarbare_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Studded; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public TunicBarbare()
            : base(0x287C)
        {
            Weight = 2.0;
            Name = "Tunique Barbare";
        }

        public TunicBarbare(Serial serial)
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
    public class LeggingsBarbare : BaseArmor
    {
        public override int NiveauAttirail { get { return ArmureBarbare_Niveau; } }

        public override int BasePhysicalResistance { get { return ArmureBarbare_Physique; } }
        public override int BaseContondantResistance { get { return ArmureBarbare_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmureBarbare_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmureBarbare_Perforant; } }
        public override int BaseMagieResistance { get { return ArmureBarbare_Magique; } }

        public override int InitMinHits { get { return ArmureBarbare_MinDurabilite; } }
        public override int InitMaxHits { get { return ArmureBarbare_MaxDurabilite; } }

        public override int AosStrReq { get { return ArmureBarbare_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Studded; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public LeggingsBarbare()
            : base(0x287D)
        {
            Weight = 2.0;
            Name = "Jambieres Barbares";
        }

        public LeggingsBarbare(Serial serial)
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
