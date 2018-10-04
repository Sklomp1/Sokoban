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
								Maze.AddField(new Floor("floor", false), row);
								break;
							case '#':
								Maze.AddField(new Wall(), row);
								break;
							case 'o':
								Maze.AddField(new Chest(), row);
								break;
							case 'x':
								Maze.AddField(new Destination(), row);
								break;
							case '@':
								Floor floor = new Floor("truck", true);

								Truck truck = new Truck
								{
									Current = floor
								};
								Maze.AddField(floor, row);
								break;
							default:
								Maze.AddField(new Empty(), row);
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