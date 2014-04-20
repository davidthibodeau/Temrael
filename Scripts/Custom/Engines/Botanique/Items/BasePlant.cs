using System;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
	public abstract class BasePlant : Item
    {
        public bool IsInBowl { get { return m_Bowl != null && !m_Bowl.Deleted; } }
        public bool HasInsects { get { return m_Insects != Insects.None; } }
        public bool HasDisease { get { return m_Disease != Disease.None; } }
        public bool HasFungi { get { return m_Fungi != Fungi.None; } }
        public bool HasPoison { get { return m_Poison != PlantPoison.None; } }
        public bool IsMature { get { return m_StateOfGrowth == StateOfGrowth.Mature; } }
        public virtual string Description { get { return String.Empty; } }
        public virtual string Latin { get { return String.Empty; } }

        private StateOfGrowth m_StateOfGrowth;
        private Insects m_Insects;
        private Disease m_Disease;
        private Fungi m_Fungi;
        private PlantPoison m_Poison;
        private int m_Hydration;
        private int m_Reagent;
        private int m_Seed;
        private BaseBowl m_Bowl;
        private DateTime m_NextGrowth;
        private DateTime m_NextSeed;
        private Timer m_TimerGrowth;

        [CommandProperty(AccessLevel.GameMaster)]
        public StateOfGrowth StateOfGrowth
        {
            get { return m_StateOfGrowth; }
            set
            {
                m_StateOfGrowth = value;
                ItemID = ComputeItemID();

                if (m_Bowl != null)
                    m_Bowl.ComputeItemID();
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public StateOfHydration StateOfHydration
        {
            get
            {
                StateOfHydration state;

                if (m_Hydration < 10)
                    state = StateOfHydration.Low;
                else if (m_Hydration < 40)
                    state = StateOfHydration.Medium;
                else if (m_Hydration < 90)
                    state = StateOfHydration.High;
                else
                    state = StateOfHydration.Drowned;

                return state;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Insects Insects
        {
            get { return m_Insects; }
            set { m_Insects = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Disease Disease
        {
            get { return m_Disease; }
            set { m_Disease = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Fungi Champignons
        {
            get { return m_Fungi; }
            set { m_Fungi = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public PlantPoison Poison
        {
            get { return m_Poison; }
            set { m_Poison = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Hydration
        {
            get { return m_Hydration; }
            set
            {
                m_Hydration = value;

                if (m_Hydration > 100)
                    m_Hydration = 100;

                if (m_Hydration < 0)
                    m_Hydration = 0;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Reagent
        {
            get { return m_Reagent; }
            set
            {
                if (value < 0)
                    value = 0;

                if (value > MaxReagent)
                    value = MaxReagent;

                m_Reagent = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Seed
        {
            get { return m_Seed; }
            set
            {
                if (value < 0)
                    value = 0;

                if (value > MaxSeed)
                    value = MaxSeed;

                m_Seed = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public BaseBowl Bowl
        {
            get { return m_Bowl; }
            set { m_Bowl = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime NextGrowth
        {
            get { return m_NextGrowth; }
            set { m_NextGrowth = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime NextSeed
        {
            get { return m_NextSeed; }
            set { m_NextSeed = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Timer TimerGrowth
        {
            get { return m_TimerGrowth; }
            set { m_TimerGrowth = value; }
        }

        public abstract PlantType PlantType { get; }
        public abstract Item RegeantType { get; }
        public abstract int MaxReagent { get; }
        public abstract int MaxSeed { get; }

        public virtual int HueBegin { get { return 0; } }
        public virtual int HueEnd { get { return 0; } }

        public bool IsGathered { get { return Movable; } }

		public BasePlant( int itemID ) : base( itemID )
		{
            Name = "plante";
			Weight = 0.5;
            Movable = false;
		}

        public BasePlant(Serial serial) : base(serial)
		{
        }

        public abstract int ComputeItemID();
        public abstract Item GetPlantReagent();
        public abstract BaseSeed GetSeed();

        public void ActivateTimer()
        {
            if (!IsInBowl)
                return;

            m_StateOfGrowth = StateOfGrowth.Seed;
            m_Hydration = 35;

            if (m_TimerGrowth == null)
                m_TimerGrowth = new GrowthTimer(m_Bowl);

            m_TimerGrowth.Start();
        }

        public virtual TimeSpan GetGrowthDelay()
        {
            switch (m_StateOfGrowth)
            {
                case StateOfGrowth.Seed: return TimeSpan.FromHours(12.0);
                case StateOfGrowth.Germ: return TimeSpan.FromHours(16.0);
                case StateOfGrowth.Young: return TimeSpan.FromHours(20.0);
                case StateOfGrowth.Mature: return TimeSpan.FromHours(96.0);
                case StateOfGrowth.Deterioration: return TimeSpan.FromHours(24.0);
                default: return TimeSpan.FromDays(365.0);
            }
        }

        public virtual TimeSpan GetSeedDelay()
        {
            return TimeSpan.FromHours(2.0);
        }

        public virtual void SetNextGrowth()
        {
            m_NextGrowth = DateTime.Now + GetGrowthDelay();
        }

        public virtual void SetNextSeed()
        {
            m_NextGrowth = DateTime.Now + GetSeedDelay();
        }

        public virtual void AddSeed()
        {
            if (m_Seed < MaxSeed)
                m_Seed++;

            SetNextSeed();
        }

        public virtual void UpdateGrowth()
        {
            if (m_StateOfGrowth == StateOfGrowth.Deterioration)
            {
                Die(CauseOfDie.TooOld);
            }
            else
            {
                m_StateOfGrowth = (StateOfGrowth)((int)m_StateOfGrowth++);
                SetNextGrowth();

                if (IsMature)
                    SetNextSeed();
            }

            if (IsInBowl)
                m_Bowl.ComputeItemID();
        }

        public virtual void Hydrate(int amount)
        {
            m_Hydration += amount;
        }

        public virtual Insects GetRandomInsects()
        {
            switch (Utility.Random(6))
            {
                case 0: return Insects.Chenilles;
                case 1: return Insects.Doryphores;
                case 2: return Insects.Limaces;
                case 3: return Insects.PercesOreilles;
                case 4: return Insects.Pucerons;
                default: return Insects.Sauterelles;
            }
        }

        public virtual void AddInsects()
        {
            AddInsects(GetRandomInsects());
        }

        public virtual void AddInsects(Insects insects)
        {
            m_Insects = insects;
        }

        public virtual Disease GetRandomDisease()
        {
            switch (Utility.Random(11))
            {
                case 0: return Disease.Aleurodes;
                case 1: return Disease.Armillaire;
                case 2: return Disease.Cécidomyie;
                case 3: return Disease.Chancre;
                case 4: return Disease.Fumagine;
                case 5: return Disease.Nématode;
                case 6: return Disease.Noctuelle;
                case 7: return Disease.Psylle;
                case 8: return Disease.Rouille;
                case 9: return Disease.Tavelure;
                case 10: return Disease.Thrips;
                default: return Disease.Rouille;
            }
        }

        public virtual void AddDisease()
        {
            AddDisease(GetRandomDisease());
        }

        public virtual void AddDisease(Disease disease)
        {
            m_Disease = disease;
        }

        public virtual Fungi GetRandomFungi()
        {
            switch (Utility.Random(6))
            {
                case 0: return Fungi.ChampignonALamelle;
                case 1: return Fungi.Bolet;
                case 2: return Fungi.Polyphores;
                case 3: return Fungi.Phalles;
                case 4: return Fungi.Vesses;
                default: return Fungi.Gesastres;
            }
        }

        public virtual void AddFungi()
        {
            AddFungi(GetRandomFungi());
        }

        public virtual void AddFungi(Fungi champignon)
        {
            m_Fungi = champignon;
        }

        public virtual void Die(CauseOfDie cause)
        {
            switch (cause)
            {
                case CauseOfDie.TooOld: PublicOverheadMessage(Server.Network.MessageType.Regular, 0, false, "La plante meurt par vieillesse."); break;
                case CauseOfDie.NotHydrated: PublicOverheadMessage(Server.Network.MessageType.Regular, 0, false, "La plante meurt de soif."); break;
                case CauseOfDie.TooHydrated: PublicOverheadMessage(Server.Network.MessageType.Regular, 0, false, "La plante meurt noyée."); break;
                case CauseOfDie.Insects: PublicOverheadMessage(Server.Network.MessageType.Regular, 0, false, "La plante meurt par les insectes."); break;
                case CauseOfDie.Disease: PublicOverheadMessage(Server.Network.MessageType.Regular, 0, false, "La plante meurt par les maladies."); break;
                case CauseOfDie.Fungi: PublicOverheadMessage(Server.Network.MessageType.Regular, 0, false, "La plante meurt par les champignons."); break;
                case CauseOfDie.Poison: PublicOverheadMessage(Server.Network.MessageType.Regular, 0, false, "La plante meurt par le poison."); break;
            }

            Delete();
        }

        private class GrowthTimer : Timer
        {
            private BaseBowl m_Bowl;

            public GrowthTimer(BaseBowl bowl) : base(TimeSpan.FromSeconds(5.0), TimeSpan.FromMinutes(45.0))
            {
                Priority = TimerPriority.OneMinute;
                m_Bowl = bowl;
            }

            protected override void OnTick()
            {
                if (m_Bowl == null || m_Bowl.Deleted || !m_Bowl.HasPlant || m_Bowl.IsEmpty)
                {
                    Stop();
                }
                else
                {
                    if (m_Bowl.Plant.NextGrowth < DateTime.Now)
                        m_Bowl.Plant.UpdateGrowth();

                    if (m_Bowl.Plant.IsMature && m_Bowl.Plant.NextSeed < DateTime.Now)
                        m_Bowl.Plant.AddSeed();

                    if (!m_Bowl.Plant.HasInsects && Utility.Random(150) == 0)
                        m_Bowl.Plant.AddInsects();

                    if (!m_Bowl.Plant.HasDisease && Utility.Random(130) == 0)
                        m_Bowl.Plant.AddDisease();

                    if (!m_Bowl.Plant.HasDisease && Utility.Random(100) == 0)
                        m_Bowl.Plant.AddFungi();

                    if (m_Bowl.Plant.StateOfHydration == StateOfHydration.Low && Utility.Random(m_Bowl.Plant.Hydration * 2) == 0)
                        m_Bowl.Plant.Die(CauseOfDie.NotHydrated);

                    if (m_Bowl.Plant.StateOfHydration == StateOfHydration.Drowned 
                        && Utility.Random((101 - m_Bowl.Plant.Hydration) < 1 ? 1 : 101 - m_Bowl.Plant.Hydration) == 0)
                        m_Bowl.Plant.Die(CauseOfDie.TooHydrated);

                    if (m_Bowl.Plant.HasInsects && Utility.RandomBool())
                        m_Bowl.Plant.Die(CauseOfDie.Insects);

                    if (m_Bowl.Plant.HasDisease && Utility.RandomBool())
                        m_Bowl.Plant.Die(CauseOfDie.Disease);

                    if (m_Bowl.Plant.HasFungi && Utility.RandomBool())
                        m_Bowl.Plant.Die(CauseOfDie.Fungi);

                    if (m_Bowl.Plant.HasPoison)
                        m_Bowl.Plant.Die(CauseOfDie.Poison);

                    m_Bowl.Plant.Hydrate(-1);
                }
            }
        }

        public virtual void ExtractReagent(Mobile from)
        {
            if (!IsGathered)
            {
                from.SendMessage("Vous devez cueillir la plante avant d'extraire sa composante.");
            }
            else if (MaxReagent > 0)
            {
                Item reagent = GetPlantReagent();

                reagent.Amount = MaxReagent > 2 ? Utility.RandomMinMax(MaxReagent - 2, MaxReagent + 2) : MaxReagent;

                from.AddToBackpack(reagent);
                from.SendMessage("Vous extrayez la composante avec succès.");

                Delete();
            }
            else if (HueBegin != 0 && HueEnd != 0)
            {
                from.SendMessage("Choisissez un bac de teinture.");
                from.Target = new DyeTubTarget(from, this);
            }
            else
            {
                from.SendMessage("Aucune composante ou teinture ne peut être extraite de cette plante.");
            }
        }

		private class DyeTubTarget : Target
        {
            private Mobile m_From;
            private BasePlant m_Plant;

			public DyeTubTarget( Mobile from, BasePlant plant ) : base( 1, false, TargetFlags.None )
			{
                m_From = from;
                m_Plant = plant;
			}

			protected override void OnTarget( Mobile from, object o )
			{
                if (o is DyeTub)
                {
                    //m_From.SendGump(new TeintureGump(m_From, TeintureTabs.Baies, m_Plant));
                }
                else
                {
                    m_From.SendMessage("Vous devez choisir un bac de teinture.");
                }
			}
		}

        public override void OnSingleClick(Mobile from)
        {
            base.OnSingleClick(from);

            /*if (from is TMobile)
            {
                TMobile m = (TMobile)from;

                if (m.GetAptitudeValue(NAptitude.Botanique) > 0)
                    LabelTo(m, String.Format("[{0}]", BotaniqueSystem.GetPlantName(PlantType, false)));
            }*/
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsGathered)
            {
                if (!from.InRange(Location, 2))
                {
                    from.SendLocalizedMessage(500446); // That is too far away.
                }
                else
                {
                    Movable = true;

                    from.PlaySound(85);
                    from.AddToBackpack(this);
                }
            }
        }

        public override void OnAfterDelete()
        {
            if (m_TimerGrowth != null)
            {
                m_TimerGrowth.Stop();
                m_TimerGrowth = null;
            }

            if (IsInBowl)
                m_Bowl.ComputeItemID();
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 2 ); // version

            writer.Write((int)m_StateOfGrowth);
            writer.Write((int)m_Insects);
            writer.Write((int)m_Disease);
            writer.Write((int)m_Hydration);
            writer.Write((int)m_Reagent);
            writer.Write((int)m_Seed);
            writer.Write((DateTime)m_NextGrowth);
            writer.Write((DateTime)m_NextSeed);
            writer.Write((Item)m_Bowl);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            switch (version)
            {
                case 2:
                    {
                        m_StateOfGrowth = (StateOfGrowth)reader.ReadInt();
                        m_Insects = (Insects)reader.ReadInt();
                        m_Disease = (Disease)reader.ReadInt();
                        m_Hydration = reader.ReadInt();
                        m_Reagent = reader.ReadInt();
                        m_Seed = reader.ReadInt();
                        m_NextGrowth = reader.ReadDateTime();
                        m_NextSeed = reader.ReadDateTime();
                        m_Bowl = (BaseBowl)reader.ReadItem();
                        goto case 1;
                    }
                case 1:
                    {
                        goto case 0;
                    }
                case 0:
                    {
                        if (version < 1)
                        {
                            reader.ReadBool();
                            reader.ReadBool();
                        }

                        break;
                    }
            }

            if (m_Bowl != null)
            {
                m_TimerGrowth = new GrowthTimer(m_Bowl);
                m_TimerGrowth.Start();
            }

            Name = "plante";
            Weight = 0.5;
		}
    }

    public class GuiPlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Gui; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "Soigne l'hypertension."; } }
        public override string Latin { get { return "VISCUM ALBUM"; } }

        [Constructable]
        public GuiPlante() : base(15739)
        {
            Name = "Le Gui";
        }

        public GuiPlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15739;
                case StateOfGrowth.Mature: return 15739;
                case StateOfGrowth.Deterioration: return 15739;

                default: return 15739;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new GuiSeed();
        }
    }

    public class InulePlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Inule; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "L'Inule infusée dans de l'eau chaude aide à soigner les hallucinations. Il est utilisé entre autre pour aider à calmer toutes concoctions hallucinogène et est prescrit pour soigner les dépendances au Gomphrena."; } }
        public override string Latin { get { return "HELENIUM"; } }

        [Constructable]
        public InulePlante() : base(15809)
        {
            Name = "L'inule";
        }

        public InulePlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15809;
                case StateOfGrowth.Mature: return 15811;
                case StateOfGrowth.Deterioration: return 15811;

                default: return 15809;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new InuleSeed();
        }
    }

    public class BenoitePlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Benoite; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "En infusion, la Benoite aide à baisser la fièvre."; } }
        public override string Latin { get { return "GEUM URBANUM"; } }

        [Constructable]
        public BenoitePlante() : base(15813)
        {
            Name = "La Benoite";
        }

        public BenoitePlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15813;
                case StateOfGrowth.Mature: return 15813;
                case StateOfGrowth.Deterioration: return 15813;

                default: return 15813;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new BenoiteSeed();
        }
    }

    public class SolidagoPlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Solidago; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "La mixture péteuse contenue dans les tiges soigne les brûlures en raffermissant la peau."; } }
        public override string Latin { get { return "SOLIDAGO CANADENSIS"; } }

        [Constructable]
        public SolidagoPlante() : base(15814)
        {
            Name = "Le Solidago";
        }

        public SolidagoPlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15814;
                case StateOfGrowth.Mature: return 15814;
                case StateOfGrowth.Deterioration: return 15814;

                default: return 15814;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new SolidagoSeed();
        }
    }

    public class GomphrenaPlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Gomphrena; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "Les feuilles de cette plante sont toxiques, mais aucunement mortelle en petite quantité. Elle agit sur la nervosité, sur les problèmes nerveux et aide à la détente. Il faut émincer les feuilles pour pouvoir les fumer à l'aide d'une pipe ou boire les tiges en infusion. Peut créer une très forte dépendance."; } }
        public override string Latin { get { return "GOMPHRENA HAAGEANA"; } }

        [Constructable]
        public GomphrenaPlante() : base(15815)
        {
            Name = "Le Gomphrena";
        }

        public GomphrenaPlante(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15815;
                case StateOfGrowth.Mature: return 15815;
                case StateOfGrowth.Deterioration: return 15815;

                default: return 15815;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new GomphrenaSeed();
        }
    }

    public class LavaterePlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Lavatere; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "Les fleurs ainsi que les feuilles de cette plante servent, une fois infusée ou mélangé dans du liquide en créant une mixture légèrement péteuse, à nettoyer l'intérieur. On l'utilise entre autre pour éliminer le poison du système. Cause de très forts vomissements."; } }
        public override string Latin { get { return "LAVATERA"; } }

        [Constructable]
        public LavaterePlante() : base(15816)
        {
            Name = "Le Lavatere";
        }

        public LavaterePlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15816;
                case StateOfGrowth.Mature: return 15816;
                case StateOfGrowth.Deterioration: return 15816;

                default: return 15816;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new LavatereSeed();
        }
    }


    public class PassiflorePlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Passiflore; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "Le Passiflore est une fleur toxique mais ne peut causer la mort que si on en abuse à outrance. Elle est hallucinogène et doit être inhalé par le nez en fumée. On utilise parfois ses tiges en encens dans les maisons car son odeur est très alléchante. Ce n'est que récemment qu'on a découvert ses propriétés hallucinogènes. Peut causer une très forte dépendance."; } }
        public override string Latin { get { return "PASSIFLORA CAERULEA"; } }

        [Constructable]
        public PassiflorePlante() : base(15817)
        {
            Name = "Le Passiflore";
        }

        public PassiflorePlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15817;
                case StateOfGrowth.Mature: return 15817;
                case StateOfGrowth.Deterioration: return 15817;

                default: return 15817;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new PassifloreSeed();
        }
    }

    public class MillepertuisPlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Millepertuis; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "Le Millepertuis est utilisé pour soigner la dépression. Il peut être fumé à l'aide d'une pipe ou mangé en salade. Le Millepertuis redonne de l'énergie et aide, pour une durée limité, à voir la vie plus belle qu'elle ne l'est. Peut causer une forte dépendance."; } }
        public override string Latin { get { return "HYPERICUM CALCYNUM"; } }

        [Constructable]
        public MillepertuisPlante() : base(15818)
        {
            Name = "Le Millepertuis";
        }

        public MillepertuisPlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15818;
                case StateOfGrowth.Mature: return 15818;
                case StateOfGrowth.Deterioration: return 15818;

                default: return 15818;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new MillepertuisSeed();
        }
    }

    public class ArtichautPlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Artichaut; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "En mangeant les tiges de l'artichaut crues, nous pouvons contrôler les troubles du foie."; } }
        public override string Latin { get { return "CYNARA CARDUNCULUS"; } }

        [Constructable]
        public ArtichautPlante() : base(15819)
        {
            Name = "L'Artichaut";
        }

        public ArtichautPlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15819;
                case StateOfGrowth.Mature: return 15819;
                case StateOfGrowth.Deterioration: return 15819;

                default: return 15819;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new ArtichautSeed();
        }
    }

    public class ImmortellePlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Immortelle; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "L'Immortelle à Bractèes est une fleur qu'on utilise pour créer de la teinture."; } }
        public override string Latin { get { return "XEROCHRYSUM BRACTEATUM"; } }

        [Constructable]
        public ImmortellePlante() : base(15820)
        {
            Name = "L'immortelle";
        }

        public ImmortellePlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15820;
                case StateOfGrowth.Mature: return 15820;
                case StateOfGrowth.Deterioration: return 15820;

                default: return 15820;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new ImmortelleSeed();
        }
    }

    public class MelaleucaPlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Melaleuca; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "Le Melaleuca est une plante qu'on utilise pour créer de la teinture."; } }
        public override string Latin { get { return "MELALEUCA ARMILLARIS "; } }

        [Constructable]
        public MelaleucaPlante() : base(15821)
        {
            Name = "Le Melaleuca";
        }

        public MelaleucaPlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15821;
                case StateOfGrowth.Mature: return 15821;
                case StateOfGrowth.Deterioration: return 15821;

                default: return 15821;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new MelaleucaSeed();
        }
    }

    public class BourrachePlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Bourrache; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "En crème, elle aide à lutter contre la peau sensible. Elle permet, entre autre, de redonner une couleur de base à une peau attaquée par la maladie. ( ex. La Neurodermatite )"; } }
        public override string Latin { get { return "BORAGO OFFICINALIS"; } }

        [Constructable]
        public BourrachePlante() : base(15822)
        {
            Name = "La Bourrache";
        }

        public BourrachePlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15822;
                case StateOfGrowth.Mature: return 15822;
                case StateOfGrowth.Deterioration: return 15822;

                default: return 15822;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new BourracheSeed();
        }
    }

    public class KalmiaPlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Kalmia; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "La Kalmia est une fleur qu'on utilise pour créer de la teinture."; } }
        public override string Latin { get { return "KALMIA LATIFOLIA"; } }

        [Constructable]
        public KalmiaPlante() : base(15823)
        {
            Name = "La Kalmia";
        }

        public KalmiaPlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15823;
                case StateOfGrowth.Mature: return 15823;
                case StateOfGrowth.Deterioration: return 15823;

                default: return 15823;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new KalmiaSeed();
        }
    }

    public class PaquerettePlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Paquerette; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "Transformée en poudre et mélangé avec du gras, la Paquerette peut être colorée pour servir mesdames. On l'utilise comme fard à paupière ou comme teinture pour les lèvres."; } }
        public override string Latin { get { return "BELLIS PERENNIS"; } }

        [Constructable]
        public PaquerettePlante() : base(15824)
        {
            Name = "La Paquerette";
        }

        public PaquerettePlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15824;
                case StateOfGrowth.Mature: return 15824;
                case StateOfGrowth.Deterioration: return 15824;

                default: return 15824;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new PaqueretteSeed();
        }
    }

    public class AsphodelinePlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Asphodeline; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "En crème, l'Asphodeline guérit les problèmes de la peau en diminuant les rougeurs, les plaques d'eczéma et l'acné."; } }
        public override string Latin { get { return "ASPHODELUS LUTEA"; } }

        [Constructable]
        public AsphodelinePlante() : base(15825)
        {
            Name = "L'Asphodeline";
        }

        public AsphodelinePlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15825;
                case StateOfGrowth.Mature: return 15825;
                case StateOfGrowth.Deterioration: return 15825;

                default: return 15825;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new AsphodelineSeed();
        }
    }

    public class AirellePlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Airelle; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return ""; } }
        public override string Latin { get { return ""; } }

        [Constructable]
        public AirellePlante() : base(15826)
        {
            Name = "Airelle";
        }

        public AirellePlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15826;
                case StateOfGrowth.Mature: return 15827;
                case StateOfGrowth.Deterioration: return 15828;

                default: return 15826;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new AirelleSeed();
        }
    }

    public class LiseronPlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Liseron; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "Le liseron infusé agit sur les troubles du sommeil. Aide ceux qui font beaucoup de cauchemars ou ceux souffrant d'insomnie."; } }
        public override string Latin { get { return "CONVOLVULUS SEPIUM"; } }

        [Constructable]
        public LiseronPlante()
            : base(15829)
        {
            Name = "Le Liseron";
        }

        public LiseronPlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15829;
                case StateOfGrowth.Mature: return 15829;
                case StateOfGrowth.Deterioration: return 15829;

                default: return 15829;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new LiseronSeed();
        }
    }

    public class AgastachePlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Agastache; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "L'Agastache est une fleur qu'on utilise pour créer de la teinture."; } }
        public override string Latin { get { return "AGASTACHE URTICIFOLIA"; } }

        [Constructable]
        public AgastachePlante()
            : base(15830)
        {
            Name = "L'Agastache";
        }

        public AgastachePlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15830;
                case StateOfGrowth.Mature: return 15830;
                case StateOfGrowth.Deterioration: return 15830;

                default: return 15830;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new AgastacheSeed();
        }
    }

    public class ChicorePlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Chicore; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "Mis en poudre à l'aide d'un mortier et dilué dans une boisson chaude, la Chicorée aide la digestion."; } }
        public override string Latin { get { return "CICHORIUM ENDIVIA"; } }

        [Constructable]
        public ChicorePlante()
            : base(15831)
        {
            Name = "La Chicore";
        }

        public ChicorePlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15831;
                case StateOfGrowth.Mature: return 15831;
                case StateOfGrowth.Deterioration: return 15831;

                default: return 15831;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new ChicoreSeed();
        }
    }

    public class AchilleePlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Achillee; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "L'Achillée est une plante qu'on utilise dans les teintures. Nous coupons les branches pour ne garder que les fleurs et, à l'aide des pétales de la plante, on créer la teinture."; } }
        public override string Latin { get { return "ACHILEA FILIPENDULA"; } }

        [Constructable]
        public AchilleePlante()
            : base(15833)
        {
            Name = "L'Achillee";
        }

        public AchilleePlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15833;
                case StateOfGrowth.Mature: return 15834;
                case StateOfGrowth.Deterioration: return 15834;

                default: return 15833;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new AchilleeSeed();
        }
    }

    public class CistePlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Ciste; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "Le Ciste est une fleur qu'on utilise pour créer de la teinture."; } }
        public override string Latin { get { return "CISTUS"; } }

        [Constructable]
        public CistePlante()
            : base(15835)
        {
            Name = "Le Ciste";
        }

        public CistePlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15835;
                case StateOfGrowth.Mature: return 15835;
                case StateOfGrowth.Deterioration: return 15835;

                default: return 15835;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new CisteSeed();
        }
    }

    public class AconitPlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Aconit; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "À l'aide des bulbes du coeur ainsi que des tiges de la fleur, nous créons des mixtures toxique. L'Aconit est utilisée dans un bon nombre de poison une fois réduite en jus."; } }
        public override string Latin { get { return "ACONITUM NAPELLUS"; } }

        [Constructable]
        public AconitPlante()
            : base(15836)
        {
            Name = "L'Aconit";
        }

        public AconitPlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15836;
                case StateOfGrowth.Mature: return 15836;
                case StateOfGrowth.Deterioration: return 15836;

                default: return 15836;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new AconitSeed();
        }
    }

    public class AdonisPlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Adonis; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "L'Adonis, une fois réduite en poudre et diluée dans de l'eau est souvent utilisée en médecine pour régulariser le rythme cardiaque et guérir les problèmes du coeur."; } }
        public override string Latin { get { return "L'ADONIS ANNUA"; } }

        [Constructable]
        public AdonisPlante()
            : base(15837)
        {
            Name = "L'Adonis";
        }

        public AdonisPlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15837;
                case StateOfGrowth.Mature: return 15837;
                case StateOfGrowth.Deterioration: return 15837;

                default: return 15837;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new AdonisSeed();
        }
    }

    public class BuplevrePlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Buplevre; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return ""; } }
        public override string Latin { get { return ""; } }

        [Constructable]
        public BuplevrePlante()
            : base(15838)
        {
            Name = "Buplevre";
        }

        public BuplevrePlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15838;
                case StateOfGrowth.Mature: return 15838;
                case StateOfGrowth.Deterioration: return 15838;

                default: return 15838;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new BuplevreSeed();
        }
    }

    public class SouciPlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Souci; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "Le Souci est une plante qu'on utilise pour créer de la teinture."; } }
        public override string Latin { get { return "CALENDULS OFFICINALIS"; } }

        [Constructable]
        public SouciPlante()
            : base(15839)
        {
            Name = "Le Souci";
        }

        public SouciPlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15839;
                case StateOfGrowth.Mature: return 15839;
                case StateOfGrowth.Deterioration: return 15839;

                default: return 15839;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new SouciSeed();
        }
    }

    public class SaugePlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Sauge; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "La sauge est un antidouleur utilisé comme antiseptique en médecine. Peut créer une forte dépendance."; } }
        public override string Latin { get { return "SALVIA GRAGAMII"; } }

        [Constructable]
        public SaugePlante()
            : base(15840)
        {
            Name = "Le Sauge";
        }

        public SaugePlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15840;
                case StateOfGrowth.Mature: return 15840;
                case StateOfGrowth.Deterioration: return 15840;

                default: return 15840;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new SaugeSeed();
        }
    }

    public class ZanthoxylumPlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Zanthoxylum; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "Le jus des fruits du Zanthoxylum aident à calmer les vomissements."; } }
        public override string Latin { get { return "ZANTHOXYLUM PLANISPINUM"; } }

        [Constructable]
        public ZanthoxylumPlante()
            : base(15841)
        {
            Name = "Le Zanthoxylum";
        }

        public ZanthoxylumPlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15841;
                case StateOfGrowth.Mature: return 15841;
                case StateOfGrowth.Deterioration: return 15841;

                default: return 15841;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new ZanthoxylumSeed();
        }
    }

    public class NiellePlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Nielle; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "La Nielle est une plante toxique. On s'en sert entre autre comme insecticide mais aussi dans les poisons."; } }
        public override string Latin { get { return "LYCHNIS GITHAGO"; } }

        [Constructable]
        public NiellePlante()
            : base(15738)
        {
            Name = "La Nielle";
        }

        public NiellePlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15738;
                case StateOfGrowth.Mature: return 15738;
                case StateOfGrowth.Deterioration: return 15738;

                default: return 15738;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new NielleSeed();
        }
    }

    public class BetoinePlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Betoine; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "En infusion, la Béttoine agit sur les voies respiratoire pour les débloquer et calme les nerfs. C'est un aphrodisiaque."; } }
        public override string Latin { get { return "STACHYS OFFICINALIS"; } }

        [Constructable]
        public BetoinePlante()
            : base(15746)
        {
            Name = "La Bettoine";
        }

        public BetoinePlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15746;
                case StateOfGrowth.Mature: return 15746;
                case StateOfGrowth.Deterioration: return 15746;

                default: return 15746;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new BetoineSeed();
        }
    }

    public class TanaisiePlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Tanaisie; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "En infusin, la Tanaisie est un remède contre les vers."; } }
        public override string Latin { get { return "TANACETUM VULGARE"; } }

        [Constructable]
        public TanaisiePlante()
            : base(15749)
        {
            Name = "La Tanaisie";
        }

        public TanaisiePlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15749;
                case StateOfGrowth.Mature: return 15749;
                case StateOfGrowth.Deterioration: return 15749;

                default: return 15749;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new TanaisieSeed();
        }
    }

    public class LinPlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Lin; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "La fleur de lin est utilisée pour créer le lin, matériel nécessaire pour les couturiers."; } }
        public override string Latin { get { return "LINUM ASTRIACUM"; } }

        [Constructable]
        public LinPlante()
            : base(15748)
        {
            Name = "Le Lin";
        }

        public LinPlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 15748;
                case StateOfGrowth.Mature: return 15748;
                case StateOfGrowth.Deterioration: return 15748;

                default: return 15748;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new LinSeed();
        }
    }

    public class CotonPlante : BasePlant
    {
        public override PlantType PlantType { get { return PlantType.Coton; } }
        public override Item RegeantType { get { return null; } }
        public override int MaxReagent { get { return 0; } }
        public override int MaxSeed { get { return 4; } }
        public override string Description { get { return "Le coton est une fibre végétale qui entoure les graines des cotonniers. Il est très utilisé par les couturiers."; } }
        public override string Latin { get { return String.Empty; } }

        [Constructable]
        public CotonPlante()
            : base(3153)
        {
            Name = "Le Coton";
        }

        public CotonPlante(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override int ComputeItemID()
        {
            switch (StateOfGrowth)
            {
                case StateOfGrowth.Young: return 3153;
                case StateOfGrowth.Mature: return 3155;
                case StateOfGrowth.Deterioration: return 3151;

                default: return 3153;
            }
        }

        public override Item GetPlantReagent()
        {
            return new Cotton();
        }

        public override BaseSeed GetSeed()
        {
            return new CotonSeed();
        }
    }
}