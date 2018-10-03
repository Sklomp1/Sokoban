using Sokoban.Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
	public class Maze
	{
		public FieldDoublyDoublyLinkedList FieldDoublyDoublyLinkedList { get; set; }

		public Maze(int capacity)
		{
			FieldDoublyDoublyLinkedList = new FieldDoublyDoublyLinkedList();
			FieldDoublyDoublyLinkedList.RowFirst = new FieldDoublyDoublyLink[capacity];
		}

		private void SwapLinkWithNext()
		{
			FieldDoublyDoublyLink nextLink = FieldDoublyDoublyLinkedList.Truck.Next;


			nextLink.Next.Previous = FieldDoublyDoublyLinkedList.Truck;
			FieldDoublyDoublyLinkedList.Truck.Previous.Next = nextLink;
			FieldDoublyDoublyLinkedList.Truck.Next = nextLink.Next;
			nextLink.Next = FieldDoublyDoublyLinkedList.Truck;
			nextLink.Previous = FieldDoublyDoublyLinkedList.Truck.Previous;
			FieldDoublyDoublyLinkedList.Truck.Previous = nextLink;

			CorrectRechts();
		}

		private void SwapLinkWithPrevious()
		{
			FieldDoublyDoublyLink prevLink = FieldDoublyDoublyLinkedList.Truck.Previous;


			prevLink.Previous.Next = FieldDoublyDoublyLinkedList.Truck;
			FieldDoublyDoublyLinkedList.Truck.Next.Previous = prevLink;
			prevLink.Next = FieldDoublyDoublyLinkedList.Truck.Next;
			FieldDoublyDoublyLinkedList.Truck.Next = prevLink;
			FieldDoublyDoublyLinkedList.Truck.Previous = prevLink.Previous;
			prevLink.Previous = FieldDoublyDoublyLinkedList.Truck;

			CorrectLinks();
		}


		private void SwapLinkWithDown()
		{
			FieldDoublyDoublyLink downLink = FieldDoublyDoublyLinkedList.Truck.Down;


			downLink.Down.Up = FieldDoublyDoublyLinkedList.Truck;
			FieldDoublyDoublyLinkedList.Truck.Up.Down = downLink;
			FieldDoublyDoublyLinkedList.Truck.Down = downLink.Down;
			downLink.Down = FieldDoublyDoublyLinkedList.Truck;
			downLink.Up = FieldDoublyDoublyLinkedList.Truck.Up;
			FieldDoublyDoublyLinkedList.Truck.Up = downLink;

			CorrectDown();
		}



		private void SwapLinkWithUp()
		{
			FieldDoublyDoublyLink upLink = FieldDoublyDoublyLinkedList.Truck.Up;

			upLink.Up.Down = FieldDoublyDoublyLinkedList.Truck;
			FieldDoublyDoublyLinkedList.Truck.Down.Up = upLink;
			upLink.Down = FieldDoublyDoublyLinkedList.Truck.Down;
			FieldDoublyDoublyLinkedList.Truck.Down = upLink;
			FieldDoublyDoublyLinkedList.Truck.Up = upLink.Up;
			upLink.Up = FieldDoublyDoublyLinkedList.Truck;

			CorrectUp();
		}

		private void CorrectDown()
		{
			FieldDoublyDoublyLink oldNext = FieldDoublyDoublyLinkedList.Truck.Next;
			FieldDoublyDoublyLink oldPrev = FieldDoublyDoublyLinkedList.Truck.Previous;
			FieldDoublyDoublyLink newNext = FieldDoublyDoublyLinkedList.Truck.Up.Next;
			FieldDoublyDoublyLink newPrev = FieldDoublyDoublyLinkedList.Truck.Up.Previous;

			oldNext.Previous = FieldDoublyDoublyLinkedList.Truck.Up;
			oldPrev.Next = FieldDoublyDoublyLinkedList.Truck.Up;

			newNext.Previous = FieldDoublyDoublyLinkedList.Truck;
			newPrev.Next = FieldDoublyDoublyLinkedList.Truck;

			FieldDoublyDoublyLinkedList.Truck.Next = newNext;
			FieldDoublyDoublyLinkedList.Truck.Previous = newPrev;

			FieldDoublyDoublyLinkedList.Truck.Up.Next = oldNext;
			FieldDoublyDoublyLinkedList.Truck.Up.Previous = oldPrev;
		}

		private void CorrectUp()
		{
			FieldDoublyDoublyLink oldNext = FieldDoublyDoublyLinkedList.Truck.Next;
			FieldDoublyDoublyLink oldPrev = FieldDoublyDoublyLinkedList.Truck.Previous;
			FieldDoublyDoublyLink newNext = FieldDoublyDoublyLinkedList.Truck.Down.Next;
			FieldDoublyDoublyLink newPrev = FieldDoublyDoublyLinkedList.Truck.Down.Previous;

			oldNext.Previous = FieldDoublyDoublyLinkedList.Truck.Down;
			oldPrev.Next = FieldDoublyDoublyLinkedList.Truck.Down;

			newNext.Previous = FieldDoublyDoublyLinkedList.Truck;
			newPrev.Next = FieldDoublyDoublyLinkedList.Truck;

			FieldDoublyDoublyLinkedList.Truck.Next = newNext;
			FieldDoublyDoublyLinkedList.Truck.Previous = newPrev;

			FieldDoublyDoublyLinkedList.Truck.Down.Next = oldNext;
			FieldDoublyDoublyLinkedList.Truck.Down.Previous = oldPrev;
		}


		private void CorrectRechts()
		{
			FieldDoublyDoublyLink oldUp = FieldDoublyDoublyLinkedList.Truck.Up;
			FieldDoublyDoublyLink oldDown = FieldDoublyDoublyLinkedList.Truck.Down;
			FieldDoublyDoublyLink newUp = FieldDoublyDoublyLinkedList.Truck.Previous.Up;
			FieldDoublyDoublyLink newDown = FieldDoublyDoublyLinkedList.Truck.Previous.Down;

			oldUp.Down = FieldDoublyDoublyLinkedList.Truck.Previous;
			oldDown.Up = FieldDoublyDoublyLinkedList.Truck.Previous;

			newUp.Down = FieldDoublyDoublyLinkedList.Truck;
			newDown.Up = FieldDoublyDoublyLinkedList.Truck;

			FieldDoublyDoublyLinkedList.Truck.Up = newUp;
			FieldDoublyDoublyLinkedList.Truck.Down = newDown;

			FieldDoublyDoublyLinkedList.Truck.Previous.Down = oldDown;
			FieldDoublyDoublyLinkedList.Truck.Previous.Up = oldUp;
		}

		private void CorrectLinks()
		{
			FieldDoublyDoublyLink oldUp = FieldDoublyDoublyLinkedList.Truck.Up;
			FieldDoublyDoublyLink oldDown = FieldDoublyDoublyLinkedList.Truck.Down;
			FieldDoublyDoublyLink newUp = FieldDoublyDoublyLinkedList.Truck.Next.Up;
			FieldDoublyDoublyLink newDown = FieldDoublyDoublyLinkedList.Truck.Next.Down;

			oldUp.Down = FieldDoublyDoublyLinkedList.Truck.Next;
			oldDown.Up = FieldDoublyDoublyLinkedList.Truck.Next;

			newUp.Down = FieldDoublyDoublyLinkedList.Truck;
			newDown.Up = FieldDoublyDoublyLinkedList.Truck;

			FieldDoublyDoublyLinkedList.Truck.Up = newUp;
			FieldDoublyDoublyLinkedList.Truck.Down = newDown;

			FieldDoublyDoublyLinkedList.Truck.Next.Down = oldDown;
			FieldDoublyDoublyLinkedList.Truck.Next.Up = oldUp;
		}


		public void SwapFields(ConsoleKey ck)
		{
			switch (ck)
			{
				case ConsoleKey.UpArrow:
					SwapLinkWithUp();
					break;
				case ConsoleKey.DownArrow:
					SwapLinkWithDown();
					break;
				case ConsoleKey.LeftArrow:
					SwapLinkWithPrevious();
					break;
				case ConsoleKey.RightArrow:
					SwapLinkWithNext();
					break;
				default:
					break;
			}
		}

		public void AddField(FieldDoublyDoublyLink fieldType, int row)
		{
			if (fieldType.Type == "truck") FieldDoublyDoublyLinkedList.Truck = fieldType;
			if (FieldDoublyDoublyLinkedList.RowFirst[row] == null)
			{
				if (row == 0)
				{
					FieldDoublyDoublyLinkedList.RowFirst[row] = fieldType;
					FieldDoublyDoublyLinkedList.Last = fieldType;
				}
				else
				{
					FieldDoublyDoublyLinkedList.RowFirst[row] = fieldType;
					FieldDoublyDoublyLinkedList.RowFirst[row - 1].Down = fieldType;
					fieldType.Up = FieldDoublyDoublyLinkedList.RowFirst[row - 1];
					FieldDoublyDoublyLinkedList.Last = fieldType;
				}
			}
			else if (row == 0 && FieldDoublyDoublyLinkedList.RowFirst[row] != null)
			{
				fieldType.Previous = FieldDoublyDoublyLinkedList.Last;
				FieldDoublyDoublyLinkedList.Last.Next = fieldType;
				FieldDoublyDoublyLinkedList.Last = fieldType;
			}
			else
			{
				fieldType.Previous = FieldDoublyDoublyLinkedList.Last;
				FieldDoublyDoublyLinkedList.Last.Up.Next.Down = fieldType;
				fieldType.Up = FieldDoublyDoublyLinkedList.Last.Up.Next;
				FieldDoublyDoublyLinkedList.Last.Next = fieldType;
				FieldDoublyDoublyLinkedList.Last = fieldType;
			}
		}
	}
}