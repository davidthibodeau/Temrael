using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Gumps;
using Server.Items;
using Server.Spells;
using Server.Commands;
using Server.Targeting;
using System.Collections.Generic;

namespace Server.Gumps
{
    public class QuickSpellLaunchGump : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("qsl", AccessLevel.Player, new CommandEventHandler(QSL_OnCommand));
            //CommandSystem.Register("sort", AccessLevel.Player, new CommandEventHandler(Sort_OnCommand));
        }

        private static Dictionary<Mobile, NewSpellbook> Book = new Dictionary<Mobile, NewSpellbook>();

        [Usage("QSL")]
        [Description("Lance le menu de sorts rapides.")]
        public static void QSL_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from is PlayerMobile)
            {
                PlayerMobile m = (PlayerMobile)from;

                if (m != null)
                {
                    m.SendMessage("Choisissez le livre ou instrument a utiliser.");
                    m.BeginTarget(12, false, TargetFlags.None, new TargetCallback(QSL_OnTarget));
                }
            }
        }

        public static void QSL_OnTarget(Mobile from, object targ)
        {
            if (targ is NewSpellbook && from.Backpack != null && ((Item)targ).Parent == from.Backpack)
            {
                Book[from] = targ as NewSpellbook;
                from.SendGump(new QuickSpellLaunchGump((PlayerMobile)from, null));
            }
            else if (targ is BaseInstrument && from.Backpack != null && ((Item)targ).Parent == from.Backpack)
                from.SendGump(new QuickSpellLaunchGump((PlayerMobile)from, (BaseInstrument)targ, null));
        }

        [Usage( "Sort <ID> | <Name>" )]
		[Description( "Lance un sort en utilisant son ID ou son Nom." )]
        public static void Sort_OnCommand(CommandEventArgs e)
        {
            if (e.Length == 1)
            {
                if (Book[e.Mobile] == null)
                {
                    e.Mobile.SendMessage("Veuillez choisir le livre de sort en faisant .qsl");
                    return;
                }

                Spell spell = SpellRegistry.NewSpell(e.GetString(0), e.Mobile, null);

                if (spell == null)
                {
                    e.Mobile.SendMessage("Le nom du sort n'existe pas");
                    return;
                }
            }
            else
            {
                e.Mobile.SendMessage("Format: Sort <Nom>");
            }
        }

        private PlayerMobile m_From;
        private BaseInstrument m_Instrument;
        private ArrayList m_List;

        public static ArrayList GetSpellList(PlayerMobile from, NewSpellbook book)
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

        public QuickSpellLaunchGump(PlayerMobile from, ArrayList list)
            : base(150, 200)
        {
            try
            {
                if (list == null)
                    list = GetSpellList(from, Book[from]);

                if (list != null)
                {
                    m_List = list;

                    m_From = from;

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

                        SpellBookEntry entry = (SpellBookEntry)list[i];

                        //Console.WriteLine(((SpellBookEntry)obj).ToString() + " " + entry.ToString());

                        if (entry != null)
                        {
                            AddButton(74 + hindex * 44, 42 + vindex * 44, entry.ImageID, entry.ImageID, entry.SpellID, GumpButtonType.Reply, 0);
                            //AddButton(102 + hindex * 57, 71 + vindex * 45, 2103, 2104, entry.SpellID + 2000, GumpButtonType.Reply, 0);
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

        public QuickSpellLaunchGump(PlayerMobile from, BaseInstrument instrument, ArrayList list)
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
                if (Book[from] != null && (Book[from].Parent == from || (from.Backpack != null && Book[from].Parent == from.Backpack)))
                {
                    if (Book[from].HasSpell(info.ButtonID))
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
                    }                

                    if (from is PlayerMobile)
                        from.SendGump(new QuickSpellLaunchGump((PlayerMobile)from, m_List));
                }
                else
                    from.SendMessage("L'objet doit rester dans votre sac en tout temps !");
            }
            else if (info.ButtonID >= 3000 && info.ButtonID != 0)
            {
                if (Book[from] != null && (Book[from].Parent == from || (from.Backpack != null && Book[from].Parent == from.Backpack)))
                {
                    string name = "Nom inconnu";

                    SpellBookEntry entry = (SpellBookEntry)NewSpellbookGump.FindEntryBySpellID(info.ButtonID - 2000);

                    if (entry != null && Book[from].HasSpell(entry.SpellID))
                    {
                        name = entry.Nom;
                    }

                    from.SendMessage(name);

                    if (from is PlayerMobile)
                        from.SendGump(new QuickSpellLaunchGump((PlayerMobile)from, m_List));
                }
                else
                    from.SendMessage("L'objet doit rester dans votre sac en tout temps !");
            }
        }
    }
}