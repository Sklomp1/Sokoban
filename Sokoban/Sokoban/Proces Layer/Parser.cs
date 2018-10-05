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

		public int Destinations { get; set; }

		private OutputView outputView;

		public Parser()
		{
			outputView = new OutputView();
		}
		public Maze ParseMaze(char mazeNumber)
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
								fieldDoublyDoublyLink.Floor = new Normal();
								Maze.AddField(fieldDoublyDoublyLink, row);
								break;
							case '#':
								fieldDoublyDoublyLink.Floor = new Wall();
								Maze.AddField(fieldDoublyDoublyLink, row);

								break;
							case 'o':
								Chest chest = new Chest();
								fieldDoublyDoublyLink.Floor = new Normal();
								fieldDoublyDoublyLink.Floor.Chest = chest;
								Maze.AddField(fieldDoublyDoublyLink, row);
								chest.Current = fieldDoublyDoublyLink;

								break;
							case 'x':
								Maze.Destinations++;
								fieldDoublyDoublyLink.Floor = new Destination();
								Maze.AddField(fieldDoublyDoublyLink, row);
								break;
							case '@':
								Truck truck = new Truck();

								fieldDoublyDoublyLink.Floor = new Normal();
								fieldDoublyDoublyLink.Floor.Truck = truck;
								Maze.AddField(fieldDoublyDoublyLink, row);

								Maze.AddTruck(new Truck(), fieldDoublyDoublyLink);
								break;
							default:
								fieldDoublyDoublyLink.Floor = new Empty();
								Maze.AddField(fieldDoublyDoublyLink, row);
								break;
						}
					}
				}
			}
			catch (FileNotFoundException e)
			{
				outputView.FileNotFound(e.FileName);
			}
			return Maze;
		}
	}
}