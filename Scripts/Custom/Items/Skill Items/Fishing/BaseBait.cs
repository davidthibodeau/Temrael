using System;
using Server;
using Server.Items;
using Server.ContextMenus;
using System.Collections.Generic;

namespace Server
{
    public interface IFishingPole
    {
        Bait Bait { get; set; }
        int Charge { get; set; }
    }

    public enum Bait
    {
        Aucun,
        Truite,
        Dore,
        Carpe,
        Anguille,
        Esturgeon,
        Brochet,
        Morue,
        Fletan,
        Maquereau,
        Sole,
        Thon,
        Saumon,
        Raie,
        Espadon
    }
}

namespace Server.ContextMenus
{
    public class ApplyBaitEntry : ContextMenuEntry
    {
        private Mobile m_From;
        private BaseBait m_Bait;

        public ApplyBaitEntry(Mobile from, BaseBait bait) : base(90, 1)
        {
            m_From = from;
            m_Bait = bait;
        }

        public override void OnClick()
        {
            if (m_Bait.Deleted || !m_Bait.Movable || !m_From.CheckAlive())
                return;

            m_From.SendMessage("Appliquer sur quelle canne à pêche?");
            m_From.BeginTarget(1, false, Server.Targeting.TargetFlags.None, new TargetStateCallback(Bait_OnApply), m_Bait);
        }

        private void Bait_OnApply(Mobile from, object targeted, object state)
        {
            if (targeted is IFishingPole)
            {
                BaseBait bait = state as BaseBait;
                IFishingPole pole = (IFishingPole)targeted;

                if (pole.Bait == Bait.Aucun && pole.Charge <= 0)
                {
                    pole.Bait = bait.Bait;
                    pole.Charge = bait.Charge;
                    from.SendMessage("Vous accrochez l'appât après la canne à pêche.");

                    bait.Delete();
                }
                else
                {
                    from.SendMessage("Cette canne à pêche possède déjà un appât.");
                }
            }
            else
            {
                from.SendMessage("Vous devez choisir une canne à pêche.");
            }
        }
    }
}

namespace Server.Items
{
    public abstract class BaseBait : Item
    {
        private Bait m_Bait;
        private int m_Charge;

        [CommandProperty(AccessLevel.GameMaster)]
        public Bait Bait
        {
            get { return m_Bait; }
            set { m_Bait = value; SetNewName(); InvalidateProperties();  }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Charge
        {
            get { return m_Charge; }
            set
            {
                m_Charge = value;

                if (m_Charge <= 0)
                    Delete();
                else if (m_Charge > 20)
                    m_Charge = 20;
            }
        }

        [Constructable]
        public BaseBait(Bait bait, int charge) : base(0xDCE)
        {
            Name = "appât";
            Weight = 0.5;

            m_Bait = bait;
            m_Charge = charge;
            Stackable = true;
        }

        public static string[] m_Material = new string[]
            {
                "aucun",
                "truite",
                "doré",
                "carpe",
                "anguille",
                "esturgeon",
                "brochet",
                "morue",
                "flétan",
                "maquereau",
                "sole",
                "thon",
                "saumon",
                "raie",
                "espadon",
            };

        public virtual string GetMaterial()
        {
            string value = "aucun";

            try
            {
                value = m_Material[((int)m_Bait)];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return value;
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            if (from.Alive && IsChildOf(from.Backpack))
            {
                list.Add(new ApplyBaitEntry(from, this));
            }

            base.GetContextMenuEntries(from, list);
        }

        public void SetNewName()
        {
            Name = "Appât : " + m_Material;
        }

        public static BaseBait CreateBait(Bait bait, int charge)
        {
            switch (bait)
            {
                case Bait.Truite: return new BaitTruite(charge);
                case Bait.Dore: return new BaitDore(charge);
                case Bait.Carpe: return new BaitCarpe(charge);
                case Bait.Anguille: return new BaitAnguille(charge);
                case Bait.Esturgeon: return new BaitEsturgeon(charge);
                case Bait.Brochet: return new BaitBrochet(charge);
                case Bait.Morue: return new BaitMorue(charge);
                case Bait.Fletan: return new BaitFletan(charge);
                case Bait.Maquereau: return new BaitMaquereau(charge);
                case Bait.Sole: return new BaitSole(charge);
                case Bait.Thon: return new BaitThon(charge);
                case Bait.Saumon: return new BaitSaumon(charge);
                case Bait.Raie: return new BaitRaie(charge);
                case Bait.Espadon: return new BaitEspadon(charge);
                default: return null;
            }
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            if (Amount > 1)
                list.Add(1060532, String.Format("{3} {0}{1}{2}", "Appâts [", GetMaterial(), "]", Amount)); // ~1_NUMBER~ ~2_ITEMNAME~
            else
                list.Add(String.Format("{0}{1}{2}", "Appât [", GetMaterial(), "]")); // ingots
        }

        public BaseBait(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version

            writer.Write((int)m_Bait);
            writer.Write(m_Charge);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    {
                        m_Bait = (Bait)reader.ReadInt();
                        m_Charge = reader.ReadInt();
                        goto case 0;
                    }
                case 0:
                    {
                        break;
                    }
            }
        }
    }
}