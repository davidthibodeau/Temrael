using System;
using System.Collections;
using System.Collections.Generic;
using Server.Network;
using Server.Engines.Craft;
using AMA = Server.Items.ArmorMeditationAllowance;
using AMT = Server.Items.ArmorMaterialType;
using ABT = Server.Items.ArmorBodyType;
using Server.ContextMenus;
using Server.Mobiles;
using System.Text.RegularExpressions;


namespace Server.Items
{
    public abstract class BaseArmor : BaseWearable, IScissorable, ICraftable, IWearableDurability
    {
        #region Balancement


        //BOUCLIERS                                                                                             Mettre valeur negative pour les dex malus.

        //                                               Physique    Magique    Force_req   Dex_malus     Min_Dura     Max_Dura
        public ShieldValues ShldBronze = new ShieldValues   (3,         0,          10,         -3,          100,        125);
        public ShieldValues ShldBuckler = new ShieldValues  (3,         0,          10,         -3,          100,        125);
        public ShieldValues ShldWoodn = new ShieldValues    (3,         0,          10,         -3,          100,        125);
        public ShieldValues ShldCuir = new ShieldValues     (3,         0,          10,         -3,          100,        125);

        public ShieldValues ShldChaos = new ShieldValues    (4,         0,          20,         -4,          125,        150);
        public ShieldValues ShldMetal = new ShieldValues    (4,         0,          20,         -4,          125,        150);
        public ShieldValues ShldWoodnKite = new ShieldValues(4,         0,          20,         -4,          125,        150);

        public ShieldValues ShldHeater = new ShieldValues   (5,         0,          30,         -5,          150,        175);
        public ShieldValues ShldOrder = new ShieldValues    (5,         0,          30,         -5,          150,        175);
        public ShieldValues ShldDecorer = new ShieldValues  (5,         0,          30,         -5,          150,        175);
        public ShieldValues ShldGarde = new ShieldValues    (5,         0,          30,         -5,          150,        175);

        public ShieldValues ShldMetalKite = new ShieldValues(6,         0,          40,         -6,          175,        200);
        public ShieldValues ShldElfique = new ShieldValues  (6,         0,          40,         -6,          175,        200);
        public ShieldValues ShldComte = new ShieldValues    (6,         0,          40,         -6,          175,        200);
        public ShieldValues ShldMarquis = new ShieldValues  (6,         0,          40,         -6,          175,        200);
        public ShieldValues ShldDuc = new ShieldValues      (6,         0,          40,         -6,          175,        200);

        public ShieldValues ShldNordique = new ShieldValues (7,         0,         50,          -7,          200,        225);
        public ShieldValues ShldChevalier = new ShieldValues(7,         0,         50,          -7,          200,        225);
        public ShieldValues ShldPavoisBlk = new ShieldValues(7,         0,         50,          -7,          200,        225);
        public ShieldValues ShldVieux = new ShieldValues    (7,         0,         50,          -7,          200,        225);





        //ARMURES                                                                                              Mettre valeur negative pour les dex malus.

        //                                               Physique     Magique    Force_req   Dex_malus     Min_Dura     Max_Dura
        // Cap 1
        public ArmorValues ArmorLeather = new ArmorValues(  3,          0,          10,         -3,          100,        125);
        public ArmorValues ArmorFeuilles = new ArmorValues( 3,          0,          10,         -3,          100,        125);
        public ArmorValues ArmorRingmail = new ArmorValues( 3,          0,          10,         -3,          100,        125);
        public ArmorValues ArmorBourgeon = new ArmorValues( 3,          0,          10,         -3,          100,        125);
        // Cap 2
        public ArmorValues ArmorMaillons = new ArmorValues( 4,          0,          20,         -4,          125,        150);
        public ArmorValues ArmorMaillures = new ArmorValues(4,          0,          20,         -4,          125,        150);
        public ArmorValues ArmorStudded = new ArmorValues(  4,          0,          20,         -4,          125,        150);
        public ArmorValues ArmorMailles = new ArmorValues(  4,          0,          20,         -4,          125,        150);
        // Cap 3
        public ArmorValues ArmorChain = new ArmorValues(    5,          0,          30,         -5,          150,        175);
        public ArmorValues ArmorBarbare = new ArmorValues(  5,          0,          30,         -5,          150,        175);
        public ArmorValues ArmorBone = new ArmorValues(     5,          0,          30,         -5,          150,        175);
        public ArmorValues ArmorChainElf = new ArmorValues( 5,          0,          30,         -5,          150,        175);
        public ArmorValues ArmorChainNoir = new ArmorValues(5,          0,          30,         -5,          150,        175);
        // Cap 4
        public ArmorValues ArmorPlaque = new ArmorValues(   6,          0,          40,         -6,          175,        200);
        public ArmorValues ArmorPlaqueElf = new ArmorValues(6,          0,          40,         -6,          175,        200);
        public ArmorValues ArmorPlaqueGoth= new ArmorValues(6,          0,          40,         -6,          175,        200);
        public ArmorValues ArmorPlaqueBarb= new ArmorValues(6,          0,          40,         -6,          175,        200);
        // Cap 5
        public ArmorValues ArmorPlaqueOrne= new ArmorValues(7,          0,          50,         -7,          200,        225);
        public ArmorValues ArmorPlaqueDeco= new ArmorValues(7,          0,          50,         -7,          200,        225);
        public ArmorValues ArmorPlaqueNobl= new ArmorValues(7,          0,          50,         -7,          200,        225);
        public ArmorValues ArmorPlaqueDaed= new ArmorValues(7,          0,          50,         -7,          200,        225);




        //ARMURES DIVERS                                                                                       Mettre valeur negative pour les dex malus.

        //                                               Physique    Magique    Force_req   Dex_malus     Min_Dura     Max_Dura
        public ArmorValues ArmorDivers1 = new ArmorValues(  2,          0,          10,         -4,          100,        125);
        public ArmorValues ArmorDivers2 = new ArmorValues(  3,          0,          20,         -5,          125,        150);
        public ArmorValues ArmorDivers3 = new ArmorValues(  4,          0,          30,         -6,          150,        175);
        public ArmorValues ArmorDivers4 = new ArmorValues(  5,          0,          40,         -7,          175,        200);
        public ArmorValues ArmorDivers5 = new ArmorValues(  6,          0,          50,         -8,          200,        225);
        public ArmorValues ArmorDivers6 = new ArmorValues(  7,          0,          60,         -9,          225,        250);


        #endregion

        // Instance values. These values must are unique to each armor piece.
        private int m_MaxDurability;
        private int m_Durability;
        private Mobile m_Crafter;
        private ArmorQuality m_Quality;
        private CraftResource m_Resource;
        private bool m_PlayerConstructed;
        private int m_PhysicalBonus, m_MagieBonus;

        // Bonus pouvant être changé IG.
        private int m_StrBonus = -1, m_DexBonus = -1, m_IntBonus = -1;
        private int m_StrReq = -1, m_DexReq = -1, m_IntReq = -1;

        // Overridable values. These values are provided to override the defaults which get defined in the individual armor scripts.
        public virtual bool AllowMaleWearer { get { return true; } }
        public virtual bool AllowFemaleWearer { get { return true; } }

        public abstract AMT MaterialType { get; }

        public virtual int BaseStrBonus { get { return 0; } }
        public virtual int BaseDexBonus { get { return 0; } }
        public virtual int BaseIntBonus { get { return 0; } }
        public virtual int BaseStrReq { get { return 0; } }
        public virtual int BaseDexReq { get { return 0; } }
        public virtual int BaseIntReq { get { return 0; } }

        public virtual double BasePhysicalResistance { get { return 0; } }
        public virtual double BaseMagieResistance { get { return 0; } }


        #region Getters & Setters

        [CommandProperty(AccessLevel.Batisseur)]
        public double ArmorRating
        {
            get
            {
                return ResistanceBonus(BasePhysicalResistance);
            }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int StrBonus
        {
            get { return (m_StrBonus == -1 ? BaseStrBonus : m_StrBonus); }
            set { m_StrBonus = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int DexBonus
        {
            get { return (m_DexBonus == -1 ? BaseDexBonus : m_DexBonus); }
            set { m_DexBonus = value; InvalidateProperties();}
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int IntBonus
        {
            get { return (m_IntBonus == -1 ? BaseIntBonus : m_IntBonus); }
            set { m_IntBonus = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int StrRequirement
        {
            get { return (m_StrReq == -1 ? BaseStrReq : m_StrReq); }
            set { m_StrReq = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int DexRequirement
        {
            get { return (m_DexReq == -1 ? BaseDexReq : m_DexReq); }
            set { m_DexReq = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int IntRequirement
        {
            get { return (m_IntReq == -1 ? BaseIntReq : m_IntReq); }
            set { m_IntReq = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public bool PlayerConstructed
        {
            get { return m_PlayerConstructed; }
            set { m_PlayerConstructed = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public CraftResource Resource
        {
            get
            {
                return m_Resource;
            }
            set
            {
                if (m_Resource != value)
                {
                    UnscaleDurability();

                    m_Resource = value;

                    if (!DefTailoring.IsNonColorable(this.GetType()))
                    {
                        Hue = CraftResources.GetHue(m_Resource);
                    }

                    Invalidate();
                    InvalidateProperties();

                    if (Parent is Mobile)
                        ((Mobile)Parent).UpdateResistances();

                    ScaleDurability();
                }
            }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int MaxDurability
        {
            get { return m_MaxDurability; }
            set { m_MaxDurability = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Durability
        {
            get
            {
                return m_Durability;
            }
            set
            {
                if (value != m_Durability && MaxDurability > 0)
                {
                    m_Durability = value;

                    if (m_Durability < 0)
                        Delete();
                    else if (m_Durability > MaxDurability)
                        m_Durability = MaxDurability;

                    InvalidateProperties();
                }
            }
        }


        [CommandProperty(AccessLevel.Batisseur)]
        public Mobile Crafter
        {
            get { return m_Crafter; }
            set { m_Crafter = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public ArmorQuality Quality
        {
            get { return m_Quality; }
            set { UnscaleDurability(); m_Quality = value; Invalidate(); InvalidateProperties(); ScaleDurability(); }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int PhysicalBonus { get { return m_PhysicalBonus; } set { m_PhysicalBonus = value; InvalidateProperties(); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int MagieBonus { get { return m_MagieBonus; } set { m_MagieBonus = value; InvalidateProperties(); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public override double PhysicalResistance 
        { get { return (double)(ScaleArmorByDurability(ResistanceBonus(BasePhysicalResistance)) + m_PhysicalBonus); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public override double MagieResistance { get { return (double)(ScaleArmorByDurability(ResistanceBonus(BaseMagieResistance)) + m_MagieBonus); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public ArmorBodyType BodyPosition
        {
            get
            {
                switch (this.Layer)
                {
                    default:
                    case Layer.Neck: return ArmorBodyType.Gorget;
                    case Layer.TwoHanded: return ArmorBodyType.Shield;
                    case Layer.Gloves: return ArmorBodyType.Gloves;
                    case Layer.Helm: return ArmorBodyType.Helmet;
                    case Layer.Arms: return ArmorBodyType.Arms;

                    case Layer.InnerLegs:
                    case Layer.OuterLegs:
                    case Layer.Pants: return ArmorBodyType.Legs;

                    case Layer.InnerTorso:
                    case Layer.OuterTorso:
                    case Layer.Shirt: return ArmorBodyType.Chest;
                }
            }
        }

        [Hue, CommandProperty(AccessLevel.Batisseur)]
        public override int Hue
        {
            get { return base.Hue; }
            set { base.Hue = value; InvalidateProperties(); }
        }
#endregion

        #region Durability
        public virtual int InitMinHits { get { return 0; } }
        public virtual int InitMaxHits { get { return 0; } }

        public void UnscaleDurability()
        {
            int scale = 100 + GetDurabilityBonus();

            m_Durability = ((m_Durability * 100) + (scale - 1)) / scale;
            m_MaxDurability = ((m_MaxDurability * 100) + (scale - 1)) / scale;
            InvalidateProperties();
        }

        public void ScaleDurability()
        {
            int scale = 100 + GetDurabilityBonus();

            m_Durability = ((m_Durability * scale) + 99) / 100;
            m_MaxDurability = ((m_MaxDurability * scale) + 99) / 100;
            InvalidateProperties();
        }

        public int GetDurabilityBonus()
        {
            if (m_Quality == ArmorQuality.Exceptional)
                return 20;
            else if (m_Quality == ArmorQuality.Low)
                return -20;
            else
                return 0;
        }

        public virtual double ScaleArmorByDurability(double armor)
        {
            int scale = 100;

            if (m_MaxDurability > 0 && m_Durability < m_MaxDurability)
                scale = 50 + ((50 * m_Durability) / m_MaxDurability);

            return (armor * scale) / 100;
        }
        #endregion

        #region Saves
        private static void SetSaveFlag(ref SaveFlag flags, SaveFlag toSet, bool setIf)
        {
            if (setIf)
                flags |= toSet;
        }

        private static bool GetSaveFlag(SaveFlag flags, SaveFlag toGet)
        {
            return ((flags & toGet) != 0);
        }

        [Flags]
        private enum SaveFlag
        {
            None              = 0x00000000,
            PhysicalBonus     = 0x00000001,
            MagieBonus        = 0x00000002,
            Identified        = 0x00000004,
            MaxDurability     = 0x00000008,
            Durability        = 0x00000010,
            Crafter           = 0x00000020,
            Quality           = 0x00000040,
            DurabilityLevel   = 0x00000080,
            Protection        = 0x00000100,
            Resource          = 0x00000200,
            BaseArmor         = 0x00000400,
            StrBonus          = 0x00000800,
            DexBonus          = 0x00001000,
            IntBonus          = 0x00002000,
            StrReq            = 0x00004000,
            DexReq            = 0x00008000,
            IntReq            = 0x00010000,
            MedAllowance      = 0x00020000,
            SkillBonuses      = 0x00040000,
            PlayerConstructed = 0x00080000,
            CrafterName       = 0x00100000
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            SaveFlag flags = SaveFlag.None;

            SetSaveFlag(ref flags, SaveFlag.PhysicalBonus, m_PhysicalBonus != 0);
            SetSaveFlag(ref flags, SaveFlag.MagieBonus, m_MagieBonus != 0);
            SetSaveFlag(ref flags, SaveFlag.MaxDurability, m_MaxDurability != 0);
            SetSaveFlag(ref flags, SaveFlag.Durability, m_Durability != 0);
            SetSaveFlag(ref flags, SaveFlag.Crafter, m_Crafter != null);
            SetSaveFlag(ref flags, SaveFlag.Quality, m_Quality != ArmorQuality.Regular);
            SetSaveFlag(ref flags, SaveFlag.Resource, m_Resource != DefaultResource);
            SetSaveFlag(ref flags, SaveFlag.StrBonus, m_StrBonus != -1);
            SetSaveFlag(ref flags, SaveFlag.DexBonus, m_DexBonus != -1);
            SetSaveFlag(ref flags, SaveFlag.IntBonus, m_IntBonus != -1);
            SetSaveFlag(ref flags, SaveFlag.StrReq, m_StrReq != -1);
            SetSaveFlag(ref flags, SaveFlag.DexReq, m_DexReq != -1);
            SetSaveFlag(ref flags, SaveFlag.IntReq, m_IntReq != -1);
            SetSaveFlag(ref flags, SaveFlag.PlayerConstructed, m_PlayerConstructed != false);

            writer.WriteEncodedInt((int)flags);

            if (GetSaveFlag(flags, SaveFlag.PhysicalBonus))
                writer.WriteEncodedInt((int)m_PhysicalBonus);

            if (GetSaveFlag(flags, SaveFlag.MagieBonus))
                writer.WriteEncodedInt((int)m_MagieBonus);

            if (GetSaveFlag(flags, SaveFlag.MaxDurability))
                writer.WriteEncodedInt((int)m_MaxDurability);

            if (GetSaveFlag(flags, SaveFlag.Durability))
                writer.WriteEncodedInt((int)m_Durability);

            if (GetSaveFlag(flags, SaveFlag.Crafter))
                writer.Write((Mobile)m_Crafter);

            if (GetSaveFlag(flags, SaveFlag.Quality))
                writer.WriteEncodedInt((int)m_Quality);

            if (GetSaveFlag(flags, SaveFlag.Durability))
                writer.WriteEncodedInt((int)m_Durability);

            if (GetSaveFlag(flags, SaveFlag.Resource))
                writer.WriteEncodedInt((int)m_Resource);

            if (GetSaveFlag(flags, SaveFlag.StrBonus))
                writer.WriteEncodedInt((int)m_StrBonus);

            if (GetSaveFlag(flags, SaveFlag.DexBonus))
                writer.WriteEncodedInt((int)m_DexBonus);

            if (GetSaveFlag(flags, SaveFlag.IntBonus))
                writer.WriteEncodedInt((int)m_IntBonus);

            if (GetSaveFlag(flags, SaveFlag.StrReq))
                writer.WriteEncodedInt((int)m_StrReq);

            if (GetSaveFlag(flags, SaveFlag.DexReq))
                writer.WriteEncodedInt((int)m_DexReq);

            if (GetSaveFlag(flags, SaveFlag.IntReq))
                writer.WriteEncodedInt((int)m_IntReq);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            SaveFlag flags = (SaveFlag)reader.ReadEncodedInt();

            if (GetSaveFlag(flags, SaveFlag.PhysicalBonus))
                m_PhysicalBonus = reader.ReadEncodedInt();

            if (GetSaveFlag(flags, SaveFlag.MagieBonus))
                m_MagieBonus = reader.ReadEncodedInt();

            if (GetSaveFlag(flags, SaveFlag.MaxDurability))
                m_MaxDurability = reader.ReadEncodedInt();

            if (GetSaveFlag(flags, SaveFlag.Durability))
                m_Durability = reader.ReadEncodedInt();

            if (GetSaveFlag(flags, SaveFlag.Crafter))
                m_Crafter = reader.ReadMobile();

            if (GetSaveFlag(flags, SaveFlag.Quality))
                m_Quality = (ArmorQuality)reader.ReadEncodedInt();
            else
                m_Quality = ArmorQuality.Regular;

            if (GetSaveFlag(flags, SaveFlag.Resource))
                m_Resource = (CraftResource)reader.ReadEncodedInt();
            else
                m_Resource = DefaultResource;

            if (m_Resource == CraftResource.None)
                m_Resource = DefaultResource;

            if (GetSaveFlag(flags, SaveFlag.StrBonus))
                m_StrBonus = reader.ReadEncodedInt();
            else
                m_StrBonus = -1;

            if (GetSaveFlag(flags, SaveFlag.DexBonus))
                m_DexBonus = reader.ReadEncodedInt();
            else
                m_DexBonus = -1;

            if (GetSaveFlag(flags, SaveFlag.IntBonus))
                m_IntBonus = reader.ReadEncodedInt();
            else
                m_IntBonus = -1;

            if (GetSaveFlag(flags, SaveFlag.StrReq))
                m_StrReq = reader.ReadEncodedInt();
            else
                m_StrReq = -1;

            if (GetSaveFlag(flags, SaveFlag.DexReq))
                m_DexReq = reader.ReadEncodedInt();
            else
                m_DexReq = -1;

            if (GetSaveFlag(flags, SaveFlag.IntReq))
                m_IntReq = reader.ReadEncodedInt();
            else
                m_IntReq = -1;

            if (GetSaveFlag(flags, SaveFlag.PlayerConstructed))
                m_PlayerConstructed = true;

            if (Parent is Mobile)
                ((Mobile)Parent).CheckStatTimers();
        }
#endregion

        #region Ressources
        public virtual CraftResource DefaultResource { get { return CraftResource.Fer; } }

        public virtual double ResistanceBonus(double BaseResistance)
        {
            double ar = BaseResistance;

            // Les bonus vont de 0% à 30% de bonus d'AR.
            switch (m_Resource)
            {
                case CraftResource.Cuivre: ar *= 1.06; break;
                case CraftResource.Bronze: ar *= 1.06; break;
                case CraftResource.Acier: ar *= 1.12; break;
                case CraftResource.Argent: ar *= 1.12; break;
                case CraftResource.Or: ar *= 1.12; break;
                case CraftResource.Mytheril: ar *= 1.18; break;
                case CraftResource.Luminium: ar *= 1.18; break;
                case CraftResource.Obscurium: ar *= 1.18; break;
                case CraftResource.Mystirium: ar *= 1.24; break;
                case CraftResource.Dominium: ar *= 1.24; break;
                case CraftResource.Venarium: ar *= 1.24; break;
                case CraftResource.Eclarium: ar *= 1.3; break;
                case CraftResource.Athenium: ar *= 1.3; break;
                case CraftResource.Umbrarium: ar *= 1.3; break;

                case CraftResource.NordiqueLeather: ar *= 1.06; break;
                case CraftResource.DesertiqueLeather: ar *= 1.06; break;
                case CraftResource.MaritimeLeather: ar *= 1.12; break;
                case CraftResource.VolcaniqueLeather: ar *= 1.12; break;
                case CraftResource.GeantLeather: ar *= 1.18; break;
                case CraftResource.OphidienLeather: ar *= 1.18; break;
                case CraftResource.ArachnideLeather: ar *= 1.18; break;
                case CraftResource.AncienLeather: ar *= 1.24; break;
                case CraftResource.DemoniaqueLeather: ar *= 1.24; break;
                case CraftResource.DragoniqueLeather: ar *= 1.3; break;
                case CraftResource.LupusLeather: ar *= 1.3; break;

                case CraftResource.NordiqueBones: ar *= 1.06; break;
                case CraftResource.DesertiqueBones: ar *= 1.06; break;
                case CraftResource.MaritimeBones: ar *= 1.12; break;
                case CraftResource.VolcaniqueBones: ar *= 1.12; break;
                case CraftResource.GeantBones: ar *= 1.18; break;
                case CraftResource.OphidienBones: ar *= 1.18; break;
                case CraftResource.ArachnideBones: ar *= 1.18; break;
                case CraftResource.AncienBones: ar *= 1.24; break;
                case CraftResource.DemonBones: ar *= 1.24; break;
                case CraftResource.DragonBones: ar *= 1.24; break;
                case CraftResource.BalronBones: ar *= 1.3; break;
                case CraftResource.WyrmBones: ar *= 1.3; break;
            }

            return ar;
        }

        public CraftAttributeInfo GetResourceAttrs()
        {
            CraftResourceInfo info = CraftResources.GetInfo(m_Resource);

            if (info == null)
                return CraftAttributeInfo.Blank;

            return info.AttributeInfo;
        }
        #endregion

        #region Constructeurs
        public BaseArmor(Serial serial)
            : base(serial)
        {
        }

        public BaseArmor(int itemID)
            : base(itemID)
        {
            m_Quality = ArmorQuality.Regular;
            m_Crafter = null;

            m_Resource = DefaultResource;
            Hue = CraftResources.GetHue(m_Resource);

            m_Durability = m_MaxDurability = Utility.RandomMinMax(InitMinHits, InitMaxHits);

            this.Layer = (Layer)ItemData.Quality;
        }
        #endregion

        public int ComputeStatReq(StatType type)
        {
            int v;

            if (type == StatType.Str)
                v = StrRequirement;
            else if (type == StatType.Dex)
                v = DexRequirement;
            else
                v = IntRequirement;

            return v;
        }

        public override bool CanEquip(Mobile from)
        {
            if (from.AccessLevel < AccessLevel.Batisseur)
            {
                if (!AllowMaleWearer && !from.Female)
                {
                    if (AllowFemaleWearer)
                        from.SendLocalizedMessage(1010388); // Only females can wear this.
                    else
                        from.SendMessage("You may not wear this.");

                    return false;
                }
                else if (!AllowFemaleWearer && from.Female)
                {
                    if (AllowMaleWearer)
                        from.SendLocalizedMessage(1063343); // Only males can wear this.
                    else
                        from.SendMessage("You may not wear this.");

                    return false;
                }
                else
                {
                    int strReq = ComputeStatReq(StatType.Str);
                    int dexReq = ComputeStatReq(StatType.Dex);
                    int intReq = ComputeStatReq(StatType.Int);

                    if (from.RawDex < dexReq || (from.Dex) < 1)
                    {
                        from.SendLocalizedMessage(502077); // You do not have enough dexterity to equip this item.
                        return false;
                    }
                    else if (from.RawStr < strReq || (from.Str) < 1)
                    {
                        from.SendLocalizedMessage(500213); // You are not strong enough to equip that.
                        return false;
                    }
                    else if (from.RawInt < intReq || (from.Int) < 1)
                    {
                        from.SendMessage("You are not smart enough to equip that.");
                        return false;
                    }
                }
            }

            return base.CanEquip(from);
        }

        public override bool CheckPropertyConfliction(Mobile m)
        {
            if (base.CheckPropertyConfliction(m))
                return true;

            if (Layer == Layer.Pants)
                return (m.FindItemOnLayer(Layer.InnerLegs) != null);

            if (Layer == Layer.Shirt)
                return (m.FindItemOnLayer(Layer.InnerTorso) != null);

            return false;
        }

        public override bool OnEquip(Mobile from)
        {
            from.CheckStatTimers();

            return base.OnEquip(from);
        }

        public override void OnRemoved(IEntity parent)
        {
            if (parent is Mobile)
            {
                Mobile m = (Mobile)parent;
                m.Delta(MobileDelta.Armor); // Tell them armor rating has changed
                m.CheckStatTimers();
            }

            base.OnRemoved(parent);
        }

        protected void Invalidate()
        {
            if (Parent is Mobile)
                ((Mobile)Parent).Delta(MobileDelta.Armor); // Tell them armor rating has changed
        }

        public virtual int OnHit(BaseWeapon weapon, int damageTaken)
        {
            double HalfAr = ArmorRating / 2.0;
            int Absorbed = (int)(HalfAr + HalfAr * Utility.RandomDouble());

            damageTaken -= Absorbed;
            if (damageTaken < 0)
                damageTaken = 0;

            if (Absorbed < 2)
                Absorbed = 2;

            if (25 > Utility.Random(100)) // 25% chance to lower durability
            {
                int wear;

                if (weapon.Type == WeaponType.Bashing)
                    wear = Absorbed / 2;
                else
                    wear = Utility.Random(2);

                if (wear > 0 && m_MaxDurability > 0)
                {
                    if (m_Durability >= wear)
                    {
                        Durability -= wear;
                        wear = 0;
                    }
                    else
                    {
                        wear -= Durability;
                        Durability = 0;
                    }

                    if (wear > 0)
                    {
                        if (m_MaxDurability > wear)
                        {
                            MaxDurability -= wear;

                            if (Parent is Mobile)
                                ((Mobile)Parent).LocalOverheadMessage(MessageType.Regular, 0x3B2, 1061121); // Your equipment is severely damaged.
                        }
                        else
                        {
                            Delete();
                        }
                    }
                }
            }

            return damageTaken;
        }

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack.
                return false;
            }

            CraftSystem system = DefTailoring.CraftSystem;

            CraftItem item = system.CraftItems.SearchFor(GetType());

            if (item != null && item.Resources.Count == 1 && item.Resources.GetAt(0).Amount >= 2)
            {
                try
                {
                    Item res = (Item)Activator.CreateInstance(CraftResources.GetInfo(m_Resource).ResourceTypes[0]);

                    ScissorHelper(from, res, m_PlayerConstructed ? (item.Resources.GetAt(0).Amount / 2) : 1);
                    return true;
                }
                catch
                {
                }
            }

            from.SendLocalizedMessage(502440); // Scissors can not be used on that to produce anything.
            return false;
        }

        public static void ValidateMobile(Mobile m)
        {
            for (int i = m.Items.Count - 1; i >= 0; --i)
            {
                if (i >= m.Items.Count)
                    continue;

                Item item = m.Items[i];

                if (item is BaseArmor)
                {
                    BaseArmor armor = (BaseArmor)item;

                    if (!armor.AllowMaleWearer && !m.Female && m.AccessLevel < AccessLevel.Batisseur)
                    {
                        if (armor.AllowFemaleWearer)
                            m.SendLocalizedMessage(1010388); // Only females can wear this.
                        else
                            m.SendMessage("You may not wear this.");

                        m.AddToBackpack(armor);
                    }
                    else if (!armor.AllowFemaleWearer && m.Female && m.AccessLevel < AccessLevel.Batisseur)
                    {
                        if (armor.AllowMaleWearer)
                            m.SendLocalizedMessage(1063343); // Only males can wear this.
                        else
                            m.SendMessage("You may not wear this.");

                        m.AddToBackpack(armor);
                    }
                }
            }
        }

        public override void OnAdded(IEntity parent)
        {
            if (parent is Mobile)
            {
                Mobile from = (Mobile)parent;

                from.Delta(MobileDelta.Armor); // Tell them armor rating has changed
            }
        }

        #region OnClick infos & OnHover
        private string GetNameString()
        {
            string name = this.Name;

            if (name == null)
                name = String.Format("#{0}", LabelNumber);

            return name;
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            //base.GetProperties( list );

            string couleur = "";
            RareteItem rarete = RareteItem.Normal;

            switch (Rarete)
            {
                case RareteItem.Mediocre:
                    rarete = RareteItem.Mediocre;
                    couleur = "333333";
                    break;
                case RareteItem.Normal:
                    rarete = RareteItem.Normal;
                    couleur = "999999";
                    break;
                case RareteItem.Magique:
                    rarete = RareteItem.Magique;
                    couleur = "003366";
                    break;
                case RareteItem.Rare:
                    rarete = RareteItem.Rare;
                    couleur = "993300";
                    break;
                case RareteItem.Legendaire:
                    rarete = RareteItem.Legendaire;
                    couleur = "5A4A31";
                    break;
                default: couleur = "999999"; break;
            }

            if (Identified)
            {
                string[] s = Regex.Split(GetType().ToString(), @"\.");
                string t = s[s.Length - 1];
                if (Name == null)
                    list.Add(1060393, "{0}\t{1}", couleur, t);
                else
                    list.Add(1060393, "{0}\t{1}", couleur, Name);
                //list.Add(1060394, "{0}\t{1}", couleur, rarete.ToString());
                list.Add(1060394, "{0}\t{1}", couleur, Quality.ToString());

                if (m_Crafter.Name != null)
                    list.Add(1060394, "{0}\t{1}", couleur, "Fabriqué par: " + m_Crafter.Name); // Fabriqué par: ~1_NAME~

                AddARProperties(list, couleur);

                int prop;

                if ((prop = ComputeStatReq(StatType.Str)) > 0)
                    list.Add(1061170, "{0}\t{1}", couleur, prop.ToString()); // strength requirement ~1_val~

                if ((prop = GetDurabilityBonus()) > 0)
                    list.Add(1060410, "{0}\t{1}", couleur, prop.ToString()); // durability ~1_val~%

                if (m_Durability >= 0 && m_MaxDurability > 0)
                    list.Add(1060639, "{0}\t{1}\t{2}", couleur, m_Durability, m_MaxDurability); // durability ~1_val~ / ~2_val~
            }
            else
            {
                string[] s = Regex.Split(GetType().ToString(), @"\.");
                string t = s[s.Length - 1];
                if (Name == null)
                    list.Add(1060393, "{0}\t{1}", couleur, t);
                else
                    list.Add(1060393, "{0}\t{1}", couleur, Name);
                //list.Add(1060394, "{0}\t{1}", couleur, rarete.ToString());
                list.Add(1060395, couleur);
            }
        }

        public void AddARProperties(ObjectPropertyList list, string couleur)
        {
            double v = PhysicalResistance;

            if (v != 0)
                list.Add(1060448, "{0}\t{1}", couleur, v.ToString()); // physical resist ~1_val~%

            v = MagieResistance;

            if (v != 0)
                list.Add(1060446, "{0}\t{1}", couleur, v.ToString()); // energy resist ~1_val~%

        }

        public override void OnSingleClick(Mobile from)
        {
            List<EquipInfoAttribute> attrs = new List<EquipInfoAttribute>();

            if (DisplayLootType)
            {
                if (LootType == LootType.Blessed)
                    attrs.Add(new EquipInfoAttribute(1038021)); // blessed
                else if (LootType == LootType.Cursed)
                    attrs.Add(new EquipInfoAttribute(1049643)); // cursed
            }

            if (m_Quality == ArmorQuality.Exceptional)
                attrs.Add(new EquipInfoAttribute(1018305 - (int)m_Quality));

            int number;

            if (Name == null)
            {
                number = LabelNumber;
            }
            else
            {
                this.LabelTo(from, Name);
                number = 1041000;
            }

            if (attrs.Count == 0 && Crafter == null && Name != null)
                return;

            EquipmentInfo eqInfo = new EquipmentInfo(number, m_Crafter, false, attrs.ToArray());

            from.Send(new DisplayEquipmentInfo(this, eqInfo));
        }
        #endregion

        #region ICraftable Members

        public int OnCraft(int quality, bool makersMark, Mobile from, CraftSystem craftSystem, Type typeRes, BaseTool tool, CraftItem craftItem, int resHue)
        {
            Quality = (ArmorQuality)quality;

            if (makersMark)
            {
                Crafter = from;
            }

            Type resourceType = typeRes;

            if (resourceType == null)
                resourceType = craftItem.Resources.GetAt(0).ItemType;

            Resource = CraftResources.GetFromType(resourceType);
            PlayerConstructed = true;

            CraftContext context = craftSystem.GetContext(from);

            RareteInit.InitItem(this, quality, Crafter);

            if (context != null && context.DoNotColor)
                Hue = 0;

            if (Quality == ArmorQuality.Exceptional)
            {
                switch (Utility.Random(2))
                {
                    case 0: m_PhysicalBonus++; break;
                    case 1: m_MagieBonus++; break;
                }
            }
            else if (Quality == ArmorQuality.Low)
            {
                switch (Utility.Random(2))
                {
                    case 0: m_PhysicalBonus--; break;
                    case 1: m_MagieBonus--; break;
                }
            }

            return quality;
        }

        #endregion
    }

    // Sert à contenir les informations sur les différentes armures.
    public class ArmorValues
    {
        public double resistance_Physique = 0;
        public double resistance_Magique = 0;
        public int force_Requise = 0;
        public int malus_Dex = 0;
        public int min_Durabilite = 0;
        public int max_Durabilite = 0;

        private ArmorValues() // Constructeur vide impossible.
        { }

        public ArmorValues(double res_Phys, double res_Mag, int force_Req, int malus_dex, int min_Dura, int max_Dura)
        {
            resistance_Physique = res_Phys;
            resistance_Magique = res_Mag;
            force_Requise = force_Req;
            min_Durabilite = min_Dura;
            max_Durabilite = max_Dura;
            malus_Dex = malus_dex;
        }
    }

    public class ShieldValues
    {
        public double resistance_Physique = 0;
        public double resistance_Magique = 0;
        public int force_Requise = 0;
        public int malus_Dex = 0;
        public int min_Durabilite = 0;
        public int max_Durabilite = 0;

        private ShieldValues() // Constructeur vide impossible.
        { }

        public ShieldValues(double res_Phys, double res_Mag, int force_Req, int malus_dex, int min_Dura, int max_Dura)
        {
            resistance_Physique = res_Phys;
            resistance_Magique = res_Mag;
            force_Requise = force_Req;
            min_Durabilite = min_Dura;
            max_Durabilite = max_Dura;
            malus_Dex = malus_dex;
        }
    }


}
