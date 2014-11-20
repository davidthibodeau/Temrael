using System;

namespace Server.Engines.Harvest
{
	public class HarvestBank
	{
		private int m_Current;
		private int m_Maximum;
		private DateTime m_NextRespawn;
        private HarvestVein m_Vein;
        private HarvestVein[] m_PossibleVeins;
            

		public int Current
		{
			get
			{
				CheckRespawn();
				return m_Current;
			}
		}

		public HarvestVein Vein
		{
			get
			{
				CheckRespawn();
				return m_Vein;
			}
			set
			{
				m_Vein = value;
			}
		}

        public HarvestVein[] PossibleVeins
        {
            get
            {
                CheckRespawn();
                return m_PossibleVeins;
            }
        }

		public void CheckRespawn()
		{
			if ( m_Current == m_Maximum || DateTime.Now < m_NextRespawn)
				return;

			m_Current = m_Maximum;
            m_Vein = ResetVein();
		}

		public void Consume( HarvestDefinition def, int amount, Point3D loc )
		{
			CheckRespawn();

			if ( m_Current == m_Maximum )
			{
				double min = def.MinRespawn.TotalMinutes;
				double max = def.MaxRespawn.TotalMinutes;
                double rnd = Utility.RandomDouble();

				m_Current = m_Maximum - amount;
				m_NextRespawn = DateTime.Now + TimeSpan.FromMinutes( min + (rnd * (max - min)) );
			}
			else
			{
				m_Current -= amount;
			}

			if ( m_Current < 0 )
				m_Current = 0;
		}

		public HarvestBank( HarvestDefinition def, HarvestVein[] vein )
		{
			m_Maximum = Utility.RandomMinMax( def.MinTotal, def.MaxTotal );
            m_Current = m_Maximum;
            m_PossibleVeins = vein;
			m_Vein = ResetVein();
		}

        public HarvestVein ResetVein()
        {
            double randomValue = Utility.RandomDouble() * 100;

            HarvestVein[] veins = m_PossibleVeins;

            for (int i = veins.Length - 1; i >= 0; i--)
            {
                if (randomValue <= veins[i].VeinChance)
                {
                    return veins[i];
                }

                randomValue -= veins[i].VeinChance;
            }
            return veins[0];
        }
    }
}