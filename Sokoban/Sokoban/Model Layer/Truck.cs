using Sokoban.Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
	public class Truck : MazePiece
	{
		public override void Move(ConsoleKey ck)
		{
			FieldDoublyDoublyLink nextField;

			switch (ck)
			{
				case ConsoleKey.UpArrow:
					nextField = Current.Up;
					break;
				case ConsoleKey.DownArrow:
					nextField = Current.Down;
					break;
				case ConsoleKey.LeftArrow:
					nextField = Current.Previous;
					break;
				case ConsoleKey.RightArrow:
					nextField = Current.Next;
					break;
				default:
					return;
			}

			if (!nextField.Floor.CanMoveTo()) return;

			if (nextField.Floor.Chest != null)
			{
				nextField.Floor.Chest.Move(ck);

				if (nextField.Floor.Chest == null)
				{
					nextField.Floor.Truck = this;
					Current.Floor.Truck = null;
					Current = nextField;
				}
			}
			else
			{
				nextField.Floor.Truck = this;
				Current.Floor.Truck = null;
				Current = nextField;
			}
		}
	}
}