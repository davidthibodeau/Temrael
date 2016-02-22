using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Alchimie
{
    public abstract class ComposantAlchimique : Item
    {
        public abstract string name { get; }
        public abstract BasePotionEffect effect { get; }

        public ComposantAlchimique(int itemid)
            : base(itemid)
        {
        }

        public ComposantAlchimique(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
    }



    public class Bloodmosss : ComposantAlchimique
    {
        public override string name
        {
            get { return "BloodMoss"; }
        }

        public override BasePotionEffect effect
        {
            get { return new PotForce(); }
        }

        [Constructable]
        public Bloodmosss()
            : base(0xF7B)
        {
        }

        public Bloodmosss(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class Ginsengg : ComposantAlchimique
    {
        public override string name
        {
            get { return "Ginseng"; }
        }

        public override BasePotionEffect effect
        {
            get { return new PotDex(); }
        }

        [Constructable]
        public Ginsengg()
            : base(0xF85)
        {
        }

        public Ginsengg(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class Nightshadee : ComposantAlchimique
    {
        public override string name
        {
            get { return "Nightshade"; }
        }

        public override BasePotionEffect effect
        {
            get { return new PotInt(); }
        }

        [Constructable]
        public Nightshadee()
            : base(0xF88)
        {
        }

        public Nightshadee(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
