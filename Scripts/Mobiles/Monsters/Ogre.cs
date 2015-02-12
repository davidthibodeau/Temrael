using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName( "Cadavre d'ogre" )]
    public class Ogre : BaseCreature
    {
        [Constructable]
        public Ogre() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.15, 0.3 )
        {
            Name = "Ogre";
            Body = 1;
            BaseSoundID = 427;

            PlayersAreEnemies = true;
            MaxRange = 2;

            SetStr( 120 );
            SetDex( 80 );
            SetInt( 50 );

            SetHits( 275 );
            SetMana( 100 );
            SetStam( 160 );    
            SetArme(12, 18, 40);

            SetResistance( ResistanceType.Physical, 20 );
            SetResistance( ResistanceType.Magical, 0 );

            SetSkill( SkillName.ArmureNaturelle, 70 );
            SetSkill( SkillName.Tactiques, 70 );
            SetSkill( SkillName.Epee, 70 );
            SetSkill( SkillName.CoupCritique, 35 );
            SetSkill( SkillName.Penetration, 70 );  
            SetSkill( SkillName.ResistanceMagique, 50 );
            SetSkill( SkillName.Parer, 35 );   
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Food);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.Junk);

            Amethyst Amethyst = new Amethyst(1);
            AddToBackpack(Amethyst);

            Amethyst = new Amethyst(1);
            AddToBackpack(Amethyst);

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
