using System;
using Server.Mobiles;
     
namespace Server.Mobiles
{
        [CorpseName( "Cadavre de serpent geant" )]
    public class SerpentGeant : BaseCreature
    {
        [Constructable]
            public SerpentGeant()
                : base(AIType.AI_Melee, FightMode.Closest, 9, 1, 0.2, 0.4)
            {
                Name = "Serpent Geant";
                Body = 21;
                Hue = 2012;
                BaseSoundID = 220;

                PlayersAreEnemies = true;
                MaxRange = 1;

                SetStr(90);
                SetDex(120);
                SetInt(10);

                SetHits(200);
                SetMana(20);
                SetStam(240);
                SetArme(10, 15, 40, Poison.Regular);

                SetResistance(ResistanceType.Physical, 0);
                SetResistance(ResistanceType.Magie, 0);

                SetSkill(SkillName.Empoisonnement, 90);
                SetSkill(SkillName.ArmureNaturelle, 72);
                SetSkill(SkillName.Tactiques, 66);
                SetSkill(SkillName.Epee, 66);
                SetSkill(SkillName.Anatomie, 66);
        }

      
        public override int Hides { get { return 5; } }
        public override HideType HideType { get { return HideType.Reptilien; } }
     
        public SerpentGeant(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
                base.Serialize(writer);
     
                writer.Write((int) 0);
        }
     
        public override void Deserialize(GenericReader reader)
        {
                base.Deserialize(reader);
     
                int version = reader.ReadInt();
        }
    }  
}