using Server.Commands;
using Server.ContextMenus;
using Server.Engines.Equitation;
using Server.Engines.Identities;
using Server.Engines.Langues;
using Server.Engines.Mort;
using Server.Engines.Races;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Movement;
using Server.Network;
using Server.Spells;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Server.Mobiles
{

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

        private int m_Fatigue;

        private bool m_Aphonie;
        private AphonieTimer m_AphonieTimer;
        public ArrayList m_MetamorphoseList = new ArrayList();
        public static Hashtable m_SpellTransformation = new Hashtable();
        public static Hashtable m_SpellName = new Hashtable();
        public static Hashtable m_SpellHue = new Hashtable();

        private DateTime m_BrulerPlanteLast;
        private int m_LastTeinture = 0;

        private DateTime m_lastDeguisement;
        private DateTime m_NextCraftTime;
        private DateTime m_NextClasseChange;


        private int m_BonusMana;
        private int m_BonusStam;
        private int m_BonusHits;

        private DateTime m_NextSnoop;

        private Mobile m_Possess;
        private Mobile m_PossessStorage;

        private bool m_Incognito = false;

        private ClasseType m_ClasseType = ClasseType.None;
        private bool m_RevealTitle = true;

        private bool[,] m_Ticks = new bool[7,9];

        private Point3D m_OldLocation;

        #region QuickSpells
        private ArrayList m_QuickSpells = new ArrayList();

        public ArrayList QuickSpells
        {
            get { return m_QuickSpells; }
        }
        #endregion


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

        [CommandProperty(AccessLevel.Batisseur)]
        public bool RevealTitle
        {
            get { return m_RevealTitle; }
            set { m_RevealTitle = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
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

        [CommandProperty(AccessLevel.Batisseur)]
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

        [CommandProperty(AccessLevel.Batisseur)]
        public bool MetamorphoseMod
        {
            get { return !CanBeginAction(typeof(MetamorphoseSpell)); }
        }

        public ArrayList MetamorphoseList
        {
            get { return m_MetamorphoseList; }
            set { m_MetamorphoseList = value; }
        }
        [CommandProperty(AccessLevel.Batisseur)]
        public DateTime LastFeuPlante
        {
            get { return m_BrulerPlanteLast; }
            set { m_BrulerPlanteLast = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int LastTeinture
        {
            get { return m_LastTeinture; }
            set { m_LastTeinture = value; }
        }


        [CommandProperty(AccessLevel.Batisseur)]
        public DateTime LastDeguisement
        {
            get { return m_lastDeguisement; }
            set { m_lastDeguisement = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public DateTime NextCraftTime
        {
            get { return m_NextCraftTime; }
            set { m_NextCraftTime = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public DateTime NextClasseChange
        {
            get { return m_NextClasseChange; }
            set { m_NextClasseChange = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int BonusHits
        {
            get { return m_BonusHits; }
            set { m_BonusHits = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int BonusStam
        {
            get { return m_BonusStam; }
            set { m_BonusStam = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int BonusMana
        {
            get { return m_BonusMana; }
            set { m_BonusMana = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public DateTime NextSnoop
        {
            get { return m_NextSnoop; }
            set { m_NextSnoop = value; }
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

        [CommandProperty(AccessLevel.Batisseur)]
        public bool Incognito
        {
            get { return m_Incognito; }
            set { m_Incognito = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public ClasseType ClasseType
        {
            get { return m_ClasseType; }
            set { m_ClasseType = value; FamilierCheck(); }
        }

        public Point3D OldLocation { get { return m_OldLocation; } set { m_OldLocation = value; } }

        #endregion

        public override bool RetainPackLocsOnDeath { get { return true; } }
        public override bool KeepsItemsOnDeath { get { return false; } }

        #region constructors
        public TMobile()
        {
            //m_classe = new ClasseGuerrier(this);
            this.FollowersMax = 5;
            Mana = 0;

            //new TourTimer(this).Start();
        }
        public TMobile(Serial s) : base(s)
        {

            //Mana = 0;
            //new TourTimer(this).Start();

        }
        #endregion

        #region languages



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
                if (Race != null && (Race.isAasimaar || Race.isTieffelin))
                {
                    if (!Race.Transformed)
                        list.Add(new TransformerEntry(this));
                    else
                        list.Add(new DetransformerEntry(this));
                }
            }
        }

        private class TransformerEntry : ContextMenuEntry
        {
            private PlayerMobile from;

            public TransformerEntry(PlayerMobile f) : base(6285)
            {
                from = f;
            }

            public override void OnClick()
            {
                from.Race.Transformer(from);
            } 
        }

        private class DetransformerEntry : ContextMenuEntry
        {
            private PlayerMobile from;

            public DetransformerEntry(PlayerMobile f) : base(6285)
            {
                from = f;
            }

            public override void OnClick()
            {
                from.Race.Detransformer(from);
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

        //public override void OnSkillsQuery(Mobile from)
        //{
        //    if (from == this)
        //    {
        //        //Console.WriteLine("Skills test");
        //        if ((this.SessionStart + TimeSpan.FromSeconds(2.0)) > DateTime.Now) return;
        //        //from.CloseAllGumps();//optional
        //        if (from is TMobile)
        //            from.SendGump(new CompetenceGump(((TMobile)from), SkillCategory.Aucun, false));//replace with your gump
        //        //base.OnSkillsQuery(from);
        //    }
        //    else
        //        base.OnSkillsQuery(from);
        //}

        public override void OnSkillChange(SkillName skill, double oldBase)
		{
            base.OnSkillChange(skill, oldBase);

            if (skill == SkillName.Langues)
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


        public void FamilierCheck()
        {
            // TOCHECK FAMILIER.
            FollowersMax = 5;

            Delta(MobileDelta.Followers);
        }

        public override bool Move(Direction d)
        {
            Equitation.CheckEquitation(this, EquitationType.Running);

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

            if (pm.AccessLevel >= AccessLevel.Batisseur)
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

            

            if (!MortEngine.RisqueDeMort)
            {
                //AddFatigue(250);
                m_Fatigue = m_Fatigue + 250;
                if (m_Fatigue > 1000)
                    m_Fatigue = 1000;

                MortEngine.Corps = c;

                EvanouieTimer timer = new EvanouieTimer(this, c, (int)Direction, MortEngine.RisqueDeMort);
                MortEngine.TimerEvanouie = timer;
                timer.Start();

                OnTransformationChange(0, null, -1, true); //Retirer spell transformation

                CheckRaceGump();

                BaseArmor.ValidateMobile(this);

                if (Blessed && AccessLevel == AccessLevel.Player)
                    Blessed = false;

                if (m_Aphonie)
                    m_Aphonie = false;

                MortEngine.MortCurrentState = MortState.Assomage;

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

                MortEngine.RisqueDeMort = false;
                MortEngine.Mort = true;
                Send(PlayMusic.GetInstance(MusicName.Death));
                Location = Utility.RandomBool() ? new Point3D(5280, 2160, 5) : new Point3D(5283, 2013, 60);
                Frozen = false;

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

            if (racegump != null && racegump is RaceGump)
                ((RaceGump)racegump).AddProperties(this);
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


        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)9);

            //for (int i = 0; i < 7; i++)
            //    for (int j = 0; j < 9; j++)
            //        writer.Write(m_Ticks[i, j]);

            writer.Write((bool)m_RevealTitle);
            writer.Write((int)m_ClasseType);

            writer.Write((bool)m_Incognito);

            writer.Write((Mobile)m_Possess);
            writer.Write((Mobile)m_PossessStorage);

            //writer.Write((DateTime)m_NextExp);

            writer.Write((DateTime)m_NextSnoop);

            //writer.Write((DateTime)m_NextFiole);

            writer.Write((int)m_BonusMana);
            writer.Write((int)m_BonusStam);
            writer.Write((int)m_BonusHits);

            writer.Write((DateTime)m_NextClasseChange);

            //writer.Write(m_ListCote.Count);
            //for (int i = 0; i < m_ListCote.Count; i++)
            //    writer.Write((int)m_ListCote[i]);

            writer.Write((DateTime)m_lastDeguisement);
            writer.Write((DateTime)m_NextCraftTime);

            writer.Write(m_QuickSpells.Count);
            for (int i = 0; i < m_QuickSpells.Count; i++)
                writer.Write((int)m_QuickSpells[i]);

            //writer.Write((DateTime) m_LastCotation);

            //writer.Write((int)m_Niveau);
            //writer.Write((int)m_AptitudesLibres);
            //writer.Write((int)m_CompetencesLibres);

            writer.Write((int)m_Fatigue);

            writer.Write((bool)m_Aphonie);


            writer.Write((DateTime)m_BrulerPlanteLast);
            writer.Write((int)m_LastTeinture);

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
                    //m_XPMode = reader.ReadBool();
                    //for (int i = 0; i < 7; i++)
                    //    for (int j = 0; j < 9; j++)
                    //        m_Ticks[i, j] = reader.ReadBool();
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
                    goto case 4;
                case 4:
                    //m_FreeReset = reader.ReadBool();
                    m_RevealTitle = reader.ReadBool();

                    goto case 3;
                case 3:
                    if(version < 9)
                        Identities.RevealIdentity = reader.ReadBool();
                    goto case 1;
                case 1:
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


                    m_Possess = reader.ReadMobile();
                    m_PossessStorage = reader.ReadMobile();

                    //m_NextExp = reader.ReadDateTime();
                    m_NextSnoop = reader.ReadDateTime();
                    //m_NextFiole = reader.ReadDateTime();

                    m_BonusMana = reader.ReadInt();
                    m_BonusStam = reader.ReadInt();
                    m_BonusHits = reader.ReadInt();

                    m_NextClasseChange = reader.ReadDateTime();

                    //m_ListCote = new List<int>(5);
                    //count = reader.ReadInt();
                    //for (int i = 0; i < count; i++)
                    //{
                    //    m_ListCote.Add((int)reader.ReadInt());
                    //}

                    //m_StatistiquesLibres = reader.ReadInt();
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

                    //m_LastCotation = reader.ReadDateTime();

                    if (version < 9)
                    {
                        reader.ReadInt();
                        int oldLength = reader.ReadInt();
                        for (int i = 0; i < oldLength; ++i)
                            reader.ReadInt();
                    }

                    //m_Niveau = reader.ReadInt();
                    //m_AptitudesLibres = reader.ReadInt();
                    //m_CompetencesLibres = reader.ReadInt();
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

  

                    m_BrulerPlanteLast = reader.ReadDateTime();
                    m_LastTeinture = reader.ReadInt();


                    break;
                default: break;
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
