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

		public void Addfield(FieldDoublyDoublyLink fieldType, int row)
		{
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
				ChangeFields(fieldType);
			}
		}
		private void ChangeFields(FieldDoublyDoublyLink fieldType)
		{
			fieldType.Previous = FieldDoublyDoublyLinkedList.Last;
			FieldDoublyDoublyLinkedList.Last.Up.Next.Down = fieldType;
			fieldType.Up = FieldDoublyDoublyLinkedList.Last.Up.Next;
			FieldDoublyDoublyLinkedList.Last.Next = fieldType;
			FieldDoublyDoublyLinkedList.Last = fieldType;
		}
	}
}