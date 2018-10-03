using Sokoban.Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
	public class Truck : FieldDoublyDoublyLink
	{

		public Truck()
		{
			Type = "truck";
		}

		public void MoveChest()
		{
			throw new System.NotImplementedException();
		}

		public void MoveTruck()
		{
			throw new System.NotImplementedException();
		}
	}
}