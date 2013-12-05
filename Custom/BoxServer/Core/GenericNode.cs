using System;
using System.Collections;
using System.Xml.Serialization;

namespace TheBox.Common
{
	/// <summary>
	/// Summary description for GenericNode.
	/// </summary>
	public class GenericNode : IComparable
	{
		private string m_Name;
		private ArrayList m_Elements;

		[ XmlAttribute ]
			/// <summary>
			/// Gets or sets the name of the node
			/// </summary>
		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		/// <summary>
		/// Gets or sets the subelements of this node
		/// </summary>
		public ArrayList Elements
		{
			get { return m_Elements; }
			set { m_Elements = value; }
		}

		/// <summary>
		/// Creates a new generic node object
		/// </summary>
		public GenericNode()
		{
			m_Elements = new ArrayList();
		}

		/// <summary>
		/// Creates a new generic node object
		/// </summary>
		/// <param name="name">The name of the node</param>
		public GenericNode( string name ) : this ()
		{
			m_Name = name;
		}

		#region IComparable Members

		public int CompareTo(object obj)
		{
			GenericNode node = obj as GenericNode;

			if ( node != null )
			{
				return m_Name.CompareTo( node.m_Name );
			}
			else
			{
				return 1;
			}
		}

		#endregion
	}
}