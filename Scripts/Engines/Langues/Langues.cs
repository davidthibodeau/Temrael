using Server.Mobiles;
using Server.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Engines.Langues
{
    public class LangageWords
    {
        public static string[] LangueCommune =
            "estu parti an odus cristi est menos puras victus sancti bridus mocta linus abun dare".Split(" ".ToCharArray());
        public static string[] LangueRunique =
            "KEL ART IN POR TOR KARTRAK RAVINAR MANI UN".Split(" ".ToCharArray());
        public static string[] LangueDunes =
            "بية العربية ب المغرب العربية قطر الكويت الأردن قطر السعودية العر الجزائر".Split(" ".ToCharArray());
        public static string[] LangueElfique =
            "A Elbereth Gilthoniel silivren penna míriel o menel aglar elenath Na-chaered palan-díriel".Split(" ".ToCharArray());
        public static string[] LangueNordique =
            "зақс Қаза стан едонс кед дони нија Српск бија и Црна Гора mål Бълга ария".Split(" ".ToCharArray());
        public static string[] LangueMorte =
            "ปร ะเท ศไ ทย ภา ษาธิ ไทยรู้".Split(" ".ToCharArray());
        public static string[] LangueOrcish =
            "한 국 어 한 국 灣 台 語 中 文 新 加 坡".Split(" ".ToCharArray());
        public static string[] LangueNoire =
            "ԱԾ ՂՃՅ ՇՆԻ ԷԹ ԵՖ ՔՓՑ".Split(" ".ToCharArray());
    }

    public enum Langue
    {
        Commune = 0,
        Runique = 1,
        Dunes = 2,
        Elfique = 3,
        Nordique = 4,
        Morte = 5,
        Orcish = 6,
        Noire = 7
    }

    [PropertyObject]
    public class Langues
    {
        private Mobile m_Mobile;

		private bool[] m_Langues = new bool[]{
               true, //Commune,
               false, //Runique,
               false, //Dunes,
               false, //Elfique,
               false, //Nordique,
               false, //Morte,
               false, //Orcish,
               false  //Noire
        };

        private List<int> m_DerniereLangueApprise = new List<int>();
        private Langue m_CurrentLangue = Langue.Commune;

        [CommandProperty(AccessLevel.GameMaster)]
        public Langue CurrentLangue
        {
			get { return m_CurrentLangue; }
            set { m_CurrentLangue = value; }
        }

        #region Langues Getters & Setters

		public bool this[int i]
		{
			get { return m_Langues[i]; }
			set
			{
				if (value && !m_Langues[i])
					m_DerniereLangueApprise.Add(i);
				else if (!value && m_Langues[i])
					m_DerniereLangueApprise.Remove(i);
				m_Langues[i] = value;
			}
		}

		public bool this[Langue l]
		{
			get { return this[(int)l]; }
			set { this[(int)l] = value; }
		}

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Commune
        {
			get { return this[0]; }
            set { this[0] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Runique
        {
            get { return this[1]; }
            set { this[1] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Dunes
        {
            get { return this[2]; }
            set { this[2] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Elfique
        {
            get { return this[3]; }
            set { this[3] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Nordique
        {
            get { return this[4]; }
            set { this[4] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Morte
        {
            get { return this[5]; }
            set { this[5] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Orcish
        {
            get { return this[6]; }
            set { this[6] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Noire
        {
            get { return this[7]; }
            set { this[7] = value; }
        }
        #endregion

        public Langues(Mobile m)
        {
            m_Mobile = m;
        }

        public Langues(Mobile m, GenericReader reader)
            : this(m)
        {
            int version = reader.ReadInt();

            int count = reader.ReadInt();
            for (int i = 0; i < count; i++)
                this[reader.ReadInt()] = true;

			m_CurrentLangue = (Langue)reader.ReadInt();
        }

		public void Apprendre(int i)
		{
			Apprendre((Langue)i);
		}
			
        public void Apprendre(Langue l)
        {
            if (!this[l])
            {
				this[l] = true;
				m_Mobile.SendMessage("Vous apprenez la langue: " + l.ToString());
            }
            else
                m_Mobile.SendMessage("Vous connaissez déjà la langue: " + l.ToString());
        }

        public void ResetLangues()
        {
            for (int i = 0; i < m_DerniereLangueApprise.Count; i++)
            {
                m_Langues[m_DerniereLangueApprise[i]] = false;
                m_DerniereLangueApprise.RemoveAt(i);
            }
        }

        public void FixLangues()
        {
            int nbrLangue = 0;
            for (int i = 0; i < 8; i++)
            {
                if (this[i])
                    nbrLangue++;
            }

            if (nbrLangue > m_Mobile.Skills.ConnaissanceLangue.Fixed / 200 + 2)
            {
                int last = m_DerniereLangueApprise.Count - 1;
                m_Langues[m_DerniereLangueApprise[last]] = false;
                m_Mobile.SendMessage("Vous n'avez pas assez de points en Connaissance (Langue) pour parler " + nbrLangue + " langues.");
                m_Mobile.SendMessage("La dernière langue choisie (" + (Langue)m_DerniereLangueApprise[last] + ") vous est retirée.");
                m_DerniereLangueApprise.RemoveAt(last);
                FixLangues();
            }
        }

        public bool MutateSpeech(ref string text)
        {
            string[] split = text.Split(' ');
            for (int i = 0; i < split.Length; ++i)
            {
                if (m_CurrentLangue == Langue.Commune)
                    split[i] = LangageWords.LangueCommune[Utility.Random(LangageWords.LangueCommune.Length)];
                else if (m_CurrentLangue == Langue.Runique)
                    split[i] = LangageWords.LangueRunique[Utility.Random(LangageWords.LangueRunique.Length)];
                else if (m_CurrentLangue == Langue.Dunes)
                    split[i] = LangageWords.LangueDunes[Utility.Random(LangageWords.LangueDunes.Length)];
                else if (m_CurrentLangue == Langue.Elfique)
                    split[i] = LangageWords.LangueElfique[Utility.Random(LangageWords.LangueElfique.Length)];
                else if (m_CurrentLangue == Langue.Nordique)
                    split[i] = LangageWords.LangueNordique[Utility.Random(LangageWords.LangueNordique.Length)];
                else if (m_CurrentLangue == Langue.Morte)
                    split[i] = LangageWords.LangueMorte[Utility.Random(LangageWords.LangueMorte.Length)];
                else if (m_CurrentLangue == Langue.Orcish)
                    split[i] = LangageWords.LangueOrcish[Utility.Random(LangageWords.LangueOrcish.Length)];
                else
                    split[i] = LangageWords.LangueNoire[Utility.Random(LangageWords.LangueNoire.Length)];
            }
            text = String.Join(" ", split);
            return true;
        }

        public bool HearsGibberish(PlayerMobile m)
        {
            Langues interlocuteur = m.Langues;

            if (m.AccessLevel >= AccessLevel.GameMaster || interlocuteur[m_CurrentLangue])
            {
                if (m_CurrentLangue != interlocuteur.CurrentLangue)
                {
                    string sla = CurrentLangue.ToString();
                    m.NetState.Send(new UnicodeMessage(m_Mobile.Serial, m_Mobile.Body, MessageType.Regular, 0x3B2, 3,
                                                       m_Mobile.Language, m_Mobile.GetNameUseBy(m), "[" + sla + "]"));
                }
                return true;
            }
            return false;
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write(0); //version
            
            writer.Write(m_DerniereLangueApprise.Count);
            for (int i = 0; i < m_DerniereLangueApprise.Count; i++)
                writer.Write(m_DerniereLangueApprise[i]);    
            
			writer.Write((int)m_CurrentLangue);
        }
    }
}
