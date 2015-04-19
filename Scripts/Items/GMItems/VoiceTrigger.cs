using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Mobiles;
using Server.Engines.Langues;

namespace Server.Items.GMItems
{
    class VoiceTrigger : Item
    {
        int m_Range;
        string m_Keyword;
        Langue m_Langue;

        [CommandProperty(AccessLevel.Batisseur)]
        public int Range
        {
            get { return m_Range; }
            set { m_Range = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public string Keyword
        {
            get { return m_Keyword; }
            set { m_Keyword = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public Langue Langue
        {
            get { return m_Langue; }
            set { m_Langue = value; }
        }


        public override bool HandlesOnSpeech { get { return true; } }

        public override void OnSpeech(SpeechEventArgs e)
        {
            if (!e.Handled)
            {
                Mobile m = e.Mobile;

                if (!m.InRange(GetWorldLocation(), m_Range))
                    return;

                if (e.Mobile is PlayerMobile)
                {
                    PlayerMobile p = (PlayerMobile)e.Mobile;

                    if (p.Langues.CurrentLangue == m_Langue)
                    {
                        if (m_Keyword != null)
                        {
                            if (e.Speech.ToLower().Contains(m_Keyword.ToLower()))
                            {
                                Trap_OnActivate(e.Mobile);
                                e.Handled = true;
                            }
                        }
                    }
                }
            }
        }


        [Constructable]
        public VoiceTrigger() : base(0x0FAA)
		{
            m_Range = 3;
            m_Keyword = null;
            m_Langue = Langue.Commune;
            Visible = false;
		}

		public VoiceTrigger( Serial serial ) : base( serial )
		{
		}

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write(m_Keyword);
            writer.Write(m_Range);
            writer.Write((int)m_Langue);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_Keyword = reader.ReadString();
            m_Range = reader.ReadInt();
            m_Langue = (Langue)reader.ReadInt();
        }

    }
}
