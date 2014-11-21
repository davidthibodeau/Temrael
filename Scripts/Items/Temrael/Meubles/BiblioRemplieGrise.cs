using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Items.Meubles
{
    public class ContenuBiblio : Item
    {
        private BookCaseContainer biblio;

        public ContenuBiblio(BookCaseContainer b, int ItemID)
            : base(ItemID)
        {
            biblio = b;
        }

        public ContenuBiblio(Serial serial)
            : base(serial)
        {
        }

        public override void OnLocationChange(Point3D oldLocation)
        {
            base.OnLocationChange(oldLocation);

            if (Location != biblio.Location)
                biblio.Location = Location;
        }

        public override bool CanBeAltered
        {
            get
            {
                return biblio.CanBeAltered;
            }
            set
            {
                biblio.CanBeAltered = value;
            }
        }

        public override bool Movable
        {
            get
            {
                return biblio.Movable;
            }
            set
            {
                biblio.Movable = value;
            }
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenus.ContextMenuEntry> list)
        {
            biblio.GetContextMenuEntries(from, list);
        }


       public override void OnMapChange()
        {
            base.OnMapChange();

            if (Map != biblio.Map)
                biblio.Map = Map;
        }

        public override void OnDoubleClick(Mobile from)
        {
            biblio.OnDoubleClick(from);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            biblio = (BookCaseContainer)reader.ReadItem();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); //version

            writer.Write(biblio);
        }
    }

    [Furniture]
    public class BiblioRemplieGriseEast : BookCaseContainer
    {
        private ContenuBiblio biblio;

        [Constructable]
        public BiblioRemplieGriseEast()
            : base(0x3bc8)
        {
            Hue = 0x811;

            int rand = Utility.Random(3);
            switch (rand)
            {
                case 0:
                    biblio = new ContenuBiblio(this, 0x3b70);
                    break;
                case 1:
                    biblio = new ContenuBiblio(this, 0x3b72);
                    break;
                case 2:
                    biblio = new ContenuBiblio(this, 0x3b74);
                    break;
                default:
                    Console.WriteLine("You don't know how to count to {0}.", rand.ToString());
                    break; 
            }

            biblio.MoveToWorld(Location, Map);
        }

        public BiblioRemplieGriseEast(Serial serial)
            : base(serial)
        {
        }

        public override void OnLocationChange(Point3D oldLocation)
        {
            base.OnLocationChange(oldLocation);

            if (Location != biblio.Location)
            {
                biblio.Location = Location;
            }
        }

        public override void OnMapChange()
        {
            base.OnMapChange();

            if (Map != biblio.Map)
                biblio.Map = Map;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); //version

            writer.Write(biblio);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            biblio = (ContenuBiblio)reader.ReadItem();
        }
    }


    [Furniture]
    public class BiblioRemplieGriseSouth : BookCaseContainer
    {
        private ContenuBiblio biblio;

        [Constructable]
        public BiblioRemplieGriseSouth()
            : base(0x3bc9)
        {
            Hue = 0x811;

            int rand = Utility.Random(3);
            switch (rand)
            {
                case 0:
                    biblio = new ContenuBiblio(this, 0x3b71);
                    break;
                case 1:
                    biblio = new ContenuBiblio(this, 0x3b73);
                    break;
                case 2:
                    biblio = new ContenuBiblio(this, 0x3b75);
                    break;
                default:
                    Console.WriteLine("You don't know how to count to {0}.", rand.ToString());
                    break; 
            }

            biblio.MoveToWorld(Location, Map);
        }

        public BiblioRemplieGriseSouth(Serial serial)
            : base(serial)
        {
        }

        public override void OnLocationChange(Point3D oldLocation)
        {
            base.OnLocationChange(oldLocation);

            if (Location != biblio.Location)
            {
                biblio.Location = Location;
            }
        }

        public override void OnMapChange()
        {
            base.OnMapChange();

            if (Map != biblio.Map)
                biblio.Map = Map;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); //version

            writer.Write(biblio);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            biblio = (ContenuBiblio)reader.ReadItem();
        }
    }
}
