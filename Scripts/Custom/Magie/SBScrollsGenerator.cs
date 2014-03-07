using System;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Spells;
using System.IO;
using Server.Commands;

namespace Server.Misc
{
    public class SBScrollGenerator
    {
        public static void Initialize()
        {
            CommandSystem.Register("sbscrollgen", AccessLevel.Administrator, new CommandEventHandler(OnSBScrollGen));
        }

        public Aptitude[] m_ConnaissanceList = new Aptitude[] {
            Aptitude.Benedictions,    
            Aptitude.Fanatisme,    
            Aptitude.Monial,      
        };

        #region Template
        private static string m_TemplatePrefix = @"";
        //Add(typeof({spelltype}), {price});
        //Add(new GenericBuyInfo(typeof({spelltype}), {price}, Utility.RandomMinMax(3, 7), {scrollappearance}, {hue}));                 
        //Register({spellid}, typeof({spelltype}));
        //typeof({spelltype}),
        private static string m_Template = @"AddSpell(typeof({spelltype}), ""{nom}"", {connlevel});
";

        private static string m_TemplateSuffixe = @"";
        #endregion

        public static int[] m_CerclesID = new int[] { 0, 8003, 8001, 7999, 7997, 7993, 7987, 7989, 7985 };
        //public static int[] m_CerclesHue = new int[] { 0, 1701, 1446, 1328, 1201, 1102, 1719, 1428, 1237 };

        [Usage("ScrollGen"),
        Description("Brings up the item script generator gump.")]
        private static void OnSBScrollGen(CommandEventArgs e)
        {
            string m_TotalTemplate = m_TemplatePrefix;

            for (int i = 0; i < NewDivineSpellbookGump.m_DivineSpellBookEntry.Length; i++)
            {
                DivineSpellBookEntry entry = (DivineSpellBookEntry)NewDivineSpellbookGump.m_DivineSpellBookEntry[i];

                if (entry != null && entry.ConnaissanceLevel <= 4)
                {
                    int scrollappearance = m_CerclesID[entry.Cercle];
                    Spell spell = SpellRegistry.NewSpell(entry.SpellID, e.Mobile, null);
                    int price = entry.ConnaissanceLevel * 50;
                    int hue = 0;
                    string nom = entry.Nom;

                    if (spell != null)
                    {
                        Type spelltype = spell.GetType();

                        if (spelltype != null)//&& scrollappearance != 0
                        {
                            string final = m_Template;

                            final = final.Replace("{spellid}", entry.SpellID.ToString());
                            final = final.Replace("{scrollappearance}", scrollappearance.ToString());
                            final = final.Replace("{spelltype}", spelltype.Name);
                            final = final.Replace("{price}", price.ToString());
                            final = final.Replace("{hue}", hue.ToString());
                            final = final.Replace("{nom}", nom);
                            final = final.Replace("{connlevel}", entry.ConnaissanceLevel.ToString());

                            m_TotalTemplate = m_TotalTemplate + final;
                        }
                    }
                }
            }

            m_TotalTemplate = m_TotalTemplate + m_TemplateSuffixe;

            StreamWriter writer = null;

            string path = "TheBox\\" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString();

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            path = Path.Combine(path, string.Format(@"{0}.cs", "SBScrollsa"));
            writer = new StreamWriter(path, false);
            writer.Write(m_TotalTemplate);

            e.Mobile.SendMessage(0x40, "SBScrolls" + " saved to {0}", path);

            if (writer != null)
                writer.Close();
        }
    }
}