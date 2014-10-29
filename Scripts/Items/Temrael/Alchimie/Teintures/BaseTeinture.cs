using System;
using Server.Network;
using Server.Targeting;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public abstract class BaseTeinture : Item
    {
        public virtual int Couleur { get { return 0; } }

        public override void OnDoubleClick(Mobile from)
        {
            //base.OnDoubleClick(from);

            from.SendMessage("Choisissez un bac de colorant pour appliquer la teinture.");
            from.BeginTarget(1, false, TargetFlags.None, new TargetCallback(this.ChooseTarget_OnTarget));
        }

        public BaseTeinture(int itemID) : base(itemID)
        {
        }

        public BaseTeinture(Serial s)
            : base(s)
        {
        }

        public void ChooseTarget_OnTarget(Mobile from, object targeted)
        {
            if (targeted is BaseArmor)
            {
                ((BaseArmor)targeted).Hue = Couleur;
                from.SendMessage("Teinture appliquée.");
                this.Delete();
            }
            else if (targeted is BaseWeapon)
            {
                ((BaseWeapon)targeted).Hue = Couleur;
                from.SendMessage("Teinture appliquée.");
                this.Delete();
            }
            else if (targeted is DyeTub)
            {
                ((DyeTub)targeted).Hue = Couleur;
                from.SendMessage("Teinture appliquée.");
                this.Delete();
            }
            else
            {
                from.SendMessage("Ceci n'est pas un bac de teinture.");
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
