using System;
using Server;
using Server.Mobiles;
using Server.Gumps;
using System.Collections;
using Server.Targeting;
using Server.Targets;
using Server.Network;
using Server.Engines.Help;
using Server.Prompts;
using System.Collections.Generic;

namespace Server.Items
{
    public class GeoConseiller
    {
        private Mobile m_mob;
        private int m_salaire;
        private bool m_accessMil;
        private bool m_accessTaxes;
        private bool m_accessPop;
        private bool m_accessRel;

        [CommandProperty(AccessLevel.Batisseur)]
        public Mobile Mob { get { return m_mob; } set { m_mob = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Salaire { get { return m_salaire; } set { m_salaire = value; } }
    }
    public class GeoMembre
    {
        private Mobile m_mob;
        private int m_salaire;
        private int m_taxe;
        private int m_salaireTresorerie;
        private int m_taxeTresorerie;
        private bool m_taxePayer;
        private int m_dime;
        private int m_dimeTresorerie;
        private bool m_dimePayer;
        private GeoClasses m_classeSociale;

        [CommandProperty(AccessLevel.Batisseur)]
        public Mobile Mob { get { return m_mob; } set { m_mob = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Salaire { get { return m_salaire; } set { m_salaire = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Taxe { get { return m_taxe; } set { m_taxe = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int SalaireTresorerie { get { return m_salaireTresorerie; } set { m_salaireTresorerie = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int TaxeTresorerie { get { return m_taxeTresorerie; } set { m_taxeTresorerie = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public bool TaxePayer { get { return m_taxePayer; } set { m_taxePayer = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Dime { get { return m_dime; } set { m_dime = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int DimeTresorerie { get { return m_dimeTresorerie; } set { m_dimeTresorerie = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public bool DimePayer { get { return m_dimePayer; } set { m_dimePayer = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public GeoClasses ClasseSociale { get { return m_classeSociale; } set { m_classeSociale = value; } }
    }
    public class GeoMilitaire
    {
        private int m_manpower;
        private int m_cout;
        private Races m_race;

        private int m_sauvages;
        private int m_archers;
        private int m_hallebardiers;
        private int m_fantassins;
        private int m_cavaliers;
        private int m_chevaliers;

        [CommandProperty(AccessLevel.Batisseur)]
        public int Manpower { get { return m_manpower; } set { m_manpower = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Cout { get { return m_cout; } set { m_cout = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public Races Race { get { return m_race; } set { m_race = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Sauvages { get { return m_sauvages; } set { m_sauvages = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Archers { get { return m_archers; } set { m_archers = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Hallebardiers { get { return m_hallebardiers; } set { m_hallebardiers = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Fantassins { get { return m_fantassins; } set { m_fantassins = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Cavaliers { get { return m_cavaliers; } set { m_cavaliers = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Chevaliers { get { return m_chevaliers; } set { m_chevaliers = value; } }
    }
    public class GeoRev
    {
        private int m_serfRev;
        private int m_bourgRev;
        private int m_clercRev;
        private int m_nobleRev;

        [CommandProperty(AccessLevel.Batisseur)]
        public int SerfRev { get { return m_serfRev; } set { m_serfRev = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int BourgRev { get { return m_bourgRev; } set { m_bourgRev = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int ClercRev { get { return m_clercRev; } set { m_clercRev = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int NobleRev { get { return m_nobleRev; } set { m_nobleRev = value; } }
    }
    public class GeoBuild
    {
        private GeoBuildType m_construction;
        private int m_level; //si plusieurs niveaux de constructions
        private int m_tooltip;
        private int m_image;
        private GeoEffet m_effet;
        private int m_effetLevel;

        [CommandProperty(AccessLevel.Batisseur)]
        public GeoBuildType Construction { get { return m_construction; } set { m_construction = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Level { get { return m_level; } set { m_level = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int ToolTip { get { return m_tooltip; } set { m_tooltip = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Image { get { return m_image; } set { m_image = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public GeoEffet Effet { get { return m_effet; } set { m_effet = value; } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int EffetLevel { get { return m_effetLevel; } set { m_effetLevel = value; } }
    }
    public enum GeoClasses
    {
        None,
        Serfs,
        Bourgeois,
        Clercs,
        Nobles
    }
    public enum GeoTerrains
    {
        Desert,
        Foret,
        Colines,
        Montagnes,
        Plaine,
        Marais
    }
    public enum GeoEffet
    {
        Manpower,
        Revenues,
        Piete,
        Import,
        Vente,
        Dime,
        Armures,
        Armes,
        Uniformes,
        Teintes,
        Experiance,
        Revoltes
    }
    public enum GeoBuildType
    {
        Castel,
        Religion,
        Routes,
        Mines,
        Port,
        Foresterie,
        //Singles
        Muraille,
        Entrainement,
        Bibliotheque,
        Tour,
        Monastere,
        Cimetiere,
        Atelier,
        Forge,
        Ferme,
        Taverne,
        Teinturier,
        Architecte,
        Alchimiste,
        Tisseur,
        MoulinEau,
        MoulinVent,
        Theatre,
        Tanneur,
        Bordel,
        Mercenaire,
        Boucher,
        Inventeur,
        Copiste,
        Artiste,
        Court,
        Palais
    }
    public enum GeoReligion
    {
        Chapelle,
        Eglise,
        Temple,
        Cathedrale,
        None
    }
    public enum GeoChateaux
    {
        Fort,
        Castel,
        Forteresse,
        Chateau,
        Citadelle,
        None
    }
    public enum GeoRoutes
    {
        Petite,
        Grande,
        None
    }
    public enum GeoMine
    {
        Petite,
        Grande,
        None
    }
    public enum GeoPort
    {
        Peche,
        Petit,
        Moyen,
        Grand,
        None
    }
    public enum GeoForesterie
    {
        Petite,
        Grande,
        None
    }
    public enum GeoConseillers
    {
        Regent,
        Sergent,
        Capitaine,
        Marechal,
        Connetable,
        Chancelier,
        Tresorier,
        Pretre,
        None
    }
    class GeoController : Item
    {
        private GeoTerrains m_Terrain;
        [CommandProperty(AccessLevel.Batisseur)]
        public GeoTerrains Terrain { get { return m_Terrain; } set { m_Terrain = value; } }

        private List<GeoBuild> m_Constructions;
        [CommandProperty(AccessLevel.Batisseur)]
        public List<GeoBuild> Constructions { get { return m_Constructions; } set { m_Constructions = value; } }

        private GeoBuild m_Projet;
        [CommandProperty(AccessLevel.Batisseur)]
        public GeoBuild Projet { get { return m_Projet; } set { m_Projet = value; } }

        private GeoMilitaire m_Armee;
        [CommandProperty(AccessLevel.Batisseur)]
        public GeoMilitaire Armee { get { return m_Armee; } set { m_Armee = value; } }

        private GeoRev m_Revolte;
        [CommandProperty(AccessLevel.Batisseur)]
        public GeoRev Revolte { get { return m_Revolte; } set { m_Revolte = value; } }

        private List<GeoConseiller> m_Conseillers;
        [CommandProperty(AccessLevel.Batisseur)]
        public List<GeoConseiller> Conseillers { get { return m_Conseillers; } set { m_Conseillers = value; } }

        private List<GeoMembre> m_Citoyens;
        [CommandProperty(AccessLevel.Batisseur)]
        public List<GeoMembre> Citoyens { get { return m_Citoyens; } set { m_Citoyens = value; } }

        //private int m_Taille;
        //[CommandProperty(AccessLevel.GameMaster)]
        //public int Taille { get { return m_Taille; } set { m_Taille = value; } }

        private int m_Aides;
        [CommandProperty(AccessLevel.Batisseur)]
        public int Aides { get { return m_Aides; } set { m_Aides = value; } }

        private int m_Octroi;
        [CommandProperty(AccessLevel.Batisseur)]
        public int Octroi { get { return m_Octroi; } set { m_Octroi = value; } }

        private int m_Taillon;
        [CommandProperty(AccessLevel.Batisseur)]
        public int Taillon { get { return m_Taillon; } set { m_Taillon = value; } }

        private int m_Traites;
        [CommandProperty(AccessLevel.Batisseur)]
        public int Traites { get { return m_Traites; } set { m_Traites = value; } }

        private int m_Aides4Cas;
        [CommandProperty(AccessLevel.Batisseur)]
        public int Aides4Cas { get { return m_Aides4Cas; } set { m_Aides4Cas = value; } }

        private int m_Dime;
        [CommandProperty(AccessLevel.Batisseur)]
        public int Dime { get { return m_Dime; } set { m_Dime = value; } }

        private int m_Tresorerie;
        [CommandProperty(AccessLevel.Batisseur)]
        public int Tresorerie { get { return m_Tresorerie; } set { m_Tresorerie = value; } }

        private int m_TresorerieReligion;
        [CommandProperty(AccessLevel.Batisseur)]
        public int TresorerieReligion { get { return m_TresorerieReligion; } set { m_TresorerieReligion = value; } }

        private GeoController m_Liege;
        [CommandProperty(AccessLevel.Batisseur)]
        public GeoController Liege { get { return m_Liege; } set { m_Liege = value; } }

        private Mobile m_Owner;
        [CommandProperty(AccessLevel.Batisseur)]
        public Mobile Owner { get { return m_Owner; } set { m_Owner = value; } }

        private DateTime m_LastUpdate;
        [CommandProperty(AccessLevel.Batisseur)]
        public DateTime LastUpdate { get { return m_LastUpdate; } set { m_LastUpdate = value; } }

        private UpdateTimer m_updateTimer;
        [CommandProperty(AccessLevel.Batisseur)]
        public UpdateTimer InternalUpdateTimer { get { return m_updateTimer; } set { m_updateTimer = value; } }

        [Constructable]
        public GeoController() : base(7187)
        {
            Weight = 0.0;
            Name = "Geopolitique";
            //Movable = false;
            m_Liege = null;
            m_Terrain = GeoTerrains.Plaine;

            m_Constructions = new List<GeoBuild>();
            m_Conseillers = new List<GeoConseiller>();
            m_Citoyens = new List<GeoMembre>();

            m_Projet = new GeoBuild();
            m_Armee = new GeoMilitaire();
            m_Revolte = new GeoRev();

            m_LastUpdate = DateTime.Now;
            m_updateTimer = new UpdateTimer(this, TimeSpan.FromDays(1.0), TimeSpan.FromDays(1.0));
        }
        public override void OnDoubleClick(Mobile from)
        {
            if (m_Owner == null)
            {
                m_Owner = from;
                from.SendGump(new GeoMaitre(from, this, GeoTabs.Index));
            }
            else if (from.Serial == m_Owner.Serial)
            {
                from.SendGump(new GeoMaitre(from, this, GeoTabs.Index));
            }
            else
            {
                bool member = false;
                for (int i = 0; i < Conseillers.Count; i++)
                {
                    if (Conseillers[i].Mob.Serial == from.Serial)
                    {
                        from.SendGump(new GeoMaitre(from, this, GeoTabs.Index));
                        member = true;
                    }
                }
                for (int i = 0; i < Citoyens.Count; i++)
                {
                    if (Citoyens[i].Mob.Serial == from.Serial)
                    {
                        from.SendGump(new GeoCitoyen(from, this, GeoTabs.Index, Citoyens[i]));
                        member = true;
                    }
                }
                if (!(member))
                    from.SendGump(new GeoEtranger(from, this, GeoTabs.Index, false));
            }

            //base.OnDoubleClick(from);
        }

        public bool Update()
        {
            if (LastUpdate.AddDays(7) < DateTime.Now)
            {
                int revenues = 0;

                for (int i = 0; i < Constructions.Count; i++)
                {
                    if (Constructions[i].Effet == GeoEffet.Revenues)
                        revenues += Constructions[i].EffetLevel;
                }
                for (int i = 0; i < Citoyens.Count; i++)
                {
                    if (Citoyens[i].Taxe > 0)
                    {
                        revenues += Citoyens[i].Taxe;
                    }
                    if (Citoyens[i].Salaire > 0)
                    {
                        revenues -= Citoyens[i].Salaire;
                    }
                }
                for (int i = 0; i < Conseillers.Count; i++)
                {
                    if (Conseillers[i].Salaire > 0)
                        revenues -= Conseillers[i].Salaire;
                }

                if (revenues + Tresorerie > 0)
                {
                    m_LastUpdate = DateTime.Now;
                    //On paye les salaires et prend les taxes une fois qu'on sait que tout est equilibre.
                    for (int i = 0; i < Citoyens.Count; i++)
                    {
                        if (Citoyens[i].Salaire > 0)
                        {
                            Citoyens[i].SalaireTresorerie += Citoyens[i].Salaire;
                            Tresorerie -= Citoyens[i].Salaire;
                        }
                        if (Citoyens[i].TaxeTresorerie >= Citoyens[i].Taxe)
                        {
                            Tresorerie += Citoyens[i].Taxe;
                            Citoyens[i].TaxeTresorerie -= Citoyens[i].Taxe;
                            Citoyens[i].TaxePayer = true;
                        }
                        else
                        {
                            Citoyens[i].TaxePayer = false;
                        }
                        if (Citoyens[i].DimeTresorerie >= Citoyens[i].Dime)
                        {
                            TresorerieReligion += Citoyens[i].Dime;
                            Citoyens[i].DimeTresorerie -= Citoyens[i].Dime;
                            Citoyens[i].DimePayer = true;
                        }
                        else
                        {
                            Citoyens[i].DimePayer = false;
                        }
                    }
                    return true;
                }
                else
                {
                    //from.SendMessage("Les couts sont plus grands que vos revenues, balancez le tout pour la mise a jour de la geopolitique !");
                    return false;
                }
            }
            return false;
        }

        public class UpdateTimer : Timer
        {
            private GeoController m_control;

            public UpdateTimer(GeoController controller, TimeSpan delay, TimeSpan interval)
                : base(delay, interval)
            {
                Priority = TimerPriority.TwentyFiveMS;
                m_control = controller;
                Start();
            }

            protected override void OnTick()
            {
                m_control.Update();
            }
        }

        public GeoController(Serial serial) : base(serial)
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

            /*switch (version)
            {
                case 1:

                    break;
            }*/
        }
    }
}
