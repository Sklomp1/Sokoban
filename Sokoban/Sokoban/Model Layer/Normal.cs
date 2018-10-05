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
	}
}