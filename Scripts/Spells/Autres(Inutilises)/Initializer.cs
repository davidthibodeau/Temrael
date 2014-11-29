using System;
using Server;
using Server.Spells;

namespace Server.Spells
{
	public class Initializer
	{
        public static void Initialize()
        {
            // Evocation
            Register(MagicArrowSpell.m_SpellID,     typeof(MagicArrowSpell));
            Register(FireballSpell.m_SpellID,       typeof(FireballSpell));
            Register(ExplosionSpell.m_SpellID,      typeof(ExplosionSpell));
            Register(EnergyBoltSpell.m_SpellID,     typeof(EnergyBoltSpell));
            Register(LightningSpell.m_SpellID,      typeof(LightningSpell));
            Register(EarthquakeSpell.m_SpellID,     typeof(EarthquakeSpell));
            Register(ChainLightningSpell.m_SpellID, typeof(ChainLightningSpell));
            Register(FireFieldSpell.m_SpellID,      typeof(FireFieldSpell));
            Register(FlameStrikeSpell.m_SpellID,    typeof(FlameStrikeSpell));

            // Immuabilite
            Register(WallOfStoneSpell.m_SpellID,    typeof(WallOfStoneSpell));
            Register(EnergyFieldSpell.m_SpellID,    typeof(EnergyFieldSpell));
            Register(ParalyzeFieldSpell.m_SpellID,  typeof(ParalyzeFieldSpell));
            Register(ParalyzeSpell.m_SpellID,       typeof(ParalyzeSpell));
            Register(EtouffementSpell.m_SpellID,    typeof(EtouffementSpell));
            Register(LenteurSpell.m_SpellID,        typeof(LenteurSpell));

            // Alteration
            Register(MindRotSpell.m_SpellID,        typeof(MindRotSpell));
            Register(CurseWeaponSpell.m_SpellID,    typeof(CurseWeaponSpell));
            Register(BloodOathSpell.m_SpellID,      typeof(BloodOathSpell));
            Register(EvilOmenSpell.m_SpellID,       typeof(EvilOmenSpell));
            Register(PainSpikeSpell.m_SpellID,      typeof(PainSpikeSpell));
            Register(StrangleSpell.m_SpellID,       typeof(StrangleSpell));
            Register(CorpseSkinSpell.m_SpellID,     typeof(CorpseSkinSpell));
            Register(HorrificBeastSpell.m_SpellID,  typeof(HorrificBeastSpell));

            // Providence
            Register(ReactiveArmorSpell.m_SpellID,  typeof(ReactiveArmorSpell));
            Register(PeauDePierreSpell.m_SpellID,     typeof(PeauDePierreSpell));
            Register(BlessSpell.m_SpellID,          typeof(BlessSpell));
            Register(StrengthSpell.m_SpellID,       typeof(StrengthSpell));
            Register(AgilitySpell.m_SpellID,        typeof(AgilitySpell));
            Register(CunningSpell.m_SpellID,        typeof(CunningSpell));
            Register(MagicReflectSpell.m_SpellID,   typeof(MagicReflectSpell));

            // Transmutation
            Register(EvasionSpell.m_SpellID,        typeof(EvasionSpell));
            Register(TeleportSpell.m_SpellID,       typeof(TeleportSpell));
            Register(SummonCreatureSpell.m_SpellID, typeof(SummonCreatureSpell));
            Register(DispelSpell.m_SpellID,         typeof(DispelSpell));
            Register(PolymorphSpell.m_SpellID,      typeof(PolymorphSpell));

            // Thaumaturgie
            Register(HealSpell.m_SpellID,           typeof(HealSpell));
            Register(CureSpell.m_SpellID,           typeof(CureSpell));
            Register(GreaterHealSpell.m_SpellID,    typeof(GreaterHealSpell));
            Register(TotemRegenSpell.m_SpellID, typeof(TotemRegenSpell));

            // Hallucination
            Register(InvisibilitySpell.m_SpellID,   typeof(InvisibilitySpell));

            // Ensorcellement
            Register(WeakenSpell.m_SpellID,         typeof(WeakenSpell));
            Register(ClumsySpell.m_SpellID,         typeof(ClumsySpell));
            Register(FeeblemindSpell.m_SpellID,     typeof(FeeblemindSpell));
            Register(CurseSpell.m_SpellID,          typeof(CurseSpell));
            Register(HarmSpell.m_SpellID,           typeof(HarmSpell));
            Register(ManaDrainSpell.m_SpellID,      typeof(ManaDrainSpell));
            Register(ManaVampireSpell.m_SpellID,    typeof(ManaVampireSpell));
            Register(MassCurseSpell.m_SpellID,      typeof(MassCurseSpell));

            // Necromancie
            Register(PoisonSpell.m_SpellID,         typeof(PoisonSpell));
            Register(PoisonFieldSpell.m_SpellID,    typeof(PoisonFieldSpell));
            Register(WraithFormSpell.m_SpellID,     typeof(WraithFormSpell));
            Register(LichFormSpell.m_SpellID,       typeof(LichFormSpell));
            Register(AnimateDeadSpell.m_SpellID,    typeof(AnimateDeadSpell));
            Register(VengefulSpiritSpell.m_SpellID, typeof(VengefulSpiritSpell));
            Register(SummonFamiliarSpell.m_SpellID, typeof(SummonFamiliarSpell));
            Register(SummonDaemonSpell.m_SpellID,   typeof(SummonDaemonSpell));
        }

		public static void Register( int spellID, Type type )
		{
			SpellRegistry.Register( spellID, type );
		}
	}
}