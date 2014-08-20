using System;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Spells;
using System.IO;
using Server.Commands;

namespace Server.Misc
{
    public class ScrollGenerator
    {
        public static void Initialize()
        {
            CommandSystem.Register("scrollgen", AccessLevel.Coordinateur, new CommandEventHandler(OnScrollGen));
        }

        #region Template
        private static string m_TemplatePrefix = @"using System;
using Server;

namespace Server.Items
{";

        private static string m_Template = @"
	[FlipableAttribute( {scrollappearance}, {scrollappearancea} )]
	public class {spelltype}Scroll : SpellScroll
	{
		[Constructable]
		public {spelltype}Scroll() : this( 1 )
		{
		}

		[Constructable]
		public {spelltype}Scroll( int amount ) : base( {spellid}, {scrollappearance}, amount )
		{
			Name = ""{namer}"";
            Hue = {huer};
		}

		public {spelltype}Scroll( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
";

        private static string m_TemplateSuffixe = @"}";
        #endregion

        public static int[] m_CerclesHue = new int[] { 0, 1701, 1446, 1328, 1201, 1102, 1719, 1428, 1237 };

        [Usage("ScrollGen"),
        Description("Brings up the item script generator gump.")]
        private static void OnScrollGen(CommandEventArgs e)
        {
            string m_TotalTemplate = m_TemplatePrefix;

            for (int i = 0; i < 105; i++)
            {
                Aptitude entry = (Aptitude)i;
                // DivineSpellBookEntry entry = (DivineSpellBookEntry)NewDivineSpellbookGump.m_DivineSpellBookEntry[i];

                //string name = entry.Nom;
                //int scrollappearance = 7971;
                //int scrollappearancea = 7971;
                //Spell spell = SpellRegistry.NewSpell(entry.SpellID, e.Mobile, null);
                //int SpellID = entry.SpellID;
                //int hue = m_CerclesHue[entry.Cercle];

                //if (spell != null)
                //{
                //Type spelltype = spell.GetType();

                //if (spelltype != null && name != null && scrollappearance != 0)
                //{
                //string final = m_Template;

                string final = @"
        [CommandProperty(AccessLevel.GameMaster)]
        public double {conn}
        {
            get { return this[NAptitude.{conn}]; }
            set { this[NAptitude.{conn}] = value; }
        }
";
                final = final.Replace("{conn}", entry.ToString());
                //final = final.Replace("{scrollappearance}", scrollappearance.ToString());
                //final = final.Replace("{scrollappearancea}", scrollappearancea.ToString());
                //final = final.Replace("{spelltype}", spelltype.Name);
                //final = final.Replace("{spellid}", SpellID.ToString());
                //final = final.Replace("{huer}", hue.ToString());

                //m_TotalTemplate = m_TotalTemplate + final;

                m_TotalTemplate = m_TotalTemplate + final;
                //}
                //}
                
            }

            m_TotalTemplate = m_TotalTemplate + m_TemplateSuffixe;

            StreamWriter writer = null;

            string path = "TheBox\\" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString();

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            path = Path.Combine(path, string.Format(@"{0}.txt", "Connaissances"));
            writer = new StreamWriter(path, false);
            writer.Write(m_TotalTemplate);

            e.Mobile.SendMessage(0x40, "Scrolls" + " saved to {0}", path);

            if (writer != null)
                writer.Close();
        }
    }
}