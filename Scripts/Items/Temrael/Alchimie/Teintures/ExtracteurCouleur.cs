using System;
using Server.Network;
using Server.Targeting;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    class ExtracteurCouleur : Item
    {
        [Constructable]
        public ExtracteurCouleur() : base(0x1849)
        {
            Name = "Extracteur de couleurs";
        }

        public ExtracteurCouleur(Serial s)
            : base(s)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            from.SendMessage("Choisissez la ressource de laquelle vous voulez extraire la couleur.");
            from.BeginTarget(1, false, TargetFlags.None, new TargetCallback(this.ChooseTarget_OnTarget));
        }

        public void ChooseTarget_OnTarget(Mobile from, object targeted)
        {
            if (targeted is IExtractable)
            {
                if (from.Skills[SkillName.Alchimie].Value >= 50)
                {
                    from.AddToBackpack(new TeintureModif((IExtractable)targeted));
                    from.SendMessage("La teinture est créée.");
                }
                else
                {
                    from.SendMessage("La méthode d'extraction vous semble trop complexe.");
                }
            }
            else
            {
                from.SendMessage("Ceci n'est pas une ressource.");
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
