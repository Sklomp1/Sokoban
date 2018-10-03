using Sokoban.Model_Layer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sokoban
{
	public class Parser
	{
		public Maze Maze { get; set; }

		public void ParseMaze(char mazeNumber)
		{
			try
			{
				string[] lines = File.ReadAllLines("../../../Mazes/doolhof" + mazeNumber + ".txt");
				Maze = new Maze(lines.Count());

				int row = -1;

				foreach (string line in lines)
				{
					row++;
					foreach (char c in line)
					{
						switch (c)
						{
							case '.':
								Maze.Addfield(new Floor(), row);
								break;
							case '#':
								Maze.Addfield(new Wall(), row);
								break;
							case 'o':
								Maze.Addfield(new Chest(), row);
								break;
							case 'x':
								Maze.Addfield(new Destination(), row);
								break;
							case '@':
								Maze.Addfield(new Truck(), row);
								break;
							default:
								Maze.Addfield(new Empty(), row);
								break;
						}
					}
				}
			}
			catch (FileNotFoundException e)
			{
				Console.WriteLine("Filename not found: " + e.FileName);
				Console.ReadLine();
				Environment.Exit(0);
			}
		}
	}
}