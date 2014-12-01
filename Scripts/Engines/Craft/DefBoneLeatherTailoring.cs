using System;
using Server.Items;

namespace Server.Engines.Craft
{
    public class DefBoneLeatherTailoring : CraftSystem
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
                    m_CraftSystem = new DefBoneLeatherTailoring();

                return m_CraftSystem;
            }
        }

        public override CraftECA ECA { get { return CraftECA.ChanceMinusSixtyToFourtyFive; } }

        public override double GetChanceAtMin(CraftItem item)
        {
            return 0.5; // 50%
        }

        private DefBoneLeatherTailoring()
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
            return false;
        }

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

            #region Armure d'Os
            index = AddCraft(typeof(BoneHelm), "Armure d'Os", "Casque d'Os", 40.0, 70.0, typeof(Bone), "Os", 4, 1044463);
            AddRes(index, typeof(Leather), "Cuir", 2, 1044463);
            index = AddCraft(typeof(BoneGloves), "Armure d'Os", "Gants d'Os", 40.0, 70.0, typeof(Bone), "Os", 6, 1044463);
            AddRes(index, typeof(Leather), "Cuir", 3, 1044463);
            index = AddCraft(typeof(BoneArms), "Armure d'Os", "Brassards d'Os", 40.0, 70.0, typeof(Bone), "Os", 8, 1044463);
            AddRes(index, typeof(Leather), "Cuir", 4, 1044463);
            index = AddCraft(typeof(BoneLegs), "Armure d'Os", "Jambieres d'Os", 40.0, 70.0, typeof(Bone), "Os", 10, 1044463);
            AddRes(index, typeof(Leather), "Cuir", 5, 1044463);
            index = AddCraft(typeof(BoneChest), "Armure d'Os", "Plastron d'Os", 40.0, 70.0, typeof(Bone), "Os", 12, 1044463);
            AddRes(index, typeof(Leather), "Cuir", 6, 1044463);
            #endregion

            #region Armure de Cuir
            index = AddCraft(typeof(LeatherGorget), "Armure de Cuir", "Gorget de Cuir", 30.0, 50.0, typeof(Leather), "Cuir", 4, 1044463, true);
            index = AddCraft(typeof(LeatherCap), "Armure de Cuir", "Casque de Cuir", 30.0, 50.0, typeof(Leather), "Cuir", 2, 1044463, true);
            index = AddCraft(typeof(LeatherGloves), "Armure de Cuir", "Gants de Cuir", 30.0, 50.0, typeof(Leather), "Cuir", 3, 1044463, true);
            index = AddCraft(typeof(LeatherArms), "Armure de Cuir", "Brassards de Cuir", 30.0, 50.0, typeof(Leather), "Cuir", 4, 1044463, true);
            index = AddCraft(typeof(LeatherLegs), "Armure de Cuir", "Jambières de Cuir", 30.0, 50.0, typeof(Leather), "Cuir", 10, 1044463, true);
            index = AddCraft(typeof(LeatherChest), "Armure de Cuir", "Plastron de Cuir", 30.0, 50.0, typeof(Leather), "Cuir", 12, 1044463, true);
            index = AddCraft(typeof(LeatherShorts), "Armure de Cuir", "Jupe de Cuir", 30.0, 50.0, typeof(Leather), "Cuir", 8, 1044463, true);
            index = AddCraft(typeof(LeatherSkirt), "Armure de Cuir", "Jupette de Cuir", 30.0, 50.0, typeof(Leather), "Cuir", 6, 1044463, true);
            index = AddCraft(typeof(LeatherBustierArms), "Armure de Cuir", "Brassards Féminins", 30.0, 50.0, typeof(Leather), "Cuir", 6, 1044463, true);
            index = AddCraft(typeof(FemaleLeatherChest), "Armure de Cuir", "Cuirasse Féminine", 30.0, 50.0, typeof(Leather), "Cuir", 8, 1044463, true);
            index = AddCraft(typeof(LeatherBarbareLeggings), "Armure de Cuir", "Jambière de Cuir Barbare", 35.0, 55.0, typeof(Leather), "Cuir", 10, 1044463, true);
            index = AddCraft(typeof(LeatherBarbareTunic), "Armure de Cuir", "Plastron de Cuir Barbare", 35.0, 55.0, typeof(Leather), "Cuir", 12, 1044463, true);
            index = AddCraft(typeof(RoublardLeggings), "Armure de Cuir", "Jambières Roublardes", 35.0, 55.0, typeof(Leather), "Cuir", 10, 1044463, true);
            index = AddCraft(typeof(RoublardTunic), "Armure de Cuir", "Plastron Roublard", 35.0, 55.0, typeof(Leather), "Cuir", 12, 1044463, true);
            index = AddCraft(typeof(ElfiqueCuirTunic), "Armure de Cuir", "Plastron de Cuir Elfique", 40.0, 60.0, typeof(Leather), "Cuir", 12, 1044463, true);
            index = AddCraft(typeof(ElfiqueCuirRobe), "Armure de Cuir", "Vetement de Cuir Elfique", 40.0, 60.0, typeof(Leather), "Cuir", 14, 1044463, true);

            #endregion

            #region Armure de Cuir Clouté
            index = AddCraft(typeof(StuddedGorget), "Armure de Cuir Clouté", "Gorget de Cuir Clouté", 35.0, 55.0, typeof(Leather), "Cuir", 6, 1044463, true);
            index = AddCraft(typeof(StuddedGloves), "Armure de Cuir Clouté", "Gants de Cuir Clouté", 35.0, 55.0, typeof(Leather), "Cuir", 8, 1044463, true);
            index = AddCraft(typeof(StuddedArms), "Armure de Cuir Clouté", "Brassards de Cuir Clouté", 35.0, 55.0, typeof(Leather), "Cuir", 10, 1044463, true);
            index = AddCraft(typeof(StuddedLegs), "Armure de Cuir Clouté", "Jambières de Cuir Clouté", 35.0, 55.0, typeof(Leather), "Cuir", 12, 1044463, true);
            index = AddCraft(typeof(StuddedChest), "Armure de Cuir Clouté", "Plastron de Cuir Clouté", 35.0, 55.0, typeof(Leather), "Cuir", 14, 1044463, true);
            index = AddCraft(typeof(StuddedBustierArms), "Armure de Cuir Clouté", "Brassards Féminins", 35.0, 55.0, typeof(Leather), "Cuir", 8, 1044463, true);
            index = AddCraft(typeof(FemaleStuddedChest), "Armure de Cuir Clouté", "Cuirasse Féminine", 35.0, 55.0, typeof(Leather), "Cuir", 10, 1044463, true);
            index = AddCraft(typeof(ElfeHelm), "Armure de Cuir Clouté", "Casque de Feuilles", 40.0, 60.0, typeof(Leather), "Cuir", 3, 1044463, true);
            AddRes(index, typeof(Log), "Bûche", 2, 1044351);
            index = AddCraft(typeof(ElfeGorget), "Armure de Cuir Clouté", "Gorget de Feuilles", 40.0, 60.0, typeof(Leather), "Cuir", 3, 1044463, true);
            AddRes(index, typeof(Log), "Bûche", 2, 1044351);
            index = AddCraft(typeof(ElfeArms), "Armure de Cuir Clouté", "Brassards de Feuilles", 40.0, 60.0, typeof(Leather), "Cuir", 3, 1044463, true);
            AddRes(index, typeof(Log), "Bûche", 2, 1044351);
            index = AddCraft(typeof(ElfeLeggings), "Armure de Cuir Clouté", "Jambières de Feuilles", 40.0, 60.0, typeof(Leather), "Cuir", 3, 1044463, true);
            AddRes(index, typeof(Log), "Bûche", 2, 1044351);
            index = AddCraft(typeof(ElfeTunic), "Armure de Cuir Clouté", "Tunique de Feuilles", 40.0, 60.0, typeof(Leather), "Cuir", 3, 1044463, true);
            AddRes(index, typeof(Log), "Bûche", 2, 1044351);
            index = AddCraft(typeof(StuddedBarbareGreaves), "Armure de Cuir Clouté", "Brassards Clouté Barbare", 45.0, 65.0, typeof(Leather), "Cuir", 10, 1044463, true);
            index = AddCraft(typeof(StuddedBarbareGorget), "Armure de Cuir Clouté", "Gorget Clouté Barbare", 45.0, 65.0, typeof(Leather), "Cuir", 6, 1044463, true);
            index = AddCraft(typeof(StuddedBarbareLeggings), "Armure de Cuir Clouté", "Jambières Clouté Barbare", 45.0, 65.0, typeof(Leather), "Cuir", 12, 1044463, true);
            index = AddCraft(typeof(StuddedBarbareTunic), "Armure de Cuir Clouté", "Tunique Clouté Barbare", 45.0, 65.0, typeof(Leather), "Cuir", 14, 1044463, true);
            #endregion

            #region Chaussures
            index = AddCraft(typeof(Sandals), "Chaussures & Bottes", "Sandales", 10.0, 20.0, typeof(Leather), "Cuir", 4, 1044463, true);
            index = AddCraft(typeof(Geta), "Chaussures & Bottes", "Geta", 20.0, 30.0, typeof(Leather), "Cuir", 5, 1044463, true);

            index = AddCraft(typeof(Shoes), "Chaussures & Bottes", "Souliers", 30.0, 50.0, typeof(Leather), "Cuir", 6, 1044463, true);
            index = AddCraft(typeof(SouliersFourrure), "Chaussures & Bottes", "Souliers Fourrure", 40.0, 60.0, typeof(Leather), "Cuir", 8, 1044463, true);
            index = AddCraft(typeof(SouliersBoucles), "Chaussures & Bottes", "Souliers Bouclés", 50.0, 70.0, typeof(Leather), "Cuir", 7, 1044463, true);

            index = AddCraft(typeof(BottesPetites), "Chaussures & Bottes", "Petites Bottes", 30.0, 50.0, typeof(Leather), "Cuir", 6, 1044463, true);
            index = AddCraft(typeof(Boots), "Chaussures & Bottes", "Bottes", 40.0, 60.0, typeof(Leather), "Cuir", 8, 1044463, true);
            index = AddCraft(typeof(ThighBoots), "Chaussures & Bottes", "Bottes Longues", 50.0, 70.0, typeof(Leather), "Cuir", 14, 1044463, true);
            index = AddCraft(typeof(BottesBoucles), "Chaussures & Bottes", "Bottes Bouclés", 60.0, 80.0, typeof(Leather), "Cuir", 8, 1044463, true);
            index = AddCraft(typeof(Bottes), "Chaussures & Bottes", "Bottes Simples", 60.0, 80.0, typeof(Leather), "Cuir", 8, 1044463, true);
            index = AddCraft(typeof(BottesVoyage), "Chaussures & Bottes", "Bottes de Voyage", 60.0, 80.0, typeof(Leather), "Cuir", 8, 1044463, true);
            index = AddCraft(typeof(BottesLourdes), "Chaussures & Bottes", "Bottes Lourdes", 70.0, 90.0, typeof(Leather), "Cuir", 12, 1044463, true);
            index = AddCraft(typeof(BottesNoble), "Chaussures & Bottes", "Bottes Nobles", 70.0, 90.0, typeof(Leather), "Cuir", 12, 1044463, true);
            index = AddCraft(typeof(BottesFourrure), "Chaussures & Bottes", "Bottes Fourrure", 80.0, 100.0, typeof(Leather), "Cuir", 10, 1044463, true);
            index = AddCraft(typeof(BottesSombres), "Chaussures & Bottes", "Bottes Sombres", 90.0, 120.0, typeof(Leather), "Cuir", 16, 1044463, true);
            #endregion

            index = AddCraft(typeof(CeinturePauvre), "Accessoires", "Ceinture Pauvre", 0.0, 20.0, typeof(Leather), "Cuir", 4, 1044463, true);
            index = AddCraft(typeof(Bourse), "Accessoires", "Bourse", 10.0, 30.0, typeof(Leather), "Cuir", 2, 1044463, true);
            index = AddCraft(typeof(Ceinture), "Accessoires", "Ceinture Simple", 20.0, 40.0, typeof(Leather), "Cuir", 3, 1044463, true);
            index = AddCraft(typeof(CeintureBourse), "Accessoires", "Ceinture Bourse", 20.0, 40.0, typeof(Leather), "Cuir", 4, 1044463, true);
            index = AddCraft(typeof(CeintureBoucle), "Accessoires", "Ceinture Bouclé", 30.0, 50.0, typeof(Leather), "Cuir", 4, 1044463, true);
            index = AddCraft(typeof(CeintureCuir), "Accessoires", "Ceinture de Cuir", 40.0, 70.0, typeof(Leather), "Cuir", 5, 1044463, true);
            index = AddCraft(typeof(CeinturePendante), "Accessoires", "Ceinture Pendante", 50.0, 80.0, typeof(Leather), "Cuir", 6, 1044463, true);
            index = AddCraft(typeof(CeintureNordique), "Accessoires", "Ceinture Nordique", 60.0, 90.0, typeof(Leather), "Cuir", 4, 1044463, true);
            index = AddCraft(typeof(CeintureLongue), "Accessoires", "Ceinture Longue", 70.0, 100.0, typeof(Leather), "Cuir", 8, 1044463, true);

            index = AddCraft(typeof(Carquois), "Accessoires", "Carquois", 30.0, 60.0, typeof(Leather), "Cuir", 8, 1044463, true);
            index = AddCraft(typeof(Fourreau), "Accessoires", "Fourreau", 30.0, 60.0, typeof(Leather), "Cuir", 8, 1044463, true);
            index = AddCraft(typeof(FourreauDos), "Accessoires", "Fourreau de Dos", 30.0, 60.0, typeof(Leather), "Cuir", 8, 1044463, true);
            index = AddCraft(typeof(FourreauDague), "Accessoires", "Fourreau à Dague", 40.0, 70.0, typeof(Leather), "Cuir", 5, 1044463, true);
            index = AddCraft(typeof(FourreauDecouvert), "Accessoires", "Fourreau à Découvert", 50.0, 80.0, typeof(Leather), "Cuir", 5, 1044463, true);
            index = AddCraft(typeof(FourreauRapiere), "Accessoires", "Fourreau d'Estoc", 60.0, 90.0, typeof(Leather), "Cuir", 5, 1044463, true);
            index = AddCraft(typeof(FourreauEpee), "Accessoires", "Fourreau à Épées", 60.0, 90.0, typeof(Leather), "Cuir", 5, 1044463, true);
            index = AddCraft(typeof(FourreauSabre), "Accessoires", "Fourreau à Sabres", 70.0, 100.0, typeof(Leather), "Cuir", 5, 1044463, true);

            index = AddCraft(typeof(SacocheCeinture), "Accessoires", "Ceinture Double", 30.0, 50.0, typeof(Leather), "Cuir", 6, 1044463, true);
            index = AddCraft(typeof(SacocheHerboriste), "Accessoires", "Sacoche d'Herboriste", 40.0, 60.0, typeof(Leather), "Cuir", 5, 1044463, true);
            index = AddCraft(typeof(SacocheRoublard), "Accessoires", "Sacoche de Roublard", 50.0, 70.0, typeof(Leather), "Cuir", 6, 1044463, true);
            index = AddCraft(typeof(SacocheAventure), "Accessoires", "Sacoche d'Aventurier", 60.0, 80.0, typeof(Leather), "Cuir", 6, 1044463, true);

            index = AddCraft(typeof(Pardessus), "Accessoires", "Pardessus", 20.0, 40.0, typeof(Leather), "Cuir", 6, 1044463, true);
            index = AddCraft(typeof(PardessusBarbare), "Accessoires", "Pardessus Barbare", 40.0, 60.0, typeof(Leather), "Cuir", 6, 1044463, true);
            index = AddCraft(typeof(EpauliereBarbare), "Accessoires", "Épaulière Barbare", 60.0, 80.0, typeof(Leather), "Cuir", 8, 1044463, true);

            // Set the overridable material
            SetSubRes(typeof(Bone), "Os");

            // Add every material you want the player to be able to choose from
            // This will override the overridable material
            AddSubRes(typeof(Bone), "Os", CraftResources.GetSkill(CraftResource.RegularBones), 1049311);
            AddSubRes(typeof(GobelinBone), "Os Gobelin", CraftResources.GetSkill( CraftResource.GobelinBones ), 1049311);
            AddSubRes(typeof(ReptilienBone), "Os Reptilien", CraftResources.GetSkill( CraftResource.ReptilienBones), 1049311);
            AddSubRes(typeof(NordiqueBone), "Os Nordique", CraftResources.GetSkill( CraftResource.NordiqueBones), 1049311);
            AddSubRes(typeof(DesertiqueBone), "Os Désertique", CraftResources.GetSkill( CraftResource.DesertiqueBones), 1049311);
            AddSubRes(typeof(MaritimeBone), "Os Maritime", CraftResources.GetSkill( CraftResource.MaritimeBones), 1049311);
            AddSubRes(typeof(VolcaniqueBone), "Os Volcanique", CraftResources.GetSkill( CraftResource.VolcaniqueBones), 1049311);
            AddSubRes(typeof(GeantBone), "Os Géant", CraftResources.GetSkill( CraftResource.GeantBones), 1049311);
            AddSubRes(typeof(MinotaureBone), "Os Minotaure", CraftResources.GetSkill( CraftResource.MinotaureBones), 1049311);
            AddSubRes(typeof(OphidienBone), "Os Ophidien", CraftResources.GetSkill( CraftResource.OphidienBones), 1049311);
            AddSubRes(typeof(ArachnideBone), "Os Arachnide", CraftResources.GetSkill( CraftResource.ArachnideBones), 1049311);
            AddSubRes(typeof(MagiqueBone), "Os Magique", CraftResources.GetSkill( CraftResource.MagiqueBones), 1049311);
            AddSubRes(typeof(AncienBone), "Os Ancien", CraftResources.GetSkill( CraftResource.AncienBones), 1049311);
            AddSubRes(typeof(DemonBone), "Os Demoniaque", CraftResources.GetSkill( CraftResource.DemonBones), 1049311);
            AddSubRes(typeof(DragonBone), "Os Dragonique", CraftResources.GetSkill( CraftResource.DragonBones), 1049311);

            // Set the overridable material 2
            SetSubRes2(typeof(Leather), "Cuir");

            // Add every material you want the player to be able to choose from
            // This will override the overridable material
            AddSubRes2(typeof(Leather), "Cuir", CraftResources.GetSkill( CraftResource.RegularLeather), 1049311);
            AddSubRes2(typeof(ReptilienLeather), "Cuir Reptilien", CraftResources.GetSkill( CraftResource.ReptilienLeather), 1049311);
            AddSubRes2(typeof(NordiqueLeather), "Cuir Nordique", CraftResources.GetSkill( CraftResource.NordiqueLeather), 1049311);
            AddSubRes2(typeof(DesertiqueLeather), "Cuir Désertique", CraftResources.GetSkill( CraftResource.DesertiqueLeather), 1049311);
            AddSubRes2(typeof(MaritimeLeather), "Cuir Maritime", CraftResources.GetSkill( CraftResource.MaritimeLeather), 1049311);
            AddSubRes2(typeof(VolcaniqueLeather), "Cuir Volcanique", CraftResources.GetSkill( CraftResource.VolcaniqueLeather), 1049311);
            AddSubRes2(typeof(GeantLeather), "Cuir Géant", CraftResources.GetSkill( CraftResource.GeantLeather), 1049311);
            AddSubRes2(typeof(MinotaureLeather), "Cuir Minotaure", CraftResources.GetSkill( CraftResource.MinotaurLeather), 1049311);
            AddSubRes2(typeof(OphidienLeather), "Cuir Ophidien", CraftResources.GetSkill( CraftResource.OphidienLeather), 1049311);
            AddSubRes2(typeof(ArachnideLeather), "Cuir Arachnide", CraftResources.GetSkill( CraftResource.ArachnideLeather), 1049311);
            AddSubRes2(typeof(MagiqueLeather), "Cuir Magique", CraftResources.GetSkill( CraftResource.MagiqueLeather), 1049311);
            AddSubRes2(typeof(AncienLeather), "Cuir Ancien", CraftResources.GetSkill( CraftResource.AncienLeather), 1049311);
            AddSubRes2(typeof(DemoniaqueLeather), "Cuir Demoniaque", CraftResources.GetSkill( CraftResource.DemoniaqueLeather), 1049311);
            AddSubRes2(typeof(DragoniqueLeather), "Cuir Dragonique", CraftResources.GetSkill( CraftResource.DragoniqueLeather), 1049311);
            AddSubRes2(typeof(LupusLeather), "Cuir Lupus", CraftResources.GetSkill( CraftResource.LupusLeather), 1049311);

            MarkOption = true;
            Repair = Core.AOS;
            CanEnhance = Core.AOS;
        }
    }
}