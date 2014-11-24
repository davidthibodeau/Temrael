using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
//using Server.Spells.Ninjitsu;

namespace Server
{
    public class AOS
    {
        public static double GeneralTimeScaling { get { return 1.5; } }

        public static void DisableStatInfluences()
        {
            for (int i = 0; i < SkillInfo.Table.Length; ++i)
            {
                SkillInfo info = SkillInfo.Table[i];

                info.StrScale = 0.0;
                info.DexScale = 0.0;
                info.IntScale = 0.0;
                info.StatTotal = 0.0;
            }
        }

        public static int Damage(Mobile m, int damage, int phys, int contondant, int tranchant, int perforant, int magie)
        {
            return Damage(m, null, damage, phys, contondant, tranchant, perforant, magie);
        }

        public static int Damage(Mobile m, Mobile from, int damage, int phys, int contondant, int tranchant, int perforant, int magie)
        {
            return Damage(m, from, damage, false, phys, contondant, tranchant, perforant, magie, 0, 0, false, false, false);
        }

        public static int Damage(Mobile m, Mobile from, int damage, bool ignoreArmor, int phys, int contondant, int tranchant, int perforant, int magie)
        {
            return Damage(m, from, damage, ignoreArmor, phys, contondant, tranchant, perforant, magie, 0, 0, false, false, false);
        }

        public static int Damage(Mobile m, Mobile from, int damage, bool ignoreArmor, int phys, int contondant, int tranchant, int perforant, int magie, int chaos, int direct, bool keepAlive, bool archer, bool deathStrike)
        {
            if (m == null || m.Deleted || !m.Alive || damage <= 0)
                return 0;

            //if( phys == 0 && fire == 100 && cold == 0 && pois == 0 && nrgy == 0 )
            //	Mobiles.MeerMage.StopEffect( m, true );

            if (!Core.AOS)
            {
                m.Damage(damage, from);
                return damage;
            }

            Fix(ref phys);
            Fix(ref contondant);
            Fix(ref tranchant);
            Fix(ref perforant);
            Fix(ref magie);
            Fix(ref chaos);
            Fix(ref direct);

            if (Core.ML && chaos > 0)
            {
                switch (Utility.Random(5))
                {
                    case 0: phys += chaos; break;
                    case 1: contondant += chaos; break;
                    case 2: tranchant += chaos; break;
                    case 3: perforant += chaos; break;
                    case 4: magie += chaos; break;
                }
            }

            BaseQuiver quiver = null;

            if (archer && from != null)
                quiver = from.FindItemOnLayer(Layer.Cloak) as BaseQuiver;

            int totalDamage = damage;

            if (!ignoreArmor)
            {
                // Armor Ignore on OSI ignores all defenses, not just physical.
                int resPhys = (int)m.PhysicalResistance;
                int resMagie = (int)m.MagicResistance;

                totalDamage = damage * phys * (150 - resPhys);
                totalDamage += damage * magie * (150 - resMagie);

                totalDamage /= 10000;

                if (Core.ML)
                {
                    totalDamage += damage * direct / 100;

                    if (quiver != null)
                        totalDamage += totalDamage * quiver.DamageIncrease / 100;
                }

                if (totalDamage < 1)
                    totalDamage = 1;
            }
            else if (Core.ML && m is PlayerMobile && from is PlayerMobile)
            {
                if (quiver != null)
                    damage += damage * quiver.DamageIncrease / 100;

                if (!deathStrike)
                    totalDamage = Math.Min(damage, 35);	// Direct Damage cap of 35
                else
                    totalDamage = Math.Min(damage, 70);	// Direct Damage cap of 70
            }
            else
            {
                totalDamage = damage;

                if (Core.ML && quiver != null)
                    totalDamage += totalDamage * quiver.DamageIncrease / 100;
            }

            #region Dragon Barding
            if ((from == null || !from.Player) && m.Player && m.Mount is DragonMarais)
            {
                DragonMarais pet = m.Mount as DragonMarais;

                if (pet != null && pet.HasBarding)
                {
                    int percent = (pet.BardingExceptional ? 20 : 10);
                    int absorbed = Scale(totalDamage, percent);

                    totalDamage -= absorbed;
                    pet.BardingHP -= absorbed;

                    if (pet.BardingHP < 0)
                    {
                        pet.HasBarding = false;
                        pet.BardingHP = 0;

                        m.SendLocalizedMessage(1053031); // Your dragon's barding has been destroyed!
                    }
                }
            }
            #endregion

            if (keepAlive && totalDamage > m.Hits)
                totalDamage = m.Hits;

            if (from != null && !from.Deleted && from.Alive)
            {
                //int reflectPhys = AosAttributes.GetValue(m, AosAttribute.ReflectPhysical);

                //if (reflectPhys > 5)
                //    reflectPhys = 5;

                //if (reflectPhys != 0)
                //{
                //    from.Damage(Scale((damage * phys * (100 - (ignoreArmor ? 0 : (int)m.PhysicalResistance))) / 10000, reflectPhys), m);
                //}
            }

            if (ExaltationMiracle.m_ExaltationTable.Contains(m))
            {
                ExaltationInfo info = (ExaltationInfo)ExaltationMiracle.m_ExaltationTable[m];

                if (info != null && info.Caster != null && info.Caster.Alive && !info.Caster.Deleted && info.Percent > 0)
                {
                    AOS.Damage(info.Caster, from, (int)(totalDamage * info.Percent), 0, 0, 0, 100, 0);
                    totalDamage = (int)(totalDamage * (1 - info.Percent));
                }

                ReligiousSpell.MiracleEffet(info.Caster, m, 8902, 10, 15, 5013, 0x7f9, 0, EffectLayer.CenterFeet);
                //m.FixedParticles(8902, 10, 15, 5013, 1437, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(555);

                ReligiousSpell.MiracleEffet(info.Caster, info.Caster, 8902, 10, 15, 5013, 0x860, 0, EffectLayer.CenterFeet);
                //info.Caster.FixedParticles(8902, 10, 15, 5013, 1437, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                info.Caster.PlaySound(555);
            }

            m.Damage(totalDamage, from);

            if (SauvegardeMiracle.m_SauvegardeTable.Contains(m))
            {
                Mobile target = (Mobile)SauvegardeMiracle.m_SauvegardeTable[m];

                if (target != null && m.Alive && m.Map == target.Map)
                {
                    m.MoveToWorld(target.Location, target.Map);
                    SauvegardeMiracle.StopTimer(m);

                    ReligiousSpell.MiracleEffet(m, m, 14138, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet);
                    ReligiousSpell.MiracleEffet(m, target, 14138, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet);

                    //m.FixedParticles(14170, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    //target.FixedParticles(14170, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m.PlaySound(1923);
                }
            }

            return totalDamage;
        }

        public static void Fix(ref int val)
        {
            if (val < 0)
                val = 0;
        }

        public static int Scale(int input, int percent)
        {
            return (input * percent) / 100;
        }
    }

    [PropertyObject]
    public abstract class BaseAttributes
    {
        private Item m_Owner;
        private uint m_Names;
        private int[] m_Values;

        private static int[] m_Empty = new int[0];

        public bool IsEmpty { get { return (m_Names == 0); } }
        public Item Owner { get { return m_Owner; } }

        public BaseAttributes(Item owner)
        {
            m_Owner = owner;
            m_Values = m_Empty;
        }

        public BaseAttributes(Item owner, BaseAttributes other)
        {
            m_Owner = owner;
            m_Values = new int[other.m_Values.Length];
            other.m_Values.CopyTo(m_Values, 0);
            m_Names = other.m_Names;
        }

        public BaseAttributes(Item owner, GenericReader reader)
        {
            m_Owner = owner;

            int version = reader.ReadByte();

            switch (version)
            {
                case 1:
                    {
                        m_Names = reader.ReadUInt();
                        m_Values = new int[reader.ReadEncodedInt()];

                        for (int i = 0; i < m_Values.Length; ++i)
                            m_Values[i] = reader.ReadEncodedInt();

                        break;
                    }
                case 0:
                    {
                        m_Names = reader.ReadUInt();
                        m_Values = new int[reader.ReadInt()];

                        for (int i = 0; i < m_Values.Length; ++i)
                            m_Values[i] = reader.ReadInt();

                        break;
                    }
            }
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write((byte)1); // version;

            writer.Write((uint)m_Names);
            writer.WriteEncodedInt((int)m_Values.Length);

            for (int i = 0; i < m_Values.Length; ++i)
                writer.WriteEncodedInt((int)m_Values[i]);
        }

        public int GetValue(int bitmask)
        {
            if (!Core.AOS)
                return 0;

            uint mask = (uint)bitmask;

            if ((m_Names & mask) == 0)
                return 0;

            int index = GetIndex(mask);

            if (index >= 0 && index < m_Values.Length)
                return m_Values[index];

            return 0;
        }

        public void SetValue(int bitmask, int value)
        {
            //if ((bitmask == (int)AosWeaponAttribute.DurabilityBonus) && (this is AosWeaponAttributes))
            //{
            //    if (m_Owner is BaseWeapon)
            //        ((BaseWeapon)m_Owner).UnscaleDurability();
            //}
            //else if ((bitmask == (int)AosArmorAttribute.DurabilityBonus) && (this is AosArmorAttributes))
            //{
            //    if (m_Owner is BaseArmor)
            //        ((BaseArmor)m_Owner).UnscaleDurability();
            //    else if (m_Owner is BaseClothing)
            //        ((BaseClothing)m_Owner).UnscaleDurability();
            //}

            uint mask = (uint)bitmask;

            if (value != 0)
            {
                if ((m_Names & mask) != 0)
                {
                    int index = GetIndex(mask);

                    if (index >= 0 && index < m_Values.Length)
                        m_Values[index] = value;
                }
                else
                {
                    int index = GetIndex(mask);

                    if (index >= 0 && index <= m_Values.Length)
                    {
                        int[] old = m_Values;
                        m_Values = new int[old.Length + 1];

                        for (int i = 0; i < index; ++i)
                            m_Values[i] = old[i];

                        m_Values[index] = value;

                        for (int i = index; i < old.Length; ++i)
                            m_Values[i + 1] = old[i];

                        m_Names |= mask;
                    }
                }
            }
            else if ((m_Names & mask) != 0)
            {
                int index = GetIndex(mask);

                if (index >= 0 && index < m_Values.Length)
                {
                    m_Names &= ~mask;

                    if (m_Values.Length == 1)
                    {
                        m_Values = m_Empty;
                    }
                    else
                    {
                        int[] old = m_Values;
                        m_Values = new int[old.Length - 1];

                        for (int i = 0; i < index; ++i)
                            m_Values[i] = old[i];

                        for (int i = index + 1; i < old.Length; ++i)
                            m_Values[i - 1] = old[i];
                    }
                }
            }

            //if ((bitmask == (int)AosWeaponAttribute.DurabilityBonus) && (this is AosWeaponAttributes))
            //{
            //    if (m_Owner is BaseWeapon)
            //        ((BaseWeapon)m_Owner).ScaleDurability();
            //}
            //else if ((bitmask == (int)AosArmorAttribute.DurabilityBonus) && (this is AosArmorAttributes))
            //{
            //    if (m_Owner is BaseArmor)
            //        ((BaseArmor)m_Owner).ScaleDurability();
            //    else if (m_Owner is BaseClothing)
            //        ((BaseClothing)m_Owner).ScaleDurability();
            //}

            if (m_Owner.Parent is Mobile)
            {
                Mobile m = (Mobile)m_Owner.Parent;

                m.CheckStatTimers();
                m.UpdateResistances();
                m.Delta(MobileDelta.Stat | MobileDelta.WeaponDamage | MobileDelta.Hits | MobileDelta.Stam | MobileDelta.Mana);

                //if (this is AosSkillBonuses)
                //{
                //    ((AosSkillBonuses)this).Remove();
                //    ((AosSkillBonuses)this).AddTo(m);
                //}
            }

            m_Owner.InvalidateProperties();
        }

        private int GetIndex(uint mask)
        {
            int index = 0;
            uint ourNames = m_Names;
            uint currentBit = 1;

            while (currentBit != mask)
            {
                if ((ourNames & currentBit) != 0)
                    ++index;

                if (currentBit == 0x80000000)
                    return -1;

                currentBit <<= 1;
            }

            return index;
        }
    }
}