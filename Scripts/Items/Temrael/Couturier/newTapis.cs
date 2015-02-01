using System;

namespace Server.Items
{
    [Flipable(0x0AA9, 0x0AAA, 0x0AAB, 0x0AAC, 0x0AAD, 0x0AAE, 0x0AAF, 0x0AB0, 0x0AB1, 0x0AB2)]
	public class TapisBrun : Item, IDyable
	{
		[Constructable]
        public TapisBrun()
            : base(0x0AA9)
		{
			Weight = 1.0;
            Name = "Tapis brun";
		}

        public TapisBrun(Serial serial)
            : base(serial)
		{
		}
		
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
		
			public bool Dye( Mobile from, DyeTub sender )
		{
			if ( Deleted )
			return false;

			Hue = sender.Hue;

			return true;
		}
	}

    [Flipable(0x0AB3, 0x0AB4, 0x0AB5, 0x0AB6, 0x0AB7, 0x0AB8, 0x0AB9, 0x0ABA, 0x0ABB, 0x0ABC)]
    public class TapisVert : Item, IDyable
    {
        [Constructable]
        public TapisVert()
            : base(0x0AB3)
        {
            Weight = 1.0;
            Name = "Tapis vert";
        }

        public TapisVert(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

        }

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.Hue;

            return true;
        }
    }

    [Flipable(0x0ABD, 0x0ABE, 0x0ABF, 0x0AC0, 0x0AC1, 0x0AC2, 0x0AC3, 0x0AC4, 0x0AC5)]
    public class TapisBleuFleuri : Item, IDyable
    {
        [Constructable]
        public TapisBleuFleuri()
            : base(0x0ABD)
        {
            Weight = 1.0;
            Name = "Tapis bleu fleuri";
        }

        public TapisBleuFleuri(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

        }

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.Hue;

            return true;
        }
    }

    [Flipable(0x0AC6, 0x0AC7, 0x0AC8, 0x0AC9, 0x0ACA, 0x0ACB, 0x0ACC, 0x0ACD, 0x0ACE, 0x0ACF, 0x0AD0)]
    public class TapisRougeDeLys : Item, IDyable
    {
        [Constructable]
        public TapisRougeDeLys()
            : base(0x0AC6)
        {
            Weight = 1.0;
            Name = "Tapis rouge de lys";
        }

        public TapisRougeDeLys(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

        }

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.Hue;

            return true;
        }
    }

    [Flipable(0x0AD1, 0x0AD2, 0x0AD3, 0x0AD4, 0x0AD5, 0x0AD6, 0x0AD7, 0x0AD8, 0x0AD9)]
    public class TapisBleuAvecMotifs : Item, IDyable
    {
        [Constructable]
        public TapisBleuAvecMotifs()
            : base(0x0AD1)
        {
            Weight = 1.0;
            Name = "Tapis bleu avec motifs";
        }

        public TapisBleuAvecMotifs(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

        }

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.Hue;

            return true;
        }
    }

    [Flipable(0x0ADA, 0x0ADB, 0x0ADC, 0x0ADD, 0x0ADE, 0x0ADF, 0x0AE0, 0x0AE1, 0x0AE2)]
    public class TapisJauneAvecMotifs : Item, IDyable
    {
        [Constructable]
        public TapisJauneAvecMotifs()
            : base(0x0ADA)
        {
            Weight = 1.0;
            Name = "Tapis jaune avec motifs";
        }

        public TapisJauneAvecMotifs(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

        }

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.Hue;

            return true;
        }
    }

    [Flipable(0x0AED, 0x0AEE, 0x0AEF, 0x0AF0, 0x0AF1, 0x0AF2, 0x0AF3, 0x0AF4, 0x0AF5)]
    public class TapisBleuBourgogne : Item, IDyable
    {
        [Constructable]
        public TapisBleuBourgogne()
            : base(0x0AED)
        {
            Weight = 1.0;
            Name = "Tapis bleu et bourgogne";
        }

        public TapisBleuBourgogne(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

        }

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.Hue;

            return true;
        }
    }






}