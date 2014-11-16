using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de loup")]
    public class LoupBlanc : BaseCreature
    {
        [Constructable]
        public LoupBlanc()
            : base(AIType.AI_Thief, FightMode.Closest, 9, 1, 0.2, 0.4)
                    {
                            Name = "Loup Blanc";
                            Body = 225;
                            Hue = 2168;
                            BaseSoundID = 229;

                            PlayersAreEnemies = true;
                            Direction = Direction.North;
                            Hidden = true;   
 
                            SetStr( 70 );
                            SetDex( 60 );
                            SetInt( 5 );
     
                            SetHits( 120 );
                            SetMana( 10);
                            SetStam( 120);    
                            SetArme(8, 12, 30);
     
                            SetResistance( ResistanceType.Physical, 15 );
                            SetResistance( ResistanceType.Magie, 0 );
     
                            SetSkill( SkillName.Infiltration, 54 );
                            SetSkill( SkillName.Tactiques, 54 );
                            SetSkill( SkillName.Epee, 54 );
                            SetSkill( SkillName.Anatomie, 48 );
                            SetSkill(SkillName.ResistanceMagique, 36);


                            Tamable = true;
                            ControlSlots = 2;
                            MinTameSkill = 30;
     
                    }

        public override int Hides { get { return 3; } }
        public override HideType HideType { get { return HideType.Nordique; } }
        public override int Meat { get { return 2; } }
        public override MeatType MeatType { get { return MeatType.Ribs; } }

        public LoupBlanc(Serial serial)
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