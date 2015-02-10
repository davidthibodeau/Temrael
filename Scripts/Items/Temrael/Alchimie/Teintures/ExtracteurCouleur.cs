using System;
using Server.Network;
using Server.Targeting;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    class ExtracteurCouleur : Item
    {
        public override int GoldValue { get { return 100; } }

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
            from.SendMessage("Choisissez la ressource de laquelle vous voulez extraire la couleur. Cela détruira l'extracteur.");
            from.BeginTarget(1, false, TargetFlags.None, new TargetCallback(this.ChooseTarget_OnTarget));
        }

        public void ChooseTarget_OnTarget(Mobile from, object targeted)
        {
            if (!from.Backpack.AcquireItems().Contains(this))
            {
                from.SendMessage("L'extracteur doit se trouver dans votre sac.");
                return;
            }

            if (targeted is IExtractable)
            {
                Item item = ((Item)targeted);

                if (!from.Backpack.AcquireItems().Contains(item))
                {
                    from.SendMessage("La ressource doit se trouver dans votre sac.");
                    return;
                }

                if (item.Amount < 5)
                {
                    from.SendMessage("Vous devez avoir au moins 5 morceaux de ce matériau.");
                    return;
                }

                from.SendMessage((from.Skills[SkillName.Alchimie].Value).ToString());
                from.SendMessage((((IExtractable)targeted).getSkillReq).ToString());

                if (from.Skills[SkillName.Alchimie].Value >= ((IExtractable)targeted).getSkillReq )
                {
                    from.AddToBackpack(new TeintureModif((IExtractable)targeted));
                    item.Consume(5);
                    from.SendMessage("La teinture est créée.");
                    Delete();
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
