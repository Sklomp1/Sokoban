using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban.Model_Layer
{
	public abstract class MazePiece
	{
		public FieldDoublyDoublyLink Current { get; set; }

		abstract public void Move(ConsoleKey ck);
	}
}
