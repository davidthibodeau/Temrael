using Server.Items;
using System.Collections.Generic;
namespace Server.Mobiles
{
    [CorpseName( "Cadavre de brigand" )]
    public class NpcNomade1 : BaseCreature
    {
        [Constructable]
        public NpcNomade1() : base( AIType.AI_Archer, FightMode.Closest, 11, 1, 0.2, 0.4 )
        {
            Name = "Brigand Nomade";
            Body = 401;
            BaseSoundID = -1;
            Hue = 1044;

            HairItemID = 8266;
            HairHue = 1109;
            FacialHairItemID = 0;
            FacialHairHue = 0;
 
            PlayersAreEnemies = true;
            MaxRange = 9;

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
            SetSkill( SkillName.ArmeDistance, 100 );
            SetSkill( SkillName.Anatomie, 40 );
            SetSkill( SkillName.Parer, 60 );

            GenerateItems();
        }

        private void GenerateItems()
        {
            List<Item> items = new List<Item>();

            /*On ajoute ici les items que l'on veut que le PNJ porte, seule cette section doit être modifiée*/
            /*------------------*/
            Item it = new Vigne();
            it.Hue = 2418;
            items.Add(it);
            it = new TurbanVoile();
            it.Hue = 1875;
            items.Add(it);
            it = new SoutienGorge();
            it.Hue = 1875;
            items.Add(it);
            it = new PantalonsCourts();
            it.Hue = 2418;
            items.Add(it);
            it = new CeintureCuir();
            it.Hue = 0;
            items.Add(it);
            it = new Sandals();
            it.Hue = 0;
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
            AddLoot( LootPack.LeatherAr );
            Server.Items.Arrow Arrow = new Server.Items.Arrow(20);
            AddToBackpack(Arrow);
        }


        public NpcNomade1(Serial serial)
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