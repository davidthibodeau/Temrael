using System;

namespace Server.Items
{
    [Flipable(0x1224, 0x139A)]
	public class sculpturePetiteFemme : Item
	{
		[Constructable]
        public sculpturePetiteFemme()
            : base(0x1224)
		{
			Weight = 2;
            Name = "Petite Sculpture de Femme";
		}

        public sculpturePetiteFemme(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}

    [Flipable(0x1225, 0x139C)]
    public class sculpturePetiteHomme : Item
    {
        [Constructable]
        public sculpturePetiteHomme()
            : base(0x1225)
        {
            Weight = 2;
            Name = "Petite Sculpture d'Homme";
        }

        public sculpturePetiteHomme(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x1226, 0x139B)]
    public class sculpturePetiteTieffelin : Item
    {
        [Constructable]
        public sculpturePetiteTieffelin()
            : base(0x1226)
        {
            Weight = 2;
            Name = "Petite Sculpture de Tieffelin";
        }

        public sculpturePetiteTieffelin(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class sculpturePetiteAasimar : Item
    {
        [Constructable]
        public sculpturePetiteAasimar()
            : base(0x1227)
        {
            Weight = 2;
            Name = "Petite Sculpture d'Aasimar";
        }

        public sculpturePetiteAasimar(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x1228, 0x139D)]
    public class sculpturePetiteAigle : Item
    {
        [Constructable]
        public sculpturePetiteAigle()
            : base(0x1228)
        {
            Weight = 2;
            Name = "Petite Sculpture d'Aigle";
        }

        public sculpturePetiteAigle(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class sculptureEtoileDeMer : Item
    {
        [Constructable]
        public sculptureEtoileDeMer()
            : base(0x1C10)
        {
            Weight = 2;
            Name = "Sculpture D'Étoile de Mer";
        }

        public sculptureEtoileDeMer(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class sculpturePoisson : Item
    {
        [Constructable]
        public sculpturePoisson()
            : base(0x1C0E)
        {
            Weight = 2;
            Name = "Sculpture de Poisson";
        }

        public sculpturePoisson(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x147E, 0x147F, 0x1480, 0x1481)]
    public class statutCulteHelionSoleil : Item
    {
        [Constructable]
        public statutCulteHelionSoleil()
            : base(0x147E)
        {
            Weight = 2;
            Name = "Statut du Culte D'Hélion (Soleil)";
        }

        public statutCulteHelionSoleil(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x1482, 0x1483, 0x1484, 0x1485)]
    public class statutCulteHelionLune : Item
    {
        [Constructable]
        public statutCulteHelionLune()
            : base(0x1482)
        {
            Weight = 2;
            Name = "Statut du Culte D'Hélion (Lune)";
        }

        public statutCulteHelionLune(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x1488, 0x1489)]
    public class statutDuCroise : Item
    {
        [Constructable]
        public statutDuCroise()
            : base(0x1488)
        {
            Weight = 2;
            Name = "Statut du Croisé";
        }

        public statutDuCroise(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x148A, 0x148B)]
    public class statutDeCaron : Item
    {
        [Constructable]
        public statutDeCaron()
            : base(0x148A)
        {
            Weight = 2;
            Name = "Statut de Caron";
        }

        public statutDeCaron(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x148C, 0x148D)]
    public class statutChuteDeRaziel : Item
    {
        [Constructable]
        public statutChuteDeRaziel()
            : base(0x148C)
        {
            Weight = 2;
            Name = "Statut de la Chute de Raziel";
        }

        public statutChuteDeRaziel(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x148E, 0x148F)]
    public class statutRaziel : Item
    {
        [Constructable]
        public statutRaziel()
            : base(0x148E)
        {
            Weight = 2;
            Name = "Statut de Raziel";
        }

        public statutRaziel(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x1490, 0x1491)]
    public class statutGuerrier : Item
    {
        [Constructable]
        public statutGuerrier()
            : base(0x1490)
        {
            Weight = 2;
            Name = "Statut de Guerrier";
        }

        public statutGuerrier(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x1492, 0x1493)]
    public class statutChevalDuCaelum : Item
    {
        [Constructable]
        public statutChevalDuCaelum()
            : base(0x1492)
        {
            Weight = 2;
            Name = "Statut de Cheval Du Caelum";
        }

        public statutChevalDuCaelum(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x149F, 0x14A0)]
    public class sigleMuralDivinAssasin : Item
    {
        [Constructable]
        public sigleMuralDivinAssasin()
            : base(0x149F)
        {
            Weight = 2;
            Name = "Sigle Mural Divin d'Assasin";
        }

        public sigleMuralDivinAssasin(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x14A1, 0x14A2)]
    public class sigleMuralDivinBatisseur : Item
    {
        [Constructable]
        public sigleMuralDivinBatisseur()
            : base(0x14A1)
        {
            Weight = 2;
            Name = "Sigle Mural Divin du Bâtisseur";
        }

        public sigleMuralDivinBatisseur(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x14A3, 0x14A4)]
    public class sigleMuralDivinCaron : Item
    {
        [Constructable]
        public sigleMuralDivinCaron()
            : base(0x14A3)
        {
            Weight = 2;
            Name = "Sigle Mural Divin du Caron";
        }

        public sigleMuralDivinCaron(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x14A5, 0x14A6)]
    public class sigleMuralDivinChasseresse : Item
    {
        [Constructable]
        public sigleMuralDivinChasseresse()
            : base(0x14A5)
        {
            Weight = 2;
            Name = "Sigle Mural Divin de la Chasseresse";
        }

        public sigleMuralDivinChasseresse(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x14A7, 0x14A8)]
    public class sigleMuralDivinCroise : Item
    {
        [Constructable]
        public sigleMuralDivinCroise()
            : base(0x14A7)
        {
            Weight = 2;
            Name = "Sigle Mural Divin du Croisé";
        }

        public sigleMuralDivinCroise(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x14A9, 0x14AA)]
    public class sigleMuralDivinGeneral : Item
    {
        [Constructable]
        public sigleMuralDivinGeneral()
            : base(0x14A9)
        {
            Weight = 2;
            Name = "Sigle Mural Divin du Général";
        }

        public sigleMuralDivinGeneral(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x14AB, 0x14AC)]
    public class sigleMuralDivinGuerrier : Item
    {
        [Constructable]
        public sigleMuralDivinGuerrier()
            : base(0x14AB)
        {
            Weight = 2;
            Name = "Sigle Mural Divin du Guerrier";
        }

        public sigleMuralDivinGuerrier(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x14AD, 0x14AE)]
    public class sigleMuralDivinMephis : Item
    {
        [Constructable]
        public sigleMuralDivinMephis()
            : base(0x14AD)
        {
            Weight = 2;
            Name = "Sigle Mural Divin de Méphis";
        }

        public sigleMuralDivinMephis(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x14AF, 0x14B0)]
    public class sigleMuralDivinMere : Item
    {
        [Constructable]
        public sigleMuralDivinMere()
            : base(0x14AF)
        {
            Weight = 2;
            Name = "Sigle Mural Divin de la Mère";
        }

        public sigleMuralDivinMere(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x14B1, 0x14B2)]
    public class sigleMuralDivinRaziel : Item
    {
        [Constructable]
        public sigleMuralDivinRaziel()
            : base(0x14B1)
        {
            Weight = 2;
            Name = "Sigle Mural Divin de Raziel";
        }

        public sigleMuralDivinRaziel(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x14B3, 0x14B4)]
    public class sigleMuralDivinSorciere : Item
    {
        [Constructable]
        public sigleMuralDivinSorciere()
            : base(0x14B3)
        {
            Weight = 2;
            Name = "Sigle Mural Divin de la Sorcière";
        }

        public sigleMuralDivinSorciere(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x14B5, 0x14B6)]
    public class sigleMuralDivinVierge : Item
    {
        [Constructable]
        public sigleMuralDivinVierge()
            : base(0x14A1)
        {
            Weight = 2;
            Name = "Sigle Mural Divin de la Vierge";
        }

        public sigleMuralDivinVierge(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}