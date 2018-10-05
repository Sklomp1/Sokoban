using Sokoban.Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
	public class Controller
	{
		private InputView inputView;
		private OutputView outputView;
		private Parser parser;
		private Maze maze;

		public Controller()
		{
			inputView = new InputView();
			outputView = new OutputView();
			parser = new Parser();
		}

		public void StartGame()
		{
			outputView.WelcomeScreen();
			outputView.ChooseMaze();

			ParseMaze();
			ShowMaze();

			Play();
		}

		private void ParseMaze()
		{
			while(maze == null)
				maze = parser.ParseMaze(inputView.ReadLine());
		}

		private void ShowMaze()
		{
			string[] values = new string[maze.FieldDoublyDoublyLinkedList.RowFirst.Length];
			for (int i = 0; i < values.Length; i++)
			{

				FieldDoublyDoublyLink item = new FieldDoublyDoublyLink();
				item = maze.FieldDoublyDoublyLinkedList.RowFirst[i];

				while (item != null)
				{
					switch (item.Floor.Type)
					{
						case "floor":
							if (item.Floor.Truck != null)
								values[i] += '@';
							else if (item.Floor.Chest != null)
								values[i] += 'O';
							else
								values[i] += '.';
							break;
						case "destination":
							if (item.Floor.Truck != null)
								values[i] += '@';
							else if (item.Floor.Chest != null)
								values[i] += '0';
							else
								values[i] += 'X';
							break;
						case "wall":
							values[i] += '█';
							break;
						case "freefall":
							if (item.Floor.Truck != null)
								values[i] += '@';
							else if (item.Floor.Chest != null)
								values[i] += 'O';
							else
								values[i] += ' ';
							break;
						case "pitfall":
							if (item.Floor.Truck != null)
								values[i] += '@';
							else if (item.Floor.Chest != null)
								values[i] += 'O';
							else
								values[i] += '~';
							break;
						case "empty":
							values[i] += ' ';
							break;
						default:
							break;
					}
					item = item.Next;
				}
			}
			outputView.DisplayMaze(values);
		}

		private void Play()
		{
			bool play = true;
			while (play)
			{
				parser.Maze.MoveTruck(inputView.ReadKey());
				ShowMaze();
				play = CheckWinner();
			}
			Console.ReadLine();
		}

		private bool CheckWinner()
		{
			if (parser.Maze.Isfinished())
			{
				Console.WriteLine("You win the game!");
				return false;
			}
			return true;
		}
	}
}