using System;
using Server.Targeting;
using Server.Items;
using Server.Engines.Harvest;
using Server.ContextMenus;
using System.Collections.Generic;

namespace Server.Items
{
    public class LargeStrongFishingPole : Item, IFishingPole
    {
        private Bait m_Bait;
        private int m_Charge;

        [CommandProperty(AccessLevel.Batisseur)]
        public Bait Bait
        {
            get { return m_Bait; }
            set { m_Bait = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Charge
        {
            get { return m_Charge; }
            set { m_Charge = value; }
        }

		[Constructable]
		public LargeStrongFishingPole() : base( 0x0DC0 )
		{
            Name = "grande canne à pêche renforcée";
			Layer = Layer.OneHanded;
            Hue = 1103;
			Weight = 8.0;
        }

        public override void OnSingleClick(Mobile from)
        {
            base.OnSingleClick(from);

            if (m_Bait != Bait.Aucun && m_Charge > 0)
            {
                LabelTo(from, String.Format("[{0} / {1} charge{2}]", BaseBait.m_Material[(int)m_Bait], m_Charge, m_Charge > 1 ? "s" : ""));
            }
        }

		public override void OnDoubleClick( Mobile from )
        {
            if (from.Skills[SkillName.Cuisine].Value >= 75.0)
                Fishing.System.BeginHarvesting(from, this);
            else
                from.SendMessage("Vous n'êtes pas assez compétent pour utiliser cet objet.");
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            if (from.Alive && m_Bait != Bait.Aucun && m_Charge > 0)
            {
                list.Add(new RemoveBaitEntry(from, this));
            }

            base.GetContextMenuEntries(from, list);
        }

		public LargeStrongFishingPole( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 2 ); // version

            writer.Write((int)m_Bait);
            writer.Write(m_Charge);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

            switch (version)
            {
                case 2:
                    {
                        m_Bait = (Bait)reader.ReadInt();
                        m_Charge = reader.ReadInt();
                        break;
                    }
                case 1:
                    {
                        reader.ReadItem();
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