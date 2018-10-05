using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban.Model_Layer
{
	public class Pitfall : Floor
	{
		int lives = 3;

		public Pitfall()
		{
			Type = "pitfall";
		}
		public override bool CanMoveTo()
		{
			return true;
		}

		public override void PlaceChest(Chest chest)
		{
			if (lives <= 0)
			{
				Chest = null;
			}
			else
			{
				Chest = chest;
				if (--lives <= 0)
				{
					Type = "freefall";
				}
			}
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
