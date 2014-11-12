using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;
using Server.ContextMenus;
using System.Collections.Generic;

namespace Server.ContextMenus
{
    public class AddSeedEntry : ContextMenuEntry
    {
        private Mobile m_From;
        private BaseBowl m_Bowl;

        public AddSeedEntry(Mobile from, BaseBowl bowl) : base(6056, 1)
        {
            m_From = from;
            m_Bowl = bowl;
        }

        public override void OnClick()
        {
            if (m_Bowl.Deleted || !m_Bowl.Movable || !m_Bowl.CanPlant || !m_From.CheckAlive())
                return;

            if (m_Bowl.HasPlant)
            {
                m_From.SendMessage("Il y a déja une graine dans ce pot.");
            }
            else
            {
                m_From.SendMessage("Choissisez la graine à planter dans le pot.");
                m_From.BeginTarget(1, false, TargetFlags.None, new TargetCallback(m_Bowl.ChooseSeed_OnTarget));
            }
        }
    }
}

namespace Server.Items
{
    [PropertyObject]
	public abstract class BaseBowl : Item
    {
        public bool HasEarth { get { return m_EarthType != EarthType.None; } }
        public bool HasPlant { get { return m_Plant != null && !m_Plant.Deleted; } }

        private EarthType m_EarthType;
        private BasePlant m_Plant;

        [CommandProperty(AccessLevel.Batisseur)]
        public EarthType EarthType
        {
            get { return m_EarthType; }
            set { m_EarthType = value; ItemID = ComputeItemID(); Weight = ComputeWeight(); }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public BasePlant Plant
        {
            get { return m_Plant; }
            set { m_Plant = value; }
        }

        public BaseBowl(int itemID) : base(itemID)
		{
        }

        public BaseBowl(Serial serial) : base(serial)
		{
        }

        public virtual bool CanPlant { get { return true; } }

        public abstract int ComputeItemID();
        public abstract double ComputeWeight();

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);

            if (from.Alive && CanPlant && HasEarth && !HasPlant)
                list.Add(new AddSeedEntry(from, this));
        }

        public void ChooseSeed_OnTarget(Mobile from, object targeted)
        {
            if (Deleted || !from.CheckAlive())
                return;

            if (targeted is BaseSeed)
            {
                if (((BaseSeed)targeted).PlantType != PlantType.None)
                    this.AddSeed((BaseSeed)targeted);
                else
                    from.SendMessage("Ceci n'est pas une graine valide..");
            }
            else
            {
                from.SendMessage("Vous devez choisir une graine.");
            }
        }

        public virtual void AddSeed(BaseSeed seed)
        {
            if (HasEarth && !HasPlant)
            {
                m_Plant = seed.GetPlant();
                m_Plant.Bowl = this;
                seed.Delete();
                Console.WriteLine(seed.GetPlant());

                m_Plant.ActivateTimer();
            }
        }

        public virtual void RemoveSeed(PlayerMobile from)
        {
            if (HasPlant && m_Plant.StateOfGrowth == StateOfGrowth.Seed)
            {
                from.AddToBackpack(m_Plant.GetSeed());

                m_Plant.Delete();
            }
        }

        public override void OnSingleClick(Mobile from)
        {
            base.OnSingleClick(from);

            if (!HasEarth && from is PlayerMobile)
            {
                PlayerMobile m = (PlayerMobile)from;

                LabelTo(from, String.Format("[{0}]", BotaniqueSystem.GetEarthName(m_EarthType, false)));
            }
        }

        /*
        public override void OnDoubleClick(Mobile from)
        {
            if (from is PlayerMobile)
            {
                if (HasEarth)
                {
                    if (HasPlant)
                    {
                        from.SendGump(new BotaniqueGump((PlayerMobile)from, this));
                    }
                    else
                    {
                        from.SendMessage("Choisissez de la graine à mettre dans votre bol.");
                        from.BeginTarget(1, false, TargetFlags.None, new TargetCallback(this.ChooseSeed_OnTarget));
                    }
                }
                else
                {
                    from.SendMessage("Choisissez de la terre à mettre dans votre bol.");
                    from.BeginTarget(1, false, TargetFlags.None, new TargetCallback(this.ChooseEarth_OnTarget));
                }
            }
        }*/

        public void ChooseEarth_OnTarget(Mobile from, object targeted)
        {
            if (Deleted || !from.CheckAlive())
                return;

            if (targeted is Earth)
            {
                m_EarthType = ((Earth)targeted).EarthType;
            }
            else
            {
                from.SendMessage("Vous devez choisir de la terre.");
            }
        }

        public virtual void AddEarth(EarthType type)
        {
            if ((!HasEarth))
                m_EarthType = type;
        }

        public virtual void Empty()
        {
            m_EarthType = EarthType.None;
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

            writer.Write((int)m_EarthType);
            writer.Write((Item)m_Plant);
		}

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    {
                        m_EarthType = (EarthType)reader.ReadInt();
                        m_Plant = (BasePlant)reader.ReadItem();
                        goto case 0;
                    }
                case 0:
                    {
                        break;
                    }
            }
        }
    }

    public class SmallBowl : BaseBowl
    {
        public override int ComputeItemID()
        {
            return (!HasEarth) ? 0x11C6 : 0x11C6;
        }

        public override double ComputeWeight()
        {
            return (!HasEarth) ? 5.0 : 15.0;
        }

        [Constructable]
        public SmallBowl() : base(0x11C6)
        {
            Name = "petit pot";
        }

        public SmallBowl(Serial serial) : base(serial)
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

            Name = "petit pot";
        }
    }

    public class LargeBowl : BaseBowl
    {
        public override int ComputeItemID()
        {
            return (!HasEarth) ? 0x11C7 : 0x11C7;
        }

        public override double ComputeWeight()
        {
            return (!HasEarth) ? 8.0 : 18.0;
        }

        [Constructable]
        public LargeBowl() : base(0x11C7)
        {
            Name = "grand pot";
        }

        public LargeBowl(Serial serial) : base(serial)
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

            Name = "grand pot";
        }
    }

    public class EarthBag : BaseBowl
    {
        public override int ComputeItemID()
        {
            return (!HasEarth) ? 0x1039 : 0x1039;
        }

        public override double ComputeWeight()
        {
            return (!HasEarth) ? 0.5 : 10.5;
        }

        public override bool CanPlant { get { return false; } }

        [Constructable]
        public EarthBag() : base(0x1039)
        {
            Name = "poche";
        }

        public EarthBag(Serial serial) : base(serial)
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

            Name = "poche";
        }
    }
}