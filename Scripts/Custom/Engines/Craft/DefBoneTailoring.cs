using System;
using Server.Items;

namespace Server.Engines.Craft
{
    public class DefBoneTailoring : CraftSystem
    {
        public override SkillName MainSkill
        {
            get { return SkillName.Couture; }
        }

        public override int GumpTitleNumber
        {
            get { return 1044005; } // <CENTER>TAILORING MENU</CENTER>
        }

        private static CraftSystem m_CraftSystem;

        public static CraftSystem CraftSystem
        {
            get
            {
                if (m_CraftSystem == null)
                    m_CraftSystem = new DefBoneTailoring();

                return m_CraftSystem;
            }
        }

        public override CraftECA ECA { get { return CraftECA.ChanceMinusSixtyToFourtyFive; } }

        public override double GetChanceAtMin(CraftItem item)
        {
            return 0.5; // 50%
        }

        private DefBoneTailoring()
            : base(1, 1, 1.25)// base( 1, 1, 4.5 )
        {
        }

        public override int CanCraft(Mobile from, BaseTool tool, Type itemType)
        {
            if (tool == null || tool.Deleted || tool.UsesRemaining < 0)
                return 1044038; // You have worn out your tool!
            else if (!BaseTool.CheckAccessible(tool, from))
                return 1044263; // The tool must be on your person to use.

            return 0;
        }

        public static bool IsNonColorable(Type type)
        {
            for (int i = 0; i < m_TailorNonColorables.Length; ++i)
            {
                if (m_TailorNonColorables[i] == type)
                {
                    return true;
                }
            }

            return false;
        }

        private static Type[] m_TailorNonColorables = new Type[]
			{
				typeof( OrcHelm )
			};

        private static Type[] m_TailorColorables = new Type[]
			{
				typeof( GozaMatEastDeed ), typeof( GozaMatSouthDeed ),
				typeof( SquareGozaMatEastDeed ), typeof( SquareGozaMatSouthDeed ),
				typeof( BrocadeGozaMatEastDeed ), typeof( BrocadeGozaMatSouthDeed ),
				typeof( BrocadeSquareGozaMatEastDeed ), typeof( BrocadeSquareGozaMatSouthDeed )
			};

        public override bool RetainsColorFrom(CraftItem item, Type type)
        {
            if (type != typeof(Bone) && type != typeof(Cloth))
                return false;

            type = item.ItemType;

            bool contains = false;

            for (int i = 0; !contains && i < m_TailorColorables.Length; ++i)
                contains = (m_TailorColorables[i] == type);

            return contains;
        }

        public override void PlayCraftEffect(Mobile from)
        {
            from.PlaySound(0x248);
        }

        public override int PlayEndingEffect(Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item)
        {
            if (toolBroken)
                from.SendLocalizedMessage(1044038); // You have worn out your tool

            if (failed)
            {
                if (lostMaterial)
                    return 1044043; // You failed to create the item, and some of your materials are lost.
                else
                    return 1044157; // You failed to create the item, but no materials were lost.
            }
            else
            {
                if (quality == 0)
                    return 502785; // You were barely able to make this item.  It's quality is below average.
                else if (makersMark && quality == 2)
                    return 1044156; // You create an exceptional quality item and affix your maker's mark.
                else if (quality == 2)
                    return 1044155; // You create an exceptional quality item.
                else
                    return 1044154; // You create the item.
            }
        }

        public override void InitCraftList()
        {
            int index = -1;

            #region Bone Armor
            index = AddCraft(typeof(BoneHelm), "Armure d'Os", "Casque d'Os", 50.0, 70.0, typeof(Bone), "Os", 4, 1044463);
            AddRes(index, typeof(Leather), "Cuir", 2, 1044463);

            index = AddCraft(typeof(BoneGloves), "Armure d'Os", "Gants d'Os", 50.0, 70.0, typeof(Bone), "Os", 6, 1044463);
            AddRes(index, typeof(Leather), "Cuir", 3, 1044463);

            index = AddCraft(typeof(BoneArms), "Armure d'Os", "Brassards d'Os", 50.0, 70.0, typeof(Bone), "Os", 8, 1044463);
            AddRes(index, typeof(Leather), "Cuir", 4, 1044463);

            index = AddCraft(typeof(BoneLegs), "Armure d'Os", "Jambieres d'Os", 50.0, 70.0, typeof(Bone), "Os", 10, 1044463);
            AddRes(index, typeof(Leather), "Cuir", 5, 1044463);

            index = AddCraft(typeof(BoneChest), "Armure d'Os", "Plastron d'Os", 50.0, 70.0, typeof(Bone), "Os", 12, 1044463);
            AddRes(index, typeof(Leather), "Cuir", 6, 1044463);
            #endregion

            // Set the overridable material
            SetSubRes(typeof(Bone), "Os");

            // Add every material you want the player to be able to choose from
            // This will override the overridable material
            AddSubRes(typeof(Bone), "Os", 00.0, 1049311);
            AddSubRes(typeof(GobelinBone), "Os Gobelin", 20.0, 1049311);
            AddSubRes(typeof(ReptilienBone), "Os Reptilien", 20.0, 1049311);
            AddSubRes(typeof(NordiqueBone), "Os Nordique", 20.0, 1049311);
            AddSubRes(typeof(DesertiqueBone), "Os Désertique", 20.0, 1049311);
            AddSubRes(typeof(MaritimeBone), "Os Maritime", 40.0, 1049311);
            AddSubRes(typeof(VolcaniqueBone), "Os Volcanique", 40.0, 1049311);
            AddSubRes(typeof(GeantBone), "Os Géant", 40.0, 1049311);
            AddSubRes(typeof(MinotaureBone), "Os Minotaure", 60.0, 1049311);
            AddSubRes(typeof(OphidienBone), "Os Ophidien", 60.0, 1049311);
            AddSubRes(typeof(ArachnideBone), "Os Arachnide", 60.0, 1049311);
            AddSubRes(typeof(MagiqueBone), "Os Magique", 80.0, 1049311);
            AddSubRes(typeof(AncienBone), "Os Ancien", 80.0, 1049311);
            AddSubRes(typeof(DemonBone), "Os Demoniaque", 80.0, 1049311);
            AddSubRes(typeof(DragonBone), "Os Dragonique", 100.0, 1049311);
            AddSubRes(typeof(BalronBone), "Os Balron", 100.0, 1049311);
            AddSubRes(typeof(WyrmBone), "Os Wyrmique", 100.0, 1049311);

            MarkOption = true;
            Repair = Core.AOS;
            CanEnhance = Core.AOS;
        }
    }
}