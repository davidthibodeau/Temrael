using System;
using Server.Mobiles;
using Server.Items;
using System.Collections.Generic;
     
namespace Server.Mobiles
{
    [CorpseName( "Cadavre de brigand" )]
    public class Brigand20 : BaseCreature
    {
        [Constructable]
        public Brigand20() : base( AIType.AI_Melee, FightMode.Closest, 11, 1, 0.2, 0.4 )
        {
            Name = "Brigand";
            Body = 400;
            BaseSoundID = 418;
 
            HairItemID = 0;
            HairHue = 0;
            FacialHairItemID = 0;
            FacialHairHue = 0;
 
            PlayersAreEnemies = true;

            SetStr( 110 );
            SetDex( 110 );
            SetInt( 20 );
     
            SetHits( 180 );
            SetMana( 40 );
            SetStam( 180 );
     
            SetResistance( ResistanceType.Physical, 15 );
            SetResistance( ResistanceType.Magical, 0 );

            SetSkill( SkillName.Detection, 60 );
            SetSkill( SkillName.Tactiques, 100 );
            SetSkill( SkillName.Epee, 100 );
            SetSkill( SkillName.Anatomie, 80 );
            SetSkill( SkillName.Parer, 60 );

            GenerateItems();
        }

        private void GenerateItems()
        {
            List<Item> items = new List<Item>();

            /*On ajoute ici les items que l'on veut que le PNJ porte, seule cette section doit être modifiée*/
            /*------------------*/
            items.Add(new Biliome());
            items.Add(new LeatherCap());
            items.Add(new LeatherChest());
            items.Add(new LeatherArms());
            items.Add(new LeatherLegs());
            items.Add(new Bottes(2418));
            /*------------------*/

            if (items.Count > 0)
            {
                for (int i = 0; i < items.Count; ++i)
                {
                    items[i].Movable = false;
                    items[i].CanBeAltered = false;
                    items[i].LootType = LootType.Blessed;
                    AddItem(items[i]);
                }
            }
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.Food );
            AddLoot( LootPack.UtilityItems );
            AddLoot( LootPack.UtilityItems );
        }


        public Brigand20(Serial serial)
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