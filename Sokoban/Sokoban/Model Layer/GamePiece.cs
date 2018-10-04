using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban.Model_Layer
{
	public abstract class GamePiece
	{
		public string Type { get; set; }

		public bool HasTruck { get; set; }
		public bool HasChest { get; set; }

		abstract public void SetTruck();
		abstract public void RemoveTruck();

		abstract public void SetChest();
		abstract public void RemoveChest();
	}
}
