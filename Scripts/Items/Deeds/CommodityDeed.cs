using System;
using Server.Targeting;
using Server.Network;

namespace Server.Items
{
	public interface ICommodity /* added IsDeedable prop so expansion-based deedables can determine true/false */
	{
		int DescriptionNumber{ get; }
		bool IsDeedable { get; }
	}
}