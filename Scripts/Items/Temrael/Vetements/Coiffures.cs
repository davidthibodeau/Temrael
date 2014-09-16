using System;
using Server.Items;

namespace Server.Items
{
    public class CoiffureOrientale : Hair
    {
        private CoiffureOrientale()
            : this(0)
        {
        }

        private CoiffureOrientale(int hue)
            : base(0x27D5, hue)
        {
        }

        public CoiffureOrientale(Serial serial)
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
    public class CoiffureChignon : Hair
    {
        private CoiffureChignon()
            : this(0)
        {
        }

        private CoiffureChignon(int hue)
            : base(0x27D6, hue)
        {
        }

        public CoiffureChignon(Serial serial)
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
    public class CoiffureLulusBoucle : Hair
    {
        private CoiffureLulusBoucle()
            : this(0)
        {
        }

        private CoiffureLulusBoucle(int hue)
            : base(0x27D8, hue)
        {
        }

        public CoiffureLulusBoucle(Serial serial)
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
    public class CoiffureCourte : Hair
    {
        private CoiffureCourte()
            : this(0)
        {
        }

        private CoiffureCourte(int hue)
            : base(0x27D9, hue)
        {
        }

        public CoiffureCourte(Serial serial)
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
    public class CoiffureDesinvolte : Hair
    {
        private CoiffureDesinvolte()
            : this(0)
        {
        }

        private CoiffureDesinvolte(int hue)
            : base(0x27DA, hue)
        {
        }

        public CoiffureDesinvolte(Serial serial)
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
    public class CoiffureLongueBoucle : Hair
    {
        private CoiffureLongueBoucle()
            : this(0)
        {
        }

        private CoiffureLongueBoucle(int hue)
            : base(0x27DB, hue)
        {
        }

        public CoiffureLongueBoucle(Serial serial)
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
    public class CoiffureLongue : Hair
    {
        private CoiffureLongue()
            : this(0)
        {
        }

        private CoiffureLongue(int hue)
            : base(0x27DC, hue)
        {
        }

        public CoiffureLongue(Serial serial)
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
    public class CoiffureDepagne : Hair
    {
        private CoiffureDepagne()
            : this(0)
        {
        }

        private CoiffureDepagne(int hue)
            : base(0x27DD, hue)
        {
        }

        public CoiffureDepagne(Serial serial)
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
    public class CoiffureBoucles : Hair
    {
        private CoiffureBoucles()
            : this(0)
        {
        }

        private CoiffureBoucles(int hue)
            : base(0x27DE, hue)
        {
        }

        public CoiffureBoucles(Serial serial)
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
    public class CoiffureNoble : Hair
    {
        private CoiffureNoble()
            : this(0)
        {
        }

        private CoiffureNoble(int hue)
            : base(0x27DF, hue)
        {
        }

        public CoiffureNoble(Serial serial)
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
    public class CoiffurePegne : Hair
    {
        private CoiffurePegne()
            : this(0)
        {
        }

        private CoiffurePegne(int hue)
            : base(0x27E1, hue)
        {
        }

        public CoiffurePegne(Serial serial)
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
    public class CoiffureLongueCouette : Hair
    {
        private CoiffureLongueCouette()
            : this(0)
        {
        }

        private CoiffureLongueCouette(int hue)
            : base(0x27E2, hue)
        {
        }

        public CoiffureLongueCouette(Serial serial)
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
    public class CoiffureCouetteNordique : Hair
    {
        private CoiffureCouetteNordique()
            : this(0)
        {
        }

        private CoiffureCouetteNordique(int hue)
            : base(0x27E3, hue)
        {
        }

        public CoiffureCouetteNordique(Serial serial)
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
    public class CoiffureAmple : Hair
    {
        private CoiffureAmple()
            : this(0)
        {
        }

        private CoiffureAmple(int hue)
            : base(0x27E4, hue)
        {
        }

        public CoiffureAmple(Serial serial)
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
    public class CoiffureCouettes : Hair
    {
        private CoiffureCouettes()
            : this(0)
        {
        }

        private CoiffureCouettes(int hue)
            : base(0x27E5, hue)
        {
        }

        public CoiffureCouettes(Serial serial)
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
    public class CoiffureCouettesAmples : Hair
    {
        private CoiffureCouettesAmples()
            : this(0)
        {
        }

        private CoiffureCouettesAmples(int hue)
            : base(0x27E6, hue)
        {
        }

        public CoiffureCouettesAmples(Serial serial)
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
    public class CoiffurePlate : Hair
    {
        private CoiffurePlate()
            : this(0)
        {
        }

        private CoiffurePlate(int hue)
            : base(0x27E7, hue)
        {
        }

        public CoiffurePlate(Serial serial)
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
    public class CoiffureCavaliere : Hair
    {
        private CoiffureCavaliere()
            : this(0)
        {
        }

        private CoiffureCavaliere(int hue)
            : base(0x27E8, hue)
        {
        }

        public CoiffureCavaliere(Serial serial)
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
    public class CoiffureServante : Hair
    {
        private CoiffureServante()
            : this(0)
        {
        }

        private CoiffureServante(int hue)
            : base(0x27EB, hue)
        {
        }

        public CoiffureServante(Serial serial)
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
    public class CoiffureCourteNoble : Hair
    {
        private CoiffureCourteNoble()
            : this(0)
        {
        }

        private CoiffureCourteNoble(int hue)
            : base(0x27EC, hue)
        {
        }

        public CoiffureCourteNoble(Serial serial)
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
    public class CoiffureLongueElfique : Hair
    {
        private CoiffureLongueElfique()
            : this(0)
        {
        }

        private CoiffureLongueElfique(int hue)
            : base(0x27ED, hue)
        {
        }

        public CoiffureLongueElfique(Serial serial)
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
    public class CoiffureLonguesLulus : Hair
    {
        private CoiffureLonguesLulus()
            : this(0)
        {
        }

        private CoiffureLonguesLulus(int hue)
            : base(0x27EE, hue)
        {
        }

        public CoiffureLonguesLulus(Serial serial)
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
    public class CoiffureLongueLulu : Hair
    {
        private CoiffureLongueLulu()
            : this(0)
        {
        }

        private CoiffureLongueLulu(int hue)
            : base(0x27EF, hue)
        {
        }

        public CoiffureLongueLulu(Serial serial)
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
    public class CoiffureTresCourte : Hair
    {
        private CoiffureTresCourte()
            : this(0)
        {
        }

        private CoiffureTresCourte(int hue)
            : base(0x27F0, hue)
        {
        }

        public CoiffureTresCourte(Serial serial)
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
    public class CoiffureCourteMouton : Hair
    {
        private CoiffureCourteMouton()
            : this(0)
        {
        }

        private CoiffureCourteMouton(int hue)
            : base(0x27F1, hue)
        {
        }

        public CoiffureCourteMouton(Serial serial)
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
    public class CoiffureLongueMouton : Hair
    {
        private CoiffureLongueMouton()
            : this(0)
        {
        }

        private CoiffureLongueMouton(int hue)
            : base(0x27F2, hue)
        {
        }

        public CoiffureLongueMouton(Serial serial)
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
    public class CoiffurePrincesse : Hair
    {
        private CoiffurePrincesse()
            : this(0)
        {
        }

        private CoiffurePrincesse(int hue)
            : base(0x27F3, hue)
        {
        }

        public CoiffurePrincesse(Serial serial)
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
    public class CoiffureFeminineElfique : Hair
    {
        private CoiffureFeminineElfique()
            : this(0)
        {
        }

        private CoiffureFeminineElfique(int hue)
            : base(0x27F4, hue)
        {
        }

        public CoiffureFeminineElfique(Serial serial)
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
    public class CoiffureMasculineElfique : Hair
    {
        private CoiffureMasculineElfique()
            : this(0)
        {
        }

        private CoiffureMasculineElfique(int hue)
            : base(0x27F5, hue)
        {
        }

        public CoiffureMasculineElfique(Serial serial)
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
    public class CoiffureToupet : Hair
    {
        private CoiffureToupet()
            : this(0)
        {
        }

        private CoiffureToupet(int hue)
            : base(0x2833, hue)
        {
        }

        public CoiffureToupet(Serial serial)
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
    public class CoiffureTresse : Hair
    {
        private CoiffureTresse()
            : this(0)
        {
        }

        private CoiffureTresse(int hue)
            : base(0x2834, hue)
        {
        }

        public CoiffureTresse(Serial serial)
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
    public class CoiffureAncestral : Hair
    {
        private CoiffureAncestral()
            : this(0)
        {
        }

        private CoiffureAncestral(int hue)
            : base(0x2835, hue)
        {
        }

        public CoiffureAncestral(Serial serial)
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
    public class CoiffureLongCalvicie : Hair
    {
        private CoiffureLongCalvicie()
            : this(0)
        {
        }

        private CoiffureLongCalvicie(int hue)
            : base(0x2836, hue)
        {
        }

        public CoiffureLongCalvicie(Serial serial)
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
    public class CoiffureCouette : Hair
    {
        private CoiffureCouette()
            : this(0)
        {
        }

        private CoiffureCouette(int hue)
            : base(0x2837, hue)
        {
        }

        public CoiffureCouette(Serial serial)
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
    public class CoiffureLulus : Hair
    {
        private CoiffureLulus()
            : this(0)
        {
        }

        private CoiffureLulus(int hue)
            : base(0x2838, hue)
        {
        }

        public CoiffureLulus(Serial serial)
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
    public class CoiffurePlats : Hair
    {
        private CoiffurePlats()
            : this(0)
        {
        }

        private CoiffurePlats(int hue)
            : base(0x2839, hue)
        {
        }

        public CoiffurePlats(Serial serial)
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
    public class CoiffurePiques : Hair
    {
        private CoiffurePiques()
            : this(0)
        {
        }

        private CoiffurePiques(int hue)
            : base(0x283A, hue)
        {
        }

        public CoiffurePiques(Serial serial)
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
    public class CoiffureRaids : Hair
    {
        private CoiffureRaids()
            : this(0)
        {
        }

        private CoiffureRaids(int hue)
            : base(0x283B, hue)
        {
        }

        public CoiffureRaids(Serial serial)
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
    public class CoiffureBouclesElfique : Hair
    {
        private CoiffureBouclesElfique()
            : this(0)
        {
        }

        private CoiffureBouclesElfique(int hue)
            : base(0x289F, hue)
        {
        }

        public CoiffureBouclesElfique(Serial serial)
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
