using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Gumps;
using Server.Items;
using Server.Spells;

namespace Server.Gumps
{
    public class QuickSpellLaunchGump : Gump
    {
        private TMobile m_From;
        private NewSpellbook m_Book;
        private BaseInstrument m_Instrument;
        private ArrayList m_List;

        public static ArrayList GetSpellList(TMobile from, NewSpellbook book)
        {
            ArrayList list = new ArrayList();

            for (int i = 0; i < from.QuickSpells.Count; i++)
            {

                int val = (int)from.QuickSpells[i];

                SpellBookEntry entry = NewSpellbookGump.FindEntryBySpellID(val);

                if (entry != null && book.HasSpell(entry.SpellID))
                {
                    list.Add(entry);
                }
            }

            return list;
        }

        public QuickSpellLaunchGump(TMobile from, NewSpellbook book, ArrayList list)
            : base(150, 200)
        {
            try
            {
                if (list == null)
                    list = GetSpellList(from, book);

                if (list != null)
                {
                    m_List = list;

                    m_From = from;
                    m_Book = book;

                    //m_From.Validate(ValidateType.Connaissances);

                    Closable = true;
                    Disposable = true;
                    Dragable = true;
                    Resizable = false;

                    AddPage(0);

                    //AddBackground(69, 35, 44 + ((list.Count / 3 + 1) < 3 ? 3 : (list.Count / 3 + 1)) * 44, 146, 2620);
                    AddBackground(69, 35, 54 + ((list.Count / 3) * 44), 146, 2620);
                    /*AddBackground(69, 35, 63 + ((list.Count / 3 + 1) < 3 ? 3 : (list.Count / 3 + 1)) * 57, 198, 9260);
                    AddBackground(92, 59, 19 + ((list.Count / 3 + 1) < 3 ? 3 : (list.Count / 3 + 1)) * 57, 154, 9270);
                    AddImageTiled(111, 34, 0 + ((list.Count / 3 + 1) < 3 ? 3 : (list.Count / 3 + 1)) * 57, 17, 10250);
                    AddImage(35, 40, 10421);
                    AddImage(111 + ((list.Count / 3 + 1) < 3 ? 3 : (list.Count / 3 + 1)) * 57, 40, 10431);
                    AddImage(59, 22, 10420);
                    AddImage(94 + ((list.Count / 3 + 1) < 3 ? 3 : (list.Count / 3 + 1)) * 57, 22, 10430);
                    AddImage(19, 172, 10402);
                    AddImage(100 + ((list.Count / 3 + 1) < 3 ? 3 : (list.Count / 3 + 1)) * 57, 172, 10412);

                    AddLabel(60 + ((list.Count / 3 + 1) < 3 ? 3 : (list.Count / 3 + 1)) * 26, 32, 50, "Lancement rapide");*/

                    int hindex = 0;
                    int vindex = 0;

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (vindex > 2)
                        {
                            hindex++;
                            vindex = 0;
                        }

                        object obj = (object)list[i];

                        if (book is NewSpellbook)
                        {
                            SpellBookEntry entry = (SpellBookEntry)obj;

                            //Console.WriteLine(((SpellBookEntry)obj).ToString() + " " + entry.ToString());

                            if (entry != null)
                            {
                                AddButton(74 + hindex * 44, 42 + vindex * 44, entry.ImageID, entry.ImageID, entry.SpellID, GumpButtonType.Reply, 0);
                                //AddButton(102 + hindex * 57, 71 + vindex * 45, 2103, 2104, entry.SpellID + 2000, GumpButtonType.Reply, 0);
                            }
                        }

                        vindex++;
                    }
                }
            }
            catch (Exception ex)
            {
                Misc.ExceptionLogging.WriteLine(ex);
            }
        }

        public QuickSpellLaunchGump(TMobile from, BaseInstrument instrument, ArrayList list)
            : base(150, 200)
        {
            try
            {
                if (list != null)
                {
                    m_List = list;

                    m_From = from;
                    m_Instrument = instrument;

                    //m_From.Validate(ValidateType.Connaissances);

                    Closable = true;
                    Disposable = true;
                    Dragable = true;
                    Resizable = false;

                    AddPage(0);

                    //AddBackground(69, 35, 44 + ((list.Count / 3 + 1) < 3 ? 3 : (list.Count / 3 + 1)) * 44, 146, 2620);
                    AddBackground(69, 35, 54 + ((list.Count / 3) * 44), 146, 2620);
                    /*AddBackground(69, 35, 63 + ((list.Count / 3 + 1) < 3 ? 3 : (list.Count / 3 + 1)) * 57, 198, 9260);
                    AddBackground(92, 59, 19 + ((list.Count / 3 + 1) < 3 ? 3 : (list.Count / 3 + 1)) * 57, 154, 9270);
                    AddImageTiled(111, 34, 0 + ((list.Count / 3 + 1) < 3 ? 3 : (list.Count / 3 + 1)) * 57, 17, 10250);
                    AddImage(35, 40, 10421);
                    AddImage(111 + ((list.Count / 3 + 1) < 3 ? 3 : (list.Count / 3 + 1)) * 57, 40, 10431);
                    AddImage(59, 22, 10420);
                    AddImage(94 + ((list.Count / 3 + 1) < 3 ? 3 : (list.Count / 3 + 1)) * 57, 22, 10430);
                    AddImage(19, 172, 10402);
                    AddImage(100 + ((list.Count / 3 + 1) < 3 ? 3 : (list.Count / 3 + 1)) * 57, 172, 10412);

                    AddLabel(60 + ((list.Count / 3 + 1) < 3 ? 3 : (list.Count / 3 + 1)) * 26, 32, 50, "Lancement rapide");*/

                    int hindex = 0;
                    int vindex = 0;

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (vindex > 2)
                        {
                            hindex++;
                            vindex = 0;
                        }

                        object obj = (object)list[i];

                        if (obj is SpellBookEntry)
                        {
                            SpellBookEntry entry = (SpellBookEntry)obj;

                            if (entry != null)
                            {
                                AddButton(74 + hindex * 44, 42 + vindex * 44, entry.ImageID, entry.ImageID, entry.SpellID, GumpButtonType.Reply, 0);
                                //AddButton(102 + hindex * 57, 71 + vindex * 45, 2103, 2104, entry.SpellID + 2000, GumpButtonType.Reply, 0);
                            }
                        }
                        

                        vindex++;
                    }
                }
            }
            catch (Exception ex)
            {
                Misc.ExceptionLogging.WriteLine(ex);
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (info.ButtonID < 3000 && info.ButtonID != 0)
            {
                if (m_Book != null && (m_Book.Parent == from || (from.Backpack != null && m_Book.Parent == from.Backpack)))
                {
                    Spell spell = SpellRegistry.NewSpell(info.ButtonID, from, null);

                    try
                    {
                        spell.Cast();
                    }
                    catch (Exception e)
                    {
                        Misc.ExceptionLogging.WriteLine(e);
                    }

                    if (from is TMobile)
                        from.SendGump(new QuickSpellLaunchGump((TMobile)from, m_Book, m_List));
                }
                else
                    from.SendMessage("L'objet doit rester dans votre sac en tout temps !");
            }
            else if (info.ButtonID >= 3000 && info.ButtonID != 0)
            {
                if (m_Book != null && (m_Book.Parent == from || (from.Backpack != null && m_Book.Parent == from.Backpack)))
                {
                    string name = "Nom inconnu";

                    SpellBookEntry entry = (SpellBookEntry)NewSpellbookGump.FindEntryBySpellID(info.ButtonID - 2000);

                    if (entry != null && m_Book.HasSpell(entry.SpellID))
                    {
                        name = entry.Nom;
                    }

                    from.SendMessage(name);

                    if (from is TMobile)
                        from.SendGump(new QuickSpellLaunchGump((TMobile)from, m_Book, m_List));
                }
                else
                    from.SendMessage("L'objet doit rester dans votre sac en tout temps !");
            }
        }
    }
}