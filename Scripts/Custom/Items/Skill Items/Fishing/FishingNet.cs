using System;
using Server.Targeting;
using Server.Items;
using Server.Engines.Harvest;

namespace Server.Items
{
    public class FishingNet : Item, IFishingPole
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
		public FishingNet() : base( 0xDCA )
        {
            Name = "filet de pêche";
			Weight = 4.0;
		}

		public override void OnDoubleClick( Mobile from )
		{
            if (from.Skills[SkillName.Peche].Value >= 40.0)
                Fishing.System.BeginHarvesting(from, this);
            else
                from.SendMessage("Vous n'êtes pas assez compétent pour utiliser cet objet.");
		}

		public FishingNet( Serial serial ) : base( serial )
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