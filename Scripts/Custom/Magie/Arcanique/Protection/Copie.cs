using System;
using Server;
using Server.Misc;
using Server.Items;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using System.Collections;
using Server.Spells;
using Server.Commands;

/* Fichier : Copie.cs
 * Description : Sort de copie. Crée un sosie d'un créature ciblée
 * Derniere MAJ : 20 janvier 2010
 *  - Copie ne peut maintenant plus être
 * 
 * */

namespace Server.Mobiles
{
    [CorpseName("un corps de copie")]
    public class Copie : BaseCreature
    {
        //Liste de toutes les "copies" créées par les joueurs
        public static Hashtable m_CopieTable = new Hashtable();

        private Mobile m_Caster;

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Caster
        {
            get { return m_Caster; }
            set { m_Caster = value; }
        }

        private bool m_Aggro;

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Aggro
        {
            get { return m_Aggro; }
            set { m_Aggro = value; }
        }

        public override bool DeleteCorpseOnDeath { get { return Summoned; } }

        public static Layer[] ItemLayers = {Layer.FirstValid, Layer.TwoHanded, Layer.Shoes, Layer.Pants,
			Layer.Shirt, Layer.Helm, Layer.Gloves, Layer.Ring, Layer.Neck, Layer.Hair,
			Layer.Waist, Layer.InnerTorso, Layer.Bracelet, Layer.FacialHair, Layer.MiddleTorso,
			Layer.Earrings, Layer.Arms, Layer.Cloak, Layer.OuterTorso, Layer.OuterLegs, Layer.Mount };

        [Constructable]
        public Copie(Mobile caster, Mobile lacopie)
            : base(AIType.AI_Animal, FightMode.None, 10, 1, 0.1, 0.1)
        {
            m_Caster = caster;

            Name = lacopie.Name;
            Hue = lacopie.Hue;

            Body = lacopie.Body;

            SetStr(lacopie.Str);
            SetDex(lacopie.Dex);
            SetInt(lacopie.Int);

            SetHits(lacopie.HitsMax / 2);

            if (lacopie.Weapon != null)
            {
                BaseWeapon weapon = (BaseWeapon)lacopie.Weapon;
                SetDamage(weapon.MinDamage - 5, weapon.MaxDamage + 5);
            }
            else
            {
                SetDamage(10, 30);
            }

            //SetSkill(SkillName.EvalInt, lacopie.Skills[SkillName.EvalInt].Value);
            SetSkill(SkillName.ArtMagique, lacopie.Skills[SkillName.ArtMagique].Value);
            //SetSkill(SkillName.MagicResist, lacopie.Skills[SkillName.MagicResist].Value);
            SetSkill(SkillName.Tactiques, lacopie.Skills[SkillName.Tactiques].Value);
            SetSkill(SkillName.ArmePoing, lacopie.Skills[SkillName.ArmePoing].Value);
            SetSkill(SkillName.ArmeTranchante, lacopie.Skills[SkillName.ArmeTranchante].Value);
            SetSkill(SkillName.ArmeContondante, lacopie.Skills[SkillName.ArmeContondante].Value);
            SetSkill(SkillName.ArmeDistance, lacopie.Skills[SkillName.ArmeDistance].Value);
            SetSkill(SkillName.ArmePerforante, lacopie.Skills[SkillName.ArmePerforante].Value);

            VirtualArmor = lacopie.VirtualArmor;
            ControlSlots = 2;

            ArrayList PossessItems = new ArrayList(lacopie.Items);
            try
            {
                for (int i = 0; i < PossessItems.Count; i++)
                {
                    Item item = (Item)PossessItems[i];
                    if (Array.IndexOf(ItemLayers, item.Layer) != -1)
                    {
                        Item itemb = Dupe.DupeItem(this, item, false);

                        if(itemb != null)
                            this.EquipItem(itemb);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Possess: MoveItems Exception: {0}", e.Message);
            }

            new CopieTimer(this as Copie).Start();

            m_CopieTable[Caster] = this;

            Aggro = false;
        }

        public override void OnDelete()
        {
            m_CopieTable.Remove(Caster);

            base.OnDelete();
        }

        public void AcquireCombattant()
        {
            ArrayList targets = new ArrayList();

            Map map = this.Map;

            if (map != null)
            {
                IPooledEnumerable eable = map.GetMobilesInRange(this.Location, 12);

                foreach (Mobile m in eable)
                {
                    if (m is BaseCreature && !m.Hidden && Caster.CanBeHarmful(m) && SpellHelper.ValidIndirectTarget(Caster, m))
                        targets.Add(m);
                }

                eable.Free();
            }

            if (targets.Count > 0)
            {
                for (int i = 0; i < targets.Count; ++i)
                {
                    BaseCreature m = (BaseCreature)targets[i];

                    m.Combatant = this;
                }
            }
        }

        public class CopieTimer : Timer
        {
            private Copie m_copie;

            public CopieTimer(Copie copie)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(5))
            {
                m_copie = copie;
            }

            protected override void OnTick()
            {
                if (m_copie != null && !m_copie.Deleted && m_copie.Alive && m_copie.Aggro)
                    m_copie.AcquireCombattant();
                else
                    Stop();
            }
        }

        public override void GenerateLoot()
        {
        }

        public Copie(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)1);

            writer.Write(m_Aggro);

            writer.Write(m_Caster);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            if (version >= 1)
                m_Aggro = reader.ReadBool();

            m_Caster = reader.ReadMobile();

            new CopieTimer(this).Start();

            m_CopieTable[Caster] = this;
        }
    }
}

namespace Server.Spells
{
    public class CopieSpell : Spell
    {
        private static SpellInfo m_Info = new SpellInfo(
                "Copie", "Quas Sanct Ort",
                SpellCircle.Sixth,
                269,
                9020,
                false,
                Reagent.Garlic,
                Reagent.MandrakeRoot,
                Reagent.Ginseng
            );

        public CopieSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public override bool DelayedDamage { get { return false; } }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (Copie.m_CopieTable.Contains(Caster))
            {
                Caster.SendMessage("Vous ne pouvez conjurer qu'une Copie à la fois !");
            }
            else if (m.Blessed)
            {
                Caster.SendMessage("Vous ne pouvez pas copier des créatures invulnérables !");
            }
            else if (CheckSequence())
            {
                SpellHelper.Turn(Caster, m);

                ToogleCopie(this, Caster, m);

                m.FixedParticles(0x374A, 10, 15, 5013, EffectLayer.Waist);
                m.PlaySound(0x1F1);
            }

            FinishSequence();
        }

        //Création d'une copie
        public static void ToogleCopie(Spell spell, Mobile Caster, Mobile from)
        {
            TimeSpan duration = spell.GetDurationForSpell(30, 1);

            SpellHelper.Summon(new Copie(Caster,from), Caster, 0x217, duration, false, false);
        }

        private class InternalTarget : Target
        {
            private CopieSpell m_Owner;

            public InternalTarget(CopieSpell owner)
                : base(12, false, TargetFlags.Beneficial)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile)
                {
                    m_Owner.Target((Mobile)o);
                }
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}

namespace Server.Scripts.Commands
{
    public class CopieAggro
    {
        public static void Initialize()
        {
            CommandSystem.Register("aggro", AccessLevel.Player, new CommandEventHandler(Aggro_OnCommand));
        }

        public static void Aggro_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            from.BeginTarget(12, false, TargetFlags.None, new TargetCallback(Aggro_OnTarget));
        }

        public static void Aggro_OnTarget(Mobile from, object targ)
        {
            if (from is TMobile)
            {
                TMobile pm = (TMobile)from;

                if (pm.GetAptitudeValue(Aptitude.Protection) < 5)
                    from.SendMessage("Vous devez pouvoir utiliser le sort Copie.");
                else if (targ is Copie)
                {
                    Copie target = (Copie)targ;

                    if (target != null && target.SummonMaster == pm)
                    {
                        if (target.Aggro)
                            target.Aggro = false;
                        else
                            target.Aggro = true;
                    }
                }
                else
                    from.SendMessage("Vous devez cibler une copie.");
            }
        }
    }
}