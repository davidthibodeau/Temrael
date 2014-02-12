using System;
using System.IO;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Items;
using Server.Gumps;
using Server.Systemes;
using Server.Accounting;

namespace Server
{
    public class XP
    {
        public static Hashtable m_XPparNiveau = new Hashtable();
        public static Hashtable m_XPparNiveauAv100 = new Hashtable();
        public static Hashtable m_XPparNiveauAp100 = new Hashtable();
        public static Hashtable m_XPparCote = new Hashtable();
        public static Hashtable m_XPparCount = new Hashtable();
        public static TimeSpan m_IntervaleXP = TimeSpan.FromMinutes(10);

        private static double[] m_ExpGainTable = new double[] { 200.0, 250.0, 300.0, 350.0,
            400.0, 500.0, 600.0 };

        private static int[] m_ExpReqTable = new int[] { 0, 0, 1000, 3000,
            6000, 10000, 15000, 21000, 28000, 36000, 45000, 55000, 66000,
            78000, 91000, 105000, 120000, 136000, 153000, 171000, 190000,
            210000, 231000, 253000, 276000, 300000, 325000, 351000, 378000,
            405000, 435000
            };

        public static void Initialize()
        {
            MakeXPparNiveauAv100();
            MakeXPparNiveauAp100();
            MakeXPparCote();
            MakeXPparCount();
            
            new XPTimer().Start();
        }

        public class XPTimer : Timer
        {
            public XPTimer()
                : base(m_IntervaleXP, m_IntervaleXP)
            {
                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                //bool JoueurChangePallier = false;
                
                if (DateTime.Now.Hour == 3 && DateTime.Now.Minute <= 59 && DateTime.Now.Minute > 0)
                {
                    ResetEndOfDay();
                }

                foreach (NetState state in NetState.Instances)
                {
                    Mobile m = state.Mobile;

                    if (m != null && m is TMobile)
                    {
                        TMobile pm = (TMobile)m;

                        if (pm.NextExp < DateTime.Now)
                        {
                            CheckXP(pm);
                            pm.NextExp = DateTime.Now.AddMinutes(20);
                        }
                    }
                }
            }
        }

        public static void ResetEndOfDay()
        {
            ArrayList targets = new ArrayList();

            foreach (Mobile m in World.Mobiles.Values)
            {
                if (m is TMobile)
                    targets.Add((TMobile)m);
            }

            if (targets.Count > 0)
            {
                for (int i = 0; i < targets.Count; i++)
                {
                    TMobile pm = (TMobile)targets[i];

                    pm.CoteCount = 1;
                }
            }

            foreach (CompensationGump.MJ mj in Systemes.CompensationGump.GetMJs())
            {
                CompensationGump.WriteLine(String.Format(
                    "Verification de paiement pour {0}. Son prochain paiement est le {1}.", 
                    mj.Nom, mj.NextCompensation.ToString()));
                if (mj.NextCompensation < DateTime.Now)
                {
                    mj.PayerXP();
                }
            }
        }

        public static int GetCote(TMobile pm)
        {
            int CoteMoyenne = 0;

            foreach (int cotation in pm.ListCote)
            {
                CoteMoyenne += cotation;
            }

            if (pm.ListCote.Count > 0)
            {
                double avg = CoteMoyenne / (double)pm.ListCote.Count;
                if (avg - (int)avg < 0.5)
                    return (int)avg;
                else
                    return (int)avg + 1;
            }
            else
                return 0;
        }

        public static void CheckXP(TMobile pm)
        {
            if (pm == null)
                return;

            int CoteMoyenne = GetCote(pm);

            /*foreach (Cote cotation in pm.CoteList)
            {
                CoteMoyenne = cotation.GetCote();
            }*/

            //int Cote = pm.Cote;
            int Count = pm.CoteCount;
            int XPparCote = 1600;
            double XPparCount = 0.01;

            //CoteMoyenne += 5;

            if (CoteMoyenne > 5)
              {
                 CoteMoyenne = 5;
                 pm.Cote = 5;
              }

            if (CoteMoyenne < 0)
               {
                 CoteMoyenne = 0;
                 pm.Cote = 0;
               }

            if (m_XPparCote.Contains(CoteMoyenne))
                XPparCote = (int)m_ExpGainTable[CoteMoyenne];
                //XPparCote = (int)m_XPparCote[CoteMoyenne];

            if (m_XPparCount.Contains(Count))
                XPparCount = (double)m_XPparCount[Count];
            else
                XPparCount = 0.01;

            int XPgain = (int)(XPparCote * XPparCount);

            if (XPgain < 0)
            {
                XPgain = 0;
            }

            if (XPgain > 500)
                XPgain = 500;

            //pm.SendMessage(Convert.ToString(XPgain));
            //pm.SendMessage(Convert.ToString(CoteMoyenne));

            pm.XP += XPgain;

            CompensationGump.MJ mj = CompensationGump.GetMJ((Account)pm.Account);
            if (mj != null)
            {
                mj.XpGainedThisWeek += XPgain;
                CompensationGump.WriteLine(String.Format("{0} recoit {1} xp. Le total courant de la semaine est de {2}.",
                    mj.Nom, XPgain, mj.XpGainedThisWeek));
            }

            pm.CoteCount++;

            //if (AOS.Testing)
            //    pm.SendMessage("XP : " + XPgain.ToString());
        }

        public static void ChangePallier(TMobile pm)
        {
            if (pm == null)
                return;

            int Cote = pm.Cote;
            //int Pallier = 9;
            //double Moyenne = pm.GetAverageCote();         
        }

        public static void MakeXP()
        {
            int baseGain = 2000;
            int value = 1000;

            for (int i = 1; i < 101; i++)
            {
                if (i > 1)
                {
                    value += baseGain;
                    m_XPparNiveau[i] = value;
                }
                else
                {
                    m_XPparNiveau[i] = value;
                }
                baseGain += 1000;
            }
        }

        public static void MakeXPparNiveauAv100()
        {
            if (m_XPparNiveauAv100 == null)
                m_XPparNiveauAv100 = new Hashtable();

            for (int i = 1; i < 101; i++)
            {
                int value = (int)(250 * Math.Pow(i, 1.45));
                m_XPparNiveauAv100[i] = value;
            }
        }

        public static int MakeXPparNiveau126()
        {
            if (m_XPparNiveauAp100 == null)
                m_XPparNiveauAp100 = new Hashtable();

            for (int i = 100; i < 150; i++) //Après le niveau 150, on prend la formule directement.
            {
                int value = (int)(198582 + 1200 * Math.Pow(i - 100, 1.45));
                m_XPparNiveauAp100[i] = value;
            }
            return (int)m_XPparNiveauAp100[128];
        }

        public static void MakeXPparNiveauAp100()
        {
            if (m_XPparNiveauAp100 == null)
                m_XPparNiveauAp100 = new Hashtable();

            for (int i = 100; i < 151; i++) //Après le niveau 150, on prend la formule directement.
            {
                int value = (int)(198582 + 1200 * Math.Pow(i - 100, 1.45));
                m_XPparNiveauAp100[i] = value;
            }
        }

        public static void MakeXPparCote()
        {
            if (m_XPparCote == null)
                m_XPparCote = new Hashtable();

            for (int i = 0; i < 21; i++)
            {
                int value = -1000 + 325 * i;
                m_XPparCote[i] = value;
            }
        }

        public static void MakeXPparCount()
        {
            if (m_XPparCount == null)
                m_XPparCount = new Hashtable();

            m_XPparCount[0] = 1.00;
            m_XPparCount[1] = 0.95;
            m_XPparCount[2] = 0.90;
            m_XPparCount[3] = 0.85;
            m_XPparCount[4] = 0.80;
            m_XPparCount[5] = 0.75;
            m_XPparCount[6] = 0.70;
            m_XPparCount[7] = 0.65;
            m_XPparCount[8] = 0.60;
            /*m_XPparCount[9] = 0.10;
            m_XPparCount[10] = 0.01;
            m_XPparCount[11] = 0.40;
            m_XPparCount[12] = 0.35;
            m_XPparCount[13] = 0.30;
            m_XPparCount[14] = 0.25;
            m_XPparCount[15] = 0.20;
            m_XPparCount[16] = 0.15;
            m_XPparCount[17] = 0.10;
            m_XPparCount[18] = 0.05;
            m_XPparCount[19] = 0.02;
            m_XPparCount[20] = 0.01;*/
        }

        
        public static void SetSkills(TMobile from, int skillcaptotal, double skillcapind)
        {
            from.SkillsCap = skillcaptotal;

            for (int i = 0; i < from.Skills.Length; ++i)
            {
                //if (!IsLoreSkill(from.Skills[i]))
                    from.Skills[i].Cap = (double)skillcapind;
            }
            
            //from.SkillsPlace += (double)3.0;
        }

        public static void SetPAs(TMobile from)
        {
            from.AptitudesLibres++;

            int paEnAttente = Aptitudes.GetRemainingPA(from) - Aptitudes.GetDisponiblePA(from);

            //if (paEnAttente > 15)
            //    paEnAttente = 15;

            from.AptitudesLibres += paEnAttente;
        }

        public static void SetPCs(TMobile from)
        {
            from.CompetencesLibres += 25;

            int compEnAttente = Competences.GetRemainingComp(from) - Competences.GetDisponibleComp(from);

            //if (paEnAttente > 15)
            //    paEnAttente = 15;

            from.CompetencesLibres += compEnAttente;
        }

        public static void SetPSs(TMobile from)
        {
            //from.StatistiquesLibres += 5;

            int statsEnAttente = Statistiques.GetRemainingStats(from) - Statistiques.GetDisponibleStats(from);

            //if (paEnAttente > 15)
            //    paEnAttente = 15;

            from.StatistiquesLibres += statsEnAttente;
        }

        //public static void SetPUs(TMobile from)
        //{
        //    from.PUDispo += 2;
        //
        //    int puEnAttente = FicheAttributsGump.GetRemainingPU(from) - FicheAttributsGump.GetDisponiblePU(from);
        //
        //    if (puEnAttente > 10)
        //        puEnAttente = 10;
        //
        //    from.PUDispo += puEnAttente;
        //}

        public static int GetNeededXP(TMobile pm)
        {
            if (pm == null)
                return 1000;

            int neededXP = 0;

            if (pm.Niveau > 30)
                neededXP = 435000 + (30000 * (pm.Niveau - 30));
            else
                neededXP = m_ExpReqTable[pm.Niveau + 1];

            return neededXP;

            /*if (pm == null)
                return 2000;

            int neededXP = 2000;

            if (pm.Niveau + 1 >= 150)
                neededXP = (int)(198582 + 1200 * Math.Pow((pm.Niveau - 100) + 1, 1.45));
            else if (pm.Niveau > 99 && XP.m_XPparNiveauAp100.Contains(pm.Niveau + 1))
                neededXP = (int)XP.m_XPparNiveauAp100[pm.Niveau + 1];
            else if (pm.Niveau <= 100 && XP.m_XPparNiveauAv100.Contains(pm.Niveau + 1))
                neededXP = (int)XP.m_XPparNiveauAv100[pm.Niveau + 1];

            return neededXP;*/
        }

        public static int GetNiveauXP(TMobile pm)
        {
            if (pm == null)
                return 1000;

            int neededXP = 0;

            if (pm.Niveau > 19)
                neededXP = 190000 + (20000 * (pm.Niveau - 20));
            else
                neededXP = m_ExpReqTable[pm.Niveau];

            return neededXP;

            /*if (pm == null)
                return 2000;

            int neededXP = 2000;

            if (pm.Niveau >= 150)
                neededXP = (int)(198582 + 1200 * Math.Pow(pm.Niveau - 100, 1.45));
            else if (pm.Niveau > 100 && XP.m_XPparNiveauAp100.Contains(pm.Niveau))
                neededXP = (int)XP.m_XPparNiveauAp100[pm.Niveau];
            else if (pm.Niveau <= 100 && XP.m_XPparNiveauAv100.Contains(pm.Niveau))
                neededXP = (int)XP.m_XPparNiveauAv100[pm.Niveau];

            return neededXP;*/
        }

        public static bool CanEvolve(Mobile from)
        {
            try
            {
                if (from is TMobile)
                {
                    TMobile pm = from as TMobile;

                    int currentXP = pm.XP;
                    int neededXP = GetNeededXP(pm);

                    if (currentXP > neededXP)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }

        public static void Evolve(Mobile from)
        {
            try
            {
                if (from is TMobile)
                {
                    TMobile pm = from as TMobile;

                    int currentXP = pm.XP;
                    int neededXP = GetNeededXP(pm);

                    if (currentXP > neededXP)
                    {
                        pm.Niveau++;

                        int SkillsCaps = 350 + pm.Niveau * 15;
                        double SkillsInd = 40 + pm.Niveau * 2.0;

                        if (SkillsInd > 100)
                            SkillsInd = 100;

                        if (SkillsCaps > 800)
                            SkillsCaps = 800;

                        SetSkills(pm, SkillsCaps, SkillsInd);
                        SetPAs(pm);
                        SetPCs(pm);
                        SetPSs(pm);
                        //SetPUs(pm);

                        //if (pm.Race == Race.Drakan && pm.Niveau == 65)
                        //{
                        //    if (pm.Hair != null)
                        //        pm.Hair.Delete();
                        //
                        //    pm.AddItem(new CornesDrakan());
                        //}

                        pm.SendMessage("Vous gagnez un niveau !");
                    }
                    else
                        pm.SendMessage("Il vous manque des points d'experieces pour gagner votre niveau !");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
    public class Cote
    {
        public enum PositifCotes
        {
            Implique,
            Fairplay,
            Interessant,
            Coherent,
            Interactif,
            Mentor
        }

        public enum NegatifCotes
        {
            Abusif,
            Silencieux,
            Individualiste,
            Bourrin,
            SuperHero
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write((int)0); // version;

            writer.Write((int)m_positif.Length);
            for (int i = 0; i < m_positif.Length; i++)
                writer.Write((bool)m_positif[i]);

            writer.Write((int)m_negatif.Length);
            for (int i = 0; i < m_negatif.Length; i++)
                writer.Write((bool)m_negatif[i]);

            writer.Write((Mobile)m_coteur);
            writer.Write((DateTime)m_cotetime);
            writer.Write((int)m_total);
        }

        public Cote(TMobile owner, GenericReader reader)
        {
            int version = reader.ReadInt();

            int positifCount = reader.ReadInt();
            m_positif = new bool[positifCount];
            for (int i = 0; i < positifCount; i++)
            {
                m_positif[i] = reader.ReadBool();
            }

            int negatifCount = reader.ReadInt();
            m_negatif = new bool[negatifCount];
            for (int i = 0; i < negatifCount; i++)
            {
                m_negatif[i] = reader.ReadBool();
            }

            m_coteur = reader.ReadMobile();
            m_cotetime = reader.ReadDateTime();
            m_total = reader.ReadInt();
        }

        private bool[] m_positif = new bool[6]{
               false, //Implique,
               false, //Fairplay,
               false, //Interessant,
               false, //Coherent,
               false, //Interactif,
               false  //Mentor,
        };

        private bool[] m_negatif = new bool[6]{
               false, //Abusif,
               false, //Silencieux,
               false, //Individualiste,
               false, //Bourrin,
               false, //Super Hero,
               false  //??,
        };

        private Mobile m_coteur;
        private DateTime m_cotetime;

        private int m_total;

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime CoteDate
        {
            get { return m_cotetime; }
            set { m_cotetime = value; this.SetCote(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Coteur
        {
            get { return m_coteur; }
            set { m_coteur = value; this.SetCote(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Total
        {
            get { return m_total; }
            set { m_total = value; this.SetCote(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public bool[] Positif
        {
            get { return m_positif; }
            set { m_positif = value; this.SetCote(); }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public bool[] Negatif
        {
            get { return m_negatif; }
            set { m_negatif = value; this.SetCote(); }
        }

        public Cote()
        {
        }

        public Cote(Mobile Coteur)
        {
            m_coteur = Coteur;
        }

        public Cote(Mobile Coteur, DateTime date)
        {
            m_cotetime = date;
            m_coteur = Coteur;
        }

        public Cote(bool[] positif, bool[] negatif)
        {
            m_positif = positif;
            m_negatif = negatif;

            SetCote();
        }

        public Cote(bool[] positif, bool[] negatif, Mobile coteur)
        {
            m_positif = positif;
            m_negatif = negatif;

            m_coteur = coteur;

            SetCote();
        }

        public void SetCote()
        {
            m_total = 0;

            if (m_positif[0])
                m_total += 1;

            if (m_positif[1])
                m_total += 1;

            if (m_positif[2])
                m_total += 1;

            if (m_positif[3])
                m_total += 1;

            if (m_positif[4])
                m_total += 1;

            if (m_positif[5])
                m_total += 1;

            if (m_negatif[0])
                m_total -= 1;

            if (m_negatif[1])
                m_total -= 1;

            if (m_negatif[2])
                m_total -= 1;

            if (m_negatif[3])
                m_total -= 1;

            if (m_negatif[4])
                m_total -= 1;

            if (m_negatif[5])
                m_total -= 1;
        }

        public int GetCote()
        {
            SetCote();

            return m_total;
        }
    }
}