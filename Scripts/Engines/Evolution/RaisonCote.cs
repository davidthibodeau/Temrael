using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Evolution
{
    public class RaisonCote
    {
        public static string GetMessage(byte message)
        {
            switch (message)
            {
                default:
                case 0: return "Continuez votre bon roleplay.";
            }
        }

        private byte message;
        private DateTime timestamp;
        private Mobile auteur;

        public string Message { get { return GetMessage(message); } }
        public DateTime Timestamp { get { return timestamp; } }
        public Mobile Auteur { get { return auteur; } }

        public RaisonCote(Mobile from, byte msg)
        {
            message = msg;
            auteur = from;
            timestamp = DateTime.Now;
        }
    }
}
