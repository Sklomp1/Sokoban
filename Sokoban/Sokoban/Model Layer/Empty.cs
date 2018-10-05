using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban.Model_Layer
{
	class Empty : Floor
	{
		public Empty()
		{
			Type = "empty";
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
