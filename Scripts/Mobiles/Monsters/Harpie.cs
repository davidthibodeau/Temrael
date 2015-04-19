using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName( "Cadavre d'Harpie" )]
    public class Harpie : BaseCreature
    {
        [Constructable]
        public Harpie() : base( AIType.AI_Melee, FightMode.Closest, 11, 1, 0.2, 0.3 )
        {
            Name = "Harpie";
            Body = 30;
            BaseSoundID = 916;

            PlayersAreEnemies = true;

            SetStr( 60 );
            SetDex( 100 );
            SetInt( 10 );

            SetHits( 200 );
            SetMana( 20);
            SetStam( 60);    
            SetArme(7, 12, 30);

            SetResistance( ResistanceType.Physical, 20 );
            SetResistance( ResistanceType.Magical, 0 );

            SetSkill( SkillName.Anatomie, 60 );
            SetSkill( SkillName.Tactiques, 60 );
            SetSkill( SkillName.Epee, 60 );
            SetSkill( SkillName.CoupCritique, 60 );

        }

        public override void GenerateLoot()
        {
            Citrine citrine = new Citrine(1);
            AddToBackpack(citrine);

            Amber amber = new Amber(1);
            AddToBackpack(amber);
        }

        public override int Feathers{ get{ return 15; } }

        public Harpie(Serial serial) : base(serial)
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
