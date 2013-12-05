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
   public class NewDivineSpellbook : NewSpellbook
   {
      public override SpellbookType SpellbookType{ get{ return SpellbookType.Regular; } }
      public override int BookOffset{ get{ return 1000; } }
      public override int BookCount{ get{ return 200; } }

      /*public override Item Dupe( int amount )
      {
         NewDivineSpellbook book = new NewDivineSpellbook();

         for (int i = 0; i < Contents.Count; i++)
         {
             int val = (int)Contents[i];
             book.Contents.Add(val);
         }

         return base.Dupe( book, amount );
      }*/

      [Constructable]
       public NewDivineSpellbook()
           : base((ulong)0, 0x2252)
      {
         Name = "Recueil de prières";
         Layer = Layer.Invalid;
      }

      public override void OnDoubleClick( Mobile from )
      {
		 Container pack = from.Backpack;

		  if ( Parent == from || (pack != null && Parent == pack))
		  {
				from.CloseGump( typeof( NewDivineSpellbookGump ) );
				from.SendGump( new NewDivineSpellbookGump( from, this ) );
		  }
			else
		  {
              from.SendMessage("Le grimoire doit être dans votre sac principal pour l'ouvrir.");
		  }
	  }

       public NewDivineSpellbook(Serial serial)
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
