using Sokoban.Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
	public class Wall : Floor
	{
		public Wall()
		{
			Type = "wall";
		}

		public override bool CanMoveTo()
		{
			return false;
		}

		public override void PlaceChest(Chest chest)
		{
			throw new NotImplementedException();
		}

		public override void PlaceTruck(Truck truck)
		{
			throw new NotImplementedException();
		}

		public override void RemoveChest()
		{
			throw new NotImplementedException();
		}

		public override void RemoveTruck()
		{
			throw new NotImplementedException();
		}
	}
}