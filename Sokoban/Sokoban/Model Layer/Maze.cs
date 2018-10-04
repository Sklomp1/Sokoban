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

		public Truck Truck { get; set; }

		public Maze(int capacity)
		{
			FieldDoublyDoublyLinkedList = new FieldDoublyDoublyLinkedList();
			FieldDoublyDoublyLinkedList.RowFirst = new FieldDoublyDoublyLink[capacity];
		}

		public void SwapFields(ConsoleKey ck)
		{
			FieldDoublyDoublyLink nextField;
			FieldDoublyDoublyLink nextChestField;

			switch (ck)
			{
				case ConsoleKey.UpArrow:
					nextField = Truck.Current.Up;
					nextChestField = nextField.Up;
					break;
				case ConsoleKey.DownArrow:
					nextField = Truck.Current.Down;
					nextChestField = nextField.Down;
					break;
				case ConsoleKey.LeftArrow:
					nextField = Truck.Current.Previous;
					nextChestField = nextField.Previous;
					break;
				case ConsoleKey.RightArrow:
					nextField = Truck.Current.Next;
					nextChestField = nextField.Next;
					break;
				default:
					return;
			}
			if (nextField.GamePiece.Type == "wall")return;

			if (nextField.GamePiece.HasChest)
			{
				if (nextChestField.GamePiece.Type == "wall") return;
				nextChestField.GamePiece.SetChest();
				nextField.GamePiece.RemoveChest();
			}

			nextField.GamePiece.SetTruck();
			Truck.Current.GamePiece.RemoveTruck();

			Truck.Current = nextField;
		}

		public void AddTruck(Truck truck, FieldDoublyDoublyLink field)
		{
			Truck = truck;
			truck.Current = field;
		}

		public void AddField(FieldDoublyDoublyLink fieldType, int row)
		{
			if (fieldType.GamePiece.Type == "truck") FieldDoublyDoublyLinkedList.Truck = fieldType;
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