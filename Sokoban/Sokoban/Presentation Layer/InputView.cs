using Sokoban.Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
	public class InputView
	{

		public char ReadLine()
		{
			return Console.ReadKey(true).KeyChar;
		}

		public ConsoleKey ReadKey()
		{
			return Console.ReadKey(true).Key;
		}
	}
}