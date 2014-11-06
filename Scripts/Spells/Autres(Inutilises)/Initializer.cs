using System;
using Server;
using Server.Spells;

namespace Server.Spells
{
	public class Initializer
	{
        public static void Initialize()
        {
            // First circle
            Register(ClumsySpell.m_SpellID,             typeof(ClumsySpell));
            Register(CreateFoodSpell.m_SpellID,         typeof(CreateFoodSpell));
            Register(FeeblemindSpell.m_SpellID,         typeof(FeeblemindSpell));
            Register(HealSpell.m_SpellID,               typeof(HealSpell));
            Register(MagicArrowSpell.m_SpellID,         typeof(MagicArrowSpell));
            Register(NightSightSpell.m_SpellID,         typeof(NightSightSpell));
            Register(ReactiveArmorSpell.m_SpellID,      typeof(ReactiveArmorSpell));
            Register(WeakenSpell.m_SpellID,             typeof(WeakenSpell));

            // Second circle
            Register(AgilitySpell.m_SpellID,            typeof(AgilitySpell));
            Register(CunningSpell.m_SpellID,            typeof(CunningSpell));
            Register(CureSpell.m_SpellID,               typeof(CureSpell));
            Register(HarmSpell.m_SpellID,               typeof(HarmSpell));
            Register(MagicTrapSpell.m_SpellID,          typeof(MagicTrapSpell));
            Register(RemoveTrapSpell.m_SpellID,         typeof(RemoveTrapSpell));
            Register(ProtectionSpell.m_SpellID,         typeof(ProtectionSpell));
            Register(StrengthSpell.m_SpellID,           typeof(StrengthSpell));

            // Third circle
            Register(BlessSpell.m_SpellID,              typeof(BlessSpell));
            Register(FireballSpell.m_SpellID,           typeof(FireballSpell));
            Register(MagicLockSpell.m_SpellID,          typeof(MagicLockSpell));
            Register(PoisonSpell.m_SpellID,             typeof(PoisonSpell));
            Register(TelekinesisSpell.m_SpellID,        typeof(TelekinesisSpell));
            Register(TeleportSpell.m_SpellID,           typeof(TeleportSpell));
            Register(UnlockSpell.m_SpellID,             typeof(UnlockSpell));
            Register(WallOfStoneSpell.m_SpellID,        typeof(WallOfStoneSpell));

            // Fourth circle
            Register(ArchCureSpell.m_SpellID,           typeof(ArchCureSpell));
            Register(ArchProtectionSpell.m_SpellID,     typeof(ArchProtectionSpell));
            Register(CurseSpell.m_SpellID,              typeof(CurseSpell));
            Register(FireFieldSpell.m_SpellID,          typeof(FireFieldSpell));
            Register(GreaterHealSpell.m_SpellID,        typeof(GreaterHealSpell));
            Register(LightningSpell.m_SpellID,          typeof(LightningSpell));
            Register(ManaDrainSpell.m_SpellID,          typeof(ManaDrainSpell));
            Register(RecallSpell.m_SpellID,             typeof(RecallSpell));

            // Fifth circle
            Register(BladeSpiritsSpell.m_SpellID,       typeof(BladeSpiritsSpell));
            Register(DispelFieldSpell.m_SpellID,        typeof(DispelFieldSpell));
            Register(IncognitoSpell.m_SpellID,          typeof(IncognitoSpell));
            Register(MagicReflectSpell.m_SpellID,       typeof(MagicReflectSpell));
            Register(MindBlastSpell.m_SpellID,          typeof(MindBlastSpell));
            Register(ParalyzeSpell.m_SpellID,           typeof(ParalyzeSpell));
            Register(PoisonFieldSpell.m_SpellID,        typeof(PoisonFieldSpell));
            Register(SummonCreatureSpell.m_SpellID,     typeof(SummonCreatureSpell));

            // Sixth circle
            Register(DispelSpell.m_SpellID,             typeof(DispelSpell));
            Register(EnergyBoltSpell.m_SpellID,         typeof(EnergyBoltSpell));
            Register(ExplosionSpell.m_SpellID,          typeof(ExplosionSpell));
            Register(InvisibilitySpell.m_SpellID,       typeof(InvisibilitySpell));
            Register(MarkSpell.m_SpellID,               typeof(MarkSpell));
            Register(MassCurseSpell.m_SpellID,          typeof(MassCurseSpell));
            Register(ParalyzeFieldSpell.m_SpellID,      typeof(ParalyzeFieldSpell));
            Register(RevealSpell.m_SpellID,             typeof(RevealSpell));

            // Seventh circle
            Register(ChainLightningSpell.m_SpellID,     typeof(ChainLightningSpell));
            Register(EnergyFieldSpell.m_SpellID,        typeof(EnergyFieldSpell));
            Register(FlameStrikeSpell.m_SpellID,        typeof(FlameStrikeSpell));
            Register(GateTravelSpell.m_SpellID,         typeof(GateTravelSpell));
            Register(ManaVampireSpell.m_SpellID,        typeof(ManaVampireSpell));
            Register(MassDispelSpell.m_SpellID,         typeof(MassDispelSpell));
            Register(MeteorSwarmSpell.m_SpellID,        typeof(MeteorSwarmSpell));
            Register(PolymorphSpell.m_SpellID,          typeof(PolymorphSpell));

            // Eighth circle
            Register(EarthquakeSpell.m_SpellID,         typeof(EarthquakeSpell));
            Register(EnergyVortexSpell.m_SpellID,       typeof(EnergyVortexSpell));
            Register(ResurrectionSpell.m_SpellID,       typeof(ResurrectionSpell));
            Register(AirElementalSpell.m_SpellID,       typeof(AirElementalSpell));
            Register(SummonDaemonSpell.m_SpellID,       typeof(SummonDaemonSpell));
            Register(EarthElementalSpell.m_SpellID,     typeof(EarthElementalSpell));
            Register(FireElementalSpell.m_SpellID,      typeof(FireElementalSpell));
            Register(WaterElementalSpell.m_SpellID,     typeof(WaterElementalSpell));

            // Necromancy spells
            Register(AnimateDeadSpell.m_SpellID,        typeof(AnimateDeadSpell));
            Register(BloodOathSpell.m_SpellID,          typeof(BloodOathSpell));
            Register(CorpseSkinSpell.m_SpellID,         typeof(CorpseSkinSpell));
            Register(CurseWeaponSpell.m_SpellID,        typeof(CurseWeaponSpell));
            Register(EvilOmenSpell.m_SpellID,           typeof(EvilOmenSpell));
            Register(HorrificBeastSpell.m_SpellID,      typeof(HorrificBeastSpell));
            Register(LichFormSpell.m_SpellID,           typeof(LichFormSpell));
            Register(MindRotSpell.m_SpellID,            typeof(MindRotSpell));
            Register(PainSpikeSpell.m_SpellID,          typeof(PainSpikeSpell));
            Register(PoisonStrikeSpell.m_SpellID,       typeof(PoisonStrikeSpell));
            Register(StrangleSpell.m_SpellID,           typeof(StrangleSpell));
            Register(SummonFamiliarSpell.m_SpellID,     typeof(SummonFamiliarSpell));
            Register(VampiricEmbraceSpell.m_SpellID,    typeof(VampiricEmbraceSpell));
            Register(VengefulSpiritSpell.m_SpellID,     typeof(VengefulSpiritSpell));
            Register(WitherSpell.m_SpellID,             typeof(WitherSpell));
            Register(WraithFormSpell.m_SpellID,         typeof(WraithFormSpell));

            // Nouveaux
            Register(Voile.m_SpellID,                   typeof(Voile));
            Register(Bourrasque.m_SpellID,              typeof(Bourrasque));
            Register(Flameche.m_SpellID,                typeof(Flameche));
            Register(Froid.m_SpellID,                   typeof(Froid));
            Register(Tempete.m_SpellID,                 typeof(Tempete));
        }

		public static void Register( int spellID, Type type )
		{
			SpellRegistry.Register( spellID, type );
		}
	}
}