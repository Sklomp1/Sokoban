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

		public int Destinations { get; set; }

		public Maze(int capacity)
		{
			FieldDoublyDoublyLinkedList = new FieldDoublyDoublyLinkedList();
			FieldDoublyDoublyLinkedList.RowFirst = new FieldDoublyDoublyLink[capacity];
		}

		public void MoveTruck(ConsoleKey ck)
		{
			Truck.Move(ck);
		}

		public bool Isfinished()
		{
			int amountOfChests = 0;
			for (int i = 0; i < FieldDoublyDoublyLinkedList.RowFirst.Length; i++)
			{
				FieldDoublyDoublyLink FDDL = FieldDoublyDoublyLinkedList.RowFirst[i];
				while (FDDL != null)
				{
					if (FDDL.Floor.Type == "destination")
					{
						if(FDDL.Floor.Chest != null)
							amountOfChests++;
					}
					FDDL = FDDL.Next;
				}
			}
			return amountOfChests == Destinations;
		}

		public void AddTruck(Truck truck, FieldDoublyDoublyLink field)
		{
			Truck = truck;
			truck.Current = field;
		}

		public void AddField(FieldDoublyDoublyLink fieldType, int row)
		{
			if (fieldType.Floor.Type == "truck") FieldDoublyDoublyLinkedList.Truck = fieldType;
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