﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
	public class OutputView
	{
		public char ReadLine()
		{
			return Console.ReadKey().KeyChar;
		}
	}
}