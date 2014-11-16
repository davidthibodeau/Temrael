using System;
using Server.Mobiles;
     
namespace Server.Mobiles
{
    [CorpseName( "Cadavre d'orc" )]
    public class OrcShaman : BaseCreature
    {
        [Constructable]
        public OrcShaman() : base( AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
        {
                Name = "Orc";
                Body = 83;
                BaseSoundID = 1115;

                PlayersAreEnemies = true;
                Direction = Direction.West;   
 
                SetStr( 60 );
                SetDex( 60 );
                SetInt( 70 );
     
                SetHits( 110 );
                SetMana( 140);
                SetStam( 120);    
                SetArme(4, 8, 40);
     
                SetResistance( ResistanceType.Physical, 10 );
                SetResistance( ResistanceType.Magie, 0 );
     
                SetSkill( SkillName.ArtMagique, 60 );
                SetSkill( SkillName.Tactiques, 20 );
                SetSkill( SkillName.Epee, 24 );
                SetSkill( SkillName.Ensorcellement, 56 );
                SetSkill( SkillName.Evocation, 60 );
                SetSkill( SkillName.MagieDeGuerre, 40 );      
        }

        public override void GenerateLoot()
        {
                AddLoot( LootPack.Regs );
                AddLoot( LootPack.Regs );
                AddLoot( LootPack.NecroRegs );
                AddLoot( LootPack.UtilityItems );
        }
      
        public override int Bones { get { return 3; } }
        public override BoneType BoneType { get { return BoneType.Nordique; } }

        public OrcShaman(Serial serial)
            : base(serial)
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