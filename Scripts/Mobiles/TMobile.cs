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

        public ArrayList m_MetamorphoseList = new ArrayList();
        public static Hashtable m_SpellTransformation = new Hashtable();
        public static Hashtable m_SpellName = new Hashtable();
        public static Hashtable m_SpellHue = new Hashtable();

        private int m_LastTeinture = 0;

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
        public int LastTeinture
        {
            get { return m_LastTeinture; }
            set { m_LastTeinture = value; }
        }

        public Point3D OldLocation { get { return m_OldLocation; } set { m_OldLocation = value; } }

        #endregion

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

            string displayName = GetNameUseBy(from);
            if (!CanBeginAction(typeof(IncognitoSpell)))
            {
                displayName = "Anonyme";
            }

            ObjectPropertyList list = new ObjectPropertyList(this);

            list.Add("<h3><basefont color=" + color + ">" + displayName + (Title == "" ? "" : (", " + Title)) + "<basefont></h3>");

            from.Send(list);
            
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


        public override bool Move(Direction d)
        {
            Equitation.CheckEquitation(this, EquitationType.Running);

            if (Hidden && CheckRevealStealth() && AccessLevel == AccessLevel.Player)
            {
                RevealingAction();
            }

            return base.Move(d);
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

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
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
                MortEngine.Corps = c;

                EvanouieTimer timer = new EvanouieTimer(this, c, (int)Direction, MortEngine.RisqueDeMort);
                MortEngine.TimerEvanouie = timer;
                timer.Start();

                OnTransformationChange(0, null, -1, true); //Retirer spell transformation

                CheckRaceGump();

                BaseArmor.ValidateMobile(this);

                if (Blessed && AccessLevel == AccessLevel.Player)
                    Blessed = false;

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

                MortEngine.RisqueDeMort = false;
                MortEngine.Mort = true;
                Send(PlayMusic.GetInstance(MusicName.Death));
                Location = Utility.RandomBool() ? new Point3D(5280, 2160, 5) : new Point3D(5283, 2013, 60);
                Frozen = false;

                if (Blessed && AccessLevel == AccessLevel.Player)
                    Blessed = false;

                //m_MortState = MortState.MortDefinitive;
            }
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

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)9);

            writer.Write(m_QuickSpells.Count);
            for (int i = 0; i < m_QuickSpells.Count; i++)
                writer.Write((int)m_QuickSpells[i]);
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

                    m_QuickSpells = new ArrayList();
                    count = reader.ReadInt();
                    for (int i = 0; i < count; i++)
                    {
                        m_QuickSpells.Add((int)reader.ReadInt());
                    }

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
