using System;

namespace Server.Items
{
    public enum PlantType
    {
        None,
        Gui,
        Inule,
        Benoite,
        Solidago,
        Gomphrena,
        Lavatere,
        Passiflore,
        Millepertuis,
        Artichaut,
        Immortelle,
        Melaleuca,
        Bourrache,
        Kalmia,
        Paquerette,
        Asphodeline,
        Airelle,
        Liseron,
        Agastache,
        Chicore,
        Achillee,
        Ciste,
        Aconit,
        Adonis,
        Buplevre,
        Souci,
        Sauge,
        Zanthoxylum,
        Nielle,
        Betoine,
        Tanaisie,
        Lin,
        Coton
    }

    public enum RegeantType
    {
        None
    }

    public enum EarthType
    {
        None,
        Forest,
        Jungle,
        Desert,
        Dirt,
        Swamp
    }

    public enum StateOfGrowth
    {
        None,
        Seed,
        Germ,
        Young,
        Mature,
        Deterioration
    }

    public enum StateOfPollination
    {
        None,
        Florissement,
        TransmissionPollen,
        ChuteFlorale,
        FormationFruit,
        MurrisementFruit,
        ChuteFruit
    }

    public enum StateOfHydration
    {
        Low,
        Medium,
        High,
        Drowned
    }

    public enum Insects
    {
        None,
        Chenilles,
        Doryphores,
        Limaces,
        PercesOreilles,
        Pucerons,
        Sauterelles,
        Ver
    }

    public enum Disease
    {
        None,
        Aleurodes,
        Armillaire,
        Cecidomyie,
        Chancre,
        Fumagine,
        Nematode,
        Noctuelle,
        Psylle,
        Rouille,
        Tavelure,
        Thrips
    }

    public enum Manure
    {
        None,
        Type01,
        Type02
    }

    public enum Fungi
    {
        None,
        ChampignonALamelle,
        Bolet,
        Polyphores,
        Phalles,
        Vesses,
        Gesastres
    }

    public enum CauseOfDie
    {
        None,
        TooOld,
        NotHydrated,
        TooHydrated,
        Insects,
        Disease,
        Fungi,
        Poison
    }

    public enum PlantPoison
    {
        None,
        Empoisonnee
    }
}