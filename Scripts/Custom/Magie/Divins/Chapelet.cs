using System;
using Server.Mobiles;
using Server.Spells;

namespace Server.Items
{
	public class Chapelet : BaseClothing
	{
        private bool m_Benit;

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Benit
        {
            get { return m_Benit; }
            set { m_Benit = value; }
        }

		[Constructable]
        public Chapelet()
            : base(0x265E)
		{
			Weight = 2.0;
            Name = "chapelet";
            Layer = Layer.Waist;
		}

        public Chapelet(Serial serial) : base(serial)
		{
		}

        public override void OnSingleClick(Mobile from)
        {
            base.OnSingleClick(from);

            if (Parent != null && (Parent == from || Parent == from.Backpack))
                LabelTo(from, "[bénit]");
        }

        public override void OnDoubleClick(Mobile from)
        {
            //Item waist = from.FindItemOnLayer(Layer.Waist);
            TMobile m = from as TMobile;

            if (m != null)
            {
                /*if (waist != this)
                {
                    m.SendMessage("Vous devez avoir le chapelet autour de la taille pour prier.");
                }
                else if (!m_Benit)
                {
                    m.SendMessage("Votre chapelet doit être bénit pour prier.");
                }*/
                if (m.Dieux == Dieux.Aucune)
                {
                    m.SendMessage("Vous devez voir un pretre de la religion pour pouvoir convertir a celle-ci.");
                }
                else if (m.GetAptitudeValue(NAptitude.GraceDivine) <= 0)
                {
                    m.SendMessage("Vous devez avoir au moins un point de Grace Divine pour user le chapelet.");
                }
                else
                {
                    m.SendGump(new Religion.ReligionGump(m, 0));
                }
            }
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );

            writer.Write(m_Benit);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            m_Benit = reader.ReadBool();
		}
	}
}