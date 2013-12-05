using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Network;
using Server.Spells;
using Server.Gumps;
using Server.Prompts;
using Server.ContextMenus;

namespace Server.Items
{
   public class NewBardSpellbook : NewSpellbook
   {
      public override SpellbookType SpellbookType{ get{ return SpellbookType.Regular; } }
      public override int BookOffset{ get{ return 1600; } }
      public override int BookCount{ get{ return 30; } }

      /*public override Item Dupe( int amount )
      {
         NewBardSpellbook book = new NewBardSpellbook();

         for (int i = 0; i < Contents.Count; i++)
         {
             int val = (int)Contents[i];
             book.Contents.Add(val);
         }

         return base.Dupe( book, amount );
      }*/

      [Constructable]
       public NewBardSpellbook()
           : base((ulong)0, 0x2252)
      {
         Name = "Livre de chansons";
         Layer = Layer.OneHanded;
         Hue = 405;

         for (int i = 1600; i < 1631; i++)
         {
             this.Contents.Add(i);
         }
      }

       public override void OnDoubleClick(Mobile from)
      {
		 Container pack = from.Backpack;

		  if ( Parent == from || (pack != null && Parent == pack))
		  {
				from.CloseGump( typeof( NewBardSpellbookGump ) );
				from.SendGump( new NewBardSpellbookGump( from, this ) );
		  }
			else
		  {
              from.SendMessage("Le grimoire doit être dans votre sac principal pour l'ouvrir.");
		  }
	  }

       public NewBardSpellbook(Serial serial)
           : base(serial)
      {
      }

      public override void Serialize( GenericWriter writer )
      {
         base.Serialize( writer );

         writer.Write( (int) 0 ); // version
      }

      public override void Deserialize(GenericReader reader)
      {
         base.Deserialize( reader );

         int version = reader.ReadInt();
      }
  }
}
