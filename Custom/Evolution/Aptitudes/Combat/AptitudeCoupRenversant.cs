using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeCoupRenversant
    {
        private static string m_name = "Coup Renversant";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.CoupRenversant];
        private static int m_tooltip = 3006307;
        private static string m_description = "Augmente les chances de faire tomber un adversaire de sa monture.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                 "+1% de chance",
                 "+2% de chance", 
                 "+3% de chance", 
                 "+4% de chance", 
                 "+5% de chance", 
                 "+6% de chance", 
                 "+7% de chance", 
                 "+8% de chance", 
                 "+9% de chance", 
                 "+10% de chance", 
                 "+11% de chance", 
                 "+12% de chance"
            };

        public static AptitudeInfo AptitudeInfo = new AptitudeInfo(
                        m_name,
                        m_entry,
                        m_tooltip,
                        m_description,
                        m_descriptionNiveau,
                        m_note,
                        m_image
                    );
    }
}
