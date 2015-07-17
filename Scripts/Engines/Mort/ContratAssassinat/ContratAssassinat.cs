using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Mort
{
    public class ContratAssassinat
    {
        static public String DefaultExplication()
        {
            return "Aucune explication";
        }

        public Mobile Commanditaire;
        public Mobile Assassin;
        public Mobile Cible;
        public String Explication;

        public ContratAssassinat()
        {
            Commanditaire = null;
            Assassin = null;
            Cible = null;

            Explication = DefaultExplication();
        }

        public ContratAssassinat(Mobile commanditaire, Mobile assassin, Mobile cible, String explication)
            : this()
        {
            if(commanditaire != null)
                Commanditaire = commanditaire;

            if( assassin != null)
                Assassin = assassin;

            if(cible != null)
                Cible = cible;

            if( explication != null)
                Explication = explication;
        }

        public static void Serialize(GenericWriter writer, ContratAssassinat contrat)
        {
            writer.Write(contrat.Commanditaire);
            writer.Write(contrat.Assassin);
            writer.Write(contrat.Cible);
            writer.Write(contrat.Explication);
        }

        public static ContratAssassinat Deserialize(GenericReader reader)
        {
            Mobile commanditaire = reader.ReadMobile();
            Mobile assassin = reader.ReadMobile();
            Mobile cible = reader.ReadMobile();
            String explication = reader.ReadString();

            return new ContratAssassinat(commanditaire, assassin, cible, explication);
        }
    }
}
