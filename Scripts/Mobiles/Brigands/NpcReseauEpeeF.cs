using System;
using Server.Mobiles;
using Server.Items;
using System.Collections.Generic;
     
namespace Server.Mobiles
{
    [CorpseName( "Cadavre de brigand" )]
    public class NpcReseauEpeeF : BaseCreature
    {
        [Constructable]
        public NpcReseauEpeeF() : base( AIType.AI_Melee, FightMode.Closest, 11, 1, 0.2, 0.4 )
        {
            Name = "Brigand";
            Body = 401;
            BaseSoundID = 418;
            Hue = 1044;

            HairItemID = 10210;
            HairHue = 1044;
            FacialHairItemID = 0;
            FacialHairHue = 0;
 
            PlayersAreEnemies = true;

            SetStr( 90 );
            SetDex( 90 );
            SetInt( 20 );
     
            SetHits( 180 );
            SetMana( 40 );
            SetStam( 180 );
     
            SetResistance( ResistanceType.Physical, 5 );
            SetResistance( ResistanceType.Magical, 0 );
     
            SetSkill( SkillName.Detection, 60 );
            SetSkill( SkillName.Tactiques, 60 );
            SetSkill( SkillName.Epee, 100 );
            SetSkill( SkillName.Anatomie, 40 );
            SetSkill( SkillName.Parer, 60 );

            GenerateItems();
        }

        private void GenerateItems()
        {
            List<Item> items = new List<Item>();

            /*On ajoute ici les items que l'on veut que le PNJ porte, seule cette section doit être modifiée*/
            /*------------------*/
            Item it = new Vorlame();
            it.Hue = 1904;
            items.Add(it);
            it = new CagouleCuir();
            it.Hue = 1904;
            items.Add(it);
            it = new SkullCap();
            it.Hue = 1906;
            items.Add(it);
            it = new RoublardTunic();
            it.Hue = 1904;
            items.Add(it);
            it = new Cloak();
            it.Hue = 1904;
            items.Add(it);
            it = new RoublardLeggings();
            it.Hue = 1904;
            items.Add(it);
            it = new FourreauEpee();
            it.Hue = 0;
            items.Add(it);
            it = new GantsSombres();
            it.Hue = 2412;
            items.Add(it);
            
            /*------------------*/

            if (items.Count > 0)
            {
                for (int i = 0; i < items.Count; ++i)
                {
                    items[i].Movable = false;
                    items[i].CanBeAltered = false;
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

        public NpcReseauEpeeF(Serial serial)
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