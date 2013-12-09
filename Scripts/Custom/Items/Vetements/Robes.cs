using System;
using Server.Items;

namespace Server.Items
{
    public class RobeDemoiselle : BaseOuterTorso
    {
        [Constructable]
        public RobeDemoiselle()
            : this(0)
        {
        }

        [Constructable]
        public RobeDemoiselle(int hue)
            : base(0x2798, hue)
        {
            Weight = 5.0;
            Name = "Robe de Demoiselle";
        }

        public RobeDemoiselle(Serial serial)
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
    public class RobeFleurit : BaseOuterTorso
    {
        [Constructable]
        public RobeFleurit()
            : this(0)
        {
        }

        [Constructable]
        public RobeFleurit(int hue)
            : base(0x2799, hue)
        {
            Weight = 5.0;
            Name = "Robe Fleurit";
        }

        public RobeFleurit(Serial serial)
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
    public class RobeSansManches : BaseOuterTorso
    {
        [Constructable]
        public RobeSansManches()
            : this(0)
        {
        }

        [Constructable]
        public RobeSansManches(int hue)
            : base(0x279A, hue)
        {
            Weight = 5.0;
            Name = "Robe Sans Manches";
        }

        public RobeSansManches(Serial serial)
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
    public class RobeElfe : BaseOuterTorso
    {
        [Constructable]
        public RobeElfe()
            : this(0)
        {
        }

        [Constructable]
        public RobeElfe(int hue)
            : base(0x279B, hue)
        {
            Weight = 5.0;
            Name = "Robe Elfique";
        }

        public RobeElfe(Serial serial)
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
    public class RobeAmpleElfique : BaseOuterTorso
    {
        [Constructable]
        public RobeAmpleElfique()
            : this(0)
        {
        }

        [Constructable]
        public RobeAmpleElfique(int hue)
            : base(0x279C, hue)
        {
            Weight = 5.0;
            Name = "Robe Ample Elfique";
        }

        public RobeAmpleElfique(Serial serial)
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
    public class RobeTrainee : BaseOuterTorso
    {
        [Constructable]
        public RobeTrainee()
            : this(0)
        {
        }

        [Constructable]
        public RobeTrainee(int hue)
            : base(0x279D, hue)
        {
            Weight = 5.0;
            Name = "Robe a Trainee";
        }

        public RobeTrainee(Serial serial)
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
    public class RobeElfeNoir : BaseOuterTorso
    {
        [Constructable]
        public RobeElfeNoir()
            : this(0)
        {
        }

        [Constructable]
        public RobeElfeNoir(int hue)
            : base(0x27A0, hue)
        {
            Weight = 5.0;
            Name = "Robe Elfe Noir";
        }

        public RobeElfeNoir(Serial serial)
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
    public class RobeServante : BaseOuterTorso
    {
        [Constructable]
        public RobeServante()
            : this(0)
        {
        }

        [Constructable]
        public RobeServante(int hue)
            : base(0x27A1, hue)
        {
            Weight = 5.0;
            Name = "Robe Servante";
        }

        public RobeServante(Serial serial)
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
    public class RobeMariage : BaseOuterTorso
    {
        [Constructable]
        public RobeMariage()
            : this(0)
        {
        }

        [Constructable]
        public RobeMariage(int hue)
            : base(0x27A2, hue)
        {
            Weight = 5.0;
            Name = "Robe Mariage";
        }

        public RobeMariage(Serial serial)
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
    public class RobeServeuse : BaseOuterTorso
    {
        [Constructable]
        public RobeServeuse()
            : this(0)
        {
        }

        [Constructable]
        public RobeServeuse(int hue)
            : base(0x27A3, hue)
        {
            Weight = 5.0;
            Name = "Robe Serveuse";
        }

        public RobeServeuse(Serial serial)
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
    public class RobeSombre : BaseOuterTorso
    {
        [Constructable]
        public RobeSombre()
            : this(0)
        {
        }

        [Constructable]
        public RobeSombre(int hue)
            : base(0x27A4, hue)
        {
            Weight = 5.0;
            Name = "Robe Sombre";
        }

        public RobeSombre(Serial serial)
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
    public class RobeDomestique : BaseOuterTorso
    {
        [Constructable]
        public RobeDomestique()
            : this(0)
        {
        }

        [Constructable]
        public RobeDomestique(int hue)
            : base(0x27A5, hue)
        {
            Weight = 5.0;
            Name = "Robe Domestique";
        }

        public RobeDomestique(Serial serial)
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
    public class RobeDentelle : BaseOuterTorso
    {
        [Constructable]
        public RobeDentelle()
            : this(0)
        {
        }

        [Constructable]
        public RobeDentelle(int hue)
            : base(0x27A6, hue)
        {
            Weight = 5.0;
            Name = "Robe a Dentelle";
        }

        public RobeDentelle(Serial serial)
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
    public class RobeAmple : BaseOuterTorso
    {
        [Constructable]
        public RobeAmple()
            : this(0)
        {
        }

        [Constructable]
        public RobeAmple(int hue)
            : base(0x27A7, hue)
        {
            Weight = 5.0;
            Name = "Robe Ample";
        }

        public RobeAmple(Serial serial)
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
    public class RobeLarge : BaseOuterTorso
    {
        [Constructable]
        public RobeLarge()
            : this(0)
        {
        }

        [Constructable]
        public RobeLarge(int hue)
            : base(0x27A8, hue)
        {
            Weight = 5.0;
            Name = "Large Robe";
        }

        public RobeLarge(Serial serial)
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
    public class Robetrainante : BaseOuterTorso
    {
        [Constructable]
        public Robetrainante()
            : this(0)
        {
        }

        [Constructable]
        public Robetrainante(int hue)
            : base(0x27A9, hue)
        {
            Weight = 5.0;
            Name = "Robe Trainnate";
        }

        public Robetrainante(Serial serial)
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
    public class RobeBourgeoise : BaseOuterTorso
    {
        [Constructable]
        public RobeBourgeoise()
            : this(0)
        {
        }

        [Constructable]
        public RobeBourgeoise(int hue)
            : base(0x27AA, hue)
        {
            Weight = 5.0;
            Name = "Robe Bourgeoise";
        }

        public RobeBourgeoise(Serial serial)
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
    public class RobeSobre : BaseOuterTorso
    {
        [Constructable]
        public RobeSobre()
            : this(0)
        {
        }

        [Constructable]
        public RobeSobre(int hue)
            : base(0x27AB, hue)
        {
            Weight = 5.0;
            Name = "Robe Sobre";
        }

        public RobeSobre(Serial serial)
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
    public class RobeAmusante : BaseOuterTorso
    {
        [Constructable]
        public RobeAmusante()
            : this(0)
        {
        }

        [Constructable]
        public RobeAmusante(int hue)
            : base(0x27AC, hue)
        {
            Weight = 5.0;
            Name = "Robe Amusante";
        }

        public RobeAmusante(Serial serial)
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
    public class RobeElegante : BaseOuterTorso
    {
        [Constructable]
        public RobeElegante()
            : this(0)
        {
        }

        [Constructable]
        public RobeElegante(int hue)
            : base(0x27AD, hue)
        {
            Weight = 5.0;
            Name = "Robe Elegante";
        }

        public RobeElegante(Serial serial)
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
    public class RobeAraneide : BaseOuterTorso
    {
        [Constructable]
        public RobeAraneide()
            : this(0)
        {
        }

        [Constructable]
        public RobeAraneide(int hue)
            : base(0x27AE, hue)
        {
            Weight = 5.0;
            Name = "Robe Araneide";
        }

        public RobeAraneide(Serial serial)
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
    public class RobeSeduisante : BaseOuterTorso
    {
        [Constructable]
        public RobeSeduisante()
            : this(0)
        {
        }

        [Constructable]
        public RobeSeduisante(int hue)
            : base(0x27AF, hue)
        {
            Weight = 5.0;
            Name = "Robe Seduisante";
        }

        public RobeSeduisante(Serial serial)
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
    public class RobeBohemienne : BaseOuterTorso
    {
        [Constructable]
        public RobeBohemienne()
            : this(0)
        {
        }

        [Constructable]
        public RobeBohemienne(int hue)
            : base(0x27BF, hue)
        {
            Weight = 5.0;
            Name = "Robe Bohemienne";
        }

        public RobeBohemienne(Serial serial)
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
    public class RobeAvecCorset : BaseOuterTorso
    {
        [Constructable]
        public RobeAvecCorset()
            : this(0)
        {
        }

        [Constructable]
        public RobeAvecCorset(int hue)
            : base(0x27C0, hue)
        {
            Weight = 5.0;
            Name = "Robe Avec Corset";
        }

        public RobeAvecCorset(Serial serial)
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
    public class RobeOrientale : BaseOuterTorso
    {
        [Constructable]
        public RobeOrientale()
            : this(0)
        {
        }

        [Constructable]
        public RobeOrientale(int hue)
            : base(0x27C1, hue)
        {
            Weight = 5.0;
            Name = "Robe Orientale";
        }

        public RobeOrientale(Serial serial)
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
    public class RobeOrcish : BaseOuterTorso
    {
        [Constructable]
        public RobeOrcish()
            : this(0)
        {
        }

        [Constructable]
        public RobeOrcish(int hue)
            : base(0x27C2, hue)
        {
            Weight = 5.0;
            Name = "Robe Orcish";
        }

        public RobeOrcish(Serial serial)
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
    public class RobeCharmante : BaseOuterTorso
    {
        [Constructable]
        public RobeCharmante()
            : this(0)
        {
        }

        [Constructable]
        public RobeCharmante(int hue)
            : base(0x27C3, hue)
        {
            Weight = 5.0;
            Name = "Robe Charmante";
        }

        public RobeCharmante(Serial serial)
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
    public class RobeElfique : BaseOuterTorso
    {
        [Constructable]
        public RobeElfique()
            : this(0)
        {
        }

        [Constructable]
        public RobeElfique(int hue)
            : base(0x27C4, hue)
        {
            Weight = 5.0;
            Name = "Robe Elfique";
        }

        public RobeElfique(Serial serial)
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
    public class RobeAraignee : BaseOuterTorso
    {
        [Constructable]
        public RobeAraignee()
            : this(0)
        {
        }

        [Constructable]
        public RobeAraignee(int hue)
            : base(0x27C5, hue)
        {
            Weight = 5.0;
            Name = "Robe Araignee";
        }

        public RobeAraignee(Serial serial)
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
    public class RobeGitane : BaseOuterTorso
    {
        [Constructable]
        public RobeGitane()
            : this(0)
        {
        }

        [Constructable]
        public RobeGitane(int hue)
            : base(0x27C6, hue)
        {
            Weight = 5.0;
            Name = "Robe Gitane";
        }

        public RobeGitane(Serial serial)
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
    public class RobeNoble : BaseOuterTorso
    {
        [Constructable]
        public RobeNoble()
            : this(0)
        {
        }

        [Constructable]
        public RobeNoble(int hue)
            : base(0x27C7, hue)
        {
            Weight = 5.0;
            Name = "Robe Noble";
        }

        public RobeNoble(Serial serial)
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
    public class RobeAubergiste : BaseOuterTorso
    {
        [Constructable]
        public RobeAubergiste()
            : this(0)
        {
        }

        [Constructable]
        public RobeAubergiste(int hue)
            : base(0x27C8, hue)
        {
            Weight = 5.0;
            Name = "Robe d'Aubergiste";
        }

        public RobeAubergiste(Serial serial)
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
    public class RobeCourt : BaseOuterTorso
    {
        [Constructable]
        public RobeCourt()
            : this(0)
        {
        }

        [Constructable]
        public RobeCourt(int hue)
            : base(0x27C9, hue)
        {
            Weight = 5.0;
            Name = "Robe de Court";
        }

        public RobeCourt(Serial serial)
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
    public class RobeSimple : BaseOuterTorso
    {
        [Constructable]
        public RobeSimple()
            : this(0)
        {
        }

        [Constructable]
        public RobeSimple(int hue)
            : base(0x27CA, hue)
        {
            Weight = 5.0;
            Name = "Robe Simple";
        }

        public RobeSimple(Serial serial)
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
    public class RobeSoubrette : BaseOuterTorso
    {
        [Constructable]
        public RobeSoubrette()
            : this(0)
        {
        }

        [Constructable]
        public RobeSoubrette(int hue)
            : base(0x27CB, hue)
        {
            Weight = 5.0;
            Name = "Robe de Soubrette";
        }

        public RobeSoubrette(Serial serial)
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
    public class RobePetite : BaseOuterTorso
    {
        [Constructable]
        public RobePetite()
            : this(0)
        {
        }

        [Constructable]
        public RobePetite(int hue)
            : base(0x27CC, hue)
        {
            Weight = 5.0;
            Name = "Petite Robe";
        }

        public RobePetite(Serial serial)
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
    public class RobeEnfantine : BaseOuterTorso
    {
        [Constructable]
        public RobeEnfantine()
            : this(0)
        {
        }

        [Constructable]
        public RobeEnfantine(int hue)
            : base(0x27CD, hue)
        {
            Weight = 5.0;
            Name = "Robe Enfantine";
        }

        public RobeEnfantine(Serial serial)
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
    public class RobeACorset : BaseOuterTorso
    {
        [Constructable]
        public RobeACorset()
            : this(0)
        {
        }

        [Constructable]
        public RobeACorset(int hue)
            : base(0x27CE, hue)
        {
            Weight = 5.0;
            Name = "Robe a Corset";
        }

        public RobeACorset(Serial serial)
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
    public class RobeAttrayante : BaseOuterTorso
    {
        [Constructable]
        public RobeAttrayante()
            : this(0)
        {
        }

        [Constructable]
        public RobeAttrayante(int hue)
            : base(0x27CF, hue)
        {
            Weight = 5.0;
            Name = "Robe Attrayante";
        }

        public RobeAttrayante(Serial serial)
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
    public class RobeCourte : BaseOuterTorso
    {
        [Constructable]
        public RobeCourte()
            : this(0)
        {
        }

        [Constructable]
        public RobeCourte(int hue)
            : base(0x27D0, hue)
        {
            Weight = 5.0;
            Name = "Courte Robe";
        }

        public RobeCourte(Serial serial)
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
    public class RobeBoheme : BaseOuterTorso
    {
        [Constructable]
        public RobeBoheme()
            : this(0)
        {
        }

        [Constructable]
        public RobeBoheme(int hue)
            : base(0x27D1, hue)
        {
            Weight = 5.0;
            Name = "Robe Boheme";
        }

        public RobeBoheme(Serial serial)
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
    public class RobeDechire : BaseOuterTorso
    {
        [Constructable]
        public RobeDechire()
            : this(0)
        {
        }

        [Constructable]
        public RobeDechire(int hue)
            : base(0x27D2, hue)
        {
            Weight = 5.0;
            Name = "Robe Dechire";
        }

        public RobeDechire(Serial serial)
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
    public class RobeOrdinaire : BaseOuterTorso
    {
        [Constructable]
        public RobeOrdinaire()
            : this(0)
        {
        }

        [Constructable]
        public RobeOrdinaire(int hue)
            : base(0x27D3, hue)
        {
            Weight = 5.0;
            Name = "Robe Ordinaire";
        }

        public RobeOrdinaire(Serial serial)
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
    public class RobeGamine : BaseOuterTorso
    {
        [Constructable]
        public RobeGamine()
            : this(0)
        {
        }

        [Constructable]
        public RobeGamine(int hue)
            : base(0x27D4, hue)
        {
            Weight = 5.0;
            Name = "Robe de Gamine";
        }

        public RobeGamine(Serial serial)
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
    public class RobeAntique : BaseOuterTorso
    {
        [Constructable]
        public RobeAntique()
            : this(0)
        {
        }

        [Constructable]
        public RobeAntique(int hue)
            : base(0x2BDA, hue)
        {
            Weight = 5.0;
            Name = "Robe Antique";
        }

        public RobeAntique(Serial serial)
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
    public class RobeCorsetAmple : BaseOuterTorso
    {
        [Constructable]
        public RobeCorsetAmple()
            : this(0)
        {
        }

        [Constructable]
        public RobeCorsetAmple(int hue)
            : base(0x2BDB, hue)
        {
            Weight = 5.0;
            Name = "Robe a Corset Ample";
        }

        public RobeCorsetAmple(Serial serial)
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
    public class RobeDore : BaseOuterTorso
    {
        [Constructable]
        public RobeDore()
            : this(0)
        {
        }

        [Constructable]
        public RobeDore(int hue)
            : base(0x2BDC, hue)
        {
            Weight = 5.0;
            Name = "Robe Doré";
        }

        public RobeDore(Serial serial)
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
    public class RobeNymph : BaseOuterTorso
    {
        [Constructable]
        public RobeNymph()
            : this(0)
        {
        }

        [Constructable]
        public RobeNymph(int hue)
            : base(0x2BDE, hue)
        {
            Weight = 5.0;
            Name = "Robe Nymph";
        }

        public RobeNymph(Serial serial)
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
    public class RobeOrient : BaseOuterTorso
    {
        [Constructable]
        public RobeOrient()
            : this(0)
        {
        }

        [Constructable]
        public RobeOrient(int hue)
            : base(0x2BE3, hue)
        {
            Weight = 5.0;
            Name = "Robe Orient";
        }

        public RobeOrient(Serial serial)
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
    public class RobeDrow : BaseOuterTorso
    {
        [Constructable]
        public RobeDrow()
            : this(0)
        {
        }

        [Constructable]
        public RobeDrow(int hue)
            : base(0x2BE7, hue)
        {
            Weight = 5.0;
            Name = "Robe Ancienne";
        }

        public RobeDrow(Serial serial)
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
    public class RobeACeinture : BaseOuterTorso
    {
        [Constructable]
        public RobeACeinture()
            : this(0)
        {
        }

        [Constructable]
        public RobeACeinture(int hue)
            : base(0x3156, hue)
        {
            Weight = 5.0;
            Name = "Robe a Ceinture";
        }

        public RobeACeinture(Serial serial)
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
    public class RobeGrande : BaseOuterTorso
    {
        [Constructable]
        public RobeGrande()
            : this(0)
        {
        }

        [Constructable]
        public RobeGrande(int hue)
            : base(0x3158, hue)
        {
            Weight = 5.0;
            Name = "Grande Robe";
        }

        public RobeGrande(Serial serial)
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
    public class RobeOuverte : BaseOuterTorso
    {
        [Constructable]
        public RobeOuverte()
            : this(0)
        {
        }

        [Constructable]
        public RobeOuverte(int hue)
            : base(0x3159, hue)
        {
            Weight = 5.0;
            Name = "Robe Ouverte";
        }

        public RobeOuverte(Serial serial)
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
    public class RobeOrne : BaseOuterTorso
    {
        [Constructable]
        public RobeOrne()
            : this(0)
        {
        }

        [Constructable]
        public RobeOrne(int hue)
            : base(0x3164, hue)
        {
            Weight = 5.0;
            Name = "Robe Orné";
        }

        public RobeOrne(Serial serial)
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
    public class RobeJuponElfique : BaseOuterTorso
    {
        [Constructable]
        public RobeJuponElfique()
            : this(0)
        {
        }

        [Constructable]
        public RobeJuponElfique(int hue)
            : base(0x2FC8, hue)
        {
            Weight = 5.0;
            Name = "Robe à Jupon Elfique";
        }

        public RobeJuponElfique(Serial serial)
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
    public class RobeCourteDrow : BaseOuterTorso
    {
        [Constructable]
        public RobeCourteDrow()
            : this(0)
        {
        }

        [Constructable]
        public RobeCourteDrow(int hue)
            : base(0x2FC9, hue)
        {
            Weight = 5.0;
            Name = "Robe Courte d'Elfe Noire";
        }

        public RobeCourteDrow(Serial serial)
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
