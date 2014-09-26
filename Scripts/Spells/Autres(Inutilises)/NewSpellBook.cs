using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Network;
using Server.Spells;
using Server.Gumps;
using Server.Prompts;
using Server.ContextMenus;
using Server.Mobiles;
using System.Collections.Generic;

namespace Server.Items
{
   public class NewSpellbook : Spellbook
   {
      public override SpellbookType SpellbookType{ get{ return SpellbookType.Regular; } }
      public override int BookOffset{ get{ return 600; } }
      public override int BookCount{ get{ return 200; } }

      public ArrayList Contents = new ArrayList();

      private class QSLEntry : ContextMenuEntry
      {
          private TMobile m_from;
          private NewSpellbook m_book;

          public QSLEntry(TMobile from, NewSpellbook book)
              : base(6268, -1)
          {
              m_from = from;
              m_book = book;
          }

          public override void OnClick()
          {
              m_from.CloseGump(typeof(QuickSpellLaunchGump));
              m_from.SendGump(new QuickSpellLaunchGump(m_from, m_book, null));
          }
      }

      public override void GetContextMenuEntries(Mobile m_from, List<ContextMenuEntry> list)
      {
          base.GetContextMenuEntries(m_from, list);

          Container pack = m_from.Backpack;

          if (Parent == m_from || (pack != null && Parent == pack))
          {
              if (m_from is TMobile)
                  list.Add(new QSLEntry(((TMobile)m_from), this));
          }
      }

      /*public override Item Dupe( int amount )
      {
         NewSpellbook book = new NewSpellbook();

         for (int i = 0; i < Contents.Count; i++)
         {
             int val = (int)Contents[i];
             book.Contents.Add(val);
         }

         return base.Dupe( book, amount );
      }*/

       [Constructable]
       public NewSpellbook()
           : this((ulong)0, 0xEFA)
       {
       }

      [Constructable]
       public NewSpellbook(ulong content, int itemid)
           : base(content, itemid)
      {
         Name = "Grimoire";
         Layer = Layer.OneHanded;
         Weight = 6.0;
      }

      public override void OnDoubleClick( Mobile from )
      {
		 Container pack = from.Backpack;

		  if ( Parent == from || (pack != null && Parent == pack))
		  {
				from.CloseGump( typeof( NewSpellbookGump ) );
				from.SendGump( new NewSpellbookGump( from, this ) );
		  }
			else
		  {
              from.SendMessage("Le grimoire doit être dans votre sac principal pour l'ouvrir.");
		  }
	  }

       public override bool OnDragDrop(Mobile from, Item dropped)
       {

           if (dropped is SpellScroll && dropped.Amount == 1)
           {
               SpellScroll scroll = (SpellScroll)dropped;


               if (HasSpell(scroll.SpellID))
               {
                   from.SendLocalizedMessage(500179); // That spell is already present in that spellbook.
                   return false;
               }
               else
               {

                   int val = scroll.SpellID;

                   /*if (val >= 600)
                   {*/
                      //Console.WriteLine(val);

                       Contents.Add(val);

                       scroll.Delete();

                       from.Send(new PlaySound(0x249, GetWorldLocation()));
                       return true;
                   //}

                   //return false;
               }
           }
           else
           {
               return false;
           }
       }

       public override bool HasSpell(int spellID)
       {
           if (Parent is TMobile)
           {
               TMobile from = Parent as TMobile;
               if (from.AccessLevel > AccessLevel.Player)
                   return true;
           }

           return Contents.Contains(spellID);
       }

       public NewSpellbook(Serial serial)
           : base(serial)
      {
      }

      public override void Serialize( GenericWriter writer )
      {
         base.Serialize( writer );

         writer.Write( (int) 0 ); // version

         writer.Write(Contents.Count);
         for (int i = 0; i < Contents.Count; i++)
         {
             int spellID = (int)Contents[i];
             writer.Write(spellID);
         }
      }

      public override void Deserialize(GenericReader reader)
      {
         base.Deserialize( reader );

         int version = reader.ReadInt();

         int count = reader.ReadInt();
         for (int i = 0; i < count; i++)
         {
             int temp = 0;
             temp = reader.ReadInt();
             Contents.Add(temp);
         }

         Weight = 6.0;
      }
  }
}
