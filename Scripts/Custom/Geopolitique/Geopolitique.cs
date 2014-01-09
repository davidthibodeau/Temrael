
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Server;
using Server.Commands;

namespace Server.Systemes.Geopolitique
{
    public class Geopolitique
    {
        public static Categorie geopolitique;
        public static List<TypeTerre> types;

        public static void Configure()
        {
            EventSink.WorldLoad += new WorldLoadEventHandler(Load);
            EventSink.WorldSave += new WorldSaveEventHandler(Save);
        }

        public static void Initialize()
        {
            CommandSystem.Register("geopol", AccessLevel.GameMaster, new CommandEventHandler(Geopol_OnCommand));
        }

        [Usage("Geopol")]
        [Description("Ouvre le menu de rentes et géopolitique.")]
        public static void Geopol_OnCommand(CommandEventArgs e)
        {
            Mobile caller = e.Mobile;

            if (caller.HasGump(typeof(GeopolGump)))
                caller.CloseGump(typeof(GeopolGump));
            caller.SendGump(new GeopolGump(caller, geopolitique));
        }

        public static void Load()
        {
            string filePath = Path.Combine("Saves/Geopolitique", "terres.xml");

            if (!File.Exists(filePath))
            {
                geopolitique = new Categorie(null, "");
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlElement root = doc["geopolitique"];
            if (root == null)
            {
                Console.WriteLine("ERREUR: Impossible de loader la categorie principale du systeme de Geopolitique.");
            }
            geopolitique = new Categorie(null, root);

            types = new List<TypeTerre>();
            foreach (XmlElement ele in doc.GetElementsByTagName("type"))
            {
                types.Add(new TypeTerre(ele));
            }
        }

        public static void Save(WorldSaveEventArgs e)
        {
            if (!Directory.Exists("Saves/Geopolitique"))
                Directory.CreateDirectory("Saves/Geopolitique");

            string filePath = Path.Combine("Saves/Geopolitique", "terres.xml");

            using (StreamWriter op = new StreamWriter(filePath))
            {
                XmlTextWriter xml = new XmlTextWriter(op);

                xml.Formatting = Formatting.Indented;
                xml.IndentChar = '\t';
                xml.Indentation = 1;

                xml.WriteStartDocument(true);

                xml.WriteStartElement("geopolitique");

                geopolitique.Save(xml);

                xml.WriteEndElement();

                foreach (TypeTerre tt in types)
                {
                    xml.WriteStartElement("type");
                    tt.Save(xml);
                    xml.WriteEndElement();
                }
          
                xml.Close();
            }
        }
    }   
}