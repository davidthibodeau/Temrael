using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using System.Collections;

namespace Server.Spells
{
    public class MontureCelesteMiracle : ReligiousSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
                "Monture Celeste", "",
                SpellCircle.Sixth,
                17,
                9032,
                false
            );

        public override int RequiredAptitudeValue { get { return 6; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Fanatisme }; } }

        public override bool Invocation { get { return true; } }

        public MontureCelesteMiracle(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override bool CheckCast()
        {
            if (!base.CheckCast())
                return false;

            if ((Caster.Followers + 1) > Caster.FollowersMax)
            {
                Caster.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
                return false;
            }

            return true;
        }

        public override void OnCast()
        {
            if (CheckSequence())
            {
                TimeSpan duration = GetDurationForSpell(30, 1.8);
                if (Caster is TMobile)
                {
                    switch (((TMobile)Caster).Dieux)
                    {
                        /*case Dieux.Valar:
                            SpellHelper.Summon(new DragonMarais(), Caster, 0x217, duration, false, false);
                            break;
                        case Dieux.Sheol:
                            SpellHelper.Summon(new Cauchemar(), Caster, 0x217, duration, false, false);
                            break;
                        case Dieux.Erys:
                            SpellHelper.Summon(new Scarabee(), Caster, 0x217, duration, false, false);
                            break;
                        case Dieux.Niobe:
                            SpellHelper.Summon(new Licorne(), Caster, 0x217, duration, false, false);
                            break;
                        case Dieux.Jarnsaxa:
                            SpellHelper.Summon(new Kirin(), Caster, 0x217, duration, false, false);
                            break;
                        case Dieux.Xenon:
                            //SpellHelper.Summon(new Nightmare(), Caster, 0x217, duration, false, false);
                            SpellHelper.Summon(new Chocobo(), Caster, 0x217, duration, false, false);
                            break;*/
                        default: SpellHelper.Summon(new Horse(), Caster, 0x217, duration, false, false); break;
                    }
                }
                else
                {
                SpellHelper.Summon(new Horse(), Caster, 0x217, duration, false, false);
                }
            }

            FinishSequence();
        }
    }
}
