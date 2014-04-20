using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Server.Gumps;
using Server.Commands;
using Server.Network;
using Server.Accounting;
using Server.Mobiles;
using Server.Prompts;


namespace Server.Systemes
{
    public class CompensationGump : Gump
    {

        private static Dictionary<Account, MJ> compensations;
        private static List<MJ> compensationsIndexed;

        public static void Configure()
		{
			EventSink.WorldLoad += new WorldLoadEventHandler( Load );
			EventSink.WorldSave += new WorldSaveEventHandler( Save );
		}

        public static void Initialize()
        {
            CommandSystem.Register("Compensation", AccessLevel.Player, new CommandEventHandler(Compensation_OnCommand));

            foreach (MJ mj in GetMJs())
            {
                mj.Init();
                compensations.Add(mj.AccountJoueur, mj);
                
            }
        }

        [Usage("Compensation")]
        [Description("Accès au système de compensation MJ")]
        private static void Compensation_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;
            if (from.AccessLevel < AccessLevel.Owner)
            {

                MJ mj = GetMJ((Account)from.Account);
                if (mj == null)
                {
                    from.SendMessage("Cette commande n'est pas accessible.");
                }
                else
                {
                    Account acc = mj.AccountJoueur;
                    if (mj.IndexPersonnage >= acc.Length)
                        from.SendMessage("Il n'y a aucun personnage qui reçoit l'expérience en ce moment");
                    else
                    {
                        if (acc[mj.IndexPersonnage] != null)
                            from.SendMessage("Le personnage qui reçoit l'expérience est : " + acc[mj.IndexPersonnage].Name);
                        else
                            from.SendMessage("Aucun personnage ne reçoit l'expérience.");

                    } from.SendMessage("Veuillez indiquer l'index du personnage qui recevra l'expérience.");
                    for (int i = 0; i < acc.Length; i++)
                    {
                        if(acc[i] != null)
                            from.SendMessage("#" + i + ". " + acc[i].Name);
                    }
                    from.Prompt = new IndexPJPrompt(mj);
                }
            }
            else
            {
                from.SendGump(new CompensationGump(0));
            }
        }

        public static void WriteLine(string text)
        {
           try
           {
               string directory = Directories.AppendPath(Directories.logs, "Compensation");

				string path = Path.Combine( directory, String.Format( "{0}.log", Directories.Today ) );

				using ( StreamWriter sw = new StreamWriter( path, true ) )
					sw.WriteLine( "[{0}] {1}", DateTime.Now, text);
			}
			catch
			{
			}
        }

        private static void Save(WorldSaveEventArgs e)
        {
            string path = Directories.AppendPath(Directories.saves, "Compensations");

			string filePath = Path.Combine( path, "compensations.xml" );

            using (StreamWriter op = new StreamWriter(filePath))
            {
                XmlTextWriter xml = new XmlTextWriter(op);

                xml.Formatting = Formatting.Indented;
                xml.IndentChar = '\t';
                xml.Indentation = 1;

                xml.WriteStartDocument(true);

                xml.WriteStartElement("compensations");

                foreach (MJ mj in compensationsIndexed)
                {
                    xml.WriteStartElement("mj");
                    mj.Save(xml);
                    xml.WriteEndElement();
                }
                xml.WriteStartElement("lastreset");
                xml.WriteString(XP.LastReset.ToString());
                xml.WriteEndElement();
                xml.Close();
            }
        }

        private static void Load()
        {
            compensations = new Dictionary<Account, MJ>();
            compensationsIndexed = new List<MJ>();

            string path = Directories.AppendPath(Directories.saves, "Compensations");
            string filePath = Path.Combine(path, "compensations.xml");

			if ( !File.Exists( filePath ) )
				return;

			XmlDocument doc = new XmlDocument();
			doc.Load( filePath );

            XmlElement root = doc["compensations"];

            foreach (XmlElement mj in root.GetElementsByTagName("mj"))
            {
                MJ m = new MJ(mj);
                compensationsIndexed.Add(m);
            }
            XP.LastReset = Utility.GetXMLDateTime(Utility.GetText(root["lastreset"], null), DateTime.Now);
        }

        public static MJ GetMJ(Account acc)
        {
            MJ mj = null;
            compensations.TryGetValue(acc, out mj);
            return mj;
        }

        public static ICollection<MJ> GetMJs()
        { //J'suis pas certain que la precondition soit pertinente...
#if !MONO
            return compensationsIndexed;
#else
			return new List<MJ>( compensationsIndexed );
#endif
        }

        public class MJ
        {
            private string m_Nom;
            private int m_XpGainedThisWeek;
            private DateTime m_NextCompensation;
            private Account m_AccountJoueur;
            private string accountname;
            private int m_IndexPersonnage;

            public string Nom { get { return m_Nom; } set { m_Nom = value; } }
            public DateTime NextCompensation { get { return m_NextCompensation; } }
            public Account AccountJoueur { get { return m_AccountJoueur; } }
            public int XpGainedThisWeek { get { return m_XpGainedThisWeek; } set { m_XpGainedThisWeek = value; } }
            public int IndexPersonnage { get { return m_IndexPersonnage; } set { m_IndexPersonnage = value; } }

            public MJ(string nom, Account account, int index)
            {
                m_Nom = nom;
                m_AccountJoueur = account;
                m_NextCompensation = DateTime.Now.AddDays(7.0);
                m_IndexPersonnage = index;
                m_XpGainedThisWeek = 0;
            }

            public MJ(XmlElement node)
            {
                m_Nom = Utility.GetText(node["nom"], "empty");
                m_XpGainedThisWeek = Utility.GetXMLInt32(Utility.GetText(node["xpthisweek"], "0"), 0);
                m_NextCompensation = Utility.GetXMLDateTime(Utility.GetText(node["nextcomp"], null), DateTime.Now.AddDays(7));
                m_IndexPersonnage = Utility.GetXMLInt32(Utility.GetText(node["indexchar"], "0"), 0);
                accountname = Utility.GetText(node["account"], "empty");
            }

            public void Init()
            {
                m_AccountJoueur = (Account) Accounts.GetAccount(accountname);
            }

            public void Save(XmlTextWriter xml)
            {
                xml.WriteStartElement("nom");
                xml.WriteString(m_Nom);
                xml.WriteEndElement();

                xml.WriteStartElement("xpthisweek");
                xml.WriteString(XmlConvert.ToString(m_XpGainedThisWeek));
                xml.WriteEndElement();

                xml.WriteStartElement("nextcomp");
                xml.WriteString(XmlConvert.ToString(m_NextCompensation, XmlDateTimeSerializationMode.Local));
                xml.WriteEndElement();

                xml.WriteStartElement("indexchar");
                xml.WriteString(XmlConvert.ToString(m_IndexPersonnage));
                xml.WriteEndElement();

                xml.WriteStartElement("account");
                xml.WriteString(m_AccountJoueur.Username);
                xml.WriteEndElement();
            }

            public void PayerXP()
            {
                if (m_AccountJoueur == null)
                    return;
                TMobile pj = (TMobile)m_AccountJoueur[m_IndexPersonnage];
                if (pj == null)
                {
                    WriteLine(String.Format("{0} n'a pas de personnage valide associé pour y déposer l'expérience.", m_Nom));
                    return;
                }
                int maxXP = 0;
                switch (XP.GetCote(pj))
                {
                    case 0:
                    case 1: maxXP = 10850; break;
                    case 2: maxXP = 13020; break;
                    case 3: maxXP = 15190; break;
                    case 4: maxXP = 17360; break;
                    case 5: maxXP = 21700; break;
                }

                int diff = maxXP - m_XpGainedThisWeek;
                if (diff > 10000)
                    pj.XP += 10000;
                else if (diff > 0)
                    pj.XP += diff;
                WriteLine(String.Format("{0} a accumule la somme de {1} xp cette semaine. Il sera donc paye {2} xp.",
                    pj.Name, m_XpGainedThisWeek, Math.Min(Math.Max(diff,0), 10000)));
                m_NextCompensation = DateTime.Now.AddDays(6.3);
                m_XpGainedThisWeek = 0;
             }
        }

        private int page;
        private MJ mj;

        public CompensationGump(int page) : base(50, 50)
        {
            this.page = page;

            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);
			AddBackground(31, 48, 416, 432, 9250);
			AddBackground(39, 56, 400, 417, 3500);
			AddLabel(174, 78, 1301, @"Compensations MJ");
            AddButton(285, 430, 4005, 4006, (int)Buttons.AjouterMJ, GumpButtonType.Reply, 0);
			AddLabel(185, 431, 1301, @"Ajouter un MJ");

            int basey = 110;
            for (int i = 0; i < compensationsIndexed.Count; i++)
            {
                if (i >= (page + 1) * 10)
                    break;
                if (i < page * 10)
                    continue;
                MJ m = compensationsIndexed[i];
                AddLabel(80, basey + (i % 10) * 30, 1301, m.Nom);
                AddLabel(270, basey + (i % 10) * 30, 1301, m.AccountJoueur.Username);
                AddButton(383, basey + (i % 10) * 30 - 1, 4005, 4006, i + 10, GumpButtonType.Reply, 0);
                
            }
            AddButton(402, 411, 5601, 5605, (int)Buttons.NextPage, GumpButtonType.Reply, 0);
			AddButton(61, 410, 5603, 5607, (int)Buttons.PreviousPage, GumpButtonType.Reply, 0);

        }

        public CompensationGump(MJ mj)
            : base(50, 50)
        {
            this.mj = mj;

            this.Closable = true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);
			AddBackground(31, 48, 416, 246, 9250);
			AddBackground(39, 56, 400, 231, 3500);
			AddLabel(206, 75, 1301, @"Compensations MJ");
			
			AddLabel(81, 110, 1301, @"Maitre du Jeu :");
            AddLabel(210, 110, 1301, mj.Nom);
            //AddButton(383, 109, 4005, 4006, (int)Buttons.ChangerNom, GumpButtonType.Reply, 0);

			AddLabel(81, 140, 1301, @"Account Joueur :");
            AddLabel(210, 140, 1301, mj.AccountJoueur.Username);

			AddLabel(81, 170, 1301, @"Personnage :");
			AddLabel(210, 170, 1301, mj.AccountJoueur[mj.IndexPersonnage].Name);
			AddButton(383, 169, 4005, 4006, (int)Buttons.ChangerPersonnage, GumpButtonType.Reply, 0);

            AddLabel(81, 200, 1301, @"Prochaine Compensation :");
			AddLabel(210, 200, 1301, mj.NextCompensation.ToString());


            AddLabel(196, 241, 1301, @"Supprimer");
            AddButton(275, 240, 4005, 4006, (int)Buttons.SupprimerMJ, GumpButtonType.Reply, 0);
        }

        public enum Buttons
        {
            AjouterMJ = 1,
            NextPage,
            PreviousPage,
            SupprimerMJ,
            //ChangerNom,
            ChangerPersonnage,
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            int i = info.ButtonID;
            switch (i)
            {
                case 0:
                    if (mj != null)
                        from.SendGump(new CompensationGump(0));
                    break;
                case (int)Buttons.AjouterMJ:
                    from.SendMessage("Veuillez entrer le nom du MJ.");
                    from.Prompt = new NomMJPrompt();
                    break;
                   
                case (int)Buttons.NextPage:
                    from.SendGump(new CompensationGump(page + 1));
                    break;
                    
                case (int)Buttons.PreviousPage:
                    from.SendGump(new CompensationGump(page - 1));
                    break;

                case (int)Buttons.SupprimerMJ:
                    from.SendMessage("Souhaitez-vous vraiment supprimer la compensation de " + mj.Nom + "?");
                    from.Prompt = new SupprimerMJPrompt(mj);
                    break;

                //case (int)Buttons.ChangerNom:
                //    from.SendMessage("Veuillez entrer le nouveau nom du MJ.");
                //    from.Prompt = new NomMJPrompt(mj);
                //    break;

                case (int)Buttons.ChangerPersonnage:
                    from.SendMessage("Veuillez indiquer l'index du personnage qui recevra l'expérience.");
                    for (int j = 0; j < mj.AccountJoueur.Count; j++)
                    {
                        from.SendMessage("#" + j + ". " + mj.AccountJoueur[j].Name);
                    }
                    from.Prompt = new IndexPJPrompt(mj);
                    break;

                default:
                    if (i >= 10 && i < 10 + compensationsIndexed.Count)
                    {
                        from.SendGump(new CompensationGump(compensationsIndexed[i - 10]));
                    }
                    else
                        from.SendGump(new CompensationGump(page));
                    break;
            }
        }

        private class NomMJPrompt : Prompt
        {

            private MJ mj;

            public NomMJPrompt()
            {
            }

            public NomMJPrompt(MJ mj)
            {
                this.mj = mj;
            }
            
            public override void OnResponse(Mobile from, string text)
            {
                if (mj == null)
                {
                    from.SendMessage("Veuillez indiquer le nom de son account joueur.");
                    from.Prompt = new AccountPJPrompt(text);
                }
                else
                {
                    from.SendMessage("Le nouveau nom de l'entrée est : " + text);
                    mj.Nom = text;
                    from.SendGump(new CompensationGump(mj));
                }
            }

            public override void OnCancel(Mobile from)
            {
                if (mj == null)
                    from.SendMessage("La création de l'entrée est annulée.");
                else
                    from.SendMessage("Le nom n'a pas été modifié.");
            }
        }

        private class AccountPJPrompt : Prompt
        {
            private string nomMJ;

            public AccountPJPrompt(string mj)
            {
                nomMJ = mj;
            }
            
            public override void OnResponse(Mobile from, string text)
            {
                Account acc = Accounts.GetAccount(text) as Account;
                if (acc == null)
                {
                    from.SendMessage("Cet account n'existe pas. Veuillez réessayer.");
                    from.Prompt = new AccountPJPrompt(nomMJ);
                }
                else
                {
                    from.SendMessage("Veuillez indiquer l'index du personnage qui recevra l'expérience.");
                    for (int i = 0; i < acc.Length; i++)
                    {
                        if(acc[i] != null)
                            from.SendMessage("#" + i + ". " + acc[i].Name);
                    }
                    from.Prompt = new IndexPJPrompt(nomMJ, acc);
                }
            }

            public override void OnCancel(Mobile from)
            {
                from.SendMessage("La création de l'entrée est annulée.");
                from.SendGump(new CompensationGump(0));
            }
        }

        private class IndexPJPrompt : Prompt
        {
            private string nomMJ;
            private Account accPJ;

            private MJ mj;

            public IndexPJPrompt(string mj, Account pj)
            {
                nomMJ = mj;
                accPJ = pj;
            }

            public IndexPJPrompt(MJ mj)
            {
                this.mj = mj;
            }
            
            public override void OnResponse(Mobile from, string text)
            {
                if (this.mj == null)
                {
                    try
                    {
                        int index = Convert.ToInt32(text);
                        if (index < 0 || index >= accPJ.Length || accPJ[index] == null)
                        {
                            from.SendMessage("L'index que vous avez entré est invalide. Veuillez réessayer.");
                            from.Prompt = new IndexPJPrompt(nomMJ, accPJ);
                        }
                        else
                        {
                            from.SendMessage("L'entrée est créée.");
                            MJ mj = new MJ(nomMJ, accPJ, index);
                            compensations.Add(accPJ, mj);
                            compensationsIndexed.Add(mj);
                        }
                    }
                    catch
                    {
                        from.SendMessage("L'index que vous avez entré est invalide. Veuillez réessayer.");
                        from.Prompt = new IndexPJPrompt(nomMJ, accPJ);
                    }
                }
                else
                {
                    try
                    {
                        int index = Convert.ToInt32(text);
                        if (index < 0 || index >= mj.AccountJoueur.Count)
                        {
                            from.SendMessage("L'index que vous avez entré est invalide. Veuillez réessayer.");
                            from.Prompt = new IndexPJPrompt(mj);
                        }
                        else
                        {
                            from.SendMessage("Le personnage a été changé.");
                            mj.IndexPersonnage = index;
                        }
                    }
                    catch
                    {
                        from.SendMessage("L'index que vous avez entré est invalide. Veuillez réessayer.");
                        from.Prompt = new IndexPJPrompt(mj);
                    }
                }
            }

            public override void OnCancel(Mobile from)
            {
                if (mj == null)
                {
                    from.SendMessage("La création de l'entrée est annulée.");
                    from.SendGump(new CompensationGump(0));
                }
                else
                {
                    from.SendMessage("Le personnage n'a pas été changé.");
                    if (from.AccessLevel == AccessLevel.Owner)
                        from.SendGump(new CompensationGump(mj));
                }
            }
        }

        private class SupprimerMJPrompt : Prompt
        {
            MJ mj;

            public SupprimerMJPrompt(MJ mj)
            {
                this.mj = mj;
            }
            
            public override void OnResponse(Mobile from, string text)
            {
                if (string.Equals(text, "oui", StringComparison.CurrentCultureIgnoreCase))
                {
                    string nom = mj.Nom;
                    compensations.Remove(mj.AccountJoueur);
                    compensationsIndexed.Remove(mj);
                    from.SendMessage(nom + " a été supprimé.");
                    from.SendGump(new CompensationGump(0));
                }
                else if (string.Equals(text, "non", StringComparison.CurrentCultureIgnoreCase))
                {
                    from.SendMessage(mj.Nom + " n'a pas été supprimé.");
                    from.SendGump(new CompensationGump(mj));
                }
                else
                {
                    from.SendMessage("Vous devez répondre par oui ou non.");
                    from.Prompt = new SupprimerMJPrompt(mj);
                }
            }

            public override void OnCancel(Mobile from)
            {
                from.SendMessage(mj.Nom + " n'a pas été supprimé.");
                from.SendGump(new CompensationGump(mj));
            }
        }

    }
}
