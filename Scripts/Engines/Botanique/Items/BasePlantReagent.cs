using System;
using Server;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
	public abstract class BasePlantReagent : Item
    {
        /*public abstract PlantType PlantType { get; }
        public abstract string ReagentName { get; }*/
        public abstract string Description { get; }

        public BasePlantReagent(int itemID) : this(itemID, 1)
		{
		}

        public BasePlantReagent(int itemID, int amount) : base(itemID)
		{
            Name = "Composante";
			Weight = 0.1;
            Amount = amount;
            Stackable = true;
		}

        public BasePlantReagent(Serial serial) : base(serial)
		{
        }

        public override void OnSingleClick(Mobile from)
        {
            base.OnSingleClick(from);

            if (from is PlayerMobile)
            {
                PlayerMobile m = (PlayerMobile)from;

                /*if (ReagentName != null && ReagentName != "" && m.GetAptitudeValue(NAptitude.Botanique) > 0)
                    LabelTo(m, String.Format("[{0}]", ReagentName));*/
            }
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

            //Name = "composante";
            Weight = 0.1;
		}
    }

    public class ChampignonDesMortsRegeant : BasePlantReagent
    {
        /*public override PlantType PlantType { get { return PlantType.Theokalon; } }
        public override string ReagentName { get { return "Champignon Des Morts"; } }*/
        public override string Description { get { return ""; } }

        [Constructable]
        public ChampignonDesMortsRegeant() : this(1)
        {
        }

        [Constructable]
        public ChampignonDesMortsRegeant(int amount) : base(3971)
        {
            Name = "Champignon Des Morts";
            Amount = amount;
        }

        public ChampignonDesMortsRegeant(Serial serial)
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
    }

    public class OeildeTritonRegeant : BasePlantReagent
    {
        public override string Description { get { return ""; } }


        [Constructable]
        public OeildeTritonRegeant()
            : this(1)
        {
        }

        [Constructable]
        public OeildeTritonRegeant(int amount)
            : base(3975)
        {
            Name = "Oeil de Triton";
            Amount = amount;
        }

        public OeildeTritonRegeant(Serial serial)
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
    }

    public class ObsidienRegeant : BasePlantReagent
    {
        public override string Description { get { return ""; } }

        [Constructable]
        public ObsidienRegeant()
            : this(1)
        {
        }

        [Constructable]
        public ObsidienRegeant(int amount)
            : base(3977)
        {
            Name = "Obsidien";
            Amount = amount;
        }

        public ObsidienRegeant(Serial serial)
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
    }

    public class LarmeRegeant : BasePlantReagent
    {
        public override string Description { get { return ""; } }

        [Constructable]
        public LarmeRegeant()
            : this(1)
        {
        }

        [Constructable]
        public LarmeRegeant(int amount)
            : base(9035)
        {
            Name = "Larme de Femme d'Atlas";
            Amount = amount;
        }

        public LarmeRegeant(Serial serial)
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
    }

    public class GueuledeLoupRegeant : BasePlantReagent
    {
        public override string Description { get { return ""; } }

        [Constructable]
        public GueuledeLoupRegeant()
            : this(1)
        {
        }

        [Constructable]
        public GueuledeLoupRegeant(int amount)
            : base(4389)
        {
            Name = "Gueule de Loup";
            Amount = amount;
        }

        public GueuledeLoupRegeant(Serial serial)
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
    }

    public class EclatDeVolcan : BasePlantReagent
    {
        public override string Description { get { return ""; } }

        [Constructable]
        public EclatDeVolcan()
            : this(1)
        {
        }

        [Constructable]
        public EclatDeVolcan(int amount)
            : base(0x345A)
        {
            Name = "Éclat de Volcan";
            Amount = amount;
        }

        public EclatDeVolcan(Serial serial)
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
    }

    public class Fumier : BasePlantReagent
    {
        public override string Description { get { return ""; } }

        [Constructable]
        public Fumier()
            : this(1)
        {
        }

        [Constructable]
        public Fumier(int amount)
            : base(0xF81)
        {
            Name = "Fumier";
            Amount = amount;
        }

        public Fumier(Serial serial)
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
    }

    public class Cendres : BasePlantReagent
    {
        public override string Description { get { return ""; } }

        [Constructable]
        public Cendres()
            : this(1)
        {
        }

        [Constructable]
        public Cendres(int amount)
            : base(0x11EB)
        {
            Name = "Cendres";
            Amount = amount;

            Hue = 2055;
        }

        public Cendres(Serial serial)
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
    }

    public class OutilFermentation : BasePlantReagent
    {
        public override string Description { get { return ""; } }

        [Constructable]
        public OutilFermentation()
            : this(1)
        {
        }

        [Constructable]
        public OutilFermentation(int amount)
            : base(0x183A)
        {
            Name = "Outil de Fermentation";
            Amount = amount;
        }

        public OutilFermentation(Serial serial)
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
    }

    public class OutilCoagulation : BasePlantReagent
    {
        public override string Description { get { return ""; } }

        [Constructable]
        public OutilCoagulation()
            : this(1)
        {
        }

        [Constructable]
        public OutilCoagulation(int amount)
            : base(0x182C)
        {
            Name = "Outil de Coagulation";
            Amount = amount;
        }

        public OutilCoagulation(Serial serial)
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

        public override void OnDoubleClick(Mobile from)
        {
            if ( from.Backpack != null ){
                if (IsChildOf(from.Backpack))
                {
                    from.SendMessage("Ciblez une créature morte.");
                    from.Target = new PickCorpseTarget(this);
                }
                else
                {
                    from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
                    return;
                }
            }
        }

        private class PickCorpseTarget : Target
        {
            private OutilCoagulation m_OutilCoagulation;

            public PickCorpseTarget(OutilCoagulation outilCoagulation)
                : base(3, false, TargetFlags.None)
            {
                m_OutilCoagulation = outilCoagulation;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (m_OutilCoagulation.Deleted)
                    return;

                Corpse m = targeted as Corpse;

                if (m != null && m is Corpse)
                {
                    if (!m.Name.Contains("Saigné"))
                    {
                        if (from.Backpack.ConsumeTotal(typeof(Bottle), 1))
                        {
                            from.AddToBackpack(new FioleDeSang(1));
                            from.SendMessage("Vous remplissez une fiole avec le sang de la créature.");
                            m.Name = m.Name + " Saigné";
                        }
                        else
                            from.SendMessage("Vous devez avoir une bouteille vide dans votre sac pour utiliser ça.");
                    }
                    else
                        from.SendMessage("Le sang de cette créature a déjà été recueilli.");
                }
                else
                    from.SendMessage("Vous devez cibler une créature morte !");
            }
        }
    }

    public class ResineAmbreBleue : BasePlantReagent
    {
        public override string Description { get { return ""; } }

        [Constructable]
        public ResineAmbreBleue()
            : this(1)
        {
        }

        [Constructable]
        public ResineAmbreBleue(int amount)
            : base(0xF8B)
        {
            Name = "Résine d'Ambre Bleue";
            Amount = amount;

            Hue = 2045;
        }

        public ResineAmbreBleue(Serial serial)
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
    }

    public class Dattes : BasePlantReagent
    {
        public override string Description { get { return ""; } }

        [Constructable]
        public Dattes()
            : this(1)
        {
        }

        [Constructable]
        public Dattes(int amount)
            : base(0x1727)
        {
            Name = "Dattes";
            Amount = amount;
        }

        public Dattes(Serial serial)
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
    }

    public class PierreVolcanique : BasePlantReagent
    {
        public override string Description { get { return ""; } }

        [Constructable]
        public PierreVolcanique()
            : this(1)
        {
        }

        [Constructable]
        public PierreVolcanique(int amount)
            : base(0xF7F)
        {
            Name = "Pierre Volcanique";
            Amount = amount;
        }

        public PierreVolcanique(Serial serial)
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
    }

    public class Coquillage : BasePlantReagent
    {
        public override string Description { get { return ""; } }

        [Constructable]
        public Coquillage()
            : this(1)
        {
        }

        [Constructable]
        public Coquillage(int amount)
            : base(0xFC7)
        {
            GoldValue = 6;
            Name = "Coquillage";
            Amount = amount;
        }

        public Coquillage(Serial serial)
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
    }

    public class FioleDeSang : BasePlantReagent
    {
        public override string Description { get { return ""; } }

        [Constructable]
        public FioleDeSang()
            : this(1)
        {
        }

        [Constructable]
        public FioleDeSang(int amount)
            : base(0xF7D)
        {
            Name = "Fiole de Sang";
            Amount = amount;
        }

        public FioleDeSang(Serial serial)
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
    }

    public class Lin : BasePlantReagent
    {
        public override string Description { get { return ""; } }

        [Constructable]
        public Lin()
            : this(1)
        {
        }

        [Constructable]
        public Lin(int amount)
            : base(4389)
        {
            Name = "Lin";
            Amount = amount;
        }

        public Lin(Serial serial)
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

        public override void OnDoubleClick(Mobile from)
        {
            if (IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502655); // What spinning wheel do you wish to spin this on?
                from.Target = new PickWheelTarget(this);
            }
            else
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
            }
        }

        public static void OnSpun(ISpinningWheel wheel, Mobile from, int hue)
        {
            //Item item = new SpoolOfThread(6);

            Item item = new LinBoltOfCloth(1);

            item.Hue = hue;

            from.AddToBackpack(item);
            from.SendMessage("Vous utilisez l'outil pour récupperez le lin de la fleur."); // You put the spools of thread in your backpack.
        }

        private class PickWheelTarget : Target
        {
            private Lin m_Lin;

            public PickWheelTarget(Lin lin)
                : base(3, false, TargetFlags.None)
            {
                m_Lin = lin;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (m_Lin.Deleted)
                    return;

                ISpinningWheel wheel = targeted as ISpinningWheel;

                if (wheel == null && targeted is AddonComponent)
                    wheel = ((AddonComponent)targeted).Addon as ISpinningWheel;

                if (wheel is Item)
                {
                    Item item = (Item)wheel;

                    if (!m_Lin.IsChildOf(from.Backpack))
                    {
                        from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
                    }
                    else if (wheel.Spinning)
                    {
                        from.SendLocalizedMessage(502656); // That spinning wheel is being used.
                    }
                    else
                    {
                        m_Lin.Consume();
                        wheel.BeginSpin(new SpinCallback(Cotton.OnSpun), from, m_Lin.Hue);
                    }
                }
                else
                {
                    from.SendLocalizedMessage(502658); // Use that on a spinning wheel.
                }
            }
        }
    }
}