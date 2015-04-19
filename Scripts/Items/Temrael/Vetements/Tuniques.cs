using System;
using Server.Items;

namespace Server.Items
{
    public class TuniqueRobuste : BaseMiddleTorso
    {
        [Constructable]
        public TuniqueRobuste()
            : this(0)
        {
        }

        [Constructable]
        public TuniqueRobuste(int hue)
            : base(0x2A73, hue)
        {
            Weight = 5.0;
            Name = "Tunique Robuste";
        }

        public TuniqueRobuste(Serial serial)
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

    public class TuniqueLegereOrient : BaseMiddleTorso
    {
        [Constructable]
        public TuniqueLegereOrient()
            : this(0)
        {
        }

        [Constructable]
        public TuniqueLegereOrient(int hue)
            : base(0x2A71, hue)
        {
            Weight = 5.0;
            Name = "Tunique Légère d'Orient";
        }

        public TuniqueLegereOrient(Serial serial)
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

    public class TuniqueElfique : BaseMiddleTorso
    {
        [Constructable]
        public TuniqueElfique()
            : this(0)
        {
        }

        [Constructable]
        public TuniqueElfique(int hue)
            : base(0x2B09, hue)
        {
            Weight = 5.0;
            Name = "Tunique Elfique";
        }

        public TuniqueElfique(Serial serial)
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

    public class TuniqueDaedric : BaseMiddleTorso
    {
        [Constructable]
        public TuniqueDaedric()
            : this(0)
        {
        }

        [Constructable]
        public TuniqueDaedric(int hue)
            : base(0x2B0C, hue)
        {
            Weight = 5.0;
            Name = "Tunique Daedric";
        }

        public TuniqueDaedric(Serial serial)
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

    public class DoubletAmple : BaseMiddleTorso
    {
        [Constructable]
        public DoubletAmple()
            : this(0)
        {
        }

        [Constructable]
        public DoubletAmple(int hue)
            : base(0x2746, hue)
        {
            Weight = 5.0;
            Name = "Doublet Ample";
        }

        public DoubletAmple(Serial serial)
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
    public class DoubletFeminin : BaseMiddleTorso
    {
        [Constructable]
        public DoubletFeminin()
            : this(0)
        {
        }

        [Constructable]
        public DoubletFeminin(int hue)
            : base(0x2748, hue)
        {
            Weight = 5.0;
            Name = "Doublet Feminin";
        }

        public DoubletFeminin(Serial serial)
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
    public class TuniquePage : BaseMiddleTorso
    {
        [Constructable]
        public TuniquePage()
            : this(0)
        {
        }

        [Constructable]
        public TuniquePage(int hue)
            : base(0x2749, hue)
        {
            Weight = 5.0;
            Name = "Tunique de Page";
        }

        public TuniquePage(Serial serial)
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
    public class TuniqueOuverte : BaseMiddleTorso
    {
        [Constructable]
        public TuniqueOuverte()
            : this(0)
        {
        }

        [Constructable]
        public TuniqueOuverte(int hue)
            : base(0x274D, hue)
        {
            Weight = 5.0;
            Name = "Tunique Ouverte";
        }

        public TuniqueOuverte(Serial serial)
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
    public class TuniquePaysanne : BaseMiddleTorso
    {
        [Constructable]
        public TuniquePaysanne()
            : this(0)
        {
        }

        [Constructable]
        public TuniquePaysanne(int hue)
            : base(0x274E, hue)
        {
            Weight = 5.0;
            Name = "Tunique Paysanne";
        }

        public TuniquePaysanne(Serial serial)
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
    public class TuniqueKilt : BaseMiddleTorso
    {
        [Constructable]
        public TuniqueKilt()
            : this(0)
        {
        }

        [Constructable]
        public TuniqueKilt(int hue)
            : base(0x274F, hue)
        {
            Weight = 5.0;
            Name = "Tunique Kilt";
        }

        public TuniqueKilt(Serial serial)
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
    public class TabarCourt : BaseMiddleTorso
    {
        [Constructable]
        public TabarCourt()
            : this(0)
        {
        }

        [Constructable]
        public TabarCourt(int hue)
            : base(0x2752, hue)
        {
            Weight = 5.0;
            Name = "Tabar Court";
        }

        public TabarCourt(Serial serial)
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
    public class Corset : BaseMiddleTorso
    {
        [Constructable]
        public Corset()
            : this(0)
        {
        }

        [Constructable]
        public Corset(int hue)
            : base(0x2753, hue)
        {
            Weight = 5.0;
            Name = "Corset";
        }

        public Corset(Serial serial)
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
    public class CorsetPetit : BaseMiddleTorso
    {
        [Constructable]
        public CorsetPetit()
            : this(0)
        {
        }

        [Constructable]
        public CorsetPetit(int hue)
            : base(0x2754, hue)
        {
            Weight = 5.0;
            Name = "Petit Corset";
        }

        public CorsetPetit(Serial serial)
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
    public class DoubletArmure : BaseMiddleTorso
    {
        [Constructable]
        public DoubletArmure()
            : this(0)
        {
        }

        [Constructable]
        public DoubletArmure(int hue)
            : base(0x2756, hue)
        {
            Weight = 5.0;
            Name = "Doublet Armure";
        }

        public DoubletArmure(Serial serial)
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
    public class TuniquePardessus : BaseMiddleTorso
    {
        [Constructable]
        public TuniquePardessus()
            : this(0)
        {
        }

        [Constructable]
        public TuniquePardessus(int hue)
            : base(0x2757, hue)
        {
            Weight = 5.0;
            Name = "Tunique Pardessus";
        }

        public TuniquePardessus(Serial serial)
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
    public class TuniqueNoble : BaseMiddleTorso
    {
        [Constructable]
        public TuniqueNoble()
            : this(0)
        {
        }

        [Constructable]
        public TuniqueNoble(int hue)
            : base(0x2758, hue)
        {
            Weight = 5.0;
            Name = "Tunique Noble";
        }

        public TuniqueNoble(Serial serial)
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
    public class TabarReligieux : BaseMiddleTorso
    {
        [Constructable]
        public TabarReligieux()
            : this(0)
        {
        }

        [Constructable]
        public TabarReligieux(int hue)
            : base(0x275A, hue)
        {
            Weight = 5.0;
            Name = "Tabar Religieux";
        }

        public TabarReligieux(Serial serial)
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
    public class TablierBarbare : BaseMiddleTorso
    {
        [Constructable]
        public TablierBarbare()
            : this(0)
        {
        }

        [Constructable]
        public TablierBarbare(int hue)
            : base(0x275B, hue)
        {
            Weight = 5.0;
            Name = "Tablier Barbare";
        }

        public TablierBarbare(Serial serial)
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
    public class TuniqueAmple : BaseMiddleTorso
    {
        [Constructable]
        public TuniqueAmple()
            : this(0)
        {
        }

        [Constructable]
        public TuniqueAmple(int hue)
            : base(0x275E, hue)
        {
            Weight = 5.0;
            Name = "Tunique Ample";
        }

        public TuniqueAmple(Serial serial)
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
    public class Veston : BaseMiddleTorso
    {
        [Constructable]
        public Veston()
            : this(0)
        {
        }

        [Constructable]
        public Veston(int hue)
            : base(0x275F, hue)
        {
            Weight = 5.0;
            Name = "Veston";
        }

        public Veston(Serial serial)
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
    public class DoubletBouton : BaseMiddleTorso
    {
        [Constructable]
        public DoubletBouton()
            : this(0)
        {
        }

        [Constructable]
        public DoubletBouton(int hue)
            : base(0x2760, hue)
        {
            Weight = 5.0;
            Name = "Doublet a Boutons";
        }

        public DoubletBouton(Serial serial)
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
    public class Tunique : BaseMiddleTorso
    {
        [Constructable]
        public Tunique()
            : this(0)
        {
        }

        [Constructable]
        public Tunique(int hue)
            : base(0x2776, hue)
        {
            Weight = 5.0;
            Name = "Tunique";
        }

        public Tunique(Serial serial)
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
    public class TabarLong : BaseMiddleTorso
    {
        [Constructable]
        public TabarLong()
            : this(0)
        {
        }

        [Constructable]
        public TabarLong(int hue)
            : base(0x2777, hue)
        {
            Weight = 5.0;
            Name = "Tabar Long";
        }

        public TabarLong(Serial serial)
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
    public class TuniqueOrientale : BaseMiddleTorso
    {
        [Constructable]
        public TuniqueOrientale()
            : this(0)
        {
        }

        [Constructable]
        public TuniqueOrientale(int hue)
            : base(0x2778, hue)
        {
            Weight = 5.0;
            Name = "Tunique Orientale";
        }

        public TuniqueOrientale(Serial serial)
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
    public class TuniqueBourgeoise : BaseMiddleTorso
    {
        [Constructable]
        public TuniqueBourgeoise()
            : this(0)
        {
        }

        [Constructable]
        public TuniqueBourgeoise(int hue)
            : base(0x2779, hue)
        {
            Weight = 5.0;
            Name = "Tunique Bourgeoise";
        }

        public TuniqueBourgeoise(Serial serial)
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
    public class Veste : BaseMiddleTorso
    {
        [Constructable]
        public Veste()
            : this(0)
        {
        }

        [Constructable]
        public Veste(int hue)
            : base(0x277A, hue)
        {
            Weight = 5.0;
            Name = "Veste";
        }

        public Veste(Serial serial)
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
    public class VesteLourde : BaseMiddleTorso
    {
        [Constructable]
        public VesteLourde()
            : this(0)
        {
        }

        [Constructable]
        public VesteLourde(int hue)
            : base(0x277B, hue)
        {
            Weight = 5.0;
            Name = "Veste Lourde";
        }

        public VesteLourde(Serial serial)
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
    public class CorsetLong : BaseMiddleTorso
    {
        [Constructable]
        public CorsetLong()
            : this(0)
        {
        }

        [Constructable]
        public CorsetLong(int hue)
            : base(0x277D, hue)
        {
            Weight = 5.0;
            Name = "Corset Long";
        }

        public CorsetLong(Serial serial)
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
    public class TuniqueLongueDechire : BaseMiddleTorso
    {
        [Constructable]
        public TuniqueLongueDechire()
            : this(0)
        {
        }

        [Constructable]
        public TuniqueLongueDechire(int hue)
            : base(0x277F, hue)
        {
            Weight = 5.0;
            Name = "Tunique Longue Dechire";
        }

        public TuniqueLongueDechire(Serial serial)
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
    public class TuniqueDechire : BaseMiddleTorso
    {
        [Constructable]
        public TuniqueDechire()
            : this(0)
        {
        }

        [Constructable]
        public TuniqueDechire(int hue)
            : base(0x2780, hue)
        {
            Weight = 5.0;
            Name = "Tunique Dechire";
        }

        public TuniqueDechire(Serial serial)
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
    public class TabarDechire : BaseMiddleTorso
    {
        [Constructable]
        public TabarDechire()
            : this(0)
        {
        }

        [Constructable]
        public TabarDechire(int hue)
            : base(0x2781, hue)
        {
            Weight = 5.0;
            Name = "Tabar Dechire";
        }

        public TabarDechire(Serial serial)
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
    public class CorsetAmple : BaseMiddleTorso
    {
        [Constructable]
        public CorsetAmple()
            : this(0)
        {
        }

        [Constructable]
        public CorsetAmple(int hue)
            : base(0x2784, hue)
        {
            Weight = 5.0;
            Name = "Corset Ample";
        }

        public CorsetAmple(Serial serial)
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
    public class TuniqueAssassin : BaseMiddleTorso
    {
        [Constructable]
        public TuniqueAssassin()
            : this(0)
        {
        }

        [Constructable]
        public TuniqueAssassin(int hue)
            : base(0x2B79, hue)
        {
            Weight = 5.0;
            Name = "Tunique d'Assassin";
        }

        public TuniqueAssassin(Serial serial)
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
    public class TuniquePirate : BaseMiddleTorso
    {
        [Constructable]
        public TuniquePirate()
            : this(0)
        {
        }

        [Constructable]
        public TuniquePirate(int hue)
            : base(0x2BE1, hue)
        {
            Weight = 5.0;
            Name = "Tunique de Pirate";
        }

        public TuniquePirate(Serial serial)
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
    public class CorsetSombre : BaseMiddleTorso
    {
        [Constructable]
        public CorsetSombre()
            : this(0)
        {
        }

        [Constructable]
        public CorsetSombre(int hue)
            : base(0x3161, hue)
        {
            Weight = 5.0;
            Name = "Corset Sombre";
        }

        public CorsetSombre(Serial serial)
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
    public class TuniqueVoyage : BaseMiddleTorso
    {
        [Constructable]
        public TuniqueVoyage()
            : this(0)
        {
        }

        [Constructable]
        public TuniqueVoyage(int hue)
            : base(0x3166, hue)
        {
            Weight = 5.0;
            Name = "Tunique de Voyage";
        }

        public TuniqueVoyage(Serial serial)
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
    public class TuniqueNomade : BaseMiddleTorso
    {
        [Constructable]
        public TuniqueNomade()
            : this(0)
        {
        }

        [Constructable]
        public TuniqueNomade(int hue)
            : base(0x3167, hue)
        {
            Weight = 5.0;
            Name = "Tunique Nomade";
        }

        public TuniqueNomade(Serial serial)
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
    public class VesteCuir : BaseMiddleTorso
    {
        [Constructable]
        public VesteCuir()
            : this(0)
        {
        }

        [Constructable]
        public VesteCuir(int hue)
            : base(0x317B, hue)
        {
            Weight = 5.0;
            Name = "Veste Cuir";
        }

        public VesteCuir(Serial serial)
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
    public class VestePoil : BaseMiddleTorso
    {
        [Constructable]
        public VestePoil()
            : this(0)
        {
        }

        [Constructable]
        public VestePoil(int hue)
            : base(0x317A, hue)
        {
            Weight = 5.0;
            Name = "Veste de Poil";
        }

        public VestePoil(Serial serial)
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
