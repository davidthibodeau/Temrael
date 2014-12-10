using System;
using System.Reflection;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
    public class TransfertSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_Timers = new Hashtable();

        public static readonly new SpellInfo Info = new SpellInfo(
                "Transfert", "Tyros Otil Wun",
                8,
                212,
                9041
            );

        private class PossessTarget : Target
        {
            private TransfertSpell spell;

            public PossessTarget(TransfertSpell spella)
                : base(-1, false, TargetFlags.None)
            {
                spell = spella;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (spell.CheckSequence())
                {
                    PlayerMobile pm = from as PlayerMobile;

                    if (o is BaseCreature)
                    {
                        BaseCreature creature = (BaseCreature)o;

                        if (creature.Controlled && creature.ControlMaster != null && !creature.Summoned)
                        {
                            Mobile master = (Mobile)creature.ControlMaster;

                            if (from.Skills[SkillName.ArtMagique].Value < master.Skills[SkillName.Dressage].Value)
                            {
                                from.SendMessage("Vous devez avoir un niveau plus élevé de Spirit Speak que celui d'Animal Taming du maître de la créature.");
                            }
                            else
                            {
                                from.DoHarmful(master);

                                creature.PrivateOverheadMessage(MessageType.Regular, 0x3B2, 502799, creature.NetState); // It seems to accept you as master.

                                creature.SetControlMaster(from);
                                creature.IsBonded = false;

                                creature.FixedParticles(14186, 10, 20, 5013, 1441, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                                creature.PlaySound(497);
                            }
                        }
                    }
                }

                spell.FinishSequence();
            }

            protected override void OnTargetFinish(Mobile from)
            {
                spell.FinishSequence();
            }
        }

        public TransfertSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
        {
        }

        public override void OnCast()
        {
            Caster.Target = new PossessTarget(this);
        }
    }
}