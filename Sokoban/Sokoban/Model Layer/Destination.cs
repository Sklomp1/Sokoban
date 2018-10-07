using Sokoban.Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
	public class Destination : Floor
	{
		public Destination()
		{
			Type = "destination";
		}

		public override bool CanMoveTo()
		{
			return true;
		}

		public override void PlaceChest(Chest chest)
		{
			Chest = chest;
		}

		public override void PlaceEmployee(Employee employee)
		{
			Employee = employee;
		}

		public override void PlaceTruck(Truck truck)
		{
			Truck = truck;
		}

		public override void RemoveChest()
		{
			Chest = null;
		}

		public override void RemoveEmployee()
		{
			Employee = null;
		}

		public override void RemoveTruck()
		{
			Truck = null;
		}
	}
}