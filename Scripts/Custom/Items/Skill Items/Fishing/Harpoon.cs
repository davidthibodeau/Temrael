using System;
using Server.Targeting;
using Server.Items;
using Server.Engines.Harvest;

namespace Server.Items
{
	[FlipableAttribute( 0x1403, 0x1402 )]
    public class Harpoon : Item, IFishingPole
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
		public Harpoon() : base( 0x1403 )
		{
            Name = "harpon";
			Layer = Layer.OneHanded;
			Weight = 8.0;
            Hue = 1103;
		}

		public override void OnDoubleClick( Mobile from )
        {
            if (from.Skills[SkillName.Peche].Value >= 90.0)
                Fishing.System.BeginHarvesting(from, this);
            else
                from.SendMessage("Vous n'êtes pas assez compétent pour utiliser cet objet.");
		}

		public Harpoon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

            writer.Write((int)m_Bait);
            writer.Write(m_Charge);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    {
                        m_Bait = (Bait)reader.ReadInt();
                        m_Charge = reader.ReadInt();
                        break;
                    }
            }
		}
	}
}