using System;

namespace Server.Engines.Craft
{
    public class CraftAptitude
	{
        private Aptitude m_AptitudeToMake;
		private int m_Required;

        public CraftAptitude(Aptitude aptitudeToMake, int required)
		{
            m_AptitudeToMake = aptitudeToMake;
            m_Required = required;
		}

        public Aptitude AptitudeToMake
		{
            get { return m_AptitudeToMake; }
		}

        public int Required
		{
            get { return m_Required; }
		}
	}
}