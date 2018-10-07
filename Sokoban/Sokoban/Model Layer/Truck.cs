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

			if (!nextField.Floor.CanMoveTo() || nextField.Floor.Employee != null) return;

			if (nextField.Floor.Chest != null)
			{
				nextField.Floor.Chest.Move(ck);

				if (nextField.Floor.Chest == null)
				{
					nextField.Floor.PlaceTruck(this);
					Current.Floor.RemoveTruck();
					Current = nextField;
				}
			}
			else
			{
				nextField.Floor.PlaceTruck(this);
				Current.Floor.RemoveTruck();
				Current = nextField;
			}
		}
	}
}