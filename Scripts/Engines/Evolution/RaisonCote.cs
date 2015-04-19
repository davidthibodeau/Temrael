using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Evolution
{
    public class RaisonCote
    {
        public static string GetMessage(int message)
        {
            switch (message)
            {
                default:
                case 0: return "Continuez votre bon roleplay."; // normal
                case 1: return "Vous étiez AFK."; // interdit
                case 100: return "Vous devriez faire de l'interaction roleplay avec les gens autour."; //passable
                case 200: return "L'isolement volontaire est à éviter puisque le jeu vise les interactions roleplay."; //questionnable 
                case 201: return "Faites attention au fair play. C'est un jeu pour lequel il faut accepter de perdre aussi."; //questionnable
                case 300: return "Les insultes à caractère HRP sont à proscrire. Les interactions doivent rester entre personnages."; //interdit
                case 301: return "Vous vous devez d'être roleplay en tout temps et de toujours incarner votre personnage."; //interdit
                case 302: return "L'abus d'un bug est interdit et le bug devrait être présenté à l'équipe plutôt qu'utilisé."; //interdit
                case 202: return "Vos émotes ne peuvent que décrire les actions et non les pensées de votre personnage. Le pensequetage est donc à proscrire."; // questionnable
            }
        }

        public static string GetGMMessage(int message)
        {
            switch (message)
            {
                default:
                case 0: return "Roleplay acceptable.";
                case 1: return "AFK.";
                case 100: return "Aucun RP avec joueurs à proximité";
                case 200: return "Isolement volontaire";
                case 201: return "Manque de fair play";
                case 300: return "Insulte à caractère hrp";
                case 301: return "Manque au roleplay";
                case 302: return "Abus de bug";
                case 202: return "Pensequetage";
            }
        }

        public static int LimiteMaximale(ValeurCote cote)
        {
            switch (cote)
            {
                default:
                case ValeurCote.Normal: return 0;
                case ValeurCote.Passable: return 100;
                case ValeurCote.Questionnable: return 202;
                case ValeurCote.Interdit: return 302;
            }
        }

        private int message;
        private DateTime timestamp;
        private Mobile auteur;

        public string Message { get { return GetMessage(message); } }
        public string GMMessage { get { return GetGMMessage(message); } }
        public DateTime Timestamp { get { return timestamp; } }
        public Mobile Auteur { get { return auteur; } }

        public RaisonCote(Mobile from, int msg)
        {
            message = msg;
            auteur = from;
            timestamp = DateTime.Now;
        }

        public RaisonCote(GenericReader reader)
        {
            int version = reader.ReadInt();

            if (version < 1)
                message = reader.ReadByte();
            else
                message = reader.ReadInt();
            timestamp = reader.ReadDateTime();
            auteur = reader.ReadMobile();
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write(1); //version

            writer.Write(message);
            writer.Write(timestamp);
            writer.Write(auteur);
        }
    }
}
