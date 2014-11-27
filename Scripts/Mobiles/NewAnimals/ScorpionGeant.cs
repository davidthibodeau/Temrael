using System;
    using Server.Mobiles;
     
    namespace Server.Mobiles
    {
            [CorpseName( "Cadavre de Scorpion" )]
            public class ScorpionGeant : BaseCreature
            {
                    [Constructable]
                    public ScorpionGeant() : base( AIType.AI_Melee, FightMode.Closest, 9, 1, 0.2, 0.4 )
                    {
                            Name = "Scorpion Geant";
                            Body = 48;
                            BaseSoundID = 0x18E;
 
                            PlayersAreEnemies = true;
 
                            SetStr( 90 );
                            SetDex( 80 );
                            SetInt( 10 );
     
                            SetHits( 225 );
                            SetMana( 20);
                            SetStam( 240);    
                            SetArme(11, 16, 40, Poison.Regular);
     
                            SetResistance( ResistanceType.Physical, 10 );
                            SetResistance( ResistanceType.Magie, 0 );
     
                            SetSkill( SkillName.Empoisonnement, 68 );
                            SetSkill( SkillName.ArmureNaturelle, 68 );
                            SetSkill( SkillName.Tactiques, 68 );
                            SetSkill( SkillName.Epee, 68 );
                            SetSkill( SkillName.Anatomie, 40 );
                            SetSkill( SkillName.CoupCritique, 34 );
                            SetSkill( SkillName.Penetration, 34 );
                    }
 
     
                    public override void GenerateLoot()
                    {

                    }


                    public override int Hides { get { return 4; } }
                    public override HideType HideType { get { return HideType.Desertique; } }
     
                    public ScorpionGeant(Serial serial) : base(serial)
                    {
                    }
     
                    public override int Meat { get { return 3;} }
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