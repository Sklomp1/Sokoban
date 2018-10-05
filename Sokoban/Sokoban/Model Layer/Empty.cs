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
	}
}
