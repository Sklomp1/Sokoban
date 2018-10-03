using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sokoban
{
	public class Parser
	{
		Maze maze = new Maze();

		public Parser()
		{

		}

		public void ParseMaze()
		{
			string[] lines = File.ReadAllLines("../../../Mazes/doolhof1.txt");

			foreach (string line in lines)
			{
				Console.WriteLine(line);
			}
		}

	}
}