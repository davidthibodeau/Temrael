using System;

namespace Server.Engines.Craft
{
	public class CraftAptitudeCol : System.Collections.CollectionBase
	{
        public CraftAptitudeCol()
		{
		}

        public void Add(CraftAptitude craftAptitude)
		{
            List.Add(craftAptitude);
		}

		public void Remove( int index )
		{
			if ( index > Count - 1 || index < 0 )
			{
			}
			else
			{
				List.RemoveAt( index );
			}
		}

        public CraftAptitude GetAt(int index)
		{
            return (CraftAptitude)List[index];
		}
	}
}