using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Misc.Balancing
{
    #region POUR LES TESTS RELATIF AUX ARMES. MÊMES COMPÉTENCES.
    public class MobilePlaqueEpeeLente : TestMobile
    {
        public MobilePlaqueEpeeLente()
        {
            RawStr = 100;
            RawDex = 100;
            RawInt = 25;

            SetSkill(SkillName.Epee, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);
            SetSkill(SkillName.CoupCritique, 100.0);
            SetSkill(SkillName.Concentration, 100.0);
            SetSkill(SkillName.Penetration, 100.0);
            SetSkill(SkillName.Parer, 100.0);

            ChooseArmor(ArmorClass.Plaque, CraftResource.Argent, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Granlame();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobilePlaqueEpeeLente(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    public class MobilePlaqueEpeeRapide : TestMobile
    {
        public MobilePlaqueEpeeRapide()
        {
            RawStr = 100;
            RawDex = 100;
            RawInt = 25;

            SetSkill(SkillName.Epee, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);
            SetSkill(SkillName.CoupCritique, 100.0);
            SetSkill(SkillName.Concentration, 100.0);
            SetSkill(SkillName.Penetration, 100.0);
            SetSkill(SkillName.Parer, 100.0);

            ChooseArmor(ArmorClass.Plaque, CraftResource.Argent, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Couliere();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobilePlaqueEpeeRapide(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    public class MobilePlaqueEpeeLenteBouclier : TestMobile
    {
        public MobilePlaqueEpeeLenteBouclier()
        {
            RawStr = 80;
            RawDex = 85;
            RawInt = 60;

            SetSkill(SkillName.Epee, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);
            SetSkill(SkillName.CoupCritique, 100.0);
            SetSkill(SkillName.Concentration, 100.0);
            SetSkill(SkillName.Penetration, 100.0);
            SetSkill(SkillName.Parer, 100.0);

            ChooseArmor(ArmorClass.Plaque, CraftResource.Argent, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Narvegne();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
            BaseShield shield = new BouclierPavoisNoir();
            shield.Quality = ArmorQuality.Exceptional;
            shield.Resource = CraftResource.Argent;
        }

        public MobilePlaqueEpeeLenteBouclier(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    public class MobilePlaqueEpeeRapideBouclier : TestMobile
    {
        public MobilePlaqueEpeeRapideBouclier()
        {
            RawStr = 80;
            RawDex = 85;
            RawInt = 60;

            SetSkill(SkillName.Epee, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);
            SetSkill(SkillName.CoupCritique, 100.0);
            SetSkill(SkillName.Concentration, 100.0);
            SetSkill(SkillName.Penetration, 100.0);
            SetSkill(SkillName.Parer, 100.0);

            ChooseArmor(ArmorClass.Plaque, CraftResource.Argent, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Hectmore();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
            BaseShield shield = new BouclierPavoisNoir();
            shield.Quality = ArmorQuality.Exceptional;
            shield.Resource = CraftResource.Argent;
        }

        public MobilePlaqueEpeeRapideBouclier(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    #endregion


    public class MobileCuirEpeeLente : TestMobile
    {
        public MobileCuirEpeeLente()
        {
            RawStr = 100;
            RawDex = 100;
            RawInt = 25;

            SetSkill(SkillName.Epee, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);
            SetSkill(SkillName.CoupCritique, 100.0);
            SetSkill(SkillName.Concentration, 100.0);
            SetSkill(SkillName.Penetration, 100.0);
            SetSkill(SkillName.Parer, 100.0);

            ChooseArmor(ArmorClass.Cuir, CraftResource.DesertiqueLeather, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Granlame();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobileCuirEpeeLente(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }
}
