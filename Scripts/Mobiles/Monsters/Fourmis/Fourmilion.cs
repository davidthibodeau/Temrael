using System;
    using Server.Mobiles;
     
    namespace Server.Mobiles
    {
            [CorpseName( "Cadavre de fourmilion" )]
            public class Fourmilion : BaseCreature
            {
                    [Constructable]
                    public Fourmilion() : base( AIType.AI_Melee, FightMode.Closest, 9, 1, 0.2, 0.4 )
                    {
                            Name = "Fourmilion";
                            Body = 125;
                            Hue = 0;
                            BaseSoundID = 1265;
 
                            PlayersAreEnemies = true;
                            MaxRange= 1;
 
                            SetStr( 110 );
                            SetDex( 80 );
                            SetInt( 10 );
     
                            SetHits( 275 );
                            SetMana( 20);
                            SetStam( 240);    
                            SetArme(13, 18, 40);
     
                            SetResistance( ResistanceType.Physical, 20 );
                            SetResistance( ResistanceType.Magical, 0 );
     
                            SetSkill( SkillName.Detection, 70 );
                            SetSkill( SkillName.ArmureNaturelle, 70 );
                            SetSkill( SkillName.Tactiques, 70 );
                            SetSkill( SkillName.Epee, 70 );
                            SetSkill( SkillName.Anatomie, 40 );
                            SetSkill( SkillName.Parer, 40 );
                            SetSkill( SkillName.CoupCritique, 40 );
                    }
 
     
                    public override void GenerateLoot()
                    {

                    }
 
     
                    public override int Hides { get { return 4; } }
                    public override HideType HideType { get { return HideType.Desertique; } }
     
                    public Fourmilion(Serial serial) : base(serial)
                    {
                    }
     
                    public override int Meat { get { return 5;} }
                    public override MeatType MeatType { get { return MeatType.Ribs; } }
     
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