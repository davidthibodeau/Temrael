using System;
using System.Collections;
using Server.Network;
using Server.Gumps;
using Server.Items;

namespace Server.Mobiles
{
    public class PlantSpawnerGump : Gump
    {
        private PlantSpawner m_Spawner;

        public PlantSpawnerGump(PlantSpawner spawner)
            : base(50, 50)
        {
            m_Spawner = spawner;

            AddPage(0);

            AddBackground(0, 0, 260, 111, 5054);

            AddLabel(95, 1, 0, "Plants List");

            //AddButton(5, 87, 0xFB1, 0xFB3, 0, GumpButtonType.Reply, 0);
            //AddLabel(38, 87, 0x384, "Cancel");

            AddButton(5, 65, 0xFB7, 0xFB9, 1, GumpButtonType.Reply, 0);
            AddLabel(38, 65, 0x384, "Okay");

            AddButton(110, 65, 0xFB4, 0xFB6, 2, GumpButtonType.Reply, 0);
            AddLabel(143, 65, 0x384, "Bring to Home");

            AddButton(110, 87, 0xFA8, 0xFAA, 3, GumpButtonType.Reply, 0);
            AddLabel(143, 87, 0x384, "Total Respawn");

            AddButton(5, 20, 0xFA5, 0xFA7, 4, GumpButtonType.Reply, 0);
            AddButton(38, 20, 0xFA2, 0xFA4, 5, GumpButtonType.Reply, 0);

            AddImageTiled(71, 20, 159, 23, 0xA40);
            AddImageTiled(72, 21, 157, 21, 0xBBC);

            string plantName = m_Spawner.PlantName.ToString();
            int count = m_Spawner.CountPlants();

            //if (m_Spawner.PlantName != PlantType.None)
            //{
                AddLabel(232, 20, 0, count.ToString());
                AddLabel(75, 21, 0, plantName);
            //}
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            if (m_Spawner.Deleted)
                return;

            switch (info.ButtonID)
            {
                case 0: // Closed
                    {
                        break;
                    }
                case 1: // Okay
                    {
                        break;
                    }
                case 2: // Bring everything home
                    {
                        m_Spawner.BringToHome();

                        break;
                    }
                case 3: // Complete respawn
                    {
                        m_Spawner.Respawn();

                        break;
                    }
                case 4: // Spawn plant
                    {
                        m_Spawner.Spawn();

                        break;
                    }
                case 5: // Remove plants
                    {
                        m_Spawner.RemovePlants();

                        break;
                    }
            }
        }
    }
}