using System;
    using Server.Mobiles;
     
    namespace Server.Mobiles
    {
            [CorpseName( "Cadavre de Mongbat" )]
            public class Mongbat : BaseCreature
            {
                [Constructable]
                public Mongbat() : base( AIType.AI_Mage, FightMode.Closest, 9, 1, 0.2, 0.4 )
                {
                    Name = "Mongbat";
                    Body = 39;
                    BaseSoundID = 0x1A7;
 
 
                    PlayersAreEnemies = true;
     
                    SetStr( 20 );
                    SetDex( 30 );
                    SetInt( 50 );
     
                    SetHits( 115 );
                    SetMana( 100 );
                    SetStam( 40 );    
                    SetArme(1, 5, 40);
     
                    SetResistance( ResistanceType.Physical, 0 );
                    SetResistance( ResistanceType.Magical, 0 );
     
                    SetSkill( SkillName.ArtMagique, 55 );
                    SetSkill( SkillName.Evocation, 55 );
                    SetSkill( SkillName.Epee, 10 );
                    SetSkill( SkillName.Tactiques, 10 );    
                }
 
                public override void GenerateLoot()
                {
                    AddLoot( LootPack.Regs );
                    AddLoot( LootPack.Regs );
                    AddLoot( LootPack.Regs );
                    AddLoot( LootPack.Regs );
                }

                public Mongbat(Serial serial) : base(serial)
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