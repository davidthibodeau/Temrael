using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server
{
    public enum ClasseType
    {
        None = -1,
        Archer = 0,
        Barbare,
        Guerrier,
        Cavalier,
        Duelliste,
        Protecteur,
        Champion,

        //Mages
        Magicien,
        Sorcier,
        Necromancien,
        Illusioniste,
        Conjurateur,

        //Roublard
        Espion,
        Rodeur,
        Assassin,
        Voleur,
        Barde,

        Artisan,

        Pretre,
        Paladin,
        PaladinDechu,

        Maximum //pour comptage
    }

    public enum ClasseBranche
    {
        Aucun,
        Guerrier,
        Roublard,
        Magie,
        Cleric,
        Artisan
    }







}