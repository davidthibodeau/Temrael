using System;
using Server.Items;

namespace Server.Items
{
    public class JartellesNoir : BaseOuterLegs
    {
        [Constructable]
        public JartellesNoir()
            : base(0x2648)
        {
            Weight = 0.1;
            Name = "Jartelles Noir";
        }

        public JartellesNoir(Serial serial)
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
    public class JartellesBlanches : BaseOuterLegs
    {
        [Constructable]
        public JartellesBlanches()
            : base(0x2649)
        {
            Weight = 0.1;
            Name = "Jartelles Blanches";
        }

        public JartellesBlanches(Serial serial)
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
    public class CeintureLongue : BaseWaist
    {
        [Constructable]
        public CeintureLongue()
            : base(0x264A)
        {
            Weight = 0.1;
            Name = "Ceinture Longue";
        }

        public CeintureLongue(Serial serial)
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
    public class CeintureTorseGrande : BaseWaist
    {
        [Constructable]
        public CeintureTorseGrande()
            : base(0x264D)
        {
            Weight = 0.1;
            Name = "Ceinture de Torse Grande";
        }

        public CeintureTorseGrande(Serial serial)
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
    public class CeinturePauvre : BaseWaist
    {
        [Constructable]
        public CeinturePauvre()
            : base(0x265F)
        {
            Weight = 0.1;
            Name = "Ceinture Pauvre";
        }

        public CeinturePauvre(Serial serial)
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
    public class CeinturePendante : BaseWaist
    {
        [Constructable]
        public CeinturePendante()
            : base(0x2660)
        {
            Weight = 0.1;
            Name = "Ceinture Pendante";
        }

        public CeinturePendante(Serial serial)
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
    public class CeintureCuir : BaseWaist
    {
        [Constructable]
        public CeintureCuir()
            : base(0x2661)
        {
            Weight = 0.1;
            Name = "Ceinture de Cuir";
        }

        public CeintureCuir(Serial serial)
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
    public class CeintureNordique : BaseWaist
    {
        [Constructable]
        public CeintureNordique()
            : base(0x2662)
        {
            Weight = 0.1;
            Name = "Ceinture Nordique";
        }

        public CeintureNordique(Serial serial)
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
    public class CeintureBoucle : BaseWaist
    {
        [Constructable]
        public CeintureBoucle()
            : base(0x2663)
        {
            Weight = 0.1;
            Name = "Ceinture Boucle";
        }

        public CeintureBoucle(Serial serial)
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
    public class CeintureBourse : BaseWaist
    {
        [Constructable]
        public CeintureBourse()
            : base(0x2664)
        {
            Weight = 0.1;
            Name = "Ceinture Bourse";
        }

        public CeintureBourse(Serial serial)
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
    public class Bourse : BaseWaist
    {
        [Constructable]
        public Bourse()
            : base(0x2665)
        {
            Weight = 0.1;
            Name = "Bourse";
        }

        public Bourse(Serial serial)
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
    public class Ceinture : BaseWaist
    {
        [Constructable]
        public Ceinture()
            : base(0x2666)
        {
            Weight = 0.1;
            Name = "Ceinture";
        }

        public Ceinture(Serial serial)
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
    public class Fourreau : BaseWaist
    {
        [Constructable]
        public Fourreau()
            : base(0x2667)
        {
            Weight = 0.1;
            Name = "Fourreau";
        }

        public Fourreau(Serial serial)
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
    public class Carquois : BaseCloak
    {
        [Constructable]
        public Carquois()
            : base(0x2668)
        {
            Weight = 0.1;
            Name = "Carquois";
        }

        public Carquois(Serial serial)
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
    public class FourreauDos : BaseWaist
    {
        [Constructable]
        public FourreauDos()
            : base(0x266B)
        {
            Weight = 0.1;
            Name = "Fourreau de Dos";
        }

        public FourreauDos(Serial serial)
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
    public class FourreauDague : BaseWaist
    {
        [Constructable]
        public FourreauDague()
            : base(0x266C)
        {
            Weight = 0.1;
            Name = "Fourreau de Dague";
        }

        public FourreauDague(Serial serial)
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
    public class FourreauDecouvert : BaseWaist
    {
        [Constructable]
        public FourreauDecouvert()
            : base(0x266D)
        {
            Weight = 0.1;
            Name = "Fourreau a Decouvert";
        }

        public FourreauDecouvert(Serial serial)
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
    public class FourreauRapiere : BaseWaist
    {
        [Constructable]
        public FourreauRapiere()
            : base(0x266E)
        {
            Weight = 0.1;
            Name = "Fourreau a Rapiere";
        }

        public FourreauRapiere(Serial serial)
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
    public class FourreauEpee : BaseWaist
    {
        [Constructable]
        public FourreauEpee()
            : base(0x2671)
        {
            Weight = 0.1;
            Name = "Fourreau a Epee";
        }

        public FourreauEpee(Serial serial)
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
    public class FourreauSabre : BaseWaist
    {
        [Constructable]
        public FourreauSabre()
            : base(0x2672)
        {
            Weight = 0.1;
            Name = "Fourreau a Sabre";
        }

        public FourreauSabre(Serial serial)
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
    public class BandeauDroit : BaseHat
    {
        [Constructable]
        public BandeauDroit()
            : base(0x2674)
        {
            Weight = 0.1;
            Name = "Bandeau Droit";
        }

        public BandeauDroit(Serial serial)
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
    public class BandeauAveugle : BaseHat
    {
        [Constructable]
        public BandeauAveugle()
            : base(0x2673)
        {
            Weight = 0.1;
            Name = "Bandeau Aveugle";
        }

        public BandeauAveugle(Serial serial)
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
    public class BandeauGauche : BaseHat
    {
        [Constructable]
        public BandeauGauche()
            : base(0x2677)
        {
            Weight = 0.1;
            Name = "Bandeau Gauche";
        }

        public BandeauGauche(Serial serial)
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
    public class SacocheCeinture : BaseWaist
    {
        [Constructable]
        public SacocheCeinture()
            : base(0x2678)
        {
            Weight = 0.1;
            Name = "Sacoche Ceintures";
        }

        public SacocheCeinture(Serial serial)
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
    public class SacocheHerboriste : BaseWaist
    {
        [Constructable]
        public SacocheHerboriste()
            : base(0x2679)
        {
            Weight = 0.1;
            Name = "Sacoche d'Herboriste";
        }

        public SacocheHerboriste(Serial serial)
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
    public class SacocheRoublard : BaseWaist
    {
        [Constructable]
        public SacocheRoublard()
            : base(0x267A)
        {
            Weight = 0.1;
            Name = "Sacoche Roublarde";
        }

        public SacocheRoublard(Serial serial)
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
    public class SacocheAventure : BaseWaist
    {
        [Constructable]
        public SacocheAventure()
            : base(0x267B)
        {
            Weight = 0.1;
            Name = "Sacoche d'Aventure";
        }

        public SacocheAventure(Serial serial)
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
    public class Cocarde : BaseWaist
    {
        [Constructable]
        public Cocarde()
            : base(0x267C)
        {
            Weight = 0.1;
            Name = "Cocarde";
        }

        public Cocarde(Serial serial)
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
    public class Corne : BasePipes
    {
        [Constructable]
        public Corne()
            : base(0x267D)
        {
            Weight = 0.1;
            Name = "Corne";
        }

        public Corne(Serial serial)
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
    public class Crane : BasePipes
    {
        [Constructable]
        public Crane()
            : base(0x267E)
        {
            Weight = 0.1;
            Name = "Crane";
        }

        public Crane(Serial serial)
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
    public class Jartelles : BaseWaist
    {
        [Constructable]
        public Jartelles()
            : base(0x267F)
        {
            Weight = 0.1;
            Name = "Jartelles";
        }

        public Jartelles(Serial serial)
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
    public class SousVetement : BaseWaist
    {
        [Constructable]
        public SousVetement()
            : base(0x2680)
        {
            Weight = 0.1;
            Name = "Sous Vetement";
        }

        public SousVetement(Serial serial)
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
    public class Voile : BaseCloak
    {
        [Constructable]
        public Voile()
            : base(0x2681)
        {
            Weight = 0.1;
            Name = "Voile";
        }

        public Voile(Serial serial)
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
    public class Geta : BaseShoes
    {
        [Constructable]
        public Geta()
            : base(0x2682)
        {
            Weight = 0.1;
            Name = "Geta";
        }

        public Geta(Serial serial)
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
    public class Pardessus : BaseFoulards
    {
        [Constructable]
        public Pardessus()
            : base(0x2683)
        {
            Weight = 0.1;
            Name = "Pardessus";
        }

        public Pardessus(Serial serial)
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
    public class PardessusBarbare : BaseFoulards
    {
        [Constructable]
        public PardessusBarbare()
            : base(0x2684)
        {
            Weight = 0.1;
            Name = "Pardessus Barbare";
        }

        public PardessusBarbare(Serial serial)
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
    public class EpauliereBarbare : BaseFoulards
    {
        [Constructable]
        public EpauliereBarbare()
            : base(0x2685)
        {
            Weight = 0.1;
            Name = "Epauliere Barbare";
        }

        public EpauliereBarbare(Serial serial)
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
    public class Bracer : BaseBrassards
    {
        [Constructable]
        public Bracer()
            : base(0x2687)
        {
            Weight = 0.1;
            Name = "Bracer";
        }

        public Bracer(Serial serial)
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
    public class Foulard : BaseFoulards
    {
        [Constructable]
        public Foulard()
            : base(0x2689)
        {
            Weight = 0.1;
            Name = "Foulard";
        }

        public Foulard(Serial serial)
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
    public class FoulardNoble : BaseFoulards
    {
        [Constructable]
        public FoulardNoble()
            : base(0x268A)
        {
            Weight = 0.1;
            Name = "Foulard Noble";
        }

        public FoulardNoble(Serial serial)
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
    public class FoulardProtecteur : BaseFoulards
    {
        public override bool Disguise { get { return true; } }

        [Constructable]
        public FoulardProtecteur()
            : base(0x268B)
        {
            Weight = 0.1;
            Name = "Foulard Protecteur";
        }

        public FoulardProtecteur(Serial serial)
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
    public class Plume : BaseHat
    {
        [Constructable]
        public Plume()
            : base(0x268C)
        {
            Weight = 0.1;
            Name = "Plume";
        }

        public Plume(Serial serial)
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
    public class BandagesBras : BaseBrassards
    {
        [Constructable]
        public BandagesBras()
            : base(0x268D)
        {
            Weight = 0.1;
            Name = "Bandages de Bras";
        }

        public BandagesBras(Serial serial)
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
    public class BandagesTorse : BaseWaist
    {
        [Constructable]
        public BandagesTorse()
            : base(0x268E)
        {
            Weight = 0.1;
            Name = "Bandages de Torse";
        }

        public BandagesTorse(Serial serial)
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
    public class BandagesJambes : BasePants
    {
        [Constructable]
        public BandagesJambes()
            : base(0x268F)
        {
            Weight = 0.1;
            Name = "Bandages de Jambes";
        }

        public BandagesJambes(Serial serial)
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
    public class Pipe : BasePipes
    {
        [Constructable]
        public Pipe()
            : base(0x2690)
        {
            Weight = 0.1;
            Name = "Pipe";
        }

        public Pipe(Serial serial)
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
    public class PipeCrochu : BasePipes
    {
        [Constructable]
        public PipeCrochu()
            : base(0x2691)
        {
            Weight = 0.1;
            Name = "Pipe Crochu";
        }

        public PipeCrochu(Serial serial)
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
    public class PipeLongue : BasePipes
    {
        [Constructable]
        public PipeLongue()
            : base(0x2692)
        {
            Weight = 0.1;
            Name = "Pipe Longue";
        }

        public PipeLongue(Serial serial)
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
    public class CagouleGrande : BaseHat
    {
        public override bool Disguise { get { return true; } }

        [Constructable]
        public CagouleGrande()
            : base(0x26A1)
        {
            Weight = 0.1;
            Name = "Grande Cagoule";
        }

        public CagouleGrande(Serial serial)
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
    public class Cagoule : BaseHat
    {
        public override bool Disguise { get { return true; } }

        [Constructable]
        public Cagoule()
            : base(0x26A2)
        {
            Weight = 0.1;
            Name = "Cagoule";
        }

        public Cagoule(Serial serial)
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
    public class Capuche : BaseHat
    {
        [Constructable]
        public Capuche()
            : base(0x26A3)
        {
            Weight = 0.1;
            Name = "Capuche";
        }

        public Capuche(Serial serial)
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
    public class CapucheGrande : BaseHat
    {
        [Constructable]
        public CapucheGrande()
            : base(0x26A4)
        {
            Weight = 0.1;
            Name = "Grande Capuche";
        }

        public CapucheGrande(Serial serial)
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
    public class CagouleGorget : BaseFoulards
    {
        public override bool Disguise { get { return true; } }

        [Constructable]
        public CagouleGorget()
            : base(0x26AD)
        {
            Weight = 0.1;
            Name = "Cagoule Gorget";
        }

        public CagouleGorget(Serial serial)
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
    public class CagouleCuir : BaseFoulards
    {
        public override bool Disguise { get { return true; } }

        [Constructable]
        public CagouleCuir()
            : base(0x26AE)
        {
            Weight = 0.1;
            Name = "Cagoule de Cuir";
        }

        public CagouleCuir(Serial serial)
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
    public class Turban : BaseHat
    {
        [Constructable]
        public Turban()
            : base(0x26AF)
        {
            Weight = 0.1;
            Name = "Turban";
        }

        public Turban(Serial serial)
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
    public class TurbanLong : BaseHat
    {
        [Constructable]
        public TurbanLong()
            : base(0x26B0)
        {
            Weight = 0.1;
            Name = "Turban Long";
        }

        public TurbanLong(Serial serial)
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
    public class TurbanVoile : BaseHat
    {
        public override bool Disguise { get { return true; } }

        [Constructable]
        public TurbanVoile()
            : base(0x2BE4)
        {
            Weight = 0.1;
            Name = "Turban Voile";
        }

        public TurbanVoile(Serial serial)
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
    public class TurbanFeminin : BaseHat
    {
        [Constructable]
        public TurbanFeminin()
            : base(0x2BE4)
        {
            Weight = 0.1;
            Name = "Turban Feminin";
        }

        public TurbanFeminin(Serial serial)
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
    public class TurbanProtecteur : BaseHat
    {
        [Constructable]
        public TurbanProtecteur()
            : base(0x3157)
        {
            Weight = 0.1;
            Name = "Turban Protecteur";
        }

        public TurbanProtecteur(Serial serial)
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
    public class TurbanNoble : BaseHat
    {
        [Constructable]
        public TurbanNoble()
            : base(0x3169)
        {
            Weight = 0.1;
            Name = "Turban Noble";
        }

        public TurbanNoble(Serial serial)
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
    public class TurbanAmple : BaseHat
    {
        [Constructable]
        public TurbanAmple()
            : base(0x316E)
        {
            Weight = 0.1;
            Name = "Turban Ample";
        }

        public TurbanAmple(Serial serial)
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
    public class SoutienGorge : BaseMiddleTorso
    {
        [Constructable]
        public SoutienGorge()
            : base(0x312C)
        {
            Weight = 0.1;
            Name = "Soutien Gorge";
        }

        public SoutienGorge(Serial serial)
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
    public class BrassardsCommun : BaseBrassards
    {
        [Constructable]
        public BrassardsCommun()
            : base(0x3162)
        {
            Weight = 0.1;
            Name = "Brassards";
        }

        public BrassardsCommun(Serial serial)
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
    public class GantsSombres : BaseBrassards
    {
        [Constructable]
        public GantsSombres()
            : base(0x3163)
        {
            Weight = 0.1;
            Name = "Gants Sombres";
        }

        public GantsSombres(Serial serial)
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
    public class BrassardsFeminins : BaseBrassards
    {
        [Constructable]
        public BrassardsFeminins()
            : base(0x316A)
        {
            Weight = 0.1;
            Name = "Brassards Feminins";
        }

        public BrassardsFeminins(Serial serial)
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
    public class BrassardsSimples : BaseBrassards
    {
        [Constructable]
        public BrassardsSimples()
            : base(0x3170)
        {
            Weight = 0.1;
            Name = "Brassards Simples";
        }

        public BrassardsSimples(Serial serial)
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
