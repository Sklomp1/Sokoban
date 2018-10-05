using Sokoban.Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
	public class Normal : Floor
	{
		public Normal()
		{
			Type = "floor";
		}

		public override bool CanMoveTo()
		{
			return true;
		}

		public override void PlaceChest(Chest chest)
		{
			Chest = chest;
		}

		public override void PlaceTruck(Truck truck)
		{
			Truck = truck;
		}

		public override void RemoveChest()
		{
			Chest = null;
		}

		public override void RemoveTruck()
		{
			Truck = null;
		}
	}
}