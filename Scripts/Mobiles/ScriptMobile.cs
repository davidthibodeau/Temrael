using Server.Engines.Hiding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.SkillHandlers;
using Server.Misc.PVP;

namespace Server.Mobiles
{
    public class ScriptMobile : Mobile
    {
        public PVPEvent CurrentPVPEventInstance; // null == pas sur un terrain de PVP atm.

        [CommandProperty(AccessLevel.Batisseur)]
        public virtual Detection Detection
        {
            get;
            set;
        }

        public ScriptMobile()
        {
            Detection = new Detection(this);
        }

        public ScriptMobile(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); //version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            Detection = new Detection(this);
        }

        public override bool Move(Direction d)
        {
            bool retour = base.Move(d);

            ActiverTestsDetection();

            return retour;
        }

        public override bool CanSee(Mobile m)
        {
            try
            {
                ScriptMobile sm = m as ScriptMobile;
                if (sm.Detection[this] == DetectionStatus.Visible)
                    return true;
            }
            catch { }

            return base.CanSee(m);
        }

        public void ActiverTestsDetection()
        {
            //Le systeme de detection fonctionne juste pour les joueurs.
            Detection.DetecterAlentours();
        }

        public override void OnHiddenChanged()
        {
            base.OnHiddenChanged();
            Detection.ResetAlentours();
        }

        public override void Damage(int amount)
        {
            Damage(amount, null);
        }

        public override void RevealingAction()
        {
            if(Hidden)
                NextSkillTime = Core.TickCount + (int)(Stealth.TempsJetRate).TotalMilliseconds;

            base.RevealingAction();
        }

        public override void Damage(int amount, Mobile from)
        {
            if (!CurrentPVPEventInstance.mode.AllowFriendlyDamage(this, from))
            {
                return;
            }

            double damage = amount;

            SacrificeSpell.GetOnHitEffect(this, ref damage);

            DernierSouffleSpell.GetOnHitEffect(this, ref damage);

            AdrenalineSpell.GetOnHitEffect(this, ref damage);

            Stam -= (int)(amount * 0.60);

            if (BandageContext.m_Table.Contains(this))
                BandageContext.GetContext(this).Slip();

            base.Damage((int)damage, from);
        }
    }
}
