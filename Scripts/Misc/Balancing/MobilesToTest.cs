using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Misc.Balancing
{
    #region POUR LES TESTS RELATIF AUX VITESSES DES ARMES.
    public class MobilePlaqueEpeeLente : TestMobile
    {
        public MobilePlaqueEpeeLente()
        {
            Name = "2H Plaque Lente";

            RawStr = 100;
            RawDex = 100;
            RawInt = 25;

            SetSkill(SkillName.Epee, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);
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
            Name = "2H Plaque Rapide";

            RawStr = 100;
            RawDex = 100;
            RawInt = 25;

            SetSkill(SkillName.Epee, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);
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
            Name = "1H Plaque Lente";

            RawStr = 80;
            RawDex = 85;
            RawInt = 60;

            SetSkill(SkillName.Epee, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);
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
            Name = "1H Plaque Rapide";

            RawStr = 80;
            RawDex = 85;
            RawInt = 60;

            SetSkill(SkillName.Epee, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);
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


    public class MobileCuirEpeeLente : TestMobile
    {
        public MobileCuirEpeeLente()
        {
            Name = "2H Cuir Lente";

            RawStr = 100;
            RawDex = 100;
            RawInt = 25;

            SetSkill(SkillName.Epee, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);
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

    public class MobileCuirEpeeRapide : TestMobile
    {
        public MobileCuirEpeeRapide()
        {
            Name = "2H Cuir Rapide";

            RawStr = 100;
            RawDex = 100;
            RawInt = 25;

            SetSkill(SkillName.Epee, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);
            SetSkill(SkillName.Parer, 100.0);

            ChooseArmor(ArmorClass.Cuir, CraftResource.DesertiqueLeather, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Couliere();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobileCuirEpeeRapide(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    public class MobileCuirEpeeLenteBouclier : TestMobile
    {
        public MobileCuirEpeeLenteBouclier()
        {
            Name = "1H Cuir Lente";

            RawStr = 80;
            RawDex = 85;
            RawInt = 60;

            SetSkill(SkillName.Epee, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);
            SetSkill(SkillName.Parer, 100.0);

            ChooseArmor(ArmorClass.Cuir, CraftResource.DesertiqueLeather, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Narvegne();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
            BaseShield shield = new BouclierPavoisNoir();
            shield.Quality = ArmorQuality.Exceptional;
            shield.Resource = CraftResource.Argent;
        }

        public MobileCuirEpeeLenteBouclier(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    public class MobileCuirEpeeRapideBouclier : TestMobile
    {
        public MobileCuirEpeeRapideBouclier()
        {
            Name = "1H Cuir Rapide";

            RawStr = 80;
            RawDex = 85;
            RawInt = 60;

            SetSkill(SkillName.Epee, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);
            SetSkill(SkillName.Parer, 100.0);

            ChooseArmor(ArmorClass.Cuir, CraftResource.DesertiqueLeather, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Hectmore();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
            BaseShield shield = new BouclierPavoisNoir();
            shield.Quality = ArmorQuality.Exceptional;
            shield.Resource = CraftResource.Argent;
        }

        public MobileCuirEpeeRapideBouclier(Serial serial) : base(serial) { }

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

    #region TESTS D'ARMURE NATURELLE VS ARMOR PENETRATION

    /*
    Devrait être :
    Cuir < Plaque
    Cuir + ArNaturelle == Plaque + ArNaturelle
    Cuir + Penetration == Plaque + Penetration
    Cuir + ArNaturelle + Penetration > Plaque + ArNaturelle + Penetration
    
    Cuir + ArNaturelle > Cuir + Penetration
    Plaque + Penetration > Plaque + ArNaturelle
    
    */

    public class MobileCuir : TestMobile
    {
        public MobileCuir()
        {
            Name = "Cuir";

            RawStr = 100;
            RawDex = 100;
            RawInt = 25;

            SetSkill(SkillName.Epee, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);

            ChooseArmor(ArmorClass.Cuir, CraftResource.DesertiqueLeather, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Couliere();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobileCuir(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }
    public class MobileCuir_ArNat : TestMobile
    {
        public MobileCuir_ArNat()
        {
            Name = "Cuir ArNat";

            RawStr = 100;
            RawDex = 100;
            RawInt = 25;

            SetSkill(SkillName.Epee, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);
            SetSkill(SkillName.ArmureNaturelle, 100.0);

            ChooseArmor(ArmorClass.Cuir, CraftResource.DesertiqueLeather, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Couliere();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobileCuir_ArNat(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }
    public class MobileCuir_Pen : TestMobile
    {
        public MobileCuir_Pen()
        {
            Name = "Cuir Pen";

            RawStr = 100;
            RawDex = 100;
            RawInt = 25;

            SetSkill(SkillName.Epee, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);
            SetSkill(SkillName.Penetration, 100.0);

            ChooseArmor(ArmorClass.Cuir, CraftResource.DesertiqueLeather, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Couliere();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobileCuir_Pen(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }
    public class MobileCuir_ArNat_Pen : TestMobile
    {
        public MobileCuir_ArNat_Pen()
        {
            Name = "Cuir ArNat Pen";

            RawStr = 100;
            RawDex = 100;
            RawInt = 25;

            SetSkill(SkillName.Epee, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);
            SetSkill(SkillName.Penetration, 100.0);
            SetSkill(SkillName.ArmureNaturelle, 100.0);

            ChooseArmor(ArmorClass.Cuir, CraftResource.DesertiqueLeather, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Couliere();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobileCuir_ArNat_Pen(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    public class MobilePlaque : TestMobile
    {
        public MobilePlaque()
        {
            Name = "Plaque";

            RawStr = 100;
            RawDex = 100;
            RawInt = 25;

            SetSkill(SkillName.Epee, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);

            ChooseArmor(ArmorClass.PlaqueLourde, CraftResource.Argent, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Couliere();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobilePlaque(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }
    public class MobilePlaque_ArNat : TestMobile
    {
        public MobilePlaque_ArNat()
        {
            Name = "Plaque ArNat";

            RawStr = 100;
            RawDex = 100;
            RawInt = 25;

            SetSkill(SkillName.Epee, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);
            SetSkill(SkillName.ArmureNaturelle, 100.0);

            ChooseArmor(ArmorClass.PlaqueLourde, CraftResource.Argent, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Couliere();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobilePlaque_ArNat(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }
    public class MobilePlaque_Pen : TestMobile
    {
        public MobilePlaque_Pen()
        {
            Name = "Plaque Pen";

            RawStr = 100;
            RawDex = 100;
            RawInt = 25;

            SetSkill(SkillName.Epee, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);
            SetSkill(SkillName.Penetration, 100.0);

            ChooseArmor(ArmorClass.PlaqueLourde, CraftResource.Argent, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Couliere();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobilePlaque_Pen(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }
    public class MobilePlaque_ArNat_Pen : TestMobile
    {
        public MobilePlaque_ArNat_Pen()
        {
            Name = "Plaque ArNat Pen";

            RawStr = 100;
            RawDex = 100;
            RawInt = 25;

            SetSkill(SkillName.Epee, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);
            SetSkill(SkillName.Penetration, 100.0);
            SetSkill(SkillName.ArmureNaturelle, 100.0);

            ChooseArmor(ArmorClass.PlaqueLourde, CraftResource.Argent, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Couliere();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobilePlaque_ArNat_Pen(Serial serial) : base(serial) { }

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

    #region POUR LES TESTS RELATIFS AUX TYPES D'ARMES.

    public class MobilePlaqueEpeeCrit : TestMobile
    {
        public MobilePlaqueEpeeCrit()
        {
            Name = "2H Plaque Epee Crit";

            RawStr = 100;
            RawDex = 100;
            RawInt = 100;

            SetSkill(SkillName.ArmeDistance, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);
            SetSkill(SkillName.CoupCritique, 100.0);

            ChooseArmor(ArmorClass.Plaque, CraftResource.Argent, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Flamberge();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobilePlaqueEpeeCrit(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    public class MobilePlaqueEpee : TestMobile
    {
        public MobilePlaqueEpee()
        {
            Name = "2H Plaque Epee";

            RawStr = 100;
            RawDex = 100;
            RawInt = 100;

            SetSkill(SkillName.ArmeDistance, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);

            ChooseArmor(ArmorClass.Plaque, CraftResource.Argent, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Flamberge();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobilePlaqueEpee(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    public class MobileCuirEpee : TestMobile
    {
        public MobileCuirEpee()
        {
            Name = "2H Cuir Epee";

            RawStr = 100;
            RawDex = 100;
            RawInt = 100;

            SetSkill(SkillName.ArmeDistance, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);

            ChooseArmor(ArmorClass.Cuir, CraftResource.DesertiqueLeather, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Flamberge();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobileCuirEpee(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    public class MobilePlaqueHache : TestMobile
    {
        public MobilePlaqueHache()
        {
            Name = "2H Plaque Hache";

            RawStr = 100;
            RawDex = 100;
            RawInt = 100;

            SetSkill(SkillName.ArmeDistance, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);

            ChooseArmor(ArmorClass.Plaque, CraftResource.Argent, ArmorQuality.Exceptional);

            BaseWeapon weapon = new TwoHandedAxe();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobilePlaqueHache(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    public class MobileCuirHache : TestMobile
    {
        public MobileCuirHache()
        {
            Name = "2H Cuir Hache";

            RawStr = 100;
            RawDex = 100;
            RawInt = 100;

            SetSkill(SkillName.ArmeDistance, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);

            ChooseArmor(ArmorClass.Cuir, CraftResource.DesertiqueLeather, ArmorQuality.Exceptional);

            BaseWeapon weapon = new TwoHandedAxe();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobileCuirHache(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    public class MobilePlaqueMasse : TestMobile
    {
        public MobilePlaqueMasse()
        {
            Name = "2H Plaque Masse";

            RawStr = 100;
            RawDex = 100;
            RawInt = 100;

            SetSkill(SkillName.ArmeDistance, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);

            ChooseArmor(ArmorClass.Plaque, CraftResource.Argent, ArmorQuality.Exceptional);

            BaseWeapon weapon = new MarteauGuerre();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobilePlaqueMasse(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    public class MobileCuirMasse : TestMobile
    {
        public MobileCuirMasse()
        {
            Name = "2H Cuir Masse";

            RawStr = 100;
            RawDex = 100;
            RawInt = 100;

            SetSkill(SkillName.ArmeDistance, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);

            ChooseArmor(ArmorClass.Cuir, CraftResource.DesertiqueLeather, ArmorQuality.Exceptional);

            BaseWeapon weapon = new MarteauGuerre();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobileCuirMasse(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    public class MobilePlaquePerforantCrit : TestMobile
    {
        public MobilePlaquePerforantCrit()
        {
            Name = "2H Plaque Perforant Crit";

            RawStr = 100;
            RawDex = 100;
            RawInt = 100;

            SetSkill(SkillName.ArmeDistance, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);
            SetSkill(SkillName.CoupCritique, 100.0);

            ChooseArmor(ArmorClass.Plaque, CraftResource.Argent, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Katara();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobilePlaquePerforantCrit(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    public class MobilePlaquePerforant : TestMobile
    {
        public MobilePlaquePerforant()
        {
            Name = "2H Plaque Perforant";

            RawStr = 100;
            RawDex = 100;
            RawInt = 100;

            SetSkill(SkillName.ArmeDistance, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);

            ChooseArmor(ArmorClass.Plaque, CraftResource.Argent, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Katara();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobilePlaquePerforant(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    public class MobileCuirPerforant : TestMobile
    {
        public MobileCuirPerforant()
        {
            Name = "2H Cuir Perforant";

            RawStr = 100;
            RawDex = 100;
            RawInt = 100;

            SetSkill(SkillName.ArmeDistance, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);

            ChooseArmor(ArmorClass.Cuir, CraftResource.DesertiqueLeather, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Katara();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobileCuirPerforant(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    public class MobilePlaqueHaste : TestMobile
    {
        public MobilePlaqueHaste()
        {
            Name = "2H Plaque Haste";

            RawStr = 100;
            RawDex = 100;
            RawInt = 100;

            SetSkill(SkillName.ArmeDistance, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);

            ChooseArmor(ArmorClass.Plaque, CraftResource.Argent, ArmorQuality.Exceptional);

            BaseWeapon weapon = new PerceTronc();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobilePlaqueHaste(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    public class MobileCuirHaste : TestMobile
    {
        public MobileCuirHaste()
        {
            Name = "2H Cuir Haste";

            RawStr = 100;
            RawDex = 100;
            RawInt = 100;

            SetSkill(SkillName.ArmeDistance, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);

            ChooseArmor(ArmorClass.Cuir, CraftResource.DesertiqueLeather, ArmorQuality.Exceptional);

            BaseWeapon weapon = new PerceTronc();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);
        }

        public MobileCuirHaste(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    public class MobilePlaqueArbalete : TestMobile
    {
        public MobilePlaqueArbalete()
        {
            Name = "2H Plaque Arbalete";

            RawStr = 100;
            RawDex = 100;
            RawInt = 100;

            SetSkill(SkillName.ArmeDistance, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);

            ChooseArmor(ArmorClass.Plaque, CraftResource.Argent, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Arbavive();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);

            Bolt bolts = new Bolt(50);
            AddItem(bolts);
        }

        public MobilePlaqueArbalete(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    public class MobileCuirArbalete : TestMobile
    {
        public MobileCuirArbalete()
        {
            Name = "2H Cuir Arbalete";

            RawStr = 100;
            RawDex = 100;
            RawInt = 100;

            SetSkill(SkillName.ArmeDistance, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);

            ChooseArmor(ArmorClass.Cuir, CraftResource.DesertiqueLeather, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Arbavive();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);

            Bolt bolts = new Bolt(50);
            AddItem(bolts);
        }

        public MobileCuirArbalete(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    public class MobilePlaqueArc : TestMobile
    {
        public MobilePlaqueArc()
        {
            Name = "2H Plaque Arc";

            RawStr = 100;
            RawDex = 100;
            RawInt = 100;

            SetSkill(SkillName.ArmeDistance, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);

            ChooseArmor(ArmorClass.Plaque, CraftResource.Argent, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Chantefleche();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);

            Arrow bolts = new Arrow(50);
            AddItem(bolts);
        }

        public MobilePlaqueArc(Serial serial) : base(serial) { }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }

    public class MobileCuirArc : TestMobile
    {
        public MobileCuirArc()
        {
            Name = "2H Cuir Arc";

            RawStr = 100;
            RawDex = 100;
            RawInt = 100;

            SetSkill(SkillName.ArmeDistance, 100.0);
            SetSkill(SkillName.Tactiques, 100.0);
            SetSkill(SkillName.Anatomie, 100.0);

            ChooseArmor(ArmorClass.Cuir, CraftResource.DesertiqueLeather, ArmorQuality.Exceptional);

            BaseWeapon weapon = new Chantefleche();
            weapon.Quality = WeaponQuality.Exceptional;
            weapon.Resource = CraftResource.Argent;
            AddItem(weapon);

            Arrow bolts = new Arrow(50);
            AddItem(bolts);
        }

        public MobileCuirArc(Serial serial) : base(serial) { }

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
}
