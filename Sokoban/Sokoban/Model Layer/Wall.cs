﻿using Sokoban.Model_Layer;
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
	}
}