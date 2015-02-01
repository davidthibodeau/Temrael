using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Mort
{
    public class ContratAssassinat
    {
        public Mobile Commanditaire;
        public Mobile Assassin;
        public Mobile Cible;

        public String Explication;

        public ContratAssassinat()
        {
            Commanditaire = new Mobile();
            Assassin = new Mobile();
            Cible = new Mobile();

            Commanditaire.Name = "Aucun";
            Assassin.Name = "Aucun";
            Cible.Name = "Aucun";

            Explication = "Aucune explication";
        }

        public ContratAssassinat(Mobile commanditaire, Mobile assassin, Mobile cible, String explication)
        {
            Commanditaire = commanditaire;
            Assassin = assassin;
            Cible = cible;

            Explication = explication;
        }
    }
}
