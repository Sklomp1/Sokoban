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
						FieldDoublyDoublyLink fieldDoublyDoublyLink = new FieldDoublyDoublyLink();
						switch (c)
						{
							case '.':
								fieldDoublyDoublyLink.GamePiece = new Floor();
								Maze.AddField(fieldDoublyDoublyLink, row);
								break;
							case '#':
								fieldDoublyDoublyLink.GamePiece = new Wall();
								Maze.AddField(fieldDoublyDoublyLink, row);

								break;
							case 'o':
								fieldDoublyDoublyLink.GamePiece = new Floor();
								fieldDoublyDoublyLink.GamePiece.SetChest();

								Maze.AddField(fieldDoublyDoublyLink, row);
								break;
							case 'x':
								fieldDoublyDoublyLink.GamePiece = new Destination();
								Maze.AddField(fieldDoublyDoublyLink, row);
								break;
							case '@':
								fieldDoublyDoublyLink.GamePiece = new Floor();
								fieldDoublyDoublyLink.GamePiece.SetTruck();
								Maze.AddField(fieldDoublyDoublyLink, row);
								Truck truck = new Truck();
								Maze.AddTruck(new Truck(), fieldDoublyDoublyLink);
								break;
							default:
								fieldDoublyDoublyLink.GamePiece = new Empty();
								Maze.AddField(fieldDoublyDoublyLink, row);
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