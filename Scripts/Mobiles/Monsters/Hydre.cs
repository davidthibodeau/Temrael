using System;
using Server.Mobiles;
using Server.Items;
     
namespace Server.Mobiles
{
        [CorpseName( "Cadavre d'hydre" )]
        public class Hydre : BaseCreature
        {
            [Constructable]
            public Hydre()
                : base(AIType.AI_Melee, FightMode.Closest, 10, 2, 0.2, 0.4)
            {
                Name = "Hydre";
                Body = 99;
                Hue = 0;
                BaseSoundID = 1261;

                PlayersAreEnemies = true;
                MaxRange = 3;

                SetStr(150);
                SetDex(200);
                SetInt(100);

                SetHits(500);
                SetMana(200);
                SetStam(400);
                SetArme(20, 25, 30/*, Poison.Deadly*/);

                SetResistance(ResistanceType.Physical, 25);
                SetResistance(ResistanceType.Magical, 0);

                SetSkill(SkillName.Empoisonnement, 100);
                SetSkill(SkillName.ArmureNaturelle, 100);
                SetSkill(SkillName.Tactiques, 100);
                SetSkill(SkillName.Epee, 100);
                SetSkill(SkillName.Anatomie, 100);
                SetSkill(SkillName.ResistanceMagique, 100);
                SetSkill(SkillName.CoupCritique, 60);
                SetSkill(SkillName.Penetration, 40);
            }
 
     
            public override void GenerateLoot()
            {
                //DeadlyPoisonPotion DeadlyPoisonPotion = new DeadlyPoisonPotion(1);
                //AddToBackpack(DeadlyPoisonPotion);

                AddToBackpack(new Amber(1));
                AddToBackpack(new Emerald(1));
            }

            public override int Hides { get { return 15; } }
            public override HideType HideType { get { return HideType.Reptilien; } }
     
            public Hydre(Serial serial) : base(serial)
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