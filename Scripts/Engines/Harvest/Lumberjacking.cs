using System;
using Server;
using Server.Items;
using System.Collections;

namespace Server.Engines.Harvest
{
	public class Lumberjacking : HarvestSystem
	{
        private static Lumberjacking m_System;

        public static Hashtable erableList  = new Hashtable();
        public static Hashtable cheneList   = new Hashtable();
        public static Hashtable pinList     = new Hashtable();
        public static Hashtable cedreList   = new Hashtable();
        public static Hashtable cypresList  = new Hashtable();
        public static Hashtable ebeneList   = new Hashtable();
        public static Hashtable acajouList  = new Hashtable();
        public static Hashtable sauleList   = new Hashtable();


        public static Lumberjacking System
        {
            get
            {
                if (m_System == null)
                    m_System = new Lumberjacking();

                return m_System;
            }
        }

        private HarvestDefinition m_Definition;

        public HarvestDefinition Definition
        {
            get { return m_Definition; }
        }

        private Lumberjacking()
        {
            HarvestResource[] res;
            HarvestVein[] veins;

            #region Lumberjacking
            HarvestDefinition lumber = new HarvestDefinition();

            // Resource banks are every 4x3 tiles
            lumber.BankWidth = 1;
            lumber.BankHeight = 1;

            // Every bank holds from 20 to 45 logs
            lumber.MinTotal = 15;
            lumber.MaxTotal = 30;

            // A resource bank will respawn its content every 20 to 30 minutes
            lumber.MinRespawn = TimeSpan.FromMinutes(15.0);
            lumber.MaxRespawn = TimeSpan.FromMinutes(25.0);

            // Skill checking is done on the Lumberjacking skill
            lumber.Skill = SkillName.Hache;

            // Set the list of harvestable tiles
            lumber.Tiles = m_TreeTiles;

            // Players must be within 2 tiles to harvest
            lumber.MaxRange = 1;

            // Ten logs per harvest action
            //lumber.MinConsumedPerHarvest = 1;
            //lumber.MaxConsumedPerHarvest = 2;

            // The chopping effect
            lumber.EffectActions = new int[] { 13 };
            lumber.EffectSounds = new int[] { 0x13E };
            lumber.EffectCounts = new int[] { 3 };
            lumber.EffectDelay = TimeSpan.FromSeconds(1.4);
            lumber.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            lumber.NoResourcesMessage = 500493; // There's not enough wood here to harvest.
            lumber.FailMessage = 500495; // You hack at the tree for a while, but fail to produce any useable wood.
            lumber.OutOfRangeMessage = 500446; // That is too far away.
            lumber.PackFullMessage = 500497; // You can't place any wood into your backpack!
            lumber.ToolBrokeMessage = 500499; // You broke your axe.

            res = HarvestZone.Resources;

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[15], null )
				};

            lumber.Resources = res;
            lumber.Veins = veins;

            m_Definition = lumber;
            Definitions.Add(lumber);
            #endregion
        }

        public override bool CheckHarvest(Mobile from, Item tool)
        {
            if (!base.CheckHarvest(from, tool))
                return false;

            if (tool.Parent != from)
            {
                from.SendLocalizedMessage(500487); // The axe must be equipped for any serious wood chopping.
                return false;
            }

            return true;
        }

        public override bool CheckHarvest(Mobile from, Item tool, HarvestDefinition def, object toHarvest)
        {
            if (!base.CheckHarvest(from, tool, def, toHarvest))
                return false;

            if (tool.Parent != from)
            {
                from.SendLocalizedMessage(500487); // The axe must be equipped for any serious wood chopping.
                return false;
            }

            return true;
        }

        public override void OnBadHarvestTarget(Mobile from, Item tool, object toHarvest)
        {
            from.SendLocalizedMessage(500489); // You can't use an axe on that.
        }

        public static void Initialize()
        {
            Array.Sort(m_TreeTiles);
            cheneList.Add("GreenAcresTest", new Region("GreenAcresTest", Map.Internal, 100, new Rectangle2D(new Point2D(4030, 42), new Point2D(4035, 35))));
        }

		#region Tile lists
        // Ici, mettre les ItemID de toutes les sortes d'arbres.
        public static int[] m_TreeTiles = new int[]
			{
                0x4D41, 0x4D42, 0x4D43, 0x4D44, 0x4D57, 0x4D58, 0x4D59, 0x4D5A,
                0x4D5B, 0x4D6E, 0x4D6F, 0x4D70, 0x4D71, 0x4D72, 0x4D84, 0x4D85,
                0x4D86,

                0x4CD6, 0x4CD8,

                0x4CD0, 0x4CD3,
                
                0x4CF8, 0x4CFB, 0x4CFE, 0x4D01,

                0x4CCA, 0x4CCB, 0x4CCC,
                
                0x4CDA, 0x4CDD, 0x4CCD,

                0x4CE0, 0x4CE3,

                0x4CE6,

                0x71C2, 0x71CC, 0x71CD, 0x71CE, 0x71CF,
                0x71C0, 0x71C6, 0x71C4, 0x575C, 0x776C, 0x71C8,
                0x71BE, 0x71C0, 0x71D4, 0x71D5, 0x71D6, 0x71D7,
                0x176C,

                0x7AA2 // Gros arbre orange-vert.
			};
		#endregion
	}
}