    using System;
    using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de Silinx")]
    public class SilinxCorps : BaseCreature
    {
        [Constructable]
        public SilinxCorps()
            : base(AIType.AI_Mage, FightMode.Closest, 11, 1, 0.2, 0.4)
        {
            Name = "Corps du Silinx";
            Body = 37;
            BaseSoundID = 443;

            MaxRange = 10;
            CantWalk = true;
            PlayersAreEnemies = true;

            SetStr(80);
            SetDex(100);
            SetInt(80);

            SetHits(8000);
            SetMana(100);
            SetStam(1000);
            SetArme(12, 18, 50);

            SetResistance(ResistanceType.Physical, 0);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.ArmureNaturelle, 50);
            SetSkill(SkillName.Tactiques, 75);
            SetSkill(SkillName.Epee, 75);
            SetSkill(SkillName.ArtMagique, 80);
            SetSkill(SkillName.ResistanceMagique, 50);
            SetSkill(SkillName.Parer, 50);
            SetSkill(SkillName.Immuabilite, 100);
            SetSkill(SkillName.Penetration, 50);
            SetSkill(SkillName.CoupCritique, 40);


        }

        public override void GenerateLoot()
        {

            Emerald emerald = new Emerald(1);
            AddToBackpack(emerald);

            emerald = new Emerald(1);
            AddToBackpack(emerald);

            emerald = new Emerald(1);
            AddToBackpack(emerald);

            emerald = new Emerald(1);
            AddToBackpack(emerald);

            emerald = new Emerald(1);
            AddToBackpack(emerald);

            emerald = new Emerald(1);
            AddToBackpack(emerald);

            emerald = new Emerald(1);
            AddToBackpack(emerald);

            emerald = new Emerald(1);
            AddToBackpack(emerald);

            emerald = new Emerald(1);
            AddToBackpack(emerald);

            emerald = new Emerald(1);
            AddToBackpack(emerald);

            emerald = new Emerald(1);
            AddToBackpack(emerald);

            emerald = new Emerald(1);
            AddToBackpack(emerald);

            LuminiumIngot luminiumIngot = new LuminiumIngot(1);
            AddToBackpack(luminiumIngot);

            luminiumIngot = new LuminiumIngot(1);
            AddToBackpack(luminiumIngot);

            luminiumIngot = new LuminiumIngot(1);
            AddToBackpack(luminiumIngot);

            luminiumIngot = new LuminiumIngot(1);
            AddToBackpack(luminiumIngot);

            luminiumIngot = new LuminiumIngot(1);
            AddToBackpack(luminiumIngot);

            luminiumIngot = new LuminiumIngot(1);
            AddToBackpack(luminiumIngot);

            luminiumIngot = new LuminiumIngot(1);
            AddToBackpack(luminiumIngot);

            luminiumIngot = new LuminiumIngot(1);
            AddToBackpack(luminiumIngot);
        }


        public SilinxCorps(Serial serial)
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