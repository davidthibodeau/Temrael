using Server.ContextMenus;
using Server.Mobiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Quetes
{
    [PropertyObject]
    public class MonstreQueteInfo
    {

        private Mobile temp_from = null;
        private bool m_Quest = false;

        private string m_QuestTitre = "";
        private string m_QuestDescription = "";
        private string m_QuestTag = "";
        private string m_QuestTagCompletion = "";
        private string m_QuestNextTitre = "";
        private string m_QuestNextDescription = "";

        private Body m_QuestMobileID = 0;
        private int m_QuestItemID = 0;

        private int m_QuestExpBonus = 0;
        private Item m_QuestItemRecompense = null;
        private Item m_QuestItemCompletion = null;
        private Mobile m_QuestMobileCompletion = null;
        private const int m_QuestRangeConst = 10;

        private string m_QuestSpeechStart = "";
        private string m_QuestSpeechDuring = "";
        private string m_QuestSpeechComplete = "";


        [CommandProperty(AccessLevel.Batisseur)]
        public bool Quete
        {
            get { return m_Quest; }
            set { m_Quest = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public string QueteTitre
        {
            get { return m_QuestTitre; }
            set { m_QuestTitre = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public string QueteDescription
        {
            get { return m_QuestDescription; }
            set { m_QuestDescription = value; }
        }
        [CommandProperty(AccessLevel.Batisseur)]
        public string QueteTag
        {
            get { return m_QuestTag; }
            set { m_QuestTag = value; }
        }
        [CommandProperty(AccessLevel.Batisseur)]
        public string QueteTagCompletion
        {
            get { return m_QuestTagCompletion; }
            set { m_QuestTagCompletion = value; }
        }
        [CommandProperty(AccessLevel.Batisseur)]
        public string QueteNextTitre
        {
            get { return m_QuestNextTitre; }
            set { m_QuestNextTitre = value; }
        }
        [CommandProperty(AccessLevel.Batisseur)]
        public string QueteNextDescription
        {
            get { return m_QuestNextDescription; }
            set { m_QuestNextDescription = value; }
        }
        [CommandProperty(AccessLevel.Batisseur)]
        public int QueteExp
        {
            get { return m_QuestExpBonus; }
            set { m_QuestExpBonus = value; }
        }
        [CommandProperty(AccessLevel.Batisseur)]
        public Item QueteObjetRecompense
        {
            get { return m_QuestItemRecompense; }
            set { m_QuestItemRecompense = value; }
        }
        [CommandProperty(AccessLevel.Batisseur)]
        public Item QueteObjetCompletion
        {
            get { return m_QuestItemCompletion; }
            set { m_QuestItemCompletion = value; }
        }
        [CommandProperty(AccessLevel.Batisseur)]
        public Mobile QueteNPCCompletion
        {
            get { return m_QuestMobileCompletion; }
            set { m_QuestMobileCompletion = value; }
        }
        [CommandProperty(AccessLevel.Batisseur)]
        public string QueteSpeechDebut
        {
            get { return m_QuestSpeechStart; }
            set { m_QuestSpeechStart = value; }
        }
        [CommandProperty(AccessLevel.Batisseur)]
        public string QueteSpeechDurant
        {
            get { return m_QuestSpeechDuring; }
            set { m_QuestSpeechDuring = value; }
        }
        [CommandProperty(AccessLevel.Batisseur)]
        public string QueteSpeechFin
        {
            get { return m_QuestSpeechComplete; }
            set { m_QuestSpeechComplete = value; }
        }
        [CommandProperty(AccessLevel.Batisseur)]
        public Body QueteMobileID
        {
            get { return m_QuestMobileID; }
            set { m_QuestMobileID = value; }
        }
        [CommandProperty(AccessLevel.Batisseur)]
        public int QueteItemID
        {
            get { return m_QuestItemID; }
            set { m_QuestItemID = value; }
        }

        private void QuestContext()
        {
            if (temp_from == null)
                return;

            /*if (temp_from is TMobile)
            {
                TMobile from = (TMobile)temp_from;

                if (!(m_QuestTag == ""))
                {
                    if (from.TagList.Contains(m_QuestTag))
                    {
                        from.SendMessage("Vous avez deja complete cette quete !");
                        SayTo(from, "Je n'ai pas de travail pour vous en ce moment.");
                    }
                }

                if (m_QuestTitre == from.QueteTitre)
                {
                    //Si un mobile
                    if (m_QuestMobileID > 0)
                    {
                        bool completion = false;
                        IPooledEnumerable eable = from.GetItemsInRange(m_QuestRangeConst);

                        foreach (Mobile m in eable)
                        {
                            if (m.Body == m_QuestMobileID)
                            {
                                if (!(m_QuestItemRecompense == null))
                                    from.Backpack.AddItem(m_QuestItemRecompense);

                                if (m_QuestExpBonus > 0)
                                    from.XP += m_QuestExpBonus;

                                if (!(m_QuestTag == ""))
                                    from.TagList.Add(m_QuestTag);

                                SayTo(from, m_QuestSpeechComplete);
                                //from.Backpack.RemoveItem(m);

                                from.QueteTitre = "";
                                from.QueteDescription = "";

                                completion = true;
                            }
                        }
                        eable.Free();

                        if (completion == false)
                        {
                            SayTo(from, m_QuestSpeechDuring);
                        }
                    }
                    else if (!(m_QuestMobileCompletion == null))
                    {
                        bool completion = false;
                        IPooledEnumerable eable = from.GetItemsInRange(m_QuestRangeConst);

                        foreach (Mobile m in eable)
                        {
                            if (m.Equals(m_QuestMobileCompletion))
                            {
                                if (!(m_QuestItemRecompense == null))
                                    from.Backpack.AddItem(m_QuestItemRecompense);

                                if (m_QuestExpBonus > 0)
                                    from.XP += m_QuestExpBonus;

                                if (!(m_QuestTag == ""))
                                    from.TagList.Add(m_QuestTag);

                                SayTo(from, m_QuestSpeechComplete);
                                //from.Backpack.RemoveItem(m);

                                from.QueteTitre = "";
                                from.QueteDescription = "";

                                completion = true;
                            }
                        }

                        eable.Free();

                        if (completion == false)
                        {
                            SayTo(from, m_QuestSpeechDuring);
                        }
                    }
                    //Si un item
                    else if (m_QuestItemID  > 0)
                    {
                        bool completion = false;
                        Item item = null;
                        foreach (Item i in from.Backpack.Items)
                        {
                            if (i.ItemID == m_QuestItemID)
                            {
                                if (!(m_QuestItemRecompense == null))
                                    from.Backpack.AddItem(m_QuestItemRecompense);

                                if (m_QuestExpBonus > 0)
                                    from.XP += m_QuestExpBonus;

                                if (!(m_QuestTag == ""))
                                    from.TagList.Add(m_QuestTag);

                                SayTo(from, m_QuestSpeechComplete);
                                item = i;
                                //from.Backpack.RemoveItem(i);

                                from.QueteTitre = "";
                                from.QueteDescription = "";

                                completion = true;
                            }
                        }
                        if (!(item == null))
                            from.Backpack.RemoveItem(item);
                        if (completion == false)
                        {
                            SayTo(from, m_QuestSpeechDuring);
                        }
                    }
                    else if (!(m_QuestItemCompletion == null))
                    {
                        bool completion = false;
                        Item item = null;
                        foreach (Item i in from.Backpack.Items)
                        {
                            if (i.Equals(m_QuestItemCompletion))
                            {
                                if (!(m_QuestItemRecompense == null))
                                    from.Backpack.AddItem(m_QuestItemRecompense);

                                if (m_QuestExpBonus > 0)
                                    from.XP += m_QuestExpBonus;

                                if (!(m_QuestTag == ""))
                                    from.TagList.Add(m_QuestTag);

                                SayTo(from, m_QuestSpeechComplete);
                                item = i;
                                //from.Backpack.RemoveItem(i);

                                from.QueteTitre = "";
                                from.QueteDescription = "";

                                completion = true;
                            }
                        }
                        if (!(item == null))
                            from.Backpack.RemoveItem(item);
                        if (completion == false)
                        {
                            SayTo(from, m_QuestSpeechDuring);
                        }
                    }
                    //Si un tag
                    else if (!(m_QuestTagCompletion == null))
                    {
                        bool completion = false;

                        foreach (string s in from.TagList)
                        {
                            if (s == m_QuestTagCompletion)
                            {
                                if (!(m_QuestItemRecompense == null))
                                    from.Backpack.AddItem(m_QuestItemRecompense);

                                if (m_QuestExpBonus > 0)
                                    from.XP += m_QuestExpBonus;

                                if (!(m_QuestTag == ""))
                                    from.TagList.Add(m_QuestTag);

                                SayTo(from, m_QuestSpeechComplete);

                                if (!(m_QuestNextTitre == ""))
                                    from.QueteTitre = m_QuestNextTitre;
                                else
                                    from.QueteTitre = "";
                                if (!(m_QuestNextDescription == ""))
                                    from.QueteDescription = m_QuestNextDescription;
                                else
                                    from.QueteDescription = "";

                                completion = true;
                            }
                        }
                        if (completion == false)
                        {
                            SayTo(from, m_QuestSpeechDuring);
                        }
                    }
                    else
                    {
                        SayTo(from, m_QuestSpeechDuring);
                    }
                }
                else
                {
                    if (!(m_QuestTitre == ""))
                        from.QueteTitre = m_QuestTitre;
                    if (!(m_QuestDescription == ""))
                        from.QueteDescription = m_QuestDescription;

                    SayTo(from, m_QuestSpeechStart);
                }
            }*/
        }

        public MonstreQueteInfo()
        {
        }

        public MonstreQueteInfo(GenericReader reader)
        {
            m_Quest = reader.ReadBool();
            m_QuestTitre = reader.ReadString();
            m_QuestDescription = reader.ReadString();
            m_QuestTag = reader.ReadString();
            m_QuestTagCompletion = reader.ReadString();
            m_QuestNextTitre = reader.ReadString();
            m_QuestNextDescription = reader.ReadString();

            m_QuestMobileID = (Body)reader.ReadInt();
            m_QuestItemID = reader.ReadInt();

            m_QuestExpBonus = reader.ReadInt();
            m_QuestItemRecompense = reader.ReadItem();
            m_QuestItemCompletion = reader.ReadItem();
            m_QuestMobileCompletion = reader.ReadMobile();

            m_QuestSpeechStart = reader.ReadString();
            m_QuestSpeechDuring = reader.ReadString();
            m_QuestSpeechComplete = reader.ReadString();
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write((bool)m_Quest);
            writer.Write((string) m_QuestTitre);
            writer.Write((string) m_QuestDescription);
            writer.Write((string) m_QuestTag);
            writer.Write((string) m_QuestTagCompletion);
            writer.Write((string) m_QuestNextTitre);
            writer.Write((string) m_QuestNextDescription);

            writer.Write((Body) m_QuestMobileID);
            writer.Write((int) m_QuestItemID);

            writer.Write((int) m_QuestExpBonus);
            writer.Write((Item) m_QuestItemRecompense);
            writer.Write((Item) m_QuestItemCompletion);
            writer.Write((Mobile) m_QuestMobileCompletion);

            writer.Write((string) m_QuestSpeechStart);
            writer.Write((string) m_QuestSpeechDuring);
            writer.Write((string) m_QuestSpeechComplete);
        }

        public void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            if (m_Quest == true)
            {
                temp_from = from;
                list.Add(new PlayerMobile.CallbackEntry(6094, new Server.Mobiles.PlayerMobile.ContextCallback(QuestContext)));
            }
        }
    }
}
