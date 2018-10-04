﻿using Sokoban.Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
	public class Destination : GamePiece
	{
		public Destination()
		{
			Type = "destination";
		}

		public override void RemoveChest()
		{
			HasChest = false;
		}

		public override void RemoveTruck()
		{
			HasTruck = false;
		}

		public override void SetChest()
		{
			HasChest = true;
		}

		public override void SetTruck()
		{
			HasTruck = true;
		}
	}
}