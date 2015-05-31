using System;
using Server.Network;
using Server.Targeting;
using Server.Items;
using Server.Mobiles;
using System.Collections;
using Server.Engines.Craft;
using System.Collections.Generic;
using Server.Engines.Combat;

namespace Server.Items
{
    public abstract class BaseFouet : BaseWearable, ICraftable, IScissorable
    {
        protected int m_Range;
        protected const double WaitTime = 15.0;                               //Wait time on individual target (seconds)
        protected const double CooldownTime = 5.0;                            //Cooldown time between each use (seconds)
        protected const double BlockEquipDuration = 15.0;                     //Wait time before target can reequip weapon in case of success drop
        protected static HashSet<Mobile> MobilesList = new HashSet<Mobile>(); //Immuned mobiles
        protected DateTime NextUse;                                           //Next time the whipe is usable

        protected const double StealingScaling = 0.30;                        //Scaling off stealing 
        protected const double StealingBonus = 30.0;                          //Bonus if stealing is at 100
        protected const double SnoopingScaling = 0.20;                        //Scaling off snooping
        protected const double SnoopingBonus = 20.0;                          //Bonus if snooping is at 100
        
        private Mobile m_Crafter;
        private string m_CrafterName;
        private FouetQuality m_Quality;
        private bool m_PlayerConstructed;
        protected CraftResource m_Resource;

        public enum FouetQuality
        {
            Low,
            Regular,
            Exceptional
        }

        #region PROPS
        [CommandProperty(AccessLevel.Batisseur)]
        public Mobile Crafter
        {
            get { return m_Crafter; }
            set { m_Crafter = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public string CrafterName
        {
            get { return m_CrafterName; }
            set { m_CrafterName = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public FouetQuality Quality
        {
            get { return m_Quality; }
            set { m_Quality = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public bool PlayerConstructed
        {
            get { return m_PlayerConstructed; }
            set { m_PlayerConstructed = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public CraftResource Resource
        {
            get { return m_Resource; }
            set { m_Resource = value; Hue = CraftResources.GetHue(value); InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Range
        {
            get { return m_Range; }
            set { m_Range = value; InvalidateProperties(); }
        }
        #endregion

        public enum Sounds
        {
            Miss = 0x234 + 1,           //User misses the target
            SuccessDrop = 0x146 + 2,    //User successfully drop the target's weapon
            SuccessSteal = 0x534 + 3,   //User successfully steals the target's weapon
            Whip = 0x146 + 4            //User whips an unarmed target
        }
        
        public BaseFouet(int itemID)
            : base(itemID)
        {
            m_Quality = FouetQuality.Regular;
            m_Crafter = null;
            NextUse = DateTime.MinValue;
            Hue = CraftResources.GetHue(m_Resource);

            this.Layer = Layer.OneHanded;
        }

        public BaseFouet(Serial serial) 
            : base(serial)
        { 
        }

        #region Serialization
        private static void SetSaveFlag(ref SaveFlag flags, SaveFlag toSet, bool setIf)
        {
            if (setIf)
                flags |= toSet;
        }

        private static bool GetSaveFlag(SaveFlag flags, SaveFlag toGet)
        {
            return ((flags & toGet) != 0);
        }

        [Flags]
        private enum SaveFlag
        {
            None = 0x00000000,
            Resource = 0x00000001,
            Resistances = 0x00000002,
            PlayerConstructed = 0x00000010,
            Crafter = 0x00000020,
            Quality = 0x00000040,
            Range = 0x00000080,
            CrafterName = 0x00000100

        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write((int)Layer);

            SaveFlag flags = SaveFlag.None;

            SetSaveFlag(ref flags, SaveFlag.Resource, true);
            SetSaveFlag(ref flags, SaveFlag.PlayerConstructed, m_PlayerConstructed != false);
            SetSaveFlag(ref flags, SaveFlag.Crafter, m_Crafter != null);
            SetSaveFlag(ref flags, SaveFlag.CrafterName, m_CrafterName != null);
            SetSaveFlag(ref flags, SaveFlag.Quality, m_Quality != FouetQuality.Regular);
            SetSaveFlag(ref flags, SaveFlag.Range, Range != 7);


            writer.WriteEncodedInt((int)flags);

            if (GetSaveFlag(flags, SaveFlag.Resource))
                writer.WriteEncodedInt((int)m_Resource);

            if (GetSaveFlag(flags, SaveFlag.Crafter))
                writer.Write((Mobile)m_Crafter);

            if (GetSaveFlag(flags, SaveFlag.CrafterName))
                writer.Write((string)m_CrafterName);

            if (GetSaveFlag(flags, SaveFlag.Quality))
                writer.WriteEncodedInt((int)m_Quality);

            if (GetSaveFlag(flags, SaveFlag.Range))
                writer.WriteEncodedInt((int)Range);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            Layer = (Layer)reader.ReadInt();

            SaveFlag flags = (SaveFlag)reader.ReadEncodedInt();

            if (GetSaveFlag(flags, SaveFlag.Resource))
                m_Resource = (CraftResource)reader.ReadEncodedInt();

            if (GetSaveFlag(flags, SaveFlag.Crafter))
                m_Crafter = reader.ReadMobile();

            if (GetSaveFlag(flags, SaveFlag.CrafterName))
                m_CrafterName = reader.ReadString();

            if (GetSaveFlag(flags, SaveFlag.Quality))
                m_Quality = (FouetQuality)reader.ReadEncodedInt();
            else
                m_Quality = FouetQuality.Regular;

            if (GetSaveFlag(flags, SaveFlag.Range))
                Range = reader.ReadEncodedInt();
            else
                Range = 7;

            if (GetSaveFlag(flags, SaveFlag.PlayerConstructed))
                m_PlayerConstructed = true;

            Mobile parent = Parent as Mobile;

            if (parent != null)
            {
                parent.CheckStatTimers();
            }
        }
        #endregion
        
        public override void OnDoubleClick(Mobile from)
        {
            if (DateTime.Now < NextUse)
                from.SendMessage("Vous ne pouvez pas utiliser le fouet maintenant.");
            else if (from.Dex < 50)
                from.SendMessage("Vous n'êtes pas assez à l'aise pour utiliser le fouet.");
            else if (from.FindItemOnLayer(Layer.OneHanded) != this)
                from.SendMessage("Vous devez avoir le fouet en main pour l'utiliser.");
            else
                from.Target = new InternalTarget(this, Range);
        }

        public void Target(Mobile atk, Mobile target)
        {
            if (!atk.CanSee(target))
            {
                atk.SendLocalizedMessage(500237); //Target can not be seen.
            }
            else if (MobilesList.Contains(target))
            {
                DoAnimation(atk, target, Sounds.Miss);
                atk.SendMessage("Vous devez attendre avant de tenter de voler l'arme de votre cible à nouveau");
            }
            else
                DoEffect(atk, target);
        }

        protected double GetBonus(double value, double scalar, double offset)
        {
            double bonus = value * scalar;

            if (value >= 100)
                bonus += offset;

            return bonus / 100;
        }

        public double GetChances(Mobile atk, Mobile def)
        {
            double chances = 0;
            chances = GetBonus(atk.Skills[SkillName.Vol].Value, StealingScaling, StealingBonus);
            chances += GetBonus(atk.Skills[SkillName.Fouille].Value, SnoopingScaling, SnoopingBonus);

            Item weapon = Weapon(def);

            if (weapon != null)
            {
                chances -= GetBonus(def.Skills[(CombatStrategy.GetStrategy(def).ToucherSkill)].Value, 0.05, 5);

                if (weapon.Layer == Layer.TwoHanded)
                {
                    chances -= 0.15;
                }
                if (def.FindItemOnLayer(Layer.TwoHanded) as BaseShield != null)
                {
                    chances -= GetBonus(def.Skills[SkillName.Parer].Value, 0.15, 5);
                }
            }

            return chances;
        }

        public void DoEffect(Mobile atk, Mobile def)
        {
            double chances = GetChances(atk, def);
            NextUse = DateTime.Now.AddSeconds(CooldownTime);
            Item weapon = Weapon(def);

            if (def.Spell != null)
            {
                if (def.Spell.IsCasting && (GetBonus(def.Skills[SkillName.ArtMagique].Value, 0.2, 5) + GetBonus(def.Skills[SkillName.Meditation].Value, 0.2, 5)) <= Utility.RandomDouble())
                {
                    //def.DisruptiveAction();
                }
            }

            if (chances >= Utility.RandomDouble())
            {
                new WaitTimer(def, TimeSpan.FromSeconds(2*WaitTime)).Start();
                if (weapon != null)
                {
                    double malus = (weapon.Layer == Layer.OneHanded) ? 0.5 : 0.3;
                    if (malus * chances >= Utility.RandomDouble() && !atk.Mounted) //Steal the weapon
                    {
                        atk.AddToBackpack(weapon);
                        DoAnimation(atk, def, Sounds.SuccessSteal);
                    }
                    else                                                           //Drop the weapon
                    {
                        weapon.MoveToWorld(weapon.GetWorldLocation(), weapon.Map);
                        DoAnimation(atk, def, Sounds.SuccessDrop);
                    }
                    BaseWeapon.BlockEquip(def, TimeSpan.FromSeconds(chances * BlockEquipDuration));
                }
                else                                                               //Fail
                {
                    DoAnimation(atk, def, Sounds.Whip);
                }
                atk.Stam -= (int)((1 - chances) * 150);
                def.Damage(15, atk);
            }
            else
            {
                new WaitTimer(def, TimeSpan.FromSeconds(WaitTime)).Start();
                DoAnimation(atk, def, Sounds.Miss);
            }

            atk.RevealingAction();
            def.RevealingAction();
            //atk.DisruptiveAction();
        }

        public void DoAnimation(Mobile from, Mobile target, Sounds sound)
        {
            switch (sound)
            {
                case Sounds.Miss:
                    {
                        from.Animate(9, 7, 1, true, false, 0);
                        from.PlaySound(((int)Sounds.Miss - 1));
                        target.SendMessage("Un coup de fouet vous frôle de près!");
                        target.PlaySound(((int)Sounds.Miss - 1));
                        break;
                    }
                case Sounds.SuccessDrop: 
                    {
                        from.Animate(9, 7, 1, true, false, 0);
                        from.PlaySound(((int)Sounds.Miss - 1));
                        target.SendMessage("Vous recevez un coup de fouet et échappez votre arme!");
                        target.Animate(20, 5, 1, true, false, 0);
                        target.PlaySound(((int)Sounds.SuccessDrop - 2));
                        break;
                    }
                case Sounds.SuccessSteal:
                    {
                        from.Animate(9, 7, 1, true, false, 0);
                        from.PlaySound(((int)Sounds.Miss - 1));
                        target.SendMessage("Vous recevez un coup de fouet et votre arme vous glisse des mains!");
                        target.Animate(20, 5, 1, true, false, 0);
                        target.PlaySound(((int)Sounds.SuccessSteal - 3));
                        break;
                    }
                case Sounds.Whip:
                    {
                        from.Animate(9, 7, 1, true, false, 0);
                        from.PlaySound(((int)Sounds.Miss - 1));
                        target.SendMessage("Vous recevez un coup de fouet!");
                        target.Animate(20, 5, 1, true, false, 0);
                        target.PlaySound(((int)Sounds.Whip - 4));
                        break;
                    }
            }
        }

        public static BaseWeapon Weapon(Mobile m)
        {
            return m.Weapon as BaseWeapon;
        }

        private class InternalTarget : Target
        {
            private BaseFouet m_Owner;

            public InternalTarget(BaseFouet owner, int range)
                : base(range, false, TargetFlags.Harmful)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                Mobile mob = (Mobile)o;

                if (mob is PlayerMobile && !mob.Blessed)
                {
                    m_Owner.Target(from, (Mobile)o);
                }
                else
                {
                    from.SendMessage("Votre cible doit être un joueur.");
                }
            }

            protected override void OnTargetFinish(Mobile from)
            {
            }
        }

        private class WaitTimer : Timer
        {
            private Mobile m_Target;
            private DateTime m_End;

            public WaitTimer(Mobile target, TimeSpan delay)
                : base(TimeSpan.FromSeconds(1.0), TimeSpan.FromSeconds(1.0))
            {
                m_Target = target;
                m_End = DateTime.Now + delay;
                MobilesList.Add(target);
                Priority = TimerPriority.TwoFiftyMS;
            }

            protected override void OnTick()
            {
                if (m_Target.Deleted || !m_Target.Alive || DateTime.Now >= m_End)
                {
                    MobilesList.Remove(m_Target);
                    Stop();
                }
            }
        }

        #region IScissorable
        public virtual bool Scissor(Mobile from, Scissors scissors)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack.
                return false;
            }

            CraftSystem system = DefTailoring.CraftSystem;

            CraftItem item = system.CraftItems.SearchFor(GetType());

            if (item != null && item.Resources.Count == 1 && item.Resources.GetAt(0).Amount >= 2)
            {
                try
                {
                    Type resourceType = null;

                    CraftResourceInfo info = CraftResources.GetInfo(m_Resource);

                    if (info != null && info.ResourceTypes.Length > 0)
                        resourceType = info.ResourceTypes[0];

                    if (resourceType == null)
                        resourceType = item.Resources.GetAt(0).ItemType;

                    Item res = (Item)Activator.CreateInstance(resourceType);

                    ScissorHelper(from, res, m_PlayerConstructed ? (item.Resources.GetAt(0).Amount / 2) : 1);

                    res.LootType = LootType.Regular;

                    return true;
                }
                catch
                {

                }
            }

            from.SendLocalizedMessage(502440); // Scissors can not be used on that to produce anything.
            return false;
        }
        #endregion

        #region ICraftable
        public virtual int OnCraft(int quality, bool makersMark, Mobile from, CraftSystem craftSystem, Type typeRes, BaseTool tool, CraftItem craftItem, int resHue)
        {
            Quality = (FouetQuality)quality;

            Crafter = from;

            Type resourceType = typeRes;

            if (resourceType == null)
                resourceType = craftItem.Resources.GetAt(0).ItemType;

            Resource = CraftResources.GetFromType(resourceType);
            PlayerConstructed = true;

            CraftContext context = craftSystem.GetContext(from);

            RareteInit.InitItem(this, quality, Crafter);

            if (context != null && context.DoNotColor)
                Hue = 0;

            return quality;
        }

        #endregion
    }

    public class FouetCuir : BaseFouet
    {
        [Constructable]
        public FouetCuir()
            : base(0x166E)
        {
            Weight = 5.0;
            Name = "Fouet en cuir";
            Range = 7;
        }

        public FouetCuir(Serial serial)
            : base(serial)
        {
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
