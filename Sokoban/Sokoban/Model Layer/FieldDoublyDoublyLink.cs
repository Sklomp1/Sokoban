using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban.Model_Layer
{
	public class FieldDoublyDoublyLink
	{
		public Floor Floor { get; set; }
		public FieldDoublyDoublyLink Up { get; set; }
		public FieldDoublyDoublyLink Down { get; set; }
		public FieldDoublyDoublyLink Next { get; set; }
		public FieldDoublyDoublyLink Previous { get; set; }
	}
}
