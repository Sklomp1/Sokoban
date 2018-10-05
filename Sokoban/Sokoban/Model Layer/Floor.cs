using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban.Model_Layer
{
	public abstract class Floor
	{
		public string Type { get; set; }

		public Truck Truck { get; set; }
		public Chest Chest { get; set; }

		abstract public bool CanMoveTo();
	}
}
