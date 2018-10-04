using Sokoban.Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
	public class Floor : FieldDoublyDoublyLink
	{
		public bool HasTruck { get; set; }

		public Floor(string type, bool isTruck)
		{
			Type = type;
			HasTruck = isTruck;
		}
	}
}