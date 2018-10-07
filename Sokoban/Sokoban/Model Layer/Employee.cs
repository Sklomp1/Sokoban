using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban.Model_Layer
{
	public class Employee : MazePiece
	{
		bool asleep;

		public char Type { get; set; }

		public Employee()
		{
			Type = '$';
		}
		public override void Move(ConsoleKey ck)
		{
			if (asleep)
				WakeUp();
			else
				Sleep();

			if (asleep) return;

			FieldDoublyDoublyLink nextField;

			Random random = new Random();
			int randomNumber = random.Next(1, 5);
			switch (randomNumber)
			{
				case 1:
					nextField = Current.Up;
					break;
				case 2:
					nextField = Current.Down;
					break;
				case 3:
					nextField = Current.Previous;
					break;
				case 4:
					nextField = Current.Next;
					break;
				default:
					return;
			}

			if (!nextField.Floor.CanMoveTo() || nextField.Floor.Truck != null) return;

			if (nextField.Floor.Chest != null)
			{
				nextField.Floor.Chest.Move(ck);

				if (nextField.Floor.Chest == null)
				{
					nextField.Floor.PlaceEmployee(this);
					Current.Floor.RemoveEmployee();
					Current = nextField;
				}
			}
			else
			{
				nextField.Floor.PlaceEmployee(this);
				Current.Floor.RemoveEmployee();
				Current = nextField;
			}

		}

		private void WakeUp()
		{
			Random random = new Random();
			int randomNumber = random.Next(1, 11);

			if (randomNumber == 7)
			{
				asleep = false;
				Type = '$';
			}
		}

		private void Sleep()
		{
			Random random = new Random();
			int randomNumber = random.Next(1, 5);

			if (randomNumber == 1)
			{
				asleep = true;
				Type = 'Z';
			}
		}
	}
}
