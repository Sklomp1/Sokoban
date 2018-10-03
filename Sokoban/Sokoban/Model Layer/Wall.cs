using Sokoban.Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
	public class Wall : FieldDoublyDoublyLink
	{
		public Wall()
		{
			Type = "wall";
		}

	}
}