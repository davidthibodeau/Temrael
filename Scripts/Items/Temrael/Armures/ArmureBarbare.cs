﻿using System;
using Server.Items;

namespace Server.Items
{
    public class TunicBarbare : BaseArmor
    {
        //public override int NiveauAttirail { get { return ArmureBarbare_Niveau; } }

        public override int BasePhysicalResistance { get { return ArmorBarbare.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorBarbare.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorBarbare.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorBarbare.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorBarbare.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorBarbare.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorBarbare.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorBarbare.force_Requise; } }
        public override int AosDexBonus { get { return ArmorBarbare.malus_Dex; } }

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
        //public override int NiveauAttirail { get { return ArmureBarbare_Niveau; } }

        public override int BasePhysicalResistance { get { return ArmorBarbare.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorBarbare.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorBarbare.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorBarbare.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorBarbare.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorBarbare.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorBarbare.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorBarbare.force_Requise; } }
        public override int AosDexBonus { get { return ArmorBarbare.malus_Dex; } }

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