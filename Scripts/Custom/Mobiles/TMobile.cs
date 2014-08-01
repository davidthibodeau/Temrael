using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Commands;
using Server.Misc;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Regions;
using Server.Movement;
using Server.Spells.Fifth;
using Server.Spells.Seventh;
using Server.Spells.Necromancy;
using Server.Spells;
using Server.Mobiles;
using Server.Multis;
using Server.ContextMenus;
using Server.Prompts;
using Server.Engines.Langues;
using Server.Engines.Identities;

namespace Server.Mobiles
{


    public enum EquitationType
    {
        Attacking,
        Running,
        BeingAttacked,
        Cast,
        Ranged
    }

    public enum MortState
    {
        Aucun,
        Mourir,
        Assomage,
        Ebranle,
        MortDefinitive,
        MortVivant,
        Resurrection,
        Delete
    }

    public enum MortEvo
    {
        Aucune,
        Decomposition,
        Zombie,
        Squelette,
        Ombre,
        Spectre,
        Esprit
    }

    public enum Blessures
    {
        Aucune,
        Hemorragie,
        Fracture,
        Felure,
        Laceration,
        Coupure,
        Contusion,
        Eraflure
    }

    public enum Membres
    {
        Buste,
        Bras,
        Jambes
    }

    public class Creation
    {
        #region Constructeur
        public Creation()
        {
            m_race = Races.Aucun;
            m_classe = ClasseType.None;
            m_destination = CreationCarteGump.DestinationsDepart.Aucune;
            //m_gumps = new List<CreationGump.PaperPreviewItem>();
            m_hue = 0;
            m_secrete = Races.Aucun;
        }
        #endregion

        #region Méthodes
        public void Reboot()
        {
            m_race = Races.Aucun;
            m_classe = ClasseType.None;
            m_hue = 0;
            m_secrete = Races.Aucun;
        }
        #endregion

        #region Variables
        //private List<Server.Gumps.CreationGump.PaperPreviewItem> m_gumps;
        private Races m_race;
        private ClasseType m_classe;
        private Server.Gumps.CreationCarteGump.DestinationsDepart m_destination;
        private int m_hue;
        private Races m_secrete;
        #endregion

        #region Accessors
        //public List<Server.Gumps.CreationGump.PaperPreviewItem> gumps { get { return m_gumps; } set { m_gumps = value; } }
        public Races race { get { return m_race; } set { m_race = value; } }
        public ClasseType classe { get { return m_classe; } set { m_classe = value; } }
        public Server.Gumps.CreationCarteGump.DestinationsDepart destination { get { return m_destination; } set { m_destination = value; } }
        public int hue { get { return m_hue; } set { m_hue = value; } }
        public Races secrete { get { return m_secrete; } set { m_secrete = value; } }
        #endregion
    }

    public class TMobile : PlayerMobile
    {

        //public static void Initialize()
        //{
        //    foreach (Mobile m in World.Mobiles.Values)
        //    {
        //        if (m is TMobile)
        //        {
        //            if (!(m.X < 6082 && m.X > 6053 && m.Y < 4064 && m.Y > 4011))
        //            {
        //                if (m.Backpack != null)
        //                    m.Backpack.DropItem(new Gold(2000));
        //            }
        //        }
        //    }
        //}
        #region Variables

        private List<int> m_ListCote = new List<int>(5);
        private DateTime m_LastCotation;

        private int m_TileToDontFall;
        private int m_Niveau;
        private int m_AptitudesLibres;
        private int m_CompetencesLibres;

        private int m_Fatigue;

        private bool m_Aphonie;
        private AphonieTimer m_AphonieTimer;
        public ArrayList m_MetamorphoseList = new ArrayList();
        public static Hashtable m_SpellTransformation = new Hashtable();
        public static Hashtable m_SpellName = new Hashtable();
        public static Hashtable m_SpellHue = new Hashtable();

        private Container m_Corps;
        private bool m_RisqueDeMort;
        private Timer m_TimerEvanouie;
        private Timer m_TimerMort;
        private Point3D m_EndroitMort;
        private bool m_Mort;
        private MortState m_MortState;
        private MortEvo m_MortEvo;
        private Races m_race;

        private DateTime m_BrulerPlanteLast;
        private int m_LastTeinture = 0;

        private DateTime m_AmeLastFed;
        private bool m_MortVivant;

        private int m_StatistiquesLibres;
        private bool m_transformer;
        private Timer m_MortVivantTimer;
        private DateTime m_lastAchever;
        private Races m_trueRace;
        private DateTime m_lastAssassinat;
        private DateTime m_lastDeguisement;
        private DateTime m_NextCraftTime;
        private DateTime m_NextClasseChange;

        private Creation m_creation = new Creation();

        private int m_BonusMana;
        private int m_BonusStam;
        private int m_BonusHits;

        private DateTime m_NextFiole;
        private DateTime m_NextSnoop;
        private DateTime m_NextExp;

        private Mobile m_Possess;
        private Mobile m_PossessStorage;

        private bool m_Incognito = false;

        private ClasseType m_ClasseType = ClasseType.None;
        private bool m_Suicide;
        private DateTime m_NextKillAllowed;
        private Races m_RaceSecrete;
        private bool m_RevealTitle = true;
        private bool m_FreeReset = false;
        private bool m_Achever = false;
        private bool[,] m_Ticks = new bool[7,9];
        private bool m_XPMode = false;

        private Point3D m_OldLocation;

        #region QuickSpells
        private ArrayList m_QuickSpells = new ArrayList();

        public ArrayList QuickSpells
        {
            get { return m_QuickSpells; }
        }
        #endregion

        private static double[] m_AttackingTable = new double[] { 0.501, 0.161, 0.051, 0.021,
            0.011, 0.001, 0.001, 0.001, 0.001, 0.001, 0.001 };

        private static double[] m_RunningTable = new double[] { 0.251, 0.161, 0.081, 0.041,
            0.021, 0.011, 0.011, 0.001, 0.000, 0.000, 0.000 };

        private static double[] m_BeingAttackedTable = new double[] { 0.501, 0.501, 0.501, 0.501,
            0.501, 0.501, 0.121, 0.051, 0.021, 0.011, 0.001 };

        private static double[] m_RangedAttackTable = new double[] { 0.501, 0.501, 0.501, 0.501,
            0.501, 0.501, 0.121, 0.051, 0.021, 0.011, 0.001 };

        private static double[] m_CastingTable = new double[] { 0.501, 0.501, 0.501, 0.501,
            0.501, 0.501, 0.121, 0.051, 0.021, 0.011, 0.001 };

        #endregion

        /*public override int VirtualArmor
        {
            get
            {
                return base.VirtualArmor + (GetAptitudeValue(NAptitude.Resistance) * 2);
            }
            set
            {
                base.VirtualArmor = value;
            }
        }*/

        #region Accessors

        [CommandProperty(AccessLevel.GameMaster)]
        public bool FreeReset
        {
            get { return m_FreeReset; }
            set { m_FreeReset = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool RevealTitle
        {
            get { return m_RevealTitle; }
            set { m_RevealTitle = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Races RaceSecrete
        {
            get { return m_RaceSecrete; }
            set { m_RaceSecrete = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime LastCotation
        {
            get { return m_LastCotation; }
            set { m_LastCotation = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public List<int> ListCote
        {
            get { return m_ListCote; }
            set { m_ListCote = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Niveau
        {
            get { return m_Niveau; }
            set { m_Niveau = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int AptitudesLibres
        {
            get { return m_AptitudesLibres; }
            set { m_AptitudesLibres = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int CompetencesLibres
        {
            get { return m_CompetencesLibres; }
            set { m_CompetencesLibres = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Fatigue
        {
            get
            {
                //if (CroixDesCilias.m_MortsTimer.Contains(this))
                //    return 1000;

                return m_Fatigue;
            }
            set { m_Fatigue = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Aphonie
        {
            get
            {
                return m_Aphonie;
            }
            set
            {
                if (m_Aphonie != value)
                {
                    m_Aphonie = value;

                    //SendMessage(m_Aphonie ? "Vous ne pouvez parler!" : "Vous pouvez parler!");
                    SendMessage(m_Aphonie ? "Vous ne pouvez incanter!" : "Vous pouvez incanter!");
                    

                    if (m_AphonieTimer != null)
                    {
                        m_AphonieTimer.Stop();
                        m_AphonieTimer = null;
                    }
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool MetamorphoseMod
        {
            get { return !CanBeginAction(typeof(MetamorphoseSpell)); }
        }

        public ArrayList MetamorphoseList
        {
            get { return m_MetamorphoseList; }
            set { m_MetamorphoseList = value; }
        }

        public Container Corps
        {
            get { return m_Corps; }
            set { m_Corps = value; }
        }

        //[CommandProperty(AccessLevel.GameMaster)]
        public bool RisqueDeMort
        {
            get { return m_RisqueDeMort; }
            set { m_RisqueDeMort = value; }
        }

        public Timer TimerEvanouie
        {
            get { return m_TimerEvanouie; }
            set { m_TimerEvanouie = value; }
        }

        public Timer TimerMort
        {
            get { return m_TimerMort; }
            set { m_TimerMort = value; }
        }

        public Point3D EndroitMort
        {
            get { return m_EndroitMort; }
            set { m_EndroitMort = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Mort
        {
            get { return m_Mort; }
            set { m_Mort = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool MortVivant
        {
            get { return m_MortVivant; }
            set { m_MortVivant = value; }
        }

        [CommandProperty(AccessLevel.Administrator)]
        public MortState MortCurrentState
        {
            get { return m_MortState; }
            set { m_MortState = value; }
        }

        [CommandProperty(AccessLevel.Administrator)]
        public MortEvo MortEvo
        {
            get { return m_MortEvo; }
            set { m_MortEvo = value; }
        }

        [CommandProperty(AccessLevel.Administrator)]
        public Races Races
        {
            get { return m_race; }
            set { m_race = value; SendPropertiesTo(this); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime LastFeuPlante
        {
            get { return m_BrulerPlanteLast; }
            set { m_BrulerPlanteLast = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int LastTeinture
        {
            get { return m_LastTeinture; }
            set { m_LastTeinture = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime AmeLastFed
        {
            get { return m_AmeLastFed; }
            set { m_AmeLastFed = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int StatistiquesLibres
        {
            get { return m_StatistiquesLibres; }
            set { m_StatistiquesLibres = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Transformer
        {
            get { return m_transformer; }
            set { m_transformer = value; }
        }

        public Timer MortVivantTimer
        {
            get { return m_MortVivantTimer; }
            set { m_MortVivantTimer = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime LastAchever
        {
            get { return m_lastAchever; }
            set { m_lastAchever = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Races MortRace
        {
            get { return m_trueRace; }
            set { m_trueRace = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime LastAssassinat
        {
            get { return m_lastAssassinat; }
            set { m_lastAssassinat = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime LastDeguisement
        {
            get { return m_lastDeguisement; }
            set { m_lastDeguisement = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime NextCraftTime
        {
            get { return m_NextCraftTime; }
            set { m_NextCraftTime = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Creation Creation
        {
            get { return m_creation; }
            set { m_creation = value; }
        }
            

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime NextClasseChange
        {
            get { return m_NextClasseChange; }
            set { m_NextClasseChange = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int BonusHits
        {
            get { return m_BonusHits; }
            set { m_BonusHits = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int BonusStam
        {
            get { return m_BonusStam; }
            set { m_BonusStam = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int BonusMana
        {
            get { return m_BonusMana; }
            set { m_BonusMana = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime NextFiole
        {
            get { return m_NextFiole; }
            set { m_NextFiole = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime NextSnoop
        {
            get { return m_NextSnoop; }
            set { m_NextSnoop = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime NextExp
        {
            get { return m_NextExp; }
            set { m_NextExp = value; }
        }

        public Mobile Possess
        {
            get { return m_Possess; }
            set { m_Possess = value; }
        }

        public Mobile PossessStorage
        {
            get { return m_PossessStorage; }
            set { m_PossessStorage = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Incognito
        {
            get { return m_Incognito; }
            set { m_Incognito = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public ClasseType ClasseType
        {
            get { return m_ClasseType; }
            set { m_ClasseType = value; FamilierCheck(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Suicide
        {
            get { return m_Suicide; }
            set { m_Suicide = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime NextKillAllowed
        {
            get { return m_NextKillAllowed; }
            set { m_NextKillAllowed = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Achever { get { return m_Achever; } set { m_Achever = value; } }

        public Point3D OldLocation { get { return m_OldLocation; } set { m_OldLocation = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        //false = daily. true = hebdo
        public bool XPMode { get { return m_XPMode; } set { m_XPMode = value; } }

        public bool[,] Ticks
        {
            get
            {
                return m_Ticks;
            }
        }
        #endregion

        public override bool RetainPackLocsOnDeath { get { return true; } }
        public override bool KeepsItemsOnDeath { get { return false; } }

        public override int PhysicalResistance
        {
            get
            {
                return base.PhysicalResistance + VirtualArmor + VirtualArmorMod + GetAptitudeValue(Aptitude.Resistance) * 2;
            }
        }

        public void OnAmeEating()
        {
            m_AmeLastFed = DateTime.Now;
            if ((m_MortEvo == MortEvo.Decomposition) || (m_MortEvo == MortEvo.Zombie) || (m_MortEvo == MortEvo.Squelette))
            {
                m_MortEvo = MortEvo.Aucune;
                m_race = m_trueRace;
                if (this.FindItemOnLayer(Layer.Shirt) is BaseMortGumps)
                {
                    FindItemOnLayer(Layer.Shirt).Delete();
                }
                CheckRaceGump();
            }
        }

        #region constructors
        public TMobile()
        {
            //m_classe = new ClasseGuerrier(this);
            this.FollowersMax = 2;
            Mana = 0;
            m_creation = new Creation();
            

            //new TourTimer(this).Start();
        }
        public TMobile(Serial s) : base(s)
        {

            //Mana = 0;
            //new TourTimer(this).Start();

        }
        #endregion

        #region languages
        

        public void Reset(bool free)
        {
            if (!FreeReset && !free)
                XP = (int)(XP * 0.95);
            else if (!free)
                FreeReset = false;

            Statistiques.Reset(this);
            Competences.Reset(this);

            ClasseType = ClasseType.None;
            FamilierCheck();

        }



        public override bool CheckHearsMutatedSpeech(Mobile m, object context)
        {
            if (m is TMobile)
            {
                TMobile player = m as TMobile;

                return Langues.HearsGibberish(player);
            }
            return true;


            //return base.CheckHearsMutatedSpeech( m, context); //True si pas mort
        }

        public override bool MutateSpeech(List<Mobile> hears, ref string text, ref object context)
        {
            //return base.MutateSpeech( hears, ref text, ref context );
            if (Alive)
            {
                for (int h = 0; h < hears.Count; ++h)
                {
                    Mobile o = hears[h];
                    //Console.WriteLine("Text: "+text);
                    //Console.WriteLine("Context: "+context);
                    if (o is TMobile)
                    {
                        TMobile player = o as TMobile;
                        //Console.WriteLine("hears[h] = "+player );

                        bool isEmote = false;

                        char debut = text[0];
                        char fin = text[text.Length - 1];

                        //Console.WriteLine("debut: "+debut.ToString());
                        //Console.WriteLine("fin: "+fin.ToString());

                        isEmote = (debut.ToString() == "*" && fin.ToString() == "*");

                        //if(isEmote)
                        //      Console.WriteLine("EMOTE EDETECT");

                        if (isEmote)
                            return false;

                        //language

                        //int sayValue = GetCompetence( m_LanguageActuel ).Value;

                        return Langues.MutateSpeech(ref text);
                    }
                }

            }
            //Console.WriteLine(text);
            return base.MutateSpeech(hears, ref text, ref context);
        }

        public override void OnSaid(SpeechEventArgs e)
        {
            ArrayList targets = new ArrayList();

            if (e.Speech.StartsWith("[") || e.Speech.StartsWith("."))
            {
                CommandSystem.Handle(this, String.Format("{0}{1}", CommandSystem.Prefix, e.Speech.Substring(1)));
                e.Blocked = true;
                base.OnSaid(e);
                return;
            }

            if (e.Type == MessageType.Whisper)
            {
                foreach (Mobile m in this.GetMobilesInRange(10))
                {
                    if (m.AccessLevel >= AccessLevel.Counselor)
                        targets.Add(m);
                }

                if (targets.Count > 0)
                {
                    for (int i = 0; i < targets.Count; ++i)
                    {
                        Mobile m = (Mobile)targets[i];
                        m.SendMessage(91, "Chuchottement de {0} : {1}", e.Mobile.Name, e.Speech);
                    }
                }
            }

            //PublicOverheadFontMessage(this, MessageType.Regular, SpeechHue, 1, e.Speech, true);
            //e.Blocked = true;

            //if (!e.Blocked && e.Type != MessageType.Whisper)
            //   RevealingAction(true);
        }

        #endregion

        #region Port d'Attirail

        [CommandProperty(AccessLevel.GameMaster)]
        public override int Dex
        {
            get
            {
                int count = base.Dex;

                return count;
            }
            set
            {
                base.Dex = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public override int Int
        {
            get
            {
                int count = base.Int;

                return count;
            }
            set
            {
                base.Int = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public override int Str
        {
            get
            {
                int count = base.Str;

                return count;
            }
            set
            {
                base.Str = value;
            }
        }

        public int GetArmorLevel(BaseArmor armor)
        {
            int req = armor.NiveauAttirail;

            if (armor.MaterialType == ArmorMaterialType.Bone)
            {
                switch (armor.Resource)
                {
                    case CraftResource.RegularBones:
                        req = 1;
                        break;
                    case CraftResource.GobelinBones:
                    case CraftResource.ReptilienBones:
                    case CraftResource.NordiqueBones:
                    case CraftResource.DesertiqueBones:
                        req = 2;
                        break;
                    case CraftResource.MaritimeBones:
                    case CraftResource.VolcaniqueBones:
                    case CraftResource.GeantBones:
                        req = 3;
                        break;
                    case CraftResource.MinotaureBones:
                    case CraftResource.OphidienBones:
                    case CraftResource.ArachnideBones:
                        req = 4;
                        break;
                    case CraftResource.MagiqueBones:
                    case CraftResource.AncienBones:
                    case CraftResource.DemonBones:
                        req = 5;
                        break;
                    case CraftResource.DragonBones:
                    case CraftResource.BalronBones:
                    case CraftResource.WyrmBones:
                        req = 6;
                        break;
                }
            }
            else if (armor.MaterialType == ArmorMaterialType.Leather)
            {
                switch (armor.Resource)
                {
                    case CraftResource.RegularLeather:
                    case CraftResource.ReptilienLeather:
                    case CraftResource.NordiqueLeather:
                    case CraftResource.DesertiqueLeather:
                        req = 1;
                        break;
                    case CraftResource.MaritimeLeather:
                    case CraftResource.VolcaniqueLeather:
                    case CraftResource.GeantLeather:
                        req = 2;
                        break;
                    case CraftResource.MinotaurLeather:
                    case CraftResource.OphidienLeather:
                    case CraftResource.ArachnideLeather:
                        req = 3;
                        break;
                    case CraftResource.MagiqueLeather:
                    case CraftResource.AncienLeather:
                    case CraftResource.DemoniaqueLeather:
                        req = 4;
                        break;
                    case CraftResource.DragoniqueLeather:
                    case CraftResource.LupusLeather:
                        req = 5;
                        break;
                }
            }
            else if (armor.MaterialType == ArmorMaterialType.Studded)
            {
                switch (armor.Resource)
                {
                    case CraftResource.RegularLeather:
                        req = 1;
                        break;
                    case CraftResource.ReptilienLeather:
                    case CraftResource.NordiqueLeather:
                    case CraftResource.DesertiqueLeather:
                        req = 2;
                        break;
                    case CraftResource.MaritimeLeather:
                    case CraftResource.VolcaniqueLeather:
                    case CraftResource.GeantLeather:
                        req = 3;
                        break;
                    case CraftResource.MinotaurLeather:
                    case CraftResource.OphidienLeather:
                    case CraftResource.ArachnideLeather:
                        req = 4;
                        break;
                    case CraftResource.MagiqueLeather:
                    case CraftResource.AncienLeather:
                    case CraftResource.DemoniaqueLeather:
                        req = 5;
                        break;
                    case CraftResource.DragoniqueLeather:
                    case CraftResource.LupusLeather:
                        req = 6;
                        break;
                }
            }

            return req;
        }

        public override bool CheckEquip(Item item)
        {
            if (item is BaseShield)
            {
                m_BonusHits = (((BaseArmor)item).Attributes.BonusHits);
                m_BonusStam = (((BaseArmor)item).Attributes.BonusStam);
                m_BonusMana = (((BaseArmor)item).Attributes.BonusMana);

                if (m_BonusHits > 25)
                    m_BonusHits = 25;

                if (m_BonusStam > 25)
                    m_BonusStam = 25;

                if (m_BonusMana > 25)
                    m_BonusMana = 25;

                /*int req = GetArmorLevel((BaseArmor)item);

                if (GetAptitudeValue(Aptitude.PortBouclier) < req)
                {
                    SendMessage("Aptitude de port de bouclier requis pour être porté : " + req);
                    return false;
                }*/
            }
            else if (item is BaseArmor)
            {
                m_BonusHits = (((BaseArmor)item).Attributes.BonusHits);
                m_BonusStam = (((BaseArmor)item).Attributes.BonusStam);
                m_BonusMana = (((BaseArmor)item).Attributes.BonusMana);

                if (m_BonusHits > 25)
                    m_BonusHits = 25;

                if (m_BonusStam > 25)
                    m_BonusStam = 25;

                if (m_BonusMana > 25)
                    m_BonusMana = 25;

                /*int req = GetArmorLevel((BaseArmor)item);

                if (GetAptitudeValue(Aptitude.PortArmure) < req)
                {
                    SendMessage("Aptitude de port d'armure requis pour être porté : " + req);
                    return false;
                }*/
            }
            else if (item is BaseRanged)
            {
                m_BonusHits = (((BaseWeapon)item).Attributes.BonusHits);
                m_BonusStam = (((BaseWeapon)item).Attributes.BonusStam);
                m_BonusMana = (((BaseWeapon)item).Attributes.BonusMana);

                if (m_BonusHits > 25)
                    m_BonusHits = 25;

                if (m_BonusStam > 25)
                    m_BonusStam = 25;

                if (m_BonusMana > 25)
                    m_BonusMana = 25;

                /*int req = ((BaseWeapon)item).NiveauAttirail;
                if (GetAptitudeValue(Aptitude.PortArmeDistance) < req)
                {
                    SendMessage("Aptitude de port d'arme de distance requis pour être porté : " + req);
                    return false;
                }*/
            }
            else if (item is BaseWeapon)
            {
                m_BonusHits = (((BaseWeapon)item).Attributes.BonusHits);
                m_BonusStam = (((BaseWeapon)item).Attributes.BonusStam);
                m_BonusMana = (((BaseWeapon)item).Attributes.BonusMana);

                if (m_BonusHits > 25)
                    m_BonusHits = 25;

                if (m_BonusStam > 25)
                    m_BonusStam = 25;

                if (m_BonusMana > 25)
                    m_BonusMana = 25;

                /*int req = ((BaseWeapon)item).NiveauAttirail;
                if (GetAptitudeValue(Aptitude.PortArme) < req)
                {
                    SendMessage("Aptitude de port d'arme requis pour être porté : " + req);
                    return false;
                }*/
            }
            else if (item is BaseJewel)
            {
                m_BonusHits = (((BaseJewel)item).Attributes.BonusHits);
                m_BonusStam = (((BaseJewel)item).Attributes.BonusStam);
                m_BonusMana = (((BaseJewel)item).Attributes.BonusMana);

                if (m_BonusHits > 25)
                    m_BonusHits = 25;

                if (m_BonusStam > 25)
                    m_BonusStam = 25;

                if (m_BonusMana > 25)
                    m_BonusMana = 25;
            }
            else if (item is BaseClothing)
            {
                m_BonusHits = (((BaseClothing)item).Attributes.BonusHits);
                m_BonusStam = (((BaseClothing)item).Attributes.BonusStam);
                m_BonusMana = (((BaseClothing)item).Attributes.BonusMana);

                if (m_BonusHits > 25)
                    m_BonusHits = 25;

                if (m_BonusStam > 25)
                    m_BonusStam = 25;

                if (m_BonusMana > 25)
                    m_BonusMana = 25;

                if (((BaseClothing)item).Disguise)
                    Identities.DisguiseHidden = true;
            }
            return base.CheckEquip(item);
        }

        public override bool OnEquip(Item item)
        {
            if (item is BaseShield)
            {
                m_BonusHits = (((BaseArmor)item).Attributes.BonusHits);
                m_BonusStam = (((BaseArmor)item).Attributes.BonusStam);
                m_BonusMana = (((BaseArmor)item).Attributes.BonusMana);

                if (m_BonusHits > 25)
                    m_BonusHits = 25;

                if (m_BonusStam > 25)
                    m_BonusStam = 25;

                if (m_BonusMana > 25)
                    m_BonusMana = 25;

                /*int req = GetArmorLevel((BaseArmor)item);

                if (GetAptitudeValue(Aptitude.PortBouclier) < req)
                {
                    SendMessage("Aptitude de port de bouclier requis pour être porté : " + req);
                    return false;
                }*/
            }
            if (item is BaseArmor)
            {
                m_BonusHits = (((BaseArmor)item).Attributes.BonusHits);
                m_BonusStam = (((BaseArmor)item).Attributes.BonusStam);
                m_BonusMana = (((BaseArmor)item).Attributes.BonusMana);

                if (m_BonusHits > 25)
                    m_BonusHits = 25;

                if (m_BonusStam > 25)
                    m_BonusStam = 25;

                if (m_BonusMana > 25)
                    m_BonusMana = 25;
                
                /*int req = GetArmorLevel((BaseArmor)item);
                
                if (GetAptitudeValue(Aptitude.PortArmure) < req)
                {
                    SendMessage("Aptitude de port d'armure requis pour être porté : " + req);
                    return false;
                }*/
            }
            else if (item is BaseRanged)
            {
                m_BonusHits = (((BaseWeapon)item).Attributes.BonusHits);
                m_BonusStam = (((BaseWeapon)item).Attributes.BonusStam);
                m_BonusMana = (((BaseWeapon)item).Attributes.BonusMana);

                if (m_BonusHits > 25)
                    m_BonusHits = 25;

                if (m_BonusStam > 25)
                    m_BonusStam = 25;

                if (m_BonusMana > 25)
                    m_BonusMana = 25;

                /*int req = ((BaseWeapon)item).NiveauAttirail;
                if (GetAptitudeValue(Aptitude.PortArmeDistance) < req)
                {
                    SendMessage("Aptitude de port d'arme de distance requis pour être porté : " + req);
                    return false;
                }*/
            }
            else if (item is BaseWeapon)
            {
                m_BonusHits = (((BaseWeapon)item).Attributes.BonusHits);
                m_BonusStam = (((BaseWeapon)item).Attributes.BonusStam);
                m_BonusMana = (((BaseWeapon)item).Attributes.BonusMana);

                if (m_BonusHits > 25)
                    m_BonusHits = 25;

                if (m_BonusStam > 25)
                    m_BonusStam = 25;

                if (m_BonusMana > 25)
                    m_BonusMana = 25;

                /*int req = ((BaseWeapon)item).NiveauAttirail;
                if (GetAptitudeValue(Aptitude.PortArme) < req)
                {
                    SendMessage("Aptitude de port d'arme requis pour être porté : " + req);
                    return false;
                }*/
            }
            else if (item is BaseJewel)
            {
                m_BonusHits = (((BaseJewel)item).Attributes.BonusHits);
                m_BonusStam = (((BaseJewel)item).Attributes.BonusStam);
                m_BonusMana = (((BaseJewel)item).Attributes.BonusMana);

                if (m_BonusHits > 25)
                    m_BonusHits = 25;

                if (m_BonusStam > 25)
                    m_BonusStam = 25;

                if (m_BonusMana > 25)
                    m_BonusMana = 25;
            }
            else if (item is BaseClothing)
            {
                m_BonusHits = (((BaseClothing)item).Attributes.BonusHits);
                m_BonusStam = (((BaseClothing)item).Attributes.BonusStam);
                m_BonusMana = (((BaseClothing)item).Attributes.BonusMana);

                if (m_BonusHits > 25)
                    m_BonusHits = 25;

                if (m_BonusStam > 25)
                    m_BonusStam = 25;

                if (m_BonusMana > 25)
                    m_BonusMana = 25;

                if (((BaseClothing)item).Disguise)
                    Identities.DisguiseHidden = true;
            }
            return base.OnEquip(item);
        }
        #endregion

        public override void AddNameProperties(ObjectPropertyList list)
        {
            string name = Name;

            if (name == null)
                name = String.Empty;

            string color = "#FFFFFF";

            list.Add(1060526, String.Format("<h3><BASEFONT COLOR={0}>{1}, {2}</BASEFONT></h3>", color, name, Title)); // ~1_PREFIX~~2_NAME~~3_SUFFIX~
        }

        public override void GetProperties(ObjectPropertyList list)
        {

        }

        public override void SendPropertiesTo(Mobile from)
        {
            string color = "#FFFFFF";

            string displayName = (from == this ? Name : GetNameUseBy(from));
            if (!CanBeginAction(typeof(IncognitoSpell)))
            {
                displayName = "Anonyme";
            }

            ObjectPropertyList list = new ObjectPropertyList(this);

            list.Add("<h3><basefont color=" + color + ">" + displayName + (Title == "" ? "" : (", " + Title)) + "<basefont></h3>");

            from.Send(list);
            
        }

        private class TransformerTieffelinEntry : ContextMenuEntry
        {
            private TMobile m_from;

            public TransformerTieffelinEntry(TMobile from)
                : base(6285, -1)
            {
                m_from = from;
            }

            public override void OnClick()
            {
                if (m_from.FindItemOnLayer(Layer.Cloak) != null)
                    m_from.AddToBackpack(m_from.FindItemOnLayer(Layer.Cloak));

                m_from.AddItem(new AilesTieffelin());

                if (m_from.FindItemOnLayer(Layer.Shirt) != null)
                {
                    if (!(m_from.FindItemOnLayer(Layer.Shirt) is BaseRaceGumps))
                    {
                        m_from.AddToBackpack(m_from.FindItemOnLayer(Layer.Shirt));
                    }
                    else
                    {
                        m_from.FindItemOnLayer(Layer.Shirt).Delete();
                    }
                }

                m_from.AddItem(new CorpsTieffelin());

                if (m_from.FindItemOnLayer(Layer.Helm) != null)
                    m_from.AddToBackpack(m_from.FindItemOnLayer(Layer.Helm));

                m_from.AddItem(new CornesTieffelin());

                if (m_from.Identities[0] == "")
                    m_from.Identities[0] = m_from.Name;
                m_from.Identities.CurrentIdentity = 13;

                m_from.Transformer = true;
            }
        }

        private class FinTransformerTieffelinEntry : ContextMenuEntry
        {
            private TMobile m_from;

            public FinTransformerTieffelinEntry(TMobile from)
                : base(6285, -1)
            {
                m_from = from;
            }

            public override void OnClick()
            {
                if (m_from.FindItemOnLayer(Layer.Cloak) is AilesTieffelin)
                    m_from.FindItemOnLayer(Layer.Cloak).Delete();
                if (m_from.FindItemOnLayer(Layer.Shirt) is CorpsTieffelin)
                    m_from.FindItemOnLayer(Layer.Shirt).Delete();
                if (m_from.FindItemOnLayer(Layer.Helm) is CornesTieffelin)
                    m_from.FindItemOnLayer(Layer.Helm).Delete();

                switch (m_from.RaceSecrete)
                {
                    case Races.Nordique:
                        m_from.Hue = 1023;
                        m_from.EquipItem(new CorpsNordique(m_from.Hue));
                        break;
                    case Races.Nomade:
                        m_from.Hue = 1044;
                        break;
                    case Races.Capiceen:
                        m_from.Hue = 1023;
                        break;
                }

                if (m_from.Identities[0] == "")
                    m_from.Identities[0] = m_from.Name;
                m_from.Identities.CurrentIdentity = 0;

                m_from.Transformer = false;
            }
        }

        private class TransformerAasimarEntry : ContextMenuEntry
        {
            private TMobile m_from;

            public TransformerAasimarEntry(TMobile from)
                : base(6285, -1)
            {
                m_from = from;
            }

            public override void OnClick()
            {
                if (m_from.FindItemOnLayer(Layer.Shirt) != null)
                {
                    if (!(m_from.FindItemOnLayer(Layer.Shirt) is BaseRaceGumps))
                    {
                        m_from.AddToBackpack(m_from.FindItemOnLayer(Layer.Shirt));
                    }
                    else
                    {
                        m_from.FindItemOnLayer(Layer.Shirt).Delete();
                    }
                }

                m_from.AddItem(new CorpsAasimar());

                if (m_from.Identities[0] == "")
                    m_from.Identities[0] = m_from.Name;
                m_from.Identities.CurrentIdentity = 13;

                m_from.Transformer = true;
            }
        }

        private class FinTransformerAasimarEntry : ContextMenuEntry
        {
            private TMobile m_from;

            public FinTransformerAasimarEntry(TMobile from)
                : base(6285, -1)
            {
                m_from = from;
            }

            public override void OnClick()
            {
                if (m_from.FindItemOnLayer(Layer.Shirt) is CorpsAasimar)
                    m_from.FindItemOnLayer(Layer.Shirt).Delete();

                switch (m_from.RaceSecrete)
                {
                    case Races.Nordique:
                        m_from.Hue = 1023;
                        m_from.EquipItem(new CorpsNordique(m_from.Hue));
                        break;
                    case Races.Nomade:
                        m_from.Hue = 1044;
                        break;
                    case Races.Capiceen:
                        m_from.Hue = 1023;
                        break;
                }

                if (m_from.Identities[0] == "")
                    m_from.Identities[0] = m_from.Name;
                m_from.Identities.CurrentIdentity = 0;

                m_from.Transformer = false;
            }
        }

        public override void GetContextMenuEntries(Mobile m_from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(m_from, list);

            if (m_from != this)
            {
                if (m_from is TMobile)
                    list.Add(new RenameEntry((TMobile)m_from, this));
                //temp_from = m_from;
                //list.Add(new CallbackEntry(6097, new ContextCallback(LaunchGumpName)));
            }
            else
            {
                list.Add(new CallbackEntry(6098, new ContextCallback(LaunchFicheGump)));
                if (this.Races == Races.Tieffelin && !(this.m_transformer))
                    list.Add(new TransformerTieffelinEntry(this));
                else if (this.Races == Races.Tieffelin && this.m_transformer)
                    list.Add(new FinTransformerTieffelinEntry(this));
                if (this.Races == Races.Aasimar && !(this.m_transformer))
                    list.Add(new TransformerAasimarEntry(this));
                else if (this.Races == Races.Aasimar && this.m_transformer)
                    list.Add(new FinTransformerAasimarEntry(this));
            }
        }

        private void LaunchFicheGump()
        {
            this.SendGump(new FicheRaceGump(this));
        }

        public void NewName(string entry, Mobile mob)
        {
            if (mob is TMobile)
            {
                TMobile tmob = (TMobile)mob;

                /*Console.WriteLine("TMOB : " + tmob.Name);
                Console.WriteLine("THIS : " + Name);*/

                Identities.NewName(entry, tmob);

                SendPropertiesTo(mob);
            }
        }

        public override string GetNameUseBy(Mobile from)
        {           
            return Identities.GetNameUseBy(from);
        }

        public override void OnAosSingleClick(Mobile from)
        {
            ObjectPropertyList opl = new ObjectPropertyList(this);
            opl.Add(GetNameUseBy(from));

            if (opl.Header > 0)
            {
                int hue = 11;
                from.Send(new MessageLocalized(this.Serial, Body, MessageType.Label, hue, 3, opl.Header, Name, opl.HeaderArgs));
            }
        }

        public override void OnSingleClick(Mobile from)
        {
            ObjectPropertyList opl = new ObjectPropertyList(this);
            opl.Add(GetNameUseBy(from));


            if (opl.Header > 0)
            {
                this.PrivateOverheadMessage(MessageType.Regular, 0x3B2, true, this.Name + ", ", from.NetState);
                this.PrivateOverheadMessage(MessageType.Regular, 0x3B2, true, "[" + this.Title + "]", from.NetState);
            }
            else
            {

            }
        }

        public override void DisplayPaperdollTo(Mobile to)
        {
            //string oldname = Name;
            //Name = GetNameUseBy(to);
            EventSink.InvokePaperdollRequest(new PaperdollRequestEventArgs(to, this));
            //Name = oldname;
        }

        public override void OnSkillsQuery(Mobile from)
        {
            if (from == this)
            {
                //Console.WriteLine("Skills test");
                if ((this.SessionStart + TimeSpan.FromSeconds(2.0)) > DateTime.Now) return;
                //from.CloseAllGumps();//optional
                if (from is TMobile)
                    from.SendGump(new CompetenceGump(((TMobile)from), CompetenceGump.CompDomaines.Aucun, false));//replace with your gump
                //base.OnSkillsQuery(from);
            }
            else
                base.OnSkillsQuery(from);
        }

        public override void OnSkillChange(SkillName skill, double oldBase)
		{
            base.OnSkillChange(skill, oldBase);

            if (skill == SkillName.ConnaissanceLangue)
                Langues.FixLangues();
		}

        public override bool OnMoveOver(Mobile m)
        {
            if (m.Hidden && m.AccessLevel > AccessLevel.Player)
            {
                return true;
            }
            if (Hidden)
            {
                return true;
            }
            if (m.Hidden)
            {
                m.Hidden = false;
            }
            if (!Mounted)
            {
                if (m.Stam == m.StamMax)
                {
                    if (m is TMobile)
                    {
                        TMobile from = (TMobile)m;
                        from.SendMessage("Vous poussez le personnage hors de votre chemin.");
                        from.Stam -= 10;
                        this.SendMessage("Vous etes pousse(e) hors du chemin par " + from.GetNameUseBy(this));
                        return true;
                    }
                    else
                    {
                        m.SendMessage("Vous poussez le personnage hors de votre chemin.");
                        m.Stam -= 10;
                        this.SendMessage("Vous etes pousse(e) hors du chemin");
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
            
        }

        public virtual int GetAptitudeValue(Aptitude aptitude)
        {
            return 0;
        }

        public void FamilierCheck()
        {
            FollowersMax = 2 + GetAptitudeValue(Aptitude.Familier);
            Delta(MobileDelta.Followers);
        }

        public virtual bool CheckEquitation(EquitationType type)
        {
            return CheckEquitation(type, Location);
        }

        public override bool Move(Direction d)
        {
            if (Mounted)
            {
                if (m_TileToDontFall > 0)
                    m_TileToDontFall--;
            }

            CheckEquitation(EquitationType.Running, Location);

            if (Hidden && CheckRevealStealth() && AccessLevel == AccessLevel.Player)
            {
                RevealingAction();
            }

            return base.Move(d);
        }

        public static double PenaliteStatistique(Mobile m, double stat)
        {
            double penalite = 0;

            /*if (stat < 50)
                penalite += (stat * 0.02);

            if (stat > 50)
                penalite += (1 + stat * 0.001);*/

            return penalite;
        }

        public bool CheckRevealStealth()
        {
            double stealth = this.Skills[SkillName.Infiltration].Base;

            if (stealth >= 100)
                return false;

            double chance = 0.80 * GetBagFilledRatio(this);

            if (chance >= Utility.RandomDouble())
                return true;

            return false;
        }

        public static double GetBagFilledRatio(TMobile pm)
        {
            Container pack = pm.Backpack;

            if (pm.AccessLevel >= AccessLevel.GameMaster)
                return 0;

            if (pack != null)
            {
                int maxweight = WeightOverloading.GetMaxWeight(pm);

                double value = (pm.TotalWeight / maxweight) - 0.50;

                if (value < 0)
                    value = 0;

                if (value > 0.50)
                    value = 0.50;

                return value;
            }

            return 0;
        }

        public bool IsDesert(Region reg)
        {
            //if (reg is TerritoryKheijan)
            //{
                TileType type = Deplacement.GetTileType(this);

                if (type == TileType.Desert)
                    return true;
            //}

            return false;
        }

        public virtual bool IsInDesert()
        {
            Region reg = Region;

            if (!reg.IsDefault)
            {
                if (IsDesert(reg))
                    return true;

                reg = reg.Parent;

                while (reg != null)
                {
                    if (IsDesert(reg))
                        return true;

                    reg = reg.Parent;
                }
            }

            return false;
        }

        #region equitation
        public virtual bool CheckEquitation(EquitationType type, Point3D oldLocation)
        {
            //true s'il ne tombe pas, false s'il tombe

            if (AccessLevel >= AccessLevel.GameMaster)
                return true;

            if (!Mounted)
                return true;

            //if (MutationMod || SubterfugeMod || ChimereMod || TransmutationMod || AlterationMod || IncognitoMod || MetamorphoseMod || InstinctCharnelMod)
            //    return false;

            if (type == EquitationType.Running && (Direction & Direction.Running) == 0)
                return true;

            if (Map == null)
                return true;

            double chance = 0.0;
            int equitation = ((int)this.Skills.Equitation.Value / 10);
            equitation += this.GetAptitudeValue(Aptitude.CombatMonte);

            //int equitation = GetAptitudeValue(NAptitude.Equitation);

            if (equitation < 0)
                equitation = 0;

            if (equitation > 10)
                equitation = 10;

            switch (type)
            {
                case EquitationType.Attacking: chance = m_AttackingTable[equitation]; break;
                case EquitationType.Running: chance = m_RunningTable[equitation]; break;
                case EquitationType.BeingAttacked: chance = m_BeingAttackedTable[equitation]; break;
            }

            double fall = Utility.RandomDouble();

            if (chance < fall)
                return true;

            if (type == EquitationType.Running)
            {
                if (m_TileToDontFall > 0)
                    return true;

                TileType tile = Deplacement.GetTileType(this);

                if (tile == TileType.Other || tile == TileType.Dirt)
                    return true;
            }

            BaseMount mount = (BaseMount)Mount;

            mount.Rider = null;
            mount.Location = oldLocation;

            m_TileToDontFall = 3;

            Timer.DelayCall(TimeSpan.FromSeconds(0.3), new TimerStateCallback(Equitation_Callback), mount);

            BeginAction(typeof(BaseMount));
            //double seconds = 10.0 - GetAptitudeValue(NAptitude.Equitation);
            double seconds = 100.0 - (int)this.Skills.Equitation.Value;
            Timer.DelayCall(TimeSpan.FromSeconds(seconds), new TimerCallback(CantMount_Callback));
            mount.NextMountAbility = DateTime.Now.AddSeconds(12 - this.Skills.Equitation.Value / 10);

            return false;
        }

        public void Equitation_Callback(object state)
        {
            BaseMount mount = (BaseMount)state;

            mount.Animate(5, 5, 1, true, false, 0);
            Animate(22, 5, 1, true, false, 0);

            Damage(Utility.RandomMinMax(2, 6));
        }

        public void CantMount_Callback()
        {
            EndAction(typeof(BaseMount));
        }
        #endregion

        public void Aphonier(TimeSpan duration)
        {
            if (!m_Aphonie)
            {
                Aphonie = true;

                m_AphonieTimer = new AphonieTimer(this, duration);
                m_AphonieTimer.Start();
            }
        }

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            //CheckEtude();

            CheckFatigue(7);

            if (willKill && from != null)
            {
                if (FerveurDivineMiracle.m_FerveurDivineRegistry == null)
                    FerveurDivineMiracle.m_FerveurDivineRegistry = new Hashtable();

                if (FerveurDivineMiracle.m_FerveurDivineRegistry.Contains(this))
                {
                    SpellHelper.Heal(this, (int)FerveurDivineMiracle.m_FerveurDivineTable[this], true, true);
                }
            }

            if (from != null && Hidden && from.CanSee(this) && from.InLOS(this))
                RevealingAction();

            base.OnDamage(amount, from, willKill);
        }

        public override bool OnBeforeDeath()
        {
            if (m_PossessStorage != null)
            {
                Server.Possess.CopySkills(this, m_Possess);
                Server.Possess.CopyProps(this, m_Possess);
                Server.Possess.MoveItems(this, m_Possess);

                m_Possess.Location = Location;
                m_Possess.Direction = Direction;
                m_Possess.Map = Map;
                m_Possess.Frozen = false;

                Server.Possess.CopySkills(m_PossessStorage, this);
                Server.Possess.CopyProps(m_PossessStorage, this);
                Server.Possess.MoveItems(m_PossessStorage, this);

                m_PossessStorage.Delete();
                m_PossessStorage = null;
                m_Possess.Kill();
                m_Possess = null;
                Hidden = true;
                return false;
            }

            return base.OnBeforeDeath();
        }

        public override void OnDeath(Container c)
        {
            if (LastKiller is BaseCreature)
            {
              LastKiller.RemoveAggressor(this);
            }
            
            if (PourrissementSpell.m_PourrissementTable.Contains(this))
            {
                FixedParticles(14000, 10, 15, 5013, 264, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                PlaySound(1099);

                double damage = (double)PourrissementSpell.m_PourrissementTable[this] + Utility.Random(1, 10);
                Mobile Caster = (Mobile)PourrissementSpell.m_PourrissementRegistry[this];

                ArrayList targets = new ArrayList();

                Map map = this.Map;

                if (map != null && Caster != null)
                {
                    foreach (Mobile m in this.GetMobilesInRange(5))
                    {
                        if (this != m && SpellHelper.ValidIndirectTarget(this, m) && !(this.Party == m.Party))
                        {
                            targets.Add(m);
                        }
                    }
                }

                if (targets.Count > 0 && Caster != null)
                {
                    for (int i = 0; i < targets.Count; ++i)
                    {
                        Mobile m = (Mobile)targets[i];

                        m.Paralyzed = false;

                        this.DoHarmful(m);
                        AOS.Damage(m, Caster, (int)damage, 0, 0, 0, 100, 0);

                        m.FixedParticles(14000, 10, 15, 5013, 264, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                        m.PlaySound(1099);
                    }
                }
            }

            base.OnDeath(c);

            //EndAction(typeof(ChauveSouris));
            DispelAllTransformations();
            //CheckEtude();

            if (m_TimerEvanouie != null)
            {
                m_TimerEvanouie.Stop();
                m_TimerEvanouie = null;
            }

            if (m_TimerMort != null)
            {
                m_TimerMort.Stop();
                m_TimerMort = null;
            }

            m_EndroitMort = Location;

            if (m_Suicide && Region.Name != "Jail")
                m_RisqueDeMort = true;

            if (!m_RisqueDeMort)
            {
                //AddFatigue(250);
                m_Fatigue = m_Fatigue + 250;
                if (m_Fatigue > 1000)
                    m_Fatigue = 1000;

                m_Corps = c;

                EvanouieTimer timer = new EvanouieTimer(this, c, (int)Direction, this.RisqueDeMort);
                m_TimerEvanouie = timer;
                timer.Start();

                OnTransformationChange(0, null, -1, true); //Retirer spell transformation

                CheckRaceGump();

                BaseArmor.ValidateMobile(this);

                if (Blessed && AccessLevel == AccessLevel.Player)
                    Blessed = false;

                if (m_Aphonie)
                    m_Aphonie = false;

                m_MortState = MortState.Assomage;

                //SendMessage("Vous êtes assommé pour une minute.");
            }
            else
            {
                /*if (m_DeguisementInfos != null)
                {
                    Deguisements.RemoveDeguisement(this);
                }*/

                //Disguised = false;

                NameMod = null;
                BodyMod = 0;
                HueMod = -1;

                CheckRaceGump();

                BaseArmor.ValidateMobile(this);

                //AddFatigue(500);
                m_Fatigue = m_Fatigue + 250;
                if (m_Fatigue > 1000)
                    m_Fatigue = 1000;

                m_RisqueDeMort = false;
                m_Mort = true;
                Send(PlayMusic.GetInstance(MusicName.Death));
                Location = Utility.RandomBool() ? new Point3D(5280, 2160, 5) : new Point3D(5283, 2013, 60);
                Frozen = false;

                if (Hunger <= 0)
                    Hunger = 2;

                if (Thirst <= 0)
                    Thirst = 2;

                if (Blessed && AccessLevel == AccessLevel.Player)
                    Blessed = false;

                if (m_Aphonie)
                    m_Aphonie = false;

                //m_MortState = MortState.MortDefinitive;
            }
        }

        public override void OnAfterDelete()
        {
            base.OnAfterDelete();

            if (m_AphonieTimer != null)
                m_AphonieTimer.Stop();

            //if (_HallucineTimer != null)
            //    _HallucineTimer.Stop();

        }

        public virtual void CheckRaceGump()
        {
            Item racegump = FindItemOnLayer(Layer.Shirt);

            if (racegump != null && racegump is BaseRaceGumps)
                ((BaseRaceGumps)racegump).AddProperties(this);
        }

        public void DispelAllTransformations()
        {
            Spells.AlterationSpell.StopTimer(this);
            Spells.SubterfugeSpell.StopTimer(this);
            Spells.TransmutationSpell.StopTimer(this);
            Spells.ChimereSpell.StopTimer(this);
            Spells.MutationSpell.StopTimer(this);
            Spells.MetamorphoseSpell.StopTimer(this);
            Spells.OmbreSpell.StopTimer(this);
            Spells.InstinctCharnelSpell.StopTimer(this);
        }

        public void OnTransformationChange(int body, string name, int hue, bool spell)
        {
            if (spell)
            {
                if (body == 0 && name == null && hue == -1)
                {
                    m_SpellTransformation.Remove(this);
                    m_SpellName.Remove(this);
                    m_SpellHue.Remove(this);
                }
                else
                {
                    m_SpellTransformation[this] = body;
                    m_SpellName[this] = name;
                    m_SpellHue[this] = hue;
                }
            }

            OnBodyChange(body);
            OnNameChange(name);
            OnHueChange(hue);
        }

        public void OnHueChange(int hue)
        {
            if (hue != -1)
            {
                HueMod = hue;
                return;
            }
            else if (m_SpellTransformation.Contains(this))
            {
                HueMod = (int)m_SpellHue[this];
                return;
            }
            /*else if (m_DeguisementInfos != null && m_DeguisementInfos.Hue != -1)
            {
                HueMod = m_DeguisementInfos.Hue;
                return;
            }*/
            else
            {
                HueMod = -1;
                return;
            }
        }

        public void OnBodyChange(int body)
        {
            if (body != 0)
            {
                BodyMod = body;
                Delta(MobileDelta.Body);
                return;
            }
            else if (m_SpellTransformation.Contains(this))
            {
                BodyMod = (int)m_SpellTransformation[this];
                Delta(MobileDelta.Body);
                return;
            }
            /*else if (m_DeguisementInfos != null && m_DeguisementInfos.Body != 0)
            {
                BodyMod = m_DeguisementInfos.Body;
                Delta(MobileDelta.Body);
                return;
            }*/
            else
            {
                BodyMod = 0;
                Delta(MobileDelta.Body);
                return;
            }
        }

        public void CagouleFix()
        {
            bool Inconnu = false;
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (Items[i] is BaseClothing)
                {
                    if (((BaseClothing)Items[i]).Disguise)
                        Inconnu = true;
                }
            }

            if (Inconnu)
                Identities.DisguiseHidden = true;
            else
                Identities.DisguiseHidden = false;
        }

        public void OnNameChange(string name)
        {
            if (name != null)
            {
                NameMod = name;
                InvalidateProperties();
                return;
            }
            else if (m_SpellName.Contains(this))
            {
                NameMod = (string)m_SpellName[this];
                InvalidateProperties();
                return;
            }
            /*else if (m_DeguisementInfos != null && m_DeguisementInfos.Name != null)
            {
                NameMod = m_DeguisementInfos.Name;
                InvalidateProperties();
                return;
            }*/
            else
            {
                NameMod = null;
                InvalidateProperties();
                return;
            }
        }

        public void OnRaceModChange(Races newrace, Races oldrace)
        {
            /*if (newrace == Races.Aucun)
            {
                Deguisements.RemoveRaceGump(this);
                Deguisements.AddRaceGump(this, oldrace, true);
            }
            else
            {
                Deguisements.RemoveRaceGump(this);
                Deguisements.AddRaceGump(this, newrace, false);
            }*/

            CheckRaceGump();
            InvalidateProperties();
        }

        public virtual void Tip(Mobile m, string tip)
        {
            SendGump(new TipGump(this, m, tip, true));

            SendMessage("Un maître de jeu vous a envoyé un message, double cliquez le parchemin pour le lire.");
        }

        #region Fatigue
        /*public virtual void AddFatigue(int amount)
        {
            if (AuraDeFatigueSpell.m_AuraDeFatigueTable.Contains(this))
            {
                amount = (int)(amount * (double)AuraDeFatigueSpell.m_AuraDeFatigueTable[this]);
                FixedParticles(14170, 10, 15, 5013, 139, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                PlaySound(507);
            }

            double bonus = (1 - TotemHelper.GetTotemBonus(this, TotemType.Talisman));

            amount = (int)(amount * bonus);

            m_Fatigue += amount;

            if (m_Fatigue < 0)
                m_Fatigue = 0;

            if (m_Fatigue > 1000)
                m_Fatigue = 1000;
        }*/

        public virtual bool CheckFatigue(int difficulty)
        {
            //difficulty : 10 combattre 0 : skill genre anatomy
            //true s'il rate le jet, false s'il ne le rate pas

            //0 = 100%
            //350 = 25%
            //650 = 49%
            //1000 = 90%

            double chanceToFail = 0; //, chanceToGrow = 0;

            /*if (difficulty < 3)
                chanceToGrow += (difficulty * 0.02);
            else if (difficulty < 7)
                chanceToGrow += (difficulty * 0.02) - 0.02;
            else
                chanceToGrow += (difficulty * 0.02) - 0.03;

            int total = Hunger + Thirst;

            if (total < 28)
            {
                chanceToGrow += (28 - total) * 0.01;
                chanceToFail += (28 - total) * 0.01;
            }

            if (chanceToGrow > Utility.RandomDouble())
                AddFatigue(1);*/

            if (m_Fatigue > 250)
            {
                if (m_Fatigue < 350)
                    chanceToFail += ((m_Fatigue / 4) - 62.5) * 0.01;
                else if (m_Fatigue < 650)
                    chanceToFail += ((m_Fatigue / 13) - 1) * 0.01;
                else
                    chanceToFail += ((4 * (m_Fatigue / 35)) - 25) * 0.01;
            }

            return chanceToFail > Utility.RandomDouble();
        }
        #endregion

        #region timers
        private class AphonieTimer : Timer
        {
            private TMobile m_Mobile;

            public AphonieTimer(TMobile m, TimeSpan duration)
                : base(duration)
            {
                Priority = TimerPriority.TwentyFiveMS;
                m_Mobile = m;
            }

            protected override void OnTick()
            {
                m_Mobile.Aphonie = false;
            }
        }

        private class EvanouieTimer : Timer
        {
            private Mobile m;
            private Container m_Corpse;
            private int m_Direction;
            private bool m_Mort;

            public EvanouieTimer(Mobile from, Container c, int direction, bool mort)
                : base(TimeSpan.FromSeconds(60))
            {
                m = from;
                m_Corpse = c;
                m_Direction = direction;
                m_Mort = mort;
                m.Frozen = true;
            }

            protected override void OnTick()
            {
                TMobile pm = m as TMobile;

                Stop();
                m.Frozen = false;

                if (!pm.Mort)
                {
                    //pm.RisqueDeMort = true;
                    m.Resurrect();

                    if (m_Corpse != null)
                    {
                        ArrayList list = new ArrayList();

                        foreach (Item item in m_Corpse.Items)
                        {
                            list.Add(item);
                        }

                        foreach (Item item in list)
                        {
                            if (item.Layer == Layer.Hair || item.Layer == Layer.FacialHair)
                                item.Delete();

                            if (item is BaseRaceGumps || (m_Corpse is Corpse && ((Corpse)m_Corpse).EquipItems.Contains(item)))
                            {
                                if (!m.EquipItem(item))
                                    m.AddToBackpack(item);
                            }
                            else
                            {
                                m.AddToBackpack(item);
                            }
                        }

                        m_Corpse.Delete();
                    }

                    m.Direction = (Direction)m_Direction;
                    m.Animate(21, 5, 1, false, false, 0);

                    //RisqueDeMortTimer Timer = new RisqueDeMortTimer(m);
                    pm.TimerMort = this;
                    //Timer.Start();

                    pm.m_MortState = MortState.Ebranle;
                }
                else
                {
                    pm.m_MortState = MortState.MortDefinitive;
                    pm.MoveToWorld(new Point3D(new Point2D(5277, 2159), 5), Map.Felucca);
                    pm.Resurrect();
                }
                /*else
                {
                    pm.RisqueDeMort = false;
                    m.Resurrect();
                }*/

                pm.CheckRaceGump();
            }
        }

        private class RisqueDeMortTimer : Timer
        {
            private Mobile m;

            public RisqueDeMortTimer(Mobile from)
                : base(TimeSpan.FromSeconds(10))
            {
                m = from;
            }

            protected override void OnTick()
            {
                TMobile pm = m as TMobile;

                Stop();
                pm.RisqueDeMort = false;
                pm.MortCurrentState = MortState.Aucun;
            }
        }

        public class MortVivantEvoTimer : Timer
        {
            private Mobile m;

            public MortVivantEvoTimer(Mobile from)
                : base(TimeSpan.FromSeconds(60),TimeSpan.FromSeconds(10))
            {
                m = from;
            }

            protected override void OnTick()
            {
                TMobile pm = m as TMobile;
                Item item = pm.FindItemOnLayer(Layer.Shirt);
                Item hair = pm.FindItemOnLayer(Layer.Hair);
                Item facialhair = pm.FindItemOnLayer(Layer.FacialHair);

                if (pm.MortVivant)
                {
                    switch (pm.MortEvo)
                    {
                        case MortEvo.Aucune:
                            if ((pm.AmeLastFed.AddSeconds(30) < DateTime.Now))
                            {
                                pm.AmeLastFed = DateTime.Now;
                                if (item is BaseRaceGumps)
                                    item.Hue = 0;
                                pm.HueMod = 0;
                                pm.SendMessage("Puisque vous ne vous êtes pas nourri de l'âme d'un vivant depuis 7 jours, votre corps se déteriore.");
                                pm.MortRace = pm.Races;
                                pm.Races = Races.MortVivant;
                                pm.MortEvo = MortEvo.Decomposition;
                                Competences.Reset(pm);
                                Statistiques.Reset(pm);
                            }
                            break;
                        case MortEvo.Decomposition:
                            if ((pm.AmeLastFed.AddSeconds(60) < DateTime.Now))
                            {
                                pm.AmeLastFed = DateTime.Now;
                                if (item is BaseRaceGumps)
                                    item.Delete();
                                pm.SendMessage("Puisque vous ne vous êtes pas nourri de l'âme d'un vivant depuis 14 jours, votre corps se déteriore à nouveau.");
                                pm.MortEvo = MortEvo.Zombie;
                                ZombieGump zombieGump = new ZombieGump();
                                EquipItem(pm, zombieGump, pm.Hue);
                            }
                            break;
                        case MortEvo.Zombie:
                            if ((pm.AmeLastFed.AddSeconds(90) < DateTime.Now))
                            {
                                pm.AmeLastFed = DateTime.Now;
                                if (item is BaseMortGumps)
                                    item.Delete();
                                if (hair != null)
                                    hair.Delete();
                                if (facialhair != null)
                                    facialhair.Delete();
                                pm.SendMessage("Puisque vous ne vous êtes pas nourri de l'âme d'un vivant depuis 28 jours, votre corps se déteriore à nouveau.");
                                pm.SendMessage("Avertissement: La prochaine transformation qui aura lieu dans 28 jours sera définitive. Nourrissez-vous de l'âme d'un vivant d'ici là.");
                                pm.MortEvo = MortEvo.Squelette;
                                SqueletteGump squeletteGump = new SqueletteGump();
                                EquipItem(pm, squeletteGump, 0);
                            }
                            break;
                        case MortEvo.Squelette:
                            if ((pm.AmeLastFed.AddSeconds(120) < DateTime.Now))
                            {
                                pm.AmeLastFed = DateTime.Now;
                                if (item is BaseMortGumps)
                                    item.Delete();
                                if (hair != null)
                                    hair.Delete();
                                if (facialhair != null)
                                    facialhair.Delete();
                                pm.SendMessage("Puisque vous ne vous êtes pas nourri de l'âme d'un vivant depuis 56 jours, votre corps se transforme en cette chose définitivement.");
                                pm.MortEvo = MortEvo.Ombre;
                                OmbreGump ombreGump = new OmbreGump();
                                EquipItem(pm, ombreGump, 0);
                            }
                            break;
                        case MortEvo.Ombre:
                            Stop();
                            break;
                    }
                }
            }

            private static void EquipItem(TMobile from, Item item)
            {
                if (item != null)
                    from.EquipItem(item);
            }

            private static void EquipItem(TMobile from, Item item, int hue)
            {
                if (item != null)
                {
                    item.Hue = hue;

                    from.EquipItem(item);
                }
            }
        }

        #endregion

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)9);

            writer.Write(m_XPMode);
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 9; j++)
                    writer.Write(m_Ticks[i, j]);

            writer.Write((bool)m_Achever);
            writer.Write((bool)m_FreeReset);
            writer.Write((bool)m_RevealTitle);

            writer.Write((int)m_RaceSecrete);

            writer.Write((DateTime)(m_NextKillAllowed));
            writer.Write((bool)m_Suicide);
            writer.Write((int)m_ClasseType);

            writer.Write((bool)m_Incognito);

            writer.Write((Mobile)m_Possess);
            writer.Write((Mobile)m_PossessStorage);

            writer.Write((DateTime)m_NextExp);

            writer.Write((DateTime)m_NextSnoop);

            writer.Write((DateTime)m_NextFiole);

            writer.Write((int)m_BonusMana);
            writer.Write((int)m_BonusStam);
            writer.Write((int)m_BonusHits);

            writer.Write((DateTime)m_NextClasseChange);

            writer.Write(m_ListCote.Count);
            for (int i = 0; i < m_ListCote.Count; i++)
                writer.Write((int)m_ListCote[i]);

            writer.Write((int)m_StatistiquesLibres);
            writer.Write((bool)m_transformer);
            writer.Write((DateTime)m_lastAchever);
            writer.Write((int)m_trueRace);
            writer.Write((DateTime)m_lastAssassinat);
            writer.Write((DateTime)m_lastDeguisement);
            writer.Write((DateTime)m_NextCraftTime);

            writer.Write(m_QuickSpells.Count);
            for (int i = 0; i < m_QuickSpells.Count; i++)
                writer.Write((int)m_QuickSpells[i]);

            writer.Write((DateTime) m_LastCotation);
            
            writer.Write((int) m_TileToDontFall);

            writer.Write((int)m_Niveau);
            writer.Write((int)m_AptitudesLibres);
            writer.Write((int)m_CompetencesLibres);

            writer.Write((int)m_Fatigue);

            writer.Write((bool)m_Aphonie);

            writer.Write((Container)m_Corps);
            writer.Write(m_RisqueDeMort);
            writer.Write(m_EndroitMort);
            writer.Write(m_Mort);

            writer.Write((int)m_MortState);
            writer.Write((int)m_MortEvo);
            writer.Write((int)m_race);

            writer.Write((DateTime)m_BrulerPlanteLast);
            writer.Write((int)m_LastTeinture);

            writer.Write((DateTime)m_AmeLastFed);
            writer.Write((bool)m_MortVivant);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            int count = 0;

            switch (version)
            {
                case 9:
                case 8:
                    m_XPMode = reader.ReadBool();
                    for (int i = 0; i < 7; i++)
                        for (int j = 0; j < 9; j++)
                            m_Ticks[i, j] = reader.ReadBool();
                    goto case 7;
                case 7:
                    if(version < 9)
                        Identities.CurrentIdentity = reader.ReadInt();
                    goto case 6;
                case 6:
                    if (version < 9)
                    {
                        count = reader.ReadInt();
                        for (int i = 0; i < count; i++)
                            Langues[reader.ReadInt()] = true;
                    }
                    goto case 5;
                case 5:
                    m_Achever = reader.ReadBool();
                    goto case 4;
                case 4:
                    m_FreeReset = reader.ReadBool();
                    m_RevealTitle = reader.ReadBool();

                    goto case 3;
                case 3:
                    if(version < 9)
                        Identities.RevealIdentity = reader.ReadBool();
                    goto case 2;
                case 2:
                    m_RaceSecrete = (Mobiles.Races)reader.ReadInt();
                    goto case 1;
                case 1:
                    m_NextKillAllowed = reader.ReadDateTime();
                    m_Suicide = reader.ReadBool();
                    if (version < 9)
                    {
                        reader.ReadDateTime();
                        reader.ReadInt();
                        reader.ReadInt();
                    }
                    if (version < 9)
                    {
                        count = reader.ReadInt();
                        for (int i = 0; i < count; i++)
                        {
                            reader.ReadInt();
                        }
                    }
                    m_ClasseType = (ClasseType)reader.ReadInt();

                    if(version < 9)
                        Identities.DisguiseHidden = reader.ReadBool();
                    m_Incognito = reader.ReadBool();

                    if (version < 9)
                        Identities.ConvertPre9Ident(reader);

                    m_Possess = reader.ReadMobile();
                    m_PossessStorage = reader.ReadMobile();

                    m_NextExp = reader.ReadDateTime();
                    m_NextSnoop = reader.ReadDateTime();
                    m_NextFiole = reader.ReadDateTime();

                    m_BonusMana = reader.ReadInt();
                    m_BonusStam = reader.ReadInt();
                    m_BonusHits = reader.ReadInt();

                    m_NextClasseChange = reader.ReadDateTime();

                    m_ListCote = new List<int>(5);
                    count = reader.ReadInt();
                    for (int i = 0; i < count; i++)
                    {
                        m_ListCote.Add((int)reader.ReadInt());
                    }

                    m_StatistiquesLibres = reader.ReadInt();
                    m_transformer = reader.ReadBool();
                    m_lastAchever = reader.ReadDateTime();
                    m_trueRace = (Races)reader.ReadInt();
                    m_lastAssassinat = reader.ReadDateTime();
                    m_lastDeguisement = reader.ReadDateTime();
                    m_NextCraftTime = reader.ReadDateTime();

                    if (version < 9)
                    {
                        int langueCount = reader.ReadInt();
                        for (int i = 0; i < langueCount; i++)
                        {
                            reader.ReadBool();
                        }
                    }

                    m_QuickSpells = new ArrayList();
                    count = reader.ReadInt();
                    for (int i = 0; i < count; i++)
                    {
                        m_QuickSpells.Add((int)reader.ReadInt());
                    }

                    m_LastCotation = reader.ReadDateTime();

                    m_TileToDontFall = reader.ReadInt();

                    if (version < 9)
                    {
                        reader.ReadInt();
                        int oldLength = reader.ReadInt();
                        for (int i = 0; i < oldLength; ++i)
                            reader.ReadInt();
                    }

                    m_Niveau = reader.ReadInt();
                    m_AptitudesLibres = reader.ReadInt();
                    m_CompetencesLibres = reader.ReadInt();
                    if (version < 8)
                    {
                        reader.ReadInt();
                        reader.ReadInt();
                    }
                    if(version < 9)
                        reader.ReadInt();

                    m_Fatigue = reader.ReadInt();
                    if (version < 9)
                    {
                        reader.ReadDateTime();
                        reader.ReadInt();
                        reader.ReadDateTime();
                        reader.ReadInt();
                    }

                    m_Aphonie = reader.ReadBool();
                    if(version < 9)
                        Identities.Disguised = reader.ReadBool();

                    m_Corps = (Container)reader.ReadItem();
                    m_RisqueDeMort = reader.ReadBool();
                    m_EndroitMort = reader.ReadPoint3D();
                    m_Mort = reader.ReadBool();

                    m_MortState = (MortState)reader.ReadInt();
                    m_MortEvo = (MortEvo)reader.ReadInt();
                    m_race = (Races)reader.ReadInt();

                    m_BrulerPlanteLast = reader.ReadDateTime();
                    m_LastTeinture = reader.ReadInt();

                    m_AmeLastFed = reader.ReadDateTime();
                    m_MortVivant = reader.ReadBool();

                    goto case 0;
                case 0:
                    if(version < 9)
                        Identities.ConvertPre9Knew(reader);
                    break;
                default: break;
            }
            if (!Alive && !m_Mort)
            {
                m_RisqueDeMort = false;

                EvanouieTimer timer = new EvanouieTimer(this, m_Corps, (int)Direction, this.RisqueDeMort);
                m_TimerEvanouie = timer;
                timer.Start();
            }

            if (m_RisqueDeMort)
            {
                RisqueDeMortTimer timer = new RisqueDeMortTimer(this);
                m_TimerMort = timer;
                timer.Start();
            }

            if (m_MortVivant)
            {
                MortVivantEvoTimer timer = new MortVivantEvoTimer(this);
                m_MortVivantTimer = timer;
                timer.Start();
            }

            if (Female)
            {
                if (this.FacialHairItemID != 0)
                    this.FacialHairItemID = 0;
            }

            CheckRaceGump();

            BaseArmor.ValidateMobile(this);

            if (Blessed && AccessLevel == AccessLevel.Player)
                Blessed = false;

            if (m_Aphonie)
                m_Aphonie = false;

            m_creation = new Creation();

            CagouleFix();

            //m_FreeReset = true;

            /*Statistiques.Reset(this);
            Competences.Reset(this);
            this.Aptitudes.Reset();

            this.ClasseType = ClasseType.None;
            this.MetierType.Clear();*/

            //KnewIdentity = new List<Identity>();
        }
    }
}
