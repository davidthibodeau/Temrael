using Server.Items;
using System.Collections.Generic;
namespace Server.Mobiles
{
    [CorpseName( "Cadavre de brigand" )]
    public class NpcNomade2 : BaseCreature
    {
        [Constructable]
        public NpcNomade2() : base( AIType.AI_Melee, FightMode.Closest, 11, 1, 0.2, 0.4 )
        {
            Name = "Brigand Nomade";
            Body = 400;
            BaseSoundID = -1;
            Hue = 1042;

            HairItemID = 8264;
            HairHue = 1109;
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
            SetSkill( SkillName.ArmeHaste, 100 );
            SetSkill( SkillName.Anatomie, 40 );
            SetSkill( SkillName.Parer, 60 );

            GenerateItems();
        }

        private void GenerateItems()
        {
            List<Item> items = new List<Item>();

            /*On ajoute ici les items que l'on veut que le PNJ porte, seule cette section doit être modifiée*/
            /*------------------*/
            Item it = new PerceCoeur();
            it.Hue = 0;
            items.Add(it);
            it = new TurbanProtecteur();
            it.Hue = 2307;
            items.Add(it);
            it = new FoulardProtecteur();
            it.Hue = 2307;
            items.Add(it);
            it = new PlaqueBarbareGreaves();
            it.Hue = 0;
            items.Add(it);
            it = new VesteCuir();
            it.Hue = 0;
            items.Add(it);
            it = new PantalonsCourts();
            it.Hue = 1875;
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
            AddLoot( LootPack.LeatherAr );
            Server.Items.Gold Gold = new Server.Items.Gold(12);
            AddToBackpack(Gold);
        }


        public NpcNomade2(Serial serial)
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