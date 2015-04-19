using Server.Items;
using System.Collections.Generic;
namespace Server.Mobiles
{
    [CorpseName( "Cadavre de brigand" )]
    public class NpcNomade4 : BaseCreature
    {
        [Constructable]
        public NpcNomade4() : base( AIType.AI_Archer, FightMode.Closest, 11, 1, 0.2, 0.4 )
        {
            Name = "Brigand Nomade";
            Body = 400;
            BaseSoundID = -1;
            Hue = 1048;

            HairItemID = 8265;
            HairHue = 1148;
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
            Item it = new ArbaleteRepetition();
            it.Hue = 0;
            items.Add(it);
            it = new Bandana();
            it.Hue = 2307;
            items.Add(it);
            it = new CagouleGorget();
            it.Hue = 2307;
            items.Add(it);
            it = new TuniqueNomade();
            it.Hue = 0;
            items.Add(it);
            it = new Carquois();
            it.Hue = 0;
            items.Add(it);
            it = new LeatherGloves();
            it.Hue = 1875;
            items.Add(it);
            it = new CeintureBourse();
            it.Hue = 2307;
            items.Add(it);
            it = new LeatherLegs();
            it.Hue = 1875;
            items.Add(it);
            it = new BottesVoyage();
            it.Hue = 2307;
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
            AddLoot( LootPack.LeatherAr );
            Server.Items.Bolt Bolt = new Server.Items.Bolt(20);
            AddToBackpack(Bolt);
        }


        public NpcNomade4(Serial serial)
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