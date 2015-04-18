using System;
using Server.Network;
using Server.Mobiles;
using Server.Engines.Combat;

namespace Server
{
	public class CurrentExpansion
	{
        private static readonly Expansion Expansion = Expansion.AOS;

		public static void Configure()
		{
			Core.Expansion = Expansion;

			bool Enabled = Core.AOS;

			ObjectPropertyList.Enabled = Enabled;
			BaseMobile.VisibleDamageType = Enabled ? VisibleDamageType.Related : VisibleDamageType.None;
			Mobile.GuildClickMessage = !Enabled;
			Mobile.AsciiClickMessage = !Enabled;

			if ( Enabled )
			{
				AOS.DisableStatInfluences();

				if ( ObjectPropertyList.Enabled )
					PacketHandlers.SingleClickProps = true; // single click for everything is overriden to check object property list
			}
		}
	}
}
