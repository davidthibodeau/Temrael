using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Misc.Balancing
{
    public enum ArmorClass 
    {
        None,
        Cuir,
        Cloute,
        Os,
        Anneau,
        Maille,
        Plaque,
        PlaqueLourde
    }

    public class TestMobile : PlayerMobile
    {
        public TestMobile()
        {
            
        }

        public TestMobile(Serial serial)
            : base(serial)
        {
        }

        public void SetSkill(SkillName sk, double value)
        {
            Skills[sk].Base = value;
        }

        public void ChooseArmor(ArmorClass ac, CraftResource res, ArmorQuality qual)
        {
            BaseArmor tete = null;
            BaseArmor gorget = null;
            BaseArmor bras = null;
            BaseArmor mains = null;
            BaseArmor torse = null;
            BaseArmor jambes = null;
            switch(ac)
            {
                case ArmorClass.Cuir:
                    tete = new LeatherCap();
                    gorget = new LeatherGorget();
                    bras = new LeatherArms();
                    mains = new LeatherGloves();
                    torse = new LeatherChest();
                    jambes = new LeatherLegs();
                    break;
                case ArmorClass.Cloute:
                    tete = new LeatherCap();
                    gorget = new StuddedGorget();
                    bras = new StuddedArms();
                    mains = new StuddedGloves();
                    torse = new StuddedChest();
                    jambes = new StuddedLegs();
                    break;


                case ArmorClass.Plaque:
                    tete = new PlateHelm();
                    gorget = new PlateGorget();
                    bras = new PlateArms();
                    mains = new PlateGloves();
                    torse = new PlateChest();
                    jambes = new PlateLegs();
                    break;
            }

            if(tete != null)
            {
                tete.Resource = res;
                tete.Quality = qual;
                AddItem(tete);
            }
            if(gorget != null)
            {
                gorget.Resource = res;
                gorget.Quality = qual;
                AddItem(gorget);
            }
            if(bras != null)
            {
                bras.Resource = res;
                bras.Quality = qual;
                AddItem(bras);
            }
            if(mains != null)
            {
                mains.Resource = res;
                mains.Quality = qual;
                AddItem(mains);
            }
            if(torse != null)
            {
                torse.Resource = res;
                torse.Quality = qual;
                AddItem(torse);
            }
            if(jambes != null)
            {
                jambes.Resource = res;
                jambes.Quality = qual;
                AddItem(jambes);
            }
        }

        public override void OnDeath(Container c)
        {
            Combatant = null;
            Balancing.InvokeDeath(new DeathEventArgs(this));
            for (int i = c.Items.Count - 1; i >= 0; i--)
            {
                EquipItem(c.Items[i]);
            }
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            Delete();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }
}

