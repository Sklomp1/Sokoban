using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban.Model_Layer
{
	public class FieldDoublyDoublyLinkedList
	{
		public FieldDoublyDoublyLink Last { get; set; }

		public FieldDoublyDoublyLink Truck { get; set; }

		public FieldDoublyDoublyLink[] RowFirst { get; set; }

	}
}
